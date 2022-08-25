using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Sockets
{
	public class TcpServer
	{
		public int RecvBytes;

		public int SendBytes;

		public bool _IsListening;

		public TcpListener _listener;

		public ConcurrentDictionary<string, TcpClientSession> _sessions = new ConcurrentDictionary<string, TcpClientSession>();

		public IPEndPoint _ListenedEndPoint { get; private set; }

		public event EventHandler _ClientConnected;

		public event EventHandler _ClientDisconnected;

		public event EventHandler _ClientMessage;

		public TcpServer(int _listport)
		{
			this._ListenedEndPoint = new IPEndPoint(IPAddress.Any, _listport);
		}

		public void Listen()
		{
			try
			{
				if (this._IsListening)
				{
					this.ClientMessage("listen has started!", null);
					return;
				}
				this._listener = new TcpListener(this._ListenedEndPoint);
				this.SetSocketOptions();
				this._listener.Start();
				this._IsListening = true;
				this.ClientMessage("Port:" + this._ListenedEndPoint.Port + " Listener Started!", null);
				Task.Factory.StartNew((Func<Task>)async delegate
				{
					await this.Accept();
				}, TaskCreationOptions.LongRunning);
			}
			catch
			{
				this.ClientMessage("TcpServer failed to open!", null);
			}
		}

		private async Task Accept()
		{
			TcpServer tcpServer2 = this;
			try
			{
				while (true)
				{
					TcpServer tcpServer = tcpServer2;
					TcpClient tcpClient = await tcpServer2._listener.AcceptTcpClientAsync();
					await Task.Factory.StartNew((Func<Task>)async delegate
					{
						await tcpServer.AsyncClient(tcpClient);
					}, TaskCreationOptions.None);
				}
			}
			catch (Exception ex)
			{
				tcpServer2.ClientMessage(null, ex.Message + ex.StackTrace);
			}
		}

		private async Task AsyncClient(TcpClient acceptedTcpClient)
		{
			TcpServer tcpServer = this;
			TcpClientSession _ClientSession = new TcpClientSession(acceptedTcpClient, tcpServer);
			if (!tcpServer._sessions.TryAdd(_ClientSession._sessionKey, _ClientSession))
			{
				return;
			}
			try
			{
				await _ClientSession.AsyncClientRecv();
				_ClientSession = null;
			}
			catch
			{
			}
			finally
			{
				TcpClientSession value = null;
				if (_ClientSession != null)
				{
					tcpServer._sessions.TryRemove(_ClientSession._sessionKey, out value);
					tcpServer.ClientDisconnected(value, null);
				}
				GC.Collect();
			}
		}

		private void SetSocketOptions()
		{
			this._listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
		}

		public void ClientConnected(object sender, string message)
		{
			this._ClientConnected?.Invoke(sender, null);
		}

		public void ClientDisconnected(object sender, string message)
		{
			this._ClientDisconnected?.Invoke(sender, null);
		}

		public void ClientMessage(object sender, string message)
		{
			this._ClientMessage?.Invoke(sender, null);
		}

		public void Shutdown()
		{
			this._listener.Stop();
			this._listener = null;
		}
	}
}

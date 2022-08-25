using System;
using System.Collections.Generic;
using System.Text;
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.TCP;
using ZEDRatApp.ZEDRAT.Messages;

namespace ZEDRatApp.ZEDRAT.Module
{
	public class Remote_Startup_Manager
	{
		public Action<string, object> _FormExecute;

		public List<string> Startuplist = new List<string>();

		public List<byte> Processbyte = new List<byte>();

		public TcpClientSession _tcs;

		public Remote_Startup_Manager(TcpClientSession tcs)
		{
			this._tcs = tcs;
		}

		public void RemoteStartupExecute(TcpClientSession tcs, byte[] bt)
		{
			try
			{
				RemoteStartup_Messages remoteStartup_Messages = RemoteStartup_Messages.ByteToClass(bt);
				string shellDataType = remoteStartup_Messages._ShellDataType;
				switch (shellDataType)
				{
				case "result":
				case "ProcessPath":
					this._FormExecute(shellDataType, Encoding.ASCII.GetString(remoteStartup_Messages._Payload));
					break;
				case "Status":
					this._FormExecute("Status", Encoding.UTF8.GetString(remoteStartup_Messages._Payload));
					break;
				case "SetupEnd":
					this.CheckingProcesslist(remoteStartup_Messages._Payload, "SetupRefresh");
					break;
				case "End":
					this.CheckingProcesslist(remoteStartup_Messages._Payload, "Refresh");
					break;
				case "WindowRefresh":
					this._FormExecute("WindowRefresh", Serializable.Deserialize(GZip.Decompress(remoteStartup_Messages._Payload)) as string);
					break;
				case "Begin":
					this.Processbyte.AddRange(remoteStartup_Messages._Payload);
					break;
				}
			}
			catch (Exception ex)
			{
				this.Processbyte?.Clear();
				this.Startuplist?.Clear();
				this._FormExecute("Status", ex.Message);
			}
		}

		private void CheckingProcesslist(byte[] payload, string Refresh)
		{
			try
			{
				if (this.Processbyte.Count != BitConverter.ToInt32(payload, 0))
				{
					this._FormExecute("Status", "Failed to get the remote process list.");
					return;
				}
				this.Startuplist = Serializable.Deserialize(GZip.Decompress(this.Processbyte.ToArray())) as List<string>;
				this._FormExecute(Refresh, this.Startuplist);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.Processbyte?.Clear();
				this.Startuplist?.Clear();
			}
		}

		public void Remote_Startup_Send(string command, byte[] payload)
		{
			try
			{
				this._tcs.Client_Send(DataType.RemoteStartupType, RemoteStartup_Messages.ClassToByte(new RemoteStartup_Messages(command, payload)));
			}
			catch (Exception ex)
			{
				this._FormExecute("Status", ex.Message);
			}
		}

		public void destroy()
		{
			this._FormExecute = null;
			this._tcs = null;
			this.Startuplist?.Clear();
			this.Startuplist = null;
			this.Processbyte?.Clear();
			this.Processbyte = null;
		}
	}
}

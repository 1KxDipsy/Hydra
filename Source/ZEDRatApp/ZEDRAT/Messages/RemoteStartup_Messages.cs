using System.IO;

namespace ZEDRatApp.ZEDRAT.Messages
{
	internal class RemoteStartup_Messages
	{
		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteStartup_Messages()
		{
		}

		public RemoteStartup_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteStartup_Messages remoteStartup_Messages = (RemoteStartup_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteStartup_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteStartup_Messages._Payload.Length);
			binaryWriter.Write(remoteStartup_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteStartup_Messages ByteToClass(byte[] b)
		{
			RemoteStartup_Messages remoteStartup_Messages = new RemoteStartup_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteStartup_Messages._ShellDataType = binaryReader.ReadString();
			remoteStartup_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteStartup_Messages;
		}
	}
}

using System.IO;

namespace ZEDRatApp.ZEDRAT.Messages
{
	public class RemoteHydraST_Messages
	{
		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteHydraST_Messages()
		{
		}

		public RemoteHydraST_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteHydraST_Messages remoteHydraST_Messages = (RemoteHydraST_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteHydraST_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteHydraST_Messages._Payload.Length);
			binaryWriter.Write(remoteHydraST_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteHydraST_Messages ByteToClass(byte[] b)
		{
			RemoteHydraST_Messages remoteHydraST_Messages = new RemoteHydraST_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteHydraST_Messages._ShellDataType = binaryReader.ReadString();
			remoteHydraST_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteHydraST_Messages;
		}
	}
}

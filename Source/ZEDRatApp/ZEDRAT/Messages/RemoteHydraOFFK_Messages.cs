using System.IO;

namespace ZEDRatApp.ZEDRAT.Messages
{
	public class RemoteHydraOFFK_Messages
	{
		public string KeyboardType;

		public byte[] payload;

		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteHydraOFFK_Messages()
		{
		}

		public RemoteHydraOFFK_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteHydraOFFK_Messages remoteHydraOFFK_Messages = (RemoteHydraOFFK_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteHydraOFFK_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteHydraOFFK_Messages._Payload.Length);
			binaryWriter.Write(remoteHydraOFFK_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteHydraOFFK_Messages ByteToClass(byte[] b)
		{
			RemoteHydraOFFK_Messages remoteHydraOFFK_Messages = new RemoteHydraOFFK_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteHydraOFFK_Messages._ShellDataType = binaryReader.ReadString();
			remoteHydraOFFK_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteHydraOFFK_Messages;
		}
	}
}

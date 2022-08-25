using System.IO;

namespace ZEDRatApp.ZEDRAT.Messages
{
	public class RemoteHydra_Messages
	{
		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteHydra_Messages()
		{
		}

		public RemoteHydra_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteHydra_Messages remoteHydra_Messages = (RemoteHydra_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteHydra_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteHydra_Messages._Payload.Length);
			binaryWriter.Write(remoteHydra_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteHydra_Messages ByteToClass(byte[] b)
		{
			RemoteHydra_Messages remoteHydra_Messages = new RemoteHydra_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteHydra_Messages._ShellDataType = binaryReader.ReadString();
			remoteHydra_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteHydra_Messages;
		}
	}
}

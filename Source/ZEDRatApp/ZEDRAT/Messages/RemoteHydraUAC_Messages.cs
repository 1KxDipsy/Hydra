using System.IO;

namespace ZEDRatApp.ZEDRAT.Messages
{
	public class RemoteHydraUAC_Messages
	{
		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteHydraUAC_Messages()
		{
		}

		public RemoteHydraUAC_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteHydraUAC_Messages remoteHydraUAC_Messages = (RemoteHydraUAC_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteHydraUAC_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteHydraUAC_Messages._Payload.Length);
			binaryWriter.Write(remoteHydraUAC_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteHydraUAC_Messages ByteToClass(byte[] b)
		{
			RemoteHydraUAC_Messages remoteHydraUAC_Messages = new RemoteHydraUAC_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteHydraUAC_Messages._ShellDataType = binaryReader.ReadString();
			remoteHydraUAC_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteHydraUAC_Messages;
		}
	}
}

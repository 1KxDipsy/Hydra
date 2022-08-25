using System.IO;

namespace ZEDRAT.Messages
{
	public class RemoteProcess_Messages
	{
		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteProcess_Messages()
		{
		}

		public RemoteProcess_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteProcess_Messages remoteProcess_Messages = (RemoteProcess_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteProcess_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteProcess_Messages._Payload.Length);
			binaryWriter.Write(remoteProcess_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteProcess_Messages ByteToClass(byte[] b)
		{
			RemoteProcess_Messages remoteProcess_Messages = new RemoteProcess_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteProcess_Messages._ShellDataType = binaryReader.ReadString();
			remoteProcess_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteProcess_Messages;
		}
	}
}

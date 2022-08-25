using System.IO;

namespace ZEDRatApp.ZEDRAT.Messages
{
	public class RemoteHydraHRDP_Messages
	{
		public string _ShellDataType;

		public byte[] _Payload;

		public RemoteHydraHRDP_Messages()
		{
		}

		public RemoteHydraHRDP_Messages(string ShellDataType, byte[] Command)
		{
			this._ShellDataType = ShellDataType;
			this._Payload = Command;
		}

		public static byte[] ClassToByte(object ob)
		{
			RemoteHydraHRDP_Messages remoteHydraHRDP_Messages = (RemoteHydraHRDP_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remoteHydraHRDP_Messages._ShellDataType);
			binaryWriter.Write((uint)remoteHydraHRDP_Messages._Payload.Length);
			binaryWriter.Write(remoteHydraHRDP_Messages._Payload);
			return memoryStream.ToArray();
		}

		public static RemoteHydraHRDP_Messages ByteToClass(byte[] b)
		{
			RemoteHydraHRDP_Messages remoteHydraHRDP_Messages = new RemoteHydraHRDP_Messages();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remoteHydraHRDP_Messages._ShellDataType = binaryReader.ReadString();
			remoteHydraHRDP_Messages._Payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remoteHydraHRDP_Messages;
		}
	}
}

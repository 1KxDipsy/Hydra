using System.IO;

namespace Client
{
	public class TcpHeartPacket
	{
		public string _senssionSign;

		public int _PayloadSize;

		public int _DataType;

		public TcpHeartPacket()
		{
		}

		public TcpHeartPacket(string senssionSign, int PayloadSize, int DataType)
		{
			this._senssionSign = senssionSign;
			this._PayloadSize = PayloadSize;
			this._DataType = DataType;
		}

		public static byte[] StructToByte(object ob)
		{
			TcpHeartPacket tcpHeartPacket = (TcpHeartPacket)ob;
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(tcpHeartPacket._senssionSign);
			binaryWriter.Write(tcpHeartPacket._PayloadSize);
			binaryWriter.Write(tcpHeartPacket._DataType);
			return memoryStream.ToArray();
		}

		public static TcpHeartPacket ByteToStruct(byte[] b)
		{
			TcpHeartPacket tcpHeartPacket = new TcpHeartPacket();
			using MemoryStream input = new MemoryStream(b);
			using BinaryReader binaryReader = new BinaryReader(input);
			tcpHeartPacket._senssionSign = binaryReader.ReadString();
			tcpHeartPacket._PayloadSize = binaryReader.ReadInt32();
			tcpHeartPacket._DataType = binaryReader.ReadInt32();
			return tcpHeartPacket;
		}
	}
}

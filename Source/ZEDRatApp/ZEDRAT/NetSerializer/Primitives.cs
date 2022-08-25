using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace ZEDRatApp.ZEDRAT.NetSerializer
{
	public static class Primitives
	{
		private sealed class StringHelper
		{
			public const int BYTEBUFFERLEN = 256;

			public const int CHARBUFFERLEN = 128;

			private Encoder m_encoder;

			private Decoder m_decoder;

			private byte[] m_byteBuffer;

			private char[] m_charBuffer;

			public UTF8Encoding Encoding { get; private set; }

			public Encoder Encoder
			{
				get
				{
					if (this.m_encoder == null)
					{
						this.m_encoder = this.Encoding.GetEncoder();
					}
					return this.m_encoder;
				}
			}

			public Decoder Decoder
			{
				get
				{
					if (this.m_decoder == null)
					{
						this.m_decoder = this.Encoding.GetDecoder();
					}
					return this.m_decoder;
				}
			}

			public byte[] ByteBuffer
			{
				get
				{
					if (this.m_byteBuffer == null)
					{
						this.m_byteBuffer = new byte[256];
					}
					return this.m_byteBuffer;
				}
			}

			public char[] CharBuffer
			{
				get
				{
					if (this.m_charBuffer == null)
					{
						this.m_charBuffer = new char[128];
					}
					return this.m_charBuffer;
				}
			}

			public StringHelper()
			{
				this.Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
			}
		}

		[ThreadStatic]
		private static StringHelper s_stringHelper;

		private static readonly byte[] s_emptyByteArray = new byte[0];

		public static MethodInfo GetWritePrimitive(Type type)
		{
			return typeof(Primitives).GetMethod("WritePrimitive", BindingFlags.Static | BindingFlags.Public | BindingFlags.ExactBinding, null, new Type[2]
			{
				typeof(Stream),
				type
			}, null);
		}

		public static MethodInfo GetReaderPrimitive(Type type)
		{
			return typeof(Primitives).GetMethod("ReadPrimitive", BindingFlags.Static | BindingFlags.Public | BindingFlags.ExactBinding, null, new Type[2]
			{
				typeof(Stream),
				type.MakeByRefType()
			}, null);
		}

		private static uint EncodeZigZag32(int n)
		{
			return (uint)((n << 1) ^ (n >> 31));
		}

		private static ulong EncodeZigZag64(long n)
		{
			return (ulong)((n << 1) ^ (n >> 63));
		}

		private static int DecodeZigZag32(uint n)
		{
			return (int)((n >> 1) ^ (0 - (n & 1)));
		}

		private static long DecodeZigZag64(ulong n)
		{
			return (long)((n >> 1) ^ (0L - (n & 1)));
		}

		private static uint ReadVarint32(Stream stream)
		{
			int num = 0;
			for (int i = 0; i < 32; i += 7)
			{
				int num2 = stream.ReadByte();
				if (num2 == -1)
				{
					throw new EndOfStreamException();
				}
				num |= (num2 & 0x7F) << i;
				if ((num2 & 0x80) == 0)
				{
					return (uint)num;
				}
			}
			throw new InvalidDataException();
		}

		private static void WriteVarint32(Stream stream, uint value)
		{
			while (value >= 128)
			{
				stream.WriteByte((byte)(value | 0x80u));
				value >>= 7;
			}
			stream.WriteByte((byte)value);
		}

		private static ulong ReadVarint64(Stream stream)
		{
			long num = 0L;
			for (int i = 0; i < 64; i += 7)
			{
				int num2 = stream.ReadByte();
				if (num2 == -1)
				{
					throw new EndOfStreamException();
				}
				num |= (long)(num2 & 0x7F) << i;
				if ((num2 & 0x80) == 0)
				{
					return (ulong)num;
				}
			}
			throw new InvalidDataException();
		}

		private static void WriteVarint64(Stream stream, ulong value)
		{
			while (value >= 128)
			{
				stream.WriteByte((byte)(value | 0x80));
				value >>= 7;
			}
			stream.WriteByte((byte)value);
		}

		public static void WritePrimitive(Stream stream, bool value)
		{
			stream.WriteByte((byte)(value ? 1 : 0));
		}

		public static void ReadPrimitive(Stream stream, out bool value)
		{
			value = stream.ReadByte() != 0;
		}

		public static void WritePrimitive(Stream stream, byte value)
		{
			stream.WriteByte(value);
		}

		public static void ReadPrimitive(Stream stream, out byte value)
		{
			value = (byte)stream.ReadByte();
		}

		public static void WritePrimitive(Stream stream, sbyte value)
		{
			stream.WriteByte((byte)value);
		}

		public static void ReadPrimitive(Stream stream, out sbyte value)
		{
			value = (sbyte)stream.ReadByte();
		}

		public static void WritePrimitive(Stream stream, char value)
		{
			Primitives.WriteVarint32(stream, value);
		}

		public static void ReadPrimitive(Stream stream, out char value)
		{
			value = (char)Primitives.ReadVarint32(stream);
		}

		public static void WritePrimitive(Stream stream, ushort value)
		{
			Primitives.WriteVarint32(stream, value);
		}

		public static void ReadPrimitive(Stream stream, out ushort value)
		{
			value = (ushort)Primitives.ReadVarint32(stream);
		}

		public static void WritePrimitive(Stream stream, short value)
		{
			Primitives.WriteVarint32(stream, Primitives.EncodeZigZag32(value));
		}

		public static void ReadPrimitive(Stream stream, out short value)
		{
			value = (short)Primitives.DecodeZigZag32(Primitives.ReadVarint32(stream));
		}

		public static void WritePrimitive(Stream stream, uint value)
		{
			Primitives.WriteVarint32(stream, value);
		}

		public static void ReadPrimitive(Stream stream, out uint value)
		{
			value = Primitives.ReadVarint32(stream);
		}

		public static void WritePrimitive(Stream stream, int value)
		{
			Primitives.WriteVarint32(stream, Primitives.EncodeZigZag32(value));
		}

		public static void ReadPrimitive(Stream stream, out int value)
		{
			value = Primitives.DecodeZigZag32(Primitives.ReadVarint32(stream));
		}

		public static void WritePrimitive(Stream stream, ulong value)
		{
			Primitives.WriteVarint64(stream, value);
		}

		public static void ReadPrimitive(Stream stream, out ulong value)
		{
			value = Primitives.ReadVarint64(stream);
		}

		public static void WritePrimitive(Stream stream, long value)
		{
			Primitives.WriteVarint64(stream, Primitives.EncodeZigZag64(value));
		}

		public static void ReadPrimitive(Stream stream, out long value)
		{
			value = Primitives.DecodeZigZag64(Primitives.ReadVarint64(stream));
		}

		public unsafe static void WritePrimitive(Stream stream, float value)
		{
			Primitives.WriteVarint32(stream, *(uint*)(&value));
		}

		public unsafe static void ReadPrimitive(Stream stream, out float value)
		{
			uint num = Primitives.ReadVarint32(stream);
			value = *(float*)(&num);
		}

		public unsafe static void WritePrimitive(Stream stream, double value)
		{
			Primitives.WriteVarint64(stream, *(ulong*)(&value));
		}

		public unsafe static void ReadPrimitive(Stream stream, out double value)
		{
			ulong num = Primitives.ReadVarint64(stream);
			value = *(double*)(&num);
		}

		public static void WritePrimitive(Stream stream, DateTime value)
		{
			Primitives.WritePrimitive(stream, value.ToBinary());
		}

		public static void ReadPrimitive(Stream stream, out DateTime value)
		{
			Primitives.ReadPrimitive(stream, out long value2);
			value = DateTime.FromBinary(value2);
		}

		public unsafe static void WritePrimitive(Stream stream, string value)
		{
			if (value == null)
			{
				Primitives.WritePrimitive(stream, 0u);
				return;
			}
			if (value.Length == 0)
			{
				Primitives.WritePrimitive(stream, 1u);
				return;
			}
			StringHelper stringHelper = Primitives.s_stringHelper;
			if (stringHelper == null)
			{
				stringHelper = (Primitives.s_stringHelper = new StringHelper());
			}
			Encoder encoder = stringHelper.Encoder;
			byte[] byteBuffer = stringHelper.ByteBuffer;
			int length = value.Length;
			int byteCount;
			fixed (char* chars = value)
			{
				byteCount = encoder.GetByteCount(chars, length, flush: true);
			}
			Primitives.WritePrimitive(stream, (uint)(byteCount + 1));
			Primitives.WritePrimitive(stream, (uint)length);
			int num = 0;
			bool completed = false;
			while (!completed)
			{
				int charsUsed;
				int bytesUsed;
				fixed (char* ptr = value)
				{
					fixed (byte* bytes = byteBuffer)
					{
						encoder.Convert(ptr + num, length - num, bytes, byteBuffer.Length, flush: true, out charsUsed, out bytesUsed, out completed);
					}
				}
				stream.Write(byteBuffer, 0, bytesUsed);
				num += charsUsed;
			}
		}

		public static void ReadPrimitive(Stream stream, out string value)
		{
			Primitives.ReadPrimitive(stream, out uint value2);
			switch (value2)
			{
			case 0u:
				value = null;
				return;
			case 1u:
				value = string.Empty;
				return;
			}
			value2--;
			Primitives.ReadPrimitive(stream, out uint value3);
			StringHelper stringHelper = Primitives.s_stringHelper;
			if (stringHelper == null)
			{
				stringHelper = (Primitives.s_stringHelper = new StringHelper());
			}
			Decoder decoder = stringHelper.Decoder;
			byte[] byteBuffer = stringHelper.ByteBuffer;
			char[] array = ((value3 > 128) ? new char[value3] : stringHelper.CharBuffer);
			int num = (int)value2;
			int num2 = 0;
			while (num > 0)
			{
				int num3 = stream.Read(byteBuffer, 0, Math.Min(byteBuffer.Length, num));
				if (num3 == 0)
				{
					throw new EndOfStreamException();
				}
				num -= num3;
				bool flush = ((num == 0) ? true : false);
				bool completed = false;
				int num4 = 0;
				while (!completed)
				{
					decoder.Convert(byteBuffer, num4, num3 - num4, array, num2, (int)value3 - num2, flush, out var bytesUsed, out var charsUsed, out completed);
					num4 += bytesUsed;
					num2 += charsUsed;
				}
			}
			value = new string(array, 0, (int)value3);
		}

		public static void WritePrimitive(Stream stream, byte[] value)
		{
			if (value == null)
			{
				Primitives.WritePrimitive(stream, 0u);
				return;
			}
			Primitives.WritePrimitive(stream, (uint)(value.Length + 1));
			stream.Write(value, 0, value.Length);
		}

		public static void ReadPrimitive(Stream stream, out byte[] value)
		{
			Primitives.ReadPrimitive(stream, out uint value2);
			switch (value2)
			{
			case 0u:
				value = null;
				return;
			case 1u:
				value = Primitives.s_emptyByteArray;
				return;
			}
			value2--;
			value = new byte[value2];
			int num;
			for (int i = 0; i < value2; i += num)
			{
				num = stream.Read(value, i, (int)value2 - i);
				if (num == 0)
				{
					throw new EndOfStreamException();
				}
			}
		}
	}
}

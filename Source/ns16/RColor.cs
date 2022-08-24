using System;
using System.Text;

namespace ns16
{
	public struct RColor
	{
		public static readonly RColor Empty = default(RColor);

		private readonly long long_0;

		public static RColor Transparent => new RColor(0L);

		public static RColor Black => RColor.FromArgb(0, 0, 0);

		public static RColor White => RColor.FromArgb(255, 255, 255);

		public static RColor WhiteSmoke => RColor.FromArgb(245, 245, 245);

		public static RColor LightGray => RColor.FromArgb(211, 211, 211);

		public byte Byte_0 => (byte)((ulong)(this.long_0 >> 16) & 0xFFuL);

		public byte Byte_1 => (byte)((ulong)(this.long_0 >> 8) & 0xFFuL);

		public byte Byte_2 => (byte)((ulong)this.long_0 & 0xFFuL);

		public byte Byte_3 => (byte)((ulong)(this.long_0 >> 24) & 0xFFuL);

		public bool IsEmpty => this.long_0 == 0L;

		private RColor(long long_1)
		{
			this.long_0 = long_1;
		}

		public static bool operator ==(RColor left, RColor right)
		{
			return left.long_0 == right.long_0;
		}

		public static bool operator !=(RColor left, RColor right)
		{
			return !(left == right);
		}

		public static RColor FromArgb(int alpha, int red, int green, int blue)
		{
			RColor.smethod_0(alpha);
			RColor.smethod_0(red);
			RColor.smethod_0(green);
			RColor.smethod_0(blue);
			return new RColor((long)(uint)((red << 16) | (green << 8) | blue | (alpha << 24)) & 0xFFFFFFFFL);
		}

		public static RColor FromArgb(int red, int green, int blue)
		{
			return RColor.FromArgb(255, red, green, blue);
		}

		public unsafe override bool Equals(object obj)
		{
			if (obj is object obj2)
			{
				return this.long_0 == ((RColor*)(&obj2))->long_0;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return this.long_0.GetHashCode();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(32);
			stringBuilder.Append(base.GetType().Name);
			stringBuilder.Append(" [");
			if ((ulong)this.long_0 > 0uL)
			{
				stringBuilder.Append("A=");
				stringBuilder.Append(this.Byte_3);
				stringBuilder.Append(", R=");
				stringBuilder.Append(this.Byte_0);
				stringBuilder.Append(", G=");
				stringBuilder.Append(this.Byte_1);
				stringBuilder.Append(", B=");
				stringBuilder.Append(this.Byte_2);
			}
			else
			{
				stringBuilder.Append("Empty");
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		private static void smethod_0(int int_0)
		{
			if (int_0 < 0 || int_0 > 255)
			{
				throw new ArgumentException("InvalidEx2BoundArgument");
			}
		}
	}
}

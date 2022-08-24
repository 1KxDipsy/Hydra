using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ns0
{
	[CompilerGenerated]
	internal sealed class Class75
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 16)]
		private struct Struct3
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 24)]
		private struct Struct4
		{
		}

		internal static readonly Struct4 struct4_0/* Not supported: data(00 00 00 00 CD CC 4C 3E CD CC CC 3E 9A 99 19 3F CD CC 4C 3F 00 00 80 3F) */;

		internal static readonly Struct4 struct4_1/* Not supported: data(00 00 00 00 00 00 00 00 CD CC 4C 3E CD CC CC 3E 00 00 80 3F 00 00 80 3F) */;

		internal static readonly long long_0/* Not supported: data(7D 00 59 00 79 00 3D 00) */;

		internal static readonly Struct3 struct3_0/* Not supported: data(0D 00 0A 00 09 00 20 00 2D 00 21 00 3C 00 3E 00) */;

		internal static readonly Struct3 struct3_1/* Not supported: data(00 00 00 00 48 E1 FA 3E B8 1E 05 3F 00 00 80 3F) */;

		internal static readonly long long_1/* Not supported: data(7B 00 58 00 78 00 3D 00) */;

		internal static readonly Struct3 struct3_2/* Not supported: data(00 00 00 00 9A 99 19 3F A4 70 7D 3F 00 00 80 3F) */;

		internal static uint smethod_0(string string_0)
		{
			uint num = default(uint);
			if (string_0 != null)
			{
				num = 2166136261u;
				for (int i = 0; i < string_0.Length; i++)
				{
					num = (string_0[i] ^ num) * 16777619;
				}
			}
			return num;
		}
	}
}

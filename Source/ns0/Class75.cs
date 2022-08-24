using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ns0
{
	// Token: 0x02000148 RID: 328
	[CompilerGenerated]
	internal sealed class Class75
	{
		// Token: 0x060013E9 RID: 5097 RVA: 0x0004E8F8 File Offset: 0x0004CAF8
		internal static uint smethod_0(string string_0)
		{
			uint num;
			if (string_0 != null)
			{
				num = 2166136261U;
				for (int i = 0; i < string_0.Length; i++)
				{
					num = ((uint)string_0[i] ^ num) * 16777619U;
				}
			}
			return num;
		}

		// Token: 0x040008B5 RID: 2229 RVA: 0x00002150 File Offset: 0x00000350
		internal static readonly Class75.Struct4 struct4_0;

		// Token: 0x040008B6 RID: 2230 RVA: 0x00002168 File Offset: 0x00000368
		internal static readonly Class75.Struct4 struct4_1;

		// Token: 0x040008B7 RID: 2231 RVA: 0x00002180 File Offset: 0x00000380
		internal static readonly long long_0;

		// Token: 0x040008B8 RID: 2232 RVA: 0x00002188 File Offset: 0x00000388
		internal static readonly Class75.Struct3 struct3_0;

		// Token: 0x040008B9 RID: 2233 RVA: 0x00002198 File Offset: 0x00000398
		internal static readonly Class75.Struct3 struct3_1;

		// Token: 0x040008BA RID: 2234 RVA: 0x000021A8 File Offset: 0x000003A8
		internal static readonly long long_1;

		// Token: 0x040008BB RID: 2235 RVA: 0x000021B0 File Offset: 0x000003B0
		internal static readonly Class75.Struct3 struct3_2;

		// Token: 0x02000149 RID: 329
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 16)]
		internal struct Struct3
		{
		}

		// Token: 0x0200014A RID: 330
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 24)]
		internal struct Struct4
		{
		}
	}
}

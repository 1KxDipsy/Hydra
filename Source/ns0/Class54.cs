using System.Collections.Generic;

namespace ns0
{
	internal sealed class Class54 : Class50
	{
		private readonly Class50 class50_2;

		private readonly int int_0;

		private readonly int int_1;

		public Class50 Class50_2 => this.class50_2;

		public int Int32_0 => this.int_0;

		public int Int32_1 => this.int_1;

		public Class54(Class50 class50_3, ref Class50 class50_4, int int_2)
			: base(class50_3, new Class63("none", bool_1: false, new Dictionary<string, string> { { "colspan", "1" } }))
		{
			this.class50_2 = class50_4;
			base.String_41 = "none";
			this.int_0 = int_2;
			this.int_1 = int_2 + int.Parse(class50_4.method_14("rowspan", "1")) - 1;
		}
	}
}

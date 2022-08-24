using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class60 : Class59
	{
		private RImage rimage_0;

		private RRect rrect_1;

		public override RImage RImage_0
		{
			get
			{
				return this.rimage_0;
			}
			set
			{
				this.rimage_0 = value;
			}
		}

		public override bool Boolean_3 => true;

		public RRect RRect_1
		{
			get
			{
				return this.rrect_1;
			}
			set
			{
				this.rrect_1 = value;
			}
		}

		public Class60(Class50 class50_1)
			: base(class50_1)
		{
		}

		public override string ToString()
		{
			return "Image";
		}
	}
}

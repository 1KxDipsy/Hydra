using System.Drawing;
using ns14;

namespace ns0
{
	internal sealed class Class68 : RFontFamily
	{
		private readonly FontFamily fontFamily_0;

		public FontFamily FontFamily_0 => this.fontFamily_0;

		public override string Name => this.fontFamily_0.Name;

		public Class68(FontFamily fontFamily_1)
		{
			this.fontFamily_0 = fontFamily_1;
		}
	}
}

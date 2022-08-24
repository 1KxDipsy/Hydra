using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class52 : Class50
	{
		public Class52(Class50 class50_2, Class63 class63_1)
			: base(class50_2, class63_1)
		{
			base.String_41 = "block";
		}

		protected override void vmethod_4(RGraphics rgraphics_0)
		{
			if (!(base.String_41 == "none"))
			{
				base.method_30();
				Class50 @class = Class25.smethod_3(this);
				double x = base.Class50_1.RPoint_0.Double_0 + base.Class50_1.Double_10 + base.Double_15 + base.Class50_1.Double_19;
				double y = ((@class == null && base.Class50_0 != null) ? base.Class50_0.Double_4 : ((base.Class50_0 == null) ? base.RPoint_0.Double_1 : 0.0)) + base.method_20(@class) + ((@class != null) ? (@class.Double_2 + @class.Double_20) : 0.0);
				base.RPoint_0 = new RPoint(x, y);
				base.Double_2 = y;
				double num = base.method_15();
				double num2 = base.Class50_1.RSize_0.Width - base.Class50_1.Double_10 - base.Class50_1.Double_12 - base.Class50_1.Double_19 - base.Class50_1.Double_21 - base.Double_15 - base.Double_17 - base.Double_19 - base.Double_21;
				if (base.String_30 != "auto" && !string.IsNullOrEmpty(base.String_30))
				{
					num2 = Class31.smethod_4(base.String_30, num2, this);
				}
				if (num2 < num || num2 >= 9999.0)
				{
					num2 = num;
				}
				double num3 = base.Double_7;
				if (num3 < 1.0)
				{
					num3 = base.RSize_0.Height + base.Double_18 + base.Double_20;
				}
				if (num3 < 1.0)
				{
					num3 = 2.0;
				}
				if (num3 <= 2.0 && base.Double_18 < 1.0 && base.Double_20 < 1.0)
				{
					base.String_7 = (base.String_4 = "solid");
					base.String_3 = "1px";
					base.String_0 = "1px";
				}
				base.RSize_0 = new RSize(num2, num3);
				base.Double_2 = base.RPoint_0.Double_1 + base.Double_9 + base.Double_11 + num3;
			}
		}

		protected override void vmethod_6(RGraphics rgraphics_0)
		{
			RPoint rPoint = ((base.HtmlContainerInt_0 == null || this.Boolean_6) ? RPoint.Empty : base.HtmlContainerInt_0.ScrollOffset);
			RRect rrect_ = new RRect(base.RRect_0.Double_0 + rPoint.Double_0, base.RRect_0.Double_1 + rPoint.Double_1, base.RRect_0.Width, base.RRect_0.Height);
			if (rrect_.Height > 2.0 && Class28.smethod_0(base.RColor_5))
			{
				rgraphics_0.DrawRectangle(rgraphics_0.GetSolidBrush(base.RColor_5), rrect_.Double_0, rrect_.Double_1, rrect_.Width, rrect_.Height);
			}
			Class38.smethod_1(Enum2.const_0, rgraphics_0, this, rgraphics_0.GetSolidBrush(base.RColor_0), rrect_);
			if (rrect_.Height > 1.0)
			{
				Class38.smethod_1(Enum2.const_3, rgraphics_0, this, rgraphics_0.GetSolidBrush(base.RColor_1), rrect_);
				Class38.smethod_1(Enum2.const_1, rgraphics_0, this, rgraphics_0.GetSolidBrush(base.RColor_3), rrect_);
				Class38.smethod_1(Enum2.const_2, rgraphics_0, this, rgraphics_0.GetSolidBrush(base.RColor_2), rrect_);
			}
		}
	}
}

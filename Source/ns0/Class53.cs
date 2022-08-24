using System;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class53 : Class50
	{
		private readonly Class60 class60_0;

		private Class43 class43_1;

		private bool bool_2;

		public RImage RImage_0 => this.class60_0.RImage_0;

		public Class53(Class50 class50_2, Class63 class63_1)
			: base(class50_2, class63_1)
		{
			this.class60_0 = new Class60(this);
			base.List_3.Add(this.class60_0);
		}

		protected override void vmethod_6(RGraphics rgraphics_0)
		{
			if (this.class43_1 == null)
			{
				this.class43_1 = new Class43(base.HtmlContainerInt_0, new Delegate6<RImage, RRect, bool>(method_35));
				this.class43_1.method_0(base.method_13("src"), (base.Class63_0 != null) ? base.Class63_0.Dictionary_0 : null);
			}
			RRect rrect_ = Class22.smethod_5(base.Dictionary_0);
			RPoint pos = RPoint.Empty;
			if (!this.Boolean_6)
			{
				pos = base.HtmlContainerInt_0.ScrollOffset;
			}
			rrect_.Offset(pos);
			bool flag = Class28.smethod_1(rgraphics_0, this);
			base.method_26(rgraphics_0, rrect_, bool_2: true, bool_3: true);
			Class38.smethod_0(rgraphics_0, this, rrect_, bool_0: true, bool_1: true);
			RRect rRect_ = this.class60_0.RRect_0;
			rRect_.Offset(pos);
			rRect_.Height -= base.Double_18 + base.Double_20 + base.Double_9 + base.Double_11;
			rRect_.Double_1 += base.Double_18 + base.Double_9;
			rRect_.Double_0 = Math.Floor(rRect_.Double_0);
			rRect_.Double_1 = Math.Floor(rRect_.Double_1);
			if (this.class60_0.RImage_0 != null)
			{
				if (rRect_.Width > 0.0 && rRect_.Height > 0.0)
				{
					if (this.class60_0.RRect_1 == RRect.Empty)
					{
						rgraphics_0.DrawImage(this.class60_0.RImage_0, rRect_);
					}
					else
					{
						rgraphics_0.DrawImage(this.class60_0.RImage_0, rRect_, this.class60_0.RRect_1);
					}
					if (this.class60_0.Boolean_0)
					{
						rgraphics_0.DrawRectangle(base.method_33(rgraphics_0, bool_2: true), this.class60_0.Double_0 + pos.Double_0, this.class60_0.Double_1 + pos.Double_1, this.class60_0.Double_2 + 2.0, Class25.smethod_15(this.class60_0).Double_0);
					}
				}
			}
			else if (this.bool_2)
			{
				if (this.bool_2 && rRect_.Width > 19.0 && rRect_.Height > 19.0)
				{
					Class28.smethod_3(rgraphics_0, base.HtmlContainerInt_0, rRect_);
				}
			}
			else
			{
				Class28.smethod_2(rgraphics_0, base.HtmlContainerInt_0, rRect_);
				if (rRect_.Width > 19.0 && rRect_.Height > 19.0)
				{
					rgraphics_0.DrawRectangle(rgraphics_0.GetPen(RColor.LightGray), rRect_.Double_0, rRect_.Double_1, rRect_.Width, rRect_.Height);
				}
			}
			if (flag)
			{
				rgraphics_0.PopClip();
			}
		}

		internal override void vmethod_5(RGraphics rgraphics_0)
		{
			if (!base.bool_1)
			{
				if (this.class43_1 == null && (base.HtmlContainerInt_0.AvoidAsyncImagesLoading || base.HtmlContainerInt_0.AvoidImagesLateLoading))
				{
					this.class43_1 = new Class43(base.HtmlContainerInt_0, new Delegate6<RImage, RRect, bool>(method_35));
					if (base.String_40 != null && base.String_40 != "normal")
					{
						this.class43_1.method_0(base.String_40, (base.Class63_0 != null) ? base.Class63_0.Dictionary_0 : null);
					}
					else
					{
						this.class43_1.method_0(base.method_13("src"), (base.Class63_0 != null) ? base.Class63_0.Dictionary_0 : null);
					}
				}
				base.method_3(rgraphics_0);
				base.bool_1 = true;
			}
			Class55.smethod_0(this.class60_0);
		}

		public override void Dispose()
		{
			if (this.class43_1 != null)
			{
				this.class43_1.Dispose();
			}
			base.Dispose();
		}

		private void method_34()
		{
			base.method_2("solid", "2px", "#A0A0A0");
			base.String_10 = (base.String_8 = "#E3E3E3");
		}

		private void method_35(RImage rimage_0, RRect rrect_0, bool bool_3)
		{
			this.class60_0.RImage_0 = rimage_0;
			this.class60_0.RRect_1 = rrect_0;
			this.bool_2 = true;
			base.bool_1 = false;
			if (this.bool_2 && rimage_0 == null)
			{
				this.method_34();
			}
			if (!base.HtmlContainerInt_0.AvoidImagesLateLoading || bool_3)
			{
				Class57 @class = new Class57(base.String_30);
				Class57 class2 = new Class57(base.String_32);
				bool layout = @class.Double_0 <= 0.0 || @class.Enum3_0 != Enum3.const_2 || class2.Double_0 <= 0.0 || class2.Enum3_0 != Enum3.const_2;
				base.HtmlContainerInt_0.RequestRefresh(layout);
			}
		}
	}
}

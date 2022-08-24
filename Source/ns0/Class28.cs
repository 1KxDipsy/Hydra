using ns10;
using ns14;
using ns16;

namespace ns0
{
	internal static class Class28
	{
		public static bool smethod_0(RColor rcolor_0)
		{
			return rcolor_0.Byte_3 > 0;
		}

		public static bool smethod_1(RGraphics rgraphics_0, Class50 class50_0)
		{
			Class50 @class = class50_0.Class50_1;
			while (true)
			{
				if (!(@class.String_61 == "hidden"))
				{
					Class50 class50_ = @class.Class50_1;
					if (class50_ == @class)
					{
						break;
					}
					@class = class50_;
					continue;
				}
				RRect clip = rgraphics_0.GetClip();
				RRect rRect_ = class50_0.Class50_1.RRect_1;
				rRect_.Double_0 -= 2.0;
				rRect_.Width += 2.0;
				if (!class50_0.Boolean_6)
				{
					rRect_.Offset(class50_0.HtmlContainerInt_0.ScrollOffset);
				}
				rRect_.Intersect(clip);
				rgraphics_0.PushClip(rRect_);
				return true;
			}
			return false;
		}

		public static void smethod_2(RGraphics rgraphics_0, HtmlContainerInt htmlContainerInt_0, RRect rrect_0)
		{
			rgraphics_0.DrawRectangle(rgraphics_0.GetPen(RColor.LightGray), rrect_0.Left + 3.0, rrect_0.Top + 3.0, 13.0, 14.0);
			RImage loadingImage = htmlContainerInt_0.RAdapter_0.GetLoadingImage();
			rgraphics_0.DrawImage(loadingImage, new RRect(rrect_0.Left + 4.0, rrect_0.Top + 4.0, loadingImage.Width, loadingImage.Height));
		}

		public static void smethod_3(RGraphics rgraphics_0, HtmlContainerInt htmlContainerInt_0, RRect rrect_0)
		{
			rgraphics_0.DrawRectangle(rgraphics_0.GetPen(RColor.LightGray), rrect_0.Left + 2.0, rrect_0.Top + 2.0, 15.0, 15.0);
			RImage loadingFailedImage = htmlContainerInt_0.RAdapter_0.GetLoadingFailedImage();
			rgraphics_0.DrawImage(loadingFailedImage, new RRect(rrect_0.Left + 3.0, rrect_0.Top + 3.0, loadingFailedImage.Width, loadingFailedImage.Height));
		}

		public static RGraphicsPath smethod_4(RGraphics rgraphics_0, RRect rrect_0, double double_0, double double_1, double double_2, double double_3)
		{
			RGraphicsPath graphicsPath = rgraphics_0.GetGraphicsPath();
			graphicsPath.Start(rrect_0.Left + double_0, rrect_0.Top);
			graphicsPath.LineTo(rrect_0.Right - double_1, rrect_0.Double_1);
			if (double_1 > 0.0)
			{
				graphicsPath.ArcTo(rrect_0.Right, rrect_0.Top + double_1, double_1, RGraphicsPath.Corner.TopRight);
			}
			graphicsPath.LineTo(rrect_0.Right, rrect_0.Bottom - double_2);
			if (double_2 > 0.0)
			{
				graphicsPath.ArcTo(rrect_0.Right - double_2, rrect_0.Bottom, double_2, RGraphicsPath.Corner.BottomRight);
			}
			graphicsPath.LineTo(rrect_0.Left + double_3, rrect_0.Bottom);
			if (double_3 > 0.0)
			{
				graphicsPath.ArcTo(rrect_0.Left, rrect_0.Bottom - double_3, double_3, RGraphicsPath.Corner.BottomLeft);
			}
			graphicsPath.LineTo(rrect_0.Left, rrect_0.Top + double_0);
			if (double_0 > 0.0)
			{
				graphicsPath.ArcTo(rrect_0.Left + double_0, rrect_0.Top, double_0, RGraphicsPath.Corner.TopLeft);
			}
			return graphicsPath;
		}
	}
}

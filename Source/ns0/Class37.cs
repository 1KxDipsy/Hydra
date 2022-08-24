using System;
using ns14;
using ns16;

namespace ns0
{
	internal static class Class37
	{
		public static void smethod_0(RGraphics rgraphics_0, Class50 class50_0, Class43 class43_0, RRect rrect_0)
		{
			RSize rSize = new RSize((class43_0.RRect_0 == RRect.Empty) ? class43_0.RImage_0.Width : class43_0.RRect_0.Width, (class43_0.RRect_0 == RRect.Empty) ? class43_0.RImage_0.Height : class43_0.RRect_0.Height);
			RPoint location = Class37.smethod_1(class50_0.String_35, rrect_0, rSize);
			RRect rRect = ((class43_0.RRect_0 == RRect.Empty) ? new RRect(0.0, 0.0, rSize.Width, rSize.Height) : new RRect(class43_0.RRect_0.Left, class43_0.RRect_0.Top, rSize.Width, rSize.Height));
			RRect rRect2 = new RRect(location, rSize);
			RRect rect = rrect_0;
			rect.Intersect(rgraphics_0.GetClip());
			rgraphics_0.PushClip(rect);
			switch (class50_0.String_36)
			{
			default:
				Class37.smethod_4(rgraphics_0, class43_0, rrect_0, rRect, rRect2, rSize);
				break;
			case "repeat-y":
				Class37.smethod_3(rgraphics_0, class43_0, rrect_0, rRect, rRect2, rSize);
				break;
			case "repeat-x":
				Class37.smethod_2(rgraphics_0, class43_0, rrect_0, rRect, rRect2, rSize);
				break;
			case "no-repeat":
				rgraphics_0.DrawImage(class43_0.RImage_0, rRect2, rRect);
				break;
			}
			rgraphics_0.PopClip();
		}

		private static RPoint smethod_1(string string_0, RRect rrect_0, RSize rsize_0)
		{
			double x = rrect_0.Left;
			if (string_0.IndexOf("left", StringComparison.OrdinalIgnoreCase) > -1)
			{
				x = rrect_0.Left + 0.5;
			}
			else if (string_0.IndexOf("right", StringComparison.OrdinalIgnoreCase) > -1)
			{
				x = rrect_0.Right - rsize_0.Width;
			}
			else if (string_0.IndexOf("0", StringComparison.OrdinalIgnoreCase) < 0)
			{
				x = rrect_0.Left + (rrect_0.Width - rsize_0.Width) / 2.0 + 0.5;
			}
			double y = rrect_0.Top;
			if (string_0.IndexOf("top", StringComparison.OrdinalIgnoreCase) > -1)
			{
				y = rrect_0.Top;
			}
			else if (string_0.IndexOf("bottom", StringComparison.OrdinalIgnoreCase) > -1)
			{
				y = rrect_0.Bottom - rsize_0.Height;
			}
			else if (string_0.IndexOf("0", StringComparison.OrdinalIgnoreCase) < 0)
			{
				y = rrect_0.Top + (rrect_0.Height - rsize_0.Height) / 2.0 + 0.5;
			}
			return new RPoint(x, y);
		}

		private static void smethod_2(RGraphics rgraphics_0, Class43 class43_0, RRect rrect_0, RRect rrect_1, RRect rrect_2, RSize rsize_0)
		{
			while (rrect_2.Double_0 > rrect_0.Double_0)
			{
				rrect_2.Double_0 -= rsize_0.Width;
			}
			using RBrush brush = rgraphics_0.GetTextureBrush(class43_0.RImage_0, rrect_1, rrect_2.Location);
			rgraphics_0.DrawRectangle(brush, rrect_0.Double_0, rrect_2.Double_1, rrect_0.Width, rrect_1.Height);
		}

		private static void smethod_3(RGraphics rgraphics_0, Class43 class43_0, RRect rrect_0, RRect rrect_1, RRect rrect_2, RSize rsize_0)
		{
			while (rrect_2.Double_1 > rrect_0.Double_1)
			{
				rrect_2.Double_1 -= rsize_0.Height;
			}
			using RBrush brush = rgraphics_0.GetTextureBrush(class43_0.RImage_0, rrect_1, rrect_2.Location);
			rgraphics_0.DrawRectangle(brush, rrect_2.Double_0, rrect_0.Double_1, rrect_1.Width, rrect_0.Height);
		}

		private static void smethod_4(RGraphics rgraphics_0, Class43 class43_0, RRect rrect_0, RRect rrect_1, RRect rrect_2, RSize rsize_0)
		{
			while (rrect_2.Double_0 > rrect_0.Double_0)
			{
				rrect_2.Double_0 -= rsize_0.Width;
			}
			while (rrect_2.Double_1 > rrect_0.Double_1)
			{
				rrect_2.Double_1 -= rsize_0.Height;
			}
			using RBrush brush = rgraphics_0.GetTextureBrush(class43_0.RImage_0, rrect_1, rrect_2.Location);
			rgraphics_0.DrawRectangle(brush, rrect_0.Double_0, rrect_0.Double_1, rrect_0.Width, rrect_0.Height);
		}
	}
}

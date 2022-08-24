using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ns4
{
	public static class GraphicsHelper
	{
		public static Color GetColorScale(int passentage, Color color1, Color color2)
		{
			Color color3 = color1;
			Color color4 = color2;
			if (color3 == color4)
			{
				return color3;
			}
			if (passentage < 100)
			{
				if (color3 == Color.Transparent)
				{
					color3 = Color.Empty;
				}
				if (color4 == Color.Transparent)
				{
					color4 = Color.Empty;
				}
			}
			int a = color3.A;
			int r = color3.R;
			int g = color3.G;
			int b = color3.B;
			int a2 = color4.A;
			int r2 = color4.R;
			int g2 = color4.G;
			return Color.FromArgb(blue: (int)Math.Round((double)b + (double)checked((unchecked((int)color4.B) - b) * passentage) * 0.01), alpha: (int)Math.Round((double)a + (double)checked((a2 - a) * passentage) * 0.01, 0), red: (int)Math.Round((double)r + (double)checked((r2 - r) * passentage) * 0.01), green: (int)Math.Round((double)g + (double)checked((g2 - g) * passentage) * 0.01, 0));
		}

		public static Bitmap ImageReplaceColor(Image image, Color oldColor, Color newColor)
		{
			Bitmap bitmap = new Bitmap(image.Width, image.Height);
			GraphicsHelper.smethod_0(Graphics.FromImage(bitmap), image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), oldColor, newColor);
			return bitmap;
		}

		internal static void smethod_0(Graphics graphics_0, Image image_0, Rectangle rectangle_0, Color color_0, Color color_1)
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(new ColorMap[1]
			{
				new ColorMap
				{
					OldColor = color_0,
					NewColor = color_1
				}
			}, ColorAdjustType.Bitmap);
			graphics_0.DrawImage(image_0, rectangle_0, 0, 0, image_0.Width, image_0.Height, GraphicsUnit.Pixel, imageAttributes, null, IntPtr.Zero);
			imageAttributes.Dispose();
		}
	}
}

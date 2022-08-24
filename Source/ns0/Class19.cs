using System;
using System.Drawing;
using System.Windows.Forms;
using ns16;

namespace ns0
{
	internal static class Class19
	{
		public static RPoint smethod_0(PointF pointF_0)
		{
			return new RPoint(pointF_0.X, pointF_0.Y);
		}

		public static PointF[] smethod_1(RPoint[] rpoint_0)
		{
			PointF[] array = new PointF[rpoint_0.Length];
			for (int i = 0; i < rpoint_0.Length; i++)
			{
				array[i] = Class19.smethod_2(rpoint_0[i]);
			}
			return array;
		}

		public static PointF smethod_2(RPoint rpoint_0)
		{
			return new PointF((float)rpoint_0.Double_0, (float)rpoint_0.Double_1);
		}

		public static Point smethod_3(RPoint rpoint_0)
		{
			return new Point((int)Math.Round(rpoint_0.Double_0), (int)Math.Round(rpoint_0.Double_1));
		}

		public static RSize smethod_4(SizeF sizeF_0)
		{
			return new RSize(sizeF_0.Width, sizeF_0.Height);
		}

		public static SizeF smethod_5(RSize rsize_0)
		{
			return new SizeF((float)rsize_0.Width, (float)rsize_0.Height);
		}

		public static Size smethod_6(RSize rsize_0)
		{
			return new Size((int)Math.Round(rsize_0.Width), (int)Math.Round(rsize_0.Height));
		}

		public static RRect smethod_7(RectangleF rectangleF_0)
		{
			return new RRect(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
		}

		public static RectangleF smethod_8(RRect rrect_0)
		{
			return new RectangleF((float)rrect_0.Double_0, (float)rrect_0.Double_1, (float)rrect_0.Width, (float)rrect_0.Height);
		}

		public static Rectangle smethod_9(RRect rrect_0)
		{
			return new Rectangle((int)Math.Round(rrect_0.Double_0), (int)Math.Round(rrect_0.Double_1), (int)Math.Round(rrect_0.Width), (int)Math.Round(rrect_0.Height));
		}

		public static RColor smethod_10(Color color_0)
		{
			return RColor.FromArgb(color_0.A, color_0.R, color_0.G, color_0.B);
		}

		public static Color smethod_11(RColor rcolor_0)
		{
			return Color.FromArgb(rcolor_0.Byte_3, rcolor_0.Byte_0, rcolor_0.Byte_1, rcolor_0.Byte_2);
		}

		public static Graphics smethod_12(Control control_0)
		{
			return control_0.CreateGraphics();
		}
	}
}

using System;
using ns14;
using ns16;

namespace ns0
{
	internal static class Class38
	{
		private static readonly RPoint[] rpoint_0 = new RPoint[4];

		public static void smethod_0(RGraphics rgraphics_0, Class50 class50_0, RRect rrect_0, bool bool_0, bool bool_1)
		{
			if (rrect_0.Width > 0.0 && rrect_0.Height > 0.0)
			{
				if (!string.IsNullOrEmpty(class50_0.String_7) && !(class50_0.String_7 == "none") && !(class50_0.String_7 == "hidden") && class50_0.Double_18 > 0.0)
				{
					Class38.smethod_2(Enum2.const_0, class50_0, rgraphics_0, rrect_0, bool_0, bool_1);
				}
				if (bool_0 && !string.IsNullOrEmpty(class50_0.String_5) && !(class50_0.String_5 == "none") && !(class50_0.String_5 == "hidden") && class50_0.Double_19 > 0.0)
				{
					Class38.smethod_2(Enum2.const_3, class50_0, rgraphics_0, rrect_0, bool_0: true, bool_1);
				}
				if (!string.IsNullOrEmpty(class50_0.String_4) && !(class50_0.String_4 == "none") && !(class50_0.String_4 == "hidden") && class50_0.Double_20 > 0.0)
				{
					Class38.smethod_2(Enum2.const_2, class50_0, rgraphics_0, rrect_0, bool_0, bool_1);
				}
				if (bool_1 && !string.IsNullOrEmpty(class50_0.String_6) && !(class50_0.String_6 == "none") && !(class50_0.String_6 == "hidden") && class50_0.Double_21 > 0.0)
				{
					Class38.smethod_2(Enum2.const_1, class50_0, rgraphics_0, rrect_0, bool_0, bool_1: true);
				}
			}
		}

		public static void smethod_1(Enum2 enum2_0, RGraphics rgraphics_0, Class50 class50_0, RBrush rbrush_0, RRect rrect_0)
		{
			Class38.smethod_3(enum2_0, class50_0, rrect_0, bool_0: true, bool_1: true);
			rgraphics_0.DrawPolygon(rbrush_0, Class38.rpoint_0);
		}

		private static void smethod_2(Enum2 enum2_0, Class50 class50_0, RGraphics rgraphics_0, RRect rrect_0, bool bool_0, bool bool_1)
		{
			string text = Class38.smethod_8(enum2_0, class50_0);
			RColor rColor = Class38.smethod_6(enum2_0, class50_0, text);
			RGraphicsPath rGraphicsPath = Class38.smethod_4(rgraphics_0, enum2_0, class50_0, rrect_0);
			if (rGraphicsPath != null)
			{
				object prevMode = null;
				if (class50_0.HtmlContainerInt_0 != null && !class50_0.HtmlContainerInt_0.AvoidGeometryAntialias && class50_0.Boolean_0)
				{
					prevMode = rgraphics_0.SetAntiAliasSmoothingMode();
				}
				RPen pen = Class38.smethod_5(rgraphics_0, text, rColor, Class38.smethod_7(enum2_0, class50_0));
				using (rGraphicsPath)
				{
					rgraphics_0.DrawPath(pen, rGraphicsPath);
				}
				rgraphics_0.ReturnPreviousSmoothingMode(prevMode);
			}
			else if (!(text == "inset") && !(text == "outset"))
			{
				RPen pen2 = Class38.smethod_5(rgraphics_0, text, rColor, Class38.smethod_7(enum2_0, class50_0));
				switch (enum2_0)
				{
				case Enum2.const_0:
					rgraphics_0.DrawLine(pen2, Math.Ceiling(rrect_0.Left), rrect_0.Top + class50_0.Double_18 / 2.0, rrect_0.Right - 1.0, rrect_0.Top + class50_0.Double_18 / 2.0);
					break;
				case Enum2.const_1:
					rgraphics_0.DrawLine(pen2, rrect_0.Right - class50_0.Double_21 / 2.0, Math.Ceiling(rrect_0.Top), rrect_0.Right - class50_0.Double_21 / 2.0, Math.Floor(rrect_0.Bottom));
					break;
				case Enum2.const_2:
					rgraphics_0.DrawLine(pen2, Math.Ceiling(rrect_0.Left), rrect_0.Bottom - class50_0.Double_20 / 2.0, rrect_0.Right - 1.0, rrect_0.Bottom - class50_0.Double_20 / 2.0);
					break;
				case Enum2.const_3:
					rgraphics_0.DrawLine(pen2, rrect_0.Left + class50_0.Double_19 / 2.0, Math.Ceiling(rrect_0.Top), rrect_0.Left + class50_0.Double_19 / 2.0, Math.Floor(rrect_0.Bottom));
					break;
				}
			}
			else
			{
				Class38.smethod_3(enum2_0, class50_0, rrect_0, bool_0, bool_1);
				rgraphics_0.DrawPolygon(rgraphics_0.GetSolidBrush(rColor), Class38.rpoint_0);
			}
		}

		private static void smethod_3(Enum2 enum2_0, Class50 class50_0, RRect rrect_0, bool bool_0, bool bool_1)
		{
			switch (enum2_0)
			{
			case Enum2.const_0:
				Class38.rpoint_0[0] = new RPoint(rrect_0.Left, rrect_0.Top);
				Class38.rpoint_0[1] = new RPoint(rrect_0.Right, rrect_0.Top);
				Class38.rpoint_0[2] = new RPoint(rrect_0.Right, rrect_0.Top + class50_0.Double_18);
				Class38.rpoint_0[3] = new RPoint(rrect_0.Left, rrect_0.Top + class50_0.Double_18);
				if (bool_1)
				{
					Class38.rpoint_0[2].Double_0 -= class50_0.Double_21;
				}
				if (bool_0)
				{
					Class38.rpoint_0[3].Double_0 += class50_0.Double_19;
				}
				break;
			case Enum2.const_1:
				Class38.rpoint_0[0] = new RPoint(rrect_0.Right - class50_0.Double_21, rrect_0.Top + class50_0.Double_18);
				Class38.rpoint_0[1] = new RPoint(rrect_0.Right, rrect_0.Top);
				Class38.rpoint_0[2] = new RPoint(rrect_0.Right, rrect_0.Bottom);
				Class38.rpoint_0[3] = new RPoint(rrect_0.Right - class50_0.Double_21, rrect_0.Bottom - class50_0.Double_20);
				break;
			case Enum2.const_2:
				Class38.rpoint_0[0] = new RPoint(rrect_0.Left, rrect_0.Bottom - class50_0.Double_20);
				Class38.rpoint_0[1] = new RPoint(rrect_0.Right, rrect_0.Bottom - class50_0.Double_20);
				Class38.rpoint_0[2] = new RPoint(rrect_0.Right, rrect_0.Bottom);
				Class38.rpoint_0[3] = new RPoint(rrect_0.Left, rrect_0.Bottom);
				if (bool_0)
				{
					Class38.rpoint_0[0].Double_0 += class50_0.Double_19;
				}
				if (bool_1)
				{
					Class38.rpoint_0[1].Double_0 -= class50_0.Double_21;
				}
				break;
			case Enum2.const_3:
				Class38.rpoint_0[0] = new RPoint(rrect_0.Left, rrect_0.Top);
				Class38.rpoint_0[1] = new RPoint(rrect_0.Left + class50_0.Double_19, rrect_0.Top + class50_0.Double_18);
				Class38.rpoint_0[2] = new RPoint(rrect_0.Left + class50_0.Double_19, rrect_0.Bottom - class50_0.Double_20);
				Class38.rpoint_0[3] = new RPoint(rrect_0.Left, rrect_0.Bottom);
				break;
			}
		}

		private static RGraphicsPath smethod_4(RGraphics rgraphics_0, Enum2 enum2_0, Class50 class50_0, RRect rrect_0)
		{
			RGraphicsPath rGraphicsPath = null;
			switch (enum2_0)
			{
			case Enum2.const_0:
				if (class50_0.Double_22 > 0.0 || class50_0.Double_23 > 0.0)
				{
					rGraphicsPath = rgraphics_0.GetGraphicsPath();
					rGraphicsPath.Start(rrect_0.Left + class50_0.Double_19 / 2.0, rrect_0.Top + class50_0.Double_18 / 2.0 + class50_0.Double_22);
					if (class50_0.Double_22 > 0.0)
					{
						rGraphicsPath.ArcTo(rrect_0.Left + class50_0.Double_19 / 2.0 + class50_0.Double_22, rrect_0.Top + class50_0.Double_18 / 2.0, class50_0.Double_22, RGraphicsPath.Corner.TopLeft);
					}
					rGraphicsPath.LineTo(rrect_0.Right - class50_0.Double_21 / 2.0 - class50_0.Double_23, rrect_0.Top + class50_0.Double_18 / 2.0);
					if (class50_0.Double_23 > 0.0)
					{
						rGraphicsPath.ArcTo(rrect_0.Right - class50_0.Double_21 / 2.0, rrect_0.Top + class50_0.Double_18 / 2.0 + class50_0.Double_23, class50_0.Double_23, RGraphicsPath.Corner.TopRight);
					}
				}
				break;
			case Enum2.const_1:
				if (class50_0.Double_23 > 0.0 || class50_0.Double_24 > 0.0)
				{
					rGraphicsPath = rgraphics_0.GetGraphicsPath();
					bool flag3 = class50_0.String_7 == "none" || class50_0.String_7 == "hidden";
					bool flag4 = class50_0.String_4 == "none" || class50_0.String_4 == "hidden";
					rGraphicsPath.Start(rrect_0.Right - class50_0.Double_21 / 2.0 - (flag3 ? class50_0.Double_23 : 0.0), rrect_0.Top + class50_0.Double_18 / 2.0 + (flag3 ? 0.0 : class50_0.Double_23));
					if (class50_0.Double_23 > 0.0 && flag3)
					{
						rGraphicsPath.ArcTo(rrect_0.Right - class50_0.Double_19 / 2.0, rrect_0.Top + class50_0.Double_18 / 2.0 + class50_0.Double_23, class50_0.Double_23, RGraphicsPath.Corner.TopRight);
					}
					rGraphicsPath.LineTo(rrect_0.Right - class50_0.Double_21 / 2.0, rrect_0.Bottom - class50_0.Double_20 / 2.0 - class50_0.Double_24);
					if (class50_0.Double_24 > 0.0 && flag4)
					{
						rGraphicsPath.ArcTo(rrect_0.Right - class50_0.Double_21 / 2.0 - class50_0.Double_24, rrect_0.Bottom - class50_0.Double_20 / 2.0, class50_0.Double_24, RGraphicsPath.Corner.BottomRight);
					}
				}
				break;
			case Enum2.const_2:
				if (class50_0.Double_25 > 0.0 || class50_0.Double_24 > 0.0)
				{
					rGraphicsPath = rgraphics_0.GetGraphicsPath();
					rGraphicsPath.Start(rrect_0.Right - class50_0.Double_21 / 2.0, rrect_0.Bottom - class50_0.Double_20 / 2.0 - class50_0.Double_24);
					if (class50_0.Double_24 > 0.0)
					{
						rGraphicsPath.ArcTo(rrect_0.Right - class50_0.Double_21 / 2.0 - class50_0.Double_24, rrect_0.Bottom - class50_0.Double_20 / 2.0, class50_0.Double_24, RGraphicsPath.Corner.BottomRight);
					}
					rGraphicsPath.LineTo(rrect_0.Left + class50_0.Double_19 / 2.0 + class50_0.Double_25, rrect_0.Bottom - class50_0.Double_20 / 2.0);
					if (class50_0.Double_25 > 0.0)
					{
						rGraphicsPath.ArcTo(rrect_0.Left + class50_0.Double_19 / 2.0, rrect_0.Bottom - class50_0.Double_20 / 2.0 - class50_0.Double_25, class50_0.Double_25, RGraphicsPath.Corner.BottomLeft);
					}
				}
				break;
			case Enum2.const_3:
				if (class50_0.Double_22 > 0.0 || class50_0.Double_25 > 0.0)
				{
					rGraphicsPath = rgraphics_0.GetGraphicsPath();
					bool flag = class50_0.String_7 == "none" || class50_0.String_7 == "hidden";
					bool flag2 = class50_0.String_4 == "none" || class50_0.String_4 == "hidden";
					rGraphicsPath.Start(rrect_0.Left + class50_0.Double_19 / 2.0 + (flag2 ? class50_0.Double_25 : 0.0), rrect_0.Bottom - class50_0.Double_20 / 2.0 - (flag2 ? 0.0 : class50_0.Double_25));
					if (class50_0.Double_25 > 0.0 && flag2)
					{
						rGraphicsPath.ArcTo(rrect_0.Left + class50_0.Double_19 / 2.0, rrect_0.Bottom - class50_0.Double_20 / 2.0 - class50_0.Double_25, class50_0.Double_25, RGraphicsPath.Corner.BottomLeft);
					}
					rGraphicsPath.LineTo(rrect_0.Left + class50_0.Double_19 / 2.0, rrect_0.Top + class50_0.Double_18 / 2.0 + class50_0.Double_22);
					if (class50_0.Double_22 > 0.0 && flag)
					{
						rGraphicsPath.ArcTo(rrect_0.Left + class50_0.Double_19 / 2.0 + class50_0.Double_22, rrect_0.Top + class50_0.Double_18 / 2.0, class50_0.Double_22, RGraphicsPath.Corner.TopLeft);
					}
				}
				break;
			}
			return rGraphicsPath;
		}

		private static RPen smethod_5(RGraphics rgraphics_0, string string_0, RColor rcolor_0, double double_0)
		{
			RPen pen = rgraphics_0.GetPen(rcolor_0);
			pen.Width = double_0;
			switch (string_0)
			{
			case "dashed":
				pen.DashStyle = RDashStyle.Dash;
				break;
			case "dotted":
				pen.DashStyle = RDashStyle.Dot;
				break;
			case "solid":
				pen.DashStyle = RDashStyle.Solid;
				break;
			}
			return pen;
		}

		private static RColor smethod_6(Enum2 enum2_0, Class49 class49_0, string string_0)
		{
			return enum2_0 switch
			{
				Enum2.const_0 => (string_0 == "inset") ? Class38.smethod_9(class49_0.RColor_0) : class49_0.RColor_0, 
				Enum2.const_1 => (string_0 == "outset") ? Class38.smethod_9(class49_0.RColor_3) : class49_0.RColor_3, 
				Enum2.const_2 => (string_0 == "outset") ? Class38.smethod_9(class49_0.RColor_2) : class49_0.RColor_2, 
				Enum2.const_3 => (string_0 == "inset") ? Class38.smethod_9(class49_0.RColor_1) : class49_0.RColor_1, 
				_ => throw new ArgumentOutOfRangeException("border"), 
			};
		}

		private static double smethod_7(Enum2 enum2_0, Class49 class49_0)
		{
			return enum2_0 switch
			{
				Enum2.const_0 => class49_0.Double_18, 
				Enum2.const_1 => class49_0.Double_21, 
				Enum2.const_2 => class49_0.Double_20, 
				Enum2.const_3 => class49_0.Double_19, 
				_ => throw new ArgumentOutOfRangeException("border"), 
			};
		}

		private static string smethod_8(Enum2 enum2_0, Class49 class49_0)
		{
			return enum2_0 switch
			{
				Enum2.const_0 => class49_0.String_7, 
				Enum2.const_1 => class49_0.String_6, 
				Enum2.const_2 => class49_0.String_4, 
				Enum2.const_3 => class49_0.String_5, 
				_ => throw new ArgumentOutOfRangeException("border"), 
			};
		}

		private static RColor smethod_9(RColor rcolor_0)
		{
			return RColor.FromArgb((int)rcolor_0.Byte_0 / 2, (int)rcolor_0.Byte_1 / 2, (int)rcolor_0.Byte_2 / 2);
		}
	}
}

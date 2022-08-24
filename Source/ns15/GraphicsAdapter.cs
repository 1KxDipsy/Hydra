using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns0;
using ns11;
using ns14;
using ns16;

namespace ns15
{
	public sealed class GraphicsAdapter : RGraphics
	{
		private static readonly int[] int_0;

		private static readonly int[] int_1;

		private static readonly CharacterRange[] characterRange_0;

		private static readonly StringFormat stringFormat_0;

		private static readonly StringFormat stringFormat_1;

		private readonly Graphics graphics_0;

		private readonly bool bool_0;

		private IntPtr intptr_0;

		private readonly bool bool_1;

		private bool bool_2;

		static GraphicsAdapter()
		{
			GraphicsAdapter.int_0 = new int[1];
			GraphicsAdapter.int_1 = new int[1000];
			GraphicsAdapter.characterRange_0 = new CharacterRange[1];
			GraphicsAdapter.stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
			GraphicsAdapter.stringFormat_0.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip;
			GraphicsAdapter.stringFormat_1 = new StringFormat(StringFormat.GenericTypographic);
		}

		public GraphicsAdapter(Graphics g, bool useGdiPlusTextRendering, bool releaseGraphics = false)
			: base(Class64.Class64_0, Class19.smethod_7(g.ClipBounds))
		{
			ArgChecker.AssertArgNotNull(g, "g");
			this.graphics_0 = g;
			this.bool_1 = releaseGraphics;
			this.bool_0 = useGdiPlusTextRendering;
		}

		public override void PopClip()
		{
			this.method_0();
			base._clipStack.Pop();
			this.graphics_0.SetClip(Class19.smethod_8(base._clipStack.Peek()), CombineMode.Replace);
		}

		public override void PushClip(RRect rect)
		{
			this.method_0();
			base._clipStack.Push(rect);
			this.graphics_0.SetClip(Class19.smethod_8(rect), CombineMode.Replace);
		}

		public override void PushClipExclude(RRect rect)
		{
			this.method_0();
			base._clipStack.Push(base._clipStack.Peek());
			this.graphics_0.SetClip(Class19.smethod_8(rect), CombineMode.Exclude);
		}

		public override object SetAntiAliasSmoothingMode()
		{
			this.method_0();
			SmoothingMode smoothingMode = this.graphics_0.SmoothingMode;
			this.graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
			return smoothingMode;
		}

		public override void ReturnPreviousSmoothingMode(object prevMode)
		{
			if (prevMode != null)
			{
				this.method_0();
				this.graphics_0.SmoothingMode = (SmoothingMode)prevMode;
			}
		}

		public override RSize MeasureString(string str, RFont font)
		{
			if (this.bool_0)
			{
				this.method_0();
				Class67 @class = (Class67)font;
				Font font_ = @class.Font_0;
				GraphicsAdapter.characterRange_0[0] = new CharacterRange(0, str.Length);
				GraphicsAdapter.stringFormat_0.SetMeasurableCharacterRanges(GraphicsAdapter.characterRange_0);
				SizeF size = this.graphics_0.MeasureCharacterRanges(str, font_, RectangleF.Empty, GraphicsAdapter.stringFormat_0)[0].GetBounds(this.graphics_0).Size;
				if (font.Height < 0.0)
				{
					int height = font_.Height;
					@class.method_0(height, (int)Math.Round((float)height - font_.Size * (float)font_.FontFamily.GetCellDescent(font_.Style) / (float)font_.FontFamily.GetEmHeight(font_.Style) + 0.5f));
				}
				return Class19.smethod_4(size);
			}
			this.method_2(font);
			Size size_ = default(Size);
			Class20.GetTextExtentPoint32W(this.intptr_0, str, str.Length, ref size_);
			if (font.Height < 0.0)
			{
				Class20.GetTextMetrics(this.intptr_0, out var struct2_);
				((Class67)font).method_0(size_.Height, struct2_.int_0 - struct2_.int_2 + struct2_.byte_1 + 1);
			}
			return Class19.smethod_4(size_);
		}

		public override void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth)
		{
			charFit = 0;
			charFitWidth = 0.0;
			if (this.bool_0)
			{
				this.method_0();
				RSize rSize = this.MeasureString(str, font);
				for (int i = 1; i <= str.Length; i++)
				{
					charFit = i - 1;
					RSize rSize2 = this.MeasureString(str.Substring(0, i), font);
					if (rSize2.Height <= rSize.Height && rSize2.Width < maxWidth)
					{
						charFitWidth = rSize2.Width;
						continue;
					}
					break;
				}
			}
			else
			{
				this.method_2(font);
				Size size_ = default(Size);
				Class20.GetTextExtentExPointW(this.intptr_0, str, str.Length, (int)Math.Round(maxWidth), GraphicsAdapter.int_0, GraphicsAdapter.int_1, ref size_);
				charFit = GraphicsAdapter.int_0[0];
				charFitWidth = ((charFit > 0) ? GraphicsAdapter.int_1[charFit - 1] : 0);
			}
		}

		public override void DrawString(string str, RFont font, RColor color, RPoint point, RSize size, bool rtl)
		{
			if (this.bool_0)
			{
				this.method_0();
				this.method_5(rtl);
				Brush brush_ = ((Class65)base._adapter.GetSolidBrush(color)).Brush_0;
				this.graphics_0.DrawString(str, ((Class67)font).Font_0, brush_, (int)(Math.Round(point.Double_0) + (rtl ? size.Width : 0.0)), (int)Math.Round(point.Double_1), GraphicsAdapter.stringFormat_1);
				return;
			}
			Point point_ = Class19.smethod_3(point);
			Color color_ = Class19.smethod_11(color);
			if (color.Byte_3 == byte.MaxValue)
			{
				this.method_2(font);
				this.method_3(color_);
				this.method_4(rtl);
				Class20.TextOutW(this.intptr_0, point_.X, point_.Y, str, str.Length);
			}
			else
			{
				this.method_1();
				this.method_4(rtl);
				GraphicsAdapter.smethod_0(this.intptr_0, str, font, point_, Class19.smethod_6(size), color_);
			}
		}

		public override RBrush GetTextureBrush(RImage image, RRect dstRect, RPoint translateTransformLocation)
		{
			TextureBrush textureBrush = new TextureBrush(((Class70)image).Image_0, Class19.smethod_8(dstRect));
			textureBrush.TranslateTransform((float)translateTransformLocation.Double_0, (float)translateTransformLocation.Double_1);
			return new Class65(textureBrush, bool_1: true);
		}

		public override RGraphicsPath GetGraphicsPath()
		{
			return new Class69();
		}

		public override void Dispose()
		{
			this.method_0();
			if (this.bool_1)
			{
				this.graphics_0.Dispose();
			}
			if (this.bool_0 && this.bool_2)
			{
				GraphicsAdapter.stringFormat_1.FormatFlags ^= StringFormatFlags.DirectionRightToLeft;
			}
		}

		public override void DrawLine(RPen pen, double x1, double y1, double x2, double y2)
		{
			this.method_0();
			this.graphics_0.DrawLine(((Class71)pen).Pen_0, (float)x1, (float)y1, (float)x2, (float)y2);
		}

		public override void DrawRectangle(RPen pen, double x, double y, double width, double height)
		{
			this.method_0();
			this.graphics_0.DrawRectangle(((Class71)pen).Pen_0, (float)x, (float)y, (float)width, (float)height);
		}

		public override void DrawRectangle(RBrush brush, double x, double y, double width, double height)
		{
			this.method_0();
			this.graphics_0.FillRectangle(((Class65)brush).Brush_0, (float)x, (float)y, (float)width, (float)height);
		}

		public override void DrawImage(RImage image, RRect destRect, RRect srcRect)
		{
			this.method_0();
			this.graphics_0.DrawImage(((Class70)image).Image_0, Class19.smethod_8(destRect), Class19.smethod_8(srcRect), GraphicsUnit.Pixel);
		}

		public override void DrawImage(RImage image, RRect destRect)
		{
			this.method_0();
			this.graphics_0.DrawImage(((Class70)image).Image_0, Class19.smethod_8(destRect));
		}

		public override void DrawPath(RPen pen, RGraphicsPath path)
		{
			this.graphics_0.DrawPath(((Class71)pen).Pen_0, ((Class69)path).GraphicsPath_0);
		}

		public override void DrawPath(RBrush brush, RGraphicsPath path)
		{
			this.method_0();
			this.graphics_0.FillPath(((Class65)brush).Brush_0, ((Class69)path).GraphicsPath_0);
		}

		public override void DrawPolygon(RBrush brush, RPoint[] points)
		{
			if (points != null && points.Length != 0)
			{
				this.method_0();
				this.graphics_0.FillPolygon(((Class65)brush).Brush_0, Class19.smethod_1(points));
			}
		}

		private void method_0()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class20.SelectClipRgn(this.intptr_0, IntPtr.Zero);
				this.graphics_0.ReleaseHdc(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
			}
		}

		private void method_1()
		{
			if (this.intptr_0 == IntPtr.Zero)
			{
				IntPtr hrgn = this.graphics_0.Clip.GetHrgn(this.graphics_0);
				this.intptr_0 = this.graphics_0.GetHdc();
				this.bool_2 = false;
				Class20.SetBkMode(this.intptr_0, 1);
				Class20.SelectClipRgn(this.intptr_0, hrgn);
				Class20.DeleteObject(hrgn);
			}
		}

		private void method_2(RFont rfont_0)
		{
			this.method_1();
			Class20.SelectObject(this.intptr_0, ((Class67)rfont_0).IntPtr_0);
		}

		private void method_3(Color color_0)
		{
			this.method_1();
			Class20.SetTextColor(int_10: ((color_0.B & 0xFF) << 16) | ((color_0.G & 0xFF) << 8) | color_0.R, intptr_0: this.intptr_0);
		}

		private void method_4(bool bool_3)
		{
			if (this.bool_2)
			{
				if (!bool_3)
				{
					Class20.SetTextAlign(this.intptr_0, 0u);
				}
			}
			else if (bool_3)
			{
				Class20.SetTextAlign(this.intptr_0, 256u);
			}
			this.bool_2 = bool_3;
		}

		private static void smethod_0(IntPtr intptr_1, string string_0, RFont rfont_0, Point point_0, Size size_0, Color color_0)
		{
			IntPtr intptr_2;
			IntPtr intptr_3 = Class20.smethod_0(intptr_1, size_0.Width, size_0.Height, out intptr_2);
			try
			{
				Class20.BitBlt(intptr_3, 0, 0, size_0.Width, size_0.Height, intptr_1, point_0.X, point_0.Y, 13369376u);
				Class20.SelectObject(intptr_3, ((Class67)rfont_0).IntPtr_0);
				Class20.SetTextColor(intptr_3, ((color_0.B & 0xFF) << 16) | ((color_0.G & 0xFF) << 8) | color_0.R);
				Class20.TextOutW(intptr_3, 0, 0, string_0, string_0.Length);
				Class20.GdiAlphaBlend(intptr_1, point_0.X, point_0.Y, size_0.Width, size_0.Height, intptr_3, 0, 0, size_0.Width, size_0.Height, new Struct0(color_0.A));
			}
			finally
			{
				Class20.smethod_1(intptr_3, intptr_2);
			}
		}

		private void method_5(bool bool_3)
		{
			if (this.bool_2)
			{
				if (!bool_3)
				{
					GraphicsAdapter.stringFormat_1.FormatFlags ^= StringFormatFlags.DirectionRightToLeft;
				}
			}
			else if (bool_3)
			{
				GraphicsAdapter.stringFormat_1.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
			}
			this.bool_2 = bool_3;
		}
	}
}

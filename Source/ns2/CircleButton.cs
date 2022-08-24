using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns0;
using ns5;

namespace ns2
{
	public class CircleButton : CustomButtonBase
	{
		private GraphicsPath graphicsPath_0;

		private ButtonImages buttonImages_0;

		private ButtonState buttonState_0;

		private ButtonState buttonState_1;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ButtonImages DefaultCustomImages
		{
			get
			{
				if (this.buttonImages_0 == null)
				{
					this.buttonImages_0 = new ButtonImages
					{
						Parent = this
					};
				}
				return this.buttonImages_0;
			}
			set
			{
				this.buttonImages_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ButtonState DefaultHoveredState
		{
			get
			{
				if (this.buttonState_0 == null)
				{
					this.buttonState_0 = new ButtonState
					{
						Parent = this
					};
				}
				return this.buttonState_0;
			}
			set
			{
				this.buttonState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ButtonState DefaultCheckedState
		{
			get
			{
				if (this.buttonState_1 == null)
				{
					this.buttonState_1 = new ButtonState
					{
						Parent = this
					};
				}
				return this.buttonState_1;
			}
			set
			{
				this.buttonState_1 = value;
			}
		}

		public CircleButton()
		{
			base.InitializeAnimationManager();
			base.DefaultTile = true;
			base.DefaultShadowDecoration.Mode = ShadowMode.Circle;
			base.Size = new Size(148, 148);
		}

		private Color method_5()
		{
			if (!(this.DefaultHoveredState.FillColor == Color.Empty))
			{
				return this.DefaultHoveredState.FillColor;
			}
			return Class6.smethod_10(base.DefaultFillColor, Color.Black, Color.White, 15);
		}

		private Color method_6()
		{
			if (!(this.DefaultHoveredState.ForeColor == Color.Empty))
			{
				return this.DefaultHoveredState.ForeColor;
			}
			return base.ForeColor;
		}

		private Color method_7()
		{
			if (!(this.DefaultHoveredState.CustomBorderColor == Color.Empty))
			{
				return this.DefaultHoveredState.CustomBorderColor;
			}
			return Class6.smethod_10(base.DefaultCustomBorderColor, Color.Black, Color.White, 15);
		}

		private Color method_8()
		{
			if (!(this.DefaultHoveredState.BorderColor == Color.Empty))
			{
				return this.DefaultHoveredState.BorderColor;
			}
			return Class6.smethod_10(base.DefaultBorderColor, Color.Black, Color.White, 15);
		}

		private Font method_9()
		{
			if (this.DefaultHoveredState.Font != null)
			{
				return this.DefaultHoveredState.Font;
			}
			return base.Font;
		}

		private Image method_10()
		{
			if (this.DefaultHoveredState.Image != null)
			{
				return this.DefaultHoveredState.Image;
			}
			return base.DefaultImage;
		}

		private Color method_11()
		{
			if (!(this.DefaultCheckedState.FillColor == Color.Empty))
			{
				return this.DefaultCheckedState.FillColor;
			}
			return this.method_5();
		}

		private Color method_12()
		{
			if (!(this.DefaultCheckedState.ForeColor == Color.Empty))
			{
				return this.DefaultCheckedState.ForeColor;
			}
			return this.method_6();
		}

		private Color method_13()
		{
			if (!(this.DefaultCheckedState.CustomBorderColor == Color.Empty))
			{
				return this.DefaultCheckedState.CustomBorderColor;
			}
			return this.method_7();
		}

		private Color method_14()
		{
			if (!(this.DefaultCheckedState.BorderColor == Color.Empty))
			{
				return this.DefaultCheckedState.BorderColor;
			}
			return this.method_8();
		}

		private Font method_15()
		{
			if (this.DefaultCheckedState.Font != null)
			{
				return this.DefaultCheckedState.Font;
			}
			return this.method_9();
		}

		private Image method_16()
		{
			if (this.DefaultCheckedState.Image != null)
			{
				return this.DefaultCheckedState.Image;
			}
			return this.method_10();
		}

		private Image method_17()
		{
			if (this.DefaultCustomImages.HoveredImage != null)
			{
				return this.DefaultCustomImages.HoveredImage;
			}
			return this.DefaultCustomImages.Image;
		}

		private Image method_18()
		{
			if (this.DefaultCustomImages.CheckedImage != null)
			{
				return this.DefaultCustomImages.CheckedImage;
			}
			return this.method_17();
		}

		private object method_19(Graphics graphics_0)
		{
			int num = base.Width;
			Bitmap bitmap = ((graphics_0 == null) ? new Bitmap(num, base.Height) : null);
			Graphics graphics = ((graphics_0 != null) ? graphics_0 : Graphics.FromImage(bitmap));
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			checked
			{
				int num2 = base.AnimationManager.GetAnimationCount() - 1;
				for (int i = 0; i <= num2; i++)
				{
					double progress = base.AnimationManager.GetProgress(i);
					Point source = base.AnimationManager.GetSource(i);
					using Brush brush = new SolidBrush(Color.FromArgb((int)Math.Round(101.0 - progress * 100.0), base.DefaultPressedColor));
					int num3 = (int)Math.Round(progress * (double)num * 2.0);
					graphics.FillEllipse(brush, new Rectangle((int)Math.Round((double)source.X - (double)num3 / 2.0), (int)Math.Round((double)source.Y - (double)num3 / 2.0), num3, num3));
				}
				return bitmap;
			}
		}

		private void method_20(Graphics graphics_0)
		{
			Color color = base.DefaultFillColor;
			Color color2 = base.ForeColor;
			Color color3 = base.DefaultCustomBorderColor;
			Color color4 = base.DefaultBorderColor;
			Font font = base.Font;
			Image image = base.DefaultImage;
			Image image2 = this.DefaultCustomImages.Image;
			if (base.DefaultAnimated && !base.DesignMode)
			{
				color = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color, this.method_5());
				color2 = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color2, this.method_6());
				color3 = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color3, this.method_7());
				color4 = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color4, this.method_8());
				color = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color, this.method_11());
				color2 = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color2, this.method_12());
				color3 = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color3, this.method_13());
				color4 = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color4, this.method_14());
			}
			else if (base.DefaultChecked)
			{
				color = this.method_11();
				color2 = this.method_12();
				color3 = this.method_13();
				color4 = this.method_14();
			}
			else if ((base.mouseState_0 == MouseState.HOVER) | (base.mouseState_0 == MouseState.DOWN))
			{
				color = this.method_5();
				color2 = this.method_6();
				color3 = this.method_7();
				color4 = this.method_8();
				if ((base.mouseState_0 == MouseState.DOWN) & (base.DefaultPressedDepth > 0))
				{
					color = Class6.smethod_23(base.DefaultPressedDepth, color, base.DefaultPressedColor);
					color3 = Class6.smethod_23(base.DefaultPressedDepth, color3, base.DefaultPressedColor);
					color4 = Class6.smethod_23(base.DefaultPressedDepth, color4, base.DefaultPressedColor);
				}
			}
			if (base.DefaultChecked)
			{
				font = this.method_15();
				image = this.method_16();
				image2 = this.method_18();
			}
			else if ((base.mouseState_0 == MouseState.HOVER) | (base.mouseState_0 == MouseState.DOWN))
			{
				font = this.method_9();
				image = this.method_10();
				image2 = this.method_17();
			}
			bool flag = !base.DefaultChecked & base.Enabled & this.Focused & (base.DefaultFocusedColor != Color.Empty) & (base.mouseState_0 == MouseState.const_2);
			this.graphicsPath_0 = new GraphicsPath();
			this.graphicsPath_0.AddEllipse(0, 0, base.Width - 1, base.Height - 1);
			graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
			graphics_0.FillPath(new SolidBrush(color), this.graphicsPath_0);
			if (flag | (base.DefaultBorderThickness > 0))
			{
				Class6.smethod_19(graphics_0, flag ? new SolidBrush(base.DefaultFocusedColor) : new SolidBrush(color4), base.ClientRectangle, (base.DefaultBorderThickness != 0) ? base.DefaultBorderThickness : (flag ? 1 : 0), base.DefaultBorderStyle);
			}
			Class6.smethod_16(graphics_0, color3, base.ClientRectangle, base.DefaultCustomBorderThickness);
			Rectangle rectangle = new Rectangle(base.DefaultTextOffset.X, base.DefaultTextOffset.Y, base.Width, base.Height);
			int num = (int)graphics_0.MeasureString(this.Text, this.Font).Width;
			if (base.DefaultTextAlign == HorizontalAlignment.Right)
			{
				rectangle.X = -10;
				rectangle.X += base.DefaultTextOffset.X;
			}
			else if (base.DefaultTextAlign == HorizontalAlignment.Left)
			{
				rectangle.X += 10;
			}
			if (image != null)
			{
				Rectangle rect = new Rectangle(base.DefaultImageOffset.X, base.DefaultImageOffset.Y, base.DefaultImageSize.Width, base.DefaultImageSize.Height);
				switch (base.DefaultImageAlign)
				{
				case HorizontalAlignment.Left:
					if (!base.DefaultTile && base.DefaultTextAlign == HorizontalAlignment.Left)
					{
						rectangle.X += base.DefaultImageSize.Width + 5;
					}
					rect.X += 10;
					rect.Y += Class6.smethod_8(base.DefaultImageSize.Height, base.Height);
					break;
				case HorizontalAlignment.Right:
					if (!base.DefaultTile && base.DefaultTextAlign == HorizontalAlignment.Right)
					{
						rectangle.X -= base.DefaultImageSize.Width + 5;
					}
					rect.X = base.Width - (base.DefaultImageSize.Width + rect.X + 10);
					rect.Y += Class6.smethod_8(base.DefaultImageSize.Height, base.Height);
					break;
				case HorizontalAlignment.Center:
					rect.X += Class6.smethod_8(base.DefaultImageSize.Width, base.Width);
					rect.Y += Class6.smethod_8(base.DefaultImageSize.Height, base.Height);
					break;
				}
				if (base.DefaultTile && this.Text != string.Empty)
				{
					int num2 = (int)((float)base.DefaultImageSize.Height + graphics_0.MeasureString(this.Text, this.Font).Height) / 3;
					rect.Y -= num2;
					rectangle.Y += num2;
				}
				else if (base.DefaultTextAlign == HorizontalAlignment.Center && base.DefaultImageAlign == HorizontalAlignment.Center)
				{
					if (base.Width > num)
					{
						rectangle.X += base.DefaultImageSize.Width / 2;
						rectangle.X += base.DefaultTextOffset.X;
						rectangle.X += 2;
						rect.X -= num / 2;
						rect.X--;
						rect.X += base.DefaultImageOffset.X;
					}
					else
					{
						int num3 = (int)((float)base.DefaultImageSize.Height + graphics_0.MeasureString(this.Text, this.Font).Height) / 3;
						rect.Y -= num3;
						rectangle.Y += num3;
					}
				}
				graphics_0.DrawImage(image, rect);
			}
			if (image2 != null)
			{
				Rectangle rect2 = new Rectangle(this.DefaultCustomImages.ImageOffset.X, this.DefaultCustomImages.ImageOffset.Y, this.DefaultCustomImages.ImageSize.Width, this.DefaultCustomImages.ImageSize.Height);
				switch (this.DefaultCustomImages.ImageAlign)
				{
				case HorizontalAlignment.Left:
					rect2.X += 10;
					rect2.Y += Class6.smethod_8(this.DefaultCustomImages.ImageSize.Height, base.Height);
					break;
				case HorizontalAlignment.Right:
					rect2.X = base.Width - (this.DefaultCustomImages.ImageSize.Width + rect2.X + 10);
					rect2.Y += Class6.smethod_8(this.DefaultCustomImages.ImageSize.Height, base.Height);
					break;
				case HorizontalAlignment.Center:
					rect2.X += Class6.smethod_8(this.DefaultCustomImages.ImageSize.Width, base.Width);
					rect2.Y += Class6.smethod_8(base.DefaultImageSize.Height, base.Height);
					break;
				}
				graphics_0.DrawImage(image2, rect2);
			}
			if (base.DefaultTile | (base.Width < num))
			{
				rectangle.X += base.Margin.Left;
				rectangle.Width -= base.Margin.Left + base.Margin.Right;
			}
			graphics_0.TextRenderingHint = base.DefaultTextRenderingHint;
			using (StringFormat format = new StringFormat
			{
				FormatFlags = StringFormatFlags.LineLimit,
				Alignment = Class6.smethod_4(base.DefaultTextAlign),
				LineAlignment = StringAlignment.Center
			})
			{
				switch (base.DefaultTextTransform)
				{
				case TextTransform.None:
					graphics_0.DrawString(this.Text, font, new SolidBrush(color2), rectangle, format);
					break;
				case TextTransform.UpperCase:
					graphics_0.DrawString(this.Text.ToUpper(), font, new SolidBrush(color2), rectangle, format);
					break;
				case TextTransform.LowerCase:
					graphics_0.DrawString(this.Text.ToLower(), font, new SolidBrush(color2), rectangle, format);
					break;
				}
			}
			if (base.DefaultAnimated & (base.DefaultPressedDepth != 0) & base.AnimationManager.IsAnimating())
			{
				graphics_0.FillPath(new TextureBrush((Bitmap)this.method_19(null)), this.graphicsPath_0);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Bitmap image = new Bitmap(base.Width, base.Height);
				this.method_20(Graphics.FromImage(image));
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else
			{
				this.method_20(e.Graphics);
			}
			base.OnPaint(e);
		}
	}
}

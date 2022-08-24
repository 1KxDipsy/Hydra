using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns5;
using ns7;

namespace ns2
{
	[ToolboxItem(false)]
	public class ControlBox : UIDefaultControl
	{
		private ControlBoxState controlBoxState_0;

		private Color color_1 = Class0.color_28;

		private Color color_2 = Color.White;

		private bool bool_4 = true;

		private Font font_0 = new Font("Marlett", 10f);

		private ControlBoxType controlBoxType_0 = ControlBoxType.CloseBox;

		private ControlBoxStyle controlBoxStyle_0 = ControlBoxStyle.Windows10;

		private Color color_3 = Color.Black;

		private int int_2 = 30;

		private bool bool_5 = true;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_6;

		private AnimationManager animationManager_0;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ControlBoxState DefaultHoveredState
		{
			get
			{
				if (this.controlBoxState_0 == null)
				{
					this.controlBoxState_0 = new ControlBoxState
					{
						Parent = this
					};
				}
				return this.controlBoxState_0;
			}
			set
			{
				this.controlBoxState_0 = value;
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultIconColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultAnimated
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}

		[Browsable(false)]
		protected float DefaultCustomIconSize
		{
			get
			{
				return this.font_0.Size;
			}
			set
			{
				this.font_0 = new Font("Marlett", value);
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected ControlBoxType DefaultControlBoxType
		{
			get
			{
				return this.controlBoxType_0;
			}
			set
			{
				this.controlBoxType_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected ControlBoxStyle DefaultControlBoxStyle
		{
			get
			{
				return this.controlBoxStyle_0;
			}
			set
			{
				this.controlBoxStyle_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultPressedColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultPressedDepth
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultShowIcon
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
				base.Invalidate();
			}
		}

		[DefaultValue(false)]
		protected bool DefaultCustomClick
		{
			[CompilerGenerated]
			get
			{
				return this.bool_6;
			}
			[CompilerGenerated]
			set
			{
				this.bool_6 = value;
			}
		}

		public ControlBox()
		{
			this.method_4();
			this.method_8();
			base.Size = new Size(45, 29);
		}

		private Color method_1()
		{
			if (!(this.DefaultHoveredState.FillColor == Color.Empty))
			{
				return this.DefaultHoveredState.FillColor;
			}
			return Class6.smethod_10(this.color_1, Color.Black, Color.White, 15);
		}

		private Color method_2()
		{
			if (!(this.DefaultHoveredState.IconColor == Color.Empty))
			{
				return this.DefaultHoveredState.IconColor;
			}
			return this.color_2;
		}

		private Color method_3()
		{
			if (!(this.DefaultHoveredState.BorderColor == Color.Empty))
			{
				return this.DefaultHoveredState.BorderColor;
			}
			return Class6.smethod_10(base.DefaultBorderColor, Color.Black, Color.White, 15);
		}

		private void method_4()
		{
			this.animationManager_0 = new AnimationManager
			{
				Increment = 0.10000000149011612,
				AnimationType = AnimationType.Linear
			};
			this.animationManager_0.OnAnimationProgress += new AnimationManager.AnimationProgress(method_5);
		}

		private void method_5(object object_0)
		{
			base.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (!this.bool_4)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode)
			{
				this.animationManager_0.StartNewAnimation((base.MouseState != 0) ? AnimationDirection.Out : AnimationDirection.In);
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			if (!this.bool_4)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode)
			{
				this.animationManager_0.StartNewAnimation(AnimationDirection.In);
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (!this.bool_4)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode)
			{
				this.animationManager_0.StartNewAnimation(AnimationDirection.Out);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			base.Focus();
			if (!this.DefaultCustomClick)
			{
				switch (this.controlBoxType_0)
				{
				case ControlBoxType.MinimizeBox:
					base.FindForm().WindowState = FormWindowState.Minimized;
					break;
				case ControlBoxType.MaximizeBox:
					if (base.FindForm().WindowState != FormWindowState.Maximized)
					{
						base.FindForm().WindowState = FormWindowState.Maximized;
					}
					else
					{
						base.FindForm().WindowState = FormWindowState.Normal;
					}
					break;
				case ControlBoxType.CloseBox:
					base.FindForm().Close();
					break;
				}
			}
			base.Invalidate();
			base.OnClick(e);
		}

		public void PerformClick()
		{
			this.OnClick(EventArgs.Empty);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			base.Invalidate();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if ((e.KeyData == Keys.Space) | (e.KeyData == Keys.Return))
			{
				this.PerformClick();
				e.Handled = true;
			}
			base.OnKeyDown(e);
		}

		private Image method_6(Color color_4, Color color_5)
		{
			Bitmap bitmap = new Bitmap(10, 10);
			Graphics graphics = Graphics.FromImage(bitmap);
			switch (this.controlBoxType_0)
			{
			case ControlBoxType.MinimizeBox:
				graphics.DrawLine(new Pen(color_4, 1f), new Point(0, 5), new Point(10, 5));
				break;
			case ControlBoxType.MaximizeBox:
				if (base.FindForm().WindowState == FormWindowState.Maximized)
				{
					graphics.DrawRectangle(new Pen(color_4, 1f), new Rectangle(2, 0, 7, 7));
					graphics.FillRectangle(new SolidBrush(color_5), new Rectangle(0, 2, 7, 7));
					graphics.DrawRectangle(new Pen(color_4, 1f), new Rectangle(0, 2, 7, 7));
				}
				else
				{
					graphics.DrawRectangle(new Pen(color_4, 1f), new Rectangle(0, 0, 9, 9));
				}
				break;
			case ControlBoxType.CloseBox:
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.DrawLine(new Pen(color_4, 1f), new Point(0, 0), new Point(10, 10));
				graphics.DrawLine(new Pen(color_4, 1f), new Point(0, 9), new Point(9, 0));
				graphics.DrawLine(new Pen(color_4, 1f), new Point(0, 0), new Point(10, 10));
				graphics.DrawLine(new Pen(color_4, 1f), new Point(0, 9), new Point(9, 0));
				break;
			}
			return bitmap;
		}

		private void method_7(Graphics graphics_0)
		{
			Color color = this.color_1;
			Color color2 = this.color_2;
			Color color3 = base.DefaultBorderColor;
			if (this.bool_4 && !base.DesignMode)
			{
				color = Class6.smethod_23((int)Math.Round(this.animationManager_0.GetProgress() * 100.0), color, this.method_1());
				color2 = Class6.smethod_23((int)Math.Round(this.animationManager_0.GetProgress() * 100.0), color2, this.method_2());
				color3 = Class6.smethod_23((int)Math.Round(this.animationManager_0.GetProgress() * 100.0), color3, this.method_3());
			}
			else if ((base.MouseState == MouseState.HOVER) | (base.MouseState == MouseState.DOWN))
			{
				color = this.method_1();
				color2 = this.method_2();
				color3 = this.method_3();
			}
			if ((base.MouseState == MouseState.DOWN) & (this.int_2 > 0))
			{
				color = Class6.smethod_23(this.int_2, (this.DefaultHoveredState.FillColor == Color.Empty) ? this.color_1 : this.DefaultHoveredState.FillColor, this.color_3);
			}
			if (base.DefaultBorderRadius > 0)
			{
				GraphicsPath path = Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), base.DefaultBorderRadius * 2);
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphics_0.FillPath(new SolidBrush(color), path);
				if (base.DefaultBorderThickness != 0)
				{
					Class6.smethod_20(graphics_0, new SolidBrush(color3), base.ClientRectangle, base.DefaultBorderRadius, base.DefaultBorderThickness, base.DefaultBorderStyle);
				}
			}
			else
			{
				graphics_0.SmoothingMode = SmoothingMode.Default;
				graphics_0.FillRectangle(new SolidBrush(color), base.ClientRectangle);
				Class6.smethod_22(graphics_0, new SolidBrush(color3), base.ClientRectangle, base.DefaultBorderThickness, base.DefaultBorderStyle);
			}
			if (!this.bool_5)
			{
				return;
			}
			if (this.controlBoxStyle_0 == ControlBoxStyle.Custom)
			{
				using (StringFormat format = new StringFormat
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				})
				{
					switch (this.controlBoxType_0)
					{
					case ControlBoxType.MinimizeBox:
						graphics_0.DrawString("0", this.font_0, new SolidBrush(color2), new Rectangle(0, 1, base.Width, base.Height), format);
						break;
					case ControlBoxType.MaximizeBox:
						if (base.FindForm().WindowState == FormWindowState.Maximized)
						{
							graphics_0.DrawString("2", this.font_0, new SolidBrush(color2), new Rectangle(0, 1, base.Width, base.Height), format);
						}
						else
						{
							graphics_0.DrawString("1", this.font_0, new SolidBrush(color2), new Rectangle(0, 1, base.Width, base.Height), format);
						}
						break;
					case ControlBoxType.CloseBox:
						graphics_0.DrawString("r", this.font_0, new SolidBrush(color2), new Rectangle(0, 1, base.Width, base.Height), format);
						break;
					}
					return;
				}
			}
			graphics_0.DrawImage(rect: new Rectangle(base.Width / 2 - 5, base.Height / 2 - 5, 10, 10), image: this.method_6(color2, color));
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				if (!base.Enabled)
				{
					Bitmap image = new Bitmap(base.Width, base.Height);
					this.method_7(Graphics.FromImage(image));
					ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
				}
				else
				{
					this.method_7(e.Graphics);
				}
			}
			catch
			{
			}
			base.OnPaint(e);
		}

		private void method_8()
		{
			base.SuspendLayout();
			this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			base.DefaultShadowDecoration.Parent = this;
			base.ResumeLayout(performLayout: false);
		}
	}
}

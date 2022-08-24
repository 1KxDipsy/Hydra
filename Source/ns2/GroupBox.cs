using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using ns0;
using ns3;
using ns5;

namespace ns2
{
	[ToolboxItem(false)]
	public class GroupBox : ContainerControl, IControl
	{
		private ShadowDecoration shadowDecoration_0;

		private Color color_0;

		private Color color_1;

		private int int_0;

		private Padding padding_0;

		private Color color_2;

		private int int_1;

		private TextRenderingHint textRenderingHint_0;

		private HorizontalAlignment horizontalAlignment_0;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private TextTransform textTransform_0;

		private Point point_0;

		private bool bool_0;

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ShadowDecoration DefaultShadowDecoration
		{
			get
			{
				if (this.shadowDecoration_0 == null)
				{
					this.shadowDecoration_0 = new ShadowDecoration(this);
				}
				return this.shadowDecoration_0;
			}
			set
			{
				this.shadowDecoration_0 = value;
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultBorderColor
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
		protected int DefaultBorderThickness
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultCustomBorderColor
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
		protected Padding DefaultCustomBorderThickness
		{
			get
			{
				return this.padding_0;
			}
			set
			{
				this.padding_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultBorderRadius
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = ((value >= 0) ? value : 0);
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected TextRenderingHint DefaultTextRenderingHint
		{
			get
			{
				return this.textRenderingHint_0;
			}
			set
			{
				this.textRenderingHint_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected HorizontalAlignment DefaultTextAlign
		{
			get
			{
				return this.horizontalAlignment_0;
			}
			set
			{
				this.horizontalAlignment_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected DashStyle DefaultBorderStyle
		{
			get
			{
				return this.dashStyle_0;
			}
			set
			{
				this.dashStyle_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected TextTransform DefaultTextTransform
		{
			get
			{
				return this.textTransform_0;
			}
			set
			{
				this.textTransform_0 = value;
				base.Invalidate();
			}
		}

		[Localizable(true)]
		[Category("Options")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Point DefaultTextOffset
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultUseTransparentBackground
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				base.Invalidate();
			}
		}

		public GroupBox()
		{
			this.color_0 = Color.White;
			this.color_1 = Color.FromArgb(213, 218, 223);
			this.int_0 = 1;
			this.color_2 = Color.FromArgb(213, 218, 223);
			this.padding_0 = new Padding(0, 40, 0, 0);
			this.ForeColor = Color.FromArgb(125, 137, 149);
			this.Font = new Font("Segoe UI", 9f);
			this.int_1 = 0;
			this.textRenderingHint_0 = TextRenderingHint.ClearTypeGridFit;
			this.horizontalAlignment_0 = HorizontalAlignment.Left;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			base.Size = new Size(300, 200);
		}

		private void method_0(Graphics graphics_0)
		{
			if (!this.bool_0)
			{
				return;
			}
			graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
			graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics_0.CompositingQuality = CompositingQuality.GammaCorrected;
			if (base.Parent == null)
			{
				return;
			}
			if (this.BackColor != Color.Transparent)
			{
				this.BackColor = Color.Transparent;
			}
			int childIndex = base.Parent.Controls.GetChildIndex(this);
			int num = base.Parent.Controls.Count - 1;
			int num2 = childIndex + 1;
			for (int i = num; i >= num2; i += -1)
			{
				Control control = base.Parent.Controls[i];
				if (control.Bounds.IntersectsWith(base.Bounds) && control.Visible)
				{
					Bitmap bitmap = new Bitmap(control.Width, control.Height, graphics_0);
					control.DrawToBitmap(bitmap, control.ClientRectangle);
					graphics_0.TranslateTransform(control.Left - base.Left, control.Top - base.Top);
					graphics_0.DrawImageUnscaled(bitmap, Point.Empty);
					graphics_0.TranslateTransform(base.Left - control.Left, base.Top - control.Top);
					bitmap.Dispose();
				}
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			this.method_0(e.Graphics);
		}

		protected override void OnResize(EventArgs e)
		{
			base.Invalidate();
			base.OnResize(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			if (this.int_1 > 0)
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.FillPath(path: Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), this.int_1 * 2), brush: new SolidBrush(this.color_0));
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				if ((this.BackgroundImage == null) & (this.int_0 == 0))
				{
					Class6.smethod_20(graphics, new SolidBrush(this.color_1), base.ClientRectangle, this.int_1, this.int_0);
				}
				else
				{
					Class6.smethod_20(graphics, new SolidBrush(this.color_1), base.ClientRectangle, this.int_1, this.int_0, this.dashStyle_0);
				}
			}
			else
			{
				graphics.FillRectangle(new SolidBrush(this.color_0), base.ClientRectangle);
				Class6.smethod_22(graphics, new SolidBrush(this.color_1), base.ClientRectangle, this.int_0, this.dashStyle_0);
			}
			Class6.smethod_13(graphics, this.color_2, base.ClientRectangle, this.padding_0, this.int_1);
			graphics.TextRenderingHint = this.textRenderingHint_0;
			Rectangle rectangle = new Rectangle(this.point_0.X, this.point_0.Y, base.Width, 40);
			if (this.horizontalAlignment_0 == HorizontalAlignment.Right)
			{
				rectangle.X = -10;
				rectangle.X += this.point_0.X;
			}
			else if (this.horizontalAlignment_0 == HorizontalAlignment.Left)
			{
				rectangle.X += 10;
			}
			using (StringFormat format = new StringFormat
			{
				FormatFlags = StringFormatFlags.NoWrap,
				Alignment = Class6.smethod_4(this.horizontalAlignment_0),
				LineAlignment = StringAlignment.Center
			})
			{
				switch (this.textTransform_0)
				{
				case TextTransform.None:
					graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rectangle, format);
					break;
				case TextTransform.UpperCase:
					graphics.DrawString(this.Text.ToUpper(), this.Font, new SolidBrush(this.ForeColor), rectangle, format);
					break;
				case TextTransform.LowerCase:
					graphics.DrawString(this.Text.ToLower(), this.Font, new SolidBrush(this.ForeColor), rectangle, format);
					break;
				}
			}
			base.OnPaint(e);
		}
	}
}

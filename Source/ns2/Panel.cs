using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns0;
using ns3;

namespace ns2
{
	[ToolboxItem(false)]
	public class Panel : System.Windows.Forms.Panel, IControl
	{
		private DashStyle dashStyle_0 = DashStyle.Solid;

		private ShadowDecoration shadowDecoration_0;

		private Color color_0;

		private Color color_1;

		private int int_0;

		private Color color_2;

		private Padding padding_0;

		private int int_1;

		private bool bool_0;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

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

		public Panel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
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

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			if (this.int_1 > 0)
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.FillPath(path: Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), checked(this.int_1 * 2)), brush: new SolidBrush(this.color_0));
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
			base.OnPaint(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.Invalidate();
			base.OnResize(e);
		}

		public void DefWndProc(Message m)
		{
			base.DefWndProc(ref m);
		}
	}
}

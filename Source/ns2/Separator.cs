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
	public class Separator : Control, IControl
	{
		private Color color_0 = Class0.color_32;

		private int int_0 = 1;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private bool bool_0;

		private Orientation orientation_0;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

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
		protected int DefaultFillThickness
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (value > 0)
				{
					this.int_0 = value;
					base.Invalidate();
				}
			}
		}

		[Browsable(false)]
		protected DashStyle DefaultFillStyle
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

		public Separator()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.SetOrientation(Orientation.Horizontal);
		}

		protected void SetOrientation(Orientation orientation)
		{
			this.orientation_0 = orientation;
			if (orientation == Orientation.Vertical)
			{
				base.Size = new Size(10, 200);
			}
			else
			{
				base.Size = new Size(200, 10);
			}
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
			using (Pen pen = new Pen(this.color_0, this.int_0))
			{
				pen.DashStyle = this.dashStyle_0;
				if (this.orientation_0 == Orientation.Vertical)
				{
					int num = base.Width / 2;
					graphics.DrawLine(pen, num, 0, num, base.Height);
				}
				else
				{
					int num2 = base.Height / 2;
					graphics.DrawLine(pen, 0, num2, base.Width, num2);
				}
			}
			base.OnPaint(e);
		}
	}
}

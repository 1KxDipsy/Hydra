using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns3;

namespace ns2
{
	[ToolboxItem(false)]
	public class ResizeControl : Control, IControl
	{
		private Control control_0;

		private Size size_0;

		private Color color_0 = Color.Black;

		private bool bool_0;

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
		protected Control DefaultTargetControl
		{
			get
			{
				return this.control_0;
			}
			set
			{
				this.control_0 = value;
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

		public ResizeControl()
		{
			this.size_0 = new Size(2, 2);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
			this.DoubleBuffered = true;
			base.Size = new Size(20, 20);
			this.ForeColor = Color.Black;
			this.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.control_0 != null)
			{
				if (e.Button == MouseButtons.Left)
				{
					base.Capture = false;
					Message m = Message.Create(this.control_0.Handle, 161, new IntPtr(17), IntPtr.Zero);
					this.DefWndProc(ref m);
				}
				base.OnMouseDown(e);
			}
		}

		protected override void OnForeColorChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnForeColorChanged(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			using (SolidBrush brush = new SolidBrush(this.color_0))
			{
				e.Graphics.FillRectangles(brush, checked(new Rectangle[6]
				{
					new Rectangle(new Point(base.ClientRectangle.Width - 6, base.ClientRectangle.Height - 6), this.size_0),
					new Rectangle(new Point(base.ClientRectangle.Width - 10, base.ClientRectangle.Height - 10), this.size_0),
					new Rectangle(new Point(base.ClientRectangle.Width - 10, base.ClientRectangle.Height - 6), this.size_0),
					new Rectangle(new Point(base.ClientRectangle.Width - 6, base.ClientRectangle.Height - 10), this.size_0),
					new Rectangle(new Point(base.ClientRectangle.Width - 14, base.ClientRectangle.Height - 6), this.size_0),
					new Rectangle(new Point(base.ClientRectangle.Width - 6, base.ClientRectangle.Height - 14), this.size_0)
				}));
			}
			base.OnPaint(e);
		}
	}
}

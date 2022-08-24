using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns3;
using ns5;

namespace ns2
{
	[ToolboxItem(false)]
	public class UIDefaultControl : Control, IControl
	{
		private int int_0 = 0;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private Color color_0 = Color.Black;

		private int int_1 = 0;

		private ShadowDecoration shadowDecoration_0;

		private bool bool_0 = false;

		internal bool bool_1 = false;

		internal bool bool_2 = false;

		protected MouseState MouseState = MouseState.const_2;

		private bool bool_3;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

		[Browsable(false)]
		protected int DefaultBorderRadius
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = ((value >= 0) ? value : 0);
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
		protected Color DefaultBorderColor
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
		protected int DefaultBorderThickness
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
				base.Invalidate();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(false)]
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
		protected bool DefaultUseTransparentBackground
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				base.Invalidate();
			}
		}

		public UIDefaultControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.bool_0 = true;
			this.MouseState = MouseState.DOWN;
			if (this.bool_1)
			{
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.MouseState = ((!this.bool_0) ? MouseState.const_2 : MouseState.HOVER);
			if (this.bool_1)
			{
				base.Invalidate();
			}
			base.OnMouseUp(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.bool_0 = true;
			this.MouseState = MouseState.HOVER;
			if (this.bool_1)
			{
				base.Invalidate();
			}
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.bool_0 = false;
			this.MouseState = MouseState.const_2;
			if (this.bool_1)
			{
				base.Invalidate();
			}
			base.OnMouseLeave(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			this.bool_0 = false;
			this.MouseState = MouseState.const_2;
			if (this.bool_2)
			{
				base.Invalidate();
			}
			base.OnLostFocus(e);
		}

		private void method_0(Graphics graphics_0)
		{
			if (!this.bool_3)
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
	}
}

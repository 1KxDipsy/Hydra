using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns3;
using ns5;
using ns7;

namespace ns2
{
	[DefaultEvent("CheckedChanged")]
	[ToolboxItem(false)]
	public class CustomCheckBox : Control, IControl
	{
		private AnimationManager animationManager_0;

		private bool bool_0 = false;

		private bool bool_1 = true;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private Color color_0 = Color.White;

		private ShadowDecoration shadowDecoration_0;

		private bool bool_2 = false;

		internal bool bool_3 = false;

		internal bool bool_4 = false;

		internal MouseState mouseState_0 = MouseState.const_2;

		private bool bool_5;

		private CustomCheckBoxState customCheckBoxState_0;

		private CustomCheckBoxState customCheckBoxState_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

		[Browsable(false)]
		protected bool DefaultChecked
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.OnCheckedChanged(EventArgs.Empty);
			}
		}

		[Browsable(false)]
		protected bool DefaultAnimated
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
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
		protected Color DefaultCheckMarkColor
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
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
				base.Invalidate();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected CustomCheckBoxState DefaultCheckedState
		{
			get
			{
				if (this.customCheckBoxState_0 == null)
				{
					this.customCheckBoxState_0 = new CustomCheckBoxState
					{
						Parent = this
					};
				}
				return this.customCheckBoxState_0;
			}
			set
			{
				this.customCheckBoxState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected CustomCheckBoxState DefaultUncheckedState
		{
			get
			{
				if (this.customCheckBoxState_1 == null)
				{
					this.customCheckBoxState_1 = new CustomCheckBoxState
					{
						Parent = this
					};
				}
				return this.customCheckBoxState_1;
			}
			set
			{
				this.customCheckBoxState_1 = value;
			}
		}

		public event EventHandler CheckedChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public CustomCheckBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.method_0();
		}

		private void method_0()
		{
			this.animationManager_0 = new AnimationManager
			{
				Increment = 0.07999999821186066,
				AnimationType = AnimationType.EaseOut
			};
			this.animationManager_0.OnAnimationProgress += new AnimationManager.AnimationProgress(method_1);
		}

		private void method_1(object object_0)
		{
			base.Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.bool_2 = true;
			this.mouseState_0 = MouseState.DOWN;
			if (this.bool_3)
			{
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.mouseState_0 = ((!this.bool_2) ? MouseState.const_2 : MouseState.HOVER);
			if (this.bool_3)
			{
				base.Invalidate();
			}
			base.OnMouseUp(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.bool_2 = true;
			this.mouseState_0 = MouseState.HOVER;
			if (this.bool_3)
			{
				base.Invalidate();
			}
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.bool_2 = false;
			this.mouseState_0 = MouseState.const_2;
			if (this.bool_3)
			{
				base.Invalidate();
			}
			base.OnMouseLeave(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			this.bool_2 = false;
			this.mouseState_0 = MouseState.const_2;
			if (this.bool_4)
			{
				base.Invalidate();
			}
			base.OnLostFocus(e);
		}

		private void method_2(Graphics graphics_0)
		{
			if (!this.bool_5)
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
			this.method_2(e.Graphics);
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCheckedChanged(EventArgs e)
		{
			if (this.animationManager_0 != null && !base.DesignMode && this.bool_1)
			{
				this.animationManager_0.StartNewAnimation((!this.bool_0) ? AnimationDirection.Out : AnimationDirection.In);
			}
			base.Invalidate();
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			if (!this.bool_0)
			{
				this.DefaultChecked = true;
			}
			else
			{
				this.DefaultChecked = false;
			}
			base.OnClick(e);
		}

		private Bitmap method_3(Color color_1, int int_0, int int_1)
		{
			Bitmap bitmap = new Bitmap(int_0, int_1);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			Rectangle rectangle = new Rectangle(1, 1, int_0 - 2, int_1 - 2);
			Point point = new Point(rectangle.Left + rectangle.Width / 2, (int)((double)(rectangle.Bottom - rectangle.Bottom / 2) + (double)rectangle.Bottom * 0.25) - 1);
			Point point2 = new Point((int)((double)rectangle.Width - (double)rectangle.Width * 0.5 - (double)rectangle.Width * 0.25) + 2, rectangle.Top + rectangle.Height / 2 + 2 - 2);
			Point point3 = new Point((int)((double)rectangle.Right - (double)rectangle.Width * 0.2) - 2 + 2, (int)((double)rectangle.Top + (double)rectangle.Height * 0.2) + 2 + 1);
			using (Pen pen = new Pen(color_1, 2f))
			{
				pen.EndCap = LineCap.Round;
				pen.StartCap = LineCap.Round;
				graphics.DrawLines(pen, new Point[4] { point, point2, point, point3 });
			}
			return bitmap;
		}

		private Bitmap method_4()
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
			Rectangle rectangle2 = new Rectangle(checked((int)Math.Round((double)rectangle.X + (double)rectangle.Width / 4.0)), checked((int)Math.Round((double)rectangle.Y + (double)rectangle.Height / 4.0)), rectangle.Width / 2, rectangle.Height / 2);
			checked
			{
				Point[] array = new Point[3]
				{
					new Point(rectangle2.X - 1, rectangle2.Y + unchecked(rectangle2.Height / 2)),
					new Point(rectangle2.X + unchecked(rectangle2.Width / 2) - 1, rectangle2.Y + rectangle2.Height - 1),
					new Point(rectangle2.X + rectangle2.Width, rectangle2.Y)
				};
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				Pen pen = new Pen(this.DefaultCheckMarkColor, 2f);
				int num = array.Length - 2;
				for (int i = 0; i <= num; i++)
				{
					graphics.DrawLine(pen, array[i], array[i + 1]);
				}
				return bitmap;
			}
		}

		private void method_5(Graphics graphics_0, CustomCheckBoxState customCheckBoxState_2)
		{
			int borderRadius = customCheckBoxState_2.BorderRadius;
			GraphicsPath graphicsPath = null;
			Color color;
			Color color2;
			if (this.bool_1 && !base.DesignMode && base.Enabled)
			{
				color = Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.FillColor, this.DefaultCheckedState.FillColor);
				color2 = Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.BorderColor, this.DefaultCheckedState.BorderColor);
				if (borderRadius > 0)
				{
					graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
					graphicsPath = Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), borderRadius * 2);
					graphics_0.FillPath(new SolidBrush(color), graphicsPath);
					if (customCheckBoxState_2.BorderThickness < 1)
					{
						graphics_0.DrawPath(new Pen(Color.FromArgb(180, color)), graphicsPath);
					}
					Class6.smethod_20(graphics_0, new SolidBrush(color2), base.ClientRectangle, borderRadius, customCheckBoxState_2.BorderThickness, this.dashStyle_0);
				}
				else
				{
					graphics_0.SmoothingMode = SmoothingMode.Default;
					graphics_0.FillRectangle(new SolidBrush(color), base.ClientRectangle);
					Class6.smethod_22(graphics_0, new SolidBrush(color2), base.ClientRectangle, customCheckBoxState_2.BorderThickness, this.dashStyle_0);
				}
				if (this.bool_0)
				{
					if (base.Height < 16)
					{
						graphics_0.DrawImageUnscaledAndClipped(this.method_4(), new Rectangle(0, 0, (int)((double)base.Width * this.animationManager_0.GetProgress()), base.Height));
					}
					else
					{
						graphics_0.DrawImageUnscaledAndClipped(this.method_3(this.color_0, base.Height, base.Width), new Rectangle(-1, -1, (int)((double)base.Width * this.animationManager_0.GetProgress()), base.Height));
					}
				}
				return;
			}
			color = customCheckBoxState_2.FillColor;
			color2 = customCheckBoxState_2.BorderColor;
			if (borderRadius > 0)
			{
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphicsPath = Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), borderRadius * 2);
				graphics_0.FillPath(new SolidBrush(color), graphicsPath);
				if (customCheckBoxState_2.BorderThickness < 1)
				{
					graphics_0.DrawPath(new Pen(Color.FromArgb(180, color)), graphicsPath);
				}
				Class6.smethod_20(graphics_0, new SolidBrush(color2), base.ClientRectangle, borderRadius, customCheckBoxState_2.BorderThickness, this.dashStyle_0);
			}
			else
			{
				graphics_0.SmoothingMode = SmoothingMode.Default;
				graphics_0.FillRectangle(new SolidBrush(color), base.ClientRectangle);
				Class6.smethod_22(graphics_0, new SolidBrush(color2), base.ClientRectangle, customCheckBoxState_2.BorderThickness, this.dashStyle_0);
			}
			if (this.bool_0)
			{
				if (base.Height < 16)
				{
					graphics_0.DrawImageUnscaledAndClipped(this.method_4(), new Rectangle(0, 0, base.Width, base.Height));
				}
				else
				{
					graphics_0.DrawImageUnscaledAndClipped(this.method_3(this.color_0, base.Height, base.Width), new Rectangle(-1, -1, base.Width, base.Height));
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Bitmap image = new Bitmap(base.Width, base.Height);
				Graphics graphics_ = Graphics.FromImage(image);
				if (this.bool_0)
				{
					this.method_5(graphics_, this.DefaultCheckedState);
				}
				else
				{
					this.method_5(graphics_, this.DefaultUncheckedState);
				}
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else if (this.bool_0)
			{
				this.method_5(e.Graphics, this.DefaultCheckedState);
			}
			else
			{
				this.method_5(e.Graphics, this.DefaultUncheckedState);
			}
			base.OnPaint(e);
		}
	}
}

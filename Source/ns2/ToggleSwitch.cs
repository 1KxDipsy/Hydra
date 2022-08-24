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
	public class ToggleSwitch : Control, IControl
	{
		private AnimationManager animationManager_0;

		private ToggleSwitchState toggleSwitchState_0;

		private ToggleSwitchState toggleSwitchState_1;

		private bool bool_0 = true;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private ShadowDecoration shadowDecoration_0;

		private bool bool_1 = false;

		private bool bool_2 = false;

		internal bool bool_3 = false;

		internal bool bool_4 = false;

		internal MouseState mouseState_0 = MouseState.const_2;

		private bool bool_5;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ToggleSwitchState DefaultCheckedState
		{
			get
			{
				if (this.toggleSwitchState_0 == null)
				{
					this.toggleSwitchState_0 = new ToggleSwitchState
					{
						Parent = this
					};
				}
				return this.toggleSwitchState_0;
			}
			set
			{
				this.toggleSwitchState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ToggleSwitchState DefaultUncheckedState
		{
			get
			{
				if (this.toggleSwitchState_1 == null)
				{
					this.toggleSwitchState_1 = new ToggleSwitchState
					{
						Parent = this
					};
				}
				return this.toggleSwitchState_1;
			}
			set
			{
				this.toggleSwitchState_1 = value;
			}
		}

		[Browsable(false)]
		protected bool DefaultAnimated
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
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
		protected bool DefaultChecked
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.OnCheckedChanged(EventArgs.Empty);
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

		public ToggleSwitch()
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
			if (this.animationManager_0 != null && !base.DesignMode)
			{
				this.animationManager_0.StartNewAnimation((!this.bool_1) ? AnimationDirection.Out : AnimationDirection.In);
			}
			base.Invalidate();
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			if (!this.bool_1)
			{
				this.DefaultChecked = true;
			}
			else
			{
				this.DefaultChecked = false;
			}
			base.OnClick(e);
		}

		private void method_3(Graphics graphics_0, ToggleSwitchState toggleSwitchState_2)
		{
			int num = 0;
			int borderRadius = toggleSwitchState_2.BorderRadius;
			GraphicsPath graphicsPath = null;
			Color color;
			Color color2;
			if (this.bool_0 && !base.DesignMode && base.Enabled)
			{
				color = Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.FillColor, this.DefaultCheckedState.FillColor);
				color2 = Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.BorderColor, this.DefaultCheckedState.BorderColor);
				if (borderRadius > 0)
				{
					graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
					graphicsPath = Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), borderRadius * 2);
					graphics_0.FillPath(new SolidBrush(color), graphicsPath);
					if (toggleSwitchState_2.BorderThickness < 1)
					{
						graphics_0.DrawPath(new Pen(Color.FromArgb(180, color)), graphicsPath);
					}
					Class6.smethod_20(graphics_0, new SolidBrush(color2), base.ClientRectangle, borderRadius, toggleSwitchState_2.BorderThickness, this.dashStyle_0);
				}
				else
				{
					graphics_0.SmoothingMode = SmoothingMode.Default;
					graphics_0.FillRectangle(new SolidBrush(color), base.ClientRectangle);
					Class6.smethod_22(graphics_0, new SolidBrush(color2), base.ClientRectangle, toggleSwitchState_2.BorderThickness, this.dashStyle_0);
				}
				int num2 = toggleSwitchState_2.InnerOffset + 8;
				int num3 = num2 / 2;
				borderRadius = toggleSwitchState_2.InnerBorderRadius;
				num = Math.Max(num3, (int)(this.animationManager_0.GetProgress() * (double)(base.Width - (base.Height - num2 + num3))));
				color = Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.InnerColor, this.DefaultCheckedState.InnerColor);
				color2 = Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.InnerBorderColor, this.DefaultCheckedState.InnerBorderColor);
				Rectangle rectangle = new Rectangle(num, num3, base.Height - num2, base.Height - num2);
				if (borderRadius > 0)
				{
					graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
					graphicsPath = Class6.smethod_12(Class6.smethod_11(rectangle), borderRadius * 2);
					graphics_0.FillPath(new SolidBrush(color), graphicsPath);
					if (toggleSwitchState_2.InnerBorderThickness < 1)
					{
						graphics_0.DrawPath(new Pen(Color.FromArgb(180, color)), graphicsPath);
					}
					Class6.smethod_20(graphics_0, new SolidBrush(color2), rectangle, borderRadius, toggleSwitchState_2.InnerBorderThickness, this.dashStyle_0);
				}
				else
				{
					graphics_0.SmoothingMode = SmoothingMode.Default;
					graphics_0.FillRectangle(new SolidBrush(color), rectangle);
					Class6.smethod_22(graphics_0, new SolidBrush(color2), rectangle, toggleSwitchState_2.InnerBorderThickness, this.dashStyle_0);
				}
				return;
			}
			color = toggleSwitchState_2.FillColor;
			color2 = toggleSwitchState_2.BorderColor;
			if (borderRadius > 0)
			{
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphicsPath = Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), borderRadius * 2);
				graphics_0.FillPath(new SolidBrush(color), graphicsPath);
				if (toggleSwitchState_2.BorderThickness < 1)
				{
					graphics_0.DrawPath(new Pen(Color.FromArgb(180, color)), graphicsPath);
				}
				Class6.smethod_20(graphics_0, new SolidBrush(color2), base.ClientRectangle, borderRadius, toggleSwitchState_2.BorderThickness, this.dashStyle_0);
			}
			else
			{
				graphics_0.SmoothingMode = SmoothingMode.Default;
				graphics_0.FillRectangle(new SolidBrush(color), base.ClientRectangle);
				Class6.smethod_22(graphics_0, new SolidBrush(color2), base.ClientRectangle, toggleSwitchState_2.BorderThickness, this.dashStyle_0);
			}
			int num4 = toggleSwitchState_2.InnerOffset + 8;
			int num5 = num4 / 2;
			borderRadius = toggleSwitchState_2.InnerBorderRadius;
			num = (this.bool_1 ? (base.Width - (base.Height - num4 + num5)) : num5);
			color = toggleSwitchState_2.InnerColor;
			color2 = toggleSwitchState_2.InnerBorderColor;
			Rectangle rectangle2 = new Rectangle(num, num5, base.Height - num4, base.Height - num4);
			if (borderRadius > 0)
			{
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphicsPath = Class6.smethod_12(Class6.smethod_11(rectangle2), borderRadius * 2);
				graphics_0.FillPath(new SolidBrush(color), graphicsPath);
				if (toggleSwitchState_2.InnerBorderThickness < 1)
				{
					graphics_0.DrawPath(new Pen(Color.FromArgb(180, color)), graphicsPath);
				}
				Class6.smethod_20(graphics_0, new SolidBrush(color2), rectangle2, borderRadius, toggleSwitchState_2.InnerBorderThickness, this.dashStyle_0);
			}
			else
			{
				graphics_0.SmoothingMode = SmoothingMode.Default;
				graphics_0.FillRectangle(new SolidBrush(color), rectangle2);
				Class6.smethod_22(graphics_0, new SolidBrush(color2), rectangle2, toggleSwitchState_2.InnerBorderThickness, this.dashStyle_0);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Bitmap image = new Bitmap(base.Width, base.Height);
				Graphics graphics_ = Graphics.FromImage(image);
				if (this.bool_1)
				{
					this.method_3(graphics_, this.DefaultCheckedState);
				}
				else
				{
					this.method_3(graphics_, this.DefaultUncheckedState);
				}
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else if (this.bool_1)
			{
				this.method_3(e.Graphics, this.DefaultCheckedState);
			}
			else
			{
				this.method_3(e.Graphics, this.DefaultUncheckedState);
			}
			base.OnPaint(e);
		}
	}
}

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
	public class CustomRadioButton : Control, IControl
	{
		private AnimationManager animationManager_0;

		private CustomRadionButtonState customRadionButtonState_0;

		private CustomRadionButtonState customRadionButtonState_1;

		private bool bool_0 = false;

		private bool bool_1 = true;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private ShadowDecoration shadowDecoration_0;

		private bool bool_2 = false;

		internal bool bool_3 = false;

		internal bool bool_4 = false;

		internal MouseState mouseState_0 = MouseState.const_2;

		private bool bool_5;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected CustomRadionButtonState DefaultCheckedState
		{
			get
			{
				if (this.customRadionButtonState_0 == null)
				{
					this.customRadionButtonState_0 = new CustomRadionButtonState
					{
						Parent = this
					};
				}
				return this.customRadionButtonState_0;
			}
			set
			{
				this.customRadionButtonState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected CustomRadionButtonState DefaultUncheckedState
		{
			get
			{
				if (this.customRadionButtonState_1 == null)
				{
					this.customRadionButtonState_1 = new CustomRadionButtonState
					{
						Parent = this
					};
				}
				return this.customRadionButtonState_1;
			}
			set
			{
				this.customRadionButtonState_1 = value;
			}
		}

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

		public CustomRadioButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.method_1();
		}

		private void method_0()
		{
			if (!base.IsHandleCreated || !this.bool_0)
			{
				return;
			}
			foreach (Control control in base.Parent.Controls)
			{
				if (control != this && control is CustomRadioButton && control != this)
				{
					CustomRadioButton customRadioButton = (CustomRadioButton)control;
					if (customRadioButton.bool_0)
					{
						customRadioButton.DefaultChecked = false;
					}
				}
			}
		}

		private void method_1()
		{
			this.animationManager_0 = new AnimationManager
			{
				Increment = 0.07999999821186066,
				AnimationType = AnimationType.EaseOut
			};
			this.animationManager_0.OnAnimationProgress += new AnimationManager.AnimationProgress(method_2);
		}

		private void method_2(object object_0)
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

		private void method_3(Graphics graphics_0)
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
			this.method_3(e.Graphics);
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCheckedChanged(EventArgs e)
		{
			if (this.bool_0)
			{
				this.method_0();
			}
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
			base.OnClick(e);
		}

		private void method_4(Graphics graphics_0, CustomRadionButtonState customRadionButtonState_2)
		{
			GraphicsPath graphicsPath = null;
			int num = customRadionButtonState_2.InnerOffset + 11;
			if (this.bool_1 && !base.DesignMode && base.Enabled)
			{
				Color color = ((!this.bool_0) ? customRadionButtonState_2.FillColor : Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.BorderColor, this.DefaultCheckedState.FillColor));
				Color color2 = Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.BorderColor, this.DefaultCheckedState.BorderColor);
				graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(0, 0, base.Width - 1, base.Height - 1);
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphics_0.FillPath(new SolidBrush(color), graphicsPath);
				Class6.smethod_19(graphics_0, new SolidBrush(color2), base.ClientRectangle, customRadionButtonState_2.BorderThickness, this.dashStyle_0);
				if (this.bool_0 && customRadionButtonState_2.BorderThickness == 0)
				{
					Class6.smethod_19(graphics_0, new SolidBrush(color), base.ClientRectangle, 2);
				}
				float num2 = base.Width - num;
				float num3 = base.Height - num;
				float num4 = (float)(base.Width / 2) - num2 / 2f;
				float num5 = (float)(base.Height / 2) - num3 / 2f;
				num2 -= 1f;
				num3 -= 1f;
				if (this.bool_0)
				{
					color = Class6.smethod_23((int)(this.animationManager_0.GetProgress() * 100.0), this.DefaultUncheckedState.InnerColor, this.DefaultCheckedState.InnerColor);
					num2 = (int)(this.animationManager_0.GetProgress() * (double)num2);
					num3 = (int)(this.animationManager_0.GetProgress() * (double)num3);
					num4 = (float)(base.Width / 2) - (num2 + 1f) / 2f;
					num5 = (float)(base.Height / 2) - (num3 + 1f) / 2f;
					if (base.Height < 16)
					{
						num4 += 0.3f;
						num5 += 0.5f;
					}
				}
				else
				{
					color = customRadionButtonState_2.InnerColor;
				}
				RectangleF rect = new RectangleF(num4, num5, num2, num3);
				graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(rect);
				graphics_0.FillPath(new SolidBrush(color), graphicsPath);
			}
			else
			{
				Color color = customRadionButtonState_2.FillColor;
				Color color2 = customRadionButtonState_2.BorderColor;
				graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(0, 0, base.Width - 1, base.Height - 1);
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphics_0.FillPath(new SolidBrush(color), graphicsPath);
				Class6.smethod_19(graphics_0, new SolidBrush(color2), base.ClientRectangle, customRadionButtonState_2.BorderThickness, this.dashStyle_0);
				if (this.bool_0 && customRadionButtonState_2.BorderThickness == 0)
				{
					Class6.smethod_19(graphics_0, new SolidBrush(color), base.ClientRectangle, 2);
				}
				color = customRadionButtonState_2.InnerColor;
				float num2 = base.Width - num;
				float num3 = base.Height - num;
				float num4 = (float)(base.Width / 2) - num2 / 2f;
				float num5 = (float)(base.Height / 2) - num3 / 2f;
				if (base.Height < 16)
				{
					num4 += 0.3f;
					num5 += 0.5f;
				}
				RectangleF rect2 = new RectangleF(num4, num5, num2 - 1f, num3 - 1f);
				graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(rect2);
				graphics_0.FillPath(new SolidBrush(color), graphicsPath);
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
					this.method_4(graphics_, this.DefaultCheckedState);
				}
				else
				{
					this.method_4(graphics_, this.DefaultUncheckedState);
				}
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else if (this.bool_0)
			{
				this.method_4(e.Graphics, this.DefaultCheckedState);
			}
			else
			{
				this.method_4(e.Graphics, this.DefaultUncheckedState);
			}
			base.OnPaint(e);
		}
	}
}

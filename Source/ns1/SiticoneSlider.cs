using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns3;
using ns5;
using ns7;

namespace ns1
{
	[Description("An advanced Slider Control")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[DefaultEvent("Scroll")]
	[ToolboxBitmap(typeof(TrackBar))]
	public class SiticoneSlider : Control, IControl
	{
		private MouseState mouseState_0;

		private Orientation orientation_0;

		private int int_0;

		private Rectangle rectangle_0;

		private Rectangle rectangle_1;

		private Rectangle rectangle_2;

		private Rectangle rectangle_3;

		private int int_1;

		private int int_2;

		private bool bool_0;

		private AnimationManager animationManager_0;

		private AnimationManager animationManager_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_1;

		private Color color_0;

		private Color color_1;

		private int int_3;

		private int int_4;

		private bool bool_1 = false;

		private int int_5;

		private int int_6;

		private int int_7;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Font font_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color color_2;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

		private Rectangle Rectangle_0
		{
			get
			{
				if (base.Enabled)
				{
					return this.rectangle_3;
				}
				return (this.orientation_0 != 0) ? new Rectangle(this.rectangle_3.X + 1, this.rectangle_3.Y + 3, this.rectangle_3.Width - 6, this.rectangle_3.Height - 6) : new Rectangle(this.rectangle_3.X + 3, this.rectangle_3.Y, this.rectangle_3.Width - 6, this.rectangle_3.Height - 6);
			}
			set
			{
				this.rectangle_3 = value;
			}
		}

		[Category("Colors")]
		[Description("The slider's thumb color")]
		[DefaultValue(typeof(Color), "98, 0, 238")]
		public Color ThumbColor
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

		[DefaultValue(typeof(Color), "198, 174, 231")]
		[Description("The slider's fill color")]
		[Category("Colors")]
		public Color FillColor
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

		[DefaultValue(0)]
		[Description("The slider's minimum value")]
		public int Minimum
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				if (value > this.int_5)
				{
					this.int_5 = value;
				}
				if (value > this.int_4)
				{
					this.int_4 = value;
				}
				this.method_4();
			}
		}

		[DefaultValue(100)]
		[Description("The slider's maximum value")]
		public int Maximum
		{
			get
			{
				return this.int_4;
			}
			set
			{
				if (value < this.int_5)
				{
					this.int_5 = value;
				}
				if (value < this.int_3)
				{
					this.int_3 = value;
				}
			}
		}

		[DefaultValue(false)]
		[Description("If true, the slider slides backwards")]
		public bool Backwards
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					int value2 = this.Value;
					this.bool_1 = value;
					this.Value = value2;
				}
			}
		}

		[Description("The slider's current value")]
		[DefaultValue(0)]
		public int Value
		{
			get
			{
				if (this.Backwards)
				{
					return this.Maximum - this.Int32_0;
				}
				return this.Int32_0;
			}
			set
			{
				if (this.Backwards)
				{
					this.Int32_0 = this.Maximum - value;
				}
				else
				{
					this.Int32_0 = value;
				}
			}
		}

		private int Int32_0
		{
			get
			{
				return this.int_5;
			}
			set
			{
				if (value != this.int_5)
				{
					if (value < this.int_3)
					{
						this.int_5 = this.int_3;
					}
					else if (value > this.int_4)
					{
						this.int_5 = this.int_4;
					}
					else
					{
						this.int_5 = value;
					}
					this.method_5();
					this.OnValueChanged(EventArgs.Empty);
					this.OnScroll(EventArgs.Empty);
				}
			}
		}

		[Description("The slider's small change")]
		[DefaultValue(1)]
		public int SmallChange
		{
			get
			{
				return this.int_6;
			}
			set
			{
				if (value > 1)
				{
					this.int_7 = value;
				}
			}
		}

		[DefaultValue(10)]
		[Description("The slider's large change")]
		public int LargeChange
		{
			get
			{
				return this.int_7;
			}
			set
			{
				if (value > 1)
				{
					this.int_7 = value;
				}
			}
		}

		[Description("The slider's font style")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new Font Font
		{
			[CompilerGenerated]
			get
			{
				return this.font_0;
			}
			[CompilerGenerated]
			set
			{
				this.font_0 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The slider's text")]
		[Browsable(false)]
		public new string Text
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		[Description("The slider's ForeColor")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new Color ForeColor
		{
			[CompilerGenerated]
			get
			{
				return this.color_2;
			}
			[CompilerGenerated]
			set
			{
				this.color_2 = value;
			}
		}

		public event EventHandler ValueChanged
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

		public event EventHandler Scroll
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public SiticoneSlider()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.method_0();
			this.mouseState_0 = MouseState.const_2;
			this.int_1 = 16;
			this.int_3 = 0;
			this.int_4 = 100;
			this.int_5 = 0;
			this.int_6 = 1;
			this.int_7 = 10;
			this.int_2 = 40;
			this.bool_0 = false;
			this.color_0 = Color.FromArgb(98, 0, 238);
			this.color_1 = Color.FromArgb(198, 174, 231);
			if (((uint)this.CreateParams.Style & (true ? 1u : 0u)) != 0)
			{
				this.orientation_0 = Orientation.Vertical;
				base.Size = new Size(60, 300);
			}
			else
			{
				this.orientation_0 = Orientation.Horizontal;
				base.Size = new Size(300, 60);
				Class13.smethod_0();
			}
		}

		protected override void OnClientSizeChanged(EventArgs e)
		{
			if (base.Height < 60)
			{
				base.Height = 60;
			}
		}

		private void method_0()
		{
			if (this.animationManager_0 == null)
			{
				this.animationManager_0 = new AnimationManager
				{
					Increment = 0.08,
					AnimationType = AnimationType.Linear
				};
				this.animationManager_0.OnAnimationProgress += new AnimationManager.AnimationProgress(method_2);
			}
			if (this.animationManager_1 == null)
			{
				this.animationManager_1 = new AnimationManager
				{
					Increment = 0.09,
					AnimationType = AnimationType.Linear
				};
				this.animationManager_1.OnAnimationProgress += new AnimationManager.AnimationProgress(method_1);
			}
		}

		private void method_1(object object_0)
		{
			base.Invalidate();
		}

		private void method_2(object object_0)
		{
			base.Invalidate();
		}

		private void method_3()
		{
			if (!base.DesignMode)
			{
				switch (this.mouseState_0)
				{
				case MouseState.HOVER:
					this.animationManager_0.StartNewAnimation(AnimationDirection.Out);
					this.animationManager_1.StartNewAnimation(AnimationDirection.In);
					break;
				case MouseState.DOWN:
					this.animationManager_0.StartNewAnimation(AnimationDirection.In);
					break;
				case MouseState.const_2:
					this.animationManager_1.StartNewAnimation(AnimationDirection.Out);
					this.animationManager_0.StartNewAnimation(AnimationDirection.Out);
					break;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValueChanged(EventArgs e)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnScroll(EventArgs e)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, EventArgs.Empty);
			}
		}

		private void method_4()
		{
			if (this.orientation_0 == Orientation.Horizontal)
			{
				this.rectangle_0 = new Rectangle(0, 0, 0, base.Height);
				this.rectangle_2 = new Rectangle(this.rectangle_0.Right, 0, base.Width - this.int_2, base.Height);
				this.Rectangle_0 = new Rectangle(0, (int)Math.Round((double)base.Height / 2.0 - (double)this.int_1 / 2.0), this.int_1, this.int_1);
			}
			else
			{
				this.rectangle_0 = new Rectangle(0, 0, base.Width, 0);
				this.rectangle_2 = new Rectangle(0, this.rectangle_0.Right, base.Width, base.Height - this.int_2);
				this.Rectangle_0 = new Rectangle((int)Math.Round((double)base.Width / 2.0 - (double)this.int_1 / 2.0), 0, this.int_1, this.int_1);
			}
			this.method_5();
		}

		private void method_5()
		{
			if (this.orientation_0 == Orientation.Horizontal)
			{
				this.rectangle_3.X = (int)Math.Round((double)checked((int)Math.Round((double)(this.int_5 - this.int_3) / (double)(this.int_4 - this.int_3) * (double)(this.rectangle_2.Width - this.int_1))) + (double)this.int_2 / 2.0);
			}
			else
			{
				this.rectangle_3.Y = (int)Math.Round((double)checked((int)Math.Round((double)(this.int_5 - this.int_3) / (double)(this.int_4 - this.int_3) * (double)(this.rectangle_2.Height - this.int_1))) + (double)this.int_2 / 2.0);
			}
			base.Invalidate();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.mouseState_0 = MouseState.HOVER;
			this.method_3();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.mouseState_0 = MouseState.const_2;
			this.method_3();
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			checked
			{
				if (this.Focused)
				{
					switch (e.KeyCode)
					{
					default:
						return;
					case Keys.Prior:
						this.int_0 = this.int_5 + this.int_7;
						break;
					case Keys.Next:
						this.int_0 = this.int_5 - this.int_7;
						break;
					case Keys.End:
						this.int_0 = this.int_4;
						break;
					case Keys.Home:
						this.int_0 = this.int_3;
						break;
					case Keys.Up:
					case Keys.Right:
						this.int_0 = this.int_5 + this.int_6;
						break;
					case Keys.Left:
					case Keys.Down:
						this.int_0 = this.int_5 - this.int_6;
						break;
					}
					this.Int32_0 = Math.Min(Math.Max(this.int_0, this.int_3), this.int_4);
					this.method_5();
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.mouseState_0 = MouseState.DOWN;
				this.method_3();
				base.Capture = true;
				if (this.rectangle_0.Contains(e.Location))
				{
					this.int_0 = this.int_5 - this.int_6;
				}
				else
				{
					if (this.rectangle_1.Contains(e.Location))
					{
						this.int_0 = this.int_5 + this.int_6;
					}
					else
					{
						if (this.Rectangle_0.Contains(e.Location))
						{
							this.bool_0 = true;
							return;
						}
						if ((this.orientation_0 != 0) ? (e.Y < this.Rectangle_0.Y) : (e.X < this.Rectangle_0.X))
						{
							this.int_0 = this.int_5 - this.int_7;
						}
						else
						{
							this.int_0 = this.int_5 + this.int_7;
						}
					}
					this.Int32_0 = Math.Min(Math.Max(this.int_0, this.int_3), this.int_4);
					this.method_5();
				}
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.mouseState_0 = MouseState.HOVER;
			this.method_3();
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (!this.Focused)
			{
				this.mouseState_0 = MouseState.const_2;
			}
			this.method_3();
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (base.Capture & this.bool_0)
			{
				int num;
				int num2;
				if (this.orientation_0 == Orientation.Horizontal)
				{
					num = (int)Math.Round((double)e.X - (double)this.int_2 / 2.0 - (double)this.rectangle_0.Width - (double)(this.int_1 / 2));
					num2 = this.rectangle_2.Width - this.int_1;
				}
				else
				{
					num = (int)Math.Round((double)e.Y - (double)this.int_2 / 2.0 - (double)this.rectangle_0.Height - (double)(this.int_1 / 2));
					num2 = this.rectangle_2.Height - this.int_1;
				}
				this.int_0 = (int)Math.Round((double)num / (double)num2 * (double)checked(this.int_4 - this.int_3)) + this.int_3;
				this.Int32_0 = Math.Min(Math.Max(this.int_0, this.int_3), this.int_4);
				this.method_5();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.mouseState_0 = MouseState.HOVER;
			this.method_3();
			base.Invalidate();
			base.OnMouseUp(e);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			this.mouseState_0 = MouseState.DOWN;
			this.method_3();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			this.method_4();
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if ((keyData == Keys.Tab) | (Control.ModifierKeys == Keys.Shift))
			{
				return base.ProcessDialogKey(keyData);
			}
			return true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			int num = this.Rectangle_0.X;
			int num2 = this.Rectangle_0.Y;
			int num3 = this.Rectangle_0.Width;
			num -= (int)Math.Round(this.animationManager_1.GetProgress() * 10.0);
			num2 -= (int)Math.Round(this.animationManager_1.GetProgress() * 10.0);
			num3 += (int)Math.Round(this.animationManager_1.GetProgress() * 20.0);
			num -= (int)Math.Round(this.animationManager_0.GetProgress() * 10.0);
			num2 -= (int)Math.Round(this.animationManager_0.GetProgress() * 10.0);
			num3 += (int)Math.Round(this.animationManager_0.GetProgress() * 20.0);
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (this.orientation_0 == Orientation.Horizontal)
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				if (this.Backwards)
				{
					graphics.FillRectangle(new SolidBrush(this.color_1), new Rectangle((int)Math.Round((double)this.int_2 / 2.0), this.Rectangle_0.Y + 6, (int)Math.Round((double)this.Rectangle_0.X - (double)this.int_2 / 2.0 - (base.Enabled ? 0.0 : ((double)this.Rectangle_0.Width / 2.0))), 3));
					graphics.FillRectangle(new SolidBrush(this.color_0), new Rectangle((int)Math.Round((double)checked(this.Rectangle_0.X + this.Rectangle_0.Width) + (base.Enabled ? 0.0 : ((double)this.Rectangle_0.Width / 2.0))), this.Rectangle_0.Y + 6, (int)Math.Round((double)base.Width - ((double)checked(this.Rectangle_0.X + this.Rectangle_0.Width) + (double)this.int_2 / 2.0) - (double)((!base.Enabled) ? this.Rectangle_0.Width : 0)), 3));
				}
				else
				{
					graphics.FillRectangle(new SolidBrush(this.color_0), new Rectangle((int)Math.Round((double)this.int_2 / 2.0), this.Rectangle_0.Y + 6, (int)Math.Round((double)this.Rectangle_0.X - (double)this.int_2 / 2.0 - (base.Enabled ? 0.0 : ((double)this.Rectangle_0.Width / 2.0))), 3));
					graphics.FillRectangle(new SolidBrush(this.color_1), new Rectangle((int)Math.Round((double)checked(this.Rectangle_0.X + this.Rectangle_0.Width) + (base.Enabled ? 0.0 : ((double)this.Rectangle_0.Width / 2.0))), this.Rectangle_0.Y + 6, (int)Math.Round((double)base.Width - ((double)checked(this.Rectangle_0.X + this.Rectangle_0.Width) + (double)this.int_2 / 2.0) - (double)((!base.Enabled) ? this.Rectangle_0.Width : 0)), 3));
				}
				graphics.FillEllipse(new SolidBrush(this.color_0), this.Rectangle_0.X, base.Enabled ? this.Rectangle_0.Y : (this.Rectangle_0.Y + 2), this.Rectangle_0.Width, this.Rectangle_0.Height);
				graphics.FillEllipse(new SolidBrush(Color.FromArgb(30, this.color_0)), num, base.Enabled ? num2 : (num2 + 2), num3, num3);
			}
			else
			{
				if (this.Backwards)
				{
					graphics.FillRectangle(new SolidBrush(this.color_1), new Rectangle(this.Rectangle_0.X + 6, (int)Math.Round((double)this.int_2 / 2.0), 3, (int)Math.Round((double)this.Rectangle_0.Y - (double)this.int_2 / 2.0 - (base.Enabled ? 0.0 : ((double)this.Rectangle_0.Height / 2.0)))));
					graphics.FillRectangle(new SolidBrush(this.color_0), new Rectangle(this.Rectangle_0.X + 6, (int)Math.Round((double)checked(this.Rectangle_0.Y + this.Rectangle_0.Height) + (base.Enabled ? 0.0 : ((double)this.Rectangle_0.Height / 2.0))), 3, (int)Math.Round((double)base.Height - ((double)checked(this.Rectangle_0.Y + this.Rectangle_0.Height) + (double)this.int_2 / 2.0) - (double)((!base.Enabled) ? this.Rectangle_0.Height : 0))));
				}
				else
				{
					graphics.FillRectangle(new SolidBrush(this.color_0), new Rectangle(this.Rectangle_0.X + 6, (int)Math.Round((double)this.int_2 / 2.0), 3, (int)Math.Round((double)this.Rectangle_0.Y - (double)this.int_2 / 2.0 - (base.Enabled ? 0.0 : ((double)this.Rectangle_0.Height / 2.0)))));
					graphics.FillRectangle(new SolidBrush(this.color_1), new Rectangle(this.Rectangle_0.X + 6, (int)Math.Round((double)checked(this.Rectangle_0.Y + this.Rectangle_0.Height) + (base.Enabled ? 0.0 : ((double)this.Rectangle_0.Height / 2.0))), 3, (int)Math.Round((double)base.Height - ((double)checked(this.Rectangle_0.Y + this.Rectangle_0.Height) + (double)this.int_2 / 2.0) - (double)((!base.Enabled) ? this.Rectangle_0.Height : 0))));
				}
				graphics.FillEllipse(new SolidBrush(this.ThumbColor), base.Enabled ? this.Rectangle_0.X : (this.Rectangle_0.X + 2), this.Rectangle_0.Y, this.Rectangle_0.Width, this.Rectangle_0.Height);
				graphics.FillEllipse(new SolidBrush(Color.FromArgb(30, this.color_0)), base.Enabled ? num : (num + 2), num2, num3, num3);
			}
			base.OnPaint(e);
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			if (!base.Enabled)
			{
				ControlPaint.DrawImageDisabled(e.Graphics, bitmap, 0, 0, Color.White);
			}
			else
			{
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			}
			bitmap.Dispose();
		}
	}
}

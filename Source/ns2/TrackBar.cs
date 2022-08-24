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

namespace ns2
{
	[ToolboxItem(false)]
	[DefaultEvent("Scroll")]
	[ToolboxBitmap(typeof(TrackBar))]
	public class TrackBar : Control, IControl
	{
		private Orientation orientation_0 = Orientation.Horizontal;

		private bool bool_0;

		private int int_0 = 50;

		private int int_1;

		private int int_2 = 100;

		private int int_3 = 1;

		private int int_4 = 5;

		private int int_5 = 10;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ScrollEventHandler scrollEventHandler_0;

		private TrackBarState trackBarState_0;

		private Color color_0 = Class0.color_22;

		private Color color_1 = Class0.color_32;

		private TrackBarStyle trackBarStyle_0 = TrackBarStyle.Default;

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[Browsable(false)]
		public MouseState MouseState
		{
			get
			{
				if (this.bool_1 && !this.bool_2)
				{
					return MouseState.HOVER;
				}
				if (this.bool_1 && this.bool_2)
				{
					return MouseState.DOWN;
				}
				return MouseState.const_2;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected TrackBarState DefaultHoveredState
		{
			get
			{
				if (this.trackBarState_0 == null)
				{
					this.trackBarState_0 = new TrackBarState
					{
						Parent = this
					};
				}
				return this.trackBarState_0;
			}
			set
			{
				this.trackBarState_0 = value;
			}
		}

		[Browsable(false)]
		protected bool DefaultUseSelectable
		{
			get
			{
				return base.GetStyle(ControlStyles.Selectable);
			}
			set
			{
				base.SetStyle(ControlStyles.Selectable, value);
			}
		}

		[Browsable(false)]
		protected bool DefaultDisplayFocus
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
		protected int DefaultValue
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (!((value >= this.int_1) & (value <= this.int_2)))
				{
					throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max)");
				}
				this.int_0 = value;
				this.OnValueChanged(EventArgs.Empty);
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultMinimum
		{
			get
			{
				return this.int_1;
			}
			set
			{
				if (value < this.int_2)
				{
					this.int_1 = value;
					if (this.int_0 < this.int_1)
					{
						this.int_0 = this.int_1;
						if (this.eventHandler_0 != null)
						{
							this.eventHandler_0(this, new EventArgs());
						}
					}
					base.Invalidate();
					return;
				}
				throw new ArgumentOutOfRangeException("Minimal value is greather than maximal one");
			}
		}

		[Browsable(false)]
		protected int DefaultMaximum
		{
			get
			{
				return this.int_2;
			}
			set
			{
				if (value > this.int_1)
				{
					this.int_2 = value;
					if (this.int_0 > this.int_2)
					{
						this.int_0 = this.int_2;
						if (this.eventHandler_0 != null)
						{
							this.eventHandler_0(this, new EventArgs());
						}
					}
					base.Invalidate();
					return;
				}
				throw new ArgumentOutOfRangeException("Maximal value is lower than minimal one");
			}
		}

		[Browsable(false)]
		protected int DefaultSmallChange
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}

		[Browsable(false)]
		protected int DefaultLargeChange
		{
			get
			{
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
			}
		}

		[Browsable(false)]
		protected int DefaultMouseWheelBarPartitions
		{
			get
			{
				return this.int_5;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero");
				}
				this.int_5 = value;
			}
		}

		[Browsable(false)]
		protected Color DefaultThumbColor
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
		protected TrackBarStyle DefaultStyle
		{
			get
			{
				return this.trackBarStyle_0;
			}
			set
			{
				this.trackBarStyle_0 = value;
				base.Invalidate();
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

		public event ScrollEventHandler Scroll
		{
			[CompilerGenerated]
			add
			{
				ScrollEventHandler scrollEventHandler = this.scrollEventHandler_0;
				ScrollEventHandler scrollEventHandler2;
				do
				{
					scrollEventHandler2 = scrollEventHandler;
					scrollEventHandler = Interlocked.CompareExchange(value: (ScrollEventHandler)Delegate.Combine(scrollEventHandler2, value), location1: ref this.scrollEventHandler_0, comparand: scrollEventHandler2);
				}
				while ((object)scrollEventHandler != scrollEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ScrollEventHandler scrollEventHandler = this.scrollEventHandler_0;
				ScrollEventHandler scrollEventHandler2;
				do
				{
					scrollEventHandler2 = scrollEventHandler;
					scrollEventHandler = Interlocked.CompareExchange(value: (ScrollEventHandler)Delegate.Remove(scrollEventHandler2, value), location1: ref this.scrollEventHandler_0, comparand: scrollEventHandler2);
				}
				while ((object)scrollEventHandler != scrollEventHandler2);
			}
		}

		public TrackBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.DoubleBuffered = true;
			if (((uint)this.CreateParams.Style & (true ? 1u : 0u)) != 0)
			{
				this.orientation_0 = Orientation.Vertical;
				base.Size = new Size(23, 300);
			}
			else
			{
				this.orientation_0 = Orientation.Horizontal;
				base.Size = new Size(300, 23);
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
		private void method_0(ScrollEventType scrollEventType_0, int int_6)
		{
			if (this.scrollEventHandler_0 != null)
			{
				this.scrollEventHandler_0(this, new ScrollEventArgs(scrollEventType_0, int_6));
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Bitmap image = new Bitmap(base.Width, base.Height);
				this.method_1(Graphics.FromImage(image));
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else
			{
				this.method_1(e.Graphics);
			}
			base.OnPaint(e);
		}

		private void method_1(Graphics graphics_0)
		{
			Color color_;
			Color color_2;
			if ((this.MouseState == MouseState.DOWN) | (this.MouseState == MouseState.HOVER))
			{
				color_ = ((this.DefaultHoveredState.FillColor == Color.Empty) ? this.color_1 : this.DefaultHoveredState.FillColor);
				color_2 = ((this.DefaultHoveredState.ThumbColor == Color.Empty) ? this.color_0 : this.DefaultHoveredState.ThumbColor);
			}
			else
			{
				color_ = this.color_1;
				color_2 = this.color_0;
			}
			if (this.trackBarStyle_0 == TrackBarStyle.Default)
			{
				this.method_3(graphics_0, color_2, color_);
			}
			else
			{
				this.method_2(graphics_0, color_2, color_);
			}
			if (this.bool_0 && this.bool_3)
			{
				ControlPaint.DrawFocusRectangle(graphics_0, base.ClientRectangle);
			}
		}

		private void method_2(Graphics graphics_0, Color color_2, Color color_3)
		{
			if (this.orientation_0 == Orientation.Horizontal)
			{
				int num = (this.int_0 - this.int_1) * (base.Width - 6) / (this.int_2 - this.int_1);
				using (SolidBrush brush = new SolidBrush(color_2))
				{
					graphics_0.FillRectangle(brush, new Rectangle(0, base.Height / 2 - 2, num, 4));
					graphics_0.FillRectangle(brush, new Rectangle(num, base.Height / 2 - 8, 6, 16));
				}
				using SolidBrush brush2 = new SolidBrush(color_3);
				graphics_0.FillRectangle(brush2, new Rectangle(num + 7, base.Height / 2 - 2, base.Width - num + 7, 4));
				return;
			}
			int num2 = (this.int_0 - this.int_1) * (base.Height - 6) / (this.int_2 - this.int_1);
			using (SolidBrush brush3 = new SolidBrush(color_2))
			{
				graphics_0.FillRectangle(brush3, new Rectangle(base.Width / 2 - 2, 0, 4, num2));
				graphics_0.FillRectangle(brush3, new Rectangle(base.Width / 2 - 8, num2, 16, 6));
			}
			using SolidBrush brush4 = new SolidBrush(color_3);
			graphics_0.FillRectangle(brush4, new Rectangle(base.Width / 2 - 2, num2 + 7, 4, base.Height - num2 + 7));
		}

		private void method_3(Graphics graphics_0, Color color_2, Color color_3)
		{
			checked
			{
				if (this.orientation_0 == Orientation.Horizontal)
				{
					int num = (int)Math.Round((double)((this.int_0 - this.int_1) * (base.Width - 19)) / (double)(this.int_2 - this.int_1));
					int num2 = 17;
					int val = num;
					int num3 = (int)Math.Round((double)base.Height / 2.0 - (double)(int)Math.Round(8.5));
					val = Math.Max(1, val);
					using (SolidBrush brush = new SolidBrush(color_2))
					{
						graphics_0.FillRectangle(brush, new Rectangle(0, (int)Math.Round((double)base.Height / 2.0 - 2.0), val, 3));
					}
					using (SolidBrush brush2 = new SolidBrush(color_3))
					{
						graphics_0.FillRectangle(brush2, new Rectangle(val + num2, (int)Math.Round((double)base.Height / 2.0 - 2.0), base.Width - (val + num2), 3));
					}
					graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
					graphics_0.DrawEllipse(new Pen(color_2, 3f), val, num3 - 1, num2, num2);
					if (this.bool_1 && this.bool_2 && base.Enabled)
					{
						graphics_0.FillEllipse(new SolidBrush(color_2), val, num3 - 1, num2, num2);
					}
				}
				else
				{
					int val2 = (int)Math.Round((double)((this.int_0 - this.int_1) * (base.Height - 19)) / (double)(this.int_2 - this.int_1));
					int num4 = 17;
					int num5 = (int)Math.Round((double)base.Width / 2.0 - (double)(int)Math.Round(8.5));
					int num6 = Math.Max(1, val2);
					using (SolidBrush brush3 = new SolidBrush(color_2))
					{
						graphics_0.FillRectangle(brush3, new Rectangle((int)Math.Round((double)base.Width / 2.0 - 2.0), 0, 3, num6));
					}
					using (SolidBrush brush4 = new SolidBrush(color_3))
					{
						graphics_0.FillRectangle(brush4, new Rectangle((int)Math.Round((double)base.Width / 2.0 - 2.0), num6 + num4, 3, base.Height - (num6 + num4)));
					}
					graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
					graphics_0.DrawEllipse(new Pen(color_2, 3f), num5 - 1, num6, num4, num4);
					if (this.bool_1 && this.bool_2 && base.Enabled)
					{
						graphics_0.FillEllipse(new SolidBrush(color_2), num5 - 1, num6, num4, num4);
					}
				}
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			this.bool_3 = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			this.bool_3 = false;
			this.bool_1 = false;
			this.bool_2 = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		protected override void OnEnter(EventArgs e)
		{
			this.bool_3 = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			this.bool_3 = false;
			this.bool_1 = false;
			this.bool_2 = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			this.bool_1 = true;
			this.bool_2 = true;
			base.Invalidate();
			base.OnKeyDown(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.bool_1 = false;
			this.bool_2 = false;
			base.Invalidate();
			base.OnKeyUp(e);
			switch (e.KeyCode)
			{
			case Keys.Prior:
				this.method_4(this.DefaultValue + this.int_4);
				this.method_0(ScrollEventType.LargeIncrement, this.DefaultValue);
				break;
			case Keys.Next:
				this.method_4(this.DefaultValue - this.int_4);
				this.method_0(ScrollEventType.LargeDecrement, this.DefaultValue);
				break;
			case Keys.End:
				this.DefaultValue = this.int_2;
				break;
			case Keys.Home:
				this.DefaultValue = this.int_1;
				break;
			case Keys.Up:
			case Keys.Right:
				this.method_4(this.DefaultValue + this.int_3);
				this.method_0(ScrollEventType.SmallIncrement, this.DefaultValue);
				break;
			case Keys.Left:
			case Keys.Down:
				this.method_4(this.DefaultValue - this.int_3);
				this.method_0(ScrollEventType.SmallDecrement, this.DefaultValue);
				break;
			}
			if (this.DefaultValue == this.int_1)
			{
				this.method_0(ScrollEventType.First, this.DefaultValue);
			}
			if (this.DefaultValue == this.int_2)
			{
				this.method_0(ScrollEventType.Last, this.DefaultValue);
			}
			Point point = base.PointToClient(Cursor.Position);
			this.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0));
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if ((keyData == Keys.Tab) | (Control.ModifierKeys == Keys.Shift))
			{
				return base.ProcessDialogKey(keyData);
			}
			this.OnKeyDown(new KeyEventArgs(keyData));
			return true;
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.bool_1 = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.bool_2 = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				base.Capture = true;
				this.method_0(ScrollEventType.ThumbTrack, this.int_0);
				this.OnValueChanged(EventArgs.Empty);
				this.OnMouseMove(e);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (base.Capture & (e.Button == MouseButtons.Left))
			{
				ScrollEventType scrollEventType_ = ScrollEventType.ThumbPosition;
				if (this.orientation_0 == Orientation.Horizontal)
				{
					this.int_0 = (int)((float)e.Location.X * ((float)(this.int_2 - this.int_1) / (float)(base.ClientSize.Width - 3)) + (float)this.int_1);
				}
				else
				{
					this.int_0 = (int)((float)e.Location.Y * ((float)(this.int_2 - this.int_1) / (float)(base.ClientSize.Height - 3)) + (float)this.int_1);
				}
				if (this.int_0 <= this.int_1)
				{
					this.int_0 = this.int_1;
					scrollEventType_ = ScrollEventType.First;
				}
				else if (this.int_0 >= this.int_2)
				{
					this.int_0 = this.int_2;
					scrollEventType_ = ScrollEventType.Last;
				}
				this.method_0(scrollEventType_, this.int_0);
				this.OnValueChanged(EventArgs.Empty);
				base.Invalidate();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.bool_2 = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.bool_1 = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			int num = e.Delta / 120 * (this.int_2 - this.int_1) / this.int_5;
			this.method_4(this.DefaultValue + num);
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		private void method_4(int int_6)
		{
			if (int_6 < this.int_1)
			{
				this.DefaultValue = this.int_1;
			}
			else if (int_6 > this.int_2)
			{
				this.DefaultValue = this.int_2;
			}
			else
			{
				this.DefaultValue = int_6;
			}
		}
	}
}

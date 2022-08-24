using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns6;

namespace ns2
{
	[DefaultProperty("Value")]
	[DefaultEvent("Scroll")]
	[ToolboxItem(false)]
	public class ScrollBar : Control
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ScrollEventHandler scrollEventHandler_0;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2;

		private Rectangle rectangle_0;

		private Rectangle rectangle_1;

		private bool bool_3;

		private bool bool_4;

		private bool bool_5;

		private int int_0 = 6;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private readonly System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

		private int int_7 = 10;

		private ScrollBarState scrollBarState_0;

		private ScrollBarState scrollBarState_1;

		private int int_8 = 0;

		private bool bool_6;

		private bool bool_7;

		private bool bool_8 = false;

		private ScrollOrientation scrollOrientation_0 = ScrollOrientation.VerticalScroll;

		private int int_9;

		private int int_10 = 100;

		private int int_11 = 1;

		private int int_12 = 10;

		private int int_13;

		private Color color_0 = Class0.color_28;

		private Color color_1 = Color.FromArgb(213, 218, 223);

		private float float_0 = 10f;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Font font_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color color_2;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		private bool bool_9 = false;

		private System.Windows.Forms.Timer timer_1 = null;

		private Rectangle Rectangle_0 => base.ClientRectangle;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScrollBarState DefaultHoveredState
		{
			get
			{
				if (this.scrollBarState_0 == null)
				{
					this.scrollBarState_0 = new ScrollBarState();
				}
				return this.scrollBarState_0;
			}
			set
			{
				this.scrollBarState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScrollBarState DefaultPressedState
		{
			get
			{
				if (this.scrollBarState_1 == null)
				{
					this.scrollBarState_1 = new ScrollBarState();
				}
				return this.scrollBarState_1;
			}
			set
			{
				this.scrollBarState_1 = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(0)]
		public int BorderRadius
		{
			get
			{
				return this.int_8;
			}
			set
			{
				this.int_8 = ((value >= 0) ? value : 0);
				base.Invalidate();
			}
		}

		public int MouseWheelBarPartitions
		{
			get
			{
				return this.int_7;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("value", "MouseWheelBarPartitions has to be greather than zero");
				}
				this.int_7 = value;
			}
		}

		public int ScrollbarSize
		{
			get
			{
				return (this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? base.Width : base.Height;
			}
			set
			{
				if (this.scrollOrientation_0 == ScrollOrientation.VerticalScroll)
				{
					base.Width = value;
				}
				else
				{
					base.Height = value;
				}
			}
		}

		[DefaultValue(false)]
		public bool HighlightOnWheel
		{
			get
			{
				return this.bool_8;
			}
			set
			{
				this.bool_8 = value;
			}
		}

		public int Minimum
		{
			get
			{
				return this.int_9;
			}
			set
			{
				if (this.int_9 != value && value >= 0 && value < this.int_10)
				{
					this.int_9 = value;
					if (this.int_13 < value)
					{
						this.int_13 = value;
					}
					if (this.int_12 > this.int_10 - this.int_9)
					{
						this.int_12 = this.int_10 - this.int_9;
					}
					this.method_2();
					if (this.int_13 < value)
					{
						this.bool_9 = true;
						this.Value = value;
					}
					else
					{
						this.method_9(this.method_5());
						this.Refresh();
					}
				}
			}
		}

		public int Maximum
		{
			get
			{
				return this.int_10;
			}
			set
			{
				if (value != this.int_10 && value >= 1 && value > this.int_9)
				{
					this.int_10 = value;
					if (this.int_12 > this.int_10 - this.int_9)
					{
						this.int_12 = this.int_10 - this.int_9;
					}
					this.method_2();
					if (this.int_13 > value)
					{
						this.bool_9 = true;
						this.Value = this.int_10;
					}
					else
					{
						this.method_9(this.method_5());
						this.Refresh();
					}
				}
			}
		}

		[DefaultValue(1)]
		public int SmallChange
		{
			get
			{
				return this.int_11;
			}
			set
			{
				if (value != this.int_11 && value >= 1 && value < this.int_12)
				{
					this.int_11 = value;
					this.method_2();
				}
			}
		}

		[DefaultValue(5)]
		public int LargeChange
		{
			get
			{
				return this.int_12;
			}
			set
			{
				if (value != this.int_12 && value >= this.int_11 && value >= 2)
				{
					if (value > this.int_10 - this.int_9)
					{
						this.int_12 = this.int_10 - this.int_9;
					}
					else
					{
						this.int_12 = value;
					}
					this.method_2();
				}
			}
		}

		[Browsable(true)]
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

		[DefaultValue(typeof(Color), "213, 218, 223")]
		[Browsable(true)]
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

		[DefaultValue(10f)]
		public float ThumbSize
		{
			get
			{
				return this.float_0;
			}
			set
			{
				if (this.scrollOrientation_0 == ScrollOrientation.HorizontalScroll)
				{
					this.float_0 = ((value >= (float)base.Width) ? ((float)base.Width) : value);
				}
				else
				{
					this.float_0 = ((value >= (float)base.Height) ? ((float)base.Height) : value);
				}
				this.method_2();
				this.method_9(this.method_5());
				this.Refresh();
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		[Browsable(true)]
		[DefaultValue(0)]
		public int Value
		{
			get
			{
				return this.int_13;
			}
			set
			{
				if (this.int_13 == value || value < this.int_9 || value > this.int_10)
				{
					return;
				}
				this.int_13 = value;
				this.method_9(this.method_5());
				this.method_0(ScrollEventType.ThumbPosition, -1, value, this.scrollOrientation_0);
				if (!this.bool_9 && this.bool_8)
				{
					if (!this.bool_6)
					{
						this.bool_6 = true;
					}
					if (this.timer_1 == null)
					{
						this.timer_1 = new System.Windows.Forms.Timer();
						this.timer_1.Interval = 1000;
						this.timer_1.Tick += new EventHandler(timer_1_Tick);
						this.timer_1.Start();
					}
					else
					{
						this.timer_1.Stop();
						this.timer_1.Start();
					}
				}
				else
				{
					this.bool_9 = false;
				}
				this.Refresh();
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

		public ScrollBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.timer_0.Interval = 20;
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
			if (((uint)this.CreateParams.Style & (true ? 1u : 0u)) != 0)
			{
				this.scrollOrientation_0 = ScrollOrientation.VerticalScroll;
				this.method_2();
			}
			else
			{
				this.scrollOrientation_0 = ScrollOrientation.HorizontalScroll;
				this.method_2();
			}
		}

		private void method_0(ScrollEventType scrollEventType_0, int int_14, int int_15, ScrollOrientation scrollOrientation_1)
		{
			if (int_14 != int_15 && this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
			if (this.scrollEventHandler_0 == null)
			{
				return;
			}
			if (scrollOrientation_1 == ScrollOrientation.HorizontalScroll)
			{
				if (scrollEventType_0 != ScrollEventType.EndScroll && this.bool_1)
				{
					scrollEventType_0 = ScrollEventType.First;
				}
				else if (!this.bool_1 && scrollEventType_0 == ScrollEventType.EndScroll)
				{
					this.bool_1 = true;
				}
			}
			else if (scrollEventType_0 != ScrollEventType.EndScroll && this.bool_0)
			{
				scrollEventType_0 = ScrollEventType.First;
			}
			else if (!this.bool_1 && scrollEventType_0 == ScrollEventType.EndScroll)
			{
				this.bool_0 = true;
			}
			this.scrollEventHandler_0(this, new ScrollEventArgs(scrollEventType_0, int_14, int_15, scrollOrientation_1));
		}

		private void timer_1_Tick(object sender, EventArgs e)
		{
			this.bool_6 = false;
			base.Invalidate();
			this.timer_1.Stop();
		}

		internal void method_1(ScrollOrientation scrollOrientation_1)
		{
			if (scrollOrientation_1 == ScrollOrientation.VerticalScroll)
			{
				this.scrollOrientation_0 = ScrollOrientation.VerticalScroll;
				this.method_2();
			}
			else
			{
				this.scrollOrientation_0 = ScrollOrientation.HorizontalScroll;
				this.method_2();
			}
		}

		public bool HitTest(Point point)
		{
			return this.rectangle_1.Contains(point);
		}

		[SecuritySafeCritical]
		public void BeginUpdate()
		{
			WinApi.SendMessage(base.Handle, 11, param: false, 0);
			this.bool_2 = true;
		}

		[SecuritySafeCritical]
		public void EndUpdate()
		{
			WinApi.SendMessage(base.Handle, 11, param: true, 0);
			this.bool_2 = false;
			this.method_2();
			this.Refresh();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			this.bool_6 = false;
			this.bool_7 = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		protected override void OnEnter(EventArgs e)
		{
			base.Invalidate();
			base.OnEnter(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			this.bool_6 = false;
			this.bool_7 = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			int num = e.Delta / 120 * (this.int_10 - this.int_9) / this.int_7;
			if (this.scrollOrientation_0 == ScrollOrientation.VerticalScroll)
			{
				this.Value -= num;
			}
			else
			{
				this.Value += num;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.bool_7 = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
			base.Focus();
			if (e.Button == MouseButtons.Left)
			{
				Point location = e.Location;
				if (this.rectangle_1.Contains(location))
				{
					this.bool_5 = true;
					this.int_5 = ((this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? (location.Y - this.rectangle_1.Y) : (location.X - this.rectangle_1.X));
					base.Invalidate(this.rectangle_1);
					return;
				}
				this.int_6 = ((this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? location.Y : location.X);
				if (this.int_6 < ((this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? this.rectangle_1.Y : this.rectangle_1.X))
				{
					this.bool_3 = true;
				}
				else
				{
					this.bool_4 = true;
				}
				this.method_10(bool_10: true);
			}
			else if (e.Button == MouseButtons.Right)
			{
				this.int_6 = ((this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? e.Y : e.X);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.bool_7 = false;
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left)
			{
				if (this.bool_5)
				{
					this.bool_5 = false;
					this.method_0(ScrollEventType.EndScroll, -1, this.int_13, this.scrollOrientation_0);
				}
				else if (this.bool_3)
				{
					this.bool_3 = false;
					this.method_8();
				}
				else if (this.bool_4)
				{
					this.bool_4 = false;
					this.method_8();
				}
				base.Invalidate();
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.bool_6 = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.bool_6 = false;
			base.Invalidate();
			base.OnMouseLeave(e);
			this.method_3();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.Button == MouseButtons.Left)
			{
				if (!this.bool_5)
				{
					return;
				}
				int num = this.int_13;
				int num2 = ((this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? e.Location.Y : e.Location.X);
				int num3 = ((this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? (num2 / this.Rectangle_0.Height / this.int_1) : (num2 / this.Rectangle_0.Width / this.int_0));
				if (num2 <= this.int_4 + this.int_5)
				{
					this.method_9(this.int_4);
					this.int_13 = this.int_9;
					base.Invalidate();
				}
				else if (num2 >= this.int_3 + this.int_5)
				{
					this.method_9(this.int_3);
					this.int_13 = this.int_10;
					base.Invalidate();
				}
				else
				{
					this.method_9(num2 - this.int_5);
					int num4;
					int num5;
					if (this.scrollOrientation_0 == ScrollOrientation.VerticalScroll)
					{
						num4 = this.Rectangle_0.Height - num3;
						num5 = this.rectangle_1.Y;
					}
					else
					{
						num4 = this.Rectangle_0.Width - num3;
						num5 = this.rectangle_1.X;
					}
					float num6 = 0f;
					if (num4 != 0)
					{
						num6 = (float)num5 / (float)num4;
					}
					this.int_13 = Convert.ToInt32(num6 * (float)(this.int_10 - this.int_9) + (float)this.int_9);
				}
				if (num != this.int_13)
				{
					this.method_0(ScrollEventType.ThumbTrack, num, this.int_13, this.scrollOrientation_0);
					this.Refresh();
				}
			}
			else if (!this.Rectangle_0.Contains(e.Location))
			{
				this.method_3();
			}
			else if (e.Button == MouseButtons.None)
			{
				if (this.rectangle_1.Contains(e.Location))
				{
					base.Invalidate(this.rectangle_1);
				}
				else if (this.Rectangle_0.Contains(e.Location))
				{
					base.Invalidate();
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			this.bool_6 = true;
			this.bool_7 = true;
			base.Invalidate();
			base.OnKeyDown(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.bool_6 = false;
			this.bool_7 = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			base.SetBoundsCore(x, y, width, height, specified);
			if (base.DesignMode)
			{
				this.method_2();
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.method_2();
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			Keys keys = Keys.Up;
			Keys keys2 = Keys.Down;
			if (this.scrollOrientation_0 == ScrollOrientation.HorizontalScroll)
			{
				keys = Keys.Left;
				keys2 = Keys.Right;
			}
			if (keyData == keys)
			{
				this.Value -= this.int_11;
				return true;
			}
			if (keyData == keys2)
			{
				this.Value += this.int_11;
				return true;
			}
			switch (keyData)
			{
			case Keys.Prior:
				this.Value = this.method_4(bool_10: false, bool_11: true);
				return true;
			case Keys.Next:
				if (this.int_13 + this.int_12 > this.int_10)
				{
					this.Value = this.int_10;
				}
				else
				{
					this.Value += this.int_12;
				}
				return true;
			case Keys.Home:
				this.Value = this.int_9;
				return true;
			case Keys.End:
				this.Value = this.int_10;
				return true;
			default:
				return base.ProcessDialogKey(keyData);
			}
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		private void method_2()
		{
			if (!this.bool_2)
			{
				if (this.scrollOrientation_0 == ScrollOrientation.VerticalScroll)
				{
					this.int_0 = ((this.Rectangle_0.Width > 0) ? this.Rectangle_0.Width : 10);
					this.int_1 = this.method_6();
					this.rectangle_0 = this.Rectangle_0;
					this.rectangle_0.Inflate(-1, -1);
					this.rectangle_1 = new Rectangle(this.Rectangle_0.X, this.Rectangle_0.Y, this.int_0, this.int_1);
					this.int_5 = this.rectangle_1.Height / 2;
					this.int_2 = this.Rectangle_0.Bottom;
					this.int_3 = this.int_2 - this.rectangle_1.Height;
					this.int_4 = this.Rectangle_0.Y;
				}
				else
				{
					this.int_1 = ((base.Height > 0) ? base.Height : 10);
					this.int_0 = this.method_6();
					this.rectangle_0 = this.Rectangle_0;
					this.rectangle_0.Inflate(-1, -1);
					this.rectangle_1 = new Rectangle(this.Rectangle_0.X, this.Rectangle_0.Y, this.int_0, this.int_1);
					this.int_5 = this.rectangle_1.Width / 2;
					this.int_2 = this.Rectangle_0.Right;
					this.int_3 = this.int_2 - this.rectangle_1.Width;
					this.int_4 = this.Rectangle_0.X;
				}
				this.method_9(this.method_5());
				this.Refresh();
			}
		}

		private void method_3()
		{
			this.bool_3 = false;
			this.bool_4 = false;
			this.method_8();
			this.Refresh();
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.method_10(bool_10: true);
		}

		private int method_4(bool bool_10, bool bool_11)
		{
			int num;
			if (bool_11)
			{
				num = this.int_13 - (bool_10 ? this.int_11 : this.int_12);
				if (num < this.int_9)
				{
					num = this.int_9;
				}
			}
			else
			{
				num = this.int_13 + (bool_10 ? this.int_11 : this.int_12);
				if (num > this.int_10)
				{
					num = this.int_10;
				}
			}
			return num;
		}

		private int method_5()
		{
			if (this.int_1 != 0 && this.int_0 != 0)
			{
				int num = ((this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? (this.int_5 / this.Rectangle_0.Height / this.int_1) : (this.int_5 / this.Rectangle_0.Width / this.int_0));
				int num2 = ((this.scrollOrientation_0 != ScrollOrientation.VerticalScroll) ? (this.Rectangle_0.Width - num) : (this.Rectangle_0.Height - num));
				int num3 = this.int_10 - this.int_9;
				float num4 = 0f;
				if (num3 != 0)
				{
					num4 = ((float)this.int_13 - (float)this.int_9) / (float)num3;
				}
				return Math.Max(this.int_4, Math.Min(this.int_3, Convert.ToInt32(num4 * (float)num2)));
			}
			return 0;
		}

		private int method_6()
		{
			int num = ((this.scrollOrientation_0 == ScrollOrientation.VerticalScroll) ? this.Rectangle_0.Height : this.Rectangle_0.Width);
			if (this.int_10 != 0 && this.int_12 != 0)
			{
				return Convert.ToInt32(Math.Min(num, Math.Max((float)this.int_12 * (float)num / (float)this.int_10, this.float_0)));
			}
			return num;
		}

		private void method_7()
		{
			if (!this.timer_0.Enabled)
			{
				this.timer_0.Interval = 600;
				this.timer_0.Start();
			}
			else
			{
				this.timer_0.Interval = 10;
			}
		}

		private void method_8()
		{
			this.timer_0.Stop();
		}

		private void method_9(int int_14)
		{
			if (this.scrollOrientation_0 == ScrollOrientation.VerticalScroll)
			{
				this.rectangle_1.Y = int_14;
			}
			else
			{
				this.rectangle_1.X = int_14;
			}
		}

		private void method_10(bool bool_10)
		{
			int num = this.int_13;
			ScrollEventType scrollEventType_ = ScrollEventType.First;
			int num2;
			int num3;
			if (this.scrollOrientation_0 == ScrollOrientation.VerticalScroll)
			{
				num2 = this.rectangle_1.Y;
				num3 = this.rectangle_1.Height;
			}
			else
			{
				num2 = this.rectangle_1.X;
				num3 = this.rectangle_1.Width;
			}
			if (this.bool_4 && num2 + num3 < this.int_6)
			{
				scrollEventType_ = ScrollEventType.LargeIncrement;
				this.int_13 = this.method_4(bool_10: false, bool_11: false);
				if (this.int_13 == this.int_10)
				{
					this.method_9(this.int_3);
					scrollEventType_ = ScrollEventType.Last;
				}
				else
				{
					this.method_9(Math.Min(this.int_3, this.method_5()));
				}
			}
			else if (this.bool_3 && num2 > this.int_6)
			{
				scrollEventType_ = ScrollEventType.LargeDecrement;
				this.int_13 = this.method_4(bool_10: false, bool_11: true);
				if (this.int_13 == this.int_9)
				{
					this.method_9(this.int_4);
					scrollEventType_ = ScrollEventType.First;
				}
				else
				{
					this.method_9(Math.Max(this.int_4, this.method_5()));
				}
			}
			if (num != this.int_13)
			{
				this.method_0(scrollEventType_, num, this.int_13, this.scrollOrientation_0);
				base.Invalidate();
				if (bool_10)
				{
					this.method_7();
				}
			}
		}

		private Color method_11(Color color_3, Color color_4)
		{
			if (color_4 == Color.Empty)
			{
				color_4 = color_3;
			}
			return color_4;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				Color color = this.ThumbColor;
				Color color2 = this.FillColor;
				if (this.bool_6)
				{
					color = this.method_11(this.ThumbColor, this.DefaultHoveredState.ThumbColor);
					color2 = this.method_11(this.FillColor, this.DefaultHoveredState.FillColor);
				}
				if (this.bool_7)
				{
					color = this.method_11(this.method_11(this.ThumbColor, this.DefaultHoveredState.ThumbColor), this.DefaultPressedState.ThumbColor);
					color2 = this.method_11(this.method_11(this.FillColor, this.DefaultHoveredState.FillColor), this.DefaultPressedState.FillColor);
				}
				Graphics graphics = e.Graphics;
				if (this.BorderRadius > 0)
				{
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					graphics.FillPath(new SolidBrush(color2), Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), this.BorderRadius * 2));
					graphics.FillPath(new SolidBrush(color), Class6.smethod_12(Class6.smethod_11(this.rectangle_1), this.BorderRadius * 2));
				}
				else
				{
					graphics.FillRectangle(new SolidBrush(color2), this.Rectangle_0);
					graphics.FillRectangle(new SolidBrush(color), this.rectangle_1);
				}
			}
			catch
			{
			}
		}
	}
}

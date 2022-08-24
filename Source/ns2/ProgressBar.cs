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
using ns5;

namespace ns2
{
	[DefaultEvent("ValueChanged")]
	[ToolboxItem(false)]
	public class ProgressBar : UIDefaultControl
	{
		private Orientation orientation_0 = Orientation.Vertical;

		private int int_2;

		private System.Windows.Forms.Timer timer_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_2;

		private TextRenderingHint textRenderingHint_0;

		private Point point_0;

		private HorizontalAlignment horizontalAlignment_0 = HorizontalAlignment.Center;

		private bool bool_4;

		private int int_3 = 100;

		private int int_4 = 0;

		private int int_5;

		private bool bool_5 = false;

		private ProgressBarStyle progressBarStyle_0 = ProgressBarStyle.Blocks;

		private Color color_1 = Class0.color_10;

		private Color color_2 = Class0.color_10;

		private BrushMode brushMode_0 = BrushMode.Gradient;

		private Color color_3 = Color.FromArgb(213, 218, 223);

		private LinearGradientMode linearGradientMode_0;

		[Browsable(false)]
		protected TextRenderingHint DefaultTextRenderingHint
		{
			get
			{
				return this.textRenderingHint_0;
			}
			set
			{
				this.textRenderingHint_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Point DefaultTextOffset
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected HorizontalAlignment DefaultTextAlign
		{
			get
			{
				return this.horizontalAlignment_0;
			}
			set
			{
				this.horizontalAlignment_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultShowPercentage
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultMaximum
		{
			get
			{
				return this.int_3;
			}
			set
			{
				if (this.int_3 != value)
				{
					if (value < 0)
					{
						value = 0;
					}
					if (this.int_4 > value)
					{
						this.int_4 = value;
					}
					this.int_3 = value;
					if (this.int_5 > this.int_3)
					{
						this.int_5 = this.int_3;
					}
					this.OnMaximumChanged(EventArgs.Empty);
				}
			}
		}

		[Browsable(false)]
		protected int DefaultMinimum
		{
			get
			{
				return this.int_4;
			}
			set
			{
				if (this.int_4 != value)
				{
					if (value < 0)
					{
						value = 0;
					}
					if (this.int_3 < value)
					{
						this.int_3 = value;
					}
					this.int_4 = value;
					if (this.int_5 < this.int_4)
					{
						this.int_5 = this.int_4;
					}
					this.OnMinimumChanged(EventArgs.Empty);
				}
			}
		}

		[Browsable(false)]
		protected int DefaultValue
		{
			get
			{
				return this.int_5;
			}
			set
			{
				if (this.int_5 != value)
				{
					if (value > this.int_3)
					{
						this.int_5 = this.int_3;
					}
					else if (value < this.int_4)
					{
						this.int_5 = this.int_4;
					}
					else
					{
						this.int_5 = value;
					}
					this.OnValueChanged(EventArgs.Empty);
				}
			}
		}

		[Browsable(false)]
		protected bool DefaultBackwards
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

		[Browsable(false)]
		protected ProgressBarStyle DefaultStyle
		{
			get
			{
				return this.progressBarStyle_0;
			}
			set
			{
				this.progressBarStyle_0 = value;
				if (base.Enabled)
				{
					if (this.progressBarStyle_0 == ProgressBarStyle.Marquee && !base.DesignMode && this.timer_0 != null)
					{
						this.timer_0.Enabled = true;
					}
					else
					{
						this.timer_0.Enabled = false;
						this.int_2 = 0;
					}
				}
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultProgressColor
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
		protected Color DefaultProgressColor2
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
		protected BrushMode DefaultProgressBrushMode
		{
			get
			{
				return this.brushMode_0;
			}
			set
			{
				this.brushMode_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected LinearGradientMode DefaultGradientMode
		{
			get
			{
				return this.linearGradientMode_0;
			}
			set
			{
				this.linearGradientMode_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		public double ProgressTotalValue => 1.0 - (double)checked(this.int_3 - this.int_5) / (double)this.int_3;

		[Browsable(false)]
		public double ProgressTotalPercent => (1.0 - (double)checked(this.int_3 - this.int_5) / (double)this.int_3) * 100.0;

		[Browsable(false)]
		public string ProgressPercentText => $"{Math.Round(this.ProgressTotalPercent)}%";

		public event EventHandler MaximumChanged
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

		public event EventHandler MinimumChanged
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

		public event EventHandler ValueChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public ProgressBar()
		{
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_0.Interval = 20;
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
			if (((uint)this.CreateParams.Style & (true ? 1u : 0u)) != 0)
			{
				this.orientation_0 = Orientation.Vertical;
				base.Size = new Size(30, 300);
			}
			else
			{
				this.orientation_0 = Orientation.Horizontal;
				base.Size = new Size(300, 30);
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (this.int_2 >= ((this.orientation_0 == Orientation.Vertical) ? base.Height : base.Width))
			{
				this.int_2 = -(int)this.method_3();
			}
			if (this.int_2 < ((this.orientation_0 == Orientation.Vertical) ? base.Height : base.Width))
			{
				this.int_2 += 2;
			}
			base.Invalidate();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMaximumChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMinimumChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, EventArgs.Empty);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValueChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, EventArgs.Empty);
			}
		}

		private int method_1()
		{
			if (this.orientation_0 == Orientation.Horizontal)
			{
				return 0;
			}
			if (this.progressBarStyle_0 == ProgressBarStyle.Marquee)
			{
				return (!this.bool_5) ? (base.Height - (int)this.method_3() - this.int_2) : this.int_2;
			}
			return (!this.bool_5) ? (base.Height - (int)this.method_3()) : 0;
		}

		private int method_2()
		{
			if (this.orientation_0 == Orientation.Vertical)
			{
				return 0;
			}
			if (this.progressBarStyle_0 == ProgressBarStyle.Marquee)
			{
				return (!this.bool_5) ? this.int_2 : (base.Width - (int)this.method_3() - this.int_2);
			}
			return this.bool_5 ? (base.Width - (int)this.method_3()) : 0;
		}

		private float method_3()
		{
			if (this.orientation_0 == Orientation.Vertical)
			{
				if (this.progressBarStyle_0 == ProgressBarStyle.Marquee)
				{
					return (float)base.Height / 1.3f;
				}
				return (float)base.Height * ((float)this.int_5 - (float)this.int_4) / ((float)this.int_3 - (float)this.int_4);
			}
			if (this.progressBarStyle_0 == ProgressBarStyle.Marquee)
			{
				return (float)base.Width / 1.3f;
			}
			return (float)base.Width * ((float)this.int_5 - (float)this.int_4) / ((float)this.int_3 - (float)this.int_4);
		}

		public void Increment(int Value)
		{
			if (Value != this.int_3)
			{
				this.DefaultValue += Value;
			}
		}

		public void Decrement(int Value)
		{
			if (Value != this.int_4)
			{
				this.DefaultValue -= Value;
			}
		}

		private Brush method_4()
		{
			if (this.brushMode_0 == BrushMode.Gradient)
			{
				return new LinearGradientBrush(new Rectangle(base.ClientRectangle.X - 1, base.ClientRectangle.Y, base.ClientRectangle.Width + 2, base.ClientRectangle.Height), this.color_1, this.color_2, this.linearGradientMode_0);
			}
			if (this.brushMode_0 == BrushMode.SolidTransition)
			{
				return new SolidBrush(Class6.smethod_23((int)this.ProgressTotalPercent, this.color_1, this.color_2));
			}
			if (this.color_1 == Color.Empty)
			{
				return new SolidBrush(this.color_2);
			}
			return new SolidBrush(this.color_1);
		}

		private void method_5(Graphics graphics_0)
		{
			if (base.DefaultBorderRadius > 0)
			{
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphics_0.FillPath(path: Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), base.DefaultBorderRadius * 2), brush: new SolidBrush(this.color_3));
			}
			else
			{
				graphics_0.FillRectangle(new SolidBrush(this.color_3), base.ClientRectangle);
			}
			if ((this.int_5 > 0) | (this.progressBarStyle_0 == ProgressBarStyle.Marquee))
			{
				Rectangle rectangle = new Rectangle(this.method_2(), this.method_1(), (this.orientation_0 == Orientation.Horizontal) ? ((int)this.method_3()) : base.Width, (this.orientation_0 == Orientation.Vertical) ? ((int)this.method_3()) : base.Height);
				if (base.DefaultBorderRadius > 0)
				{
					GraphicsPath path2 = Class6.smethod_12(Class6.smethod_11(rectangle), base.DefaultBorderRadius * 2);
					if (this.progressBarStyle_0 == ProgressBarStyle.Marquee)
					{
						Bitmap bitmap = new Bitmap(base.Width, base.Height);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.SmoothingMode = SmoothingMode.AntiAlias;
						graphics.FillPath(this.method_4(), path2);
						graphics_0.FillPath(new TextureBrush(bitmap), Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), base.DefaultBorderRadius * 2));
					}
					else
					{
						graphics_0.FillPath(this.method_4(), path2);
					}
				}
				else
				{
					graphics_0.FillRectangle(this.method_4(), rectangle);
				}
			}
			if (base.DefaultBorderThickness > 0)
			{
				if (base.DefaultBorderRadius > 0)
				{
					Class6.smethod_20(graphics_0, new SolidBrush(base.DefaultBorderColor), base.ClientRectangle, base.DefaultBorderRadius, base.DefaultBorderThickness, base.DefaultBorderStyle);
				}
				else
				{
					Class6.smethod_22(graphics_0, new SolidBrush(base.DefaultBorderColor), base.ClientRectangle, base.DefaultBorderThickness, base.DefaultBorderStyle);
				}
			}
			if (!this.bool_4)
			{
				return;
			}
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
			graphics_0.TextRenderingHint = this.textRenderingHint_0;
			Rectangle rectangle2 = new Rectangle(this.point_0.X, this.point_0.Y, base.Width, base.Height);
			if (this.orientation_0 == Orientation.Horizontal)
			{
				if (this.horizontalAlignment_0 == HorizontalAlignment.Right)
				{
					rectangle2.X = -10;
					rectangle2.X += this.point_0.X;
				}
				else if (this.horizontalAlignment_0 == HorizontalAlignment.Left)
				{
					rectangle2.X += 10;
				}
			}
			else if (this.horizontalAlignment_0 == HorizontalAlignment.Right)
			{
				rectangle2.Y = -10;
				rectangle2.Y += this.point_0.Y;
			}
			else if (this.horizontalAlignment_0 == HorizontalAlignment.Left)
			{
				rectangle2.Y += 10;
			}
			graphics_0.DrawString(this.ProgressPercentText, this.Font, new SolidBrush(this.ForeColor), rectangle2, new StringFormat
			{
				FormatFlags = StringFormatFlags.LineLimit,
				Alignment = ((this.orientation_0 != 0) ? StringAlignment.Center : Class6.smethod_4(this.horizontalAlignment_0)),
				LineAlignment = ((this.orientation_0 != Orientation.Vertical) ? StringAlignment.Center : Class6.smethod_4(this.horizontalAlignment_0))
			});
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Bitmap image = new Bitmap(base.Width, base.Height);
				this.method_5(Graphics.FromImage(image));
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else
			{
				this.method_5(e.Graphics);
			}
			base.OnPaint(e);
		}
	}
}

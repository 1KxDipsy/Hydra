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

namespace ns2
{
	[ToolboxItem(false)]
	[DefaultEvent("ValueChanged")]
	public class CircleProgressBar : ContainerControl, IControl
	{
		internal float float_0;

		private int int_0;

		private int int_1;

		private bool bool_0;

		private bool bool_1;

		private int int_2;

		private int int_3;

		private Color color_0;

		private int int_4;

		private int int_5;

		private int int_6;

		private LineCap lineCap_0;

		private LineCap lineCap_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_2;

		private bool bool_2;

		private System.Windows.Forms.Timer timer_0;

		private float float_1 = 0.6f;

		private ShadowDecoration shadowDecoration_0;

		private TextRenderingHint textRenderingHint_0 = TextRenderingHint.ClearTypeGridFit;

		private Image image_0;

		private Size size_0 = new Size(42, 42);

		private Point point_0;

		private bool bool_3;

		private Color color_1 = Class0.color_10;

		private Color color_2 = Class0.color_10;

		private BrushMode brushMode_0 = BrushMode.Gradient;

		private LinearGradientMode linearGradientMode_0;

		private Color color_3 = Color.FromArgb(213, 218, 223);

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[Browsable(false)]
		protected bool DefaultUseTransparentBackground
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultAnimated
		{
			get
			{
				return this.timer_0.Enabled;
			}
			set
			{
				this.timer_0.Enabled = value;
			}
		}

		[Browsable(false)]
		protected float DefaultAnimationSpeed
		{
			get
			{
				return this.float_1;
			}
			set
			{
				this.float_1 = value;
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
		protected Image DefaultImage
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Size DefaultImageSize
		{
			get
			{
				return this.size_0;
			}
			set
			{
				this.size_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Point DefaultImageOffset
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
		protected bool DefaultShowPercentage
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

		[Browsable(false)]
		protected int DefaultFillOffset
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultEnsureVisible
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

		[Browsable(false)]
		protected bool DefaultBackwards
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultFillThickness
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultProgressOffset
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

		[Browsable(false)]
		protected int DefaultProgressThickness
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
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

		[Browsable(true)]
		protected Color DefaultInnerColor
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
		protected int DefaultMaximum
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
					if (this.int_5 > value)
					{
						this.int_5 = value;
					}
					this.int_4 = value;
					if (this.int_6 > this.int_4)
					{
						this.int_6 = this.int_4;
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
				return this.int_5;
			}
			set
			{
				if (this.int_5 != value)
				{
					if (value < 0)
					{
						value = 0;
					}
					if (this.int_4 < value)
					{
						this.int_4 = value;
					}
					this.int_5 = value;
					if (this.int_6 < this.int_5)
					{
						this.int_6 = this.int_5;
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
				return this.int_6;
			}
			set
			{
				if (this.int_6 != value)
				{
					if (value > this.int_4)
					{
						this.int_6 = this.int_4;
					}
					else if (value < this.int_5)
					{
						this.int_6 = this.int_5;
					}
					else
					{
						this.int_6 = value;
					}
					this.OnValueChanged(EventArgs.Empty);
				}
			}
		}

		[Browsable(false)]
		public string ProgressPercentText => $"{Math.Round(this.ProgressTotalPercent)}%";

		[Browsable(false)]
		public double ProgressTotalPercent => (1.0 - (double)checked(this.int_4 - this.int_6) / (double)this.int_4) * 100.0;

		[Browsable(false)]
		public double ProgressTotalValue => 1.0 - (double)checked(this.int_4 - this.int_6) / (double)this.int_4;

		[Browsable(false)]
		protected LineCap DefaultProgressStartCap
		{
			get
			{
				return this.lineCap_0;
			}
			set
			{
				this.lineCap_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected LineCap DefaultProgressEndCap
		{
			get
			{
				return this.lineCap_1;
			}
			set
			{
				this.lineCap_1 = value;
				base.Invalidate();
			}
		}

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

		public CircleProgressBar()
		{
			this.color_0 = Color.Transparent;
			this.float_0 = 270f;
			this.int_0 = 0;
			this.int_1 = 0;
			this.int_2 = 23;
			this.int_3 = 23;
			this.int_4 = 100;
			this.lineCap_0 = LineCap.Flat;
			this.lineCap_1 = LineCap.Flat;
			base.Size = new Size(130, 130);
			this.DefaultShadowDecoration.Mode = ShadowMode.Circle;
			this.DoubleBuffered = true;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
			this.DoubleBuffered = true;
			this.method_1();
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

		private void method_0(Graphics graphics_0)
		{
			if (!this.bool_2)
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

		private void method_1()
		{
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_0.Interval = 20;
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (!this.IsDesignMode)
			{
				this.float_0 += 6f * this.DefaultAnimationSpeed * (float)((!this.bool_1) ? 1 : (-1));
				this.Refresh();
			}
		}

		private float method_2()
		{
			return checked(base.Height - this.int_0);
		}

		private float method_3()
		{
			return checked(base.Width - this.int_0);
		}

		private float method_4()
		{
			return checked(base.Height - this.int_1);
		}

		private float method_5()
		{
			return checked(base.Width - this.int_1);
		}

		public float ProgressX(int i)
		{
			return (float)((double)base.Width / 2.0) - this.method_5() / 2f + (float)((double)i / 2.0);
		}

		public float ProgressY(int i)
		{
			return (float)((double)base.Height / 2.0) - this.method_4() / 2f + (float)((double)i / 2.0);
		}

		public float BaseX(int i)
		{
			return (float)((double)base.Width / 2.0) - this.method_3() / 2f + (float)((double)i / 2.0);
		}

		public float BaseY(int i)
		{
			return (float)((double)base.Height / 2.0) - this.method_2() / 2f + (float)((double)i / 2.0);
		}

		public void Reset()
		{
			this.DefaultValue = this.int_5;
			this.float_0 = 270f;
			this.Refresh();
		}

		public void Increment(int Value)
		{
			checked
			{
				if (Value != this.int_4)
				{
					this.DefaultValue += Value;
				}
			}
		}

		public void Decrement(int Value)
		{
			checked
			{
				if (Value != this.int_5)
				{
					this.DefaultValue -= Value;
				}
			}
		}

		private Brush method_6()
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

		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				Graphics graphics = e.Graphics;
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					graphicsPath.AddEllipse(this.BaseX(this.int_2), this.BaseY(this.int_2), this.method_3() - (float)this.int_2 - 2f, this.method_2() - (float)this.int_2 - 2f);
					e.Graphics.FillPath(new SolidBrush(this.color_0), graphicsPath);
				}
				using (SolidBrush brush = new SolidBrush(this.color_3))
				{
					using Pen pen = new Pen(brush, this.int_2);
					pen.StartCap = this.lineCap_0;
					pen.EndCap = this.lineCap_1;
					graphics.DrawArc(pen, this.BaseX(this.int_2), this.BaseY(this.int_2), this.method_3() - (float)this.int_2 - 2f, this.method_2() - (float)this.int_2 - 2f, -90f, 360f);
				}
				if (this.int_6 > 0)
				{
					using Pen pen2 = new Pen(this.method_6(), this.int_3);
					pen2.StartCap = this.lineCap_0;
					pen2.EndCap = this.lineCap_1;
					float num = checked((float)(this.int_6 - this.int_5) / (float)(this.int_4 - this.int_5));
					float num2 = ((!this.bool_0) ? (360f * num) : (30f + 300f * num));
					if (this.bool_1)
					{
						num2 = 0f - num2;
					}
					e.Graphics.DrawArc(pen2, this.ProgressX(this.int_3), this.ProgressY(this.int_3), this.method_5() - (float)this.int_3 - 2f, this.method_4() - (float)this.int_3 - 2f, this.float_0, num2);
				}
				if (this.DefaultImage != null)
				{
					graphics.DrawImage(this.DefaultImage, new Rectangle(base.Width / 2 - this.size_0.Width / 2 + this.point_0.X, base.Height / 2 - this.size_0.Height / 2 + this.point_0.Y, this.size_0.Width, this.size_0.Width));
				}
				if (this.bool_3)
				{
					graphics.TextRenderingHint = this.DefaultTextRenderingHint;
					using StringFormat format = new StringFormat
					{
						FormatFlags = StringFormatFlags.LineLimit,
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					};
					graphics.DrawString(this.ProgressPercentText, this.Font, new SolidBrush(base.ForeColor), base.ClientRectangle, format);
					return;
				}
			}
			catch
			{
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.Width = base.Height;
		}
	}
}

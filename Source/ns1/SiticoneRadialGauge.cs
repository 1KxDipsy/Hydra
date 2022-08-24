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

namespace ns1
{
	[DefaultEvent("ValueChanged")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("An advanced Radial Gauge Control")]
	public class SiticoneRadialGauge : Control, IControl
	{
		private float float_0 = 490f;

		private int int_0 = 20;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		private Color color_0 = Class0.color_29;

		private bool bool_0 = true;

		private int int_1 = 4;

		private Color color_1 = Color.FromArgb(213, 218, 223);

		private Color color_2 = Class0.color_16;

		private Color color_3 = Class0.color_16;

		private bool bool_1 = true;

		private int int_2 = 25;

		private int int_3;

		private BrushMode brushMode_0 = BrushMode.Gradient;

		private LinearGradientMode linearGradientMode_0;

		private LineCap lineCap_0;

		private LineCap lineCap_1;

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[Description("The control's text")]
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

		[DefaultValue(typeof(Color), "125, 137, 149")]
		public Color ArrowColor
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

		[Description("If true, the arrow will be visible")]
		[DefaultValue(true)]
		public bool ArrowVisible
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

		[DefaultValue(4)]
		[Description("The control's arrow thickness, the higher the value, the thicker the arrow")]
		public int ArrowThickness
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

		[DefaultValue(typeof(Color), "213, 218, 223")]
		[Description("The BackColor that will fill the control")]
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

		[Description("The gauge's maximum value")]
		[DefaultValue(100)]
		public int Maximum => 100;

		[DefaultValue(0)]
		[Description("The gauge's minimum value")]
		public int Minimum => 0;

		[DefaultValue(typeof(Color), "77, 196, 255")]
		[Description("The gauge's progress color")]
		public Color ProgressColor
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

		[DefaultValue(typeof(Color), "77, 196, 255")]
		[Description("The gauge's second progress color in a gradient mode")]
		public Color ProgressColor2
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

		[Description("If true, the gauge's progress value/percentage will be shown")]
		[DefaultValue(true)]
		public bool ShowPercentage
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

		[Description("The gauge's progress percentile text")]
		[Browsable(false)]
		public string ProgressPercentText => $"{Math.Round(this.ProgressTotalPercent)}%";

		[DefaultValue(25)]
		[Description("The gauge's progress thickness, the higher the value, the thicker")]
		public int ProgressThickness
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

		[Description("The gauge's progress total percentage")]
		[Browsable(false)]
		public double ProgressTotalPercent => (1.0 - (double)checked(this.Maximum - this.Value) / (double)this.Maximum) * 100.0;

		[Browsable(false)]
		[Description("The gauge's progress total value")]
		public double ProgressTotalValue => 1.0 - (double)checked(this.Maximum - this.Value) / (double)this.Maximum;

		[Description("The gauge's progress value")]
		[DefaultValue(0)]
		public int Value
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				if (value > this.Maximum)
				{
					this.int_3 = this.Maximum;
				}
				if (value < this.Minimum)
				{
					this.int_3 = this.Minimum;
				}
				this.OnValueChanged(EventArgs.Empty);
			}
		}

		[Description("The gauge's progress brush mode")]
		[Browsable(true)]
		[DefaultValue(BrushMode.Gradient)]
		public BrushMode ProgressBrushMode
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

		[DefaultValue(LinearGradientMode.Horizontal)]
		[Browsable(true)]
		[Description("The gauge's progress gradient mode")]
		public LinearGradientMode GradientMode
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

		[DefaultValue(0)]
		[Description("The gauge's progress start cap or design")]
		public LineCap ProgressStartCap
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

		[DefaultValue(0)]
		[Description("The gauge's progress end cap or design")]
		public LineCap ProgressEndCap
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

		public SiticoneRadialGauge()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
			this.DoubleBuffered = true;
			base.Size = new Size(240, 240);
			base.MinimumSize = new Size(30, 30);
			this.ForeColor = Class0.color_28;
			this.Font = new Font("Verdana", 8.2f);
			Class13.smethod_0();
		}

		private int method_0()
		{
			return base.Width - this.int_0;
		}

		private Point method_1(Point point_0, double double_0, double double_1)
		{
			double a = double_0 * Math.Cos(Math.PI * double_1 / 180.0) + (double)point_0.X;
			return checked(new Point(y: (int)Math.Round(double_0 * Math.Sin(Math.PI * double_1 / 180.0) + (double)point_0.Y), x: (int)Math.Round(a)));
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValueChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.Height = base.Width;
			base.Invalidate();
			base.OnResize(e);
		}

		private Brush method_2()
		{
			if (this.ProgressBrushMode == BrushMode.Gradient)
			{
				return new LinearGradientBrush(new Rectangle(base.ClientRectangle.X - 1, base.ClientRectangle.Y, base.ClientRectangle.Width + 2, base.ClientRectangle.Height), this.ProgressColor, this.ProgressColor2, this.GradientMode);
			}
			if (this.ProgressBrushMode == BrushMode.SolidTransition)
			{
				return new SolidBrush(Class6.smethod_23((int)this.ProgressTotalPercent, this.ProgressColor, this.ProgressColor2));
			}
			if (this.ProgressColor == Color.Empty)
			{
				return new SolidBrush(this.ProgressColor2);
			}
			return new SolidBrush(this.ProgressColor);
		}

		private void method_3(Graphics graphics_0)
		{
			double double_ = (double)this.method_0() / 2.0 - (double)this.ProgressThickness * 2.5;
			checked
			{
				Point point = new Point((int)Math.Round((double)base.Width / 2.0), (int)Math.Round((double)base.Width / 2.0));
				double double_2 = 280f * (float)(this.Value - this.Minimum) / (float)(this.Maximum - this.Minimum) + this.float_0;
				using Pen pen = new Pen(new SolidBrush(this.ArrowColor));
				pen.EndCap = LineCap.ArrowAnchor;
				pen.StartCap = LineCap.RoundAnchor;
				pen.Width = this.ArrowThickness;
				graphics_0.DrawLine(pen, point, this.method_1(point, double_, double_2));
			}
		}

		private void method_4(Graphics graphics_0)
		{
			checked
			{
				int num = (int)Math.Round((double)this.method_0() / 2.0);
				int num2 = (int)Math.Round((double)base.Width / 2.0 - (double)num + (double)this.int_2 / 2.0);
				int num3 = (int)Math.Round((double)base.Width / 2.0 - (double)num + (double)this.int_2 / 2.0);
				num = this.method_0() - this.int_2;
				using (Pen pen = new Pen(this.FillColor, this.ProgressThickness))
				{
					pen.StartCap = this.ProgressStartCap;
					pen.EndCap = this.ProgressEndCap;
					graphics_0.DrawArc(pen, num2, num3, num, num, this.float_0, 280f);
				}
				using Pen pen2 = new Pen(this.method_2(), this.ProgressThickness);
				pen2.StartCap = this.ProgressStartCap;
				pen2.EndCap = this.ProgressEndCap;
				graphics_0.DrawArc(pen2, num2, num3, num, num, this.float_0, 280f * (float)(this.Value - this.Minimum) / (float)(this.Maximum - this.Minimum));
			}
		}

		private void method_5(Graphics graphics_0)
		{
			int num = 0;
			checked
			{
				do
				{
					double double_ = (double)this.method_0() / 2.0 - ((double)this.ProgressThickness + (double)this.ProgressThickness / 1.5);
					Point point_ = new Point((int)Math.Round((double)this.method_0() / 2.0), (int)Math.Round((double)this.method_0() / 2.0));
					if (num != 0)
					{
						Point point = this.method_1(point_, double_, 280.0 * (((double)num * ((double)this.Maximum / 10.0) - (double)this.Minimum) / (double)(this.Maximum - this.Minimum)) + (double)this.float_0);
						unchecked
						{
							point.X++;
							switch (num)
							{
							case 9:
								graphics_0.DrawString((num * 10).ToString(), this.Font, new SolidBrush(this.ForeColor), new Point(point.X + 2, point.Y));
								break;
							case 10:
								graphics_0.DrawString((num * 10).ToString(), this.Font, new SolidBrush(this.ForeColor), new Point(point.X + 1, point.Y));
								break;
							case 8:
								graphics_0.DrawString((num * 10).ToString(), this.Font, new SolidBrush(this.ForeColor), new Point(point.X + 2, point.Y));
								break;
							case 7:
								graphics_0.DrawString((num * 10).ToString(), this.Font, new SolidBrush(this.ForeColor), new Point(point.X + 1, point.Y));
								break;
							default:
								graphics_0.DrawString((num * 10).ToString(), this.Font, new SolidBrush(this.ForeColor), point);
								break;
							}
						}
					}
					else
					{
						Point point2 = this.method_1(point_, double_, 280f * (float)(num - this.Minimum) / (float)(this.Maximum - this.Minimum) + this.float_0);
						unchecked
						{
							point2.X++;
							graphics_0.DrawString(num.ToString(), this.Font, new SolidBrush(this.ForeColor), point2);
						}
					}
					num++;
				}
				while (num <= 10);
			}
		}

		private void method_6(Graphics graphics_0)
		{
			new Bitmap(base.Width, base.Height);
			graphics_0.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
			this.method_4(graphics_0);
			if (this.ShowPercentage)
			{
				this.method_5(graphics_0);
			}
			if (this.ArrowVisible)
			{
				this.method_3(graphics_0);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				if (!base.Enabled)
				{
					Bitmap image = new Bitmap(base.Width, base.Height);
					this.method_6(Graphics.FromImage(image));
					ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
				}
				else
				{
					this.method_6(e.Graphics);
				}
			}
			catch
			{
			}
			base.OnPaint(e);
		}
	}
}

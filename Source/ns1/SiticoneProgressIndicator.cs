using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;
using ns5;

namespace ns1
{
	[ToolboxBitmap(typeof(System.Windows.Forms.ProgressBar))]
	[ToolboxItem(true)]
	public class SiticoneProgressIndicator : UIDefaultControl
	{
		private IContainer icontainer_0 = null;

		private Timer timer_0;

		private int int_2 = 1;

		private int int_3 = 100;

		private Color color_1 = Class0.color_19;

		private bool bool_4;

		private bool bool_5 = true;

		private float float_0 = 1f;

		private int int_4 = 8;

		private int int_5 = 8;

		private ProgressIndicatorStyle progressIndicatorStyle_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Font font_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Color color_2;

		private float float_1 = 1f;

		[Browsable(false)]
		[Description("The control's font style")]
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

		[Browsable(false)]
		[Description("The control's text")]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
		[Description("The control's ForeColor")]
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
		[Description("The progress style of the ProressIndicator control")]
		[DefaultValue(ProgressIndicatorStyle.Default)]
		protected ProgressIndicatorStyle DefaultStyle
		{
			get
			{
				return this.progressIndicatorStyle_0;
			}
			set
			{
				this.progressIndicatorStyle_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[DefaultValue(false)]
		[Description("If true, the background will allow a transparent color")]
		public bool UseTransparentBackground
		{
			get
			{
				return base.DefaultUseTransparentBackground;
			}
			set
			{
				base.DefaultUseTransparentBackground = value;
			}
		}

		[Category("Appearance")]
		[DefaultValue(typeof(Color), "94, 148, 255")]
		[Description("Gets or sets the base color for the circles.")]
		public Color ProgressColor
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

		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Gets or sets a value indicating if the animation should start automatically.")]
		public bool AutoStart
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
				if (this.bool_4 && !base.DesignMode)
				{
					this.Start();
				}
				else
				{
					this.Stop();
				}
			}
		}

		[Category("Appearance")]
		[Description("Gets or sets the scale for the circles")]
		[DefaultValue(1.5f)]
		public float CircleSize
		{
			get
			{
				return this.float_0;
			}
			set
			{
				if (this.progressIndicatorStyle_0 == ProgressIndicatorStyle.Default)
				{
					if (value <= 0f)
					{
						this.float_0 = 0.1f;
					}
					else
					{
						this.float_0 = ((value > 1f) ? 1f : value);
					}
				}
				else if (value <= 0f)
				{
					this.float_0 = 0.1f;
				}
				else
				{
					this.float_0 = value;
				}
				base.Invalidate();
			}
		}

		[DefaultValue(75)]
		[Category("Behavior")]
		[Description("Gets or sets the animation speed.")]
		public int AnimationSpeed
		{
			get
			{
				return (-this.int_3 + 400) / 4;
			}
			set
			{
				int num = checked(400 - value * 4);
				if (num < 10)
				{
					this.int_3 = 10;
				}
				else
				{
					this.int_3 = ((num > 400) ? 400 : num);
				}
				this.timer_0.Interval = this.int_3;
			}
		}

		[DefaultValue(8)]
		[Description("Gets or sets the number of circles used in the animation.")]
		[Category("Behavior")]
		public int NumberOfCircles
		{
			get
			{
				return this.int_4;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer.");
				}
				this.int_4 = value;
				this.int_5 = this.int_2;
				base.Invalidate();
			}
		}

		public SiticoneProgressIndicator()
		{
			this.method_1();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.SetStyle(ControlStyles.ResizeRedraw, value: true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			if (this.AutoStart)
			{
				this.timer_0.Start();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_1()
		{
			this.icontainer_0 = new Container();
			this.timer_0 = new Timer(this.icontainer_0);
			base.SuspendLayout();
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
			base.Size = new Size(90, 90);
			base.ResumeLayout(performLayout: false);
		}

		public void Start()
		{
			this.timer_0.Interval = this.int_3;
			this.bool_5 = false;
			this.timer_0.Start();
		}

		public void Stop()
		{
			this.timer_0.Stop();
			this.int_2 = 1;
			this.bool_5 = true;
			base.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.progressIndicatorStyle_0 == ProgressIndicatorStyle.Default)
			{
				GraphicsState gstate = e.Graphics.Save();
				float num = 360f / (float)this.int_4;
				e.Graphics.TranslateTransform((float)base.Width / 2f, (float)base.Height / 2f);
				e.Graphics.RotateTransform(num * (float)this.int_2 * 1f);
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				float num2 = 4.5f / this.float_0;
				float num3 = (float)base.Width / num2;
				float num4 = (float)base.Width / 4.5f - num3;
				float num5 = (float)base.Width / 9f + num4;
				float num6 = (float)base.Height / 9f + num4;
				for (int i = 1; i <= this.int_4; i++)
				{
					int num7 = ((!((double)(255f * ((float)i / (float)this.int_5)) > 255.0)) ? ((int)(255f * ((float)i / (float)this.int_5))) : 0);
					using SolidBrush brush = new SolidBrush(Color.FromArgb(this.bool_5 ? 31 : num7, this.color_1));
					e.Graphics.FillEllipse(brush, num5, num6, num3, num3);
					e.Graphics.RotateTransform(num * 1f);
				}
				e.Graphics.Restore(gstate);
			}
			else
			{
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				int num8 = Math.Min(base.Width, base.Height);
				PointF pointF = new PointF(num8 / 2, num8 / 2);
				float num9 = (float)(num8 / 2) - this.CircleSize - (float)(this.int_4 - 1) * this.float_1;
				float num10 = 360 / this.int_4;
				this.int_2 = ((this.int_2 < this.int_4) ? this.int_2 : 0);
				int num11 = 0;
				for (int j = this.int_2; j < this.int_2 + this.int_4; j++)
				{
					int num12 = j % this.int_4;
					float num13 = pointF.X + (float)((double)num9 * Math.Cos((double)(num10 * (float)num12) * Math.PI / 180.0));
					float num14 = pointF.Y + (float)((double)num9 * Math.Sin((double)(num10 * (float)num12) * Math.PI / 180.0));
					float num15 = this.CircleSize + (float)num11 * this.float_1;
					PointF pointF2 = new PointF(num13 - num15, num14 - num15);
					e.Graphics.FillEllipse(new SolidBrush(this.ProgressColor), pointF2.X, pointF2.Y, 2f * num15, 2f * num15);
					num11++;
				}
			}
			base.OnPaint(e);
		}

		protected override void OnResize(EventArgs e)
		{
			this.method_2();
			base.OnResize(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			this.method_2();
			base.OnSizeChanged(e);
		}

		private void method_2()
		{
			int num = Math.Max(base.Width, base.Height);
			base.Size = new Size(num, num);
		}

		private void method_3()
		{
			if (this.int_2 + 1 <= this.int_4)
			{
				this.int_2++;
			}
			else
			{
				this.int_2 = 1;
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (!base.DesignMode)
			{
				this.method_3();
				base.Invalidate();
			}
		}
	}
}

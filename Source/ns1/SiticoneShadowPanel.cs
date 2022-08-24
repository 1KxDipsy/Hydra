using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	[DebuggerStepThrough]
	[Description("A ShadowPanel Control")]
	[ToolboxBitmap(typeof(Panel))]
	[ToolboxItem(true)]
	public class SiticoneShadowPanel : Panel
	{
		public enum ShadowMode
		{
			ForwardDiagonal = 0,
			Surrounded = 1,
			Dropped = 2
		}

		private Color color_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private Color color_1;

		private const int int_3 = 10;

		private int int_4;

		private Color color_2;

		private ShadowMode shadowMode_0;

		[Description("The begin gradient color.")]
		public Color FillColor
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

		[DefaultValue(0)]
		[Description("The width of an edge.")]
		public int EdgeWidth
		{
			get
			{
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
				base.Invalidate();
			}
		}

		[Description("The corner round radius.")]
		[DefaultValue(0)]
		public int Radius
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
				if ((value > 0) & (this.BackColor != Color.Transparent))
				{
					this.BackColor = Color.Transparent;
				}
				base.Invalidate();
			}
		}

		[Description("The shadow color.")]
		public Color ShadowColor
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

		[DefaultValue(100)]
		[Description("The shadow depth color.")]
		public int ShadowDepth
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

		[DefaultValue(5)]
		[Description("The shadow shift.")]
		public int ShadowShift
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

		[DefaultValue(1)]
		[Description("Style of the shadow.")]
		public ShadowMode ShadowStyle
		{
			get
			{
				return this.shadowMode_0;
			}
			set
			{
				this.shadowMode_0 = value;
				base.Invalidate();
			}
		}

		public SiticoneShadowPanel()
		{
			this.color_0 = Color.White;
			this.int_0 = 100;
			this.int_1 = 0;
			this.int_2 = 5;
			this.color_1 = Color.Black;
			this.int_4 = 0;
			this.shadowMode_0 = ShadowMode.Surrounded;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			Class13.smethod_0();
		}

		private GraphicsPath method_0(Rectangle rectangle_0, int int_5)
		{
			return this.method_1(rectangle_0, int_5, bool_0: false);
		}

		private GraphicsPath method_1(Rectangle rectangle_0, int int_5, bool bool_0)
		{
			int num = rectangle_0.X;
			int num2 = rectangle_0.Y;
			int num3 = rectangle_0.Width;
			int num4 = rectangle_0.Height;
			int num5 = num + num3;
			int num6 = num2 + num4;
			int num7 = num5 - int_5;
			int num8 = num6 - int_5;
			int num9 = num + int_5;
			int num10 = num2 + int_5;
			int num11 = int_5 * 2;
			int num12 = num5 - num11;
			int num13 = num6 - num11;
			int num14 = (int)Math.Round((double)num + (double)num3 / 2.0);
			int num15 = (int)Math.Round((double)num6 - (double)num4 / 20.0);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.StartFigure();
			if (num11 > 0)
			{
				graphicsPath.AddArc(num, num2, num11, num11, 180f, 90f);
			}
			graphicsPath.AddLine(num9, num2, num7, num2);
			if (num11 > 0)
			{
				graphicsPath.AddArc(num12, num2, num11, num11, 270f, 90f);
			}
			graphicsPath.AddLine(num5, num10, num5, num8);
			if (num11 > 0)
			{
				graphicsPath.AddArc(num12, num13, num11, num11, 0f, 90f);
			}
			if (bool_0)
			{
				graphicsPath.AddBezier(new Point(num7, num6), new Point(num14, num15), new Point(num14, num15), new Point(num9, num6));
			}
			else
			{
				graphicsPath.AddLine(num7, num6, num9, num6);
			}
			if (num11 > 0)
			{
				graphicsPath.AddArc(num, num13, num11, num11, 90f, 90f);
			}
			graphicsPath.AddLine(num, num8, num, num10);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		private GraphicsPath method_2(Graphics graphics_0, Brush brush_0, Rectangle rectangle_0, int int_5)
		{
			GraphicsPath graphicsPath = this.method_0(rectangle_0, int_5);
			SmoothingMode smoothingMode = graphics_0.SmoothingMode;
			graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
			graphics_0.FillPath(brush_0, graphicsPath);
			graphics_0.SmoothingMode = smoothingMode;
			return graphicsPath;
		}

		private GraphicsPath method_3(Graphics graphics_0, Pen pen_0, Rectangle rectangle_0, int int_5)
		{
			GraphicsPath graphicsPath = this.method_0(rectangle_0, int_5);
			SmoothingMode smoothingMode = graphics_0.SmoothingMode;
			graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
			graphics_0.DrawPath(pen_0, graphicsPath);
			graphics_0.SmoothingMode = smoothingMode;
			return graphicsPath;
		}

		private void method_4(Graphics graphics_0, ref Rectangle rectangle_0)
		{
			Rectangle rect = rectangle_0;
			rect.Inflate(1, 1);
			Blend blend = new Blend();
			if (this.Radius >= 150)
			{
				blend.Positions = new float[6] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };
				blend.Factors = new float[6] { 0f, 0f, 0.2f, 0.4f, 1f, 1f };
			}
			else
			{
				blend.Positions = new float[4] { 0f, 0.49f, 0.52f, 1f };
				blend.Factors = new float[4] { 0f, 0.6f, 0.99f, 1f };
			}
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, this.color_2, this.color_2, LinearGradientMode.ForwardDiagonal);
			linearGradientBrush.Blend = blend;
			this.method_2(graphics_0, linearGradientBrush, rectangle_0, checked(this.int_1 * 2));
		}

		private void method_5(Graphics graphics_0, Rectangle rectangle_0)
		{
			using Brush brush_ = new SolidBrush(this.color_0);
			this.method_2(graphics_0, brush_, rectangle_0, checked(this.int_1 * 2));
		}

		private void method_6(Graphics graphics_0, Rectangle rectangle_0)
		{
			using Brush brush_ = new SolidBrush(this.color_0);
			this.method_2(graphics_0, brush_, rectangle_0, checked(this.int_1 * 2));
		}

		private void method_7(Graphics graphics_0, Rectangle rectangle_0)
		{
			this.color_0.GetSaturation();
			this.color_2 = ControlPaint.Dark(this.color_0);
			this.method_4(graphics_0, ref rectangle_0);
			rectangle_0.Inflate(-this.int_4, -this.int_4);
			this.method_5(graphics_0, rectangle_0);
		}

		private void method_8(Graphics graphics_0, Rectangle rectangle_0)
		{
			this.color_0.GetSaturation();
			this.color_2 = ControlPaint.Light(this.color_0);
			this.method_4(graphics_0, ref rectangle_0);
			rectangle_0.Inflate(-this.int_4, -this.int_4);
			this.method_5(graphics_0, rectangle_0);
		}

		private void method_9(Graphics graphics_0)
		{
			Rectangle rectangle_ = default(Rectangle);
			switch (this.shadowMode_0)
			{
			case ShadowMode.ForwardDiagonal:
				rectangle_ = new Rectangle(this.ShadowShift + 10, this.ShadowShift + 10, base.Width - this.ShadowShift - 10, base.Height - this.ShadowShift - 10);
				break;
			case ShadowMode.Surrounded:
				rectangle_ = new Rectangle(0, 0, base.Width, base.Height);
				break;
			case ShadowMode.Dropped:
				rectangle_ = new Rectangle(this.int_2, 0, base.Width - 2 * this.int_2, base.Height);
				break;
			}
			GraphicsPath path = ((this.shadowMode_0 == ShadowMode.Dropped) ? this.method_1(rectangle_, this.int_1 * 2, bool_0: true) : this.method_0(rectangle_, this.int_1 * 2));
			using PathGradientBrush pathGradientBrush = new PathGradientBrush(path);
			pathGradientBrush.CenterPoint = new PointF((float)((double)rectangle_.Width / 2.0), (float)((double)rectangle_.Height / 2.0));
			pathGradientBrush.SurroundColors = new Color[1] { Color.Transparent };
			pathGradientBrush.CenterColor = Color.FromArgb(this.int_0, this.color_1);
			graphics_0.FillPath(pathGradientBrush, path);
			pathGradientBrush.FocusScales = new PointF(0.95f, 0.85f);
			graphics_0.FillPath(pathGradientBrush, path);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			_ = e.Graphics;
			Rectangle rectangle_ = default(Rectangle);
			if (this.int_2 > 0)
			{
				this.method_9(e.Graphics);
			}
			switch (this.shadowMode_0)
			{
			case ShadowMode.ForwardDiagonal:
				rectangle_ = new Rectangle(0, 0, base.Width - this.int_2 - 1, base.Height - this.int_2 - 1);
				break;
			case ShadowMode.Surrounded:
				rectangle_ = new Rectangle(this.ShadowShift, this.int_2 + this.int_4, base.Width - 2 * this.ShadowShift - 1, base.Height - 2 * this.ShadowShift - 1);
				break;
			case ShadowMode.Dropped:
				rectangle_ = new Rectangle(0, 0, base.Width - 1, base.Height - 2 * this.ShadowShift - 1);
				break;
			}
			this.method_6(e.Graphics, rectangle_);
			base.OnPaint(e);
		}
	}
}

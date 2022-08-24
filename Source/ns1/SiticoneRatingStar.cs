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

namespace ns1
{
	[DefaultEvent("ValueChanged")]
	[Description("A Rating Control")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	public class SiticoneRatingStar : Control, IControl
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Font font_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_1;

		private float float_0 = 0f;

		private Color color_0;

		private Color color_1 = Class0.color_15;

		private Color color_2 = Class0.color_32;

		private int int_0 = 2;

		private Color color_3;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The rating control's font style")]
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
		[Description("The rating control's text")]
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

		[Description("The rating control's ForeColor")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new string ForeColor
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		[DefaultValue(0f)]
		[Description("The rating control's minimum value")]
		public float Minimum => 0f;

		[DefaultValue(5f)]
		[Description("The rating control's maximum value")]
		public float Maximum => 5f;

		[DefaultValue(0f)]
		[Description("The rating control's current value")]
		public float Value
		{
			get
			{
				return this.float_0;
			}
			set
			{
				if (this.float_0 != value)
				{
					if (value > this.Maximum)
					{
						this.float_0 = this.Maximum;
					}
					else if (value < this.Minimum)
					{
						this.float_0 = this.Minimum;
					}
					else
					{
						this.float_0 = value;
					}
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, EventArgs.Empty);
					}
					base.Invalidate();
				}
			}
		}

		[Description("The rating control's fill color")]
		[DefaultValue(typeof(Color), "")]
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

		[DefaultValue(typeof(Color), "113, 208, 255")]
		[Description("The rating control's color")]
		public Color RatingColor
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

		[Description("The rating control's border color")]
		[DefaultValue(typeof(Color), "193, 200, 207")]
		public Color BorderColor
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

		[Description("The rating control's border thickness")]
		[DefaultValue(2)]
		public int BorderThickness
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

		[DefaultValue(typeof(Color), "")]
		[Description("The rating control's color when focused")]
		public Color FocusedColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
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

		public SiticoneRatingStar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.Size = new Size(200, 40);
			Class13.smethod_0();
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if ((keyData == Keys.Tab) | (Control.ModifierKeys == Keys.Shift))
			{
				return base.ProcessDialogKey(keyData);
			}
			return true;
		}

		private PointF[] method_0(PointF pointF_0, float float_1, float float_2)
		{
			double num = Math.PI / 5.0;
			double num2 = Math.PI * 2.0 / 5.0;
			float num3 = (float)Math.Sin(num);
			float num4 = (float)Math.Sin(num2);
			float num5 = (float)Math.Cos(num);
			float num6 = (float)Math.Cos(num2);
			PointF[] array = new PointF[10] { pointF_0, pointF_0, pointF_0, pointF_0, pointF_0, pointF_0, pointF_0, pointF_0, pointF_0, pointF_0 };
			array[0].Y -= float_1;
			array[1].X += float_2 * num3;
			array[1].Y -= float_2 * num5;
			array[2].X += float_1 * num4;
			array[2].Y -= float_1 * num6;
			array[3].X += float_2 * num4;
			array[3].Y += float_2 * num6;
			array[4].X += float_1 * num3;
			array[4].Y += float_1 * num5;
			array[5].Y += float_2;
			array[6].X += array[6].X - array[4].X;
			array[6].Y = array[4].Y;
			array[7].X += array[7].X - array[3].X;
			array[7].Y = array[3].Y;
			array[8].X += array[8].X - array[2].X;
			array[8].Y = array[2].Y;
			array[9].X += array[9].X - array[1].X;
			array[9].Y = array[1].Y;
			return array;
		}

		private PointF[] method_1(PointF pointF_0, float float_1)
		{
			return this.method_0(new PointF(float_1 + pointF_0.X, float_1 + float_1 / 12f + pointF_0.Y), float_1, float_1 / 2f);
		}

		private float method_2()
		{
			return (float)base.Height - 10f;
		}

		private float method_3(int int_1)
		{
			float result = 4f;
			if (int_1 == 2)
			{
				result = 4f;
			}
			if (int_1 == 2)
			{
				result = (float)base.Width / 4f - this.method_2() / 2f + this.method_2() / 4f + 2f;
			}
			if (int_1 == 3)
			{
				result = (float)base.Width / 2f - this.method_2() / 2f;
			}
			if (int_1 == 4)
			{
				result = (float)base.Width / 4f - this.method_2() / 2f + ((float)base.Width / 2f - this.method_2() / 4f) - 2f;
			}
			if (int_1 == 5)
			{
				result = (float)base.Width - (this.method_2() + 4f);
			}
			return result;
		}

		private float method_4(int int_1)
		{
			float result = 0f;
			if (this.Value == (float)int_1 - 0.5f)
			{
				result = this.method_2() / 2f;
			}
			else if (this.Value < (float)int_1)
			{
				result = 0f;
			}
			else if (this.Value >= (float)int_1)
			{
				result = this.method_2();
			}
			return result;
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnLostFocus(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			if (this.Focused)
			{
				switch (e.KeyCode)
				{
				case Keys.Prior:
					this.Value = (float)((double)this.Value + 0.5);
					break;
				case Keys.Next:
					this.Value = (float)((double)this.Value - 0.5);
					break;
				case Keys.End:
					this.Value = this.Maximum;
					break;
				case Keys.Home:
					this.Value = this.Minimum;
					break;
				case Keys.Up:
				case Keys.Right:
					this.Value = (float)((double)this.Value + 0.5);
					break;
				case Keys.Left:
				case Keys.Down:
					this.Value = (float)((double)this.Value - 0.5);
					break;
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			int num = 1;
			do
			{
				float num2 = this.method_3(num);
				if ((float)e.Location.X >= num2)
				{
					this.Value = num;
				}
				if (((float)e.Location.X < num2 + this.method_2() / 2f) & ((float)e.Location.X >= num2))
				{
					this.Value = (float)((double)num - 0.5);
				}
				num = checked(num + 1);
			}
			while (num <= 5);
			base.OnMouseDown(e);
		}

		private void method_5(Graphics graphics_0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			float num = 4f;
			float num2 = 4f;
			int num3 = 1;
			do
			{
				num = this.method_3(num3);
				PointF[] points = this.method_1(new PointF(num, num2), this.method_2() / 2f);
				graphics_0.FillPolygon(new SolidBrush(this.FillColor), points);
				if (this.method_4(num3) > 0f)
				{
					graphicsPath.AddPolygon(points);
					graphics.FillRectangle(new SolidBrush(this.RatingColor), new RectangleF(num, num2, this.method_4(num3), this.method_2()));
					graphics_0.FillPath(new TextureBrush(bitmap), graphicsPath);
				}
				if (this.Focused && this.FocusedColor != Color.Empty)
				{
					graphics_0.DrawPolygon(new Pen(this.FocusedColor, (this.BorderThickness <= 0) ? 1 : this.BorderThickness), points);
				}
				else if (this.BorderThickness > 0)
				{
					graphics_0.DrawPolygon(new Pen((this.method_4(num3) > 0f) ? this.RatingColor : this.BorderColor, this.BorderThickness), points);
				}
				num3++;
			}
			while (num3 <= 5);
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

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns3;
using ns5;

namespace ns2
{
	[Description("ShadowDecoration")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[DebuggerStepThrough]
	public class ShadowDecoration
	{
		private Bitmap bitmap_0;

		private bool bool_0;

		private Control control_0;

		private int int_0;

		private Control control_1;

		private bool bool_1;

		private ShadowMode shadowMode_0 = ShadowMode.Custom;

		private Color color_0;

		private int int_1;

		private Padding padding_0;

		private int int_2;

		private int int_3 = 0;

		[Browsable(false)]
		public Control Parent
		{
			get
			{
				return this.control_0;
			}
			set
			{
				if (this.control_0 != null)
				{
					this.control_0.VisibleChanged -= new EventHandler(control_0_VisibleChanged);
				}
				this.control_0 = value;
				if (this.control_0 != null)
				{
					this.control_0.VisibleChanged += new EventHandler(control_0_VisibleChanged);
				}
			}
		}

		[Browsable(true)]
		[Description("If true, the shadow decoration will be enabled")]
		[DefaultValue(false)]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public bool Enabled
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					this.bool_1 = value;
					if (this.int_0 > 0 && this.Parent != null && this.bool_1 && this.Parent.BackColor != Color.Transparent)
					{
						this.Parent.BackColor = Color.Transparent;
					}
					if (this.control_1 == null)
					{
						new Thread(new ThreadStart(method_3)).Start();
					}
					else
					{
						this.method_2(this.bool_1);
					}
				}
				this.method_5();
			}
		}

		[DefaultValue(ShadowMode.Custom)]
		[Browsable(true)]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The shadow decoration mode")]
		public ShadowMode Mode
		{
			get
			{
				return this.shadowMode_0;
			}
			set
			{
				this.shadowMode_0 = value;
				this.method_5();
			}
		}

		[Description("The shadow decoration color")]
		[DefaultValue(typeof(Color), "Black")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		public Color Color
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.method_5();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The shadow decoration depth")]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		[DefaultValue(30)]
		public int Depth
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = ((value > 255) ? 255 : ((value >= 0) ? value : 0));
				this.method_5();
			}
		}

		[DefaultValue(typeof(Padding), "5, 5, 5, 5")]
		[Description("The shadow decoration shadow")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		public Padding Shadow
		{
			get
			{
				return this.padding_0;
			}
			set
			{
				this.padding_0 = value;
				this.method_5();
			}
		}

		[Browsable(true)]
		[Description("The shadow decoration border radius")]
		[NotifyParentProperty(true)]
		[DefaultValue(6)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public int BorderRadius
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = ((value >= 0) ? value : 0);
				this.method_5();
			}
		}

		public ShadowDecoration(IControl owner)
		{
			this.color_0 = Color.Black;
			this.int_1 = 30;
			this.padding_0 = new Padding(5);
			this.int_2 = 6;
			this.bool_0 = false;
			this.Parent = (Control)owner;
			this.Parent.Invalidate();
		}

		internal void method_0(int int_4)
		{
			this.int_0 = int_4;
			if (this.int_0 > 0 && this.Parent != null && this.bool_1 && this.Parent.BackColor != Color.Transparent)
			{
				this.Parent.BackColor = Color.Transparent;
			}
		}

		internal void method_1(PaintValueEventArgs paintValueEventArgs_0)
		{
			if (this.Enabled)
			{
				paintValueEventArgs_0.Graphics.FillRectangle(new SolidBrush(this.color_0), paintValueEventArgs_0.Bounds);
			}
		}

		private void method_2(bool bool_2)
		{
			if (!this.method_4())
			{
				return;
			}
			if (bool_2)
			{
				if (this.int_3 == 0)
				{
					this.int_3 = 1;
					this.control_1.ControlRemoved += new ControlEventHandler(control_1_ControlRemoved);
					this.control_1.Paint += new PaintEventHandler(control_1_Paint);
					this.control_1.Resize += new EventHandler(control_1_Resize);
					this.Parent.Resize += new EventHandler(method_8);
				}
			}
			else
			{
				this.int_3 = 0;
				this.control_1.ControlRemoved -= new ControlEventHandler(control_1_ControlRemoved);
				this.control_1.Paint -= new PaintEventHandler(control_1_Paint);
				this.control_1.Resize -= new EventHandler(control_1_Resize);
				this.Parent.Resize -= new EventHandler(method_8);
			}
		}

		private void method_3()
		{
			while (this.Parent.Parent == null)
			{
				Thread.Sleep(100);
				Application.DoEvents();
			}
			this.control_1 = this.Parent.Parent;
			this.method_2(this.bool_1);
			this.method_5();
		}

		private bool method_4()
		{
			return !((IControl)this.Parent).IsDesignMode && this.control_1 != null;
		}

		private void method_5()
		{
			this.bool_0 = false;
			if (this.method_4())
			{
				this.control_1.Invalidate();
			}
		}

		public override string ToString()
		{
			return string.Empty;
		}

		private Rectangle method_6()
		{
			return checked(new Rectangle(this.Parent.Location.X - this.Shadow.Left, this.Parent.Location.Y - this.Shadow.Top, this.Parent.Width + (this.Shadow.Left + this.Shadow.Right), this.Parent.Height + (this.Shadow.Top + this.Shadow.Bottom)));
		}

		private int method_7()
		{
			int num = ((this.Shadow.Left < this.Shadow.Right) ? this.Shadow.Right : this.Shadow.Left);
			int num2 = ((this.Shadow.Top < this.Shadow.Bottom) ? this.Shadow.Right : this.Shadow.Left);
			if (num >= num2)
			{
				return num;
			}
			return num2;
		}

		private void control_0_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Enabled)
			{
				this.method_2(this.Parent.Visible);
			}
			this.method_5();
		}

		private void method_8(object sender, EventArgs e)
		{
			this.method_5();
		}

		private void control_1_ControlRemoved(object sender, ControlEventArgs e)
		{
			if (e.Control == this.Parent)
			{
				this.method_2(bool_2: false);
				this.method_5();
			}
		}

		private void control_1_Resize(object sender, EventArgs e)
		{
			this.control_1.Invalidate();
		}

		private void control_1_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				if (!this.Parent.Visible)
				{
					return;
				}
				if (!this.bool_0 | (this.bitmap_0 == null))
				{
					Bitmap bitmap = new Bitmap(this.method_6().Width / 2, this.method_6().Height / 2);
					Graphics graphics = Graphics.FromImage(bitmap);
					if (this.shadowMode_0 == ShadowMode.Custom)
					{
						graphics.SmoothingMode = SmoothingMode.AntiAlias;
						graphics.FillPath(new SolidBrush(Color.FromArgb(this.Depth, this.Color)), Class6.smethod_12(Class6.smethod_11(new RectangleF(0f, 0f, this.method_6().Width / 2, this.method_6().Height / 2)), (this.BorderRadius < 2) ? 2 : this.BorderRadius));
					}
					else
					{
						GraphicsPath graphicsPath = new GraphicsPath();
						graphicsPath.AddEllipse(0, 0, this.method_6().Width / 2 - 1, this.method_6().Height / 2 - 1);
						graphics.SmoothingMode = SmoothingMode.AntiAlias;
						graphics.FillPath(new SolidBrush(Color.FromArgb(this.Depth, this.Color)), graphicsPath);
					}
					this.bitmap_0 = new Bitmap(this.method_6().Width, this.method_6().Height);
					Graphics graphics2 = Graphics.FromImage(this.bitmap_0);
					graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
					int num = this.method_7();
					int num2 = ((num >= 10) ? 10 : num);
					checked
					{
						for (int i = 0; i <= num2; i++)
						{
							graphics2.DrawImage(bitmap, new Rectangle(i, i, this.method_6().Width - i * 2, this.method_6().Height - i * 2));
						}
						bitmap.Dispose();
						this.bool_0 = true;
					}
				}
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.DrawImage(this.bitmap_0, this.method_6().X, this.method_6().Y);
			}
			catch
			{
			}
		}
	}
}

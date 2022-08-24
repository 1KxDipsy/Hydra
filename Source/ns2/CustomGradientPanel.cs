using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns0;
using ns3;

namespace ns2
{
	[ToolboxItem(false)]
	public class CustomGradientPanel : System.Windows.Forms.Panel, IControl
	{
		private ShadowDecoration shadowDecoration_0;

		private Color color_0;

		private int int_0;

		private Color color_1;

		private Padding padding_0;

		private int int_1;

		private Image image_0;

		private Color color_2;

		private Color color_3;

		private Color color_4;

		private Color color_5;

		private int int_2;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

		[Browsable(false)]
		protected Color DefaultFillColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.method_1();
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor2
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				this.method_1();
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor3
		{
			get
			{
				return this.color_4;
			}
			set
			{
				this.color_4 = value;
				this.method_1();
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor4
		{
			get
			{
				return this.color_5;
			}
			set
			{
				this.color_5 = value;
				this.method_1();
			}
		}

		[Browsable(false)]
		protected int DefaultQuality
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.method_1();
			}
		}

		[Browsable(false)]
		protected DashStyle DefaultBorderStyle
		{
			get
			{
				return this.dashStyle_0;
			}
			set
			{
				this.dashStyle_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
		protected Color DefaultBorderColor
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
		protected int DefaultBorderThickness
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
		protected Color DefaultCustomBorderColor
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
		protected Padding DefaultCustomBorderThickness
		{
			get
			{
				return this.padding_0;
			}
			set
			{
				this.padding_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultBorderRadius
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = ((value >= 0) ? value : 0);
				base.Invalidate();
			}
		}

		public CustomGradientPanel()
		{
			this.color_2 = Color.White;
			this.color_3 = Color.White;
			this.color_4 = Color.White;
			this.color_5 = Color.White;
			this.int_2 = 10;
			this.int_0 = 0;
			this.padding_0 = new Padding(0);
			this.int_1 = 0;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			base.Size = new Size(200, 200);
			this.method_1();
		}

		private Image method_0()
		{
			if (this.image_0 != null)
			{
				Bitmap bitmap = new Bitmap(base.Width, base.Height);
				Class6.smethod_5(Graphics.FromImage(bitmap), this.image_0, ImageLayout.Stretch, base.ClientRectangle, base.ClientRectangle, new Point(0, 0), this.RightToLeft);
				return bitmap;
			}
			return null;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Image image = this.method_0();
			if (this.int_1 > 0)
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				GraphicsPath path = Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), checked(this.int_1 * 2));
				if (image != null)
				{
					using (TextureBrush textureBrush = new TextureBrush(image))
					{
						textureBrush.TranslateTransform(0f, 0f);
						graphics.FillPath(textureBrush, path);
					}
					graphics.SmoothingMode = SmoothingMode.HighQuality;
				}
				if (this.int_0 > 0)
				{
					Class6.smethod_20(graphics, (this.int_0 > 0) ? new SolidBrush(this.color_0) : new SolidBrush(this.color_2), base.ClientRectangle, this.int_1, this.int_0, this.dashStyle_0);
				}
			}
			else
			{
				if (image != null)
				{
					graphics.DrawImage(image, base.ClientRectangle);
				}
				Class6.smethod_22(graphics, new SolidBrush(this.color_0), base.ClientRectangle, (this.int_0 > 0) ? this.int_0 : 0, this.dashStyle_0);
			}
			Class6.smethod_13(graphics, this.color_1, base.ClientRectangle, this.padding_0, this.int_1);
			base.OnPaint(e);
		}

		protected override void OnResize(EventArgs e)
		{
			this.method_1();
			base.OnResize(e);
		}

		private void method_1()
		{
			Bitmap bitmap = new Bitmap(this.int_2, this.int_2);
			if (this.int_2 == 100)
			{
				bitmap = new Bitmap(base.Width, base.Height);
			}
			int num = bitmap.Width - 1;
			for (int i = 0; i <= num; i++)
			{
				Color color = Class6.smethod_23(int.Parse(Math.Round((double)i / (double)bitmap.Width * 100.0, 0).ToString()), this.color_2, this.color_5);
				int num2 = bitmap.Height - 1;
				for (int j = 0; j <= num2; j++)
				{
					bitmap.SetPixel(i, j, Class6.smethod_1(color, Class6.smethod_23(int.Parse(Math.Round((double)j / (double)bitmap.Height * 100.0, 0).ToString()), this.color_4, this.color_3)));
				}
			}
			this.image_0 = bitmap;
			base.Invalidate();
		}
	}
}

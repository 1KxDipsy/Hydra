using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using ns0;
using ns2;
using ns3;
using ns5;

namespace ns1
{
	[Description("Siticone chip control")]
	public class SiticoneChip : Control, IControl
	{
		private SiticoneButton siticoneButton_0;

		private System.Windows.Forms.PictureBox pictureBox_0;

		private bool bool_0 = false;

		private Image image_0 = null;

		[Description("The press color when the close button is pressed")]
		[Browsable(false)]
		private Color color_0 = Color.Black;

		[Description("The font of the Siticone Chip Icon")]
		[Browsable(false)]
		private Font font_0;

		private Color color_1 = Color.FromArgb(255, 105, 180);

		[Browsable(true)]
		private float float_0 = 10f;

		[Browsable(true)]
		private bool bool_1 = false;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private ShadowDecoration shadowDecoration_0;

		private Color color_2 = Class0.color_25;

		private Color color_3;

		private int int_0;

		private int int_1;

		private bool bool_2;

		private HorizontalAlignment horizontalAlignment_0 = HorizontalAlignment.Center;

		private TextTransform textTransform_0 = TextTransform.None;

		private Point point_0;

		private TextRenderingHint textRenderingHint_0;

		[Browsable(true)]
		[Description("If true, the control will display its icon")]
		public bool ShowIcon
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				bool flag;
				if (flag = this.bool_0)
				{
					if (!flag)
					{
						base.Invalidate();
					}
					else
					{
						base.Controls.Add(this.pictureBox_0);
					}
				}
				else
				{
					base.Controls.Remove(this.pictureBox_0);
				}
			}
		}

		[Browsable(true)]
		[Description("The control's icon")]
		public Image Icon
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
				this.pictureBox_0.Image = value;
				this.pictureBox_0.Invalidate();
				base.Invalidate();
			}
		}

		public Color CloseButtonPressColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.siticoneButton_0.PressedColor = value;
				this.siticoneButton_0.Invalidate();
				base.Invalidate();
			}
		}

		private Font Font_0
		{
			get
			{
				return this.font_0 = new Font("Marlett", this.CloseButtonSize);
			}
			set
			{
				this.font_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[Description("The Siticone Chip Icon Color")]
		public Color CloseButtonForeColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.siticoneButton_0.ForeColor = value;
				this.siticoneButton_0.Invalidate();
				base.Invalidate();
			}
		}

		[Description("The size of the Siticone Chip Icon")]
		public float CloseButtonSize
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
				this.siticoneButton_0.Font = new Font("Marlett", value);
				this.siticoneButton_0.Invalidate();
				base.Invalidate();
			}
		}

		[Description("If true, the Siticone Chip Close button will be displayed")]
		public bool IsClosable
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				bool flag;
				if (flag = this.bool_1)
				{
					if (!flag)
					{
						base.Invalidate();
						return;
					}
					int num = base.Width - 30;
					int num2 = Convert.ToInt32(base.Height / 2 - this.siticoneButton_0.Height / 2);
					this.siticoneButton_0.Location = new Point(num, num2);
					base.Controls.Add(this.siticoneButton_0);
				}
				else
				{
					base.Controls.Remove(this.siticoneButton_0);
				}
			}
		}

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
		[DefaultValue(DashStyle.Solid)]
		[Browsable(true)]
		public DashStyle BorderStyle
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Description("Shadow property of the control to add and customize a control's shadow")]
		public ShadowDecoration ShadowDecoration
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
				base.Invalidate();
			}
		}

		[Description("The BackColor that will fill the control")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "255, 77, 165")]
		public Color FillColor
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

		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
		[Description("The control's border color")]
		public Color BorderColor
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

		[DefaultValue(0)]
		[Browsable(true)]
		[Description("The border thickness. The higher the value, the thicker the border")]
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

		[Description("The curve angle of the control on all angles")]
		[DefaultValue(0)]
		[Browsable(true)]
		public int BorderRadius
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

		[Description("If true, the background will allow a transparent color")]
		[DefaultValue(false)]
		[Browsable(true)]
		public bool UseTransparentBackground
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

		[Category("Options")]
		[Localizable(true)]
		[Description("Gets or sets the text asociated with this control.")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Size = new Size(Convert.ToInt32(base.CreateGraphics().MeasureString(this.Text, this.Font).Width) + 80, base.Height);
				base.Invalidate();
			}
		}

		[Browsable(false)]
		[Description("The control's text alignment")]
		[DefaultValue(2)]
		private HorizontalAlignment HorizontalAlignment_0
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

		[Browsable(true)]
		[Description("The control's text transform property which allows you to change the appearance of the text")]
		[DefaultValue(0)]
		public TextTransform TextTransform
		{
			get
			{
				return this.textTransform_0;
			}
			set
			{
				this.textTransform_0 = value;
				base.Invalidate();
			}
		}

		[Description("The control's text position")]
		[DefaultValue(typeof(Point), "0, 0")]
		[Browsable(true)]
		public Point TextOffset
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

		[DefaultValue(5)]
		[Description("This property allows you to change how text is printed onto the control")]
		[Browsable(true)]
		public TextRenderingHint TextRenderingHint
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

		public SiticoneChip()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.ForeColor = Color.White;
			this.Font = new Font("Segoe UI", 9f);
			base.Size = new Size(160, 40);
			this.BorderColor = Color.FromArgb(255, 77, 165);
			this.FillColor = Color.FromArgb(70, 255, 77, 165);
			this.BorderThickness = 1;
			this.BorderRadius = 19;
			this.BorderStyle = DashStyle.DashDot;
			this.pictureBox_0 = new System.Windows.Forms.PictureBox
			{
				BackColor = Color.Transparent,
				Enabled = false,
				SizeMode = PictureBoxSizeMode.Zoom,
				Size = new Size(25, 25),
				Location = new Point(8, 8)
			};
			this.siticoneButton_0 = new SiticoneButton
			{
				Text = "r",
				Font = new Font("Marlett", this.CloseButtonSize),
				BorderColor = Color.Transparent,
				FillColor = Color.Transparent,
				BorderRadius = 14,
				BorderThickness = 0,
				ForeColor = Color.Magenta,
				Size = new Size(30, 30),
				BackColor = Color.Transparent
			};
			this.siticoneButton_0.Click += new EventHandler(siticoneButton_0_Click);
		}

		private void siticoneButton_0_Click(object sender, EventArgs e)
		{
			base.Dispose();
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

		protected override void OnResize(EventArgs e)
		{
			base.Size = new Size(Convert.ToInt32(base.CreateGraphics().MeasureString(this.Text, this.Font).Width) + 80, base.Height);
			base.OnResize(e);
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.Size = new Size(Convert.ToInt32(base.CreateGraphics().MeasureString(this.Text, this.Font).Width) + 80, base.Height);
			base.OnFontChanged(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			if (this.BorderRadius > 0)
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.FillPath(path: Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), checked(this.BorderRadius * 2)), brush: new SolidBrush(this.FillColor));
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				if ((this.BackgroundImage == null) & (this.BorderThickness == 0))
				{
					Class6.smethod_20(graphics, new SolidBrush(this.BorderColor), base.ClientRectangle, this.BorderRadius, this.BorderThickness);
				}
				else
				{
					Class6.smethod_20(graphics, new SolidBrush(this.BorderColor), base.ClientRectangle, this.BorderRadius, this.BorderThickness, this.BorderStyle);
				}
			}
			else
			{
				graphics.FillRectangle(new SolidBrush(this.FillColor), base.ClientRectangle);
				Class6.smethod_22(graphics, new SolidBrush(this.BorderColor), base.ClientRectangle, this.BorderThickness, this.dashStyle_0);
			}
			Rectangle rectangle = new Rectangle(this.point_0.X, this.point_0.Y, base.Width, base.Height);
			if (this.horizontalAlignment_0 == HorizontalAlignment.Right)
			{
				rectangle.X = -10;
				rectangle.X += this.point_0.X;
			}
			else if (this.horizontalAlignment_0 == HorizontalAlignment.Left)
			{
				rectangle.X += 10;
			}
			_ = this.Text;
			switch (this.textTransform_0)
			{
			case TextTransform.LowerCase:
				this.Text.ToLower();
				break;
			case TextTransform.UpperCase:
				this.Text.ToUpper();
				break;
			}
			graphics.TextRenderingHint = this.textRenderingHint_0;
			graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rectangle, new StringFormat
			{
				FormatFlags = StringFormatFlags.NoWrap,
				Alignment = Class6.smethod_4(this.horizontalAlignment_0),
				LineAlignment = StringAlignment.Center
			});
			bool isClosable;
			if (isClosable = this.IsClosable)
			{
				if (!isClosable)
				{
					base.OnPaint(e);
					return;
				}
				int num = base.Width - 33;
				int num2 = Convert.ToInt32(base.Height / 2 - this.siticoneButton_0.Height / 2);
				this.siticoneButton_0.Location = new Point(num, num2);
				base.Controls.Add(this.siticoneButton_0);
			}
			else
			{
				base.Controls.Remove(this.siticoneButton_0);
			}
		}
	}
}

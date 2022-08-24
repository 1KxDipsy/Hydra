using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns3;
using ns5;

namespace ns2
{
	[ToolboxItem(false)]
	public class ComboBox : System.Windows.Forms.ComboBox, IControl
	{
		private TextRenderingHint textRenderingHint_0;

		private TextTransform textTransform_0;

		private int int_0;

		private int int_1;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		private int int_2;

		private MouseState mouseState_0;

		private GraphicsPath graphicsPath_0;

		private HorizontalAlignment horizontalAlignment_0 = HorizontalAlignment.Left;

		private ComboBoxItemsAppearance comboBoxItemsAppearance_0;

		private ComboBoxState comboBoxState_0;

		private ShadowDecoration shadowDecoration_0;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private bool bool_0 = false;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool IsDesignMode => base.DesignMode;

		[DefaultValue(HorizontalAlignment.Left)]
		[Description("Gets or sets how text is aligned in a TextBox control.")]
		[Browsable(true)]
		public HorizontalAlignment TextAlign
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ComboBoxItemsAppearance DefaultItemsAppearance
		{
			get
			{
				if (this.comboBoxItemsAppearance_0 == null)
				{
					this.comboBoxItemsAppearance_0 = new ComboBoxItemsAppearance
					{
						Parent = this
					};
				}
				return this.comboBoxItemsAppearance_0;
			}
			set
			{
				this.comboBoxItemsAppearance_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ComboBoxState DefaultHoveredState
		{
			get
			{
				if (this.comboBoxState_0 == null)
				{
					this.comboBoxState_0 = new ComboBoxState
					{
						Parent = this
					};
				}
				return this.comboBoxState_0;
			}
			set
			{
				this.comboBoxState_0 = value;
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
		protected TextTransform DefaultTextTransform
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

		[Browsable(false)]
		protected int DefaultBorderRadius
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = ((value >= 0) ? value : 0);
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultStartIndex
		{
			get
			{
				return this.int_1;
			}
			set
			{
				try
				{
					if ((base.Items.Count >= value) & (base.Items.Count > 0))
					{
						base.SelectedIndex = value;
						this.int_1 = value;
					}
				}
				catch
				{
				}
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor
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
		protected Color DefaultBorderColor
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
		protected Color DefaultFocusedColor
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
		protected int DefaultBorderThickness
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

		public ComboBox()
		{
			this.textRenderingHint_0 = TextRenderingHint.ClearTypeGridFit;
			this.int_1 = -1;
			this.color_0 = Color.White;
			this.color_1 = Color.FromArgb(217, 221, 226);
			this.color_2 = Color.FromArgb(136, 191, 255);
			this.int_2 = 1;
			this.mouseState_0 = MouseState.const_2;
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			base.SetStyle(ControlStyles.ResizeRedraw, value: true);
			base.SetStyle(ControlStyles.UserPaint, value: true);
			base.SetStyle(ControlStyles.DoubleBuffer, value: true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			base.DrawMode = DrawMode.OwnerDrawFixed;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ForeColor = Color.FromArgb(68, 88, 112);
			this.Font = new Font("Segoe UI", 10f);
			base.Size = new Size(140, 36);
			base.ItemHeight = 30;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.bool_0 = true;
			this.mouseState_0 = MouseState.DOWN;
			base.Invalidate();
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.mouseState_0 = ((!this.bool_0) ? MouseState.const_2 : MouseState.HOVER);
			base.Invalidate();
			base.OnMouseUp(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.bool_0 = true;
			this.mouseState_0 = MouseState.HOVER;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.bool_0 = false;
			this.mouseState_0 = MouseState.const_2;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			this.bool_0 = false;
			this.mouseState_0 = MouseState.const_2;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		private Color method_0()
		{
			if (!(this.DefaultItemsAppearance.ForeColor == Color.Empty))
			{
				return this.DefaultItemsAppearance.ForeColor;
			}
			return this.ForeColor;
		}

		private Color method_1()
		{
			if (!(this.DefaultItemsAppearance.BackColor == Color.Empty))
			{
				return this.DefaultItemsAppearance.BackColor;
			}
			return this.color_0;
		}

		private Font method_2()
		{
			if (this.DefaultItemsAppearance.Font != null)
			{
				return this.DefaultItemsAppearance.Font;
			}
			return this.Font;
		}

		private Font method_3()
		{
			if (this.DefaultItemsAppearance.SelectedFont != null)
			{
				return this.DefaultItemsAppearance.SelectedFont;
			}
			return this.method_2();
		}

		private Color method_4()
		{
			if (!(this.DefaultItemsAppearance.SelectedBackColor == Color.Empty))
			{
				return this.DefaultItemsAppearance.SelectedBackColor;
			}
			return Class6.smethod_10(this.method_1(), Color.Black, Color.White, 15);
		}

		private Color method_5()
		{
			if (!(this.DefaultItemsAppearance.SelectedForeColor == Color.Empty))
			{
				return this.DefaultItemsAppearance.SelectedForeColor;
			}
			return this.method_0();
		}

		private Color method_6()
		{
			if (!(this.DefaultHoveredState.FillColor == Color.Empty))
			{
				return this.DefaultHoveredState.FillColor;
			}
			return this.color_0;
		}

		private Color method_7()
		{
			if (!(this.DefaultHoveredState.ForeColor == Color.Empty))
			{
				return this.DefaultHoveredState.ForeColor;
			}
			return this.ForeColor;
		}

		private Color method_8()
		{
			if (!(this.DefaultHoveredState.BorderColor == Color.Empty))
			{
				return this.DefaultHoveredState.BorderColor;
			}
			return Class6.smethod_10(this.color_1, Color.Black, Color.White, 10);
		}

		private Font method_9()
		{
			if (this.DefaultHoveredState.Font != null)
			{
				return this.DefaultHoveredState.Font;
			}
			return this.Font;
		}

		private Bitmap method_10(Color color_3)
		{
			Bitmap bitmap = new Bitmap(20, 20);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawLine(new Pen(color_3, 2f), new Point(18, 10), new Point(14, 14));
			graphics.DrawLine(new Pen(color_3, 2f), new Point(14, 14), new Point(10, 10));
			graphics.DrawLine(new Pen(color_3), new Point(14, 15), new Point(14, 14));
			return bitmap;
		}

		private string method_11(string string_0)
		{
			return this.textTransform_0 switch
			{
				TextTransform.LowerCase => string_0.ToLower(), 
				TextTransform.UpperCase => string_0.ToUpper(), 
				_ => string_0, 
			};
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			try
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(this.method_4()), e.Bounds);
					e.Graphics.DrawString(this.method_11(base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index]))), this.method_3(), new SolidBrush(this.method_5()), new Rectangle(10, e.Bounds.Y, e.Bounds.Width - 40, e.Bounds.Height), new StringFormat
					{
						Trimming = StringTrimming.EllipsisPath,
						FormatFlags = StringFormatFlags.LineLimit,
						LineAlignment = StringAlignment.Center,
						Alignment = Class6.smethod_4(this.horizontalAlignment_0)
					});
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(this.method_1()), e.Bounds);
					e.Graphics.DrawString(this.method_11(base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index]))), this.method_2(), new SolidBrush(this.method_0()), new Rectangle(10, e.Bounds.Y, e.Bounds.Width - 40, e.Bounds.Height), new StringFormat
					{
						Trimming = StringTrimming.EllipsisPath,
						FormatFlags = StringFormatFlags.LineLimit,
						LineAlignment = StringAlignment.Center,
						Alignment = Class6.smethod_4(this.horizontalAlignment_0)
					});
				}
			}
			catch
			{
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Color color = this.color_1;
			Color color2 = this.color_0;
			Color color3 = this.ForeColor;
			Font font = this.Font;
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.TextRenderingHint = this.textRenderingHint_0;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			if ((this.mouseState_0 == MouseState.DOWN) | (this.mouseState_0 == MouseState.HOVER))
			{
				color = this.method_8();
				color2 = this.method_6();
				color3 = this.method_7();
				font = this.method_9();
			}
			bool flag = base.Enabled & this.Focused & (this.color_2 != Color.Empty);
			if (this.int_0 > 0)
			{
				this.graphicsPath_0 = Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), this.int_0 * 2);
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.FillPath(new SolidBrush(color2), this.graphicsPath_0);
				Class6.smethod_20(graphics, flag ? new SolidBrush(this.color_2) : ((this.int_2 > 0) ? new SolidBrush(color) : new SolidBrush(color2)), base.ClientRectangle, this.int_0, this.int_2, this.dashStyle_0);
			}
			else
			{
				this.graphicsPath_0 = null;
				graphics.SmoothingMode = SmoothingMode.Default;
				graphics.FillRectangle(new SolidBrush(color2), base.ClientRectangle);
				Class6.smethod_22(graphics, flag ? new SolidBrush(this.color_2) : new SolidBrush(color), base.ClientRectangle, (this.int_2 > 0) ? this.int_2 : (flag ? 1 : 0), this.dashStyle_0);
			}
			if (this.Text != string.Empty)
			{
				graphics.DrawString(this.method_11(this.Text), font, new SolidBrush(color3), new Rectangle(10, 0, base.Width - 40, base.Height - 1), new StringFormat
				{
					Trimming = StringTrimming.EllipsisPath,
					FormatFlags = StringFormatFlags.LineLimit,
					LineAlignment = StringAlignment.Center,
					Alignment = Class6.smethod_4(this.horizontalAlignment_0)
				});
			}
			graphics.DrawImage(this.method_10(color3), new Point(base.Width - 30, (int)Math.Round((double)base.Height / 2.0 - 12.0)));
			if (!base.Enabled)
			{
				ControlPaint.DrawImageDisabled(e.Graphics, bitmap, 0, 0, Color.White);
			}
			else
			{
				e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			}
			graphics.Dispose();
			bitmap.Dispose();
		}
	}
}

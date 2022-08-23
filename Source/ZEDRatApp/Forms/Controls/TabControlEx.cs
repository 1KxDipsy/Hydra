using System.Drawing;
using System.Windows.Forms;
using NeonRat.Forms;

namespace ZEDRatApp.Forms.Controls
{
	internal class TabControlEx : TabControl
	{
		private Color nonactive_color1 = Color.FromArgb(60, 60, 60);

		private Color nonactive_color2 = Color.FromArgb(30, 30, 30);

		private Color active_color1 = Color.FromArgb(80, 80, 80);

		private Color active_color2 = Color.FromArgb(40, 40, 40);

		public Color forecolor = HYDRAUI.m_ForeColor;

		private int color1Transparent = 220;

		private int color2Transparent = 220;

		private int angle = 90;

		public Color ActiveTabStartColor
		{
			get
			{
				return this.active_color1;
			}
			set
			{
				this.active_color1 = value;
				base.Invalidate();
			}
		}

		public Color ActiveTabEndColor
		{
			get
			{
				return this.active_color2;
			}
			set
			{
				this.active_color2 = value;
				base.Invalidate();
			}
		}

		public Color NonActiveTabStartColor
		{
			get
			{
				return this.nonactive_color1;
			}
			set
			{
				this.nonactive_color1 = value;
				base.Invalidate();
			}
		}

		public Color NonActiveTabEndColor
		{
			get
			{
				return this.nonactive_color2;
			}
			set
			{
				this.nonactive_color2 = value;
				base.Invalidate();
			}
		}

		public int Transparent1
		{
			get
			{
				return this.color1Transparent;
			}
			set
			{
				this.color1Transparent = value;
				if (this.color1Transparent > 255)
				{
					this.color1Transparent = 255;
					base.Invalidate();
				}
				else
				{
					base.Invalidate();
				}
			}
		}

		public int Transparent2
		{
			get
			{
				return this.color2Transparent;
			}
			set
			{
				this.color2Transparent = value;
				if (this.color2Transparent > 255)
				{
					this.color2Transparent = 255;
					base.Invalidate();
				}
				else
				{
					base.Invalidate();
				}
			}
		}

		public int GradientAngle
		{
			get
			{
				return this.angle;
			}
			set
			{
				this.angle = value;
				base.Invalidate();
			}
		}

		public Color TextColor
		{
			get
			{
				return this.forecolor;
			}
			set
			{
				this.forecolor = value;
				base.Invalidate();
			}
		}

		public TabControlEx()
		{
			base.DrawMode = TabDrawMode.OwnerDrawFixed;
			base.Padding = new Point(22, 4);
			base.Alignment = TabAlignment.Bottom;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			Rectangle clipRectangle = pe.ClipRectangle;
			SolidBrush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
			pe.Graphics.FillRectangle(brush, clipRectangle);
			base.OnPaint(pe);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			Rectangle tabRect = base.GetTabRect(e.Index);
			e.Graphics.FillRectangle(new SolidBrush(HYDRAUI.m_ThemeColor), tabRect);
			base.TabPages[e.Index].BorderStyle = BorderStyle.None;
			base.TabPages[e.Index].ForeColor = SystemColors.ControlText;
			Rectangle rectangle = new Rectangle(e.Bounds.Left + 15, e.Bounds.Top + 5, e.Bounds.Width, e.Bounds.Height);
			e.Graphics.DrawString(base.TabPages[e.Index].Text, this.Font, new SolidBrush(this.forecolor), rectangle);
			Rectangle tabRect2 = base.GetTabRect(base.TabPages.Count - 1);
			RectangleF rect = new RectangleF(tabRect2.X + tabRect2.Width, tabRect2.Y - 5, base.Width - (tabRect2.X + tabRect2.Width), tabRect2.Height + 7);
			SolidBrush brush = new SolidBrush(HYDRAUI.m_ThemeColor);
			e.Graphics.FillRectangle(brush, rect);
			RectangleF rect2 = new RectangleF(base.Width - 4, 1f, 1f, base.Height - tabRect2.Height - 8);
			RectangleF rect3 = new RectangleF(tabRect2.X + tabRect2.Width, tabRect2.Y - 5, base.Width - (tabRect2.X + tabRect2.Width), 4f);
			Brush brush2 = new SolidBrush(Color.Black);
			e.Graphics.FillRectangle(brush2, rect2);
			e.Graphics.FillRectangle(brush2, rect3);
			e.DrawFocusRectangle();
		}
	}
}

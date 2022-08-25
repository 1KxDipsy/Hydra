using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ToggleButtons
{
	public class ToggleButton : Control
	{
		public delegate void ToggleButtonStateChanged(object sender, ToggleButtonStateEventArgs e);

		public class ToggleButtonStateEventArgs : EventArgs
		{
			public ToggleButtonStateEventArgs(ToggleButtonState ButtonState)
			{
			}
		}

		public enum ToggleButtonState
		{
			ON = 0,
			OFF = 1
		}

		public enum ToggleButtonStyle
		{
			Android = 0,
			Windows = 1,
			IOS = 2,
			Custom = 3,
			Metallic = 4
		}

		private FileInfo f;

		private Rectangle contentRectangle = Rectangle.Empty;

		private Point[] pts2 = new Point[4];

		private Rectangle controlBounds = Rectangle.Empty;

		private Point[] andPoints = new Point[4];

		private Point p1;

		private Point p2;

		private Point p3;

		private Point p4;

		private int tPadx;

		private RectangleF staticInnerRect;

		private bool iosSelected;

		private bool dblclick;

		private Point downpos = Point.Empty;

		private bool isMouseMoved;

		private Point sliderPoint = Point.Empty;

		private int padx;

		private int ipadx = 2;

		private bool switchrec;

		private string activeText = "ON";

		private string inActiveText = "OFF";

		private int slidingAngle = 5;

		private Color activeColor = Color.FromArgb(27, 161, 226);

		private Color sliderColor = Color.Black;

		private Color textColor = Color.White;

		private Color inActiveColor = Color.FromArgb(70, 70, 70);

		private ToggleButtonStyle toggleStyle;

		private ToggleButtonState toggleState = ToggleButtonState.OFF;

		private Rectangle WindowSliderBounds
		{
			get
			{
				_ = Rectangle.Empty;
				if (this.sliderPoint.X > this.controlBounds.Right - 15)
				{
					this.sliderPoint.X = this.controlBounds.Right - 15;
				}
				if (this.sliderPoint.X < this.controlBounds.Left)
				{
					this.sliderPoint.X = this.controlBounds.Left;
				}
				return new Rectangle(this.sliderPoint.X, this.controlBounds.Y, 15, base.Height);
			}
		}

		public string ActiveText
		{
			get
			{
				return this.activeText;
			}
			set
			{
				this.activeText = value;
			}
		}

		public string InActiveText
		{
			get
			{
				return this.inActiveText;
			}
			set
			{
				this.inActiveText = value;
			}
		}

		public int SlidingAngle
		{
			get
			{
				return this.slidingAngle;
			}
			set
			{
				this.slidingAngle = value;
				this.Refresh();
			}
		}

		public Color ActiveColor
		{
			get
			{
				return this.activeColor;
			}
			set
			{
				this.activeColor = value;
				this.Refresh();
			}
		}

		public Color SliderColor
		{
			get
			{
				return this.sliderColor;
			}
			set
			{
				this.sliderColor = value;
				this.Refresh();
			}
		}

		public Color TextColor
		{
			get
			{
				return this.textColor;
			}
			set
			{
				this.textColor = value;
				this.Refresh();
			}
		}

		public Color InActiveColor
		{
			get
			{
				return this.inActiveColor;
			}
			set
			{
				this.inActiveColor = value;
				this.Refresh();
			}
		}

		public ToggleButtonStyle ToggleStyle
		{
			get
			{
				return this.toggleStyle;
			}
			set
			{
				this.toggleStyle = value;
				switch (value)
				{
				case ToggleButtonStyle.Android:
					base.Region = new Region(new Rectangle(0, 0, base.Width, base.Height));
					this.BackColor = Color.FromArgb(32, 32, 32);
					this.InActiveColor = Color.FromArgb(70, 70, 70);
					this.SlidingAngle = 8;
					break;
				case ToggleButtonStyle.IOS:
					this.InActiveColor = Color.WhiteSmoke;
					break;
				}
				base.Invalidate(invalidateChildren: true);
				base.Update();
				this.Refresh();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public ToggleButtonState ToggleState
		{
			get
			{
				return this.toggleState;
			}
			set
			{
				if (this.toggleState != value)
				{
					this.RaiseButtonStateChanged();
					this.toggleState = value;
					base.Invalidate();
					this.Refresh();
				}
			}
		}

		public event ToggleButtonStateChanged ButtonStateChanged;

		public ToggleButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.f = ToggleButton.FindApplicationFile("screw.png");
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			this.controlBounds = e.ClipRectangle;
			e.Graphics.ResetClip();
			switch (this.ToggleStyle)
			{
			case ToggleButtonStyle.Android:
				this.MinimumSize = new Size(75, 23);
				this.MaximumSize = new Size(119, 32);
				this.contentRectangle = e.ClipRectangle;
				this.BackColor = Color.FromArgb(32, 32, 32);
				this.DrawAndroidStyle(e);
				break;
			case ToggleButtonStyle.Windows:
				this.MinimumSize = new Size(65, 23);
				this.MaximumSize = new Size(119, 32);
				this.contentRectangle = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, base.Width - 1, base.Height - 1);
				this.DrawWindowsStyle(e);
				break;
			case ToggleButtonStyle.IOS:
				this.MinimumSize = new Size(93, 30);
				this.MaximumSize = new Size(135, 51);
				this.contentRectangle = new Rectangle(0, 0, base.Width, base.Height);
				this.DrawIOSStyle(e);
				break;
			}
			base.OnPaint(e);
		}

		private Point[] AndroidPoints()
		{
			this.p1 = new Point(this.padx, this.contentRectangle.Y);
			if (this.padx == 0)
			{
				this.p2 = new Point(this.padx, this.contentRectangle.Bottom);
			}
			else
			{
				this.p2 = new Point(this.padx - this.SlidingAngle, this.contentRectangle.Bottom);
			}
			this.p4 = new Point(this.p1.X + this.contentRectangle.Width / 2, this.contentRectangle.Y);
			this.p3 = new Point(this.p4.X - this.SlidingAngle, this.contentRectangle.Bottom);
			if (this.p4.X == this.contentRectangle.Right)
			{
				this.p3 = new Point(this.p4.X, this.contentRectangle.Bottom);
			}
			this.andPoints[0] = this.p1;
			this.andPoints[1] = this.p2;
			this.andPoints[2] = this.p3;
			this.andPoints[3] = this.p4;
			return this.andPoints;
		}

		private void DrawAndroidStyle(PaintEventArgs e)
		{
			e.Graphics.ResetClip();
			Font font = new Font("Century Gothic", 7f);
			this.contentRectangle = e.ClipRectangle;
			if (!this.isMouseMoved)
			{
				if (this.ToggleState == ToggleButtonState.ON)
				{
					this.padx = this.contentRectangle.Right - this.contentRectangle.Width / 2;
				}
				else
				{
					this.padx = 0;
				}
			}
			using (SolidBrush brush = new SolidBrush(this.BackColor))
			{
				e.Graphics.FillRectangle(brush, e.ClipRectangle);
			}
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			using (SolidBrush brush2 = new SolidBrush((this.padx != 0) ? this.ActiveColor : this.InActiveColor))
			{
				e.Graphics.FillPolygon(brush2, this.AndroidPoints());
			}
			if (this.padx == 0)
			{
				e.Graphics.DrawString(this.InActiveText, font, Brushes.White, new PointF(this.padx + this.contentRectangle.Width / 2 / 6, this.contentRectangle.Y + this.contentRectangle.Height / 4));
			}
			else
			{
				e.Graphics.DrawString(this.ActiveText, font, Brushes.White, new PointF(this.padx + this.contentRectangle.Width / 2 / 4, this.contentRectangle.Y + this.contentRectangle.Height / 4));
			}
		}

		private void DrawWindowsStyle(PaintEventArgs e)
		{
			this.contentRectangle = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, base.Width - 1, base.Height - 1);
			if (!this.isMouseMoved)
			{
				if (this.ToggleState == ToggleButtonState.ON)
				{
					this.sliderPoint = new Point(this.controlBounds.Right - 15, this.sliderPoint.Y);
				}
				else
				{
					this.sliderPoint = new Point(this.controlBounds.Left, this.sliderPoint.Y);
				}
			}
			Pen pen = new Pen(Color.FromArgb(159, 159, 159));
			pen.Width = 1.9f;
			e.Graphics.DrawRectangle(pen, this.contentRectangle);
			e.Graphics.DrawRectangle(pen, Rectangle.Inflate(this.contentRectangle, -3, -3));
			Rectangle rect = new Rectangle(Rectangle.Inflate(this.contentRectangle, -3, -3).Left, Rectangle.Inflate(this.contentRectangle, -3, -3).Y, this.WindowSliderBounds.Left - Rectangle.Inflate(this.contentRectangle, -3, -3).Left, Rectangle.Inflate(this.contentRectangle, -3, -3).Height);
			Rectangle rect2 = new Rectangle(this.WindowSliderBounds.Right, rect.Y, Rectangle.Inflate(this.contentRectangle, -3, -3).Right - this.WindowSliderBounds.Right, rect.Height);
			using (SolidBrush brush = new SolidBrush(this.ActiveColor))
			{
				e.Graphics.FillRectangle(brush, rect);
			}
			using (SolidBrush brush2 = new SolidBrush(this.SliderColor))
			{
				e.Graphics.FillRectangle(brush2, this.WindowSliderBounds);
			}
			using (SolidBrush brush3 = new SolidBrush(this.InActiveColor))
			{
				e.Graphics.FillRectangle(brush3, rect2);
			}
			this.BackColor = Color.White;
		}

		private void DrawIOSStyle(PaintEventArgs e)
		{
			this.BackColor = Color.Transparent;
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			Rectangle rectangle = (this.contentRectangle = new Rectangle(0, 0, base.Width, base.Height));
			if (!this.isMouseMoved)
			{
				if (this.ToggleState == ToggleButtonState.ON)
				{
					this.ipadx = this.contentRectangle.Right - (this.contentRectangle.Height - 3);
				}
				else
				{
					this.ipadx = 2;
				}
			}
			Rectangle rect = new Rectangle(this.ipadx, rectangle.Y, rectangle.Height - 5, rectangle.Height);
			Rectangle rectangle2 = new Rectangle(base.Width / 6 - 10, base.Height / 2, base.Width / 6 - 10 + (rect.X + rect.Width / 2), base.Height / 2);
			GraphicsPath graphicsPath = new GraphicsPath();
			int num = base.Height;
			graphicsPath.AddArc(rectangle.X, rectangle.Y, num, num, 180f, 90f);
			graphicsPath.AddArc(rectangle.X + rectangle.Width - num, rectangle.Y, num, num, 270f, 90f);
			graphicsPath.AddArc(rectangle.X + rectangle.Width - num, rectangle.Y + rectangle.Height - num, num, num, 0f, 90f);
			graphicsPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - num, num, num, 90f, 90f);
			base.Region = new Region(graphicsPath);
			GraphicsPath graphicsPath2 = new GraphicsPath();
			num = base.Height / 2;
			graphicsPath2.AddArc(rectangle2.X, rectangle2.Y, num, num, 180f, 90f);
			graphicsPath2.AddArc(rectangle2.X + rectangle2.Width - num, rectangle2.Y, num, num, 270f, 90f);
			graphicsPath2.AddArc(rectangle2.X + rectangle2.Width - num, rectangle2.Y + rectangle2.Height - num, num, num, 0f, 90f);
			graphicsPath2.AddArc(rectangle2.X, rectangle2.Y + rectangle2.Height - num, num, num, 90f, 90f);
			if (this.ipadx < this.contentRectangle.Width / 2)
			{
				this.iosSelected = false;
			}
			else if (this.ipadx == this.contentRectangle.Right - (this.contentRectangle.Height - 3) || this.ipadx > this.contentRectangle.Width / 2)
			{
				this.iosSelected = true;
			}
			Rectangle rect2 = new Rectangle(rectangle.X, rectangle.Y, rectangle.X + rect.Right, rectangle.Height);
			Rectangle rect3 = new Rectangle(rect.X + rect.Width / 2, rectangle.Y, rect.X + rect.Width / 2 + rectangle.Right, rectangle.Height);
			LinearGradientBrush brush = new LinearGradientBrush(rect2, this.InActiveColor, this.ActiveColor, LinearGradientMode.Vertical);
			LinearGradientBrush brush2 = new LinearGradientBrush(rect2, this.ActiveColor, this.ActiveColor, LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(brush2, rect2);
			e.Graphics.FillPath(brush, graphicsPath2);
			rectangle2 = new Rectangle(rect.X + rect.Width / 2, base.Height / 2, base.Width / 2 + base.Width / 4 - (rect.X + rect.Width / 2) + base.Height / 2, base.Height / 2);
			graphicsPath2 = new GraphicsPath();
			num = base.Height / 2;
			graphicsPath2.AddArc(rectangle2.X, rectangle2.Y, num, num, 180f, 90f);
			graphicsPath2.AddArc(rectangle2.X + rectangle2.Width - num, rectangle2.Y, num, num, 270f, 90f);
			graphicsPath2.AddArc(rectangle2.X + rectangle2.Width - num, rectangle2.Y + rectangle2.Height - num, num, num, 0f, 90f);
			graphicsPath2.AddArc(rectangle2.X, rectangle2.Y + rectangle2.Height - num, num, num, 90f, 90f);
			brush = new LinearGradientBrush(rect3, Color.FromArgb(238, 238, 238), Color.LightGray, LinearGradientMode.Vertical);
			LinearGradientBrush brush3 = new LinearGradientBrush(rect3, Color.FromArgb(238, 238, 238), Color.Silver, LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(brush3, rect3);
			e.Graphics.FillPath(brush, graphicsPath2);
			if (this.iosSelected)
			{
				e.Graphics.DrawString(this.ActiveText, this.Font, Brushes.White, new PointF(rectangle.Width / 4, this.contentRectangle.Y + this.contentRectangle.Height / 4));
			}
			else
			{
				e.Graphics.DrawString(this.InActiveText, this.Font, new SolidBrush(Color.FromArgb(123, 123, 123)), new PointF(rectangle.Width / 2, this.contentRectangle.Y + this.contentRectangle.Height / 4));
			}
			Color color = ((base.Parent != null) ? base.Parent.BackColor : Color.White);
			e.Graphics.DrawEllipse(new Pen(Color.LightGray, 2f), rect);
			LinearGradientBrush brush4 = new LinearGradientBrush(rect, Color.White, Color.Silver, LinearGradientMode.Vertical);
			e.Graphics.FillEllipse(brush4, rect);
			e.Graphics.DrawPath(new Pen(color, 2f), graphicsPath);
			e.Graphics.ResetClip();
		}

		protected virtual void FillShape(Graphics g, object brush, GraphicsPath path)
		{
			if (brush.GetType().ToString() == "System.Drawing.Drawing2D.LinearGradientBrush")
			{
				g.FillPath((LinearGradientBrush)brush, path);
			}
			else if (brush.GetType().ToString() == "System.Drawing.Drawing2D.PathGradientBrush")
			{
				g.FillPath((PathGradientBrush)brush, path);
			}
		}

		protected void RaiseButtonStateChanged()
		{
			if (this.ButtonStateChanged != null)
			{
				this.ButtonStateChanged(this, new ToggleButtonStateEventArgs(this.ToggleState));
			}
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this.sliderPoint = this.downpos;
			this.dblclick = !this.dblclick;
			this.switchrec = !this.switchrec;
			if (this.ToggleStyle == ToggleButtonStyle.Windows)
			{
				if (this.WindowSliderBounds.X < this.controlBounds.Width / 2)
				{
					this.sliderPoint = new Point(this.controlBounds.Left, this.sliderPoint.Y);
					this.ToggleState = ToggleButtonState.OFF;
				}
				else
				{
					this.sliderPoint = new Point(this.controlBounds.Right - 15, this.sliderPoint.Y);
					this.ToggleState = ToggleButtonState.ON;
				}
			}
			else if (this.ToggleStyle == ToggleButtonStyle.Android)
			{
				if (this.downpos.X <= this.contentRectangle.Width / 4)
				{
					this.padx = this.contentRectangle.Left;
					this.ToggleState = ToggleButtonState.OFF;
				}
				else
				{
					this.padx = this.contentRectangle.Right - this.contentRectangle.Width / 2;
					this.ToggleState = ToggleButtonState.ON;
				}
			}
			else if (this.ToggleStyle == ToggleButtonStyle.IOS || this.ToggleStyle == ToggleButtonStyle.Metallic)
			{
				if (this.downpos.X <= this.contentRectangle.Width / 4)
				{
					this.ipadx = 2;
					this.ToggleState = ToggleButtonState.OFF;
				}
				else
				{
					this.ipadx = (this.ipadx = this.contentRectangle.Right - (this.contentRectangle.Height - 3));
					this.ToggleState = ToggleButtonState.ON;
				}
			}
			else if (this.ToggleStyle == ToggleButtonStyle.Custom)
			{
				this.tPadx = this.downpos.X;
				if ((float)this.tPadx <= this.staticInnerRect.X + this.staticInnerRect.Width / 2f)
				{
					this.tPadx = (int)this.staticInnerRect.X;
					this.ToggleState = ToggleButtonState.OFF;
				}
				else if ((float)this.tPadx >= this.staticInnerRect.X + this.staticInnerRect.Width / 2f)
				{
					this.tPadx = (int)this.staticInnerRect.Right - 20;
					this.ToggleState = ToggleButtonState.ON;
				}
			}
			this.Refresh();
		}

		private Rectangle GetRectangle()
		{
			return new Rectangle(2, 2, base.Width - 5, base.Height - 5);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (!base.DesignMode)
			{
				this.downpos = e.Location;
			}
			base.Invalidate();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Space)
			{
				if (this.ToggleState == ToggleButtonState.ON)
				{
					this.ToggleState = ToggleButtonState.OFF;
				}
				else
				{
					this.ToggleState = ToggleButtonState.ON;
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.Button != MouseButtons.Left || base.DesignMode)
			{
				return;
			}
			this.sliderPoint = e.Location;
			this.isMouseMoved = true;
			if (this.ToggleStyle == ToggleButtonStyle.Android)
			{
				this.padx = e.X;
				if (this.padx <= this.contentRectangle.Left + this.SlidingAngle)
				{
					this.padx = this.contentRectangle.Left;
					this.ToggleState = ToggleButtonState.OFF;
				}
				if (this.padx >= this.contentRectangle.Right - this.contentRectangle.Width / 2)
				{
					this.padx = this.contentRectangle.Right - this.contentRectangle.Width / 2;
					this.ToggleState = ToggleButtonState.ON;
				}
			}
			else if (this.ToggleStyle == ToggleButtonStyle.IOS || this.ToggleStyle == ToggleButtonStyle.Metallic)
			{
				this.ipadx = e.X;
				if (this.ipadx <= 2)
				{
					this.ipadx = 2;
					this.ToggleState = ToggleButtonState.OFF;
				}
				if (this.ipadx >= this.contentRectangle.Right - (this.contentRectangle.Height - 3))
				{
					this.ipadx = this.contentRectangle.Right - (this.contentRectangle.Height - 3);
					this.ToggleState = ToggleButtonState.ON;
				}
			}
			else if (this.ToggleStyle == ToggleButtonStyle.Custom)
			{
				this.tPadx = e.X;
				if ((float)this.tPadx <= this.staticInnerRect.X)
				{
					this.tPadx = (int)this.staticInnerRect.X;
					this.ToggleState = ToggleButtonState.OFF;
				}
				if ((float)this.tPadx >= this.staticInnerRect.Right - 20f)
				{
					this.tPadx = (int)this.staticInnerRect.Right - 20;
					this.ToggleState = ToggleButtonState.ON;
				}
			}
			this.Refresh();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (base.DesignMode)
			{
				return;
			}
			base.Invalidate();
			if (this.isMouseMoved)
			{
				if (this.ToggleStyle == ToggleButtonStyle.Windows)
				{
					this.sliderPoint = e.Location;
					if (this.WindowSliderBounds.X < this.controlBounds.Width / 2)
					{
						this.sliderPoint = new Point(this.controlBounds.Left, this.sliderPoint.Y);
						this.ToggleState = ToggleButtonState.OFF;
					}
					else
					{
						this.sliderPoint = new Point(this.controlBounds.Right - 15, this.sliderPoint.Y);
						this.ToggleState = ToggleButtonState.ON;
					}
				}
				else if (this.ToggleStyle == ToggleButtonStyle.Android)
				{
					this.padx = e.Location.X;
					if (this.padx < this.contentRectangle.Width / 4)
					{
						this.padx = this.contentRectangle.Left;
						this.ToggleState = ToggleButtonState.OFF;
					}
					else
					{
						this.padx = this.contentRectangle.Right - this.contentRectangle.Width / 2;
						this.ToggleState = ToggleButtonState.ON;
					}
				}
				else if (this.ToggleStyle == ToggleButtonStyle.IOS || this.ToggleStyle == ToggleButtonStyle.Metallic)
				{
					this.ipadx = e.Location.X;
					if (this.ipadx < this.contentRectangle.Width / 2)
					{
						this.ipadx = 2;
						this.ToggleState = ToggleButtonState.OFF;
					}
					else
					{
						this.ipadx = this.contentRectangle.Right - (this.contentRectangle.Height - 3);
						this.ToggleState = ToggleButtonState.ON;
					}
				}
				else if (this.ToggleStyle == ToggleButtonStyle.Custom)
				{
					this.tPadx = e.Location.X;
					if ((float)this.tPadx <= this.staticInnerRect.X + this.staticInnerRect.Width / 2f)
					{
						this.tPadx = (int)this.staticInnerRect.X;
						this.ToggleState = ToggleButtonState.OFF;
					}
					else if ((float)this.tPadx >= this.staticInnerRect.X + this.staticInnerRect.Width / 2f)
					{
						this.tPadx = (int)this.staticInnerRect.Right - 20;
						this.ToggleState = ToggleButtonState.ON;
					}
				}
				base.Invalidate();
				base.Update();
			}
			this.isMouseMoved = false;
		}

		private void RefreshToggleState(ToggleButtonState state)
		{
			this.ToggleState = state;
		}

		public static FileInfo FindApplicationFile(string fileName)
		{
			FileInfo fileInfo = new FileInfo(Path.Combine(Application.StartupPath, fileName));
			while (!fileInfo.Exists)
			{
				if (fileInfo.Directory.Parent == null)
				{
					return null;
				}
				fileInfo = new FileInfo(Path.Combine(fileInfo.Directory.Parent.FullName, fileInfo.Name));
			}
			return fileInfo;
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	[Description("Siticone RadioButton Control")]
	[ToolboxBitmap(typeof(RadioButton))]
	[DefaultEvent("CheckedChanged")]
	public class SiticoneMaterialRadioButton : Control
	{
		private SiticoneButton siticoneButton_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		private bool bool_0 = false;

		private DashStyle dashStyle_0 = DashStyle.Dot;

		private int int_0 = 0;

		public Color _hoverButtonColor = Color.DodgerBlue;

		public Color _hoverTextColor = Color.DodgerBlue;

		public Color _ButtonColor = Color.Gray;

		public Color _TextColor = Color.Gray;

		public Color _hoverButtonBorderColor = Color.White;

		private Color color_0 = Color.White;

		private Color color_1 = Color.DodgerBlue;

		private bool bool_1 = false;

		private Color color_2 = Color.White;

		[Description("The control's access property")]
		[Category("Custom ~ Access Condition")]
		[Browsable(true)]
		public bool ReadOnly
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

		[Browsable(true)]
		[Description("The border style")]
		[Category("Custom ~ Style Property")]
		public DashStyle BorderStyle
		{
			get
			{
				return this.dashStyle_0;
			}
			set
			{
				this.dashStyle_0 = value;
				this.siticoneButton_0.BorderStyle = value;
				base.Invalidate();
			}
		}

		[Category("Custom ~ Text Properties")]
		[Browsable(true)]
		[Description("The color's text")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Invalidate();
			}
		}

		[Category("Custom ~ Text Properties")]
		[Description("The left align of the control's text")]
		[Browsable(true)]
		public int TextLeftAlign
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				if (this.int_0 < 0)
				{
					this.int_0 = 0;
				}
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[Category("Custom ~ Text Properties")]
		[Description("The font of the control's text")]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				base.Invalidate();
			}
		}

		[Description("The color that will be applied to the RadioButton when the cursor hovers over the control")]
		[Category("Custom ~ Hovered State")]
		[Browsable(true)]
		public Color HoverFillColor
		{
			get
			{
				return this._hoverButtonColor;
			}
			set
			{
				this._hoverButtonColor = value;
				base.Invalidate();
			}
		}

		[Category("Custom ~ Hovered State")]
		[Description("The color that will be applied to the text when the cursor hovers over the control")]
		[Browsable(true)]
		public Color HoverTextColor
		{
			get
			{
				return this._hoverTextColor;
			}
			set
			{
				this._hoverTextColor = value;
				base.Invalidate();
			}
		}

		[Category("Custom ~ Normal State")]
		[Description("The color that will be applied to the RadioButton when the cursor hovers over the control")]
		[Browsable(true)]
		public Color BorderColor
		{
			get
			{
				return this._ButtonColor;
			}
			set
			{
				this._ButtonColor = value;
				this.siticoneButton_0.BorderColor = value;
				base.Invalidate();
			}
		}

		[Description("The color that will be applied to the text when the cursor leaves the control or is out of focus")]
		[Browsable(true)]
		[Category("Custom ~ Normal State")]
		public Color TextColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
				this.ForeColor = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[Category("Custom ~ Hovered State")]
		[Browsable(true)]
		[Description("The color that will be applied to the Button border when the cursor is over the control or hovered")]
		public Color HoverBorderColor
		{
			get
			{
				return this._hoverButtonBorderColor;
			}
			set
			{
				this._hoverButtonBorderColor = value;
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[Category("Custom ~ Checked State")]
		[Description("The color that will be applied to the Button border when checked")]
		public Color CheckedBorderColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				if (this.Checked)
				{
					this.siticoneButton_0.BorderColor = value;
				}
				else
				{
					this.siticoneButton_0.BorderColor = this.BorderColor;
				}
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[Category("Custom ~ Checked State")]
		[Description("The color that will be applied to the Button when checked")]
		public Color CheckedFillColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				if (this.Checked)
				{
					this.siticoneButton_0.FillColor = value;
				}
				else
				{
					this.siticoneButton_0.FillColor = Color.Transparent;
				}
				base.Invalidate();
			}
		}

		[Category("Custom ~ Check Toggle State")]
		[Description("The checked state of the")]
		[Browsable(true)]
		public bool Checked
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				if (value)
				{
					this.siticoneButton_0.FillColor = this.CheckedFillColor;
					this.siticoneButton_0.BorderColor = this.CheckedBorderColor;
					this.ForeColor = this.CheckedTextColor;
				}
				else
				{
					this.siticoneButton_0.FillColor = Color.Transparent;
					this.siticoneButton_0.BorderColor = this.BorderColor;
					this.ForeColor = this.TextColor;
				}
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[Category("Custom ~ Checked State")]
		[Description("The color that will be applied to the Button text when checked")]
		public Color CheckedTextColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				if (this.Checked)
				{
					this.ForeColor = value;
				}
				else
				{
					this.ForeColor = this.TextColor;
				}
				base.Invalidate();
			}
		}

		[Category("Custom ~ Getter Properties")]
		[Description("The getter property for the control")]
		[Browsable(true)]
		public bool IsSelected
		{
			get
			{
				if (this.Checked)
				{
					return true;
				}
				return false;
			}
		}

		[Category("Custom ~ Getter Properties")]
		[Description("The getter property for the control")]
		[Browsable(true)]
		public bool IsChecked
		{
			get
			{
				if (this.Checked)
				{
					return true;
				}
				return false;
			}
		}

		[Category("Custom ~ Getter Properties")]
		[Browsable(true)]
		[Description("The getter property for the control")]
		public bool IsReadOnly
		{
			get
			{
				if (this.ReadOnly)
				{
					return true;
				}
				return false;
			}
		}

		public event EventHandler CheckedChanged
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

		public SiticoneMaterialRadioButton()
		{
			Class13.smethod_0();
			base.SetStyle(ControlStyles.StandardClick | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.ForeColor = this.TextColor;
			this.BackColor = Color.Transparent;
			base.Size = new Size(180, 20);
			this.Font = new Font("Segoe UI", 8.5f);
			this.siticoneButton_0 = new SiticoneButton
			{
				Size = new Size(18, 18),
				FillColor = Color.Transparent,
				BorderRadius = 8,
				BorderStyle = this.BorderStyle,
				BorderColor = this.BorderColor,
				BorderThickness = 2,
				Text = string.Empty,
				BackColor = Color.Transparent,
				Location = new Point(1, 1)
			};
			base.Controls.Add(this.siticoneButton_0);
			this.siticoneButton_0.MouseEnter += new EventHandler(siticoneButton_0_MouseEnter);
			this.siticoneButton_0.MouseLeave += new EventHandler(siticoneButton_0_MouseLeave);
			this.siticoneButton_0.Click += new EventHandler(siticoneButton_0_Click);
		}

		private void siticoneButton_0_Click(object sender, EventArgs e)
		{
			if (!this.ReadOnly)
			{
				this.method_0();
				this.ForeColor = this.CheckedTextColor;
				this.eventHandler_0?.Invoke(this, e);
			}
		}

		private void siticoneButton_0_MouseLeave(object sender, EventArgs e)
		{
			if (!this.ReadOnly)
			{
				if (this.Checked)
				{
					this.siticoneButton_0.FillColor = this.CheckedFillColor;
					this.siticoneButton_0.BorderColor = this.CheckedBorderColor;
					this.ForeColor = this.CheckedTextColor;
				}
				else
				{
					this.siticoneButton_0.FillColor = Color.Transparent;
					this.siticoneButton_0.BorderColor = this.BorderColor;
					this.ForeColor = this.TextColor;
				}
			}
		}

		private void siticoneButton_0_MouseEnter(object sender, EventArgs e)
		{
			if (!this.ReadOnly && !this.Checked)
			{
				this.siticoneButton_0.FillColor = this.HoverFillColor;
				this.siticoneButton_0.BorderColor = this.HoverBorderColor;
				this.ForeColor = this.HoverTextColor;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.Height = 20;
			base.OnResize(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			if (!this.IsReadOnly)
			{
				if (!this.Checked)
				{
					this.siticoneButton_0.FillColor = this.HoverFillColor;
					this.siticoneButton_0.BorderColor = this.HoverBorderColor;
					this.ForeColor = this.HoverTextColor;
				}
				base.OnMouseEnter(e);
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (!this.IsReadOnly)
			{
				if (this.Checked)
				{
					this.siticoneButton_0.FillColor = this.CheckedFillColor;
					this.siticoneButton_0.BorderColor = this.CheckedBorderColor;
					this.ForeColor = this.CheckedTextColor;
				}
				else
				{
					this.siticoneButton_0.FillColor = Color.Transparent;
					this.siticoneButton_0.BorderColor = this.BorderColor;
					this.ForeColor = this.TextColor;
				}
				base.OnMouseLeave(e);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (!this.IsReadOnly)
			{
				this.ForeColor = this.CheckedTextColor;
				base.OnMouseDown(e);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			if (!this.IsReadOnly)
			{
				this.method_0();
				this.ForeColor = this.CheckedTextColor;
				this.eventHandler_0?.Invoke(this, e);
				base.OnClick(e);
			}
		}

		private void method_0()
		{
			foreach (Control control in base.Parent.Controls)
			{
				if (control.GetType() == typeof(SiticoneMaterialRadioButton))
				{
					((SiticoneMaterialRadioButton)control).Checked = false;
					((SiticoneMaterialRadioButton)control).siticoneButton_0.FillColor = Color.Transparent;
					((SiticoneMaterialRadioButton)control).siticoneButton_0.BorderColor = this.BorderColor;
					((SiticoneMaterialRadioButton)control).ForeColor = this.TextColor;
				}
			}
			this.Checked = true;
			this.siticoneButton_0.FillColor = this.CheckedFillColor;
			this.siticoneButton_0.BorderColor = this.CheckedBorderColor;
			this.siticoneButton_0.ForeColor = this.CheckedTextColor;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			SizeF sizeF = graphics.MeasureString(this.Text, this.Font);
			graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), Convert.ToInt32(22 + this.TextLeftAlign), Convert.ToInt32((float)(base.Height / 2) - sizeF.Height / 2f));
			base.OnPaint(e);
		}
	}
}

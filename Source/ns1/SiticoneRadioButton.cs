using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using ns2;

namespace ns1
{
	[Description("Siticone RadioButton Control")]
	[ToolboxBitmap(typeof(RadioButton))]
	public class SiticoneRadioButton : RadioButton
	{
		private SiticoneCustomRadioButton siticoneCustomRadioButton1;

		private TextRenderingHint textRenderingHint_0 = TextRenderingHint.ClearTypeGridFit;

		[Description("This property allows you to change how text is printed onto the control")]
		[Browsable(true)]
		[DefaultValue(5)]
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

		[Browsable(true)]
		[Description("If true, the control will be animated while interacting with the mouse")]
		[DefaultValue(true)]
		public bool Animated
		{
			get
			{
				return this.siticoneCustomRadioButton1.Animated;
			}
			set
			{
				this.siticoneCustomRadioButton1.Animated = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Description("The properties that will be applied when the control is in a checked state")]
		public CustomRadionButtonState CheckedState
		{
			get
			{
				return this.siticoneCustomRadioButton1.CheckedState;
			}
			set
			{
				this.siticoneCustomRadioButton1.CheckedState = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Description("The properties that will be applied when the control is in an unchecked state")]
		public CustomRadionButtonState UncheckedState
		{
			get
			{
				return this.siticoneCustomRadioButton1.UncheckedState;
			}
			set
			{
				this.siticoneCustomRadioButton1.UncheckedState = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(DashStyle.Solid)]
		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
		public DashStyle BorderStyle
		{
			get
			{
				return this.siticoneCustomRadioButton1.BorderStyle;
			}
			set
			{
				this.siticoneCustomRadioButton1.BorderStyle = value;
			}
		}

		public SiticoneRadioButton()
		{
			this.method_0();
		}

		private void method_0()
		{
			this.siticoneCustomRadioButton1 = new SiticoneCustomRadioButton();
			base.SuspendLayout();
			this.siticoneCustomRadioButton1.Location = new Point(0, 0);
			this.siticoneCustomRadioButton1.Name = "siticoneCustomRadioButton1";
			this.siticoneCustomRadioButton1.ShadowDecoration.Parent = this.siticoneCustomRadioButton1;
			this.siticoneCustomRadioButton1.Size = new Size(15, 15);
			this.siticoneCustomRadioButton1.TabIndex = 0;
			this.siticoneCustomRadioButton1.CheckedChanged += new EventHandler(siticoneCustomRadioButton1_CheckedChanged);
			base.Controls.Add(this.siticoneCustomRadioButton1);
			base.ResumeLayout(performLayout: false);
		}

		protected override void OnCheckedChanged(EventArgs e)
		{
			if (this.siticoneCustomRadioButton1.Checked != base.Checked)
			{
				this.siticoneCustomRadioButton1.Checked = base.Checked;
			}
			base.OnCheckedChanged(e);
		}

		private void siticoneCustomRadioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.siticoneCustomRadioButton1.Checked != base.Checked)
			{
				base.Checked = this.siticoneCustomRadioButton1.Checked;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			if (this.siticoneCustomRadioButton1 != null)
			{
				this.siticoneCustomRadioButton1.Top = base.Height / 2 - this.siticoneCustomRadioButton1.Height / 2;
			}
			base.OnResize(e);
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			pevent.Graphics.TextRenderingHint = this.textRenderingHint_0;
			base.OnPaint(pevent);
		}
	}
}

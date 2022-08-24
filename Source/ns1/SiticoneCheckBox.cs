using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using ns2;

namespace ns1
{
	[ToolboxBitmap(typeof(CheckBox))]
	[Description("Siticone CheckBox Control")]
	public class SiticoneCheckBox : CheckBox
	{
		private SiticoneCustomCheckBox siticoneCustomCheckBox1;

		private TextRenderingHint textRenderingHint_0 = TextRenderingHint.ClearTypeGridFit;

		[Browsable(true)]
		[DefaultValue(5)]
		[Description("This property allows you to change how text is printed onto the control")]
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
		[DefaultValue(true)]
		[Description("If true, the control will be animated while interacting with the mouse")]
		public bool Animated
		{
			get
			{
				return this.siticoneCustomCheckBox1.Animated;
			}
			set
			{
				this.siticoneCustomCheckBox1.Animated = value;
			}
		}

		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
		[Browsable(true)]
		[DefaultValue(DashStyle.Solid)]
		public DashStyle BorderStyle
		{
			get
			{
				return this.siticoneCustomCheckBox1.BorderStyle;
			}
			set
			{
				this.siticoneCustomCheckBox1.BorderStyle = value;
			}
		}

		[Description("The Color of the checkmark")]
		[DefaultValue(typeof(Color), "White")]
		[Browsable(true)]
		public Color CheckMarkColor
		{
			get
			{
				return this.siticoneCustomCheckBox1.CheckMarkColor;
			}
			set
			{
				this.siticoneCustomCheckBox1.CheckMarkColor = value;
			}
		}

		[Description("The properties that will be applied when the control is in an unchecked state")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public CustomCheckBoxState UncheckedState
		{
			get
			{
				return this.siticoneCustomCheckBox1.UncheckedState;
			}
			set
			{
				this.siticoneCustomCheckBox1.UncheckedState = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The properties that will be applied when the control is in a checked state")]
		[Browsable(true)]
		public CustomCheckBoxState CheckedState
		{
			get
			{
				return this.siticoneCustomCheckBox1.CheckedState;
			}
			set
			{
				this.siticoneCustomCheckBox1.CheckedState = value;
			}
		}

		public SiticoneCheckBox()
		{
			this.method_0();
		}

		private void method_0()
		{
			this.siticoneCustomCheckBox1 = new SiticoneCustomCheckBox();
			base.SuspendLayout();
			this.siticoneCustomCheckBox1.Location = new Point(0, 0);
			this.siticoneCustomCheckBox1.Name = "siticoneCustomCheckBox1";
			this.siticoneCustomCheckBox1.ShadowDecoration.Parent = this.siticoneCustomCheckBox1;
			this.siticoneCustomCheckBox1.Size = new Size(15, 15);
			this.siticoneCustomCheckBox1.TabIndex = 0;
			this.siticoneCustomCheckBox1.CheckedChanged += new EventHandler(siticoneCustomCheckBox1_CheckedChanged);
			base.Controls.Add(this.siticoneCustomCheckBox1);
			base.ResumeLayout(performLayout: false);
		}

		protected override void OnCheckedChanged(EventArgs e)
		{
			if (this.siticoneCustomCheckBox1.Checked != base.Checked)
			{
				this.siticoneCustomCheckBox1.Checked = base.Checked;
			}
			base.OnCheckedChanged(e);
		}

		protected override void OnResize(EventArgs e)
		{
			if (this.siticoneCustomCheckBox1 != null)
			{
				this.siticoneCustomCheckBox1.Top = base.Height / 2 - this.siticoneCustomCheckBox1.Height / 2 - 1;
			}
			base.OnResize(e);
		}

		private void siticoneCustomCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.siticoneCustomCheckBox1.Checked != base.Checked)
			{
				base.Checked = this.siticoneCustomCheckBox1.Checked;
			}
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			pevent.Graphics.TextRenderingHint = this.textRenderingHint_0;
			base.OnPaint(pevent);
		}
	}
}

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("A numeric UpDown control")]
	[ToolboxBitmap(typeof(System.Windows.Forms.NumericUpDown))]
	public class SiticoneNumericUpDown : ns2.NumericUpDown
	{
		[Description("The properties that will be applied when the control is in a focused state")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public NumericUpDownState FocusedState
		{
			get
			{
				return base.DefaultFocusedState;
			}
			set
			{
				base.DefaultFocusedState = value;
			}
		}

		[Description("The properties that will be applied when the control is in a disabled state")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public NumericUpDownState DisabledState
		{
			get
			{
				return base.DefaultDisabledState;
			}
			set
			{
				base.DefaultDisabledState = value;
			}
		}

		[DefaultValue(true)]
		[Description("If true, the UpDown button will be visible")]
		[Browsable(true)]
		public bool UpDownButtonBorderVisible
		{
			get
			{
				return base.DefaultUpDownButtonBorderVisible;
			}
			set
			{
				base.DefaultUpDownButtonBorderVisible = value;
			}
		}

		[Browsable(true)]
		[Description("The UpDown button fill color")]
		[DefaultValue(typeof(Color), "94, 148, 255")]
		public Color UpDownButtonFillColor
		{
			get
			{
				return base.DefaultUpDownButtonFillColor;
			}
			set
			{
				base.DefaultUpDownButtonFillColor = value;
			}
		}

		[DefaultValue(typeof(Color), "80, 0, 0, 0")]
		[Browsable(true)]
		[Description("The UpDown button ForeColor")]
		public Color UpDownButtonForeColor
		{
			get
			{
				return base.DefaultUpDownButtonForeColor;
			}
			set
			{
				base.DefaultUpDownButtonForeColor = value;
			}
		}

		[DefaultValue(DashStyle.Solid)]
		[Browsable(true)]
		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
		public new DashStyle BorderStyle
		{
			get
			{
				return base.DefaultBorderStyle;
			}
			set
			{
				base.DefaultBorderStyle = value;
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Shadow property of the control to add and customize a control's shadow")]
		public ShadowDecoration ShadowDecoration
		{
			get
			{
				return base.DefaultShadowDecoration;
			}
			set
			{
				base.DefaultShadowDecoration = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		[Description("The BackColor that will fill the control")]
		public Color FillColor
		{
			get
			{
				return base.DefaultFillColor;
			}
			set
			{
				base.DefaultFillColor = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "213, 218, 223")]
		[Description("The control's border color")]
		public Color BorderColor
		{
			get
			{
				return base.DefaultBorderColor;
			}
			set
			{
				base.DefaultBorderColor = value;
			}
		}

		[Description("The border thickness. The higher the value, the thicker the border")]
		[Browsable(true)]
		[DefaultValue(1)]
		public int BorderThickness
		{
			get
			{
				return base.DefaultBorderThickness;
			}
			set
			{
				base.DefaultBorderThickness = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(0)]
		[Description("The curve angle of the control on all angles")]
		public int BorderRadius
		{
			get
			{
				return base.DefaultBorderRadius;
			}
			set
			{
				base.DefaultBorderRadius = value;
			}
		}

		[Description("If true, the background will allow a transparent color")]
		[DefaultValue(false)]
		[Browsable(true)]
		public bool UseTransparentBackground
		{
			get
			{
				return base.DefaultUseTransparentBackground;
			}
			set
			{
				base.DefaultUseTransparentBackground = value;
			}
		}

		[Browsable(true)]
		[Description("The control's text position")]
		[DefaultValue(typeof(Point), "0, 0")]
		public Point TextOffset
		{
			get
			{
				return base.DefaultTextOffset;
			}
			set
			{
				base.DefaultTextOffset = value;
			}
		}

		public SiticoneNumericUpDown()
		{
			this.DisabledState.Parent = this;
			this.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.DisabledState.UpDownButtonFillColor = Color.FromArgb(177, 177, 177);
			this.DisabledState.UpDownButtonForeColor = Color.FromArgb(203, 203, 203);
			this.FocusedState.Parent = this;
			this.FocusedState.BorderColor = Class0.color_19;
			Class13.smethod_0();
		}
	}
}

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[ToolboxBitmap(typeof(RadioButton))]
	[DebuggerStepThrough]
	[Description("Advanced RadioButton Control")]
	[ToolboxItem(true)]
	public class SiticoneCustomRadioButton : CustomRadioButton
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Font font_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_1;

		[Description("The properties that will be applied when the control is in a checked state")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public CustomRadionButtonState CheckedState
		{
			get
			{
				return base.DefaultCheckedState;
			}
			set
			{
				base.DefaultCheckedState = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The properties that will be applied when the control is in an unchecked state")]
		[Browsable(true)]
		public CustomRadionButtonState UncheckedState
		{
			get
			{
				return base.DefaultUncheckedState;
			}
			set
			{
				base.DefaultUncheckedState = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The control's font")]
		public new Font Font
		{
			[CompilerGenerated]
			get
			{
				return this.font_0;
			}
			[CompilerGenerated]
			set
			{
				this.font_0 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The control's text")]
		[Browsable(false)]
		public new string Text
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		[Browsable(false)]
		[Description("The control's ForeColor")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new string ForeColor
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(false)]
		[Description("The properties that will be applied when the control is checked")]
		public bool Checked
		{
			get
			{
				return base.DefaultChecked;
			}
			set
			{
				base.DefaultChecked = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(true)]
		[Description("If true, the control will be animated while interacting with the mouse")]
		public bool Animated
		{
			get
			{
				return base.DefaultAnimated;
			}
			set
			{
				base.DefaultAnimated = value;
			}
		}

		[DefaultValue(DashStyle.Solid)]
		[Browsable(true)]
		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
		public DashStyle BorderStyle
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
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

		public SiticoneCustomRadioButton()
		{
			base.DefaultCheckedState.Parent = this;
			base.DefaultCheckedState.BorderColor = Class0.color_19;
			base.DefaultCheckedState.BorderThickness = 0;
			base.DefaultCheckedState.FillColor = Class0.color_19;
			base.DefaultCheckedState.InnerColor = Color.White;
			base.DefaultCheckedState.InnerOffset = 0;
			base.DefaultUncheckedState.Parent = this;
			base.DefaultUncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			base.DefaultUncheckedState.BorderThickness = 2;
			base.DefaultUncheckedState.FillColor = Color.Transparent;
			base.DefaultUncheckedState.InnerColor = Color.Transparent;
			base.DefaultUncheckedState.InnerOffset = 0;
			base.Size = new Size(20, 20);
			Class13.smethod_0();
		}
	}
}

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
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("Advanced CheckBox Control")]
	[ToolboxBitmap(typeof(CheckBox))]
	public class SiticoneCustomCheckBox : CustomCheckBox
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Font font_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_1;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The properties that will be applied when the control is in a checked state")]
		[Browsable(true)]
		public CustomCheckBoxState CheckedState
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
		[Browsable(true)]
		[Description("The properties that will be applied when the control is in an unchecked state")]
		public CustomCheckBoxState UncheckedState
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Description("The control's font style")]
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

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The control's text")]
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

		[Description("The control's ForeColor")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		[Description("If true, the control will be animated while interacting with the mouse")]
		[DefaultValue(true)]
		[Browsable(true)]
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

		[Browsable(true)]
		[DefaultValue(DashStyle.Solid)]
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

		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		[Description("The Color of the checkmark")]
		public Color CheckMarkColor
		{
			get
			{
				return base.DefaultCheckMarkColor;
			}
			set
			{
				base.DefaultCheckMarkColor = value;
			}
		}

		[Description("If true, the control will be in a checked state")]
		[DefaultValue(false)]
		[Browsable(true)]
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
		[DefaultValue(CheckState.Unchecked)]
		[Description("This property returns the check state of the control")]
		public CheckState CheckState
		{
			get
			{
				return base.DefaultChecked ? CheckState.Checked : CheckState.Unchecked;
			}
			set
			{
				base.DefaultChecked = value == CheckState.Checked;
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

		[DefaultValue(false)]
		[Description("If true, the background will allow a transparent color")]
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

		public SiticoneCustomCheckBox()
		{
			base.DefaultCheckedState.Parent = this;
			base.DefaultCheckedState.BorderColor = Class0.color_19;
			base.DefaultCheckedState.BorderRadius = 2;
			base.DefaultCheckedState.BorderThickness = 0;
			base.DefaultCheckedState.FillColor = Class0.color_19;
			base.DefaultUncheckedState.Parent = this;
			base.DefaultUncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			base.DefaultUncheckedState.BorderRadius = 2;
			base.DefaultUncheckedState.BorderThickness = 0;
			base.DefaultUncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			base.Size = new Size(20, 20);
			Class13.smethod_0();
		}
	}
}

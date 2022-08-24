using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns0;
using ns2;

namespace ns1
{
	[Description("A ToggleSwitch Control")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	public class SiticoneToggleSwitch : ToggleSwitch
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Font font_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_1;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The properties that will be applied when the control is in a checked state")]
		[Browsable(true)]
		public ToggleSwitchState CheckedState
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

		[Browsable(true)]
		[Description("The properties that will be applied when the control is in an unchecked state")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ToggleSwitchState UncheckedState
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

		[Description("The toggle switch's font style")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
		[Browsable(false)]
		[Description("The toggle switch's text")]
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

		[Description("The toggle switch's ForeColor")]
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
		[Browsable(true)]
		[DefaultValue(true)]
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
		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
		[Browsable(true)]
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

		[Description("Shadow property of the control to add and customize a control's shadow")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
		[DefaultValue(false)]
		[Description("If true, the background will allow a transparent color")]
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
		[Description("The properties that will be applied when the control is checked")]
		[DefaultValue(false)]
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

		public SiticoneToggleSwitch()
		{
			base.DefaultCheckedState.Parent = this;
			base.DefaultCheckedState.BorderColor = Class0.color_19;
			base.DefaultCheckedState.FillColor = Class0.color_19;
			base.DefaultCheckedState.InnerBorderColor = Color.White;
			base.DefaultCheckedState.InnerColor = Color.White;
			base.DefaultUncheckedState.Parent = this;
			base.DefaultUncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			base.DefaultUncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			base.DefaultUncheckedState.InnerBorderColor = Color.White;
			base.DefaultUncheckedState.InnerColor = Color.White;
			base.Size = new Size(35, 20);
		}
	}
}

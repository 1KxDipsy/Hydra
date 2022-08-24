using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;
using ns5;

namespace ns1
{
	[ToolboxBitmap(typeof(System.Windows.Forms.Button))]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("Advanced controlbox control that supports animations")]
	public class SiticoneControlBox : ControlBox
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Font font_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color color_4;

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The properties that will be applied when the cursor is over the control")]
		public ControlBoxState HoveredState
		{
			get
			{
				return base.DefaultHoveredState;
			}
			set
			{
				base.DefaultHoveredState = value;
			}
		}

		[Browsable(false)]
		[Description("The control's font style")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Font Font
		{
			[CompilerGenerated]
			get
			{
				return this.font_1;
			}
			[CompilerGenerated]
			set
			{
				this.font_1 = value;
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

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The control's ForeColor")]
		public new Color ForeColor
		{
			[CompilerGenerated]
			get
			{
				return this.color_4;
			}
			[CompilerGenerated]
			set
			{
				this.color_4 = value;
			}
		}

		[Description("The curve angle of the control on all angles")]
		[Browsable(true)]
		[DefaultValue(0)]
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

		[Browsable(true)]
		[Description("The border color")]
		[DefaultValue(typeof(Color), "Black")]
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

		[Browsable(true)]
		[DefaultValue(0)]
		[Description("The border thickness. The higher the value, the thicker the border")]
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
		[Browsable(true)]
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

		[DefaultValue(typeof(Color), "")]
		[Description("The BackColor that will fill the control")]
		[Browsable(true)]
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

		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[Description("The control's icon color")]
		public Color IconColor
		{
			get
			{
				return base.DefaultIconColor;
			}
			set
			{
				base.DefaultIconColor = value;
			}
		}

		[Browsable(true)]
		[Description("If true, the control will be animated while interacting with the mouse")]
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

		[Browsable(true)]
		[Description("The size of the control's icon")]
		[DefaultValue(10f)]
		public float CustomIconSize
		{
			get
			{
				return base.DefaultCustomIconSize;
			}
			set
			{
				base.DefaultCustomIconSize = value;
			}
		}

		[DefaultValue(ControlBoxType.CloseBox)]
		[Browsable(true)]
		[Description("The controlbox type: close, maximize or minimize")]
		public ControlBoxType ControlBoxType
		{
			get
			{
				return base.DefaultControlBoxType;
			}
			set
			{
				base.DefaultControlBoxType = value;
			}
		}

		[Browsable(true)]
		[Description("The controlbox style: Windows or custom")]
		[DefaultValue(ControlBoxStyle.Windows10)]
		public ControlBoxStyle ControlBoxStyle
		{
			get
			{
				return base.DefaultControlBoxStyle;
			}
			set
			{
				base.DefaultControlBoxStyle = value;
			}
		}

		[DefaultValue(typeof(Color), "Black")]
		[Description("The color of the control when pressed down by the mouse")]
		[Browsable(true)]
		public Color PressedColor
		{
			get
			{
				return base.DefaultPressedColor;
			}
			set
			{
				base.DefaultPressedColor = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(30)]
		[Description("The visual effect of the pressing event. This property helps animate the pressing event")]
		public int PressedDepth
		{
			get
			{
				return base.DefaultPressedDepth;
			}
			set
			{
				base.DefaultPressedDepth = value;
			}
		}

		public SiticoneControlBox()
		{
			Class13.smethod_0();
		}
	}
}

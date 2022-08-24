using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using ns0;
using ns2;
using ns5;

namespace ns1
{
	[Description("An advanced button control that supports a gradient background")]
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(System.Windows.Forms.Button))]
	[ToolboxItem(true)]
	public class SiticoneGradientButton : GradientButton
	{
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The properties that will be applied when the cursor is over the control")]
		public GradientButtonState HoveredState
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

		[Browsable(true)]
		[Description("The properties that will be applied when the control is in a checked state")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public GradientButtonState CheckedState
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
		[Description("Custom images of the control")]
		public ButtonImages CustomImages
		{
			get
			{
				return base.DefaultCustomImages;
			}
			set
			{
				base.DefaultCustomImages = value;
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

		[DefaultValue(typeof(Color), "94, 148, 255")]
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
		[Description("The border BackColor")]
		[Browsable(true)]
		public Color CustomBorderColor
		{
			get
			{
				return base.DefaultCustomBorderColor;
			}
			set
			{
				base.DefaultCustomBorderColor = value;
			}
		}

		[DefaultValue(typeof(Padding), "0, 0, 0, 0")]
		[Browsable(true)]
		[Description("The thickness of the border. The higher the value, the thicker the border")]
		public Padding CustomBorderThickness
		{
			get
			{
				return base.DefaultCustomBorderThickness;
			}
			set
			{
				base.DefaultCustomBorderThickness = value;
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

		[Description("The visual effect of the pressing event. This property helps animate the pressing event")]
		[DefaultValue(30)]
		[Browsable(true)]
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

		[DefaultValue(0)]
		[Description("The type of Button. The control can act as a toggle button, radio button or a general button")]
		public ButtonMode ButtonMode
		{
			get
			{
				return base.DefaultButtonMode;
			}
			set
			{
				base.DefaultButtonMode = value;
			}
		}

		[Description("The curve angle of the control on all angles")]
		[DefaultValue(0)]
		[Browsable(true)]
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

		[Description("The border color")]
		[DefaultValue(typeof(Color), "Black")]
		[Browsable(true)]
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
		[DefaultValue(0)]
		[Browsable(true)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Shadow property of the control to add and customize a control's shadow")]
		[Browsable(true)]
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

		[Description("The control's image")]
		[DefaultValue(typeof(Image), "")]
		[Browsable(true)]
		public Image Image
		{
			get
			{
				return base.DefaultImage;
			}
			set
			{
				base.DefaultImage = value;
			}
		}

		[DefaultValue(typeof(Size), "20, 20")]
		[Browsable(true)]
		[Description("The size of the control's image")]
		public Size ImageSize
		{
			get
			{
				return base.DefaultImageSize;
			}
			set
			{
				base.DefaultImageSize = value;
			}
		}

		[DefaultValue(typeof(Point), "0, 0")]
		[Browsable(true)]
		[Description("Setting the position of the control's image")]
		public Point ImageOffset
		{
			get
			{
				return base.DefaultImageOffset;
			}
			set
			{
				base.DefaultImageOffset = value;
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

		[Browsable(true)]
		[DefaultValue(2)]
		[Description("The control's horizontal text alignment")]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return base.DefaultTextAlign;
			}
			set
			{
				base.DefaultTextAlign = value;
			}
		}

		[Description("The control's image alignment")]
		[Browsable(true)]
		[DefaultValue(2)]
		public HorizontalAlignment ImageAlign
		{
			get
			{
				return base.DefaultImageAlign;
			}
			set
			{
				base.DefaultImageAlign = value;
			}
		}

		[DefaultValue(5)]
		[Browsable(true)]
		[Description("This property allows you to change how text is printed onto the control")]
		public TextRenderingHint TextRenderingHint
		{
			get
			{
				return base.DefaultTextRenderingHint;
			}
			set
			{
				base.DefaultTextRenderingHint = value;
			}
		}

		[DefaultValue(0)]
		[Browsable(true)]
		[Description("The control's text transform property which allows you to change the appearance of the text")]
		public TextTransform TextTransform
		{
			get
			{
				return base.DefaultTextTransform;
			}
			set
			{
				base.DefaultTextTransform = value;
			}
		}

		[DefaultValue(typeof(Color), "255, 77, 165")]
		[Browsable(true)]
		[Description("The second fill BackColor in a gradient mode")]
		public Color FillColor2
		{
			get
			{
				return base.DefaultFillColor2;
			}
			set
			{
				base.DefaultFillColor2 = value;
			}
		}

		[Description("The gradient mode")]
		[DefaultValue(0)]
		[Browsable(false)]
		public LinearGradientMode GradientMode
		{
			get
			{
				return base.DefaultGradientMode;
			}
			set
			{
				base.DefaultGradientMode = value;
			}
		}

		public SiticoneGradientButton()
		{
			Class13.smethod_0();
		}
	}
}

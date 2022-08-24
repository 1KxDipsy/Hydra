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
	[Description("An advanced circle button")]
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(System.Windows.Forms.Button))]
	[ToolboxItem(true)]
	public class SiticoneGradientCircleButton : GradientCircleButton
	{
		[Description("If true, tiles will be applied")]
		[DefaultValue(true)]
		[Browsable(true)]
		public bool Tile
		{
			get
			{
				return base.DefaultTile;
			}
			set
			{
				base.DefaultTile = value;
			}
		}

		[Description("The properties that will be applied when the cursor is over the control")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		[Description("The properties that will be applied when the control is in a checked state")]
		[Browsable(true)]
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

		[Description("Custom images of the control")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		[Description("The properties that will be applied when the control is checked")]
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

		[DefaultValue(typeof(Color), "94, 148, 255")]
		[Browsable(true)]
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
		[DefaultValue(typeof(Color), "")]
		[Description("The border BackColor")]
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

		[DefaultValue(30)]
		[Description("The visual effect of the pressing event. This property helps animate the pressing event")]
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

		[Description("The type of Button. The control can act as a toggle button, radio button or a general button")]
		[DefaultValue(0)]
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

		[DefaultValue(0)]
		[Description("The curve angle of the control on all angles")]
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

		[DefaultValue(typeof(Color), "Black")]
		[Browsable(true)]
		[Description("The border color")]
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

		[Description("Shadow property of the control to add and customize a control's shadow")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		[Browsable(true)]
		[Description("The control's image")]
		[DefaultValue(typeof(Image), "")]
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
		[Description("The size of the control's image")]
		[Browsable(true)]
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

		[Browsable(true)]
		[Description("Setting the position of the control's image")]
		[DefaultValue(typeof(Point), "0, 0")]
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
		[DefaultValue(typeof(Point), "0, 0")]
		[Description("The control's text position")]
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

		[DefaultValue(2)]
		[Browsable(true)]
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

		[DefaultValue(2)]
		[Browsable(true)]
		[Description("The control's image alignment")]
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

		[Browsable(true)]
		[Description("This property allows you to change how text is printed onto the control")]
		[DefaultValue(5)]
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

		[Description("The control's text transform property which allows you to change the appearance of the text")]
		[Browsable(true)]
		[DefaultValue(0)]
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
		[Description("The control's second fill BacColor in a gradient mode")]
		[Browsable(true)]
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

		[DefaultValue(0)]
		[Description("The control's gradient mode")]
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

		public SiticoneGradientCircleButton()
		{
			Class13.smethod_0();
		}
	}
}

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
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(System.Windows.Forms.Button))]
	[Description("Advanced circle button control with animation effects features")]
	[ToolboxItem(true)]
	public class SiticoneCircleButton : CircleButton
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Description("The properties that will be applied when the cursor is over the control")]
		public ns2.ButtonState HoveredState
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Description("The properties that will be applied when the control is in a checked state")]
		public ns2.ButtonState CheckedState
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

		[Browsable(true)]
		[DefaultValue(true)]
		[Description("If true, tiles will be applied")]
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

		[Browsable(true)]
		[Description("If true, the background will allow a transparent color")]
		[DefaultValue(false)]
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

		[DefaultValue(true)]
		[Browsable(true)]
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

		[Description("The BackColor that will fill the control")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "94, 148, 255")]
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

		[Description("The border BackColor")]
		[DefaultValue(typeof(Color), "")]
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

		[Description("The color of the control when pressed down by the mouse")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Black")]
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

		[Browsable(true)]
		[Description("The border thickness. The higher the value, the thicker the border")]
		[DefaultValue(0)]
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

		[Browsable(true)]
		[DefaultValue(typeof(Image), "")]
		[Description("The control's image")]
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

		[Description("The size of the control's image")]
		[Browsable(true)]
		[DefaultValue(typeof(Size), "20, 20")]
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

		[Description("Setting the position of the control's image")]
		[DefaultValue(typeof(Point), "0, 0")]
		[Browsable(true)]
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

		[DefaultValue(typeof(Point), "0, 0")]
		[Browsable(true)]
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

		[Description("The control's text alignment")]
		[DefaultValue(2)]
		[Browsable(true)]
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
		[Description("The control's horizontal text alignment")]
		[Browsable(true)]
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
		[Description("The control's image alignment")]
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

		[Description("This property allows you to change how text is printed onto the control")]
		[DefaultValue(0)]
		[Browsable(true)]
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

		public SiticoneCircleButton()
		{
			Class13.smethod_0();
		}
	}
}

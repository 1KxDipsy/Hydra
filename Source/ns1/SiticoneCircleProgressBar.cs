using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;
using ns5;

namespace ns1
{
	[Description("Advanced progress bar control")]
	[ToolboxBitmap(typeof(System.Windows.Forms.ProgressBar))]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	public class SiticoneCircleProgressBar : CircleProgressBar
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		[DefaultValue(false)]
		[Description("If true, the control will be animated while interacting with the mouse")]
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
		[Description("The speed of the control's animation")]
		[DefaultValue(0.6f)]
		public float AnimationSpeed
		{
			get
			{
				return base.DefaultAnimationSpeed;
			}
			set
			{
				base.DefaultAnimationSpeed = value;
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

		[DefaultValue(5)]
		[Description("This property allows you to change how text is printed onto the control")]
		[Browsable(true)]
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

		[DefaultValue(typeof(Image), "")]
		[Browsable(true)]
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

		[Browsable(true)]
		[Description("The size of the control's image")]
		[DefaultValue(typeof(Size), "42, 42")]
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
		[DefaultValue(false)]
		[Description("If true, the control's percentile value will be shown")]
		public bool ShowPercentage
		{
			get
			{
				return base.DefaultShowPercentage;
			}
			set
			{
				base.DefaultShowPercentage = value;
			}
		}

		[DefaultValue(0)]
		[Description("Setting the position on the control that will be filled")]
		[Browsable(true)]
		public int FillOffset
		{
			get
			{
				return base.DefaultFillOffset;
			}
			set
			{
				base.DefaultFillOffset = value;
			}
		}

		[DefaultValue(false)]
		[Browsable(true)]
		public bool EnsureVisible
		{
			get
			{
				return base.DefaultEnsureVisible;
			}
			set
			{
				base.DefaultEnsureVisible = value;
			}
		}

		[Browsable(true)]
		[Description("If true, the control will progress in a backward direction")]
		[DefaultValue(false)]
		public bool Backwards
		{
			get
			{
				return base.DefaultBackwards;
			}
			set
			{
				base.DefaultBackwards = value;
			}
		}

		[Browsable(true)]
		[Description("The thickness of the control's progress")]
		[DefaultValue(23)]
		public int FillThickness
		{
			get
			{
				return base.DefaultFillThickness;
			}
			set
			{
				base.DefaultFillThickness = value;
			}
		}

		[Browsable(true)]
		[Description("The position of the control's progress")]
		[DefaultValue(0)]
		public int ProgressOffset
		{
			get
			{
				return base.DefaultProgressOffset;
			}
			set
			{
				base.DefaultProgressOffset = value;
			}
		}

		[Description("The thickness of the control's progress")]
		[DefaultValue(23)]
		[Browsable(true)]
		public int ProgressThickness
		{
			get
			{
				return base.DefaultProgressThickness;
			}
			set
			{
				base.DefaultProgressThickness = value;
			}
		}

		[Description("The progress BackColor")]
		[DefaultValue(typeof(Color), "139, 201, 77")]
		[Browsable(true)]
		public Color ProgressColor
		{
			get
			{
				return base.DefaultProgressColor;
			}
			set
			{
				base.DefaultProgressColor = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "139, 201, 77")]
		[Description("The progress second BackColor")]
		public Color ProgressColor2
		{
			get
			{
				return base.DefaultProgressColor2;
			}
			set
			{
				base.DefaultProgressColor2 = value;
			}
		}

		[DefaultValue(BrushMode.Gradient)]
		[Description("The progress brush mode while running")]
		[Browsable(true)]
		public BrushMode ProgressBrushMode
		{
			get
			{
				return base.DefaultProgressBrushMode;
			}
			set
			{
				base.DefaultProgressBrushMode = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(LinearGradientMode.Horizontal)]
		[Description("The progress gradient mode")]
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

		[Description("The BackColor that will fill the control")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "213, 218, 223")]
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
		[Description("The inner BackColor of the control")]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color InnerColor
		{
			get
			{
				return base.DefaultInnerColor;
			}
			set
			{
				base.DefaultInnerColor = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(0)]
		[Description("The design type of progress start")]
		public LineCap ProgressStartCap
		{
			get
			{
				return base.DefaultProgressStartCap;
			}
			set
			{
				base.DefaultProgressStartCap = value;
			}
		}

		[DefaultValue(0)]
		[Browsable(true)]
		[Description("The design type of progress end")]
		public LineCap ProgressEndCap
		{
			get
			{
				return base.DefaultProgressEndCap;
			}
			set
			{
				base.DefaultProgressEndCap = value;
			}
		}

		[DefaultValue(100)]
		[Description("The progress maximum value")]
		public int Maximum
		{
			get
			{
				return base.DefaultMaximum;
			}
			set
			{
				base.DefaultMaximum = value;
			}
		}

		[DefaultValue(0)]
		[Description("The progress minimum value")]
		public int Minimum
		{
			get
			{
				return base.DefaultMinimum;
			}
			set
			{
				base.DefaultMinimum = value;
			}
		}

		[DefaultValue(0)]
		[Description("The progress value")]
		public int Value
		{
			get
			{
				return base.DefaultValue;
			}
			set
			{
				base.DefaultValue = value;
			}
		}

		public SiticoneCircleProgressBar()
		{
			Class13.smethod_0();
		}
	}
}

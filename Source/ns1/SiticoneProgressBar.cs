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
	[ToolboxItem(true)]
	[DebuggerStepThrough]
	[Description("An advanced progress bar control")]
	[ToolboxBitmap(typeof(System.Windows.Forms.ProgressBar))]
	public class SiticoneProgressBar : ns2.ProgressBar
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

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

		[DefaultValue(typeof(Color), "Black")]
		[Browsable(true)]
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

		[DefaultValue(0)]
		[Description("The border thickness. The higher the value, the thicker the border")]
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

		[Description("If control's text")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		[Description("The control's text position")]
		[Browsable(true)]
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

		[Description("The control's horizontal text alignment")]
		[Browsable(true)]
		[DefaultValue(2)]
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

		[DefaultValue(100)]
		[Description("The control's maximum value")]
		[Browsable(true)]
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

		[Browsable(true)]
		[Description("The control's minimum value")]
		[DefaultValue(0)]
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
		[Description("The control's value")]
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

		[DefaultValue(false)]
		[Description("If true, the control will progress in a backward direction")]
		[Browsable(true)]
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

		[Description("The progress bar style")]
		[DefaultValue(ProgressBarStyle.Blocks)]
		[Browsable(true)]
		public ProgressBarStyle Style
		{
			get
			{
				return base.DefaultStyle;
			}
			set
			{
				base.DefaultStyle = value;
			}
		}

		[Description("The progress bar color")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "139, 201, 77")]
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

		[DefaultValue(typeof(Color), "139, 201, 77")]
		[Browsable(true)]
		[Description("The progress bar second color in a gradient mode")]
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
		[Description("The progress bar brush mode")]
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
		[DefaultValue(typeof(Color), "213, 218, 223")]
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

		[Description("The control's gradient mode")]
		[DefaultValue(typeof(LinearGradientMode), "")]
		[Browsable(true)]
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

		public SiticoneProgressBar()
		{
			Class13.smethod_0();
		}
	}
}

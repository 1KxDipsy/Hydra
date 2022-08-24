using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;
using ns5;

namespace ns1
{
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("An advanced ImageButton Control")]
	[ToolboxBitmap(typeof(System.Windows.Forms.Button))]
	public class SiticoneImageButton : ImageButton
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Font font_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color color_2;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Description("The properties that will be applied when the cursor is over the control")]
		public ImageControlState HoveredState
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
		[Description("The properties that will be applied when the control is in a checked state")]
		[Browsable(true)]
		public ImageControlState CheckedState
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
		[Description("The state of the control when pressed")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ImageControlState PressedState
		{
			get
			{
				return base.DefaultPressedState;
			}
			set
			{
				base.DefaultPressedState = value;
			}
		}

		[Description("The control's font style")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor
		{
			[CompilerGenerated]
			get
			{
				return this.color_2;
			}
			[CompilerGenerated]
			set
			{
				this.color_2 = value;
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
		[Browsable(true)]
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

		[DefaultValue(0)]
		[Description("The control's text transform property which allows you to change the appearance of the text")]
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

		[Description("If true, the control will be checked")]
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

		public SiticoneImageButton()
		{
			Class13.smethod_0();
		}
	}
}

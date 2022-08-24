using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[ToolboxBitmap(typeof(CheckBox))]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("An Advanced ImageCheckBox Control")]
	public class SiticoneImageCheckBox : ImageCheckBox
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Font font_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color color_1;

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

		[Description("The properties that will be applied when the control is in a checked state")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		[Description("The properties that will be applied when the control is pressed")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
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

		[Description("The control's text")]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		[Description("The control's ForeColor")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor
		{
			[CompilerGenerated]
			get
			{
				return this.color_1;
			}
			[CompilerGenerated]
			set
			{
				this.color_1 = value;
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

		[Description("If true, the control will be in a checked state")]
		[Browsable(true)]
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
		[DefaultValue(typeof(Point), "0, 0")]
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

		public SiticoneImageCheckBox()
		{
			Class13.smethod_0();
		}
	}
}

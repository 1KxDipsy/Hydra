using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[Description("An advanced resize control")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	public class SiticoneResizeBox : ResizeControl
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Font font_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color color_1;

		[Browsable(false)]
		[Description("The control's font style")]
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

		[Description("The control's text")]
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

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The control's ForeColor")]
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

		[DefaultValue(typeof(Control), "")]
		[Browsable(true)]
		[Description("The target control to resize")]
		public Control TargetControl
		{
			get
			{
				return base.DefaultTargetControl;
			}
			set
			{
				base.DefaultTargetControl = value;
			}
		}

		[Description("If true, the background will allow a transparent color")]
		[Browsable(true)]
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

		[Browsable(true)]
		[DefaultValue(typeof(Color), "Black")]
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

		public SiticoneResizeBox()
		{
			Class13.smethod_0();
		}
	}
}

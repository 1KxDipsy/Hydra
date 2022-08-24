using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns0;
using ns2;

namespace ns1
{
	[DebuggerStepThrough]
	[Description("A Separator Control")]
	[ToolboxItem(true)]
	public class SiticoneSeparator : Separator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Font font_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_1;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Description("The separator's font style")]
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

		[Description("The separator's text")]
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The separator's ForeColor")]
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

		[Description("The BackColor that will fill the control")]
		[DefaultValue(typeof(Color), "193, 200, 207")]
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

		[DefaultValue(1)]
		[Description("The thickness of the separator control")]
		[Browsable(true)]
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
		[DefaultValue(DashStyle.Solid)]
		[Description("The css-style of the separator")]
		public DashStyle FillStyle
		{
			get
			{
				return base.DefaultFillStyle;
			}
			set
			{
				base.DefaultFillStyle = value;
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

		public SiticoneSeparator()
		{
			Class13.smethod_0();
		}
	}
}

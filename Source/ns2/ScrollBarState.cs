using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[Description("ScrollBarState")]
	[DebuggerStepThrough]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ScrollBarState : ExpandableObjectConverter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private HScrollBar hscrollBar_0;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		[Browsable(false)]
		public HScrollBar Parent
		{
			[CompilerGenerated]
			get
			{
				return this.hscrollBar_0;
			}
			[CompilerGenerated]
			set
			{
				this.hscrollBar_0 = value;
			}
		}

		[DefaultValue(typeof(Color), "")]
		[Description("The scroll bar thumb color")]
		[Browsable(true)]
		public Color ThumbColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
		[Description("The scroll bar fill color")]
		public Color FillColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
			}
		}

		[Description("The scroll bar border color")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
		public Color BorderColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
			}
		}

		public override string ToString()
		{
			return string.Empty;
		}
	}
}

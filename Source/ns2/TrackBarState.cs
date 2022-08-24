using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[Description("TrackBarState")]
	[DebuggerStepThrough]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class TrackBarState
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private TrackBar trackBar_0;

		private Color color_0;

		private Color color_1;

		[Browsable(false)]
		public TrackBar Parent
		{
			[CompilerGenerated]
			get
			{
				return this.trackBar_0;
			}
			[CompilerGenerated]
			set
			{
				this.trackBar_0 = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
		[Description("The control's fill color")]
		public Color FillColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.method_0();
			}
		}

		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[Description("The control's thumb color")]
		public Color ThumbColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.method_0();
			}
		}

		private void method_0()
		{
			if (this.Parent != null)
			{
				this.Parent.Invalidate();
			}
		}

		public override string ToString()
		{
			return string.Empty;
		}
	}
}

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[DebuggerStepThrough]
	[Description("ControlBoxState")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ControlBoxState
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ControlBox controlBox_0;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		[Browsable(false)]
		public ControlBox Parent
		{
			[CompilerGenerated]
			get
			{
				return this.controlBox_0;
			}
			[CompilerGenerated]
			set
			{
				this.controlBox_0 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[Description("The fill color")]
		[Browsable(true)]
		[NotifyParentProperty(true)]
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

		[Description("The icon color")]
		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color IconColor
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

		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		[Description("The color of the border")]
		public Color BorderColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.method_0();
			}
		}

		private void method_0()
		{
		}

		public override string ToString()
		{
			return string.Empty;
		}
	}
}

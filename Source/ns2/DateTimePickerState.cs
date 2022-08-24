using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[DebuggerStepThrough]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Description("DateTimePickerState")]
	public class DateTimePickerState
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private DateTimePicker dateTimePicker_0;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		[Browsable(false)]
		public DateTimePicker Parent
		{
			[CompilerGenerated]
			get
			{
				return this.dateTimePicker_0;
			}
			[CompilerGenerated]
			set
			{
				this.dateTimePicker_0 = value;
			}
		}

		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		[Description("The date picker's fill color")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
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

		[Browsable(true)]
		[Description("The date picker's ForeColor")]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Color), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color ForeColor
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

		[Description("The date picker's border color")]
		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
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

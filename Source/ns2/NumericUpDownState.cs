using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Description("NumericUpDownState")]
	[DebuggerStepThrough]
	public class NumericUpDownState
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private NumericUpDown numericUpDown_0;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		private Color color_3;

		private Color color_4;

		[Browsable(false)]
		public NumericUpDown Parent
		{
			[CompilerGenerated]
			get
			{
				return this.numericUpDown_0;
			}
			[CompilerGenerated]
			set
			{
				this.numericUpDown_0 = value;
			}
		}

		[Description("The control's ForeColor")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
		public Color ForeColor
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
		[NotifyParentProperty(true)]
		[Description("The control's UpDown button ForeColor")]
		[DefaultValue(typeof(Color), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color UpDownButtonForeColor
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

		[Description("The control's UpDown button fill color")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		public Color UpDownButtonFillColor
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

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The control's UpDown button fill color")]
		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		public Color FillColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
			}
		}

		[Description("The control's UpDown button border color")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[NotifyParentProperty(true)]
		public Color BorderColor
		{
			get
			{
				return this.color_4;
			}
			set
			{
				this.color_4 = value;
			}
		}

		public override string ToString()
		{
			return string.Empty;
		}

		private void method_0()
		{
			if (this.Parent != null)
			{
				this.Parent.Invalidate();
			}
		}
	}
}

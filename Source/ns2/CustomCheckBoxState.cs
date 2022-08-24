using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[DebuggerStepThrough]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Description("CustomCheckBoxState")]
	public class CustomCheckBoxState
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private CustomCheckBox customCheckBox_0;

		private Color color_0;

		private Color color_1;

		private int int_0;

		private int int_1;

		[Browsable(false)]
		public CustomCheckBox Parent
		{
			[CompilerGenerated]
			get
			{
				return this.customCheckBox_0;
			}
			[CompilerGenerated]
			set
			{
				this.customCheckBox_0 = value;
			}
		}

		[Description("The fill color")]
		[DefaultValue(typeof(Color), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
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

		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[Description("The border color")]
		public Color BorderColor
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

		[Browsable(true)]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Int32), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The curve angle of the control on all angles")]
		public int BorderRadius
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.method_0();
			}
		}

		[Description("The thickness of the border. The higher the value, the thicker the border")]
		[DefaultValue(typeof(Int32), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		public int BorderThickness
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
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

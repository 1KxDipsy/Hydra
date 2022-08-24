using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[DebuggerStepThrough]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Description("CustomRadionButtonState")]
	public class CustomRadionButtonState
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private CustomRadioButton customRadioButton_0;

		private Color color_0;

		private Color color_1;

		private int int_0;

		private Color color_2;

		private int int_1;

		[Browsable(false)]
		public CustomRadioButton Parent
		{
			[CompilerGenerated]
			get
			{
				return this.customRadioButton_0;
			}
			[CompilerGenerated]
			set
			{
				this.customRadioButton_0 = value;
			}
		}

		[NotifyParentProperty(true)]
		[Description("The fill color")]
		[DefaultValue(typeof(Color), "")]
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

		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		[Description("The control's border color")]
		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
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

		[DefaultValue(typeof(Int32), "")]
		[NotifyParentProperty(true)]
		[Description("The thickness of the border. The higher the value, the thicker the border")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		public int BorderThickness
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

		[DefaultValue(typeof(Color), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[Description("The inner color of the control")]
		[NotifyParentProperty(true)]
		public Color InnerColor
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

		[Description("The offset of the control")]
		[DefaultValue(0)]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public int InnerOffset
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

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[DebuggerStepThrough]
	[Description("ToggleSwitchState")]
	public class ToggleSwitchState
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private ToggleSwitch toggleSwitch_0;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		private Color color_3;

		private int int_0 = 9;

		private int int_1;

		private int int_2 = 5;

		private int int_3;

		private int int_4;

		[Browsable(false)]
		public ToggleSwitch Parent
		{
			[CompilerGenerated]
			get
			{
				return this.toggleSwitch_0;
			}
			[CompilerGenerated]
			set
			{
				this.toggleSwitch_0 = value;
			}
		}

		[Description("The toggle switch fill color")]
		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
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

		[Description("The toggle switch border color")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
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

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
		[Description("The toggle switch inner color")]
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

		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[Description("The toggle switch inner border color")]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		public Color InnerBorderColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				this.method_0();
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		[Description("The toggle switch border radius")]
		[DefaultValue(9)]
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

		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(0)]
		[Browsable(true)]
		[NotifyParentProperty(true)]
		[Description("The toggle switch border thickness")]
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

		[Browsable(true)]
		[NotifyParentProperty(true)]
		[Description("The toggle switch innder border radius")]
		[DefaultValue(5)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public int InnerBorderRadius
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.method_0();
			}
		}

		[Description("The toggle switch innder border thickness")]
		[DefaultValue(0)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		public int InnerBorderThickness
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				this.method_0();
			}
		}

		[NotifyParentProperty(true)]
		[Description("The toggle switch inner offset")]
		[DefaultValue(0)]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public int InnerOffset
		{
			get
			{
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
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

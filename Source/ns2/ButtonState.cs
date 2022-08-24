using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[Description("Button State")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[DebuggerStepThrough]
	public class ButtonState
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private CustomButtonBase customButtonBase_0;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		private Color color_3;

		private Image image_0;

		private Font font_0;

		[Browsable(false)]
		public CustomButtonBase Parent
		{
			[CompilerGenerated]
			get
			{
				return this.customButtonBase_0;
			}
			[CompilerGenerated]
			set
			{
				this.customButtonBase_0 = value;
			}
		}

		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[Description("The controls' fill color")]
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

		[NotifyParentProperty(true)]
		[Description("The controls' ForeColor")]
		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
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

		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Color), "")]
		[Description("The controls' border color")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
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

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Color), "")]
		[Description("The controls' custom border color")]
		public Color CustomBorderColor
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

		[Description("The controls' image")]
		[Browsable(true)]
		[DefaultValue(typeof(Image), "")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Image Image
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
				this.method_0();
			}
		}

		[Description("The controls' font style")]
		[DefaultValue(typeof(Font), "")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		public Font Font
		{
			get
			{
				return this.font_0;
			}
			set
			{
				this.font_0 = value;
				this.method_0();
			}
		}

		internal void method_0()
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

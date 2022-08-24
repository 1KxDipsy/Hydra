using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[DebuggerStepThrough]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Description("")]
	public class TextBoxState
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TextBox textBox_0;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		private Color color_3;

		[Browsable(false)]
		public TextBox Parent
		{
			[CompilerGenerated]
			get
			{
				return this.textBox_0;
			}
			[CompilerGenerated]
			set
			{
				this.textBox_0 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The textbox ForeColor")]
		[Browsable(true)]
		[NotifyParentProperty(true)]
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

		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[Description("The textbox Placeholder ForeColor")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color PlaceholderForeColor
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

		[NotifyParentProperty(true)]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
		[Description("The textbox fill color")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color FillColor
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

		[NotifyParentProperty(true)]
		[Description("The textbox border color")]
		[DefaultValue(typeof(Color), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		public Color BorderColor
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

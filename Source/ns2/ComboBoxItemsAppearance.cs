using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[Description("ComboBoxItemsAppearance")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[DebuggerStepThrough]
	public class ComboBoxItemsAppearance
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private ComboBox comboBox_0;

		private Font font_0;

		private Color color_0;

		private Color color_1;

		private Font font_1;

		private Color color_2;

		private Color color_3;

		[Browsable(false)]
		public ComboBox Parent
		{
			[CompilerGenerated]
			get
			{
				return this.comboBox_0;
			}
			[CompilerGenerated]
			set
			{
				this.comboBox_0 = value;
			}
		}

		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DefaultValue(typeof(Font), "")]
		[Description("The font style")]
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

		[Browsable(true)]
		[Description("The ForeColor")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		public Color ForeColor
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
		[Description("The BackColor")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color BackColor
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
		[Description("The font style of a selected item")]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Font), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Font SelectedFont
		{
			get
			{
				return this.font_1;
			}
			set
			{
				this.font_1 = value;
				this.method_0();
			}
		}

		[NotifyParentProperty(true)]
		[Description("The ForeColor of a selected item")]
		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color SelectedForeColor
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

		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[Description("The BackColor of a selected item")]
		public Color SelectedBackColor
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

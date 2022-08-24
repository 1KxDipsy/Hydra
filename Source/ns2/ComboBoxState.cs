using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;

namespace ns2
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[DebuggerStepThrough]
	[Description("ComboBoxState")]
	public class ComboBoxState
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ComboBox comboBox_0;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		private Font font_0;

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

		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[Description("The fill color")]
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

		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Color), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The forecolor")]
		[Browsable(true)]
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

		[DefaultValue(typeof(Color), "")]
		[Description("The color of the border")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
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

		[Browsable(true)]
		[Description("The font style")]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Font), "")]
		[EditorBrowsable(EditorBrowsableState.Always)]
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

		internal void method_1(PaintValueEventArgs paintValueEventArgs_0)
		{
			int num = paintValueEventArgs_0.Bounds.Width / 3;
			paintValueEventArgs_0.Graphics.FillRectangle(new SolidBrush(this.BorderColor), new Rectangle(paintValueEventArgs_0.Bounds.X, paintValueEventArgs_0.Bounds.Y, num, paintValueEventArgs_0.Bounds.Height));
			paintValueEventArgs_0.Graphics.FillRectangle(new SolidBrush(this.FillColor), new Rectangle(paintValueEventArgs_0.Bounds.X + num, paintValueEventArgs_0.Bounds.Y, num, paintValueEventArgs_0.Bounds.Height));
			paintValueEventArgs_0.Graphics.FillRectangle(new SolidBrush(this.ForeColor), new Rectangle(paintValueEventArgs_0.Bounds.X + num + num, paintValueEventArgs_0.Bounds.Y, num, paintValueEventArgs_0.Bounds.Height));
		}
	}
}

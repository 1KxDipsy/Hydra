using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns5;

namespace ns1
{
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("An advanced textbox control")]
	[ToolboxBitmap(typeof(TextBox))]
	public class SiticoneMaterialTextBox : SiticoneTextBox
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DashStyle dashStyle_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_2;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
		public new DashStyle BorderStyle
		{
			[CompilerGenerated]
			get
			{
				return this.dashStyle_1;
			}
			[CompilerGenerated]
			set
			{
				this.dashStyle_1 = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The curve angle of the control on all angles")]
		public new int BorderRadius
		{
			[CompilerGenerated]
			get
			{
				return this.int_2;
			}
			[CompilerGenerated]
			set
			{
				this.int_2 = value;
			}
		}

		public SiticoneMaterialTextBox()
		{
			base.DefaultStyle = TextBoxStyle.Material;
		}
	}
}

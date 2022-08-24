using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(TextBox))]
	[DebuggerStepThrough]
	[Description("A RoundedTextBox Control")]
	public class SiticoneRoundedTextBox : SiticoneTextBox
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.BorderRadius = base.Height / 2 - 1;
		}
	}
}

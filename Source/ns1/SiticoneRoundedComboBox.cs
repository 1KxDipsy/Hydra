using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxBitmap(typeof(ComboBox))]
	[Description("A RoundedComboBox Control")]
	[ToolboxItem(true)]
	[DebuggerStepThrough]
	public class SiticoneRoundedComboBox : SiticoneComboBox
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_3;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int BorderRadius
		{
			[CompilerGenerated]
			get
			{
				return this.int_3;
			}
			[CompilerGenerated]
			set
			{
				this.int_3 = value;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.BorderRadius = base.Height / 2 - 1;
		}
	}
}

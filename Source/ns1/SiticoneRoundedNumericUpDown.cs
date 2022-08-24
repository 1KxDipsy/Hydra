using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns1
{
	[Description("A RoundedNumericUpDown Control")]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ComboBox))]
	[DebuggerStepThrough]
	public class SiticoneRoundedNumericUpDown : SiticoneNumericUpDown
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The curve angle of the control on all angles")]
		[Browsable(false)]
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

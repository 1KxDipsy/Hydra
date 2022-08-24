using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxItem(true)]
	[Description("A RoundedButton Control")]
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(Button))]
	public class SiticoneRoundedButton : SiticoneButton
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_3;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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
			base.DefaultBorderRadius = base.Height / 2 - 1;
		}
	}
}

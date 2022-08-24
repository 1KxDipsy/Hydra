using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxItem(true)]
	[Description("A RoundedGradientButton Control")]
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(Button))]
	public class SiticoneRoundedGradientButton : SiticoneGradientButton
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_4;

		[Description("The curve angle of the control on all angles")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int BorderRadius
		{
			[CompilerGenerated]
			get
			{
				return this.int_4;
			}
			[CompilerGenerated]
			set
			{
				this.int_4 = value;
			}
		}

		public SiticoneRoundedGradientButton()
		{
			base.Size = new Size(230, 45);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.DefaultBorderRadius = base.Height / 2 - 1;
		}
	}
}

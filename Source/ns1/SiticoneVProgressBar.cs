using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxBitmap(typeof(ProgressBar))]
	[ToolboxItem(true)]
	[DebuggerStepThrough]
	[Description("A vertical ProgressBar Control")]
	public class SiticoneVProgressBar : SiticoneProgressBar
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style |= 1;
				return createParams;
			}
		}
	}
}

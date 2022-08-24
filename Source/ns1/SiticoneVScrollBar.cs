using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[Description("A vertical ScrollBar Control")]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(VScrollBar))]
	[DebuggerStepThrough]
	public class SiticoneVScrollBar : SiticoneHScrollBar
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

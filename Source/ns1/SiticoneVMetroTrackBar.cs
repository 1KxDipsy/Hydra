using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxBitmap(typeof(TrackBar))]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("A vertical MetroTrackBar control")]
	public class SiticoneVMetroTrackBar : SiticoneMetroTrackBar
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

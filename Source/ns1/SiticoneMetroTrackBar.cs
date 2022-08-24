using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ns5;

namespace ns1
{
	[ToolboxItem(true)]
	[DebuggerStepThrough]
	[Description("A metro style trackbar control")]
	[ToolboxBitmap(typeof(TrackBar))]
	public class SiticoneMetroTrackBar : SiticoneTrackBar
	{
		public SiticoneMetroTrackBar()
		{
			base.DefaultStyle = TrackBarStyle.Metro;
		}
	}
}

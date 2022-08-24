using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxBitmap(typeof(Button))]
	[DebuggerStepThrough]
	[Description("An advanced TileButton Control")]
	public class SiticoneTileButton : SiticoneButton
	{
		public SiticoneTileButton()
		{
			base.DefaultTile = true;
			base.Size = new Size(180, 180);
		}
	}
}

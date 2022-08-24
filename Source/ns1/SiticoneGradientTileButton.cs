using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxBitmap(typeof(Button))]
	[Description("An advanced tile button control")]
	[DebuggerStepThrough]
	public class SiticoneGradientTileButton : SiticoneGradientButton
	{
		public SiticoneGradientTileButton()
		{
			base.DefaultTile = true;
			base.Size = new Size(180, 180);
		}
	}
}

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ns5;

namespace ns1
{
	[ToolboxBitmap(typeof(ProgressBar))]
	[DebuggerStepThrough]
	[Description("A Windows ProgressIndicator Control")]
	public class SiticoneWinProgressIndicator : SiticoneProgressIndicator
	{
		public SiticoneWinProgressIndicator()
		{
			base.DefaultStyle = ProgressIndicatorStyle.Windows;
		}
	}
}

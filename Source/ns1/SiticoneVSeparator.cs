using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ns1
{
	[Description("A vertical Separator Control")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	public class SiticoneVSeparator : SiticoneSeparator
	{
		public SiticoneVSeparator()
		{
			base.SetOrientation(Orientation.Vertical);
		}
	}
}

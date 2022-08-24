using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[ToolboxBitmap(typeof(Button))]
	[ToolboxItem(true)]
	[Description("A vertical Slider control")]
	[DebuggerStepThrough]
	public class SiticoneVSlider : SiticoneSlider
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

		protected override void OnClientSizeChanged(EventArgs e)
		{
			if (base.Width < 60)
			{
				base.Width = 60;
			}
		}
	}
}

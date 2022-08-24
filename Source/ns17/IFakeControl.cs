using System;
using System.Drawing;
using System.Windows.Forms;

namespace ns17
{
	public interface IFakeControl
	{
		Bitmap BgBmp { get; set; }

		Bitmap Frame { get; set; }

		event EventHandler<TransfromNeededEventArg> TransfromNeeded;

		event EventHandler<PaintEventArgs> FramePainting;

		event EventHandler<PaintEventArgs> FramePainted;

		void InitParent(Control animatedControl, Padding padding);
	}
}

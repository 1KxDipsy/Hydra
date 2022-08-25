using System.Drawing;

namespace NeonRat.Forms
{
	internal class AnimateMsgBox
	{
		public Size FormSize;

		public MsgBox.AnimateStyle Style;

		public AnimateMsgBox(Size formSize, MsgBox.AnimateStyle style)
		{
			this.FormSize = formSize;
			this.Style = style;
		}
	}
}

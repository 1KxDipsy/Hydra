using System.Windows.Forms;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook
{
	public interface IKeyboardEvents
	{
		event KeyEventHandler KeyDown;

		event KeyPressEventHandler KeyPress;

		event KeyEventHandler KeyUp;
	}
}

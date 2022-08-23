using ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation
{
	internal class AppMouseListener : MouseListener
	{
		public AppMouseListener()
			: base(new Subscribe(HookHelper.HookAppMouse))
		{
		}

		protected override MouseEventExtArgs GetEventArgs(CallbackData data)
		{
			return MouseEventExtArgs.FromRawDataApp(data);
		}
	}
}

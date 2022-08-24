using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using ns8;

namespace ns0
{
	internal sealed class Class13
	{
		private const string string_0 = "YHA2yJAghbE2agvrrEDHrB+N6XzMMyrNYEe7ANq9VtvBn007S8E1lGGrb1h1ffRN";

		public static bool Boolean_0
		{
			get
			{
				if (File.Exists(Class16.String_1))
				{
					if ("A25256661969E6A13599597FA00436E3" == Class14.smethod_3(Class16.String_1))
					{
						return true;
					}
					return false;
				}
				return false;
			}
		}

		public static void smethod_0()
		{
		}

		private static void smethod_1()
		{
			LMessageBox.Show("<br><b>Hello " + Environment.MachineName + "!</b><br>It looks like your target platform is set to <i>'Any CPU'</i>, please specify your target platform <b>before</b> you proceed.<br><br>We encourage you to specify to:<br><b>(a)</b> 'x86' if your are targeting 32 and 64 bit systems, <b>OR</b><br><b>(b)</b> 'x64' if your are targeting 64 bit systems ONLY.<br><br><br><br><br><b>How to specify the target platform</b><br><b>(a)</b> Right-Click your <i>Project</i> > <i>Properties</i> > <i>Build</i> > and locate <i>'Target Platform'</i>. Specify to either <b>x86</b> or <b>x64</b>. <br><br><b>OR</b><br> <b>(b)</b> Read the documentation section at <b>docs.microsoft.com</b>", "Specify Your Target Platform", "Read Microsoft's Documentation Section", "What Does Visual Studio IDE 'Any CPU' target platform mean?", Color.FromArgb(153, 50, 204), showLinkLabel: true, new LMessageBox.ButtonClick(smethod_2), new LMessageBox.LinkLabelClick(smethod_3));
		}

		private static void smethod_2()
		{
			Process.Start("https://docs.microsoft.com/en-us/visualstudio/ide/how-to-configure-projects-to-target-platforms?view=vs-2019");
		}

		private static void smethod_3()
		{
			Process.Start("https://stackoverflow.com/questions/516730/what-does-the-visual-studio-any-cpu-target-mean");
		}

		private static void smethod_4()
		{
			string text = Class13.smethod_13();
			bool flag;
			if (!(flag = !(text == "") && File.Exists(text)))
			{
				_ = !flag | !File.Exists(Class16.String_1);
			}
		}

		private static void smethod_5()
		{
			Process.Start("mailto:support@siticoneframework.com");
		}

		private static void smethod_6()
		{
			Process.Start("https://www.siticoneframework.com/");
		}

		private static void smethod_7()
		{
		}

		private static void smethod_8()
		{
		}

		private static void smethod_9()
		{
			string text = Class13.smethod_13();
			if (!(text == "") && File.Exists(text))
			{
				Process.Start(text);
			}
		}

		private static void smethod_10()
		{
			Process.Start("https://www.siticoneframework.com/");
		}

		private static void smethod_11()
		{
			Process.Start("https://www.siticoneframework.com/pricing.html");
		}

		private static void smethod_12()
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Siticone Framework Manager");
				registryKey.SetValue("exe32", Application.ExecutablePath);
				registryKey.Close();
			}
			catch
			{
			}
		}

		private static string smethod_13()
		{
			string result = "";
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Siticone Framework Manager");
				result = registryKey.GetValue("exe32", "").ToString();
				registryKey.Close();
			}
			catch
			{
			}
			return result;
		}

		internal static bool smethod_14()
		{
			string fileName = Path.GetFileName(Application.ExecutablePath);
			if (fileName == "devenv.exe")
			{
				return true;
			}
			if (fileName == "WDExpress.exe")
			{
				return true;
			}
			return false;
		}
	}
}

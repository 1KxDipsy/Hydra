using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace ns0
{
	internal static class Class14
	{
		public const int int_0 = 0;

		public const int int_1 = -3;

		public const int int_2 = -2;

		public const int int_3 = -1;

		public const int int_4 = 1;

		public const int int_5 = 2;

		public const int int_6 = 3;

		public const int int_7 = 4;

		public const int int_8 = 5;

		public const int int_9 = 6;

		public const int int_10 = 7;

		public const int int_11 = 8;

		public const int int_12 = 9;

		public const int int_13 = 10;

		public const int int_14 = 11;

		public const int int_15 = 12;

		public const int int_16 = 13;

		public const int int_17 = 14;

		public const int int_18 = 15;

		public const int int_19 = 16;

		public const int int_20 = 17;

		public const int int_21 = 18;

		public const int int_22 = 19;

		public const int int_23 = 20;

		public const int int_24 = 21;

		public const int int_25 = 98;

		public const int int_26 = 99;

		[DllImport("DNA.dll")]
		public static extern int DNA_ProtectionOK(string string_0, int int_27, int int_28);

		[DllImport("DNA.dll")]
		public static extern int DNA_Activate(string string_0, string string_1, string string_2, string string_3);

		[DllImport("DNA.dll")]
		public static extern int DNA_ActivateOffline(string string_0, string string_1);

		[DllImport("DNA.dll")]
		public static extern int DNA_Reactivate(string string_0, string string_1, string string_2, string string_3);

		[DllImport("DNA.dll")]
		public static extern int DNA_Validate(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_Validate2(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_Validate3(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_Validate4(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_Validate5(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_ValidateCDM(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_ValidateCDM2(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_ValidateCDM3(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_ValidateCDM4(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_ValidateCDM5(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_Deactivate(string string_0, string string_1);

		[DllImport("DNA.dll")]
		public static extern int DNA_SendPassword(string string_0, string string_1);

		[DllImport("DNA.dll")]
		public static extern int DNA_Query(string string_0, string string_1);

		[DllImport("DNA.dll")]
		public static extern int DNA_InfoTag(string string_0, string string_1, string string_2);

		[DllImport("DNA.dll")]
		public static extern int DNA_SetBuildNo(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_SendEvalCode(string string_0, string string_1, int int_27);

		[DllImport("DNA.dll")]
		public static extern int DNA_SetCDMPathName(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_SetINIPathName(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_SetProxy(string string_0, string string_1, string string_2, string string_3);

		[DllImport("DNA.dll")]
		public static extern int DNA_SetLanguage(int int_27);

		[DllImport("DNA.dll")]
		public static extern int DNA_EvaluateNow(string string_0);

		[DllImport("DNA.dll")]
		public static extern int DNA_UseIESettings(int int_27);

		[DllImport("DNA.dll")]
		private static extern int DNA_Error(int int_27, StringBuilder stringBuilder_0, int int_28);

		[DllImport("DNA.dll")]
		private static extern int DNA_Param(string string_0, StringBuilder stringBuilder_0, int int_27);

		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string string_0);

		public static string smethod_0()
		{
			return (IntPtr.Size == 4) ? "x86" : "x64";
		}

		public static string smethod_1(int int_27)
		{
			StringBuilder stringBuilder = new StringBuilder(2048);
			if (Class14.DNA_Error(int_27, stringBuilder, stringBuilder.Capacity) == 0)
			{
				return stringBuilder.ToString();
			}
			return "???";
		}

		public static string smethod_2(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder(2048);
			if (Class14.DNA_Param(string_0, stringBuilder, stringBuilder.Capacity) == 0)
			{
				return stringBuilder.ToString();
			}
			return "???";
		}

		public static string smethod_3(string string_0)
		{
			if (File.Exists(string_0))
			{
				FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read);
				byte[] array = new MD5CryptoServiceProvider().ComputeHash(fileStream);
				fileStream.Close();
				StringBuilder stringBuilder = new StringBuilder();
				byte[] array2 = array;
				foreach (byte b in array2)
				{
					stringBuilder.Append(b.ToString("x2").ToUpper());
				}
				return stringBuilder.ToString();
			}
			return "";
		}
	}
}

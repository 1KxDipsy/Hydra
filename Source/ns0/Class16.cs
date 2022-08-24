using System;

namespace ns0
{
	internal sealed class Class16
	{
		internal enum Enum1
		{
			const_0 = 0,
			const_1 = -3,
			const_2 = -2,
			const_3 = -1,
			const_4 = 1,
			const_5 = 2,
			const_6 = 3,
			const_7 = 4,
			const_8 = 5,
			const_9 = 6,
			const_10 = 7,
			const_11 = 8,
			const_12 = 9,
			const_13 = 10,
			const_14 = 11,
			const_15 = 12,
			const_16 = 13,
			const_17 = 14,
			const_18 = 15,
			const_19 = 16,
			const_20 = 17,
			const_21 = 18,
			const_22 = 19,
			const_23 = 20,
			const_24 = 21,
			const_25 = 98,
			const_26 = 99,
			const_27 = 100
		}

		public static class Class17
		{
			public static string String_0 => Class16.bool_0 ? Class14.smethod_2("ACTIVATION_CODE") : "";

			public static string String_1 => Class16.bool_0 ? Class14.smethod_2("EXPIRY_DATE") : "";

			public static string String_2 => Class16.bool_0 ? Class14.smethod_2("ACTIVATION_DATE") : "";

			public static string String_3 => Class16.bool_0 ? Class14.smethod_2("EMAIL") : "";

			public static string String_4 => Class16.bool_0 ? Class14.smethod_2("REACTIVATION_DATE") : "";

			public static string String_5 => Class16.bool_0 ? Class14.smethod_2("VALIDATION_DATE") : "";

			public static string String_6 => Class16.bool_0 ? Class14.smethod_2("VALIDATION_WARNING") : "";

			public static string String_7 => Class16.bool_0 ? Class14.smethod_2("VALIDATION_LIMIT") : "";

			public static string String_8 => Class16.bool_0 ? Class14.smethod_2("EVAL_CODE") : "";

			public static string String_9 => Class16.bool_0 ? Class14.smethod_2("CLIENT_VERSION") : "";
		}

		private const string string_0 = "C23mhuE5zhRgu8jBXgyi8/gZ99hbMEfCNbHJQbjSY8se7XBNqoFViGDyaqE8nGEd2ETzySGlL/UQBB0ywWKD9894HODA/ZXbk9qpjoacqHXXpcsONlA6aG9XQ7QWBycjabztzjy+6eK/syb26gcB8Q==";

		private static bool bool_0 = false;

		public static string String_0 => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SiticoneFrameworkFiles";

		public static string String_1 => Class16.String_0 + "\\" + Class14.smethod_0() + "\\dna.dll";

		public static string String_2 => Class16.String_0 + "\\SiticoneFramework.CDM";

		public static Enum1 Enum1_0
		{
			get
			{
				if (!Class16.bool_0)
				{
					return Enum1.const_27;
				}
				return (Enum1)Class14.DNA_Validate("P0207210-QAB:CzPPpSerzFE24qE+c2rQpWuD4E4i5NQ0iRVoreYM6EEZkDY8xeaPFcUXsm6AMBIF5/qnvCJHNAB4P3Qnh02S1f");
			}
		}

		public static void smethod_0()
		{
			Class14.LoadLibrary(Class16.String_1);
			Class14.DNA_SetCDMPathName(Class16.String_2);
			Class16.bool_0 = true;
		}

		public static Enum1 smethod_1(string string_1, string string_2, string string_3)
		{
			if (!Class16.bool_0)
			{
				return Enum1.const_27;
			}
			return (Enum1)Class14.DNA_Activate("P0207210-QAB:CzPPpSerzFE24qE+c2rQpWuD4E4i5NQ0iRVoreYM6EEZkDY8xeaPFcUXsm6AMBIF5/qnvCJHNAB4P3Qnh02S1f", string_1, string_2, string_3);
		}

		public static Enum1 smethod_2(string string_1)
		{
			if (!Class16.bool_0)
			{
				return Enum1.const_27;
			}
			return (Enum1)Class14.DNA_Deactivate("P0207210-QAB:CzPPpSerzFE24qE+c2rQpWuD4E4i5NQ0iRVoreYM6EEZkDY8xeaPFcUXsm6AMBIF5/qnvCJHNAB4P3Qnh02S1f", string_1);
		}

		public static Enum1 smethod_3()
		{
			if (!Class16.bool_0)
			{
				return Enum1.const_27;
			}
			return (Enum1)Class14.DNA_EvaluateNow("P0207210-QAB:CzPPpSerzFE24qE+c2rQpWuD4E4i5NQ0iRVoreYM6EEZkDY8xeaPFcUXsm6AMBIF5/qnvCJHNAB4P3Qnh02S1f");
		}

		public static string smethod_4(Enum1 enum1_0)
		{
			if (!Class16.bool_0)
			{
				return "dna.dll does not exist!";
			}
			return Class14.smethod_1((int)enum1_0);
		}
	}
}

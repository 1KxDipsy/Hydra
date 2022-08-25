using dnlib.DotNet;

namespace HYDRA_PROTECTOR
{
	internal static class fakeobfuscator
	{
		public static class xd
		{
			public static int cflowint = 0;

			public static string renamertype = null;

			public static int thelength = 5;
		}

		private static readonly string[] attrib = new string[26]
		{
			RUtils.RandomSymbols(xd.thelength),
			"MedusaObfuscator",
			"ObfuscatedByUnderwordDog",
			"KatanaObf",
			"Pegacode",
			"PoweredByPEGASUS",
			"ObfuscatedByDavid",
			"Obfuscator.Evaluation",
			"UnderwordGuard",
			"HYDRANetProtector",
			"HYDRAPatcher",
			"KAKAfuscator",
			"KronosObfuscator",
			"HydraObfuscator",
			"ObfuscatedByHydra",
			"Yano",
			"Xenocode",
			"PoweredByAttribute",
			"ObfuscatedByGoliath",
			"NineRays.Obfuscator.Evaluation",
			"NetGuard",
			"dotNetProtector",
			"DotNetPatcher",
			"Dotfuscator",
			"CryptoObfuscator",
			"BabelObfuscator"
		};

		public static void Execute(ModuleDefMD module)
		{
			int num = 0;
			do
			{
				TypeDefUser typeDefUser = new TypeDefUser(fakeobfuscator.attrib[num], fakeobfuscator.attrib[num], module.CorLibTypes.Object.TypeDefOrRef);
				num++;
				module.Types.Add(typeDefUser);
				typeDefUser.Attributes = TypeAttributes.WindowsRuntime;
			}
			while (num < fakeobfuscator.attrib.Length);
			num = 0;
		}
	}
}

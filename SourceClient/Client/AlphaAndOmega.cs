using System.Security.Principal;
using System.Text;

namespace Client
{
	internal class AlphaAndOmega
	{
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

		public static bool IsAdmin()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}

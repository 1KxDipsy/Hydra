using System.Text;

namespace HYDRA_PROTECTOR
{
	internal class StringDec
	{
		public static string Decrypt(string @string, int key)
		{
			byte[] array = new byte[@string.Length];
			for (int i = 0; i < @string.Length; i++)
			{
				array[i] = (byte)(@string[i] ^ key);
			}
			return Encoding.UTF8.GetString(array);
		}
	}
}

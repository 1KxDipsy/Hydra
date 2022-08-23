using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HYDRA_PROTECTOR
{
	internal class StringDec2
	{
		public static string Decrypt(string encryptedText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes("48235728");
			byte[] array = Convert.FromBase64String(encryptedText);
			ICryptoTransform transform = new DESCryptoServiceProvider().CreateDecryptor(bytes, Encoding.ASCII.GetBytes("fmwa3x6k"));
			MemoryStream memoryStream = new MemoryStream(array);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			byte[] array2 = new byte[array.Length];
			int count = cryptoStream.Read(array2, 0, array2.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(array2, 0, count).TrimEnd("\0".ToCharArray());
		}
	}
}

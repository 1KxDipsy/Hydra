using System;
using System.Security.Cryptography;
using System.Text;

namespace ns0
{
	internal class Class15
	{
		private const string string_0 = "opmaioqwszaxkjmwiewqasqwasvgfhty";

		private const string string_1 = "nghdgfqmkasdwert";

		public static string smethod_0(string string_2)
		{
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(string_2);
				AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider
				{
					BlockSize = 128,
					KeySize = 256,
					Key = Encoding.ASCII.GetBytes("opmaioqwszaxkjmwiewqasqwasvgfhty"),
					IV = Encoding.ASCII.GetBytes("nghdgfqmkasdwert"),
					Padding = PaddingMode.PKCS7,
					Mode = CipherMode.CBC
				};
				ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
				byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
				cryptoTransform.Dispose();
				return Convert.ToBase64String(inArray);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return "";
			}
		}

		public static string smethod_1(string string_2)
		{
			try
			{
				byte[] array = Convert.FromBase64String(string_2);
				AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider
				{
					BlockSize = 128,
					KeySize = 256,
					Key = Encoding.ASCII.GetBytes("opmaioqwszaxkjmwiewqasqwasvgfhty"),
					IV = Encoding.ASCII.GetBytes("nghdgfqmkasdwert"),
					Padding = PaddingMode.PKCS7,
					Mode = CipherMode.CBC
				};
				ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
				byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
				cryptoTransform.Dispose();
				return Encoding.ASCII.GetString(bytes);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return "";
			}
		}
	}
}

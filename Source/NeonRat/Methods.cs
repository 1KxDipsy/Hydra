using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeonRat
{
	public static class Methods
	{
		private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

		public static Random Random = new Random();

		public static string BytesToString(long byteCount)
		{
			string[] array = new string[7] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
			if (byteCount == 0L)
			{
				return "0" + array[0];
			}
			long num = Math.Abs(byteCount);
			int num2 = Convert.ToInt32(Math.Floor(Math.Log(num, 1024.0)));
			double num3 = Math.Round((double)num / Math.Pow(1024.0, num2), 1);
			return (double)Math.Sign(byteCount) * num3 + array[num2];
		}

		public static async Task FadeIn(Form o, int interval = 80)
		{
			while (o.Opacity < 1.0)
			{
				await Task.Delay(interval);
				o.Opacity += 0.05;
			}
		}

		public static string GetRandomString(int length)
		{
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[Methods.Random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)]);
			}
			return stringBuilder.ToString();
		}
	}
}

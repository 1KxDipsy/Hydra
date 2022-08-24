using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using ns16;

namespace ns0
{
	internal static class Class22
	{
		private static readonly string[,] string_0 = new string[4, 10]
		{
			{ "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" },
			{ "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" },
			{ "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" },
			{ "", "M", "MM", "MMM", "M(V)", "(V)", "(V)M", "(V)MM", "(V)MMM", "M(X)" }
		};

		private static readonly string[,] string_1 = new string[3, 9]
		{
			{ "א", "ב", "ג", "ד", "ה", "ו", "ז", "ח", "ט" },
			{ "י", "כ", "ל", "מ", "נ", "ס", "ע", "פ", "צ" },
			{ "ק", "ר", "ש", "ת", "תק", "תר", "תש", "תת", "תתק" }
		};

		private static readonly string[,] string_2 = new string[3, 9]
		{
			{ "ა", "ბ", "გ", "დ", "ე", "ვ", "ზ", "ჱ", "თ" },
			{ "ი", "პ", "ლ", "მ", "ნ", "ჲ", "ო", "პ", "ჟ" },
			{ "რ", "ს", "ტ", "ჳ", "ფ", "ქ", "ღ", "ყ", "შ" }
		};

		private static readonly string[,] string_3 = new string[3, 9]
		{
			{ "Ա", "Բ", "Գ", "Դ", "Ե", "Զ", "Է", "Ը", "Թ" },
			{ "Ժ", "Ի", "Լ", "Խ", "Ծ", "Կ", "Հ", "Ձ", "Ղ" },
			{ "Ճ", "Մ", "Յ", "Ն", "Շ", "Ո", "Չ", "Պ", "Ջ" }
		};

		private static readonly string[] string_4 = new string[48]
		{
			"あ", "ぃ", "ぅ", "ぇ", "ぉ", "か", "き", "く", "け", "こ",
			"さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と",
			"な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ",
			"ま", "み", "む", "め", "も", "ゃ", "ゅ", "ょ", "ら", "り",
			"る", "れ", "ろ", "ゎ", "ゐ", "ゑ", "を", "ん"
		};

		private static readonly string[] string_5 = new string[48]
		{
			"ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ",
			"サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト",
			"ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ",
			"マ", "ミ", "ム", "メ", "モ", "ヤ", "ユ", "ヨ", "ラ", "リ",
			"ル", "レ", "ロ", "ワ", "ヰ", "ヱ", "ヲ", "ン"
		};

		public static string string_6;

		public static bool smethod_0(char char_0)
		{
			return char_0 >= '一' && char_0 <= '鶴';
		}

		public static bool smethod_1(char char_0, bool bool_0 = false)
		{
			return (char_0 >= '0' && char_0 <= '9') || (bool_0 && ((char_0 >= 'a' && char_0 <= 'f') || (char_0 >= 'A' && char_0 <= 'F')));
		}

		public static int smethod_2(char char_0, bool bool_0 = false)
		{
			if (char_0 >= '0' && char_0 <= '9')
			{
				return char_0 - 48;
			}
			if (bool_0)
			{
				if (char_0 >= 'a' && char_0 <= 'f')
				{
					return char_0 - 97 + 10;
				}
				if (char_0 >= 'A' && char_0 <= 'F')
				{
					return char_0 - 65 + 10;
				}
			}
			return 0;
		}

		public static RSize smethod_3(RSize rsize_0, RSize rsize_1)
		{
			return new RSize(Math.Max(rsize_0.Width, rsize_1.Width), Math.Max(rsize_0.Height, rsize_1.Height));
		}

		public static Uri smethod_4(string string_7)
		{
			try
			{
				if (Uri.IsWellFormedUriString(string_7, UriKind.RelativeOrAbsolute))
				{
					return new Uri(string_7);
				}
			}
			catch
			{
			}
			return null;
		}

		public static U smethod_5<T, U>(IDictionary<T, U> idictionary_0, U gparam_0 = default(U))
		{
			if (idictionary_0 != null)
			{
				using IEnumerator<KeyValuePair<T, U>> enumerator = idictionary_0.GetEnumerator();
				if (enumerator.MoveNext())
				{
					return enumerator.Current.Value;
				}
			}
			return gparam_0;
		}

		public static FileInfo smethod_6(string string_7)
		{
			try
			{
				return new FileInfo(string_7);
			}
			catch
			{
			}
			return null;
		}

		public static string smethod_7(WebClient webClient_0)
		{
			foreach (string responseHeader in webClient_0.ResponseHeaders)
			{
				if (responseHeader.Equals("Content-Type", StringComparison.InvariantCultureIgnoreCase))
				{
					return webClient_0.ResponseHeaders[responseHeader];
				}
			}
			return null;
		}

		public static FileInfo smethod_8(Uri uri_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string absoluteUri = uri_0.AbsoluteUri;
			int num = absoluteUri.LastIndexOf('/');
			if (num == -1)
			{
				return null;
			}
			stringBuilder.Append(absoluteUri.Substring(0, num).GetHashCode().ToString());
			stringBuilder.Append('_');
			string text = absoluteUri.Substring(num + 1);
			int num2 = text.IndexOf('?');
			if (num2 == -1)
			{
				string value = ".png";
				int num3 = text.IndexOf('.');
				if (num3 > -1)
				{
					value = text.Substring(num3);
					text = text.Substring(0, num3);
				}
				stringBuilder.Append(text);
				stringBuilder.Append(value);
			}
			else
			{
				int num4 = text.IndexOf('.');
				if (num4 != -1 && num4 <= num2)
				{
					if (num2 > num4)
					{
						stringBuilder.Append(text, 0, num4);
						stringBuilder.Append(text, num2, text.Length - num2);
						stringBuilder.Append(text, num4, num2 - num4);
					}
				}
				else
				{
					stringBuilder.Append(text);
					stringBuilder.Append(".png");
				}
			}
			string text2 = Class22.smethod_11(stringBuilder.ToString());
			if (text2.Length > 25)
			{
				text2 = text2.Substring(0, 24) + text2.Substring(24).GetHashCode() + Path.GetExtension(text2);
			}
			if (Class22.string_6 == null)
			{
				Class22.string_6 = Path.Combine(Path.GetTempPath(), "HtmlRenderer");
				if (!Directory.Exists(Class22.string_6))
				{
					Directory.CreateDirectory(Class22.string_6);
				}
			}
			return new FileInfo(Path.Combine(Class22.string_6, text2));
		}

		public static int smethod_9(string string_7, int int_0, out int int_1)
		{
			while (int_0 < string_7.Length && char.IsWhiteSpace(string_7[int_0]))
			{
				int_0++;
			}
			if (int_0 < string_7.Length)
			{
				int i;
				for (i = int_0 + 1; i < string_7.Length && !char.IsWhiteSpace(string_7[i]); i++)
				{
				}
				int_1 = i - int_0;
				return int_0;
			}
			int_1 = 0;
			return -1;
		}

		public static bool smethod_10(string string_7, int int_0, int int_1, string string_8)
		{
			if (int_1 == string_8.Length && int_0 + int_1 <= string_7.Length)
			{
				int num = 0;
				while (true)
				{
					if (num < int_1)
					{
						if (char.ToLowerInvariant(string_7[int_0 + num]) != char.ToLowerInvariant(string_8[num]))
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		private static string smethod_11(string string_7)
		{
			string text = string_7;
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			for (int i = 0; i < invalidFileNameChars.Length; i++)
			{
				text = text.Replace(invalidFileNameChars[i], '_');
			}
			return text;
		}

		public static string smethod_12(int int_0, string string_7 = "upper-alpha")
		{
			if (int_0 == 0)
			{
				return string.Empty;
			}
			if (string_7.Equals("lower-greek", StringComparison.InvariantCultureIgnoreCase))
			{
				return Class22.smethod_14(int_0);
			}
			if (string_7.Equals("lower-roman", StringComparison.InvariantCultureIgnoreCase))
			{
				return Class22.smethod_15(int_0, bool_0: true);
			}
			if (string_7.Equals("upper-roman", StringComparison.InvariantCultureIgnoreCase))
			{
				return Class22.smethod_15(int_0, bool_0: false);
			}
			if (string_7.Equals("armenian", StringComparison.InvariantCultureIgnoreCase))
			{
				return Class22.smethod_16(int_0, Class22.string_3);
			}
			if (string_7.Equals("georgian", StringComparison.InvariantCultureIgnoreCase))
			{
				return Class22.smethod_16(int_0, Class22.string_2);
			}
			if (string_7.Equals("hebrew", StringComparison.InvariantCultureIgnoreCase))
			{
				return Class22.smethod_16(int_0, Class22.string_1);
			}
			if (!string_7.Equals("hiragana", StringComparison.InvariantCultureIgnoreCase) && !string_7.Equals("hiragana-iroha", StringComparison.InvariantCultureIgnoreCase))
			{
				if (!string_7.Equals("katakana", StringComparison.InvariantCultureIgnoreCase) && !string_7.Equals("katakana-iroha", StringComparison.InvariantCultureIgnoreCase))
				{
					return Class22.smethod_13(int_0, string_7.Equals("lower-alpha", StringComparison.InvariantCultureIgnoreCase) || string_7.Equals("lower-latin", StringComparison.InvariantCultureIgnoreCase));
				}
				return Class22.smethod_17(int_0, Class22.string_5);
			}
			return Class22.smethod_17(int_0, Class22.string_4);
		}

		private static string smethod_13(int int_0, bool bool_0)
		{
			string text = string.Empty;
			int num = (bool_0 ? 97 : 65);
			while (int_0 > 0)
			{
				int num2 = int_0 % 26 - 1;
				if (num2 >= 0)
				{
					text = (char)(num + num2) + text;
					int_0 /= 26;
				}
				else
				{
					text = (char)(num + 25) + text;
					int_0 = (int_0 - 1) / 26;
				}
			}
			return text;
		}

		private static string smethod_14(int int_0)
		{
			string text = string.Empty;
			while (int_0 > 0)
			{
				int num = int_0 % 24 - 1;
				if (num > 16)
				{
					num++;
				}
				if (num >= 0)
				{
					text = (char)(945 + num) + text;
					int_0 /= 24;
				}
				else
				{
					text = "ω" + text;
					int_0 = (int_0 - 1) / 25;
				}
			}
			return text;
		}

		private static string smethod_15(int int_0, bool bool_0)
		{
			string text = string.Empty;
			int num = 1000;
			int num2 = 3;
			while (num > 0)
			{
				int num3 = int_0 / num;
				text += string.Format(Class22.string_0[num2, num3]);
				int_0 -= num3 * num;
				num /= 10;
				num2--;
			}
			return bool_0 ? text.ToLower() : text;
		}

		private static string smethod_16(int int_0, string[,] string_7)
		{
			int num = 0;
			string text = string.Empty;
			while (int_0 > 0 && num < string_7.GetLength(0))
			{
				if (int_0 % 10 > 0)
				{
					text = string_7[num, int_0 % 10 - 1].ToString(CultureInfo.InvariantCulture) + text;
				}
				int_0 /= 10;
				num++;
			}
			return text;
		}

		private static string smethod_17(int int_0, string[] string_7)
		{
			for (int num = 20; num > 0; num--)
			{
				if (int_0 > 49 * num - num + 1)
				{
					int_0++;
				}
			}
			string text = string.Empty;
			while (int_0 > 0)
			{
				text = string_7[Math.Max(0, int_0 % 49 - 1)].ToString(CultureInfo.InvariantCulture) + text;
				int_0 /= 49;
			}
			return text;
		}
	}
}

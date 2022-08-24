using System;
using System.Collections.Generic;

namespace ns0
{
	internal static class Class35
	{
		public static Class50 smethod_0(string string_0)
		{
			Class50 @class = Class50.smethod_2();
			Class50 class50_ = @class;
			int num = 0;
			int num2 = 0;
			while (num2 >= 0)
			{
				int num3 = string_0.IndexOf('<', num2);
				if (num3 >= 0 && num3 < string_0.Length)
				{
					Class35.smethod_1(string_0, num2, num3, ref class50_);
					if (string_0[num3 + 1] == '!')
					{
						if (string_0[num3 + 2] == '-')
						{
							num2 = string_0.IndexOf("-->", num3 + 2);
							num = ((num2 > 0) ? (num2 + 3) : (num3 + 2));
						}
						else
						{
							num2 = string_0.IndexOf(">", num3 + 2);
							num = ((num2 > 0) ? (num2 + 1) : (num3 + 2));
						}
					}
					else
					{
						num = Class35.smethod_2(string_0, num3, ref class50_) + 1;
						if (class50_.Class63_0 != null && class50_.Class63_0.String_0.Equals("style", StringComparison.OrdinalIgnoreCase))
						{
							int int_ = num;
							num = string_0.IndexOf("</style>", num, StringComparison.OrdinalIgnoreCase);
							if (num > -1)
							{
								Class35.smethod_1(string_0, int_, num, ref class50_);
							}
						}
					}
				}
				num2 = ((num3 <= -1 || num <= 0) ? (-1) : num);
			}
			if (num > -1 && num < string_0.Length)
			{
				Class29 class2 = new Class29(string_0, num, string_0.Length - num);
				if (!class2.method_1())
				{
					Class50.smethod_1(@class).Class29_0 = class2;
				}
			}
			return @class;
		}

		private static void smethod_1(string string_0, int int_0, int int_1, ref Class50 class50_0)
		{
			Class29 @class = ((int_1 > int_0) ? new Class29(string_0, int_0, int_1 - int_0) : null);
			if (@class != null)
			{
				Class50.smethod_1(class50_0).Class29_0 = @class;
			}
		}

		private static int smethod_2(string string_0, int int_0, ref Class50 class50_0)
		{
			int num = string_0.IndexOf('>', int_0 + 1);
			if (num > 0)
			{
				if (Class35.smethod_3(string_0, int_0, num - int_0 + 1 - ((string_0[num - 1] == '/') ? 1 : 0), out var string_, out var dictionary_))
				{
					if (!Class27.smethod_0(string_) && class50_0.Class50_0 != null)
					{
						class50_0 = Class25.smethod_2(class50_0.Class50_0, string_, class50_0);
					}
				}
				else if (!string.IsNullOrEmpty(string_))
				{
					bool flag = Class27.smethod_0(string_) || string_0[num - 1] == '/';
					Class63 class63_ = new Class63(string_, flag, dictionary_);
					if (flag)
					{
						Class50.smethod_0(class63_, class50_0);
					}
					else
					{
						class50_0 = Class50.smethod_0(class63_, class50_0);
					}
				}
				else
				{
					num = int_0 + 1;
				}
			}
			return num;
		}

		private static bool smethod_3(string string_0, int int_0, int int_1, out string string_1, out Dictionary<string, string> dictionary_0)
		{
			int_0++;
			int_1 -= ((string_0[int_0 + int_1 - 3] == '/') ? 3 : 2);
			bool flag = false;
			if (string_0[int_0] == '/')
			{
				int_0++;
				int_1--;
				flag = true;
			}
			int i;
			for (i = int_0; i < int_0 + int_1 && !char.IsWhiteSpace(string_0, i); i++)
			{
			}
			string_1 = string_0.Substring(int_0, i - int_0).ToLower();
			dictionary_0 = null;
			if (!flag && int_0 + int_1 > i)
			{
				Class35.smethod_4(string_0, i, int_1 - (i - int_0), out dictionary_0);
			}
			return flag;
		}

		private static void smethod_4(string string_0, int int_0, int int_1, out Dictionary<string, string> dictionary_0)
		{
			dictionary_0 = null;
			int i = int_0;
			while (i < int_0 + int_1)
			{
				for (; i < int_0 + int_1 && char.IsWhiteSpace(string_0, i); i++)
				{
				}
				int j;
				for (j = i + 1; j < int_0 + int_1 && !char.IsWhiteSpace(string_0, j) && string_0[j] != '='; j++)
				{
				}
				if (i >= int_0 + int_1)
				{
					continue;
				}
				string text = string_0.Substring(i, j - i);
				string value = "";
				for (i = j + 1; i < int_0 + int_1 && (char.IsWhiteSpace(string_0, i) || string_0[i] == '='); i++)
				{
				}
				bool flag = false;
				if (i < int_0 + int_1)
				{
					char c = string_0[i];
					if (c == '"' || c == '\'')
					{
						flag = true;
						i++;
					}
					for (j = i + ((!flag) ? 1 : 0); j < int_0 + int_1; j++)
					{
						if (!flag)
						{
							if (char.IsWhiteSpace(string_0, j))
							{
								break;
							}
						}
						else if (string_0[j] == c)
						{
							break;
						}
					}
					value = Class27.smethod_1(string_0.Substring(i, j - i));
				}
				if (text.Length != 0)
				{
					if (dictionary_0 == null)
					{
						dictionary_0 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					}
					dictionary_0[text.ToLower()] = value;
				}
				i = j + ((!flag) ? 1 : 2);
			}
		}
	}
}

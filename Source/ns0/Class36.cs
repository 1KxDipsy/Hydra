using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ns0
{
	internal static class Class36
	{
		public const string string_0 = "@media[^\\{\\}]*\\{";

		public const string string_1 = "[^\\{\\}]*\\{[^\\{\\}]*\\}";

		public const string string_2 = "{[0-9]+|[0-9]*\\.[0-9]+}";

		public const string string_3 = "([0-9]+|[0-9]*\\.[0-9]+)\\%";

		public const string string_4 = "([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)";

		public const string string_5 = "(normal|{[0-9]+|[0-9]*\\.[0-9]+}|([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)|([0-9]+|[0-9]*\\.[0-9]+)\\%)";

		public const string string_6 = "(\"[^\"]*\"|'[^']*'|\\S+\\s*)(\\s*\\,\\s*(\"[^\"]*\"|'[^']*'|\\S+))*";

		public const string string_7 = "(normal|italic|oblique)";

		public const string string_8 = "(normal|small-caps)";

		public const string string_9 = "(normal|bold|bolder|lighter|100|200|300|400|500|600|700|800|900)";

		public const string string_10 = "(([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)|([0-9]+|[0-9]*\\.[0-9]+)\\%|xx-small|x-small|small|medium|large|x-large|xx-large|larger|smaller)";

		public const string string_11 = "(([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)|([0-9]+|[0-9]*\\.[0-9]+)\\%|xx-small|x-small|small|medium|large|x-large|xx-large|larger|smaller)(\\/(normal|{[0-9]+|[0-9]*\\.[0-9]+}|([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)|([0-9]+|[0-9]*\\.[0-9]+)\\%))?(\\s|$)";

		private static readonly Dictionary<string, Regex> dictionary_0 = new Dictionary<string, Regex>();

		public static string smethod_0(string string_12, ref int int_0)
		{
			int_0 = string_12.IndexOf('@', int_0);
			if (int_0 > -1)
			{
				int num = 1;
				int num2 = string_12.IndexOf('{', int_0);
				if (num2 > -1)
				{
					while (num > 0 && num2 < string_12.Length)
					{
						num2++;
						if (string_12[num2] == '{')
						{
							num++;
						}
						else if (string_12[num2] == '}')
						{
							num--;
						}
					}
					if (num2 < string_12.Length)
					{
						string result = string_12.Substring(int_0, num2 - int_0 + 1);
						int_0 = num2;
						return result;
					}
				}
			}
			return null;
		}

		public static MatchCollection smethod_1(string string_12, string string_13)
		{
			return Class36.smethod_4(string_12).Matches(string_13);
		}

		public static string smethod_2(string string_12, string string_13)
		{
			int int_;
			return Class36.smethod_3(string_12, string_13, out int_);
		}

		public static string smethod_3(string string_12, string string_13, out int int_0)
		{
			MatchCollection matchCollection = Class36.smethod_1(string_12, string_13);
			if (matchCollection.Count > 0)
			{
				int_0 = matchCollection[0].Index;
				return matchCollection[0].Value;
			}
			int_0 = -1;
			return null;
		}

		private static Regex smethod_4(string string_12)
		{
			if (!Class36.dictionary_0.TryGetValue(string_12, out var value))
			{
				value = new Regex(string_12, RegexOptions.IgnoreCase | RegexOptions.Singleline);
				Class36.dictionary_0[string_12] = value;
			}
			return value;
		}
	}
}

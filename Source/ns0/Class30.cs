using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ns10;
using ns11;
using ns13;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class30
	{
		private static readonly char[] char_0 = new char[2] { '}', ';' };

		private readonly RAdapter radapter_0;

		private readonly Class31 class31_0;

		private static readonly char[] char_1 = new char[8] { '\r', '\n', '\t', ' ', '-', '!', '<', '>' };

		public Class30(RAdapter radapter_1)
		{
			ArgChecker.AssertArgNotNull(radapter_1, "global");
			this.class31_0 = new Class31(radapter_1);
			this.radapter_0 = radapter_1;
		}

		public CssData method_0(string string_0, bool bool_0)
		{
			CssData cssData = (bool_0 ? this.radapter_0.DefaultCssData.Clone() : new CssData());
			if (!string.IsNullOrEmpty(string_0))
			{
				this.method_1(cssData, string_0);
			}
			return cssData;
		}

		public void method_1(CssData cssData_0, string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				string_0 = Class30.smethod_0(string_0);
				this.method_5(cssData_0, string_0);
				this.method_6(cssData_0, string_0);
			}
		}

		public CssBlock method_2(string string_0, string string_1)
		{
			return this.method_8(string_0, string_1);
		}

		public string method_3(string string_0)
		{
			return this.method_13(string_0);
		}

		public RColor method_4(string string_0)
		{
			return this.class31_0.method_1(string_0);
		}

		private static string smethod_0(string string_0)
		{
			StringBuilder stringBuilder = null;
			int num = 0;
			int num2 = 0;
			while (num2 > -1 && num2 < string_0.Length)
			{
				num2 = string_0.IndexOf("/*", num2);
				if (num2 > -1)
				{
					if (stringBuilder == null)
					{
						stringBuilder = new StringBuilder(string_0.Length);
					}
					stringBuilder.Append(string_0.Substring(num, num2 - num));
					int num3 = string_0.IndexOf("*/", num2 + 2);
					if (num3 < 0)
					{
						num3 = string_0.Length;
					}
					num = (num2 = num3 + 2);
				}
				else
				{
					stringBuilder?.Append(string_0.Substring(num));
				}
			}
			return (stringBuilder != null) ? stringBuilder.ToString() : string_0;
		}

		private void method_5(CssData cssData_0, string string_0)
		{
			int i = 0;
			int j = 0;
			while (i < string_0.Length && j > -1)
			{
				j = i;
				while (j + 1 < string_0.Length)
				{
					j++;
					if (string_0[j] == '}')
					{
						i = j + 1;
					}
					if (string_0[j] == '{')
					{
						break;
					}
				}
				int num = j + 1;
				if (j <= -1)
				{
					continue;
				}
				for (j++; j < string_0.Length; j++)
				{
					if (string_0[j] == '{')
					{
						i = num + 1;
					}
					if (string_0[j] == '}')
					{
						break;
					}
				}
				if (j < string_0.Length)
				{
					for (; char.IsWhiteSpace(string_0[i]); i++)
					{
					}
					this.method_7(cssData_0, string_0.Substring(i, j - i + 1));
				}
				i = j + 1;
			}
		}

		private void method_6(CssData cssData_0, string string_0)
		{
			int int_ = 0;
			string text;
			while ((text = Class36.smethod_0(string_0, ref int_)) != null)
			{
				if (!text.StartsWith("@media", StringComparison.InvariantCultureIgnoreCase))
				{
					continue;
				}
				MatchCollection matchCollection = Class36.smethod_1("@media[^\\{\\}]*\\{", text);
				if (matchCollection.Count != 1)
				{
					continue;
				}
				string value = matchCollection[0].Value;
				if (!value.StartsWith("@media", StringComparison.InvariantCultureIgnoreCase) || !value.EndsWith("{"))
				{
					continue;
				}
				string[] array = value.Substring(6, value.Length - 7).Split(' ');
				foreach (string text2 in array)
				{
					if (string.IsNullOrEmpty(text2.Trim()))
					{
						continue;
					}
					foreach (Match item in Class36.smethod_1("[^\\{\\}]*\\{[^\\{\\}]*\\}", text))
					{
						this.method_7(cssData_0, item.Value, text2.Trim());
					}
				}
			}
		}

		private void method_7(CssData cssData_0, string string_0, string string_1 = "all")
		{
			int num = string_0.IndexOf("{", StringComparison.Ordinal);
			int num2 = ((num > -1) ? string_0.IndexOf("}", num) : (-1));
			if (num <= -1 || num2 <= -1)
			{
				return;
			}
			string string_2 = string_0.Substring(num + 1, num2 - num - 1);
			string[] array = string_0.Substring(0, num).Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim(Class30.char_1);
				if (!string.IsNullOrEmpty(text))
				{
					CssBlock cssBlock = this.method_8(text, string_2);
					if (cssBlock != null)
					{
						cssData_0.AddCssBlock(string_1, cssBlock);
					}
				}
			}
		}

		private CssBlock method_8(string string_0, string string_1)
		{
			string_0 = string_0.ToLower();
			string text = null;
			int num = string_0.IndexOf(":", StringComparison.Ordinal);
			if (num > -1 && !string_0.StartsWith("::"))
			{
				text = ((num < string_0.Length - 1) ? string_0.Substring(num + 1).Trim() : null);
				string_0 = string_0.Substring(0, num).Trim();
			}
			if (!string.IsNullOrEmpty(string_0))
			{
				switch (text)
				{
				case null:
				case "link":
				case "hover":
				{
					string string_2;
					return new CssBlock(selectors: Class30.smethod_1(string_0, out string_2), properties: this.method_9(string_1), @class: string_2, hover: text == "hover");
				}
				}
			}
			return null;
		}

		private static List<CssBlockSelectorItem> smethod_1(string string_0, out string string_1)
		{
			List<CssBlockSelectorItem> list = null;
			string_1 = null;
			int num = string_0.Length - 1;
			while (num > -1)
			{
				bool flag = false;
				while (char.IsWhiteSpace(string_0[num]) || string_0[num] == '>')
				{
					flag = flag || string_0[num] == '>';
					num--;
				}
				int num2 = num;
				while (num2 > -1 && !char.IsWhiteSpace(string_0[num2]) && string_0[num2] != '>')
				{
					num2--;
				}
				if (num2 > -1)
				{
					if (list == null)
					{
						list = new List<CssBlockSelectorItem>();
					}
					string text = string_0.Substring(num2 + 1, num - num2);
					if (string_1 == null)
					{
						string_1 = text;
					}
					else
					{
						while (char.IsWhiteSpace(string_0[num2]) || string_0[num2] == '>')
						{
							num2--;
						}
						list.Add(new CssBlockSelectorItem(text, flag));
					}
				}
				else if (string_1 != null)
				{
					list.Add(new CssBlockSelectorItem(string_0.Substring(0, num + 1), flag));
				}
				num = num2;
			}
			string_1 = string_1 ?? string_0;
			return list;
		}

		private Dictionary<string, string> method_9(string string_0)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int num = 0;
			while (num < string_0.Length)
			{
				int num2 = string_0.IndexOfAny(Class30.char_0, num);
				if (num >= 0 && num2 - num >= 10 && string_0.Length - num >= 10 && string_0.IndexOf("data:image", num, num2 - num) >= 0)
				{
					num2 = string_0.IndexOfAny(Class30.char_0, num2 + 1);
				}
				if (num2 < 0)
				{
					num2 = string_0.Length - 1;
				}
				int num3 = string_0.IndexOf(':', num, num2 - num);
				if (num3 > -1)
				{
					num += ((string_0[num] == ' ') ? 1 : 0);
					int num4 = num2 - ((string_0[num2] == ' ' || string_0[num2] == ';') ? 1 : 0);
					string string_ = string_0.Substring(num, num3 - num).Trim().ToLower();
					num3 += ((string_0[num3 + 1] != ' ') ? 1 : 2);
					if (num4 >= num3)
					{
						string text = string_0.Substring(num3, num4 - num3 + 1).Trim();
						if (!text.StartsWith("url", StringComparison.InvariantCultureIgnoreCase))
						{
							text = text.ToLower();
						}
						this.method_10(string_, text, dictionary);
					}
				}
				num = num2 + 1;
			}
			return dictionary;
		}

		private void method_10(string string_0, string string_1, Dictionary<string, string> dictionary_0)
		{
			string_1 = string_1.Replace("!important", string.Empty).Trim();
			switch (string_0)
			{
			case "font":
				this.method_12(string_1, dictionary_0);
				break;
			case "border":
				this.method_14(string_1, null, dictionary_0);
				break;
			case "border-left":
				this.method_14(string_1, "-left", dictionary_0);
				break;
			case "border-top":
				this.method_14(string_1, "-top", dictionary_0);
				break;
			case "border-right":
				this.method_14(string_1, "-right", dictionary_0);
				break;
			case "border-bottom":
				this.method_14(string_1, "-bottom", dictionary_0);
				break;
			case "margin":
				Class30.smethod_4(string_1, dictionary_0);
				break;
			case "border-style":
				Class30.smethod_5(string_1, dictionary_0);
				break;
			case "border-width":
				Class30.smethod_6(string_1, dictionary_0);
				break;
			case "border-color":
				Class30.smethod_7(string_1, dictionary_0);
				break;
			case "padding":
				Class30.smethod_8(string_1, dictionary_0);
				break;
			case "background-image":
				dictionary_0["background-image"] = Class30.smethod_3(string_1);
				break;
			case "content":
				dictionary_0["content"] = Class30.smethod_3(string_1);
				break;
			case "font-family":
				dictionary_0["font-family"] = this.method_13(string_1);
				break;
			default:
				dictionary_0[string_0] = string_1;
				break;
			case "color":
			case "backgroundcolor":
			case "bordertopcolor":
			case "borderbottomcolor":
			case "borderleftcolor":
			case "borderrightcolor":
				this.method_11(string_0, string_1, dictionary_0);
				break;
			case "width":
			case "height":
			case "lineheight":
				Class30.smethod_2(string_0, string_1, dictionary_0);
				break;
			}
		}

		private static void smethod_2(string string_0, string string_1, Dictionary<string, string> dictionary_0)
		{
			if (Class31.smethod_2(string_1) || string_1.Equals("auto", StringComparison.OrdinalIgnoreCase))
			{
				dictionary_0[string_0] = string_1;
			}
		}

		private void method_11(string string_0, string string_1, Dictionary<string, string> dictionary_0)
		{
			if (this.class31_0.method_0(string_1))
			{
				dictionary_0[string_0] = string_1;
			}
		}

		private void method_12(string string_0, Dictionary<string, string> dictionary_0)
		{
			string text = Class36.smethod_3("(([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)|([0-9]+|[0-9]*\\.[0-9]+)\\%|xx-small|x-small|small|medium|large|x-large|xx-large|larger|smaller)(\\/(normal|{[0-9]+|[0-9]*\\.[0-9]+}|([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)|([0-9]+|[0-9]*\\.[0-9]+)\\%))?(\\s|$)", string_0, out var int_);
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Trim();
				string string_ = string_0.Substring(0, int_);
				string value = Class36.smethod_2("(normal|italic|oblique)", string_);
				string value2 = Class36.smethod_2("(normal|small-caps)", string_);
				string value3 = Class36.smethod_2("(normal|bold|bolder|lighter|100|200|300|400|500|600|700|800|900)", string_);
				string text2 = string_0.Substring(int_ + text.Length).Trim();
				string value4 = text;
				string value5 = string.Empty;
				if (text.Contains("/") && text.Length > text.IndexOf("/", StringComparison.Ordinal) + 1)
				{
					int num = text.IndexOf("/", StringComparison.Ordinal);
					value4 = text.Substring(0, num);
					value5 = text.Substring(num + 1);
				}
				if (!string.IsNullOrEmpty(text2))
				{
					dictionary_0["font-family"] = this.method_13(text2);
				}
				if (!string.IsNullOrEmpty(value))
				{
					dictionary_0["font-style"] = value;
				}
				if (!string.IsNullOrEmpty(value2))
				{
					dictionary_0["font-variant"] = value2;
				}
				if (!string.IsNullOrEmpty(value3))
				{
					dictionary_0["font-weight"] = value3;
				}
				if (!string.IsNullOrEmpty(value4))
				{
					dictionary_0["font-size"] = value4;
				}
				if (!string.IsNullOrEmpty(value5))
				{
					dictionary_0["line-height"] = value5;
				}
			}
		}

		private static string smethod_3(string string_0)
		{
			int num = string_0.IndexOf("url(", StringComparison.InvariantCultureIgnoreCase);
			if (num > -1)
			{
				num += 4;
				int num2 = string_0.IndexOf(')', num);
				if (num2 > -1)
				{
					for (num2--; num < num2 && (char.IsWhiteSpace(string_0[num]) || string_0[num] == '\'' || string_0[num] == '"'); num++)
					{
					}
					while (num < num2 && (char.IsWhiteSpace(string_0[num2]) || string_0[num2] == '\'' || string_0[num2] == '"'))
					{
						num2--;
					}
					if (num <= num2)
					{
						return string_0.Substring(num, num2 - num + 1);
					}
				}
			}
			return string_0;
		}

		private string method_13(string string_0)
		{
			int i = 0;
			while (i > -1 && i < string_0.Length)
			{
				for (; char.IsWhiteSpace(string_0[i]) || string_0[i] == ',' || string_0[i] == '\'' || string_0[i] == '"'; i++)
				{
				}
				int num = string_0.IndexOf(',', i);
				if (num < 0)
				{
					num = string_0.Length;
				}
				int num2 = num - 1;
				while (char.IsWhiteSpace(string_0[num2]) || string_0[num2] == '\'' || string_0[num2] == '"')
				{
					num2--;
				}
				string text = string_0.Substring(i, num2 - i + 1);
				if (!this.radapter_0.IsFontExists(text))
				{
					i = num;
					continue;
				}
				return text;
			}
			return "inherit";
		}

		private void method_14(string string_0, string string_1, Dictionary<string, string> dictionary_0)
		{
			this.method_15(string_0, out var string_2, out var string_3, out var string_4);
			if (string_1 != null)
			{
				if (string_2 != null)
				{
					dictionary_0["border" + string_1 + "-width"] = string_2;
				}
				if (string_3 != null)
				{
					dictionary_0["border" + string_1 + "-style"] = string_3;
				}
				if (string_4 != null)
				{
					dictionary_0["border" + string_1 + "-color"] = string_4;
				}
			}
			else
			{
				if (string_2 != null)
				{
					Class30.smethod_6(string_2, dictionary_0);
				}
				if (string_3 != null)
				{
					Class30.smethod_5(string_3, dictionary_0);
				}
				if (string_4 != null)
				{
					Class30.smethod_7(string_4, dictionary_0);
				}
			}
		}

		private static void smethod_4(string string_0, Dictionary<string, string> dictionary_0)
		{
			Class30.smethod_9(string_0, out var string_, out var string_2, out var string_3, out var string_4);
			if (string_ != null)
			{
				dictionary_0["margin-left"] = string_;
			}
			if (string_2 != null)
			{
				dictionary_0["margin-top"] = string_2;
			}
			if (string_3 != null)
			{
				dictionary_0["margin-right"] = string_3;
			}
			if (string_4 != null)
			{
				dictionary_0["margin-bottom"] = string_4;
			}
		}

		private static void smethod_5(string string_0, Dictionary<string, string> dictionary_0)
		{
			Class30.smethod_9(string_0, out var string_, out var string_2, out var string_3, out var string_4);
			if (string_ != null)
			{
				dictionary_0["border-left-style"] = string_;
			}
			if (string_2 != null)
			{
				dictionary_0["border-top-style"] = string_2;
			}
			if (string_3 != null)
			{
				dictionary_0["border-right-style"] = string_3;
			}
			if (string_4 != null)
			{
				dictionary_0["border-bottom-style"] = string_4;
			}
		}

		private static void smethod_6(string string_0, Dictionary<string, string> dictionary_0)
		{
			Class30.smethod_9(string_0, out var string_, out var string_2, out var string_3, out var string_4);
			if (string_ != null)
			{
				dictionary_0["border-left-width"] = string_;
			}
			if (string_2 != null)
			{
				dictionary_0["border-top-width"] = string_2;
			}
			if (string_3 != null)
			{
				dictionary_0["border-right-width"] = string_3;
			}
			if (string_4 != null)
			{
				dictionary_0["border-bottom-width"] = string_4;
			}
		}

		private static void smethod_7(string string_0, Dictionary<string, string> dictionary_0)
		{
			Class30.smethod_9(string_0, out var string_, out var string_2, out var string_3, out var string_4);
			if (string_ != null)
			{
				dictionary_0["border-left-color"] = string_;
			}
			if (string_2 != null)
			{
				dictionary_0["border-top-color"] = string_2;
			}
			if (string_3 != null)
			{
				dictionary_0["border-right-color"] = string_3;
			}
			if (string_4 != null)
			{
				dictionary_0["border-bottom-color"] = string_4;
			}
		}

		private static void smethod_8(string string_0, Dictionary<string, string> dictionary_0)
		{
			Class30.smethod_9(string_0, out var string_, out var string_2, out var string_3, out var string_4);
			if (string_ != null)
			{
				dictionary_0["padding-left"] = string_;
			}
			if (string_2 != null)
			{
				dictionary_0["padding-top"] = string_2;
			}
			if (string_3 != null)
			{
				dictionary_0["padding-right"] = string_3;
			}
			if (string_4 != null)
			{
				dictionary_0["padding-bottom"] = string_4;
			}
		}

		private static void smethod_9(string string_0, out string string_1, out string string_2, out string string_3, out string string_4)
		{
			string_2 = null;
			string_1 = null;
			string_3 = null;
			string_4 = null;
			string[] array = Class30.smethod_10(string_0);
			switch (array.Length)
			{
			case 1:
				string_2 = (string_1 = (string_3 = (string_4 = array[0])));
				break;
			case 2:
				string_2 = (string_4 = array[0]);
				string_1 = (string_3 = array[1]);
				break;
			case 3:
				string_2 = array[0];
				string_1 = (string_3 = array[1]);
				string_4 = array[2];
				break;
			case 4:
				string_2 = array[0];
				string_3 = array[1];
				string_4 = array[2];
				string_1 = array[3];
				break;
			}
		}

		private static string[] smethod_10(string string_0, char char_2 = ' ')
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				string[] array = string_0.Split(char_2);
				List<string> list = new List<string>();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i].Trim();
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
				}
				return list.ToArray();
			}
			return new string[0];
		}

		public void method_15(string string_0, out string string_1, out string string_2, out string string_3)
		{
			string_1 = (string_2 = (string_3 = null));
			if (string.IsNullOrEmpty(string_0))
			{
				return;
			}
			int int_ = 0;
			int int_2;
			while ((int_ = Class22.smethod_9(string_0, int_, out int_2)) > -1)
			{
				if (string_1 == null)
				{
					string_1 = Class30.smethod_11(string_0, int_, int_2);
				}
				if (string_2 == null)
				{
					string_2 = Class30.smethod_12(string_0, int_, int_2);
				}
				if (string_3 == null)
				{
					string_3 = this.method_16(string_0, int_, int_2);
				}
				int_ = int_ + int_2 + 1;
			}
		}

		private static string smethod_11(string string_0, int int_0, int int_1)
		{
			if ((int_1 > 2 && char.IsDigit(string_0[int_0])) || (int_1 > 3 && string_0[int_0] == '.'))
			{
				string text = null;
				if (Class22.smethod_10(string_0, int_0 + int_1 - 2, 2, "px"))
				{
					text = "px";
				}
				else if (Class22.smethod_10(string_0, int_0 + int_1 - 2, 2, "pt"))
				{
					text = "pt";
				}
				else if (Class22.smethod_10(string_0, int_0 + int_1 - 2, 2, "em"))
				{
					text = "em";
				}
				else if (Class22.smethod_10(string_0, int_0 + int_1 - 2, 2, "ex"))
				{
					text = "ex";
				}
				else if (Class22.smethod_10(string_0, int_0 + int_1 - 2, 2, "in"))
				{
					text = "in";
				}
				else if (Class22.smethod_10(string_0, int_0 + int_1 - 2, 2, "cm"))
				{
					text = "cm";
				}
				else if (Class22.smethod_10(string_0, int_0 + int_1 - 2, 2, "mm"))
				{
					text = "mm";
				}
				else if (Class22.smethod_10(string_0, int_0 + int_1 - 2, 2, "pc"))
				{
					text = "pc";
				}
				if (text != null && Class31.smethod_0(string_0, int_0, int_1 - 2))
				{
					return string_0.Substring(int_0, int_1);
				}
			}
			else
			{
				if (Class22.smethod_10(string_0, int_0, int_1, "thin"))
				{
					return "thin";
				}
				if (Class22.smethod_10(string_0, int_0, int_1, "medium"))
				{
					return "medium";
				}
				if (Class22.smethod_10(string_0, int_0, int_1, "thick"))
				{
					return "thick";
				}
			}
			return null;
		}

		private static string smethod_12(string string_0, int int_0, int int_1)
		{
			if (Class22.smethod_10(string_0, int_0, int_1, "none"))
			{
				return "none";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "solid"))
			{
				return "solid";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "hidden"))
			{
				return "hidden";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "dotted"))
			{
				return "dotted";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "dashed"))
			{
				return "dashed";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "double"))
			{
				return "double";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "groove"))
			{
				return "groove";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "ridge"))
			{
				return "ridge";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "inset"))
			{
				return "inset";
			}
			if (Class22.smethod_10(string_0, int_0, int_1, "outset"))
			{
				return "outset";
			}
			return null;
		}

		private string method_16(string string_0, int int_0, int int_1)
		{
			RColor rcolor_;
			return this.class31_0.method_2(string_0, int_0, int_1, out rcolor_) ? string_0.Substring(int_0, int_1) : null;
		}
	}
}

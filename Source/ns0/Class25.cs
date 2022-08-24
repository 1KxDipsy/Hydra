using System;
using System.Collections.Generic;
using System.Text;
using ns10;
using ns13;
using ns16;

namespace ns0
{
	internal sealed class Class25
	{
		public static bool smethod_0(Class50 class50_0, RPoint rpoint_0)
		{
			foreach (KeyValuePair<Class58, RRect> item in class50_0.Dictionary_0)
			{
				if (item.Value.Contains(rpoint_0))
				{
					return true;
				}
			}
			foreach (Class50 item2 in class50_0.List_0)
			{
				if (Class25.smethod_0(item2, rpoint_0))
				{
					return true;
				}
			}
			return false;
		}

		public static bool smethod_1(Class50 class50_0)
		{
			foreach (Class50 item in class50_0.List_0)
			{
				if (!item.Boolean_2)
				{
					return false;
				}
			}
			return true;
		}

		public static Class50 smethod_2(Class50 class50_0, string string_0, Class50 class50_1)
		{
			if (class50_1 == null)
			{
				return class50_0;
			}
			if (class50_1.Class63_0 != null && class50_1.Class63_0.String_0.Equals(string_0, StringComparison.CurrentCultureIgnoreCase))
			{
				return class50_1.Class50_0 ?? class50_0;
			}
			return Class25.smethod_2(class50_0, string_0, class50_1.Class50_0);
		}

		public static Class50 smethod_3(Class50 class50_0)
		{
			if (class50_0.Class50_0 != null)
			{
				int num = class50_0.Class50_0.List_0.IndexOf(class50_0);
				if (num > 0)
				{
					int num2 = 1;
					Class50 @class = class50_0.Class50_0.List_0[num - 1];
					while ((@class.String_41 == "none" || @class.String_45 == "absolute" || @class.String_45 == "fixed") && num - num2 - 1 >= 0)
					{
						@class = class50_0.Class50_0.List_0[num - ++num2];
					}
					return (@class.String_41 == "none" || @class.String_45 == "fixed") ? null : @class;
				}
			}
			return null;
		}

		public static Class50 smethod_4(Class50 class50_0)
		{
			Class50 @class = class50_0;
			int num = @class.Class50_0.List_0.IndexOf(@class);
			while (@class.Class50_0 != null && num < 1 && @class.String_41 != "block" && @class.String_41 != "table" && @class.String_41 != "table-cell" && @class.String_41 != "list-item")
			{
				@class = @class.Class50_0;
				num = ((@class.Class50_0 != null) ? @class.Class50_0.List_0.IndexOf(@class) : (-1));
			}
			@class = @class.Class50_0;
			if (@class != null && num > 0)
			{
				int num2 = 1;
				Class50 class2 = @class.List_0[num - 1];
				while ((class2.String_41 == "none" || class2.String_45 == "absolute" || class2.String_45 == "fixed") && num - num2 - 1 >= 0)
				{
					class2 = @class.List_0[num - ++num2];
				}
				return (class2.String_41 == "none") ? null : class2;
			}
			return null;
		}

		public static bool smethod_5(Class50 class50_0)
		{
			if (!class50_0.List_3[0].Boolean_3 && class50_0.List_3[0].Boolean_1 && class50_0.Boolean_2)
			{
				Class50 @class = Class25.smethod_4(class50_0);
				if (@class != null && @class.Boolean_2)
				{
					return true;
				}
			}
			return false;
		}

		public static Class50 smethod_6(Class50 class50_0)
		{
			Class50 result = null;
			if (class50_0.Class50_0 != null)
			{
				for (int i = class50_0.Class50_0.List_0.IndexOf(class50_0) + 1; i <= class50_0.Class50_0.List_0.Count - 1; i++)
				{
					Class50 @class = class50_0.Class50_0.List_0[i];
					if (@class.String_41 != "none" && @class.String_45 != "absolute" && @class.String_45 != "fixed")
					{
						result = @class;
						break;
					}
				}
			}
			return result;
		}

		public static string smethod_7(Class50 class50_0, string string_0)
		{
			string text = null;
			while (class50_0 != null && text == null)
			{
				text = class50_0.method_14(string_0, null);
				class50_0 = class50_0.Class50_0;
			}
			return text;
		}

		public static Class50 smethod_8(Class50 class50_0, RPoint rpoint_0, bool bool_0 = true)
		{
			if (class50_0 != null && (!bool_0 || class50_0.String_52 == "visible") && (class50_0.RRect_0.IsEmpty || class50_0.RRect_0.Contains(rpoint_0)))
			{
				foreach (Class50 item in class50_0.List_0)
				{
					if (Class22.smethod_5(class50_0.Dictionary_0, class50_0.RRect_0).Contains(rpoint_0))
					{
						return Class25.smethod_8(item, rpoint_0) ?? item;
					}
				}
			}
			return null;
		}

		public static void smethod_9(Class50 class50_0, List<Class50> list_0)
		{
			if (class50_0 == null)
			{
				return;
			}
			if (class50_0.Boolean_7 && class50_0.String_52 == "visible")
			{
				list_0.Add(class50_0);
			}
			foreach (Class50 item in class50_0.List_0)
			{
				Class25.smethod_9(item, list_0);
			}
		}

		public static Class50 smethod_10(Class50 class50_0, RPoint rpoint_0)
		{
			if (class50_0 != null)
			{
				if (class50_0.Boolean_7 && class50_0.String_52 == "visible" && Class25.smethod_0(class50_0, rpoint_0))
				{
					return class50_0;
				}
				if (class50_0.RRect_1.IsEmpty || class50_0.RRect_1.Contains(rpoint_0))
				{
					foreach (Class50 item in class50_0.List_0)
					{
						Class50 @class = Class25.smethod_10(item, rpoint_0);
						if (@class != null)
						{
							return @class;
						}
					}
				}
			}
			return null;
		}

		public static Class50 smethod_11(Class50 class50_0, string string_0)
		{
			if (class50_0 != null && !string.IsNullOrEmpty(string_0))
			{
				if (class50_0.Class63_0 != null && string_0.Equals(class50_0.Class63_0.method_2("id"), StringComparison.OrdinalIgnoreCase))
				{
					return class50_0;
				}
				foreach (Class50 item in class50_0.List_0)
				{
					Class50 @class = Class25.smethod_11(item, string_0);
					if (@class != null)
					{
						return @class;
					}
				}
			}
			return null;
		}

		public static Class58 smethod_12(Class50 class50_0, RPoint rpoint_0)
		{
			Class58 @class = null;
			if (class50_0 != null)
			{
				if (class50_0.List_1.Count > 0 && (class50_0.Class63_0 == null || class50_0.Class63_0.String_0 != "td" || class50_0.RRect_0.Contains(rpoint_0)))
				{
					foreach (Class58 item in class50_0.List_1)
					{
						foreach (KeyValuePair<Class50, RRect> item2 in item.Dictionary_0)
						{
							if (item2.Value.Top <= rpoint_0.Double_1)
							{
								@class = item;
							}
							if (item2.Value.Top > rpoint_0.Double_1)
							{
								return @class;
							}
						}
					}
				}
				foreach (Class50 item3 in class50_0.List_0)
				{
					@class = Class25.smethod_12(item3, rpoint_0) ?? @class;
				}
			}
			return @class;
		}

		public static Class59 smethod_13(Class50 class50_0, RPoint rpoint_0)
		{
			if (class50_0 != null && class50_0.String_52 == "visible")
			{
				if (class50_0.List_1.Count > 0)
				{
					foreach (Class58 item in class50_0.List_1)
					{
						Class59 @class = Class25.smethod_14(item, rpoint_0);
						if (@class != null)
						{
							return @class;
						}
					}
				}
				if (class50_0.RRect_1.IsEmpty || class50_0.RRect_1.Contains(rpoint_0))
				{
					foreach (Class50 item2 in class50_0.List_0)
					{
						Class59 class2 = Class25.smethod_13(item2, rpoint_0);
						if (class2 != null)
						{
							return class2;
						}
					}
				}
			}
			return null;
		}

		public static Class59 smethod_14(Class58 class58_0, RPoint rpoint_0)
		{
			foreach (KeyValuePair<Class50, RRect> item in class58_0.Dictionary_0)
			{
				foreach (Class59 item2 in item.Key.List_3)
				{
					RRect rRect_ = item2.RRect_0;
					rRect_.Width += item2.Class50_0.Double_26;
					if (rRect_.Contains(rpoint_0))
					{
						return item2;
					}
				}
			}
			return null;
		}

		public static Class58 smethod_15(Class59 class59_0)
		{
			Class50 class50_ = class59_0.Class50_0;
			while (class50_.List_1.Count == 0)
			{
				class50_ = class50_.Class50_0;
			}
			foreach (Class58 item in class50_.List_1)
			{
				foreach (Class59 item2 in item.List_1)
				{
					if (item2 == class59_0)
					{
						return item;
					}
				}
			}
			return class50_.List_1[0];
		}

		public static string smethod_16(Class50 class50_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			return stringBuilder.ToString(0, Class25.smethod_19(stringBuilder, class50_0)).Trim();
		}

		public static string smethod_17(Class50 class50_0, HtmlGenerationStyle htmlGenerationStyle_0 = HtmlGenerationStyle.Inline, bool bool_0 = false)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (class50_0 != null)
			{
				Dictionary<Class50, bool> dictionary_ = (bool_0 ? Class25.smethod_20(class50_0) : null);
				Class25.smethod_24(class50_1: bool_0 ? Class25.smethod_22(class50_0, dictionary_) : null, class30_0: class50_0.HtmlContainerInt_0.Class30_0, stringBuilder_0: stringBuilder, class50_0: class50_0, htmlGenerationStyle_0: htmlGenerationStyle_0, dictionary_0: dictionary_);
			}
			return stringBuilder.ToString();
		}

		public static string smethod_18(Class50 class50_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Class25.smethod_29(class50_0, stringBuilder, 0);
			return stringBuilder.ToString();
		}

		private static int smethod_19(StringBuilder stringBuilder_0, Class50 class50_0)
		{
			int num = 0;
			foreach (Class59 item in class50_0.List_3)
			{
				if (item.Boolean_0)
				{
					stringBuilder_0.Append(Class25.smethod_28(item, bool_0: true));
					num = stringBuilder_0.Length;
				}
			}
			if (class50_0.List_0.Count < 1 && class50_0.Class29_0 != null && class50_0.Class29_0.method_2())
			{
				stringBuilder_0.Append(' ');
			}
			if (class50_0.String_52 != "hidden" && class50_0.String_41 != "none")
			{
				foreach (Class50 item2 in class50_0.List_0)
				{
					num = Math.Max(num, Class25.smethod_19(stringBuilder_0, item2));
				}
			}
			if (stringBuilder_0.Length > 0)
			{
				if (class50_0.Class63_0 != null && class50_0.Class63_0.String_0 == "hr")
				{
					if (stringBuilder_0.Length > 1 && stringBuilder_0[stringBuilder_0.Length - 1] != '\n')
					{
						stringBuilder_0.AppendLine();
					}
					stringBuilder_0.AppendLine(new string('-', 80));
				}
				if ((class50_0.String_41 == "block" || class50_0.String_41 == "list-item" || class50_0.String_41 == "table-row") && (!class50_0.Boolean_1 || stringBuilder_0.Length <= 1 || stringBuilder_0[stringBuilder_0.Length - 1] != '\n'))
				{
					stringBuilder_0.AppendLine();
				}
				if (class50_0.String_41 == "table-cell")
				{
					stringBuilder_0.Append(' ');
				}
				if (class50_0.Class63_0 != null && class50_0.Class63_0.String_0 == "p")
				{
					int num2 = 0;
					int num3 = stringBuilder_0.Length - 1;
					while (num3 >= 0 && char.IsWhiteSpace(stringBuilder_0[num3]))
					{
						num2 += ((stringBuilder_0[num3] == '\n') ? 1 : 0);
						num3--;
					}
					if (num2 < 2)
					{
						stringBuilder_0.AppendLine();
					}
				}
			}
			return num;
		}

		private static Dictionary<Class50, bool> smethod_20(Class50 class50_0)
		{
			Dictionary<Class50, bool> dictionary = new Dictionary<Class50, bool>();
			Class25.smethod_21(class50_0, dictionary, new Dictionary<Class50, bool>());
			return dictionary;
		}

		private static bool smethod_21(Class50 class50_0, Dictionary<Class50, bool> dictionary_0, Dictionary<Class50, bool> dictionary_1)
		{
			bool result = false;
			foreach (Class59 item in class50_0.List_3)
			{
				if (!item.Boolean_0)
				{
					continue;
				}
				dictionary_0[class50_0] = true;
				foreach (KeyValuePair<Class50, bool> item2 in dictionary_1)
				{
					dictionary_0[item2.Key] = item2.Value;
				}
				dictionary_1.Clear();
				result = true;
			}
			foreach (Class50 item3 in class50_0.List_0)
			{
				if (Class25.smethod_21(item3, dictionary_0, dictionary_1))
				{
					dictionary_0[class50_0] = true;
					result = true;
				}
			}
			if (class50_0.Class63_0 != null && dictionary_0.Count > 0)
			{
				dictionary_1[class50_0] = true;
			}
			return result;
		}

		private static Class50 smethod_22(Class50 class50_0, Dictionary<Class50, bool> dictionary_0)
		{
			Class50 @class = class50_0;
			Class50 class2 = class50_0;
			while (true)
			{
				bool flag = false;
				Class50 class3 = null;
				foreach (Class50 item in class2.List_0)
				{
					if (dictionary_0.ContainsKey(item))
					{
						if (class3 != null)
						{
							flag = true;
							break;
						}
						class3 = item;
					}
				}
				if (flag || class3 == null)
				{
					break;
				}
				class2 = class3;
				if (class2.Class63_0 != null)
				{
					@class = class2;
				}
			}
			if (!Class25.smethod_23(@class))
			{
				class2 = @class.Class50_0;
				while (class2.Class50_0 != null && class2.Class63_0 == null)
				{
					class2 = class2.Class50_0;
				}
				if (class2.Class63_0 != null)
				{
					@class = class2;
				}
			}
			return @class;
		}

		private static bool smethod_23(Class50 class50_0)
		{
			foreach (Class50 item in class50_0.List_0)
			{
				if (item.Class63_0 != null || Class25.smethod_23(item))
				{
					return true;
				}
			}
			return false;
		}

		private static void smethod_24(Class30 class30_0, StringBuilder stringBuilder_0, Class50 class50_0, HtmlGenerationStyle htmlGenerationStyle_0, Dictionary<Class50, bool> dictionary_0, Class50 class50_1)
		{
			if (class50_0.Class63_0 != null && dictionary_0 != null && !dictionary_0.ContainsKey(class50_0))
			{
				return;
			}
			if (class50_0.Class63_0 != null)
			{
				if (class50_0.Class63_0.String_0 != "link" || !class50_0.Class63_0.Dictionary_0.ContainsKey("href") || (!class50_0.Class63_0.Dictionary_0["href"].StartsWith("property") && !class50_0.Class63_0.Dictionary_0["href"].StartsWith("method")))
				{
					Class25.smethod_25(class30_0, stringBuilder_0, class50_0, htmlGenerationStyle_0);
					if (class50_0 == class50_1)
					{
						stringBuilder_0.Append("<!--StartFragment-->");
					}
				}
				if (htmlGenerationStyle_0 == HtmlGenerationStyle.InHeader && class50_0.Class63_0.String_0 == "html" && class50_0.HtmlContainerInt_0.CssData != null)
				{
					stringBuilder_0.AppendLine("<head>");
					Class25.smethod_27(stringBuilder_0, class50_0.HtmlContainerInt_0.CssData);
					stringBuilder_0.AppendLine("</head>");
				}
			}
			if (class50_0.List_3.Count > 0)
			{
				foreach (Class59 item in class50_0.List_3)
				{
					if (dictionary_0 == null || item.Boolean_0)
					{
						stringBuilder_0.Append(Class27.smethod_2(Class25.smethod_28(item, dictionary_0 != null)));
					}
				}
			}
			foreach (Class50 item2 in class50_0.List_0)
			{
				Class25.smethod_24(class30_0, stringBuilder_0, item2, htmlGenerationStyle_0, dictionary_0, class50_1);
			}
			if (class50_0.Class63_0 != null && !class50_0.Class63_0.Boolean_0)
			{
				if (class50_0 == class50_1)
				{
					stringBuilder_0.Append("<!--EndFragment-->");
				}
				stringBuilder_0.AppendFormat("</{0}>", class50_0.Class63_0.String_0);
			}
		}

		private static void smethod_25(Class30 class30_0, StringBuilder stringBuilder_0, Class50 class50_0, HtmlGenerationStyle htmlGenerationStyle_0)
		{
			stringBuilder_0.AppendFormat("<{0}", class50_0.Class63_0.String_0);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			IEnumerable<CssBlock> cssBlock = class50_0.HtmlContainerInt_0.CssData.GetCssBlock(class50_0.Class63_0.String_0);
			if (cssBlock != null)
			{
				foreach (CssBlock item in cssBlock)
				{
					foreach (KeyValuePair<string, string> property in item.Properties)
					{
						dictionary[property.Key] = property.Value;
					}
				}
			}
			if (class50_0.Class63_0.method_0())
			{
				stringBuilder_0.Append(" ");
				foreach (KeyValuePair<string, string> item2 in class50_0.Class63_0.Dictionary_0)
				{
					if (htmlGenerationStyle_0 == HtmlGenerationStyle.Inline && item2.Key == "style")
					{
						foreach (KeyValuePair<string, string> property2 in class30_0.method_2(class50_0.Class63_0.String_0, class50_0.Class63_0.method_2("style")).Properties)
						{
							dictionary[property2.Key] = property2.Value;
						}
					}
					else if (htmlGenerationStyle_0 == HtmlGenerationStyle.Inline && item2.Key == "class")
					{
						IEnumerable<CssBlock> cssBlock2 = class50_0.HtmlContainerInt_0.CssData.GetCssBlock("." + item2.Value);
						if (cssBlock2 == null)
						{
							continue;
						}
						foreach (CssBlock item3 in cssBlock2)
						{
							foreach (KeyValuePair<string, string> property3 in item3.Properties)
							{
								dictionary[property3.Key] = property3.Value;
							}
						}
					}
					else
					{
						stringBuilder_0.AppendFormat("{0}=\"{1}\" ", item2.Key, item2.Value);
					}
				}
				stringBuilder_0.Remove(stringBuilder_0.Length - 1, 1);
			}
			if (htmlGenerationStyle_0 == HtmlGenerationStyle.Inline && dictionary.Count > 0)
			{
				Dictionary<string, string> dictionary2 = Class25.smethod_26(class50_0, dictionary);
				if (dictionary2.Count > 0)
				{
					stringBuilder_0.Append(" style=\"");
					foreach (KeyValuePair<string, string> item4 in dictionary2)
					{
						stringBuilder_0.AppendFormat("{0}: {1}; ", item4.Key, item4.Value);
					}
					stringBuilder_0.Remove(stringBuilder_0.Length - 1, 1);
					stringBuilder_0.Append("\"");
				}
			}
			stringBuilder_0.AppendFormat("{0}>", class50_0.Class63_0.Boolean_0 ? "/" : "");
		}

		private static Dictionary<string, string> smethod_26(Class50 class50_0, Dictionary<string, string> dictionary_0)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			IEnumerable<CssBlock> cssBlock = class50_0.HtmlContainerInt_0.RAdapter_0.DefaultCssData.GetCssBlock(class50_0.Class63_0.String_0);
			foreach (KeyValuePair<string, string> item in dictionary_0)
			{
				bool flag = false;
				foreach (CssBlock item2 in cssBlock)
				{
					if (item2.Properties.TryGetValue(item.Key, out var value) && value.Equals(item.Value, StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					dictionary[item.Key] = item.Value;
				}
			}
			return dictionary;
		}

		private static void smethod_27(StringBuilder stringBuilder_0, CssData cssData_0)
		{
			stringBuilder_0.AppendLine("<style type=\"text/css\">");
			foreach (KeyValuePair<string, List<CssBlock>> item in cssData_0.IDictionary_0["all"])
			{
				stringBuilder_0.Append(item.Key);
				stringBuilder_0.Append(" { ");
				foreach (CssBlock item2 in item.Value)
				{
					foreach (KeyValuePair<string, string> property in item2.Properties)
					{
						stringBuilder_0.AppendFormat("{0}: {1};", property.Key, property.Value);
					}
				}
				stringBuilder_0.Append(" }");
				stringBuilder_0.AppendLine();
			}
			stringBuilder_0.AppendLine("</style>");
		}

		private static string smethod_28(Class59 class59_0, bool bool_0)
		{
			if (bool_0 && class59_0.Int32_0 > -1 && class59_0.Int32_1 > -1)
			{
				return class59_0.String_0.Substring(class59_0.Int32_0, class59_0.Int32_1 - class59_0.Int32_0);
			}
			if (bool_0 && class59_0.Int32_0 > -1)
			{
				return class59_0.String_0.Substring(class59_0.Int32_0) + (class59_0.Boolean_2 ? " " : "");
			}
			if (bool_0 && class59_0.Int32_1 > -1)
			{
				return class59_0.String_0.Substring(0, class59_0.Int32_1);
			}
			if (class59_0.Class50_0.List_3[0] != class59_0)
			{
				if (!class59_0.Boolean_1)
				{
					goto IL_00c4;
				}
			}
			else if (!Class25.smethod_5(class59_0.Class50_0))
			{
				goto IL_00c4;
			}
			object obj = " ";
			goto IL_00d0;
			IL_00c4:
			obj = "";
			goto IL_00d0;
			IL_00d0:
			return (string)obj + class59_0.String_0 + (class59_0.Boolean_2 ? " " : "");
		}

		private static void smethod_29(Class50 class50_0, StringBuilder stringBuilder_0, int int_0)
		{
			stringBuilder_0.AppendFormat("{0}<{1}", new string(' ', 2 * int_0), class50_0.String_41);
			if (class50_0.Class63_0 != null)
			{
				stringBuilder_0.AppendFormat(" element=\"{0}\"", (class50_0.Class63_0 != null) ? class50_0.Class63_0.String_0 : string.Empty);
			}
			if (class50_0.List_3.Count > 0)
			{
				stringBuilder_0.AppendFormat(" words=\"{0}\"", class50_0.List_3.Count);
			}
			stringBuilder_0.AppendFormat("{0}>\r\n", (class50_0.List_0.Count > 0) ? "" : "/");
			if (class50_0.List_0.Count <= 0)
			{
				return;
			}
			foreach (Class50 item in class50_0.List_0)
			{
				Class25.smethod_29(item, stringBuilder_0, int_0 + 1);
			}
			stringBuilder_0.AppendFormat("{0}</{1}>\r\n", new string(' ', 2 * int_0), class50_0.String_41);
		}
	}
}

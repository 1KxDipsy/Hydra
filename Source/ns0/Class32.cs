using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using ns10;
using ns11;
using ns13;
using ns16;

namespace ns0
{
	internal sealed class Class32
	{
		[CompilerGenerated]
		private sealed class Class33
		{
			public string string_0;

			internal void method_0(Class50 class50_0)
			{
				class50_0.String_5 = (class50_0.String_7 = (class50_0.String_6 = (class50_0.String_4 = "solid")));
				class50_0.String_1 = (class50_0.String_3 = (class50_0.String_2 = (class50_0.String_0 = this.string_0)));
			}
		}

		[CompilerGenerated]
		private sealed class Class34
		{
			public string string_0;

			internal void method_0(Class50 class50_0)
			{
				class50_0.String_24 = (class50_0.String_26 = (class50_0.String_25 = (class50_0.String_23 = this.string_0)));
			}
		}

		private readonly Class30 class30_0;

		public Class32(Class30 class30_1)
		{
			ArgChecker.AssertArgNotNull(class30_1, "cssParser");
			this.class30_0 = class30_1;
		}

		public Class50 method_0(string string_0, HtmlContainerInt htmlContainerInt_0, ref CssData cssData_0)
		{
			Class50 @class = Class35.smethod_0(string_0);
			if (@class != null)
			{
				@class.HtmlContainerInt_0 = htmlContainerInt_0;
				bool bool_ = false;
				this.method_1(@class, htmlContainerInt_0, ref cssData_0, ref bool_);
				this.method_2(@class, cssData_0);
				this.method_3(htmlContainerInt_0, cssData_0);
				Class32.smethod_11(@class);
				Class32.smethod_12(@class);
				bool bool_2 = true;
				Class32.smethod_13(@class, ref bool_2);
				Class32.smethod_17(@class);
				Class32.smethod_14(@class);
				Class32.smethod_17(@class);
			}
			return @class;
		}

		private void method_1(Class50 class50_0, HtmlContainerInt htmlContainerInt_0, ref CssData cssData_0, ref bool bool_0)
		{
			if (class50_0.Class63_0 != null)
			{
				if (class50_0.Class63_0.String_0.Equals("link", StringComparison.CurrentCultureIgnoreCase) && class50_0.method_14("rel", string.Empty).Equals("stylesheet", StringComparison.CurrentCultureIgnoreCase))
				{
					Class32.smethod_6(ref cssData_0, ref bool_0);
					Class46.smethod_0(htmlContainerInt_0, class50_0.method_14("href", string.Empty), class50_0.Class63_0.Dictionary_0, out var string_, out var cssData_);
					if (string_ != null)
					{
						this.class30_0.method_1(cssData_0, string_);
					}
					else if (cssData_ != null)
					{
						cssData_0.Combine(cssData_);
					}
				}
				if (class50_0.Class63_0.String_0.Equals("style", StringComparison.CurrentCultureIgnoreCase) && class50_0.List_0.Count > 0)
				{
					Class32.smethod_6(ref cssData_0, ref bool_0);
					foreach (Class50 item in class50_0.List_0)
					{
						this.class30_0.method_1(cssData_0, item.Class29_0.method_3());
					}
				}
			}
			foreach (Class50 item2 in class50_0.List_0)
			{
				this.method_1(item2, htmlContainerInt_0, ref cssData_0, ref bool_0);
			}
		}

		private void method_2(Class50 class50_0, CssData cssData_0)
		{
			class50_0.method_19();
			if (class50_0.Class63_0 != null)
			{
				Class32.smethod_1(class50_0, cssData_0, "*");
				Class32.smethod_1(class50_0, cssData_0, class50_0.Class63_0.String_0);
				if (class50_0.Class63_0.method_1("class"))
				{
					Class32.smethod_0(class50_0, cssData_0);
				}
				if (class50_0.Class63_0.method_1("id"))
				{
					Class32.smethod_1(class50_0, cssData_0, "#" + class50_0.Class63_0.method_2("id"));
				}
				this.method_4(class50_0.Class63_0, class50_0);
				if (class50_0.Class63_0.method_1("style"))
				{
					CssBlock cssBlock = this.class30_0.method_2(class50_0.Class63_0.String_0, class50_0.Class63_0.method_2("style"));
					if (cssBlock != null)
					{
						Class32.smethod_4(class50_0, cssBlock);
					}
				}
			}
			if (class50_0.String_50 != string.Empty && class50_0.Class29_0 == null)
			{
				foreach (Class50 item in class50_0.List_0)
				{
					item.String_50 = class50_0.String_50;
				}
				class50_0.String_50 = string.Empty;
			}
			foreach (Class50 item2 in class50_0.List_0)
			{
				this.method_2(item2, cssData_0);
			}
		}

		private void method_3(HtmlContainerInt htmlContainerInt_0, CssData cssData_0)
		{
			htmlContainerInt_0.RColor_0 = RColor.Empty;
			htmlContainerInt_0.RColor_1 = RColor.Empty;
			if (!cssData_0.ContainsCssBlock("::selection"))
			{
				return;
			}
			foreach (CssBlock item in cssData_0.GetCssBlock("::selection"))
			{
				if (item.Properties.ContainsKey("color"))
				{
					htmlContainerInt_0.RColor_0 = this.class30_0.method_4(item.Properties["color"]);
				}
				if (item.Properties.ContainsKey("background-color"))
				{
					htmlContainerInt_0.RColor_1 = this.class30_0.method_4(item.Properties["background-color"]);
				}
			}
		}

		private static void smethod_0(Class50 class50_0, CssData cssData_0)
		{
			string text = class50_0.Class63_0.method_2("class");
			int i = 0;
			while (i < text.Length)
			{
				for (; i < text.Length && text[i] == ' '; i++)
				{
				}
				if (i < text.Length)
				{
					int num = text.IndexOf(' ', i);
					if (num < 0)
					{
						num = text.Length;
					}
					string text2 = "." + text.Substring(i, num - i);
					Class32.smethod_1(class50_0, cssData_0, text2);
					Class32.smethod_1(class50_0, cssData_0, class50_0.Class63_0.String_0 + text2);
					i = num + 1;
				}
			}
		}

		private static void smethod_1(Class50 class50_0, CssData cssData_0, string string_0)
		{
			foreach (CssBlock item in cssData_0.GetCssBlock(string_0))
			{
				if (Class32.smethod_2(class50_0, item))
				{
					Class32.smethod_4(class50_0, item);
				}
			}
		}

		private static bool smethod_2(Class50 class50_0, CssBlock cssBlock_0)
		{
			bool flag = true;
			if (cssBlock_0.Selectors != null)
			{
				flag = Class32.smethod_3(class50_0, cssBlock_0);
			}
			else if (class50_0.Class63_0.String_0.Equals("a", StringComparison.OrdinalIgnoreCase) && cssBlock_0.Class.Equals("a", StringComparison.OrdinalIgnoreCase) && !class50_0.Class63_0.method_1("href"))
			{
				flag = false;
			}
			if (flag && cssBlock_0.Hover)
			{
				class50_0.HtmlContainerInt_0.method_4(class50_0, cssBlock_0);
				flag = false;
			}
			return flag;
		}

		private static bool smethod_3(Class50 class50_0, CssBlock cssBlock_0)
		{
			foreach (CssBlockSelectorItem selector in cssBlock_0.Selectors)
			{
				bool flag = false;
				while (!flag)
				{
					class50_0 = class50_0.Class50_0;
					while (class50_0 != null && class50_0.Class63_0 == null)
					{
						class50_0 = class50_0.Class50_0;
					}
					if (class50_0 != null)
					{
						if (class50_0.Class63_0.String_0.Equals(selector.Class, StringComparison.InvariantCultureIgnoreCase))
						{
							flag = true;
						}
						if (!flag && class50_0.Class63_0.method_1("class"))
						{
							string text = class50_0.Class63_0.method_2("class");
							if (selector.Class.Equals("." + text, StringComparison.InvariantCultureIgnoreCase) || selector.Class.Equals(class50_0.Class63_0.String_0 + "." + text, StringComparison.InvariantCultureIgnoreCase))
							{
								flag = true;
							}
						}
						if (!flag && class50_0.Class63_0.method_1("id"))
						{
							string text2 = class50_0.Class63_0.method_2("id");
							if (selector.Class.Equals("#" + text2, StringComparison.InvariantCultureIgnoreCase))
							{
								flag = true;
							}
						}
						if (!flag && selector.DirectParent)
						{
							return false;
						}
						continue;
					}
					return false;
				}
			}
			return true;
		}

		private static void smethod_4(Class50 class50_0, CssBlock cssBlock_0)
		{
			foreach (KeyValuePair<string, string> property in cssBlock_0.Properties)
			{
				string string_ = property.Value;
				if (property.Value == "inherit" && class50_0.Class50_0 != null)
				{
					string_ = Class24.smethod_1(class50_0.Class50_0, property.Key);
				}
				if (Class32.smethod_5(class50_0, property.Key, string_))
				{
					Class24.smethod_2(class50_0, property.Key, string_);
				}
			}
		}

		private static bool smethod_5(Class50 class50_0, string string_0, string string_1)
		{
			if (class50_0.Class63_0 != null && string_0 == "display")
			{
				string string_2 = class50_0.Class63_0.String_0;
				uint num = Class75.smethod_0(string_2);
				if (num <= 1251777503)
				{
					if (num <= 1027948613)
					{
						if (num != 150307336)
						{
							if (num == 1027948613 && string_2 == "td")
							{
								goto IL_00fb;
							}
						}
						else if (string_2 == "colgroup")
						{
							return string_1 == "table-column-group";
						}
					}
					else if (num != 1095059089)
					{
						switch (num)
						{
						case 1251777503u:
							if (string_2 == "table")
							{
								return string_1 == "table";
							}
							break;
						case 1195724803u:
							if (string_2 == "tr")
							{
								return string_1 == "table-row";
							}
							break;
						}
					}
					else if (string_2 == "th")
					{
						goto IL_00fb;
					}
				}
				else
				{
					switch (num)
					{
					case 2853211801u:
						if (string_2 == "thead")
						{
							return string_1 == "table-header-group";
						}
						break;
					case 2340213611u:
						if (string_2 == "tbody")
						{
							return string_1 == "table-row-group";
						}
						break;
					case 4069381233u:
						if (string_2 == "col")
						{
							return string_1 == "table-column";
						}
						break;
					case 4011007077u:
						if (string_2 == "caption")
						{
							return string_1 == "table-caption";
						}
						break;
					case 3216274459u:
						if (string_2 == "tfoot")
						{
							return string_1 == "table-footer-group";
						}
						break;
					}
				}
			}
			return true;
			IL_00fb:
			return string_1 == "table-cell";
		}

		private static void smethod_6(ref CssData cssData_0, ref bool bool_0)
		{
			if (!bool_0)
			{
				bool_0 = true;
				cssData_0 = cssData_0.Clone();
			}
		}

		private void method_4(Class63 class63_0, Class50 class50_0)
		{
			if (!class63_0.method_0())
			{
				return;
			}
			foreach (string key in class63_0.Dictionary_0.Keys)
			{
				string text = class63_0.Dictionary_0[key];
				string text2 = key;
				switch (Class75.smethod_0(text2))
				{
				case 410724115u:
					if (text2 == "hspace")
					{
						class50_0.String_21 = (class50_0.String_20 = Class32.smethod_7(text));
					}
					break;
				case 292255708u:
					if (text2 == "face")
					{
						class50_0.String_55 = this.class30_0.method_3(text);
					}
					break;
				case 597743964u:
					if (text2 == "size")
					{
						if (class63_0.String_0.Equals("hr", StringComparison.OrdinalIgnoreCase))
						{
							class50_0.String_32 = Class32.smethod_7(text);
						}
						else if (class63_0.String_0.Equals("font", StringComparison.OrdinalIgnoreCase))
						{
							class50_0.String_56 = text;
						}
					}
					break;
				case 525480503u:
					if (!(text2 == "border"))
					{
						break;
					}
					if (!string.IsNullOrEmpty(text) && text != "0")
					{
						class50_0.String_5 = (class50_0.String_7 = (class50_0.String_6 = (class50_0.String_4 = "solid")));
					}
					class50_0.String_1 = (class50_0.String_3 = (class50_0.String_2 = (class50_0.String_0 = Class32.smethod_7(text))));
					if (class63_0.String_0 == "table")
					{
						if (text != "0")
						{
							Class32.smethod_8(class50_0, "1px");
						}
					}
					else
					{
						class50_0.String_7 = (class50_0.String_5 = (class50_0.String_6 = (class50_0.String_4 = "solid")));
					}
					break;
				case 1269553309u:
					if (text2 == "background")
					{
						class50_0.String_34 = text.ToLower();
					}
					break;
				case 1031692888u:
					if (text2 == "color")
					{
						class50_0.String_39 = text.ToLower();
					}
					break;
				case 1613521886u:
					if (text2 == "align")
					{
						switch (text)
						{
						default:
							class50_0.String_47 = text.ToLower();
							break;
						case "left":
						case "center":
						case "right":
						case "justify":
							class50_0.String_49 = text.ToLower();
							break;
						}
					}
					break;
				case 1520291810u:
					if (text2 == "valign")
					{
						class50_0.String_47 = text.ToLower();
					}
					break;
				case 1650154374u:
					if (text2 == "bordercolor")
					{
						class50_0.String_9 = (class50_0.String_11 = (class50_0.String_10 = (class50_0.String_8 = text.ToLower())));
					}
					break;
				case 1618420134u:
					if (text2 == "cellpadding")
					{
						Class32.smethod_9(class50_0, text);
					}
					break;
				case 2508680735u:
					if (text2 == "width")
					{
						class50_0.String_30 = Class32.smethod_7(text);
					}
					break;
				case 2386557534u:
					if (text2 == "nowrap")
					{
						class50_0.String_51 = "nowrap";
					}
					break;
				case 3427432841u:
					if (text2 == "bgcolor")
					{
						class50_0.String_33 = text.ToLower();
					}
					break;
				case 3397645134u:
					if (text2 == "cellspacing")
					{
						class50_0.String_12 = Class32.smethod_7(text);
					}
					break;
				case 4086697401u:
					if (text2 == "vspace")
					{
						class50_0.String_22 = (class50_0.String_19 = Class32.smethod_7(text));
					}
					break;
				case 3915559316u:
					if (text2 == "dir")
					{
						class50_0.String_42 = text.ToLower();
					}
					break;
				case 3585981250u:
					if (text2 == "height")
					{
						class50_0.String_32 = Class32.smethod_7(text);
					}
					break;
				}
			}
		}

		private static string smethod_7(string string_0)
		{
			if (new Class57(string_0).Boolean_0)
			{
				return string.Format(NumberFormatInfo.InvariantInfo, "{0}px", new object[1] { string_0 });
			}
			return string_0;
		}

		private static void smethod_8(Class50 class50_0, string string_0)
		{
			Class32.smethod_10(class50_0, delegate(Class50 class50_0)
			{
				class50_0.String_5 = (class50_0.String_7 = (class50_0.String_6 = (class50_0.String_4 = "solid")));
				class50_0.String_1 = (class50_0.String_3 = (class50_0.String_2 = (class50_0.String_0 = string_0)));
			});
		}

		private static void smethod_9(Class50 class50_0, string string_0)
		{
			string string_ = Class32.smethod_7(string_0);
			Class32.smethod_10(class50_0, delegate(Class50 class50_0)
			{
				class50_0.String_24 = (class50_0.String_26 = (class50_0.String_25 = (class50_0.String_23 = string_)));
			});
		}

		private static void smethod_10(Class50 class50_0, Delegate4<Class50> delegate4_0)
		{
			foreach (Class50 item in class50_0.List_0)
			{
				foreach (Class50 item2 in item.List_0)
				{
					if (item2.Class63_0 != null && item2.Class63_0.String_0 == "td")
					{
						delegate4_0(item2);
						continue;
					}
					foreach (Class50 item3 in item2.List_0)
					{
						delegate4_0(item3);
					}
				}
			}
		}

		private static void smethod_11(Class50 class50_0)
		{
			for (int num = class50_0.List_0.Count - 1; num >= 0; num--)
			{
				Class50 @class = class50_0.List_0[num];
				if (@class.Class29_0 != null)
				{
					if (@class.Class29_0.method_1() && !(@class.String_51 == "pre") && !(@class.String_51 == "pre-wrap") && class50_0.List_0.Count != 1 && (num <= 0 || num >= class50_0.List_0.Count - 1 || !class50_0.List_0[num - 1].Boolean_2 || !class50_0.List_0[num + 1].Boolean_2) && (num != 0 || class50_0.List_0.Count <= 1 || !class50_0.List_0[1].Boolean_2 || !class50_0.Boolean_2) && (num != class50_0.List_0.Count - 1 || class50_0.List_0.Count <= 1 || !class50_0.List_0[num - 1].Boolean_2 || !class50_0.Boolean_2))
					{
						@class.Class50_0.List_0.RemoveAt(num);
					}
					else
					{
						@class.method_9();
					}
				}
				else
				{
					Class32.smethod_11(@class);
				}
			}
		}

		private static void smethod_12(Class50 class50_0)
		{
			for (int num = class50_0.List_0.Count - 1; num >= 0; num--)
			{
				Class50 @class = class50_0.List_0[num];
				if (@class is Class53 && @class.String_41 == "block")
				{
					@class.Class50_0 = Class50.smethod_3(@class.Class50_0, null, @class);
					@class.String_41 = "inline";
				}
				else
				{
					Class32.smethod_12(@class);
				}
			}
		}

		private static void smethod_13(Class50 class50_0, ref bool bool_0)
		{
			bool_0 = bool_0 || class50_0.Boolean_3;
			foreach (Class50 item in class50_0.List_0)
			{
				Class32.smethod_13(item, ref bool_0);
				bool_0 = item.List_3.Count == 0 && (bool_0 || item.Boolean_3);
			}
			int num = -1;
			Class50 @class;
			do
			{
				@class = null;
				for (int i = 0; i < class50_0.List_0.Count; i++)
				{
					if (@class != null)
					{
						break;
					}
					if (i > num && class50_0.List_0[i].Boolean_1)
					{
						@class = class50_0.List_0[i];
						num = i;
					}
					else if (class50_0.List_0[i].List_3.Count > 0)
					{
						bool_0 = false;
					}
					else if (class50_0.List_0[i].Boolean_3)
					{
						bool_0 = true;
					}
				}
				if (@class != null)
				{
					@class.String_41 = "block";
					if (bool_0)
					{
						@class.String_32 = ".95em";
					}
				}
			}
			while (@class != null);
		}

		private static void smethod_14(Class50 class50_0)
		{
			try
			{
				if (Class25.smethod_1(class50_0) && !Class32.smethod_18(class50_0))
				{
					Class50 @class = Class32.smethod_15(class50_0);
					while (@class != null)
					{
						Class50 class2 = null;
						if (Class25.smethod_1(@class) && !Class32.smethod_18(@class))
						{
							class2 = Class32.smethod_15(@class);
						}
						@class.Class50_0.method_8(@class);
						@class.Class50_0 = null;
						@class = class2;
					}
				}
				if (Class25.smethod_1(class50_0))
				{
					return;
				}
				foreach (Class50 item in class50_0.List_0)
				{
					Class32.smethod_14(item);
				}
			}
			catch (Exception exception_)
			{
				class50_0.HtmlContainerInt_0.method_2(HtmlRenderErrorType.HtmlParsing, "Failed in block inside inline box correction", exception_);
			}
		}

		private static Class50 smethod_15(Class50 class50_0)
		{
			if (class50_0.String_41 == "inline")
			{
				class50_0.String_41 = "block";
			}
			if (class50_0.List_0.Count <= 1 && class50_0.List_0[0].List_0.Count <= 1)
			{
				if (class50_0.List_0[0].String_41 == "inline")
				{
					class50_0.List_0[0].String_41 = "block";
				}
			}
			else
			{
				Class50 @class = Class50.smethod_3(class50_0);
				while (Class32.smethod_18(class50_0.List_0[0]))
				{
					class50_0.List_0[0].Class50_0 = @class;
				}
				@class.method_7(class50_0.List_0[0]);
				Class50 class2 = class50_0.List_0[1];
				class2.Class50_0 = null;
				Class32.smethod_16(class50_0, class2, @class);
				if (@class.List_0.Count < 1)
				{
					@class.Class50_0 = null;
				}
				int num = ((@class.Class50_0 == null) ? 1 : 2);
				if (class50_0.List_0.Count > num)
				{
					Class50 class3 = Class50.smethod_1(class50_0, null, class50_0.List_0[num]);
					while (class50_0.List_0.Count > num + 1)
					{
						class50_0.List_0[num + 1].Class50_0 = class3;
					}
					return class3;
				}
			}
			return null;
		}

		private static void smethod_16(Class50 class50_0, Class50 class50_1, Class50 class50_2)
		{
			Class50 @class = null;
			while (class50_1.List_0[0].Boolean_2 && Class32.smethod_18(class50_1.List_0[0]))
			{
				if (@class == null)
				{
					@class = Class50.smethod_1(class50_2, class50_1.Class63_0);
					@class.method_19(class50_1, bool_2: true);
				}
				class50_1.List_0[0].Class50_0 = @class;
			}
			Class50 class2 = class50_1.List_0[0];
			if (!Class32.smethod_18(class2))
			{
				Class32.smethod_16(class50_0, class2, class50_2);
				class2.Class50_0 = null;
			}
			else
			{
				class2.Class50_0 = class50_0;
			}
			if (class50_1.List_0.Count > 0)
			{
				Class50 class3;
				if (class2.Class50_0 == null && class50_0.List_0.Count >= 3)
				{
					class3 = class50_0.List_0[2];
				}
				else
				{
					class3 = Class50.smethod_1(class50_0, class50_1.Class63_0);
					class3.method_19(class50_1, bool_2: true);
					if (class50_0.List_0.Count > 2)
					{
						class3.method_7(class50_0.List_0[1]);
					}
					if (class2.Class50_0 != null)
					{
						class2.method_7(class3);
					}
				}
				class3.method_8(class50_1);
			}
			else if (class2.Class50_0 != null && class50_0.List_0.Count > 1)
			{
				class2.method_7(class50_0.List_0[1]);
				if (class2.Class63_0 != null && class2.Class63_0.String_0 == "br" && (@class != null || class50_2.List_0.Count > 1))
				{
					class2.String_41 = "inline";
				}
			}
		}

		private static void smethod_17(Class50 class50_0)
		{
			if (Class32.smethod_19(class50_0))
			{
				for (int i = 0; i < class50_0.List_0.Count; i++)
				{
					if (class50_0.List_0[i].Boolean_2)
					{
						Class50 class50_ = Class50.smethod_3(class50_0, null, class50_0.List_0[i++]);
						while (i < class50_0.List_0.Count && class50_0.List_0[i].Boolean_2)
						{
							class50_0.List_0[i].Class50_0 = class50_;
						}
					}
				}
			}
			if (Class25.smethod_1(class50_0))
			{
				return;
			}
			foreach (Class50 item in class50_0.List_0)
			{
				Class32.smethod_17(item);
			}
		}

		private static bool smethod_18(Class50 class50_0)
		{
			foreach (Class50 item in class50_0.List_0)
			{
				if (!item.Boolean_2 || !Class32.smethod_18(item))
				{
					return false;
				}
			}
			return true;
		}

		private static bool smethod_19(Class50 class50_0)
		{
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < class50_0.List_0.Count; i++)
			{
				if (flag && flag2)
				{
					break;
				}
				bool flag3 = !class50_0.List_0[i].Boolean_2;
				flag = flag || flag3;
				flag2 = flag2 || !flag3;
			}
			return flag && flag2;
		}
	}
}

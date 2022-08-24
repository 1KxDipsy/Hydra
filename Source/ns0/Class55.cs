using System;
using System.Collections.Generic;
using ns11;
using ns14;
using ns16;

namespace ns0
{
	internal static class Class55
	{
		public static void smethod_0(Class60 class60_0)
		{
			ArgChecker.AssertArgNotNull(class60_0, "imageWord");
			ArgChecker.AssertArgNotNull(class60_0.Class50_0, "imageWord.OwnerBox");
			Class57 @class = new Class57(class60_0.Class50_0.String_30);
			Class57 class2 = new Class57(class60_0.Class50_0.String_32);
			bool flag = @class.Double_0 > 0.0 && @class.Enum3_0 == Enum3.const_2;
			bool flag2 = class2.Double_0 > 0.0 && class2.Enum3_0 == Enum3.const_2;
			bool flag3 = false;
			if (flag)
			{
				class60_0.Double_2 = @class.Double_0;
			}
			else if (@class.Double_0 > 0.0 && @class.Boolean_1)
			{
				class60_0.Double_2 = @class.Double_0 * class60_0.Class50_0.Class50_1.RSize_0.Width;
				flag3 = true;
			}
			else if (class60_0.RImage_0 != null)
			{
				class60_0.Double_2 = ((class60_0.RRect_1 == RRect.Empty) ? class60_0.RImage_0.Width : class60_0.RRect_1.Width);
			}
			else
			{
				class60_0.Double_2 = (flag2 ? (class2.Double_0 / 1.1399999856948853) : 20.0);
			}
			Class57 class3 = new Class57(class60_0.Class50_0.String_31);
			if (class3.Double_0 > 0.0)
			{
				double num = -1.0;
				if (class3.Enum3_0 == Enum3.const_2)
				{
					num = class3.Double_0;
				}
				else if (class3.Boolean_1)
				{
					num = class3.Double_0 * class60_0.Class50_0.Class50_1.RSize_0.Width;
				}
				if (num > -1.0 && class60_0.Double_2 > num)
				{
					class60_0.Double_2 = num;
					flag3 = !flag2;
				}
			}
			if (flag2)
			{
				class60_0.Double_5 = class2.Double_0;
			}
			else if (class60_0.RImage_0 != null)
			{
				class60_0.Double_5 = ((class60_0.RRect_1 == RRect.Empty) ? class60_0.RImage_0.Height : class60_0.RRect_1.Height);
			}
			else
			{
				class60_0.Double_5 = ((class60_0.Double_2 > 0.0) ? (class60_0.Double_2 * 1.1399999856948853) : 22.799999237060547);
			}
			if (class60_0.RImage_0 != null)
			{
				if ((flag && !flag2) || flag3)
				{
					double num2 = class60_0.Double_2 / class60_0.RImage_0.Width;
					class60_0.Double_5 = class60_0.RImage_0.Height * num2;
				}
				else if (flag2 && !flag)
				{
					double num3 = class60_0.Double_5 / class60_0.RImage_0.Height;
					class60_0.Double_2 = class60_0.RImage_0.Width * num3;
				}
			}
			class60_0.Double_5 += class60_0.Class50_0.Double_20 + class60_0.Class50_0.Double_18 + class60_0.Class50_0.Double_9 + class60_0.Class50_0.Double_11;
		}

		public static void smethod_1(RGraphics rgraphics_0, Class50 class50_0)
		{
			ArgChecker.AssertArgNotNull(rgraphics_0, "g");
			ArgChecker.AssertArgNotNull(class50_0, "blockBox");
			class50_0.List_1.Clear();
			double double_ = class50_0.Double_1 - class50_0.Double_12 - class50_0.Double_21;
			double num = class50_0.RPoint_0.Double_0 + class50_0.Double_10 - 0.0 + class50_0.Double_19;
			double num2 = class50_0.RPoint_0.Double_1 + class50_0.Double_9 - 0.0 + class50_0.Double_18;
			double double_2 = num + class50_0.Double_29;
			double double_3 = num2;
			double double_4 = num;
			double double_5 = num2;
			Class58 class58_ = new Class58(class50_0);
			Class55.smethod_3(rgraphics_0, class50_0, class50_0, double_, 0.0, num, ref class58_, ref double_2, ref double_3, ref double_4, ref double_5);
			if (class50_0.Double_1 >= 90999.0)
			{
				class50_0.Double_1 = double_4 + class50_0.Double_12 + class50_0.Double_21;
			}
			foreach (Class58 item in class50_0.List_1)
			{
				Class55.smethod_6(rgraphics_0, item);
				Class55.smethod_7(class50_0, item);
				Class55.smethod_5(class50_0, item);
				Class55.smethod_10(rgraphics_0, item);
				item.method_3();
			}
			class50_0.Double_2 = double_5 + class50_0.Double_11 + class50_0.Double_20;
			if (class50_0.String_32 != null && class50_0.String_32 != "auto" && class50_0.String_61 == "hidden" && class50_0.Double_2 - class50_0.RPoint_0.Double_1 > class50_0.Double_7)
			{
				class50_0.Double_2 = class50_0.RPoint_0.Double_1 + class50_0.Double_7;
			}
		}

		public static void smethod_2(RGraphics rgraphics_0, Class50 class50_0)
		{
			ArgChecker.AssertArgNotNull(rgraphics_0, "g");
			ArgChecker.AssertArgNotNull(class50_0, "cell");
			if (class50_0.String_47 == "top" || class50_0.String_47 == "baseline")
			{
				return;
			}
			double double_ = class50_0.Double_6;
			double num = class50_0.method_16(class50_0, 0.0);
			double double_2 = 0.0;
			if (class50_0.String_47 == "bottom")
			{
				double_2 = double_ - num;
			}
			else if (class50_0.String_47 == "middle")
			{
				double_2 = (double_ - num) / 2.0;
			}
			foreach (Class50 item in class50_0.List_0)
			{
				item.method_24(double_2);
			}
		}

		private static void smethod_3(RGraphics rgraphics_0, Class50 class50_0, Class50 class50_1, double double_0, double double_1, double double_2, ref Class58 class58_0, ref double double_3, ref double double_4, ref double double_5, ref double double_6)
		{
			double num = double_3;
			double num2 = double_4;
			class50_1.Class58_0 = class58_0;
			double num3 = double_3;
			double num4 = double_5;
			double num5 = double_6;
			foreach (Class50 item in class50_1.List_0)
			{
				double num6 = ((!(item.String_45 != "absolute") || !(item.String_45 != "fixed")) ? 0.0 : (item.Double_15 + item.Double_19 + item.Double_10));
				double num7 = ((!(item.String_45 != "absolute") || !(item.String_45 != "fixed")) ? 0.0 : (item.Double_17 + item.Double_21 + item.Double_12));
				item.method_30();
				item.vmethod_5(rgraphics_0);
				double_3 += num6;
				if (item.List_3.Count > 0)
				{
					bool flag = false;
					if (item.String_51 == "nowrap" && double_3 > double_2)
					{
						double num8 = double_3;
						foreach (Class59 item2 in item.List_3)
						{
							num8 += item2.Double_3;
						}
						if (num8 > double_0)
						{
							flag = true;
						}
					}
					if (Class25.smethod_5(item))
					{
						double_3 += class50_1.Double_26;
					}
					foreach (Class59 item3 in item.List_3)
					{
						if (double_6 - double_4 < class50_1.Double_28)
						{
							double_6 += class50_1.Double_28 - (double_6 - double_4);
						}
						if ((item.String_51 != "nowrap" && item.String_51 != "pre" && double_3 + item3.Double_2 + num7 > double_0 && (item.String_51 != "pre-wrap" || !item3.Boolean_4)) || item3.Boolean_5 || flag)
						{
							flag = false;
							double_3 = double_2;
							if (item == class50_1.List_0[0] && !item3.Boolean_5 && (item3 == item.List_3[0] || (class50_1.Class50_0 != null && class50_1.Class50_0.Boolean_3)))
							{
								double_3 += class50_1.Double_15 + class50_1.Double_19 + class50_1.Double_10;
							}
							double_4 = double_6 + double_1;
							class58_0 = new Class58(class50_0);
							if (item3.Boolean_3 || item3.Equals(item.Class59_0))
							{
								double_3 += num6;
							}
						}
						class58_0.method_0(item3);
						item3.Double_0 = double_3;
						item3.Double_1 = double_4;
						if (!class50_1.Boolean_6)
						{
							item3.method_0();
						}
						double_3 = item3.Double_0 + item3.Double_3;
						double_5 = Math.Max(double_5, item3.Double_6);
						double_6 = Math.Max(double_6, item3.Double_7);
						if (item.String_45 == "absolute")
						{
							item3.Double_0 += class50_1.Double_15;
							item3.Double_1 += class50_1.Double_13;
						}
					}
				}
				else
				{
					Class55.smethod_3(rgraphics_0, class50_0, item, double_0, double_1, double_2, ref class58_0, ref double_3, ref double_4, ref double_5, ref double_6);
				}
				double_3 += num7;
			}
			if (double_6 - num2 < class50_1.Double_7)
			{
				double_6 += class50_1.Double_7 - (double_6 - num2);
			}
			if (class50_1.Boolean_2 && 0.0 <= double_3 - num && double_3 - num < class50_1.Double_8)
			{
				double_3 += class50_1.Double_8 - (double_3 - num);
				class58_0.Dictionary_0.Add(class50_1, new RRect(num, num2, class50_1.Double_8, class50_1.Double_7));
			}
			if (class50_1.Class29_0 != null && class50_1.Class29_0.method_2() && !class50_1.Boolean_4 && class50_1.Boolean_2 && class50_1.List_0.Count == 0 && class50_1.List_3.Count == 0)
			{
				double_3 += class50_1.Double_26;
			}
			if (class50_1.String_45 == "absolute")
			{
				double_3 = num3;
				double_5 = num4;
				double_6 = num5;
				Class55.smethod_4(class50_1, 0.0, 0.0);
			}
			class50_1.Class58_1 = class58_0;
		}

		private static void smethod_4(Class50 class50_0, double double_0, double double_1)
		{
			double_0 += class50_0.Double_15;
			double_1 += class50_0.Double_13;
			if (class50_0.List_3.Count > 0)
			{
				foreach (Class59 item in class50_0.List_3)
				{
					item.Double_0 += double_0;
					item.Double_1 += double_1;
				}
				return;
			}
			foreach (Class50 item2 in class50_0.List_0)
			{
				Class55.smethod_4(item2, double_0, double_1);
			}
		}

		private static void smethod_5(Class50 class50_0, Class58 class58_0)
		{
			if (class50_0.List_3.Count > 0)
			{
				double num = 3.4028234663852886E+38;
				double num2 = 3.4028234663852886E+38;
				double num3 = -3.4028234663852886E+38;
				double num4 = -3.4028234663852886E+38;
				List<Class59> list = class58_0.method_1(class50_0);
				if (list.Count <= 0)
				{
					return;
				}
				foreach (Class59 item in list)
				{
					double num5 = item.Double_0;
					if (class50_0 == class50_0.Class50_0.List_0[0] && item == class50_0.List_3[0] && item == class58_0.List_1[0] && class58_0 != class58_0.Class50_0.List_1[0] && !item.Boolean_5)
					{
						num5 -= class50_0.Class50_0.Double_15 + class50_0.Class50_0.Double_19 + class50_0.Class50_0.Double_10;
					}
					num = Math.Min(num, num5);
					num3 = Math.Max(num3, item.Double_6);
					num2 = Math.Min(num2, item.Double_1);
					num4 = Math.Max(num4, item.Double_7);
				}
				class58_0.method_2(class50_0, num, num2, num3, num4);
				return;
			}
			foreach (Class50 item2 in class50_0.List_0)
			{
				Class55.smethod_5(item2, class58_0);
			}
		}

		private static void smethod_6(RGraphics rgraphics_0, Class58 class58_0)
		{
			switch (class58_0.Class50_0.String_49)
			{
			default:
				Class55.smethod_14(rgraphics_0, class58_0);
				break;
			case "justify":
				Class55.smethod_11(rgraphics_0, class58_0);
				break;
			case "center":
				Class55.smethod_12(rgraphics_0, class58_0);
				break;
			case "right":
				Class55.smethod_13(rgraphics_0, class58_0);
				break;
			}
		}

		private static void smethod_7(Class50 class50_0, Class58 class58_0)
		{
			if (class50_0.String_42 == "rtl")
			{
				Class55.smethod_8(class58_0);
				return;
			}
			foreach (Class50 item in class58_0.List_0)
			{
				if (item.String_42 == "rtl")
				{
					Class55.smethod_9(class58_0, item);
				}
			}
		}

		private static void smethod_8(Class58 class58_0)
		{
			if (class58_0.List_1.Count <= 0)
			{
				return;
			}
			double double_ = class58_0.List_1[0].Double_0;
			double double_2 = class58_0.List_1[class58_0.List_1.Count - 1].Double_6;
			foreach (Class59 item in class58_0.List_1)
			{
				item.Double_0 = double_2 - (item.Double_0 - double_) - item.Double_2;
			}
		}

		private static void smethod_9(Class58 class58_0, Class50 class50_0)
		{
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < class58_0.List_1.Count; i++)
			{
				if (class58_0.List_1[i].Class50_0 == class50_0)
				{
					if (num < 0)
					{
						num = i;
					}
					num2 = i;
				}
			}
			if (num > -1 && num2 > num)
			{
				double double_ = class58_0.List_1[num].Double_0;
				double double_2 = class58_0.List_1[num2].Double_6;
				for (int j = num; j <= num2; j++)
				{
					double double_3 = class58_0.List_1[j].Double_0;
					class58_0.List_1[j].Double_0 = double_2 - (double_3 - double_) - class58_0.List_1[j].Double_2;
				}
			}
		}

		private static void smethod_10(RGraphics rgraphics_0, Class58 class58_0)
		{
			double num = -3.4028234663852886E+38;
			foreach (Class50 key in class58_0.Dictionary_0.Keys)
			{
				num = Math.Max(num, class58_0.Dictionary_0[key].Top);
			}
			foreach (Class50 item in new List<Class50>(class58_0.Dictionary_0.Keys))
			{
				string string_ = item.String_47;
				switch (Class75.smethod_0(string_))
				{
				case 2802900028u:
					if (string_ == "top")
					{
						break;
					}
					goto default;
				case 1319594794u:
					if (string_ == "bottom")
					{
						break;
					}
					goto default;
				case 1083724742u:
					if (string_ == "text-bottom")
					{
						break;
					}
					goto default;
				case 3380782872u:
					if (string_ == "middle")
					{
						break;
					}
					goto default;
				case 2929335800u:
					if (string_ == "text-top")
					{
						break;
					}
					goto default;
				case 4152230356u:
					if (string_ == "super")
					{
						class58_0.method_4(rgraphics_0, item, num - class58_0.Dictionary_0[item].Height * 0.20000000298023224);
						break;
					}
					goto default;
				case 3696113941u:
					if (string_ == "sub")
					{
						class58_0.method_4(rgraphics_0, item, num + class58_0.Dictionary_0[item].Height * 0.5);
						break;
					}
					goto default;
				default:
					class58_0.method_4(rgraphics_0, item, num);
					break;
				}
			}
		}

		private static void smethod_11(RGraphics rgraphics_0, Class58 class58_0)
		{
			if (class58_0.Equals(class58_0.Class50_0.List_1[class58_0.Class50_0.List_1.Count - 1]))
			{
				return;
			}
			double num = (class58_0.Equals(class58_0.Class50_0.List_1[0]) ? class58_0.Class50_0.Double_29 : 0.0);
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = class58_0.Class50_0.RRect_1.Width - num;
			foreach (Class59 item in class58_0.List_1)
			{
				num2 += item.Double_2;
				num3 += 1.0;
			}
			if (num3 <= 0.0)
			{
				return;
			}
			double num5 = (num4 - num2) / num3;
			double double_ = class58_0.Class50_0.Double_3 + num;
			foreach (Class59 item2 in class58_0.List_1)
			{
				item2.Double_0 = double_;
				double_ = item2.Double_6 + num5;
				if (item2 == class58_0.List_1[class58_0.List_1.Count - 1])
				{
					item2.Double_0 = class58_0.Class50_0.Double_5 - item2.Double_2;
				}
			}
		}

		private static void smethod_12(RGraphics rgraphics_0, Class58 class58_0)
		{
			if (class58_0.List_1.Count == 0)
			{
				return;
			}
			Class59 @class = class58_0.List_1[class58_0.List_1.Count - 1];
			double num = (class58_0.Class50_0.Double_1 - class58_0.Class50_0.Double_12 - class58_0.Class50_0.Double_21 - @class.Double_6 - @class.Class50_0.Double_21 - @class.Class50_0.Double_12) / 2.0;
			if (!(num > 0.0))
			{
				return;
			}
			foreach (Class59 item in class58_0.List_1)
			{
				item.Double_0 += num;
			}
			if (class58_0.Dictionary_0.Count <= 0)
			{
				return;
			}
			foreach (Class50 item2 in Class55.smethod_15(class58_0.Dictionary_0.Keys))
			{
				RRect rRect = class58_0.Dictionary_0[item2];
				class58_0.Dictionary_0[item2] = new RRect(rRect.Double_0 + num, rRect.Double_1, rRect.Width, rRect.Height);
			}
		}

		private static void smethod_13(RGraphics rgraphics_0, Class58 class58_0)
		{
			if (class58_0.List_1.Count == 0)
			{
				return;
			}
			Class59 @class = class58_0.List_1[class58_0.List_1.Count - 1];
			double num = class58_0.Class50_0.Double_1 - class58_0.Class50_0.Double_12 - class58_0.Class50_0.Double_21 - @class.Double_6 - @class.Class50_0.Double_21 - @class.Class50_0.Double_12;
			if (!(num > 0.0))
			{
				return;
			}
			foreach (Class59 item in class58_0.List_1)
			{
				item.Double_0 += num;
			}
			if (class58_0.Dictionary_0.Count <= 0)
			{
				return;
			}
			foreach (Class50 item2 in Class55.smethod_15(class58_0.Dictionary_0.Keys))
			{
				RRect rRect = class58_0.Dictionary_0[item2];
				class58_0.Dictionary_0[item2] = new RRect(rRect.Double_0 + num, rRect.Double_1, rRect.Width, rRect.Height);
			}
		}

		private static void smethod_14(RGraphics rgraphics_0, Class58 class58_0)
		{
		}

		private static List<T> smethod_15<T>(IEnumerable<T> ienumerable_0)
		{
			List<T> list = new List<T>();
			foreach (T item in ienumerable_0)
			{
				list.Add(item);
			}
			return list;
		}
	}
}

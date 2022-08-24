using System;
using System.Globalization;
using ns11;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class31
	{
		private readonly RAdapter radapter_0;

		public Class31(RAdapter radapter_1)
		{
			ArgChecker.AssertArgNotNull(radapter_1, "global");
			this.radapter_0 = radapter_1;
		}

		public static bool smethod_0(string string_0, int int_0, int int_1)
		{
			if (int_1 < 1)
			{
				return false;
			}
			bool flag = false;
			int num = 0;
			while (true)
			{
				if (num < int_1)
				{
					if (string_0[int_0 + num] == '.')
					{
						if (flag)
						{
							return false;
						}
						flag = true;
					}
					else if (!char.IsDigit(string_0[int_0 + num]))
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

		public static bool smethod_1(string string_0, int int_0, int int_1)
		{
			if (int_1 < 1)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < int_1)
				{
					if (!char.IsDigit(string_0[int_0 + num]))
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

		public static bool smethod_2(string string_0)
		{
			if (string_0.Length > 1)
			{
				string s = string.Empty;
				if (string_0.EndsWith("%"))
				{
					s = string_0.Substring(0, string_0.Length - 1);
				}
				else if (string_0.Length > 2)
				{
					s = string_0.Substring(0, string_0.Length - 2);
				}
				double result;
				return double.TryParse(s, out result);
			}
			return false;
		}

		public static double smethod_3(string string_0, double double_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return 0.0;
			}
			string s = string_0;
			bool flag;
			if (flag = string_0.EndsWith("%"))
			{
				s = string_0.Substring(0, string_0.Length - 1);
			}
			if (!double.TryParse(s, NumberStyles.Number, NumberFormatInfo.InvariantInfo, out var result))
			{
				return 0.0;
			}
			if (flag)
			{
				result = result / 100.0 * double_0;
			}
			return result;
		}

		public static double smethod_4(string string_0, double double_0, Class49 class49_0, bool bool_0 = false)
		{
			return Class31.smethod_6(string_0, double_0, class49_0.method_0(), null, bool_0, bool_1: false);
		}

		public static double smethod_5(string string_0, double double_0, Class49 class49_0, string string_1)
		{
			return Class31.smethod_6(string_0, double_0, class49_0.method_0(), string_1, bool_0: false, bool_1: false);
		}

		public static double smethod_6(string string_0, double double_0, double double_1, string string_1, bool bool_0, bool bool_1)
		{
			string string_2;
			double num2;
			if (!string.IsNullOrEmpty(string_0) && !(string_0 == "0"))
			{
				if (string_0.EndsWith("%"))
				{
					return Class31.smethod_3(string_0, double_0);
				}
				bool bool_2;
				string text = Class31.smethod_7(string_0, string_1, out bool_2);
				string_2 = (bool_2 ? string_0.Substring(0, string_0.Length - 2) : string_0);
				string text2 = text;
				uint num = Class75.smethod_0(text2);
				if (num <= 1313756516)
				{
					if (num <= 1094220446)
					{
						if (num != 1075471351)
						{
							if (num != 1094220446 || !(text2 == "in"))
							{
								goto IL_01cf;
							}
							num2 = 96.0;
						}
						else
						{
							if (!(text2 == "em"))
							{
								goto IL_01cf;
							}
							num2 = double_1;
						}
					}
					else if (num != 1260025160)
					{
						if (num != 1313756516 || !(text2 == "pc"))
						{
							goto IL_01cf;
						}
						num2 = 16.0;
					}
					else
					{
						if (!(text2 == "ex"))
						{
							goto IL_01cf;
						}
						num2 = double_1 / 2.0;
					}
				}
				else if (num <= 1565420801)
				{
					if (num != 1498310325)
					{
						if (num != 1565420801 || !(text2 == "pt"))
						{
							goto IL_01cf;
						}
						num2 = 1.3333333730697632;
						if (bool_1)
						{
							return Class31.smethod_3(string_2, double_0);
						}
					}
					else
					{
						if (!(text2 == "px"))
						{
							goto IL_01cf;
						}
						num2 = (bool_0 ? 0.75f : 1f);
					}
				}
				else if (num != 1613635087)
				{
					if (num != 1680451373 || !(text2 == "cm"))
					{
						goto IL_01cf;
					}
					num2 = 37.7952766418457;
				}
				else
				{
					if (!(text2 == "mm"))
					{
						goto IL_01cf;
					}
					num2 = 3.7795276641845703;
				}
				goto IL_01e7;
			}
			return 0.0;
			IL_01e7:
			return num2 * Class31.smethod_3(string_2, double_0);
			IL_01cf:
			num2 = 0.0;
			goto IL_01e7;
		}

		private static string smethod_7(string string_0, string string_1, out bool bool_0)
		{
			string text = ((string_0.Length >= 3) ? string_0.Substring(string_0.Length - 2, 2) : string.Empty);
			string text2 = text;
			uint num = Class75.smethod_0(text2);
			if (num <= 1313756516)
			{
				if (num <= 1094220446)
				{
					if (num != 1075471351)
					{
						if (num != 1094220446 || !(text2 == "in"))
						{
							goto IL_0114;
						}
					}
					else if (!(text2 == "em"))
					{
						goto IL_0114;
					}
				}
				else if (num != 1260025160)
				{
					if (num != 1313756516 || !(text2 == "pc"))
					{
						goto IL_0114;
					}
				}
				else if (!(text2 == "ex"))
				{
					goto IL_0114;
				}
			}
			else if (num <= 1565420801)
			{
				if (num != 1498310325)
				{
					if (num != 1565420801 || !(text2 == "pt"))
					{
						goto IL_0114;
					}
				}
				else if (!(text2 == "px"))
				{
					goto IL_0114;
				}
			}
			else if (num != 1613635087)
			{
				if (num != 1680451373 || !(text2 == "cm"))
				{
					goto IL_0114;
				}
			}
			else if (!(text2 == "mm"))
			{
				goto IL_0114;
			}
			bool_0 = true;
			goto IL_0127;
			IL_0114:
			bool_0 = false;
			text = string_1 ?? string.Empty;
			goto IL_0127;
			IL_0127:
			return text;
		}

		public bool method_0(string string_0)
		{
			RColor rcolor_;
			return this.method_2(string_0, 0, string_0.Length, out rcolor_);
		}

		public RColor method_1(string string_0)
		{
			this.method_2(string_0, 0, string_0.Length, out var rcolor_);
			return rcolor_;
		}

		public bool method_2(string string_0, int int_0, int int_1, out RColor rcolor_0)
		{
			try
			{
				if (!string.IsNullOrEmpty(string_0))
				{
					if (int_1 > 1 && string_0[int_0] == '#')
					{
						return Class31.smethod_9(string_0, int_0, int_1, out rcolor_0);
					}
					if (int_1 > 10 && Class22.smethod_10(string_0, int_0, 4, "rgb(") && string_0[int_1 - 1] == ')')
					{
						return Class31.smethod_10(string_0, int_0, int_1, out rcolor_0);
					}
					if (int_1 > 13 && Class22.smethod_10(string_0, int_0, 5, "rgba(") && string_0[int_1 - 1] == ')')
					{
						return Class31.smethod_11(string_0, int_0, int_1, out rcolor_0);
					}
					return this.method_3(string_0, int_0, int_1, out rcolor_0);
				}
			}
			catch
			{
			}
			rcolor_0 = RColor.Black;
			return false;
		}

		public static double smethod_8(string string_0, Class49 class49_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return Class31.smethod_8("medium", class49_0);
			}
			return string_0 switch
			{
				"thick" => 4.0, 
				"medium" => 2.0, 
				"thin" => 1.0, 
				_ => Math.Abs(Class31.smethod_4(string_0, 1.0, class49_0)), 
			};
		}

		private static bool smethod_9(string string_0, int int_0, int int_1, out RColor rcolor_0)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			switch (int_1)
			{
			case 7:
				num = Class31.smethod_14(string_0, int_0 + 1, 2);
				num2 = Class31.smethod_14(string_0, int_0 + 3, 2);
				num3 = Class31.smethod_14(string_0, int_0 + 5, 2);
				break;
			case 4:
				num = Class31.smethod_14(string_0, int_0 + 1, 1);
				num = num * 16 + num;
				num2 = Class31.smethod_14(string_0, int_0 + 2, 1);
				num2 = num2 * 16 + num2;
				num3 = Class31.smethod_14(string_0, int_0 + 3, 1);
				num3 = num3 * 16 + num3;
				break;
			}
			if (num > -1 && num2 > -1 && num3 > -1)
			{
				rcolor_0 = RColor.FromArgb(num, num2, num3);
				return true;
			}
			rcolor_0 = RColor.Empty;
			return false;
		}

		private static bool smethod_10(string string_0, int int_0, int int_1, out RColor rcolor_0)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			if (int_1 > 10)
			{
				int int_2 = int_0 + 4;
				num = Class31.smethod_12(string_0, ref int_2);
				if (int_2 < int_0 + int_1)
				{
					num2 = Class31.smethod_12(string_0, ref int_2);
				}
				if (int_2 < int_0 + int_1)
				{
					num3 = Class31.smethod_12(string_0, ref int_2);
				}
			}
			if (num > -1 && num2 > -1 && num3 > -1)
			{
				rcolor_0 = RColor.FromArgb(num, num2, num3);
				return true;
			}
			rcolor_0 = RColor.Empty;
			return false;
		}

		private static bool smethod_11(string string_0, int int_0, int int_1, out RColor rcolor_0)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			if (int_1 > 13)
			{
				int int_2 = int_0 + 5;
				num = Class31.smethod_12(string_0, ref int_2);
				if (int_2 < int_0 + int_1)
				{
					num2 = Class31.smethod_12(string_0, ref int_2);
				}
				if (int_2 < int_0 + int_1)
				{
					num3 = Class31.smethod_12(string_0, ref int_2);
				}
				if (int_2 < int_0 + int_1)
				{
					num4 = Class31.smethod_12(string_0, ref int_2);
				}
			}
			if (num > -1 && num2 > -1 && num3 > -1 && num4 > -1)
			{
				rcolor_0 = RColor.FromArgb(num4, num, num2, num3);
				return true;
			}
			rcolor_0 = RColor.Empty;
			return false;
		}

		private bool method_3(string string_0, int int_0, int int_1, out RColor rcolor_0)
		{
			rcolor_0 = this.radapter_0.GetColor(string_0.Substring(int_0, int_1));
			return rcolor_0.Byte_3 > 0;
		}

		private static int smethod_12(string string_0, ref int int_0)
		{
			int i = 0;
			while (char.IsWhiteSpace(string_0, int_0))
			{
				int_0++;
			}
			for (; char.IsDigit(string_0, int_0 + i); i++)
			{
			}
			int result = Class31.smethod_13(string_0, int_0, i);
			int_0 = int_0 + i + 1;
			return result;
		}

		private static int smethod_13(string string_0, int int_0, int int_1)
		{
			if (int_1 < 1)
			{
				return -1;
			}
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < int_1)
				{
					int num3 = string_0[int_0 + num2];
					if (num3 < 48 || num3 > 57)
					{
						break;
					}
					num = num * 10 + num3 - 48;
					num2++;
					continue;
				}
				return num;
			}
			return -1;
		}

		private static int smethod_14(string string_0, int int_0, int int_1)
		{
			if (int_1 < 1)
			{
				return -1;
			}
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < int_1)
				{
					int num3 = string_0[int_0 + num2];
					if ((num3 < 48 || num3 > 57) && (num3 < 65 || num3 > 70) && (num3 < 97 || num3 > 102))
					{
						break;
					}
					num = num * 16 + ((num3 <= 57) ? (num3 - 48) : (10 + num3 - ((num3 <= 70) ? 65 : 97)));
					num2++;
					continue;
				}
				return num;
			}
			return -1;
		}
	}
}

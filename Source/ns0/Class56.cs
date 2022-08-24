using System;
using System.Collections.Generic;
using ns11;
using ns13;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class56
	{
		private readonly Class50 class50_0;

		private Class50 class50_1;

		private Class50 class50_2;

		private Class50 class50_3;

		private readonly List<Class50> list_0 = new List<Class50>();

		private readonly List<Class50> list_1 = new List<Class50>();

		private readonly List<Class50> list_2 = new List<Class50>();

		private int int_0;

		private bool bool_0;

		private double[] double_0;

		private double[] double_1;

		private Class56(Class50 class50_4)
		{
			this.class50_0 = class50_4;
		}

		public static double smethod_0(Class50 class50_4)
		{
			int num = 0;
			int num2 = 0;
			foreach (Class50 item in class50_4.List_0)
			{
				if (item.String_41 == "table-column")
				{
					num2 += Class56.smethod_6(item);
				}
				else if (item.String_41 == "table-row-group")
				{
					foreach (Class50 item2 in class50_4.List_0)
					{
						num++;
						if (item2.String_41 == "table-row")
						{
							num2 = Math.Max(num2, item2.List_0.Count);
						}
					}
				}
				else if (item.String_41 == "table-row")
				{
					num++;
					num2 = Math.Max(num2, item.List_0.Count);
				}
				if (num > 30)
				{
					break;
				}
			}
			return (double)(num2 + 1) * Class56.smethod_7(class50_4);
		}

		public static void smethod_1(RGraphics rgraphics_0, Class50 class50_4)
		{
			ArgChecker.AssertArgNotNull(rgraphics_0, "g");
			ArgChecker.AssertArgNotNull(class50_4, "tableBox");
			try
			{
				new Class56(class50_4).method_0(rgraphics_0);
			}
			catch (Exception exception_)
			{
				class50_4.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Layout, "Failed table layout", exception_);
			}
		}

		private void method_0(RGraphics rgraphics_0)
		{
			Class56.smethod_5(this.class50_0, rgraphics_0);
			this.method_1();
			this.method_2();
			this.method_4(this.method_3());
			this.method_6();
			this.method_5();
			this.class50_0.String_24 = (this.class50_0.String_26 = (this.class50_0.String_25 = (this.class50_0.String_23 = "0")));
			this.method_7(rgraphics_0);
		}

		private void method_1()
		{
			foreach (Class50 item in this.class50_0.List_0)
			{
				string string_ = item.String_41;
				switch (Class75.smethod_0(string_))
				{
				case 1180230732u:
					if (!(string_ == "table-row-group"))
					{
						break;
					}
					foreach (Class50 item2 in item.List_0)
					{
						if (item2.String_41 == "table-row")
						{
							this.list_0.Add(item2);
						}
					}
					break;
				case 675151018u:
					if (string_ == "table-row")
					{
						this.list_0.Add(item);
					}
					break;
				case 126687312u:
					if (string_ == "table-caption")
					{
						this.class50_1 = item;
					}
					break;
				case 3265876631u:
					if (string_ == "table-footer-group")
					{
						if (this.class50_3 != null)
						{
							this.list_0.Add(item);
						}
						else
						{
							this.class50_3 = item;
						}
					}
					break;
				case 3222146762u:
					if (!(string_ == "table-column-group"))
					{
						break;
					}
					if (item.List_0.Count == 0)
					{
						int num = Class56.smethod_6(item);
						for (int i = 0; i < num; i++)
						{
							this.list_1.Add(item);
						}
						break;
					}
					foreach (Class50 item3 in item.List_0)
					{
						int num2 = Class56.smethod_6(item3);
						for (int j = 0; j < num2; j++)
						{
							this.list_1.Add(item3);
						}
					}
					break;
				case 4034808716u:
					if (string_ == "table-column")
					{
						for (int k = 0; k < Class56.smethod_6(item); k++)
						{
							this.list_1.Add(item);
						}
					}
					break;
				case 3615688129u:
					if (string_ == "table-header-group")
					{
						if (this.class50_2 != null)
						{
							this.list_0.Add(item);
						}
						else
						{
							this.class50_2 = item;
						}
					}
					break;
				}
			}
			if (this.class50_2 != null)
			{
				this.list_2.AddRange(this.class50_2.List_0);
			}
			this.list_2.AddRange(this.list_0);
			if (this.class50_3 != null)
			{
				this.list_2.AddRange(this.class50_3.List_0);
			}
		}

		private void method_2()
		{
			if (this.class50_0.bool_0)
			{
				return;
			}
			int num = 0;
			List<Class50> list = this.list_0;
			foreach (Class50 item in list)
			{
				for (int i = 0; i < item.List_0.Count; i++)
				{
					Class50 class50_ = item.List_0[i];
					int num2 = Class56.smethod_4(class50_);
					int num3 = Class56.smethod_2(item, class50_);
					for (int j = num + 1; j < num + num2; j++)
					{
						if (list.Count <= j)
						{
							continue;
						}
						int num4 = 0;
						for (int k = 0; k < list[j].List_0.Count; k++)
						{
							if (num4 != num3)
							{
								num4++;
								num3 -= Class56.smethod_3(list[j].List_0[k]) - 1;
								continue;
							}
							list[j].List_0.Insert(num4, new Class54(this.class50_0, ref class50_, num));
							break;
						}
					}
				}
				num++;
			}
			this.class50_0.bool_0 = true;
		}

		private double method_3()
		{
			if (this.list_1.Count > 0)
			{
				this.int_0 = this.list_1.Count;
			}
			else
			{
				using List<Class50>.Enumerator enumerator = this.list_2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					this.int_0 = Math.Max(val2: enumerator.Current.List_0.Count, val1: this.int_0);
				}
			}
			this.double_0 = new double[this.int_0];
			for (int i = 0; i < this.double_0.Length; i++)
			{
				this.double_0[i] = double.NaN;
			}
			double result = this.method_15();
			if (this.list_1.Count > 0)
			{
				for (int j = 0; j < this.list_1.Count; j++)
				{
					Class57 @class = new Class57(this.list_1[j].String_30);
					if (@class.Double_0 > 0.0)
					{
						if (@class.Boolean_1)
						{
							this.double_0[j] = Class31.smethod_3(this.list_1[j].String_30, result);
						}
						else if (@class.Enum3_0 == Enum3.const_2 || @class.Enum3_0 == Enum3.const_0)
						{
							this.double_0[j] = @class.Double_0;
						}
					}
				}
			}
			else
			{
				foreach (Class50 item in this.list_2)
				{
					for (int k = 0; k < this.int_0; k++)
					{
						if ((k >= 20 && !double.IsNaN(this.double_0[k])) || k >= item.List_0.Count || !(item.List_0[k].String_41 == "table-cell"))
						{
							continue;
						}
						double num = Class31.smethod_4(item.List_0[k].String_30, result, item.List_0[k]);
						if (num > 0.0)
						{
							int num2 = Class56.smethod_3(item.List_0[k]);
							num /= (double)Convert.ToSingle(num2);
							for (int l = k; l < k + num2; l++)
							{
								this.double_0[l] = (double.IsNaN(this.double_0[l]) ? num : Math.Max(this.double_0[l], num));
							}
						}
					}
				}
			}
			return result;
		}

		private void method_4(double double_2)
		{
			double num = 0.0;
			if (this.bool_0)
			{
				int num2 = 0;
				double[] array = this.double_0;
				foreach (double num3 in array)
				{
					if (double.IsNaN(num3))
					{
						num2++;
					}
					else
					{
						num += num3;
					}
				}
				int num4 = num2;
				double[] array2 = null;
				if (num2 < this.double_0.Length)
				{
					array2 = new double[this.double_0.Length];
					for (int j = 0; j < this.double_0.Length; j++)
					{
						array2[j] = this.double_0[j];
					}
				}
				if (num2 > 0)
				{
					this.method_14(bool_1: true, out var _, out var double_4);
					int num5;
					do
					{
						num5 = num2;
						for (int k = 0; k < this.double_0.Length; k++)
						{
							double num6 = (double_2 - num) / (double)num2;
							if (double.IsNaN(this.double_0[k]) && num6 > double_4[k])
							{
								this.double_0[k] = double_4[k];
								num2--;
								num += double_4[k];
							}
						}
					}
					while (num5 != num2);
					if (num2 > 0)
					{
						double num7 = (double_2 - num) / (double)num2;
						for (int l = 0; l < this.double_0.Length; l++)
						{
							if (double.IsNaN(this.double_0[l]))
							{
								this.double_0[l] = num7;
							}
						}
					}
				}
				if (num2 != 0 || !(num < double_2))
				{
					return;
				}
				if (num4 > 0)
				{
					double num8 = (double_2 - num) / (double)num4;
					for (int m = 0; m < this.double_0.Length; m++)
					{
						if (array2 == null || double.IsNaN(array2[m]))
						{
							this.double_0[m] += num8;
						}
					}
				}
				else
				{
					for (int n = 0; n < this.double_0.Length; n++)
					{
						this.double_0[n] += (double_2 - num) * (this.double_0[n] / num);
					}
				}
				return;
			}
			this.method_14(bool_1: true, out var double_5, out var double_6);
			for (int num9 = 0; num9 < this.double_0.Length; num9++)
			{
				if (double.IsNaN(this.double_0[num9]))
				{
					this.double_0[num9] = double_5[num9];
				}
				num += this.double_0[num9];
			}
			for (int num10 = 0; num10 < this.double_0.Length; num10++)
			{
				if (double_6[num10] > this.double_0[num10])
				{
					double num11 = this.double_0[num10];
					this.double_0[num10] = Math.Min(this.double_0[num10] + (double_2 - num) / (double)Convert.ToSingle(this.double_0.Length - num10), double_6[num10]);
					num = num + this.double_0[num10] - num11;
				}
			}
		}

		private void method_5()
		{
			int i = 0;
			double num = this.method_16();
			while (!(num <= this.method_12()) && this.method_10())
			{
				for (; !this.method_11(i); i++)
				{
				}
				this.double_0[i] -= 1.0;
				i++;
				if (i >= this.double_0.Length)
				{
					i = 0;
				}
			}
			double num2 = this.method_13();
			if (!(num2 < 90999.0) || !(num2 < this.method_16()))
			{
				return;
			}
			this.method_14(bool_1: false, out var double_, out var double_2);
			for (int j = 0; j < this.double_0.Length; j++)
			{
				this.double_0[j] = double_[j];
			}
			num = this.method_16();
			if (num2 < num)
			{
				for (int k = 0; k < 15; k++)
				{
					if (!(num2 < num - 0.1))
					{
						break;
					}
					int num3 = 0;
					double num4 = 0.0;
					double num5 = 0.0;
					for (int l = 0; l < this.double_0.Length; l++)
					{
						if (this.double_0[l] > num4 + 0.1)
						{
							num5 = num4;
							num4 = this.double_0[l];
							num3 = 1;
						}
						else if (this.double_0[l] > num4 - 0.1)
						{
							num3++;
						}
					}
					double num6 = ((num5 > 0.0) ? (num4 - num5) : ((num - num2) / (double)this.double_0.Length));
					if (num6 * (double)num3 > num - num2)
					{
						num6 = (num - num2) / (double)num3;
					}
					for (int m = 0; m < this.double_0.Length; m++)
					{
						if (this.double_0[m] > num4 - 0.1)
						{
							this.double_0[m] -= num6;
						}
					}
					num = this.method_16();
				}
				return;
			}
			for (int n = 0; n < 15; n++)
			{
				if (!(num2 > num + 0.1))
				{
					break;
				}
				int num7 = 0;
				for (int num8 = 0; num8 < this.double_0.Length; num8++)
				{
					if (this.double_0[num8] + 1.0 < double_2[num8])
					{
						num7++;
					}
				}
				if (num7 == 0)
				{
					num7 = this.double_0.Length;
				}
				bool flag = false;
				double num9 = (num2 - num) / (double)num7;
				for (int num10 = 0; num10 < this.double_0.Length; num10++)
				{
					if (this.double_0[num10] + 0.1 < double_2[num10])
					{
						num9 = Math.Min(num9, double_2[num10] - this.double_0[num10]);
						flag = true;
					}
				}
				for (int num11 = 0; num11 < this.double_0.Length; num11++)
				{
					if (!flag || this.double_0[num11] + 1.0 < double_2[num11])
					{
						this.double_0[num11] += num9;
					}
				}
				num = this.method_16();
			}
		}

		private void method_6()
		{
			foreach (Class50 item in this.list_2)
			{
				foreach (Class50 item2 in item.List_0)
				{
					int num = Class56.smethod_3(item2);
					int num2 = Class56.smethod_2(item, item2);
					int num3 = num2 + num - 1;
					if (this.double_0.Length > num2 && this.double_0[num2] < this.method_17()[num2])
					{
						double num4 = this.method_17()[num2] - this.double_0[num2];
						this.double_0[num3] = this.method_17()[num3];
						if (num2 < this.double_0.Length - 1)
						{
							this.double_0[num2 + 1] -= num4;
						}
					}
				}
			}
		}

		private void method_7(RGraphics rgraphics_0)
		{
			double num = Math.Max(this.class50_0.Double_3 + this.method_18(), 0.0);
			double num2 = Math.Max(this.class50_0.Double_4 + this.method_19(), 0.0);
			double y = num2;
			double val = num;
			double num3 = 0.0;
			int num4 = 0;
			if (this.class50_0.String_49 == "center" || this.class50_0.String_49 == "right")
			{
				double num5 = this.method_16();
				num = ((this.class50_0.String_49 == "right") ? (this.method_12() - num5) : (num + (this.method_12() - num5) / 2.0));
				this.class50_0.RPoint_0 = new RPoint(num - this.class50_0.Double_19 - this.class50_0.Double_10 - this.method_18(), this.class50_0.RPoint_0.Double_1);
			}
			for (int i = 0; i < this.list_2.Count; i++)
			{
				Class50 @class = this.list_2[i];
				double x = num;
				int num6 = 0;
				bool flag = false;
				for (int j = 0; j < @class.List_0.Count; j++)
				{
					Class50 class2 = @class.List_0[j];
					if (num6 >= this.double_0.Length)
					{
						break;
					}
					int num7 = Class56.smethod_4(class2);
					double width = this.method_9(Class56.smethod_2(@class, class2), class2);
					class2.RPoint_0 = new RPoint(x, y);
					class2.RSize_0 = new RSize(width, 0.0);
					class2.method_5(rgraphics_0);
					if (class2 is Class54 class3)
					{
						if (class3.Int32_1 == num4)
						{
							num3 = Math.Max(num3, class3.Class50_2.Double_2);
						}
					}
					else if (num7 == 1)
					{
						num3 = Math.Max(num3, class2.Double_2);
					}
					val = Math.Max(val, class2.Double_1);
					num6++;
					x = class2.Double_1 + this.method_18();
				}
				foreach (Class50 item in @class.List_0)
				{
					Class54 class4 = item as Class54;
					if (class4 == null && Class56.smethod_4(item) == 1)
					{
						item.Double_2 = num3;
						Class55.smethod_2(rgraphics_0, item);
					}
					else if (class4 != null && class4.Int32_1 == num4)
					{
						class4.Class50_2.Double_2 = num3;
						Class55.smethod_2(rgraphics_0, class4.Class50_2);
					}
					if (this.class50_0.String_27 == "avoid" && (flag = item.method_21()))
					{
						y = item.RPoint_0.Double_1;
						break;
					}
				}
				if (flag)
				{
					i = ((i != 1) ? (i - 1) : (-1));
					num3 = 0.0;
				}
				else
				{
					y = num3 + this.method_19();
					num4++;
				}
			}
			double num8 = Math.Max(val, this.class50_0.RPoint_0.Double_0 + this.class50_0.Double_8);
			this.class50_0.Double_1 = num8 + this.method_18() + this.class50_0.Double_21;
			this.class50_0.Double_2 = Math.Max(num3, num2) + this.method_19() + this.class50_0.Double_20;
		}

		private double method_8(Class50 class50_4, Class50 class50_5, int int_1, int int_2)
		{
			double num = 0.0;
			for (int i = int_1; i < class50_4.List_0.Count || i < int_1 + int_2 - 1; i++)
			{
				if (i < this.method_17().Length)
				{
					num += this.method_17()[i];
				}
			}
			return num;
		}

		private static int smethod_2(Class50 class50_4, Class50 class50_5)
		{
			int num = 0;
			foreach (Class50 item in class50_4.List_0)
			{
				if (!item.Equals(class50_5))
				{
					num += Class56.smethod_3(item);
					continue;
				}
				break;
			}
			return num;
		}

		private double method_9(int int_1, Class50 class50_4)
		{
			double num = Convert.ToSingle(Class56.smethod_3(class50_4));
			double num2 = 0.0;
			for (int i = int_1; (double)i < (double)int_1 + num; i++)
			{
				if (int_1 >= this.double_0.Length)
				{
					break;
				}
				if (this.double_0.Length <= i)
				{
					break;
				}
				num2 += this.double_0[i];
			}
			return num2 + (num - 1.0) * this.method_18();
		}

		private static int smethod_3(Class50 class50_4)
		{
			if (!int.TryParse(class50_4.method_14("colspan", "1"), out var result))
			{
				return 1;
			}
			return result;
		}

		private static int smethod_4(Class50 class50_4)
		{
			if (!int.TryParse(class50_4.method_14("rowspan", "1"), out var result))
			{
				return 1;
			}
			return result;
		}

		private static void smethod_5(Class50 class50_4, RGraphics rgraphics_0)
		{
			if (class50_4 == null)
			{
				return;
			}
			foreach (Class50 item in class50_4.List_0)
			{
				item.vmethod_5(rgraphics_0);
				Class56.smethod_5(item, rgraphics_0);
			}
		}

		private bool method_10()
		{
			int num = 0;
			while (true)
			{
				if (num < this.double_0.Length)
				{
					if (this.method_11(num))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		private bool method_11(int int_1)
		{
			if (this.double_0.Length < int_1 && this.method_17().Length < int_1)
			{
				return this.double_0[int_1] > this.method_17()[int_1];
			}
			return false;
		}

		private double method_12()
		{
			if (new Class57(this.class50_0.String_30).Double_0 > 0.0)
			{
				this.bool_0 = true;
				return Class31.smethod_4(this.class50_0.String_30, this.class50_0.Class50_0.Double_0, this.class50_0);
			}
			return this.class50_0.Class50_0.Double_0;
		}

		private double method_13()
		{
			if (new Class57(this.class50_0.String_31).Double_0 > 0.0)
			{
				this.bool_0 = true;
				return Class31.smethod_4(this.class50_0.String_31, this.class50_0.Class50_0.Double_0, this.class50_0);
			}
			return 9999.0;
		}

		private void method_14(bool bool_1, out double[] double_2, out double[] double_3)
		{
			double_3 = new double[this.double_0.Length];
			double_2 = new double[this.double_0.Length];
			foreach (Class50 item in this.list_2)
			{
				for (int i = 0; i < item.List_0.Count; i++)
				{
					int num = Class56.smethod_2(item, item.List_0[i]);
					num = ((this.double_0.Length > num) ? num : (this.double_0.Length - 1));
					if ((!bool_1 || double.IsNaN(this.double_0[num])) && i < item.List_0.Count)
					{
						item.List_0[i].method_17(out var double_4, out var double_5);
						int num2 = Class56.smethod_3(item.List_0[i]);
						double_4 /= (double)num2;
						double_5 /= (double)num2;
						for (int j = 0; j < num2; j++)
						{
							double_2[num + j] = Math.Max(double_2[num + j], double_4);
							double_3[num + j] = Math.Max(double_3[num + j], double_5);
						}
					}
				}
			}
		}

		private double method_15()
		{
			return this.method_12() - this.method_18() * (double)(this.int_0 + 1) - this.class50_0.Double_19 - this.class50_0.Double_21;
		}

		private double method_16()
		{
			double num = 0.0;
			double[] array = this.double_0;
			foreach (double num2 in array)
			{
				if (!double.IsNaN(num2))
				{
					num += num2;
					continue;
				}
				throw new Exception("CssTable Algorithm error: There's a NaN in column widths");
			}
			return num + this.method_18() * (double)(this.double_0.Length + 1) + (this.class50_0.Double_19 + this.class50_0.Double_21);
		}

		private static int smethod_6(Class50 class50_4)
		{
			return Math.Max(1, Convert.ToInt32(Class31.smethod_3(class50_4.method_13("span"), 1.0)));
		}

		private double[] method_17()
		{
			if (this.double_1 == null)
			{
				this.double_1 = new double[this.double_0.Length];
				foreach (Class50 item in this.list_2)
				{
					foreach (Class50 item2 in item.List_0)
					{
						int num = Class56.smethod_3(item2);
						int num2 = Class56.smethod_2(item, item2);
						int num3 = Math.Min(num2 + num, this.double_1.Length) - 1;
						double num4 = this.method_8(item, item2, num2, num);
						double num5 = num - 1;
						double num6 = this.method_18();
						this.double_1[num3] = Math.Max(this.double_1[num3], item2.method_15() - (num4 + num5 * num6));
					}
				}
			}
			return this.double_1;
		}

		private double method_18()
		{
			return (this.class50_0.String_13 == "collapse") ? (-1.0) : this.class50_0.Double_30;
		}

		private static double smethod_7(Class50 class50_4)
		{
			return (class50_4.String_13 == "collapse") ? (-1.0) : class50_4.Double_30;
		}

		private double method_19()
		{
			return (this.class50_0.String_13 == "collapse") ? (-1.0) : this.class50_0.Double_31;
		}
	}
}

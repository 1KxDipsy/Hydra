using System;
using System.Collections.Generic;
using System.Globalization;
using ns10;
using ns11;
using ns13;
using ns14;
using ns16;

namespace ns0
{
	internal class Class50 : Class49, IDisposable
	{
		private Class50 class50_0;

		protected HtmlContainerInt htmlContainerInt_0;

		private readonly Class63 class63_0;

		private readonly List<Class59> list_0 = new List<Class59>();

		private readonly List<Class50> list_1 = new List<Class50>();

		private readonly List<Class58> list_2 = new List<Class58>();

		private readonly List<Class58> list_3 = new List<Class58>();

		private readonly Dictionary<Class58, RRect> dictionary_0 = new Dictionary<Class58, RRect>();

		private Class29 class29_0;

		internal bool bool_0;

		protected bool bool_1;

		private Class50 class50_1;

		private Class58 class58_0;

		private Class58 class58_1;

		private Class43 class43_0;

		public HtmlContainerInt HtmlContainerInt_0
		{
			get
			{
				return this.htmlContainerInt_0 ?? (this.htmlContainerInt_0 = ((this.class50_0 != null) ? this.class50_0.HtmlContainerInt_0 : null));
			}
			set
			{
				this.htmlContainerInt_0 = value;
			}
		}

		public Class50 Class50_0
		{
			get
			{
				return this.class50_0;
			}
			set
			{
				if (this.class50_0 != null)
				{
					this.class50_0.List_0.Remove(this);
				}
				this.class50_0 = value;
				if (value != null)
				{
					this.class50_0.List_0.Add(this);
				}
			}
		}

		public List<Class50> List_0 => this.list_1;

		public bool Boolean_1 => this.class63_0 != null && this.class63_0.String_0.Equals("br", StringComparison.InvariantCultureIgnoreCase);

		public bool Boolean_2 => (base.String_41 == "inline" || base.String_41 == "inline-block") && !this.Boolean_1;

		public bool Boolean_3 => base.String_41 == "block";

		public virtual bool Boolean_7 => this.Class63_0 != null && this.Class63_0.String_0 == "a" && !this.Class63_0.method_1("id");

		public virtual bool Boolean_6
		{
			get
			{
				if (base.String_45 == "fixed")
				{
					return true;
				}
				if (this.Class50_0 == null)
				{
					return false;
				}
				Class50 @class = this;
				while (@class.Class50_0 != null && @class != @class.Class50_0)
				{
					@class = @class.Class50_0;
					if (@class.String_45 == "fixed")
					{
						return true;
					}
				}
				return false;
			}
		}

		public virtual string String_65 => this.method_13("href");

		public Class50 Class50_1
		{
			get
			{
				if (this.Class50_0 == null)
				{
					return this;
				}
				Class50 @class = this.Class50_0;
				while (!@class.Boolean_3 && @class.String_41 != "list-item" && @class.String_41 != "table" && @class.String_41 != "table-cell" && @class.Class50_0 != null)
				{
					@class = @class.Class50_0;
				}
				if (@class == null)
				{
					throw new Exception("There's no containing block on the chain");
				}
				return @class;
			}
		}

		public Class63 Class63_0 => this.class63_0;

		public bool Boolean_4 => this.List_3.Count == 1 && this.List_3[0].Boolean_3;

		public bool Boolean_5
		{
			get
			{
				if ((this.List_3.Count != 0 || this.List_0.Count != 0) && (this.List_3.Count != 1 || !this.List_3[0].Boolean_4))
				{
					foreach (Class59 item in this.List_3)
					{
						if (!item.Boolean_4)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		public Class29 Class29_0
		{
			get
			{
				return this.class29_0;
			}
			set
			{
				this.class29_0 = value;
				this.list_0.Clear();
			}
		}

		internal List<Class58> List_1 => this.list_2;

		internal List<Class58> List_2 => this.list_3;

		internal Dictionary<Class58, RRect> Dictionary_0 => this.dictionary_0;

		internal List<Class59> List_3 => this.list_0;

		internal Class59 Class59_0 => this.List_3[0];

		internal Class58 Class58_0
		{
			get
			{
				return this.class58_0;
			}
			set
			{
				this.class58_0 = value;
			}
		}

		internal Class58 Class58_1
		{
			get
			{
				return this.class58_1;
			}
			set
			{
				this.class58_1 = value;
			}
		}

		public Class50(Class50 class50_2, Class63 class63_1)
		{
			if (class50_2 != null)
			{
				this.class50_0 = class50_2;
				this.class50_0.List_0.Add(this);
			}
			this.class63_0 = class63_1;
		}

		public static Class50 smethod_0(Class63 class63_1, Class50 class50_2 = null)
		{
			ArgChecker.AssertArgNotNull(class63_1, "tag");
			if (class63_1.String_0 == "img")
			{
				return new Class53(class50_2, class63_1);
			}
			if (class63_1.String_0 == "iframe")
			{
				return new Class51(class50_2, class63_1);
			}
			if (class63_1.String_0 == "hr")
			{
				return new Class52(class50_2, class63_1);
			}
			return new Class50(class50_2, class63_1);
		}

		public static Class50 smethod_1(Class50 class50_2, Class63 class63_1 = null, Class50 class50_3 = null)
		{
			ArgChecker.AssertArgNotNull(class50_2, "parent");
			Class50 @class = new Class50(class50_2, class63_1);
			@class.method_19();
			if (class50_3 != null)
			{
				@class.method_7(class50_3);
			}
			return @class;
		}

		public static Class50 smethod_2()
		{
			Class50 @class = new Class50(null, null);
			@class.String_41 = "block";
			return @class;
		}

		public static Class50 smethod_3(Class50 class50_2, Class63 class63_1 = null, Class50 class50_3 = null)
		{
			ArgChecker.AssertArgNotNull(class50_2, "parent");
			Class50 @class = Class50.smethod_1(class50_2, class63_1, class50_3);
			@class.String_41 = "block";
			return @class;
		}

		public void method_5(RGraphics rgraphics_0)
		{
			try
			{
				this.vmethod_4(rgraphics_0);
			}
			catch (Exception exception_)
			{
				this.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Layout, "Exception in box layout", exception_);
			}
		}

		public void method_6(RGraphics rgraphics_0)
		{
			try
			{
				if (!(base.String_41 != "none") || !(base.String_52 == "visible"))
				{
					return;
				}
				if (base.String_45 == "fixed")
				{
					rgraphics_0.SuspendClipping();
				}
				bool flag;
				if (!(flag = this.Dictionary_0.Count == 0))
				{
					RRect clip = rgraphics_0.GetClip();
					RRect rRect_ = this.Class50_1.RRect_1;
					rRect_.Double_0 -= 2.0;
					rRect_.Width += 2.0;
					if (!this.Boolean_6)
					{
						rRect_.Offset(this.HtmlContainerInt_0.ScrollOffset);
					}
					clip.Intersect(rRect_);
					if (clip != RRect.Empty)
					{
						flag = true;
					}
				}
				if (flag)
				{
					this.vmethod_6(rgraphics_0);
				}
				if (base.String_45 == "fixed")
				{
					rgraphics_0.ResumeClipping();
				}
			}
			catch (Exception exception_)
			{
				this.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Paint, "Exception in box paint", exception_);
			}
		}

		public void method_7(Class50 class50_2)
		{
			int num = this.class50_0.List_0.IndexOf(class50_2);
			if (num < 0)
			{
				throw new Exception("before box doesn't exist on parent");
			}
			this.class50_0.List_0.Remove(this);
			this.class50_0.List_0.Insert(num, this);
		}

		public void method_8(Class50 class50_2)
		{
			foreach (Class50 item in class50_2.list_1)
			{
				item.class50_0 = this;
			}
			this.list_1.AddRange(class50_2.list_1);
			class50_2.list_1.Clear();
		}

		public void method_9()
		{
			this.list_0.Clear();
			int i = 0;
			bool flag;
			bool flag2 = (flag = base.String_51 == "pre" || base.String_51 == "pre-wrap") || base.String_51 == "pre-line";
			while (i < this.class29_0.Int32_1)
			{
				for (; i < this.class29_0.Int32_1 && this.class29_0[i] == '\r'; i++)
				{
				}
				if (i >= this.class29_0.Int32_1)
				{
					continue;
				}
				int j;
				for (j = i; j < this.class29_0.Int32_1 && char.IsWhiteSpace(this.class29_0[j]) && this.class29_0[j] != '\n'; j++)
				{
				}
				if (j > i)
				{
					if (flag)
					{
						this.list_0.Add(new Class61(this, Class27.smethod_1(this.class29_0.method_4(i, j - i)), bool_2: false, bool_3: false));
					}
				}
				else
				{
					for (j = i; j < this.class29_0.Int32_1 && !char.IsWhiteSpace(this.class29_0[j]) && this.class29_0[j] != '-'; j++)
					{
						if (!(base.String_54 != "break-all"))
						{
							break;
						}
						if (Class22.smethod_0(this.class29_0[j]))
						{
							break;
						}
					}
					if (j < this.class29_0.Int32_1 && (this.class29_0[j] == '-' || base.String_54 == "break-all" || Class22.smethod_0(this.class29_0[j])))
					{
						j++;
					}
					if (j > i)
					{
						bool bool_ = !flag && i > 0 && this.list_0.Count == 0 && char.IsWhiteSpace(this.class29_0[i - 1]);
						bool bool_2 = !flag && j < this.class29_0.Int32_1 && char.IsWhiteSpace(this.class29_0[j]);
						this.list_0.Add(new Class61(this, Class27.smethod_1(this.class29_0.method_4(i, j - i)), bool_, bool_2));
					}
				}
				if (j < this.class29_0.Int32_1 && this.class29_0[j] == '\n')
				{
					j++;
					if (flag2)
					{
						this.list_0.Add(new Class61(this, "\n", bool_2: false, bool_3: false));
					}
				}
				i = j;
			}
		}

		public virtual void Dispose()
		{
			if (this.class43_0 != null)
			{
				this.class43_0.Dispose();
			}
			foreach (Class50 item in this.List_0)
			{
				item.Dispose();
			}
		}

		protected virtual void vmethod_4(RGraphics rgraphics_0)
		{
			if (base.String_41 != "none")
			{
				this.method_30();
				this.vmethod_5(rgraphics_0);
			}
			if (!this.Boolean_3 && !(base.String_41 == "list-item") && !(base.String_41 == "table") && !(base.String_41 == "inline-table") && !(base.String_41 == "table-cell"))
			{
				Class50 @class = Class25.smethod_3(this);
				if (@class != null)
				{
					if (base.RPoint_0 == RPoint.Empty)
					{
						base.RPoint_0 = @class.RPoint_0;
					}
					base.Double_2 = @class.Double_2;
				}
			}
			else
			{
				if (base.String_41 != "table-cell" && base.String_41 != "table")
				{
					double num = this.Class50_1.RSize_0.Width - this.Class50_1.Double_10 - this.Class50_1.Double_12 - this.Class50_1.Double_19 - this.Class50_1.Double_21;
					if (base.String_30 != "auto" && !string.IsNullOrEmpty(base.String_30))
					{
						num = Class31.smethod_4(base.String_30, num, this);
					}
					base.RSize_0 = new RSize(num, base.RSize_0.Height);
					base.RSize_0 = new RSize(num - base.Double_15 - base.Double_17, base.RSize_0.Height);
				}
				if (base.String_41 != "table-cell")
				{
					Class50 class2 = Class25.smethod_3(this);
					if (base.String_45 == "fixed")
					{
						double num2 = 0.0;
						double num3 = 0.0;
					}
					else
					{
						double num2 = this.Class50_1.RPoint_0.Double_0 + this.Class50_1.Double_10 + base.Double_15 + this.Class50_1.Double_19;
						double num3 = ((class2 == null && this.Class50_0 != null) ? this.Class50_0.Double_4 : ((this.Class50_0 == null) ? base.RPoint_0.Double_1 : 0.0)) + this.method_20(class2) + ((class2 != null) ? (class2.Double_2 + class2.Double_20) : 0.0);
						base.RPoint_0 = new RPoint(num2, num3);
						base.Double_2 = num3;
					}
				}
				if (!(base.String_41 == "table") && !(base.String_41 == "inline-table"))
				{
					if (Class25.smethod_1(this))
					{
						base.Double_2 = base.RPoint_0.Double_1;
						Class55.smethod_1(rgraphics_0, this);
					}
					else if (this.list_1.Count > 0)
					{
						foreach (Class50 item in this.List_0)
						{
							item.method_5(rgraphics_0);
						}
						base.Double_1 = this.method_22();
						base.Double_2 = this.method_23();
					}
				}
				else
				{
					Class56.smethod_1(rgraphics_0, this);
				}
			}
			base.Double_2 = Math.Max(base.Double_2, base.RPoint_0.Double_1 + base.Double_7);
			this.method_11(rgraphics_0);
			if (!this.Boolean_6)
			{
				double width = Math.Max(this.method_15() + Class50.smethod_5(this), (base.RSize_0.Width < 90999.0) ? (base.Double_1 - this.HtmlContainerInt_0.Class50_0.RPoint_0.Double_0) : 0.0);
				this.HtmlContainerInt_0.ActualSize = Class22.smethod_3(this.HtmlContainerInt_0.ActualSize, new RSize(width, base.Double_2 - this.HtmlContainerInt_0.Class50_0.RPoint_0.Double_1));
			}
		}

		internal virtual void vmethod_5(RGraphics rgraphics_0)
		{
			if (this.bool_1)
			{
				return;
			}
			if (base.String_34 != "none" && this.class43_0 == null)
			{
				this.class43_0 = new Class43(this.HtmlContainerInt_0, new Delegate6<RImage, RRect, bool>(method_31));
				this.class43_0.method_0(base.String_34, (this.Class63_0 != null) ? this.Class63_0.Dictionary_0 : null);
			}
			base.method_3(rgraphics_0);
			if (this.List_3.Count > 0)
			{
				foreach (Class59 item in this.List_3)
				{
					item.Double_2 = ((item.String_0 != "\n") ? rgraphics_0.MeasureString(item.String_0, base.RFont_1).Width : 0.0);
					item.Double_5 = base.RFont_1.Height;
				}
			}
			this.bool_1 = true;
		}

		protected sealed override Class49 vmethod_3()
		{
			return this.class50_0;
		}

		private int method_10()
		{
			bool flag = !string.IsNullOrEmpty(this.Class50_0.method_13("reversed"));
			if (!int.TryParse(this.Class50_0.method_13("start"), out var result))
			{
				if (flag)
				{
					result = 0;
					foreach (Class50 item in this.Class50_0.List_0)
					{
						if (item.String_41 == "list-item")
						{
							result++;
						}
					}
				}
				else
				{
					result = 1;
				}
			}
			foreach (Class50 item2 in this.Class50_0.List_0)
			{
				if (!item2.Equals(this))
				{
					if (item2.String_41 == "list-item")
					{
						result += ((!flag) ? 1 : (-1));
					}
					continue;
				}
				return result;
			}
			return result;
		}

		private void method_11(RGraphics rgraphics_0)
		{
			if (!(base.String_41 == "list-item") || !(base.String_64 != "none"))
			{
				return;
			}
			if (this.class50_1 == null)
			{
				this.class50_1 = new Class50(null, null);
				this.class50_1.method_19(this);
				this.class50_1.String_41 = "inline";
				this.class50_1.HtmlContainerInt_0 = this.HtmlContainerInt_0;
				if (base.String_64.Equals("disc", StringComparison.InvariantCultureIgnoreCase))
				{
					this.class50_1.Class29_0 = new Class29("•");
				}
				else if (base.String_64.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
				{
					this.class50_1.Class29_0 = new Class29("o");
				}
				else if (base.String_64.Equals("square", StringComparison.InvariantCultureIgnoreCase))
				{
					this.class50_1.Class29_0 = new Class29("♠");
				}
				else if (base.String_64.Equals("decimal", StringComparison.InvariantCultureIgnoreCase))
				{
					this.class50_1.Class29_0 = new Class29(this.method_10().ToString(CultureInfo.InvariantCulture) + ".");
				}
				else if (base.String_64.Equals("decimal-leading-zero", StringComparison.InvariantCultureIgnoreCase))
				{
					this.class50_1.Class29_0 = new Class29(this.method_10().ToString("00", CultureInfo.InvariantCulture) + ".");
				}
				else
				{
					this.class50_1.Class29_0 = new Class29(Class22.smethod_12(this.method_10(), base.String_64) + ".");
				}
				this.class50_1.method_9();
				this.class50_1.vmethod_4(rgraphics_0);
				this.class50_1.RSize_0 = new RSize(this.class50_1.List_3[0].Double_2, this.class50_1.List_3[0].Double_5);
			}
			this.class50_1.List_3[0].Double_0 = base.RPoint_0.Double_0 - this.class50_1.RSize_0.Width - 5.0;
			this.class50_1.List_3[0].Double_1 = base.RPoint_0.Double_1 + base.Double_9;
		}

		internal Class59 method_12(Class50 class50_2, Class58 class58_2)
		{
			if (class50_2.List_3.Count == 0 && class50_2.List_0.Count == 0)
			{
				return null;
			}
			if (class50_2.List_3.Count > 0)
			{
				foreach (Class59 item in class50_2.List_3)
				{
					if (class58_2.List_1.Contains(item))
					{
						return item;
					}
				}
				return null;
			}
			foreach (Class50 item2 in class50_2.List_0)
			{
				Class59 @class = this.method_12(item2, class58_2);
				if (@class != null)
				{
					return @class;
				}
			}
			return null;
		}

		internal string method_13(string string_67)
		{
			return this.method_14(string_67, string.Empty);
		}

		internal string method_14(string string_67, string string_68)
		{
			return (this.Class63_0 != null) ? this.Class63_0.method_2(string_67, string_68) : string_68;
		}

		internal double method_15()
		{
			double double_ = 0.0;
			Class59 class59_ = null;
			Class50.smethod_4(this, ref double_, ref class59_);
			double num = 0.0;
			if (class59_ != null)
			{
				for (Class50 @class = class59_.Class50_0; @class != null; @class = ((@class != this) ? @class.Class50_0 : null))
				{
					num += @class.Double_21 + @class.Double_12 + @class.Double_19 + @class.Double_10;
				}
			}
			return double_ + num;
		}

		private static void smethod_4(Class50 class50_2, ref double double_25, ref Class59 class59_0)
		{
			if (class50_2.List_3.Count > 0)
			{
				foreach (Class59 item in class50_2.List_3)
				{
					if (item.Double_2 > double_25)
					{
						double_25 = item.Double_2;
						class59_0 = item;
					}
				}
				return;
			}
			foreach (Class50 item2 in class50_2.List_0)
			{
				Class50.smethod_4(item2, ref double_25, ref class59_0);
			}
		}

		private static double smethod_5(Class50 class50_2)
		{
			double num = 0.0;
			if (class50_2.RSize_0.Width > 90999.0 || (class50_2.Class50_0 != null && class50_2.Class50_0.RSize_0.Width > 90999.0))
			{
				while (class50_2 != null)
				{
					num += class50_2.Double_15 + class50_2.Double_17;
					class50_2 = class50_2.Class50_0;
				}
			}
			return num;
		}

		internal double method_16(Class50 class50_2, double double_25)
		{
			foreach (Class58 key in class50_2.Dictionary_0.Keys)
			{
				double_25 = Math.Max(double_25, class50_2.Dictionary_0[key].Bottom);
			}
			foreach (Class50 item in class50_2.List_0)
			{
				double_25 = Math.Max(double_25, this.method_16(item, double_25));
			}
			return double_25;
		}

		internal void method_17(out double double_25, out double double_26)
		{
			double double_27 = 0.0;
			double double_28 = 0.0;
			double double_29 = 0.0;
			double double_30 = 0.0;
			Class50.smethod_6(this, ref double_27, ref double_28, ref double_29, ref double_30);
			double_26 = double_29 + double_28;
			double_25 = double_29 + ((double_27 < 90999.0) ? double_27 : 0.0);
		}

		private static void smethod_6(Class50 class50_2, ref double double_25, ref double double_26, ref double double_27, ref double double_28)
		{
			double? num = null;
			if (class50_2.String_41 != "inline" && class50_2.String_41 != "table-cell" && class50_2.String_51 != "nowrap")
			{
				num = double_26;
				double_26 = double_28;
			}
			double_27 += class50_2.Double_19 + class50_2.Double_21 + class50_2.Double_12 + class50_2.Double_10;
			if (class50_2.String_41 == "table")
			{
				double_27 += Class56.smethod_0(class50_2);
			}
			if (class50_2.List_3.Count > 0)
			{
				foreach (Class59 item in class50_2.List_3)
				{
					double_26 += item.Double_3 + (item.Boolean_1 ? item.Class50_0.Double_26 : 0.0);
					double_25 = Math.Max(double_25, item.Double_2);
				}
				if (class50_2.List_3.Count > 0 && !class50_2.List_3[class50_2.List_3.Count - 1].Boolean_2)
				{
					double_26 -= class50_2.List_3[class50_2.List_3.Count - 1].Double_4;
				}
			}
			else
			{
				for (int i = 0; i < class50_2.List_0.Count; i++)
				{
					Class50 @class = class50_2.List_0[i];
					double_28 += @class.Double_15 + @class.Double_17;
					Class50.smethod_6(@class, ref double_25, ref double_26, ref double_27, ref double_28);
					double_28 -= @class.Double_15 + @class.Double_17;
				}
			}
			if (num.HasValue)
			{
				double_26 = Math.Max(double_26, num.Value);
			}
		}

		internal bool method_18()
		{
			return this.Class50_0 != null && Class25.smethod_1(this.Class50_0);
		}

		internal void method_19(Class50 class50_2 = null, bool bool_2 = false)
		{
			base.method_4(class50_2 ?? this.Class50_0, bool_2);
		}

		protected double method_20(Class49 class49_0)
		{
			double num2 = ((class49_0 != null) ? (base.Double_14 = Math.Max(class49_0.Double_16, base.Double_13)) : ((this.class50_0 == null || !(base.Double_9 < 0.1) || !(base.Double_11 < 0.1) || !(this.class50_0.Double_9 < 0.1) || !(this.class50_0.Double_11 < 0.1)) ? base.Double_13 : Math.Max(0.0, base.Double_13 - Math.Max(this.class50_0.Double_13, this.class50_0.Double_14))));
			if (num2 < 0.1 && this.Class63_0 != null && this.Class63_0.String_0 == "hr")
			{
				num2 = base.method_0() * 1.100000023841858;
			}
			return num2;
		}

		public bool method_21()
		{
			HtmlContainerInt htmlContainerInt = this.HtmlContainerInt_0;
			if (base.RSize_0.Height >= htmlContainerInt.PageSize.Height)
			{
				return false;
			}
			double num = (base.RPoint_0.Double_1 - (double)htmlContainerInt.MarginTop) % htmlContainerInt.PageSize.Height;
			if (num > (base.Double_2 - (double)htmlContainerInt.MarginTop) % htmlContainerInt.PageSize.Height)
			{
				double num2 = htmlContainerInt.PageSize.Height - num;
				base.RPoint_0 = new RPoint(base.RPoint_0.Double_0, base.RPoint_0.Double_1 + num2 + 1.0);
				return true;
			}
			return false;
		}

		private double method_22()
		{
			if (base.Double_1 > 90999.0)
			{
				double num = 0.0;
				foreach (Class50 item in this.List_0)
				{
					num = Math.Max(num, item.Double_1 + item.Double_17);
				}
				return num + base.Double_12 + base.Double_17 + base.Double_21;
			}
			return base.Double_1;
		}

		private double method_23()
		{
			double num = 0.0;
			if (this.Class50_0 != null && this.Class50_0.List_0.IndexOf(this) == this.Class50_0.List_0.Count - 1 && this.class50_0.Double_16 < 0.1)
			{
				double num2 = this.list_1[this.list_1.Count - 1].Double_16;
				num = ((base.String_32 == "auto") ? Math.Max(base.Double_16, num2) : num2);
			}
			return Math.Max(base.Double_2, this.list_1[this.list_1.Count - 1].Double_2 + num + base.Double_11 + base.Double_20);
		}

		internal void method_24(double double_25)
		{
			List<Class58> list = new List<Class58>();
			foreach (Class58 key in this.Dictionary_0.Keys)
			{
				list.Add(key);
			}
			foreach (Class58 item in list)
			{
				RRect rRect = this.Dictionary_0[item];
				this.Dictionary_0[item] = new RRect(rRect.Double_0, rRect.Double_1 + double_25, rRect.Width, rRect.Height);
			}
			foreach (Class59 item2 in this.List_3)
			{
				item2.Double_1 += double_25;
			}
			foreach (Class50 item3 in this.List_0)
			{
				item3.method_24(double_25);
			}
			if (this.class50_1 != null)
			{
				this.class50_1.method_24(double_25);
			}
			base.RPoint_0 = new RPoint(base.RPoint_0.Double_0, base.RPoint_0.Double_1 + double_25);
		}

		protected virtual void vmethod_6(RGraphics rgraphics_0)
		{
			if (!(base.String_41 != "none") || (!(base.String_41 != "table-cell") && !(base.String_43 != "hide") && this.Boolean_5))
			{
				return;
			}
			bool flag = Class28.smethod_1(rgraphics_0, this);
			List<RRect> list = ((this.Dictionary_0.Count == 0) ? new List<RRect>(new RRect[1] { base.RRect_0 }) : new List<RRect>(this.Dictionary_0.Values));
			RRect clip = rgraphics_0.GetClip();
			RRect[] array = list.ToArray();
			RPoint rPoint = RPoint.Empty;
			if (!this.Boolean_6)
			{
				rPoint = this.HtmlContainerInt_0.ScrollOffset;
			}
			for (int i = 0; i < array.Length; i++)
			{
				RRect rrect_ = array[i];
				rrect_.Offset(rPoint);
				if (this.method_25(rrect_, clip))
				{
					this.method_26(rgraphics_0, rrect_, i == 0, i == array.Length - 1);
					Class38.smethod_0(rgraphics_0, this, rrect_, i == 0, i == array.Length - 1);
				}
			}
			this.method_27(rgraphics_0, rPoint);
			for (int j = 0; j < array.Length; j++)
			{
				RRect rrect_2 = array[j];
				rrect_2.Offset(rPoint);
				if (this.method_25(rrect_2, clip))
				{
					this.method_28(rgraphics_0, rrect_2, j == 0, j == array.Length - 1);
				}
			}
			foreach (Class50 item in this.List_0)
			{
				if (item.String_45 != "absolute" && !item.Boolean_6)
				{
					item.method_6(rgraphics_0);
				}
			}
			foreach (Class50 item2 in this.List_0)
			{
				if (item2.String_45 == "absolute")
				{
					item2.method_6(rgraphics_0);
				}
			}
			foreach (Class50 item3 in this.List_0)
			{
				if (item3.Boolean_6)
				{
					item3.method_6(rgraphics_0);
				}
			}
			if (flag)
			{
				rgraphics_0.PopClip();
			}
			if (this.class50_1 != null)
			{
				this.class50_1.method_6(rgraphics_0);
			}
		}

		private bool method_25(RRect rrect_0, RRect rrect_1)
		{
			rrect_0.Double_0 -= 2.0;
			rrect_0.Width += 2.0;
			rrect_1.Intersect(rrect_0);
			if (rrect_1 != RRect.Empty)
			{
				return true;
			}
			return false;
		}

		protected void method_26(RGraphics rgraphics_0, RRect rrect_0, bool bool_2, bool bool_3)
		{
			if (!(rrect_0.Width > 0.0) || !(rrect_0.Height > 0.0))
			{
				return;
			}
			RBrush rBrush = null;
			if (base.String_37 != "none")
			{
				rBrush = rgraphics_0.GetLinearGradientBrush(rrect_0, base.RColor_5, base.RColor_6, base.Double_27);
			}
			else if (Class28.smethod_0(base.RColor_5))
			{
				rBrush = rgraphics_0.GetSolidBrush(base.RColor_5);
			}
			if (rBrush != null)
			{
				RGraphicsPath rGraphicsPath = null;
				if (base.Boolean_0)
				{
					rGraphicsPath = Class28.smethod_4(rgraphics_0, rrect_0, base.Double_22, base.Double_23, base.Double_24, base.Double_25);
				}
				object prevMode = null;
				if (this.HtmlContainerInt_0 != null && !this.HtmlContainerInt_0.AvoidGeometryAntialias && base.Boolean_0)
				{
					prevMode = rgraphics_0.SetAntiAliasSmoothingMode();
				}
				if (rGraphicsPath != null)
				{
					rgraphics_0.DrawPath(rBrush, rGraphicsPath);
				}
				else
				{
					rgraphics_0.DrawRectangle(rBrush, Math.Ceiling(rrect_0.Double_0), Math.Ceiling(rrect_0.Double_1), rrect_0.Width, rrect_0.Height);
				}
				rgraphics_0.ReturnPreviousSmoothingMode(prevMode);
				rGraphicsPath?.Dispose();
				rBrush.Dispose();
			}
			if (this.class43_0 != null && this.class43_0.RImage_0 != null && bool_2)
			{
				Class37.smethod_0(rgraphics_0, this, this.class43_0, rrect_0);
			}
		}

		private void method_27(RGraphics rgraphics_0, RPoint rpoint_1)
		{
			if (base.String_30.Length <= 0)
			{
				return;
			}
			bool rtl = base.String_42 == "rtl";
			foreach (Class59 item in this.List_3)
			{
				if (item.Boolean_5)
				{
					continue;
				}
				RRect clip = rgraphics_0.GetClip();
				RRect rRect_ = item.RRect_0;
				rRect_.Offset(rpoint_1);
				clip.Intersect(rRect_);
				if (!(clip != RRect.Empty))
				{
					continue;
				}
				RPoint point = new RPoint(item.Double_0 + rpoint_1.Double_0, item.Double_1 + rpoint_1.Double_1);
				if (item.Boolean_0)
				{
					Class58 @class = Class25.smethod_15(item);
					double num = ((item.Double_8 > -1.0) ? item.Double_8 : ((@class.List_1[0] == item || !item.Boolean_1) ? 0.0 : (0.0 - base.Double_26)));
					bool flag = item.Boolean_2 && !@class.method_5(item);
					RRect rect = new RRect(width: ((item.Double_9 > -1.0) ? item.Double_9 : (item.Double_2 + (flag ? base.Double_26 : 0.0))) - num, x: item.Double_0 + rpoint_1.Double_0 + num, y: item.Double_1 + rpoint_1.Double_1, height: @class.Double_0);
					rgraphics_0.DrawRectangle(this.method_33(rgraphics_0, bool_2: false), rect.Double_0, rect.Double_1, rect.Width, rect.Height);
					if (this.HtmlContainerInt_0.RColor_0 != RColor.Empty && (item.Double_8 > 0.0 || item.Int32_1 > -1))
					{
						rgraphics_0.PushClipExclude(rect);
						rgraphics_0.DrawString(item.String_0, base.RFont_1, base.RColor_4, point, new RSize(item.Double_2, item.Double_5), rtl);
						rgraphics_0.PopClip();
						rgraphics_0.PushClip(rect);
						rgraphics_0.DrawString(item.String_0, base.RFont_1, this.method_32(), point, new RSize(item.Double_2, item.Double_5), rtl);
						rgraphics_0.PopClip();
					}
					else
					{
						rgraphics_0.DrawString(item.String_0, base.RFont_1, this.method_32(), point, new RSize(item.Double_2, item.Double_5), rtl);
					}
				}
				else
				{
					rgraphics_0.DrawString(item.String_0, base.RFont_1, base.RColor_4, point, new RSize(item.Double_2, item.Double_5), rtl);
				}
			}
		}

		protected void method_28(RGraphics rgraphics_0, RRect rrect_0, bool bool_2, bool bool_3)
		{
			if (!string.IsNullOrEmpty(base.String_50) && !(base.String_50 == "none"))
			{
				double num = 0.0;
				if (base.String_50 == "underline")
				{
					num = Math.Round(rrect_0.Top + base.RFont_1.UnderlineOffset);
				}
				else if (base.String_50 == "line-through")
				{
					num = rrect_0.Top + rrect_0.Height / 2.0;
				}
				else if (base.String_50 == "overline")
				{
					num = rrect_0.Top;
				}
				num -= base.Double_11 - base.Double_20;
				double num2 = rrect_0.Double_0;
				if (bool_2)
				{
					num2 += base.Double_10 + base.Double_19;
				}
				double num3 = rrect_0.Right;
				if (bool_3)
				{
					num3 -= base.Double_12 + base.Double_21;
				}
				RPen pen = rgraphics_0.GetPen(base.RColor_4);
				pen.Width = 1.0;
				pen.DashStyle = RDashStyle.Solid;
				rgraphics_0.DrawLine(pen, num2, num, num3, num);
			}
		}

		internal void method_29(Class58 class58_2, double double_25)
		{
			if (this.Dictionary_0.ContainsKey(class58_2))
			{
				RRect rRect = this.Dictionary_0[class58_2];
				this.Dictionary_0[class58_2] = new RRect(rRect.Double_0, rRect.Double_1 + double_25, rRect.Width, rRect.Height);
			}
		}

		internal void method_30()
		{
			this.dictionary_0.Clear();
		}

		private void method_31(RImage rimage_0, RRect rrect_0, bool bool_2)
		{
			if (rimage_0 != null && bool_2)
			{
				this.HtmlContainerInt_0.RequestRefresh(layout: false);
			}
		}

		protected RColor method_32()
		{
			return (this.HtmlContainerInt_0.RColor_0 != RColor.Empty) ? this.HtmlContainerInt_0.RColor_0 : base.RColor_4;
		}

		protected RBrush method_33(RGraphics rgraphics_0, bool bool_2)
		{
			RColor rColor_ = this.HtmlContainerInt_0.RColor_1;
			if (rColor_ != RColor.Empty)
			{
				if (bool_2 && rColor_.Byte_3 > 180)
				{
					return rgraphics_0.GetSolidBrush(RColor.FromArgb(180, rColor_.Byte_0, rColor_.Byte_1, rColor_.Byte_2));
				}
				return rgraphics_0.GetSolidBrush(rColor_);
			}
			return rgraphics_0.GetSolidBrush(Class24.RColor_0);
		}

		protected override RFont vmethod_2(string string_67, double double_25, RFontStyle rfontStyle_0)
		{
			return this.HtmlContainerInt_0.RAdapter_0.GetFont(string_67, double_25, rfontStyle_0);
		}

		protected override RColor vmethod_1(string string_67)
		{
			return this.HtmlContainerInt_0.Class30_0.method_4(string_67);
		}

		protected override RPoint vmethod_0(string string_67, string string_68)
		{
			return new RPoint(Class31.smethod_5(string_67, this.HtmlContainerInt_0.PageSize.Width, this, null), Class31.smethod_5(string_68, this.HtmlContainerInt_0.PageSize.Height, this, null));
		}

		public override string ToString()
		{
			string text = ((this.Class63_0 != null) ? $"<{this.Class63_0.String_0}>" : "anon");
			if (this.Boolean_3)
			{
				return string.Format("{0}{1} Block {2}, Children:{3}", (this.Class50_0 == null) ? "Root: " : string.Empty, text, base.String_56, this.List_0.Count);
			}
			if (base.String_41 == "none")
			{
				return string.Format("{0}{1} None", (this.Class50_0 == null) ? "Root: " : string.Empty, text);
			}
			return string.Format("{0}{1} {2}: {3}", (this.Class50_0 == null) ? "Root: " : string.Empty, text, base.String_41, this.Class29_0);
		}
	}
}

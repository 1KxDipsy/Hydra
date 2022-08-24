using System;
using System.Collections.Generic;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class58
	{
		private readonly List<Class59> list_0;

		private readonly Class50 class50_0;

		private readonly Dictionary<Class50, RRect> dictionary_0;

		private readonly List<Class50> list_1;

		public List<Class50> List_0 => this.list_1;

		public List<Class59> List_1 => this.list_0;

		public Class50 Class50_0 => this.class50_0;

		public Dictionary<Class50, RRect> Dictionary_0 => this.dictionary_0;

		public double Double_0
		{
			get
			{
				double num = 0.0;
				foreach (KeyValuePair<Class50, RRect> item in this.dictionary_0)
				{
					num = Math.Max(num, item.Value.Height);
				}
				return num;
			}
		}

		public double Double_1
		{
			get
			{
				double num = 0.0;
				foreach (KeyValuePair<Class50, RRect> item in this.dictionary_0)
				{
					num = Math.Max(num, item.Value.Bottom);
				}
				return num;
			}
		}

		public Class58(Class50 class50_1)
		{
			this.dictionary_0 = new Dictionary<Class50, RRect>();
			this.list_1 = new List<Class50>();
			this.list_0 = new List<Class59>();
			this.class50_0 = class50_1;
			this.class50_0.List_1.Add(this);
		}

		internal void method_0(Class59 class59_0)
		{
			if (!this.List_1.Contains(class59_0))
			{
				this.List_1.Add(class59_0);
			}
			if (!this.List_0.Contains(class59_0.Class50_0))
			{
				this.List_0.Add(class59_0.Class50_0);
			}
		}

		internal List<Class59> method_1(Class50 class50_1)
		{
			List<Class59> list = new List<Class59>();
			foreach (Class59 item in this.List_1)
			{
				if (item.Class50_0.Equals(class50_1))
				{
					list.Add(item);
				}
			}
			return list;
		}

		internal void method_2(Class50 class50_1, double double_0, double double_1, double double_2, double double_3)
		{
			double num = class50_1.Double_19 + class50_1.Double_10;
			double num2 = class50_1.Double_21 + class50_1.Double_12;
			double num3 = class50_1.Double_18 + class50_1.Double_9;
			double num4 = class50_1.Double_20 + class50_1.Double_9;
			if ((class50_1.Class58_0 != null && class50_1.Class58_0.Equals(this)) || class50_1.Boolean_4)
			{
				double_0 -= num;
			}
			if ((class50_1.Class58_1 != null && class50_1.Class58_1.Equals(this)) || class50_1.Boolean_4)
			{
				double_2 += num2;
			}
			if (!class50_1.Boolean_4)
			{
				double_1 -= num3;
				double_3 += num4;
			}
			if (!this.Dictionary_0.ContainsKey(class50_1))
			{
				this.Dictionary_0.Add(class50_1, RRect.FromLTRB(double_0, double_1, double_2, double_3));
			}
			else
			{
				RRect rRect = this.Dictionary_0[class50_1];
				this.Dictionary_0[class50_1] = RRect.FromLTRB(Math.Min(rRect.Double_0, double_0), Math.Min(rRect.Double_1, double_1), Math.Max(rRect.Right, double_2), Math.Max(rRect.Bottom, double_3));
			}
			if (class50_1.Class50_0 != null && class50_1.Class50_0.Boolean_2)
			{
				this.method_2(class50_1.Class50_0, double_0, double_1, double_2, double_3);
			}
		}

		internal void method_3()
		{
			foreach (Class50 key in this.Dictionary_0.Keys)
			{
				key.Dictionary_0.Add(this, this.Dictionary_0[key]);
			}
		}

		internal void method_4(RGraphics rgraphics_0, Class50 class50_1, double double_0)
		{
			List<Class59> list = this.method_1(class50_1);
			if (!this.Dictionary_0.ContainsKey(class50_1))
			{
				return;
			}
			RRect rRect = this.Dictionary_0[class50_1];
			double num = 0.0;
			if (list.Count > 0)
			{
				num = list[0].Double_1 - rRect.Top;
			}
			else
			{
				Class59 @class = class50_1.method_12(class50_1, this);
				if (@class != null)
				{
					num = @class.Double_1 - rRect.Top;
				}
			}
			if (class50_1.Class50_0 != null && class50_1.Class50_0.Dictionary_0.ContainsKey(this) && rRect.Height < class50_1.Class50_0.Dictionary_0[this].Height)
			{
				RRect value = new RRect(rRect.Double_0, double_0 - num, rRect.Width, rRect.Height);
				this.Dictionary_0[class50_1] = value;
				class50_1.method_29(this, num);
			}
			foreach (Class59 item in list)
			{
				if (!item.Boolean_3)
				{
					item.Double_1 = double_0;
				}
			}
		}

		public bool method_5(Class59 class59_0)
		{
			int num = 0;
			while (true)
			{
				if (num < this.list_0.Count - 1)
				{
					if (this.list_0[num] == class59_0)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return !this.list_0[num + 1].Boolean_0;
		}

		public override string ToString()
		{
			string[] array = new string[this.List_1.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.List_1[i].String_0;
			}
			return string.Join(" ", array);
		}
	}
}

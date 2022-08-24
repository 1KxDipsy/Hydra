using System;
using System.Collections.Generic;
using ns0;
using ns11;
using ns13;
using ns14;

namespace ns10
{
	public sealed class CssData
	{
		private static readonly List<CssBlock> list_0 = new List<CssBlock>();

		private readonly Dictionary<string, Dictionary<string, List<CssBlock>>> dictionary_0 = new Dictionary<string, Dictionary<string, List<CssBlock>>>(StringComparer.InvariantCultureIgnoreCase);

		internal IDictionary<string, Dictionary<string, List<CssBlock>>> IDictionary_0 => this.dictionary_0;

		internal CssData()
		{
			this.dictionary_0.Add("all", new Dictionary<string, List<CssBlock>>(StringComparer.InvariantCultureIgnoreCase));
		}

		public static CssData Parse(RAdapter adapter, string stylesheet, bool combineWithDefault = true)
		{
			return new Class30(adapter).method_0(stylesheet, combineWithDefault);
		}

		public bool ContainsCssBlock(string className, string media = "all")
		{
			Dictionary<string, List<CssBlock>> value;
			return this.dictionary_0.TryGetValue(media, out value) && value.ContainsKey(className);
		}

		public IEnumerable<CssBlock> GetCssBlock(string className, string media = "all")
		{
			List<CssBlock> value = null;
			if (this.dictionary_0.TryGetValue(media, out var value2))
			{
				value2.TryGetValue(className, out value);
			}
			return value ?? CssData.list_0;
		}

		public void AddCssBlock(string media, CssBlock cssBlock)
		{
			if (!this.dictionary_0.TryGetValue(media, out var value))
			{
				value = new Dictionary<string, List<CssBlock>>(StringComparer.InvariantCultureIgnoreCase);
				this.dictionary_0.Add(media, value);
			}
			if (!value.ContainsKey(cssBlock.Class))
			{
				List<CssBlock> list = new List<CssBlock>();
				list.Add(cssBlock);
				value[cssBlock.Class] = list;
				return;
			}
			bool flag = false;
			List<CssBlock> list2 = value[cssBlock.Class];
			foreach (CssBlock item in list2)
			{
				if (item.EqualsSelector(cssBlock))
				{
					flag = true;
					item.Merge(cssBlock);
					break;
				}
			}
			if (!flag)
			{
				if (cssBlock.Selectors == null)
				{
					list2.Insert(0, cssBlock);
				}
				else
				{
					list2.Add(cssBlock);
				}
			}
		}

		public void Combine(CssData other)
		{
			ArgChecker.AssertArgNotNull(other, "other");
			foreach (KeyValuePair<string, Dictionary<string, List<CssBlock>>> item in other.IDictionary_0)
			{
				foreach (KeyValuePair<string, List<CssBlock>> item2 in item.Value)
				{
					using List<CssBlock>.Enumerator enumerator3 = item2.Value.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						this.AddCssBlock(cssBlock: enumerator3.Current, media: item.Key);
					}
				}
			}
		}

		public CssData Clone()
		{
			CssData cssData = new CssData();
			foreach (KeyValuePair<string, Dictionary<string, List<CssBlock>>> item in this.dictionary_0)
			{
				Dictionary<string, List<CssBlock>> dictionary = new Dictionary<string, List<CssBlock>>(StringComparer.InvariantCultureIgnoreCase);
				foreach (KeyValuePair<string, List<CssBlock>> item2 in item.Value)
				{
					List<CssBlock> list = new List<CssBlock>();
					foreach (CssBlock item3 in item2.Value)
					{
						list.Add(item3.Clone());
					}
					dictionary[item2.Key] = list;
				}
				cssData.dictionary_0[item.Key] = dictionary;
			}
			return cssData;
		}
	}
}

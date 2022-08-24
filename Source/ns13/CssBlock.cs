using System.Collections.Generic;
using ns11;

namespace ns13
{
	public sealed class CssBlock
	{
		private readonly string string_0;

		private readonly Dictionary<string, string> dictionary_0;

		private readonly List<CssBlockSelectorItem> list_0;

		private readonly bool bool_0;

		public string Class => this.string_0;

		public List<CssBlockSelectorItem> Selectors => this.list_0;

		public IDictionary<string, string> Properties => this.dictionary_0;

		public bool Hover => this.bool_0;

		public CssBlock(string @class, Dictionary<string, string> properties, List<CssBlockSelectorItem> selectors = null, bool hover = false)
		{
			ArgChecker.AssertArgNotNullOrEmpty(@class, "@class");
			ArgChecker.AssertArgNotNull(properties, "properties");
			this.string_0 = @class;
			this.list_0 = selectors;
			this.dictionary_0 = properties;
			this.bool_0 = hover;
		}

		public void Merge(CssBlock other)
		{
			ArgChecker.AssertArgNotNull(other, "other");
			foreach (string key in other.dictionary_0.Keys)
			{
				this.dictionary_0[key] = other.dictionary_0[key];
			}
		}

		public CssBlock Clone()
		{
			return new CssBlock(this.string_0, new Dictionary<string, string>(this.dictionary_0), (this.list_0 != null) ? new List<CssBlockSelectorItem>(this.list_0) : null);
		}

		public bool Equals(CssBlock other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (!object.Equals(other.string_0, this.string_0))
			{
				return false;
			}
			if (!object.Equals(other.dictionary_0.Count, this.dictionary_0.Count))
			{
				return false;
			}
			foreach (KeyValuePair<string, string> item in this.dictionary_0)
			{
				if (other.dictionary_0.ContainsKey(item.Key))
				{
					if (!object.Equals(other.dictionary_0[item.Key], item.Value))
					{
						return false;
					}
					continue;
				}
				return false;
			}
			if (!this.EqualsSelector(other))
			{
				return false;
			}
			return true;
		}

		public bool EqualsSelector(CssBlock other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (other.Hover != this.Hover)
			{
				return false;
			}
			if (other.list_0 == null && this.list_0 != null)
			{
				return false;
			}
			if (other.list_0 != null && this.list_0 == null)
			{
				return false;
			}
			if (other.list_0 != null && this.list_0 != null)
			{
				if (!object.Equals(other.list_0.Count, this.list_0.Count))
				{
					return false;
				}
				for (int i = 0; i < this.list_0.Count; i++)
				{
					if (object.Equals(other.list_0[i].Class, this.list_0[i].Class))
					{
						if (!object.Equals(other.list_0[i].DirectParent, this.list_0[i].DirectParent))
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

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != typeof(CssBlock))
			{
				return false;
			}
			return this.Equals((CssBlock)obj);
		}

		public override int GetHashCode()
		{
			return (((this.string_0 != null) ? this.string_0.GetHashCode() : 0) * 397) ^ ((this.dictionary_0 != null) ? this.dictionary_0.GetHashCode() : 0);
		}

		public override string ToString()
		{
			string text = this.string_0 + " { ";
			foreach (KeyValuePair<string, string> item in this.dictionary_0)
			{
				text += $"{item.Key}={item.Value}; ";
			}
			return text + " }";
		}
	}
}

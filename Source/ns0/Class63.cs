using System.Collections.Generic;
using ns11;

namespace ns0
{
	internal sealed class Class63
	{
		private readonly string string_0;

		private readonly bool bool_0;

		private readonly Dictionary<string, string> dictionary_0;

		public string String_0 => this.string_0;

		public Dictionary<string, string> Dictionary_0 => this.dictionary_0;

		public bool Boolean_0 => this.bool_0;

		public Class63(string string_1, bool bool_1, Dictionary<string, string> dictionary_1 = null)
		{
			ArgChecker.AssertArgNotNullOrEmpty(string_1, "name");
			this.string_0 = string_1;
			this.bool_0 = bool_1;
			this.dictionary_0 = dictionary_1;
		}

		public bool method_0()
		{
			return this.dictionary_0 != null && this.dictionary_0.Count > 0;
		}

		public bool method_1(string string_1)
		{
			return this.dictionary_0 != null && this.dictionary_0.ContainsKey(string_1);
		}

		public string method_2(string string_1, string string_2 = null)
		{
			return (this.dictionary_0 == null || !this.dictionary_0.ContainsKey(string_1)) ? string_2 : this.dictionary_0[string_1];
		}

		public override string ToString()
		{
			return $"<{this.string_0}>";
		}
	}
}

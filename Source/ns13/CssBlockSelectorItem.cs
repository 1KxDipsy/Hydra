using ns11;

namespace ns13
{
	public struct CssBlockSelectorItem
	{
		private readonly string string_0;

		private readonly bool bool_0;

		public string Class => this.string_0;

		public bool DirectParent => this.bool_0;

		public CssBlockSelectorItem(string @class, bool directParent)
		{
			ArgChecker.AssertArgNotNullOrEmpty(@class, "@class");
			this.string_0 = @class;
			this.bool_0 = directParent;
		}

		public override string ToString()
		{
			return this.string_0 + (this.bool_0 ? " > " : string.Empty);
		}
	}
}

namespace ns13
{
	public sealed class LinkElementData<T>
	{
		private readonly string string_0;

		private readonly string string_1;

		private readonly T gparam_0;

		public string Id => this.string_0;

		public string Href => this.string_1;

		public T Rectangle => this.gparam_0;

		public bool IsAnchor => this.string_1.Length > 0 && this.string_1[0] == '#';

		public string AnchorId => (!this.IsAnchor || this.string_1.Length <= 1) ? string.Empty : this.string_1.Substring(1);

		public LinkElementData(string id, string href, T rectangle)
		{
			this.string_0 = id;
			this.string_1 = href;
			this.gparam_0 = rectangle;
		}

		public override string ToString()
		{
			return $"Id: {this.string_0}, Href: {this.string_1}, Rectangle: {this.gparam_0}";
		}
	}
}

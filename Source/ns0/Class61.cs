namespace ns0
{
	internal sealed class Class61 : Class59
	{
		private readonly string string_0;

		private readonly bool bool_0;

		private readonly bool bool_1;

		public override bool Boolean_1 => this.bool_0;

		public override bool Boolean_2 => this.bool_1;

		public override bool Boolean_4
		{
			get
			{
				string text = this.String_0;
				int num = 0;
				while (true)
				{
					if (num < text.Length)
					{
						if (!char.IsWhiteSpace(text[num]))
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
		}

		public override bool Boolean_5 => this.String_0 == "\n";

		public override string String_0 => this.string_0;

		public Class61(Class50 class50_1, string string_1, bool bool_2, bool bool_3)
			: base(class50_1)
		{
			this.string_0 = string_1;
			this.bool_0 = bool_2;
			this.bool_1 = bool_3;
		}

		public override string ToString()
		{
			return string.Format("{0} ({1} char{2})", this.String_0.Replace(' ', '-').Replace("\n", "\\n"), this.String_0.Length, (this.String_0.Length != 1) ? "s" : string.Empty);
		}
	}
}

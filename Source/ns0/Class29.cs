using System;
using ns11;

namespace ns0
{
	internal sealed class Class29
	{
		private readonly string string_0;

		private readonly int int_0;

		private readonly int int_1;

		public string String_0 => this.string_0;

		public int Int32_0 => this.int_0;

		public int Int32_1 => this.int_1;

		public char this[int int_2]
		{
			get
			{
				if (int_2 < 0 || int_2 > this.int_1)
				{
					throw new ArgumentOutOfRangeException("idx", "must be within the string range");
				}
				return this.string_0[this.int_0 + int_2];
			}
		}

		public Class29(string string_1)
		{
			ArgChecker.AssertArgNotNull(string_1, "fullString");
			this.string_0 = string_1;
			this.int_0 = 0;
			this.int_1 = string_1.Length;
		}

		public Class29(string string_1, int int_2, int int_3)
		{
			ArgChecker.AssertArgNotNull(string_1, "fullString");
			if (int_2 >= 0 && int_2 < string_1.Length)
			{
				if (int_3 < 0 || int_2 + int_3 > string_1.Length)
				{
					throw new ArgumentOutOfRangeException("length", "Must within fullString boundries");
				}
				this.string_0 = string_1;
				this.int_0 = int_2;
				this.int_1 = int_3;
				return;
			}
			throw new ArgumentOutOfRangeException("startIdx", "Must within fullString boundries");
		}

		public bool method_0()
		{
			return this.int_1 < 1;
		}

		public bool method_1()
		{
			int num = 0;
			while (true)
			{
				if (num < this.int_1)
				{
					if (!char.IsWhiteSpace(this.string_0, this.int_0 + num))
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

		public bool method_2()
		{
			if (this.int_1 < 1)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < this.int_1)
				{
					if (!char.IsWhiteSpace(this.string_0, this.int_0 + num))
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

		public string method_3()
		{
			return (this.int_1 > 0) ? this.string_0.Substring(this.int_0, this.int_1) : string.Empty;
		}

		public string method_4(int int_2, int int_3)
		{
			if (int_2 >= 0 && int_2 <= this.int_1)
			{
				if (int_3 > this.int_1)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				if (int_2 + int_3 > this.int_1)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				return this.string_0.Substring(this.int_0 + int_2, int_3);
			}
			throw new ArgumentOutOfRangeException("startIdx");
		}

		public override string ToString()
		{
			return $"Sub-string: {((this.int_1 > 0) ? this.string_0.Substring(this.int_0, this.int_1) : string.Empty)}";
		}
	}
}

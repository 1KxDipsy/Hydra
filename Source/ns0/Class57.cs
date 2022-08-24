using System;
using System.Globalization;

namespace ns0
{
	internal sealed class Class57
	{
		private readonly double double_0;

		private readonly bool bool_0;

		private readonly Enum3 enum3_0;

		private readonly string string_0;

		private readonly bool bool_1;

		private readonly bool bool_2;

		public double Double_0 => this.double_0;

		public bool Boolean_0 => this.bool_2;

		public bool Boolean_1 => this.bool_1;

		public bool Boolean_2 => this.bool_0;

		public Enum3 Enum3_0 => this.enum3_0;

		public string String_0 => this.string_0;

		public Class57(string string_1)
		{
			this.string_0 = string_1;
			this.double_0 = 0.0;
			this.enum3_0 = Enum3.const_0;
			this.bool_1 = false;
			if (string.IsNullOrEmpty(string_1) || string_1 == "0")
			{
				return;
			}
			if (string_1.EndsWith("%"))
			{
				this.double_0 = Class31.smethod_3(string_1, 1.0);
				this.bool_1 = true;
				return;
			}
			if (string_1.Length < 3)
			{
				double.TryParse(string_1, out this.double_0);
				this.bool_2 = true;
				return;
			}
			string text = string_1.Substring(string_1.Length - 2, 2);
			string s = string_1.Substring(0, string_1.Length - 2);
			string text2 = text;
			uint num = Class75.smethod_0(text2);
			if (num <= 1313756516)
			{
				if (num <= 1094220446)
				{
					if (num != 1075471351)
					{
						if (num != 1094220446 || !(text2 == "in"))
						{
							goto IL_01fd;
						}
						this.enum3_0 = Enum3.const_4;
					}
					else
					{
						if (!(text2 == "em"))
						{
							goto IL_01fd;
						}
						this.enum3_0 = Enum3.const_1;
						this.bool_0 = true;
					}
				}
				else if (num != 1260025160)
				{
					if (num != 1313756516 || !(text2 == "pc"))
					{
						goto IL_01fd;
					}
					this.enum3_0 = Enum3.const_8;
				}
				else
				{
					if (!(text2 == "ex"))
					{
						goto IL_01fd;
					}
					this.enum3_0 = Enum3.const_3;
					this.bool_0 = true;
				}
			}
			else if (num <= 1565420801)
			{
				if (num != 1498310325)
				{
					if (num != 1565420801 || !(text2 == "pt"))
					{
						goto IL_01fd;
					}
					this.enum3_0 = Enum3.const_7;
				}
				else
				{
					if (!(text2 == "px"))
					{
						goto IL_01fd;
					}
					this.enum3_0 = Enum3.const_2;
					this.bool_0 = true;
				}
			}
			else if (num != 1613635087)
			{
				if (num != 1680451373 || !(text2 == "cm"))
				{
					goto IL_01fd;
				}
				this.enum3_0 = Enum3.const_5;
			}
			else
			{
				if (!(text2 == "mm"))
				{
					goto IL_01fd;
				}
				this.enum3_0 = Enum3.const_6;
			}
			if (!double.TryParse(s, NumberStyles.Number, NumberFormatInfo.InvariantInfo, out this.double_0))
			{
				this.bool_2 = true;
			}
			return;
			IL_01fd:
			this.bool_2 = true;
		}

		public Class57 method_0(double double_1)
		{
			if (this.Boolean_0)
			{
				throw new InvalidOperationException("Invalid length");
			}
			if (this.Enum3_0 != Enum3.const_1)
			{
				throw new InvalidOperationException("Length is not in ems");
			}
			return new Class57(string.Format("{0}pt", Convert.ToSingle(this.Double_0 * double_1).ToString("0.0", NumberFormatInfo.InvariantInfo)));
		}

		public Class57 method_1(double double_1)
		{
			if (this.Boolean_0)
			{
				throw new InvalidOperationException("Invalid length");
			}
			if (this.Enum3_0 != Enum3.const_1)
			{
				throw new InvalidOperationException("Length is not in ems");
			}
			return new Class57(string.Format("{0}px", Convert.ToSingle(this.Double_0 * double_1).ToString("0.0", NumberFormatInfo.InvariantInfo)));
		}

		public override string ToString()
		{
			if (this.Boolean_0)
			{
				return string.Empty;
			}
			if (this.Boolean_1)
			{
				return string.Format(NumberFormatInfo.InvariantInfo, "{0}%", new object[1] { this.Double_0 });
			}
			string text = string.Empty;
			switch (this.Enum3_0)
			{
			case Enum3.const_1:
				text = "em";
				break;
			case Enum3.const_2:
				text = "px";
				break;
			case Enum3.const_3:
				text = "ex";
				break;
			case Enum3.const_4:
				text = "in";
				break;
			case Enum3.const_5:
				text = "cm";
				break;
			case Enum3.const_6:
				text = "mm";
				break;
			case Enum3.const_7:
				text = "pt";
				break;
			case Enum3.const_8:
				text = "pc";
				break;
			}
			return string.Format(NumberFormatInfo.InvariantInfo, "{0}{1}", new object[2] { this.Double_0, text });
		}
	}
}

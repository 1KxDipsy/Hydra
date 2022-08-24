using System;
using System.Collections.Generic;
using ns11;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class40
	{
		private readonly RAdapter radapter_0;

		private readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

		private readonly Dictionary<string, RFontFamily> dictionary_1 = new Dictionary<string, RFontFamily>(StringComparer.InvariantCultureIgnoreCase);

		private readonly Dictionary<string, Dictionary<double, Dictionary<RFontStyle, RFont>>> dictionary_2 = new Dictionary<string, Dictionary<double, Dictionary<RFontStyle, RFont>>>(StringComparer.InvariantCultureIgnoreCase);

		public Class40(RAdapter radapter_1)
		{
			ArgChecker.AssertArgNotNull(radapter_1, "global");
			this.radapter_0 = radapter_1;
		}

		public bool method_0(string string_0)
		{
			bool result;
			if (!(result = this.dictionary_1.ContainsKey(string_0)) && this.dictionary_0.TryGetValue(string_0, out var value))
			{
				result = this.dictionary_1.ContainsKey(value);
			}
			return result;
		}

		public void method_1(RFontFamily rfontFamily_0)
		{
			ArgChecker.AssertArgNotNull(rfontFamily_0, "family");
			this.dictionary_1[rfontFamily_0.Name] = rfontFamily_0;
		}

		public void method_2(string string_0, string string_1)
		{
			ArgChecker.AssertArgNotNullOrEmpty(string_0, "fromFamily");
			ArgChecker.AssertArgNotNullOrEmpty(string_1, "toFamily");
			this.dictionary_0[string_0] = string_1;
		}

		public RFont method_3(string string_0, double double_0, RFontStyle rfontStyle_0)
		{
			RFont rFont = this.method_4(string_0, double_0, rfontStyle_0);
			if (rFont == null)
			{
				if (!this.dictionary_1.ContainsKey(string_0) && this.dictionary_0.TryGetValue(string_0, out var value))
				{
					rFont = this.method_4(value, double_0, rfontStyle_0);
					if (rFont == null)
					{
						rFont = this.method_5(value, double_0, rfontStyle_0);
						this.dictionary_2[value][double_0][rfontStyle_0] = rFont;
					}
				}
				if (rFont == null)
				{
					rFont = this.method_5(string_0, double_0, rfontStyle_0);
				}
				this.dictionary_2[string_0][double_0][rfontStyle_0] = rFont;
			}
			return rFont;
		}

		private RFont method_4(string string_0, double double_0, RFontStyle rfontStyle_0)
		{
			RFont result = null;
			if (this.dictionary_2.ContainsKey(string_0))
			{
				Dictionary<double, Dictionary<RFontStyle, RFont>> dictionary = this.dictionary_2[string_0];
				if (dictionary.ContainsKey(double_0))
				{
					Dictionary<RFontStyle, RFont> dictionary2 = dictionary[double_0];
					if (dictionary2.ContainsKey(rfontStyle_0))
					{
						result = dictionary2[rfontStyle_0];
					}
				}
				else
				{
					this.dictionary_2[string_0][double_0] = new Dictionary<RFontStyle, RFont>();
				}
			}
			else
			{
				this.dictionary_2[string_0] = new Dictionary<double, Dictionary<RFontStyle, RFont>>();
				this.dictionary_2[string_0][double_0] = new Dictionary<RFontStyle, RFont>();
			}
			return result;
		}

		private RFont method_5(string string_0, double double_0, RFontStyle rfontStyle_0)
		{
			RFontFamily value;
			try
			{
				return this.dictionary_1.TryGetValue(string_0, out value) ? this.radapter_0.method_1(value, double_0, rfontStyle_0) : this.radapter_0.method_0(string_0, double_0, rfontStyle_0);
			}
			catch
			{
				return this.dictionary_1.TryGetValue(string_0, out value) ? this.radapter_0.method_1(value, double_0, RFontStyle.Regular) : this.radapter_0.method_0(string_0, double_0, RFontStyle.Regular);
			}
		}
	}
}

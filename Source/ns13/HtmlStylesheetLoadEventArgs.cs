using System;
using System.Collections.Generic;
using ns10;

namespace ns13
{
	public sealed class HtmlStylesheetLoadEventArgs : EventArgs
	{
		private readonly string string_0;

		private readonly Dictionary<string, string> dictionary_0;

		private string string_1;

		private string string_2;

		private CssData cssData_0;

		public string Src => this.string_0;

		public Dictionary<string, string> Attributes => this.dictionary_0;

		public string SetSrc
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		public string SetStyleSheet
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		public CssData SetStyleSheetData
		{
			get
			{
				return this.cssData_0;
			}
			set
			{
				this.cssData_0 = value;
			}
		}

		internal HtmlStylesheetLoadEventArgs(string string_3, Dictionary<string, string> dictionary_1)
		{
			this.string_0 = string_3;
			this.dictionary_0 = dictionary_1;
		}
	}
}

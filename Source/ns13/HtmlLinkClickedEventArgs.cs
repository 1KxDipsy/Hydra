using System;
using System.Collections.Generic;

namespace ns13
{
	public sealed class HtmlLinkClickedEventArgs : EventArgs
	{
		private readonly string string_0;

		private readonly Dictionary<string, string> dictionary_0;

		private bool bool_0;

		public string Link => this.string_0;

		public Dictionary<string, string> Attributes => this.dictionary_0;

		public bool Handled
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public HtmlLinkClickedEventArgs(string link, Dictionary<string, string> attributes)
		{
			this.string_0 = link;
			this.dictionary_0 = attributes;
		}

		public override string ToString()
		{
			return $"Link: {this.string_0}, Handled: {this.bool_0}";
		}
	}
}

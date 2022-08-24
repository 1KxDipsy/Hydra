using System;
using System.Collections.Generic;
using ns11;
using ns16;

namespace ns13
{
	public sealed class HtmlImageLoadEventArgs : EventArgs
	{
		private bool bool_0;

		private readonly string string_0;

		private readonly Dictionary<string, string> dictionary_0;

		private readonly HtmlImageLoadCallback htmlImageLoadCallback_0;

		public string Src => this.string_0;

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

		internal HtmlImageLoadEventArgs(string string_1, Dictionary<string, string> dictionary_1, HtmlImageLoadCallback htmlImageLoadCallback_1)
		{
			this.string_0 = string_1;
			this.dictionary_0 = dictionary_1;
			this.htmlImageLoadCallback_0 = htmlImageLoadCallback_1;
		}

		public void Callback()
		{
			this.bool_0 = true;
			this.htmlImageLoadCallback_0(null, null, default(RRect));
		}

		public void Callback(string path)
		{
			ArgChecker.AssertArgNotNullOrEmpty(path, "path");
			this.bool_0 = true;
			this.htmlImageLoadCallback_0(path, null, RRect.Empty);
		}

		public void Callback(string path, double x, double y, double width, double height)
		{
			ArgChecker.AssertArgNotNullOrEmpty(path, "path");
			this.bool_0 = true;
			this.htmlImageLoadCallback_0(path, null, new RRect(x, y, width, height));
		}

		public void Callback(object image)
		{
			ArgChecker.AssertArgNotNull(image, "image");
			this.bool_0 = true;
			this.htmlImageLoadCallback_0(null, image, RRect.Empty);
		}

		public void Callback(object image, double x, double y, double width, double height)
		{
			ArgChecker.AssertArgNotNull(image, "image");
			this.bool_0 = true;
			this.htmlImageLoadCallback_0(null, image, new RRect(x, y, width, height));
		}
	}
}

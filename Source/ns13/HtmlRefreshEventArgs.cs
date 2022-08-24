using System;

namespace ns13
{
	public sealed class HtmlRefreshEventArgs : EventArgs
	{
		private readonly bool bool_0;

		public bool Layout => this.bool_0;

		public HtmlRefreshEventArgs(bool layout)
		{
			this.bool_0 = layout;
		}

		public override string ToString()
		{
			return $"Layout: {this.bool_0}";
		}
	}
}

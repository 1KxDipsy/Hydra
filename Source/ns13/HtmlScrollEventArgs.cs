using System;
using ns16;

namespace ns13
{
	public sealed class HtmlScrollEventArgs : EventArgs
	{
		private readonly RPoint rpoint_0;

		public double Double_0 => this.rpoint_0.Double_0;

		public double Double_1 => this.rpoint_0.Double_1;

		public HtmlScrollEventArgs(RPoint location)
		{
			this.rpoint_0 = location;
		}

		public override string ToString()
		{
			return $"Location: {this.rpoint_0}";
		}
	}
}

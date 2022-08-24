using System;

namespace ns13
{
	public sealed class HtmlRenderErrorEventArgs : EventArgs
	{
		private readonly HtmlRenderErrorType htmlRenderErrorType_0;

		private readonly string string_0;

		private readonly Exception exception_0;

		public HtmlRenderErrorType Type => this.htmlRenderErrorType_0;

		public string Message => this.string_0;

		public Exception Exception => this.exception_0;

		public HtmlRenderErrorEventArgs(HtmlRenderErrorType type, string message, Exception exception = null)
		{
			this.htmlRenderErrorType_0 = type;
			this.string_0 = message;
			this.exception_0 = exception;
		}

		public override string ToString()
		{
			return $"Type: {this.htmlRenderErrorType_0}";
		}
	}
}

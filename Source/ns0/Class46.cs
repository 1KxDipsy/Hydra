using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using ns10;
using ns11;
using ns13;

namespace ns0
{
	internal static class Class46
	{
		public static void smethod_0(HtmlContainerInt htmlContainerInt_0, string string_0, Dictionary<string, string> dictionary_0, out string string_1, out CssData cssData_0)
		{
			ArgChecker.AssertArgNotNull(htmlContainerInt_0, "htmlContainer");
			string_1 = null;
			cssData_0 = null;
			try
			{
				HtmlStylesheetLoadEventArgs htmlStylesheetLoadEventArgs = new HtmlStylesheetLoadEventArgs(string_0, dictionary_0);
				htmlContainerInt_0.method_0(htmlStylesheetLoadEventArgs);
				if (!string.IsNullOrEmpty(htmlStylesheetLoadEventArgs.SetStyleSheet))
				{
					string_1 = htmlStylesheetLoadEventArgs.SetStyleSheet;
				}
				else if (htmlStylesheetLoadEventArgs.SetStyleSheetData != null)
				{
					cssData_0 = htmlStylesheetLoadEventArgs.SetStyleSheetData;
				}
				else if (htmlStylesheetLoadEventArgs.SetSrc != null)
				{
					string_1 = Class46.smethod_1(htmlContainerInt_0, htmlStylesheetLoadEventArgs.SetSrc);
				}
				else
				{
					string_1 = Class46.smethod_1(htmlContainerInt_0, string_0);
				}
			}
			catch (Exception exception_)
			{
				htmlContainerInt_0.method_2(HtmlRenderErrorType.CssParsing, "Exception in handling stylesheet source", exception_);
			}
		}

		private static string smethod_1(HtmlContainerInt htmlContainerInt_0, string string_0)
		{
			Uri uri = Class22.smethod_4(string_0);
			if (!(uri == null) && !(uri.Scheme == "file"))
			{
				return Class46.smethod_3(htmlContainerInt_0, uri);
			}
			return Class46.smethod_2(htmlContainerInt_0, (uri != null) ? uri.AbsolutePath : string_0);
		}

		private static string smethod_2(HtmlContainerInt htmlContainerInt_0, string string_0)
		{
			FileInfo fileInfo = Class22.smethod_6(string_0);
			if (fileInfo != null)
			{
				if (fileInfo.Exists)
				{
					using StreamReader streamReader = new StreamReader(fileInfo.FullName);
					return streamReader.ReadToEnd();
				}
				htmlContainerInt_0.method_2(HtmlRenderErrorType.CssParsing, "No stylesheet found by path: " + string_0);
			}
			else
			{
				htmlContainerInt_0.method_2(HtmlRenderErrorType.CssParsing, "Failed load image, invalid source: " + string_0);
			}
			return string.Empty;
		}

		private static string smethod_3(HtmlContainerInt htmlContainerInt_0, Uri uri_0)
		{
			using WebClient webClient = new WebClient();
			string text = webClient.DownloadString(uri_0);
			try
			{
				text = Class46.smethod_4(text, uri_0);
			}
			catch (Exception exception_)
			{
				htmlContainerInt_0.method_2(HtmlRenderErrorType.CssParsing, "Error in correcting relative URL in loaded stylesheet", exception_);
			}
			return text;
		}

		private static string smethod_4(string string_0, Uri uri_0)
		{
			int num = 0;
			while (num >= 0 && num < string_0.Length)
			{
				num = string_0.IndexOf("url(", num, StringComparison.OrdinalIgnoreCase);
				if (num < 0)
				{
					continue;
				}
				int num2 = string_0.IndexOf(')', num);
				if (num2 > num + 4)
				{
					int num3 = 4 + ((string_0[num + 4] == '\'') ? 1 : 0);
					if (Uri.TryCreate(string_0.Substring(num + num3, num2 - num - num3 - ((string_0[num2 - 1] == '\'') ? 1 : 0)), UriKind.Relative, out var result))
					{
						result = new Uri(uri_0, result);
						string_0 = string_0.Remove(num + 4, num2 - num - 4);
						string_0 = string_0.Insert(num + 4, result.AbsoluteUri);
						num += result.AbsoluteUri.Length + 4;
					}
					else
					{
						num = num2 + 1;
					}
				}
				else
				{
					num += 4;
				}
			}
			return string_0;
		}
	}
}

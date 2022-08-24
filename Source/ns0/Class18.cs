using System;
using System.Text;
using System.Windows.Forms;

namespace ns0
{
	internal static class Class18
	{
		private const string string_0 = "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4";

		public const string string_1 = "<!--StartFragment-->";

		public const string string_2 = "<!--EndFragment-->";

		private static readonly char[] char_0 = new char[1];

		public static DataObject smethod_0(string string_3, string string_4)
		{
			string_3 = string_3 ?? string.Empty;
			string text = Class18.smethod_3(string_3);
			if (Environment.Version.Major < 4 && string_3.Length != Encoding.UTF8.GetByteCount(string_3))
			{
				text = Encoding.Default.GetString(Encoding.UTF8.GetBytes(text));
			}
			DataObject dataObject = new DataObject();
			dataObject.SetData(DataFormats.Html, text);
			dataObject.SetData(DataFormats.Text, string_4);
			dataObject.SetData(DataFormats.UnicodeText, string_4);
			return dataObject;
		}

		public static void smethod_1(string string_3, string string_4)
		{
			Clipboard.SetDataObject(Class18.smethod_0(string_3, string_4), copy: true);
		}

		public static void smethod_2(string string_3)
		{
			DataObject dataObject = new DataObject();
			dataObject.SetData(DataFormats.Text, string_3);
			dataObject.SetData(DataFormats.UnicodeText, string_3);
			Clipboard.SetDataObject(dataObject, copy: true);
		}

		private static string smethod_3(string string_3)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4");
			stringBuilder.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
			int num = string_3.IndexOf("<!--StartFragment-->", StringComparison.OrdinalIgnoreCase);
			int num2 = string_3.LastIndexOf("<!--EndFragment-->", StringComparison.OrdinalIgnoreCase);
			int num3 = string_3.IndexOf("<html", StringComparison.OrdinalIgnoreCase);
			int num4 = ((num3 > -1) ? (string_3.IndexOf('>', num3) + 1) : (-1));
			int num5 = string_3.LastIndexOf("</html", StringComparison.OrdinalIgnoreCase);
			int num8;
			int num9;
			if (num < 0 && num2 < 0)
			{
				int num6 = string_3.IndexOf("<body", StringComparison.OrdinalIgnoreCase);
				int num7 = ((num6 > -1) ? (string_3.IndexOf('>', num6) + 1) : (-1));
				if (num4 < 0 && num7 < 0)
				{
					stringBuilder.Append("<html><body>");
					stringBuilder.Append("<!--StartFragment-->");
					num8 = Class18.smethod_4(stringBuilder);
					stringBuilder.Append(string_3);
					num9 = Class18.smethod_4(stringBuilder);
					stringBuilder.Append("<!--EndFragment-->");
					stringBuilder.Append("</body></html>");
				}
				else
				{
					int num10 = string_3.LastIndexOf("</body", StringComparison.OrdinalIgnoreCase);
					if (num4 < 0)
					{
						stringBuilder.Append("<html>");
					}
					else
					{
						stringBuilder.Append(string_3, 0, num4);
					}
					if (num7 > -1)
					{
						stringBuilder.Append(string_3, (num4 > -1) ? num4 : 0, num7 - ((num4 > -1) ? num4 : 0));
					}
					stringBuilder.Append("<!--StartFragment-->");
					num8 = Class18.smethod_4(stringBuilder);
					int num11 = ((num7 > -1) ? num7 : ((num4 > -1) ? num4 : 0));
					int num12 = ((num10 > -1) ? num10 : ((num5 > -1) ? num5 : string_3.Length));
					stringBuilder.Append(string_3, num11, num12 - num11);
					num9 = Class18.smethod_4(stringBuilder);
					stringBuilder.Append("<!--EndFragment-->");
					if (num12 < string_3.Length)
					{
						stringBuilder.Append(string_3, num12, string_3.Length - num12);
					}
					if (num5 < 0)
					{
						stringBuilder.Append("</html>");
					}
				}
			}
			else
			{
				if (num4 < 0)
				{
					stringBuilder.Append("<html>");
				}
				int num13 = Class18.smethod_4(stringBuilder);
				stringBuilder.Append(string_3);
				num8 = num13 + Class18.smethod_4(stringBuilder, num13, num13 + num) + "<!--StartFragment-->".Length;
				num9 = num13 + Class18.smethod_4(stringBuilder, num13, num13 + num2);
				if (num5 < 0)
				{
					stringBuilder.Append("</html>");
				}
			}
			stringBuilder.Replace("<<<<<<<<1", "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length.ToString("D9"), 0, "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length);
			stringBuilder.Replace("<<<<<<<<2", Class18.smethod_4(stringBuilder).ToString("D9"), 0, "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length);
			stringBuilder.Replace("<<<<<<<<3", num8.ToString("D9"), 0, "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length);
			stringBuilder.Replace("<<<<<<<<4", num9.ToString("D9"), 0, "Version:0.9\nStartHTML:<<<<<<<<1\nEndHTML:<<<<<<<<2\nStartFragment:<<<<<<<<3\nEndFragment:<<<<<<<<4\nStartSelection:<<<<<<<<3\nEndSelection:<<<<<<<<4".Length);
			return stringBuilder.ToString();
		}

		private static int smethod_4(StringBuilder stringBuilder_0, int int_0 = 0, int int_1 = -1)
		{
			int num = 0;
			int_1 = ((int_1 > -1) ? int_1 : stringBuilder_0.Length);
			for (int i = int_0; i < int_1; i++)
			{
				Class18.char_0[0] = stringBuilder_0[i];
				num += Encoding.UTF8.GetByteCount(Class18.char_0);
			}
			return num;
		}
	}
}

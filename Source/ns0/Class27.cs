using System;
using System.Collections.Generic;

namespace ns0
{
	internal static class Class27
	{
		private static readonly List<string> list_0;

		private static readonly KeyValuePair<string, string>[] keyValuePair_0;

		private static readonly Dictionary<string, char> dictionary_0;

		static Class27()
		{
			Class27.list_0 = new List<string>(new string[13]
			{
				"area", "base", "basefont", "br", "col", "frame", "hr", "img", "input", "isindex",
				"link", "meta", "param"
			});
			Class27.keyValuePair_0 = new KeyValuePair<string, string>[4]
			{
				new KeyValuePair<string, string>("&lt;", "<"),
				new KeyValuePair<string, string>("&gt;", ">"),
				new KeyValuePair<string, string>("&quot;", "\""),
				new KeyValuePair<string, string>("&amp;", "&")
			};
			Class27.dictionary_0 = new Dictionary<string, char>(StringComparer.InvariantCultureIgnoreCase);
			Class27.dictionary_0["nbsp"] = ' ';
			Class27.dictionary_0["rdquo"] = '"';
			Class27.dictionary_0["lsquo"] = '\'';
			Class27.dictionary_0["apos"] = '\'';
			Class27.dictionary_0["iexcl"] = Convert.ToChar(161);
			Class27.dictionary_0["cent"] = Convert.ToChar(162);
			Class27.dictionary_0["pound"] = Convert.ToChar(163);
			Class27.dictionary_0["curren"] = Convert.ToChar(164);
			Class27.dictionary_0["yen"] = Convert.ToChar(165);
			Class27.dictionary_0["brvbar"] = Convert.ToChar(166);
			Class27.dictionary_0["sect"] = Convert.ToChar(167);
			Class27.dictionary_0["uml"] = Convert.ToChar(168);
			Class27.dictionary_0["copy"] = Convert.ToChar(169);
			Class27.dictionary_0["ordf"] = Convert.ToChar(170);
			Class27.dictionary_0["laquo"] = Convert.ToChar(171);
			Class27.dictionary_0["not"] = Convert.ToChar(172);
			Class27.dictionary_0["shy"] = Convert.ToChar(173);
			Class27.dictionary_0["reg"] = Convert.ToChar(174);
			Class27.dictionary_0["macr"] = Convert.ToChar(175);
			Class27.dictionary_0["deg"] = Convert.ToChar(176);
			Class27.dictionary_0["plusmn"] = Convert.ToChar(177);
			Class27.dictionary_0["sup2"] = Convert.ToChar(178);
			Class27.dictionary_0["sup3"] = Convert.ToChar(179);
			Class27.dictionary_0["acute"] = Convert.ToChar(180);
			Class27.dictionary_0["micro"] = Convert.ToChar(181);
			Class27.dictionary_0["para"] = Convert.ToChar(182);
			Class27.dictionary_0["middot"] = Convert.ToChar(183);
			Class27.dictionary_0["cedil"] = Convert.ToChar(184);
			Class27.dictionary_0["sup1"] = Convert.ToChar(185);
			Class27.dictionary_0["ordm"] = Convert.ToChar(186);
			Class27.dictionary_0["raquo"] = Convert.ToChar(187);
			Class27.dictionary_0["frac14"] = Convert.ToChar(188);
			Class27.dictionary_0["frac12"] = Convert.ToChar(189);
			Class27.dictionary_0["frac34"] = Convert.ToChar(190);
			Class27.dictionary_0["iquest"] = Convert.ToChar(191);
			Class27.dictionary_0["times"] = Convert.ToChar(215);
			Class27.dictionary_0["divide"] = Convert.ToChar(247);
			Class27.dictionary_0["Agrave"] = Convert.ToChar(192);
			Class27.dictionary_0["Aacute"] = Convert.ToChar(193);
			Class27.dictionary_0["Acirc"] = Convert.ToChar(194);
			Class27.dictionary_0["Atilde"] = Convert.ToChar(195);
			Class27.dictionary_0["Auml"] = Convert.ToChar(196);
			Class27.dictionary_0["Aring"] = Convert.ToChar(197);
			Class27.dictionary_0["AElig"] = Convert.ToChar(198);
			Class27.dictionary_0["Ccedil"] = Convert.ToChar(199);
			Class27.dictionary_0["Egrave"] = Convert.ToChar(200);
			Class27.dictionary_0["Eacute"] = Convert.ToChar(201);
			Class27.dictionary_0["Ecirc"] = Convert.ToChar(202);
			Class27.dictionary_0["Euml"] = Convert.ToChar(203);
			Class27.dictionary_0["Igrave"] = Convert.ToChar(204);
			Class27.dictionary_0["Iacute"] = Convert.ToChar(205);
			Class27.dictionary_0["Icirc"] = Convert.ToChar(206);
			Class27.dictionary_0["Iuml"] = Convert.ToChar(207);
			Class27.dictionary_0["ETH"] = Convert.ToChar(208);
			Class27.dictionary_0["Ntilde"] = Convert.ToChar(209);
			Class27.dictionary_0["Ograve"] = Convert.ToChar(210);
			Class27.dictionary_0["Oacute"] = Convert.ToChar(211);
			Class27.dictionary_0["Ocirc"] = Convert.ToChar(212);
			Class27.dictionary_0["Otilde"] = Convert.ToChar(213);
			Class27.dictionary_0["Ouml"] = Convert.ToChar(214);
			Class27.dictionary_0["Oslash"] = Convert.ToChar(216);
			Class27.dictionary_0["Ugrave"] = Convert.ToChar(217);
			Class27.dictionary_0["Uacute"] = Convert.ToChar(218);
			Class27.dictionary_0["Ucirc"] = Convert.ToChar(219);
			Class27.dictionary_0["Uuml"] = Convert.ToChar(220);
			Class27.dictionary_0["Yacute"] = Convert.ToChar(221);
			Class27.dictionary_0["THORN"] = Convert.ToChar(222);
			Class27.dictionary_0["szlig"] = Convert.ToChar(223);
			Class27.dictionary_0["agrave"] = Convert.ToChar(224);
			Class27.dictionary_0["aacute"] = Convert.ToChar(225);
			Class27.dictionary_0["acirc"] = Convert.ToChar(226);
			Class27.dictionary_0["atilde"] = Convert.ToChar(227);
			Class27.dictionary_0["auml"] = Convert.ToChar(228);
			Class27.dictionary_0["aring"] = Convert.ToChar(229);
			Class27.dictionary_0["aelig"] = Convert.ToChar(230);
			Class27.dictionary_0["ccedil"] = Convert.ToChar(231);
			Class27.dictionary_0["egrave"] = Convert.ToChar(232);
			Class27.dictionary_0["eacute"] = Convert.ToChar(233);
			Class27.dictionary_0["ecirc"] = Convert.ToChar(234);
			Class27.dictionary_0["euml"] = Convert.ToChar(235);
			Class27.dictionary_0["igrave"] = Convert.ToChar(236);
			Class27.dictionary_0["iacute"] = Convert.ToChar(237);
			Class27.dictionary_0["icirc"] = Convert.ToChar(238);
			Class27.dictionary_0["iuml"] = Convert.ToChar(239);
			Class27.dictionary_0["eth"] = Convert.ToChar(240);
			Class27.dictionary_0["ntilde"] = Convert.ToChar(241);
			Class27.dictionary_0["ograve"] = Convert.ToChar(242);
			Class27.dictionary_0["oacute"] = Convert.ToChar(243);
			Class27.dictionary_0["ocirc"] = Convert.ToChar(244);
			Class27.dictionary_0["otilde"] = Convert.ToChar(245);
			Class27.dictionary_0["ouml"] = Convert.ToChar(246);
			Class27.dictionary_0["oslash"] = Convert.ToChar(248);
			Class27.dictionary_0["ugrave"] = Convert.ToChar(249);
			Class27.dictionary_0["uacute"] = Convert.ToChar(250);
			Class27.dictionary_0["ucirc"] = Convert.ToChar(251);
			Class27.dictionary_0["uuml"] = Convert.ToChar(252);
			Class27.dictionary_0["yacute"] = Convert.ToChar(253);
			Class27.dictionary_0["thorn"] = Convert.ToChar(254);
			Class27.dictionary_0["yuml"] = Convert.ToChar(255);
			Class27.dictionary_0["forall"] = Convert.ToChar(8704);
			Class27.dictionary_0["part"] = Convert.ToChar(8706);
			Class27.dictionary_0["exist"] = Convert.ToChar(8707);
			Class27.dictionary_0["empty"] = Convert.ToChar(8709);
			Class27.dictionary_0["nabla"] = Convert.ToChar(8711);
			Class27.dictionary_0["isin"] = Convert.ToChar(8712);
			Class27.dictionary_0["notin"] = Convert.ToChar(8713);
			Class27.dictionary_0["ni"] = Convert.ToChar(8715);
			Class27.dictionary_0["prod"] = Convert.ToChar(8719);
			Class27.dictionary_0["sum"] = Convert.ToChar(8721);
			Class27.dictionary_0["minus"] = Convert.ToChar(8722);
			Class27.dictionary_0["lowast"] = Convert.ToChar(8727);
			Class27.dictionary_0["radic"] = Convert.ToChar(8730);
			Class27.dictionary_0["prop"] = Convert.ToChar(8733);
			Class27.dictionary_0["infin"] = Convert.ToChar(8734);
			Class27.dictionary_0["ang"] = Convert.ToChar(8736);
			Class27.dictionary_0["and"] = Convert.ToChar(8743);
			Class27.dictionary_0["or"] = Convert.ToChar(8744);
			Class27.dictionary_0["cap"] = Convert.ToChar(8745);
			Class27.dictionary_0["cup"] = Convert.ToChar(8746);
			Class27.dictionary_0["int"] = Convert.ToChar(8747);
			Class27.dictionary_0["there4"] = Convert.ToChar(8756);
			Class27.dictionary_0["sim"] = Convert.ToChar(8764);
			Class27.dictionary_0["cong"] = Convert.ToChar(8773);
			Class27.dictionary_0["asymp"] = Convert.ToChar(8776);
			Class27.dictionary_0["ne"] = Convert.ToChar(8800);
			Class27.dictionary_0["equiv"] = Convert.ToChar(8801);
			Class27.dictionary_0["le"] = Convert.ToChar(8804);
			Class27.dictionary_0["ge"] = Convert.ToChar(8805);
			Class27.dictionary_0["sub"] = Convert.ToChar(8834);
			Class27.dictionary_0["sup"] = Convert.ToChar(8835);
			Class27.dictionary_0["nsub"] = Convert.ToChar(8836);
			Class27.dictionary_0["sube"] = Convert.ToChar(8838);
			Class27.dictionary_0["supe"] = Convert.ToChar(8839);
			Class27.dictionary_0["oplus"] = Convert.ToChar(8853);
			Class27.dictionary_0["otimes"] = Convert.ToChar(8855);
			Class27.dictionary_0["perp"] = Convert.ToChar(8869);
			Class27.dictionary_0["sdot"] = Convert.ToChar(8901);
			Class27.dictionary_0["Alpha"] = Convert.ToChar(913);
			Class27.dictionary_0["Beta"] = Convert.ToChar(914);
			Class27.dictionary_0["Gamma"] = Convert.ToChar(915);
			Class27.dictionary_0["Delta"] = Convert.ToChar(916);
			Class27.dictionary_0["Epsilon"] = Convert.ToChar(917);
			Class27.dictionary_0["Zeta"] = Convert.ToChar(918);
			Class27.dictionary_0["Eta"] = Convert.ToChar(919);
			Class27.dictionary_0["Theta"] = Convert.ToChar(920);
			Class27.dictionary_0["Iota"] = Convert.ToChar(921);
			Class27.dictionary_0["Kappa"] = Convert.ToChar(922);
			Class27.dictionary_0["Lambda"] = Convert.ToChar(923);
			Class27.dictionary_0["Mu"] = Convert.ToChar(924);
			Class27.dictionary_0["Nu"] = Convert.ToChar(925);
			Class27.dictionary_0["Xi"] = Convert.ToChar(926);
			Class27.dictionary_0["Omicron"] = Convert.ToChar(927);
			Class27.dictionary_0["Pi"] = Convert.ToChar(928);
			Class27.dictionary_0["Rho"] = Convert.ToChar(929);
			Class27.dictionary_0["Sigma"] = Convert.ToChar(931);
			Class27.dictionary_0["Tau"] = Convert.ToChar(932);
			Class27.dictionary_0["Upsilon"] = Convert.ToChar(933);
			Class27.dictionary_0["Phi"] = Convert.ToChar(934);
			Class27.dictionary_0["Chi"] = Convert.ToChar(935);
			Class27.dictionary_0["Psi"] = Convert.ToChar(936);
			Class27.dictionary_0["Omega"] = Convert.ToChar(937);
			Class27.dictionary_0["alpha"] = Convert.ToChar(945);
			Class27.dictionary_0["beta"] = Convert.ToChar(946);
			Class27.dictionary_0["gamma"] = Convert.ToChar(947);
			Class27.dictionary_0["delta"] = Convert.ToChar(948);
			Class27.dictionary_0["epsilon"] = Convert.ToChar(949);
			Class27.dictionary_0["zeta"] = Convert.ToChar(950);
			Class27.dictionary_0["eta"] = Convert.ToChar(951);
			Class27.dictionary_0["theta"] = Convert.ToChar(952);
			Class27.dictionary_0["iota"] = Convert.ToChar(953);
			Class27.dictionary_0["kappa"] = Convert.ToChar(954);
			Class27.dictionary_0["lambda"] = Convert.ToChar(955);
			Class27.dictionary_0["mu"] = Convert.ToChar(956);
			Class27.dictionary_0["nu"] = Convert.ToChar(957);
			Class27.dictionary_0["xi"] = Convert.ToChar(958);
			Class27.dictionary_0["omicron"] = Convert.ToChar(959);
			Class27.dictionary_0["pi"] = Convert.ToChar(960);
			Class27.dictionary_0["rho"] = Convert.ToChar(961);
			Class27.dictionary_0["sigmaf"] = Convert.ToChar(962);
			Class27.dictionary_0["sigma"] = Convert.ToChar(963);
			Class27.dictionary_0["tau"] = Convert.ToChar(964);
			Class27.dictionary_0["upsilon"] = Convert.ToChar(965);
			Class27.dictionary_0["phi"] = Convert.ToChar(966);
			Class27.dictionary_0["chi"] = Convert.ToChar(967);
			Class27.dictionary_0["psi"] = Convert.ToChar(968);
			Class27.dictionary_0["omega"] = Convert.ToChar(969);
			Class27.dictionary_0["thetasym"] = Convert.ToChar(977);
			Class27.dictionary_0["upsih"] = Convert.ToChar(978);
			Class27.dictionary_0["piv"] = Convert.ToChar(982);
			Class27.dictionary_0["OElig"] = Convert.ToChar(338);
			Class27.dictionary_0["oelig"] = Convert.ToChar(339);
			Class27.dictionary_0["Scaron"] = Convert.ToChar(352);
			Class27.dictionary_0["scaron"] = Convert.ToChar(353);
			Class27.dictionary_0["Yuml"] = Convert.ToChar(376);
			Class27.dictionary_0["fnof"] = Convert.ToChar(402);
			Class27.dictionary_0["circ"] = Convert.ToChar(710);
			Class27.dictionary_0["tilde"] = Convert.ToChar(732);
			Class27.dictionary_0["ndash"] = Convert.ToChar(8211);
			Class27.dictionary_0["mdash"] = Convert.ToChar(8212);
			Class27.dictionary_0["lsquo"] = Convert.ToChar(8216);
			Class27.dictionary_0["rsquo"] = Convert.ToChar(8217);
			Class27.dictionary_0["sbquo"] = Convert.ToChar(8218);
			Class27.dictionary_0["ldquo"] = Convert.ToChar(8220);
			Class27.dictionary_0["rdquo"] = Convert.ToChar(8221);
			Class27.dictionary_0["bdquo"] = Convert.ToChar(8222);
			Class27.dictionary_0["dagger"] = Convert.ToChar(8224);
			Class27.dictionary_0["Dagger"] = Convert.ToChar(8225);
			Class27.dictionary_0["bull"] = Convert.ToChar(8226);
			Class27.dictionary_0["hellip"] = Convert.ToChar(8230);
			Class27.dictionary_0["permil"] = Convert.ToChar(8240);
			Class27.dictionary_0["prime"] = Convert.ToChar(8242);
			Class27.dictionary_0["Prime"] = Convert.ToChar(8243);
			Class27.dictionary_0["lsaquo"] = Convert.ToChar(8249);
			Class27.dictionary_0["rsaquo"] = Convert.ToChar(8250);
			Class27.dictionary_0["oline"] = Convert.ToChar(8254);
			Class27.dictionary_0["euro"] = Convert.ToChar(8364);
			Class27.dictionary_0["trade"] = Convert.ToChar(153);
			Class27.dictionary_0["larr"] = Convert.ToChar(8592);
			Class27.dictionary_0["uarr"] = Convert.ToChar(8593);
			Class27.dictionary_0["rarr"] = Convert.ToChar(8594);
			Class27.dictionary_0["darr"] = Convert.ToChar(8595);
			Class27.dictionary_0["harr"] = Convert.ToChar(8596);
			Class27.dictionary_0["crarr"] = Convert.ToChar(8629);
			Class27.dictionary_0["lceil"] = Convert.ToChar(8968);
			Class27.dictionary_0["rceil"] = Convert.ToChar(8969);
			Class27.dictionary_0["lfloor"] = Convert.ToChar(8970);
			Class27.dictionary_0["rfloor"] = Convert.ToChar(8971);
			Class27.dictionary_0["loz"] = Convert.ToChar(9674);
			Class27.dictionary_0["spades"] = Convert.ToChar(9824);
			Class27.dictionary_0["clubs"] = Convert.ToChar(9827);
			Class27.dictionary_0["hearts"] = Convert.ToChar(9829);
			Class27.dictionary_0["diams"] = Convert.ToChar(9830);
		}

		public static bool smethod_0(string string_0)
		{
			return Class27.list_0.Contains(string_0);
		}

		public static string smethod_1(string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				string_0 = Class27.smethod_3(string_0);
				string_0 = Class27.smethod_4(string_0);
				KeyValuePair<string, string>[] array = Class27.keyValuePair_0;
				for (int i = 0; i < array.Length; i++)
				{
					KeyValuePair<string, string> keyValuePair = array[i];
					string_0 = string_0.Replace(keyValuePair.Key, keyValuePair.Value);
				}
			}
			return string_0;
		}

		public static string smethod_2(string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				for (int num = Class27.keyValuePair_0.Length - 1; num >= 0; num--)
				{
					string_0 = string_0.Replace(Class27.keyValuePair_0[num].Value, Class27.keyValuePair_0[num].Key);
				}
			}
			return string_0;
		}

		private static string smethod_3(string string_0)
		{
			for (int num = string_0.IndexOf("&#", StringComparison.OrdinalIgnoreCase); num > -1; num = string_0.IndexOf("&#", num + 1))
			{
				bool flag = string_0.Length > num + 3 && char.ToLower(string_0[num + 2]) == 'x';
				int num2 = num + 2 + (flag ? 1 : 0);
				long num3 = 0L;
				while (num2 < string_0.Length && Class22.smethod_1(string_0[num2], flag))
				{
					num3 = num3 * (flag ? 16 : 10) + Class22.smethod_2(string_0[num2++], flag);
				}
				num2 += ((num2 < string_0.Length && string_0[num2] == ';') ? 1 : 0);
				string value = string.Empty;
				if (num3 >= 0L && num3 <= 1114111L && (num3 < 55296L || num3 > 57343L))
				{
					value = char.ConvertFromUtf32((int)num3);
				}
				string_0 = string_0.Remove(num, num2 - num);
				string_0 = string_0.Insert(num, value);
			}
			return string_0;
		}

		private static string smethod_4(string string_0)
		{
			for (int num = string_0.IndexOf('&'); num > -1; num = string_0.IndexOf('&', num + 1))
			{
				int num2 = string_0.IndexOf(';', num);
				if (num2 > -1 && num2 - num < 8)
				{
					string key = string_0.Substring(num + 1, num2 - num - 1);
					if (Class27.dictionary_0.TryGetValue(key, out var value))
					{
						string_0 = string_0.Remove(num, num2 - num + 1);
						string_0 = string_0.Insert(num, value.ToString());
					}
				}
			}
			return string_0;
		}
	}
}

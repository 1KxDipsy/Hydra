using ns14;
using ns16;

namespace ns0
{
	internal static class Class24
	{
		private static readonly RColor rcolor_0 = RColor.FromArgb(169, 51, 153, 255);

		public static RColor RColor_0 => Class24.rcolor_0;

		public static double smethod_0(RGraphics rgraphics_0, Class49 class49_0)
		{
			double num = class49_0.RFont_1.GetWhitespaceWidth(rgraphics_0);
			if (!string.IsNullOrEmpty(class49_0.String_53) && !(class49_0.String_53 == "normal"))
			{
				num += Class31.smethod_4(class49_0.String_53, 0.0, class49_0, bool_0: true);
			}
			return num;
		}

		public static string smethod_1(Class50 class50_0, string string_0)
		{
			switch (Class75.smethod_0(string_0))
			{
			case 219030440u:
				if (string_0 == "font-variant")
				{
					return class50_0.String_58;
				}
				goto default;
			case 127652482u:
				if (string_0 == "text-align")
				{
					return class50_0.String_49;
				}
				goto default;
			case 306900080u:
				if (string_0 == "left")
				{
					return class50_0.String_28;
				}
				goto default;
			case 252494808u:
				if (string_0 == "font-style")
				{
					return class50_0.String_57;
				}
				goto default;
			case 549768767u:
				if (string_0 == "font-family")
				{
					return class50_0.String_55;
				}
				goto default;
			case 349487689u:
				if (string_0 == "list-style-image")
				{
					return class50_0.String_63;
				}
				goto default;
			case 787794385u:
				if (string_0 == "word-spacing")
				{
					return class50_0.String_53;
				}
				goto default;
			case 742030163u:
				if (string_0 == "vertical-align")
				{
					return class50_0.String_47;
				}
				goto default;
			case 823368261u:
				if (string_0 == "margin-top")
				{
					return class50_0.String_22;
				}
				goto default;
			case 805531780u:
				if (string_0 == "border-bottom-width")
				{
					return class50_0.String_0;
				}
				goto default;
			case 883380135u:
				if (string_0 == "text-indent")
				{
					return class50_0.String_48;
				}
				goto default;
			case 831303221u:
				if (string_0 == "corner-radius")
				{
					return class50_0.String_14;
				}
				goto default;
			case 1103135245u:
				if (string_0 == "border-right-width")
				{
					return class50_0.String_2;
				}
				goto default;
			case 1031692888u:
				if (string_0 == "color")
				{
					return class50_0.String_39;
				}
				goto default;
			case 1177978080u:
				if (string_0 == "margin-right")
				{
					return class50_0.String_21;
				}
				goto default;
			case 1164572437u:
				if (string_0 == "display")
				{
					return class50_0.String_41;
				}
				goto default;
			case 1422898045u:
				if (string_0 == "border-bottom-style")
				{
					return class50_0.String_4;
				}
				goto default;
			case 1306599407u:
				if (string_0 == "margin-left")
				{
					return class50_0.String_20;
				}
				goto default;
			case 1525338768u:
				if (string_0 == "corner-se-radius")
				{
					return class50_0.String_17;
				}
				goto default;
			case 1466694928u:
				if (string_0 == "padding-top")
				{
					return class50_0.String_26;
				}
				goto default;
			case 1706478630u:
				if (string_0 == "empty-cells")
				{
					return class50_0.String_43;
				}
				goto default;
			case 1635657715u:
				if (string_0 == "corner-ne-radius")
				{
					return class50_0.String_16;
				}
				goto default;
			case 2000487999u:
				if (string_0 == "background-repeat")
				{
					return class50_0.String_36;
				}
				goto default;
			case 1711128953u:
				if (string_0 == "corner-nw-radius")
				{
					return class50_0.String_15;
				}
				goto default;
			case 2041122471u:
				if (string_0 == "text-decoration")
				{
					return class50_0.String_50;
				}
				goto default;
			case 2039958762u:
				if (string_0 == "border-right-color")
				{
					return class50_0.String_10;
				}
				goto default;
			case 2361821363u:
				if (string_0 == "background-position")
				{
					return class50_0.String_35;
				}
				goto default;
			case 2134373861u:
				if (string_0 == "visibility")
				{
					return class50_0.String_52;
				}
				goto default;
			case 2416839281u:
				if (string_0 == "margin-bottom")
				{
					return class50_0.String_19;
				}
				goto default;
			case 2393169011u:
				if (string_0 == "page-break-inside")
				{
					return class50_0.String_27;
				}
				goto default;
			case 2471448074u:
				if (string_0 == "position")
				{
					return class50_0.String_45;
				}
				goto default;
			case 2428421058u:
				if (string_0 == "content")
				{
					return class50_0.String_40;
				}
				goto default;
			case 2502958641u:
				if (string_0 == "white-space")
				{
					return class50_0.String_51;
				}
				goto default;
			case 2479631166u:
				if (string_0 == "background-gradient-angle")
				{
					return class50_0.String_38;
				}
				goto default;
			case 2508680735u:
				if (string_0 == "width")
				{
					return class50_0.String_30;
				}
				goto default;
			case 2507507657u:
				if (string_0 == "list-style")
				{
					return class50_0.String_60;
				}
				goto default;
			case 2572986219u:
				if (string_0 == "overflow")
				{
					return class50_0.String_61;
				}
				goto default;
			case 2560944639u:
				if (string_0 == "border-bottom-color")
				{
					return class50_0.String_8;
				}
				goto default;
			case 2683585427u:
				if (string_0 == "border-spacing")
				{
					return class50_0.String_12;
				}
				goto default;
			case 2679686814u:
				if (string_0 == "border-left-width")
				{
					return class50_0.String_1;
				}
				goto default;
			case 2802900028u:
				if (string_0 == "top")
				{
					return class50_0.String_29;
				}
				goto default;
			case 2797886853u:
				if (string_0 == "float")
				{
					return class50_0.String_44;
				}
				goto default;
			case 2930062261u:
				if (string_0 == "border-left-color")
				{
					return class50_0.String_9;
				}
				goto default;
			case 2876783500u:
				if (string_0 == "padding-left")
				{
					return class50_0.String_24;
				}
				goto default;
			case 3133968552u:
				if (string_0 == "max-width")
				{
					return class50_0.String_31;
				}
				goto default;
			case 2980770829u:
				if (string_0 == "background-image")
				{
					return class50_0.String_34;
				}
				goto default;
			case 3247228931u:
				if (string_0 == "font-weight")
				{
					return class50_0.String_59;
				}
				goto default;
			case 3173719076u:
				if (string_0 == "list-style-type")
				{
					return class50_0.String_64;
				}
				goto default;
			case 3391345689u:
				if (string_0 == "padding-right")
				{
					return class50_0.String_25;
				}
				goto default;
			case 3328355879u:
				if (string_0 == "background-color")
				{
					return class50_0.String_33;
				}
				goto default;
			case 3498345039u:
				if (string_0 == "word-break")
				{
					return class50_0.String_54;
				}
				goto default;
			case 3473090444u:
				if (string_0 == "border-right-style")
				{
					return class50_0.String_6;
				}
				goto default;
			case 3585981250u:
				if (string_0 == "height")
				{
					return class50_0.String_32;
				}
				goto default;
			case 3504398499u:
				if (string_0 == "border-top-color")
				{
					return class50_0.String_11;
				}
				goto default;
			case 3659658663u:
				if (string_0 == "border-left-style")
				{
					return class50_0.String_5;
				}
				goto default;
			case 3590500362u:
				if (string_0 == "corner-sw-radius")
				{
					return class50_0.String_18;
				}
				goto default;
			case 3748513642u:
				if (string_0 == "direction")
				{
					return class50_0.String_42;
				}
				goto default;
			case 3703130240u:
				if (string_0 == "background-gradient")
				{
					return class50_0.String_37;
				}
				goto default;
			case 3860607080u:
				if (string_0 == "border-top-width")
				{
					return class50_0.String_3;
				}
				goto default;
			case 3769371381u:
				if (string_0 == "line-height")
				{
					return class50_0.String_46;
				}
				goto default;
			case 3975754638u:
				if (string_0 == "padding-bottom")
				{
					return class50_0.String_23;
				}
				goto default;
			case 3928017457u:
				if (string_0 == "border-top-style")
				{
					return class50_0.String_7;
				}
				goto default;
			case 4284404126u:
				if (string_0 == "font-size")
				{
					return class50_0.String_56;
				}
				goto default;
			case 4130385793u:
				if (string_0 == "border-collapse")
				{
					return class50_0.String_13;
				}
				goto default;
			case 4067849007u:
				if (string_0 == "list-style-position")
				{
					return class50_0.String_62;
				}
				goto default;
			default:
				return null;
			}
		}

		public static void smethod_2(Class50 class50_0, string string_0, string string_1)
		{
			switch (Class75.smethod_0(string_0))
			{
			case 219030440u:
				if (string_0 == "font-variant")
				{
					class50_0.String_58 = string_1;
				}
				break;
			case 127652482u:
				if (string_0 == "text-align")
				{
					class50_0.String_49 = string_1;
				}
				break;
			case 306900080u:
				if (string_0 == "left")
				{
					class50_0.String_28 = string_1;
				}
				break;
			case 252494808u:
				if (string_0 == "font-style")
				{
					class50_0.String_57 = string_1;
				}
				break;
			case 549768767u:
				if (string_0 == "font-family")
				{
					class50_0.String_55 = string_1;
				}
				break;
			case 349487689u:
				if (string_0 == "list-style-image")
				{
					class50_0.String_63 = string_1;
				}
				break;
			case 787794385u:
				if (string_0 == "word-spacing")
				{
					class50_0.String_53 = string_1;
				}
				break;
			case 742030163u:
				if (string_0 == "vertical-align")
				{
					class50_0.String_47 = string_1;
				}
				break;
			case 823368261u:
				if (string_0 == "margin-top")
				{
					class50_0.String_22 = string_1;
				}
				break;
			case 805531780u:
				if (string_0 == "border-bottom-width")
				{
					class50_0.String_0 = string_1;
				}
				break;
			case 883380135u:
				if (string_0 == "text-indent")
				{
					class50_0.String_48 = string_1;
				}
				break;
			case 831303221u:
				if (string_0 == "corner-radius")
				{
					class50_0.String_14 = string_1;
				}
				break;
			case 1103135245u:
				if (string_0 == "border-right-width")
				{
					class50_0.String_2 = string_1;
				}
				break;
			case 1031692888u:
				if (string_0 == "color")
				{
					class50_0.String_39 = string_1;
				}
				break;
			case 1177978080u:
				if (string_0 == "margin-right")
				{
					class50_0.String_21 = string_1;
				}
				break;
			case 1164572437u:
				if (string_0 == "display")
				{
					class50_0.String_41 = string_1;
				}
				break;
			case 1422898045u:
				if (string_0 == "border-bottom-style")
				{
					class50_0.String_4 = string_1;
				}
				break;
			case 1306599407u:
				if (string_0 == "margin-left")
				{
					class50_0.String_20 = string_1;
				}
				break;
			case 1525338768u:
				if (string_0 == "corner-se-radius")
				{
					class50_0.String_17 = string_1;
				}
				break;
			case 1466694928u:
				if (string_0 == "padding-top")
				{
					class50_0.String_26 = string_1;
				}
				break;
			case 1706478630u:
				if (string_0 == "empty-cells")
				{
					class50_0.String_43 = string_1;
				}
				break;
			case 1635657715u:
				if (string_0 == "corner-ne-radius")
				{
					class50_0.String_16 = string_1;
				}
				break;
			case 2000487999u:
				if (string_0 == "background-repeat")
				{
					class50_0.String_36 = string_1;
				}
				break;
			case 1711128953u:
				if (string_0 == "corner-nw-radius")
				{
					class50_0.String_15 = string_1;
				}
				break;
			case 2041122471u:
				if (string_0 == "text-decoration")
				{
					class50_0.String_50 = string_1;
				}
				break;
			case 2039958762u:
				if (string_0 == "border-right-color")
				{
					class50_0.String_10 = string_1;
				}
				break;
			case 2361821363u:
				if (string_0 == "background-position")
				{
					class50_0.String_35 = string_1;
				}
				break;
			case 2134373861u:
				if (string_0 == "visibility")
				{
					class50_0.String_52 = string_1;
				}
				break;
			case 2416839281u:
				if (string_0 == "margin-bottom")
				{
					class50_0.String_19 = string_1;
				}
				break;
			case 2393169011u:
				if (string_0 == "page-break-inside")
				{
					class50_0.String_27 = string_1;
				}
				break;
			case 2471448074u:
				if (string_0 == "position")
				{
					class50_0.String_45 = string_1;
				}
				break;
			case 2428421058u:
				if (string_0 == "content")
				{
					class50_0.String_40 = string_1;
				}
				break;
			case 2502958641u:
				if (string_0 == "white-space")
				{
					class50_0.String_51 = string_1;
				}
				break;
			case 2479631166u:
				if (string_0 == "background-gradient-angle")
				{
					class50_0.String_38 = string_1;
				}
				break;
			case 2508680735u:
				if (string_0 == "width")
				{
					class50_0.String_30 = string_1;
				}
				break;
			case 2507507657u:
				if (string_0 == "list-style")
				{
					class50_0.String_60 = string_1;
				}
				break;
			case 2572986219u:
				if (string_0 == "overflow")
				{
					class50_0.String_61 = string_1;
				}
				break;
			case 2560944639u:
				if (string_0 == "border-bottom-color")
				{
					class50_0.String_8 = string_1;
				}
				break;
			case 2683585427u:
				if (string_0 == "border-spacing")
				{
					class50_0.String_12 = string_1;
				}
				break;
			case 2679686814u:
				if (string_0 == "border-left-width")
				{
					class50_0.String_1 = string_1;
				}
				break;
			case 2802900028u:
				if (string_0 == "top")
				{
					class50_0.String_29 = string_1;
				}
				break;
			case 2797886853u:
				if (string_0 == "float")
				{
					class50_0.String_44 = string_1;
				}
				break;
			case 2930062261u:
				if (string_0 == "border-left-color")
				{
					class50_0.String_9 = string_1;
				}
				break;
			case 2876783500u:
				if (string_0 == "padding-left")
				{
					class50_0.String_24 = string_1;
				}
				break;
			case 3133968552u:
				if (string_0 == "max-width")
				{
					class50_0.String_31 = string_1;
				}
				break;
			case 2980770829u:
				if (string_0 == "background-image")
				{
					class50_0.String_34 = string_1;
				}
				break;
			case 3247228931u:
				if (string_0 == "font-weight")
				{
					class50_0.String_59 = string_1;
				}
				break;
			case 3173719076u:
				if (string_0 == "list-style-type")
				{
					class50_0.String_64 = string_1;
				}
				break;
			case 3391345689u:
				if (string_0 == "padding-right")
				{
					class50_0.String_25 = string_1;
				}
				break;
			case 3328355879u:
				if (string_0 == "background-color")
				{
					class50_0.String_33 = string_1;
				}
				break;
			case 3498345039u:
				if (string_0 == "word-break")
				{
					class50_0.String_54 = string_1;
				}
				break;
			case 3473090444u:
				if (string_0 == "border-right-style")
				{
					class50_0.String_6 = string_1;
				}
				break;
			case 3585981250u:
				if (string_0 == "height")
				{
					class50_0.String_32 = string_1;
				}
				break;
			case 3504398499u:
				if (string_0 == "border-top-color")
				{
					class50_0.String_11 = string_1;
				}
				break;
			case 3659658663u:
				if (string_0 == "border-left-style")
				{
					class50_0.String_5 = string_1;
				}
				break;
			case 3590500362u:
				if (string_0 == "corner-sw-radius")
				{
					class50_0.String_18 = string_1;
				}
				break;
			case 3748513642u:
				if (string_0 == "direction")
				{
					class50_0.String_42 = string_1;
				}
				break;
			case 3703130240u:
				if (string_0 == "background-gradient")
				{
					class50_0.String_37 = string_1;
				}
				break;
			case 3860607080u:
				if (string_0 == "border-top-width")
				{
					class50_0.String_3 = string_1;
				}
				break;
			case 3769371381u:
				if (string_0 == "line-height")
				{
					class50_0.String_46 = string_1;
				}
				break;
			case 3975754638u:
				if (string_0 == "padding-bottom")
				{
					class50_0.String_23 = string_1;
				}
				break;
			case 3928017457u:
				if (string_0 == "border-top-style")
				{
					class50_0.String_7 = string_1;
				}
				break;
			case 4284404126u:
				if (string_0 == "font-size")
				{
					class50_0.String_56 = string_1;
				}
				break;
			case 4130385793u:
				if (string_0 == "border-collapse")
				{
					class50_0.String_13 = string_1;
				}
				break;
			case 4067849007u:
				if (string_0 == "list-style-position")
				{
					class50_0.String_62 = string_1;
				}
				break;
			}
		}
	}
}

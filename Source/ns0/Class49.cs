using System.Globalization;
using System.Text.RegularExpressions;
using ns14;
using ns16;

namespace ns0
{
	internal abstract class Class49
	{
		private string string_0 = "transparent";

		private string string_1 = "none";

		private string string_2 = "90";

		private string string_3 = "none";

		private string string_4 = "0% 0%";

		private string string_5 = "repeat";

		private string string_6 = "medium";

		private string string_7 = "medium";

		private string string_8 = "medium";

		private string string_9 = "medium";

		private string string_10 = "black";

		private string string_11 = "black";

		private string string_12 = "black";

		private string string_13 = "black";

		private string string_14 = "none";

		private string string_15 = "none";

		private string string_16 = "none";

		private string string_17 = "none";

		private string string_18 = "0";

		private string string_19 = "separate";

		private string string_20;

		private string string_21 = "black";

		private string string_22 = "normal";

		private string string_23 = "0";

		private string string_24 = "0";

		private string string_25 = "0";

		private string string_26 = "0";

		private string string_27 = "0";

		private string string_28 = "show";

		private string string_29 = "ltr";

		private string string_30 = "inline";

		private string string_31;

		private string string_32 = "medium";

		private string string_33 = "normal";

		private string string_34 = "normal";

		private string string_35 = "normal";

		private string string_36 = "none";

		private string string_37 = "auto";

		private string string_38 = "0";

		private string string_39 = "0";

		private string string_40 = "0";

		private string string_41 = "0";

		private string string_42 = "auto";

		private string string_43 = "normal";

		private string string_44 = "disc";

		private string string_45 = string.Empty;

		private string string_46 = "outside";

		private string string_47 = string.Empty;

		private string string_48 = "visible";

		private string string_49 = "0";

		private string string_50 = "0";

		private string string_51 = "0";

		private string string_52 = "0";

		private string string_53 = "auto";

		private string string_54;

		private string string_55 = string.Empty;

		private string string_56 = string.Empty;

		private string string_57 = "0";

		private string string_58 = "auto";

		private string string_59 = "static";

		private string string_60 = "baseline";

		private string string_61 = "auto";

		private string string_62 = "none";

		private string string_63 = "normal";

		private string string_64 = "normal";

		private string string_65 = "normal";

		private string string_66 = "visible";

		private RPoint rpoint_0;

		private RSize rsize_0;

		private double double_0 = double.NaN;

		private double double_1 = double.NaN;

		private double double_2 = double.NaN;

		private double double_3 = double.NaN;

		private RColor rcolor_0 = RColor.Empty;

		private double double_4 = double.NaN;

		private double double_5 = double.NaN;

		private double double_6 = double.NaN;

		private double double_7 = double.NaN;

		private double double_8 = double.NaN;

		private double double_9 = double.NaN;

		private double double_10 = double.NaN;

		private double double_11 = double.NaN;

		private double double_12 = double.NaN;

		private double double_13 = double.NaN;

		private double double_14 = double.NaN;

		private double double_15 = double.NaN;

		private double double_16 = double.NaN;

		private double double_17 = double.NaN;

		private double double_18 = double.NaN;

		private double double_19 = double.NaN;

		private double double_20 = double.NaN;

		private double double_21 = double.NaN;

		private double double_22 = double.NaN;

		private double double_23 = double.NaN;

		private double double_24 = double.NaN;

		private RColor rcolor_1 = RColor.Empty;

		private RColor rcolor_2 = RColor.Empty;

		private RColor rcolor_3 = RColor.Empty;

		private RColor rcolor_4 = RColor.Empty;

		private RColor rcolor_5 = RColor.Empty;

		private RColor rcolor_6 = RColor.Empty;

		private RFont rfont_0;

		public string String_0
		{
			get
			{
				return this.string_8;
			}
			set
			{
				this.string_8 = value;
				this.double_18 = double.NaN;
			}
		}

		public string String_1
		{
			get
			{
				return this.string_9;
			}
			set
			{
				this.string_9 = value;
				this.double_17 = double.NaN;
			}
		}

		public string String_2
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
				this.double_19 = double.NaN;
			}
		}

		public string String_3
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
				this.double_16 = double.NaN;
			}
		}

		public string String_4
		{
			get
			{
				return this.string_16;
			}
			set
			{
				this.string_16 = value;
			}
		}

		public string String_5
		{
			get
			{
				return this.string_17;
			}
			set
			{
				this.string_17 = value;
			}
		}

		public string String_6
		{
			get
			{
				return this.string_15;
			}
			set
			{
				this.string_15 = value;
			}
		}

		public string String_7
		{
			get
			{
				return this.string_14;
			}
			set
			{
				this.string_14 = value;
			}
		}

		public string String_8
		{
			get
			{
				return this.string_12;
			}
			set
			{
				this.string_12 = value;
				this.rcolor_4 = RColor.Empty;
			}
		}

		public string String_9
		{
			get
			{
				return this.string_13;
			}
			set
			{
				this.string_13 = value;
				this.rcolor_3 = RColor.Empty;
			}
		}

		public string String_10
		{
			get
			{
				return this.string_11;
			}
			set
			{
				this.string_11 = value;
				this.rcolor_5 = RColor.Empty;
			}
		}

		public string String_11
		{
			get
			{
				return this.string_10;
			}
			set
			{
				this.string_10 = value;
				this.rcolor_2 = RColor.Empty;
			}
		}

		public string String_12
		{
			get
			{
				return this.string_18;
			}
			set
			{
				this.string_18 = value;
			}
		}

		public string String_13
		{
			get
			{
				return this.string_19;
			}
			set
			{
				this.string_19 = value;
			}
		}

		public string String_14
		{
			get
			{
				return this.string_27;
			}
			set
			{
				MatchCollection matchCollection = Class36.smethod_1("([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", value);
				switch (matchCollection.Count)
				{
				case 1:
					this.String_16 = matchCollection[0].Value;
					this.String_15 = matchCollection[0].Value;
					this.String_17 = matchCollection[0].Value;
					this.String_18 = matchCollection[0].Value;
					break;
				case 2:
					this.String_16 = matchCollection[0].Value;
					this.String_15 = matchCollection[0].Value;
					this.String_17 = matchCollection[1].Value;
					this.String_18 = matchCollection[1].Value;
					break;
				case 3:
					this.String_16 = matchCollection[0].Value;
					this.String_15 = matchCollection[1].Value;
					this.String_17 = matchCollection[2].Value;
					break;
				case 4:
					this.String_16 = matchCollection[0].Value;
					this.String_15 = matchCollection[1].Value;
					this.String_17 = matchCollection[2].Value;
					this.String_18 = matchCollection[3].Value;
					break;
				}
				this.string_27 = value;
			}
		}

		public string String_15
		{
			get
			{
				return this.string_23;
			}
			set
			{
				this.string_23 = value;
			}
		}

		public string String_16
		{
			get
			{
				return this.string_24;
			}
			set
			{
				this.string_24 = value;
			}
		}

		public string String_17
		{
			get
			{
				return this.string_25;
			}
			set
			{
				this.string_25 = value;
			}
		}

		public string String_18
		{
			get
			{
				return this.string_26;
			}
			set
			{
				this.string_26 = value;
			}
		}

		public string String_19
		{
			get
			{
				return this.string_38;
			}
			set
			{
				this.string_38 = value;
			}
		}

		public string String_20
		{
			get
			{
				return this.string_39;
			}
			set
			{
				this.string_39 = value;
			}
		}

		public string String_21
		{
			get
			{
				return this.string_40;
			}
			set
			{
				this.string_40 = value;
			}
		}

		public string String_22
		{
			get
			{
				return this.string_41;
			}
			set
			{
				this.string_41 = value;
			}
		}

		public string String_23
		{
			get
			{
				return this.string_50;
			}
			set
			{
				this.string_50 = value;
				this.double_8 = double.NaN;
			}
		}

		public string String_24
		{
			get
			{
				return this.string_49;
			}
			set
			{
				this.string_49 = value;
				this.double_10 = double.NaN;
			}
		}

		public string String_25
		{
			get
			{
				return this.string_51;
			}
			set
			{
				this.string_51 = value;
				this.double_9 = double.NaN;
			}
		}

		public string String_26
		{
			get
			{
				return this.string_52;
			}
			set
			{
				this.string_52 = value;
				this.double_7 = double.NaN;
			}
		}

		public string String_27
		{
			get
			{
				return this.string_53;
			}
			set
			{
				this.string_53 = value;
			}
		}

		public string String_28
		{
			get
			{
				return this.string_42;
			}
			set
			{
				this.string_42 = value;
				if (this.String_45 == "fixed")
				{
					this.rpoint_0 = this.vmethod_0(this.String_28, this.String_29);
				}
			}
		}

		public string String_29
		{
			get
			{
				return this.string_58;
			}
			set
			{
				this.string_58 = value;
				if (this.String_45 == "fixed")
				{
					this.rpoint_0 = this.vmethod_0(this.String_28, this.String_29);
				}
			}
		}

		public string String_30
		{
			get
			{
				return this.string_61;
			}
			set
			{
				this.string_61 = value;
			}
		}

		public string String_31
		{
			get
			{
				return this.string_62;
			}
			set
			{
				this.string_62 = value;
			}
		}

		public string String_32
		{
			get
			{
				return this.string_37;
			}
			set
			{
				this.string_37 = value;
			}
		}

		public string String_33
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		public string String_34
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}

		public string String_35
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}

		public string String_36
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}

		public string String_37
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

		public string String_38
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

		public string String_39
		{
			get
			{
				return this.string_21;
			}
			set
			{
				this.string_21 = value;
				this.rcolor_0 = RColor.Empty;
			}
		}

		public string String_40
		{
			get
			{
				return this.string_22;
			}
			set
			{
				this.string_22 = value;
			}
		}

		public string String_41
		{
			get
			{
				return this.string_30;
			}
			set
			{
				this.string_30 = value;
			}
		}

		public string String_42
		{
			get
			{
				return this.string_29;
			}
			set
			{
				this.string_29 = value;
			}
		}

		public string String_43
		{
			get
			{
				return this.string_28;
			}
			set
			{
				this.string_28 = value;
			}
		}

		public string String_44
		{
			get
			{
				return this.string_36;
			}
			set
			{
				this.string_36 = value;
			}
		}

		public string String_45
		{
			get
			{
				return this.string_59;
			}
			set
			{
				this.string_59 = value;
			}
		}

		public string String_46
		{
			get
			{
				return this.string_43;
			}
			set
			{
				this.string_43 = string.Format(NumberFormatInfo.InvariantInfo, "{0}px", new object[1] { Class31.smethod_5(value, this.RSize_0.Height, this, "em") });
			}
		}

		public string String_47
		{
			get
			{
				return this.string_60;
			}
			set
			{
				this.string_60 = value;
			}
		}

		public string String_48
		{
			get
			{
				return this.string_57;
			}
			set
			{
				this.string_57 = this.method_1(value);
			}
		}

		public string String_49
		{
			get
			{
				return this.string_55;
			}
			set
			{
				this.string_55 = value;
			}
		}

		public string String_50
		{
			get
			{
				return this.string_56;
			}
			set
			{
				this.string_56 = value;
			}
		}

		public string String_51
		{
			get
			{
				return this.string_65;
			}
			set
			{
				this.string_65 = value;
			}
		}

		public string String_52
		{
			get
			{
				return this.string_66;
			}
			set
			{
				this.string_66 = value;
			}
		}

		public string String_53
		{
			get
			{
				return this.string_63;
			}
			set
			{
				this.string_63 = this.method_1(value);
			}
		}

		public string String_54
		{
			get
			{
				return this.string_64;
			}
			set
			{
				this.string_64 = value;
			}
		}

		public string String_55
		{
			get
			{
				return this.string_31;
			}
			set
			{
				this.string_31 = value;
			}
		}

		public string String_56
		{
			get
			{
				return this.string_32;
			}
			set
			{
				string text = Class36.smethod_2("([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", value);
				if (text != null)
				{
					Class57 @class = new Class57(text);
					this.string_32 = (@class.Boolean_0 ? "medium" : ((@class.Enum3_0 != Enum3.const_1 || this.vmethod_3() == null) ? @class.ToString() : @class.method_0(this.vmethod_3().RFont_1.Size).ToString()));
				}
				else
				{
					this.string_32 = value;
				}
			}
		}

		public string String_57
		{
			get
			{
				return this.string_33;
			}
			set
			{
				this.string_33 = value;
			}
		}

		public string String_58
		{
			get
			{
				return this.string_34;
			}
			set
			{
				this.string_34 = value;
			}
		}

		public string String_59
		{
			get
			{
				return this.string_35;
			}
			set
			{
				this.string_35 = value;
			}
		}

		public string String_60
		{
			get
			{
				return this.string_47;
			}
			set
			{
				this.string_47 = value;
			}
		}

		public string String_61
		{
			get
			{
				return this.string_48;
			}
			set
			{
				this.string_48 = value;
			}
		}

		public string String_62
		{
			get
			{
				return this.string_46;
			}
			set
			{
				this.string_46 = value;
			}
		}

		public string String_63
		{
			get
			{
				return this.string_45;
			}
			set
			{
				this.string_45 = value;
			}
		}

		public string String_64
		{
			get
			{
				return this.string_44;
			}
			set
			{
				this.string_44 = value;
			}
		}

		public RPoint RPoint_0
		{
			get
			{
				if (this.rpoint_0.IsEmpty && this.String_45 == "fixed")
				{
					_ = this.String_28;
					_ = this.String_29;
					this.rpoint_0 = this.vmethod_0(this.String_28, this.String_29);
				}
				return this.rpoint_0;
			}
			set
			{
				this.rpoint_0 = value;
			}
		}

		public RSize RSize_0
		{
			get
			{
				return this.rsize_0;
			}
			set
			{
				this.rsize_0 = value;
			}
		}

		public RRect RRect_0 => new RRect(this.RPoint_0, this.RSize_0);

		public double Double_0 => this.RSize_0.Width - this.Double_19 - this.Double_10 - this.Double_12 - this.Double_21;

		public double Double_1
		{
			get
			{
				return this.RPoint_0.Double_0 + this.RSize_0.Width;
			}
			set
			{
				this.RSize_0 = new RSize(value - this.RPoint_0.Double_0, this.RSize_0.Height);
			}
		}

		public double Double_2
		{
			get
			{
				return this.RPoint_0.Double_1 + this.RSize_0.Height;
			}
			set
			{
				this.RSize_0 = new RSize(this.RSize_0.Width, value - this.RPoint_0.Double_1);
			}
		}

		public double Double_3 => this.RPoint_0.Double_0 + this.Double_19 + this.Double_10;

		public double Double_4 => this.RPoint_0.Double_1 + this.Double_18 + this.Double_9;

		public double Double_5 => this.Double_1 - this.Double_12 - this.Double_21;

		public double Double_6 => this.Double_2 - this.Double_11 - this.Double_20;

		public RRect RRect_1 => RRect.FromLTRB(this.Double_3, this.Double_4, this.Double_5, this.Double_6);

		public double Double_7
		{
			get
			{
				if (double.IsNaN(this.double_5))
				{
					this.double_5 = Class31.smethod_4(this.String_32, this.RSize_0.Height, this);
				}
				return this.double_5;
			}
		}

		public double Double_8
		{
			get
			{
				if (double.IsNaN(this.double_6))
				{
					this.double_6 = Class31.smethod_4(this.String_30, this.RSize_0.Width, this);
				}
				return this.double_6;
			}
		}

		public double Double_9
		{
			get
			{
				if (double.IsNaN(this.double_7))
				{
					this.double_7 = Class31.smethod_4(this.String_26, this.RSize_0.Width, this);
				}
				return this.double_7;
			}
		}

		public double Double_10
		{
			get
			{
				if (double.IsNaN(this.double_10))
				{
					this.double_10 = Class31.smethod_4(this.String_24, this.RSize_0.Width, this);
				}
				return this.double_10;
			}
		}

		public double Double_11
		{
			get
			{
				if (double.IsNaN(this.double_8))
				{
					this.double_8 = Class31.smethod_4(this.String_23, this.RSize_0.Width, this);
				}
				return this.double_8;
			}
		}

		public double Double_12
		{
			get
			{
				if (double.IsNaN(this.double_9))
				{
					this.double_9 = Class31.smethod_4(this.String_25, this.RSize_0.Width, this);
				}
				return this.double_9;
			}
		}

		public double Double_13
		{
			get
			{
				if (double.IsNaN(this.double_11))
				{
					if (this.String_22 == "auto")
					{
						this.String_22 = "0";
					}
					double result = Class31.smethod_4(this.String_22, this.RSize_0.Width, this);
					if (this.String_20.EndsWith("%"))
					{
						return result;
					}
					this.double_11 = result;
				}
				return this.double_11;
			}
		}

		public double Double_14
		{
			get
			{
				return double.IsNaN(this.double_12) ? 0.0 : this.double_12;
			}
			set
			{
				this.double_12 = value;
			}
		}

		public double Double_15
		{
			get
			{
				if (double.IsNaN(this.double_15))
				{
					if (this.String_20 == "auto")
					{
						this.String_20 = "0";
					}
					double result = Class31.smethod_4(this.String_20, this.RSize_0.Width, this);
					if (this.String_20.EndsWith("%"))
					{
						return result;
					}
					this.double_15 = result;
				}
				return this.double_15;
			}
		}

		public double Double_16
		{
			get
			{
				if (double.IsNaN(this.double_13))
				{
					if (this.String_19 == "auto")
					{
						this.String_19 = "0";
					}
					double result = Class31.smethod_4(this.String_19, this.RSize_0.Width, this);
					if (this.String_20.EndsWith("%"))
					{
						return result;
					}
					this.double_13 = result;
				}
				return this.double_13;
			}
		}

		public double Double_17
		{
			get
			{
				if (double.IsNaN(this.double_14))
				{
					if (this.String_21 == "auto")
					{
						this.String_21 = "0";
					}
					double result = Class31.smethod_4(this.String_21, this.RSize_0.Width, this);
					if (this.String_20.EndsWith("%"))
					{
						return result;
					}
					this.double_14 = result;
				}
				return this.double_14;
			}
		}

		public double Double_18
		{
			get
			{
				if (double.IsNaN(this.double_16))
				{
					this.double_16 = Class31.smethod_8(this.String_3, this);
					if (string.IsNullOrEmpty(this.String_7) || this.String_7 == "none")
					{
						this.double_16 = 0.0;
					}
				}
				return this.double_16;
			}
		}

		public double Double_19
		{
			get
			{
				if (double.IsNaN(this.double_17))
				{
					this.double_17 = Class31.smethod_8(this.String_1, this);
					if (string.IsNullOrEmpty(this.String_5) || this.String_5 == "none")
					{
						this.double_17 = 0.0;
					}
				}
				return this.double_17;
			}
		}

		public double Double_20
		{
			get
			{
				if (double.IsNaN(this.double_18))
				{
					this.double_18 = Class31.smethod_8(this.String_0, this);
					if (string.IsNullOrEmpty(this.String_4) || this.String_4 == "none")
					{
						this.double_18 = 0.0;
					}
				}
				return this.double_18;
			}
		}

		public double Double_21
		{
			get
			{
				if (double.IsNaN(this.double_19))
				{
					this.double_19 = Class31.smethod_8(this.String_2, this);
					if (string.IsNullOrEmpty(this.String_6) || this.String_6 == "none")
					{
						this.double_19 = 0.0;
					}
				}
				return this.double_19;
			}
		}

		public RColor RColor_0
		{
			get
			{
				if (this.rcolor_2.IsEmpty)
				{
					this.rcolor_2 = this.vmethod_1(this.String_11);
				}
				return this.rcolor_2;
			}
		}

		public RColor RColor_1
		{
			get
			{
				if (this.rcolor_3.IsEmpty)
				{
					this.rcolor_3 = this.vmethod_1(this.String_9);
				}
				return this.rcolor_3;
			}
		}

		public RColor RColor_2
		{
			get
			{
				if (this.rcolor_4.IsEmpty)
				{
					this.rcolor_4 = this.vmethod_1(this.String_8);
				}
				return this.rcolor_4;
			}
		}

		public RColor RColor_3
		{
			get
			{
				if (this.rcolor_5.IsEmpty)
				{
					this.rcolor_5 = this.vmethod_1(this.String_10);
				}
				return this.rcolor_5;
			}
		}

		public double Double_22
		{
			get
			{
				if (double.IsNaN(this.double_0))
				{
					this.double_0 = Class31.smethod_4(this.String_15, 0.0, this);
				}
				return this.double_0;
			}
		}

		public double Double_23
		{
			get
			{
				if (double.IsNaN(this.double_1))
				{
					this.double_1 = Class31.smethod_4(this.String_16, 0.0, this);
				}
				return this.double_1;
			}
		}

		public double Double_24
		{
			get
			{
				if (double.IsNaN(this.double_3))
				{
					this.double_3 = Class31.smethod_4(this.String_17, 0.0, this);
				}
				return this.double_3;
			}
		}

		public double Double_25
		{
			get
			{
				if (double.IsNaN(this.double_2))
				{
					this.double_2 = Class31.smethod_4(this.String_18, 0.0, this);
				}
				return this.double_2;
			}
		}

		public bool Boolean_0 => this.Double_23 > 0.0 || this.Double_22 > 0.0 || this.Double_24 > 0.0 || this.Double_25 > 0.0;

		public double Double_26 => this.double_21;

		public RColor RColor_4
		{
			get
			{
				if (this.rcolor_0.IsEmpty)
				{
					this.rcolor_0 = this.vmethod_1(this.String_39);
				}
				return this.rcolor_0;
			}
		}

		public RColor RColor_5
		{
			get
			{
				if (this.rcolor_6.IsEmpty)
				{
					this.rcolor_6 = this.vmethod_1(this.String_33);
				}
				return this.rcolor_6;
			}
		}

		public RColor RColor_6
		{
			get
			{
				if (this.rcolor_1.IsEmpty)
				{
					this.rcolor_1 = this.vmethod_1(this.String_37);
				}
				return this.rcolor_1;
			}
		}

		public double Double_27
		{
			get
			{
				if (double.IsNaN(this.double_4))
				{
					this.double_4 = Class31.smethod_3(this.String_38, 360.0);
				}
				return this.double_4;
			}
		}

		public RFont RFont_0 => (this.vmethod_3() == null) ? this.RFont_1 : this.vmethod_3().RFont_1;

		public RFont RFont_1
		{
			get
			{
				RFontStyle rFontStyle;
				double num;
				double num3;
				if (this.rfont_0 == null)
				{
					if (string.IsNullOrEmpty(this.String_55))
					{
						this.String_55 = "Segoe UI";
					}
					if (string.IsNullOrEmpty(this.String_56))
					{
						this.String_56 = 11.0.ToString(CultureInfo.InvariantCulture) + "pt";
					}
					rFontStyle = RFontStyle.Regular;
					if (this.String_57 == "italic" || this.String_57 == "oblique")
					{
						rFontStyle |= RFontStyle.Italic;
					}
					if (this.String_59 != "normal" && this.String_59 != "lighter" && !string.IsNullOrEmpty(this.String_59) && this.String_59 != "inherit")
					{
						rFontStyle |= RFontStyle.Bold;
					}
					num = 11.0;
					if (this.vmethod_3() != null)
					{
						num = this.vmethod_3().RFont_1.Size;
					}
					string text = this.String_56;
					uint num2 = Class75.smethod_0(text);
					if (num2 <= 681251161)
					{
						if (num2 <= 284158167)
						{
							if (num2 != 223437115)
							{
								if (num2 != 284158167 || !(text == "xx-small"))
								{
									goto IL_027e;
								}
								num3 = 7.0;
							}
							else
							{
								if (!(text == "smaller"))
								{
									goto IL_027e;
								}
								num3 = num - 2.0;
							}
						}
						else if (num2 != 515378866)
						{
							if (num2 != 681251161 || !(text == "x-large"))
							{
								goto IL_027e;
							}
							num3 = 14.0;
						}
						else
						{
							if (!(text == "larger"))
							{
								goto IL_027e;
							}
							num3 = num + 2.0;
						}
					}
					else if (num2 <= 900716406)
					{
						if (num2 != 731393469)
						{
							if (num2 != 900716406 || !(text == "medium"))
							{
								goto IL_027e;
							}
							num3 = 11.0;
						}
						else
						{
							if (!(text == "x-small"))
							{
								goto IL_027e;
							}
							num3 = 8.0;
						}
					}
					else if (num2 != 1271934388)
					{
						if (num2 != 1865116687)
						{
							if (num2 != 2730816652u || !(text == "small"))
							{
								goto IL_027e;
							}
							num3 = 9.0;
						}
						else
						{
							if (!(text == "xx-large"))
							{
								goto IL_027e;
							}
							num3 = 15.0;
						}
					}
					else
					{
						if (!(text == "large"))
						{
							goto IL_027e;
						}
						num3 = 13.0;
					}
					goto IL_029d;
				}
				goto IL_02cf;
				IL_029d:
				if (num3 <= 1.0)
				{
					num3 = 11.0;
				}
				this.rfont_0 = this.vmethod_2(this.String_55, num3, rFontStyle);
				goto IL_02cf;
				IL_02cf:
				return this.rfont_0;
				IL_027e:
				num3 = Class31.smethod_6(this.String_56, num, num, null, bool_0: true, bool_1: true);
				goto IL_029d;
			}
		}

		public double Double_28
		{
			get
			{
				if (double.IsNaN(this.double_20))
				{
					this.double_20 = 0.8999999761581421 * Class31.smethod_4(this.String_46, this.RSize_0.Height, this);
				}
				return this.double_20;
			}
		}

		public double Double_29
		{
			get
			{
				if (double.IsNaN(this.double_22))
				{
					this.double_22 = Class31.smethod_4(this.String_48, this.RSize_0.Width, this);
				}
				return this.double_22;
			}
		}

		public double Double_30
		{
			get
			{
				if (double.IsNaN(this.double_23))
				{
					MatchCollection matchCollection = Class36.smethod_1("([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", this.String_12);
					if (matchCollection.Count == 0)
					{
						this.double_23 = 0.0;
					}
					else if (matchCollection.Count > 0)
					{
						this.double_23 = Class31.smethod_4(matchCollection[0].Value, 1.0, this);
					}
				}
				return this.double_23;
			}
		}

		public double Double_31
		{
			get
			{
				if (double.IsNaN(this.double_24))
				{
					MatchCollection matchCollection = Class36.smethod_1("([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", this.String_12);
					if (matchCollection.Count == 0)
					{
						this.double_24 = 0.0;
					}
					else if (matchCollection.Count == 1)
					{
						this.double_24 = Class31.smethod_4(matchCollection[0].Value, 1.0, this);
					}
					else
					{
						this.double_24 = Class31.smethod_4(matchCollection[1].Value, 1.0, this);
					}
				}
				return this.double_24;
			}
		}

		protected abstract RPoint vmethod_0(string string_67, string string_68);

		protected abstract RColor vmethod_1(string string_67);

		protected abstract RFont vmethod_2(string string_67, double double_25, RFontStyle rfontStyle_0);

		protected abstract Class49 vmethod_3();

		public double method_0()
		{
			return this.RFont_1.Height;
		}

		protected string method_1(string string_67)
		{
			Class57 @class = new Class57(string_67);
			if (@class.Enum3_0 == Enum3.const_1)
			{
				string_67 = @class.method_1(this.method_0()).ToString();
			}
			return string_67;
		}

		protected void method_2(string string_67 = null, string string_68 = null, string string_69 = null)
		{
			if (string_67 != null)
			{
				this.String_5 = (this.String_7 = (this.String_6 = (this.String_4 = string_67)));
			}
			if (string_68 != null)
			{
				this.String_1 = (this.String_3 = (this.String_2 = (this.String_0 = string_68)));
			}
			if (string_69 != null)
			{
				this.String_9 = (this.String_11 = (this.String_10 = (this.String_8 = string_69)));
			}
		}

		protected void method_3(RGraphics rgraphics_0)
		{
			if (double.IsNaN(this.Double_26))
			{
				this.double_21 = Class24.smethod_0(rgraphics_0, this);
				if (this.String_53 != "normal")
				{
					this.double_21 += Class31.smethod_4(Class36.smethod_2("([0-9]+|[0-9]*\\.[0-9]+)(em|ex|px|in|cm|mm|pt|pc)", this.String_53), 1.0, this);
				}
			}
		}

		protected void method_4(Class50 class50_0, bool bool_0)
		{
			if (class50_0 != null)
			{
				this.string_18 = class50_0.string_18;
				this.string_19 = class50_0.string_19;
				this.string_21 = class50_0.string_21;
				this.string_28 = class50_0.string_28;
				this.string_65 = class50_0.string_65;
				this.string_66 = class50_0.string_66;
				this.string_57 = class50_0.string_57;
				this.string_55 = class50_0.string_55;
				this.string_60 = class50_0.string_60;
				this.string_31 = class50_0.string_31;
				this.string_32 = class50_0.string_32;
				this.string_33 = class50_0.string_33;
				this.string_34 = class50_0.string_34;
				this.string_35 = class50_0.string_35;
				this.string_45 = class50_0.string_45;
				this.string_46 = class50_0.string_46;
				this.string_44 = class50_0.string_44;
				this.string_47 = class50_0.string_47;
				this.string_43 = class50_0.string_43;
				this.string_64 = class50_0.String_54;
				this.string_29 = class50_0.string_29;
				if (bool_0)
				{
					this.string_0 = class50_0.string_0;
					this.string_1 = class50_0.string_1;
					this.string_2 = class50_0.string_2;
					this.string_3 = class50_0.string_3;
					this.string_4 = class50_0.string_4;
					this.string_5 = class50_0.string_5;
					this.string_6 = class50_0.string_6;
					this.string_7 = class50_0.string_7;
					this.string_8 = class50_0.string_8;
					this.string_9 = class50_0.string_9;
					this.string_10 = class50_0.string_10;
					this.string_11 = class50_0.string_11;
					this.string_12 = class50_0.string_12;
					this.string_13 = class50_0.string_13;
					this.string_14 = class50_0.string_14;
					this.string_15 = class50_0.string_15;
					this.string_16 = class50_0.string_16;
					this.string_17 = class50_0.string_17;
					this.string_20 = class50_0.string_20;
					this.string_23 = class50_0.string_23;
					this.string_24 = class50_0.string_24;
					this.string_25 = class50_0.string_25;
					this.string_26 = class50_0.string_26;
					this.string_27 = class50_0.string_27;
					this.string_30 = class50_0.string_30;
					this.string_36 = class50_0.string_36;
					this.string_37 = class50_0.string_37;
					this.string_38 = class50_0.string_38;
					this.string_39 = class50_0.string_39;
					this.string_40 = class50_0.string_40;
					this.string_41 = class50_0.string_41;
					this.string_42 = class50_0.string_42;
					this.string_43 = class50_0.string_43;
					this.string_48 = class50_0.string_48;
					this.string_49 = class50_0.string_49;
					this.string_50 = class50_0.string_50;
					this.string_51 = class50_0.string_51;
					this.string_52 = class50_0.string_52;
					this.string_54 = class50_0.string_54;
					this.string_56 = class50_0.string_56;
					this.string_58 = class50_0.string_58;
					this.string_59 = class50_0.string_59;
					this.string_61 = class50_0.string_61;
					this.string_62 = class50_0.string_62;
					this.string_63 = class50_0.string_63;
				}
			}
		}
	}
}

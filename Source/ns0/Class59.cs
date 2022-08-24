using ns10;
using ns14;
using ns16;

namespace ns0
{
	internal abstract class Class59
	{
		private readonly Class50 class50_0;

		private RRect rrect_0;

		private Class45 class45_0;

		public Class50 Class50_0 => this.class50_0;

		public RRect RRect_0
		{
			get
			{
				return this.rrect_0;
			}
			set
			{
				this.rrect_0 = value;
			}
		}

		public double Double_0
		{
			get
			{
				return this.rrect_0.Double_0;
			}
			set
			{
				this.rrect_0.Double_0 = value;
			}
		}

		public double Double_1
		{
			get
			{
				return this.rrect_0.Double_1;
			}
			set
			{
				this.rrect_0.Double_1 = value;
			}
		}

		public double Double_2
		{
			get
			{
				return this.rrect_0.Width;
			}
			set
			{
				this.rrect_0.Width = value;
			}
		}

		public double Double_3 => this.rrect_0.Width + this.Double_4;

		public double Double_4 => (this.Class50_0 != null) ? ((this.Boolean_2 ? this.Class50_0.Double_26 : 0.0) + (this.Boolean_3 ? this.Class50_0.Double_26 : 0.0)) : 0.0;

		public double Double_5
		{
			get
			{
				return this.rrect_0.Height;
			}
			set
			{
				this.rrect_0.Height = value;
			}
		}

		public double Double_6
		{
			get
			{
				return this.RRect_0.Right;
			}
			set
			{
				this.Double_2 = value - this.Double_0;
			}
		}

		public double Double_7
		{
			get
			{
				return this.RRect_0.Bottom;
			}
			set
			{
				this.Double_5 = value - this.Double_1;
			}
		}

		public Class45 Class45_0
		{
			get
			{
				return this.class45_0;
			}
			set
			{
				this.class45_0 = value;
			}
		}

		public virtual bool Boolean_1 => false;

		public virtual bool Boolean_2 => false;

		public virtual RImage RImage_0
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual bool Boolean_3 => false;

		public virtual bool Boolean_4 => true;

		public virtual bool Boolean_5 => false;

		public virtual string String_0 => null;

		public bool Boolean_0 => this.class45_0 != null;

		public int Int32_0 => (this.class45_0 != null) ? this.class45_0.method_9(this) : (-1);

		public int Int32_1 => (this.class45_0 != null) ? this.class45_0.method_10(this) : (-1);

		public double Double_8 => (this.class45_0 != null) ? this.class45_0.method_11(this) : (-1.0);

		public double Double_9 => (this.class45_0 != null) ? this.class45_0.method_12(this) : (-1.0);

		internal double Double_10 => (this.Class50_0 != null) ? this.Class50_0.RFont_1.LeftPadding : 0.0;

		protected Class59(Class50 class50_1)
		{
			this.class50_0 = class50_1;
		}

		public override string ToString()
		{
			return string.Format("{0} ({1} char{2})", this.String_0.Replace(' ', '-').Replace("\n", "\\n"), this.String_0.Length, (this.String_0.Length != 1) ? "s" : string.Empty);
		}

		public bool method_0()
		{
			HtmlContainerInt htmlContainerInt_ = this.Class50_0.HtmlContainerInt_0;
			if (this.Double_5 >= htmlContainerInt_.PageSize.Height)
			{
				return false;
			}
			double num = (this.Double_1 - (double)htmlContainerInt_.MarginTop) % htmlContainerInt_.PageSize.Height;
			if (num > (this.Double_7 - (double)htmlContainerInt_.MarginTop) % htmlContainerInt_.PageSize.Height)
			{
				this.Double_1 += htmlContainerInt_.PageSize.Height - num + 1.0;
				return true;
			}
			return false;
		}
	}
}

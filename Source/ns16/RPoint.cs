using System;

namespace ns16
{
	public struct RPoint
	{
		public static readonly RPoint Empty;

		private double double_0;

		private double double_1;

		public bool IsEmpty
		{
			get
			{
				if (Math.Abs(this.double_0 - 0.0) < 0.001)
				{
					return Math.Abs(this.double_1 - 0.0) < 0.001;
				}
				return false;
			}
		}

		public double Double_0
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
			}
		}

		public double Double_1
		{
			get
			{
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
			}
		}

		static RPoint()
		{
			RPoint.Empty = default(RPoint);
		}

		public RPoint(double x, double y)
		{
			this.double_0 = x;
			this.double_1 = y;
		}

		public static RPoint operator +(RPoint pt, RSize sz)
		{
			return RPoint.Add(pt, sz);
		}

		public static RPoint operator -(RPoint pt, RSize sz)
		{
			return RPoint.Subtract(pt, sz);
		}

		public static bool operator ==(RPoint left, RPoint right)
		{
			if (left.Double_0 == right.Double_0)
			{
				return left.Double_1 == right.Double_1;
			}
			return false;
		}

		public static bool operator !=(RPoint left, RPoint right)
		{
			return !(left == right);
		}

		public static RPoint Add(RPoint pt, RSize sz)
		{
			return new RPoint(pt.Double_0 + sz.Width, pt.Double_1 + sz.Height);
		}

		public static RPoint Subtract(RPoint pt, RSize sz)
		{
			return new RPoint(pt.Double_0 - sz.Width, pt.Double_1 - sz.Height);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RPoint rPoint))
			{
				return false;
			}
			if (rPoint.Double_0 == this.Double_0 && rPoint.Double_1 == this.Double_1)
			{
				return rPoint.GetType().Equals(base.GetType());
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{{X={0}, Y={1}}}", new object[2] { this.double_0, this.double_1 });
		}
	}
}

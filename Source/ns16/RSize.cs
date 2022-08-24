using System;

namespace ns16
{
	public struct RSize
	{
		public static readonly RSize Empty = default(RSize);

		private double double_0;

		private double double_1;

		public bool IsEmpty
		{
			get
			{
				if (Math.Abs(this.double_1) < 0.0001)
				{
					return Math.Abs(this.double_0) < 0.0001;
				}
				return false;
			}
		}

		public double Width
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

		public double Height
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

		public RSize(RSize size)
		{
			this.double_1 = size.double_1;
			this.double_0 = size.double_0;
		}

		public RSize(RPoint pt)
		{
			this.double_1 = pt.Double_0;
			this.double_0 = pt.Double_1;
		}

		public RSize(double width, double height)
		{
			this.double_1 = width;
			this.double_0 = height;
		}

		public static explicit operator RPoint(RSize size)
		{
			return new RPoint(size.Width, size.Height);
		}

		public static RSize operator +(RSize sz1, RSize sz2)
		{
			return RSize.Add(sz1, sz2);
		}

		public static RSize operator -(RSize sz1, RSize sz2)
		{
			return RSize.Subtract(sz1, sz2);
		}

		public static bool operator ==(RSize sz1, RSize sz2)
		{
			if (Math.Abs(sz1.Width - sz2.Width) < 0.001)
			{
				return Math.Abs(sz1.Height - sz2.Height) < 0.001;
			}
			return false;
		}

		public static bool operator !=(RSize sz1, RSize sz2)
		{
			return !(sz1 == sz2);
		}

		public static RSize Add(RSize sz1, RSize sz2)
		{
			return new RSize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
		}

		public static RSize Subtract(RSize sz1, RSize sz2)
		{
			return new RSize(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RSize rSize))
			{
				return false;
			}
			if (Math.Abs(rSize.Width - this.Width) < 0.001 && Math.Abs(rSize.Height - this.Height) < 0.001)
			{
				return rSize.GetType() == base.GetType();
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public RPoint ToPointF()
		{
			return (RPoint)this;
		}

		public override string ToString()
		{
			return "{Width=" + this.double_1 + ", Height=" + this.double_0 + "}";
		}
	}
}

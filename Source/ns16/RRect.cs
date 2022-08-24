using System;

namespace ns16
{
	public struct RRect
	{
		public static readonly RRect Empty = default(RRect);

		private double double_0;

		private double double_1;

		private double double_2;

		private double double_3;

		public RPoint Location
		{
			get
			{
				return new RPoint(this.Double_0, this.Double_1);
			}
			set
			{
				this.Double_0 = value.Double_0;
				this.Double_1 = value.Double_1;
			}
		}

		public RSize Size
		{
			get
			{
				return new RSize(this.Width, this.Height);
			}
			set
			{
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}

		public double Double_0
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
			}
		}

		public double Double_1
		{
			get
			{
				return this.double_3;
			}
			set
			{
				this.double_3 = value;
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

		public double Left => this.Double_0;

		public double Top => this.Double_1;

		public double Right => this.Double_0 + this.Width;

		public double Bottom => this.Double_1 + this.Height;

		public bool IsEmpty
		{
			get
			{
				if (this.Width > 0.0)
				{
					return this.Height <= 0.0;
				}
				return true;
			}
		}

		public RRect(double x, double y, double width, double height)
		{
			this.double_2 = x;
			this.double_3 = y;
			this.double_1 = width;
			this.double_0 = height;
		}

		public RRect(RPoint location, RSize size)
		{
			this.double_2 = location.Double_0;
			this.double_3 = location.Double_1;
			this.double_1 = size.Width;
			this.double_0 = size.Height;
		}

		public static bool operator ==(RRect left, RRect right)
		{
			if (Math.Abs(left.Double_0 - right.Double_0) < 0.001 && Math.Abs(left.Double_1 - right.Double_1) < 0.001 && Math.Abs(left.Width - right.Width) < 0.001)
			{
				return Math.Abs(left.Height - right.Height) < 0.001;
			}
			return false;
		}

		public static bool operator !=(RRect left, RRect right)
		{
			return !(left == right);
		}

		public static RRect FromLTRB(double left, double top, double right, double bottom)
		{
			return new RRect(left, top, right - left, bottom - top);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RRect rRect))
			{
				return false;
			}
			if (Math.Abs(rRect.Double_0 - this.Double_0) < 0.001 && Math.Abs(rRect.Double_1 - this.Double_1) < 0.001 && Math.Abs(rRect.Width - this.Width) < 0.001)
			{
				return Math.Abs(rRect.Height - this.Height) < 0.001;
			}
			return false;
		}

		public bool Contains(double x, double y)
		{
			if (this.Double_0 <= x && x < this.Double_0 + this.Width && this.Double_1 <= y)
			{
				return y < this.Double_1 + this.Height;
			}
			return false;
		}

		public bool Contains(RPoint pt)
		{
			return this.Contains(pt.Double_0, pt.Double_1);
		}

		public bool Contains(RRect rect)
		{
			if (this.Double_0 <= rect.Double_0 && rect.Double_0 + rect.Width <= this.Double_0 + this.Width && this.Double_1 <= rect.Double_1)
			{
				return rect.Double_1 + rect.Height <= this.Double_1 + this.Height;
			}
			return false;
		}

		public void Inflate(double x, double y)
		{
			this.Double_0 -= x;
			this.Double_1 -= y;
			this.Width += 2.0 * x;
			this.Height += 2.0 * y;
		}

		public void Inflate(RSize size)
		{
			this.Inflate(size.Width, size.Height);
		}

		public static RRect Inflate(RRect rect, double x, double y)
		{
			RRect result = rect;
			result.Inflate(x, y);
			return result;
		}

		public void Intersect(RRect rect)
		{
			RRect rRect = RRect.Intersect(rect, this);
			this.Double_0 = rRect.Double_0;
			this.Double_1 = rRect.Double_1;
			this.Width = rRect.Width;
			this.Height = rRect.Height;
		}

		public static RRect Intersect(RRect a, RRect b)
		{
			double num = Math.Max(a.Double_0, b.Double_0);
			double num2 = Math.Min(a.Double_0 + a.Width, b.Double_0 + b.Width);
			double num3 = Math.Max(a.Double_1, b.Double_1);
			double num4 = Math.Min(a.Double_1 + a.Height, b.Double_1 + b.Height);
			if (num2 >= num && num4 >= num3)
			{
				return new RRect(num, num3, num2 - num, num4 - num3);
			}
			return RRect.Empty;
		}

		public bool IntersectsWith(RRect rect)
		{
			if (rect.Double_0 < this.Double_0 + this.Width && this.Double_0 < rect.Double_0 + rect.Width && rect.Double_1 < this.Double_1 + this.Height)
			{
				return this.Double_1 < rect.Double_1 + rect.Height;
			}
			return false;
		}

		public static RRect Union(RRect a, RRect b)
		{
			double num = Math.Min(a.Double_0, b.Double_0);
			double num2 = Math.Max(a.Double_0 + a.Width, b.Double_0 + b.Width);
			double num3 = Math.Min(a.Double_1, b.Double_1);
			return new RRect(num, num3, num2 - num, Math.Max(a.Double_1 + a.Height, b.Double_1 + b.Height) - num3);
		}

		public void Offset(RPoint pos)
		{
			this.Offset(pos.Double_0, pos.Double_1);
		}

		public void Offset(double x, double y)
		{
			this.Double_0 += x;
			this.Double_1 += y;
		}

		public override int GetHashCode()
		{
			return (int)((uint)this.Double_0 ^ (((uint)this.Double_1 << 13) | ((uint)this.Double_1 >> 19)) ^ (((uint)this.Width << 26) | ((uint)this.Width >> 6)) ^ (((uint)this.Height << 7) | ((uint)this.Height >> 25)));
		}

		public override string ToString()
		{
			return "{X=" + this.Double_0 + ",Y=" + this.Double_1 + ",Width=" + this.Width + ",Height=" + this.Height + "}";
		}
	}
}

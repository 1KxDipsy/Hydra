using System;

namespace ns14
{
	public abstract class RGraphicsPath : IDisposable
	{
		public enum Corner
		{
			TopLeft = 0,
			TopRight = 1,
			BottomLeft = 2,
			BottomRight = 3
		}

		public abstract void Start(double x, double y);

		public abstract void LineTo(double x, double y);

		public abstract void ArcTo(double x, double y, double size, Corner corner);

		public abstract void Dispose();
	}
}

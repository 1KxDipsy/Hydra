using System;
using System.Drawing.Drawing2D;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class69 : RGraphicsPath
	{
		private readonly GraphicsPath graphicsPath_0 = new GraphicsPath();

		private RPoint rpoint_0;

		public GraphicsPath GraphicsPath_0 => this.graphicsPath_0;

		public override void Start(double x, double y)
		{
			this.rpoint_0 = new RPoint(x, y);
		}

		public override void LineTo(double x, double y)
		{
			this.graphicsPath_0.AddLine((float)this.rpoint_0.Double_0, (float)this.rpoint_0.Double_1, (float)x, (float)y);
			this.rpoint_0 = new RPoint(x, y);
		}

		public override void ArcTo(double x, double y, double size, Corner corner)
		{
			float x2 = (float)(Math.Min(x, this.rpoint_0.Double_0) - ((corner == Corner.TopRight || corner == Corner.BottomRight) ? size : 0.0));
			double num = Math.Min(y, this.rpoint_0.Double_1);
			this.graphicsPath_0.AddArc(x2, (float)(num - ((corner == Corner.BottomLeft || corner == Corner.BottomRight) ? size : 0.0)), (float)size * 2f, (float)size * 2f, Class69.smethod_0(corner), 90f);
			this.rpoint_0 = new RPoint(x, y);
		}

		public override void Dispose()
		{
			this.graphicsPath_0.Dispose();
		}

		private static int smethod_0(Corner corner_0)
		{
			return corner_0 switch
			{
				Corner.TopLeft => 180, 
				Corner.TopRight => 270, 
				Corner.BottomLeft => 90, 
				Corner.BottomRight => 0, 
				_ => throw new ArgumentOutOfRangeException("corner"), 
			};
		}
	}
}

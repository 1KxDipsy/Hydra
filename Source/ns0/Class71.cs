using System.Drawing;
using System.Drawing.Drawing2D;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class71 : RPen
	{
		private readonly Pen pen_0;

		public Pen Pen_0 => this.pen_0;

		public override double Width
		{
			get
			{
				return this.pen_0.Width;
			}
			set
			{
				this.pen_0.Width = (float)value;
			}
		}

		public override RDashStyle DashStyle
		{
			set
			{
				switch (value)
				{
				default:
					this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					break;
				case RDashStyle.Solid:
					this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
					break;
				case RDashStyle.Dash:
					this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
					if (this.Width < 2.0)
					{
						this.pen_0.DashPattern = new float[2] { 4f, 4f };
					}
					break;
				case RDashStyle.Dot:
					this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
					break;
				case RDashStyle.DashDot:
					this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
					break;
				case RDashStyle.DashDotDot:
					this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
					break;
				case RDashStyle.Custom:
					this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					break;
				}
			}
		}

		public Class71(Pen pen_1)
		{
			this.pen_0 = pen_1;
		}
	}
}

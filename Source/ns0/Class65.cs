using System.Drawing;
using ns14;

namespace ns0
{
	internal sealed class Class65 : RBrush
	{
		private readonly Brush brush_0;

		private readonly bool bool_0;

		public Brush Brush_0 => this.brush_0;

		public Class65(Brush brush_1, bool bool_1)
		{
			this.brush_0 = brush_1;
			this.bool_0 = bool_1;
		}

		public override void Dispose()
		{
			if (this.bool_0)
			{
				this.brush_0.Dispose();
			}
		}
	}
}

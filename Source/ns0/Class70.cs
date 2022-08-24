using System.Drawing;
using ns14;

namespace ns0
{
	internal sealed class Class70 : RImage
	{
		private readonly Image image_0;

		public Image Image_0 => this.image_0;

		public override double Width => this.image_0.Width;

		public override double Height => this.image_0.Height;

		public Class70(Image image_1)
		{
			this.image_0 = image_1;
		}

		public override void Dispose()
		{
			this.image_0.Dispose();
		}
	}
}

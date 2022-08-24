using System;
using System.Drawing;
using ns14;

namespace ns0
{
	internal sealed class Class67 : RFont
	{
		private readonly Font font_0;

		private IntPtr intptr_0;

		private float float_0 = -1f;

		private float float_1 = -1f;

		private double double_0 = -1.0;

		public Font Font_0 => this.font_0;

		public IntPtr IntPtr_0
		{
			get
			{
				if (this.intptr_0 == IntPtr.Zero)
				{
					this.intptr_0 = this.font_0.ToHfont();
				}
				return this.intptr_0;
			}
		}

		public override double Size => this.font_0.Size;

		public override double UnderlineOffset => this.float_0;

		public override double Height => this.float_1;

		public override double LeftPadding => this.float_1 / 6f;

		public Class67(Font font_1)
		{
			this.font_0 = font_1;
		}

		public override double GetWhitespaceWidth(RGraphics graphics)
		{
			if (this.double_0 < 0.0)
			{
				this.double_0 = graphics.MeasureString(" ", this).Width;
			}
			return this.double_0;
		}

		internal void method_0(int int_0, int int_1)
		{
			this.float_1 = int_0;
			this.float_0 = int_1;
		}
	}
}

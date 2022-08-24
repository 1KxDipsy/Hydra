using System;

namespace ns7
{
	public static class AnimationEaseInOut
	{
		public static double double_0 = Math.PI;

		public static double PI_HALF = Math.PI / 2.0;

		public static double CalculateProgress(double progress)
		{
			return AnimationEaseInOut.smethod_0(progress);
		}

		private static double smethod_0(double double_1)
		{
			return double_1 - Math.Sin(double_1 * 2.0 * AnimationEaseInOut.double_0) / (2.0 * AnimationEaseInOut.double_0);
		}
	}
}

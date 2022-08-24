using System;

namespace ns7
{
	public static class AnimationCustomQuadratic
	{
		public static double CalculateProgress(double progress)
		{
			double num = 0.6;
			return 1.0 - Math.Cos((Math.Max(progress, num) - num) * Math.PI / 0.8);
		}
	}
}

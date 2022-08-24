namespace ns7
{
	public static class AnimationEaseOut
	{
		public static double CalculateProgress(double progress)
		{
			return -1.0 * progress * (progress - 2.0);
		}
	}
}

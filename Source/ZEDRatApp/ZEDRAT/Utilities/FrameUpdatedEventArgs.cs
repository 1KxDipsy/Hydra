using System;

namespace ZEDRatApp.ZEDRAT.Utilities
{
	public class FrameUpdatedEventArgs : EventArgs
	{
		public float CurrentFramesPerSecond { get; private set; }

		public FrameUpdatedEventArgs(float _CurrentFramesPerSecond)
		{
			this.CurrentFramesPerSecond = _CurrentFramesPerSecond;
		}
	}
}

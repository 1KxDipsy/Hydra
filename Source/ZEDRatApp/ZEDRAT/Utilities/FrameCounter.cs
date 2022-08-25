using System.Collections.Generic;
using System.Linq;

namespace ZEDRatApp.ZEDRAT.Utilities
{
	public class FrameCounter
	{
		public const int MAXIMUM_SAMPLES = 100;

		private Queue<float> _sampleBuffer = new Queue<float>();

		public long TotalFrames { get; private set; }

		public float TotalSeconds { get; private set; }

		public float AverageFramesPerSecond { get; private set; }

		public event FrameUpdatedEventHandler FrameUpdated;

		public void Update(float deltaTime)
		{
			float num = 1f / deltaTime;
			this._sampleBuffer.Enqueue(num);
			if (this._sampleBuffer.Count > 100)
			{
				this._sampleBuffer.Dequeue();
				this.AverageFramesPerSecond = this._sampleBuffer.Average((float i) => i);
			}
			else
			{
				this.AverageFramesPerSecond = num;
			}
			this.OnFrameUpdated(new FrameUpdatedEventArgs(this.AverageFramesPerSecond));
			this.TotalFrames++;
			this.TotalSeconds += deltaTime;
		}

		protected virtual void OnFrameUpdated(FrameUpdatedEventArgs e)
		{
			this.FrameUpdated?.Invoke(e);
		}
	}
}

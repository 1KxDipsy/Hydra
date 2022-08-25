using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ZEDRatApp.ZEDRAT.Utilities;

namespace ZEDRatApp.Forms.Controls
{
	public class RapidPictureBox : PictureBox, IRapidPictureBox
	{
		private readonly object _imageLock = new object();

		private Stopwatch _sWatch;

		private FrameCounter _frameCounter;

		public bool Running { get; set; }

		public int ScreenWidth { get; private set; }

		public int ScreenHeight { get; private set; }

		public Image GetImageSafe
		{
			get
			{
				return base.Image;
			}
			set
			{
				lock (this._imageLock)
				{
					base.Image = value;
				}
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams obj = base.CreateParams;
				obj.ExStyle |= 33554432;
				return obj;
			}
		}

		public void SetFrameUpdatedEvent(FrameUpdatedEventHandler e)
		{
			this._frameCounter.FrameUpdated += e;
		}

		public void UnsetFrameUpdatedEvent(FrameUpdatedEventHandler e)
		{
			this._frameCounter.FrameUpdated -= e;
		}

		public void Start()
		{
			this._frameCounter = new FrameCounter();
			this._sWatch = Stopwatch.StartNew();
			this.Running = true;
		}

		public void Stop()
		{
			if (this._sWatch != null)
			{
				this._sWatch.Stop();
			}
			this.Running = false;
		}

		public void UpdateImage(Bitmap bmp, bool cloneBitmap)
		{
			try
			{
				this.CountFps();
				if (this.ScreenWidth != bmp.Width && this.ScreenHeight != bmp.Height)
				{
					this.UpdateScreenSize(bmp.Width, bmp.Height);
				}
				lock (this._imageLock)
				{
					Image getImageSafe = this.GetImageSafe;
					base.SuspendLayout();
					this.GetImageSafe = (cloneBitmap ? new Bitmap(bmp, base.Width, base.Height) : bmp);
					base.ResumeLayout();
					getImageSafe?.Dispose();
				}
			}
			catch (InvalidOperationException)
			{
			}
			catch (Exception)
			{
			}
		}

		public RapidPictureBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			lock (this._imageLock)
			{
				if (this.GetImageSafe != null)
				{
					pe.Graphics.DrawImage(this.GetImageSafe, new Point(0, 0));
				}
			}
		}

		private void UpdateScreenSize(int newWidth, int newHeight)
		{
			this.ScreenWidth = newWidth;
			this.ScreenHeight = newHeight;
		}

		private void CountFps()
		{
			float deltaTime = (float)this._sWatch.Elapsed.TotalSeconds;
			this._sWatch = Stopwatch.StartNew();
			this._frameCounter.Update(deltaTime);
		}
	}
}

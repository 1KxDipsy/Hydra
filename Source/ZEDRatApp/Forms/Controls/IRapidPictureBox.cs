using System.Drawing;

namespace ZEDRatApp.Forms.Controls
{
	public interface IRapidPictureBox
	{
		bool Running { get; set; }

		Image GetImageSafe { get; set; }

		void Start();

		void Stop();

		void UpdateImage(Bitmap bmp, bool cloneBitmap = false);
	}
}

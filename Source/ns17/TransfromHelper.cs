using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ns17
{
	public static class TransfromHelper
	{
		private const int int_0 = 4;

		private static Random random_0 = new Random();

		public static void DoScale(TransfromNeededEventArg e, Animation animation)
		{
			Rectangle clientRectangle = e.ClientRectangle;
			PointF pointF = new PointF(clientRectangle.Left + clientRectangle.Width / 2, clientRectangle.Top + clientRectangle.Height / 2);
			e.Matrix.Translate(pointF.X, pointF.Y);
			float num = 1f - animation.ScaleCoeff.X * e.CurrentTime;
			float num2 = 1f - animation.ScaleCoeff.X * e.CurrentTime;
			if (Math.Abs(num) <= 0.001f)
			{
				num = 0.001f;
			}
			if (Math.Abs(num2) <= 0.001f)
			{
				num2 = 0.001f;
			}
			e.Matrix.Scale(num, num2);
			e.Matrix.Translate(0f - pointF.X, 0f - pointF.Y);
		}

		public static void DoSlide(TransfromNeededEventArg e, Animation animation)
		{
			float currentTime = e.CurrentTime;
			e.Matrix.Translate((float)(-e.ClientRectangle.Width) * currentTime * animation.SlideCoeff.X, (float)(-e.ClientRectangle.Height) * currentTime * animation.SlideCoeff.Y);
		}

		public static void DoBlind(NonLinearTransfromNeededEventArg e, Animation animation)
		{
			if (animation.BlindCoeff == PointF.Empty)
			{
				return;
			}
			byte[] pixels = e.Pixels;
			int width = e.ClientRectangle.Width;
			int height = e.ClientRectangle.Height;
			int stride = e.Stride;
			float x = animation.BlindCoeff.X;
			float y = animation.BlindCoeff.Y;
			int num = (int)(((float)width * x + (float)height * y) * (1f - e.CurrentTime));
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					int num2 = j * stride + i * 4;
					if ((float)i * x + (float)j * y - (float)num >= 0f)
					{
						pixels[num2 + 3] = 0;
					}
				}
			}
		}

		public static void DoMosaic(NonLinearTransfromNeededEventArg e, Animation animation, ref Point[] buffer, ref byte[] pixelsBuffer)
		{
			if (animation.MosaicCoeff == PointF.Empty || animation.MosaicSize == 0)
			{
				return;
			}
			byte[] pixels = e.Pixels;
			int width = e.ClientRectangle.Width;
			int height = e.ClientRectangle.Height;
			int stride = e.Stride;
			float currentTime = e.CurrentTime;
			int num = pixels.Length;
			float num2 = 1f - e.CurrentTime;
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			if (num2 > 1f)
			{
				num2 = 1f;
			}
			float x = animation.MosaicCoeff.X;
			float y = animation.MosaicCoeff.Y;
			if (buffer == null)
			{
				buffer = new Point[pixels.Length];
				for (int i = 0; i < pixels.Length; i++)
				{
					buffer[i] = new Point((int)((double)x * (TransfromHelper.random_0.NextDouble() - 0.5)), (int)((double)y * (TransfromHelper.random_0.NextDouble() - 0.5)));
				}
			}
			if (pixelsBuffer == null)
			{
				pixelsBuffer = (byte[])pixels.Clone();
			}
			for (int j = 0; j < num; j += 4)
			{
				pixels[j] = byte.MaxValue;
				pixels[j + 1] = byte.MaxValue;
				pixels[j + 2] = byte.MaxValue;
				pixels[j + 3] = 0;
			}
			int mosaicSize = animation.MosaicSize;
			float x2 = animation.MosaicShift.X;
			float y2 = animation.MosaicShift.Y;
			for (int k = 0; k < height; k++)
			{
				for (int l = 0; l < width; l++)
				{
					int num3 = k / mosaicSize;
					int num4 = l / mosaicSize;
					int num5 = k * stride + l * 4;
					int num6 = num3 * stride + num4 * 4;
					int num7 = l + (int)(currentTime * ((float)buffer[num6].X + (float)num4 * x2));
					int num8 = k + (int)(currentTime * ((float)buffer[num6].Y + (float)num3 * y2));
					if (num7 >= 0 && num7 < width && num8 >= 0 && num8 < height)
					{
						int num9 = num8 * stride + num7 * 4;
						pixels[num9] = pixelsBuffer[num5];
						pixels[num9 + 1] = pixelsBuffer[num5 + 1];
						pixels[num9 + 2] = pixelsBuffer[num5 + 2];
						pixels[num9 + 3] = (byte)((float)(int)pixelsBuffer[num5 + 3] * num2);
					}
				}
			}
		}

		public static void DoLeaf(NonLinearTransfromNeededEventArg e, Animation animation)
		{
			if (animation.LeafCoeff == 0f)
			{
				return;
			}
			byte[] pixels = e.Pixels;
			int width = e.ClientRectangle.Width;
			int height = e.ClientRectangle.Height;
			int stride = e.Stride;
			int num = (int)((float)(width + height) * (1f - e.CurrentTime * e.CurrentTime));
			int num2 = pixels.Length;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					int num3 = j * stride + i * 4;
					if (i + j >= num)
					{
						int num4 = num - j;
						int num5 = num - i;
						int num6 = num - i - j;
						if (num6 < -20)
						{
							num6 = -20;
						}
						int num7 = num5 * stride + num4 * 4;
						if (num4 >= 0 && num5 >= 0 && num7 >= 0 && num7 < num2 && pixels[num3 + 3] > 0)
						{
							pixels[num7] = (byte)Math.Min(255, num6 + 250 + (int)pixels[num3] / 10);
							pixels[num7 + 1] = (byte)Math.Min(255, num6 + 250 + (int)pixels[num3 + 1] / 10);
							pixels[num7 + 2] = (byte)Math.Min(255, num6 + 250 + (int)pixels[num3 + 2] / 10);
							pixels[num7 + 3] = 230;
						}
						pixels[num3 + 3] = 0;
					}
				}
			}
		}

		public static void DoTransparent(NonLinearTransfromNeededEventArg e, Animation animation)
		{
			if (animation.TransparencyCoeff != 0f)
			{
				float num = 1f - animation.TransparencyCoeff * e.CurrentTime;
				if (num < 0f)
				{
					num = 0f;
				}
				if (num > 1f)
				{
					num = 1f;
				}
				byte[] pixels = e.Pixels;
				for (int i = 0; i < pixels.Length; i += 4)
				{
					pixels[i + 3] = (byte)((float)(int)pixels[i + 3] * num);
				}
			}
		}

		public static void CalcDifference(Bitmap bmp1, Bitmap bmp2)
		{
			Rectangle rect = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
			BitmapData bitmapData = bmp1.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			IntPtr scan = bitmapData.Scan0;
			BitmapData bitmapData2 = bmp2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			IntPtr scan2 = bitmapData2.Scan0;
			int num = bmp1.Width * bmp1.Height * 4;
			byte[] array = new byte[num];
			byte[] array2 = new byte[num];
			Marshal.Copy(scan, array, 0, num);
			Marshal.Copy(scan2, array2, 0, num);
			for (int i = 0; i < num; i += 4)
			{
				if (array[i] == array2[i] && array[i + 1] == array2[i + 1] && array[i + 2] == array2[i + 2])
				{
					array[i] = byte.MaxValue;
					array[i + 1] = byte.MaxValue;
					array[i + 2] = byte.MaxValue;
					array[i + 3] = 0;
				}
			}
			Marshal.Copy(array, 0, scan, num);
			bmp1.UnlockBits(bitmapData);
			bmp2.UnlockBits(bitmapData2);
		}

		public static void DoRotate(TransfromNeededEventArg e, Animation animation)
		{
			Rectangle clientRectangle = e.ClientRectangle;
			PointF pointF = new PointF(clientRectangle.Left + clientRectangle.Width / 2, clientRectangle.Top + clientRectangle.Height / 2);
			e.Matrix.Translate(pointF.X, pointF.Y);
			if (e.CurrentTime > animation.RotateLimit)
			{
				e.Matrix.Rotate(360f * (e.CurrentTime - animation.RotateLimit) * animation.RotateCoeff);
			}
			e.Matrix.Translate(0f - pointF.X, 0f - pointF.Y);
		}

		public static void DoBottomMirror(NonLinearTransfromNeededEventArg e)
		{
			byte[] sourcePixels = e.SourcePixels;
			byte[] pixels = e.Pixels;
			int stride = e.Stride;
			int num = 1;
			int num2 = e.SourceClientRectangle.Bottom + 1;
			int height = e.ClientRectangle.Height;
			int left = e.SourceClientRectangle.Left;
			int right = e.SourceClientRectangle.Right;
			int num3 = height - num2;
			for (int i = left; i < right; i++)
			{
				for (int j = num2; j < height; j++)
				{
					int num4 = num2 - 1 - num - (j - num2);
					if (num4 < 0)
					{
						break;
					}
					int num5 = num4 * stride + i * 4;
					int num6 = j * stride + i * 4;
					pixels[num6] = sourcePixels[num5];
					pixels[num6 + 1] = sourcePixels[num5 + 1];
					pixels[num6 + 2] = sourcePixels[num5 + 2];
					pixels[num6 + 3] = (byte)((1f - 1f * (float)(j - num2) / (float)num3) * 90f);
				}
			}
		}

		public static void DoBlur(NonLinearTransfromNeededEventArg e, int r)
		{
			byte[] pixels = e.Pixels;
			byte[] sourcePixels = e.SourcePixels;
			int stride = e.Stride;
			int height = e.ClientRectangle.Height;
			int width = e.ClientRectangle.Width;
			int num = sourcePixels.Length - 4;
			for (int i = r; i < width - r; i++)
			{
				for (int j = r; j < height - r; j++)
				{
					int num2 = j * stride + i * 4;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					int num7 = 0;
					for (int k = i - r; k < i + r; k++)
					{
						for (int l = j - r; l < j + r; l++)
						{
							int num8 = l * stride + k * 4;
							if (num8 >= 0 && num8 < num && sourcePixels[num8 + 3] > 0)
							{
								num5 += sourcePixels[num8];
								num4 += sourcePixels[num8 + 1];
								num3 += sourcePixels[num8 + 2];
								num6 += sourcePixels[num8 + 3];
								num7++;
							}
						}
					}
					if (num2 < num && num7 > 5)
					{
						pixels[num2] = (byte)(num5 / num7);
						pixels[num2 + 1] = (byte)(num4 / num7);
						pixels[num2 + 2] = (byte)(num3 / num7);
						pixels[num2 + 3] = (byte)(num6 / num7);
					}
				}
			}
		}
	}
}

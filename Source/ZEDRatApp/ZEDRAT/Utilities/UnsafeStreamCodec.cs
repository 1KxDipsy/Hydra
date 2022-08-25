using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZEDRatApp.ZEDRAT.Compression;

namespace ZEDRatApp.ZEDRAT.Utilities
{
	public class UnsafeStreamCodec : IDisposable
	{
		private int _imageQuality;

		private byte[] _encodeBuffer;

		private Bitmap _decodedBitmap;

		private PixelFormat _encodedFormat;

		private int _encodedWidth;

		private int _encodedHeight;

		private readonly object _imageProcessLock = new object();

		private JpgCompression _jpgCompression;

		public int Monitor { get; private set; }

		public string Resolution { get; private set; }

		public Size CheckBlock { get; private set; }

		public int ImageQuality
		{
			get
			{
				return this._imageQuality;
			}
			private set
			{
				lock (this._imageProcessLock)
				{
					this._imageQuality = value;
					if (this._jpgCompression != null)
					{
						this._jpgCompression.Dispose();
					}
					this._jpgCompression = new JpgCompression(this._imageQuality);
				}
			}
		}

		public UnsafeStreamCodec(int imageQuality, int monitor, string resolution)
		{
			this.ImageQuality = imageQuality;
			this.Monitor = monitor;
			this.Resolution = resolution;
			this.CheckBlock = new Size(50, 1);
		}

		public void Dispose()
		{
			this.Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this._decodedBitmap != null)
				{
					this._decodedBitmap.Dispose();
				}
				if (this._jpgCompression != null)
				{
					this._jpgCompression.Dispose();
				}
			}
		}

		public unsafe void CodeImage(IntPtr scan0, Rectangle scanArea, Size imageSize, PixelFormat format, Stream outStream)
		{
			lock (this._imageProcessLock)
			{
				byte* ptr = (byte*)scan0.ToInt32();
				if (!outStream.CanWrite)
				{
					throw new Exception("Must have access to Write in the Stream");
				}
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				switch (format)
				{
				case PixelFormat.Format24bppRgb:
				case PixelFormat.Format32bppRgb:
					num3 = 3;
					break;
				case PixelFormat.Format32bppPArgb:
				case PixelFormat.Format32bppArgb:
					num3 = 4;
					break;
				default:
					throw new NotSupportedException(format.ToString());
				}
				num = imageSize.Width * num3;
				num2 = num * imageSize.Height;
				if (this._encodeBuffer == null)
				{
					this._encodedFormat = format;
					this._encodedWidth = imageSize.Width;
					this._encodedHeight = imageSize.Height;
					this._encodeBuffer = new byte[num2];
					fixed (byte* value = this._encodeBuffer)
					{
						byte[] array = null;
						using (Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height, num, format, scan0))
						{
							array = this._jpgCompression.Compress(bmp);
						}
						outStream.Write(BitConverter.GetBytes(array.Length), 0, 4);
						outStream.Write(array, 0, array.Length);
						NativeMethods.memcpy(new IntPtr(value), scan0, (uint)num2);
					}
					return;
				}
				if (this._encodedFormat != format)
				{
					throw new Exception("PixelFormat is not equal to previous Bitmap");
				}
				if (this._encodedWidth != imageSize.Width || this._encodedHeight != imageSize.Height)
				{
					throw new Exception("Bitmap width/height are not equal to previous bitmap");
				}
				long position = outStream.Position;
				outStream.Write(new byte[4], 0, 4);
				long num4 = 0L;
				List<Rectangle> list = new List<Rectangle>();
				Size size = new Size(scanArea.Width, this.CheckBlock.Height);
				Size size2 = new Size(scanArea.Width % this.CheckBlock.Width, scanArea.Height % this.CheckBlock.Height);
				int num5 = scanArea.Height - size2.Height;
				int num6 = scanArea.Width - size2.Width;
				Rectangle item = default(Rectangle);
				List<Rectangle> list2 = new List<Rectangle>();
				size = new Size(scanArea.Width, size.Height);
				fixed (byte* ptr2 = this._encodeBuffer)
				{
					int num7 = 0;
					for (int i = scanArea.Y; i != scanArea.Height; i += size.Height)
					{
						if (i == num5)
						{
							size = new Size(scanArea.Width, size2.Height);
						}
						item = new Rectangle(scanArea.X, i, scanArea.Width, size.Height);
						int num8 = i * num + scanArea.X * num3;
						if (NativeMethods.memcmp(ptr2 + num8, ptr + num8, (uint)num) != 0)
						{
							num7 = list.Count - 1;
							if (list.Count != 0 && list[num7].Y + list[num7].Height == item.Y)
							{
								item = (list[num7] = new Rectangle(list[num7].X, list[num7].Y, list[num7].Width, list[num7].Height + item.Height));
							}
							else
							{
								list.Add(item);
							}
						}
					}
					for (int j = 0; j < list.Count; j++)
					{
						size = new Size(this.CheckBlock.Width, list[j].Height);
						for (int k = scanArea.X; k != scanArea.Width; k += size.Width)
						{
							if (k == num6)
							{
								size = new Size(size2.Width, list[j].Height);
							}
							item = new Rectangle(k, list[j].Y, size.Width, list[j].Height);
							bool flag = false;
							uint count = (uint)(num3 * item.Width);
							for (int l = 0; l < item.Height; l++)
							{
								int num9 = num * (item.Y + l) + num3 * item.X;
								if (NativeMethods.memcmp(ptr2 + num9, ptr + num9, count) != 0)
								{
									flag = true;
								}
								NativeMethods.memcpy(ptr2 + num9, ptr + num9, count);
							}
							if (flag)
							{
								num7 = list2.Count - 1;
								if (list2.Count > 0 && list2[num7].X + list2[num7].Width == item.X)
								{
									Rectangle rectangle2 = list2[num7];
									item = (list2[num7] = new Rectangle(width: item.Width + rectangle2.Width, x: rectangle2.X, y: rectangle2.Y, height: rectangle2.Height));
								}
								else
								{
									list2.Add(item);
								}
							}
						}
					}
				}
				for (int m = 0; m < list2.Count; m++)
				{
					Rectangle rectangle4 = list2[m];
					int num10 = num3 * rectangle4.Width;
					Bitmap bitmap = null;
					BitmapData bitmapData = null;
					long num12;
					try
					{
						bitmap = new Bitmap(rectangle4.Width, rectangle4.Height, format);
						bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
						int n = 0;
						int num11 = 0;
						for (; n < rectangle4.Height; n++)
						{
							NativeMethods.memcpy(src: ptr + (num * (rectangle4.Y + n) + num3 * rectangle4.X), dst: (byte*)bitmapData.Scan0.ToPointer() + num11, count: (uint)num10);
							num11 += num10;
						}
						outStream.Write(BitConverter.GetBytes(rectangle4.X), 0, 4);
						outStream.Write(BitConverter.GetBytes(rectangle4.Y), 0, 4);
						outStream.Write(BitConverter.GetBytes(rectangle4.Width), 0, 4);
						outStream.Write(BitConverter.GetBytes(rectangle4.Height), 0, 4);
						outStream.Write(new byte[4], 0, 4);
						num12 = outStream.Length;
						long position2 = outStream.Position;
						this._jpgCompression.Compress(bitmap, ref outStream);
						num12 = outStream.Position - num12;
						outStream.Position = position2 - 4;
						outStream.Write(BitConverter.GetBytes(num12), 0, 4);
						outStream.Position += num12;
					}
					finally
					{
						bitmap.UnlockBits(bitmapData);
						bitmap.Dispose();
					}
					num4 += num12 + 20;
				}
				outStream.Position = position;
				outStream.Write(BitConverter.GetBytes(num4), 0, 4);
			}
		}

		public unsafe Bitmap DecodeData(IntPtr codecBuffer, uint length)
		{
			if (length < 4)
			{
				return this._decodedBitmap;
			}
			int num = *(int*)(void*)codecBuffer;
			if (this._decodedBitmap == null)
			{
				byte[] array = new byte[num];
				fixed (byte* value = array)
				{
					NativeMethods.memcpy(new IntPtr(value), new IntPtr(codecBuffer.ToInt32() + 4), (uint)num);
				}
				this._decodedBitmap = (Bitmap)Image.FromStream(new MemoryStream(array));
				return this._decodedBitmap;
			}
			return this._decodedBitmap;
		}

		public Bitmap DecodeData(Stream inStream)
		{
			byte[] array = new byte[4];
			inStream.Read(array, 0, 4);
			int num = BitConverter.ToInt32(array, 0);
			if (this._decodedBitmap == null)
			{
				array = new byte[num];
				inStream.Read(array, 0, array.Length);
				this._decodedBitmap = (Bitmap)Image.FromStream(new MemoryStream(array));
				return this._decodedBitmap;
			}
			using (Graphics graphics = Graphics.FromImage(this._decodedBitmap))
			{
				while (num > 0)
				{
					byte[] array2 = new byte[20];
					inStream.Read(array2, 0, array2.Length);
					Rectangle rectangle = new Rectangle(BitConverter.ToInt32(array2, 0), BitConverter.ToInt32(array2, 4), BitConverter.ToInt32(array2, 8), BitConverter.ToInt32(array2, 12));
					int num2 = BitConverter.ToInt32(array2, 16);
					byte[] array3 = new byte[num2];
					inStream.Read(array3, 0, array3.Length);
					using (MemoryStream stream = new MemoryStream(array3))
					{
						using Bitmap image = (Bitmap)Image.FromStream(stream);
						graphics.DrawImage(image, rectangle.Location);
					}
					num -= num2 + 20;
				}
			}
			return this._decodedBitmap;
		}
	}
}

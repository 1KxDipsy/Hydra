using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ns10;
using ns11;
using ns12;
using ns13;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class43 : IDisposable
	{
		[CompilerGenerated]
		private sealed class Class44
		{
			public FileInfo fileInfo_0;

			public Class43 class43_0;

			internal void method_0(object object_0)
			{
				this.class43_0.method_6(this.fileInfo_0.FullName);
			}
		}

		private readonly HtmlContainerInt htmlContainerInt_0;

		private readonly Delegate6<RImage, RRect, bool> delegate6_0;

		private FileStream fileStream_0;

		private RImage rimage_0;

		private RRect rrect_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		public RImage RImage_0 => this.rimage_0;

		public RRect RRect_0 => this.rrect_0;

		public Class43(HtmlContainerInt htmlContainerInt_1, Delegate6<RImage, RRect, bool> delegate6_1)
		{
			ArgChecker.AssertArgNotNull(htmlContainerInt_1, "htmlContainer");
			ArgChecker.AssertArgNotNull(delegate6_1, "loadCompleteCallback");
			this.htmlContainerInt_0 = htmlContainerInt_1;
			this.delegate6_0 = delegate6_1;
		}

		public void method_0(string string_0, Dictionary<string, string> dictionary_0)
		{
			try
			{
				HtmlImageLoadEventArgs htmlImageLoadEventArgs = new HtmlImageLoadEventArgs(string_0, dictionary_0, new HtmlImageLoadCallback(method_1));
				this.htmlContainerInt_0.method_1(htmlImageLoadEventArgs);
				this.bool_0 = !this.htmlContainerInt_0.AvoidAsyncImagesLoading;
				if (htmlImageLoadEventArgs.Handled)
				{
					return;
				}
				if (!string.IsNullOrEmpty(string_0))
				{
					if (string_0.StartsWith("data:image", StringComparison.CurrentCultureIgnoreCase))
					{
						this.method_2(string_0);
					}
					else
					{
						this.method_4(string_0);
					}
				}
				else
				{
					this.method_9(bool_3: false);
				}
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.Image, "Exception in handling image source", exception_);
				this.method_9(bool_3: false);
			}
		}

		public void Dispose()
		{
			this.bool_2 = true;
			this.method_10();
		}

		private void method_1(string string_0, object object_0, RRect rrect_1)
		{
			if (!this.bool_2)
			{
				this.rrect_0 = rrect_1;
				if (object_0 != null)
				{
					this.rimage_0 = this.htmlContainerInt_0.RAdapter_0.ConvertImage(object_0);
					this.method_9(this.bool_0);
				}
				else if (!string.IsNullOrEmpty(string_0))
				{
					this.method_4(string_0);
				}
				else
				{
					this.method_9(this.bool_0);
				}
			}
		}

		private void method_2(string string_0)
		{
			this.rimage_0 = this.method_3(string_0);
			if (this.rimage_0 == null)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.Image, "Failed extract image from inline data");
			}
			this.bool_1 = true;
			this.method_9(bool_3: false);
		}

		private RImage method_3(string string_0)
		{
			string[] array = string_0.Substring(string_0.IndexOf(':') + 1).Split(new char[1] { ',' }, 2);
			if (array.Length == 2)
			{
				int num = 0;
				int num2 = 0;
				string[] array2 = array[0].Split(';');
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i].Trim();
					if (text.StartsWith("image/", StringComparison.InvariantCultureIgnoreCase))
					{
						num++;
					}
					if (text.Equals("base64", StringComparison.InvariantCultureIgnoreCase))
					{
						num2++;
					}
				}
				if (num > 0)
				{
					byte[] buffer = ((num2 > 0) ? Convert.FromBase64String(array[1].Trim()) : new UTF8Encoding().GetBytes(Uri.UnescapeDataString(array[1].Trim())));
					return this.htmlContainerInt_0.RAdapter_0.ImageFromStream(new MemoryStream(buffer));
				}
			}
			return null;
		}

		private void method_4(string string_0)
		{
			Uri uri = Class22.smethod_4(string_0);
			if (uri != null && uri.Scheme != "file")
			{
				this.method_7(uri);
				return;
			}
			FileInfo fileInfo = Class22.smethod_6((uri != null) ? uri.AbsolutePath : string_0);
			if (fileInfo != null)
			{
				this.method_5(fileInfo);
				return;
			}
			this.htmlContainerInt_0.method_2(HtmlRenderErrorType.Image, "Failed load image, invalid source: " + string_0);
			this.method_9(bool_3: false);
		}

		private void method_5(FileInfo fileInfo_0)
		{
			if (fileInfo_0.Exists)
			{
				if (this.htmlContainerInt_0.AvoidAsyncImagesLoading)
				{
					this.method_6(fileInfo_0.FullName);
					return;
				}
				ThreadPool.QueueUserWorkItem(delegate
				{
					this.method_6(fileInfo_0.FullName);
				});
			}
			else
			{
				this.method_9();
			}
		}

		private void method_6(string string_0)
		{
			try
			{
				FileStream fileStream = File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				lock (this.delegate6_0)
				{
					this.fileStream_0 = fileStream;
					if (!this.bool_2)
					{
						this.rimage_0 = this.htmlContainerInt_0.RAdapter_0.ImageFromStream(this.fileStream_0);
					}
					this.bool_1 = true;
				}
				this.method_9();
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.Image, "Failed to load image from disk: " + string_0, exception_);
				this.method_9();
			}
		}

		private void method_7(Uri uri_0)
		{
			FileInfo fileInfo = Class22.smethod_8(uri_0);
			if (fileInfo.Exists && fileInfo.Length > 0L)
			{
				this.method_5(fileInfo);
			}
			else
			{
				this.htmlContainerInt_0.method_5().method_0(uri_0, fileInfo.FullName, !this.htmlContainerInt_0.AvoidAsyncImagesLoading, new DownloadFileAsyncCallback(method_8));
			}
		}

		private void method_8(Uri uri_0, string string_0, Exception exception_0, bool bool_3)
		{
			if (!bool_3 && !this.bool_2)
			{
				if (exception_0 == null)
				{
					this.method_6(string_0);
					return;
				}
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.Image, "Failed to load image from URL: " + uri_0, exception_0);
				this.method_9();
			}
		}

		private void method_9(bool bool_3 = true)
		{
			if (this.bool_2)
			{
				this.method_10();
			}
			else
			{
				this.delegate6_0(this.rimage_0, this.rrect_0, bool_3);
			}
		}

		private void method_10()
		{
			lock (this.delegate6_0)
			{
				if (this.bool_1 && this.rimage_0 != null)
				{
					this.rimage_0.Dispose();
					this.rimage_0 = null;
				}
				if (this.fileStream_0 != null)
				{
					this.fileStream_0.Dispose();
					this.fileStream_0 = null;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using ns11;
using ns12;

namespace ns0
{
	internal sealed class Class41 : IDisposable
	{
		private sealed class Class42
		{
			public readonly Uri uri_0;

			public readonly string string_0;

			public readonly string string_1;

			public Class42(Uri uri_1, string string_2, string string_3)
			{
				this.uri_0 = uri_1;
				this.string_0 = string_2;
				this.string_1 = string_3;
			}
		}

		private readonly List<WebClient> list_0 = new List<WebClient>();

		private readonly Dictionary<string, List<DownloadFileAsyncCallback>> dictionary_0 = new Dictionary<string, List<DownloadFileAsyncCallback>>();

		public void method_0(Uri uri_0, string string_0, bool bool_0, DownloadFileAsyncCallback downloadFileAsyncCallback_0)
		{
			ArgChecker.AssertArgNotNull(uri_0, "imageUri");
			ArgChecker.AssertArgNotNull(downloadFileAsyncCallback_0, "cachedFileCallback");
			bool flag = true;
			lock (this.dictionary_0)
			{
				if (this.dictionary_0.ContainsKey(string_0))
				{
					flag = false;
					this.dictionary_0[string_0].Add(downloadFileAsyncCallback_0);
				}
				else
				{
					this.dictionary_0[string_0] = new List<DownloadFileAsyncCallback> { downloadFileAsyncCallback_0 };
				}
			}
			if (flag)
			{
				string tempFileName = Path.GetTempFileName();
				if (bool_0)
				{
					ThreadPool.QueueUserWorkItem(new WaitCallback(method_2), new Class42(uri_0, tempFileName, string_0));
				}
				else
				{
					this.method_1(uri_0, tempFileName, string_0);
				}
			}
		}

		public void Dispose()
		{
			this.method_5();
		}

		private void method_1(Uri uri_0, string string_0, string string_1)
		{
			try
			{
				using WebClient webClient = new WebClient();
				this.list_0.Add(webClient);
				webClient.DownloadFile(uri_0, string_0);
				this.method_4(webClient, uri_0, string_0, string_1, null, bool_0: false);
			}
			catch (Exception exception_)
			{
				this.method_4(null, uri_0, string_0, string_1, exception_, bool_0: false);
			}
		}

		private void method_2(object object_0)
		{
			Class42 @class = (Class42)object_0;
			try
			{
				WebClient webClient = new WebClient();
				this.list_0.Add(webClient);
				webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(method_3);
				webClient.DownloadFileAsync(@class.uri_0, @class.string_0, @class);
			}
			catch (Exception exception_)
			{
				this.method_4(null, @class.uri_0, @class.string_0, @class.string_1, exception_, bool_0: false);
			}
		}

		private void method_3(object sender, AsyncCompletedEventArgs e)
		{
			Class42 @class = (Class42)e.UserState;
			try
			{
				using WebClient webClient = (WebClient)sender;
				webClient.DownloadFileCompleted -= new AsyncCompletedEventHandler(method_3);
				this.method_4(webClient, @class.uri_0, @class.string_0, @class.string_1, e.Error, e.Cancelled);
			}
			catch (Exception exception_)
			{
				this.method_4(null, @class.uri_0, @class.string_0, @class.string_1, exception_, bool_0: false);
			}
		}

		private void method_4(WebClient webClient_0, Uri uri_0, string string_0, string string_1, Exception exception_0, bool bool_0)
		{
			if (!bool_0)
			{
				if (exception_0 == null)
				{
					string text = Class22.smethod_7(webClient_0);
					if (text == null || !text.StartsWith("image", StringComparison.OrdinalIgnoreCase))
					{
						exception_0 = new Exception("Failed to load image, not image content type: " + text);
					}
				}
				if (exception_0 == null)
				{
					if (File.Exists(string_0))
					{
						try
						{
							File.Move(string_0, string_1);
						}
						catch (Exception innerException)
						{
							exception_0 = new Exception("Failed to move downloaded image from temp to cache location", innerException);
						}
					}
					exception_0 = (File.Exists(string_1) ? null : (exception_0 ?? new Exception("Failed to download image, unknown error")));
				}
			}
			List<DownloadFileAsyncCallback> value;
			lock (this.dictionary_0)
			{
				if (this.dictionary_0.TryGetValue(string_1, out value))
				{
					this.dictionary_0.Remove(string_1);
				}
			}
			if (value == null)
			{
				return;
			}
			foreach (DownloadFileAsyncCallback item in value)
			{
				try
				{
					item(uri_0, string_1, exception_0, bool_0);
				}
				catch
				{
				}
			}
		}

		private void method_5()
		{
			this.dictionary_0.Clear();
			while (this.list_0.Count > 0)
			{
				try
				{
					WebClient webClient = this.list_0[0];
					webClient.CancelAsync();
					webClient.Dispose();
					this.list_0.RemoveAt(0);
				}
				catch
				{
				}
			}
		}
	}
}

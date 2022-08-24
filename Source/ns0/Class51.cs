using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ns13;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class51 : Class50
	{
		[CompilerGenerated]
		private sealed class Class47
		{
			public Uri uri_0;

			public Class51 class51_0;

			internal void method_0(object object_0)
			{
				try
				{
					Uri address = new Uri($"http://gdata.youtube.com/feeds/api/videos/{this.uri_0.Segments[2]}?v=2&alt=json");
					WebClient webClient = new WebClient();
					webClient.Encoding = Encoding.UTF8;
					webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(this.class51_0.method_35);
					webClient.DownloadStringAsync(address);
				}
				catch (Exception exception_)
				{
					this.class51_0.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Iframe, "Failed to get youtube video data: " + this.uri_0, exception_);
					this.class51_0.HtmlContainerInt_0.RequestRefresh(layout: false);
				}
			}
		}

		[CompilerGenerated]
		private sealed class Class48
		{
			public Uri uri_0;

			public Class51 class51_0;

			internal void method_0(object object_0)
			{
				try
				{
					Uri address = new Uri($"http://vimeo.com/api/v2/video/{this.uri_0.Segments[2]}.json");
					WebClient webClient = new WebClient();
					webClient.Encoding = Encoding.UTF8;
					webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(this.class51_0.method_37);
					webClient.DownloadStringAsync(address);
				}
				catch (Exception exception_)
				{
					this.class51_0.bool_3 = true;
					this.class51_0.method_43();
					this.class51_0.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Iframe, "Failed to get vimeo video data: " + this.uri_0, exception_);
					this.class51_0.HtmlContainerInt_0.RequestRefresh(layout: false);
				}
			}
		}

		private readonly Class60 class60_0;

		private readonly bool bool_2;

		private string string_67;

		private string string_68;

		private string string_69;

		private Class43 class43_1;

		private bool bool_3;

		public override bool Boolean_7 => true;

		public override string String_65 => this.string_69 ?? base.method_13("src");

		public new bool Boolean_6 => this.bool_2;

		public Class51(Class50 class50_2, Class63 class63_1)
			: base(class50_2, class63_1)
		{
			this.class60_0 = new Class60(this);
			base.List_3.Add(this.class60_0);
			if (Uri.TryCreate(base.method_13("src"), UriKind.Absolute, out var result))
			{
				if (result.Host.IndexOf("youtube.com", StringComparison.InvariantCultureIgnoreCase) > -1)
				{
					this.bool_2 = true;
					this.method_34(result);
				}
				else if (result.Host.IndexOf("vimeo.com", StringComparison.InvariantCultureIgnoreCase) > -1)
				{
					this.bool_2 = true;
					this.method_36(result);
				}
			}
			if (!this.bool_2)
			{
				this.method_43();
			}
		}

		public override void Dispose()
		{
			if (this.class43_1 != null)
			{
				this.class43_1.Dispose();
			}
			base.Dispose();
		}

		private void method_34(Uri uri_0)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				try
				{
					Uri address = new Uri($"http://gdata.youtube.com/feeds/api/videos/{uri_0.Segments[2]}?v=2&alt=json");
					WebClient webClient = new WebClient();
					webClient.Encoding = Encoding.UTF8;
					webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(method_35);
					webClient.DownloadStringAsync(address);
				}
				catch (Exception exception_)
				{
					base.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Iframe, "Failed to get youtube video data: " + uri_0, exception_);
					base.HtmlContainerInt_0.RequestRefresh(layout: false);
				}
			});
		}

		private void method_35(object sender, DownloadStringCompletedEventArgs e)
		{
			try
			{
				if (!e.Cancelled)
				{
					if (e.Error == null)
					{
						int num = e.Result.IndexOf("\"media$title\"", StringComparison.Ordinal);
						if (num > -1)
						{
							num = e.Result.IndexOf("\"$t\"", num);
							if (num > -1)
							{
								num = e.Result.IndexOf('"', num + 4);
								if (num > -1)
								{
									int num2 = e.Result.IndexOf('"', num + 1);
									while (e.Result[num2 - 1] == '\\')
									{
										num2 = e.Result.IndexOf('"', num2 + 1);
									}
									if (num2 > -1)
									{
										this.string_67 = e.Result.Substring(num + 1, num2 - num - 1).Replace("\\\"", "\"");
									}
								}
							}
						}
						num = e.Result.IndexOf("\"media$thumbnail\"", StringComparison.Ordinal);
						if (num > -1)
						{
							int num3 = e.Result.IndexOf("sddefault", num);
							if (num3 > -1)
							{
								if (string.IsNullOrEmpty(base.String_30))
								{
									base.String_30 = "640px";
								}
								if (string.IsNullOrEmpty(base.String_32))
								{
									base.String_32 = "480px";
								}
							}
							else
							{
								num3 = e.Result.IndexOf("hqdefault", num);
								if (num3 > -1)
								{
									if (string.IsNullOrEmpty(base.String_30))
									{
										base.String_30 = "480px";
									}
									if (string.IsNullOrEmpty(base.String_32))
									{
										base.String_32 = "360px";
									}
								}
								else
								{
									num3 = e.Result.IndexOf("mqdefault", num);
									if (num3 > -1)
									{
										if (string.IsNullOrEmpty(base.String_30))
										{
											base.String_30 = "320px";
										}
										if (string.IsNullOrEmpty(base.String_32))
										{
											base.String_32 = "180px";
										}
									}
									else
									{
										num3 = e.Result.IndexOf("default", num);
										if (string.IsNullOrEmpty(base.String_30))
										{
											base.String_30 = "120px";
										}
										if (string.IsNullOrEmpty(base.String_32))
										{
											base.String_32 = "90px";
										}
									}
								}
							}
							num3 = e.Result.LastIndexOf("http:", num3, StringComparison.Ordinal);
							if (num3 > -1)
							{
								int num4 = e.Result.IndexOf('"', num3);
								if (num4 > -1)
								{
									this.string_68 = e.Result.Substring(num3, num4 - num3).Replace("\\\"", "\"").Replace("\\", "");
								}
							}
						}
						num = e.Result.IndexOf("\"link\"", StringComparison.Ordinal);
						if (num > -1)
						{
							num = e.Result.IndexOf("http:", num);
							if (num > -1)
							{
								int num5 = e.Result.IndexOf('"', num);
								if (num5 > -1)
								{
									this.string_69 = e.Result.Substring(num, num5 - num).Replace("\\\"", "\"").Replace("\\", "");
								}
							}
						}
					}
					else
					{
						this.method_38(e.Error, "YouTube");
					}
				}
			}
			catch (Exception exception_)
			{
				base.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Iframe, "Failed to parse YouTube video response", exception_);
			}
			this.method_39(sender);
		}

		private void method_36(Uri uri_0)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				try
				{
					Uri address = new Uri($"http://vimeo.com/api/v2/video/{uri_0.Segments[2]}.json");
					WebClient webClient = new WebClient();
					webClient.Encoding = Encoding.UTF8;
					webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(method_37);
					webClient.DownloadStringAsync(address);
				}
				catch (Exception exception_)
				{
					this.bool_3 = true;
					this.method_43();
					base.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Iframe, "Failed to get vimeo video data: " + uri_0, exception_);
					base.HtmlContainerInt_0.RequestRefresh(layout: false);
				}
			});
		}

		private void method_37(object sender, DownloadStringCompletedEventArgs e)
		{
			try
			{
				if (!e.Cancelled)
				{
					if (e.Error == null)
					{
						int num = e.Result.IndexOf("\"title\"", StringComparison.Ordinal);
						if (num > -1)
						{
							num = e.Result.IndexOf('"', num + 7);
							if (num > -1)
							{
								int num2 = e.Result.IndexOf('"', num + 1);
								while (e.Result[num2 - 1] == '\\')
								{
									num2 = e.Result.IndexOf('"', num2 + 1);
								}
								if (num2 > -1)
								{
									this.string_67 = e.Result.Substring(num + 1, num2 - num - 1).Replace("\\\"", "\"");
								}
							}
						}
						num = e.Result.IndexOf("\"thumbnail_large\"", StringComparison.Ordinal);
						if (num > -1)
						{
							if (string.IsNullOrEmpty(base.String_30))
							{
								base.String_30 = "640";
							}
							if (string.IsNullOrEmpty(base.String_32))
							{
								base.String_32 = "360";
							}
						}
						else
						{
							num = e.Result.IndexOf("thumbnail_medium", num);
							if (num > -1)
							{
								if (string.IsNullOrEmpty(base.String_30))
								{
									base.String_30 = "200";
								}
								if (string.IsNullOrEmpty(base.String_32))
								{
									base.String_32 = "150";
								}
							}
							else
							{
								num = e.Result.IndexOf("thumbnail_small", num);
								if (string.IsNullOrEmpty(base.String_30))
								{
									base.String_30 = "100";
								}
								if (string.IsNullOrEmpty(base.String_32))
								{
									base.String_32 = "75";
								}
							}
						}
						if (num > -1)
						{
							num = e.Result.IndexOf("http:", num);
							if (num > -1)
							{
								int num3 = e.Result.IndexOf('"', num);
								if (num3 > -1)
								{
									this.string_68 = e.Result.Substring(num, num3 - num).Replace("\\\"", "\"").Replace("\\", "");
								}
							}
						}
						num = e.Result.IndexOf("\"url\"", StringComparison.Ordinal);
						if (num > -1)
						{
							num = e.Result.IndexOf("http:", num);
							if (num > -1)
							{
								int num4 = e.Result.IndexOf('"', num);
								if (num4 > -1)
								{
									this.string_69 = e.Result.Substring(num, num4 - num).Replace("\\\"", "\"").Replace("\\", "");
								}
							}
						}
					}
					else
					{
						this.method_38(e.Error, "Vimeo");
					}
				}
			}
			catch (Exception exception_)
			{
				base.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Iframe, "Failed to parse Vimeo video response", exception_);
			}
			this.method_39(sender);
		}

		private void method_38(Exception exception_0, string string_70)
		{
			HttpWebResponse httpWebResponse = ((exception_0 is WebException ex) ? (ex.Response as HttpWebResponse) : null);
			if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.NotFound)
			{
				this.string_67 = "The video is not found, possibly removed by the user.";
			}
			else
			{
				base.HtmlContainerInt_0.method_2(HtmlRenderErrorType.Iframe, "Failed to load " + string_70 + " video data", exception_0);
			}
		}

		private void method_39(object object_0)
		{
			try
			{
				if (this.string_68 == null)
				{
					this.bool_3 = true;
					this.method_43();
				}
				WebClient webClient = (WebClient)object_0;
				webClient.DownloadStringCompleted -= new DownloadStringCompletedEventHandler(method_35);
				webClient.DownloadStringCompleted -= new DownloadStringCompletedEventHandler(method_37);
				webClient.Dispose();
				base.HtmlContainerInt_0.RequestRefresh(this.method_45());
			}
			catch
			{
			}
		}

		protected override void vmethod_6(RGraphics rgraphics_0)
		{
			if (this.string_68 != null && this.class43_1 == null)
			{
				this.class43_1 = new Class43(base.HtmlContainerInt_0, new Delegate6<RImage, RRect, bool>(method_44));
				this.class43_1.method_0(this.string_68, (base.Class63_0 != null) ? base.Class63_0.Dictionary_0 : null);
			}
			RRect rrect_ = Class22.smethod_5(base.Dictionary_0);
			RPoint rPoint = ((base.HtmlContainerInt_0 == null || ((Class50)this).Boolean_6) ? RPoint.Empty : base.HtmlContainerInt_0.ScrollOffset);
			rrect_.Offset(rPoint);
			bool flag = Class28.smethod_1(rgraphics_0, this);
			base.method_26(rgraphics_0, rrect_, bool_2: true, bool_3: true);
			Class38.smethod_0(rgraphics_0, this, rrect_, bool_0: true, bool_1: true);
			RRect rRect_ = base.List_3[0].RRect_0;
			rRect_.Offset(rPoint);
			rRect_.Height -= base.Double_18 + base.Double_20 + base.Double_9 + base.Double_11;
			rRect_.Double_1 += base.Double_18 + base.Double_9;
			rRect_.Double_0 = Math.Floor(rRect_.Double_0);
			rRect_.Double_1 = Math.Floor(rRect_.Double_1);
			RRect rrect_2 = rRect_;
			this.method_40(rgraphics_0, rPoint, rrect_2);
			this.method_41(rgraphics_0, rrect_2);
			this.method_42(rgraphics_0, rrect_2);
			if (flag)
			{
				rgraphics_0.PopClip();
			}
		}

		private void method_40(RGraphics rgraphics_0, RPoint rpoint_1, RRect rrect_0)
		{
			if (this.class60_0.RImage_0 != null)
			{
				if (rrect_0.Width > 0.0 && rrect_0.Height > 0.0)
				{
					if (this.class60_0.RRect_1 == RRect.Empty)
					{
						rgraphics_0.DrawImage(this.class60_0.RImage_0, rrect_0);
					}
					else
					{
						rgraphics_0.DrawImage(this.class60_0.RImage_0, rrect_0, this.class60_0.RRect_1);
					}
					if (this.class60_0.Boolean_0)
					{
						rgraphics_0.DrawRectangle(base.method_33(rgraphics_0, bool_2: true), this.class60_0.Double_0 + rpoint_1.Double_0, this.class60_0.Double_1 + rpoint_1.Double_1, this.class60_0.Double_2 + 2.0, Class25.smethod_15(this.class60_0).Double_0);
					}
				}
			}
			else if (this.bool_2 && !this.bool_3)
			{
				Class28.smethod_2(rgraphics_0, base.HtmlContainerInt_0, rrect_0);
				if (rrect_0.Width > 19.0 && rrect_0.Height > 19.0)
				{
					rgraphics_0.DrawRectangle(rgraphics_0.GetPen(RColor.LightGray), rrect_0.Double_0, rrect_0.Double_1, rrect_0.Width, rrect_0.Height);
				}
			}
		}

		private void method_41(RGraphics rgraphics_0, RRect rrect_0)
		{
			if (this.string_67 != null && this.class60_0.Double_2 > 40.0 && this.class60_0.Double_5 > 40.0)
			{
				RFont font = base.HtmlContainerInt_0.RAdapter_0.GetFont("Arial", 9.0, RFontStyle.Regular);
				rgraphics_0.DrawRectangle(rgraphics_0.GetSolidBrush(RColor.FromArgb(160, 0, 0, 0)), rrect_0.Left, rrect_0.Top, rrect_0.Width, base.RFont_1.Height + 7.0);
				rgraphics_0.DrawString(point: new RRect(rrect_0.Left + 3.0, rrect_0.Top + 3.0, rrect_0.Width - 6.0, rrect_0.Height - 6.0).Location, str: this.string_67, font: font, color: RColor.WhiteSmoke, size: RSize.Empty, rtl: false);
			}
		}

		private void method_42(RGraphics rgraphics_0, RRect rrect_0)
		{
			if (this.bool_2 && this.class60_0.Double_2 > 70.0 && this.class60_0.Double_5 > 50.0)
			{
				object prevMode = rgraphics_0.SetAntiAliasSmoothingMode();
				RSize rSize = new RSize(60.0, 40.0);
				double num = rrect_0.Left + (rrect_0.Width - rSize.Width) / 2.0;
				double num2 = rrect_0.Top + (rrect_0.Height - rSize.Height) / 2.0;
				rgraphics_0.DrawRectangle(rgraphics_0.GetSolidBrush(RColor.FromArgb(160, 0, 0, 0)), num, num2, rSize.Width, rSize.Height);
				rgraphics_0.DrawPolygon(points: new RPoint[3]
				{
					new RPoint(num + rSize.Width / 3.0 + 1.0, num2 + 3.0 * rSize.Height / 4.0),
					new RPoint(num + rSize.Width / 3.0 + 1.0, num2 + rSize.Height / 4.0),
					new RPoint(num + 2.0 * rSize.Width / 3.0 + 1.0, num2 + rSize.Height / 2.0)
				}, brush: rgraphics_0.GetSolidBrush(RColor.White));
				rgraphics_0.ReturnPreviousSmoothingMode(prevMode);
			}
		}

		internal override void vmethod_5(RGraphics rgraphics_0)
		{
			if (!base.bool_1)
			{
				base.method_3(rgraphics_0);
				base.bool_1 = true;
			}
			Class55.smethod_0(this.class60_0);
		}

		private void method_43()
		{
			base.method_2("solid", "2px", "#A0A0A0");
			base.String_10 = (base.String_8 = "#E3E3E3");
		}

		private void method_44(RImage rimage_0, RRect rrect_0, bool bool_4)
		{
			this.class60_0.RImage_0 = rimage_0;
			this.class60_0.RRect_1 = rrect_0;
			this.bool_3 = true;
			base.bool_1 = false;
			if (this.bool_3 && rimage_0 == null)
			{
				this.method_43();
			}
			if (bool_4)
			{
				base.HtmlContainerInt_0.RequestRefresh(this.method_45());
			}
		}

		private bool method_45()
		{
			Class57 @class = new Class57(base.String_30);
			Class57 class2 = new Class57(base.String_32);
			return @class.Double_0 <= 0.0 || @class.Enum3_0 != Enum3.const_2 || class2.Double_0 <= 0.0 || class2.Enum3_0 != Enum3.const_2;
		}
	}
}

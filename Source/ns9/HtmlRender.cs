using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using ns0;
using ns10;
using ns11;
using ns13;
using ns15;
using ns16;

namespace ns9
{
	public static class HtmlRender
	{
		public static void AddFontFamily(FontFamily fontFamily)
		{
			ArgChecker.AssertArgNotNull(fontFamily, "fontFamily");
			Class64.Class64_0.AddFontFamily(new Class68(fontFamily));
		}

		public static void AddFontFamilyMapping(string fromFamily, string toFamily)
		{
			ArgChecker.AssertArgNotNullOrEmpty(fromFamily, "fromFamily");
			ArgChecker.AssertArgNotNullOrEmpty(toFamily, "toFamily");
			Class64.Class64_0.AddFontFamilyMapping(fromFamily, toFamily);
		}

		public static CssData ParseStyleSheet(string stylesheet, bool combineWithDefault = true)
		{
			return CssData.Parse(Class64.Class64_0, stylesheet, combineWithDefault);
		}

		public static SizeF Measure(Graphics g, string html, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			return HtmlRender.smethod_0(g, html, maxWidth, cssData, bool_0: false, stylesheetLoad, imageLoad);
		}

		public static SizeF MeasureGdiPlus(Graphics g, string html, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			return HtmlRender.smethod_0(g, html, maxWidth, cssData, bool_0: true, stylesheetLoad, imageLoad);
		}

		public static SizeF Render(Graphics g, string html, float left = 0f, float top = 0f, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			return HtmlRender.smethod_2(g, html, new PointF(left, top), new SizeF(maxWidth, 0f), cssData, bool_0: false, stylesheetLoad, imageLoad);
		}

		public static SizeF Render(Graphics g, string html, PointF location, SizeF maxSize, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			return HtmlRender.smethod_2(g, html, location, maxSize, cssData, bool_0: false, stylesheetLoad, imageLoad);
		}

		public static SizeF RenderGdiPlus(Graphics g, string html, float left = 0f, float top = 0f, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			return HtmlRender.smethod_2(g, html, new PointF(left, top), new SizeF(maxWidth, 0f), cssData, bool_0: true, stylesheetLoad, imageLoad);
		}

		public static SizeF RenderGdiPlus(Graphics g, string html, PointF location, SizeF maxSize, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			return HtmlRender.smethod_2(g, html, location, maxSize, cssData, bool_0: true, stylesheetLoad, imageLoad);
		}

		public static Metafile RenderToMetafile(string html, float left = 0f, float top = 0f, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			IntPtr intptr_;
			IntPtr intPtr = Class20.smethod_0(IntPtr.Zero, 1, 1, out intptr_);
			Metafile metafile;
			try
			{
				metafile = new Metafile(intPtr, EmfType.EmfPlusDual, "..");
				using Graphics g = Graphics.FromImage(metafile);
				HtmlRender.Render(g, html, left, top, maxWidth, cssData, stylesheetLoad, imageLoad);
			}
			finally
			{
				Class20.smethod_1(intPtr, intptr_);
			}
			return metafile;
		}

		public static void RenderToImage(Image image, string html, PointF location = default(PointF), CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			ArgChecker.AssertArgNotNull(image, "image");
			SizeF maxSize = new SizeF((float)image.Size.Width - location.X, (float)image.Size.Height - location.Y);
			HtmlRender.RenderToImage(image, html, location, maxSize, cssData, stylesheetLoad, imageLoad);
		}

		public static void RenderToImage(Image image, string html, PointF location, SizeF maxSize, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			ArgChecker.AssertArgNotNull(image, "image");
			if (string.IsNullOrEmpty(html))
			{
				return;
			}
			IntPtr intptr_;
			IntPtr intPtr = Class20.smethod_0(IntPtr.Zero, image.Width, image.Height, out intptr_);
			try
			{
				using (Graphics graphics = Graphics.FromHdc(intPtr))
				{
					graphics.DrawImageUnscaled(image, 0, 0);
					HtmlRender.smethod_3(graphics, html, location, maxSize, cssData, bool_0: false, stylesheetLoad, imageLoad);
				}
				HtmlRender.smethod_4(intPtr, image);
			}
			finally
			{
				Class20.smethod_1(intPtr, intptr_);
			}
		}

		public static Image RenderToImage(string html, Size size, Color backgroundColor = default(Color), CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			if (backgroundColor == Color.Transparent)
			{
				throw new ArgumentOutOfRangeException("backgroundColor", "Transparent background in not supported");
			}
			Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
			if (!string.IsNullOrEmpty(html))
			{
				IntPtr intptr_;
				IntPtr intPtr = Class20.smethod_0(IntPtr.Zero, bitmap.Width, bitmap.Height, out intptr_);
				try
				{
					using (Graphics graphics = Graphics.FromHdc(intPtr))
					{
						graphics.Clear((backgroundColor != Color.Empty) ? backgroundColor : Color.White);
						HtmlRender.smethod_3(graphics, html, PointF.Empty, size, cssData, bool_0: true, stylesheetLoad, imageLoad);
					}
					HtmlRender.smethod_4(intPtr, bitmap);
				}
				finally
				{
					Class20.smethod_1(intPtr, intptr_);
				}
			}
			return bitmap;
		}

		public static Image RenderToImage(string html, int maxWidth = 0, int maxHeight = 0, Color backgroundColor = default(Color), CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			return HtmlRender.RenderToImage(html, Size.Empty, new Size(maxWidth, maxHeight), backgroundColor, cssData, stylesheetLoad, imageLoad);
		}

		public static Image RenderToImage(string html, Size minSize, Size maxSize, Color backgroundColor = default(Color), CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			if (backgroundColor == Color.Transparent)
			{
				throw new ArgumentOutOfRangeException("backgroundColor", "Transparent background in not supported");
			}
			if (string.IsNullOrEmpty(html))
			{
				return new Bitmap(0, 0, PixelFormat.Format32bppArgb);
			}
			using HtmlContainer htmlContainer = new HtmlContainer();
			htmlContainer.AvoidAsyncImagesLoading = true;
			htmlContainer.AvoidImagesLateLoading = true;
			if (stylesheetLoad != null)
			{
				htmlContainer.StylesheetLoad += stylesheetLoad;
			}
			if (imageLoad != null)
			{
				htmlContainer.ImageLoad += imageLoad;
			}
			htmlContainer.SetHtml(html, cssData);
			Size size = HtmlRender.smethod_1(htmlContainer, minSize, maxSize);
			htmlContainer.MaxSize = size;
			Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
			IntPtr intptr_;
			IntPtr intPtr = Class20.smethod_0(IntPtr.Zero, bitmap.Width, bitmap.Height, out intptr_);
			try
			{
				using (Graphics graphics = Graphics.FromHdc(intPtr))
				{
					graphics.Clear((backgroundColor != Color.Empty) ? backgroundColor : Color.White);
					htmlContainer.PerformPaint(graphics);
				}
				HtmlRender.smethod_4(intPtr, bitmap);
			}
			finally
			{
				Class20.smethod_1(intPtr, intptr_);
			}
			return bitmap;
		}

		public static Image RenderToImageGdiPlus(string html, Size size, TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.TextRenderingHint = textRenderingHint;
				HtmlRender.smethod_3(graphics, html, PointF.Empty, size, cssData, bool_0: true, stylesheetLoad, imageLoad);
			}
			return bitmap;
		}

		public static Image RenderToImageGdiPlus(string html, int maxWidth = 0, int maxHeight = 0, TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			return HtmlRender.RenderToImageGdiPlus(html, Size.Empty, new Size(maxWidth, maxHeight), textRenderingHint, cssData, stylesheetLoad, imageLoad);
		}

		public static Image RenderToImageGdiPlus(string html, Size minSize, Size maxSize, TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
		{
			if (string.IsNullOrEmpty(html))
			{
				return new Bitmap(0, 0, PixelFormat.Format32bppArgb);
			}
			using HtmlContainer htmlContainer = new HtmlContainer();
			htmlContainer.AvoidAsyncImagesLoading = true;
			htmlContainer.AvoidImagesLateLoading = true;
			htmlContainer.UseGdiPlusTextRendering = true;
			if (stylesheetLoad != null)
			{
				htmlContainer.StylesheetLoad += stylesheetLoad;
			}
			if (imageLoad != null)
			{
				htmlContainer.ImageLoad += imageLoad;
			}
			htmlContainer.SetHtml(html, cssData);
			Size size = HtmlRender.smethod_1(htmlContainer, minSize, maxSize);
			htmlContainer.MaxSize = size;
			Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.TextRenderingHint = textRenderingHint;
				htmlContainer.PerformPaint(graphics);
			}
			return bitmap;
		}

		private static SizeF smethod_0(Graphics graphics_0, string string_0, float float_0, CssData cssData_0, bool bool_0, EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_0, EventHandler<HtmlImageLoadEventArgs> eventHandler_1)
		{
			SizeF result = SizeF.Empty;
			if (!string.IsNullOrEmpty(string_0))
			{
				using HtmlContainer htmlContainer = new HtmlContainer();
				htmlContainer.MaxSize = new SizeF(float_0, 0f);
				htmlContainer.AvoidAsyncImagesLoading = true;
				htmlContainer.AvoidImagesLateLoading = true;
				htmlContainer.UseGdiPlusTextRendering = bool_0;
				if (eventHandler_0 != null)
				{
					htmlContainer.StylesheetLoad += eventHandler_0;
				}
				if (eventHandler_1 != null)
				{
					htmlContainer.ImageLoad += eventHandler_1;
				}
				htmlContainer.SetHtml(string_0, cssData_0);
				htmlContainer.PerformLayout(graphics_0);
				result = htmlContainer.ActualSize;
			}
			return result;
		}

		private static Size smethod_1(HtmlContainer htmlContainer_0, Size size_0, Size size_1)
		{
			using Graphics g = Graphics.FromHwnd(IntPtr.Zero);
			using GraphicsAdapter g2 = new GraphicsAdapter(g, htmlContainer_0.UseGdiPlusTextRendering);
			RSize rsize_ = HtmlRendererUtils.MeasureHtmlByRestrictions(g2, htmlContainer_0.HtmlContainerInt, Class19.smethod_4(size_0), Class19.smethod_4(size_1));
			if (size_1.Width < 1 && rsize_.Width > 4096.0)
			{
				rsize_.Width = 4096.0;
			}
			return Class19.smethod_6(rsize_);
		}

		private static SizeF smethod_2(Graphics graphics_0, string string_0, PointF pointF_0, SizeF sizeF_0, CssData cssData_0, bool bool_0, EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_0, EventHandler<HtmlImageLoadEventArgs> eventHandler_1)
		{
			Region region = null;
			if (sizeF_0.Height > 0f)
			{
				region = graphics_0.Clip;
				graphics_0.SetClip(new RectangleF(pointF_0, sizeF_0));
			}
			SizeF result = HtmlRender.smethod_3(graphics_0, string_0, pointF_0, sizeF_0, cssData_0, bool_0, eventHandler_0, eventHandler_1);
			if (region != null)
			{
				graphics_0.SetClip(region, CombineMode.Replace);
			}
			return result;
		}

		private static SizeF smethod_3(Graphics graphics_0, string string_0, PointF pointF_0, SizeF sizeF_0, CssData cssData_0, bool bool_0, EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_0, EventHandler<HtmlImageLoadEventArgs> eventHandler_1)
		{
			SizeF result = SizeF.Empty;
			if (!string.IsNullOrEmpty(string_0))
			{
				using HtmlContainer htmlContainer = new HtmlContainer();
				htmlContainer.Location = pointF_0;
				htmlContainer.MaxSize = sizeF_0;
				htmlContainer.AvoidAsyncImagesLoading = true;
				htmlContainer.AvoidImagesLateLoading = true;
				htmlContainer.UseGdiPlusTextRendering = bool_0;
				if (eventHandler_0 != null)
				{
					htmlContainer.StylesheetLoad += eventHandler_0;
				}
				if (eventHandler_1 != null)
				{
					htmlContainer.ImageLoad += eventHandler_1;
				}
				htmlContainer.SetHtml(string_0, cssData_0);
				htmlContainer.PerformLayout(graphics_0);
				htmlContainer.PerformPaint(graphics_0);
				result = htmlContainer.ActualSize;
			}
			return result;
		}

		private static void smethod_4(IntPtr intptr_0, Image image_0)
		{
			using Graphics graphics = Graphics.FromImage(image_0);
			IntPtr hdc = graphics.GetHdc();
			Class20.BitBlt(hdc, 0, 0, image_0.Width, image_0.Height, intptr_0, 0, 0, 13369376u);
			graphics.ReleaseHdc(hdc);
		}
	}
}

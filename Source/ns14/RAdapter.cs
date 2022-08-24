using System;
using System.Collections.Generic;
using System.IO;
using ns0;
using ns10;
using ns11;
using ns16;

namespace ns14
{
	public abstract class RAdapter
	{
		private readonly Dictionary<RColor, RBrush> dictionary_0 = new Dictionary<RColor, RBrush>();

		private readonly Dictionary<RColor, RPen> dictionary_1 = new Dictionary<RColor, RPen>();

		private readonly Class40 class40_0;

		private CssData cssData_0;

		private RImage rimage_0;

		private RImage rimage_1;

		public CssData DefaultCssData => this.cssData_0 ?? (this.cssData_0 = CssData.Parse(this, "\n        html, address,\n        blockquote,\n        body, dd, div,\n        dl, dt, fieldset, form,\n        frame, frameset,\n        h1, h2, h3, h4,\n        h5, h6, noframes,\n        ol, p, ul, center,\n        dir, menu, pre   { display: block }\n        li              { display: list-item }\n        head            { display: none }\n        table           { display: table }\n        tr              { display: table-row }\n        thead           { display: table-header-group }\n        tbody           { display: table-row-group }\n        tfoot           { display: table-footer-group }\n        col             { display: table-column }\n        colgroup        { display: table-column-group }\n        td, th          { display: table-cell }\n        caption         { display: table-caption }\n        th              { font-weight: bolder; text-align: center }\n        caption         { text-align: center }\n        body            { margin: 8px }\n        h1              { font-size: 2em; margin: .67em 0 }\n        h2              { font-size: 1.5em; margin: .75em 0 }\n        h3              { font-size: 1.17em; margin: .83em 0 }\n        h4, p,\n        blockquote, ul,\n        fieldset, form,\n        ol, dl, dir,\n        menu            { margin: 1.12em 0 }\n        h5              { font-size: .83em; margin: 1.5em 0 }\n        h6              { font-size: .75em; margin: 1.67em 0 }\n        h1, h2, h3, h4,\n        h5, h6, b,\n        strong          { font-weight: bolder; }\n        blockquote      { margin-left: 40px; margin-right: 40px }\n        i, cite, em,\n        var, address    { font-style: italic }\n        pre, tt, code,\n        kbd, samp       { font-family: monospace }\n        pre             { white-space: pre }\n        button, textarea,\n        input, select   { display: inline-block }\n        big             { font-size: 1.17em }\n        small, sub, sup { font-size: .83em }\n        sub             { vertical-align: sub }\n        sup             { vertical-align: super }\n        table           { border-spacing: 2px; }\n        thead, tbody,\n        tfoot, tr       { vertical-align: middle }\n        td, th          { vertical-align: inherit }\n        s, strike, del  { text-decoration: line-through }\n        hr              { border: 1px inset; }\n        ol, ul, dir,\n        menu, dd        { margin-left: 40px }\n        ol              { list-style-type: decimal }\n        ol ul, ul ol,\n        ul ul, ol ol    { margin-top: 0; margin-bottom: 0 }\n        ol ul, ul ul   { list-style-type: circle }\n        ul ul ul, \n        ol ul ul, \n        ul ol ul        { list-style-type: square }\n        u, ins          { text-decoration: underline }\n        br:before       { content: \"\\A\" }\n        :before, :after { white-space: pre-line }\n        center          { text-align: center }\n        :link, :visited { text-decoration: underline }\n        :focus          { outline: thin dotted invert }\n\n        /* Begin bidirectionality settings (do not change) */\n        BDO[DIR=\"ltr\"]  { direction: ltr; unicode-bidi: bidi-override }\n        BDO[DIR=\"rtl\"]  { direction: rtl; unicode-bidi: bidi-override }\n\n        *[DIR=\"ltr\"]    { direction: ltr; unicode-bidi: embed }\n        *[DIR=\"rtl\"]    { direction: rtl; unicode-bidi: embed }\n\n        @media print {\n          h1            { page-break-before: always }\n          h1, h2, h3,\n          h4, h5, h6    { page-break-after: avoid }\n          ul, ol, dl    { page-break-before: avoid }\n        }\n\n        /* Not in the specification but necessary */\n        a               { color: #0055BB; text-decoration:underline }\n        table           { border-color:#dfdfdf; }\n        td, th          { border-color:#dfdfdf; overflow: hidden; }\n        style, title,\n        script, link,\n        meta, area,\n        base, param     { display:none }\n        hr              { border-top-color: #9A9A9A; border-left-color: #9A9A9A; border-bottom-color: #EEEEEE; border-right-color: #EEEEEE; }\n        pre             { font-size: 10pt; margin-top: 15px; }\n        \n        /*This is the background of the HtmlToolTip*/\n        .htmltooltip {\n            border:solid 1px #767676;\n            background-color:white;\n            background-gradient:#E4E5F0;\n            padding: 8px; \n            Font: 9pt Tahoma;\n        }", combineWithDefault: false));

		protected RAdapter()
		{
			this.class40_0 = new Class40(this);
		}

		public RColor GetColor(string colorName)
		{
			ArgChecker.AssertArgNotNullOrEmpty(colorName, "colorName");
			return this.GetColorInt(colorName);
		}

		public RPen GetPen(RColor color)
		{
			if (!this.dictionary_1.TryGetValue(color, out var value))
			{
				value = (this.dictionary_1[color] = this.CreatePen(color));
			}
			return value;
		}

		public RBrush GetSolidBrush(RColor color)
		{
			if (!this.dictionary_0.TryGetValue(color, out var value))
			{
				value = (this.dictionary_0[color] = this.CreateSolidBrush(color));
			}
			return value;
		}

		public RBrush GetLinearGradientBrush(RRect rect, RColor color1, RColor color2, double angle)
		{
			return this.CreateLinearGradientBrush(rect, color1, color2, angle);
		}

		public RImage ConvertImage(object image)
		{
			return this.ConvertImageInt(image);
		}

		public RImage ImageFromStream(Stream memoryStream)
		{
			return this.ImageFromStreamInt(memoryStream);
		}

		public bool IsFontExists(string font)
		{
			return this.class40_0.method_0(font);
		}

		public void AddFontFamily(RFontFamily fontFamily)
		{
			this.class40_0.method_1(fontFamily);
		}

		public void AddFontFamilyMapping(string fromFamily, string toFamily)
		{
			this.class40_0.method_2(fromFamily, toFamily);
		}

		public RFont GetFont(string family, double size, RFontStyle style)
		{
			return this.class40_0.method_3(family, size, style);
		}

		public RImage GetLoadingImage()
		{
			if (this.rimage_0 == null)
			{
				Stream manifestResourceStream = typeof(HtmlRendererUtils).Assembly.GetManifestResourceStream("Siticone.UI.HtmlRenderer.Core.Utils.ImageLoad.png");
				if (manifestResourceStream != null)
				{
					this.rimage_0 = this.ImageFromStream(manifestResourceStream);
				}
			}
			return this.rimage_0;
		}

		public RImage GetLoadingFailedImage()
		{
			if (this.rimage_1 == null)
			{
				Stream manifestResourceStream = typeof(HtmlRendererUtils).Assembly.GetManifestResourceStream("Siticone.UI.HtmlRenderer.Core.Utils.ImageError.png");
				if (manifestResourceStream != null)
				{
					this.rimage_1 = this.ImageFromStream(manifestResourceStream);
				}
			}
			return this.rimage_1;
		}

		public object GetClipboardDataObject(string html, string plainText)
		{
			return this.GetClipboardDataObjectInt(html, plainText);
		}

		public void SetToClipboard(string text)
		{
			this.SetToClipboardInt(text);
		}

		public void SetToClipboard(string html, string plainText)
		{
			this.SetToClipboardInt(html, plainText);
		}

		public void SetToClipboard(RImage image)
		{
			this.SetToClipboardInt(image);
		}

		public RContextMenu GetContextMenu()
		{
			return this.CreateContextMenuInt();
		}

		public void SaveToFile(RImage image, string name, string extension, RControl control = null)
		{
			this.SaveToFileInt(image, name, extension, control);
		}

		internal RFont method_0(string string_0, double double_0, RFontStyle rfontStyle_0)
		{
			return this.CreateFontInt(string_0, double_0, rfontStyle_0);
		}

		internal RFont method_1(RFontFamily rfontFamily_0, double double_0, RFontStyle rfontStyle_0)
		{
			return this.CreateFontInt(rfontFamily_0, double_0, rfontStyle_0);
		}

		protected abstract RColor GetColorInt(string colorName);

		protected abstract RPen CreatePen(RColor color);

		protected abstract RBrush CreateSolidBrush(RColor color);

		protected abstract RBrush CreateLinearGradientBrush(RRect rect, RColor color1, RColor color2, double angle);

		protected abstract RImage ConvertImageInt(object image);

		protected abstract RImage ImageFromStreamInt(Stream memoryStream);

		protected abstract RFont CreateFontInt(string family, double size, RFontStyle style);

		protected abstract RFont CreateFontInt(RFontFamily family, double size, RFontStyle style);

		protected virtual object GetClipboardDataObjectInt(string html, string plainText)
		{
			throw new NotImplementedException();
		}

		protected virtual void SetToClipboardInt(string text)
		{
			throw new NotImplementedException();
		}

		protected virtual void SetToClipboardInt(string html, string plainText)
		{
			throw new NotImplementedException();
		}

		protected virtual void SetToClipboardInt(RImage image)
		{
			throw new NotImplementedException();
		}

		protected virtual RContextMenu CreateContextMenuInt()
		{
			throw new NotImplementedException();
		}

		protected virtual void SaveToFileInt(RImage image, string name, string extension, RControl control = null)
		{
			throw new NotImplementedException();
		}
	}
}

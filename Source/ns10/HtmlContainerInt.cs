using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using ns0;
using ns11;
using ns13;
using ns14;
using ns16;

namespace ns10
{
	public sealed class HtmlContainerInt : IDisposable
	{
		private readonly RAdapter radapter_0;

		private readonly Class30 class30_0;

		private Class50 class50_0;

		private List<Class62> list_0;

		private Class45 class45_0;

		private Class41 class41_0;

		private RColor rcolor_0;

		private RColor rcolor_1;

		private CssData cssData_0;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private bool bool_5;

		private RPoint rpoint_0;

		private RSize rsize_0;

		private RPoint rpoint_1;

		private RSize rsize_1;

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<HtmlLinkClickedEventArgs> eventHandler_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HtmlRefreshEventArgs> eventHandler_2;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HtmlScrollEventArgs> eventHandler_3;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<HtmlRenderErrorEventArgs> eventHandler_4;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_5;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HtmlImageLoadEventArgs> eventHandler_6;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private RSize rsize_2;

		internal RAdapter RAdapter_0 => this.radapter_0;

		internal Class30 Class30_0 => this.class30_0;

		public CssData CssData => this.cssData_0;

		public bool AvoidGeometryAntialias
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		public bool AvoidAsyncImagesLoading
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}

		public bool AvoidImagesLateLoading
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}

		public bool IsSelectionEnabled
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public bool IsContextMenuEnabled
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		public RPoint ScrollOffset
		{
			get
			{
				return this.rpoint_1;
			}
			set
			{
				this.rpoint_1 = value;
			}
		}

		public RPoint Location
		{
			get
			{
				return this.rpoint_0;
			}
			set
			{
				this.rpoint_0 = value;
			}
		}

		public RSize MaxSize
		{
			get
			{
				return this.rsize_0;
			}
			set
			{
				this.rsize_0 = value;
			}
		}

		public RSize ActualSize
		{
			get
			{
				return this.rsize_1;
			}
			set
			{
				this.rsize_1 = value;
			}
		}

		public RSize PageSize
		{
			[CompilerGenerated]
			get
			{
				return this.rsize_2;
			}
			[CompilerGenerated]
			set
			{
				this.rsize_2 = value;
			}
		}

		public int MarginTop
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (value > -1)
				{
					this.int_0 = value;
				}
			}
		}

		public int MarginBottom
		{
			get
			{
				return this.int_1;
			}
			set
			{
				if (value > -1)
				{
					this.int_1 = value;
				}
			}
		}

		public int MarginLeft
		{
			get
			{
				return this.int_2;
			}
			set
			{
				if (value > -1)
				{
					this.int_2 = value;
				}
			}
		}

		public int MarginRight
		{
			get
			{
				return this.int_3;
			}
			set
			{
				if (value > -1)
				{
					this.int_3 = value;
				}
			}
		}

		public string SelectedText => this.class45_0.method_7();

		public string SelectedHtml => this.class45_0.method_8();

		internal Class50 Class50_0 => this.class50_0;

		internal RColor RColor_0
		{
			get
			{
				return this.rcolor_0;
			}
			set
			{
				this.rcolor_0 = value;
			}
		}

		internal RColor RColor_1
		{
			get
			{
				return this.rcolor_1;
			}
			set
			{
				this.rcolor_1 = value;
			}
		}

		public event EventHandler LoadComplete
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlLinkClickedEventArgs> eventHandler = this.eventHandler_1;
				EventHandler<HtmlLinkClickedEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlLinkClickedEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlLinkClickedEventArgs> eventHandler = this.eventHandler_1;
				EventHandler<HtmlLinkClickedEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlLinkClickedEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlRefreshEventArgs> Refresh
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlRefreshEventArgs> eventHandler = this.eventHandler_2;
				EventHandler<HtmlRefreshEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlRefreshEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlRefreshEventArgs> eventHandler = this.eventHandler_2;
				EventHandler<HtmlRefreshEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlRefreshEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlScrollEventArgs> ScrollChange
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlScrollEventArgs> eventHandler = this.eventHandler_3;
				EventHandler<HtmlScrollEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlScrollEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlScrollEventArgs> eventHandler = this.eventHandler_3;
				EventHandler<HtmlScrollEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlScrollEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlRenderErrorEventArgs> RenderError
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlRenderErrorEventArgs> eventHandler = this.eventHandler_4;
				EventHandler<HtmlRenderErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlRenderErrorEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_4, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlRenderErrorEventArgs> eventHandler = this.eventHandler_4;
				EventHandler<HtmlRenderErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlRenderErrorEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_4, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler = this.eventHandler_5;
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlStylesheetLoadEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_5, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler = this.eventHandler_5;
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlStylesheetLoadEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_5, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlImageLoadEventArgs> ImageLoad
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlImageLoadEventArgs> eventHandler = this.eventHandler_6;
				EventHandler<HtmlImageLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlImageLoadEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_6, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlImageLoadEventArgs> eventHandler = this.eventHandler_6;
				EventHandler<HtmlImageLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlImageLoadEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_6, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public HtmlContainerInt(RAdapter adapter)
		{
			ArgChecker.AssertArgNotNull(adapter, "global");
			this.radapter_0 = adapter;
			this.class30_0 = new Class30(adapter);
		}

		public void SetMargins(int value)
		{
			if (value > -1)
			{
				this.int_1 = (this.int_2 = (this.int_0 = (this.int_3 = value)));
			}
		}

		public void SetHtml(string htmlSource, CssData baseCssData = null)
		{
			this.Clear();
			if (!string.IsNullOrEmpty(htmlSource))
			{
				this.bool_5 = false;
				this.cssData_0 = baseCssData ?? this.radapter_0.DefaultCssData;
				this.class50_0 = new Class32(this.class30_0).method_0(htmlSource, this, ref this.cssData_0);
				if (this.class50_0 != null)
				{
					this.class45_0 = new Class45(this.class50_0);
					this.class41_0 = new Class41();
				}
			}
		}

		public void Clear()
		{
			if (this.class50_0 != null)
			{
				this.class50_0.Dispose();
				this.class50_0 = null;
				if (this.class45_0 != null)
				{
					this.class45_0.Dispose();
				}
				this.class45_0 = null;
				if (this.class41_0 != null)
				{
					this.class41_0.Dispose();
				}
				this.class41_0 = null;
				this.list_0 = null;
			}
		}

		public void ClearSelection()
		{
			if (this.class45_0 != null)
			{
				this.class45_0.method_13();
				this.RequestRefresh(layout: false);
			}
		}

		public string GetHtml(HtmlGenerationStyle styleGen = HtmlGenerationStyle.Inline)
		{
			return Class25.smethod_17(this.class50_0, styleGen);
		}

		public string GetAttributeAt(RPoint location, string attribute)
		{
			ArgChecker.AssertArgNotNullOrEmpty(attribute, "attribute");
			Class50 @class = Class25.smethod_8(this.class50_0, this.method_6(location));
			return (@class != null) ? Class25.smethod_7(@class, attribute) : null;
		}

		public List<LinkElementData<RRect>> GetLinks()
		{
			List<Class50> list = new List<Class50>();
			Class25.smethod_9(this.class50_0, list);
			List<LinkElementData<RRect>> list2 = new List<LinkElementData<RRect>>();
			foreach (Class50 item in list)
			{
				list2.Add(new LinkElementData<RRect>(item.method_13("id"), item.method_13("href"), Class22.smethod_5(item.Dictionary_0, item.RRect_0)));
			}
			return list2;
		}

		public string GetLinkAt(RPoint location)
		{
			return Class25.smethod_10(this.class50_0, this.method_6(location))?.String_65;
		}

		public RRect? GetElementRectangle(string elementId)
		{
			ArgChecker.AssertArgNotNullOrEmpty(elementId, "elementId");
			Class50 @class = Class25.smethod_11(this.class50_0, elementId.ToLower());
			return (@class != null) ? new RRect?(Class22.smethod_5(@class.Dictionary_0, @class.RRect_0)) : null;
		}

		public void PerformLayout(RGraphics g)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			this.rsize_1 = RSize.Empty;
			if (this.class50_0 != null)
			{
				this.class50_0.RSize_0 = new RSize((this.rsize_0.Width > 0.0) ? this.rsize_0.Width : 99999.0, 0.0);
				this.class50_0.RPoint_0 = this.rpoint_0;
				this.class50_0.method_5(g);
				if (this.rsize_0.Width <= 0.1)
				{
					this.class50_0.RSize_0 = new RSize((int)Math.Ceiling(this.rsize_1.Width), 0.0);
					this.rsize_1 = RSize.Empty;
					this.class50_0.method_5(g);
				}
				if (!this.bool_5)
				{
					this.bool_5 = true;
					this.eventHandler_0?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		public void PerformPaint(RGraphics g)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			if (this.MaxSize.Height > 0.0)
			{
				g.PushClip(new RRect(this.rpoint_0.Double_0, this.rpoint_0.Double_1, Math.Min(this.rsize_0.Width, this.PageSize.Width), Math.Min(this.rsize_0.Height, this.PageSize.Height)));
			}
			else
			{
				g.PushClip(new RRect(this.MarginLeft, this.MarginTop, this.PageSize.Width, this.PageSize.Height));
			}
			if (this.class50_0 != null)
			{
				this.class50_0.method_6(g);
			}
			g.PopClip();
		}

		public void HandleMouseDown(RControl parent, RPoint location)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			try
			{
				if (this.class45_0 != null)
				{
					this.class45_0.method_2(parent, this.method_6(location), this.method_7(location));
				}
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.KeyboardMouse, "Failed mouse down handle", exception_);
			}
		}

		public void HandleMouseUp(RControl parent, RPoint location, RMouseEvent e)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			try
			{
				if (this.class45_0 != null && this.method_7(location) && !this.class45_0.method_3(parent, e.LeftButton) && e.LeftButton)
				{
					Class50 @class = Class25.smethod_10(rpoint_0: this.method_6(location), class50_0: this.class50_0);
					if (@class != null)
					{
						this.method_3(parent, location, @class);
					}
				}
			}
			catch (HtmlLinkClickedException)
			{
				throw;
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.KeyboardMouse, "Failed mouse up handle", exception_);
			}
		}

		public void HandleMouseDoubleClick(RControl parent, RPoint location)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			try
			{
				if (this.class45_0 != null && this.method_7(location))
				{
					this.class45_0.method_1(parent, this.method_6(location));
				}
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.KeyboardMouse, "Failed mouse double click handle", exception_);
			}
		}

		public void HandleMouseMove(RControl parent, RPoint location)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			try
			{
				RPoint rPoint = this.method_6(location);
				if (this.class45_0 != null && this.method_7(location))
				{
					this.class45_0.method_4(parent, rPoint);
				}
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.KeyboardMouse, "Failed mouse move handle", exception_);
			}
		}

		public void HandleMouseLeave(RControl parent)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			try
			{
				if (this.class45_0 != null)
				{
					this.class45_0.method_5(parent);
				}
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.KeyboardMouse, "Failed mouse leave handle", exception_);
			}
		}

		public void HandleKeyDown(RControl parent, RKeyEvent e)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			ArgChecker.AssertArgNotNull(e, "e");
			try
			{
				if (e.Control && this.class45_0 != null)
				{
					if (e.AKeyCode)
					{
						this.class45_0.method_0(parent);
					}
					if (e.CKeyCode)
					{
						this.class45_0.method_6();
					}
				}
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.KeyboardMouse, "Failed key down handle", exception_);
			}
		}

		internal void method_0(HtmlStylesheetLoadEventArgs htmlStylesheetLoadEventArgs_0)
		{
			try
			{
				this.eventHandler_5?.Invoke(this, htmlStylesheetLoadEventArgs_0);
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.CssParsing, "Failed stylesheet load event", exception_);
			}
		}

		internal void method_1(HtmlImageLoadEventArgs htmlImageLoadEventArgs_0)
		{
			try
			{
				this.eventHandler_6?.Invoke(this, htmlImageLoadEventArgs_0);
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.Image, "Failed image load event", exception_);
			}
		}

		public void RequestRefresh(bool layout)
		{
			try
			{
				this.eventHandler_2?.Invoke(this, new HtmlRefreshEventArgs(layout));
			}
			catch (Exception exception_)
			{
				this.method_2(HtmlRenderErrorType.General, "Failed refresh request", exception_);
			}
		}

		internal void method_2(HtmlRenderErrorType htmlRenderErrorType_0, string string_0, Exception exception_0 = null)
		{
			try
			{
				this.eventHandler_4?.Invoke(this, new HtmlRenderErrorEventArgs(htmlRenderErrorType_0, string_0, exception_0));
			}
			catch
			{
			}
		}

		internal void method_3(RControl rcontrol_0, RPoint rpoint_2, Class50 class50_1)
		{
			EventHandler<HtmlLinkClickedEventArgs> eventHandler = this.eventHandler_1;
			if (eventHandler != null)
			{
				HtmlLinkClickedEventArgs htmlLinkClickedEventArgs = new HtmlLinkClickedEventArgs(class50_1.String_65, class50_1.Class63_0.Dictionary_0);
				try
				{
					eventHandler(this, htmlLinkClickedEventArgs);
				}
				catch (Exception innerException)
				{
					throw new HtmlLinkClickedException("Error in link clicked intercept", innerException);
				}
				if (htmlLinkClickedEventArgs.Handled)
				{
					return;
				}
			}
			if (string.IsNullOrEmpty(class50_1.String_65))
			{
				return;
			}
			if (class50_1.String_65.StartsWith("#") && class50_1.String_65.Length > 1)
			{
				EventHandler<HtmlScrollEventArgs> eventHandler2 = this.eventHandler_3;
				if (eventHandler2 != null)
				{
					RRect? elementRectangle = this.GetElementRectangle(class50_1.String_65.Substring(1));
					if (elementRectangle.HasValue)
					{
						eventHandler2(this, new HtmlScrollEventArgs(elementRectangle.Value.Location));
						this.HandleMouseMove(rcontrol_0, rpoint_2);
					}
				}
			}
			else
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(class50_1.String_65);
				processStartInfo.UseShellExecute = true;
				Process.Start(processStartInfo);
			}
		}

		internal void method_4(Class50 class50_1, CssBlock cssBlock_0)
		{
			ArgChecker.AssertArgNotNull(class50_1, "box");
			ArgChecker.AssertArgNotNull(cssBlock_0, "block");
			if (this.list_0 == null)
			{
				this.list_0 = new List<Class62>();
			}
			this.list_0.Add(new Class62(class50_1, cssBlock_0));
		}

		internal Class41 method_5()
		{
			return this.class41_0;
		}

		public void Dispose()
		{
			this.method_8(bool_6: true);
		}

		private RPoint method_6(RPoint rpoint_2)
		{
			return new RPoint(rpoint_2.Double_0 - this.ScrollOffset.Double_0, rpoint_2.Double_1 - this.ScrollOffset.Double_1);
		}

		private bool method_7(RPoint rpoint_2)
		{
			return rpoint_2.Double_0 >= this.rpoint_0.Double_0 && rpoint_2.Double_0 <= this.rpoint_0.Double_0 + this.rsize_1.Width && rpoint_2.Double_1 >= this.rpoint_0.Double_1 + this.ScrollOffset.Double_1 && rpoint_2.Double_1 <= this.rpoint_0.Double_1 + this.ScrollOffset.Double_1 + this.rsize_1.Height;
		}

		private void method_8(bool bool_6)
		{
			try
			{
				if (bool_6)
				{
					this.eventHandler_1 = null;
					this.eventHandler_2 = null;
					this.eventHandler_4 = null;
					this.eventHandler_5 = null;
					this.eventHandler_6 = null;
				}
				this.cssData_0 = null;
				if (this.class50_0 != null)
				{
					this.class50_0.Dispose();
				}
				this.class50_0 = null;
				if (this.class45_0 != null)
				{
					this.class45_0.Dispose();
				}
				this.class45_0 = null;
			}
			catch
			{
			}
		}
	}
}

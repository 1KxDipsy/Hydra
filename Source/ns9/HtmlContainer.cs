using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ns0;
using ns10;
using ns11;
using ns13;
using ns15;
using ns16;

namespace ns9
{
	public sealed class HtmlContainer : IDisposable
	{
		private readonly HtmlContainerInt htmlContainerInt_0;

		private bool bool_0;

		public HtmlContainerInt HtmlContainerInt => this.htmlContainerInt_0;

		public bool UseGdiPlusTextRendering
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 != value)
				{
					this.bool_0 = value;
					this.htmlContainerInt_0.RequestRefresh(layout: true);
				}
			}
		}

		public CssData CssData => this.htmlContainerInt_0.CssData;

		public bool AvoidGeometryAntialias
		{
			get
			{
				return this.htmlContainerInt_0.AvoidGeometryAntialias;
			}
			set
			{
				this.htmlContainerInt_0.AvoidGeometryAntialias = value;
			}
		}

		public bool AvoidAsyncImagesLoading
		{
			get
			{
				return this.htmlContainerInt_0.AvoidAsyncImagesLoading;
			}
			set
			{
				this.htmlContainerInt_0.AvoidAsyncImagesLoading = value;
			}
		}

		public bool AvoidImagesLateLoading
		{
			get
			{
				return this.htmlContainerInt_0.AvoidImagesLateLoading;
			}
			set
			{
				this.htmlContainerInt_0.AvoidImagesLateLoading = value;
			}
		}

		public bool IsSelectionEnabled
		{
			get
			{
				return this.htmlContainerInt_0.IsSelectionEnabled;
			}
			set
			{
				this.htmlContainerInt_0.IsSelectionEnabled = value;
			}
		}

		public bool IsContextMenuEnabled
		{
			get
			{
				return this.htmlContainerInt_0.IsContextMenuEnabled;
			}
			set
			{
				this.htmlContainerInt_0.IsContextMenuEnabled = value;
			}
		}

		public Point ScrollOffset
		{
			get
			{
				return Class19.smethod_3(this.htmlContainerInt_0.ScrollOffset);
			}
			set
			{
				this.htmlContainerInt_0.ScrollOffset = Class19.smethod_0(value);
			}
		}

		public PointF Location
		{
			get
			{
				return Class19.smethod_2(this.htmlContainerInt_0.Location);
			}
			set
			{
				this.htmlContainerInt_0.Location = Class19.smethod_0(value);
			}
		}

		public SizeF MaxSize
		{
			get
			{
				return Class19.smethod_5(this.htmlContainerInt_0.MaxSize);
			}
			set
			{
				this.htmlContainerInt_0.MaxSize = Class19.smethod_4(value);
			}
		}

		public SizeF ActualSize
		{
			get
			{
				return Class19.smethod_5(this.htmlContainerInt_0.ActualSize);
			}
			internal set
			{
				this.htmlContainerInt_0.ActualSize = Class19.smethod_4(value);
			}
		}

		public string SelectedText => this.htmlContainerInt_0.SelectedText;

		public string SelectedHtml => this.htmlContainerInt_0.SelectedHtml;

		public event EventHandler LoadComplete
		{
			add
			{
				this.HtmlContainerInt.LoadComplete += value;
			}
			remove
			{
				this.HtmlContainerInt.LoadComplete -= value;
			}
		}

		public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked
		{
			add
			{
				this.htmlContainerInt_0.LinkClicked += value;
			}
			remove
			{
				this.htmlContainerInt_0.LinkClicked -= value;
			}
		}

		public event EventHandler<HtmlRefreshEventArgs> Refresh
		{
			add
			{
				this.htmlContainerInt_0.Refresh += value;
			}
			remove
			{
				this.htmlContainerInt_0.Refresh -= value;
			}
		}

		public event EventHandler<HtmlScrollEventArgs> ScrollChange
		{
			add
			{
				this.htmlContainerInt_0.ScrollChange += value;
			}
			remove
			{
				this.htmlContainerInt_0.ScrollChange -= value;
			}
		}

		public event EventHandler<HtmlRenderErrorEventArgs> RenderError
		{
			add
			{
				this.htmlContainerInt_0.RenderError += value;
			}
			remove
			{
				this.htmlContainerInt_0.RenderError -= value;
			}
		}

		public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad
		{
			add
			{
				this.htmlContainerInt_0.StylesheetLoad += value;
			}
			remove
			{
				this.htmlContainerInt_0.StylesheetLoad -= value;
			}
		}

		public event EventHandler<HtmlImageLoadEventArgs> ImageLoad
		{
			add
			{
				this.htmlContainerInt_0.ImageLoad += value;
			}
			remove
			{
				this.htmlContainerInt_0.ImageLoad -= value;
			}
		}

		public HtmlContainer()
		{
			this.htmlContainerInt_0 = new HtmlContainerInt(Class64.Class64_0);
			this.htmlContainerInt_0.SetMargins(0);
			this.htmlContainerInt_0.PageSize = new RSize(99999.0, 99999.0);
		}

		public void ClearSelection()
		{
			this.HtmlContainerInt.ClearSelection();
		}

		public void SetHtml(string htmlSource, CssData baseCssData = null)
		{
			this.htmlContainerInt_0.SetHtml(htmlSource, baseCssData);
		}

		public string GetHtml(HtmlGenerationStyle styleGen = HtmlGenerationStyle.Inline)
		{
			return this.htmlContainerInt_0.GetHtml(styleGen);
		}

		public string GetAttributeAt(Point location, string attribute)
		{
			return this.htmlContainerInt_0.GetAttributeAt(Class19.smethod_0(location), attribute);
		}

		public List<LinkElementData<RectangleF>> GetLinks()
		{
			List<LinkElementData<RectangleF>> list = new List<LinkElementData<RectangleF>>();
			foreach (LinkElementData<RRect> link in this.HtmlContainerInt.GetLinks())
			{
				list.Add(new LinkElementData<RectangleF>(link.Id, link.Href, Class19.smethod_8(link.Rectangle)));
			}
			return list;
		}

		public string GetLinkAt(Point location)
		{
			return this.htmlContainerInt_0.GetLinkAt(Class19.smethod_0(location));
		}

		public RectangleF? GetElementRectangle(string elementId)
		{
			RRect? elementRectangle = this.htmlContainerInt_0.GetElementRectangle(elementId);
			return elementRectangle.HasValue ? new RectangleF?(Class19.smethod_8(elementRectangle.Value)) : null;
		}

		public void PerformLayout(Graphics g)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			using GraphicsAdapter g2 = new GraphicsAdapter(g, this.bool_0);
			this.htmlContainerInt_0.PerformLayout(g2);
		}

		public void PerformPaint(Graphics g)
		{
			ArgChecker.AssertArgNotNull(g, "g");
			using GraphicsAdapter g2 = new GraphicsAdapter(g, this.bool_0);
			this.htmlContainerInt_0.PerformPaint(g2);
		}

		public void HandleMouseDown(Control parent, MouseEventArgs e)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			ArgChecker.AssertArgNotNull(e, "e");
			this.htmlContainerInt_0.HandleMouseDown(new Control2(parent, this.bool_0), Class19.smethod_0(e.Location));
		}

		public void HandleMouseUp(Control parent, MouseEventArgs e)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			ArgChecker.AssertArgNotNull(e, "e");
			this.htmlContainerInt_0.HandleMouseUp(new Control2(parent, this.bool_0), Class19.smethod_0(e.Location), HtmlContainer.smethod_0(e));
		}

		public void HandleMouseDoubleClick(Control parent, MouseEventArgs e)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			ArgChecker.AssertArgNotNull(e, "e");
			this.htmlContainerInt_0.HandleMouseDoubleClick(new Control2(parent, this.bool_0), Class19.smethod_0(e.Location));
		}

		public void HandleMouseMove(Control parent, MouseEventArgs e)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			ArgChecker.AssertArgNotNull(e, "e");
			this.htmlContainerInt_0.HandleMouseMove(new Control2(parent, this.bool_0), Class19.smethod_0(e.Location));
		}

		public void HandleMouseLeave(Control parent)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			this.htmlContainerInt_0.HandleMouseLeave(new Control2(parent, this.bool_0));
		}

		public void HandleKeyDown(Control parent, KeyEventArgs e)
		{
			ArgChecker.AssertArgNotNull(parent, "parent");
			ArgChecker.AssertArgNotNull(e, "e");
			this.htmlContainerInt_0.HandleKeyDown(new Control2(parent, this.bool_0), HtmlContainer.smethod_1(e));
		}

		public void Dispose()
		{
			this.htmlContainerInt_0.Dispose();
		}

		private static RMouseEvent smethod_0(MouseEventArgs mouseEventArgs_0)
		{
			return new RMouseEvent((mouseEventArgs_0.Button & MouseButtons.Left) != 0);
		}

		private static RKeyEvent smethod_1(KeyEventArgs keyEventArgs_0)
		{
			return new RKeyEvent(keyEventArgs_0.Control, keyEventArgs_0.KeyCode == Keys.A, keyEventArgs_0.KeyCode == Keys.C);
		}
	}
}

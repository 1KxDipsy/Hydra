using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns10;
using ns13;
using ns9;

namespace ns1
{
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ToolTip))]
	[DebuggerStepThrough]
	[Description("A tooltip control")]
	public class SiticoneToolTip : ToolTip
	{
		protected HtmlContainer _htmlContainer;

		protected string _baseRawCssData;

		protected CssData _baseCssData;

		protected TextRenderingHint _textRenderingHint = TextRenderingHint.SystemDefault;

		private string string_0 = "htmltooltip";

		private Control control_0;

		private System.Windows.Forms.Timer timer_0;

		private IntPtr intptr_0;

		private bool bool_0 = true;

		private Color color_0 = Class0.color_31;

		private Font font_0 = new Font("segoe ui", 9f);

		private Font font_1 = new Font("segoe ui", 9f, FontStyle.Bold);

		private Color color_1 = Class0.color_19;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<HtmlLinkClickedEventArgs> eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HtmlRenderErrorEventArgs> eventHandler_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_2;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<HtmlImageLoadEventArgs> eventHandler_3;

		[Description("The tooltip ForeColor")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "125, 137, 149")]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[Browsable(true)]
		[Description("The tooltip BackColor")]
		[DefaultValue(typeof(Color), "White")]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		[DefaultValue(typeof(Color), "213, 218, 223")]
		[Browsable(true)]
		[Description("The tooltip BorderColor")]
		public Color BorderColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
			}
		}

		[DefaultValue(typeof(Font), "Segoe UI, 9pt")]
		[Browsable(true)]
		[Description("The tooltip font style")]
		public Font Font
		{
			get
			{
				return this.font_0;
			}
			set
			{
				this.font_0 = value;
			}
		}

		[Description("The tooltip title font style")]
		[DefaultValue(typeof(Font), "Segoe UI, 9pt, style=Bold")]
		[Browsable(true)]
		public Font TitleFont
		{
			get
			{
				return this.font_1;
			}
			set
			{
				this.font_1 = value;
			}
		}

		[DefaultValue(typeof(Color), "94, 148, 255")]
		[Description("The tooltip title ForeColor")]
		[Browsable(true)]
		public Color TitleForeColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("If true, the tooltip will draw itself")]
		[Browsable(false)]
		public new bool OwnerDraw
		{
			[CompilerGenerated]
			get
			{
				return this.bool_1;
			}
			[CompilerGenerated]
			set
			{
				this.bool_1 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If to use GDI+ text rendering to measure/draw text, false - use GDI")]
		public bool UseGdiPlusTextRendering
		{
			get
			{
				return this._htmlContainer.UseGdiPlusTextRendering;
			}
			set
			{
				this._htmlContainer.UseGdiPlusTextRendering = value;
			}
		}

		[Description("The text rendering hint to be used for text rendering.")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Behavior")]
		[DefaultValue(TextRenderingHint.SystemDefault)]
		public TextRenderingHint TextRenderingHint
		{
			get
			{
				return this._textRenderingHint;
			}
			set
			{
				this._textRenderingHint = value;
			}
		}

		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[Category("Appearance")]
		[Description("Set base stylesheet to be used by html rendered in the tooltip.")]
		[Browsable(false)]
		internal virtual string String_0
		{
			get
			{
				return this._baseRawCssData;
			}
			set
			{
				this._baseRawCssData = value;
				this._baseCssData = HtmlRender.ParseStyleSheet(value);
			}
		}

		[Browsable(false)]
		[Category("Appearance")]
		[Description("The CSS class used for tooltip html root div.")]
		internal virtual string String_1
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If to handle links in the tooltip.")]
		[Browsable(true)]
		public virtual bool AllowLinksHandling
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

		[Category("Layout")]
		[Description("Restrict the max size of the shown tooltip (0 is not restricted)")]
		[Browsable(true)]
		public virtual Size MaximumSize
		{
			get
			{
				return Size.Round(this._htmlContainer.MaxSize);
			}
			set
			{
				this._htmlContainer.MaxSize = value;
			}
		}

		public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlLinkClickedEventArgs> eventHandler = this.eventHandler_0;
				EventHandler<HtmlLinkClickedEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlLinkClickedEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlLinkClickedEventArgs> eventHandler = this.eventHandler_0;
				EventHandler<HtmlLinkClickedEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlLinkClickedEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlRenderErrorEventArgs> RenderError
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlRenderErrorEventArgs> eventHandler = this.eventHandler_1;
				EventHandler<HtmlRenderErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlRenderErrorEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlRenderErrorEventArgs> eventHandler = this.eventHandler_1;
				EventHandler<HtmlRenderErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlRenderErrorEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler = this.eventHandler_2;
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlStylesheetLoadEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler = this.eventHandler_2;
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlStylesheetLoadEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlImageLoadEventArgs> ImageLoad
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlImageLoadEventArgs> eventHandler = this.eventHandler_3;
				EventHandler<HtmlImageLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlImageLoadEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlImageLoadEventArgs> eventHandler = this.eventHandler_3;
				EventHandler<HtmlImageLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlImageLoadEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public SiticoneToolTip()
		{
			base.OwnerDraw = true;
			this._htmlContainer = new HtmlContainer();
			this._htmlContainer.IsSelectionEnabled = false;
			this._htmlContainer.IsContextMenuEnabled = false;
			this._htmlContainer.AvoidGeometryAntialias = true;
			this._htmlContainer.AvoidImagesLateLoading = true;
			this._htmlContainer.RenderError += new EventHandler<HtmlRenderErrorEventArgs>(method_2);
			this._htmlContainer.StylesheetLoad += new EventHandler<HtmlStylesheetLoadEventArgs>(method_3);
			this._htmlContainer.ImageLoad += new EventHandler<HtmlImageLoadEventArgs>(method_4);
			this.BackColor = Color.White;
			this.ForeColor = Class0.color_29;
			base.Popup += new PopupEventHandler(SiticoneToolTip_Popup);
			base.Draw += new DrawToolTipEventHandler(SiticoneToolTip_Draw);
			base.Disposed += new EventHandler(SiticoneToolTip_Disposed);
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
			this.timer_0.Interval = 40;
			this._htmlContainer.LinkClicked += new EventHandler<HtmlLinkClickedEventArgs>(method_5);
			Class13.smethod_0();
		}

		public string ColorToHtml(Color color)
		{
			return string.Concat(new string[4]
			{
				"#",
				color.R.ToString("X2"),
				color.G.ToString("X2"),
				color.B.ToString("X2")
			});
		}

		internal string method_0(Color color_2)
		{
			return "rgb(" + color_2.R + "," + color_2.G + "," + color_2.B + ")";
		}

		private void method_1(string string_1, string string_2)
		{
			string text = ".basetooltip {\n            border: solid 1px {0};\n            background-color: {1};\n            padding: 8px; \n            } ".Replace("{0}", this.ColorToHtml(this.BorderColor)).Replace("{1}", this.ColorToHtml(base.BackColor));
			string text2 = string_2;
			if (string_2 != string.Empty)
			{
				text = string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text + "#default-tooltiptitle { ", "padding: 1.2px; "), "font-family: '{0}'; ".Replace("{0}", this.TitleFont.Name)), "font-size: {0}pt; ".Replace("{0}", this.TitleFont.SizeInPoints.ToString())), "width: 100%; "), "height: 100%; "), "font-style: normal; "), "font-weight: normal; "), "text-decoration: none; "), $"color: {this.ColorToHtml(this.TitleForeColor)}; "), "} ");
				if (this.TitleFont.Bold)
				{
					text2 = $"<b>{text2}</b>";
				}
				if (this.TitleFont.Italic)
				{
					text2 = $"<i>{text2}</i>";
				}
				if (this.TitleFont.Underline)
				{
					text2 = $"<u>{text2}</u>";
				}
				if (this.TitleFont.Strikeout)
				{
					text2 = $"<del>{text2}</del>";
				}
				text2 = "<div id=\"default-tooltiptitle\">" + text2 + "</div>";
			}
			text = string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text + "#default-tooltiptext { ", "padding: 1.2px; "), "font-family: '{0}'; ".Replace("{0}", this.Font.Name)), "font-size: {0}pt; ".Replace("{0}", this.Font.SizeInPoints.ToString())), "width: 100%; "), "height: 100%; "), "font-style: normal; "), "font-weight: normal; "), "text-decoration: none; "), $"color: {this.ColorToHtml(this.ForeColor)}; "), "} ");
			string text3 = string_1;
			if (this.Font.Bold)
			{
				text3 = $"<b>{text3}</b>";
			}
			if (this.Font.Italic)
			{
				text3 = $"<i>{text3}</i>";
			}
			if (this.Font.Underline)
			{
				text3 = $"<u>{text3}</u>";
			}
			if (this.Font.Strikeout)
			{
				text3 = $"<del>{text3}</del>";
			}
			text3 = "<div id=\"default-tooltiptext\">" + text3 + "</div>";
			this._baseRawCssData = text;
			this._baseCssData = HtmlRender.ParseStyleSheet(this._baseRawCssData);
			this._htmlContainer.SetHtml($"<div class=\"basetooltip\">{text2 + text3}</div>", this._baseCssData);
		}

		protected virtual void OnToolTipPopup(PopupEventArgs e)
		{
			this.method_1(base.GetToolTip(e.AssociatedControl), base.ToolTipTitle);
			this._htmlContainer.MaxSize = this.MaximumSize;
			using (Graphics graphics = e.AssociatedControl.CreateGraphics())
			{
				graphics.TextRenderingHint = this._textRenderingHint;
				this._htmlContainer.PerformLayout(graphics);
			}
			e.ToolTipSize = new Size((int)Math.Ceiling((this.MaximumSize.Width > 0) ? Math.Min(this._htmlContainer.ActualSize.Width, this.MaximumSize.Width) : this._htmlContainer.ActualSize.Width), (int)Math.Ceiling((this.MaximumSize.Height > 0) ? Math.Min(this._htmlContainer.ActualSize.Height, this.MaximumSize.Height) : this._htmlContainer.ActualSize.Height));
			if (this.bool_0)
			{
				this.control_0 = e.AssociatedControl;
				this.timer_0.Start();
			}
		}

		protected virtual void OnToolTipDraw(DrawToolTipEventArgs e)
		{
			if (this.intptr_0 == IntPtr.Zero)
			{
				IntPtr hdc = e.Graphics.GetHdc();
				this.intptr_0 = Class20.WindowFromDC(hdc);
				e.Graphics.ReleaseHdc(hdc);
				this.AdjustTooltipPosition(e.AssociatedControl, e.Bounds.Size);
			}
			e.Graphics.Clear(Color.White);
			e.Graphics.TextRenderingHint = this._textRenderingHint;
			this._htmlContainer.PerformPaint(e.Graphics);
		}

		protected virtual void AdjustTooltipPosition(Control associatedControl, Size size)
		{
			Point mousePosition = Control.MousePosition;
			Rectangle workingArea = Screen.FromControl(associatedControl).WorkingArea;
			if (mousePosition.X + size.Width > workingArea.Right)
			{
				mousePosition.X = Math.Max(workingArea.Right - size.Width - 5, workingArea.Left + 3);
			}
			if (mousePosition.Y + size.Height + 20 > workingArea.Bottom)
			{
				mousePosition.Y = Math.Max(workingArea.Bottom - size.Height - 20 - 3, workingArea.Top + 2);
			}
			Class20.MoveWindow(this.intptr_0, mousePosition.X, mousePosition.Y + 20, size.Width, size.Height, bool_0: false);
		}

		protected virtual void OnLinkClicked(HtmlLinkClickedEventArgs e)
		{
			this.eventHandler_0?.Invoke(this, e);
		}

		protected virtual void OnRenderError(HtmlRenderErrorEventArgs e)
		{
			this.eventHandler_1?.Invoke(this, e);
		}

		protected virtual void OnStylesheetLoad(HtmlStylesheetLoadEventArgs e)
		{
			this.eventHandler_2?.Invoke(this, e);
		}

		protected virtual void OnImageLoad(HtmlImageLoadEventArgs e)
		{
			this.eventHandler_3?.Invoke(this, e);
		}

		protected virtual void OnLinkHandlingTimerTick(EventArgs e)
		{
			try
			{
				IntPtr intPtr = this.intptr_0;
				if (intPtr != IntPtr.Zero && Class20.IsWindowVisible(intPtr))
				{
					Point mousePosition = Control.MousePosition;
					MouseButtons mouseButtons = Control.MouseButtons;
					Rectangle rectangle = Class20.smethod_2(intPtr);
					if (rectangle.Contains(mousePosition))
					{
						this._htmlContainer.HandleMouseMove(this.control_0, new MouseEventArgs(mouseButtons, 0, mousePosition.X - rectangle.X, mousePosition.Y - rectangle.Y, 0));
					}
					return;
				}
				this.timer_0.Stop();
				this.intptr_0 = IntPtr.Zero;
				Point mousePosition2 = Control.MousePosition;
				MouseButtons mouseButtons2 = Control.MouseButtons;
				Rectangle rectangle2 = Class20.smethod_2(intPtr);
				if (rectangle2.Contains(mousePosition2) && mouseButtons2 == MouseButtons.Left)
				{
					MouseEventArgs e2 = new MouseEventArgs(mouseButtons2, 1, mousePosition2.X - rectangle2.X, mousePosition2.Y - rectangle2.Y, 0);
					this._htmlContainer.HandleMouseDown(this.control_0, e2);
					this._htmlContainer.HandleMouseUp(this.control_0, e2);
				}
			}
			catch (Exception exception)
			{
				this.method_2(this, new HtmlRenderErrorEventArgs(HtmlRenderErrorType.General, "Error in link handling for tooltip", exception));
			}
		}

		protected virtual void OnToolTipDisposed(EventArgs e)
		{
			base.Popup -= new PopupEventHandler(SiticoneToolTip_Popup);
			base.Draw -= new DrawToolTipEventHandler(SiticoneToolTip_Draw);
			base.Disposed -= new EventHandler(SiticoneToolTip_Disposed);
			if (this._htmlContainer != null)
			{
				this._htmlContainer.RenderError -= new EventHandler<HtmlRenderErrorEventArgs>(method_2);
				this._htmlContainer.StylesheetLoad -= new EventHandler<HtmlStylesheetLoadEventArgs>(method_3);
				this._htmlContainer.ImageLoad -= new EventHandler<HtmlImageLoadEventArgs>(method_4);
				this._htmlContainer.Dispose();
				this._htmlContainer = null;
			}
			if (this.timer_0 != null)
			{
				this.timer_0.Dispose();
				this.timer_0 = null;
				if (this._htmlContainer != null)
				{
					this._htmlContainer.LinkClicked -= new EventHandler<HtmlLinkClickedEventArgs>(method_5);
				}
			}
		}

		private void SiticoneToolTip_Popup(object sender, PopupEventArgs e)
		{
			this.OnToolTipPopup(e);
		}

		private void SiticoneToolTip_Draw(object sender, DrawToolTipEventArgs e)
		{
			this.OnToolTipDraw(e);
		}

		private void method_2(object sender, HtmlRenderErrorEventArgs e)
		{
			this.OnRenderError(e);
		}

		private void method_3(object sender, HtmlStylesheetLoadEventArgs e)
		{
			this.OnStylesheetLoad(e);
		}

		private void method_4(object sender, HtmlImageLoadEventArgs e)
		{
			this.OnImageLoad(e);
		}

		private void method_5(object sender, HtmlLinkClickedEventArgs e)
		{
			this.OnLinkClicked(e);
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.OnLinkHandlingTimerTick(e);
		}

		private void SiticoneToolTip_Disposed(object sender, EventArgs e)
		{
			this.OnToolTipDisposed(e);
		}
	}
}

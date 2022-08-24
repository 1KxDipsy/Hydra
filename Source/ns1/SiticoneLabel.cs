using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns10;
using ns13;
using ns15;
using ns16;
using ns9;

namespace ns1
{
	[ToolboxBitmap(typeof(Label))]
	[Description("Label control that supports html tags. See our YouTube tutorials to learn more")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	public class SiticoneLabel : Control
	{
		[CompilerGenerated]
		private sealed class Class3
		{
			public HtmlRenderErrorEventArgs htmlRenderErrorEventArgs_0;

			public SiticoneLabel siticoneLabel_0;

			internal void method_0()
			{
				this.siticoneLabel_0.OnRenderError(this.htmlRenderErrorEventArgs_0);
			}
		}

		[CompilerGenerated]
		private sealed class Class4
		{
			public HtmlRefreshEventArgs htmlRefreshEventArgs_0;

			public SiticoneLabel siticoneLabel_0;

			internal void method_0()
			{
				this.siticoneLabel_0.OnRefresh(this.htmlRefreshEventArgs_0);
			}
		}

		protected HtmlContainer _htmlContainer;

		protected BorderStyle _borderStyle;

		protected string _baseRawCssData;

		protected CssData _baseCssData;

		protected string _text;

		protected bool _autoSizeHight;

		protected bool _useSystemCursors;

		protected TextRenderingHint _textRenderingHint = TextRenderingHint.SystemDefault;

		private bool bool_0 = false;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HtmlLinkClickedEventArgs> eventHandler_2;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<HtmlRenderErrorEventArgs> eventHandler_3;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_4;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<HtmlImageLoadEventArgs> eventHandler_5;

		private ContentAlignment contentAlignment_0 = ContentAlignment.TopLeft;

		[Description("If anti-aliasing should be avoided for geometry like backgrounds and borders")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public virtual bool AvoidGeometryAntialias
		{
			get
			{
				return this._htmlContainer.AvoidGeometryAntialias;
			}
			set
			{
				this._htmlContainer.AvoidGeometryAntialias = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("If to use GDI+ text rendering to measure/draw text, false - use GDI")]
		[Category("Behavior")]
		[DefaultValue(false)]
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
		[DefaultValue(TextRenderingHint.SystemDefault)]
		[Category("Behavior")]
		[EditorBrowsable(EditorBrowsableState.Always)]
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

		[Description("If to use cursors defined by the operating system or .NET cursors")]
		[Category("Behavior")]
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public bool UseSystemCursors
		{
			get
			{
				return this._useSystemCursors;
			}
			set
			{
				this._useSystemCursors = value;
			}
		}

		[DefaultValue(typeof(BorderStyle), "None")]
		[Category("Appearance")]
		public virtual BorderStyle BorderStyle
		{
			get
			{
				return this._borderStyle;
			}
			set
			{
				if (this.BorderStyle != value)
				{
					this._borderStyle = value;
					this.OnBorderStyleChanged(EventArgs.Empty);
				}
			}
		}

		[Description("Is content selection is enabled for the rendered html.")]
		[DefaultValue(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Behavior")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		public virtual bool IsSelectionEnabled
		{
			get
			{
				return this._htmlContainer.IsSelectionEnabled;
			}
			set
			{
				this._htmlContainer.IsSelectionEnabled = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Behavior")]
		[Description("Is the build-in context menu enabled and will be shown on mouse right click.")]
		[Browsable(true)]
		[DefaultValue(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public virtual bool IsContextMenuEnabled
		{
			get
			{
				return this._htmlContainer.IsContextMenuEnabled;
			}
			set
			{
				this._htmlContainer.IsContextMenuEnabled = value;
			}
		}

		[Description("Set base stylesheet to be used by html rendered in the control.")]
		[Category("Appearance")]
		[Browsable(true)]
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
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
				this._htmlContainer.SetHtml(this._text, this._baseCssData);
			}
		}

		[Description("Automatically sets the size of the label by content size.")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(true)]
		[Browsable(true)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
				if (value)
				{
					this._autoSizeHight = false;
					base.PerformLayout();
					base.Invalidate();
				}
			}
		}

		[Category("Layout")]
		[Description("Automatically sets the height of the label by content height (width is not effected)")]
		[DefaultValue(false)]
		[Browsable(true)]
		public virtual bool AutoSizeHeightOnly
		{
			get
			{
				return this._autoSizeHight;
			}
			set
			{
				this._autoSizeHight = value;
				if (value)
				{
					this.AutoSize = false;
					base.PerformLayout();
					base.Invalidate();
				}
			}
		}

		[Description("If AutoSize or AutoSizeHeightOnly is set this will restrict the max size of the control (0 is not restricted)")]
		public override Size MaximumSize
		{
			get
			{
				return base.MaximumSize;
			}
			set
			{
				base.MaximumSize = value;
				if (this._htmlContainer != null)
				{
					this._htmlContainer.MaxSize = value;
					base.PerformLayout();
					base.Invalidate();
				}
			}
		}

		[Description("If AutoSize or AutoSizeHeightOnly is set this will restrict the min size of the control (0 is not restricted)")]
		public override Size MinimumSize
		{
			get
			{
				return base.MinimumSize;
			}
			set
			{
				base.MinimumSize = value;
			}
		}

		[Description("Sets the html of this control.")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public override string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				this._text = value;
				base.Text = value;
				this.method_1();
			}
		}

		[Browsable(true)]
		[DisplayName("TextAlign")]
		[Description("Determines the position of the text within the label. Referred to as 'TextAlignment' when using it in code.")]
		[DefaultValue(ContentAlignment.TopLeft)]
		public ContentAlignment TextAlignment
		{
			get
			{
				return this.contentAlignment_0;
			}
			set
			{
				this.contentAlignment_0 = value;
				this.method_1();
			}
		}

		[Browsable(true)]
		[Description("Gets or sets the foreground color of the control")]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
				this.method_1();
			}
		}

		[Browsable(true)]
		[Description("Gets or sets the font of the text displayed by the control")]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				this.method_1();
			}
		}

		[Browsable(false)]
		public virtual string SelectedText => this._htmlContainer.SelectedText;

		[Browsable(false)]
		public virtual string SelectedHtml => this._htmlContainer.SelectedHtml;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				switch (this._borderStyle)
				{
				case BorderStyle.Fixed3D:
					createParams.ExStyle |= 512;
					break;
				case BorderStyle.FixedSingle:
					createParams.Style |= 8388608;
					break;
				}
				return createParams;
			}
		}

		[Browsable(false)]
		public override bool AllowDrop
		{
			get
			{
				return base.AllowDrop;
			}
			set
			{
				base.AllowDrop = value;
			}
		}

		[Browsable(false)]
		public override RightToLeft RightToLeft
		{
			get
			{
				return base.RightToLeft;
			}
			set
			{
				base.RightToLeft = value;
			}
		}

		[Browsable(false)]
		public override Cursor Cursor
		{
			get
			{
				return base.Cursor;
			}
			set
			{
				base.Cursor = value;
			}
		}

		[Browsable(false)]
		public new bool UseWaitCursor
		{
			get
			{
				return base.UseWaitCursor;
			}
			set
			{
				base.UseWaitCursor = value;
			}
		}

		[Category("Property Changed")]
		public event EventHandler BorderStyleChanged
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

		public event EventHandler LoadComplete
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlLinkClickedEventArgs> eventHandler = this.eventHandler_2;
				EventHandler<HtmlLinkClickedEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlLinkClickedEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlLinkClickedEventArgs> eventHandler = this.eventHandler_2;
				EventHandler<HtmlLinkClickedEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlLinkClickedEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlRenderErrorEventArgs> RenderError
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlRenderErrorEventArgs> eventHandler = this.eventHandler_3;
				EventHandler<HtmlRenderErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlRenderErrorEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlRenderErrorEventArgs> eventHandler = this.eventHandler_3;
				EventHandler<HtmlRenderErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlRenderErrorEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler = this.eventHandler_4;
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlStylesheetLoadEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_4, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler = this.eventHandler_4;
				EventHandler<HtmlStylesheetLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlStylesheetLoadEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_4, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<HtmlImageLoadEventArgs> ImageLoad
		{
			[CompilerGenerated]
			add
			{
				EventHandler<HtmlImageLoadEventArgs> eventHandler = this.eventHandler_5;
				EventHandler<HtmlImageLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlImageLoadEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_5, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<HtmlImageLoadEventArgs> eventHandler = this.eventHandler_5;
				EventHandler<HtmlImageLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<HtmlImageLoadEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_5, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public SiticoneLabel()
		{
			base.SuspendLayout();
			this.AutoSize = true;
			this.DoubleBuffered = true;
			base.SetStyle(ControlStyles.ResizeRedraw, value: true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			base.SetStyle(ControlStyles.Opaque, value: false);
			this.BackColor = Color.Transparent;
			this._htmlContainer = new HtmlContainer();
			this._htmlContainer.AvoidImagesLateLoading = true;
			this._htmlContainer.MaxSize = this.MaximumSize;
			this._htmlContainer.LoadComplete += new EventHandler(_htmlContainer_LoadComplete);
			this._htmlContainer.LinkClicked += new EventHandler<HtmlLinkClickedEventArgs>(method_2);
			this._htmlContainer.RenderError += new EventHandler<HtmlRenderErrorEventArgs>(method_3);
			this._htmlContainer.Refresh += new EventHandler<HtmlRefreshEventArgs>(method_6);
			this._htmlContainer.StylesheetLoad += new EventHandler<HtmlStylesheetLoadEventArgs>(method_4);
			this._htmlContainer.ImageLoad += new EventHandler<HtmlImageLoadEventArgs>(method_5);
			base.ResumeLayout(performLayout: false);
			this.bool_0 = true;
			Class13.smethod_0();
		}

		public virtual string GetHtml()
		{
			return (this._htmlContainer != null) ? this._htmlContainer.GetHtml() : null;
		}

		public virtual RectangleF? GetElementRectangle(string elementId)
		{
			return (this._htmlContainer != null) ? this._htmlContainer.GetElementRectangle(elementId) : null;
		}

		public void ClearSelection()
		{
			if (this._htmlContainer != null)
			{
				this._htmlContainer.ClearSelection();
			}
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

		internal string method_0(Color color_0)
		{
			return "rgb(" + color_0.R + "," + color_0.G + "," + color_0.B + ")";
		}

		private void method_1()
		{
			if (base.IsDisposed)
			{
				return;
			}
			if (this.bool_0)
			{
				int num = 0;
				string newValue = "left";
				string text = this.TextAlignment.ToString();
				int num2 = (this.AutoSize ? (TextRenderer.MeasureText(this.Text, this.Font).Height - 1) : ((int)Math.Round(base.CreateGraphics().MeasureString(this.Text, this.Font, base.Width).Height)));
				string text2 = " #default-label { " + "padding: 1.2px; ";
				if (!this.AutoSize)
				{
					text2 += "margin: auto; ";
					if (text.Contains("Middle"))
					{
						num = (int)Math.Round((double)base.Height / 2.0) - (int)Math.Round((double)num2 / 2.0);
					}
					if (text.Contains("Bottom"))
					{
						num = base.Height - num2;
					}
					if (text.Contains("Top"))
					{
						num = 0;
					}
					text2 += "padding-top: {0}px;".Replace("{0}", num.ToString());
				}
				if (text.Contains("Left"))
				{
					newValue = "left";
				}
				if (text.Contains("Right"))
				{
					newValue = "right";
				}
				if (text.Contains("Center"))
				{
					newValue = "center";
				}
				text2 = string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text2 + "font-family: '{0}'; ".Replace("{0}", this.Font.Name), "font-size: {0}pt; ".Replace("{0}", this.Font.SizeInPoints.ToString())), "width: 100%; "), "height: 100%; "), "font-style: normal; "), "font-weight: normal; "), "text-decoration: none; "), "text-align: {0}; ".Replace("{0}", newValue)), $"color: {this.ColorToHtml(this.ForeColor)}; "), "}");
				string text3 = this._text;
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
				text3 = "<div id=\"default-label\">" + text3 + "</div>";
				this._baseRawCssData = text2;
				this._baseCssData = HtmlRender.ParseStyleSheet(this._baseRawCssData);
				this._htmlContainer.SetHtml(text3, this._baseCssData);
			}
			base.PerformLayout();
			base.Invalidate();
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			if (this._htmlContainer != null)
			{
				Graphics graphics = Class19.smethod_12(this);
				if (graphics != null)
				{
					using (graphics)
					{
						using GraphicsAdapter g = new GraphicsAdapter(graphics, this._htmlContainer.UseGdiPlusTextRendering);
						RSize rSize = HtmlRendererUtils.Layout(g, this._htmlContainer.HtmlContainerInt, new RSize(base.ClientSize.Width - base.Padding.Horizontal, base.ClientSize.Height - base.Padding.Vertical), new RSize(this.MinimumSize.Width - base.Padding.Horizontal, this.MinimumSize.Height - base.Padding.Vertical), new RSize(this.MaximumSize.Width - base.Padding.Horizontal, this.MaximumSize.Height - base.Padding.Vertical), this.AutoSize, this.AutoSizeHeightOnly);
						base.ClientSize = Class19.smethod_6(new RSize(rSize.Width + (double)base.Padding.Horizontal, rSize.Height + (double)base.Padding.Vertical));
					}
				}
			}
			base.OnLayout(levent);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this._htmlContainer != null)
			{
				e.Graphics.TextRenderingHint = this._textRenderingHint;
				this._htmlContainer.Location = new PointF(base.Padding.Left, base.Padding.Top);
				this._htmlContainer.PerformPaint(e.Graphics);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this._htmlContainer != null)
			{
				this._htmlContainer.HandleMouseMove(this, e);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (this._htmlContainer != null)
			{
				this._htmlContainer.HandleMouseDown(this, e);
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (this._htmlContainer != null)
			{
				this._htmlContainer.HandleMouseLeave(this);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (this._htmlContainer != null)
			{
				this._htmlContainer.HandleMouseUp(this, e);
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
			if (this._htmlContainer != null)
			{
				this._htmlContainer.HandleMouseDoubleClick(this, e);
			}
		}

		protected virtual void OnBorderStyleChanged(EventArgs e)
		{
			base.UpdateStyles();
			this.eventHandler_0?.Invoke(this, e);
		}

		protected virtual void OnLoadComplete(EventArgs e)
		{
			this.eventHandler_1?.Invoke(this, e);
		}

		protected virtual void OnLinkClicked(HtmlLinkClickedEventArgs e)
		{
			this.eventHandler_2?.Invoke(this, e);
		}

		protected virtual void OnRenderError(HtmlRenderErrorEventArgs e)
		{
			this.eventHandler_3?.Invoke(this, e);
		}

		protected virtual void OnStylesheetLoad(HtmlStylesheetLoadEventArgs e)
		{
			this.eventHandler_4?.Invoke(this, e);
		}

		protected virtual void OnImageLoad(HtmlImageLoadEventArgs e)
		{
			this.eventHandler_5?.Invoke(this, e);
		}

		protected virtual void OnRefresh(HtmlRefreshEventArgs e)
		{
			if (e.Layout)
			{
				base.PerformLayout();
			}
			base.Invalidate();
		}

		[DebuggerStepThrough]
		protected override void WndProc(ref Message m)
		{
			if (this._useSystemCursors && m.Msg == 32 && this.Cursor == Cursors.Hand)
			{
				try
				{
					Class20.SetCursor(Class20.LoadCursor(0, 32649));
					m.Result = IntPtr.Zero;
					return;
				}
				catch (Exception exception)
				{
					this.method_3(this, new HtmlRenderErrorEventArgs(HtmlRenderErrorType.General, "Failed to set OS hand cursor", exception));
				}
			}
			base.WndProc(ref m);
		}

		protected override void Dispose(bool disposing)
		{
			if (this._htmlContainer != null)
			{
				this._htmlContainer.LoadComplete -= new EventHandler(_htmlContainer_LoadComplete);
				this._htmlContainer.LinkClicked -= new EventHandler<HtmlLinkClickedEventArgs>(method_2);
				this._htmlContainer.RenderError -= new EventHandler<HtmlRenderErrorEventArgs>(method_3);
				this._htmlContainer.Refresh -= new EventHandler<HtmlRefreshEventArgs>(method_6);
				this._htmlContainer.StylesheetLoad -= new EventHandler<HtmlStylesheetLoadEventArgs>(method_4);
				this._htmlContainer.ImageLoad -= new EventHandler<HtmlImageLoadEventArgs>(method_5);
				this._htmlContainer.Dispose();
				this._htmlContainer = null;
			}
			base.Dispose(disposing);
		}

		private void _htmlContainer_LoadComplete(object sender, EventArgs e)
		{
			this.OnLoadComplete(e);
		}

		private void method_2(object sender, HtmlLinkClickedEventArgs e)
		{
			this.OnLinkClicked(e);
		}

		private void method_3(object sender, HtmlRenderErrorEventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke((MethodInvoker)delegate
				{
					this.OnRenderError(e);
				});
			}
			else
			{
				this.OnRenderError(e);
			}
		}

		private void method_4(object sender, HtmlStylesheetLoadEventArgs e)
		{
			this.OnStylesheetLoad(e);
		}

		private void method_5(object sender, HtmlImageLoadEventArgs e)
		{
			this.OnImageLoad(e);
		}

		private void method_6(object sender, HtmlRefreshEventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke((MethodInvoker)delegate
				{
					this.OnRefresh(e);
				});
			}
			else
			{
				this.OnRefresh(e);
			}
		}
	}
}

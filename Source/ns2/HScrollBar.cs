using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using ns3;

namespace ns2
{
	[DefaultProperty("Value")]
	[DefaultEvent("Scroll")]
	[ToolboxItem(false)]
	public class HScrollBar : UserControl, IControl
	{
		private IContainer icontainer_0 = null;

		private ScrollBar owner;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Padding padding_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private ScrollEventHandler scrollEventHandler_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_2;

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ScrollBarState DefaultHoveredState
		{
			get
			{
				return this.owner.DefaultHoveredState;
			}
			set
			{
				this.owner.DefaultHoveredState = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ScrollBarState DefaultPressedState
		{
			get
			{
				return this.owner.DefaultPressedState;
			}
			set
			{
				this.owner.DefaultPressedState = value;
			}
		}

		public new Padding Padding
		{
			[CompilerGenerated]
			get
			{
				return this.padding_0;
			}
			[CompilerGenerated]
			set
			{
				this.padding_0 = value;
			}
		}

		[Browsable(false)]
		protected int DefaultBorderRadius
		{
			get
			{
				return this.owner.BorderRadius;
			}
			set
			{
				this.owner.BorderRadius = value;
			}
		}

		[Browsable(false)]
		protected int DefaultMouseWheelBarPartitions
		{
			get
			{
				return this.owner.MouseWheelBarPartitions;
			}
			set
			{
				this.owner.MouseWheelBarPartitions = value;
			}
		}

		[Browsable(false)]
		protected int DefaultScrollbarSize
		{
			get
			{
				return this.owner.ScrollbarSize;
			}
			set
			{
				this.owner.ScrollbarSize = value;
			}
		}

		[Browsable(false)]
		protected float DefaultThumbSize
		{
			get
			{
				return this.owner.ThumbSize;
			}
			set
			{
				this.owner.ThumbSize = value;
			}
		}

		[Browsable(false)]
		protected bool DefaultHighlightOnWheel
		{
			get
			{
				return this.owner.HighlightOnWheel;
			}
			set
			{
				this.owner.HighlightOnWheel = value;
			}
		}

		[Browsable(false)]
		protected int DefaultMinimum
		{
			get
			{
				return this.owner.Minimum;
			}
			set
			{
				if (this.owner.Minimum != value)
				{
					this.OnMinimumChanged(EventArgs.Empty);
				}
				this.owner.Minimum = value;
			}
		}

		[Browsable(false)]
		protected int DefaultMaximum
		{
			get
			{
				return this.owner.Maximum;
			}
			set
			{
				if (this.owner.Maximum != value)
				{
					this.OnMaximumChanged(EventArgs.Empty);
				}
				this.owner.Maximum = value;
			}
		}

		[Browsable(false)]
		protected int DefaultSmallChange
		{
			get
			{
				return this.owner.SmallChange;
			}
			set
			{
				this.owner.SmallChange = value;
			}
		}

		[Browsable(false)]
		protected int DefaultLargeChange
		{
			get
			{
				return this.owner.LargeChange;
			}
			set
			{
				this.owner.LargeChange = value;
			}
		}

		[Browsable(false)]
		protected Color DefaultThumbColor
		{
			get
			{
				return this.owner.ThumbColor;
			}
			set
			{
				this.owner.ThumbColor = value;
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor
		{
			get
			{
				return this.owner.FillColor;
			}
			set
			{
				this.owner.FillColor = value;
			}
		}

		[Browsable(false)]
		protected int DefaultValue
		{
			get
			{
				return this.owner.Value;
			}
			set
			{
				this.owner.Value = value;
			}
		}

		[Browsable(false)]
		protected Padding DefaultFillOffset
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		public event EventHandler MaximumChanged
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

		public event EventHandler MinimumChanged
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

		public new event ScrollEventHandler Scroll
		{
			[CompilerGenerated]
			add
			{
				ScrollEventHandler scrollEventHandler = this.scrollEventHandler_0;
				ScrollEventHandler scrollEventHandler2;
				do
				{
					scrollEventHandler2 = scrollEventHandler;
					scrollEventHandler = Interlocked.CompareExchange(value: (ScrollEventHandler)Delegate.Combine(scrollEventHandler2, value), location1: ref this.scrollEventHandler_0, comparand: scrollEventHandler2);
				}
				while ((object)scrollEventHandler != scrollEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ScrollEventHandler scrollEventHandler = this.scrollEventHandler_0;
				ScrollEventHandler scrollEventHandler2;
				do
				{
					scrollEventHandler2 = scrollEventHandler;
					scrollEventHandler = Interlocked.CompareExchange(value: (ScrollEventHandler)Delegate.Remove(scrollEventHandler2, value), location1: ref this.scrollEventHandler_0, comparand: scrollEventHandler2);
				}
				while ((object)scrollEventHandler != scrollEventHandler2);
			}
		}

		public event EventHandler ValueChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public HScrollBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.InitializeComponent();
			this.owner.DefaultPressedState.Parent = this;
			this.owner.DefaultPressedState.Parent = this;
			if (((uint)this.CreateParams.Style & (true ? 1u : 0u)) != 0)
			{
				base.Size = new Size(18, 300);
				this.owner.method_1(ScrollOrientation.VerticalScroll);
			}
			else
			{
				base.Size = new Size(300, 18);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.owner = new ns2.ScrollBar();
			base.SuspendLayout();
			this.owner.BackColor = System.Drawing.Color.Transparent;
			this.owner.Dock = System.Windows.Forms.DockStyle.Fill;
			this.owner.FillColor = System.Drawing.Color.FromArgb(213, 218, 223);
			this.owner.LargeChange = 10;
			this.owner.Location = new System.Drawing.Point(0, 0);
			this.owner.Maximum = 100;
			this.owner.Minimum = 0;
			this.owner.MouseWheelBarPartitions = 10;
			this.owner.Name = "owner";
			this.owner.ScrollbarSize = 26;
			this.owner.Size = new System.Drawing.Size(421, 26);
			this.owner.TabIndex = 0;
			this.owner.ThumbColor = System.Drawing.Color.FromArgb(139, 152, 166);
			this.owner.Scroll += new System.Windows.Forms.ScrollEventHandler(owner_Scroll);
			this.owner.ValueChanged += new System.EventHandler(owner_ValueChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.owner);
			base.Name = "G2HScrollBar";
			base.Size = new System.Drawing.Size(421, 26);
			base.ResumeLayout(false);
		}

		public bool HitTest(Point point)
		{
			return this.owner.HitTest(point);
		}

		[SecuritySafeCritical]
		public void BeginUpdate()
		{
			this.owner.BeginUpdate();
		}

		[SecuritySafeCritical]
		public void EndUpdate()
		{
			this.owner.EndUpdate();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMaximumChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMinimumChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, EventArgs.Empty);
			}
		}

		protected virtual void OnScrollChanged(ScrollEventArgs e)
		{
			base.Invalidate();
			if (this.scrollEventHandler_0 != null)
			{
				this.scrollEventHandler_0(this, e);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValueChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, e);
			}
		}

		private void owner_Scroll(object sender, ScrollEventArgs e)
		{
			this.OnScrollChanged(e);
		}

		private void owner_ValueChanged(object sender, EventArgs e)
		{
			this.OnValueChanged(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.Invalidate();
			if (this.owner != null)
			{
				this.owner.Invalidate();
			}
			base.OnResize(e);
		}
	}
}

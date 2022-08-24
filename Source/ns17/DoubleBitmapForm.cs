using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ns17
{
	public class DoubleBitmapForm : Form, IFakeControl
	{
		private Bitmap bitmap_0;

		private Bitmap bitmap_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<TransfromNeededEventArg> eventHandler_0;

		private Padding padding_0;

		private Control control_0;

		private Point point_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<PaintEventArgs> eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<PaintEventArgs> eventHandler_2;

		private IContainer icontainer_0 = null;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style = int.MinValue;
				createParams.ExStyle |= 134217856;
				createParams.X = base.Location.X;
				createParams.Y = base.Location.Y;
				return createParams;
			}
		}

		public Bitmap BgBmp
		{
			get
			{
				return this.bitmap_0;
			}
			set
			{
				this.bitmap_0 = value;
			}
		}

		public Bitmap Frame
		{
			get
			{
				return this.bitmap_1;
			}
			set
			{
				this.bitmap_1 = value;
			}
		}

		public event EventHandler<TransfromNeededEventArg> TransfromNeeded
		{
			[CompilerGenerated]
			add
			{
				EventHandler<TransfromNeededEventArg> eventHandler = this.eventHandler_0;
				EventHandler<TransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<TransfromNeededEventArg>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<TransfromNeededEventArg> eventHandler = this.eventHandler_0;
				EventHandler<TransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<TransfromNeededEventArg>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<PaintEventArgs> FramePainting
		{
			[CompilerGenerated]
			add
			{
				EventHandler<PaintEventArgs> eventHandler = this.eventHandler_1;
				EventHandler<PaintEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<PaintEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<PaintEventArgs> eventHandler = this.eventHandler_1;
				EventHandler<PaintEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<PaintEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<PaintEventArgs> FramePainted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<PaintEventArgs> eventHandler = this.eventHandler_2;
				EventHandler<PaintEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<PaintEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<PaintEventArgs> eventHandler = this.eventHandler_2;
				EventHandler<PaintEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<PaintEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public DoubleBitmapForm()
		{
			this.InitializeComponent();
			base.Visible = false;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.TopMost = true;
			base.FormBorderStyle = FormBorderStyle.None;
			base.WindowState = FormWindowState.Maximized;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			this.OnFramePainting(e);
			try
			{
				graphics.DrawImage(this.bitmap_0, -base.Location.X, -base.Location.Y);
				if (this.bitmap_1 != null)
				{
					TransfromNeededEventArg transfromNeededEventArg = new TransfromNeededEventArg();
					transfromNeededEventArg.ClientRectangle = (transfromNeededEventArg.ClipRectangle = new Rectangle(this.control_0.Bounds.Left - this.padding_0.Left, this.control_0.Bounds.Top - this.padding_0.Top, this.control_0.Bounds.Width + this.padding_0.Horizontal, this.control_0.Bounds.Height + this.padding_0.Vertical));
					this.method_0(transfromNeededEventArg);
					graphics.SetClip(transfromNeededEventArg.ClipRectangle);
					graphics.Transform = transfromNeededEventArg.Matrix;
					Point location = this.control_0.Location;
					graphics.DrawImage(this.bitmap_1, location.X - this.padding_0.Left, location.Y - this.padding_0.Top);
				}
				this.OnFramePainted(e);
			}
			catch
			{
			}
		}

		private void method_0(TransfromNeededEventArg transfromNeededEventArg_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, transfromNeededEventArg_0);
			}
		}

		protected virtual void OnFramePainting(PaintEventArgs e)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, e);
			}
		}

		protected virtual void OnFramePainted(PaintEventArgs e)
		{
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, e);
			}
		}

		public void InitParent(Control control, Padding padding)
		{
			this.control_0 = control;
			base.Location = new Point(0, 0);
			base.Size = Screen.PrimaryScreen.Bounds.Size;
			control.VisibleChanged += new EventHandler(method_1);
			this.padding_0 = padding;
		}

		private void method_1(object sender, EventArgs e)
		{
			this.point_0 = (sender as Control).Location;
			_ = (sender as Control).Size;
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
			base.SuspendLayout();
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(284, 262);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "DoubleBitmapForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DoubleBitmapForm";
			base.ResumeLayout(false);
		}
	}
}

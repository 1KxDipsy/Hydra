using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ns17
{
	[ToolboxItem(false)]
	public class DoubleBitmapControl : Control, IFakeControl
	{
		private Bitmap bitmap_0;

		private Bitmap bitmap_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<TransfromNeededEventArg> eventHandler_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<PaintEventArgs> eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<PaintEventArgs> eventHandler_2;

		private IContainer icontainer_0 = null;

		Bitmap IFakeControl.BgBmp
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

		Bitmap IFakeControl.Frame
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

		public event EventHandler<PaintEventArgs> FramePainted
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

		public event EventHandler<PaintEventArgs> FramePainting
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

		public DoubleBitmapControl()
		{
			this.method_1();
			base.Visible = false;
			base.SetStyle(ControlStyles.Selectable, value: false);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			this.OnFramePainting(e);
			try
			{
				graphics.DrawImage(this.bitmap_0, 0, 0);
				if (this.bitmap_1 != null)
				{
					TransfromNeededEventArg transfromNeededEventArg = new TransfromNeededEventArg
					{
						ClientRectangle = new Rectangle(0, 0, base.Width, base.Height)
					};
					transfromNeededEventArg.ClipRectangle = transfromNeededEventArg.ClientRectangle;
					this.method_0(transfromNeededEventArg);
					graphics.SetClip(transfromNeededEventArg.ClipRectangle);
					graphics.Transform = transfromNeededEventArg.Matrix;
					graphics.DrawImage(this.bitmap_1, 0, 0);
				}
			}
			catch
			{
			}
			this.OnFramePainted(e);
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
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, e);
			}
		}

		protected virtual void OnFramePainted(PaintEventArgs e)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, e);
			}
		}

		public void InitParent(Control control, Padding padding)
		{
			base.Parent = control.Parent;
			int childIndex = control.Parent.Controls.GetChildIndex(control);
			control.Parent.Controls.SetChildIndex(this, childIndex);
			base.Bounds = new Rectangle(control.Left - padding.Left, control.Top - padding.Top, control.Size.Width + padding.Left + padding.Right, control.Size.Height + padding.Top + padding.Bottom);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_1()
		{
			this.icontainer_0 = new Container();
		}
	}
}

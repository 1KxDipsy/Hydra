using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ns17;

namespace ns0
{
	internal class Control3 : UserControl
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private DecorationType decorationType_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Control control_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Padding padding_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Bitmap bitmap_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private byte[] byte_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Bitmap bitmap_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float float_0;

		private System.Windows.Forms.Timer timer_0;

		private bool bool_0 = false;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<NonLinearTransfromNeededEventArg> eventHandler_0;

		public DecorationType DecorationType
		{
			[CompilerGenerated]
			get
			{
				return this.decorationType_0;
			}
			[CompilerGenerated]
			set
			{
				this.decorationType_0 = value;
			}
		}

		public Control DecoratedControl
		{
			[CompilerGenerated]
			get
			{
				return this.control_0;
			}
			[CompilerGenerated]
			set
			{
				this.control_0 = value;
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

		public Bitmap CtrlBmp
		{
			[CompilerGenerated]
			get
			{
				return this.bitmap_0;
			}
			[CompilerGenerated]
			set
			{
				this.bitmap_0 = value;
			}
		}

		public byte[] CtrlPixels
		{
			[CompilerGenerated]
			get
			{
				return this.byte_0;
			}
			[CompilerGenerated]
			set
			{
				this.byte_0 = value;
			}
		}

		public int CtrlStride
		{
			[CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		public Bitmap Frame
		{
			[CompilerGenerated]
			get
			{
				return this.bitmap_1;
			}
			[CompilerGenerated]
			set
			{
				this.bitmap_1 = value;
			}
		}

		public float CurrentTime
		{
			[CompilerGenerated]
			get
			{
				return this.float_0;
			}
			[CompilerGenerated]
			set
			{
				this.float_0 = value;
			}
		}

		public event EventHandler<NonLinearTransfromNeededEventArg> Event_0
		{
			[CompilerGenerated]
			add
			{
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler = this.eventHandler_0;
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<NonLinearTransfromNeededEventArg>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler = this.eventHandler_0;
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<NonLinearTransfromNeededEventArg>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public Control3(DecorationType decorationType_1, Control control_1)
		{
			this.DecorationType = decorationType_1;
			this.DecoratedControl = control_1;
			control_1.VisibleChanged += new EventHandler(method_2);
			control_1.ParentChanged += new EventHandler(method_2);
			control_1.LocationChanged += new EventHandler(method_2);
			control_1.Paint += new PaintEventHandler(method_1);
			base.SetStyle(ControlStyles.Selectable, value: false);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.method_0();
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_0.Interval = 100;
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
			this.timer_0.Enabled = true;
		}

		private void method_0()
		{
			if (this.DecorationType == DecorationType.BottomMirror)
			{
				this.Padding = new Padding(0, 0, 0, 20);
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			DecorationType decorationType = this.DecorationType;
			if (decorationType == DecorationType.BottomMirror || decorationType == DecorationType.Custom)
			{
				base.Invalidate();
			}
		}

		private void method_1(object sender, PaintEventArgs e)
		{
			if (!this.bool_0)
			{
				base.Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			this.CtrlBmp = this.vmethod_0(this.DecoratedControl);
			this.CtrlPixels = this.method_4(this.CtrlBmp);
			if (this.Frame != null)
			{
				this.Frame.Dispose();
			}
			this.Frame = this.vmethod_1();
			if (this.Frame != null)
			{
				e.Graphics.DrawImage(this.Frame, Point.Empty);
			}
		}

		private void method_2(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void method_3()
		{
			base.Parent = this.DecoratedControl.Parent;
			base.Visible = this.DecoratedControl.Visible;
			base.Location = new Point(this.DecoratedControl.Left - this.Padding.Left, this.DecoratedControl.Top - this.Padding.Top);
			if (base.Parent != null)
			{
				int childIndex = base.Parent.Controls.GetChildIndex(this.DecoratedControl);
				base.Parent.Controls.SetChildIndex(this, childIndex + 1);
			}
			Size size = new Size(this.DecoratedControl.Width + this.Padding.Left + this.Padding.Right, this.DecoratedControl.Height + this.Padding.Top + this.Padding.Bottom);
			if (size != base.Size)
			{
				base.Size = size;
			}
		}

		protected virtual Bitmap vmethod_0(Control control_1)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			if (!control_1.IsDisposed)
			{
				this.bool_0 = true;
				control_1.DrawToBitmap(bitmap, new Rectangle(this.Padding.Left, this.Padding.Top, control_1.Width, control_1.Height));
				this.bool_0 = false;
			}
			return bitmap;
		}

		private byte[] method_4(Bitmap bitmap_2)
		{
			BitmapData bitmapData = bitmap_2.LockBits(new Rectangle(0, 0, bitmap_2.Width, bitmap_2.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			IntPtr scan = bitmapData.Scan0;
			int num = bitmap_2.Width * bitmap_2.Height * 4;
			byte[] array = new byte[num];
			Marshal.Copy(scan, array, 0, num);
			bitmap_2.UnlockBits(bitmapData);
			return array;
		}

		protected virtual Bitmap vmethod_1()
		{
			Bitmap bitmap = null;
			if (this.CtrlBmp == null)
			{
				return null;
			}
			try
			{
				bitmap = new Bitmap(base.Width, base.Height);
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
				IntPtr scan = bitmapData.Scan0;
				int num = bitmap.Width * bitmap.Height * 4;
				byte[] array = new byte[num];
				Marshal.Copy(scan, array, 0, num);
				NonLinearTransfromNeededEventArg nonLinearTransfromNeededEventArg = new NonLinearTransfromNeededEventArg
				{
					CurrentTime = this.CurrentTime,
					ClientRectangle = base.ClientRectangle,
					Pixels = array,
					Stride = bitmapData.Stride,
					SourcePixels = this.CtrlPixels,
					SourceClientRectangle = new Rectangle(this.Padding.Left, this.Padding.Top, this.DecoratedControl.Width, this.DecoratedControl.Height),
					SourceStride = this.CtrlStride
				};
				try
				{
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, nonLinearTransfromNeededEventArg);
					}
					else
					{
						nonLinearTransfromNeededEventArg.UseDefaultTransform = true;
					}
					if (nonLinearTransfromNeededEventArg.UseDefaultTransform && this.DecorationType == DecorationType.BottomMirror)
					{
						TransfromHelper.DoBottomMirror(nonLinearTransfromNeededEventArg);
					}
				}
				catch
				{
				}
				Marshal.Copy(array, 0, scan, num);
				bitmap.UnlockBits(bitmapData);
			}
			catch
			{
			}
			return bitmap;
		}

		protected override void Dispose(bool disposing)
		{
			this.timer_0.Stop();
			this.timer_0.Dispose();
			base.Dispose(disposing);
		}
	}
}

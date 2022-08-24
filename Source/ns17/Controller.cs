using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ns17
{
	public class Controller
	{
		protected Bitmap ctrlBmp;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float float_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float float_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<TransfromNeededEventArg> eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<NonLinearTransfromNeededEventArg> eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<PaintEventArgs> eventHandler_2;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<PaintEventArgs> eventHandler_3;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<MouseEventArgs> eventHandler_4;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Control control_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Control control_1;

		private Point[] point_0;

		private byte[] byte_0;

		protected Rectangle CustomClipRect;

		private AnimateMode animateMode_0;

		private Animation animation_0;

		protected Bitmap BgBmp
		{
			get
			{
				return (this.DoubleBitmap as IFakeControl).BgBmp;
			}
			set
			{
				(this.DoubleBitmap as IFakeControl).BgBmp = value;
			}
		}

		public Bitmap Frame
		{
			get
			{
				return (this.DoubleBitmap as IFakeControl).Frame;
			}
			set
			{
				(this.DoubleBitmap as IFakeControl).Frame = value;
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
			private set
			{
				this.float_0 = value;
			}
		}

		protected float TimeStep
		{
			[CompilerGenerated]
			get
			{
				return this.float_1;
			}
			[CompilerGenerated]
			private set
			{
				this.float_1 = value;
			}
		}

		public Control DoubleBitmap
		{
			[CompilerGenerated]
			get
			{
				return this.control_0;
			}
			[CompilerGenerated]
			private set
			{
				this.control_0 = value;
			}
		}

		public Control AnimatedControl
		{
			[CompilerGenerated]
			get
			{
				return this.control_1;
			}
			[CompilerGenerated]
			set
			{
				this.control_1 = value;
			}
		}

		public bool IsCompleted => (this.TimeStep >= 0f && !(this.CurrentTime < this.animation_0.MaxTime)) || (this.TimeStep <= 0f && this.CurrentTime <= this.animation_0.MinTime);

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

		public event EventHandler<NonLinearTransfromNeededEventArg> NonLinearTransfromNeeded
		{
			[CompilerGenerated]
			add
			{
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler = this.eventHandler_1;
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<NonLinearTransfromNeededEventArg>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler = this.eventHandler_1;
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<NonLinearTransfromNeededEventArg>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
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

		public event EventHandler<PaintEventArgs> FramePainted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<PaintEventArgs> eventHandler = this.eventHandler_3;
				EventHandler<PaintEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<PaintEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<PaintEventArgs> eventHandler = this.eventHandler_3;
				EventHandler<PaintEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<PaintEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<MouseEventArgs> MouseDown
		{
			[CompilerGenerated]
			add
			{
				EventHandler<MouseEventArgs> eventHandler = this.eventHandler_4;
				EventHandler<MouseEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<MouseEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_4, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<MouseEventArgs> eventHandler = this.eventHandler_4;
				EventHandler<MouseEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<MouseEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_4, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public Controller(Control control, AnimateMode mode, Animation animation, float timeStep, Rectangle controlClipRect)
		{
			if (control is Form)
			{
				this.DoubleBitmap = new DoubleBitmapForm();
			}
			else
			{
				this.DoubleBitmap = new DoubleBitmapControl();
			}
			(this.DoubleBitmap as IFakeControl).FramePainting += new EventHandler<PaintEventArgs>(OnFramePainting);
			(this.DoubleBitmap as IFakeControl).FramePainted += new EventHandler<PaintEventArgs>(OnFramePainting);
			(this.DoubleBitmap as IFakeControl).TransfromNeeded += new EventHandler<TransfromNeededEventArg>(OnTransfromNeeded);
			this.DoubleBitmap.MouseDown += new MouseEventHandler(OnMouseDown);
			this.animation_0 = animation;
			this.AnimatedControl = control;
			this.animateMode_0 = mode;
			this.CustomClipRect = controlClipRect;
			if (mode == AnimateMode.Show || mode == AnimateMode.BeginUpdate)
			{
				timeStep = 0f - timeStep;
			}
			this.TimeStep = timeStep * ((animation.TimeCoeff == 0f) ? 1f : animation.TimeCoeff);
			if (this.TimeStep == 0f)
			{
				timeStep = 0.01f;
			}
			try
			{
				switch (mode)
				{
				case AnimateMode.Show:
					this.BgBmp = this.GetBackground(control);
					(this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
					this.DoubleBitmap.Visible = true;
					this.DoubleBitmap.Refresh();
					control.Visible = true;
					this.ctrlBmp = this.GetForeground(control);
					break;
				case AnimateMode.Hide:
					this.BgBmp = this.GetBackground(control);
					(this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
					this.ctrlBmp = this.GetForeground(control);
					this.DoubleBitmap.Visible = true;
					control.Visible = false;
					break;
				case AnimateMode.Update:
				case AnimateMode.BeginUpdate:
					(this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
					this.BgBmp = this.GetBackground(control, includeForeground: true);
					this.DoubleBitmap.Visible = true;
					break;
				}
			}
			catch
			{
				this.Dispose();
			}
			this.CurrentTime = ((timeStep > 0f) ? animation.MinTime : animation.MaxTime);
		}

		public void Dispose()
		{
			if (this.ctrlBmp != null)
			{
				this.BgBmp.Dispose();
			}
			if (this.ctrlBmp != null)
			{
				this.ctrlBmp.Dispose();
			}
			if (this.Frame != null)
			{
				this.Frame.Dispose();
			}
			this.AnimatedControl = null;
			this.Hide();
		}

		public void Hide()
		{
			if (this.DoubleBitmap == null)
			{
				return;
			}
			try
			{
				this.DoubleBitmap.BeginInvoke((MethodInvoker)delegate
				{
					if (this.DoubleBitmap.Visible)
					{
						this.DoubleBitmap.Hide();
					}
					this.DoubleBitmap.Parent = null;
				});
			}
			catch
			{
			}
		}

		protected virtual Rectangle GetBounds()
		{
			return new Rectangle(this.AnimatedControl.Left - this.animation_0.Padding.Left, this.AnimatedControl.Top - this.animation_0.Padding.Top, this.AnimatedControl.Size.Width + this.animation_0.Padding.Left + this.animation_0.Padding.Right, this.AnimatedControl.Size.Height + this.animation_0.Padding.Top + this.animation_0.Padding.Bottom);
		}

		protected virtual Rectangle ControlRectToMyRect(Rectangle rect)
		{
			return new Rectangle(this.animation_0.Padding.Left + rect.Left, this.animation_0.Padding.Top + rect.Top, rect.Width + this.animation_0.Padding.Left + this.animation_0.Padding.Right, rect.Height + this.animation_0.Padding.Top + this.animation_0.Padding.Bottom);
		}

		protected virtual void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (this.eventHandler_4 != null)
			{
				this.eventHandler_4(this, e);
			}
		}

		protected virtual void OnFramePainting(object sender, PaintEventArgs e)
		{
			Bitmap frame = this.Frame;
			this.Frame = null;
			if (this.animateMode_0 != AnimateMode.BeginUpdate)
			{
				this.Frame = this.OnNonLinearTransfromNeeded();
				if (frame != this.Frame)
				{
					frame?.Dispose();
				}
				float num = this.CurrentTime + this.TimeStep;
				if (num > this.animation_0.MaxTime)
				{
					num = this.animation_0.MaxTime;
				}
				if (num < this.animation_0.MinTime)
				{
					num = this.animation_0.MinTime;
				}
				this.CurrentTime = num;
				if (this.eventHandler_2 != null)
				{
					this.eventHandler_2(this, e);
				}
			}
		}

		protected virtual void OnFramePainted(object sender, PaintEventArgs e)
		{
			if (this.eventHandler_3 != null)
			{
				this.eventHandler_3(this, e);
			}
		}

		protected virtual Bitmap GetBackground(Control ctrl, bool includeForeground = false, bool clip = false)
		{
			if (ctrl is Form)
			{
				return this.method_0(ctrl, includeForeground, clip);
			}
			Rectangle bounds = this.GetBounds();
			int num = bounds.Width;
			int num2 = bounds.Height;
			if (num == 0)
			{
				num = 1;
			}
			if (num2 == 1)
			{
				num2 = 1;
			}
			Bitmap bitmap = new Bitmap(num, num2);
			PaintEventArgs paintEventArgs = new PaintEventArgs(clipRect: new Rectangle(0, 0, bitmap.Width, bitmap.Height), graphics: Graphics.FromImage(bitmap));
			if (clip)
			{
				if (this.CustomClipRect == default(Rectangle))
				{
					paintEventArgs.Graphics.SetClip(new Rectangle(0, 0, num, num2));
				}
				else
				{
					paintEventArgs.Graphics.SetClip(this.CustomClipRect);
				}
			}
			for (int num3 = ctrl.Parent.Controls.Count - 1; num3 >= 0; num3--)
			{
				Control control = ctrl.Parent.Controls[num3];
				if (control == ctrl && !includeForeground)
				{
					break;
				}
				if (control.Visible && !control.IsDisposed && control.Bounds.IntersectsWith(bounds))
				{
					using Bitmap bitmap2 = new Bitmap(control.Width, control.Height);
					control.DrawToBitmap(bitmap2, new Rectangle(0, 0, control.Width, control.Height));
					paintEventArgs.Graphics.DrawImage(bitmap2, control.Left - bounds.Left, control.Top - bounds.Top, control.Width, control.Height);
				}
				if (control == ctrl)
				{
					break;
				}
			}
			paintEventArgs.Graphics.Dispose();
			return bitmap;
		}

		private Bitmap method_0(Control control_2, bool bool_0, bool bool_1)
		{
			Size size = Screen.PrimaryScreen.Bounds.Size;
			Bitmap bitmap = new Bitmap(g: this.DoubleBitmap.CreateGraphics(), width: size.Width, height: size.Height);
			Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, size);
			return bitmap;
		}

		protected virtual Bitmap GetForeground(Control ctrl)
		{
			Bitmap bitmap = null;
			if (!ctrl.IsDisposed)
			{
				if (ctrl.Parent == null)
				{
					bitmap = new Bitmap(ctrl.Width + this.animation_0.Padding.Horizontal, ctrl.Height + this.animation_0.Padding.Vertical);
					ctrl.DrawToBitmap(bitmap, new Rectangle(this.animation_0.Padding.Left, this.animation_0.Padding.Top, ctrl.Width, ctrl.Height));
				}
				else
				{
					bitmap = new Bitmap(this.DoubleBitmap.Width, this.DoubleBitmap.Height);
					ctrl.DrawToBitmap(bitmap, new Rectangle(ctrl.Left - this.DoubleBitmap.Left, ctrl.Top - this.DoubleBitmap.Top, ctrl.Width, ctrl.Height));
				}
			}
			return bitmap;
		}

		protected virtual void OnTransfromNeeded(object sender, TransfromNeededEventArg e)
		{
			try
			{
				if (this.CustomClipRect != default(Rectangle))
				{
					e.ClipRectangle = this.ControlRectToMyRect(this.CustomClipRect);
				}
				e.CurrentTime = this.CurrentTime;
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, e);
				}
				else
				{
					e.UseDefaultMatrix = true;
				}
				if (e.UseDefaultMatrix)
				{
					TransfromHelper.DoScale(e, this.animation_0);
					TransfromHelper.DoRotate(e, this.animation_0);
					TransfromHelper.DoSlide(e, this.animation_0);
				}
			}
			catch
			{
			}
		}

		protected virtual Bitmap OnNonLinearTransfromNeeded()
		{
			Bitmap bitmap = null;
			if (this.ctrlBmp == null)
			{
				return null;
			}
			if (this.eventHandler_1 == null && !this.animation_0.IsNonLinearTransformNeeded)
			{
				return this.ctrlBmp;
			}
			try
			{
				bitmap = (Bitmap)this.ctrlBmp.Clone();
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
				IntPtr scan = bitmapData.Scan0;
				int num = bitmap.Width * bitmap.Height * 4;
				byte[] array = new byte[num];
				Marshal.Copy(scan, array, 0, num);
				NonLinearTransfromNeededEventArg nonLinearTransfromNeededEventArg = new NonLinearTransfromNeededEventArg
				{
					CurrentTime = this.CurrentTime,
					ClientRectangle = this.DoubleBitmap.ClientRectangle,
					Pixels = array,
					Stride = bitmapData.Stride
				};
				if (this.eventHandler_1 != null)
				{
					this.eventHandler_1(this, nonLinearTransfromNeededEventArg);
				}
				else
				{
					nonLinearTransfromNeededEventArg.UseDefaultTransform = true;
				}
				if (nonLinearTransfromNeededEventArg.UseDefaultTransform)
				{
					TransfromHelper.DoBlind(nonLinearTransfromNeededEventArg, this.animation_0);
					TransfromHelper.DoMosaic(nonLinearTransfromNeededEventArg, this.animation_0, ref this.point_0, ref this.byte_0);
					TransfromHelper.DoTransparent(nonLinearTransfromNeededEventArg, this.animation_0);
					TransfromHelper.DoLeaf(nonLinearTransfromNeededEventArg, this.animation_0);
				}
				Marshal.Copy(array, 0, scan, num);
				bitmap.UnlockBits(bitmapData);
			}
			catch
			{
			}
			return bitmap;
		}

		public void EndUpdate()
		{
			Bitmap background = this.GetBackground(this.AnimatedControl, includeForeground: true, clip: true);
			if (this.animation_0.AnimateOnlyDifferences)
			{
				TransfromHelper.CalcDifference(background, this.BgBmp);
			}
			this.ctrlBmp = background;
			this.animateMode_0 = AnimateMode.Update;
		}

		internal void method_1()
		{
			if (this.animateMode_0 != AnimateMode.BeginUpdate)
			{
				this.DoubleBitmap.Invalidate();
			}
		}

		[CompilerGenerated]
		private void method_2()
		{
			if (this.DoubleBitmap.Visible)
			{
				this.DoubleBitmap.Hide();
			}
			this.DoubleBitmap.Parent = null;
		}
	}
}

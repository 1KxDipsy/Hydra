using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ns0;

namespace ns17
{
	[ProvideProperty("Decoration", typeof(Control))]
	[ToolboxItem(false)]
	public class Animator : Component, IExtenderProvider
	{
		protected class QueueItem
		{
			public Animation animation;

			public Controller controller;

			public Control control;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private DateTime dateTime_0;

			public AnimateMode mode;

			public Rectangle clipRectangle;

			public bool isActive;

			public DateTime ActivateTime
			{
				[CompilerGenerated]
				get
				{
					return this.dateTime_0;
				}
				[CompilerGenerated]
				private set
				{
					this.dateTime_0 = value;
				}
			}

			public bool IsActive
			{
				get
				{
					return this.isActive;
				}
				set
				{
					if (this.isActive != value)
					{
						this.isActive = value;
						if (value)
						{
							this.ActivateTime = DateTime.Now;
						}
					}
				}
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (this.control != null)
				{
					stringBuilder.Append(this.control.GetType().Name + " ");
				}
				stringBuilder.Append(this.mode);
				return stringBuilder.ToString();
			}
		}

		[CompilerGenerated]
		private sealed class Class72
		{
			public QueueItem queueItem_0;

			public Animator animator_0;

			internal void method_0()
			{
				this.animator_0.method_5(this.queueItem_0);
			}
		}

		[CompilerGenerated]
		private sealed class Class73
		{
			public AnimateMode animateMode_0;

			public Control control_0;

			internal void method_0()
			{
				try
				{
					switch (this.animateMode_0)
					{
					case AnimateMode.Hide:
						this.control_0.Visible = false;
						break;
					case AnimateMode.Show:
						this.control_0.Visible = true;
						break;
					}
				}
				catch
				{
				}
			}
		}

		[CompilerGenerated]
		private sealed class Class74
		{
			public QueueItem queueItem_0;

			internal void method_0()
			{
				switch (this.queueItem_0.mode)
				{
				case AnimateMode.Hide:
					this.queueItem_0.control.Visible = false;
					break;
				case AnimateMode.Show:
					this.queueItem_0.control.Visible = true;
					break;
				}
			}
		}

		private IContainer icontainer_0 = null;

		protected List<QueueItem> queue = new List<QueueItem>();

		private Thread thread_0;

		private System.Windows.Forms.Timer timer_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<AnimationCompletedEventArg> eventHandler_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<TransfromNeededEventArg> eventHandler_2;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<NonLinearTransfromNeededEventArg> eventHandler_3;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<MouseEventArgs> eventHandler_4;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler<PaintEventArgs> eventHandler_5;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Animation animation_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Cursor cursor_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_1;

		private AnimationType animationType_0;

		private Control control_0;

		private int int_2;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float float_0;

		private List<QueueItem> list_0 = new List<QueueItem>();

		private readonly Dictionary<Control, Control3> dictionary_0 = new Dictionary<Control, Control3>();

		[DefaultValue(1500)]
		public int MaxAnimationTime
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

		[TypeConverter(typeof(ExpandableObjectConverter))]
		[DefaultValue("")]
		public Animation DefaultAnimation
		{
			[CompilerGenerated]
			get
			{
				return this.animation_0;
			}
			[CompilerGenerated]
			set
			{
				this.animation_0 = value;
			}
		}

		[DefaultValue(typeof(Cursor), "Default")]
		public Cursor Cursor
		{
			[CompilerGenerated]
			get
			{
				return this.cursor_0;
			}
			[CompilerGenerated]
			set
			{
				this.cursor_0 = value;
			}
		}

		public bool IsCompleted
		{
			get
			{
				lock (this.queue)
				{
					return this.queue.Count == 0;
				}
			}
		}

		[DefaultValue(10)]
		public int Interval
		{
			[CompilerGenerated]
			get
			{
				return this.int_1;
			}
			[CompilerGenerated]
			set
			{
				this.int_1 = value;
			}
		}

		[DefaultValue(AnimationType.VertBlind)]
		public AnimationType AnimationType
		{
			get
			{
				return this.animationType_0;
			}
			set
			{
				this.animationType_0 = value;
				this.method_6(this.animationType_0);
			}
		}

		[DefaultValue(0.02f)]
		public float TimeStep
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

		public event EventHandler<AnimationCompletedEventArg> AnimationCompleted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<AnimationCompletedEventArg> eventHandler = this.eventHandler_0;
				EventHandler<AnimationCompletedEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<AnimationCompletedEventArg>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<AnimationCompletedEventArg> eventHandler = this.eventHandler_0;
				EventHandler<AnimationCompletedEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<AnimationCompletedEventArg>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler AllAnimationsCompleted
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

		public event EventHandler<TransfromNeededEventArg> TransfromNeeded
		{
			[CompilerGenerated]
			add
			{
				EventHandler<TransfromNeededEventArg> eventHandler = this.eventHandler_2;
				EventHandler<TransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<TransfromNeededEventArg>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<TransfromNeededEventArg> eventHandler = this.eventHandler_2;
				EventHandler<TransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<TransfromNeededEventArg>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<NonLinearTransfromNeededEventArg> NonLinearTransfromNeeded
		{
			[CompilerGenerated]
			add
			{
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler = this.eventHandler_3;
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<NonLinearTransfromNeededEventArg>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler = this.eventHandler_3;
				EventHandler<NonLinearTransfromNeededEventArg> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<NonLinearTransfromNeededEventArg>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
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

		public event EventHandler<PaintEventArgs> FramePainted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<PaintEventArgs> eventHandler = this.eventHandler_5;
				EventHandler<PaintEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<PaintEventArgs>)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_5, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<PaintEventArgs> eventHandler = this.eventHandler_5;
				EventHandler<PaintEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler<PaintEventArgs>)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_5, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public Animator()
		{
			this.Init();
			this.AnimationType = AnimationType.VertBlind;
			Class13.smethod_0();
		}

		public Animator(IContainer container)
		{
			container.Add(this);
			this.Init();
			this.AnimationType = AnimationType.VertBlind;
			Class13.smethod_0();
		}

		protected virtual void Init()
		{
			this.AnimationType = AnimationType.VertSlide;
			this.DefaultAnimation = new Animation();
			this.MaxAnimationTime = 1500;
			this.TimeStep = 0.02f;
			this.Interval = 10;
			base.Disposed += new EventHandler(Animator_Disposed);
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
			this.timer_0.Interval = 1;
			this.timer_0.Start();
		}

		private void method_0()
		{
			this.thread_0 = new Thread(new ThreadStart(method_1));
			this.thread_0.IsBackground = true;
			this.thread_0.Name = "Animator thread";
			this.thread_0.Start();
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.timer_0.Stop();
			this.control_0 = new Control();
			this.control_0.CreateControl();
			this.method_0();
		}

		private void Animator_Disposed(object sender, EventArgs e)
		{
			this.ClearQueue();
			if (this.thread_0 != null)
			{
				this.thread_0.Abort();
			}
		}

		private void method_1()
		{
			QueueItem queueItem_0;
			while (true)
			{
				Thread.Sleep(this.Interval);
				try
				{
					int num = 0;
					List<QueueItem> list = new List<QueueItem>();
					List<QueueItem> list2 = new List<QueueItem>();
					lock (this.queue)
					{
						num = this.queue.Count;
						bool flag = false;
						foreach (QueueItem item in this.queue)
						{
							if (item.IsActive)
							{
								flag = true;
							}
							if (item.controller != null && item.controller.IsCompleted)
							{
								list.Add(item);
							}
							else if (item.IsActive)
							{
								if ((DateTime.Now - item.ActivateTime).TotalMilliseconds > (double)this.MaxAnimationTime)
								{
									list.Add(item);
								}
								else
								{
									list2.Add(item);
								}
							}
						}
						if (!flag)
						{
							foreach (QueueItem item2 in this.queue)
							{
								if (!item2.IsActive)
								{
									list2.Add(item2);
									item2.IsActive = true;
									break;
								}
							}
						}
					}
					foreach (QueueItem item3 in list)
					{
						this.method_7(item3);
					}
					foreach (QueueItem item4 in list2)
					{
						try
						{
							queueItem_0 = item4;
							this.control_0.BeginInvoke((MethodInvoker)delegate
							{
								this.method_5(queueItem_0);
							});
						}
						catch
						{
							this.method_7(item4);
						}
					}
					if (num == 0)
					{
						if (list.Count > 0)
						{
							this.OnAllAnimationsCompleted();
						}
						this.method_2();
					}
				}
				catch
				{
				}
			}
		}

		private void method_2()
		{
			List<QueueItem> list = new List<QueueItem>();
			lock (this.list_0)
			{
				Dictionary<Control, QueueItem> dictionary = new Dictionary<Control, QueueItem>();
				foreach (QueueItem item in this.list_0)
				{
					if (item.control != null)
					{
						if (dictionary.ContainsKey(item.control))
						{
							list.Add(dictionary[item.control]);
						}
						dictionary[item.control] = item;
					}
					else
					{
						list.Add(item);
					}
				}
				foreach (QueueItem value in dictionary.Values)
				{
					if (value.control != null && !this.method_3(value.control, value.mode))
					{
						if (this.control_0 != null)
						{
							this.method_4(value.control, value.mode);
						}
					}
					else
					{
						list.Add(value);
					}
				}
				foreach (QueueItem item2 in list)
				{
					this.list_0.Remove(item2);
				}
			}
		}

		private bool method_3(Control control_1, AnimateMode animateMode_0)
		{
			return animateMode_0 switch
			{
				AnimateMode.Hide => !control_1.Visible, 
				AnimateMode.Show => control_1.Visible, 
				_ => true, 
			};
		}

		private void method_4(Control control_1, AnimateMode animateMode_0)
		{
			this.control_0.Invoke((MethodInvoker)delegate
			{
				try
				{
					switch (animateMode_0)
					{
					case AnimateMode.Hide:
						control_1.Visible = false;
						break;
					case AnimateMode.Show:
						control_1.Visible = true;
						break;
					}
				}
				catch
				{
				}
			});
		}

		private void method_5(QueueItem queueItem_0)
		{
			lock (queueItem_0)
			{
				try
				{
					if (queueItem_0.controller == null)
					{
						queueItem_0.controller = this.method_8(queueItem_0.control, queueItem_0.mode, queueItem_0.animation, queueItem_0.clipRectangle);
					}
					if (!queueItem_0.controller.IsCompleted)
					{
						queueItem_0.controller.method_1();
					}
				}
				catch
				{
					if (queueItem_0.controller != null)
					{
						queueItem_0.controller.Dispose();
					}
					this.method_7(queueItem_0);
				}
			}
		}

		private void method_6(AnimationType animationType_1)
		{
			switch (animationType_1)
			{
			case AnimationType.Rotate:
				this.DefaultAnimation = Animation.Rotate;
				break;
			case AnimationType.HorizSlide:
				this.DefaultAnimation = Animation.HorizSlide;
				break;
			case AnimationType.VertSlide:
				this.DefaultAnimation = Animation.VertSlide;
				break;
			case AnimationType.Scale:
				this.DefaultAnimation = Animation.Scale;
				break;
			case AnimationType.ScaleAndRotate:
				this.DefaultAnimation = Animation.ScaleAndRotate;
				break;
			case AnimationType.HorizSlideAndRotate:
				this.DefaultAnimation = Animation.HorizSlideAndRotate;
				break;
			case AnimationType.ScaleAndHorizSlide:
				this.DefaultAnimation = Animation.ScaleAndHorizSlide;
				break;
			case AnimationType.Transparent:
				this.DefaultAnimation = Animation.Transparent;
				break;
			case AnimationType.Leaf:
				this.DefaultAnimation = Animation.Leaf;
				break;
			case AnimationType.Mosaic:
				this.DefaultAnimation = Animation.Mosaic;
				break;
			case AnimationType.Particles:
				this.DefaultAnimation = Animation.Particles;
				break;
			case AnimationType.VertBlind:
				this.DefaultAnimation = Animation.VertBlind;
				break;
			case AnimationType.HorizBlind:
				this.DefaultAnimation = Animation.HorizBlind;
				break;
			case AnimationType.Custom:
				break;
			}
		}

		public void Show(Control control, bool parallel = false, Animation animation = null)
		{
			this.AddToQueue(control, AnimateMode.Show, parallel, animation);
		}

		public void ShowSync(Control control, bool parallel = false, Animation animation = null)
		{
			this.Show(control, parallel, animation);
			this.WaitAnimation(control);
		}

		public void Hide(Control control, bool parallel = false, Animation animation = null)
		{
			this.AddToQueue(control, AnimateMode.Hide, parallel, animation);
		}

		public void HideSync(Control control, bool parallel = false, Animation animation = null)
		{
			this.Hide(control, parallel, animation);
			this.WaitAnimation(control);
		}

		public void BeginUpdate(Control control, bool parallel = false, Animation animation = null, Rectangle clipRectangle = default(Rectangle))
		{
			this.AddToQueue(control, AnimateMode.BeginUpdate, parallel, animation, clipRectangle);
			bool flag = false;
			do
			{
				flag = false;
				lock (this.queue)
				{
					foreach (QueueItem item in this.queue)
					{
						if (item.control == control && item.mode == AnimateMode.BeginUpdate && item.controller == null)
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					Application.DoEvents();
				}
			}
			while (flag);
		}

		public void EndUpdate(Control control)
		{
			lock (this.queue)
			{
				foreach (QueueItem item in this.queue)
				{
					if (item.control == control && item.mode == AnimateMode.BeginUpdate)
					{
						item.controller.EndUpdate();
						item.mode = AnimateMode.Update;
					}
				}
			}
		}

		public void EndUpdateSync(Control control)
		{
			this.EndUpdate(control);
			this.WaitAnimation(control);
		}

		public void WaitAllAnimations()
		{
			while (!this.IsCompleted)
			{
				Application.DoEvents();
			}
		}

		public void WaitAnimation(Control animatedControl)
		{
			while (true)
			{
				bool flag = false;
				lock (this.queue)
				{
					foreach (QueueItem item in this.queue)
					{
						if (item.control == animatedControl)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					Application.DoEvents();
					continue;
				}
				break;
			}
		}

		private void method_7(QueueItem queueItem_0)
		{
			if (queueItem_0.controller != null)
			{
				queueItem_0.controller.Dispose();
			}
			lock (this.queue)
			{
				this.queue.Remove(queueItem_0);
			}
			this.OnAnimationCompleted(new AnimationCompletedEventArg
			{
				Animation = queueItem_0.animation,
				Control = queueItem_0.control,
				Mode = queueItem_0.mode
			});
		}

		public void AddToQueue(Control control, AnimateMode mode, bool parallel = true, Animation animation = null, Rectangle clipRectangle = default(Rectangle))
		{
			if (animation == null)
			{
				animation = this.DefaultAnimation;
			}
			if (control is IFakeControl)
			{
				control.Visible = false;
				return;
			}
			QueueItem item = new QueueItem
			{
				animation = animation,
				control = control,
				IsActive = parallel,
				mode = mode,
				clipRectangle = clipRectangle
			};
			switch (mode)
			{
			case AnimateMode.Hide:
				if (!control.Visible)
				{
					this.method_7(new QueueItem
					{
						control = control,
						mode = mode
					});
					return;
				}
				break;
			case AnimateMode.Show:
				if (control.Visible)
				{
					this.method_7(new QueueItem
					{
						control = control,
						mode = mode
					});
					return;
				}
				break;
			}
			lock (this.queue)
			{
				this.queue.Add(item);
			}
			lock (this.list_0)
			{
				this.list_0.Add(item);
			}
		}

		private Controller method_8(Control control_1, AnimateMode animateMode_0, Animation animation_1, Rectangle rectangle_0)
		{
			Controller controller = new Controller(control_1, animateMode_0, animation_1, this.TimeStep, rectangle_0);
			controller.TransfromNeeded += new EventHandler<TransfromNeededEventArg>(OnTransformNeeded);
			if (this.eventHandler_3 != null)
			{
				controller.NonLinearTransfromNeeded += new EventHandler<NonLinearTransfromNeededEventArg>(OnNonLinearTransfromNeeded);
			}
			controller.MouseDown += new EventHandler<MouseEventArgs>(OnMouseDown);
			controller.DoubleBitmap.Cursor = this.Cursor;
			controller.FramePainted += new EventHandler<PaintEventArgs>(method_9);
			return controller;
		}

		private void method_9(object sender, PaintEventArgs e)
		{
			if (this.eventHandler_5 != null)
			{
				this.eventHandler_5(sender, e);
			}
		}

		protected virtual void OnMouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				Controller controller = (Controller)sender;
				Point location = e.Location;
				location.Offset(controller.DoubleBitmap.Left - controller.AnimatedControl.Left, controller.DoubleBitmap.Top - controller.AnimatedControl.Top);
				if (this.eventHandler_4 != null)
				{
					this.eventHandler_4(sender, new MouseEventArgs(e.Button, e.Clicks, location.X, location.Y, e.Delta));
				}
			}
			catch
			{
			}
		}

		protected virtual void OnNonLinearTransfromNeeded(object sender, NonLinearTransfromNeededEventArg e)
		{
			if (this.eventHandler_3 != null)
			{
				this.eventHandler_3(this, e);
			}
			else
			{
				e.UseDefaultTransform = true;
			}
		}

		protected virtual void OnTransformNeeded(object sender, TransfromNeededEventArg e)
		{
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, e);
			}
			else
			{
				e.UseDefaultMatrix = true;
			}
		}

		public void ClearQueue()
		{
			List<QueueItem> list = null;
			lock (this.queue)
			{
				list = new List<QueueItem>(this.queue);
				this.queue.Clear();
			}
			foreach (QueueItem queueItem_0 in list)
			{
				if (queueItem_0.control != null)
				{
					queueItem_0.control.BeginInvoke((MethodInvoker)delegate
					{
						switch (queueItem_0.mode)
						{
						case AnimateMode.Hide:
							queueItem_0.control.Visible = false;
							break;
						case AnimateMode.Show:
							queueItem_0.control.Visible = true;
							break;
						}
					});
				}
				this.OnAnimationCompleted(new AnimationCompletedEventArg
				{
					Animation = queueItem_0.animation,
					Control = queueItem_0.control,
					Mode = queueItem_0.mode
				});
			}
			if (list.Count > 0)
			{
				this.OnAllAnimationsCompleted();
			}
		}

		protected virtual void OnAnimationCompleted(AnimationCompletedEventArg e)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, e);
			}
		}

		protected virtual void OnAllAnimationsCompleted()
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, EventArgs.Empty);
			}
		}

		public DecorationType GetDecoration(Control control)
		{
			if (this.dictionary_0.ContainsKey(control))
			{
				return this.dictionary_0[control].DecorationType;
			}
			return DecorationType.None;
		}

		public void SetDecoration(Control control, DecorationType decoration)
		{
			Control3 control2 = (this.dictionary_0.ContainsKey(control) ? this.dictionary_0[control] : null);
			if (decoration == DecorationType.None)
			{
				control2?.Dispose();
				this.dictionary_0.Remove(control);
				return;
			}
			if (control2 == null)
			{
				control2 = new Control3(decoration, control);
			}
			control2.DecorationType = decoration;
			this.dictionary_0[control] = control2;
		}

		public bool CanExtend(object extendee)
		{
			return extendee is Control;
		}
	}
}

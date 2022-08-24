using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns5;

namespace ns1
{
	public class SiticoneMouseStateHandler : Component
	{
		private class Class1
		{
			private delegate void Delegate0(int count, int countOUT);

			private bool bool_0 = false;

			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private SiticoneMouseStateHandler siticoneMouseStateHandler_0;

			private MouseState mouseState_0 = MouseState.const_2;

			private Control control_0;

			public SiticoneMouseStateHandler Parent
			{
				[CompilerGenerated]
				get
				{
					return this.siticoneMouseStateHandler_0;
				}
				[CompilerGenerated]
				set
				{
					this.siticoneMouseStateHandler_0 = value;
				}
			}

			public MouseState MouseState_0
			{
				get
				{
					return this.mouseState_0;
				}
				set
				{
					this.mouseState_0 = value;
					if (value == MouseState.const_2)
					{
						new Thread(new ThreadStart(method_1)).Start();
					}
					else
					{
						this.Parent.MouseState_0 = value;
					}
				}
			}

			public Control Control_0
			{
				get
				{
					return this.control_0;
				}
				set
				{
					if (this.control_0 != null)
					{
						this.control_0.MouseDown -= new MouseEventHandler(control_0_MouseDown);
						this.control_0.MouseLeave -= new EventHandler(control_0_MouseLeave);
						this.control_0.MouseEnter -= new EventHandler(control_0_MouseEnter);
						this.control_0.MouseUp -= new MouseEventHandler(control_0_MouseUp);
					}
					this.control_0 = value;
					if (this.control_0 != null)
					{
						this.control_0.MouseDown += new MouseEventHandler(control_0_MouseDown);
						this.control_0.MouseLeave += new EventHandler(control_0_MouseLeave);
						this.control_0.MouseEnter += new EventHandler(control_0_MouseEnter);
						this.control_0.MouseUp += new MouseEventHandler(control_0_MouseUp);
					}
				}
			}

			private void control_0_MouseDown(object sender, MouseEventArgs e)
			{
				this.bool_0 = true;
				this.MouseState_0 = MouseState.DOWN;
			}

			private void control_0_MouseEnter(object sender, EventArgs e)
			{
				this.bool_0 = true;
				this.MouseState_0 = MouseState.HOVER;
			}

			private void control_0_MouseLeave(object sender, EventArgs e)
			{
				this.bool_0 = false;
				this.MouseState_0 = MouseState.const_2;
			}

			private void control_0_MouseUp(object sender, MouseEventArgs e)
			{
				this.MouseState_0 = ((!this.bool_0) ? MouseState.const_2 : MouseState.HOVER);
			}

			private void method_0(int int_0, int int_1)
			{
				if (int_1 == int_0)
				{
					this.Parent.MouseState_0 = MouseState.const_2;
				}
			}

			private void method_1()
			{
				Thread.Sleep(10);
				int num = this.Parent.list_0.Count();
				int num2 = 0;
				foreach (Class1 item in this.Parent.list_0)
				{
					if (item.MouseState_0 == MouseState.const_2)
					{
						num2++;
					}
				}
				try
				{
					if (this.Control_0 != null)
					{
						this.Control_0.Invoke(new Delegate0(method_0), num, num2);
					}
				}
				catch
				{
				}
			}
		}

		private IContainer icontainer_0 = null;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_2;

		private List<Class1> list_0 = new List<Class1>();

		private MouseState mouseState_0 = MouseState.const_2;

		private MouseState MouseState_0
		{
			get
			{
				return this.mouseState_0;
			}
			set
			{
				if (this.mouseState_0 == value)
				{
					return;
				}
				this.mouseState_0 = value;
				switch (value)
				{
				case MouseState.HOVER:
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, EventArgs.Empty);
					}
					break;
				case MouseState.DOWN:
					if (this.eventHandler_1 != null)
					{
						this.eventHandler_1(this, EventArgs.Empty);
					}
					break;
				case MouseState.const_2:
					if (this.eventHandler_2 != null)
					{
						this.eventHandler_2(this, EventArgs.Empty);
					}
					break;
				}
			}
		}

		[Browsable(false)]
		public int Count => this.list_0.Count;

		public event EventHandler HoveredChanged
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

		public event EventHandler PressedChanged
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

		public event EventHandler IdleChanged
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

		public SiticoneMouseStateHandler()
		{
			this.method_0();
			Class13.smethod_0();
		}

		public SiticoneMouseStateHandler(IContainer container)
		{
			container.Add(this);
			this.method_0();
			Class13.smethod_0();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Clear();
			}
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_0()
		{
			this.icontainer_0 = new Container();
		}

		public void Add(Control control)
		{
			foreach (Class1 item in this.list_0)
			{
				if (item.Control_0 == control)
				{
					return;
				}
			}
			this.list_0.Add(new Class1
			{
				Parent = this,
				Control_0 = control,
				MouseState_0 = this.MouseState_0
			});
		}

		public void Remove(Control control)
		{
			foreach (Class1 item in this.list_0)
			{
				if (item.Control_0 == control)
				{
					item.Control_0 = null;
					this.list_0.Remove(item);
					break;
				}
			}
		}

		public void Clear()
		{
			foreach (Class1 item in this.list_0)
			{
				item.Control_0 = null;
			}
			this.list_0.Clear();
		}
	}
}

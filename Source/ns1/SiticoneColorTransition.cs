using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("Advanced Color transition component")]
	public class SiticoneColorTransition : Component
	{
		private System.Windows.Forms.Timer timer_0;

		private IContainer icontainer_0 = null;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		private Color[] color_0;

		private Color color_1;

		private Color color_2;

		private int int_0;

		private Color color_3;

		private int int_1;

		private int int_2;

		[Browsable(true)]
		public Color[] ColorArray
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

		[Browsable(true)]
		[DefaultValue(typeof(Color), "Red")]
		[Description("The start color to apply to the parent's BackColor")]
		public Color StartColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.method_2();
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "Blue")]
		[Description("The end color to apply to the parent's BackColor")]
		public Color EndColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.method_2();
			}
		}

		[Browsable(true)]
		[Description("The transition progress value")]
		[DefaultValue(0)]
		public int ProgressValue
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.method_2();
				this.OnValueChanged(EventArgs.Empty);
			}
		}

		[DefaultValue(20)]
		[Browsable(true)]
		[Description("The transition interval")]
		public int Interval
		{
			get
			{
				return this.timer_0.Interval;
			}
			set
			{
				this.timer_0.Interval = value;
			}
		}

		[Description("The current color applied to the parent's BackColor")]
		[Browsable(true)]
		public Color Value => this.color_3;

		[Browsable(true)]
		[Description("If true, the transition will start automatically")]
		[DefaultValue(false)]
		public bool AutoTransition
		{
			get
			{
				return this.timer_0.Enabled;
			}
			set
			{
				this.timer_0.Enabled = value;
			}
		}

		[DefaultValue(100)]
		[Description("The control's maximum value")]
		public int Maximum => 100;

		[DefaultValue(0)]
		[Description("The control's minimum value")]
		public int Minimum => 0;

		public event EventHandler ValueChanged
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

		public SiticoneColorTransition()
		{
			this.method_0();
			this.method_1();
			Class13.smethod_0();
		}

		public SiticoneColorTransition(IContainer container)
		{
			container.Add(this);
			this.method_0();
			this.method_1();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.timer_0.Stop();
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_0()
		{
			this.icontainer_0 = new Container();
			this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
			this.timer_0.Interval = 20;
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
		}

		private void method_1()
		{
			this.ColorArray = new Color[3]
			{
				Color.Red,
				Color.Blue,
				Color.Orange
			};
			this.color_1 = Color.Red;
			this.color_2 = Color.Blue;
			this.method_2();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValueChanged(EventArgs e)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		private void method_2()
		{
			this.color_3 = Class6.smethod_23(this.int_0, this.color_1, this.color_2);
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (base.DesignMode)
			{
				return;
			}
			if (this.ColorArray.Length != 0)
			{
				if (this.ProgressValue == 100)
				{
					this.ProgressValue = 0;
					this.int_1++;
					if (this.int_1 == this.ColorArray.Length)
					{
						this.int_1 = 0;
					}
				}
				this.StartColor = this.ColorArray[this.int_1];
				this.int_2 = this.int_1 + 1;
				if (this.int_2 > this.ColorArray.Length - 1)
				{
					this.int_2 = 0;
				}
				this.EndColor = this.ColorArray[this.int_2];
				this.ProgressValue++;
			}
			else if (this.ProgressValue != 100)
			{
				this.ProgressValue++;
			}
		}
	}
}

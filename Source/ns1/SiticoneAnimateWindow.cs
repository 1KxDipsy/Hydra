using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns6;

namespace ns1
{
	[Description("This components animates a winform when loading")]
	[ToolboxItem(true)]
	public class SiticoneAnimateWindow : Component
	{
		public enum AnimateWindowType
		{
			AW_HOR_POSITIVE = 1,
			AW_HOR_NEGATIVE = 2,
			AW_VER_POSITIVE = 4,
			AW_VER_NEGATIVE = 8,
			AW_CENTER = 0x10,
			AW_HIDE = 0x10000,
			AW_ACTIVATE = 0x20000,
			AW_SLIDE = 0x40000,
			AW_BLEND = 0x80000
		}

		private IContainer icontainer_0 = null;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private AnimateWindowType animateWindowType_0;

		[Browsable(true)]
		[DefaultValue(100)]
		public int Interval
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

		[Browsable(true)]
		[DefaultValue(16)]
		public AnimateWindowType AnimationType
		{
			[CompilerGenerated]
			get
			{
				return this.animateWindowType_0;
			}
			[CompilerGenerated]
			set
			{
				this.animateWindowType_0 = value;
			}
		}

		public SiticoneAnimateWindow()
		{
			this.method_0();
			this.Interval = 100;
			this.AnimationType = AnimateWindowType.AW_CENTER;
			Class13.smethod_0();
		}

		public SiticoneAnimateWindow(Form form, AnimateWindowType animateWindowType = AnimateWindowType.AW_CENTER, int interval = 100)
		{
			this.method_0();
			this.Interval = interval;
			this.AnimationType = animateWindowType;
			this.SetAnimateWindow(form, animateWindowType, interval);
			Class13.smethod_0();
		}

		public SiticoneAnimateWindow(ContextMenuStrip contextMenuStrip, AnimateWindowType animateWindowType = AnimateWindowType.AW_CENTER, int interval = 100)
		{
			this.method_0();
			this.Interval = interval;
			this.AnimationType = animateWindowType;
			this.SetAnimateWindow(contextMenuStrip, animateWindowType, interval);
			Class13.smethod_0();
		}

		public SiticoneAnimateWindow(IContainer container)
		{
			container.Add(this);
			this.method_0();
			this.Interval = 100;
			this.AnimationType = AnimateWindowType.AW_CENTER;
		}

		protected override void Dispose(bool disposing)
		{
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

		public void SetAnimateWindow(Form form, AnimateWindowType animationType, int interval)
		{
			try
			{
				this.Interval = interval;
				this.AnimationType = animationType;
				if (interval > 0 && form != null)
				{
					WinApi.AnimateWindow(form.Handle, interval, (int)animationType);
				}
			}
			catch
			{
			}
		}

		public void SetAnimateWindow(ContextMenuStrip contextMenuStrip, AnimateWindowType animationType, int interval)
		{
			try
			{
				this.Interval = interval;
				this.AnimationType = animationType;
				if (interval > 0 && contextMenuStrip != null)
				{
					WinApi.AnimateWindow(contextMenuStrip.Handle, interval, (int)animationType);
				}
			}
			catch
			{
			}
		}

		public void SetAnimateWindow(Form form, AnimateWindowType animationType)
		{
			try
			{
				this.AnimationType = animationType;
				if (this.Interval > 0 && form != null)
				{
					WinApi.AnimateWindow(form.Handle, this.Interval, (int)animationType);
				}
			}
			catch
			{
			}
		}

		public void SetAnimateWindow(ContextMenuStrip contextMenuStrip, AnimateWindowType animationType)
		{
			try
			{
				this.AnimationType = animationType;
				if (this.Interval > 0 && contextMenuStrip != null)
				{
					WinApi.AnimateWindow(contextMenuStrip.Handle, this.Interval, (int)animationType);
				}
			}
			catch
			{
			}
		}

		public void SetAnimateWindow(Form form)
		{
			try
			{
				if (this.Interval > 0 && form != null)
				{
					WinApi.AnimateWindow(form.Handle, this.Interval, (int)this.AnimationType);
				}
			}
			catch
			{
			}
		}

		public void SetAnimateWindow(ContextMenuStrip contextMenuStrip)
		{
			try
			{
				if (this.Interval > 0 && contextMenuStrip != null)
				{
					WinApi.AnimateWindow(contextMenuStrip.Handle, this.Interval, (int)this.AnimationType);
				}
			}
			catch
			{
			}
		}
	}
}

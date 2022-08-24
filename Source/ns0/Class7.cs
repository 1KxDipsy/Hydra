using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns5;

namespace ns0
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	internal class Class7 : NumericUpDown
	{
		public delegate void Delegate1(bool e);

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Delegate1 delegate1_0;

		private bool bool_0 = false;

		internal MouseState mouseState_0 = MouseState.const_2;

		[Browsable(false)]
		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		public bool Boolean_0 => base.DesignMode;

		public event Delegate1 Event_0
		{
			[CompilerGenerated]
			add
			{
				Delegate1 @delegate = this.delegate1_0;
				Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					@delegate = Interlocked.CompareExchange(value: (Delegate1)Delegate.Combine(delegate2, value), location1: ref this.delegate1_0, comparand: delegate2);
				}
				while ((object)@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Delegate1 @delegate = this.delegate1_0;
				Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					@delegate = Interlocked.CompareExchange(value: (Delegate1)Delegate.Remove(delegate2, value), location1: ref this.delegate1_0, comparand: delegate2);
				}
				while ((object)@delegate != delegate2);
			}
		}

		protected virtual void vmethod_0(bool bool_1)
		{
			if (this.delegate1_0 != null)
			{
				this.delegate1_0(bool_1);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.bool_0 = true;
			this.mouseState_0 = MouseState.DOWN;
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.mouseState_0 = ((!this.bool_0) ? MouseState.const_2 : MouseState.HOVER);
			base.OnMouseUp(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.bool_0 = true;
			this.mouseState_0 = MouseState.HOVER;
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.bool_0 = false;
			this.mouseState_0 = MouseState.const_2;
			base.OnMouseLeave(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			this.bool_0 = false;
			this.mouseState_0 = MouseState.const_2;
			base.OnLostFocus(e);
			this.vmethod_0(bool_1: false);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.vmethod_0(bool_1: true);
		}
	}
}

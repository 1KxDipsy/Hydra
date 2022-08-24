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
	internal class Class8 : TextBox
	{
		public delegate void Delegate2(bool e);

		public delegate void Delegate3(bool e);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Delegate2 delegate2_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Delegate3 delegate3_0;

		private bool bool_0 = false;

		internal MouseState mouseState_0 = MouseState.const_2;

		private bool bool_1 = true;

		private string string_0 = "Enter Text";

		private bool bool_2 = false;

		private char char_0;

		public EventHandler eventHandler_0;

		public bool Boolean_0
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					this.bool_1 = value;
					this.vmethod_0(value);
				}
				if (value)
				{
					this.method_0(bool_3: true);
				}
				else
				{
					this.method_0(bool_3: false);
				}
			}
		}

		public string String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				if (this.Text == "")
				{
					this.Boolean_0 = false;
					this.OnTextChanged(EventArgs.Empty);
				}
				else
				{
					this.Boolean_0 = true;
					this.OnTextChanged(EventArgs.Empty);
				}
			}
		}

		[Category("Options")]
		public char Char_0
		{
			get
			{
				return this.char_0;
			}
			set
			{
				this.char_0 = value;
				base.PasswordChar = value;
			}
		}

		[Browsable(false)]
		public override string Text
		{
			get
			{
				if (this.Boolean_0)
				{
					return "";
				}
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, EventArgs.Empty);
				}
			}
		}

		public event Delegate2 Event_0
		{
			[CompilerGenerated]
			add
			{
				Delegate2 @delegate = this.delegate2_0;
				Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					@delegate = Interlocked.CompareExchange(value: (Delegate2)Delegate.Combine(delegate2, value), location1: ref this.delegate2_0, comparand: delegate2);
				}
				while ((object)@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Delegate2 @delegate = this.delegate2_0;
				Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					@delegate = Interlocked.CompareExchange(value: (Delegate2)Delegate.Remove(delegate2, value), location1: ref this.delegate2_0, comparand: delegate2);
				}
				while ((object)@delegate != delegate2);
			}
		}

		public event Delegate3 Event_1
		{
			[CompilerGenerated]
			add
			{
				Delegate3 @delegate = this.delegate3_0;
				Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					@delegate = Interlocked.CompareExchange(value: (Delegate3)Delegate.Combine(delegate2, value), location1: ref this.delegate3_0, comparand: delegate2);
				}
				while ((object)@delegate != delegate2);
			}
			[CompilerGenerated]
			remove
			{
				Delegate3 @delegate = this.delegate3_0;
				Delegate3 delegate2;
				do
				{
					delegate2 = @delegate;
					@delegate = Interlocked.CompareExchange(value: (Delegate3)Delegate.Remove(delegate2, value), location1: ref this.delegate3_0, comparand: delegate2);
				}
				while ((object)@delegate != delegate2);
			}
		}

		protected virtual void vmethod_0(bool bool_3)
		{
			if (this.delegate2_0 != null)
			{
				this.delegate2_0(bool_3);
			}
		}

		protected virtual void vmethod_1(bool bool_3)
		{
			if (this.delegate3_0 != null)
			{
				this.delegate3_0(bool_3);
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
			this.vmethod_1(bool_3: false);
		}

		private void method_0(bool bool_3)
		{
			if (this.bool_2 != bool_3)
			{
				this.bool_2 = bool_3;
				base.SetStyle(ControlStyles.UserMouse, this.bool_2);
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			if (this.Boolean_0)
			{
				base.Select(0, 0);
			}
			base.OnGotFocus(e);
			this.vmethod_1(bool_3: true);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (this.Boolean_0 && ((e.KeyCode == Keys.Right) | (e.KeyCode == Keys.Down) | (e.KeyCode == Keys.Left) | (e.KeyCode == Keys.Delete) | (e.KeyCode == Keys.A && e.Control)))
			{
				this.method_0(bool_3: true);
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			if (base.Text == string.Empty && this.String_0 != "")
			{
				this.Boolean_0 = true;
				this.Text = this.String_0;
				base.OnTextChanged(e);
			}
			else if (!this.Boolean_0 | (base.Text == string.Empty))
			{
				base.OnTextChanged(e);
			}
			else if (this.String_0 == "")
			{
				this.Boolean_0 = false;
				base.OnTextChanged(e);
			}
			else
			{
				if (!this.Boolean_0)
				{
					return;
				}
				if (base.TextLength > this.String_0.Length)
				{
					this.Boolean_0 = false;
					if (base.Text.Contains(this.String_0) && base.Text.Length > this.String_0.Length && this.String_0 != "")
					{
						this.Text = base.Text.Replace(this.String_0, "");
						base.Select(this.Text.Length, 0);
					}
				}
				if (base.Text != this.String_0)
				{
					this.Boolean_0 = false;
				}
				if (base.TextLength > this.String_0.Length)
				{
					this.Boolean_0 = false;
				}
			}
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ns0;

namespace ns1
{
	[Description("A resize form control")]
	[ToolboxItem(true)]
	[DebuggerStepThrough]
	public class SiticoneResizeForm : Component
	{
		private class Control0 : Control
		{
			public void method_0(Message message_0)
			{
				base.DefWndProc(ref message_0);
			}
		}

		private IContainer icontainer_0 = null;

		private Form form_0;

		private Message[] message_0;

		private Point point_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private int int_0;

		private int int_1;

		private Control0 control0_0;

		public SiticoneResizeForm()
		{
			this.method_0();
			Class13.smethod_0();
		}

		public SiticoneResizeForm(Form form)
		{
			this.method_0();
			Class13.smethod_0();
			this.SetResizeForm(form);
		}

		public SiticoneResizeForm(IContainer container)
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
			this.message_0 = new Message[9];
			this.control0_0 = new Control0();
		}

		private void method_1(Rectangle rectangle_0)
		{
			if (this.form_0.Width > rectangle_0.Width)
			{
				this.form_0.Width = rectangle_0.Width;
			}
			if (this.form_0.Height > rectangle_0.Height)
			{
				this.form_0.Height = rectangle_0.Height;
			}
			int num = this.form_0.Location.X;
			int num2 = this.form_0.Location.Y;
			if (num < rectangle_0.X)
			{
				num = rectangle_0.X;
			}
			if (num2 < rectangle_0.Y)
			{
				num2 = rectangle_0.Y;
			}
			int num3 = rectangle_0.X + rectangle_0.Width;
			int num4 = rectangle_0.Y + rectangle_0.Height;
			if (num + this.form_0.Width > num3)
			{
				num = num3 - this.form_0.Width;
			}
			if (num2 + this.form_0.Height > num4)
			{
				num2 = num4 - this.form_0.Height;
			}
			this.form_0.Location = new Point(num, num2);
		}

		private int method_2()
		{
			Form form = this.form_0;
			this.method_6();
			this.point_0 = form.PointToClient(this.method_6());
			this.bool_0 = this.point_0.X < 7;
			this.bool_1 = this.point_0.X > this.form_0.Width - 7;
			this.bool_2 = this.point_0.Y < 7;
			this.bool_3 = this.point_0.Y > this.form_0.Height - 7;
			if (this.bool_0 && this.bool_2)
			{
				return 4;
			}
			if (this.bool_0 && this.bool_3)
			{
				return 7;
			}
			if (this.bool_1 && this.bool_2)
			{
				return 5;
			}
			if (this.bool_1 && this.bool_3)
			{
				return 8;
			}
			if (this.bool_0)
			{
				return 1;
			}
			if (this.bool_1)
			{
				return 2;
			}
			if (this.bool_2)
			{
				return 3;
			}
			if (this.bool_3)
			{
				return 6;
			}
			return 0;
		}

		private void method_3()
		{
			this.int_0 = this.method_2();
			if (this.int_0 != this.int_1)
			{
				this.int_1 = this.int_0;
				if (this.int_1 == 0)
				{
					this.form_0.Cursor = Cursors.Default;
				}
				if ((this.int_1 == 1) | (this.int_1 == 2))
				{
					this.form_0.Cursor = Cursors.SizeWE;
				}
				if ((this.int_1 == 3) | (this.int_1 == 6))
				{
					this.form_0.Cursor = Cursors.SizeNS;
				}
				if ((this.int_1 == 4) | (this.int_1 == 8))
				{
					this.form_0.Cursor = Cursors.SizeNWSE;
				}
				if ((this.int_1 == 5) | (this.int_1 == 7))
				{
					this.form_0.Cursor = Cursors.SizeNESW;
				}
			}
		}

		private void method_4(object object_0, string string_0, object[] object_1)
		{
			object_0.GetType().GetMethod(string_0).Invoke(object_0, object_1);
		}

		private object method_5(object object_0, string string_0, object[] object_1)
		{
			return object_0.GetType().GetMethod(string_0).Invoke(object_0, object_1);
		}

		private void form_0_MouseMove(object sender, MouseEventArgs e)
		{
			if (sender != null && ((Form)sender).WindowState != FormWindowState.Maximized)
			{
				this.method_3();
			}
		}

		private Point method_6()
		{
			return Control.MousePosition;
		}

		private void form_0_MouseLeave(object sender, EventArgs e)
		{
			if (sender != null)
			{
				Form form = (Form)sender;
				if (form.GetChildAtPoint(this.method_6()) != null)
				{
					form.Cursor = Cursors.Default;
				}
			}
		}

		private void form_0_MouseDown(object sender, MouseEventArgs e)
		{
			if (sender == null)
			{
				return;
			}
			Form form = (Form)sender;
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			if (form.WindowState != FormWindowState.Maximized)
			{
				form.Capture = false;
				if (this.int_1 != 0)
				{
					this.control0_0.method_0(this.message_0[this.int_1]);
				}
			}
			else
			{
				form.Capture = false;
				this.control0_0.method_0(this.message_0[0]);
			}
		}

		public void SetResizeForm(Form form)
		{
			if (this.form_0 != form)
			{
				this.Clear();
				this.form_0 = form;
				this.method_7();
			}
		}

		public void Clear()
		{
			try
			{
				if (this.form_0 != null)
				{
					this.form_0.MouseMove -= new MouseEventHandler(form_0_MouseMove);
					this.form_0.MouseLeave -= new EventHandler(form_0_MouseLeave);
					this.form_0.MouseDown -= new MouseEventHandler(form_0_MouseDown);
					this.form_0 = null;
				}
			}
			catch
			{
			}
		}

		private void method_7()
		{
			try
			{
				if (this.form_0 == null)
				{
					return;
				}
				this.form_0.FormBorderStyle = FormBorderStyle.None;
				this.form_0.MouseMove += new MouseEventHandler(form_0_MouseMove);
				this.form_0.MouseLeave += new EventHandler(form_0_MouseLeave);
				this.form_0.MouseDown += new MouseEventHandler(form_0_MouseDown);
				if (!base.DesignMode)
				{
					this.message_0[0] = Message.Create(this.form_0.Handle, 161, new IntPtr(2), IntPtr.Zero);
					int num = 1;
					do
					{
						this.message_0[num] = Message.Create(this.form_0.Handle, 161, new IntPtr(num + 9), IntPtr.Zero);
						num++;
					}
					while (num <= 8);
				}
			}
			catch
			{
			}
		}
	}
}

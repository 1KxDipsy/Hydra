using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns0;
using ns6;

namespace ns1
{
	[Description("A component to apply radius to the winform edges")]
	[ToolboxItem(true)]
	public class SiticoneElipse : Component
	{
		private IContainer icontainer_0 = null;

		private Control control_0;

		private int int_0 = 6;

		[Description("The curve angle of the control on all angles")]
		[Browsable(true)]
		[DefaultValue(6)]
		public int BorderRadius
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.method_1(this.control_0, this.int_0);
			}
		}

		[Description("The target control to apply curves to the edges")]
		[Browsable(true)]
		[DefaultValue(typeof(Control), "")]
		public Control TargetControl
		{
			get
			{
				return this.control_0;
			}
			set
			{
				this.Clear();
				this.control_0 = value;
				this.method_2();
			}
		}

		public SiticoneElipse()
		{
			this.method_0();
			Class13.smethod_0();
		}

		public SiticoneElipse(Control control)
		{
			this.method_0();
			Class13.smethod_0();
			this.SetElipse(control);
		}

		public SiticoneElipse(IContainer container)
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

		public void SetElipse(Control control)
		{
			this.Clear();
			this.control_0 = control;
			this.method_2();
		}

		private void method_1(Control control_1, int int_1)
		{
			try
			{
				if (control_1.GetType() == typeof(Form))
				{
					Form form = (Form)control_1;
					form.FormBorderStyle = FormBorderStyle.None;
					form.Region = Region.FromHrgn(WinApi.CreateRoundRectRgn(0, 0, form.Width, form.Height, int_1, int_1));
				}
				else
				{
					control_1.Region = Region.FromHrgn(WinApi.CreateRoundRectRgn(0, 0, control_1.Width, control_1.Height, int_1, int_1));
				}
			}
			catch
			{
			}
		}

		private void control_0_Resize(object sender, EventArgs e)
		{
			try
			{
				this.method_1(this.control_0, this.int_0);
			}
			catch
			{
			}
		}

		public void Clear()
		{
			if (this.control_0 != null)
			{
				this.method_1(this.control_0, 0);
				this.control_0.Resize -= new EventHandler(control_0_Resize);
				this.control_0 = null;
			}
		}

		private void method_2()
		{
			if (this.control_0 != null)
			{
				this.method_1(this.control_0, this.int_0);
				this.control_0.Resize += new EventHandler(control_0_Resize);
			}
		}
	}
}

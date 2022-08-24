using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using ns0;
using ns6;

namespace ns1
{
	[ToolboxItem(true)]
	[DebuggerStepThrough]
	[Description("The component that is used to drag a borderless winform")]
	public class SiticoneDragControl : Component
	{
		private IContainer icontainer_0 = null;

		private Control control_0;

		[Description("The control to use to drag a target winfrom. The control should be a child control of the winform ")]
		public Control TargetControl
		{
			get
			{
				return this.control_0;
			}
			set
			{
				if (this.control_0 != value)
				{
					if (this.control_0 != null)
					{
						this.control_0.MouseDown -= new MouseEventHandler(control_0_MouseDown);
					}
					this.control_0 = value;
					if (this.control_0 != null)
					{
						this.control_0.MouseDown += new MouseEventHandler(control_0_MouseDown);
					}
				}
			}
		}

		public SiticoneDragControl()
		{
			this.method_0();
			Class13.smethod_0();
		}

		public SiticoneDragControl(Control control)
		{
			this.method_0();
			this.TargetControl = control;
			Class13.smethod_0();
		}

		public SiticoneDragControl(IContainer container)
		{
			container.Add(this);
			this.method_0();
			Class13.smethod_0();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				if (this.control_0 != null)
				{
					this.control_0.MouseDown -= new MouseEventHandler(control_0_MouseDown);
				}
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_0()
		{
			this.icontainer_0 = new Container();
		}

		public void SetDrag(Control control)
		{
			this.TargetControl = control;
		}

		private void control_0_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.control_0 != null)
			{
				WinApi.ReleaseCapture();
				WinApi.SendMessage(this.control_0.FindForm().Handle, 161, 2, 0);
			}
		}
	}
}

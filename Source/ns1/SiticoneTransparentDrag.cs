using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ns1
{
	[Description("Siticone drag component that drags borderless winforms while applying a transparent background")]
	[ToolboxBitmap(typeof(Process))]
	[DebuggerStepThrough]
	public class SiticoneTransparentDrag : Component
	{
		private Control control_0;

		private double double_0 = 0.9;

		private double double_1 = 1.0;

		[Browsable(true)]
		[Description("Choose the control that will be used to drag the form")]
		[Category("Siticone Control Features")]
		public Control TargetDragControl
		{
			get
			{
				return this.control_0;
			}
			set
			{
				this.control_0 = value;
				try
				{
					this.control_0.MouseDown += new MouseEventHandler(control_0_MouseDown);
				}
				catch (Exception ex)
				{
					ex.Message.ToString();
				}
			}
		}

		[Description("The transparency value that will be applied when the dragging starts")]
		[Category("Siticone Control Features")]
		[Browsable(true)]
		public double DragStartTransparencyValue
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
				if (this.double_0 > 0.9)
				{
					this.double_0 = 0.9;
				}
				else if (this.double_0 < 0.1)
				{
					this.double_0 = 0.1;
				}
			}
		}

		[Category("Siticone Control Features")]
		[Description("The transparency value that will be applied when the dragging ends. The default value is 1")]
		[Browsable(true)]
		public double DragEndTransparencyValue
		{
			get
			{
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
				if (this.double_1 > 1.0)
				{
					this.double_1 = 1.0;
				}
				else if (this.double_1 <= 0.0)
				{
					this.double_1 = 0.1;
				}
			}
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr a, int msg, int wParam, int IParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private void control_0_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.TargetDragControl.FindForm().Opacity = this.DragStartTransparencyValue;
				SiticoneTransparentDrag.ReleaseCapture();
				SiticoneTransparentDrag.SendMessage(this.TargetDragControl.FindForm().Handle, 161, 2, 0);
				this.TargetDragControl.FindForm().Opacity = this.DragEndTransparencyValue;
			}
		}
	}
}

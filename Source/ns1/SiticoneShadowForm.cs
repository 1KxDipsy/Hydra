using System.ComponentModel;
using System.Windows.Forms;
using ns2;

namespace ns1
{
	[Description("A ShadowForm Component")]
	[ToolboxItem(true)]
	public class SiticoneShadowForm : Component
	{
		private ShadowForm shadowForm_0;

		private Form form_0;

		private ns2.Panel panel_0 = new ns2.Panel();

		private IContainer icontainer_0 = null;

		private FormBorderStyle formBorderStyle_0;

		public SiticoneShadowForm()
		{
			this.method_0();
		}

		public SiticoneShadowForm(Form form)
		{
			this.method_0();
			this.SetShadowForm(form);
		}

		public SiticoneShadowForm(IContainer container)
		{
			container.Add(this);
			this.method_0();
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

		public void SetShadowForm(Form form)
		{
			if (this.form_0 != form)
			{
				this.Clear();
				this.form_0 = form;
				this.method_1();
			}
		}

		private void method_1()
		{
			try
			{
				if (this.form_0 != null)
				{
					this.formBorderStyle_0 = this.form_0.FormBorderStyle;
					this.shadowForm_0 = new ShadowForm(this.form_0);
				}
			}
			catch
			{
			}
		}

		public void Clear()
		{
			try
			{
				if (this.form_0 != null && this.shadowForm_0 != null)
				{
					this.form_0.FormBorderStyle = this.formBorderStyle_0;
					this.shadowForm_0.Dispose();
					this.form_0 = null;
				}
			}
			catch
			{
			}
		}
	}
}

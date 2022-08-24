using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns17;

namespace ns0
{
	[ToolboxItem(false)]
	internal class Control4 : TabControl
	{
		private Animator animator_0;

		private IContainer icontainer_0 = null;

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Animation Animation_0
		{
			get
			{
				return this.animator_0.DefaultAnimation;
			}
			set
			{
				this.animator_0.DefaultAnimation = value;
			}
		}

		public Control4()
		{
			this.method_0();
			this.animator_0 = new Animator();
			this.animator_0.AnimationType = AnimationType.VertSlide;
			this.animator_0.DefaultAnimation.TimeCoeff = 1f;
			this.animator_0.DefaultAnimation.AnimateOnlyDifferences = false;
		}

		protected override void OnSelecting(TabControlCancelEventArgs e)
		{
			base.OnSelecting(e);
			this.animator_0.BeginUpdate(this, parallel: false, null, new Rectangle(0, base.ItemSize.Height + 3, base.Width, base.Height - base.ItemSize.Height - 3));
			base.BeginInvoke((MethodInvoker)delegate
			{
				this.animator_0.EndUpdate(this);
			});
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

		[CompilerGenerated]
		private void method_1()
		{
			this.animator_0.EndUpdate(this);
		}
	}
}

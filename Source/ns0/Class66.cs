using System;
using System.Windows.Forms;
using ns11;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class66 : RContextMenu
	{
		private readonly ContextMenuStrip contextMenuStrip_0;

		public override int ItemsCount => this.contextMenuStrip_0.Items.Count;

		public Class66()
		{
			this.contextMenuStrip_0 = new ContextMenuStrip();
			this.contextMenuStrip_0.ShowImageMargin = false;
		}

		public override void AddDivider()
		{
			this.contextMenuStrip_0.Items.Add("-");
		}

		public override void AddItem(string text, bool enabled, EventHandler onClick)
		{
			ArgChecker.AssertArgNotNullOrEmpty(text, "text");
			ArgChecker.AssertArgNotNull(onClick, "onClick");
			this.contextMenuStrip_0.Items.Add(text, null, onClick).Enabled = enabled;
		}

		public override void RemoveLastDivider()
		{
			if (this.contextMenuStrip_0.Items[this.contextMenuStrip_0.Items.Count - 1].Text == string.Empty)
			{
				this.contextMenuStrip_0.Items.RemoveAt(this.contextMenuStrip_0.Items.Count - 1);
			}
		}

		public override void Show(RControl parent, RPoint location)
		{
			this.contextMenuStrip_0.Show(((Control2)parent).Control_0, Class19.smethod_3(location));
		}

		public override void Dispose()
		{
			this.contextMenuStrip_0.Dispose();
		}
	}
}

using System;
using System.Drawing;
using System.Windows.Forms;
using ns1;

namespace ns4
{
	public class PanelScrollHelper
	{
		public class VScrollBarPanelHelper
		{
			private SiticoneVScrollBar siticoneVScrollBar_0;

			private Panel panel_0;

			private bool bool_0;

			private bool bool_1;

			public VScrollBarPanelHelper(Panel panel, SiticoneVScrollBar vScrollBar, bool autoSizeAndLocation = true)
			{
				this.bool_0 = true;
				this.bool_1 = false;
				this.panel_0 = panel;
				this.siticoneVScrollBar_0 = vScrollBar;
				this.bool_0 = autoSizeAndLocation;
				this.panel_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				this.panel_0.AutoScroll = true;
				this.siticoneVScrollBar_0.Scroll += new ScrollEventHandler(siticoneVScrollBar_0_Scroll);
				this.panel_0.MouseWheel += new MouseEventHandler(panel_0_MouseWheel);
				this.panel_0.SizeChanged += new EventHandler(panel_0_SizeChanged);
				this.panel_0.ControlAdded += new ControlEventHandler(panel_0_ControlAdded);
				this.panel_0.ControlRemoved += new ControlEventHandler(panel_0_ControlRemoved);
				this.updateScrollBar();
			}

			private void panel_0_SizeChanged(object sender, EventArgs e)
			{
				this.updateScrollBar();
			}

			private void panel_0_ControlAdded(object sender, ControlEventArgs e)
			{
				this.updateScrollBar();
			}

			private void panel_0_ControlRemoved(object sender, ControlEventArgs e)
			{
				this.updateScrollBar();
			}

			private void panel_0_MouseWheel(object sender, MouseEventArgs e)
			{
				this.bool_1 = true;
				if (this.siticoneVScrollBar_0 != null)
				{
					try
					{
						this.siticoneVScrollBar_0.Value = this.panel_0.VerticalScroll.Value;
						this.updateScrollBar();
					}
					catch
					{
					}
				}
				this.bool_1 = false;
			}

			private void siticoneVScrollBar_0_Scroll(object sender, ScrollEventArgs e)
			{
				if (!this.bool_1)
				{
					this.panel_0.VerticalScroll.Value = this.siticoneVScrollBar_0.Value;
				}
			}

			public void updateScrollBar()
			{
				try
				{
					if (this.siticoneVScrollBar_0 == null)
					{
						return;
					}
					if (this.bool_0)
					{
						if (this.panel_0.HorizontalScroll.Visible)
						{
							this.siticoneVScrollBar_0.Height = this.panel_0.Height - Math.Max(18, SystemInformation.HorizontalScrollBarHeight);
						}
						else
						{
							this.siticoneVScrollBar_0.Height = this.panel_0.Height;
						}
						this.siticoneVScrollBar_0.Height = this.panel_0.Height;
						this.siticoneVScrollBar_0.Width = Math.Max(18, SystemInformation.VerticalScrollBarWidth);
						this.siticoneVScrollBar_0.Location = new Point(checked(this.panel_0.Location.X + (this.panel_0.Width - this.siticoneVScrollBar_0.Width)), this.panel_0.Location.Y);
						this.siticoneVScrollBar_0.BringToFront();
					}
					this.siticoneVScrollBar_0.Maximum = this.panel_0.VerticalScroll.Maximum;
					this.siticoneVScrollBar_0.Minimum = this.panel_0.VerticalScroll.Minimum;
					this.siticoneVScrollBar_0.LargeChange = this.panel_0.VerticalScroll.LargeChange;
					this.siticoneVScrollBar_0.SmallChange = this.panel_0.VerticalScroll.SmallChange;
					this.siticoneVScrollBar_0.Value = this.panel_0.VerticalScroll.Value;
					this.siticoneVScrollBar_0.Visible = this.panel_0.VerticalScroll.Visible;
				}
				catch
				{
				}
			}
		}

		public class HScrollBarPanelHelper
		{
			private SiticoneHScrollBar siticoneHScrollBar_0;

			private Panel panel_0;

			private bool bool_0;

			public HScrollBarPanelHelper(Panel panel, SiticoneHScrollBar hScrollBar, bool autoSizeAndLocation = true)
			{
				this.bool_0 = true;
				this.panel_0 = panel;
				this.siticoneHScrollBar_0 = hScrollBar;
				this.bool_0 = autoSizeAndLocation;
				this.panel_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				this.panel_0.AutoScroll = true;
				this.siticoneHScrollBar_0.Scroll += new ScrollEventHandler(siticoneHScrollBar_0_Scroll);
				this.panel_0.ControlAdded += new ControlEventHandler(panel_0_ControlAdded);
				this.panel_0.ControlRemoved += new ControlEventHandler(panel_0_ControlRemoved);
				this.panel_0.SizeChanged += new EventHandler(panel_0_SizeChanged);
				this.updateScrollBar();
			}

			private void panel_0_SizeChanged(object sender, EventArgs e)
			{
				this.updateScrollBar();
			}

			private void panel_0_ControlAdded(object sender, ControlEventArgs e)
			{
				this.updateScrollBar();
			}

			private void panel_0_ControlRemoved(object sender, ControlEventArgs e)
			{
				this.updateScrollBar();
			}

			private void siticoneHScrollBar_0_Scroll(object sender, ScrollEventArgs e)
			{
				this.panel_0.HorizontalScroll.Value = this.siticoneHScrollBar_0.Value;
			}

			public void updateScrollBar()
			{
				checked
				{
					try
					{
						if (this.siticoneHScrollBar_0 == null)
						{
							return;
						}
						if (this.bool_0)
						{
							if (this.panel_0.VerticalScroll.Visible)
							{
								this.siticoneHScrollBar_0.Width = this.panel_0.Width - Math.Max(18, SystemInformation.VerticalScrollBarWidth);
								this.siticoneHScrollBar_0.FillOffset = new Padding(this.siticoneHScrollBar_0.FillOffset.Left, this.siticoneHScrollBar_0.FillOffset.Top, Math.Max(18, SystemInformation.VerticalScrollBarWidth), this.siticoneHScrollBar_0.FillOffset.Bottom);
							}
							else
							{
								this.siticoneHScrollBar_0.Width = this.panel_0.Width;
							}
							this.siticoneHScrollBar_0.Height = Math.Max(18, SystemInformation.HorizontalScrollBarHeight);
							this.siticoneHScrollBar_0.Location = new Point(this.panel_0.Location.X, this.panel_0.Location.Y + this.panel_0.Height - this.siticoneHScrollBar_0.Height);
							this.siticoneHScrollBar_0.BringToFront();
						}
						this.siticoneHScrollBar_0.Maximum = this.panel_0.HorizontalScroll.Maximum;
						this.siticoneHScrollBar_0.Minimum = this.panel_0.HorizontalScroll.Minimum;
						this.siticoneHScrollBar_0.LargeChange = this.panel_0.HorizontalScroll.LargeChange;
						this.siticoneHScrollBar_0.SmallChange = this.panel_0.HorizontalScroll.SmallChange;
						this.siticoneHScrollBar_0.Value = this.panel_0.HorizontalScroll.Value;
						this.siticoneHScrollBar_0.Visible = this.panel_0.HorizontalScroll.Visible;
					}
					catch
					{
					}
				}
			}
		}

		private HScrollBarPanelHelper hscrollBarPanelHelper_0;

		private VScrollBarPanelHelper vscrollBarPanelHelper_0;

		public PanelScrollHelper(Panel panel, SiticoneVScrollBar vScrollBar, bool autoSizeAndLocationOfScrollBar = true)
		{
			this.vscrollBarPanelHelper_0 = new VScrollBarPanelHelper(panel, vScrollBar, autoSizeAndLocationOfScrollBar);
		}

		public PanelScrollHelper(Panel panel, SiticoneHScrollBar hScrollBar, bool autoSizeAndLocationOfScrollBar = true)
		{
			this.hscrollBarPanelHelper_0 = new HScrollBarPanelHelper(panel, hScrollBar, autoSizeAndLocationOfScrollBar);
		}

		public void UpdateScrollBar()
		{
			if (this.hscrollBarPanelHelper_0 != null)
			{
				this.hscrollBarPanelHelper_0.updateScrollBar();
			}
			if (this.vscrollBarPanelHelper_0 != null)
			{
				this.vscrollBarPanelHelper_0.updateScrollBar();
			}
		}
	}
}

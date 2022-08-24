using System;
using System.Drawing;
using System.Windows.Forms;
using ns1;

namespace ns4
{
	public class ListViewScrollHelper
	{
		internal class Class11
		{
			private ListView listView_0;

			private SiticoneVScrollBar siticoneVScrollBar_0;

			private bool bool_0;

			private bool bool_1;

			public Class11(ListView listView_1, SiticoneVScrollBar siticoneVScrollBar_1, bool bool_2 = true)
			{
				this.bool_0 = true;
				this.bool_1 = false;
				this.listView_0 = listView_1;
				this.siticoneVScrollBar_0 = siticoneVScrollBar_1;
				this.bool_0 = bool_2;
				this.listView_0.SizeChanged += new EventHandler(listView_0_SizeChanged);
				this.listView_0.MouseWheel += new MouseEventHandler(listView_0_MouseWheel);
				this.siticoneVScrollBar_0.Scroll += new ScrollEventHandler(siticoneVScrollBar_0_Scroll);
				this.method_5();
			}

			private void listView_0_SizeChanged(object sender, EventArgs e)
			{
				this.method_5();
			}

			private void listView_0_MouseWheel(object sender, EventArgs e)
			{
				this.bool_1 = true;
				if (this.siticoneVScrollBar_0 != null)
				{
					try
					{
						this.siticoneVScrollBar_0.Value = this.method_1();
						this.method_5();
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
					this.method_3(this.siticoneVScrollBar_0.Value);
				}
			}

			internal int method_0()
			{
				try
				{
					if (this.listView_0.Items != null && this.listView_0.Items.Count > 0)
					{
						return this.listView_0.GetItemRect(0).Height;
					}
				}
				catch
				{
				}
				return 0;
			}

			public int method_1()
			{
				try
				{
					if (this.listView_0.TopItem != null)
					{
						return checked(this.listView_0.TopItem.Index * this.method_0());
					}
				}
				catch
				{
				}
				return 0;
			}

			internal int method_2()
			{
				try
				{
					if (this.listView_0.Items != null && this.listView_0.Items.Count > 0)
					{
						return checked(this.method_0() * this.listView_0.Items.Count);
					}
				}
				catch
				{
				}
				return 0;
			}

			public void method_3(int int_0)
			{
				checked
				{
					try
					{
						if (this.listView_0.Items != null && this.listView_0.Items.Count > 0)
						{
							int num = this.method_0();
							if (int_0 == 0)
							{
								this.listView_0.TopItem = this.listView_0.Items[0];
								return;
							}
							if (int_0 >= num * this.listView_0.Items.Count)
							{
								this.listView_0.TopItem = this.listView_0.Items[this.listView_0.Items.Count - 1];
								return;
							}
							int num2 = (int)Math.Round(Math.Round((double)int_0 / (double)num, 0, MidpointRounding.AwayFromZero));
							this.listView_0.TopItem = this.listView_0.Items[num2 + 1];
						}
					}
					catch
					{
					}
				}
			}

			private int method_4()
			{
				if (this.listView_0.Items.Count > 0)
				{
					return checked((int)Math.Round((double)this.listView_0.Items[0].GetBounds(ItemBoundsPortion.Entire).Height + (double)this.listView_0.Items[0].GetBounds(ItemBoundsPortion.Entire).Height / 2.0));
				}
				return 0;
			}

			public void method_5()
			{
				checked
				{
					try
					{
						if (this.siticoneVScrollBar_0 == null)
						{
							return;
						}
						if (this.bool_0)
						{
							this.siticoneVScrollBar_0.Height = this.listView_0.Height;
							this.siticoneVScrollBar_0.Location = new Point(this.listView_0.Location.X + (this.listView_0.Width - this.siticoneVScrollBar_0.Width), this.listView_0.Location.Y);
							this.siticoneVScrollBar_0.BringToFront();
						}
						if (this.listView_0.Items.Count > 0)
						{
							this.siticoneVScrollBar_0.Maximum = this.method_2();
							this.siticoneVScrollBar_0.ThumbSize = (float)Math.Round(Math.Max(30.0, (double)this.siticoneVScrollBar_0.Height * ((double)this.siticoneVScrollBar_0.Height / (double)this.method_2() * 100.0 / 100.0)));
							this.siticoneVScrollBar_0.Width = Math.Max(18, SystemInformation.VerticalScrollBarWidth);
							if (this.method_2() + this.method_4() >= this.listView_0.Height)
							{
								this.siticoneVScrollBar_0.Visible = true;
							}
							else
							{
								this.siticoneVScrollBar_0.Visible = false;
							}
						}
						else
						{
							this.siticoneVScrollBar_0.Visible = false;
						}
					}
					catch
					{
					}
				}
			}
		}

		private Class11 class11_0;

		public ListViewScrollHelper(ListView listView, SiticoneVScrollBar vScrollBar, bool autoSizeAndLocationOfScrollBar)
		{
			this.class11_0 = new Class11(listView, vScrollBar, autoSizeAndLocationOfScrollBar);
		}

		public void UpdateScrollBar()
		{
			this.class11_0.method_5();
		}
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns1;

namespace ns4
{
	public class DataGridViewScrollHelper
	{
		internal class Class9
		{
			private bool bool_0;

			private bool bool_1;

			private SiticoneVScrollBar siticoneVScrollBar_0;

			private DataGridView dataGridView_0;

			private int int_0;

			private VScrollBar vscrollBar_0;

			private HScrollBar hscrollBar_0;

			public Class9(DataGridView dataGridView_1, SiticoneVScrollBar siticoneVScrollBar_1, bool bool_2 = true)
			{
				this.bool_0 = true;
				this.bool_1 = false;
				this.siticoneVScrollBar_0 = siticoneVScrollBar_1;
				this.dataGridView_0 = dataGridView_1;
				this.bool_0 = bool_2;
				try
				{
					foreach (object control in this.dataGridView_0.Controls)
					{
						if (control.GetType() == typeof(VScrollBar))
						{
							this.vscrollBar_0 = (VScrollBar)control;
						}
						if (control.GetType() == typeof(HScrollBar))
						{
							this.hscrollBar_0 = (HScrollBar)control;
						}
					}
				}
				catch
				{
				}
				this.dataGridView_0.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView_0_RowsAdded);
				this.dataGridView_0.UserDeletedRow += new DataGridViewRowEventHandler(dataGridView_0_UserDeletedRow);
				this.dataGridView_0.MouseWheel += new MouseEventHandler(dataGridView_0_MouseWheel);
				this.dataGridView_0.Resize += new EventHandler(dataGridView_0_Resize);
				this.siticoneVScrollBar_0.Scroll += new ScrollEventHandler(siticoneVScrollBar_0_Scroll);
				this.method_2();
			}

			private void dataGridView_0_MouseWheel(object sender, EventArgs e)
			{
				this.bool_1 = true;
				if (this.siticoneVScrollBar_0 != null)
				{
					try
					{
						this.method_2();
					}
					catch
					{
					}
				}
				this.bool_1 = false;
			}

			private void dataGridView_0_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
			{
				this.method_2();
			}

			private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
			{
				this.method_2();
			}

			private void siticoneVScrollBar_0_Scroll(object sender, ScrollEventArgs e)
			{
				if (this.bool_1 || this.int_0 > 0)
				{
					return;
				}
				checked
				{
					try
					{
						int num = ((this.siticoneVScrollBar_0.Value < 0 || this.siticoneVScrollBar_0.Value >= this.dataGridView_0.Rows.Count) ? (this.siticoneVScrollBar_0.Value - 1) : ((this.siticoneVScrollBar_0.Value + ((this.siticoneVScrollBar_0.Value != 1) ? 1 : (-1)) >= this.dataGridView_0.Rows.Count) ? (this.dataGridView_0.Rows.Count - 1) : (this.siticoneVScrollBar_0.Value + ((this.siticoneVScrollBar_0.Value != 1) ? 1 : (-1)))));
						while (!this.dataGridView_0.Rows[num].Visible)
						{
							num = ((num >= 1) ? (num - 1) : 0);
						}
						this.dataGridView_0.FirstDisplayedScrollingRowIndex = num;
					}
					catch
					{
						this.dataGridView_0.FirstDisplayedScrollingRowIndex = 0;
					}
				}
			}

			private void method_0()
			{
				this.int_0++;
			}

			private void method_1()
			{
				if (this.int_0 > 0)
				{
					this.int_0--;
				}
			}

			public void method_2()
			{
				if (this.dataGridView_0 == null)
				{
					return;
				}
				checked
				{
					try
					{
						this.method_0();
						try
						{
							if (this.bool_0)
							{
								if (this.hscrollBar_0.Visible)
								{
									this.siticoneVScrollBar_0.Height = this.dataGridView_0.Height - Math.Max(18, SystemInformation.HorizontalScrollBarHeight);
								}
								else
								{
									this.siticoneVScrollBar_0.Height = this.dataGridView_0.Height;
								}
								this.siticoneVScrollBar_0.Width = Math.Max(18, SystemInformation.VerticalScrollBarWidth);
								this.siticoneVScrollBar_0.Location = new Point(this.dataGridView_0.Location.X + (this.dataGridView_0.Width - this.siticoneVScrollBar_0.Width), this.dataGridView_0.Location.Y);
								this.siticoneVScrollBar_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
								this.siticoneVScrollBar_0.BringToFront();
							}
						}
						catch
						{
						}
						int num = this.method_3();
						this.siticoneVScrollBar_0.Maximum = this.dataGridView_0.RowCount;
						this.siticoneVScrollBar_0.Minimum = 1;
						this.siticoneVScrollBar_0.SmallChange = 1;
						this.siticoneVScrollBar_0.LargeChange = Math.Max(1, num - 1);
						this.siticoneVScrollBar_0.Value = this.dataGridView_0.FirstDisplayedScrollingRowIndex;
						this.siticoneVScrollBar_0.Visible = this.vscrollBar_0.Visible;
					}
					finally
					{
						this.method_1();
					}
				}
			}

			private int method_3()
			{
				return this.dataGridView_0.DisplayedRowCount(includePartialRow: true);
			}

			private int method_4()
			{
				return this.dataGridView_0.DisplayedColumnCount(includePartialColumns: true);
			}

			private bool method_5()
			{
				bool result = false;
				if (this.dataGridView_0.DisplayedRowCount(includePartialRow: true) < checked(this.dataGridView_0.RowCount + (this.dataGridView_0.RowHeadersVisible ? 1 : 0)))
				{
					result = true;
				}
				return result;
			}

			private bool method_6()
			{
				bool result = false;
				if (this.dataGridView_0.DisplayedColumnCount(includePartialColumns: true) < checked(this.dataGridView_0.ColumnCount + (this.dataGridView_0.ColumnHeadersVisible ? 1 : 0)))
				{
					result = true;
				}
				return result;
			}

			private void dataGridView_0_Resize(object sender, EventArgs e)
			{
				this.method_2();
			}

			private void method_7(object sender, ListChangedEventArgs e)
			{
				this.method_2();
			}
		}

		internal class Class10
		{
			private bool bool_0;

			private SiticoneHScrollBar siticoneHScrollBar_0;

			private DataGridView dataGridView_0;

			private int int_0;

			private HScrollBar hscrollBar_0;

			private VScrollBar vscrollBar_0;

			public Class10(DataGridView dataGridView_1, SiticoneHScrollBar siticoneHScrollBar_1, bool bool_1 = true)
			{
				this.bool_0 = true;
				this.siticoneHScrollBar_0 = siticoneHScrollBar_1;
				this.dataGridView_0 = dataGridView_1;
				this.bool_0 = bool_1;
				try
				{
					foreach (object control in this.dataGridView_0.Controls)
					{
						if (control.GetType() == typeof(VScrollBar))
						{
							this.vscrollBar_0 = (VScrollBar)control;
						}
						if (control.GetType() == typeof(HScrollBar))
						{
							this.hscrollBar_0 = (HScrollBar)control;
						}
					}
				}
				catch
				{
				}
				this.dataGridView_0.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView_0_RowsAdded);
				this.dataGridView_0.UserDeletedRow += new DataGridViewRowEventHandler(dataGridView_0_UserDeletedRow);
				this.dataGridView_0.Resize += new EventHandler(dataGridView_0_Resize);
				this.siticoneHScrollBar_0.Scroll += new ScrollEventHandler(siticoneHScrollBar_0_Scroll);
				this.method_2();
			}

			private void dataGridView_0_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
			{
				this.method_2();
			}

			private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
			{
				this.method_2();
			}

			private void siticoneHScrollBar_0_Scroll(object sender, ScrollEventArgs e)
			{
				if (this.int_0 <= 0)
				{
					try
					{
						this.hscrollBar_0.Value = this.siticoneHScrollBar_0.Value;
						this.dataGridView_0.HorizontalScrollingOffset = this.siticoneHScrollBar_0.Value;
					}
					catch
					{
					}
				}
			}

			private void method_0()
			{
				this.int_0++;
			}

			private void method_1()
			{
				if (this.int_0 > 0)
				{
					this.int_0--;
				}
			}

			public void method_2()
			{
				if (this.dataGridView_0 == null)
				{
					return;
				}
				try
				{
					this.method_0();
					try
					{
						if (this.bool_0)
						{
							if (this.vscrollBar_0.Visible)
							{
								this.siticoneHScrollBar_0.Width = this.dataGridView_0.Width;
								this.siticoneHScrollBar_0.FillOffset = new Padding(this.siticoneHScrollBar_0.FillOffset.Left, this.siticoneHScrollBar_0.FillOffset.Top, Math.Max(18, SystemInformation.VerticalScrollBarWidth), this.siticoneHScrollBar_0.FillOffset.Bottom);
							}
							else
							{
								this.siticoneHScrollBar_0.Width = this.dataGridView_0.Width;
							}
							this.siticoneHScrollBar_0.Height = Math.Max(18, SystemInformation.HorizontalScrollBarHeight);
							this.siticoneHScrollBar_0.Location = new Point(this.dataGridView_0.Location.X, checked(this.dataGridView_0.Location.Y + (this.dataGridView_0.Height - this.hscrollBar_0.Height)));
							this.siticoneHScrollBar_0.BringToFront();
						}
					}
					catch
					{
					}
					this.method_4();
					this.siticoneHScrollBar_0.Maximum = this.hscrollBar_0.Maximum;
					this.siticoneHScrollBar_0.Minimum = this.hscrollBar_0.Minimum;
					this.siticoneHScrollBar_0.SmallChange = this.hscrollBar_0.SmallChange;
					this.siticoneHScrollBar_0.LargeChange = this.hscrollBar_0.LargeChange;
					this.siticoneHScrollBar_0.Visible = this.hscrollBar_0.Visible;
					this.siticoneHScrollBar_0.Value = this.hscrollBar_0.Value;
				}
				finally
				{
					this.method_1();
				}
			}

			private int method_3()
			{
				return this.dataGridView_0.DisplayedRowCount(includePartialRow: true);
			}

			private int method_4()
			{
				return this.dataGridView_0.DisplayedColumnCount(includePartialColumns: true);
			}

			private bool method_5()
			{
				bool result = false;
				if (this.dataGridView_0.DisplayedRowCount(includePartialRow: true) < checked(this.dataGridView_0.RowCount + (this.dataGridView_0.RowHeadersVisible ? 1 : 0)))
				{
					result = true;
				}
				return result;
			}

			private bool method_6()
			{
				bool result = false;
				if (this.dataGridView_0.DisplayedColumnCount(includePartialColumns: true) < checked(this.dataGridView_0.ColumnCount + (this.dataGridView_0.ColumnHeadersVisible ? 1 : 0)))
				{
					result = true;
				}
				return result;
			}

			private void dataGridView_0_Resize(object sender, EventArgs e)
			{
				this.method_2();
			}

			private void method_7(object sender, ListChangedEventArgs e)
			{
				this.method_2();
			}
		}

		private Class10 class10_0;

		private Class9 class9_0;

		public DataGridViewScrollHelper(DataGridView dataGridView, SiticoneVScrollBar vScrollBar, bool autoSizeAndLocationOfScrollBar)
		{
			this.class9_0 = new Class9(dataGridView, vScrollBar, autoSizeAndLocationOfScrollBar);
		}

		public DataGridViewScrollHelper(DataGridView dataGridView, SiticoneHScrollBar hScrollBar, bool autoSizeAndLocationOfScrollBar)
		{
			this.class10_0 = new Class10(dataGridView, hScrollBar, autoSizeAndLocationOfScrollBar);
		}

		public void UpdateScrollBar()
		{
			if (this.class10_0 != null)
			{
				this.class10_0.method_2();
			}
			if (this.class9_0 != null)
			{
				this.class9_0.method_2();
			}
		}
	}
}

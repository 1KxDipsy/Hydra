using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Description("DataGridViewHeaderStyle")]
	[DebuggerStepThrough]
	public class SiticoneDataGridViewHeaderStyle
	{
		private SiticoneDataGridView siticoneDataGridView_0;

		private DataGridViewCellStyle dataGridViewCellStyle_0;

		[Description("The height size mode")]
		public DataGridViewColumnHeadersHeightSizeMode HeaightSizeMode
		{
			get
			{
				return this.method_0().ColumnHeadersHeightSizeMode;
			}
			set
			{
				this.method_0().ColumnHeadersHeightSizeMode = value;
			}
		}

		[Description("The height")]
		public int Height
		{
			get
			{
				return this.method_0().ColumnHeadersHeight;
			}
			set
			{
				if (this.method_0().ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					this.method_0().ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
				}
				this.method_0().ColumnHeadersHeight = value;
			}
		}

		[Description("The DataGridView HeaderBorderStyle ")]
		public DataGridViewHeaderBorderStyle BorderStyle
		{
			get
			{
				return this.method_0().ColumnHeadersBorderStyle;
			}
			set
			{
				this.method_0().ColumnHeadersBorderStyle = value;
			}
		}

		[Description("The BackColor")]
		public Color BackColor
		{
			get
			{
				return this.method_1().BackColor;
			}
			set
			{
				this.method_1().BackColor = value;
			}
		}

		[Description("The ForeColor")]
		public Color ForeColor
		{
			get
			{
				return this.method_1().ForeColor;
			}
			set
			{
				this.method_1().ForeColor = value;
			}
		}

		[Description("The Font style")]
		public Font Font
		{
			get
			{
				return this.method_1().Font;
			}
			set
			{
				this.method_1().Font = value;
			}
		}

		public SiticoneDataGridViewHeaderStyle(DataGridViewCellStyle sender, SiticoneDataGridView parent)
		{
			this.dataGridViewCellStyle_0 = sender;
			this.siticoneDataGridView_0 = parent;
		}

		private SiticoneDataGridView method_0()
		{
			if (this.siticoneDataGridView_0 != null)
			{
				return this.siticoneDataGridView_0;
			}
			return new SiticoneDataGridView();
		}

		private DataGridViewCellStyle method_1()
		{
			if (this.dataGridViewCellStyle_0 != null)
			{
				return this.dataGridViewCellStyle_0;
			}
			return new DataGridViewCellStyle();
		}

		public override string ToString()
		{
			return "";
		}
	}
}

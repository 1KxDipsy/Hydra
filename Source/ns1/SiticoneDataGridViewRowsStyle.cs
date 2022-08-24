using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[Description("DataGridViewRowsStyle")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[DebuggerStepThrough]
	public class SiticoneDataGridViewRowsStyle
	{
		private SiticoneDataGridView siticoneDataGridView_0;

		private DataGridViewCellStyle dataGridViewCellStyle_0;

		private DataGridViewCellBorderStyle dataGridViewCellBorderStyle_0;

		[Description("The Dheight")]
		public int Height
		{
			get
			{
				return this.method_0().RowTemplate.Height;
			}
			set
			{
				this.method_0().RowTemplate.Height = value;
			}
		}

		public DataGridViewCellBorderStyle BorderStyle
		{
			get
			{
				return this.dataGridViewCellBorderStyle_0;
			}
			set
			{
				this.method_0().CellBorderStyle = value;
				this.dataGridViewCellBorderStyle_0 = value;
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

		[Description("The font style")]
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

		[Description("The Selection BackColor")]
		public Color SelectionBackColor
		{
			get
			{
				return this.method_1().SelectionBackColor;
			}
			set
			{
				this.method_1().SelectionBackColor = value;
			}
		}

		[Description("The selection ForeColor")]
		public Color SelectionForeColor
		{
			get
			{
				return this.method_1().SelectionForeColor;
			}
			set
			{
				this.method_1().SelectionForeColor = value;
			}
		}

		public SiticoneDataGridViewRowsStyle(DataGridViewCellStyle sender, SiticoneDataGridView parent)
		{
			this.dataGridViewCellBorderStyle_0 = DataGridViewCellBorderStyle.SingleHorizontal;
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

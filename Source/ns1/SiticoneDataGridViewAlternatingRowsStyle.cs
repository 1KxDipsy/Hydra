using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns1
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Description("DataGridViewAlternatingRowsStyle")]
	[DebuggerStepThrough]
	public class SiticoneDataGridViewAlternatingRowsStyle
	{
		private DataGridViewCellStyle dataGridViewCellStyle_0;

		[Description("The BackColor")]
		public Color BackColor
		{
			get
			{
				return this.method_0().BackColor;
			}
			set
			{
				this.method_0().BackColor = value;
			}
		}

		[Description("The ForeColor")]
		public Color ForeColor
		{
			get
			{
				return this.method_0().ForeColor;
			}
			set
			{
				this.method_0().ForeColor = value;
			}
		}

		[Description("The font style")]
		public Font Font
		{
			get
			{
				return this.method_0().Font;
			}
			set
			{
				this.method_0().Font = value;
			}
		}

		[Description("The Selection BackColor")]
		public Color SelectionBackColor
		{
			get
			{
				return this.method_0().SelectionBackColor;
			}
			set
			{
				this.method_0().SelectionBackColor = value;
			}
		}

		[Description("The Selection ForeColor")]
		public Color SelectionForeColor
		{
			get
			{
				return this.method_0().SelectionForeColor;
			}
			set
			{
				this.method_0().SelectionForeColor = value;
			}
		}

		public SiticoneDataGridViewAlternatingRowsStyle(DataGridViewCellStyle sender)
		{
			this.dataGridViewCellStyle_0 = sender;
		}

		private DataGridViewCellStyle method_0()
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

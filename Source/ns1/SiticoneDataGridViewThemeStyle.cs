using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns1
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[DebuggerStepThrough]
	[Description("DataGridViewThemeStyle")]
	public class SiticoneDataGridViewThemeStyle
	{
		private SiticoneDataGridView siticoneDataGridView_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SiticoneDataGridViewRowsStyle siticoneDataGridViewRowsStyle_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SiticoneDataGridViewHeaderStyle siticoneDataGridViewHeaderStyle_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SiticoneDataGridViewAlternatingRowsStyle siticoneDataGridViewAlternatingRowsStyle_0;

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public SiticoneDataGridViewRowsStyle RowsStyle
		{
			[CompilerGenerated]
			get
			{
				return this.siticoneDataGridViewRowsStyle_0;
			}
			[CompilerGenerated]
			set
			{
				this.siticoneDataGridViewRowsStyle_0 = value;
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public SiticoneDataGridViewHeaderStyle HeaderStyle
		{
			[CompilerGenerated]
			get
			{
				return this.siticoneDataGridViewHeaderStyle_0;
			}
			[CompilerGenerated]
			set
			{
				this.siticoneDataGridViewHeaderStyle_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		public SiticoneDataGridViewAlternatingRowsStyle AlternatingRowsStyle
		{
			[CompilerGenerated]
			get
			{
				return this.siticoneDataGridViewAlternatingRowsStyle_0;
			}
			[CompilerGenerated]
			set
			{
				this.siticoneDataGridViewAlternatingRowsStyle_0 = value;
			}
		}

		[Description("The BackColor")]
		public Color BackColor
		{
			get
			{
				return this.method_0().BackgroundColor;
			}
			set
			{
				this.method_0().BackgroundColor = value;
			}
		}

		[Description("The grid color")]
		public Color GridColor
		{
			get
			{
				return this.method_0().GridColor;
			}
			set
			{
				this.method_0().GridColor = value;
			}
		}

		[Description("The readonly property")]
		public bool ReadOnly
		{
			get
			{
				return this.method_0().ReadOnly;
			}
			set
			{
				this.method_0().ReadOnly = value;
			}
		}

		public SiticoneDataGridViewThemeStyle(SiticoneDataGridView sender)
		{
			this.siticoneDataGridView_0 = sender;
			this.AlternatingRowsStyle = new SiticoneDataGridViewAlternatingRowsStyle(this.method_0().AlternatingRowsDefaultCellStyle);
			this.RowsStyle = new SiticoneDataGridViewRowsStyle(this.method_0().DefaultCellStyle, this.siticoneDataGridView_0);
			this.HeaderStyle = new SiticoneDataGridViewHeaderStyle(this.method_0().ColumnHeadersDefaultCellStyle, this.siticoneDataGridView_0);
		}

		private SiticoneDataGridView method_0()
		{
			if (this.siticoneDataGridView_0 != null)
			{
				return this.siticoneDataGridView_0;
			}
			return new SiticoneDataGridView();
		}

		public override string ToString()
		{
			return "BackColor=" + this.BackColor.ToString() + ", GridColor=" + this.GridColor.ToString() + ", [ReadOnly]=" + this.ReadOnly;
		}
	}
}

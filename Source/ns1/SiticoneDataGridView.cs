using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns5;

namespace ns1
{
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(DataGridView))]
	[Description("A themed DataGridView control")]
	public class SiticoneDataGridView : DataGridView
	{
		private int int_0;

		private DataGridViewPresetThemes dataGridViewPresetThemes_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private SiticoneDataGridViewThemeStyle siticoneDataGridViewThemeStyle_0;

		[DefaultValue(true)]
		[DisplayName("Theme")]
		[Category("Siticone Properties")]
		[Description("Lets you choose and apply a preset theme from the current list of preset themes.")]
		public DataGridViewPresetThemes Theme
		{
			get
			{
				return this.dataGridViewPresetThemes_0;
			}
			set
			{
				this.method_1(value);
				this.dataGridViewPresetThemes_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Category("Siticone Properties")]
		[Description("Select a theme style to apply to the DataGridView Control")]
		public SiticoneDataGridViewThemeStyle ThemeStyle
		{
			[CompilerGenerated]
			get
			{
				return this.siticoneDataGridViewThemeStyle_0;
			}
			[CompilerGenerated]
			set
			{
				this.siticoneDataGridViewThemeStyle_0 = value;
			}
		}

		public SiticoneDataGridView()
		{
			this.int_0 = 0;
			this.dataGridViewPresetThemes_0 = DataGridViewPresetThemes.Light;
			this.ThemeStyle = new SiticoneDataGridViewThemeStyle(this);
			try
			{
				this.DoubleBuffered = true;
				base.RowHeadersVisible = false;
				base.BorderStyle = BorderStyle.None;
				base.EnableHeadersVisualStyles = false;
				base.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				base.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
			catch
			{
			}
			base.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5f);
			base.DefaultCellStyle.Font = new Font("Segoe UI", 10.5f);
			base.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			base.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			base.BackgroundColor = Color.White;
			this.Theme = DataGridViewPresetThemes.Default;
			Class13.smethod_0();
		}

		private void method_0(Color color_0, Color color_1, Color color_2, Color color_3, Color color_4, Color color_5, Color color_6, Color color_7)
		{
			base.GridColor = color_7;
			base.ColumnHeadersDefaultCellStyle.BackColor = color_0;
			base.ColumnHeadersDefaultCellStyle.ForeColor = color_1;
			base.DefaultCellStyle.BackColor = color_2;
			base.DefaultCellStyle.ForeColor = color_3;
			base.DefaultCellStyle.SelectionBackColor = color_4;
			base.DefaultCellStyle.SelectionForeColor = color_5;
			base.AlternatingRowsDefaultCellStyle.BackColor = color_6;
			this.ThemeStyle = new SiticoneDataGridViewThemeStyle(this);
		}

		private void method_1(DataGridViewPresetThemes dataGridViewPresetThemes_1)
		{
			switch (dataGridViewPresetThemes_1)
			{
			case DataGridViewPresetThemes.Default:
				this.method_0(Color.FromArgb(100, 88, 255), Color.White, Color.White, Color.FromArgb(71, 69, 94), Color.FromArgb(231, 229, 255), Color.FromArgb(71, 69, 94), Color.White, Color.FromArgb(231, 229, 255));
				break;
			case DataGridViewPresetThemes.Alizarin:
				this.method_0(Color.FromArgb(231, 76, 60), Color.White, Color.FromArgb(249, 219, 216), Color.Black, Color.FromArgb(239, 135, 125), Color.Black, Color.FromArgb(247, 201, 197), Color.FromArgb(245, 192, 188));
				break;
			case DataGridViewPresetThemes.Carrot:
				this.method_0(Color.FromArgb(230, 126, 34), Color.White, Color.FromArgb(249, 229, 211), Color.Black, Color.FromArgb(238, 169, 107), Color.Black, Color.FromArgb(247, 216, 189), Color.FromArgb(245, 209, 177));
				break;
			case DataGridViewPresetThemes.SunFlower:
				this.method_0(Color.FromArgb(241, 196, 15), Color.White, Color.FromArgb(251, 243, 207), Color.Black, Color.FromArgb(245, 215, 95), Color.Black, Color.FromArgb(250, 237, 183), Color.FromArgb(249, 233, 170));
				break;
			case DataGridViewPresetThemes.Amethyst:
				this.method_0(Color.FromArgb(155, 89, 182), Color.White, Color.FromArgb(235, 221, 240), Color.Black, Color.FromArgb(188, 144, 206), Color.Black, Color.FromArgb(225, 205, 233), Color.FromArgb(222, 201, 231));
				break;
			case DataGridViewPresetThemes.FeterRiver:
				this.method_0(Color.FromArgb(52, 152, 219), Color.White, Color.FromArgb(214, 234, 247), Color.Black, Color.FromArgb(119, 186, 231), Color.Black, Color.FromArgb(194, 224, 244), Color.FromArgb(187, 220, 242));
				break;
			case DataGridViewPresetThemes.Emerald:
				this.method_0(Color.FromArgb(46, 204, 113), Color.White, Color.FromArgb(213, 244, 226), Color.Black, Color.FromArgb(115, 221, 160), Color.Black, Color.FromArgb(192, 239, 212), Color.FromArgb(187, 238, 208));
				break;
			case DataGridViewPresetThemes.GreenSea:
				this.method_0(Color.FromArgb(22, 160, 133), Color.White, Color.FromArgb(208, 235, 230), Color.Black, Color.FromArgb(99, 191, 173), Color.Black, Color.FromArgb(185, 226, 218), Color.FromArgb(182, 224, 216));
				break;
			case DataGridViewPresetThemes.Turquoise:
				this.method_0(Color.FromArgb(148, 0, 211), Color.White, Color.FromArgb(233, 204, 245), Color.Black, Color.FromArgb(183, 85, 225), Color.Black, Color.FromArgb(223, 179, 241), Color.FromArgb(223, 179, 241));
				break;
			case DataGridViewPresetThemes.WetAsphalt:
				this.method_0(Color.FromArgb(52, 73, 94), Color.White, Color.FromArgb(214, 218, 223), Color.Black, Color.FromArgb(119, 133, 147), Color.Black, Color.FromArgb(194, 200, 207), Color.FromArgb(193, 199, 206));
				break;
			case DataGridViewPresetThemes.Red:
				this.method_0(Color.FromArgb(243, 67, 54), Color.White, Color.FromArgb(252, 217, 215), Color.Black, Color.FromArgb(247, 129, 121), Color.Black, Color.FromArgb(251, 199, 195), Color.FromArgb(250, 189, 184));
				break;
			case DataGridViewPresetThemes.Pink:
				this.method_0(Color.FromArgb(232, 30, 99), Color.White, Color.FromArgb(249, 210, 223), Color.Black, Color.FromArgb(239, 105, 151), Color.Black, Color.FromArgb(247, 188, 208), Color.FromArgb(245, 180, 203));
				break;
			case DataGridViewPresetThemes.Indigo:
				this.method_0(Color.FromArgb(63, 81, 181), Color.White, Color.FromArgb(216, 220, 239), Color.Black, Color.FromArgb(127, 139, 205), Color.Black, Color.FromArgb(197, 203, 232), Color.FromArgb(194, 201, 231));
				break;
			case DataGridViewPresetThemes.Blue:
				this.method_0(Color.FromArgb(33, 150, 242), Color.White, Color.FromArgb(211, 233, 252), Color.Black, Color.FromArgb(107, 185, 246), Color.Black, Color.FromArgb(189, 223, 251), Color.FromArgb(187, 222, 251));
				break;
			case DataGridViewPresetThemes.LightBlue:
				this.method_0(Color.FromArgb(3, 169, 243), Color.White, Color.FromArgb(205, 237, 252), Color.Black, Color.FromArgb(87, 197, 247), Color.Black, Color.FromArgb(180, 229, 251), Color.FromArgb(179, 230, 251));
				break;
			case DataGridViewPresetThemes.Cyan:
				this.method_0(Color.FromArgb(0, 188, 211), Color.White, Color.FromArgb(204, 241, 245), Color.Black, Color.FromArgb(85, 210, 225), Color.Black, Color.FromArgb(179, 235, 241), Color.FromArgb(177, 235, 241));
				break;
			case DataGridViewPresetThemes.Purple:
				this.method_0(Color.FromArgb(156, 39, 176), Color.White, Color.FromArgb(235, 212, 239), Color.Black, Color.FromArgb(189, 111, 202), Color.Black, Color.FromArgb(225, 191, 231), Color.FromArgb(224, 188, 231));
				break;
			case DataGridViewPresetThemes.DeepPurple:
				this.method_0(Color.FromArgb(103, 58, 183), Color.White, Color.FromArgb(224, 215, 240), Color.Black, Color.FromArgb(153, 123, 207), Color.Black, Color.FromArgb(209, 196, 233), Color.FromArgb(207, 193, 232));
				break;
			case DataGridViewPresetThemes.Teal:
				this.method_0(Color.FromArgb(0, 150, 136), Color.White, Color.FromArgb(204, 233, 231), Color.Black, Color.FromArgb(85, 185, 175), Color.Black, Color.FromArgb(179, 223, 219), Color.FromArgb(177, 222, 218));
				break;
			case DataGridViewPresetThemes.Green:
				this.method_0(Color.FromArgb(76, 175, 80), Color.White, Color.FromArgb(219, 239, 220), Color.Black, Color.FromArgb(135, 201, 138), Color.Black, Color.FromArgb(201, 231, 203), Color.FromArgb(199, 231, 201));
				break;
			case DataGridViewPresetThemes.LightGreen:
				this.method_0(Color.FromArgb(139, 194, 74), Color.White, Color.FromArgb(231, 242, 219), Color.Black, Color.FromArgb(177, 214, 134), Color.Black, Color.FromArgb(220, 236, 201), Color.FromArgb(219, 235, 199));
				break;
			case DataGridViewPresetThemes.Lime:
				this.method_0(Color.FromArgb(204, 219, 57), Color.White, Color.FromArgb(244, 247, 215), Color.Black, Color.FromArgb(221, 231, 123), Color.Black, Color.FromArgb(239, 244, 196), Color.FromArgb(238, 243, 194));
				break;
			case DataGridViewPresetThemes.Yellow:
				this.method_0(Color.FromArgb(254, 234, 59), Color.White, Color.FromArgb(254, 250, 215), Color.Black, Color.FromArgb(254, 241, 124), Color.Black, Color.FromArgb(254, 248, 196), Color.FromArgb(254, 248, 188));
				break;
			case DataGridViewPresetThemes.Ember:
				this.method_0(Color.FromArgb(254, 192, 7), Color.White, Color.FromArgb(254, 250, 215), Color.Black, Color.FromArgb(254, 213, 89), Color.Black, Color.FromArgb(254, 248, 196), Color.FromArgb(254, 235, 177));
				break;
			case DataGridViewPresetThemes.Orange:
				this.method_0(Color.FromArgb(243, 156, 18), Color.White, Color.FromArgb(252, 235, 207), Color.Black, Color.FromArgb(247, 189, 97), Color.Black, Color.FromArgb(251, 225, 184), Color.FromArgb(250, 218, 171));
				break;
			case DataGridViewPresetThemes.DeepOrange:
				this.method_0(Color.FromArgb(254, 87, 34), Color.White, Color.FromArgb(254, 221, 211), Color.Black, Color.FromArgb(254, 143, 107), Color.Black, Color.FromArgb(254, 205, 189), Color.FromArgb(254, 203, 186));
				break;
			case DataGridViewPresetThemes.White:
				this.method_0(Color.White, Color.Black, Color.FromArgb(247, 248, 249), Color.Black, Color.FromArgb(239, 241, 243), Color.Black, Color.White, Color.FromArgb(247, 248, 249));
				break;
			case DataGridViewPresetThemes.WhiteGrid:
				this.method_0(Color.White, Color.Black, Color.White, Color.Black, Color.FromArgb(239, 241, 243), Color.Black, Color.White, Color.FromArgb(239, 241, 243));
				break;
			case DataGridViewPresetThemes.Light:
				this.method_0(Color.FromArgb(232, 234, 237), Color.Black, Color.White, Color.Black, Color.FromArgb(239, 241, 243), Color.Black, Color.FromArgb(247, 248, 249), Color.FromArgb(244, 245, 247));
				break;
			case DataGridViewPresetThemes.LightGrid:
				this.method_0(Color.FromArgb(232, 234, 237), Color.Black, Color.White, Color.Black, Color.FromArgb(239, 241, 243), Color.Black, Color.White, Color.FromArgb(239, 241, 243));
				break;
			case DataGridViewPresetThemes.Dark:
				this.method_0(Color.FromArgb(15, 16, 18), Color.White, Color.FromArgb(33, 37, 41), Color.White, Color.FromArgb(114, 117, 119), Color.White, Color.FromArgb(44, 48, 52), Color.FromArgb(50, 56, 62));
				break;
			}
		}
	}
}

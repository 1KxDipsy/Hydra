using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns1
{
	[Description("A RoundedDateTimePicker Control")]
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(ComboBox))]
	[ToolboxItem(true)]
	public class SiticoneRoundedDateTimePicker : SiticoneDateTimePicker
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_2;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int BorderRadius
		{
			[CompilerGenerated]
			get
			{
				return this.int_2;
			}
			[CompilerGenerated]
			set
			{
				this.int_2 = value;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.BorderRadius = base.Height / 2 - 1;
		}
	}
}

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace ns0
{
	[DebuggerStepThrough]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Description("UITypeEditor")]
	internal class Class2 : UITypeEditor
	{
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs e)
		{
			base.PaintValue(e);
		}
	}
}

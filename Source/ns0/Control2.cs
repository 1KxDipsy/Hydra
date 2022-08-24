using System.Windows.Forms;
using ns11;
using ns14;
using ns15;
using ns16;

namespace ns0
{
	internal sealed class Control2 : RControl
	{
		private readonly Control control_0;

		private readonly bool bool_0;

		public Control Control_0 => this.control_0;

		public override RPoint MouseLocation => Class19.smethod_0(this.control_0.PointToClient(Control.MousePosition));

		public override bool LeftMouseButton => (Control.MouseButtons & MouseButtons.Left) != 0;

		public override bool RightMouseButton => (Control.MouseButtons & MouseButtons.Right) != 0;

		public Control2(Control control_1, bool bool_1)
			: base(Class64.Class64_0)
		{
			ArgChecker.AssertArgNotNull(control_1, "control");
			this.control_0 = control_1;
			this.bool_0 = bool_1;
		}

		public override void SetCursorDefault()
		{
			this.control_0.Cursor = Cursors.Default;
		}

		public override void SetCursorHand()
		{
			this.control_0.Cursor = Cursors.Hand;
		}

		public override void SetCursorIBeam()
		{
			this.control_0.Cursor = Cursors.IBeam;
		}

		public override void DoDragDropCopy(object dragDropData)
		{
			this.control_0.DoDragDrop(dragDropData, DragDropEffects.Copy);
		}

		public override void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth)
		{
			using GraphicsAdapter graphicsAdapter = new GraphicsAdapter(this.control_0.CreateGraphics(), this.bool_0, releaseGraphics: true);
			graphicsAdapter.MeasureString(str, font, maxWidth, out charFit, out charFitWidth);
		}

		public override void Invalidate()
		{
			this.control_0.Invalidate();
		}
	}
}

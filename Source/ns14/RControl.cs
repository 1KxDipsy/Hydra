using ns11;
using ns16;

namespace ns14
{
	public abstract class RControl
	{
		private readonly RAdapter radapter_0;

		public RAdapter Adapter => this.radapter_0;

		public abstract bool LeftMouseButton { get; }

		public abstract bool RightMouseButton { get; }

		public abstract RPoint MouseLocation { get; }

		protected RControl(RAdapter adapter)
		{
			ArgChecker.AssertArgNotNull(adapter, "adapter");
			this.radapter_0 = adapter;
		}

		public abstract void SetCursorDefault();

		public abstract void SetCursorHand();

		public abstract void SetCursorIBeam();

		public abstract void DoDragDropCopy(object dragDropData);

		public abstract void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth);

		public abstract void Invalidate();
	}
}

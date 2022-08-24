namespace ns16
{
	public sealed class RMouseEvent
	{
		private readonly bool bool_0;

		public bool LeftButton => this.bool_0;

		public RMouseEvent(bool leftButton)
		{
			this.bool_0 = leftButton;
		}
	}
}

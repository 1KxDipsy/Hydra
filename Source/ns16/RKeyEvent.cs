namespace ns16
{
	public sealed class RKeyEvent
	{
		private readonly bool bool_0;

		private readonly bool bool_1;

		private readonly bool bool_2;

		public bool Control => this.bool_0;

		public bool AKeyCode => this.bool_1;

		public bool CKeyCode => this.bool_2;

		public RKeyEvent(bool control, bool aKeyCode, bool cKeyCode)
		{
			this.bool_0 = control;
			this.bool_1 = aKeyCode;
			this.bool_2 = cKeyCode;
		}
	}
}

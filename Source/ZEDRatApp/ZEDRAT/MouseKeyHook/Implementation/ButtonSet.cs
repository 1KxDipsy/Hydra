using System.Windows.Forms;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation
{
	internal class ButtonSet
	{
		private MouseButtons m_Set;

		public ButtonSet()
		{
			this.m_Set = MouseButtons.None;
		}

		public void Add(MouseButtons element)
		{
			this.m_Set |= element;
		}

		public void Remove(MouseButtons element)
		{
			this.m_Set &= ~element;
		}

		public bool Contains(MouseButtons element)
		{
			return (this.m_Set & element) != 0;
		}
	}
}

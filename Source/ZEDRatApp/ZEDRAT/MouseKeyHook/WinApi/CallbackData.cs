using System;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi
{
	internal struct CallbackData
	{
		private readonly IntPtr m_LParam;

		private readonly IntPtr m_WParam;

		public IntPtr WParam => this.m_WParam;

		public IntPtr LParam => this.m_LParam;

		public CallbackData(IntPtr wParam, IntPtr lParam)
		{
			this.m_WParam = wParam;
			this.m_LParam = lParam;
		}
	}
}

using System;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.WinApi
{
	internal class HookResult : IDisposable
	{
		private readonly HookProcedureHandle m_Handle;

		private readonly HookProcedure m_Procedure;

		public HookProcedureHandle Handle => this.m_Handle;

		public HookProcedure Procedure => this.m_Procedure;

		public HookResult(HookProcedureHandle handle, HookProcedure procedure)
		{
			this.m_Handle = handle;
			this.m_Procedure = procedure;
		}

		public void Dispose()
		{
			this.m_Handle.Dispose();
		}
	}
}

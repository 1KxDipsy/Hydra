using System;
using System.Collections.Generic;
using Sockets;

namespace ZEDRAT.TCP
{
	public class IAsyncEventDispatcher
	{
		public object _obj = new object();

		public TcpClientSession _tcs;

		public Dictionary<DataType, Action<TcpClientSession, byte[]>> _ProcessorsMessageHandler;

		public IAsyncEventDispatcher(TcpClientSession tcs)
		{
			this._tcs = tcs;
			this._ProcessorsMessageHandler = new Dictionary<DataType, Action<TcpClientSession, byte[]>>();
		}

		~IAsyncEventDispatcher()
		{
		}

		public void DispatchMessageHandler(TcpHeartPacket tp, byte[] payload)
		{
			try
			{
				Action<TcpClientSession, byte[]> value = null;
				if (this._ProcessorsMessageHandler.TryGetValue((DataType)tp._DataType, out value))
				{
					value?.Invoke(this._tcs, payload);
				}
			}
			catch
			{
			}
		}

		public bool Register(DataType dt, Action<TcpClientSession, byte[]> ob)
		{
			lock (this._obj)
			{
				this._ProcessorsMessageHandler?.Add(dt, ob);
				return true;
			}
		}

		public bool Unregister(DataType dt)
		{
			lock (this._obj)
			{
				return this._ProcessorsMessageHandler.Remove(dt);
			}
		}

		public void destroy()
		{
			this._ProcessorsMessageHandler?.Clear();
			this._ProcessorsMessageHandler = null;
			this._obj = null;
			this._tcs = null;
		}
	}
}

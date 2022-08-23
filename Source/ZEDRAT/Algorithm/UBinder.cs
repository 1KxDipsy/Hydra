using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Remote_Process;
using ZEDRAT.Messages;

namespace ZEDRAT.Algorithm
{
	public class UBinder : SerializationBinder
	{
		public override Type BindToType(string assemblyName, string typeName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (typeName.Contains("System.Collections.Generic.List") && typeName.Contains("Remote_Process.RemoteProcessList"))
			{
				return typeof(List<RemoteProcessList>);
			}
			if (typeName.Contains("System.Collections.Generic.List") && typeName.Contains("Messages.RemoteWebList"))
			{
				return typeof(List<RemoteWebList>);
			}
			if (typeName.Contains("System.Collections.Generic.List") && typeName.Contains("ZEDRAT.Messages.RemoteFilesList"))
			{
				return typeof(List<RemoteFilesList>);
			}
			return executingAssembly.GetType(typeName);
		}
	}
}

using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZEDRAT.Algorithm
{
	public class UBinder : SerializationBinder
	{
		public override Type BindToType(string assemblyName, string typeName)
		{
			Type result = null;
			Type[] types = Assembly.GetExecutingAssembly().GetTypes();
			int num = 0;
			for (num = 0; num < types.Length; num++)
			{
				if (types[num].FullName == typeName)
				{
					result = types[num];
					break;
				}
			}
			return result;
		}
	}
}

using System;
using System.Collections.Generic;

namespace ZEDRatApp.ZEDRAT.NetSerializer
{
	public interface ITypeSerializer
	{
		bool Handles(Type type);

		IEnumerable<Type> GetSubtypes(Type type);
	}
}

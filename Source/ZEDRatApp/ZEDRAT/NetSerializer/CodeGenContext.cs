using System;
using System.Collections.Generic;
using System.Reflection;

namespace ZEDRatApp.ZEDRAT.NetSerializer
{
	public sealed class CodeGenContext
	{
		private readonly Dictionary<Type, TypeData> m_typeMap;

		public MethodInfo SerializerSwitchMethodInfo { get; private set; }

		public MethodInfo DeserializerSwitchMethodInfo { get; private set; }

		public IDictionary<Type, TypeData> TypeMap => this.m_typeMap;

		public CodeGenContext(Dictionary<Type, TypeData> typeMap)
		{
			this.m_typeMap = typeMap;
			TypeData typeData = this.m_typeMap[typeof(object)];
			this.SerializerSwitchMethodInfo = typeData.WriterMethodInfo;
			this.DeserializerSwitchMethodInfo = typeData.ReaderMethodInfo;
		}

		public MethodInfo GetWriterMethodInfo(Type type)
		{
			return this.m_typeMap[type].WriterMethodInfo;
		}

		public MethodInfo GetReaderMethodInfo(Type type)
		{
			return this.m_typeMap[type].ReaderMethodInfo;
		}

		public bool IsGenerated(Type type)
		{
			return this.m_typeMap[type].IsGenerated;
		}

		private bool CanCallDirect(Type type)
		{
			if (type.IsValueType || type.IsArray)
			{
				return true;
			}
			if (type.IsSealed && !this.IsGenerated(type))
			{
				return true;
			}
			return false;
		}

		public TypeData GetTypeData(Type type)
		{
			return this.m_typeMap[type];
		}

		public TypeData GetTypeDataForCall(Type type)
		{
			if (!this.CanCallDirect(type))
			{
				type = typeof(object);
			}
			return this.GetTypeData(type);
		}
	}
}

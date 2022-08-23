using System.Reflection;

namespace ZEDRatApp.ZEDRAT.NetSerializer
{
	public sealed class TypeData
	{
		public readonly ushort TypeID;

		public readonly IDynamicTypeSerializer TypeSerializer;

		public MethodInfo WriterMethodInfo;

		public MethodInfo ReaderMethodInfo;

		public bool IsGenerated => this.TypeSerializer != null;

		public bool NeedsInstanceParameter { get; private set; }

		public TypeData(ushort typeID, IDynamicTypeSerializer serializer)
		{
			this.TypeID = typeID;
			this.TypeSerializer = serializer;
			this.NeedsInstanceParameter = true;
		}

		public TypeData(ushort typeID, MethodInfo writer, MethodInfo reader)
		{
			this.TypeID = typeID;
			this.WriterMethodInfo = writer;
			this.ReaderMethodInfo = reader;
			this.NeedsInstanceParameter = writer.GetParameters().Length == 3;
		}
	}
}

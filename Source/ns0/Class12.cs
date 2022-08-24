using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns0
{
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class Class12
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Class12.resourceManager_0 == null)
				{
					Class12.resourceManager_0 = new ResourceManager("ns0.Class12", typeof(Class12).Assembly);
				}
				return Class12.resourceManager_0;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Class12.cultureInfo_0;
			}
			set
			{
				Class12.cultureInfo_0 = value;
			}
		}

		internal Class12()
		{
		}
	}
}

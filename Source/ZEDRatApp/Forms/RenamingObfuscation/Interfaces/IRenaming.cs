using dnlib.DotNet;

namespace ZEDRatApp.Forms.RenamingObfuscation.Interfaces
{
	public interface IRenaming
	{
		ModuleDefMD Rename(ModuleDefMD module);
	}
}

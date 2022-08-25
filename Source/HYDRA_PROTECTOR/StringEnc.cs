using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace HYDRA_PROTECTOR
{
	internal class StringEnc
	{
		public static void Run(ModuleDefMD module)
		{
			MethodDef method2 = (MethodDef)InjectHelper.Inject(ModuleDefMD.Load(typeof(StringDec).Module).ResolveTypeDef(MDToken.ToRID(typeof(StringDec).MetadataToken)), module.GlobalType, module).Single((IDnlibDef method) => method.Name == "Decrypt");
			foreach (MethodDef method3 in module.GlobalType.Methods)
			{
				if (!(method3.Name != ".ctor"))
				{
					module.GlobalType.Remove(method3);
					break;
				}
			}
			foreach (TypeDef item in from x in module.GetTypes()
				where x.HasMethods
				select x)
			{
				foreach (MethodDef item2 in item.Methods.Where((MethodDef x) => x.HasBody))
				{
					IList<Instruction> instructions = item2.Body.Instructions;
					for (int i = 0; i < instructions.Count; i++)
					{
						if (instructions[i].OpCode == OpCodes.Ldstr && !string.IsNullOrEmpty(instructions[i].Operand.ToString()))
						{
							int length = item2.Name.Length;
							string operand = StringEnc.Ecrypt(new Tuple<string, int>(instructions[i].Operand.ToString(), length));
							instructions[i].OpCode = OpCodes.Ldstr;
							instructions[i].Operand = operand;
							instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(length));
							instructions.Insert(i + 2, OpCodes.Call.ToInstruction(method2));
							i += 2;
						}
					}
					item2.Body.SimplifyMacros(item2.Parameters);
				}
			}
		}

		public static string Ecrypt(Tuple<string, int> values)
		{
			byte[] array = new byte[values.Item1.Length];
			for (int i = 0; i < values.Item1.Length; i++)
			{
				array[i] = (byte)(values.Item1[i] ^ values.Item2);
			}
			return Encoding.UTF8.GetString(array);
		}
	}
}

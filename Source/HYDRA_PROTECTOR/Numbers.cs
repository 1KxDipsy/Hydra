using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace HYDRA_PROTECTOR
{
	internal class Numbers
	{
		public static Random Random = new Random();

		public static void Run(ModuleDefMD md)
		{
			foreach (TypeDef type in md.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody)
					{
						continue;
					}
					for (int i = 0; i < method.Body.Instructions.Count; i++)
					{
						if (method.Body.Instructions[i].IsLdcI4())
						{
							int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
							if (ldcI4Value > 0)
							{
								method.Body.Instructions[i].OpCode = OpCodes.Ldstr;
								method.Body.Instructions[i].Operand = Numbers.Random2(ldcI4Value);
								method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(md.Import(typeof(string).GetMethod("get_Length"))));
							}
						}
					}
				}
			}
		}

		public static string Random2(int length)
		{
			return new string((from s in Enumerable.Repeat("難金女月弓日尸木火土十大中手田水口廿卜山戈人心", length)
				select s[Numbers.Random.Next(s.Length)]).ToArray());
		}
	}
}

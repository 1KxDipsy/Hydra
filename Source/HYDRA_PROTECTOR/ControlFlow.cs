using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace HYDRA_PROTECTOR
{
	internal class ControlFlow
	{
		public static Random Random = new Random();

		public static void Execute(ModuleDefMD Module)
		{
			for (int i = 0; i < Module.Types.Count; i++)
			{
				TypeDef typeDef = Module.Types[i];
				if (typeDef == Module.GlobalType)
				{
					continue;
				}
				for (int j = 0; j < typeDef.Methods.Count; j++)
				{
					MethodDef methodDef = typeDef.Methods[j];
					if (!methodDef.Name.StartsWith("get_") && !methodDef.Name.StartsWith("set_") && methodDef.HasBody && !methodDef.IsConstructor)
					{
						methodDef.Body.SimplifyBranches();
						ControlFlow.ExecuteMethod(methodDef, Module);
						ControlFlow.ExecuteMethod2(methodDef, Module);
					}
				}
			}
		}

		public static void ExecuteMethod4(MethodDef method, ModuleDefMD Module)
		{
			method.Body.SimplifyMacros(method.Parameters);
			List<Block> blocks = Blocks.Block(method);
			blocks = ControlFlow.Randomize(blocks);
			method.Body.Instructions.Clear();
			Local local = new Local(Module.CorLibTypes.UInt32);
			method.Body.Variables.Add(local);
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			foreach (Instruction item in ControlFlow.Calc(0))
			{
				method.Body.Instructions.Add(item);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			foreach (Block item2 in blocks.Where((Block block) => block != blocks.Single((Block x) => x.Number == blocks.Count - 1)))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item3 in ControlFlow.Calc(item2.Number))
				{
					method.Body.Instructions.Add(item3);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction instruction4 in item2.Instructions)
				{
					method.Body.Instructions.Add(instruction4);
				}
				foreach (Instruction item4 in ControlFlow.Calc(item2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction2);
			foreach (Instruction instruction5 in blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions)
			{
				method.Body.Instructions.Add(instruction5);
			}
		}

		public static void ExecuteMethod5(MethodDef method, ModuleDefMD Module)
		{
			method.Body.SimplifyMacros(method.Parameters);
			List<Block> blocks = Blocks.Block(method);
			blocks = ControlFlow.Randomize(blocks);
			method.Body.Instructions.Clear();
			Local local = new Local(Module.CorLibTypes.UInt64);
			method.Body.Variables.Add(local);
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			foreach (Instruction item in ControlFlow.Calc(0))
			{
				method.Body.Instructions.Add(item);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			foreach (Block item2 in blocks.Where((Block block) => block != blocks.Single((Block x) => x.Number == blocks.Count - 1)))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item3 in ControlFlow.Calc(item2.Number))
				{
					method.Body.Instructions.Add(item3);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction instruction4 in item2.Instructions)
				{
					method.Body.Instructions.Add(instruction4);
				}
				foreach (Instruction item4 in ControlFlow.Calc(item2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction2);
			foreach (Instruction instruction5 in blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions)
			{
				method.Body.Instructions.Add(instruction5);
			}
		}

		public static void ExecuteMethod6(MethodDef method, ModuleDefMD Module)
		{
			method.Body.SimplifyMacros(method.Parameters);
			List<Block> blocks = Blocks.Block(method);
			blocks = ControlFlow.Randomize(blocks);
			method.Body.Instructions.Clear();
			Local local = new Local(Module.CorLibTypes.Int16);
			method.Body.Variables.Add(local);
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			foreach (Instruction item in ControlFlow.Calc(0))
			{
				method.Body.Instructions.Add(item);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			foreach (Block item2 in blocks.Where((Block block) => block != blocks.Single((Block x) => x.Number == blocks.Count - 1)))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item3 in ControlFlow.Calc(item2.Number))
				{
					method.Body.Instructions.Add(item3);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction instruction4 in item2.Instructions)
				{
					method.Body.Instructions.Add(instruction4);
				}
				foreach (Instruction item4 in ControlFlow.Calc(item2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction2);
			foreach (Instruction instruction5 in blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions)
			{
				method.Body.Instructions.Add(instruction5);
			}
		}

		public static void ExecuteMethod3(MethodDef method, ModuleDefMD Module)
		{
			method.Body.SimplifyMacros(method.Parameters);
			List<Block> blocks = Blocks.Block(method);
			blocks = ControlFlow.Randomize(blocks);
			method.Body.Instructions.Clear();
			Local local = new Local(Module.CorLibTypes.UInt16);
			method.Body.Variables.Add(local);
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			foreach (Instruction item in ControlFlow.Calc(0))
			{
				method.Body.Instructions.Add(item);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			foreach (Block item2 in blocks.Where((Block block) => block != blocks.Single((Block x) => x.Number == blocks.Count - 1)))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item3 in ControlFlow.Calc(item2.Number))
				{
					method.Body.Instructions.Add(item3);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction instruction4 in item2.Instructions)
				{
					method.Body.Instructions.Add(instruction4);
				}
				foreach (Instruction item4 in ControlFlow.Calc(item2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction2);
			foreach (Instruction instruction5 in blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions)
			{
				method.Body.Instructions.Add(instruction5);
			}
		}

		public static void ExecuteMethod2(MethodDef method, ModuleDefMD Module)
		{
			method.Body.SimplifyMacros(method.Parameters);
			List<Block> blocks = Blocks.Block(method);
			blocks = ControlFlow.Randomize(blocks);
			method.Body.Instructions.Clear();
			Local local = new Local(Module.CorLibTypes.IntPtr);
			method.Body.Variables.Add(local);
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			foreach (Instruction item in ControlFlow.Calc(0))
			{
				method.Body.Instructions.Add(item);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			foreach (Block item2 in blocks.Where((Block block) => block != blocks.Single((Block x) => x.Number == blocks.Count - 1)))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item3 in ControlFlow.Calc(item2.Number))
				{
					method.Body.Instructions.Add(item3);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction instruction4 in item2.Instructions)
				{
					method.Body.Instructions.Add(instruction4);
				}
				foreach (Instruction item4 in ControlFlow.Calc(item2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction2);
			foreach (Instruction instruction5 in blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions)
			{
				method.Body.Instructions.Add(instruction5);
			}
		}

		public static void ExecuteMethod(MethodDef method, ModuleDefMD Module)
		{
			method.Body.SimplifyMacros(method.Parameters);
			List<Block> blocks = Blocks.Block(method);
			blocks = ControlFlow.Randomize(blocks);
			method.Body.Instructions.Clear();
			Local local = new Local(Module.CorLibTypes.UIntPtr);
			method.Body.Variables.Add(local);
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			foreach (Instruction item in ControlFlow.Calc(0))
			{
				method.Body.Instructions.Add(item);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			foreach (Block item2 in blocks.Where((Block block) => block != blocks.Single((Block x) => x.Number == blocks.Count - 1)))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item3 in ControlFlow.Calc(item2.Number))
				{
					method.Body.Instructions.Add(item3);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction instruction4 in item2.Instructions)
				{
					method.Body.Instructions.Add(instruction4);
				}
				foreach (Instruction item4 in ControlFlow.Calc(item2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction2);
			foreach (Instruction instruction5 in blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions)
			{
				method.Body.Instructions.Add(instruction5);
			}
		}

		public static List<Block> Randomize(List<Block> input)
		{
			List<Block> list = new List<Block>();
			using List<Block>.Enumerator enumerator = input.GetEnumerator();
			while (enumerator.MoveNext())
			{
				list.Insert(item: enumerator.Current, index: ControlFlow.Random.Next(0, list.Count));
			}
			return list;
		}

		public static List<Instruction> Calc(int value)
		{
			return new List<Instruction> { Instruction.Create(OpCodes.Ldc_I4, value) };
		}

		public static void AddJump(IList<Instruction> instrs, Instruction target)
		{
			instrs.Add(Instruction.Create(OpCodes.Br, target));
		}
	}
}

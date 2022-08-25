using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace HYDRA_PROTECTOR
{
	internal class Junk
	{
		public static Random Random = new Random();

		public static string Ascii = "1234567890";

		public static string Ascii2 = "ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψωABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي0123456789艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת";

		public static void Run(ModuleDefMD module)
		{
			for (int i = 0; i < 150; i++)
			{
				TypeDefUser typeDefUser = new TypeDefUser("HydraTwister" + Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii), module.CorLibTypes.Object.TypeDefOrRef);
				InterfaceImplUser item = new InterfaceImplUser(typeDefUser);
				typeDefUser.Interfaces.Add(item);
				MethodDef methodDef = new MethodDefUser(Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii2), MethodSig.CreateStatic(module.CorLibTypes.Int32, new SZArraySig(module.CorLibTypes.UIntPtr)));
				methodDef.Attributes = MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig;
				methodDef.ImplAttributes = MethodImplAttributes.IL;
				methodDef.ParamDefs.Add(new ParamDefUser(Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii2), 1));
				typeDefUser.Methods.Add(methodDef);
				MemberRef mr = new MemberRefUser(@class: new TypeRefUser(module, "System", "Console", module.CorLibTypes.AssemblyRef), module: module, name: "WriteLine", sig: MethodSig.CreateStatic(module.CorLibTypes.Void, module.CorLibTypes.String));
				CilBody cilBody2 = (methodDef.Body = new CilBody());
				cilBody2.Instructions.Add(OpCodes.Ldstr.ToInstruction(Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii2)));
				cilBody2.Instructions.Add(OpCodes.Call.ToInstruction(mr));
				cilBody2.Instructions.Add(OpCodes.Ldc_I4_0.ToInstruction());
				cilBody2.Instructions.Add(OpCodes.Ret.ToInstruction());
				module.Types.Add(typeDefUser);
			}
		}

		public static void junkfield(ModuleDefMD module)
		{
			foreach (TypeDef type in module.Types)
			{
				MethodDef[] array = type.Methods.ToArray();
				foreach (MethodDef methodDef in array)
				{
					FieldDefUser fieldDefUser = new FieldDefUser(Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii2), new FieldSig(module.CorLibTypes.String), FieldAttributes.Public | FieldAttributes.Static);
					FieldDefUser fieldDefUser2 = new FieldDefUser(Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii2), new FieldSig(module.CorLibTypes.UIntPtr), FieldAttributes.Public | FieldAttributes.Static);
					FieldDefUser fieldDefUser3 = new FieldDefUser(Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii2), new FieldSig(module.CorLibTypes.IntPtr), FieldAttributes.Public | FieldAttributes.Static);
					FieldDefUser fieldDefUser4 = new FieldDefUser(Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii2), new FieldSig(module.CorLibTypes.UInt32), FieldAttributes.Public | FieldAttributes.Static);
					type.Fields.Add(fieldDefUser);
					type.Fields.Add(fieldDefUser2);
					type.Fields.Add(fieldDefUser3);
					type.Fields.Add(fieldDefUser4);
					if (methodDef.HasBody && methodDef.Body.HasInstructions)
					{
						_ = methodDef.Body.HasExceptionHandlers;
					}
					if (!methodDef.IsVirtual)
					{
						Local local = new Local(module.CorLibTypes.UIntPtr);
						Local local2 = new Local(module.CorLibTypes.UInt32);
						Local local3 = new Local(module.CorLibTypes.IntPtr);
						Local local4 = new Local(module.CorLibTypes.String);
						methodDef.Body.Variables.Add(local);
						methodDef.Body.Variables.Add(local2);
						methodDef.Body.Variables.Add(local3);
						methodDef.Body.Variables.Add(local4);
						for (int num = 0; num < methodDef.Body.Instructions.Count - 2; num = num + 8 + 1)
						{
							methodDef.Body.Instructions.Insert(num + 1, OpCodes.Ldsfld.ToInstruction(fieldDefUser));
							methodDef.Body.Instructions.Insert(num + 2, OpCodes.Stloc.ToInstruction(local4));
							methodDef.Body.Instructions.Insert(num + 3, OpCodes.Ldsfld.ToInstruction(fieldDefUser2));
							methodDef.Body.Instructions.Insert(num + 4, OpCodes.Stloc.ToInstruction(local));
							methodDef.Body.Instructions.Insert(num + 5, OpCodes.Ldsfld.ToInstruction(fieldDefUser4));
							methodDef.Body.Instructions.Insert(num + 6, OpCodes.Stloc.ToInstruction(local2));
							methodDef.Body.Instructions.Insert(num + 7, OpCodes.Ldsfld.ToInstruction(fieldDefUser3));
							methodDef.Body.Instructions.Insert(num + 8, OpCodes.Stloc.ToInstruction(local3));
						}
					}
				}
			}
		}

		public static void JunkString(ModuleDefMD module)
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
					_ = method.Body.Instructions;
					for (int i = 0; i < 150; i++)
					{
						if (method.DeclaringType.IsGlobalModuleType)
						{
							continue;
						}
						IList<Instruction> instructions = method.Body.Instructions;
						try
						{
							if (instructions[i - 1].OpCode == OpCodes.Callvirt && instructions[i + 1].OpCode == OpCodes.Call)
							{
								return;
							}
							if (!instructions[i + 4].IsBr())
							{
								bool flag = true;
								switch (Junk.Random.Next(0, 2))
								{
								case 1:
									flag = false;
									break;
								case 0:
									flag = true;
									break;
								}
								Local local = new Local(method.Module.CorLibTypes.String);
								method.Body.Variables.Add(local);
								Local local2 = new Local(method.Module.CorLibTypes.Int32);
								method.Body.Variables.Add(local2);
								int ldcI4Value = instructions[i].GetLdcI4Value();
								string s = "HydraTwister" + Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii);
								instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local2));
								instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local2));
								if (flag)
								{
									instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
									instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
								}
								else
								{
									instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
									instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
								}
								instructions.Insert(i, Instruction.Create(OpCodes.Call, method.Module.Import(typeof(string).GetMethod("op_Equality", new Type[2]
								{
									typeof(string),
									typeof(string)
								}))));
								instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, s));
								instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local));
								instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local));
								if (flag)
								{
									instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, s));
								}
								else
								{
									instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, "HydraTwister" + Junk.RandomString(Junk.Random.Next(10, 20), Junk.Ascii)));
								}
								instructions.Insert(i + 5, Instruction.Create(OpCodes.Brtrue_S, instructions[i + 6]));
								instructions.Insert(i + 7, Instruction.Create(OpCodes.Br_S, instructions[i + 8]));
								instructions.RemoveAt(i + 10);
							}
						}
						catch
						{
						}
					}
					method.Body.SimplifyBranches();
				}
			}
		}

		private static string RandomString(int length, string chars)
		{
			return new string((from s in Enumerable.Repeat(chars, length)
				select s[Junk.Random.Next(s.Length)]).ToArray());
		}
	}
}

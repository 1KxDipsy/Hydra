using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace HYDRA_PROTECTOR
{
	internal class hideMethods
	{
		public static Random Random = new Random();

		public static string Ascii = "ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψωABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي0123456789艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת";

		private static string RandomString(int length, string chars)
		{
			return new string((from s in Enumerable.Repeat(chars, length)
				select s[hideMethods.Random.Next(s.Length)]).ToArray());
		}

		public static void Execute(ModuleDefMD asm)
		{
			asm.Mvid = null;
			asm.Name = hideMethods.RandomString(hideMethods.Random.Next(90, 120), hideMethods.Ascii);
			asm.Import(new FieldDefUser(hideMethods.RandomString(hideMethods.Random.Next(90, 120), hideMethods.Ascii)));
			foreach (TypeDef type in asm.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					if (method.Body == null)
					{
						continue;
					}
					method.Body.SimplifyBranches();
					if (!(method.ReturnType.FullName != "System.Void") && method.HasBody && method.Body.Instructions.Count != 0)
					{
						Local local = new Local(asm.Import(typeof(int)).ToTypeSig());
						Local local2 = new Local(asm.Import(typeof(bool)).ToTypeSig());
						method.Body.Variables.Add(local);
						method.Body.Variables.Add(local2);
						Instruction operand = method.Body.Instructions[method.Body.Instructions.Count - 1];
						Instruction item = new Instruction(OpCodes.Ret);
						Instruction instruction = new Instruction(OpCodes.Ldc_I4_1);
						method.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4_0));
						method.Body.Instructions.Insert(1, new Instruction(OpCodes.Stloc, local));
						method.Body.Instructions.Insert(2, new Instruction(OpCodes.Br, instruction));
						Instruction instruction2 = new Instruction(OpCodes.Ldloc, local);
						method.Body.Instructions.Insert(3, instruction2);
						method.Body.Instructions.Insert(4, new Instruction(OpCodes.Ldc_I4_0));
						method.Body.Instructions.Insert(5, new Instruction(OpCodes.Ceq));
						method.Body.Instructions.Insert(6, new Instruction(OpCodes.Ldc_I4_1));
						method.Body.Instructions.Insert(7, new Instruction(OpCodes.Ceq));
						method.Body.Instructions.Insert(8, new Instruction(OpCodes.Stloc, local2));
						method.Body.Instructions.Insert(9, new Instruction(OpCodes.Ldloc, local2));
						method.Body.Instructions.Insert(10, new Instruction(OpCodes.Brtrue, method.Body.Instructions[10]));
						method.Body.Instructions.Insert(11, new Instruction(OpCodes.Ret));
						method.Body.Instructions.Insert(12, new Instruction(OpCodes.Ldstr, "Hydra"));
						method.Body.Instructions.Insert(13, new Instruction(OpCodes.Unbox_Any));
						method.Body.Instructions.Insert(14, new Instruction(OpCodes.Call));
						method.Body.Instructions.Insert(15, new Instruction(OpCodes.Calli));
						method.Body.Instructions.Insert(16, new Instruction(OpCodes.Callvirt));
						method.Body.Instructions.Insert(17, new Instruction(OpCodes.Sizeof));
						method.Body.Instructions.Insert(18, new Instruction(OpCodes.Unaligned, operand));
						method.Body.Instructions.Insert(method.Body.Instructions.Count, instruction);
						method.Body.Instructions.Insert(method.Body.Instructions.Count, new Instruction(OpCodes.Stloc, local2));
						method.Body.Instructions.Insert(method.Body.Instructions.Count, new Instruction(OpCodes.Br, instruction2));
						method.Body.Instructions.Insert(method.Body.Instructions.Count, item);
						ExceptionHandler item2 = new ExceptionHandler(ExceptionHandlerType.Finally)
						{
							HandlerStart = method.Body.Instructions[10],
							HandlerEnd = method.Body.Instructions[11],
							TryEnd = method.Body.Instructions[14],
							TryStart = method.Body.Instructions[12]
						};
						if (!method.Body.HasExceptionHandlers)
						{
							method.Body.ExceptionHandlers.Add(item2);
						}
						method.Body.OptimizeBranches();
						method.Body.OptimizeMacros();
					}
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace HYDRA_PROTECTOR
{
	internal class StringEnc2
	{
		public static void Run(ModuleDefMD module)
		{
			MethodDef method2 = (MethodDef)InjectHelper.Inject(ModuleDefMD.Load(typeof(StringDec2).Module).ResolveTypeDef(MDToken.ToRID(typeof(StringDec2).MetadataToken)), module.GlobalType, module).Single((IDnlibDef method) => method.Name == "Decrypt");
			foreach (MethodDef method3 in module.GlobalType.Methods)
			{
				if (!(method3.Name != ".ctor"))
				{
					module.GlobalType.Remove(method3);
					break;
				}
			}
			foreach (TypeDef type in module.GetTypes())
			{
				if (type.IsGlobalModuleType)
				{
					continue;
				}
				foreach (MethodDef method4 in type.Methods)
				{
					if (!method4.HasBody)
					{
						continue;
					}
					IList<Instruction> instructions = method4.Body.Instructions;
					for (int i = 0; i < instructions.Count; i++)
					{
						if (instructions[i].OpCode == OpCodes.Ldstr)
						{
							string operand = StringEnc2.Encrypt(instructions[i].Operand as string);
							instructions[i].Operand = operand;
							instructions.Insert(i + 1, Instruction.Create(OpCodes.Call, method2));
						}
					}
					method4.Body.SimplifyBranches();
				}
			}
		}

		public static string Encrypt(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes("48235728");
			byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
			ICryptoTransform transform = new DESCryptoServiceProvider().CreateEncryptor(bytes, Encoding.ASCII.GetBytes("fmwa3x6k"));
			byte[] inArray;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(bytes2, 0, bytes2.Length);
					cryptoStream.FlushFinalBlock();
					inArray = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(inArray);
		}
	}
}

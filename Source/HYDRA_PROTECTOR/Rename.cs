using System;
using System.Linq;
using dnlib.DotNet;

namespace HYDRA_PROTECTOR
{
	internal class Rename
	{
		public static Random Random = new Random();

		public static string Ascii = "ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψωABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي0123456789艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת";

		public static void Run(ModuleDef module)
		{
			foreach (TypeDef type in module.Types)
			{
				type.Name = Rename.RandomString(Rename.Random.Next(90, 120), Rename.Ascii);
				type.Namespace = Rename.RandomString(Rename.Random.Next(90, 120), Rename.Ascii);
				if (type.IsGlobalModuleType || type.IsRuntimeSpecialName || type.IsSpecialName || type.IsWindowsRuntime || type.IsInterface)
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (!method.IsRuntimeSpecialName && !method.IsVirtual)
					{
						method.Name = Rename.RandomString(Rename.Random.Next(90, 120), Rename.Ascii);
					}
				}
				foreach (PropertyDef property in type.Properties)
				{
					if (!property.IsRuntimeSpecialName)
					{
						property.Name = Rename.RandomString(Rename.Random.Next(90, 120), Rename.Ascii);
					}
				}
				foreach (FieldDef field in type.Fields)
				{
					field.Name = Rename.RandomString(Rename.Random.Next(90, 120), Rename.Ascii);
				}
				foreach (EventDef @event in type.Events)
				{
					@event.Name = Rename.RandomString(Rename.Random.Next(90, 120), Rename.Ascii);
				}
			}
		}

		private static string RandomString(int length, string chars)
		{
			return new string((from s in Enumerable.Repeat(chars, length)
				select s[Rename.Random.Next(s.Length)]).ToArray());
		}
	}
}

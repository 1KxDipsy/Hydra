using System;
using System.IO;

namespace ns11
{
	public static class ArgChecker
	{
		public static void AssertIsTrue<TException>(bool condition, string message) where TException : Exception, new()
		{
			if (!condition)
			{
				throw (TException)Activator.CreateInstance(typeof(TException), message);
			}
		}

		public static void AssertArgNotNull(object arg, string argName)
		{
			if (arg == null)
			{
				throw new ArgumentNullException(argName);
			}
		}

		public static void AssertArgNotNull(IntPtr arg, string argName)
		{
			if (arg == IntPtr.Zero)
			{
				throw new ArgumentException("IntPtr argument cannot be Zero", argName);
			}
		}

		public static void AssertArgNotNullOrEmpty(string arg, string argName)
		{
			if (string.IsNullOrEmpty(arg))
			{
				throw new ArgumentNullException(argName);
			}
		}

		public static T AssertArgOfType<T>(object arg, string argName)
		{
			ArgChecker.AssertArgNotNull(arg, argName);
			if (!(arg is T))
			{
				throw new ArgumentException($"Given argument isn't of type '{typeof(T).Name}'.", argName);
			}
			return (T)arg;
		}

		public static void AssertFileExist(string arg, string argName)
		{
			ArgChecker.AssertArgNotNullOrEmpty(arg, argName);
			if (!File.Exists(arg))
			{
				throw new FileNotFoundException($"Given file in argument '{argName}' not exist.", arg);
			}
		}
	}
}

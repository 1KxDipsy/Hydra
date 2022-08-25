using System.Collections.Generic;

namespace HydraSZEDRatApp.Controls
{
	internal class App
	{
		public static string Error = null;

		public static Dictionary<string, string> Variables = new Dictionary<string, string>();

		public static string GrabVariable(string name)
		{
			try
			{
				if (User.ID != null || User.HWID != null || User.IP != null || !Constants.Breached)
				{
					return App.Variables[name];
				}
				Constants.Breached = true;
				return "User is not logged in, possible breach detected!";
			}
			catch
			{
				return "N/A";
			}
		}
	}
}

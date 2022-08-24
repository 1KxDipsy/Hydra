using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class64 : RAdapter
	{
		private static readonly Class64 class64_0 = new Class64();

		public static Class64 Class64_0 => Class64.class64_0;

		private Class64()
		{
			base.AddFontFamilyMapping("monospace", "Courier New");
			base.AddFontFamilyMapping("Helvetica", "Arial");
			FontFamily[] families = FontFamily.Families;
			for (int i = 0; i < families.Length; i++)
			{
				base.AddFontFamily(new Class68(families[i]));
			}
		}

		protected override RColor GetColorInt(string colorName)
		{
			return Class19.smethod_10(Color.FromName(colorName));
		}

		protected override RPen CreatePen(RColor color)
		{
			return new Class71(new Pen(Class19.smethod_11(color)));
		}

		protected override RBrush CreateSolidBrush(RColor color)
		{
			return new Class65((color == RColor.White) ? Brushes.White : ((color == RColor.Black) ? Brushes.Black : ((color.Byte_3 >= 1) ? new SolidBrush(Class19.smethod_11(color)) : Brushes.Transparent)), bool_1: false);
		}

		protected override RBrush CreateLinearGradientBrush(RRect rect, RColor color1, RColor color2, double angle)
		{
			return new Class65(new LinearGradientBrush(Class19.smethod_8(rect), Class19.smethod_11(color1), Class19.smethod_11(color2), (float)angle), bool_1: true);
		}

		protected override RImage ConvertImageInt(object image)
		{
			return (image != null) ? new Class70((Image)image) : null;
		}

		protected override RImage ImageFromStreamInt(Stream memoryStream)
		{
			return new Class70(Image.FromStream(memoryStream));
		}

		protected override RFont CreateFontInt(string family, double size, RFontStyle style)
		{
			return new Class67(new Font(family, (float)size, (FontStyle)style));
		}

		protected override RFont CreateFontInt(RFontFamily family, double size, RFontStyle style)
		{
			return new Class67(new Font(((Class68)family).FontFamily_0, (float)size, (FontStyle)style));
		}

		protected override object GetClipboardDataObjectInt(string html, string plainText)
		{
			return Class18.smethod_0(html, plainText);
		}

		protected override void SetToClipboardInt(string text)
		{
			Class18.smethod_2(text);
		}

		protected override void SetToClipboardInt(string html, string plainText)
		{
			Class18.smethod_1(html, plainText);
		}

		protected override void SetToClipboardInt(RImage image)
		{
			Clipboard.SetImage(((Class70)image).Image_0);
		}

		protected override RContextMenu CreateContextMenuInt()
		{
			return new Class66();
		}

		protected override void SaveToFileInt(RImage image, string name, string extension, RControl control = null)
		{
			using SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
			saveFileDialog.FileName = name;
			saveFileDialog.DefaultExt = extension;
			if (((control == null) ? saveFileDialog.ShowDialog() : saveFileDialog.ShowDialog(((Control2)control).Control_0)) == DialogResult.OK)
			{
				((Class70)image).Image_0.Save(saveFileDialog.FileName);
			}
		}
	}
}

using System;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ns9
{
	public static class MetafileExtensions
	{
		public static void SaveAsEmf(Metafile me, string fileName)
		{
			int num = me.GetHenhmetafile().ToInt32();
			int enhMetaFileBits = MetafileExtensions.GetEnhMetaFileBits(num, 0, null);
			byte[] array = new byte[enhMetaFileBits];
			if (MetafileExtensions.GetEnhMetaFileBits(num, enhMetaFileBits, array) <= 0)
			{
				throw new SystemException("Fail");
			}
			FileStream fileStream = File.Open(fileName, FileMode.Create);
			fileStream.Write(array, 0, enhMetaFileBits);
			fileStream.Close();
			fileStream.Dispose();
			if (!MetafileExtensions.DeleteEnhMetaFile(num))
			{
				throw new SystemException("Fail Free");
			}
		}

		[DllImport("gdi32")]
		public static extern int GetEnhMetaFileBits(int hemf, int cbBuffer, byte[] lpbBuffer);

		[DllImport("gdi32")]
		public static extern bool DeleteEnhMetaFile(int hemfbitHandle);
	}
}

using System;
using System.Drawing;

namespace ZEDRAT.Messages
{
	[Serializable]
	public class RemoteFilesList
	{
		public string FileName;

		public string Size;

		public string Type;

		public Bitmap FileIcon;
	}
}

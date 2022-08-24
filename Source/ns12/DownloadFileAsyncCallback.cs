using System;

namespace ns12
{
	public delegate void DownloadFileAsyncCallback(Uri imageUri, string filePath, Exception error, bool canceled);
}

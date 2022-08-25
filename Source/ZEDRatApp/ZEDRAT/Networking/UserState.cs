using System;
using System.Windows.Forms;
using ZEDRatApp.Forms;
using ZEDRatApp.ZEDRAT.Utilities;

namespace ZEDRatApp.ZEDRAT.Networking
{
	public class UserState : IDisposable
	{
		private bool _processingDirectory;

		private readonly object _processingDirectoryLock;

		public string Version { get; set; }

		public string OperatingSystem { get; set; }

		public string AccountType { get; set; }

		public int ImageIndex { get; set; }

		public string Country { get; set; }

		public string CountryCode { get; set; }

		public string Region { get; set; }

		public string City { get; set; }

		public string Id { get; set; }

		public string Username { get; set; }

		public string PCName { get; set; }

		public string UserAtPc => $"{this.Username}@{this.PCName}";

		public string CountryWithCode => $"{this.Country} [{this.CountryCode}]";

		public string Tag { get; set; }

		public string DownloadDirectory { get; set; }

		public Remote_Desk FrmRdp { get; set; }

		public bool ReceivedLastDirectory { get; set; }

		public UnsafeStreamCodec StreamCodec { get; set; }

		public bool ProcessingDirectory
		{
			get
			{
				lock (this._processingDirectoryLock)
				{
					return this._processingDirectory;
				}
			}
			set
			{
				lock (this._processingDirectoryLock)
				{
					this._processingDirectory = value;
				}
			}
		}

		public UserState()
		{
			this.ReceivedLastDirectory = true;
			this._processingDirectory = false;
			this._processingDirectoryLock = new object();
		}

		public void Dispose()
		{
			this.Dispose(disposing: true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing)
			{
				return;
			}
			try
			{
				if (this.FrmRdp != null)
				{
					this.FrmRdp.Invoke((MethodInvoker)delegate
					{
						this.FrmRdp.Close();
					});
				}
			}
			catch (InvalidOperationException)
			{
			}
			if (this.StreamCodec != null)
			{
				this.StreamCodec.Dispose();
			}
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Runtime.CompilerServices;

namespace ns1
{
	[Description("Get several unique device IDs (UIDs) as string")]
	[ToolboxBitmap(typeof(Process))]
	[DebuggerStepThrough]
	public class SiticoneDeviceID : Component
	{
		public enum DeviceIdentifierType
		{
			ProcessorID = 0,
			BIOSVersion = 1,
			BIOSSerialNumber = 2,
			HardDriveCaption = 3,
			HardDriveFirmwareRevision = 4,
			HardDriveModel = 5,
			HardDriveSerialNumber = 6,
			HardDriveSignature = 7,
			HardDriveSize = 8,
			BaseBoardSerialNumber = 9,
			UserAccountSID = 10
		}

		private DeviceIdentifierType deviceIdentifierType_0 = DeviceIdentifierType.ProcessorID;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0 = string.Empty;

		[Category("Siticone Component Features")]
		[Description("Select the identifer type to retrieve its value. The ID will be returned in a string format")]
		[Browsable(true)]
		public DeviceIdentifierType DeviceIDType
		{
			get
			{
				return this.deviceIdentifierType_0;
			}
			set
			{
				this.deviceIdentifierType_0 = value;
				this.method_0();
			}
		}

		[Browsable(true)]
		[Description("The GetID property retrieves the Unique Device Identifier and returns it in a format of a string")]
		[Category("Siticone Component Features")]
		public string GetID
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			private set
			{
				this.string_0 = value;
			}
		}

		public SiticoneDeviceID()
		{
			this.method_0();
		}

		private void method_0()
		{
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.DoWork += new DoWorkEventHandler(method_2);
			backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(method_1);
			try
			{
				backgroundWorker.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		private void method_1(object sender, RunWorkerCompletedEventArgs e)
		{
			this.method_3();
			if (string.IsNullOrWhiteSpace(this.GetID))
			{
				this.method_3();
			}
		}

		private void method_2(object sender, DoWorkEventArgs e)
		{
			this.method_3();
		}

		private void method_3()
		{
			switch (this.DeviceIDType)
			{
			case DeviceIdentifierType.ProcessorID:
			{
				foreach (ManagementObject item in new ManagementObjectSearcher("SELECT * FROM Win32_Processor").Get())
				{
					this.GetID = item["ProcessorId"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.BIOSVersion:
			{
				foreach (ManagementObject item2 in new ManagementObjectSearcher("SELECT * FROM Win32_BIOS").Get())
				{
					this.GetID = item2["Version"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.BIOSSerialNumber:
			{
				foreach (ManagementObject item3 in new ManagementObjectSearcher("SELECT * FROM Win32_BIOS").Get())
				{
					this.GetID = item3["SerialNumber"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.HardDriveCaption:
			{
				foreach (ManagementObject item4 in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get())
				{
					this.GetID = item4["Caption"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.HardDriveFirmwareRevision:
			{
				foreach (ManagementObject item5 in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get())
				{
					this.GetID = item5["FirmwareRevision"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.HardDriveModel:
			{
				foreach (ManagementObject item6 in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get())
				{
					this.GetID = item6["Model"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.HardDriveSerialNumber:
			{
				foreach (ManagementObject item7 in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get())
				{
					this.GetID = item7["SerialNumber"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.HardDriveSignature:
			{
				foreach (ManagementObject item8 in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get())
				{
					this.GetID = item8["Signature"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.HardDriveSize:
			{
				foreach (ManagementObject item9 in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get())
				{
					this.GetID = item9["Size"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.BaseBoardSerialNumber:
			{
				foreach (ManagementObject item10 in new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard").Get())
				{
					this.GetID = item10["SerialNumber"].ToString();
				}
				break;
			}
			case DeviceIdentifierType.UserAccountSID:
			{
				foreach (ManagementObject item11 in new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount").Get())
				{
					this.GetID = item11["SID"].ToString();
				}
				break;
			}
			}
		}
	}
}

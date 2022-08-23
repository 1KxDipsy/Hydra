using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bunifu_Controls;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using EO.WebBrowser;
using EO.WinForm;
using Guna.UI2.WinForms;
using MetroSet_UI.Controls;
using ZEDRatApp.Forms.Obfu;
using ZEDRatApp.Properties;

namespace ZEDRatApp.Forms
{
	public class Forma : Form
	{
		public string Info = string.Empty;

		public string Key = string.Empty;

		public string User = string.Empty;

		public string Pass = string.Empty;

		public string Keys = string.Empty;

		private IContainer components;

		public static string ee;

		public static string index;

		private static readonly string name;

		private static readonly string Hydraid;

		private static readonly string Hydramystic;

		private static readonly string version;

		public static Phychedelic trance;

		private BunifuFormDock bunifuFormDock1;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator2;

		private BunifuSeparator bunifuSeparator3;

		private BunifuSeparator bunifuSeparator4;

		private BunifuIconButton btnLogout;

		private BunifuTextBox key;

		private BunifuTextBox password;

		private BunifuTextBox username;

		private BunifuIconButton bunifuIconButton1;

		private MetroSetSwitch chkSave;

		private CustomLabel customLabel2;

		private CustomLabel customLabel1;

		private Label status;

		private Label label3;

		private BunifuIconButton RgstrBtn;

		private BunifuIconButton LicBtn;

		private BunifuIconButton LoginBtn;

		private BunifuIconButton UpgradeBtn;

		private BunifuToolTip bunifuToolTip1;

		private Guna2ShadowForm guna2ShadowForm1;

		private WebControl webControl1;

		private WebView webView1;

		public Forma()
		{
			Runtime.AddLicense("6A+frfD09uihfsay4Q/lW5f69h3youbyzs2xaqW0s8uud7Pl9Q+frfD09uihfsay6BvlW5f69h3youbyzs2xaaW0s8uud7Pl9Q+frfD09uihfsay6BvlW5f69h3youbyzs2xaqW0s8uud7Oz8hfrqO7CzRrxndz22hnlqJfo8h/kdpm1wNyuaae0ws2frOzm1iPvounpBOzzdpm1wNyucrC9ys2fr9z2BBTup7Smw82faLXABBTmp9j4Bh3kd+T20tbFiajL4fPRoenW2RX4ksbS4hK8drOzBBTmp9j4Bh3kd7Oz/RTinuX39ul14+30EO2s3MLNF+ic3PIEEMidtbXE3rZ1pvD6DuSn6unaD7112PD9GvZ3s+X1D5+t8PT26KF+xrLUE/Go5Omzy/We6ff6Gu12mbbB2a9bl7PP5+Cd26QFJO+etKbW+q183/YAGORbl/r2HfKi5vLOzbFqpbSzy653s+X1D5+t8PT26KF+xrLoEOFbl/r2HfKi5vLOzbFppbSzy653s+X1D5+t8PT26KF+xrLoEOFbl/r2HfKi5vLOzbFqpbSzy653s+X1D5+t8PT26KF+xrLhD+Vbl/r2HfKi5vLOzbFppbSzy653s+X1");
			this.InitializeComponent();
		}

		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void Forma_Load(object sender, EventArgs e)
		{
			this.bunifuFormDock1.DockingIndicatorsColor = Color.FromArgb(226, 28, 71);
			this.password.UseSystemPasswordChar = true;
			Forma.trance.init();
			if (File.Exists(Application.StartupPath + "\\LocalUser\\LoginRememberMe.ini"))
			{
				this.chkSave.Switched = true;
				using (StreamReader streamReader = new StreamReader(Application.StartupPath + "\\LocalUser\\LoginRememberMe.ini"))
				{
					if (!string.IsNullOrWhiteSpace(streamReader.ReadToEnd()))
					{
						string text = File.ReadAllText(Application.StartupPath + "\\LocalUser\\LoginRememberMe.ini");
						this.User = text.Split('|')[0];
						this.Pass = text.Split('|')[1];
						this.username.Text = this.User;
						this.password.Text = this.Pass;
						streamReader.Dispose();
					}
				}
				this.LoginBtn.PerformClick();
			}
			else if (File.Exists(Application.StartupPath + "\\LocalUser\\Key.ini"))
			{
				this.chkSave.Switched = true;
				using (StreamReader streamReader2 = new StreamReader(Application.StartupPath + "\\LocalUser\\Key.ini"))
				{
					if (!string.IsNullOrWhiteSpace(streamReader2.ReadToEnd()))
					{
						string text2 = File.ReadAllText(Application.StartupPath + "\\LocalUser\\Key.ini");
						this.User = text2.Split('|')[0];
						this.Keys = text2.Split('|')[1];
						this.key.Text = this.Keys;
						streamReader2.Dispose();
					}
				}
				this.LicBtn.PerformClick();
			}
			if (Forma.trance.checkblack())
			{
				this.LicBtn.PerformClick();
			}
		}

		private void UpgradeBtn_Click(object sender, EventArgs e)
		{
			Forma.trance.upgrade(this.username.Text, this.key.Text);
		}

		private static string random_string()
		{
			string text = null;
			Random random = new Random();
			for (int i = 0; i < 5; i++)
			{
				text += Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0)));
			}
			return text;
		}

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			Forma.trance.login(this.username.Text, this.password.Text);
			new Thread((ThreadStart)delegate
			{
				this.status.Text = "Login successful!";
				base.Hide();
			}).Start();
		}

		private void RgstrBtn_Click(object sender, EventArgs e)
		{
			Forma.trance.register(this.username.Text, this.password.Text, this.key.Text);
			new Thread((ThreadStart)delegate
			{
				if (Forma.trance.response.success)
				{
					this.status.Text = "register successful!";
					base.Hide();
				}
				else
				{
					this.status.Text = "Status: " + Forma.trance.response.message;
				}
			}).Start();
		}

		public DateTime UnixTimeToDateTime(long unixtime)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).AddSeconds(unixtime).ToLocalTime();
		}

		private void LicBtn_Click(object sender, EventArgs e)
		{
			Forma.trance.license(this.key.Text);
			new Thread((ThreadStart)delegate
			{
				if (Forma.trance.response.success)
				{
					if (this.chkSave.Switched)
					{
						if (!File.Exists(Application.StartupPath + "\\LocalUser"))
						{
							Directory.CreateDirectory(Application.StartupPath + "\\LocalUser");
							File.WriteAllText(contents: "Key|" + this.key.Text, path: Application.StartupPath + "\\LocalUser\\Key.ini");
						}
						for (int i = 0; i < Forma.trance.user_data.subscriptions.Count; i++)
						{
						}
						this.status.Text = "Login successful!";
					}
					base.Hide();
				}
				else
				{
					this.status.Text = "Status: " + Forma.trance.response.message;
				}
			}).Start();
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			Forma.ReleaseCapture();
			Forma.SendMessage(base.Handle, 274, 61458, 0);
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(Forma.reupload(""));
		}

		private static string reupload(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i] ^ c);
			}
			return stringBuilder.ToString();
		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
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
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties11 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties12 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Forma));
			this.bunifuFormDock1 = new Bunifu.UI.WinForms.BunifuFormDock();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.btnLogout = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.username = new Bunifu.UI.WinForms.BunifuTextBox();
			this.password = new Bunifu.UI.WinForms.BunifuTextBox();
			this.key = new Bunifu.UI.WinForms.BunifuTextBox();
			this.bunifuIconButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.chkSave = new MetroSet_UI.Controls.MetroSetSwitch();
			this.customLabel1 = new Bunifu_Controls.CustomLabel();
			this.customLabel2 = new Bunifu_Controls.CustomLabel();
			this.status = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.LoginBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.LicBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.RgstrBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.UpgradeBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
			this.webControl1 = new EO.WinForm.WebControl();
			this.webView1 = new EO.WebBrowser.WebView();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.bunifuFormDock1.AllowFormDragging = true;
			this.bunifuFormDock1.AllowFormDropShadow = true;
			this.bunifuFormDock1.AllowFormResizing = true;
			this.bunifuFormDock1.AllowHidingBottomRegion = true;
			this.bunifuFormDock1.AllowOpacityChangesWhileDragging = false;
			this.bunifuFormDock1.BorderOptions.BottomBorder.BorderColor = System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.BottomBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.BottomBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.LeftBorder.BorderColor = System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.LeftBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.LeftBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.RightBorder.BorderColor = System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.RightBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.RightBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.TopBorder.BorderColor = System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.TopBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.TopBorder.ShowBorder = true;
			this.bunifuFormDock1.ContainerControl = this;
			this.bunifuFormDock1.DockingIndicatorsColor = System.Drawing.Color.FromArgb(202, 215, 233);
			this.bunifuFormDock1.DockingIndicatorsOpacity = 0.5;
			this.bunifuFormDock1.DockingOptions.DockAll = true;
			this.bunifuFormDock1.DockingOptions.DockBottomLeft = true;
			this.bunifuFormDock1.DockingOptions.DockBottomRight = true;
			this.bunifuFormDock1.DockingOptions.DockFullScreen = true;
			this.bunifuFormDock1.DockingOptions.DockLeft = true;
			this.bunifuFormDock1.DockingOptions.DockRight = true;
			this.bunifuFormDock1.DockingOptions.DockTopLeft = true;
			this.bunifuFormDock1.DockingOptions.DockTopRight = true;
			this.bunifuFormDock1.FormDraggingOpacity = 0.9;
			this.bunifuFormDock1.ParentForm = this;
			this.bunifuFormDock1.ShowCursorChanges = true;
			this.bunifuFormDock1.ShowDockingIndicators = true;
			this.bunifuFormDock1.TitleBarOptions.AllowFormDragging = true;
			this.bunifuFormDock1.TitleBarOptions.BunifuFormDock = this.bunifuFormDock1;
			this.bunifuFormDock1.TitleBarOptions.DoubleClickToExpandWindow = true;
			this.bunifuFormDock1.TitleBarOptions.TitleBarControl = null;
			this.bunifuFormDock1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(2, -8);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(5);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Size = new System.Drawing.Size(696, 16);
			this.bunifuSeparator2.TabIndex = 159;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator2, "");
			this.bunifuSeparator2.Visible = false;
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(2, 331);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(8);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Size = new System.Drawing.Size(696, 16);
			this.bunifuSeparator1.TabIndex = 160;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator1, "");
			this.bunifuSeparator1.Visible = false;
			this.bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(690, 1);
			this.bunifuSeparator4.Margin = new System.Windows.Forms.Padding(5);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator4.Size = new System.Drawing.Size(10, 338);
			this.bunifuSeparator4.TabIndex = 161;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator4, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator4, "");
			this.bunifuSeparator4.Visible = false;
			this.bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator3.LineThickness = 1;
			this.bunifuSeparator3.Location = new System.Drawing.Point(-5, 0);
			this.bunifuSeparator3.Margin = new System.Windows.Forms.Padding(8);
			this.bunifuSeparator3.Name = "bunifuSeparator3";
			this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator3.Size = new System.Drawing.Size(10, 339);
			this.bunifuSeparator3.TabIndex = 162;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator3, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator3, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator3, "");
			this.bunifuSeparator3.Visible = false;
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
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.btnLogout.CustomizableEdges = borderEdges;
			this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnLogout.Image = (System.Drawing.Image)resources.GetObject("btnLogout.Image");
			this.btnLogout.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnLogout.Location = new System.Drawing.Point(645, 16);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.RoundBorders = false;
			this.btnLogout.ShowBorders = true;
			this.btnLogout.Size = new System.Drawing.Size(35, 35);
			this.btnLogout.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnLogout.TabIndex = 163;
			this.bunifuToolTip1.SetToolTip(this.btnLogout, "");
			this.bunifuToolTip1.SetToolTipIcon(this.btnLogout, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnLogout, "");
			this.btnLogout.Click += new System.EventHandler(guna2PictureBox1_Click);
			this.username.AcceptsReturn = false;
			this.username.AcceptsTab = false;
			this.username.AnimationSpeed = 200;
			this.username.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.username.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.username.AutoSizeHeight = true;
			this.username.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.username.BackgroundImage = (System.Drawing.Image)resources.GetObject("username.BackgroundImage");
			this.username.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.username.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.username.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.username.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.username.BorderRadius = 1;
			this.username.BorderThickness = 1;
			this.username.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.username.DefaultFont = new System.Drawing.Font("Century Gothic", 9.25f);
			this.username.DefaultText = "";
			this.username.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.username.HideSelection = true;
			this.username.IconLeft = null;
			this.username.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.username.IconPadding = 10;
			this.username.IconRight = null;
			this.username.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.username.Lines = new string[0];
			this.username.Location = new System.Drawing.Point(118, 86);
			this.username.MaxLength = 32767;
			this.username.MinimumSize = new System.Drawing.Size(1, 1);
			this.username.Modified = false;
			this.username.Multiline = false;
			this.username.Name = "username";
			stateProperties.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties.FillColor = System.Drawing.Color.Empty;
			stateProperties.ForeColor = System.Drawing.Color.Empty;
			stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.username.OnActiveState = stateProperties;
			stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.username.OnDisabledState = stateProperties2;
			stateProperties3.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties3.FillColor = System.Drawing.Color.Empty;
			stateProperties3.ForeColor = System.Drawing.Color.Empty;
			stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.username.OnHoverState = stateProperties3;
			stateProperties4.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties4.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties4.ForeColor = System.Drawing.Color.Empty;
			stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.username.OnIdleState = stateProperties4;
			this.username.Padding = new System.Windows.Forms.Padding(3);
			this.username.PasswordChar = '\0';
			this.username.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.username.PlaceholderText = "User";
			this.username.ReadOnly = false;
			this.username.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.username.SelectedText = "";
			this.username.SelectionLength = 0;
			this.username.SelectionStart = 0;
			this.username.ShortcutsEnabled = true;
			this.username.Size = new System.Drawing.Size(460, 38);
			this.username.TabIndex = 165;
			this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.username.TextMarginBottom = 0;
			this.username.TextMarginLeft = 3;
			this.username.TextMarginTop = 1;
			this.username.TextPlaceholder = "User";
			this.bunifuToolTip1.SetToolTip(this.username, "");
			this.bunifuToolTip1.SetToolTipIcon(this.username, null);
			this.bunifuToolTip1.SetToolTipTitle(this.username, "");
			this.username.UseSystemPasswordChar = false;
			this.username.WordWrap = true;
			this.password.AcceptsReturn = false;
			this.password.AcceptsTab = false;
			this.password.AnimationSpeed = 200;
			this.password.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.password.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.password.AutoSizeHeight = true;
			this.password.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.password.BackgroundImage = (System.Drawing.Image)resources.GetObject("password.BackgroundImage");
			this.password.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.password.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.password.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.password.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.password.BorderRadius = 1;
			this.password.BorderThickness = 1;
			this.password.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.password.DefaultFont = new System.Drawing.Font("Century Gothic", 9.25f);
			this.password.DefaultText = "";
			this.password.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.password.HideSelection = true;
			this.password.IconLeft = null;
			this.password.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.password.IconPadding = 10;
			this.password.IconRight = null;
			this.password.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.password.Lines = new string[0];
			this.password.Location = new System.Drawing.Point(118, 128);
			this.password.MaxLength = 32767;
			this.password.MinimumSize = new System.Drawing.Size(1, 1);
			this.password.Modified = false;
			this.password.Multiline = false;
			this.password.Name = "password";
			stateProperties5.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties5.FillColor = System.Drawing.Color.Empty;
			stateProperties5.ForeColor = System.Drawing.Color.Empty;
			stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.password.OnActiveState = stateProperties5;
			stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.password.OnDisabledState = stateProperties6;
			stateProperties7.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties7.FillColor = System.Drawing.Color.Empty;
			stateProperties7.ForeColor = System.Drawing.Color.Empty;
			stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.password.OnHoverState = stateProperties7;
			stateProperties8.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties8.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties8.ForeColor = System.Drawing.Color.Empty;
			stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.password.OnIdleState = stateProperties8;
			this.password.Padding = new System.Windows.Forms.Padding(3);
			this.password.PasswordChar = '\0';
			this.password.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.password.PlaceholderText = "Password";
			this.password.ReadOnly = false;
			this.password.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.password.SelectedText = "";
			this.password.SelectionLength = 0;
			this.password.SelectionStart = 0;
			this.password.ShortcutsEnabled = true;
			this.password.Size = new System.Drawing.Size(460, 38);
			this.password.TabIndex = 166;
			this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.password.TextMarginBottom = 0;
			this.password.TextMarginLeft = 3;
			this.password.TextMarginTop = 1;
			this.password.TextPlaceholder = "Password";
			this.bunifuToolTip1.SetToolTip(this.password, "");
			this.bunifuToolTip1.SetToolTipIcon(this.password, null);
			this.bunifuToolTip1.SetToolTipTitle(this.password, "");
			this.password.UseSystemPasswordChar = false;
			this.password.WordWrap = true;
			this.key.AcceptsReturn = false;
			this.key.AcceptsTab = false;
			this.key.AnimationSpeed = 200;
			this.key.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.key.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.key.AutoSizeHeight = true;
			this.key.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.key.BackgroundImage = (System.Drawing.Image)resources.GetObject("key.BackgroundImage");
			this.key.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.key.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.key.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.key.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.key.BorderRadius = 1;
			this.key.BorderThickness = 1;
			this.key.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.key.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.key.DefaultFont = new System.Drawing.Font("Century Gothic", 9.25f);
			this.key.DefaultText = "";
			this.key.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.key.HideSelection = true;
			this.key.IconLeft = null;
			this.key.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.key.IconPadding = 10;
			this.key.IconRight = null;
			this.key.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.key.Lines = new string[0];
			this.key.Location = new System.Drawing.Point(118, 170);
			this.key.MaxLength = 32767;
			this.key.MinimumSize = new System.Drawing.Size(1, 1);
			this.key.Modified = false;
			this.key.Multiline = false;
			this.key.Name = "key";
			stateProperties9.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties9.FillColor = System.Drawing.Color.Empty;
			stateProperties9.ForeColor = System.Drawing.Color.Empty;
			stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.key.OnActiveState = stateProperties9;
			stateProperties10.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties10.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties10.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.key.OnDisabledState = stateProperties10;
			stateProperties11.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties11.FillColor = System.Drawing.Color.Empty;
			stateProperties11.ForeColor = System.Drawing.Color.Empty;
			stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.key.OnHoverState = stateProperties11;
			stateProperties12.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties12.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties12.ForeColor = System.Drawing.Color.Empty;
			stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.key.OnIdleState = stateProperties12;
			this.key.Padding = new System.Windows.Forms.Padding(3);
			this.key.PasswordChar = '\0';
			this.key.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.key.PlaceholderText = "Key";
			this.key.ReadOnly = false;
			this.key.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.key.SelectedText = "";
			this.key.SelectionLength = 0;
			this.key.SelectionStart = 0;
			this.key.ShortcutsEnabled = true;
			this.key.Size = new System.Drawing.Size(460, 38);
			this.key.TabIndex = 167;
			this.key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.key.TextMarginBottom = 0;
			this.key.TextMarginLeft = 3;
			this.key.TextMarginTop = 1;
			this.key.TextPlaceholder = "Key";
			this.bunifuToolTip1.SetToolTip(this.key, "");
			this.bunifuToolTip1.SetToolTipIcon(this.key, null);
			this.bunifuToolTip1.SetToolTipTitle(this.key, "");
			this.key.UseSystemPasswordChar = false;
			this.key.WordWrap = true;
			this.bunifuIconButton1.AllowAnimations = true;
			this.bunifuIconButton1.AllowBorderColorChanges = true;
			this.bunifuIconButton1.AllowMouseEffects = true;
			this.bunifuIconButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuIconButton1.AnimationSpeed = 200;
			this.bunifuIconButton1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton1.BorderRadius = 1;
			this.bunifuIconButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton1.BorderThickness = 1;
			this.bunifuIconButton1.ColorContrastOnClick = 30;
			this.bunifuIconButton1.ColorContrastOnHover = 30;
			this.bunifuIconButton1.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.bunifuIconButton1.CustomizableEdges = borderEdges2;
			this.bunifuIconButton1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton1.Image");
			this.bunifuIconButton1.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton1.Location = new System.Drawing.Point(15, 16);
			this.bunifuIconButton1.Name = "bunifuIconButton1";
			this.bunifuIconButton1.RoundBorders = false;
			this.bunifuIconButton1.ShowBorders = true;
			this.bunifuIconButton1.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton1.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton1.TabIndex = 168;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton1, "");
			this.chkSave.BackColor = System.Drawing.Color.Transparent;
			this.chkSave.BackgroundColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkSave.BorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkSave.CheckColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.chkSave.DisabledBorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkSave.DisabledCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkSave.DisabledUnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkSave.IsDerivedStyle = true;
			this.chkSave.Location = new System.Drawing.Point(118, 224);
			this.chkSave.Name = "chkSave";
			this.chkSave.Size = new System.Drawing.Size(58, 22);
			this.chkSave.StyleManager = null;
			this.chkSave.Switched = true;
			this.chkSave.SymbolColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkSave.TabIndex = 226;
			this.chkSave.Text = "metroSetSwitch5";
			this.chkSave.ThemeAuthor = "Narwin";
			this.chkSave.ThemeName = "MetroDark";
			this.bunifuToolTip1.SetToolTip(this.chkSave, "Save your user/pass/lisence for autotic login!");
			this.bunifuToolTip1.SetToolTipIcon(this.chkSave, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.chkSave, "HYDRA");
			this.chkSave.UnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.customLabel1.AutoSize = true;
			this.customLabel1.BackColor = System.Drawing.Color.Transparent;
			this.customLabel1.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.customLabel1.Location = new System.Drawing.Point(57, 23);
			this.customLabel1.Name = "customLabel1";
			this.customLabel1.Size = new System.Drawing.Size(48, 20);
			this.customLabel1.TabIndex = 227;
			this.customLabel1.Text = "Login";
			this.bunifuToolTip1.SetToolTip(this.customLabel1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.customLabel1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.customLabel1, "");
			this.customLabel2.AutoSize = true;
			this.customLabel2.BackColor = System.Drawing.Color.Transparent;
			this.customLabel2.Font = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.customLabel2.Location = new System.Drawing.Point(182, 227);
			this.customLabel2.Name = "customLabel2";
			this.customLabel2.Size = new System.Drawing.Size(74, 17);
			this.customLabel2.TabIndex = 228;
			this.customLabel2.Text = "Save Login";
			this.bunifuToolTip1.SetToolTip(this.customLabel2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.customLabel2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.customLabel2, "");
			this.status.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.status.AutoSize = true;
			this.status.BackColor = System.Drawing.Color.Transparent;
			this.status.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.status.Location = new System.Drawing.Point(80, 310);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(57, 21);
			this.status.TabIndex = 231;
			this.status.Text = "status";
			this.bunifuToolTip1.SetToolTip(this.status, "");
			this.bunifuToolTip1.SetToolTipIcon(this.status, null);
			this.bunifuToolTip1.SetToolTipTitle(this.status, "");
			this.status.Visible = false;
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(11, 310);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 21);
			this.label3.TabIndex = 230;
			this.label3.Text = "Status:";
			this.bunifuToolTip1.SetToolTip(this.label3, "");
			this.bunifuToolTip1.SetToolTipIcon(this.label3, null);
			this.bunifuToolTip1.SetToolTipTitle(this.label3, "");
			this.label3.Visible = false;
			this.LoginBtn.AllowAnimations = true;
			this.LoginBtn.AllowBorderColorChanges = true;
			this.LoginBtn.AllowMouseEffects = true;
			this.LoginBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.LoginBtn.AnimationSpeed = 200;
			this.LoginBtn.BackColor = System.Drawing.Color.Transparent;
			this.LoginBtn.BackgroundColor = System.Drawing.Color.Transparent;
			this.LoginBtn.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.LoginBtn.BorderRadius = 1;
			this.LoginBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.LoginBtn.BorderThickness = 1;
			this.LoginBtn.ColorContrastOnClick = 30;
			this.LoginBtn.ColorContrastOnHover = 30;
			this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges3.BottomLeft = true;
			borderEdges3.BottomRight = true;
			borderEdges3.TopLeft = true;
			borderEdges3.TopRight = true;
			this.LoginBtn.CustomizableEdges = borderEdges3;
			this.LoginBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.LoginBtn.Image = (System.Drawing.Image)resources.GetObject("LoginBtn.Image");
			this.LoginBtn.ImageMargin = new System.Windows.Forms.Padding(0);
			this.LoginBtn.Location = new System.Drawing.Point(461, 218);
			this.LoginBtn.Name = "LoginBtn";
			this.LoginBtn.RoundBorders = false;
			this.LoginBtn.ShowBorders = true;
			this.LoginBtn.Size = new System.Drawing.Size(40, 40);
			this.LoginBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.LoginBtn.TabIndex = 233;
			this.bunifuToolTip1.SetToolTip(this.LoginBtn, "Login with user/pass/license!");
			this.bunifuToolTip1.SetToolTipIcon(this.LoginBtn, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.LoginBtn, "HYDRA");
			this.LoginBtn.Click += new System.EventHandler(LoginBtn_Click);
			this.LicBtn.AllowAnimations = true;
			this.LicBtn.AllowBorderColorChanges = true;
			this.LicBtn.AllowMouseEffects = true;
			this.LicBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.LicBtn.AnimationSpeed = 200;
			this.LicBtn.BackColor = System.Drawing.Color.Transparent;
			this.LicBtn.BackgroundColor = System.Drawing.Color.Transparent;
			this.LicBtn.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.LicBtn.BorderRadius = 1;
			this.LicBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.LicBtn.BorderThickness = 1;
			this.LicBtn.ColorContrastOnClick = 30;
			this.LicBtn.ColorContrastOnHover = 30;
			this.LicBtn.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges4.BottomLeft = true;
			borderEdges4.BottomRight = true;
			borderEdges4.TopLeft = true;
			borderEdges4.TopRight = true;
			this.LicBtn.CustomizableEdges = borderEdges4;
			this.LicBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.LicBtn.Image = (System.Drawing.Image)resources.GetObject("LicBtn.Image");
			this.LicBtn.ImageMargin = new System.Windows.Forms.Padding(0);
			this.LicBtn.Location = new System.Drawing.Point(543, 218);
			this.LicBtn.Name = "LicBtn";
			this.LicBtn.RoundBorders = false;
			this.LicBtn.ShowBorders = true;
			this.LicBtn.Size = new System.Drawing.Size(35, 35);
			this.LicBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.LicBtn.TabIndex = 234;
			this.bunifuToolTip1.SetToolTip(this.LicBtn, "Login Only with a License!");
			this.bunifuToolTip1.SetToolTipIcon(this.LicBtn, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.LicBtn, "HYDRA");
			this.LicBtn.Click += new System.EventHandler(LicBtn_Click);
			this.RgstrBtn.AllowAnimations = true;
			this.RgstrBtn.AllowBorderColorChanges = true;
			this.RgstrBtn.AllowMouseEffects = true;
			this.RgstrBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.RgstrBtn.AnimationSpeed = 200;
			this.RgstrBtn.BackColor = System.Drawing.Color.Transparent;
			this.RgstrBtn.BackgroundColor = System.Drawing.Color.Transparent;
			this.RgstrBtn.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.RgstrBtn.BorderRadius = 1;
			this.RgstrBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.RgstrBtn.BorderThickness = 1;
			this.RgstrBtn.ColorContrastOnClick = 30;
			this.RgstrBtn.ColorContrastOnHover = 30;
			this.RgstrBtn.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges5.BottomLeft = true;
			borderEdges5.BottomRight = true;
			borderEdges5.TopLeft = true;
			borderEdges5.TopRight = true;
			this.RgstrBtn.CustomizableEdges = borderEdges5;
			this.RgstrBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.RgstrBtn.Image = (System.Drawing.Image)resources.GetObject("RgstrBtn.Image");
			this.RgstrBtn.ImageMargin = new System.Windows.Forms.Padding(0);
			this.RgstrBtn.Location = new System.Drawing.Point(502, 218);
			this.RgstrBtn.Name = "RgstrBtn";
			this.RgstrBtn.RoundBorders = false;
			this.RgstrBtn.ShowBorders = true;
			this.RgstrBtn.Size = new System.Drawing.Size(35, 35);
			this.RgstrBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.RgstrBtn.TabIndex = 235;
			this.bunifuToolTip1.SetToolTip(this.RgstrBtn, "Register new user/key!");
			this.bunifuToolTip1.SetToolTipIcon(this.RgstrBtn, (System.Drawing.Image)resources.GetObject("RgstrBtn.ToolTipIcon"));
			this.bunifuToolTip1.SetToolTipTitle(this.RgstrBtn, "HYDRA");
			this.RgstrBtn.Click += new System.EventHandler(RgstrBtn_Click);
			this.UpgradeBtn.AllowAnimations = true;
			this.UpgradeBtn.AllowBorderColorChanges = true;
			this.UpgradeBtn.AllowMouseEffects = true;
			this.UpgradeBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.UpgradeBtn.AnimationSpeed = 200;
			this.UpgradeBtn.BackColor = System.Drawing.Color.Transparent;
			this.UpgradeBtn.BackgroundColor = System.Drawing.Color.Transparent;
			this.UpgradeBtn.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.UpgradeBtn.BorderRadius = 1;
			this.UpgradeBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.UpgradeBtn.BorderThickness = 1;
			this.UpgradeBtn.ColorContrastOnClick = 30;
			this.UpgradeBtn.ColorContrastOnHover = 30;
			this.UpgradeBtn.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges6.BottomLeft = true;
			borderEdges6.BottomRight = true;
			borderEdges6.TopLeft = true;
			borderEdges6.TopRight = true;
			this.UpgradeBtn.CustomizableEdges = borderEdges6;
			this.UpgradeBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.UpgradeBtn.Image = (System.Drawing.Image)resources.GetObject("UpgradeBtn.Image");
			this.UpgradeBtn.ImageMargin = new System.Windows.Forms.Padding(0);
			this.UpgradeBtn.Location = new System.Drawing.Point(420, 218);
			this.UpgradeBtn.Name = "UpgradeBtn";
			this.UpgradeBtn.RoundBorders = false;
			this.UpgradeBtn.ShowBorders = true;
			this.UpgradeBtn.Size = new System.Drawing.Size(35, 35);
			this.UpgradeBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.UpgradeBtn.TabIndex = 236;
			this.bunifuToolTip1.SetToolTip(this.UpgradeBtn, "Upgrade license!");
			this.bunifuToolTip1.SetToolTipIcon(this.UpgradeBtn, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.UpgradeBtn, "HYDRA");
			this.UpgradeBtn.Click += new System.EventHandler(UpgradeBtn_Click);
			this.bunifuToolTip1.Active = true;
			this.bunifuToolTip1.AlignTextWithTitle = false;
			this.bunifuToolTip1.AllowAutoClose = false;
			this.bunifuToolTip1.AllowFading = true;
			this.bunifuToolTip1.AutoCloseDuration = 5000;
			this.bunifuToolTip1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuToolTip1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuToolTip1.ClickToShowDisplayControl = false;
			this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
			this.bunifuToolTip1.DisplayControl = null;
			this.bunifuToolTip1.EntryAnimationSpeed = 350;
			this.bunifuToolTip1.ExitAnimationSpeed = 200;
			this.bunifuToolTip1.GenerateAutoCloseDuration = false;
			this.bunifuToolTip1.IconMargin = 6;
			this.bunifuToolTip1.InitialDelay = 0;
			this.bunifuToolTip1.Name = "bunifuToolTip1";
			this.bunifuToolTip1.Opacity = 1.0;
			this.bunifuToolTip1.OverrideToolTipTitles = false;
			this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
			this.bunifuToolTip1.ReshowDelay = 100;
			this.bunifuToolTip1.ShowAlways = true;
			this.bunifuToolTip1.ShowBorders = false;
			this.bunifuToolTip1.ShowIcons = true;
			this.bunifuToolTip1.ShowShadows = true;
			this.bunifuToolTip1.Tag = null;
			this.bunifuToolTip1.TextFont = new System.Drawing.Font("Century Gothic", 11.25f);
			this.bunifuToolTip1.TextForeColor = System.Drawing.Color.White;
			this.bunifuToolTip1.TextMargin = 2;
			this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Silver;
			this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
			this.bunifuToolTip1.ToolTipTitle = "HYDRA";
			this.webControl1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.webControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webControl1.Location = new System.Drawing.Point(0, 0);
			this.webControl1.Name = "webControl1";
			this.webControl1.Size = new System.Drawing.Size(696, 340);
			this.webControl1.TabIndex = 237;
			this.webControl1.Text = "webControl1";
			this.bunifuToolTip1.SetToolTip(this.webControl1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.webControl1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.webControl1, "");
			this.webControl1.WebView = this.webView1;
			this.webControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			this.webView1.InputMsgFilter = null;
			this.webView1.ObjectForScripting = null;
			this.webView1.Title = null;
			this.webView1.Url = ZEDRatApp.Forms.Forma.index;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(10f, 21f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(696, 340);
			base.Controls.Add(this.UpgradeBtn);
			base.Controls.Add(this.RgstrBtn);
			base.Controls.Add(this.LicBtn);
			base.Controls.Add(this.LoginBtn);
			base.Controls.Add(this.chkSave);
			base.Controls.Add(this.bunifuIconButton1);
			base.Controls.Add(this.key);
			base.Controls.Add(this.password);
			base.Controls.Add(this.username);
			base.Controls.Add(this.btnLogout);
			base.Controls.Add(this.status);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.customLabel2);
			base.Controls.Add(this.customLabel1);
			base.Controls.Add(this.bunifuSeparator4);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuSeparator3);
			base.Controls.Add(this.webControl1);
			this.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(5);
			base.Name = "Forma";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HYDRA LOGIN";
			base.Load += new System.EventHandler(Forma_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		static Forma()
		{
			Forma.ee = Application.ExecutablePath.Replace("Hydra.exe", "Index.html");
			Forma.index = "file:///" + Application.StartupPath + "//Index.html";
			Forma.name = "demoapp";
			Forma.Hydraid = "rZsbifQeLf";
			Forma.Hydramystic = "9054b01a394c8ea7c6e650f7e5d762eaff6955e728be1cdacd6189332942a5bf";
			Forma.version = "1.0";
			Forma.trance = new Phychedelic(Forma.name, Forma.Hydraid, Forma.Hydramystic, Forma.version);
		}
	}
}

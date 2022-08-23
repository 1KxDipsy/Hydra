using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using ns1;
using ns2;
using ZEDRatApp.ZEDRAT.Module;
using ComboBox = ns2.ComboBox;
using TextBox = ns2.TextBox;

namespace ZEDRatApp.Forms.Remote_Startup_Dialog
{
	public class frmAddStartup : Form
	{
		private IContainer components;

		private SiticoneElipse siticoneElipse1;

		private SiticoneGroupBox groupBox1;

		private SiticoneLabel siticoneLabel3;

		private SiticoneLabel siticoneLabel2;

		private SiticoneLabel siticoneLabel1;

		private SiticoneRoundedComboBox cmbType;

		private SiticoneRoundedTextBox txtPath;

		private SiticoneRoundedTextBox txtName;

		private SiticoneRoundedButton siticoneRoundedButton1;

		private SiticoneRoundedButton btnBuild;

		private SiticoneLabel siticoneLabel12;

		private Guna2ControlBox guna2ControlBox1;

		private BunifuSeparator bunifuSeparator2;

		public frmAddStartup()
		{
			this.InitializeComponent();
			this.AddTypes();
		}

		public frmAddStartup(string startupPath)
		{
			this.InitializeComponent();
			this.AddTypes();
			((TextBox)this.txtName).Text = Path.GetFileNameWithoutExtension(startupPath);
			((TextBox)this.txtPath).Text = startupPath;
		}

		private void AddTypes()
		{
			((ComboBox)(object)this.cmbType).Items.Add("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
			((ComboBox)(object)this.cmbType).Items.Add("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce");
			((ComboBox)(object)this.cmbType).Items.Add("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
			((ComboBox)(object)this.cmbType).Items.Add("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce");
			((ComboBox)(object)this.cmbType).Items.Add("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run");
			((ComboBox)(object)this.cmbType).Items.Add("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\RunOnce");
			((ComboBox)(object)this.cmbType).Items.Add("%APPDATA%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
			((ListControl)(object)this.cmbType).SelectedIndex = 0;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			AutoStartItem.Name = ((TextBox)this.txtName).Text;
			AutoStartItem.Path = ((TextBox)this.txtPath).Text;
			AutoStartItem.Type = ((ListControl)(object)this.cmbType).SelectedIndex;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		private void txtName_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = (e.KeyChar == '\\' || frmAddStartup.CheckPathForIllegalChars(e.KeyChar.ToString())) && !char.IsControl(e.KeyChar);
		}

		private void txtPath_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = (e.KeyChar == '\\' || frmAddStartup.CheckPathForIllegalChars(e.KeyChar.ToString())) && !char.IsControl(e.KeyChar);
		}

		public static bool CheckPathForIllegalChars(string path)
		{
			return path.Any((char c) => Path.GetInvalidPathChars().Union(Path.GetInvalidFileNameChars()).ToArray()
				.Contains(c));
		}

		private void siticoneGradientCircleButton1_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_Startup_Dialog.frmAddStartup));
			this.siticoneElipse1 = new SiticoneElipse(this.components);
			this.groupBox1 = new SiticoneGroupBox();
			this.siticoneRoundedButton1 = new SiticoneRoundedButton();
			this.btnBuild = new SiticoneRoundedButton();
			this.txtPath = new SiticoneRoundedTextBox();
			this.txtName = new SiticoneRoundedTextBox();
			this.cmbType = new SiticoneRoundedComboBox();
			this.siticoneLabel3 = new SiticoneLabel();
			this.siticoneLabel2 = new SiticoneLabel();
			this.siticoneLabel1 = new SiticoneLabel();
			this.siticoneLabel12 = new SiticoneLabel();
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			((System.Windows.Forms.Control)(object)this.groupBox1).SuspendLayout();
			base.SuspendLayout();
			this.siticoneElipse1.BorderRadius = 0;
			this.siticoneElipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.groupBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.btnBuild);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.txtPath);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.txtName);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.cmbType);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel3);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel2);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel1);
			this.groupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.groupBox1.FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.groupBox1).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.groupBox1).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.groupBox1).Location = new System.Drawing.Point(12, 71);
			((System.Windows.Forms.Control)(object)this.groupBox1).Name = "groupBox1";
			this.groupBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.groupBox1;
			((System.Windows.Forms.Control)(object)this.groupBox1).Size = new System.Drawing.Size(812, 224);
			((System.Windows.Forms.Control)(object)this.groupBox1).TabIndex = 42;
			((System.Windows.Forms.Control)(object)this.groupBox1).Text = "Automatic Startup";
			((SiticoneButton)this.siticoneRoundedButton1).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.siticoneRoundedButton1).BorderThickness = 1;
			((SiticoneButton)this.siticoneRoundedButton1).CheckedState.Parent = (CustomButtonBase)(object)this.siticoneRoundedButton1;
			((SiticoneButton)this.siticoneRoundedButton1).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.siticoneRoundedButton1).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			((SiticoneButton)this.siticoneRoundedButton1).CustomImages.Parent = (CustomButtonBase)(object)this.siticoneRoundedButton1;
			((SiticoneButton)this.siticoneRoundedButton1).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1).ForeColor = System.Drawing.Color.White;
			((SiticoneButton)this.siticoneRoundedButton1).HoveredState.Parent = (CustomButtonBase)(object)this.siticoneRoundedButton1;
			((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1).Location = new System.Drawing.Point(581, 187);
			((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1).Name = "siticoneRoundedButton1";
			((SiticoneButton)this.siticoneRoundedButton1).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneRoundedButton1;
			((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1).Size = new System.Drawing.Size(140, 23);
			((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1).TabIndex = 27;
			((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1).Text = "Cancel";
			((System.Windows.Forms.Control)(object)this.siticoneRoundedButton1).Click += new System.EventHandler(btnCancel_Click);
			((SiticoneButton)this.btnBuild).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnBuild).BorderThickness = 1;
			((SiticoneButton)this.btnBuild).CheckedState.Parent = (CustomButtonBase)(object)this.btnBuild;
			((SiticoneButton)this.btnBuild).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnBuild).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			((SiticoneButton)this.btnBuild).CustomImages.Parent = (CustomButtonBase)(object)this.btnBuild;
			((SiticoneButton)this.btnBuild).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnBuild).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnBuild).ForeColor = System.Drawing.Color.White;
			((SiticoneButton)this.btnBuild).HoveredState.Parent = (CustomButtonBase)(object)this.btnBuild;
			((System.Windows.Forms.Control)(object)this.btnBuild).Location = new System.Drawing.Point(122, 187);
			((System.Windows.Forms.Control)(object)this.btnBuild).Name = "btnBuild";
			((SiticoneButton)this.btnBuild).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnBuild;
			((System.Windows.Forms.Control)(object)this.btnBuild).Size = new System.Drawing.Size(140, 23);
			((System.Windows.Forms.Control)(object)this.btnBuild).TabIndex = 26;
			((System.Windows.Forms.Control)(object)this.btnBuild).Text = "Add";
			((System.Windows.Forms.Control)(object)this.btnBuild).Click += new System.EventHandler(btnAdd_Click);
			((System.Windows.Forms.Control)(object)this.txtPath).BackColor = System.Drawing.Color.Transparent;
			((SiticoneTextBox)this.txtPath).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtPath).Cursor = System.Windows.Forms.Cursors.IBeam;
			((TextBox)this.txtPath).DefaultText = "";
			((SiticoneTextBox)this.txtPath).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			((SiticoneTextBox)this.txtPath).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			((SiticoneTextBox)this.txtPath).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtPath).DisabledState.Parent = (TextBox)(object)this.txtPath;
			((SiticoneTextBox)this.txtPath).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtPath).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneTextBox)this.txtPath).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtPath).FocusedState.Parent = (TextBox)(object)this.txtPath;
			((SiticoneTextBox)this.txtPath).HoveredState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtPath).HoveredState.Parent = (TextBox)(object)this.txtPath;
			((System.Windows.Forms.Control)(object)this.txtPath).Location = new System.Drawing.Point(122, 94);
			((System.Windows.Forms.Control)(object)this.txtPath).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			((System.Windows.Forms.Control)(object)this.txtPath).Name = "txtPath";
			((TextBox)this.txtPath).PasswordChar = '\0';
			((SiticoneTextBox)this.txtPath).PlaceholderText = "";
			((TextBox)this.txtPath).SelectedText = "";
			((SiticoneTextBox)this.txtPath).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtPath;
			((System.Windows.Forms.Control)(object)this.txtPath).Size = new System.Drawing.Size(599, 28);
			((System.Windows.Forms.Control)(object)this.txtPath).TabIndex = 25;
			((System.Windows.Forms.Control)(object)this.txtName).BackColor = System.Drawing.Color.Transparent;
			((SiticoneTextBox)this.txtName).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtName).Cursor = System.Windows.Forms.Cursors.IBeam;
			((TextBox)this.txtName).DefaultText = "";
			((SiticoneTextBox)this.txtName).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			((SiticoneTextBox)this.txtName).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			((SiticoneTextBox)this.txtName).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtName).DisabledState.Parent = (TextBox)(object)this.txtName;
			((SiticoneTextBox)this.txtName).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtName).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneTextBox)this.txtName).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtName).FocusedState.Parent = (TextBox)(object)this.txtName;
			((SiticoneTextBox)this.txtName).HoveredState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtName).HoveredState.Parent = (TextBox)(object)this.txtName;
			((System.Windows.Forms.Control)(object)this.txtName).Location = new System.Drawing.Point(122, 61);
			((System.Windows.Forms.Control)(object)this.txtName).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			((System.Windows.Forms.Control)(object)this.txtName).Name = "txtName";
			((TextBox)this.txtName).PasswordChar = '\0';
			((SiticoneTextBox)this.txtName).PlaceholderText = "";
			((TextBox)this.txtName).SelectedText = "";
			((SiticoneTextBox)this.txtName).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtName;
			((System.Windows.Forms.Control)(object)this.txtName).Size = new System.Drawing.Size(599, 28);
			((System.Windows.Forms.Control)(object)this.txtName).TabIndex = 24;
			((System.Windows.Forms.Control)(object)this.cmbType).BackColor = System.Drawing.Color.Transparent;
			((SiticoneComboBox)this.cmbType).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.ComboBox)(object)this.cmbType).DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			((System.Windows.Forms.ComboBox)(object)this.cmbType).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			((SiticoneComboBox)this.cmbType).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneComboBox)this.cmbType).FocusedColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.cmbType).Font = new System.Drawing.Font("Century Gothic", 8f);
			((System.Windows.Forms.Control)(object)this.cmbType).ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.ListControl)(object)this.cmbType).FormattingEnabled = true;
			((SiticoneComboBox)this.cmbType).HoveredState.Parent = (ComboBox)(object)this.cmbType;
			((System.Windows.Forms.ComboBox)(object)this.cmbType).ItemHeight = 30;
			((System.Windows.Forms.ComboBox)(object)this.cmbType).Items.AddRange(new object[3] { "AppData", "Programs Files", "System" });
			((SiticoneComboBox)this.cmbType).ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneComboBox)this.cmbType).ItemsAppearance.Font = new System.Drawing.Font("Century Gothic", 8f);
			((SiticoneComboBox)this.cmbType).ItemsAppearance.ForeColor = System.Drawing.Color.White;
			((SiticoneComboBox)this.cmbType).ItemsAppearance.Parent = (ComboBox)(object)this.cmbType;
			((SiticoneComboBox)this.cmbType).ItemsAppearance.SelectedBackColor = System.Drawing.Color.Gray;
			((SiticoneComboBox)this.cmbType).ItemsAppearance.SelectedFont = new System.Drawing.Font("Century Gothic", 8f);
			((SiticoneComboBox)this.cmbType).ItemsAppearance.SelectedForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.cmbType).Location = new System.Drawing.Point(122, 128);
			((System.Windows.Forms.Control)(object)this.cmbType).Name = "cmbType";
			((SiticoneComboBox)this.cmbType).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.cmbType;
			((System.Windows.Forms.Control)(object)this.cmbType).Size = new System.Drawing.Size(599, 36);
			((System.Windows.Forms.Control)(object)this.cmbType).TabIndex = 13;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel3.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Location = new System.Drawing.Point(68, 144);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Name = "siticoneLabel3";
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Size = new System.Drawing.Size(36, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).TabIndex = 2;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Text = "Type:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel2.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Location = new System.Drawing.Point(68, 107);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Name = "siticoneLabel2";
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Size = new System.Drawing.Size(33, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).TabIndex = 1;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Text = "Path:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel1.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Location = new System.Drawing.Point(68, 74);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Name = "siticoneLabel1";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Size = new System.Drawing.Size(40, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).TabIndex = 0;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Text = "Name:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Location = new System.Drawing.Point(356, 12);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Name = "siticoneLabel12";
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Size = new System.Drawing.Size(126, 20);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).TabIndex = 44;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Text = "Add To Startup";
			this.guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox1.BorderRadius = 12;
			this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox1.Location = new System.Drawing.Point(779, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			this.guna2ControlBox1.TabIndex = 55;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-1, 51);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(839, 10);
			this.bunifuSeparator2.TabIndex = 91;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(836, 298);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.guna2ControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmAddStartup";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add to autostart";
			((System.Windows.Forms.Control)(object)this.groupBox1).ResumeLayout(false);
			((System.Windows.Forms.Control)(object)this.groupBox1).PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;

using ZEDRatApp.ZEDRAT.Module;
using TextBox = Guna.UI2.WinForms.Guna2TextBox;

namespace ZEDRatApp.Forms.Remote_Startup_Dialog
{
	public class frmAddStartup : Form
	{
		private IContainer components;

		private Guna2Elipse Guna2Elipse1;

		private Guna2GroupBox groupBox1;

		private Guna2HtmlLabel Guna2HtmlLabel3;

		private Guna2HtmlLabel Guna2HtmlLabel;

		private Guna2HtmlLabel Guna2HtmlLabel1;

		private Guna2ComboBox cmbType;

		private Guna2TextBox txtPath;

		private Guna2TextBox txtName;

		private Guna2Button Guna2Button1;

		private Guna2Button btnBuild;

		private Guna2HtmlLabel Guna2HtmlLabel12;

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
			(this.txtName).Text = Path.GetFileNameWithoutExtension(startupPath);
			(this.txtPath).Text = startupPath;
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
			AutoStartItem.Name = (this.txtName).Text;
			AutoStartItem.Path = (this.txtPath).Text;
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
			this.Guna2Elipse1 = new Guna2Elipse(this.components);
			this.groupBox1 = new Guna2GroupBox();
			this.Guna2Button1 = new Guna2Button();
			this.btnBuild = new Guna2Button();
			this.txtPath = new Guna2TextBox();
			this.txtName = new Guna2TextBox();
			this.cmbType = new Guna2ComboBox();
			this.Guna2HtmlLabel3 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel = new Guna2HtmlLabel();
			this.Guna2HtmlLabel1 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			((System.Windows.Forms.Control)(object)this.groupBox1).SuspendLayout();
			base.SuspendLayout();
			this.Guna2Elipse1.BorderRadius = 0;
			this.Guna2Elipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.groupBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2Button1);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.btnBuild);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.txtPath);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.txtName);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.cmbType);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1);
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
			(this.Guna2Button1).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.Guna2Button1).BorderThickness = 1;
			(this.Guna2Button1).CheckedState.Parent = this.Guna2Button1;
			(this.Guna2Button1).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.Guna2Button1).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.Guna2Button1).CustomImages.Parent = this.Guna2Button1;
			(this.Guna2Button1).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.Guna2Button1).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Location = new System.Drawing.Point(581, 187);
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Name = "Guna2Button1";
			(this.Guna2Button1).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2Button1;
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Size = new System.Drawing.Size(140, 23);
			((System.Windows.Forms.Control)(object)this.Guna2Button1).TabIndex = 27;
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Text = "Cancel";
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Click += new System.EventHandler(btnCancel_Click);
			(this.btnBuild).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).BorderThickness = 1;
			(this.btnBuild).CheckedState.Parent = this.btnBuild;
			(this.btnBuild).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnBuild).CustomImages.Parent = this.btnBuild;
			(this.btnBuild).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnBuild).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnBuild).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnBuild).Location = new System.Drawing.Point(122, 187);
			((System.Windows.Forms.Control)(object)this.btnBuild).Name = "btnBuild";
			(this.btnBuild).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnBuild;
			((System.Windows.Forms.Control)(object)this.btnBuild).Size = new System.Drawing.Size(140, 23);
			((System.Windows.Forms.Control)(object)this.btnBuild).TabIndex = 26;
			((System.Windows.Forms.Control)(object)this.btnBuild).Text = "Add";
			((System.Windows.Forms.Control)(object)this.btnBuild).Click += new System.EventHandler(btnAdd_Click);
			((System.Windows.Forms.Control)(object)this.txtPath).BackColor = System.Drawing.Color.Transparent;
			(this.txtPath).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtPath).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtPath).DefaultText = "";
			(this.txtPath).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtPath).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtPath).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtPath).DisabledState.Parent = this.txtPath;
			(this.txtPath).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtPath).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtPath).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtPath).FocusedState.Parent = this.txtPath;
			((System.Windows.Forms.Control)(object)this.txtPath).Location = new System.Drawing.Point(122, 94);
			((System.Windows.Forms.Control)(object)this.txtPath).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			((System.Windows.Forms.Control)(object)this.txtPath).Name = "txtPath";
			(this.txtPath).PasswordChar = '\0';
			(this.txtPath).PlaceholderText = "";
			(this.txtPath).SelectedText = "";
			(this.txtPath).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtPath;
			((System.Windows.Forms.Control)(object)this.txtPath).Size = new System.Drawing.Size(599, 28);
			((System.Windows.Forms.Control)(object)this.txtPath).TabIndex = 25;
			((System.Windows.Forms.Control)(object)this.txtName).BackColor = System.Drawing.Color.Transparent;
			(this.txtName).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtName).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtName).DefaultText = "";
			(this.txtName).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtName).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtName).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtName).DisabledState.Parent = this.txtName;
			(this.txtName).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtName).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtName).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtName).FocusedState.Parent = this.txtName;
			((System.Windows.Forms.Control)(object)this.txtName).Location = new System.Drawing.Point(122, 61);
			((System.Windows.Forms.Control)(object)this.txtName).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			((System.Windows.Forms.Control)(object)this.txtName).Name = "txtName";
			(this.txtName).PasswordChar = '\0';
			(this.txtName).PlaceholderText = "";
			(this.txtName).SelectedText = "";
			(this.txtName).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtName;
			((System.Windows.Forms.Control)(object)this.txtName).Size = new System.Drawing.Size(599, 28);
			((System.Windows.Forms.Control)(object)this.txtName).TabIndex = 24;
			((System.Windows.Forms.Control)(object)this.cmbType).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.ComboBox)(object)this.cmbType).DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			((System.Windows.Forms.ComboBox)(object)this.cmbType).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			((System.Windows.Forms.Control)(object)this.cmbType).Font = new System.Drawing.Font("Century Gothic", 8f);
			((System.Windows.Forms.Control)(object)this.cmbType).ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.ListControl)(object)this.cmbType).FormattingEnabled = true;
			((System.Windows.Forms.ComboBox)(object)this.cmbType).ItemHeight = 30;
			((System.Windows.Forms.ComboBox)(object)this.cmbType).Items.AddRange(new object[3] { "AppData", "Programs Files", "System" });
			((System.Windows.Forms.Control)(object)this.cmbType).Location = new System.Drawing.Point(122, 128);
			((System.Windows.Forms.Control)(object)this.cmbType).Name = "cmbType";
			((System.Windows.Forms.Control)(object)this.cmbType).Size = new System.Drawing.Size(599, 36);
			((System.Windows.Forms.Control)(object)this.cmbType).TabIndex = 13;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Location = new System.Drawing.Point(68, 144);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Name = "Guna2HtmlLabel3";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Size = new System.Drawing.Size(36, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).TabIndex = 2;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Text = "Type:";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Location = new System.Drawing.Point(68, 107);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Name = "Guna2HtmlLabel";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Size = new System.Drawing.Size(33, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).TabIndex = 1;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Text = "Path:";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Location = new System.Drawing.Point(68, 74);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Name = "Guna2HtmlLabel1";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Size = new System.Drawing.Size(40, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).TabIndex = 0;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Text = "Name:";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(356, 12);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(126, 20);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 44;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "Add To Startup";
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
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
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

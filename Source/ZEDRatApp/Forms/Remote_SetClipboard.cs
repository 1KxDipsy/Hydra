using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using Siticone.Desktop.UI.WinForms;

using TextBox = System.Windows.Forms.TextBox;

namespace ZEDRatApp.Forms
{
	public class Remote_SetClipboard : Form
	{
		internal Remote_Desk rmDesktop;

		private IContainer components;

		private TextBox txtClipboard;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private SiticoneRoundedButton btnSetClipboard;

		private SiticoneControlBox siticoneControlBox1;

		private Guna2Elipse guna2Elipse1;

		private SiticoneHtmlLabel SiticoneHtmlLabel12;

		private BunifuSeparator bunifuSeparator1;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_SetClipboard(Remote_Desk RemoteDesktop)
		{
			this.InitializeComponent();
			this.rmDesktop = this.rmDesktop;
		}

		private void btnSetClipboard_Click(object sender, EventArgs e)
		{
			string text = null;
			string strClipboard = this.txtClipboard.Text;
			this.rmDesktop.SendClipboard(strClipboard);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_SetClipboard));
			this.txtClipboard = new System.Windows.Forms.TextBox();
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.btnSetClipboard = new SiticoneRoundedButton();
			this.siticoneControlBox1 = new SiticoneControlBox();
			this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
			this.SiticoneHtmlLabel12 = new SiticoneHtmlLabel();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.txtClipboard.BackColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.txtClipboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtClipboard.ForeColor = System.Drawing.Color.White;
			this.txtClipboard.Location = new System.Drawing.Point(47, 109);
			this.txtClipboard.Multiline = true;
			this.txtClipboard.Name = "txtClipboard";
			this.txtClipboard.Size = new System.Drawing.Size(550, 80);
			this.txtClipboard.TabIndex = 1;
			this.guna2BorderlessForm1.ContainerControl = this;
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			(this.btnSetClipboard).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnSetClipboard).BorderThickness = 1;
			(this.btnSetClipboard).CheckedState.Parent = this.btnSetClipboard;
			(this.btnSetClipboard).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnSetClipboard).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnSetClipboard).CustomImages.Parent = this.btnSetClipboard;
			(this.btnSetClipboard).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).Location = new System.Drawing.Point(236, 195);
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).Name = "btnSetClipboard";
			(this.btnSetClipboard).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnSetClipboard;
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).Size = new System.Drawing.Size(167, 36);
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).TabIndex = 24;
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).Text = "Set Clipboard";
			((System.Windows.Forms.Control)(object)this.btnSetClipboard).Click += new System.EventHandler(btnSetClipboard_Click);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).BackColor = System.Drawing.Color.Transparent;
			this.siticoneControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.siticoneControlBox1.BorderRadius = 12;
			this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.siticoneControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Location = new System.Drawing.Point(568, 12);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Name = "siticoneControlBox1";
			this.siticoneControlBox1.PressedColor = System.Drawing.Color.Red;
			this.siticoneControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneControlBox1;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).TabIndex = 26;
			this.guna2Elipse1.BorderRadius = 40;
			this.guna2Elipse1.TargetControl = this.txtClipboard;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.SiticoneHtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.SiticoneHtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Location = new System.Drawing.Point(249, 19);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Name = "SiticoneHtmlLabel12";
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Size = new System.Drawing.Size(110, 23);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).TabIndex = 56;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Text = "Set Clipboard";
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(-1, 52);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(627, 9);
			this.bunifuSeparator1.TabIndex = 57;
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
			this.CloseBtn.Location = new System.Drawing.Point(12, 12);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.RoundBorders = false;
			this.CloseBtn.ShowBorders = true;
			this.CloseBtn.Size = new System.Drawing.Size(35, 35);
			this.CloseBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.CloseBtn.TabIndex = 170;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(625, 243);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnSetClipboard);
			base.Controls.Add(this.txtClipboard);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Remote_SetClipboard";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remote_SetClipboard";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

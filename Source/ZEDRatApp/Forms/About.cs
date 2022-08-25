using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Siticone.Desktop.UI.WinForms;

namespace ZEDRatApp.Forms
{
	public class About : Form
	{
		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ControlBox guna2ControlBox3;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2ControlBox guna2ControlBox1;

		private SiticoneHtmlLabel SiticoneHtmlLabel12;

		private BunifuSeparator bunifuSeparator2;

		private Guna2PictureBox guna2PictureBox1;

		public About()
		{
			this.InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.About));
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.SiticoneHtmlLabel12 = new SiticoneHtmlLabel();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).BeginInit();
			base.SuspendLayout();
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2ControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox3.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox3.BorderRadius = 12;
			this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			this.guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox3.HoverState.Parent = this.guna2ControlBox3;
			this.guna2ControlBox3.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox3.Location = new System.Drawing.Point(641, 12);
			this.guna2ControlBox3.Name = "guna2ControlBox3";
			this.guna2ControlBox3.ShadowDecoration.Parent = this.guna2ControlBox3;
			this.guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
			this.guna2ControlBox3.TabIndex = 55;
			this.guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox2.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox2.BorderRadius = 12;
			this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
			this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
			this.guna2ControlBox2.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox2.Location = new System.Drawing.Point(692, 12);
			this.guna2ControlBox2.Name = "guna2ControlBox2";
			this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
			this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
			this.guna2ControlBox2.TabIndex = 54;
			this.guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox1.BorderRadius = 12;
			this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox1.Location = new System.Drawing.Point(743, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			this.guna2ControlBox1.TabIndex = 53;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.SiticoneHtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.SiticoneHtmlLabel12.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Location = new System.Drawing.Point(375, 21);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Name = "SiticoneHtmlLabel12";
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Size = new System.Drawing.Size(50, 21);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).TabIndex = 89;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Text = "About";
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-1, 55);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(800, 10);
			this.bunifuSeparator2.TabIndex = 90;
			this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			this.guna2PictureBox1.ImageRotate = 0f;
			this.guna2PictureBox1.Location = new System.Drawing.Point(0, 61);
			this.guna2PictureBox1.Name = "guna2PictureBox1";
			this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
			this.guna2PictureBox1.Size = new System.Drawing.Size(800, 430);
			this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.guna2PictureBox1.TabIndex = 91;
			this.guna2PictureBox1.TabStop = false;
			this.guna2PictureBox1.UseTransparentBackground = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(800, 491);
			base.Controls.Add(this.guna2PictureBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.guna2ControlBox3);
			base.Controls.Add(this.guna2ControlBox2);
			base.Controls.Add(this.guna2ControlBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "About";
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

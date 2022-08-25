using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;

namespace ZEDRatApp.Forms
{
	public class Help : Form
	{
		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Label label1;

		private BunifuIconButton bunifuIconButton2;

		private BunifuIconButton bunifuIconButton29;

		private MetroSetControlBox metroSetControlBox1;

		public Help()
		{
			this.InitializeComponent();
		}

		private void bunifuIconButton29_Click(object sender, EventArgs e)
		{
			Process.Start("https://t.me/HydraSupportChannel");
		}

		private void bunifuIconButton2_Click(object sender, EventArgs e)
		{
			Process.Start("https://shophydra.sellix.io/");
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
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Help));
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.bunifuIconButton29 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
			base.SuspendLayout();
			this.guna2BorderlessForm1.ContainerControl = this;
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label1.Location = new System.Drawing.Point(57, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(833, 323);
			this.label1.TabIndex = 283;
			this.label1.Text = resources.GetString("label1.Text");
			this.bunifuIconButton29.AllowAnimations = true;
			this.bunifuIconButton29.AllowBorderColorChanges = true;
			this.bunifuIconButton29.AllowMouseEffects = true;
			this.bunifuIconButton29.AnimationSpeed = 200;
			this.bunifuIconButton29.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton29.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton29.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton29.BorderRadius = 1;
			this.bunifuIconButton29.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton29.BorderThickness = 1;
			this.bunifuIconButton29.ColorContrastOnClick = 30;
			this.bunifuIconButton29.ColorContrastOnHover = 30;
			this.bunifuIconButton29.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.bunifuIconButton29.CustomizableEdges = borderEdges;
			this.bunifuIconButton29.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton29.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton29.Image");
			this.bunifuIconButton29.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton29.Location = new System.Drawing.Point(60, 375);
			this.bunifuIconButton29.Name = "bunifuIconButton29";
			this.bunifuIconButton29.RoundBorders = false;
			this.bunifuIconButton29.ShowBorders = true;
			this.bunifuIconButton29.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton29.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton29.TabIndex = 302;
			this.bunifuIconButton29.Click += new System.EventHandler(bunifuIconButton29_Click);
			this.bunifuIconButton2.AllowAnimations = true;
			this.bunifuIconButton2.AllowBorderColorChanges = true;
			this.bunifuIconButton2.AllowMouseEffects = true;
			this.bunifuIconButton2.AnimationSpeed = 200;
			this.bunifuIconButton2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton2.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton2.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton2.BorderRadius = 1;
			this.bunifuIconButton2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton2.BorderThickness = 1;
			this.bunifuIconButton2.ColorContrastOnClick = 30;
			this.bunifuIconButton2.ColorContrastOnHover = 30;
			this.bunifuIconButton2.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.bunifuIconButton2.CustomizableEdges = borderEdges2;
			this.bunifuIconButton2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton2.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton2.Image");
			this.bunifuIconButton2.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton2.Location = new System.Drawing.Point(104, 375);
			this.bunifuIconButton2.Name = "bunifuIconButton2";
			this.bunifuIconButton2.RoundBorders = false;
			this.bunifuIconButton2.ShowBorders = true;
			this.bunifuIconButton2.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton2.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton2.TabIndex = 304;
			this.bunifuIconButton2.Click += new System.EventHandler(bunifuIconButton2_Click);
			this.metroSetControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.IsDerivedStyle = true;
			this.metroSetControlBox1.Location = new System.Drawing.Point(843, 2);
			this.metroSetControlBox1.MaximizeBox = true;
			this.metroSetControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.MaximizeHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.MaximizeNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.MinimizeBox = true;
			this.metroSetControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.MinimizeHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.MinimizeNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.Name = "metroSetControlBox1";
			this.metroSetControlBox1.Size = new System.Drawing.Size(100, 25);
			this.metroSetControlBox1.Style = MetroSet_UI.Enums.Style.Custom;
			this.metroSetControlBox1.StyleManager = null;
			this.metroSetControlBox1.TabIndex = 305;
			this.metroSetControlBox1.Text = "metroSetControlBox1";
			this.metroSetControlBox1.ThemeAuthor = "Narwin";
			this.metroSetControlBox1.ThemeName = "MetroLite";
			base.AutoScaleDimensions = new System.Drawing.SizeF(10f, 21f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(946, 442);
			base.Controls.Add(this.metroSetControlBox1);
			base.Controls.Add(this.bunifuIconButton2);
			base.Controls.Add(this.bunifuIconButton29);
			base.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.MaximumSize = new System.Drawing.Size(946, 442);
			this.MinimumSize = new System.Drawing.Size(946, 442);
			base.Name = "Help";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Help";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

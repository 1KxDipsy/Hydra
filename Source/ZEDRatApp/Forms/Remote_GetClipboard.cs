using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;

using ns2;
using ns1;
using ns2;
namespace ZEDRatApp.Forms
{
	public class Remote_GetClipboard : Form
	{
		private string m_strPrevClipboard = "";

		private IContainer components;

		private ListView lvClipboard;

		private ColumnHeader colClipboardNo;

		private ColumnHeader colClipboardDate;

		private ColumnHeader colClipboardText;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private SiticoneControlBox siticoneControlBox1;

		private SiticoneLabel siticoneLabel12;

		private BunifuSeparator bunifuSeparator1;

		private BunifuIconButton CloseBtn;

		private Guna2ShadowForm guna2ShadowForm1;

		public Remote_GetClipboard()
		{
			this.InitializeComponent();
		}

		public bool IsOldClipboard(string strClipboard)
		{
			if (this.m_strPrevClipboard.Equals(strClipboard))
			{
				return true;
			}
			return false;
		}

		public void AddClipboard(string strClipboard)
		{
			DateTime date = DateTime.UtcNow.Date;
			ListViewItem value = new ListViewItem(new string[3]
			{
				(this.lvClipboard.Items.Count + 1).ToString(),
				date.ToString("yyyy-MM-dd hh:mm:ss"),
				strClipboard
			});
			this.lvClipboard.Items.Add(value);
			this.m_strPrevClipboard = strClipboard;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZEDRatApp.Forms.Remote_GetClipboard));
			this.lvClipboard = new System.Windows.Forms.ListView();
			this.colClipboardNo = new System.Windows.Forms.ColumnHeader();
			this.colClipboardDate = new System.Windows.Forms.ColumnHeader();
			this.colClipboardText = new System.Windows.Forms.ColumnHeader();
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.siticoneControlBox1 = new SiticoneControlBox();
			this.siticoneLabel12 = new SiticoneLabel();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.CloseBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.lvClipboard.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.lvClipboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvClipboard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.colClipboardNo, this.colClipboardDate, this.colClipboardText });
			this.lvClipboard.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lvClipboard.HideSelection = false;
			this.lvClipboard.Location = new System.Drawing.Point(10, 113);
			this.lvClipboard.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.lvClipboard.Name = "lvClipboard";
			this.lvClipboard.Size = new System.Drawing.Size(810, 486);
			this.lvClipboard.TabIndex = 0;
			this.lvClipboard.UseCompatibleStateImageBehavior = false;
			this.lvClipboard.View = System.Windows.Forms.View.Details;
			this.colClipboardNo.Text = "No";
			this.colClipboardNo.Width = 50;
			this.colClipboardDate.Text = "Date";
			this.colClipboardDate.Width = 110;
			this.colClipboardText.Text = "Clipboard Text";
			this.colClipboardText.Width = 350;
			this.guna2BorderlessForm1.ContainerControl = this;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.siticoneControlBox1.BorderColor = System.Drawing.Color.DarkGray;
			this.siticoneControlBox1.BorderRadius = 12;
			this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.siticoneControlBox1.HoveredState.Parent = (ControlBox)(object)this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Location = new System.Drawing.Point(737, 19);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Name = "siticoneControlBox1";
			this.siticoneControlBox1.PressedColor = System.Drawing.Color.Red;
			this.siticoneControlBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneControlBox1;
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).Size = new System.Drawing.Size(75, 47);
			((System.Windows.Forms.Control)(object)this.siticoneControlBox1).TabIndex = 4;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Location = new System.Drawing.Point(308, 31);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Name = "siticoneLabel12";
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Size = new System.Drawing.Size(193, 37);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).TabIndex = 54;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Text = "Get Clipboard";
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.DimGray;
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(3, 89);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(827, 16);
			this.bunifuSeparator1.TabIndex = 55;
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
			this.CloseBtn.Location = new System.Drawing.Point(20, 19);
			this.CloseBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.RoundBorders = false;
			this.CloseBtn.ShowBorders = true;
			this.CloseBtn.Size = new System.Drawing.Size(58, 57);
			this.CloseBtn.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.CloseBtn.TabIndex = 169;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(10f, 21f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(832, 611);
			base.Controls.Add(this.CloseBtn);
			base.Controls.Add(this.bunifuSeparator1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel12);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneControlBox1);
			base.Controls.Add(this.lvClipboard);
			this.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			base.MaximizeBox = false;
			base.Name = "Remote_GetClipboard";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Get clipboard";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

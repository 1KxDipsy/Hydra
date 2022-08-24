using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns1;
using ns5;

namespace ns8
{
	public class LMessageBox : Form
	{
		public delegate void ButtonClick();

		public delegate void LinkLabelClick();

		public ButtonClick buttonClick;

		public LinkLabelClick linkLabelClick;

		private IContainer icontainer_0 = null;

		private SiticonePanel siticonePanel1;

		private LinkLabel linkLabel1;

		private SiticoneLabel siticoneLabel2;

		private SiticoneLabel siticoneLabel1;

		private SiticoneButton siticoneButton1;

		private SiticoneControlBox siticoneControlBox1;

		private SiticoneControlBox siticoneControlBox2;

		private SiticoneDragControl siticoneDragControl_0;

		private SiticoneAnimateWindow siticoneAnimateWindow_0;

		public LMessageBox()
		{
			this.InitializeComponent();
		}

		public static void Show(string caption, string text, string buttonText, string linkLabelText, Color color, bool showLinkLabel, ButtonClick ButtonClick, LinkLabelClick LinkLabelClick)
		{
			LMessageBox lMessageBox = new LMessageBox();
			lMessageBox.Text = "Siticone UI WinForms - " + text;
			lMessageBox.siticoneLabel1.Text = text;
			lMessageBox.siticoneLabel2.Text = caption;
			lMessageBox.siticonePanel1.CustomBorderColor = color;
			lMessageBox.siticoneButton1.FillColor = color;
			lMessageBox.siticoneButton1.Text = buttonText;
			lMessageBox.linkLabel1.Text = linkLabelText;
			lMessageBox.linkLabel1.LinkColor = color;
			lMessageBox.linkLabel1.Visible = showLinkLabel;
			lMessageBox.buttonClick = ButtonClick;
			lMessageBox.linkLabelClick = LinkLabelClick;
			lMessageBox.ShowDialog();
		}

		private void siticoneButton1_Click(object sender, EventArgs e)
		{
			if (this.buttonClick != null)
			{
				base.Invoke(this.buttonClick);
			}
			base.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.linkLabelClick != null)
			{
				base.Invoke(this.linkLabelClick);
			}
		}

		private void LMessageBox_Load(object sender, EventArgs e)
		{
			this.siticoneAnimateWindow_0.SetAnimateWindow(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns8.LMessageBox));
			this.siticoneControlBox2 = new ns1.SiticoneControlBox();
			this.siticoneButton1 = new ns1.SiticoneButton();
			this.siticoneControlBox1 = new ns1.SiticoneControlBox();
			this.siticonePanel1 = new ns1.SiticonePanel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.siticoneLabel2 = new ns1.SiticoneLabel();
			this.siticoneLabel1 = new ns1.SiticoneLabel();
			this.siticoneDragControl_0 = new ns1.SiticoneDragControl(this.icontainer_0);
			this.siticoneAnimateWindow_0 = new ns1.SiticoneAnimateWindow(this.icontainer_0);
			this.siticonePanel1.SuspendLayout();
			base.SuspendLayout();
			this.siticoneControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.siticoneControlBox2.Animated = false;
			this.siticoneControlBox2.ControlBoxType = ns5.ControlBoxType.MinimizeBox;
			this.siticoneControlBox2.FillColor = System.Drawing.Color.White;
			this.siticoneControlBox2.IconColor = System.Drawing.Color.Black;
			this.siticoneControlBox2.Location = new System.Drawing.Point(330, 5);
			this.siticoneControlBox2.Name = "siticoneControlBox2";
			this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.Size = new System.Drawing.Size(45, 29);
			this.siticoneControlBox2.TabIndex = 6;
			this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 10f);
			this.siticoneButton1.ForeColor = System.Drawing.Color.White;
			this.siticoneButton1.Location = new System.Drawing.Point(36, 412);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new System.Drawing.Size(351, 50);
			this.siticoneButton1.TabIndex = 2;
			this.siticoneButton1.Text = "siticoneButton1";
			this.siticoneButton1.Click += new System.EventHandler(siticoneButton1_Click);
			this.siticoneControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.siticoneControlBox1.Animated = false;
			this.siticoneControlBox1.FillColor = System.Drawing.Color.White;
			this.siticoneControlBox1.IconColor = System.Drawing.Color.Black;
			this.siticoneControlBox1.Location = new System.Drawing.Point(378, 5);
			this.siticoneControlBox1.Name = "siticoneControlBox1";
			this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.Size = new System.Drawing.Size(45, 29);
			this.siticoneControlBox1.TabIndex = 1;
			this.siticonePanel1.Controls.Add(this.siticoneControlBox2);
			this.siticonePanel1.Controls.Add(this.linkLabel1);
			this.siticonePanel1.Controls.Add(this.siticoneLabel2);
			this.siticonePanel1.Controls.Add(this.siticoneLabel1);
			this.siticonePanel1.Controls.Add(this.siticoneButton1);
			this.siticonePanel1.Controls.Add(this.siticoneControlBox1);
			this.siticonePanel1.CustomBorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
			this.siticonePanel1.CustomBorderThickness = new System.Windows.Forms.Padding(1, 5, 1, 1);
			this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
			this.siticonePanel1.Name = "siticonePanel1";
			this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
			this.siticonePanel1.Size = new System.Drawing.Size(424, 523);
			this.siticonePanel1.TabIndex = 0;
			this.linkLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel1.Location = new System.Drawing.Point(36, 476);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(351, 23);
			this.linkLabel1.TabIndex = 5;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "linkLabel1";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			this.siticoneLabel2.AutoSize = false;
			this.siticoneLabel2.BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel2.ForeColor = System.Drawing.Color.Black;
			this.siticoneLabel2.Location = new System.Drawing.Point(36, 75);
			this.siticoneLabel2.Name = "siticoneLabel2";
			this.siticoneLabel2.Size = new System.Drawing.Size(351, 313);
			this.siticoneLabel2.TabIndex = 4;
			this.siticoneLabel2.Text = "siticoneLabel2";
			this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel1.ForeColor = System.Drawing.Color.Black;
			this.siticoneLabel1.Location = new System.Drawing.Point(36, 44);
			this.siticoneLabel1.Name = "siticoneLabel1";
			this.siticoneLabel1.Size = new System.Drawing.Size(113, 23);
			this.siticoneLabel1.TabIndex = 3;
			this.siticoneLabel1.Text = "siticoneLabel1";
			this.siticoneDragControl_0.TargetControl = this.siticonePanel1;
			this.siticoneAnimateWindow_0.AnimationType = ns1.SiticoneAnimateWindow.AnimateWindowType.AW_HIDE;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(424, 523);
			base.Controls.Add(this.siticonePanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "LMessageBox";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LMessageBox";
			base.TopMost = true;
			base.Load += new System.EventHandler(LMessageBox_Load);
			this.siticonePanel1.ResumeLayout(false);
			this.siticonePanel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}

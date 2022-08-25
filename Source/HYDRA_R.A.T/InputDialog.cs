using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu_Controls;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;

namespace HYDRA_R.A.T
{
	internal class InputDialog : Form
	{
		private const int CS_DROPSHADOW = 131072;

		protected string _txtInput;

		protected bool _txtPaintInvalidated;

		private IContainer components;

		private BunifuSeparator bunifuSeparator1;

		private BunifuSeparator bunifuSeparator2;

		private BunifuSeparator bunifuSeparator3;

		private BunifuSeparator bunifuSeparator4;

		private BunifuIconButton bunifuIconButton6;

		private CustomLabel lblMessage;

		private BunifuTextBox txtInput;

		private Guna2ShadowForm guna2ShadowForm1;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams obj = base.CreateParams;
				obj.ClassStyle |= 131072;
				return obj;
			}
		}

		private InputDialog()
		{
			Panel panel = new Panel
			{
				Dock = DockStyle.Fill
			};
			FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
			{
				Dock = DockStyle.Fill
			};
			this.lblMessage = new CustomLabel();
			this.lblMessage.Font = new Font("Electrolize", 10f);
			this.lblMessage.ForeColor = Color.White;
			this.lblMessage.AutoSize = true;
			Panel panel2 = new Panel();
			panel2.BorderStyle = BorderStyle.None;
			panel2.Width = 360;
			panel2.Height = 28;
			panel2.Padding = new Padding(5);
			panel2.BackColor = Color.FromArgb(25, 27, 38);
			panel2.Margin = new Padding(0, 15, 0, 0);
			panel2.Paint += new PaintEventHandler(txtPl_Paint);
			this.txtInput = new BunifuTextBox();
			this.txtInput.Dock = DockStyle.Fill;
			this.txtInput.BorderStyle = BorderStyle.None;
			this.txtInput.Font = new Font("Electrolize", 9f);
			this.txtInput.KeyDown += new KeyEventHandler(txtInput_KeyDown);
			this.txtInput.BackColor = Color.FromArgb(25, 27, 38);
			this.txtInput.Multiline = true;
			this.txtInput.ForeColor = Color.White;
			panel2.Controls.Add(this.txtInput);
			FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
			{
				Dock = DockStyle.Bottom,
				FlowDirection = FlowDirection.RightToLeft,
				Height = 35
			};
			Button button = new Button();
			button.Text = "Cancel";
			button.ForeColor = Color.White;
			button.Font = new Font("Electrolize", 8f);
			button.Padding = new Padding(3);
			button.FlatStyle = FlatStyle.Flat;
			button.Height = 30;
			button.Click += new EventHandler(btnCancel_Click);
			Button button2 = new Button();
			button2.Text = "OK";
			button2.ForeColor = Color.White;
			button2.Font = new Font("Electrolize", 8f);
			button2.Padding = new Padding(3);
			button2.FlatStyle = FlatStyle.Flat;
			button2.Height = 30;
			button2.Click += new EventHandler(btnOK_Click);
			flowLayoutPanel2.Controls.Add(button);
			flowLayoutPanel2.Controls.Add(button2);
			flowLayoutPanel.Controls.Add(this.lblMessage);
			flowLayoutPanel.SetFlowBreak(this.lblMessage, value: true);
			flowLayoutPanel.Controls.Add(panel2);
			flowLayoutPanel.SetFlowBreak(panel2, value: true);
			flowLayoutPanel.Controls.Add(flowLayoutPanel2);
			panel.Controls.Add(flowLayoutPanel);
			base.Controls.Add(panel);
			base.Controls.Add(flowLayoutPanel2);
			base.FormBorderStyle = FormBorderStyle.None;
			this.BackColor = Color.FromArgb(25, 27, 38);
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Padding = new Padding(20);
			base.Width = 400;
			base.Height = 200;
		}

		private void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			if (e.KeyCode == Keys.Return)
			{
				this._txtInput = textBox.Text;
				base.Dispose();
				return;
			}
			if (textBox.Text.Length > 60)
			{
				textBox.Parent.Height = 80;
				if (!this._txtPaintInvalidated)
				{
					textBox.Parent.Invalidate();
					this._txtPaintInvalidated = true;
				}
			}
			if (textBox.Text.Length < 60)
			{
				textBox.Parent.Height = 28;
				if (this._txtPaintInvalidated)
				{
					textBox.Parent.Invalidate();
					this._txtPaintInvalidated = false;
				}
			}
		}

		private void txtPl_Paint(object sender, PaintEventArgs e)
		{
			Panel panel = (Panel)sender;
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			Rectangle rect = new Rectangle(new Point(0, 0), new Size(panel.Width - 1, panel.Height - 1));
			Pen pen = new Pen(Color.FromArgb(54, 193, 214))
			{
				Width = 3f
			};
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(25, 27, 38)), rect);
			graphics.DrawRectangle(pen, rect);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Dispose();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this._txtInput = this.txtInput.Text;
			base.Dispose();
		}

		public static string Show(string message)
		{
			InputDialog inputDialog = new InputDialog();
			inputDialog.lblMessage.Text = message;
			inputDialog.ShowDialog();
			return inputDialog._txtInput;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawRectangle(rect: new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1)), pen: new Pen(Color.FromArgb(54, 193, 214)));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HYDRA_R.A.T.InputDialog));
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.bunifuIconButton6 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.lblMessage = new Bunifu_Controls.CustomLabel();
			this.txtInput = new Bunifu.UI.WinForms.BunifuTextBox();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			base.SuspendLayout();
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(0, -7);
			this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(514, 14);
			this.bunifuSeparator1.TabIndex = 0;
			this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator2.LineThickness = 1;
			this.bunifuSeparator2.Location = new System.Drawing.Point(0, 337);
			this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.bunifuSeparator2.Name = "bunifuSeparator2";
			this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator2.Size = new System.Drawing.Size(514, 18);
			this.bunifuSeparator2.TabIndex = 1;
			this.bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator3.LineThickness = 1;
			this.bunifuSeparator3.Location = new System.Drawing.Point(-5, 1);
			this.bunifuSeparator3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.bunifuSeparator3.Name = "bunifuSeparator3";
			this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator3.Size = new System.Drawing.Size(10, 345);
			this.bunifuSeparator3.TabIndex = 2;
			this.bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
			this.bunifuSeparator4.LineThickness = 1;
			this.bunifuSeparator4.Location = new System.Drawing.Point(508, 1);
			this.bunifuSeparator4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
			this.bunifuSeparator4.Name = "bunifuSeparator4";
			this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
			this.bunifuSeparator4.Size = new System.Drawing.Size(10, 345);
			this.bunifuSeparator4.TabIndex = 3;
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
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.bunifuIconButton6.CustomizableEdges = borderEdges;
			this.bunifuIconButton6.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton6.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton6.Image");
			this.bunifuIconButton6.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton6.Location = new System.Drawing.Point(12, 14);
			this.bunifuIconButton6.Name = "bunifuIconButton6";
			this.bunifuIconButton6.RoundBorders = false;
			this.bunifuIconButton6.ShowBorders = true;
			this.bunifuIconButton6.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton6.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton6.TabIndex = 23;
			this.lblMessage.AutoSize = true;
			this.lblMessage.Font = new System.Drawing.Font("Century Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblMessage.Location = new System.Drawing.Point(53, 26);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(83, 20);
			this.lblMessage.TabIndex = 22;
			this.lblMessage.Text = "User Input";
			this.txtInput.AcceptsReturn = false;
			this.txtInput.AcceptsTab = false;
			this.txtInput.AnimationSpeed = 200;
			this.txtInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.txtInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.txtInput.AutoSizeHeight = true;
			this.txtInput.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.txtInput.BackgroundImage = (System.Drawing.Image)resources.GetObject("txtInput.BackgroundImage");
			this.txtInput.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.txtInput.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.txtInput.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.txtInput.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.txtInput.BorderRadius = 1;
			this.txtInput.BorderThickness = 1;
			this.txtInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtInput.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtInput.DefaultFont = new System.Drawing.Font("Century Gothic", 9.25f);
			this.txtInput.DefaultText = "";
			this.txtInput.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.txtInput.HideSelection = true;
			this.txtInput.IconLeft = null;
			this.txtInput.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.txtInput.IconPadding = 10;
			this.txtInput.IconRight = null;
			this.txtInput.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.txtInput.Lines = new string[0];
			this.txtInput.Location = new System.Drawing.Point(27, 154);
			this.txtInput.MaxLength = 32767;
			this.txtInput.MinimumSize = new System.Drawing.Size(1, 1);
			this.txtInput.Modified = false;
			this.txtInput.Multiline = false;
			this.txtInput.Name = "txtInput";
			stateProperties.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties.FillColor = System.Drawing.Color.Empty;
			stateProperties.ForeColor = System.Drawing.Color.Empty;
			stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtInput.OnActiveState = stateProperties;
			stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.txtInput.OnDisabledState = stateProperties2;
			stateProperties3.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties3.FillColor = System.Drawing.Color.Empty;
			stateProperties3.ForeColor = System.Drawing.Color.Empty;
			stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtInput.OnHoverState = stateProperties3;
			stateProperties4.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties4.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties4.ForeColor = System.Drawing.Color.Empty;
			stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtInput.OnIdleState = stateProperties4;
			this.txtInput.Padding = new System.Windows.Forms.Padding(3);
			this.txtInput.PasswordChar = '\0';
			this.txtInput.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.txtInput.PlaceholderText = "Input";
			this.txtInput.ReadOnly = false;
			this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtInput.SelectedText = "";
			this.txtInput.SelectionLength = 0;
			this.txtInput.SelectionStart = 0;
			this.txtInput.ShortcutsEnabled = true;
			this.txtInput.Size = new System.Drawing.Size(460, 38);
			this.txtInput.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
			this.txtInput.TabIndex = 24;
			this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtInput.TextMarginBottom = 0;
			this.txtInput.TextMarginLeft = 3;
			this.txtInput.TextMarginTop = 1;
			this.txtInput.TextPlaceholder = "Input";
			this.txtInput.UseSystemPasswordChar = false;
			this.txtInput.WordWrap = true;
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(514, 347);
			base.Controls.Add(this.txtInput);
			base.Controls.Add(this.bunifuIconButton6);
			base.Controls.Add(this.lblMessage);
			base.Controls.Add(this.bunifuSeparator4);
			base.Controls.Add(this.bunifuSeparator3);
			base.Controls.Add(this.bunifuSeparator2);
			base.Controls.Add(this.bunifuSeparator1);
			this.Font = new System.Drawing.Font("Century Gothic", 9f);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "InputDialog";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InputDialog";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

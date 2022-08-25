using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NeonRat.Forms
{
	public class MsgBox : Form
	{
		public enum Buttons
		{
			AbortRetryIgnore = 1,
			OK = 2,
			OKCancel = 3,
			RetryCancel = 4,
			YesNo = 5,
			YesNoCancel = 6
		}

		public new enum Icon
		{
			Application = 1,
			Exclamation = 2,
			Error = 3,
			Warning = 4,
			Info = 5,
			Question = 6,
			Shield = 7,
			Search = 8,
			Information = 9
		}

		public enum AnimateStyle
		{
			SlideDown = 1,
			FadeIn = 2,
			ZoomIn = 3
		}

		private const int CS_DROPSHADOW = 131072;

		private static MsgBox _msgBox;

		private Panel _plHeader = new Panel();

		private Panel _plFooter = new Panel();

		private Panel _plIcon = new Panel();

		private PictureBox _picIcon = new PictureBox();

		private FlowLayoutPanel _flpButtons = new FlowLayoutPanel();

		private Label _lblTitle;

		private Label _lblMessage;

		private List<Button> _buttonCollection = new List<Button>();

		private static DialogResult _buttonResult;

		private static Timer _timer;

		private static Point lastMousePos;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams obj = base.CreateParams;
				obj.ClassStyle |= 131072;
				return obj;
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool MessageBeep(uint type);

		private MsgBox()
		{
			base.FormBorderStyle = FormBorderStyle.None;
			this.BackColor = Color.FromArgb(9, 8, 13);
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Padding = new Padding(3);
			base.Width = 400;
			this._lblTitle = new Label();
			this._lblTitle.ForeColor = Color.White;
			this._lblTitle.Font = new Font("Century Gothic", 18f);
			this._lblTitle.Dock = DockStyle.Top;
			this._lblTitle.Height = 50;
			this._lblMessage = new Label();
			this._lblMessage.ForeColor = Color.White;
			this._lblMessage.Font = new Font("Century Gothic", 10f);
			this._lblMessage.Dock = DockStyle.Fill;
			this._flpButtons.FlowDirection = FlowDirection.RightToLeft;
			this._flpButtons.Dock = DockStyle.Fill;
			this._plHeader.Dock = DockStyle.Fill;
			this._plHeader.Padding = new Padding(20);
			this._plHeader.Controls.Add(this._lblMessage);
			this._plHeader.Controls.Add(this._lblTitle);
			this._plFooter.Dock = DockStyle.Bottom;
			this._plFooter.Padding = new Padding(20);
			this._plFooter.BackColor = Color.FromArgb(9, 8, 13);
			this._plFooter.Height = 80;
			this._plFooter.Controls.Add(this._flpButtons);
			this._picIcon.Width = 32;
			this._picIcon.Height = 32;
			this._picIcon.Location = new Point(30, 50);
			this._plIcon.Dock = DockStyle.Left;
			this._plIcon.Padding = new Padding(20);
			this._plIcon.Width = 70;
			this._plIcon.Controls.Add(this._picIcon);
			foreach (Control item in new List<Control> { this, this._lblTitle, this._lblMessage, this._flpButtons, this._plHeader, this._plFooter, this._plIcon, this._picIcon })
			{
				item.MouseDown += new MouseEventHandler(MsgBox_MouseDown);
				item.MouseMove += new MouseEventHandler(MsgBox_MouseMove);
			}
			base.Controls.Add(this._plHeader);
			base.Controls.Add(this._plIcon);
			base.Controls.Add(this._plFooter);
		}

		private static void MsgBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MsgBox.lastMousePos = new Point(e.X, e.Y);
			}
		}

		private static void MsgBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MsgBox._msgBox.Left += e.X - MsgBox.lastMousePos.X;
				MsgBox._msgBox.Top += e.Y - MsgBox.lastMousePos.Y;
			}
		}

		public static DialogResult Show(string message)
		{
			MsgBox._msgBox = new MsgBox();
			MsgBox._msgBox._lblMessage.Text = message;
			MsgBox.InitButtons(Buttons.OK);
			MsgBox._msgBox.ShowDialog();
			MsgBox.MessageBeep(0u);
			return MsgBox._buttonResult;
		}

		public static DialogResult Show(string message, string title)
		{
			MsgBox._msgBox = new MsgBox();
			MsgBox._msgBox._lblMessage.Text = message;
			MsgBox._msgBox._lblTitle.Text = title;
			MsgBox._msgBox.Size = MsgBox.MessageSize(message);
			MsgBox.InitButtons(Buttons.OK);
			MsgBox._msgBox.ShowDialog();
			MsgBox.MessageBeep(0u);
			return MsgBox._buttonResult;
		}

		public static DialogResult Show(string message, string title, Buttons buttons)
		{
			MsgBox._msgBox = new MsgBox();
			MsgBox._msgBox._lblMessage.Text = message;
			MsgBox._msgBox._lblTitle.Text = title;
			MsgBox._msgBox._plIcon.Hide();
			MsgBox.InitButtons(buttons);
			MsgBox._msgBox.Size = MsgBox.MessageSize(message);
			MsgBox._msgBox.ShowDialog();
			MsgBox.MessageBeep(0u);
			return MsgBox._buttonResult;
		}

		public static DialogResult Show(string message, string title, Buttons buttons, Icon icon)
		{
			MsgBox._msgBox = new MsgBox();
			MsgBox._msgBox._lblMessage.Text = message;
			MsgBox._msgBox._lblTitle.Text = title;
			MsgBox.InitButtons(buttons);
			MsgBox.InitIcon(icon);
			MsgBox._msgBox.Size = MsgBox.MessageSize(message);
			MsgBox._msgBox.ShowDialog();
			MsgBox.MessageBeep(0u);
			return MsgBox._buttonResult;
		}

		public static DialogResult Show(string message, string title, Buttons buttons, Icon icon, AnimateStyle style)
		{
			MsgBox._msgBox = new MsgBox();
			MsgBox._msgBox._lblMessage.Text = message;
			MsgBox._msgBox._lblTitle.Text = title;
			MsgBox._msgBox.Height = 0;
			MsgBox.InitButtons(buttons);
			MsgBox.InitIcon(icon);
			MsgBox._timer = new Timer();
			Size size = MsgBox.MessageSize(message);
			switch (style)
			{
			case AnimateStyle.SlideDown:
				MsgBox._msgBox.Size = new Size(size.Width, 0);
				MsgBox._timer.Interval = 1;
				MsgBox._timer.Tag = new AnimateMsgBox(size, style);
				break;
			case AnimateStyle.FadeIn:
				MsgBox._msgBox.Size = size;
				MsgBox._msgBox.Opacity = 0.0;
				MsgBox._timer.Interval = 20;
				MsgBox._timer.Tag = new AnimateMsgBox(size, style);
				break;
			case AnimateStyle.ZoomIn:
				MsgBox._msgBox.Size = new Size(size.Width + 100, size.Height + 100);
				MsgBox._timer.Tag = new AnimateMsgBox(size, style);
				MsgBox._timer.Interval = 1;
				break;
			}
			MsgBox._timer.Tick += new EventHandler(timer_Tick);
			MsgBox._timer.Start();
			MsgBox._msgBox.ShowDialog();
			MsgBox.MessageBeep(0u);
			return MsgBox._buttonResult;
		}

		internal static void timer_Tick(object sender, EventArgs e)
		{
			AnimateMsgBox animateMsgBox = (AnimateMsgBox)((Timer)sender).Tag;
			switch (animateMsgBox.Style)
			{
			case AnimateStyle.SlideDown:
				if (MsgBox._msgBox.Height < animateMsgBox.FormSize.Height)
				{
					MsgBox._msgBox.Height += 17;
					MsgBox._msgBox.Invalidate();
				}
				else
				{
					MsgBox._timer.Stop();
					MsgBox._timer.Dispose();
				}
				break;
			case AnimateStyle.FadeIn:
				if (MsgBox._msgBox.Opacity < 1.0)
				{
					MsgBox._msgBox.Opacity += 0.1;
					MsgBox._msgBox.Invalidate();
				}
				else
				{
					MsgBox._timer.Stop();
					MsgBox._timer.Dispose();
				}
				break;
			case AnimateStyle.ZoomIn:
				if (MsgBox._msgBox.Width > animateMsgBox.FormSize.Width)
				{
					MsgBox._msgBox.Width -= 17;
					MsgBox._msgBox.Invalidate();
				}
				if (MsgBox._msgBox.Height > animateMsgBox.FormSize.Height)
				{
					MsgBox._msgBox.Height -= 17;
					MsgBox._msgBox.Invalidate();
				}
				break;
			}
		}

		private static void InitButtons(Buttons buttons)
		{
			switch (buttons)
			{
			case Buttons.AbortRetryIgnore:
				MsgBox._msgBox.InitAbortRetryIgnoreButtons();
				break;
			case Buttons.OK:
				MsgBox._msgBox.InitOKButton();
				break;
			case Buttons.OKCancel:
				MsgBox._msgBox.InitOKCancelButtons();
				break;
			case Buttons.RetryCancel:
				MsgBox._msgBox.InitRetryCancelButtons();
				break;
			case Buttons.YesNo:
				MsgBox._msgBox.InitYesNoButtons();
				break;
			case Buttons.YesNoCancel:
				MsgBox._msgBox.InitYesNoCancelButtons();
				break;
			}
			foreach (Button item in MsgBox._msgBox._buttonCollection)
			{
				item.ForeColor = Color.White;
				item.Font = new Font("Century Gothic", 8f);
				item.Padding = new Padding(3);
				item.FlatStyle = FlatStyle.Flat;
				item.Height = 30;
				item.FlatAppearance.BorderColor = Color.FromArgb(226, 28, 71);
				MsgBox._msgBox._flpButtons.Controls.Add(item);
			}
		}

		private static void InitIcon(Icon icon)
		{
			switch (icon)
			{
			case Icon.Application:
				MsgBox._msgBox._picIcon.Image = SystemIcons.Application.ToBitmap();
				break;
			case Icon.Exclamation:
				MsgBox._msgBox._picIcon.Image = SystemIcons.Exclamation.ToBitmap();
				break;
			case Icon.Error:
				MsgBox._msgBox._picIcon.Image = SystemIcons.Error.ToBitmap();
				break;
			case Icon.Info:
				MsgBox._msgBox._picIcon.Image = SystemIcons.Information.ToBitmap();
				break;
			case Icon.Question:
				MsgBox._msgBox._picIcon.Image = SystemIcons.Question.ToBitmap();
				break;
			case Icon.Shield:
				MsgBox._msgBox._picIcon.Image = SystemIcons.Shield.ToBitmap();
				break;
			case Icon.Warning:
				MsgBox._msgBox._picIcon.Image = SystemIcons.Warning.ToBitmap();
				break;
			}
		}

		private void InitAbortRetryIgnoreButtons()
		{
			Button button = new Button();
			button.Text = "Abort";
			button.Click += new EventHandler(ButtonClick);
			Button button2 = new Button();
			button2.Text = "Retry";
			button2.Click += new EventHandler(ButtonClick);
			Button button3 = new Button();
			button3.Text = "Ignore";
			button3.Click += new EventHandler(ButtonClick);
			this._buttonCollection.Add(button);
			this._buttonCollection.Add(button2);
			this._buttonCollection.Add(button3);
		}

		private void InitOKButton()
		{
			Button button = new Button();
			button.Text = "OK";
			button.Click += new EventHandler(ButtonClick);
			this._buttonCollection.Add(button);
		}

		private void InitOKCancelButtons()
		{
			Button button = new Button();
			button.Text = "OK";
			button.Click += new EventHandler(ButtonClick);
			Button button2 = new Button();
			button2.Text = "Cancel";
			button2.Click += new EventHandler(ButtonClick);
			this._buttonCollection.Add(button);
			this._buttonCollection.Add(button2);
		}

		private void InitRetryCancelButtons()
		{
			Button button = new Button();
			button.Text = "OK";
			button.Click += new EventHandler(ButtonClick);
			Button button2 = new Button();
			button2.Text = "Cancel";
			button2.Click += new EventHandler(ButtonClick);
			this._buttonCollection.Add(button);
			this._buttonCollection.Add(button2);
		}

		private void InitYesNoButtons()
		{
			Button button = new Button();
			button.Text = "Yes";
			button.Click += new EventHandler(ButtonClick);
			Button button2 = new Button();
			button2.Text = "No";
			button2.Click += new EventHandler(ButtonClick);
			this._buttonCollection.Add(button);
			this._buttonCollection.Add(button2);
		}

		private void InitYesNoCancelButtons()
		{
			Button button = new Button();
			button.Text = "Abort";
			button.Click += new EventHandler(ButtonClick);
			Button button2 = new Button();
			button2.Text = "Retry";
			button2.Click += new EventHandler(ButtonClick);
			Button button3 = new Button();
			button3.Text = "Cancel";
			button3.Click += new EventHandler(ButtonClick);
			this._buttonCollection.Add(button);
			this._buttonCollection.Add(button2);
			this._buttonCollection.Add(button3);
		}

		private static void ButtonClick(object sender, EventArgs e)
		{
			switch (((Button)sender).Text)
			{
			case "Abort":
				MsgBox._buttonResult = DialogResult.Abort;
				break;
			case "Retry":
				MsgBox._buttonResult = DialogResult.Retry;
				break;
			case "Ignore":
				MsgBox._buttonResult = DialogResult.Ignore;
				break;
			case "OK":
				MsgBox._buttonResult = DialogResult.OK;
				break;
			case "Cancel":
				MsgBox._buttonResult = DialogResult.Cancel;
				break;
			case "Yes":
				MsgBox._buttonResult = DialogResult.Yes;
				break;
			case "No":
				MsgBox._buttonResult = DialogResult.No;
				break;
			}
			MsgBox._msgBox.Dispose();
		}

		private static Size MessageSize(string message)
		{
			Graphics graphics = MsgBox._msgBox.CreateGraphics();
			int num = 350;
			int num2 = 230;
			SizeF sizeF = graphics.MeasureString(message, new Font("Century Gothic", 10f));
			if (message.Length < 150 && (int)sizeF.Width > 350)
			{
				num = (int)sizeF.Width;
			}
			return new Size(num, num2);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawRectangle(rect: new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1)), pen: new Pen(Color.FromArgb(226, 28, 71)));
		}
	}
}

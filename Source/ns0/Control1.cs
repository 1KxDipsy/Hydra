using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ns0
{
	[ToolboxItem(false)]
	internal class Control1
	{
		private Color color_1;

		private Point point_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_2;

		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
		public Color Color_0
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				base.Invalidate();
			}
		}

		public event EventHandler Event_0
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler Event_1
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_1, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler Event_2
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_2, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public Control1()
		{
			//Discarded unreachable code: IL_0006
			/*Error near IL_0001: Invalid metadata token*/;
		}

		private bool method_1(Point point_1)
		{
			if (point_1.Y < base.Height / 2)
			{
				return true;
			}
			return false;
		}

		private bool method_2(Point point_1)
		{
			if (point_1.Y > base.Height / 2)
			{
				return true;
			}
			return false;
		}

		protected virtual void OnMouseMove(MouseEventArgs e)
		{
			this.point_0 = e.Location;
			base.OnMouseMove(e);
		}

		protected virtual void OnMouseDown(MouseEventArgs e)
		{
			//Discarded unreachable code: IL_0007, IL_0015, IL_0022, IL_002d
			/*Error near IL_0002: Invalid metadata token*/;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void vmethod_0(EventArgs eventArgs_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void vmethod_1(EventArgs eventArgs_0)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, EventArgs.Empty);
			}
		}

		private Image method_3()
		{
			//Discarded unreachable code: IL_003b, IL_0043, IL_005b, IL_008c, IL_0092, IL_0099, IL_00a5, IL_00ab, IL_00b3, IL_00ba, IL_00c6, IL_00cc, IL_00d2, IL_00d9, IL_00f2, IL_00fe, IL_0104, IL_0109
			//IL_003c: Invalid comparison between Unknown and I4
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Invalid comparison between Unknown and I4
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			Bitmap bitmap = new Bitmap(base.Height + base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			/*Error near IL_0036: Invalid metadata token*/;
		}

		protected virtual void OnPaint(PaintEventArgs e)
		{
			//Discarded unreachable code: IL_005f, IL_0099
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected I4, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected I4, but got Unknown
			Graphics graphics = e.Graphics;
			graphics.DrawImage(this.method_3(), new Rectangle(-base.Height, 0, base.Width + base.Height, base.Height));
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			this.method_4(((Control)(object)this).ForeColor).RotateFlip(RotateFlipType.Rotate180FlipX);
			_ = base.Width / 2;
			_ = 4;
			/*Error near IL_005a: Invalid metadata token*/;
		}

		private Bitmap method_4(Color color_2)
		{
			Bitmap bitmap = new Bitmap(20, 20);
			Graphics.FromImage(bitmap).FillPolygon(new SolidBrush(color_2), new Point[3]
			{
				new Point(bitmap.Width - 20, bitmap.Height / 2 - 2),
				new Point(bitmap.Width - 9, bitmap.Height / 2 - 2),
				new Point(bitmap.Width - 15, bitmap.Height / 2 + 4)
			});
			return bitmap;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void vmethod_2(EventArgs eventArgs_0)
		{
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, EventArgs.Empty);
			}
		}

		protected virtual void OnGotFocus(EventArgs e)
		{
			this.vmethod_2(e);
			base.OnGotFocus(e);
		}
	}
}

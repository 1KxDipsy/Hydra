using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns5;
using ns7;

namespace ns2
{
	[ToolboxItem(false)]
	[DefaultEvent("ValueChanged")]
	public class DateTimePicker : UIDefaultControl
	{
		private AnimationManager animationManager_0;

		private AnimationManager animationManager_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;

		private DateTimePickerState dateTimePickerState_0;

		private DateTimePickerState dateTimePickerState_1;

		private Color color_1;

		private Point point_0;

		private HorizontalAlignment horizontalAlignment_0 = HorizontalAlignment.Left;

		private TextRenderingHint textRenderingHint_0;

		private TextTransform textTransform_0;

		private bool bool_4 = true;

		private bool bool_5 = false;

		private Color color_2 = Class0.color_5;

		private Point point_1;

		private Image image_0;

		private GraphicsPath graphicsPath_0;

		private System.Windows.Forms.DateTimePicker owner;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_2;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_3;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_4;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected DateTimePickerState DefaultHoveredState
		{
			get
			{
				if (this.dateTimePickerState_0 == null)
				{
					this.dateTimePickerState_0 = new DateTimePickerState
					{
						Parent = this
					};
				}
				return this.dateTimePickerState_0;
			}
			set
			{
				this.dateTimePickerState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected DateTimePickerState DefaultCheckedState
		{
			get
			{
				if (this.dateTimePickerState_1 == null)
				{
					this.dateTimePickerState_1 = new DateTimePickerState
					{
						Parent = this
					};
				}
				return this.dateTimePickerState_1;
			}
			set
			{
				this.dateTimePickerState_1 = value;
			}
		}

		[Browsable(false)]
		protected Color DefaultFocusedColor
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

		[Browsable(false)]
		protected Point DefaultTextOffset
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected HorizontalAlignment DefaultTextAlign
		{
			get
			{
				return this.horizontalAlignment_0;
			}
			set
			{
				this.horizontalAlignment_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected TextRenderingHint DefaultTextRenderingHint
		{
			get
			{
				return this.textRenderingHint_0;
			}
			set
			{
				this.textRenderingHint_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected TextTransform DefaultTextTransform
		{
			get
			{
				return this.textTransform_0;
			}
			set
			{
				this.textTransform_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultAnimated
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}

		[Browsable(false)]
		protected bool DefaultChecked
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (!base.DesignMode & (value != this.bool_5))
				{
					if (value)
					{
						this.animationManager_1.StartNewAnimation(AnimationDirection.In);
					}
					else
					{
						this.animationManager_1.StartNewAnimation(AnimationDirection.Out);
					}
				}
				this.bool_5 = value;
				this.OnCheckedChanged(EventArgs.Empty);
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				base.Invalidate();
			}
		}

		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(null)]
		[Localizable(true)]
		public string CustomFormat
		{
			get
			{
				return this.owner.CustomFormat;
			}
			set
			{
				this.owner.CustomFormat = value;
			}
		}

		[RefreshProperties(RefreshProperties.Repaint)]
		public DateTimePickerFormat Format
		{
			get
			{
				return this.owner.Format;
			}
			set
			{
				this.owner.Format = value;
			}
		}

		public DateTime MaxDate
		{
			get
			{
				return this.owner.MaxDate;
			}
			set
			{
				this.owner.MaxDate = value;
			}
		}

		public static DateTime MaximumDateTime => DateTimePicker.MaximumDateTime;

		public DateTime MinDate
		{
			get
			{
				return this.owner.MinDate;
			}
			set
			{
				this.owner.MinDate = value;
			}
		}

		public static DateTime MinimumDateTime => DateTimePicker.MinimumDateTime;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int PreferredHeight => base.Height;

		[DefaultValue(false)]
		[Browsable(true)]
		public bool ShowCheckBox
		{
			get
			{
				return this.owner.ShowCheckBox;
			}
			set
			{
				this.owner.ShowCheckBox = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		[DefaultValue(false)]
		public bool ShowUpDown
		{
			get
			{
				return this.owner.ShowUpDown;
			}
			set
			{
				this.owner.ShowUpDown = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return this.owner.Text;
			}
			set
			{
				this.owner.Text = value;
			}
		}

		[Bindable(true)]
		[RefreshProperties(RefreshProperties.All)]
		public DateTime Value
		{
			get
			{
				return this.owner.Value;
			}
			set
			{
				this.owner.Value = value;
			}
		}

		public event EventHandler CheckedChanged
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

		public event EventHandler ValueChanged
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

		public event EventHandler FormatChanged
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

		public event EventHandler DropDown
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_3;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_3;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_3, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler CloseUp
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_4;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_4, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_4;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_4, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public DateTimePicker()
		{
			this.method_1();
			this.method_13();
			base.Controls.Add(this.owner);
			base.Size = new Size(200, 36);
		}

		public void PerformClick()
		{
			this.OnClick(EventArgs.Empty);
		}

		private void method_1()
		{
			this.animationManager_0 = new AnimationManager
			{
				Increment = 0.07000000029802322,
				AnimationType = AnimationType.Linear
			};
			this.animationManager_0.OnAnimationProgress += new AnimationManager.AnimationProgress(method_3);
			this.animationManager_1 = new AnimationManager
			{
				Increment = 0.07000000029802322,
				AnimationType = AnimationType.Linear
			};
			this.animationManager_1.OnAnimationProgress += new AnimationManager.AnimationProgress(method_2);
		}

		private void method_2(object object_0)
		{
			base.Invalidate();
		}

		private void method_3(object object_0)
		{
			base.Invalidate();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCheckedChanged(EventArgs e)
		{
			if (!this.bool_4 | base.DesignMode)
			{
				base.Invalidate();
			}
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			this.point_1 = e.Location;
			base.OnMouseMove(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			base.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (!this.bool_4)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode & !this.bool_5)
			{
				this.animationManager_0.StartNewAnimation((base.MouseState != 0) ? AnimationDirection.Out : AnimationDirection.In);
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			if (!this.bool_4)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode & !this.bool_5)
			{
				this.animationManager_0.StartNewAnimation(AnimationDirection.In);
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (!this.bool_4)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode)
			{
				this.animationManager_0.StartNewAnimation(AnimationDirection.Out);
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnLostFocus(e);
		}

		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			if ((kevent.KeyData == Keys.Space) | (kevent.KeyData == Keys.Return))
			{
				this.PerformClick();
				kevent.Handled = true;
			}
			base.OnKeyDown(kevent);
		}

		private Image method_4()
		{
			if (this.image_0 == null)
			{
				Stream manifestResourceStream = typeof(DateTimePicker).Assembly.GetManifestResourceStream(typeof(DateTimePicker).Namespace + ".ImageCalendar.png");
				if (manifestResourceStream != null)
				{
					this.image_0 = Image.FromStream(manifestResourceStream);
				}
			}
			return this.image_0;
		}

		private Color method_5()
		{
			if (!(this.DefaultHoveredState.FillColor == Color.Empty))
			{
				return this.DefaultHoveredState.FillColor;
			}
			return Class6.smethod_10(this.color_2, Color.Black, Color.White, 15);
		}

		private Color method_6()
		{
			if (!(this.DefaultHoveredState.ForeColor == Color.Empty))
			{
				return this.DefaultHoveredState.ForeColor;
			}
			return base.ForeColor;
		}

		private Color method_7()
		{
			if (!(this.DefaultHoveredState.BorderColor == Color.Empty))
			{
				return this.DefaultHoveredState.BorderColor;
			}
			return Class6.smethod_10(base.DefaultBorderColor, Color.Black, Color.White, 15);
		}

		private Color method_8()
		{
			if (!(this.DefaultCheckedState.FillColor == Color.Empty))
			{
				return this.DefaultCheckedState.FillColor;
			}
			return this.method_5();
		}

		private Color method_9()
		{
			if (!(this.DefaultCheckedState.ForeColor == Color.Empty))
			{
				return this.DefaultCheckedState.ForeColor;
			}
			return this.method_6();
		}

		private Color method_10()
		{
			if (!(this.DefaultCheckedState.BorderColor == Color.Empty))
			{
				return this.DefaultCheckedState.BorderColor;
			}
			return this.method_7();
		}

		private Bitmap method_11(Color color_3)
		{
			Bitmap bitmap = new Bitmap(20, 20);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawLine(new Pen(color_3, 2f), new Point(18, 10), new Point(14, 14));
			graphics.DrawLine(new Pen(color_3, 2f), new Point(14, 14), new Point(10, 10));
			graphics.DrawLine(new Pen(color_3), new Point(14, 15), new Point(14, 14));
			return bitmap;
		}

		private void method_12(Graphics graphics_0)
		{
			Color color = this.color_2;
			Color color2 = this.ForeColor;
			Color color3 = base.DefaultBorderColor;
			if (this.bool_4 && !base.DesignMode)
			{
				color = Class6.smethod_23((int)Math.Round(this.animationManager_0.GetProgress() * 100.0), color, this.method_5());
				color2 = Class6.smethod_23((int)Math.Round(this.animationManager_0.GetProgress() * 100.0), color2, this.method_6());
				color3 = Class6.smethod_23((int)Math.Round(this.animationManager_0.GetProgress() * 100.0), color3, this.method_7());
				color = Class6.smethod_23((int)Math.Round(this.animationManager_1.GetProgress() * 100.0), color, this.method_8());
				color2 = Class6.smethod_23((int)Math.Round(this.animationManager_1.GetProgress() * 100.0), color2, this.method_9());
				color3 = Class6.smethod_23((int)Math.Round(this.animationManager_1.GetProgress() * 100.0), color3, this.method_10());
			}
			else if (this.bool_5)
			{
				color = this.method_8();
				color2 = this.method_9();
				color3 = this.method_10();
			}
			else if ((base.MouseState == MouseState.HOVER) | (base.MouseState == MouseState.DOWN))
			{
				color = this.method_5();
				color2 = this.method_6();
				color3 = this.method_7();
			}
			bool flag = !this.bool_5 & base.Enabled & this.Focused & (this.color_1 != Color.Empty) & (base.MouseState == MouseState.const_2);
			if (base.DefaultBorderRadius > 0)
			{
				this.graphicsPath_0 = Class6.smethod_12(Class6.smethod_11(base.ClientRectangle), base.DefaultBorderRadius * 2);
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphics_0.FillPath(new SolidBrush(color), this.graphicsPath_0);
				if (flag | (base.DefaultBorderThickness != 0))
				{
					Class6.smethod_20(graphics_0, flag ? new SolidBrush(this.color_1) : new SolidBrush(color3), base.ClientRectangle, base.DefaultBorderRadius, (base.DefaultBorderThickness > 0) ? base.DefaultBorderThickness : (flag ? 1 : 0), base.DefaultBorderStyle);
				}
			}
			else
			{
				graphics_0.SmoothingMode = SmoothingMode.Default;
				graphics_0.FillRectangle(new SolidBrush(color), base.ClientRectangle);
				Class6.smethod_22(graphics_0, flag ? new SolidBrush(this.color_1) : new SolidBrush(color3), base.ClientRectangle, (base.DefaultBorderThickness > 0) ? base.DefaultBorderThickness : (flag ? 1 : 0), base.DefaultBorderStyle);
			}
			Rectangle rectangle = new Rectangle(this.point_0.X, this.point_0.Y, base.Width, base.Height);
			if (this.horizontalAlignment_0 == HorizontalAlignment.Right)
			{
				rectangle.X = -10;
				rectangle.X += this.point_0.X;
			}
			else if (this.horizontalAlignment_0 == HorizontalAlignment.Left)
			{
				rectangle.X += 10;
			}
			if (this.horizontalAlignment_0 == HorizontalAlignment.Right)
			{
				rectangle.X -= 19;
			}
			else if (this.horizontalAlignment_0 == HorizontalAlignment.Left)
			{
				rectangle.X += 19;
			}
			if (this.ShowCheckBox)
			{
				graphics_0.DrawRectangle(new Pen(this.ForeColor, 1f), new Rectangle(10, base.Height / 2 - 6, 12, 12));
				if (this.bool_5)
				{
					graphics_0.FillRectangle(new SolidBrush(this.ForeColor), new Rectangle(12, base.Height / 2 - 4, 9, 9));
				}
			}
			else
			{
				graphics_0.DrawImage(Class6.smethod_25(this.method_4(), Color.White, color2), new Rectangle(10, base.Height / 2 - 7, 13, 13));
			}
			graphics_0.DrawImage(this.method_11(color2), new Rectangle(base.Width - 29, base.Height / 2 - 12, 20, 20));
			graphics_0.TextRenderingHint = this.textRenderingHint_0;
			string s = this.Text;
			switch (this.textTransform_0)
			{
			case TextTransform.LowerCase:
				s = this.Text.ToLower();
				break;
			case TextTransform.UpperCase:
				s = this.Text.ToUpper();
				break;
			}
			graphics_0.DrawString(s, this.Font, new SolidBrush(color2), rectangle, new StringFormat
			{
				FormatFlags = StringFormatFlags.NoWrap,
				Alignment = Class6.smethod_4(this.horizontalAlignment_0),
				LineAlignment = StringAlignment.Center
			});
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Bitmap image = new Bitmap(base.Width, base.Height);
				this.method_12(Graphics.FromImage(image));
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else
			{
				this.method_12(e.Graphics);
			}
			base.OnPaint(e);
		}

		protected override void OnResize(EventArgs e)
		{
			this.owner.Width = base.Width;
			this.owner.Left = 0;
			this.owner.Top = base.Height;
			base.Invalidate();
			base.OnResize(e);
		}

		public override string ToString()
		{
			return this.owner.ToString();
		}

		private void method_13()
		{
			this.owner = new System.Windows.Forms.DateTimePicker();
			base.SuspendLayout();
			this.owner.Font = new Font("Microsoft Sans Serif", 1f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.owner.Location = new Point(0, 0);
			this.owner.Name = "owner";
			this.owner.Size = new Size(200, 9);
			this.owner.TabIndex = 0;
			this.owner.FormatChanged += new EventHandler(owner_FormatChanged);
			this.owner.CloseUp += new EventHandler(owner_CloseUp);
			this.owner.ValueChanged += new EventHandler(owner_ValueChanged);
			this.owner.DropDown += new EventHandler(owner_DropDown);
			base.DefaultShadowDecoration.Parent = this;
			this.DefaultTextAlign = HorizontalAlignment.Left;
			this.DefaultTextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			this.DefaultTextTransform = TextTransform.None;
			base.ResumeLayout(performLayout: false);
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValueChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, EventArgs.Empty);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnFormatChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, EventArgs.Empty);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDropDown(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_3 != null)
			{
				this.eventHandler_3(this, EventArgs.Empty);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCloseUp(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_4 != null)
			{
				this.eventHandler_4(this, EventArgs.Empty);
			}
		}

		private void owner_ValueChanged(object sender, EventArgs e)
		{
			this.OnValueChanged(EventArgs.Empty);
		}

		private void owner_FormatChanged(object sender, EventArgs e)
		{
			this.OnFormatChanged(EventArgs.Empty);
		}

		private void owner_DropDown(object sender, EventArgs e)
		{
			this.OnDropDown(EventArgs.Empty);
		}

		private void owner_CloseUp(object sender, EventArgs e)
		{
			base.Select();
			this.OnCloseUp(EventArgs.Empty);
		}

		protected override void OnClick(EventArgs e)
		{
			if (this.point_1.X < 30 && this.ShowCheckBox)
			{
				this.DefaultChecked = ((!this.bool_5) ? true : false);
				return;
			}
			this.owner.Select();
			SendKeys.Send("%{DOWN}");
			base.OnClick(e);
		}
	}
}

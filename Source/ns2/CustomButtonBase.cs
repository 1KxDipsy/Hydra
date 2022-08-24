using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns3;
using ns5;
using ns7;

namespace ns2
{
	[ToolboxItem(false)]
	public class CustomButtonBase : Control, IButtonControl, IControl
	{
		private DialogResult dialogResult_0;

		protected AnimationManager AnimationManager;

		protected AnimationManager HoveredAnimationManager;

		protected AnimationManager CheckedAnimationManager;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		private Color color_0;

		private int int_0 = 0;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private Color color_1 = Color.Black;

		private int int_1 = 0;

		private ShadowDecoration shadowDecoration_0;

		private Image image_0;

		private Size size_0;

		private Point point_0;

		private Point point_1;

		private HorizontalAlignment horizontalAlignment_0;

		private HorizontalAlignment horizontalAlignment_1;

		private TextRenderingHint textRenderingHint_0;

		private TextTransform textTransform_0;

		private bool bool_0 = false;

		private bool bool_1 = true;

		private bool bool_2 = false;

		private Color color_2 = Class0.color_19;

		private Color color_3;

		private Padding padding_0 = new Padding(0);

		private Color color_4 = Color.Black;

		private int int_2 = 30;

		private ButtonMode buttonMode_0;

		private bool bool_3;

		private bool bool_4 = false;

		internal MouseState mouseState_0 = MouseState.const_2;

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[DefaultValue(0)]
		public DialogResult DialogResult
		{
			get
			{
				return this.dialogResult_0;
			}
			set
			{
				this.dialogResult_0 = value;
			}
		}

		[Localizable(true)]
		[Category("Options")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultFocusedColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultBorderRadius
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = ((value >= 0) ? value : 0);
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected DashStyle DefaultBorderStyle
		{
			get
			{
				return this.dashStyle_0;
			}
			set
			{
				this.dashStyle_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultBorderColor
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
		protected int DefaultBorderThickness
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ShadowDecoration DefaultShadowDecoration
		{
			get
			{
				if (this.shadowDecoration_0 == null)
				{
					this.shadowDecoration_0 = new ShadowDecoration(this);
				}
				return this.shadowDecoration_0;
			}
			set
			{
				this.shadowDecoration_0 = value;
			}
		}

		[Browsable(false)]
		protected Image DefaultImage
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Size DefaultImageSize
		{
			get
			{
				return this.size_0;
			}
			set
			{
				this.size_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Point DefaultImageOffset
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
		protected Point DefaultTextOffset
		{
			get
			{
				return this.point_1;
			}
			set
			{
				this.point_1 = value;
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
		protected HorizontalAlignment DefaultImageAlign
		{
			get
			{
				return this.horizontalAlignment_1;
			}
			set
			{
				this.horizontalAlignment_1 = value;
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
		protected bool DefaultTile
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultAnimated
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		[Browsable(false)]
		protected bool DefaultChecked
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (!base.DesignMode & (value != this.bool_2))
				{
					if (value)
					{
						this.CheckedAnimationManager.StartNewAnimation(AnimationDirection.In);
					}
					else
					{
						this.CheckedAnimationManager.StartNewAnimation(AnimationDirection.Out);
					}
				}
				this.bool_2 = value;
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

		[Browsable(false)]
		protected Color DefaultCustomBorderColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Padding DefaultCustomBorderThickness
		{
			get
			{
				return this.padding_0;
			}
			set
			{
				this.padding_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultPressedColor
		{
			get
			{
				return this.color_4;
			}
			set
			{
				this.color_4 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultPressedDepth
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected ButtonMode DefaultButtonMode
		{
			get
			{
				return this.buttonMode_0;
			}
			set
			{
				this.buttonMode_0 = value;
				base.Invalidate();
			}
		}

		[Description("Set the use of transfarant backgroud on this control.")]
		[Browsable(false)]
		protected bool DefaultUseTransparentBackground
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				base.Invalidate();
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

		public CustomButtonBase()
		{
			this.InitializeAnimationManager();
			this.dialogResult_0 = DialogResult.None;
			this.size_0 = new Size(20, 20);
			this.horizontalAlignment_0 = HorizontalAlignment.Center;
			this.horizontalAlignment_1 = HorizontalAlignment.Center;
			this.textRenderingHint_0 = TextRenderingHint.ClearTypeGridFit;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.ForeColor = Color.White;
			this.Font = new Font("Segoe UI", 9f);
		}

		public void NotifyDefault(bool value)
		{
		}

		public void PerformClick()
		{
			this.OnClick(EventArgs.Empty);
		}

		protected void InitializeAnimationManager()
		{
			this.AnimationManager = new AnimationManager(singular: false)
			{
				Increment = 0.029999999329447746,
				AnimationType = AnimationType.EaseOut
			};
			this.AnimationManager.OnAnimationProgress += new AnimationManager.AnimationProgress(method_2);
			this.HoveredAnimationManager = new AnimationManager
			{
				Increment = 0.07000000029802322,
				AnimationType = AnimationType.Linear
			};
			this.HoveredAnimationManager.OnAnimationProgress += new AnimationManager.AnimationProgress(method_1);
			this.CheckedAnimationManager = new AnimationManager
			{
				Increment = 0.07000000029802322,
				AnimationType = AnimationType.Linear
			};
			this.CheckedAnimationManager.OnAnimationProgress += new AnimationManager.AnimationProgress(method_0);
		}

		private void method_0(object object_0)
		{
			base.Invalidate();
		}

		private void method_1(object object_0)
		{
			base.Invalidate();
		}

		private void method_2(object object_0)
		{
			base.Invalidate();
		}

		private void method_3()
		{
			if (!base.IsHandleCreated || !this.bool_2 || this.buttonMode_0 != ButtonMode.RadioButton)
			{
				return;
			}
			foreach (Control control in base.Parent.Controls)
			{
				if (control != this && control is CustomButtonBase && control != this)
				{
					CustomButtonBase customButtonBase = (CustomButtonBase)control;
					if (customButtonBase.DefaultChecked)
					{
						customButtonBase.DefaultChecked = false;
					}
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCheckedChanged(EventArgs e)
		{
			if (this.buttonMode_0 == ButtonMode.RadioButton && this.bool_2 && !base.DesignMode)
			{
				this.method_3();
			}
			if (!this.bool_1 | base.DesignMode)
			{
				base.Invalidate();
			}
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		private void method_4(Graphics graphics_0)
		{
			if (!this.bool_3)
			{
				return;
			}
			graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
			graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics_0.CompositingQuality = CompositingQuality.GammaCorrected;
			if (base.Parent == null)
			{
				return;
			}
			if (this.BackColor != Color.Transparent)
			{
				this.BackColor = Color.Transparent;
			}
			int childIndex = base.Parent.Controls.GetChildIndex(this);
			int num = base.Parent.Controls.Count - 1;
			int num2 = childIndex + 1;
			for (int i = num; i >= num2; i += -1)
			{
				Control control = base.Parent.Controls[i];
				if (control.Bounds.IntersectsWith(base.Bounds) && control.Visible)
				{
					Bitmap bitmap = new Bitmap(control.Width, control.Height, graphics_0);
					control.DrawToBitmap(bitmap, control.ClientRectangle);
					graphics_0.TranslateTransform(control.Left - base.Left, control.Top - base.Top);
					graphics_0.DrawImageUnscaled(bitmap, Point.Empty);
					graphics_0.TranslateTransform(base.Left - control.Left, base.Top - control.Top);
					bitmap.Dispose();
				}
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			this.method_4(e.Graphics);
		}

		protected override void OnResize(EventArgs e)
		{
			base.Invalidate();
			base.OnResize(e);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			this.bool_4 = false;
			this.mouseState_0 = MouseState.const_2;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.bool_4 = true;
			this.mouseState_0 = MouseState.DOWN;
			if (!this.DefaultAnimated)
			{
				base.Invalidate();
			}
			else if (e.Button == MouseButtons.Left && !this.DefaultChecked)
			{
				this.AnimationManager.StartNewAnimation(AnimationDirection.In, e.Location);
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.mouseState_0 = ((!this.bool_4) ? MouseState.const_2 : MouseState.HOVER);
			if (!this.DefaultAnimated)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode & !this.DefaultChecked)
			{
				this.HoveredAnimationManager.StartNewAnimation((this.mouseState_0 != 0) ? AnimationDirection.Out : AnimationDirection.In);
			}
			base.OnMouseUp(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.bool_4 = true;
			this.mouseState_0 = MouseState.HOVER;
			if (!this.DefaultAnimated)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode & !this.DefaultChecked)
			{
				this.HoveredAnimationManager.StartNewAnimation(AnimationDirection.In);
			}
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.bool_4 = false;
			this.mouseState_0 = MouseState.const_2;
			if (!this.DefaultAnimated)
			{
				base.Invalidate();
			}
			else if (!base.DesignMode)
			{
				this.HoveredAnimationManager.StartNewAnimation(AnimationDirection.Out);
			}
			base.OnMouseLeave(e);
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

		protected override void OnClick(EventArgs e)
		{
			switch (this.buttonMode_0)
			{
			case ButtonMode.ToogleButton:
				if (!this.bool_2)
				{
					this.DefaultChecked = true;
				}
				else
				{
					this.DefaultChecked = false;
				}
				break;
			case ButtonMode.RadioButton:
				if (!this.bool_2)
				{
					this.DefaultChecked = true;
				}
				break;
			}
			if (!this.bool_2)
			{
				base.Focus();
			}
			base.OnClick(e);
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns3;

namespace ns2
{
	[ToolboxItem(false)]
	[DefaultEvent("ValueChanged")]
	public class NumericUpDown : UserControl, ISupportInitialize, IControl
	{
		private Control1 upDownButton1;

		private Class7 Owner;

		private IContainer icontainer_0 = null;

		private NumericUpDownState numericUpDownState_0;

		private NumericUpDownState numericUpDownState_1;

		private bool bool_0 = true;

		private Color color_0 = Color.FromArgb(94, 148, 255);

		private Color color_1 = Color.FromArgb(80, 0, 0, 0);

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private ShadowDecoration shadowDecoration_0;

		private Color color_2 = Color.White;

		private Color color_3 = Class0.color_31;

		private int int_0 = 1;

		private int int_1;

		private Point point_0;

		private bool bool_1;

		private Padding padding_0 = new Padding(9, 9, 9, 9);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[Description("Gets a value that indicates whether the Component is currently in design mode.")]
		[Browsable(false)]
		public bool IsDesignMode => base.DesignMode;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected NumericUpDownState DefaultFocusedState
		{
			get
			{
				if (this.numericUpDownState_0 == null)
				{
					this.numericUpDownState_0 = new NumericUpDownState
					{
						Parent = this
					};
				}
				return this.numericUpDownState_0;
			}
			set
			{
				this.numericUpDownState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected NumericUpDownState DefaultDisabledState
		{
			get
			{
				if (this.numericUpDownState_1 == null)
				{
					this.numericUpDownState_1 = new NumericUpDownState
					{
						Parent = this
					};
				}
				return this.numericUpDownState_1;
			}
			set
			{
				this.numericUpDownState_1 = value;
			}
		}

		[Browsable(false)]
		protected bool DefaultUpDownButtonBorderVisible
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				//Discarded unreachable code: IL_0020, IL_002e
				this.bool_0 = value;
				if (this.bool_0)
				{
					_ = this.upDownButton1;
					_ = this.int_0;
					/*Error near IL_001b: Invalid metadata token*/;
				}
				_ = this.upDownButton1;
				_ = 0;
				/*Error near IL_0029: Invalid metadata token*/;
			}
		}

		[Browsable(false)]
		protected Color DefaultUpDownButtonFillColor
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
		protected Color DefaultUpDownButtonForeColor
		{
			get
			{
				return ((Control)(object)this.upDownButton1).ForeColor;
			}
			set
			{
				this.color_1 = value;
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
				//Discarded unreachable code: IL_0018
				this.dashStyle_0 = value;
				_ = this.upDownButton1;
				_ = this.dashStyle_0;
				/*Error near IL_0013: Invalid metadata token*/;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(false)]
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
		protected Color DefaultFillColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.Owner.BackColor = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultBorderColor
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
		protected int DefaultBorderThickness
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				if (this.bool_0)
				{
					_ = this.upDownButton1;
					_ = this.int_0;
					/*Error near IL_001b: Invalid metadata token*/;
				}
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected int DefaultBorderRadius
		{
			get
			{
				return this.int_1;
			}
			set
			{
				//Discarded unreachable code: IL_001f
				this.int_1 = ((value >= 0) ? value : 0);
				_ = this.upDownButton1;
				_ = this.int_1;
				/*Error near IL_001a: Invalid metadata token*/;
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
				this.method_3();
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultUseTransparentBackground
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public NumericUpDownAccelerationCollection Accelerations => this.Owner.Accelerations;

		[DefaultValue(0)]
		public int DecimalPlaces
		{
			get
			{
				return this.Owner.DecimalPlaces;
			}
			set
			{
				this.Owner.DecimalPlaces = value;
			}
		}

		[DefaultValue(false)]
		public bool Hexadecimal
		{
			get
			{
				return this.Owner.Hexadecimal;
			}
			set
			{
				this.Owner.Hexadecimal = value;
			}
		}

		[DefaultValue(typeof(Decimal), "1")]
		public decimal Increment
		{
			get
			{
				return this.Owner.Increment;
			}
			set
			{
				this.Owner.Increment = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(typeof(Decimal), "100")]
		public decimal Maximum
		{
			get
			{
				return this.Owner.Maximum;
			}
			set
			{
				this.Owner.Maximum = value;
			}
		}

		[DefaultValue(typeof(Decimal), "0")]
		[RefreshProperties(RefreshProperties.All)]
		public decimal Minimum
		{
			get
			{
				return this.Owner.Minimum;
			}
			set
			{
				this.Owner.Minimum = value;
			}
		}

		[Bindable(false)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text
		{
			get
			{
				return this.Owner.Text;
			}
			set
			{
				this.Owner.Text = value;
			}
		}

		[DefaultValue(false)]
		[Localizable(true)]
		public bool ThousandsSeparator
		{
			get
			{
				return this.Owner.ThousandsSeparator;
			}
			set
			{
				this.Owner.ThousandsSeparator = value;
			}
		}

		[Bindable(true)]
		[DefaultValue(typeof(Decimal), "0")]
		public decimal Value
		{
			get
			{
				return this.Owner.Value;
			}
			set
			{
				this.Owner.Value = value;
			}
		}

		[Category("Options")]
		[Browsable(true)]
		[Description("Sets the TextBox's foreground color.")]
		[DefaultValue(typeof(Color), "125, 137, 149")]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
				base.Invalidate();
			}
		}

		[Description("Gets or sets the font of the text displayed by the control.")]
		public new Font Font
		{
			get
			{
				return this.Owner.Font;
			}
			set
			{
				this.Owner.Font = value;
				base.Font = value;
				this.method_2();
			}
		}

		[Description("Gets a value indicating whether the control has input focus")]
		public new bool Focused => this.Owner.Focused | base.Focused;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler TextChanged
		{
			add
			{
				base.TextChanged += value;
			}
			remove
			{
				base.TextChanged -= value;
			}
		}

		public event EventHandler ValueChanged
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

		public NumericUpDown()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.DoubleBuffered = true;
			this.InitializeComponent();
			this.Owner.SendToBack();
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
			//Discarded unreachable code: IL_010d, IL_0119, IL_01a2
			this.Owner = new ns0.Class7();
			this.upDownButton1 = new ns0.Control1();
			((System.ComponentModel.ISupportInitialize)this.Owner).BeginInit();
			base.SuspendLayout();
			this.Owner.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.Owner.BackColor = System.Drawing.Color.White;
			this.Owner.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Owner.ForeColor = System.Drawing.Color.FromArgb(126, 137, 149);
			this.Owner.Location = new System.Drawing.Point(18, 9);
			this.Owner.Name = "Owner";
			this.Owner.Size = new System.Drawing.Size(79, 19);
			this.Owner.TabIndex = 2;
			this.Owner.Event_0 += new ns0.Class7.Delegate1(method_7);
			this.Owner.ValueChanged += new System.EventHandler(Owner_ValueChanged);
			((System.Windows.Forms.Control)(object)this.upDownButton1).BackColor = System.Drawing.Color.Transparent;
			_ = this.upDownButton1;
			System.Drawing.Color.FromArgb(213, 218, 223);
			/*Error near IL_0108: Invalid metadata token*/;
		}

		private void method_0(Graphics graphics_0)
		{
			if (!this.bool_1)
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
			this.method_0(e.Graphics);
		}

		private Image method_1()
		{
			//Discarded unreachable code: IL_0272, IL_027b, IL_0288, IL_0293, IL_02d5, IL_02f7, IL_031e
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			Color fillColor = this.color_2;
			Color foreColor = this.ForeColor;
			Color color = this.color_3;
			Color upDownButtonFillColor = this.color_0;
			Color upDownButtonForeColor = this.color_1;
			if (base.Enabled)
			{
				if (this.Owner.Focused | base.Focused)
				{
					if (this.DefaultFocusedState.FillColor != Color.Empty)
					{
						fillColor = this.DefaultFocusedState.FillColor;
					}
					if (this.DefaultFocusedState.ForeColor != Color.Empty)
					{
						foreColor = this.DefaultFocusedState.ForeColor;
					}
					if (this.DefaultFocusedState.BorderColor != Color.Empty)
					{
						color = this.DefaultFocusedState.BorderColor;
					}
					if (this.DefaultFocusedState.UpDownButtonFillColor != Color.Empty)
					{
						upDownButtonFillColor = this.DefaultFocusedState.UpDownButtonFillColor;
					}
					if (this.DefaultFocusedState.UpDownButtonForeColor != Color.Empty)
					{
						upDownButtonForeColor = this.DefaultFocusedState.UpDownButtonForeColor;
					}
				}
			}
			else
			{
				if (this.DefaultDisabledState.FillColor != Color.Empty)
				{
					fillColor = this.DefaultDisabledState.FillColor;
				}
				if (this.DefaultDisabledState.ForeColor != Color.Empty)
				{
					foreColor = this.DefaultDisabledState.ForeColor;
				}
				if (this.DefaultDisabledState.BorderColor != Color.Empty)
				{
					color = this.DefaultDisabledState.BorderColor;
				}
				if (this.DefaultDisabledState.UpDownButtonFillColor != Color.Empty)
				{
					upDownButtonFillColor = this.DefaultDisabledState.UpDownButtonFillColor;
				}
				if (this.DefaultDisabledState.UpDownButtonForeColor != Color.Empty)
				{
					upDownButtonForeColor = this.DefaultDisabledState.UpDownButtonForeColor;
				}
			}
			if (this.Owner.ForeColor != foreColor)
			{
				this.Owner.ForeColor = foreColor;
			}
			if (this.Owner.BackColor != fillColor)
			{
				this.Owner.BackColor = fillColor;
			}
			if (this.upDownButton1.Color_0 != upDownButtonFillColor)
			{
				this.upDownButton1.Color_0 = upDownButtonFillColor;
			}
			if (((Control)(object)this.upDownButton1).ForeColor != upDownButtonForeColor)
			{
				((Control)(object)this.upDownButton1).ForeColor = upDownButtonForeColor;
			}
			_ = this.upDownButton1;
			/*Error near IL_026d: Invalid metadata token*/;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.DrawImageUnscaledAndClipped(this.method_1(), new Rectangle(0, 0, base.Width - (int)((float)base.Height / 1.3f), base.Height));
			base.OnPaint(e);
		}

		protected override void OnResize(EventArgs e)
		{
			this.method_2();
			base.OnResize(e);
		}

		internal void method_2()
		{
			this.method_3();
			base.Invalidate();
		}

		private void method_3()
		{
			if (this.Owner != null)
			{
				Padding padding = this.padding_0;
				padding.Left += this.point_0.X;
				padding.Right += this.point_0.X;
				Rectangle clientRectangle = base.ClientRectangle;
				Rectangle clientRectangle2 = this.Owner.ClientRectangle;
				clientRectangle2.X = 0;
				clientRectangle2.Y = 0;
				clientRectangle2.Y = base.Height / 2 - clientRectangle2.Height / 2;
				clientRectangle2.Y++;
				clientRectangle2.Y += this.point_0.Y;
				clientRectangle2.X = padding.Left;
				clientRectangle.Width -= clientRectangle2.X;
				clientRectangle.Width -= (int)((float)base.Height / 1.3f);
				clientRectangle.Width += 18;
				if (this.Owner.Width != clientRectangle.Width)
				{
					this.Owner.Width = clientRectangle.Width;
				}
				if (this.Owner.Left != clientRectangle2.Left)
				{
					this.Owner.Left = clientRectangle2.Left;
				}
				if (this.Owner.Top != clientRectangle2.Top)
				{
					this.Owner.Top = clientRectangle2.Top;
				}
				((Control)(object)this.upDownButton1).Width = (int)((float)base.Height / 1.3f);
				((Control)(object)this.upDownButton1).Height = base.Height;
				((Control)(object)this.upDownButton1).Top = 0;
				((Control)(object)this.upDownButton1).Left = base.Width - (int)((float)base.Height / 1.3f);
				((Control)(object)this.upDownButton1).Invalidate();
			}
		}

		private void method_4(object sender, EventArgs e)
		{
			this.Owner.UpButton();
		}

		private void method_5(object sender, EventArgs e)
		{
			this.Owner.DownButton();
		}

		public void BeginInit()
		{
			this.Owner.BeginInit();
		}

		public void DownButton()
		{
			this.Owner.DownButton();
		}

		public void EndInit()
		{
			this.Owner.EndInit();
		}

		public override string ToString()
		{
			return this.Owner.ToString();
		}

		public void UpButton()
		{
			this.Owner.UpButton();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValueChanged(EventArgs e)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		private void Owner_ValueChanged(object sender, EventArgs e)
		{
			this.OnValueChanged(EventArgs.Empty);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			this.Owner.Select();
			this.Owner.Focus();
			base.OnGotFocus(e);
		}

		private void method_6(object sender, EventArgs e)
		{
			this.OnGotFocus(EventArgs.Empty);
		}

		private void method_7(bool bool_2)
		{
			base.Invalidate();
		}
	}
}

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("A textbox control")]
	[ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]
	public class SiticoneTextBox : ns2.TextBox
	{
		[Browsable(true)]
		[Description("The properties that will be applied when the cursor is over the control")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextBoxState HoveredState
		{
			get
			{
				return base.DefaultHoveredState;
			}
			set
			{
				base.DefaultHoveredState = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The properties that will be applied when the control is focused")]
		[Browsable(true)]
		public TextBoxState FocusedState
		{
			get
			{
				return base.DefaultFocusedState;
			}
			set
			{
				base.DefaultFocusedState = value;
			}
		}

		[Browsable(true)]
		[Description("The properties that will be applied when the cursor is in a disabled state")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextBoxState DisabledState
		{
			get
			{
				return base.DefaultDisabledState;
			}
			set
			{
				base.DefaultDisabledState = value;
			}
		}

		[Description("If true, the control will be animated while interacting with the mouse")]
		[DefaultValue(true)]
		[Browsable(true)]
		public bool Animated
		{
			get
			{
				return base.DefaultAnimated;
			}
			set
			{
				base.DefaultAnimated = value;
			}
		}

		[Description("The control's text position")]
		[DefaultValue(typeof(Point), "0, 0")]
		public Point TextOffset
		{
			get
			{
				return base.DefaultTextOffset;
			}
			set
			{
				base.DefaultTextOffset = value;
			}
		}

		[Description("The control's placeholder text")]
		[Category("Options")]
		[Browsable(true)]
		public string PlaceholderText
		{
			get
			{
				return base.DefaultPlaceholderText;
			}
			set
			{
				base.DefaultPlaceholderText = value;
			}
		}

		[DefaultValue(typeof(Color), "193, 200, 207")]
		[Description("The control's placeholder text ForeColor")]
		[Browsable(true)]
		public Color PlaceholderForeColor
		{
			get
			{
				return base.DefaultPlaceholderForeColor;
			}
			set
			{
				base.DefaultPlaceholderForeColor = value;
			}
		}

		[Browsable(true)]
		[Description("Sets the TextBox's border radius.")]
		[DefaultValue(0)]
		public int BorderRadius
		{
			get
			{
				return base.DefaultBorderRadius;
			}
			set
			{
				base.DefaultBorderRadius = value;
			}
		}

		[DefaultValue(DashStyle.Solid)]
		[Description("The control's css-like border style")]
		[Browsable(true)]
		public new DashStyle BorderStyle
		{
			get
			{
				return base.DefaultBorderStyle;
			}
			set
			{
				base.DefaultBorderStyle = value;
			}
		}

		[DefaultValue(typeof(Color), "213, 218, 223")]
		[Browsable(true)]
		[Description("Gets or sets the control border color.")]
		public Color BorderColor
		{
			get
			{
				return base.DefaultBorderColor;
			}
			set
			{
				base.DefaultBorderColor = value;
			}
		}

		[DefaultValue(1)]
		[Browsable(true)]
		[Description("Gets or sets the control border size.")]
		public int BorderThickness
		{
			get
			{
				return base.DefaultBorderThickness;
			}
			set
			{
				base.DefaultBorderThickness = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Shadow property of the control to add and customize a control's shadow")]
		[Browsable(true)]
		public ShadowDecoration ShadowDecoration
		{
			get
			{
				return base.DefaultShadowDecoration;
			}
			set
			{
				base.DefaultShadowDecoration = value;
			}
		}

		[Description("Sets the TextBox's left icon.")]
		[Browsable(true)]
		[DefaultValue(typeof(Image), "")]
		public Image IconLeft
		{
			get
			{
				return base.DefaultIconLeft;
			}
			set
			{
				base.DefaultIconLeft = value;
			}
		}

		[Browsable(true)]
		[Description("Sets TextBox's left icon size.")]
		[DefaultValue(typeof(Size), "20, 20")]
		public Size IconLeftSize
		{
			get
			{
				return base.DefaultIconLeftSize;
			}
			set
			{
				base.DefaultIconLeftSize = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Cursor), "Default")]
		[Description("Sets TextBox's left icon cursor.")]
		public Cursor IconLeftCursor
		{
			get
			{
				return base.DefaultIconLeftCursor;
			}
			set
			{
				base.DefaultIconLeftCursor = value;
			}
		}

		[DefaultValue(typeof(Point), "0, 0")]
		[Description("Sets TextBox's left icon offset (Point).")]
		[Browsable(true)]
		public Point IconLeftOffset
		{
			get
			{
				return base.DefaultIconLeftOffset;
			}
			set
			{
				base.DefaultIconLeftOffset = value;
			}
		}

		[DefaultValue(typeof(Image), "")]
		[Description("Sets the TextBox's right icon.")]
		[Browsable(true)]
		public Image IconRight
		{
			get
			{
				return base.DefaultIconRight;
			}
			set
			{
				base.DefaultIconRight = value;
			}
		}

		[Browsable(true)]
		[Description("Sets TextBox's right icon size.")]
		[DefaultValue(typeof(Size), "20, 20")]
		public Size IconRightSize
		{
			get
			{
				return base.DefaultIconRightSize;
			}
			set
			{
				base.DefaultIconRightSize = value;
			}
		}

		[Description("Sets TextBox's right icon cursor.")]
		[DefaultValue(typeof(Cursor), "Default")]
		[Browsable(true)]
		public Cursor IconRightCursor
		{
			get
			{
				return base.DefaultIconRightCursor;
			}
			set
			{
				base.DefaultIconRightCursor = value;
			}
		}

		[Browsable(true)]
		[Description("Sets TextBox's right icon offset (Point).")]
		[DefaultValue(typeof(Point), "0, 0")]
		public Point IconRightOffset
		{
			get
			{
				return base.DefaultIconRightOffset;
			}
			set
			{
				base.DefaultIconRightOffset = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		[Description("Sets the TextBox's fill color or inner-background color.")]
		public Color FillColor
		{
			get
			{
				return base.DefaultFillColor;
			}
			set
			{
				base.DefaultFillColor = value;
			}
		}

		public SiticoneTextBox()
		{
			base.DefaultDisabledState.Parent = this;
			base.DefaultDisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			base.DefaultDisabledState.FillColor = Color.FromArgb(226, 226, 226);
			base.DefaultDisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			base.DefaultDisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			base.DefaultHoveredState.Parent = this;
			base.DefaultHoveredState.BorderColor = Class0.color_19;
			base.DefaultFocusedState.Parent = this;
			base.DefaultFocusedState.BorderColor = Class0.color_19;
			Class13.smethod_0();
		}
	}
}

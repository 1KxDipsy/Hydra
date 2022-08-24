using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using ns0;
using ns2;
using ns5;

namespace ns1
{
	[ToolboxItem(true)]
	[Description("Advanced ComboBox Control")]
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(System.Windows.Forms.ComboBox))]
	public class SiticoneComboBox : ns2.ComboBox
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The properties that will be applied when the cursor is over the control")]
		[Browsable(true)]
		public ComboBoxState HoveredState
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
		[Browsable(true)]
		[Description("The appearance of the control's items")]
		public ComboBoxItemsAppearance ItemsAppearance
		{
			get
			{
				return base.DefaultItemsAppearance;
			}
			set
			{
				base.DefaultItemsAppearance = value;
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

		[Browsable(true)]
		[DefaultValue(5)]
		[Description("This property allows you to change how text is printed onto the control")]
		public TextRenderingHint TextRenderingHint
		{
			get
			{
				return base.DefaultTextRenderingHint;
			}
			set
			{
				base.DefaultTextRenderingHint = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(0)]
		[Description("The control's text transform property which allows you to change the appearance of the text")]
		public TextTransform TextTransform
		{
			get
			{
				return base.DefaultTextTransform;
			}
			set
			{
				base.DefaultTextTransform = value;
			}
		}

		[Description("The curve angle of the control on all angles")]
		[DefaultValue(0)]
		[Browsable(true)]
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

		[Description("The starting or pre-selected index or position in the items list")]
		[Browsable(true)]
		[DefaultValue(-1)]
		public int StartIndex
		{
			get
			{
				return base.DefaultStartIndex;
			}
			set
			{
				base.DefaultStartIndex = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		[Description("The BackColor that will fill the control")]
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

		[Browsable(true)]
		[Description("The border color")]
		[DefaultValue(typeof(Color), "217, 221, 226")]
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

		[DefaultValue(typeof(Color), "136, 191, 255")]
		[Browsable(true)]
		[Description("The control's color when focused")]
		public Color FocusedColor
		{
			get
			{
				return base.DefaultFocusedColor;
			}
			set
			{
				base.DefaultFocusedColor = value;
			}
		}

		[Description("The border thickness. The higher the value, the thicker the border")]
		[Browsable(true)]
		[DefaultValue(1)]
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

		[DefaultValue(DashStyle.Solid)]
		[Browsable(true)]
		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
		public DashStyle BorderStyle
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

		public SiticoneComboBox()
		{
			Class13.smethod_0();
		}
	}
}

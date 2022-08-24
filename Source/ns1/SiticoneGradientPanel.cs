using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[ToolboxItem(true)]
	[DebuggerStepThrough]
	[Description("A gradient panel control")]
	[ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
	public class SiticoneGradientPanel : GradientPanel
	{
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
		[DefaultValue(typeof(Color), "")]
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

		[Description("The second BackColor that will fill the control in a gradient mode")]
		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		public Color FillColor2
		{
			get
			{
				return base.DefaultFillColor2;
			}
			set
			{
				base.DefaultFillColor2 = value;
			}
		}

		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[Description("The control's border color")]
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

		[Browsable(true)]
		[DefaultValue(0)]
		[Description("The border thickness. The higher the value, the thicker the border")]
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

		[DefaultValue(typeof(Color), "")]
		[Description("The control's custom border color")]
		[Browsable(true)]
		public Color CustomBorderColor
		{
			get
			{
				return base.DefaultCustomBorderColor;
			}
			set
			{
				base.DefaultCustomBorderColor = value;
			}
		}

		[Description("The control's custom border thickness")]
		[DefaultValue(typeof(Padding), "0, 0, 0, 0")]
		[Browsable(true)]
		public Padding CustomBorderThickness
		{
			get
			{
				return base.DefaultCustomBorderThickness;
			}
			set
			{
				base.DefaultCustomBorderThickness = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(0)]
		[Description("The curve angle of the control on all angles")]
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

		[Description("The control's gradient mode")]
		[DefaultValue(0)]
		[Browsable(true)]
		public LinearGradientMode GradientMode
		{
			get
			{
				return base.DefaultGradientMode;
			}
			set
			{
				base.DefaultGradientMode = value;
			}
		}

		[Browsable(true)]
		[Description("If true, the background will allow a transparent color")]
		[DefaultValue(false)]
		public bool UseTransparentBackground
		{
			get
			{
				return base.DefaultUseTransparentBackground;
			}
			set
			{
				base.DefaultUseTransparentBackground = value;
			}
		}

		[DefaultValue(DashStyle.Solid)]
		[Browsable(true)]
		[Description("The css-like style of the border. You can customize the border to meet your design needs")]
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

		public SiticoneGradientPanel()
		{
			Class13.smethod_0();
		}
	}
}

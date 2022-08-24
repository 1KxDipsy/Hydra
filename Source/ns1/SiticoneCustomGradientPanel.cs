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
	[Description("Advanced panel control that supports gradient colors")]
	[ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
	[ToolboxItem(true)]
	public class SiticoneCustomGradientPanel : CustomGradientPanel
	{
		[Browsable(true)]
		[Description("The BackColor that will fill the control")]
		[DefaultValue(typeof(Color), "White")]
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

		[DefaultValue(typeof(Color), "White")]
		[Description("The second BackColor that will fill the control in a gradient mode")]
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

		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		[Description("The third BackColor that will fill the control in a gradient mode")]
		public Color FillColor3
		{
			get
			{
				return base.DefaultFillColor3;
			}
			set
			{
				base.DefaultFillColor3 = value;
			}
		}

		[Description("The fourth BackColor that will fill the control in a gradient mode")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		public Color FillColor4
		{
			get
			{
				return base.DefaultFillColor4;
			}
			set
			{
				base.DefaultFillColor4 = value;
			}
		}

		[Description("Quality")]
		[DefaultValue(10)]
		public int Quality
		{
			get
			{
				return base.DefaultQuality;
			}
			set
			{
				base.DefaultQuality = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(DashStyle.Solid)]
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

		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[Description("The border color")]
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
		[Description("The border thickness. The higher the value, the thicker the border")]
		[DefaultValue(0)]
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

		[Browsable(true)]
		[Description("The border custom color")]
		[DefaultValue(typeof(Color), "")]
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

		[DefaultValue(typeof(Padding), "0, 0, 0, 0")]
		[Description("The border thickness. The higher the value, the thicker the border")]
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

		public SiticoneCustomGradientPanel()
		{
			Class13.smethod_0();
		}
	}
}

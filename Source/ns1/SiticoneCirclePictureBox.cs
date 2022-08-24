using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[ToolboxBitmap(typeof(System.Windows.Forms.PictureBox))]
	[ToolboxItem(true)]
	[DebuggerStepThrough]
	[Description("Advanced circle picturebox")]
	public class SiticoneCirclePictureBox : CirclePictureBox
	{
		[Browsable(true)]
		[DefaultValue(false)]
		[Description("If true, the background will allow a transparent color")]
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

		[Description("The BackColor that will fill the control")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "")]
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

		[Description("Shadow property of the control to add and customize a control's shadow")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		public SiticoneCirclePictureBox()
		{
			base.Size = new Size(200, 200);
			Class13.smethod_0();
		}
	}
}

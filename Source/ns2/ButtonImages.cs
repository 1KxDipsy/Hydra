using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns2
{
	[Description("ButtonCustomImages")]
	[DebuggerStepThrough]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ButtonImages
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private CustomButtonBase customButtonBase_0;

		private Image image_0;

		private Image image_1;

		private Image image_2;

		private Size size_0 = new Size(20, 20);

		private Point point_0;

		private HorizontalAlignment horizontalAlignment_0 = HorizontalAlignment.Right;

		[Browsable(false)]
		public CustomButtonBase Parent
		{
			[CompilerGenerated]
			get
			{
				return this.customButtonBase_0;
			}
			[CompilerGenerated]
			set
			{
				this.customButtonBase_0 = value;
			}
		}

		[NotifyParentProperty(true)]
		[Description("Image")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DefaultValue(typeof(Image), "")]
		public Image Image
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
				this.method_0();
			}
		}

		[DefaultValue(typeof(Image), "")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The Image that will be applied when the cursor hovers over the control")]
		[Browsable(true)]
		public Image HoveredImage
		{
			get
			{
				return this.image_1;
			}
			set
			{
				this.image_1 = value;
				this.method_0();
			}
		}

		[Description("The Image that will be applied when the control is checked")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Image), "")]
		public Image CheckedImage
		{
			get
			{
				return this.image_2;
			}
			set
			{
				this.image_2 = value;
				this.method_0();
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The Image size")]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Size), "20, 20")]
		public Size ImageSize
		{
			get
			{
				return this.size_0;
			}
			set
			{
				this.size_0 = value;
				this.method_0();
			}
		}

		[Browsable(true)]
		[Description("The Image positioning")]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Point), "0, 0")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Point ImageOffset
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				this.method_0();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Description("The Image location or horizontal-alignment on the control")]
		[DefaultValue(1)]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		public HorizontalAlignment ImageAlign
		{
			get
			{
				return this.horizontalAlignment_0;
			}
			set
			{
				this.horizontalAlignment_0 = value;
				this.method_0();
			}
		}

		public override string ToString()
		{
			return string.Empty;
		}

		private void method_0()
		{
			if (this.Parent != null)
			{
				this.Parent.Invalidate();
			}
		}
	}
}

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns2
{
	[Description("ImageControlState")]
	[DebuggerStepThrough]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ImageControlState
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UIDefaultControl uidefaultControl_0;

		private Image image_0;

		private Size size_0 = new Size(20, 20);

		private Point point_0;

		[Browsable(false)]
		public UIDefaultControl Parent
		{
			[CompilerGenerated]
			get
			{
				return this.uidefaultControl_0;
			}
			[CompilerGenerated]
			set
			{
				this.uidefaultControl_0 = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Image), "")]
		[Description("The control's image")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
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

		[Description("The control's image size")]
		[DefaultValue(typeof(Size), "20, 20")]
		[NotifyParentProperty(true)]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
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

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[Description("The control's image offset")]
		[DefaultValue(typeof(Point), "0, 0")]
		[NotifyParentProperty(true)]
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

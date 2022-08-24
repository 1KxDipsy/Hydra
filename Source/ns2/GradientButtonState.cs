using System.ComponentModel;
using System.Drawing;

namespace ns2
{
	public class GradientButtonState : ButtonState
	{
		private Color color_4;

		[NotifyParentProperty(true)]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[Description("The second fill color in a gradient mode")]
		public Color FillColor2
		{
			get
			{
				return this.color_4;
			}
			set
			{
				this.color_4 = value;
				base.method_0();
			}
		}
	}
}

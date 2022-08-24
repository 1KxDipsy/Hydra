using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using ns0;
using ns2;

namespace ns1
{
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[Description("An OS style toggle switch")]
	public class SiticoneOSToggleSwith : ToggleSwitch
	{
		[Description("If true, the control will be animated while interacting with the mouse")]
		[Browsable(true)]
		[DefaultValue(true)]
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

		[DefaultValue(typeof(Color), "94, 148, 255")]
		[Browsable(true)]
		[Description("The color that will fill the control when it is in a checked state or toggled ON")]
		public Color CheckedFillColor
		{
			get
			{
				return base.DefaultCheckedState.FillColor;
			}
			set
			{
				base.DefaultCheckedState.FillColor = value;
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[Description("The inner color that will fill the control when it is in a checked state or toggled ON")]
		[DefaultValue(typeof(Color), "White")]
		public Color CheckedInnerColor
		{
			get
			{
				return base.DefaultCheckedState.InnerColor;
			}
			set
			{
				base.DefaultCheckedState.InnerColor = value;
				base.Invalidate();
			}
		}

		[DefaultValue(typeof(Color), "125, 137, 149")]
		[Description("The color that will fill the control when it is in an unchecked state or toggled OFF")]
		[Browsable(true)]
		public Color UncheckedFillColor
		{
			get
			{
				return base.DefaultUncheckedState.FillColor;
			}
			set
			{
				base.DefaultUncheckedState.FillColor = value;
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		[Description("The inner color that will fill the control when it is in an unchecked state or toggled OFF")]
		public Color UncheckInnerColor
		{
			get
			{
				return base.DefaultUncheckedState.InnerColor;
			}
			set
			{
				base.DefaultUncheckedState.InnerColor = value;
				base.Invalidate();
			}
		}

		[Browsable(true)]
		[DefaultValue(false)]
		[Description("The properties that will be applied when the control is checked")]
		public bool Checked
		{
			get
			{
				return base.DefaultChecked;
			}
			set
			{
				base.DefaultChecked = value;
			}
		}

		public SiticoneOSToggleSwith()
		{
			base.DefaultCheckedState.Parent = this;
			base.DefaultCheckedState.BorderColor = Class0.color_19;
			base.DefaultCheckedState.FillColor = Class0.color_19;
			base.DefaultCheckedState.InnerBorderColor = Color.White;
			base.DefaultCheckedState.InnerColor = Color.White;
			base.DefaultCheckedState.InnerOffset = -2;
			base.DefaultUncheckedState.Parent = this;
			base.DefaultUncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			base.DefaultUncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			base.DefaultUncheckedState.InnerBorderColor = Color.White;
			base.DefaultUncheckedState.InnerColor = Color.White;
			base.DefaultUncheckedState.InnerOffset = -2;
			base.Size = new Size(38, 22);
		}

		protected override void OnResize(EventArgs e)
		{
			if (base.DefaultCheckedState != null && base.DefaultUncheckedState != null)
			{
				base.DefaultCheckedState.BorderRadius = base.Height / 2 - 1;
				base.DefaultUncheckedState.BorderRadius = base.DefaultCheckedState.BorderRadius;
				base.DefaultCheckedState.InnerBorderRadius = base.Height / 2 - 4;
				base.DefaultUncheckedState.InnerBorderRadius = base.DefaultCheckedState.InnerBorderRadius;
				base.Invalidate();
			}
			base.OnResize(e);
		}
	}
}

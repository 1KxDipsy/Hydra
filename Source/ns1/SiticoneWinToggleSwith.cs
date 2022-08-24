using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using ns0;
using ns2;

namespace ns1
{
	[Description("A Windows ToggleSwith Control")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	public class SiticoneWinToggleSwith : ToggleSwitch
	{
		[Browsable(true)]
		[DefaultValue(true)]
		[Description("If true, the control will be animated while interacting with the mouse")]
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

		[Description("The color that will be filled if the control is in a checked state")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "94, 148, 255")]
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

		[Description("The color that will be filled in the inner part of the control if its state is checked")]
		[Browsable(true)]
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

		[Browsable(true)]
		[Description("The control's border color that will be filled if the control is in an unchecked state")]
		[DefaultValue(typeof(Color), "125, 137, 149")]
		public Color UncheckedBorderColor
		{
			get
			{
				return base.DefaultUncheckedState.BorderColor;
			}
			set
			{
				base.DefaultUncheckedState.BorderColor = value;
				base.Invalidate();
			}
		}

		[Description("The color that will be filled in the inner part of the control if it is in an unchecked state")]
		[DefaultValue(typeof(Color), "125, 137, 149")]
		[Browsable(true)]
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

		[Description("The properties that will be applied when the control is checked")]
		[DefaultValue(false)]
		[Browsable(true)]
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

		public SiticoneWinToggleSwith()
		{
			base.DefaultCheckedState.Parent = this;
			base.DefaultCheckedState.FillColor = Class0.color_19;
			base.DefaultCheckedState.InnerBorderColor = Color.White;
			base.DefaultCheckedState.InnerColor = Color.White;
			base.DefaultCheckedState.InnerOffset = 4;
			base.DefaultUncheckedState.Parent = this;
			base.DefaultUncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			base.DefaultUncheckedState.BorderThickness = 2;
			base.DefaultUncheckedState.FillColor = Color.Empty;
			base.DefaultUncheckedState.InnerBorderColor = Color.White;
			base.DefaultUncheckedState.InnerColor = Color.FromArgb(125, 137, 149);
			base.DefaultUncheckedState.InnerOffset = 4;
			base.Size = new Size(45, 22);
		}

		protected override void OnResize(EventArgs e)
		{
			if (base.DefaultCheckedState != null && base.DefaultUncheckedState != null)
			{
				base.DefaultCheckedState.BorderRadius = base.Height / 2 - 1;
				base.DefaultUncheckedState.BorderRadius = base.DefaultCheckedState.BorderRadius;
				base.DefaultCheckedState.InnerBorderRadius = base.Height / 2 - 7;
				base.DefaultUncheckedState.InnerBorderRadius = base.DefaultCheckedState.InnerBorderRadius;
				base.Invalidate();
			}
			base.OnResize(e);
		}
	}
}

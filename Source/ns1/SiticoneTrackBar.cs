using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[Description("A TrackBar Control")]
	[DebuggerStepThrough]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(System.Windows.Forms.TrackBar))]
	public class SiticoneTrackBar : ns2.TrackBar
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Font font_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color color_2;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Description("The properties that will be applied when the cursor is over the control")]
		public TrackBarState HoveredState
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

		[Description("The trackbar's font style")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Font Font
		{
			[CompilerGenerated]
			get
			{
				return this.font_0;
			}
			[CompilerGenerated]
			set
			{
				this.font_0 = value;
			}
		}

		[Browsable(false)]
		[Description("The trackbar's text")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new string Text
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The trackbar's ForeColor")]
		public new Color ForeColor
		{
			[CompilerGenerated]
			get
			{
				return this.color_2;
			}
			[CompilerGenerated]
			set
			{
				this.color_2 = value;
			}
		}

		[DefaultValue(true)]
		[Category("Behaviour")]
		[Browsable(false)]
		public bool UseSelectable
		{
			get
			{
				return base.DefaultUseSelectable;
			}
			set
			{
				base.DefaultUseSelectable = value;
			}
		}

		[Category("Appearance")]
		[DefaultValue(false)]
		public bool DisplayFocus
		{
			get
			{
				return base.DefaultDisplayFocus;
			}
			set
			{
				base.DefaultDisplayFocus = value;
			}
		}

		[Description("The trackbar's current value")]
		[DefaultValue(50)]
		public int Value
		{
			get
			{
				return base.DefaultValue;
			}
			set
			{
				base.DefaultValue = value;
			}
		}

		[Description("The trackbar's minimum value")]
		[DefaultValue(0)]
		public int Minimum
		{
			get
			{
				return base.DefaultMinimum;
			}
			set
			{
				base.DefaultMinimum = value;
			}
		}

		[Description("The trackbar's maximum value")]
		[DefaultValue(100)]
		public int Maximum
		{
			get
			{
				return base.DefaultMaximum;
			}
			set
			{
				base.DefaultMaximum = value;
			}
		}

		[DefaultValue(1)]
		[Description("The trackbar's small change")]
		public int SmallChange
		{
			get
			{
				return base.DefaultSmallChange;
			}
			set
			{
				base.DefaultSmallChange = value;
			}
		}

		[DefaultValue(5)]
		[Description("The trackbar's large change")]
		public int LargeChange
		{
			get
			{
				return base.DefaultLargeChange;
			}
			set
			{
				base.DefaultLargeChange = value;
			}
		}

		[DefaultValue(10)]
		[Description("The trackbar's mouse wheel trackbar change")]
		public int MouseWheelBarPartitions
		{
			get
			{
				return base.DefaultMouseWheelBarPartitions;
			}
			set
			{
				base.DefaultMouseWheelBarPartitions = value;
			}
		}

		[DefaultValue(typeof(Color), "160, 113 225")]
		[Browsable(true)]
		[Description("The trackbar's thumb color")]
		public Color ThumbColor
		{
			get
			{
				return base.DefaultThumbColor;
			}
			set
			{
				base.DefaultThumbColor = value;
			}
		}

		[Description("The trackbar's fill color")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "192, 200, 207")]
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

		public SiticoneTrackBar()
		{
			Class13.smethod_0();
		}
	}
}

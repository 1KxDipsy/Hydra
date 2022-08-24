using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns0;
using ns2;

namespace ns1
{
	[DebuggerStepThrough]
	[ToolboxBitmap(typeof(System.Windows.Forms.HScrollBar))]
	[ToolboxItem(true)]
	[Description("")]
	public class SiticoneHScrollBar : ns2.HScrollBar
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Padding padding_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Font font_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Color color_0;

		private float float_0 = 10f;

		[Browsable(true)]
		[Description("The properties that will be applied when the cursor is over the control")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScrollBarState HoveredState
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
		[Description("The properties that will be applied when the control is in pressed state")]
		public ScrollBarState PressedState
		{
			get
			{
				return base.DefaultPressedState;
			}
			set
			{
				base.DefaultPressedState = value;
			}
		}

		[Description("The control's padding property")]
		public new Padding Padding
		{
			[CompilerGenerated]
			get
			{
				return this.padding_1;
			}
			[CompilerGenerated]
			set
			{
				this.padding_1 = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Description("The control's font")]
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Description("The control's text")]
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Description("The control's ForeColor")]
		public new Color ForeColor
		{
			[CompilerGenerated]
			get
			{
				return this.color_0;
			}
			[CompilerGenerated]
			set
			{
				this.color_0 = value;
			}
		}

		[DefaultValue(10f)]
		[Description("The control's thumb size")]
		[Browsable(true)]
		public float ThumbSize
		{
			get
			{
				return base.DefaultThumbSize;
			}
			set
			{
				base.DefaultThumbSize = value;
			}
		}

		[Description("The curve angle of the control on all angles")]
		[Browsable(true)]
		[DefaultValue(0)]
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

		[Browsable(true)]
		[Description("The MouseWheel Bar Partitions when using the mouse wheel")]
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

		[Description("The size of the scrollbar")]
		[Browsable(true)]
		public int ScrollbarSize
		{
			get
			{
				return base.DefaultScrollbarSize;
			}
			set
			{
				base.DefaultScrollbarSize = value;
			}
		}

		[DefaultValue(false)]
		[Description("If true, the bar will be highlighted on mouse wheel")]
		public bool HighlightOnWheel
		{
			get
			{
				return base.DefaultHighlightOnWheel;
			}
			set
			{
				base.DefaultHighlightOnWheel = value;
			}
		}

		[Browsable(true)]
		[Description("The minimum scrollbar value")]
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

		[Description("The maximum scrollbar value")]
		[Browsable(true)]
		[DefaultValue(100)]
		public int Maximum
		{
			get
			{
				return base.DefaultMaximum;
			}
			set
			{
				if (base.DefaultMaximum != value)
				{
					this.OnMaximumChanged(EventArgs.Empty);
				}
				base.DefaultMaximum = value;
			}
		}

		[Description("The minimum scrollbar value change")]
		[DefaultValue(1)]
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

		[Description("The maximum scrollbar value change")]
		[DefaultValue(5)]
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

		[Description("The scrollbar thumb color")]
		[Browsable(true)]
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

		[Browsable(true)]
		[Description("The control's fill color")]
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

		[Description("The scrollbar current value")]
		[DefaultValue(0)]
		[Browsable(true)]
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

		[DefaultValue(typeof(Padding), "0, 0, 0, 0")]
		[Browsable(true)]
		[Description("The bar positioning property")]
		public Padding FillOffset
		{
			get
			{
				return base.DefaultFillOffset;
			}
			set
			{
				base.DefaultFillOffset = value;
			}
		}

		public SiticoneHScrollBar()
		{
			Class13.smethod_0();
		}
	}
}

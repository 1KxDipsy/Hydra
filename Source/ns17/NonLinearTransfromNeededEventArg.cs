using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns17
{
	public class NonLinearTransfromNeededEventArg : EventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float float_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Rectangle rectangle_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private byte[] byte_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Rectangle rectangle_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte[] byte_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Animation animation_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Control control_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private AnimateMode animateMode_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_0;

		public float CurrentTime
		{
			[CompilerGenerated]
			get
			{
				return this.float_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.float_0 = value;
			}
		}

		public Rectangle ClientRectangle
		{
			[CompilerGenerated]
			get
			{
				return this.rectangle_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.rectangle_0 = value;
			}
		}

		public byte[] Pixels
		{
			[CompilerGenerated]
			get
			{
				return this.byte_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.byte_0 = value;
			}
		}

		public int Stride
		{
			[CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.int_0 = value;
			}
		}

		public Rectangle SourceClientRectangle
		{
			[CompilerGenerated]
			get
			{
				return this.rectangle_1;
			}
			[CompilerGenerated]
			internal set
			{
				this.rectangle_1 = value;
			}
		}

		public byte[] SourcePixels
		{
			[CompilerGenerated]
			get
			{
				return this.byte_1;
			}
			[CompilerGenerated]
			internal set
			{
				this.byte_1 = value;
			}
		}

		public int SourceStride
		{
			[CompilerGenerated]
			get
			{
				return this.int_1;
			}
			[CompilerGenerated]
			set
			{
				this.int_1 = value;
			}
		}

		public Animation Animation
		{
			[CompilerGenerated]
			get
			{
				return this.animation_0;
			}
			[CompilerGenerated]
			set
			{
				this.animation_0 = value;
			}
		}

		public Control Control
		{
			[CompilerGenerated]
			get
			{
				return this.control_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.control_0 = value;
			}
		}

		public AnimateMode Mode
		{
			[CompilerGenerated]
			get
			{
				return this.animateMode_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.animateMode_0 = value;
			}
		}

		public bool UseDefaultTransform
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}
	}
}

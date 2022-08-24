using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns17
{
	public class TransfromNeededEventArg : EventArgs
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Matrix matrix_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float float_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Rectangle rectangle_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Rectangle rectangle_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Animation animation_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Control control_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private AnimateMode animateMode_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_0;

		public Matrix Matrix
		{
			[CompilerGenerated]
			get
			{
				return this.matrix_0;
			}
			[CompilerGenerated]
			set
			{
				this.matrix_0 = value;
			}
		}

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

		public Rectangle ClipRectangle
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

		public bool UseDefaultMatrix
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

		public TransfromNeededEventArg()
		{
			this.Matrix = new Matrix(1f, 0f, 0f, 1f, 0f, 0f);
		}
	}
}

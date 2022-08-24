using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns17
{
	public class AnimationCompletedEventArg : EventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Animation animation_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Control control_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private AnimateMode animateMode_0;

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
	}
}

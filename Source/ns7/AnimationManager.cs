using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ns7
{
	public class AnimationManager
	{
		public delegate void AnimationFinished(object sender);

		public delegate void AnimationProgress(object sender);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double double_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private double double_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private AnimationType animationType_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool bool_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private AnimationFinished animationFinished_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private AnimationProgress animationProgress_0;

		private readonly List<double> list_0;

		private readonly List<Point> list_1;

		private readonly List<AnimationDirection> list_2;

		private readonly List<object[]> list_3;

		private const double double_2 = 0.0;

		private const double double_3 = 1.0;

		private readonly System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer
		{
			Interval = 5,
			Enabled = false
		};

		public bool InterruptAnimation
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

		public double Increment
		{
			[CompilerGenerated]
			get
			{
				return this.double_0;
			}
			[CompilerGenerated]
			set
			{
				this.double_0 = value;
			}
		}

		public double SecondaryIncrement
		{
			[CompilerGenerated]
			get
			{
				return this.double_1;
			}
			[CompilerGenerated]
			set
			{
				this.double_1 = value;
			}
		}

		public AnimationType AnimationType
		{
			[CompilerGenerated]
			get
			{
				return this.animationType_0;
			}
			[CompilerGenerated]
			set
			{
				this.animationType_0 = value;
			}
		}

		public bool Singular
		{
			[CompilerGenerated]
			get
			{
				return this.bool_1;
			}
			[CompilerGenerated]
			set
			{
				this.bool_1 = value;
			}
		}

		public event AnimationFinished OnAnimationFinished
		{
			[CompilerGenerated]
			add
			{
				AnimationFinished animationFinished = this.animationFinished_0;
				AnimationFinished animationFinished2;
				do
				{
					animationFinished2 = animationFinished;
					animationFinished = Interlocked.CompareExchange(value: (AnimationFinished)Delegate.Combine(animationFinished2, value), location1: ref this.animationFinished_0, comparand: animationFinished2);
				}
				while ((object)animationFinished != animationFinished2);
			}
			[CompilerGenerated]
			remove
			{
				AnimationFinished animationFinished = this.animationFinished_0;
				AnimationFinished animationFinished2;
				do
				{
					animationFinished2 = animationFinished;
					animationFinished = Interlocked.CompareExchange(value: (AnimationFinished)Delegate.Remove(animationFinished2, value), location1: ref this.animationFinished_0, comparand: animationFinished2);
				}
				while ((object)animationFinished != animationFinished2);
			}
		}

		public event AnimationProgress OnAnimationProgress
		{
			[CompilerGenerated]
			add
			{
				AnimationProgress animationProgress = this.animationProgress_0;
				AnimationProgress animationProgress2;
				do
				{
					animationProgress2 = animationProgress;
					animationProgress = Interlocked.CompareExchange(value: (AnimationProgress)Delegate.Combine(animationProgress2, value), location1: ref this.animationProgress_0, comparand: animationProgress2);
				}
				while ((object)animationProgress != animationProgress2);
			}
			[CompilerGenerated]
			remove
			{
				AnimationProgress animationProgress = this.animationProgress_0;
				AnimationProgress animationProgress2;
				do
				{
					animationProgress2 = animationProgress;
					animationProgress = Interlocked.CompareExchange(value: (AnimationProgress)Delegate.Remove(animationProgress2, value), location1: ref this.animationProgress_0, comparand: animationProgress2);
				}
				while ((object)animationProgress != animationProgress2);
			}
		}

		public AnimationManager(bool singular = true)
		{
			this.list_0 = new List<double>();
			this.list_1 = new List<Point>();
			this.list_2 = new List<AnimationDirection>();
			this.list_3 = new List<object[]>();
			this.Increment = 0.03;
			this.SecondaryIncrement = 0.03;
			this.AnimationType = AnimationType.Linear;
			this.InterruptAnimation = true;
			this.Singular = singular;
			if (this.Singular)
			{
				this.list_0.Add(0.0);
				this.list_1.Add(new Point(0, 0));
				this.list_2.Add(AnimationDirection.In);
			}
			this.timer_0.Tick += new EventHandler(timer_0_Tick);
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < this.list_0.Count; i++)
			{
				this.UpdateProgress(i);
				if (!this.Singular)
				{
					if (this.list_2[i] == AnimationDirection.InOutIn && this.list_0[i] == 1.0)
					{
						this.list_2[i] = AnimationDirection.InOutOut;
					}
					else if (this.list_2[i] == AnimationDirection.InOutRepeatingIn && this.list_0[i] == 0.0)
					{
						this.list_2[i] = AnimationDirection.InOutRepeatingOut;
					}
					else if (this.list_2[i] == AnimationDirection.InOutRepeatingOut && this.list_0[i] == 0.0)
					{
						this.list_2[i] = AnimationDirection.InOutRepeatingIn;
					}
					else if ((this.list_2[i] == AnimationDirection.In && this.list_0[i] == 1.0) || (this.list_2[i] == AnimationDirection.Out && this.list_0[i] == 0.0) || (this.list_2[i] == AnimationDirection.InOutOut && this.list_0[i] == 0.0))
					{
						this.list_0.RemoveAt(i);
						this.list_1.RemoveAt(i);
						this.list_2.RemoveAt(i);
						this.list_3.RemoveAt(i);
					}
				}
				else if (this.list_2[i] == AnimationDirection.InOutIn && this.list_0[i] == 1.0)
				{
					this.list_2[i] = AnimationDirection.InOutOut;
				}
				else if (this.list_2[i] == AnimationDirection.InOutRepeatingIn && this.list_0[i] == 1.0)
				{
					this.list_2[i] = AnimationDirection.InOutRepeatingOut;
				}
				else if (this.list_2[i] == AnimationDirection.InOutRepeatingOut && this.list_0[i] == 0.0)
				{
					this.list_2[i] = AnimationDirection.InOutRepeatingIn;
				}
			}
			this.animationProgress_0?.Invoke(this);
		}

		public bool IsAnimating()
		{
			return this.timer_0.Enabled;
		}

		public void StartNewAnimation(AnimationDirection animationDirection, object[] data = null)
		{
			this.StartNewAnimation(animationDirection, new Point(0, 0), data);
		}

		public void StartNewAnimation(AnimationDirection animationDirection, Point animationSource, object[] data = null)
		{
			if (!this.IsAnimating() || this.InterruptAnimation)
			{
				if (this.Singular && this.list_2.Count > 0)
				{
					this.list_2[0] = animationDirection;
				}
				else
				{
					this.list_2.Add(animationDirection);
				}
				if (this.Singular && this.list_1.Count > 0)
				{
					this.list_1[0] = animationSource;
				}
				else
				{
					this.list_1.Add(animationSource);
				}
				if (!this.Singular || this.list_0.Count <= 0)
				{
					switch (this.list_2[this.list_2.Count - 1])
					{
					default:
						throw new Exception("Invalid AnimationDirection");
					case AnimationDirection.In:
					case AnimationDirection.InOutIn:
					case AnimationDirection.InOutRepeatingIn:
						this.list_0.Add(0.0);
						break;
					case AnimationDirection.Out:
					case AnimationDirection.InOutOut:
					case AnimationDirection.InOutRepeatingOut:
						this.list_0.Add(1.0);
						break;
					}
				}
				if (this.Singular && this.list_3.Count > 0)
				{
					this.list_3[0] = data ?? new object[0];
				}
				else
				{
					this.list_3.Add(data ?? new object[0]);
				}
			}
			this.timer_0.Start();
		}

		public void UpdateProgress(int index)
		{
			switch (this.list_2[index])
			{
			default:
				throw new Exception("No AnimationDirection has been set");
			case AnimationDirection.In:
			case AnimationDirection.InOutIn:
			case AnimationDirection.InOutRepeatingIn:
				this.method_0(index);
				break;
			case AnimationDirection.Out:
			case AnimationDirection.InOutOut:
			case AnimationDirection.InOutRepeatingOut:
				this.method_1(index);
				break;
			}
		}

		private void method_0(int int_0)
		{
			this.list_0[int_0] += this.Increment;
			if (!(this.list_0[int_0] > 1.0))
			{
				return;
			}
			this.list_0[int_0] = 1.0;
			int num = 0;
			while (true)
			{
				if (num < this.GetAnimationCount())
				{
					if (this.list_2[num] != AnimationDirection.InOutIn && this.list_2[num] != AnimationDirection.InOutRepeatingIn && this.list_2[num] != AnimationDirection.InOutRepeatingOut && (this.list_2[num] != AnimationDirection.InOutOut || this.list_0[num] == 1.0) && (this.list_2[num] != 0 || this.list_0[num] == 1.0))
					{
						num++;
						continue;
					}
					break;
				}
				this.timer_0.Stop();
				this.animationFinished_0?.Invoke(this);
				break;
			}
		}

		private void method_1(int int_0)
		{
			this.list_0[int_0] -= ((this.list_2[int_0] == AnimationDirection.InOutOut || this.list_2[int_0] == AnimationDirection.InOutRepeatingOut) ? this.SecondaryIncrement : this.Increment);
			if (!(this.list_0[int_0] < 0.0))
			{
				return;
			}
			this.list_0[int_0] = 0.0;
			int num = 0;
			while (true)
			{
				if (num < this.GetAnimationCount())
				{
					if (this.list_2[num] != AnimationDirection.InOutIn && this.list_2[num] != AnimationDirection.InOutRepeatingIn && this.list_2[num] != AnimationDirection.InOutRepeatingOut && (this.list_2[num] != AnimationDirection.InOutOut || this.list_0[num] == 0.0) && (this.list_2[num] != AnimationDirection.Out || this.list_0[num] == 0.0))
					{
						num++;
						continue;
					}
					break;
				}
				this.timer_0.Stop();
				this.animationFinished_0?.Invoke(this);
				break;
			}
		}

		public double GetProgress()
		{
			if (!this.Singular)
			{
				throw new Exception("Animation is not set to Singular.");
			}
			if (this.list_0.Count == 0)
			{
				throw new Exception("Invalid animation");
			}
			return this.GetProgress(0);
		}

		public double GetProgress(int index)
		{
			if (index >= this.GetAnimationCount())
			{
				throw new IndexOutOfRangeException("Invalid animation index");
			}
			return this.AnimationType switch
			{
				AnimationType.Linear => AnimationLinear.CalculateProgress(this.list_0[index]), 
				AnimationType.EaseInOut => AnimationEaseInOut.CalculateProgress(this.list_0[index]), 
				AnimationType.EaseOut => AnimationEaseOut.CalculateProgress(this.list_0[index]), 
				AnimationType.CustomQuadratic => AnimationCustomQuadratic.CalculateProgress(this.list_0[index]), 
				_ => throw new NotImplementedException("The given AnimationType is not implemented"), 
			};
		}

		public Point GetSource(int index)
		{
			if (index >= this.GetAnimationCount())
			{
				throw new IndexOutOfRangeException("Invalid animation index");
			}
			return this.list_1[index];
		}

		public Point GetSource()
		{
			if (!this.Singular)
			{
				throw new Exception("Animation is not set to Singular.");
			}
			if (this.list_1.Count == 0)
			{
				throw new Exception("Invalid animation");
			}
			return this.list_1[0];
		}

		public AnimationDirection GetDirection()
		{
			if (!this.Singular)
			{
				throw new Exception("Animation is not set to Singular.");
			}
			if (this.list_2.Count == 0)
			{
				throw new Exception("Invalid animation");
			}
			return this.list_2[0];
		}

		public AnimationDirection GetDirection(int index)
		{
			if (index >= this.list_2.Count)
			{
				throw new IndexOutOfRangeException("Invalid animation index");
			}
			return this.list_2[index];
		}

		public object[] GetData()
		{
			if (!this.Singular)
			{
				throw new Exception("Animation is not set to Singular.");
			}
			if (this.list_3.Count == 0)
			{
				throw new Exception("Invalid animation");
			}
			return this.list_3[0];
		}

		public object[] GetData(int index)
		{
			if (index >= this.list_3.Count)
			{
				throw new IndexOutOfRangeException("Invalid animation index");
			}
			return this.list_3[index];
		}

		public int GetAnimationCount()
		{
			return this.list_0.Count;
		}

		public void SetProgress(double progress)
		{
			if (!this.Singular)
			{
				throw new Exception("Animation is not set to Singular.");
			}
			if (this.list_0.Count == 0)
			{
				throw new Exception("Invalid animation");
			}
			this.list_0[0] = progress;
		}

		public void SetDirection(AnimationDirection direction)
		{
			if (!this.Singular)
			{
				throw new Exception("Animation is not set to Singular.");
			}
			if (this.list_0.Count == 0)
			{
				throw new Exception("Invalid animation");
			}
			this.list_2[0] = direction;
		}

		public void SetData(object[] data)
		{
			if (!this.Singular)
			{
				throw new Exception("Animation is not set to Singular.");
			}
			if (this.list_3.Count == 0)
			{
				throw new Exception("Invalid animation");
			}
			this.list_3[0] = data;
		}
	}
}

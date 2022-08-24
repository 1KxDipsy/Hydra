using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns17
{
	public class Animation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private PointF pointF_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float float_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float float_1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PointF pointF_1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float float_2;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float float_3;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PointF pointF_2;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PointF pointF_3;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private PointF pointF_4;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float float_4;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float float_5;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float float_6;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Padding padding_0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool bool_0;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[TypeConverter(typeof(PointFConverter))]
		public PointF SlideCoeff
		{
			[CompilerGenerated]
			get
			{
				return this.pointF_0;
			}
			[CompilerGenerated]
			set
			{
				this.pointF_0 = value;
			}
		}

		public float RotateCoeff
		{
			[CompilerGenerated]
			get
			{
				return this.float_0;
			}
			[CompilerGenerated]
			set
			{
				this.float_0 = value;
			}
		}

		public float RotateLimit
		{
			[CompilerGenerated]
			get
			{
				return this.float_1;
			}
			[CompilerGenerated]
			set
			{
				this.float_1 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[TypeConverter(typeof(PointFConverter))]
		public PointF ScaleCoeff
		{
			[CompilerGenerated]
			get
			{
				return this.pointF_1;
			}
			[CompilerGenerated]
			set
			{
				this.pointF_1 = value;
			}
		}

		public float TransparencyCoeff
		{
			[CompilerGenerated]
			get
			{
				return this.float_2;
			}
			[CompilerGenerated]
			set
			{
				this.float_2 = value;
			}
		}

		public float LeafCoeff
		{
			[CompilerGenerated]
			get
			{
				return this.float_3;
			}
			[CompilerGenerated]
			set
			{
				this.float_3 = value;
			}
		}

		[TypeConverter(typeof(PointFConverter))]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public PointF MosaicShift
		{
			[CompilerGenerated]
			get
			{
				return this.pointF_2;
			}
			[CompilerGenerated]
			set
			{
				this.pointF_2 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[TypeConverter(typeof(PointFConverter))]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public PointF MosaicCoeff
		{
			[CompilerGenerated]
			get
			{
				return this.pointF_3;
			}
			[CompilerGenerated]
			set
			{
				this.pointF_3 = value;
			}
		}

		public int MosaicSize
		{
			[CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[TypeConverter(typeof(PointFConverter))]
		public PointF BlindCoeff
		{
			[CompilerGenerated]
			get
			{
				return this.pointF_4;
			}
			[CompilerGenerated]
			set
			{
				this.pointF_4 = value;
			}
		}

		public float TimeCoeff
		{
			[CompilerGenerated]
			get
			{
				return this.float_4;
			}
			[CompilerGenerated]
			set
			{
				this.float_4 = value;
			}
		}

		public float MinTime
		{
			[CompilerGenerated]
			get
			{
				return this.float_5;
			}
			[CompilerGenerated]
			set
			{
				this.float_5 = value;
			}
		}

		public float MaxTime
		{
			[CompilerGenerated]
			get
			{
				return this.float_6;
			}
			[CompilerGenerated]
			set
			{
				this.float_6 = value;
			}
		}

		public Padding Padding
		{
			[CompilerGenerated]
			get
			{
				return this.padding_0;
			}
			[CompilerGenerated]
			set
			{
				this.padding_0 = value;
			}
		}

		public bool AnimateOnlyDifferences
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

		public bool IsNonLinearTransformNeeded
		{
			get
			{
				if (this.BlindCoeff == PointF.Empty && (this.MosaicCoeff == PointF.Empty || this.MosaicSize == 0) && this.TransparencyCoeff == 0f && this.LeafCoeff == 0f)
				{
					return false;
				}
				return true;
			}
		}

		public static Animation Rotate => new Animation
		{
			RotateCoeff = 1f,
			TransparencyCoeff = 1f,
			Padding = new Padding(50, 50, 50, 50)
		};

		public static Animation HorizSlide => new Animation
		{
			SlideCoeff = new PointF(1f, 0f)
		};

		public static Animation VertSlide => new Animation
		{
			SlideCoeff = new PointF(0f, 1f)
		};

		public static Animation Scale => new Animation
		{
			ScaleCoeff = new PointF(1f, 1f)
		};

		public static Animation ScaleAndRotate => new Animation
		{
			ScaleCoeff = new PointF(1f, 1f),
			RotateCoeff = 0.5f,
			RotateLimit = 0.2f,
			Padding = new Padding(30, 30, 30, 30)
		};

		public static Animation HorizSlideAndRotate => new Animation
		{
			SlideCoeff = new PointF(1f, 0f),
			RotateCoeff = 0.3f,
			RotateLimit = 0.2f,
			Padding = new Padding(50, 50, 50, 50)
		};

		public static Animation ScaleAndHorizSlide => new Animation
		{
			ScaleCoeff = new PointF(1f, 1f),
			SlideCoeff = new PointF(1f, 0f),
			Padding = new Padding(30, 0, 0, 0)
		};

		public static Animation Transparent => new Animation
		{
			TransparencyCoeff = 1f
		};

		public static Animation Leaf => new Animation
		{
			LeafCoeff = 1f
		};

		public static Animation Mosaic => new Animation
		{
			MosaicCoeff = new PointF(100f, 100f),
			MosaicSize = 20,
			Padding = new Padding(30, 30, 30, 30)
		};

		public static Animation Particles => new Animation
		{
			MosaicCoeff = new PointF(200f, 200f),
			MosaicSize = 1,
			MosaicShift = new PointF(0f, 0.5f),
			Padding = new Padding(100, 50, 100, 150),
			TimeCoeff = 2f
		};

		public static Animation VertBlind => new Animation
		{
			BlindCoeff = new PointF(0f, 1f)
		};

		public static Animation HorizBlind => new Animation
		{
			BlindCoeff = new PointF(1f, 0f)
		};

		public Animation()
		{
			this.MinTime = 0f;
			this.MaxTime = 1f;
			this.AnimateOnlyDifferences = true;
		}

		public override string ToString()
		{
			return string.Empty;
		}

		public Animation Clone()
		{
			return (Animation)base.MemberwiseClone();
		}

		public void Add(Animation a)
		{
			this.SlideCoeff = new PointF(this.SlideCoeff.X + a.SlideCoeff.X, this.SlideCoeff.Y + a.SlideCoeff.Y);
			this.RotateCoeff += a.RotateCoeff;
			this.RotateLimit += a.RotateLimit;
			this.ScaleCoeff = new PointF(this.ScaleCoeff.X + a.ScaleCoeff.X, this.ScaleCoeff.Y + a.ScaleCoeff.Y);
			this.TransparencyCoeff += a.TransparencyCoeff;
			this.LeafCoeff += a.LeafCoeff;
			this.MosaicShift = new PointF(this.MosaicShift.X + a.MosaicShift.X, this.MosaicShift.Y + a.MosaicShift.Y);
			this.MosaicCoeff = new PointF(this.MosaicCoeff.X + a.MosaicCoeff.X, this.MosaicCoeff.Y + a.MosaicCoeff.Y);
			this.MosaicSize += a.MosaicSize;
			this.BlindCoeff = new PointF(this.BlindCoeff.X + a.BlindCoeff.X, this.BlindCoeff.Y + a.BlindCoeff.Y);
			this.TimeCoeff += a.TimeCoeff;
			this.Padding += a.Padding;
		}
	}
}

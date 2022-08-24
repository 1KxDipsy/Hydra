using System;
using ns11;
using ns13;
using ns14;
using ns16;

namespace ns0
{
	internal sealed class Class45 : IDisposable
	{
		private readonly Class50 class50_0;

		private readonly Class39 class39_0;

		private RPoint rpoint_0;

		private Class59 class59_0;

		private Class59 class59_1;

		private int int_0 = -1;

		private int int_1 = -1;

		private double double_0 = -1.0;

		private double double_1 = -1.0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private bool bool_5;

		private DateTime dateTime_0;

		private object object_0;

		public Class45(Class50 class50_1)
		{
			ArgChecker.AssertArgNotNull(class50_1, "root");
			this.class50_0 = class50_1;
			this.class39_0 = new Class39(this, class50_1.HtmlContainerInt_0);
		}

		public void method_0(RControl rcontrol_0)
		{
			if (this.class50_0.HtmlContainerInt_0.IsSelectionEnabled)
			{
				this.method_13();
				this.method_16(this.class50_0);
				rcontrol_0.Invalidate();
			}
		}

		public void method_1(RControl rcontrol_0, RPoint rpoint_1)
		{
			if (this.class50_0.HtmlContainerInt_0.IsSelectionEnabled)
			{
				Class59 @class = Class25.smethod_13(this.class50_0, rpoint_1);
				if (@class != null)
				{
					@class.Class45_0 = this;
					this.rpoint_0 = rpoint_1;
					this.class59_0 = (this.class59_1 = @class);
					rcontrol_0.Invalidate();
				}
			}
		}

		public void method_2(RControl rcontrol_0, RPoint rpoint_1, bool bool_6)
		{
			bool flag = !bool_6;
			if (bool_6)
			{
				this.bool_3 = true;
				this.bool_2 = (DateTime.Now - this.dateTime_0).TotalMilliseconds < 400.0;
				this.dateTime_0 = DateTime.Now;
				this.bool_4 = false;
				if (this.class50_0.HtmlContainerInt_0.IsSelectionEnabled && rcontrol_0.LeftMouseButton)
				{
					Class59 @class = Class25.smethod_13(this.class50_0, rpoint_1);
					if (@class != null && @class.Boolean_0)
					{
						this.bool_4 = true;
					}
					else
					{
						flag = true;
					}
				}
				else if (rcontrol_0.RightMouseButton)
				{
					Class59 class2 = Class25.smethod_13(this.class50_0, rpoint_1);
					Class50 class50_ = Class25.smethod_10(this.class50_0, rpoint_1);
					if (this.class50_0.HtmlContainerInt_0.IsContextMenuEnabled)
					{
						this.class39_0.method_0(rcontrol_0, class2, class50_);
					}
					flag = class2 == null || !class2.Boolean_0;
				}
			}
			if (flag)
			{
				this.method_13();
				rcontrol_0.Invalidate();
			}
		}

		public bool method_3(RControl rcontrol_0, bool bool_6)
		{
			bool flag = false;
			this.bool_3 = false;
			if (this.class50_0.HtmlContainerInt_0.IsSelectionEnabled)
			{
				flag = this.bool_1;
				if (!this.bool_1 && bool_6 && this.bool_4)
				{
					this.method_13();
					rcontrol_0.Invalidate();
				}
				this.bool_4 = false;
				this.bool_1 = false;
			}
			return flag = flag || DateTime.Now - this.dateTime_0 > TimeSpan.FromSeconds(1.0);
		}

		public void method_4(RControl rcontrol_0, RPoint rpoint_1)
		{
			if (this.class50_0.HtmlContainerInt_0.IsSelectionEnabled && this.bool_3 && rcontrol_0.LeftMouseButton)
			{
				if (this.bool_4)
				{
					if ((DateTime.Now - this.dateTime_0).TotalMilliseconds > 200.0)
					{
						this.method_15(rcontrol_0);
					}
				}
				else
				{
					this.method_14(rcontrol_0, rpoint_1, !this.bool_2);
					this.bool_1 = this.class59_0 != null && this.class59_1 != null && (this.class59_0 != this.class59_1 || this.int_0 != this.int_1);
				}
			}
			else if (Class25.smethod_10(this.class50_0, rpoint_1) != null)
			{
				this.bool_5 = true;
				rcontrol_0.SetCursorHand();
			}
			else if (this.class50_0.HtmlContainerInt_0.IsSelectionEnabled)
			{
				Class59 @class = Class25.smethod_13(this.class50_0, rpoint_1);
				this.bool_5 = @class != null && !@class.Boolean_3 && (!@class.Boolean_0 || (@class.Int32_0 >= 0 && !(@class.Double_0 + @class.Double_8 <= rpoint_1.Double_0)) || (!(@class.Double_9 < 0.0) && !(@class.Double_0 + @class.Double_9 >= rpoint_1.Double_0)));
				if (this.bool_5)
				{
					rcontrol_0.SetCursorIBeam();
				}
				else
				{
					rcontrol_0.SetCursorDefault();
				}
			}
			else if (this.bool_5)
			{
				rcontrol_0.SetCursorDefault();
			}
		}

		public void method_5(RControl rcontrol_0)
		{
			if (this.bool_5)
			{
				this.bool_5 = false;
				rcontrol_0.SetCursorDefault();
			}
		}

		public void method_6()
		{
			if (this.class50_0.HtmlContainerInt_0.IsSelectionEnabled)
			{
				string html = Class25.smethod_17(this.class50_0, HtmlGenerationStyle.Inline, bool_0: true);
				string text = Class25.smethod_16(this.class50_0);
				if (!string.IsNullOrEmpty(text))
				{
					this.class50_0.HtmlContainerInt_0.RAdapter_0.SetToClipboard(html, text);
				}
			}
		}

		public string method_7()
		{
			return this.class50_0.HtmlContainerInt_0.IsSelectionEnabled ? Class25.smethod_16(this.class50_0) : null;
		}

		public string method_8()
		{
			return this.class50_0.HtmlContainerInt_0.IsSelectionEnabled ? Class25.smethod_17(this.class50_0, HtmlGenerationStyle.Inline, bool_0: true) : null;
		}

		public int method_9(Class59 class59_2)
		{
			if (!this.bool_0)
			{
				if (class59_2 != this.class59_0)
				{
					goto IL_001b;
				}
			}
			else if (class59_2 != this.class59_1)
			{
				goto IL_001b;
			}
			int result = (this.bool_0 ? this.int_1 : this.int_0);
			goto IL_0034;
			IL_001b:
			result = -1;
			goto IL_0034;
			IL_0034:
			return result;
		}

		public int method_10(Class59 class59_2)
		{
			if (!this.bool_0)
			{
				if (class59_2 != this.class59_1)
				{
					goto IL_001b;
				}
			}
			else if (class59_2 != this.class59_0)
			{
				goto IL_001b;
			}
			int result = (this.bool_0 ? this.int_0 : this.int_1);
			goto IL_0034;
			IL_001b:
			result = -1;
			goto IL_0034;
			IL_0034:
			return result;
		}

		public double method_11(Class59 class59_2)
		{
			if (!this.bool_0)
			{
				if (class59_2 != this.class59_0)
				{
					goto IL_001b;
				}
			}
			else if (class59_2 != this.class59_1)
			{
				goto IL_001b;
			}
			double result = (this.bool_0 ? this.double_1 : this.double_0);
			goto IL_003c;
			IL_001b:
			result = -1.0;
			goto IL_003c;
			IL_003c:
			return result;
		}

		public double method_12(Class59 class59_2)
		{
			if (!this.bool_0)
			{
				if (class59_2 != this.class59_1)
				{
					goto IL_001b;
				}
			}
			else if (class59_2 != this.class59_0)
			{
				goto IL_001b;
			}
			double result = (this.bool_0 ? this.double_0 : this.double_1);
			goto IL_003c;
			IL_001b:
			result = -1.0;
			goto IL_003c;
			IL_003c:
			return result;
		}

		public void method_13()
		{
			this.object_0 = null;
			Class45.smethod_0(this.class50_0);
			this.double_0 = -1.0;
			this.int_0 = -1;
			this.double_1 = -1.0;
			this.int_1 = -1;
			this.rpoint_0 = RPoint.Empty;
			this.class59_0 = null;
			this.class59_1 = null;
		}

		public void Dispose()
		{
			this.class39_0.Dispose();
		}

		private void method_14(RControl rcontrol_0, RPoint rpoint_1, bool bool_6)
		{
			Class58 @class = Class25.smethod_12(this.class50_0, rpoint_1);
			if (@class == null)
			{
				return;
			}
			Class59 class2 = Class25.smethod_14(@class, rpoint_1);
			if (class2 == null && @class.List_1.Count > 0)
			{
				if (rpoint_1.Double_1 > @class.Double_1)
				{
					class2 = @class.List_1[@class.List_1.Count - 1];
				}
				else if (rpoint_1.Double_0 < @class.List_1[0].Double_0)
				{
					class2 = @class.List_1[0];
				}
				else if (rpoint_1.Double_0 > @class.List_1[@class.List_1.Count - 1].Double_6)
				{
					class2 = @class.List_1[@class.List_1.Count - 1];
				}
			}
			if (class2 == null)
			{
				return;
			}
			if (this.class59_0 == null)
			{
				this.rpoint_0 = rpoint_1;
				this.class59_0 = class2;
				if (bool_6)
				{
					this.method_20(rcontrol_0, class2, rpoint_1, bool_6: true);
				}
			}
			this.class59_1 = class2;
			if (bool_6)
			{
				this.method_20(rcontrol_0, class2, rpoint_1, bool_6: false);
			}
			Class45.smethod_0(this.class50_0);
			if (this.method_17(rpoint_1, bool_6))
			{
				this.method_21();
				this.method_18(this.class50_0, this.bool_0 ? this.class59_1 : this.class59_0, this.bool_0 ? this.class59_0 : this.class59_1);
			}
			else
			{
				this.class59_1 = null;
			}
			this.bool_5 = true;
			rcontrol_0.SetCursorIBeam();
			rcontrol_0.Invalidate();
		}

		private static void smethod_0(Class50 class50_1)
		{
			foreach (Class59 item in class50_1.List_3)
			{
				item.Class45_0 = null;
			}
			foreach (Class50 item2 in class50_1.List_0)
			{
				Class45.smethod_0(item2);
			}
		}

		private void method_15(RControl rcontrol_0)
		{
			if (this.object_0 == null)
			{
				string html = Class25.smethod_17(this.class50_0, HtmlGenerationStyle.Inline, bool_0: true);
				string plainText = Class25.smethod_16(this.class50_0);
				this.object_0 = rcontrol_0.Adapter.GetClipboardDataObject(html, plainText);
			}
			rcontrol_0.DoDragDropCopy(this.object_0);
		}

		public void method_16(Class50 class50_1)
		{
			foreach (Class59 item in class50_1.List_3)
			{
				item.Class45_0 = this;
			}
			foreach (Class50 item2 in class50_1.List_0)
			{
				this.method_16(item2);
			}
		}

		private bool method_17(RPoint rpoint_1, bool bool_6)
		{
			if (!bool_6)
			{
				return true;
			}
			if (Math.Abs(this.rpoint_0.Double_0 - rpoint_1.Double_0) <= 1.0 && Math.Abs(this.rpoint_0.Double_1 - rpoint_1.Double_1) < 5.0)
			{
				return false;
			}
			return this.class59_0 != this.class59_1 || this.int_0 != this.int_1;
		}

		private void method_18(Class50 class50_1, Class59 class59_2, Class59 class59_3)
		{
			bool bool_ = false;
			this.method_19(class50_1, class59_2, class59_3, ref bool_);
		}

		private bool method_19(Class50 class50_1, Class59 class59_2, Class59 class59_3, ref bool bool_6)
		{
			foreach (Class59 item in class50_1.List_3)
			{
				if (!bool_6 && item == class59_2)
				{
					bool_6 = true;
				}
				if (bool_6)
				{
					item.Class45_0 = this;
					if (class59_2 == class59_3 || item == class59_3)
					{
						return true;
					}
				}
			}
			foreach (Class50 item2 in class50_1.List_0)
			{
				if (this.method_19(item2, class59_2, class59_3, ref bool_6))
				{
					return true;
				}
			}
			return false;
		}

		private void method_20(RControl rcontrol_0, Class59 class59_2, RPoint rpoint_1, bool bool_6)
		{
			Class45.smethod_1(rcontrol_0, class59_2, rpoint_1, bool_6, out var int_, out var double_);
			if (bool_6)
			{
				this.int_0 = int_;
				this.double_0 = double_;
			}
			else
			{
				this.int_1 = int_;
				this.double_1 = double_;
			}
		}

		private static void smethod_1(RControl rcontrol_0, Class59 class59_2, RPoint rpoint_1, bool bool_6, out int int_2, out double double_2)
		{
			int_2 = 0;
			double_2 = 0.0;
			double num = rpoint_1.Double_0 - class59_2.Double_0;
			if (class59_2.String_0 == null)
			{
				int_2 = -1;
				double_2 = -1.0;
			}
			else if (!(num > class59_2.Double_2 - class59_2.Class50_0.Double_26) && !(rpoint_1.Double_1 > Class25.smethod_15(class59_2).Double_1))
			{
				if (num > 0.0)
				{
					rcontrol_0.MeasureString(maxWidth: num + (bool_6 ? 0.0 : (1.5 * class59_2.Double_10)), str: class59_2.String_0, font: class59_2.Class50_0.RFont_1, charFit: out var charFit, charFitWidth: out var charFitWidth);
					int_2 = charFit;
					double_2 = charFitWidth;
				}
			}
			else
			{
				int_2 = class59_2.String_0.Length;
				double_2 = class59_2.Double_2;
			}
		}

		private void method_21()
		{
			if (this.class59_0 == this.class59_1)
			{
				this.bool_0 = this.int_0 > this.int_1;
			}
			else if (Class25.smethod_15(this.class59_0) == Class25.smethod_15(this.class59_1))
			{
				this.bool_0 = this.class59_0.Double_0 > this.class59_1.Double_0;
			}
			else
			{
				this.bool_0 = this.class59_0.Double_1 >= this.class59_1.Double_7;
			}
		}
	}
}

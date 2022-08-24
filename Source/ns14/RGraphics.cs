using System;
using System.Collections.Generic;
using ns11;
using ns16;

namespace ns14
{
	public abstract class RGraphics : IDisposable
	{
		protected readonly RAdapter _adapter;

		protected readonly Stack<RRect> _clipStack = new Stack<RRect>();

		private Stack<RRect> stack_0 = new Stack<RRect>();

		protected RGraphics(RAdapter adapter, RRect initialClip)
		{
			ArgChecker.AssertArgNotNull(adapter, "global");
			this._adapter = adapter;
			this._clipStack.Push(initialClip);
		}

		public RPen GetPen(RColor color)
		{
			return this._adapter.GetPen(color);
		}

		public RBrush GetSolidBrush(RColor color)
		{
			return this._adapter.GetSolidBrush(color);
		}

		public RBrush GetLinearGradientBrush(RRect rect, RColor color1, RColor color2, double angle)
		{
			return this._adapter.GetLinearGradientBrush(rect, color1, color2, angle);
		}

		public RRect GetClip()
		{
			return this._clipStack.Peek();
		}

		public abstract void PopClip();

		public abstract void PushClip(RRect rect);

		public abstract void PushClipExclude(RRect rect);

		public void SuspendClipping()
		{
			while (this._clipStack.Count > 1)
			{
				RRect clip = this.GetClip();
				this.stack_0.Push(clip);
				this.PopClip();
			}
		}

		public void ResumeClipping()
		{
			while (this.stack_0.Count > 0)
			{
				this.PushClip(this.stack_0.Pop());
			}
		}

		public abstract object SetAntiAliasSmoothingMode();

		public abstract void ReturnPreviousSmoothingMode(object prevMode);

		public abstract RBrush GetTextureBrush(RImage image, RRect dstRect, RPoint translateTransformLocation);

		public abstract RGraphicsPath GetGraphicsPath();

		public abstract RSize MeasureString(string str, RFont font);

		public abstract void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth);

		public abstract void DrawString(string str, RFont font, RColor color, RPoint point, RSize size, bool rtl);

		public abstract void DrawLine(RPen pen, double x1, double y1, double x2, double y2);

		public abstract void DrawRectangle(RPen pen, double x, double y, double width, double height);

		public abstract void DrawRectangle(RBrush brush, double x, double y, double width, double height);

		public abstract void DrawImage(RImage image, RRect destRect, RRect srcRect);

		public abstract void DrawImage(RImage image, RRect destRect);

		public abstract void DrawPath(RPen pen, RGraphicsPath path);

		public abstract void DrawPath(RBrush brush, RGraphicsPath path);

		public abstract void DrawPolygon(RBrush brush, RPoint[] points);

		public abstract void Dispose();
	}
}

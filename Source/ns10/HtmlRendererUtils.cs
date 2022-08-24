using System;
using ns14;
using ns16;

namespace ns10
{
	public static class HtmlRendererUtils
	{
		public static RSize MeasureHtmlByRestrictions(RGraphics g, HtmlContainerInt htmlContainer, RSize minSize, RSize maxSize)
		{
			htmlContainer.PerformLayout(g);
			if (maxSize.Width > 0.0 && maxSize.Width < htmlContainer.ActualSize.Width)
			{
				htmlContainer.MaxSize = new RSize(maxSize.Width, 0.0);
				htmlContainer.PerformLayout(g);
			}
			double num = Math.Max((maxSize.Width > 0.0) ? Math.Min(maxSize.Width, (int)htmlContainer.ActualSize.Width) : ((double)(int)htmlContainer.ActualSize.Width), minSize.Width);
			if (num > htmlContainer.ActualSize.Width)
			{
				htmlContainer.MaxSize = new RSize(num, 0.0);
				htmlContainer.PerformLayout(g);
			}
			return new RSize(num, Math.Max((maxSize.Height > 0.0) ? Math.Min(maxSize.Height, (int)htmlContainer.ActualSize.Height) : ((double)(int)htmlContainer.ActualSize.Height), minSize.Height));
		}

		public static RSize Layout(RGraphics g, HtmlContainerInt htmlContainer, RSize size, RSize minSize, RSize maxSize, bool autoSize, bool autoSizeHeightOnly)
		{
			if (autoSize)
			{
				htmlContainer.MaxSize = new RSize(0.0, 0.0);
			}
			else if (autoSizeHeightOnly)
			{
				htmlContainer.MaxSize = new RSize(size.Width, 0.0);
			}
			else
			{
				htmlContainer.MaxSize = size;
			}
			htmlContainer.PerformLayout(g);
			RSize result = size;
			if (autoSize || autoSizeHeightOnly)
			{
				if (autoSize)
				{
					if (maxSize.Width > 0.0 && maxSize.Width < htmlContainer.ActualSize.Width)
					{
						htmlContainer.MaxSize = maxSize;
						htmlContainer.PerformLayout(g);
					}
					else if (minSize.Width > 0.0 && minSize.Width > htmlContainer.ActualSize.Width)
					{
						htmlContainer.MaxSize = new RSize(minSize.Width, 0.0);
						htmlContainer.PerformLayout(g);
					}
					result = htmlContainer.ActualSize;
				}
				else if (Math.Abs(size.Height - htmlContainer.ActualSize.Height) > 0.01)
				{
					double width = size.Width;
					result.Height = ((!(minSize.Height > 0.0) || minSize.Height <= htmlContainer.ActualSize.Height) ? htmlContainer.ActualSize.Height : minSize.Height);
					if (Math.Abs(width - size.Width) > 0.01)
					{
						return HtmlRendererUtils.Layout(g, htmlContainer, size, minSize, maxSize, autoSize: false, autoSizeHeightOnly: true);
					}
				}
			}
			return result;
		}
	}
}

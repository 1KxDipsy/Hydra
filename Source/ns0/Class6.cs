using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ns0
{
	internal class Class6
	{
		public enum Enum0
		{
			const_0 = 0,
			const_1 = 1,
			const_2 = 2,
			const_3 = 3,
			const_4 = 4
		}

		internal static Color color_0 = Color.FromArgb(90, Color.DimGray);

		internal static Rectangle rectangle_0 = new Rectangle(0, 0, 0, 0);

		internal static Color smethod_0(Color color_1)
		{
			return Class6.smethod_24(10, color_1, Color.DimGray);
		}

		public static Color smethod_1(Color color_1, Color color_2)
		{
			double num = (int)color_1.R;
			int g = color_1.G;
			int b = color_1.B;
			int r = color_2.R;
			int g2 = color_2.G;
			checked
			{
				return Color.FromArgb(blue: (int)Math.Round((double)(b + unchecked((int)color_2.B)) / 2.0), red: (int)Math.Round((num + (double)r) / 2.0), green: (int)Math.Round((double)(g + g2) / 2.0));
			}
		}

		internal static Rectangle smethod_2(Rectangle rectangle_1, Padding padding_0)
		{
			checked
			{
				rectangle_1.X += padding_0.Left;
				rectangle_1.Y += padding_0.Top;
				rectangle_1.Width -= padding_0.Horizontal;
				rectangle_1.Height -= padding_0.Vertical;
				return rectangle_1;
			}
		}

		internal static Rectangle smethod_3(Image image_0, Rectangle rectangle_1, Padding padding_0, PictureBoxSizeMode pictureBoxSizeMode_0)
		{
			Rectangle result = Class6.smethod_2(rectangle_1, padding_0);
			checked
			{
				if (image_0 != null)
				{
					switch (pictureBoxSizeMode_0)
					{
					case PictureBoxSizeMode.Normal:
					case PictureBoxSizeMode.AutoSize:
						result.Size = image_0.Size;
						break;
					case PictureBoxSizeMode.CenterImage:
						result.X = (int)Math.Round((double)result.X + (double)(result.Width - image_0.Width) / 2.0);
						result.Y = (int)Math.Round((double)result.Y + (double)(result.Height - image_0.Height) / 2.0);
						result.Size = image_0.Size;
						break;
					case PictureBoxSizeMode.Zoom:
					{
						Size size = image_0.Size;
						float num = Math.Min((float)rectangle_1.Width / (float)size.Width, (float)rectangle_1.Height / (float)size.Height);
						result.Width = (int)Math.Round((float)size.Width * num);
						result.Height = (int)Math.Round((float)size.Height * num);
						result.X = (int)Math.Round((double)(rectangle_1.Width - result.Width) / 2.0);
						result.Y = (int)Math.Round((double)(rectangle_1.Height - result.Height) / 2.0);
						break;
					}
					}
				}
				return result;
			}
		}

		internal static StringAlignment smethod_4(HorizontalAlignment horizontalAlignment_0)
		{
			return horizontalAlignment_0 switch
			{
				HorizontalAlignment.Left => StringAlignment.Near, 
				HorizontalAlignment.Right => StringAlignment.Far, 
				HorizontalAlignment.Center => StringAlignment.Center, 
				_ => (StringAlignment)horizontalAlignment_0, 
			};
		}

		internal static void smethod_5(Graphics graphics_0, Image image_0, ImageLayout imageLayout_0, Rectangle rectangle_1, Rectangle rectangle_2, Point point_0, RightToLeft rightToLeft_0)
		{
			if (imageLayout_0 == ImageLayout.Tile)
			{
				using (TextureBrush textureBrush = new TextureBrush(image_0, WrapMode.Tile))
				{
					if (point_0 != Point.Empty)
					{
						Matrix transform = textureBrush.Transform;
						transform.Translate(point_0.X, point_0.Y);
						textureBrush.Transform = transform;
					}
					graphics_0.FillRectangle(textureBrush, rectangle_2);
					return;
				}
			}
			Rectangle rectangle = Class6.smethod_6(rectangle_1, image_0, imageLayout_0);
			checked
			{
				if (rightToLeft_0 == RightToLeft.Yes && imageLayout_0 == ImageLayout.None)
				{
					rectangle.X += rectangle_2.Width - rectangle.Width;
				}
				if (!rectangle_2.Contains(rectangle))
				{
					switch (imageLayout_0)
					{
					case ImageLayout.None:
					{
						rectangle.Offset(rectangle_2.Location);
						rectangle.Intersect(rectangle_2);
						Rectangle rectangle3 = new Rectangle(Point.Empty, rectangle.Size);
						graphics_0.DrawImage(image_0, rectangle, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, GraphicsUnit.Pixel);
						break;
					}
					default:
					{
						rectangle.Intersect(rectangle_2);
						Rectangle rectangle2 = new Rectangle(new Point(rectangle.X - rectangle.X, rectangle.Y - rectangle.Y), rectangle.Size);
						graphics_0.DrawImage(image_0, rectangle, rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height, GraphicsUnit.Pixel);
						break;
					}
					case ImageLayout.Stretch:
					case ImageLayout.Zoom:
						rectangle.Intersect(rectangle_2);
						graphics_0.DrawImage(image_0, rectangle);
						break;
					}
				}
				else
				{
					ImageAttributes imageAttributes = new ImageAttributes();
					imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
					graphics_0.DrawImage(image_0, rectangle, 0, 0, image_0.Width, image_0.Height, GraphicsUnit.Pixel, imageAttributes);
					imageAttributes.Dispose();
				}
			}
		}

		internal static Rectangle smethod_6(Rectangle rectangle_1, Image image_0, ImageLayout imageLayout_0)
		{
			Rectangle result = rectangle_1;
			checked
			{
				if (image_0 != null)
				{
					switch (imageLayout_0)
					{
					case ImageLayout.None:
						result.Size = image_0.Size;
						break;
					case ImageLayout.Center:
					{
						result.Size = image_0.Size;
						Size size2 = rectangle_1.Size;
						if (size2.Width > result.Width)
						{
							result.X = (int)Math.Round((double)(size2.Width - result.Width) / 2.0);
						}
						if (size2.Height > result.Height)
						{
							result.Y = (int)Math.Round((double)(size2.Height - result.Height) / 2.0);
						}
						break;
					}
					case ImageLayout.Stretch:
						result.Size = rectangle_1.Size;
						break;
					case ImageLayout.Zoom:
					{
						Size size = image_0.Size;
						float num = (float)rectangle_1.Width / (float)size.Width;
						float num2 = (float)rectangle_1.Height / (float)size.Height;
						if (num < num2)
						{
							result.Width = rectangle_1.Width;
							result.Height = (int)Math.Round((double)((float)size.Height * num) + 0.5);
							if (rectangle_1.Y >= 0)
							{
								result.Y = (int)Math.Round((double)(rectangle_1.Height - result.Height) / 2.0);
							}
						}
						else
						{
							result.Height = rectangle_1.Height;
							result.Width = (int)Math.Round((double)((float)size.Width * num2) + 0.5);
							if (rectangle_1.X >= 0)
							{
								result.X = (int)Math.Round((double)(rectangle_1.Width - result.Width) / 2.0);
							}
						}
						break;
					}
					}
				}
				return result;
			}
		}

		internal static Point smethod_7(int int_0, int int_1, int int_2, int int_3)
		{
			return checked(new Point((int)Math.Round((double)int_2 / 2.0 - (double)int_0 / 2.0), (int)Math.Round((double)int_3 / 2.0 - (double)int_1 / 2.0)));
		}

		internal static int smethod_8(int int_0, int int_1)
		{
			return checked((int)Math.Round((double)int_1 / 2.0 - (double)int_0 / 2.0));
		}

		internal static int smethod_9(int int_0, int int_1)
		{
			return checked((int)Math.Round((double)int_1 / 2.0 - (double)int_0 / 2.0));
		}

		internal static Color smethod_10(Color color_1, Color color_2, Color color_3, int int_0)
		{
			checked
			{
				if (unchecked((int)color_1.R) + unchecked((int)color_1.G) + unchecked((int)color_1.B) >= 382)
				{
					return Class6.smethod_23(int_0, color_1, color_2);
				}
				return Class6.smethod_23(int_0, color_1, color_3);
			}
		}

		internal static RectangleF smethod_11(RectangleF rectangleF_0)
		{
			return new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width - 1f, rectangleF_0.Height - 1f);
		}

		internal static GraphicsPath smethod_12(RectangleF rectangleF_0, float float_0)
		{
			RectangleF rectangleF = rectangleF_0;
			rectangleF.X -= 0.1f;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(rectangleF.X, rectangleF.Y, float_0, float_0, 180f, 90f);
			graphicsPath.AddArc(rectangleF.X + rectangleF.Width - float_0, rectangleF.Y, float_0, float_0, 270f, 90f);
			graphicsPath.AddArc(rectangleF.X + rectangleF.Width - float_0, rectangleF.Y + rectangleF.Height - float_0, float_0, float_0, 0f, 90f);
			graphicsPath.AddArc(rectangleF.X, rectangleF.Y + rectangleF.Height - float_0, float_0, float_0, 90f, 90f);
			graphicsPath.CloseAllFigures();
			return graphicsPath;
		}

		internal static void smethod_13(Graphics graphics_0, Color color_1, Rectangle rectangle_1, Padding padding_0, int int_0)
		{
			checked
			{
				if (int_0 > 0)
				{
					if (padding_0.Top > 0)
					{
						graphics_0.DrawImage(Class6.smethod_14(rectangle_1.Width, rectangle_1.Height, rectangle_1.Width, padding_0.Top, Enum0.const_0, color_1, padding_0, int_0), new Rectangle(rectangle_1.X, rectangle_1.Y, rectangle_1.Width, padding_0.Top));
					}
					if (padding_0.Left > 0)
					{
						graphics_0.DrawImage(Class6.smethod_14(rectangle_1.Width, rectangle_1.Height, padding_0.Left, rectangle_1.Height, Enum0.const_1, color_1, padding_0, int_0), new Rectangle(rectangle_1.X, rectangle_1.Y, padding_0.Left, rectangle_1.Height));
					}
					if (padding_0.Right > 0)
					{
						graphics_0.DrawImage(Class6.smethod_14(rectangle_1.Width, rectangle_1.Height, padding_0.Right, rectangle_1.Height, Enum0.const_2, color_1, padding_0, int_0), new Rectangle(rectangle_1.X + (rectangle_1.Width - padding_0.Right), rectangle_1.Y, padding_0.Right, rectangle_1.Height));
					}
					if (padding_0.Bottom > 0)
					{
						graphics_0.DrawImage(Class6.smethod_14(rectangle_1.Width, rectangle_1.Height, rectangle_1.Width, padding_0.Bottom, Enum0.const_3, color_1, padding_0, int_0), new Rectangle(rectangle_1.X, rectangle_1.Y + (rectangle_1.Height - padding_0.Bottom), rectangle_1.Width, padding_0.Bottom));
					}
				}
				else
				{
					Class6.smethod_21(graphics_0, new SolidBrush(color_1), rectangle_1, padding_0.Top, padding_0.Left, padding_0.Right, padding_0.Bottom);
				}
			}
		}

		private static Image smethod_14(int int_0, int int_1, int int_2, int int_3, Enum0 enum0_0, Color color_1, Padding padding_0, int int_4)
		{
			Bitmap bitmap = new Bitmap(int_2, int_3);
			Rectangle rectangle = Class6.rectangle_0;
			checked
			{
				switch (enum0_0)
				{
				case Enum0.const_0:
					rectangle = new Rectangle(0, 0, int_0 - 1, int_1 - 1);
					break;
				case Enum0.const_1:
					rectangle = new Rectangle(0, 0, int_0 - 1, int_1 - 1);
					break;
				case Enum0.const_2:
					rectangle = new Rectangle(-int_0 + padding_0.Right, 0, int_0 - 1, int_1 - 1);
					break;
				case Enum0.const_3:
					rectangle = new Rectangle(0, -(int_1 - padding_0.Bottom), int_0 - 1, int_1 - 1);
					break;
				}
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				GraphicsPath path = Class6.smethod_12(rectangle, int_4 * 2);
				graphics.FillPath(new SolidBrush(color_1), path);
				using (Pen pen = new Pen(color_1, 1f))
				{
					graphics.DrawPath(pen, path);
				}
				return bitmap;
			}
		}

		internal static GraphicsPath smethod_15(Rectangle rectangle_1, float float_0, float float_1)
		{
			RectangleF rectangleF_ = new RectangleF(rectangle_1.X, rectangle_1.Y, rectangle_1.Width, rectangle_1.Height);
			rectangleF_.Width -= 1f;
			rectangleF_.Height -= 1f;
			if (float_1 != 1f)
			{
				float num = float_1 / 2f;
				rectangleF_.X += num;
				rectangleF_.Y += num;
				rectangleF_.Width -= float_1;
				rectangleF_.Height -= float_1;
				return Class6.smethod_12(rectangleF_, float_0 * 2f - 1f);
			}
			return Class6.smethod_12(rectangleF_, float_0 * 2f);
		}

		internal static void smethod_16(Graphics graphics_0, Color color_1, Rectangle rectangle_1, Padding padding_0)
		{
			if (padding_0.Top > 0)
			{
				graphics_0.DrawImage(Class6.smethod_17(rectangle_1.Width, rectangle_1.Height, rectangle_1.Width, padding_0.Top, Enum0.const_0, color_1, padding_0), new Rectangle(rectangle_1.X, rectangle_1.Y, rectangle_1.Width, padding_0.Top));
			}
			if (padding_0.Left > 0)
			{
				graphics_0.DrawImage(Class6.smethod_17(rectangle_1.Width, rectangle_1.Height, padding_0.Left, rectangle_1.Height, Enum0.const_1, color_1, padding_0), new Rectangle(rectangle_1.X, rectangle_1.Y, padding_0.Left, rectangle_1.Height));
			}
			checked
			{
				if (padding_0.Right > 0)
				{
					graphics_0.DrawImage(Class6.smethod_17(rectangle_1.Width, rectangle_1.Height, padding_0.Right, rectangle_1.Height, Enum0.const_2, color_1, padding_0), new Rectangle(rectangle_1.X + (rectangle_1.Width - padding_0.Right), rectangle_1.Y, padding_0.Right, rectangle_1.Height));
				}
				if (padding_0.Bottom > 0)
				{
					graphics_0.DrawImage(Class6.smethod_17(rectangle_1.Width, rectangle_1.Height, rectangle_1.Width, padding_0.Bottom, Enum0.const_3, color_1, padding_0), new Rectangle(rectangle_1.X, rectangle_1.Y + (rectangle_1.Height - padding_0.Bottom), rectangle_1.Width, padding_0.Bottom));
				}
			}
		}

		private static Image smethod_17(int int_0, int int_1, int int_2, int int_3, Enum0 enum0_0, Color color_1, Padding padding_0)
		{
			Bitmap bitmap = new Bitmap(int_2, int_3);
			Rectangle rectangle = Class6.rectangle_0;
			checked
			{
				switch (enum0_0)
				{
				case Enum0.const_0:
					rectangle = new Rectangle(0, 0, int_0 - 1, int_1 - 1);
					break;
				case Enum0.const_1:
					rectangle = new Rectangle(0, 0, int_0 - 1, int_1 - 1);
					break;
				case Enum0.const_2:
					rectangle = new Rectangle(-int_0 + padding_0.Right, 0, int_0 - 1, int_1 - 1);
					break;
				case Enum0.const_3:
					rectangle = new Rectangle(0, -(int_1 - padding_0.Bottom), int_0 - 1, int_1 - 1);
					break;
				}
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				GraphicsPath path = Class6.smethod_18(rectangle, 1f);
				graphics.FillPath(new SolidBrush(color_1), path);
				using (Pen pen = new Pen(color_1, 1f))
				{
					graphics.DrawPath(pen, path);
				}
				return bitmap;
			}
		}

		internal static GraphicsPath smethod_18(RectangleF rectangleF_0, float float_0)
		{
			RectangleF rect = new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
			rect.Width -= 1f;
			rect.Height -= 1f;
			if (float_0 != 1f)
			{
				rect.X += float_0 / 4f - 0.1f;
				rect.Y += float_0 / 4f;
				rect.Width -= float_0 / 1.6f - 0.2f;
				rect.Height -= float_0 / 1.9f;
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(rect);
			return graphicsPath;
		}

		internal static void smethod_19(Graphics graphics_0, Brush brush_0, RectangleF rectangleF_0, int int_0, DashStyle dashStyle_0 = DashStyle.Solid)
		{
			if (int_0 >= 1)
			{
				using (Pen pen = new Pen(brush_0, int_0))
				{
					GraphicsPath path = Class6.smethod_18(rectangleF_0, int_0);
					pen.DashStyle = dashStyle_0;
					graphics_0.DrawPath(pen, path);
				}
			}
		}

		internal static void smethod_20(Graphics graphics_0, Brush brush_0, Rectangle rectangle_1, int int_0, int int_1, DashStyle dashStyle_0 = DashStyle.Solid)
		{
			if (int_1 >= 1)
			{
				GraphicsPath path = Class6.smethod_15(rectangle_1, int_0, int_1);
				using Pen pen = new Pen(brush_0, int_1);
				pen.DashStyle = dashStyle_0;
				graphics_0.DrawPath(pen, path);
			}
		}

		internal static void smethod_21(Graphics graphics_0, Brush brush_0, Rectangle rectangle_1, int int_0, int int_1, int int_2, int int_3)
		{
			if (int_0 > 0)
			{
				graphics_0.FillRectangle(brush_0, new Rectangle((int_1 > 0) ? int_1 : 0, 0, rectangle_1.Width - ((int_2 > 0) ? int_2 : 0), int_0));
			}
			if (int_1 > 0)
			{
				graphics_0.FillRectangle(brush_0, new Rectangle(0, 0, int_1, rectangle_1.Height));
			}
			if (int_2 > 0)
			{
				graphics_0.FillRectangle(brush_0, new Rectangle(rectangle_1.Width - int_2, 0, int_2, rectangle_1.Height));
			}
			if (int_3 > 0)
			{
				graphics_0.FillRectangle(brush_0, new Rectangle((int_1 > 0) ? int_1 : 0, rectangle_1.Height - int_3, rectangle_1.Width - ((int_2 > 0) ? int_2 : 0), int_3));
			}
		}

		internal static void smethod_22(Graphics graphics_0, Brush brush_0, Rectangle rectangle_1, int int_0, DashStyle dashStyle_0 = DashStyle.Solid)
		{
			if (int_0 < 1)
			{
				return;
			}
			using Pen pen = new Pen(brush_0, int_0);
			pen.DashStyle = dashStyle_0;
			GraphicsPath graphicsPath = new GraphicsPath();
			RectangleF rect = new RectangleF(rectangle_1.X, rectangle_1.Y, rectangle_1.Width, rectangle_1.Height);
			float num = (float)int_0 / 2f;
			if (int_0 > 1)
			{
				rect.X += num;
				rect.Y += num;
			}
			rect.Width -= int_0;
			rect.Height -= int_0;
			graphicsPath.AddRectangle(rect);
			graphics_0.DrawPath(pen, graphicsPath);
		}

		internal static Color smethod_23(int int_0, Color color_1, Color color_2)
		{
			Color color = color_1;
			Color color2 = color_2;
			if (int_0 < 100)
			{
				if (color == Color.Transparent)
				{
					color = Color.Empty;
				}
				if (color2 == Color.Transparent)
				{
					color2 = Color.Empty;
				}
			}
			int a = color.A;
			int r = color.R;
			int g = color.G;
			int b = color.B;
			int a2 = color2.A;
			int r2 = color2.R;
			int g2 = color2.G;
			return Color.FromArgb(blue: (int)Math.Round((double)b + (double)checked((unchecked((int)color2.B) - b) * int_0) * 0.01), alpha: (int)Math.Round((double)a + (double)checked((a2 - a) * int_0) * 0.01, 0), red: (int)Math.Round((double)r + (double)checked((r2 - r) * int_0) * 0.01), green: (int)Math.Round((double)g + (double)checked((g2 - g) * int_0) * 0.01, 0));
		}

		internal static Color smethod_24(int int_0, Color color_1, Color color_2)
		{
			Color color = color_1;
			Color color2 = color_2;
			if ((color == Color.Transparent) | (color == Color.Empty))
			{
				color = Color.Black;
			}
			if ((color2 == Color.Transparent) | (color2 == Color.Empty))
			{
				color2 = color;
			}
			if (color == color2)
			{
				return color;
			}
			int r = color.R;
			int g = color.G;
			int b = color.B;
			int r2 = color2.R;
			int g2 = color2.G;
			return Color.FromArgb(blue: (int)Math.Round((double)b + (double)checked((unchecked((int)color2.B) - b) * int_0) * 0.01, 0), alpha: 255, red: (int)Math.Round((double)r + (double)checked((r2 - r) * int_0) * 0.01, 0), green: (int)Math.Round((double)g + (double)checked((g2 - g) * int_0) * 0.01, 0));
		}

		internal static Bitmap smethod_25(Image image_0, Color color_1, Color color_2)
		{
			Bitmap bitmap = new Bitmap(image_0.Width, image_0.Height);
			Class6.smethod_26(Graphics.FromImage(bitmap), image_0, new Rectangle(0, 0, bitmap.Width, bitmap.Height), color_1, color_2);
			return bitmap;
		}

		internal static void smethod_26(Graphics graphics_0, Image image_0, Rectangle rectangle_1, Color color_1, Color color_2)
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(new ColorMap[1]
			{
				new ColorMap
				{
					OldColor = color_1,
					NewColor = color_2
				}
			}, ColorAdjustType.Bitmap);
			graphics_0.DrawImage(image_0, rectangle_1, 0, 0, image_0.Width, image_0.Height, GraphicsUnit.Pixel, imageAttributes, null, IntPtr.Zero);
			imageAttributes.Dispose();
		}
	}
}

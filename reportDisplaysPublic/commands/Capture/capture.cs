using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace reportDisplays
{
	public partial class Form1 : Form {

		private void capture() {
			CaptureImageLocations.Clear();
			CaptureImageLocations.Add(new Point(0, 0));
			//capture
			foreach (var info in screens.ScreenInfomations.Screens)
			{
				capture(info.Bounds, 1, CaptureImageLocations[0]);
				break;
			}
		}

		private void capture(Rectangle rc, int screenNumbers, System.Drawing.Point point, int scale=10, double screenscale=100)
		{
			try
			{
				Bitmap afterbmp = CaptureScreen(rc, point, scale, screenscale);

				// ビットマップ画像として保存して表示
				//string filePath = @"screen" + screenNumbers + ".jpg";
				//afterbmp.Save(filePath, ImageFormat.Jpeg);
			}
			catch (Exception exception)
			{
			}
		}

		private Bitmap CaptureScreen(Rectangle rc, Point point, int scale, double screenscale)
		{
			// Bitmapオブジェクトにスクリーン・キャプチャ
			Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.CopyFromScreen(rc.X, rc.Y, 0, 0,
				  rc.Size, CopyPixelOperation.SourceCopy);
			}
			double width = rc.Width / scale * 100 / screenscale;
			double height = rc.Height / scale * 100 / screenscale;
			int intwidth = (int)width;
			int intheight = (int)height;

			Bitmap afterbmp = new Bitmap(bmp, intwidth, intheight);
			//pictureboxに表示
			picture(afterbmp, point);
			return afterbmp;
		}
	}
}
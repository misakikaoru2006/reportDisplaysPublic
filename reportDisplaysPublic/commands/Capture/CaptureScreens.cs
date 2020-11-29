using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace reportDisplays
{
	public partial class Form1 : Form 
	{
		/// <summary>
		/// screenを列挙してキャプチャーする
		/// </summary>
		private void CaptureScreens()
		{
			//System.Windows.Forms.Screen[] screens = System.Windows.Forms.Screen.AllScreens;
			int screenNumbers = 1;
			List<Rectangle> rectangles = new List<Rectangle>();

			var log = string.Empty;

			foreach (var screen in screens.ScreenInfomations.Screens)
			{
				log += screen.ToString();

				//長方形の位置と大きさを配列に入れる
				double locationx = (screen.ScreenLocation.X / scale) * (100 / screen.Width);
				int intlocationx = (int)locationx;

				rectangles.Add(new Rectangle(200 + intlocationx,
																	100 + screen.ScreenLocation.Y / scale,
																	screen.Width / scale,
																	screen.Height / scale));
				CaptureImageLocations.Add(new Point(OriginPoint.X + screen.ScreenLocation.X / 10,
														OriginPoint.Y + screen.ScreenLocation.Y / 10));
				//capture
				capture(screen.Bounds, screenNumbers+1, CaptureImageLocations[CaptureImageLocations.Count - 1], scale, screen.Screenscale);

				screenNumbers++;
			}

			if (screens.ScreenInfomations.Screens.Count < 4) radioButton4.Visible = false;

			textBox.Text = log;
		}

		private void CaptureNow_Click(object sender, EventArgs e)
		{
			CaptureScreens();
		}
	}
}
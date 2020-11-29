using System;
using System.Drawing;

namespace ScreenConfiguration
{
	public class ScreenInfomation
	{
		public int ScreenNumber = 1;
		public int Width = 2160;
		public int Height = 3840;
		public System.Drawing.Point ScreenLocation = new System.Drawing.Point(0, 0);
		public int Left;
		public double Screenscale = 100;
		public Rectangle Bounds = new Rectangle();
		public bool IsMainDisplay = false;

		public override string ToString()
		{
			var number = ScreenNumber == 0 ? "Primary" :
								ScreenNumber == 1 ? "2nd" :
								ScreenNumber == 2 ? "3rd" :
								(ScreenNumber+1) + "th";

			return number + "Screen \r\n"+
				"Width = " + Width + "\r\n" +
				"Height = " + Height + "\r\n" +
				"screenLocation(X) = " + ScreenLocation.X + "\r\n" +
				"screenLocation(Y) = " + ScreenLocation.Y + "\r\n\r\n";
		}

		internal void CheckMainDisplay()
		{
			if (3840 <= this.Width && 0 <= ScreenLocation.X)
				IsMainDisplay = true;
			Left = ScreenLocation.X + Width - 1;
		}
	}
}

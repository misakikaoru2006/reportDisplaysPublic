using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace reportDisplays
{
	public partial class Form1 : Form
	{
		Point PastPoint = new Point();

		/// <summary>
		/// ディスプレイのサイズの差をなくしてマウス(mouse.move, Pointer)をシームレスに動かす。
		/// </summary>
		/// <param name="pointerlocation"></param>
		private void LeftRightJump(Point pointerlocation)
		{
			int left = screens.ScreenInfomations.Screens[screens.ScreenInfomations.Screens.Count - 1].ScreenLocation.X +
						screens.ScreenInfomations.Screens[screens.ScreenInfomations.Screens.Count - 1].Width;
			int right = screens.ScreenInfomations.Screens[0].ScreenLocation.X;


			//右端から左端
			if (pointerlocation.X == left-1 && PastPoint.X < left-1)
				pointerlocation.X = right;
			//左端から右端
			else if (pointerlocation.X == right && right < PastPoint.X)
				pointerlocation.X = left;

			else if (screens.ScreenInfomations.Screens.FirstOrDefault(screen => screen.Left==pointerlocation.X) != null)
				pointerlocation.Y = pointerlocation.Y*2160/3840;

				////Display1の右端からDisplay2の左端
				//else if (pointerlocation.X == -1 && PastPoint.X < -1)
				//	pointerlocation.Y = pointerlocation.Y*2160/3840;
				////Display2の左端からDisplay1の右端
				//else if (pointerlocation.X == 0 && 0< PastPoint.X)
				//	pointerlocation.Y = pointerlocation.Y * 3840 / 2160;
				////Display1の左端からDisplay3の右端
				//else if (pointerlocation.X == -2160 && -2160 < PastPoint.X && pointerlocation.Y < 350)
				//	pointerlocation.Y = 0;
				//else if (pointerlocation.X == -2160 && -2160 < PastPoint.X && 1920 < pointerlocation.Y)
				//	pointerlocation.Y = 1920;
				////Display2の右端からDisplay4の左端
				//else if (pointerlocation.X == 3839 && PastPoint.X < 3839 && pointerlocation.Y < 583)
				//	pointerlocation.Y = 583;
				////Display4の左端からDisplay2の右端
				//else if (pointerlocation.X == 3840 && 3840 < PastPoint.X && 2160 < pointerlocation.Y)
				//	pointerlocation.Y = 2160;


				Cursor.Position = pointerlocation;
			PastPoint = pointerlocation;
		}
	}
}
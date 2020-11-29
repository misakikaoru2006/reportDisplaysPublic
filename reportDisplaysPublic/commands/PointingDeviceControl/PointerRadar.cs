using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace reportDisplays
{
	public partial class Form1 : Form    {

		//Cursorsクラスの静的プロパティを取得する
		static Type cursorsType = typeof(System.Windows.Forms.Cursors);
		static PropertyInfo properrty = cursorsType.GetProperties(
			System.Reflection.BindingFlags.Public |
			System.Reflection.BindingFlags.Static).Where(p => p.Name.ToLower() == "arrow").FirstOrDefault();
		//CursorsクラスのプロパティからCursorオブジェクトを取得する
		Cursor cursor = (Cursor)properrty.GetValue(null, null);

		private void pointertimer_Tick(object sender, EventArgs e)
		{
			//ポインタの位置を取得する
			Point pointerlocation = System.Windows.Forms.Cursor.Position;

			if (screens.ScreenInfomations.Screens.Count <= 1) return;
			if (pointerlocation.X < screens.ScreenInfomations.Screens[1].ScreenLocation.X)
			{
				radioButton1.Checked = true;
				SetBackColer(pointerlocation, 0);
			}
			else if (pointerlocation.X < screens.ScreenInfomations.Screens[2].ScreenLocation.X)
			{
				radioButton2.Checked = true;
				SetBackColer(pointerlocation, 1);
			}
			//else if (pointerlocation.X < screens.ScreenInfomations.Screens[3].ScreenLocation.X) radioButton3.Checked = true;
			else
			{
				radioButton3.Checked = true;
				SetBackColer(pointerlocation, 2);
			}
			//else radioButton4.Checked = true;

			locationX.Text = pointerlocation.X.ToString();
			locationY.Text = pointerlocation.Y.ToString();

			//pointer表示用のlocation
			Point PointerLocationPoint = new Point(600 + pointerlocation.X / scale, 100 + pointerlocation.Y / scale);
			foreach (var control in this.Controls)
			{
				if (control.GetType() == typeof(PictureBox))
				{
					PictureBox picturebox = control as PictureBox;

					if (picturebox.Location.X <= PointerLocationPoint.X &&
						PointerLocationPoint.X <= picturebox.Location.X + picturebox.Width &&
						//picturebox.Location.Y <= PointerLocationPoint.Y &&
						PointerLocationPoint.Y <= picturebox.Location.Y + picturebox.Height)
					{
						this.Text = picturebox.Name;
						picturebox.Image = drawcursor(PointerLocationPoint, picturebox.Image as Bitmap);
						picturebox.Invalidate();
						//break;
					}
				}
			}

			LeftRightJump(pointerlocation);
		}

		private void SetBackColer(Point pointerlocation, int screen)
		{
			//背景色
			try
			{
				var height = 255 - pointerlocation.Y * 256 / screens.ScreenInfomations.Screens[screen].Bounds.Height;
				var width = 255 - (0 < screen ? pointerlocation.X - screens.ScreenInfomations.Screens[screen].Bounds.Location.X : pointerlocation.X) * 256 / screens.ScreenInfomations.Screens[screen].Bounds.Width;
				//this.BackColor = Color.FromArgb(255, height, (width + height) / 2, width);
				//this.BackColor = Color.FromArgb(255, (width + height) / 2, width, height);
				this.BackColor = Color.FromArgb(255, width, (width + height) / 2, height);
			}
			catch (Exception)
			{
			}
		}
	}
}

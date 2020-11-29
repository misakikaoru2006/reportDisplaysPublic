using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace reportDisplays
{
	public partial class Form1 : Form 
	{
		private void picture(Bitmap bmp, Point point) {
			PictureBox pictureBox = new PictureBox();
			pictureBox.Location = point;
			pictureBox.Name = "captureimage(X=" + point.X + "_Y=" + point.Y + ")";
			pictureBox.Image = bmp;
			pictureBox.Size = new System.Drawing.Size(bmp.Width, bmp.Height);
			this.Controls.Add(pictureBox);
		}
	}
}
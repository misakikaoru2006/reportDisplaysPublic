using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace reportDisplays
{
	public partial class Form1 : Form    {
		private Bitmap drawcursor(Point PointerLocationPoint, Bitmap bmp)
		{
			//this.Cursor = new Cursor(Cursor.Current.Handle);
			this.Cursor = Cursors.Arrow;

			//Point cursorPoint = Cursor.Position;
			//Point hotSpot = this.Cursor.HotSpot;
			//Point position = new Point((cursorPoint.X - hotSpot.X) / 10, (cursorPoint.Y - hotSpot.Y) / 10);

			//Graphics graph = Graphics.FromImage(bmp);
			//Rectangle rc = new Rectangle(new Point(0, 0), new Size(3840, 2160));
			//////bmp = CaptureScreen(rc, new Point(0,0), 10, 100);//これは失敗。
			////graph.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
			//this.Cursor.Draw(graph, new Rectangle(position, this.Cursor.Size));
			//graph.Dispose();

			//return bmp;
			////http://blog.code-life.net/blog/2012/01/28/screen-capture-with-mouse-pointer-c-sharp/


			Graphics g = Graphics.FromImage(bmp);
			//g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
			this.Cursor.Draw(g, new Rectangle(PointerLocationPoint, this.Cursor.Size));
			g.Dispose();
			return bmp;
		}
	}
}

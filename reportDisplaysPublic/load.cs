using System;
using System.Windows.Forms;

namespace reportDisplays
{
	public partial class Form1 : Form {
		private void Form1_Load(object sender, EventArgs e) {
				CaptureScreens();
				textBox.SelectionStart = 0;
				this.ShowInTaskbar = false;

			this.TopMost = true;
		}
	}
}
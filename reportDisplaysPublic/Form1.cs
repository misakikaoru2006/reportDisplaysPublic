using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace reportDisplays
{
	public partial class Form1 : Form    {

 		static string executePath = Application.ExecutablePath;
		static string executeFolder = Path.GetDirectoryName(executePath);
		List<Point> CaptureImageLocations = new List<Point>();

		//縮尺率
		int scale = 10;

		//表示用の原点
		Point OriginPoint = new Point(250, 100);

		string domain = Environment.UserDomainName;// ドメイン名=マシン名
		static string[] args = Environment.GetCommandLineArgs();
		string keyword = string.Join(" ", args, 1, args.Length - 1);

		ScreenInfomation.ScreenInfomation screens = new ScreenInfomation.ScreenInfomation();

		public Form1()
		{
			InitializeComponent();
		}
	}
}
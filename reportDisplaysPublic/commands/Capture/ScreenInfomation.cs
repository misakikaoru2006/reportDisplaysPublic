using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenInfomation
{
	public class ScreenInfomation
	{
		public ScreenConfiguration.ScreenInfomations ScreenInfomations = new ScreenConfiguration.ScreenInfomations();

		[DllImport("user32.dll")]
		extern static bool SetProcessDPIAware();

		public ScreenInfomation()
		{
			SetDpiAwareness();
			SetProcessDPIAware();
			var Screens = System.Windows.Forms.Screen.AllScreens;
			foreach (var screen in Screens.Select((s, i) => new { i, s }))
			{
				var info = new ScreenConfiguration.ScreenInfomation()
				{
					ScreenNumber=screen.i,
					Width=screen.s.Bounds.Width,
					Height=screen.s.Bounds.Height,
					ScreenLocation=screen.s.Bounds.Location,
					Bounds = screen.s.Bounds,
					Screenscale= screen.s.Bounds.Width == 2160 ? 150 : 100,
			};
				ScreenInfomations.Screens.Add(info);
			}
			ScreenInfomations.Sort();
			ScreenInfomations.Save();
		}

		/// <summary>
		/// 自身のウィンドウがあるディスプレイの解像度を取得する。自身のアプリのウィンドウやフォームが表示されているディスプレイの情報を取得するには、System.Windows.Forms.ScreenクラスのFrom????メソッドを使う。 
		/// Windowフォームの場合	FromControlメソッドを使い引数に自身のフォームを渡す。 
		/// </summary>
		/// <returns></returns>
		public Size GetThisWindowOnScreen(Form form)
		{
			var screen = System.Windows.Forms.Screen.FromControl(form);
			return screen.Bounds.Size;
		}

		private enum ProcessDPIAwareness
		{
			ProcessDPIUnaware = 0,
			ProcessSystemDPIAware = 1,
			ProcessPerMonitorDPIAware = 2
		}

		[DllImport("shcore.dll")]
		private static extern int SetProcessDpiAwareness(ProcessDPIAwareness value);

		public static void SetDpiAwareness()
		{
			if (6 <= Environment.OSVersion.Version.Major)
				SetProcessDpiAwareness(ProcessDPIAwareness.ProcessPerMonitorDPIAware);
		}
	}
}
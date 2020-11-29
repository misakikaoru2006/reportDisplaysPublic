using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace reportDisplays
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			try {
				Application.Run(new Form1());
			}
			catch (Exception e) {
			}
		}
    }
}
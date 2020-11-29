using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ScreenConfiguration
{
	public partial class ScreenInfomations
	{
		public List<ScreenInfomation> Screens = new List<ScreenInfomation>();
		string ScreenSetting = string.Empty;
		string ScreenSettingPath = "Screen.Setting";

		public ScreenInfomations()
		{
		}

		public void Read()
		{
			if (!string.IsNullOrEmpty(ScreenSetting)) return;

			ScreenSetting  = File.ReadAllText(ScreenSettingPath, Encoding.UTF8);
			var screeninformations = JsonConvert.DeserializeObject<ScreenInfomations>(ScreenSetting);
			this.Screens = screeninformations.Screens;
			Sort();
		}

		/// <summary>
		/// 独自クラスのソート
		/// </summary>
		public void Sort()
		{
			Screens.Sort((a, b) => a.ScreenLocation.X - b.ScreenLocation.X);
			foreach (var screen in Screens) screen.CheckMainDisplay();
		}

		public void Save()
		{
			var screenSetting = JsonConvert.SerializeObject(this);
			if (string.IsNullOrEmpty(screenSetting)) return;

			if (File.Exists(ScreenSettingPath))
			{
				var nowScreenSetting = File.ReadAllText(ScreenSettingPath, Encoding.UTF8);
				if (nowScreenSetting.Replace("\r\n", string.Empty).Trim()
					==
					screenSetting.Replace("\r\n", string.Empty).Trim())
				{
					return;
				}

				File.Delete(ScreenSettingPath);
				Thread.Sleep(500);
			}
			File.AppendAllText(ScreenSettingPath, screenSetting, Encoding.UTF8);
		}
	}
}

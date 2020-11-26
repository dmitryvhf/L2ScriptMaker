using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L2ScriptMaker.Core
{
	public static class SettingsUtils
	{
		public static GlobalSettings Settings { get; private set; }

		public static string AppConfigName = "L2ScriptMaker.cfg";

		private static void Init()
		{
			if(Settings != null) return;

			Settings = new GlobalSettings();
			Settings.WorkFolder = Environment.CurrentDirectory;
		}

		public static void Load()
		{
			string configPath = Path.Combine(Environment.CurrentDirectory, AppConfigName);

			if (File.Exists(configPath))
			{
				Settings = SerializeUtils.Deserialize<GlobalSettings>(configPath);
				return;
			}

			Init();
			Save();
		}

		public static void Save()
		{
			string configPath =  Path.Combine(Environment.CurrentDirectory, AppConfigName);
			SerializeUtils.Serialize(Settings, configPath);
		}
	}
}

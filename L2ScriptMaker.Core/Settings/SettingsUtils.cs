using System;
using System.IO;
using L2ScriptMaker.Core.Settings.Models;

namespace L2ScriptMaker.Core.Settings
{
	public static class SettingsUtils
	{
		public static GlobalSettings Settings { get; private set; }

		private const string AppConfigName = "L2ScriptMaker.cfg";

		private static void Init()
		{
			if(Settings != null) return;

			InitDefaultValues();
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
			string configPath = Path.Combine(Environment.CurrentDirectory, AppConfigName);
			SerializeUtils.Serialize(Settings, configPath);
		}

		private static void InitDefaultValues()
		{
			Settings = new GlobalSettings
			{
				WorkFolder = Environment.CurrentDirectory,
				LogsFolder = Environment.CurrentDirectory
			};
		}
	}
}

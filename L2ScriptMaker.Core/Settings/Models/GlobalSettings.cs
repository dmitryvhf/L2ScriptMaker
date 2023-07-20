namespace L2ScriptMaker.Core.Settings.Models
{
	public class GlobalSettings
	{
		public string WorkFolder { get; set; }
		public string LogsFolder { get; set; }

		public NpcPchMakerSettings NpcPchMakerSettings { get; set; }

		public GlobalSettings()
		{
			NpcPchMakerSettings = new NpcPchMakerSettings();
		}
	}
}

namespace L2ScriptMaker.Core.Settings.Models
{
	public class GlobalSettings
	{
		public string WorkFolder { get; set; }
		public string LogsFolder { get; set; }

		public NpcPchMaker NpcPchMaker { get; set; }

		public GlobalSettings()
		{
			NpcPchMaker = new NpcPchMaker();
		}
	}
}

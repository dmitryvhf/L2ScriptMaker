using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L2ScriptMaker.Services.Parsers.Npc;
using L2ScriptMaker.Services.Parsers;
using L2ScriptMaker.Core.ScriptParser;
using L2ScriptMaker.Core.ScriptParser.InlineData;
using L2ScriptMaker.Core.Files;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcPchService
	{
		private static readonly IFactory<InlineData, NpcPch> Factory = new NpcPchFactory();
		private static readonly IScriptReader<InlineData> InlineReader = new InlineDataReader();

		public static IEnumerable<InlineData> Load(IEnumerable<string> data)
		{
			var result = data.Select(InlineReader.Read).Where(a => !a.IsEmpty);
			return result;
		}

		public static IEnumerable<NpcPch> Parse(IEnumerable<InlineData> data)
		{
			IEnumerable<NpcPch> result = data.Select(Factory.Build);
			return result;
		}

		#region WinForms services
		public void Generate(string NpcDataFile, string NpcDataDir)
		{
			NpcPchFactory npcPchFactory = new NpcPchFactory();
			IEnumerable<string> rawNpcData = FileUtils.ReadFile(NpcDataFile);

			IEnumerable<InlineData> data1 = NpcPchService.Load(rawNpcData);
			IEnumerable<NpcPch> data2 = NpcPchService.Parse(data1);
			var data3 = data2.Select(npcPchFactory.Print);

			FileUtils.SaveFile(data3, NpcDataDir + @"\npc_pch.txt", Encoding.Unicode);
		}
		#endregion
	}
}

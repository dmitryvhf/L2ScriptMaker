using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Parsers.Parsers.Inline;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcPchService : INpcPchService
	{
		private const int NpcPchPrefix = 1_000_000;
		private static readonly IInlineParser InlineParser = new InlineParser<NpcDataDto>();

		public NpcPchService()
		{
			InlineParser.Initialize();
		}

		public IEnumerable<NpcPch> Parse(IEnumerable<string> data)
		{
			IEnumerable<NpcPch> result = data.Select(a => InlineParser.Parse<NpcPch>(a));
			return result;
		}

		#region WinForms services
		public void Generate(string NpcDataFile, string NpcDataDir)
		{
			IEnumerable<string> rawNpcData = FileUtils.ReadFile(NpcDataFile);

			IEnumerable<NpcPch> data = Parse(rawNpcData);
			IEnumerable<string> result = data.Select(Print);

			FileUtils.SaveFile(result, NpcDataDir + @"\npc_pch.txt", Encoding.Unicode);
			FileUtils.SaveFile(Enumerable.Empty<string>(), NpcDataDir + @"\npc_pch2.txt", Encoding.Unicode);
		}
		#endregion

		// [gremlin]       =       1020001
		public static string Print(NpcPch model)
		{
			return $"[{model.Name}] = {NpcPchPrefix + model.Id}";
		}
	}
}

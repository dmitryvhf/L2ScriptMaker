using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Parsers.Parsers.Inline;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcDataService : INpcDataService
	{
		private static readonly IInlineParser InlineParser = new InlineParser<NpcDataDto>();

		public NpcDataService()
		{
			InlineParser.Initialize();
		}

		public IEnumerable<NpcData> Parse(IEnumerable<string> data)
		{
			IEnumerable<NpcData> result = data.Select(a => InlineParser.Parse<NpcData>(a));
			return result;
		}

		// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
		public static string Print(NpcData model)
		{
			return $"npc_begin" +
			       $"\t{model.Type}" +
			       $"\t{model.Id}" +
			       $"\t[{model.Name}]";
		}
	}
}

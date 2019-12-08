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
		private static readonly IInlineParser<NpcDataDto> InlineParser = new InlineParser<NpcDataDto>();

		public NpcDataService()
		{
			InlineParser.Initialize();
		}

		public NpcDataDto Parse(string data)
		{
			return InlineParser.Parse(data);
		}

		public IEnumerable<NpcDataDto> Parse(IEnumerable<string> data)
		{
			IEnumerable<NpcDataDto> result = data.Select(Parse);
			return result;
		}

		public ServiceResult Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress)
		{
			throw new NotImplementedException();
		}

		// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
		public static string Print(NpcData model)
		{
			throw new NotImplementedException();
			//return $"npc_begin" +
			//       $"\t{model.Type}" +
			//       $"\t{model.Id}" +
			//       $"\t[{model.Name}]";
		}
	}
}

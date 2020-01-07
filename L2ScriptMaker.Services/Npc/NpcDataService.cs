using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Core.Parser;
using L2ScriptMaker.Models.Dto;
using L2ScriptMaker.Core.Mapper;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcDataService : INpcDataService
	{
		private readonly ModelMapper<NpcDataDto> _mapper = new ModelMapper<NpcDataDto>();

		private const string StartPrefix = "npc_begin";
		private const string EndPrefix = "npc_end";

		public IEnumerable<string> Collect(IEnumerable<string> lines)
		{
			return ScriptLoader.Collect(lines, StartPrefix, EndPrefix);
		}

		public NpcDataDto Parse(string record)
		{
			ParsedData data = ParseService.Parse(record);
			NpcDataDto npcDataDto = _mapper.Map(data);
			return npcDataDto;
			// return InlineParser.Parse(data);
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

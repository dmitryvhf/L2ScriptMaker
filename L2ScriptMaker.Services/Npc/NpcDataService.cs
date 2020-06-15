using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Core.Mapper;
using L2ScriptMaker.Core.Parser;
using L2ScriptMaker.Models.Dto;
using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcDataService : INpcDataService
	{
		private readonly ModelMapper<NpcDataDto> _mapper = new ModelMapper<NpcDataDto>();

		private const string StartPrefix = "npc_begin";
		private const string EndPrefix = "npc_end";

		public IEnumerable<NpcDataDto> Get(string dataFile)
		{
			IEnumerable<string> rawData = FileUtils.Read(dataFile);
			IEnumerable<string> filteredData = Collect(rawData);
			return Parse(filteredData).ToList();
		}

		public IEnumerable<NpcDataDto> Get(string dataFile, IProgress<int> progress)
		{
			IEnumerable<string> rawData = FileUtils.Read(dataFile, progress);
			IEnumerable<string> filteredData = Collect(rawData);
			return Parse(filteredData).ToList();
		}

		private IEnumerable<string> Collect(IEnumerable<string> lines)
		{
			return ParseService.Collect(lines, StartPrefix, EndPrefix);
		}

		private NpcDataDto Parse(string record)
		{
			ParsedData data = ParseService.ToKeyValueCollection(record);
			return _mapper.Map(data);
		}

		private IEnumerable<NpcDataDto> Parse(IEnumerable<string> data)
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

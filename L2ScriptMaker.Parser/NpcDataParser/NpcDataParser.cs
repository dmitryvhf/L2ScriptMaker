using System.Collections.Generic;
using System.Linq;
using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Parsers.Core;
using L2ScriptMaker.Parsers.Dto;

namespace L2ScriptMaker.Parsers
{
	internal class NpcDataParser : IParserService<NpcData>
	{
		private const string StartPrefix = "npc_begin";
		private const string EndPrefix = "npc_end";

		private readonly ModelMapper<NpcDataDto> _mapper = new ModelMapper<NpcDataDto>();

		public IEnumerable<NpcData> Do(IEnumerable<string> rawData)
		{
			IEnumerable<string> filteredData = Collect(rawData);
			List<NpcDataDto> dtoData = Parse(filteredData).ToList();

			return AutoMapService.Map<NpcDataDto, NpcData>(dtoData);
		}

		private static IEnumerable<string> Collect(IEnumerable<string> lines)
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
	}
}

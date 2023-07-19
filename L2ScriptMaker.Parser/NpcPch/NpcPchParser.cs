﻿using System.Collections.Generic;
using System.Linq;

using L2ScriptMaker.Core;
using L2ScriptMaker.Parsers.Core;
using L2ScriptMaker.Parsers.Dto;

namespace L2ScriptMaker.Parsers.NpcPch
{
	internal class NpcPchParser : IParserService<Models.Npc.NpcPch>
	{
		// private readonly ModelMapper<NpcPchDto> _mapper = new ModelMapper<NpcPchDto>();

		public IEnumerable<Models.Npc.NpcPch> Do(IEnumerable<string> rawData)
		{
			List<NpcPchDto> dtoData = Parse(rawData).ToList();
			return AutoMapService.Map<NpcPchDto, Models.Npc.NpcPch>(dtoData);
		}

		private NpcPchDto Parse(string record)
		{
			KeyValuePair<string, string> data = ParseService.ToKeyValue(record);
			return Map(data);
			// return _mapper.Map(data);
		}

		private IEnumerable<NpcPchDto> Parse(IEnumerable<string> data)
		{
			IEnumerable<NpcPchDto> result = data.Select(Parse);
			return result;
		}

		private static NpcPchDto Map(KeyValuePair<string, string> data)
		{
			return new NpcPchDto { Id = data.Value, Name = StringUtils.CutBrackets(data.Key) };
		}

		//private NpcPchDto Parse(string record)
		//{
		//	KeyValuePair<string, string> data = ParseService.ToKeyValue(record);
		//	return Map(data);
		//}

		//private IEnumerable<NpcPchDto> Parse(IEnumerable<string> data)
		//{
		//	IEnumerable<NpcPchDto> result = data.Select(Parse);
		//	return result;
		//}

	}
}

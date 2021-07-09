using System.Collections.Generic;
using System.Linq;
using L2ScriptMaker.Models.Common;
using L2ScriptMaker.Models.Skill;
using L2ScriptMaker.Parsers.Core;
using L2ScriptMaker.Parsers.Dto;

namespace L2ScriptMaker.Parsers
{
	internal class SkillDataParser : IParserService<SkillData>
	{
		private const string StartPrefix = "skill_begin";
		private const string EndPrefix = "skill_end";

		private readonly ModelMapper<SkillDataDto> _mapper = new ModelMapper<SkillDataDto>();

		public IEnumerable<SkillData> Do(IEnumerable<string> rawData)
		{
			IEnumerable<string> filteredData = Collect(rawData);

			List<SkillDataDto> dtoData = Parse(filteredData).ToList();
			return AutoMapService.Map<SkillDataDto, SkillData>(dtoData);
		}

		private IEnumerable<string> Collect(IEnumerable<string> lines)
		{
			return ParseService.Collect(lines, StartPrefix, EndPrefix);
		}

		private SkillDataDto Parse(string record)
		{
			ParsedData data = ParseService.ToKeyValueCollection(record);
			return _mapper.Map(data);
		}

		private IEnumerable<SkillDataDto> Parse(IEnumerable<string> data)
		{
			IEnumerable<SkillDataDto> result = data.Select(Parse);
			return result;
		}

		//public NpcData Map(NpcDataDto dto)
		//{
		//	NpcData model = new NpcData
		//	{
		//		Name = dto.Name,
		//		Id = dto.Id,
		//		Type = dto.Type
		//	};

		//	return model;
		//}
	}
}

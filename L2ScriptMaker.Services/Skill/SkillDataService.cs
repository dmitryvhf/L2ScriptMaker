using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Models.Dto;
using L2ScriptMaker.Core.Parser;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Core.Mapper;

namespace L2ScriptMaker.Services.Skill
{
	public class SkillDataService : ISkillDataService
	{

		private readonly ModelMapper<SkillDataDto> _mapper = new ModelMapper<SkillDataDto>();

		private const string StartPrefix = "skill_begin";
		private const string EndPrefix = "skill_end";

		public IEnumerable<string> Collect(IEnumerable<string> lines)
		{
			return ScriptLoader.Collect(lines, StartPrefix, EndPrefix);
		}

		public SkillDataDto Parse(string record)
		{
			ParsedData data = ParseService.Parse(record);
			SkillDataDto skillDataDto = _mapper.Map(data);
			return skillDataDto;
		}

		public IEnumerable<SkillDataDto> Parse(IEnumerable<string> data)
		{
			IEnumerable<SkillDataDto> result = data.Select(Parse);
			return result;
		}

		public static string Print(NpcData model)
		{
			throw new NotImplementedException();
		}
	}
}

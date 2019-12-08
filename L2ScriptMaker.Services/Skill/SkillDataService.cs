using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Parsers.Parsers.Inline;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Services.Skill
{
	public class SkillDataService : ISkillDataService
	{
		private static readonly IInlineParser<SkillDataDto> InlineParser = new InlineParser<SkillDataDto>();

		public SkillDataService()
		{
			InlineParser.Initialize();
		}

		public SkillDataDto Parse(string data)
		{
			return InlineParser.Parse(data);
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

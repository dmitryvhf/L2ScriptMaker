using System.Collections.Generic;
using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcDataService : IParserService<NpcDataDto>, IGenerateService
	{
	}
}
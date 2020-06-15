using L2ScriptMaker.Models.Dto;
using System;
using System.Collections.Generic;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcDataService : IGenerateService // : IParserService<NpcDataDto>, IGenerateService
	{
		IEnumerable<NpcDataDto> Get(string dataFile);
		IEnumerable<NpcDataDto> Get(string dataFile, IProgress<int> progress);
	}
}
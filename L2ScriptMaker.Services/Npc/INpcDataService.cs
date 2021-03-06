﻿using System.Collections.Generic;
using L2ScriptMaker.Models.Dto;
using L2ScriptMaker.Models.Npc;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcDataService : IParserService<NpcDataDto>, IGenerateService
	{
	}
}
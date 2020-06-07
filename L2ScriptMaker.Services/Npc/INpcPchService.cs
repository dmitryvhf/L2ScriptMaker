using System;
using System.Collections.Generic;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Models.Dto;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcPchService : IParserService<NpcPchDto>, IGenerateService
	{
		List<ListItem> GetListItems(string fileName);
	}
}
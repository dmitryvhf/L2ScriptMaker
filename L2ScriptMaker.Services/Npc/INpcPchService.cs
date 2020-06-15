using System;
using System.Collections.Generic;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Models.Dto;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcPchService : IGenerateService // : IParserService<NpcPchDto>, IGenerateService
	{
		IEnumerable<NpcPchDto> Get(string dataFile);
		IEnumerable<NpcPchDto> Get(string dataFile, IProgress<int> progress);
		List<ListItem> GetListItems(string fileName);
	}
}
using L2ScriptMaker.Models.Dto;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcDataService : IParserService<NpcDataDto>, IGenerateService
	{
	}
}
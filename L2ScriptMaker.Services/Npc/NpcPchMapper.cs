using L2ScriptMaker.Models.Dto;
using L2ScriptMaker.Models.Npc;

namespace L2ScriptMaker.Services.Npc
{
	internal class NpcPchMapper : IMapper<NpcDataDto, NpcPch>
	{
		public NpcPch Map(NpcDataDto data)
		{
			return new NpcPch
			{
				Name = data.Name,
				Id = NpcContants.NpcPchPrefix + data.Id
			};
		}
	}
}

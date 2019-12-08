using System;
using System.Collections.Generic;
using System.Text;
using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Services.Npc
{
	internal class NpcDataMapper : IMapper<NpcDataDto, NpcData>
	{
		public NpcData Map(NpcDataDto dto)
		{
			NpcData model = new NpcData
			{
				Name = dto.Name,
				Id = dto.Id,
				Type = dto.Type
			};

			return model;
		}
	}
}

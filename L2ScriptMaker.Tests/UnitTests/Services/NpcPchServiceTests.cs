using System;
using L2ScriptMaker.Models.Npc;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using L2ScriptMaker.Services.Scripts.Npc;

namespace L2ScriptMaker.Tests.UnitTests.Services
{
	public class NpcPchServiceTests
	{
		[Fact(Skip = "NotImplementedException")]
		public void GenerateData()
		{
			throw new NotImplementedException();

			//INpcPchService npcPchService = new NpcPchService();
			//IEnumerable<string> rawData = GetNpcData();

			//// IEnumerable<NpcPch> result = npcPchService.Generate(rawData).ToArray();

			//Assert.True(result.Any());
		}

		readonly IEnumerable<NpcData> _npcDataArray = new NpcData[]
		{
			new NpcData{ Id = 20001, Name = "gremlin", Type = "warrior"},
			new NpcData{ Id = 20002, Name = "rabbit", Type = "warrior"},
			new NpcData{ Id = 20003, Name = "goblin", Type = "warrior"}
		};

		private IEnumerable<string> GetNpcData()
		{
			// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
			return _npcDataArray.Select(NpcDataService.Print);
		}
	}
}

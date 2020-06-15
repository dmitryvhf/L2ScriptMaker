using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Models.CachedScript;
using L2ScriptMaker.Models.Dto;
using L2ScriptMaker.Services.Npc;

namespace L2ScriptMaker.Services.CachedScript
{
	public class NpcCacheService : INpcCacheService
	{
		private readonly INpcDataService _npcDataService = new NpcDataService();

		#region WinForms service
		public ServiceResult Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress)
		{
			string inNpcdataFile = Path.Combine(NpcDataDir, NpcDataFile);
			string outPchFile = Path.Combine(NpcDataDir, NpcContants.NpcCacheFileName);

			List<NpcDataDto> npcData = _npcDataService.Get(inNpcdataFile, progress).ToList();

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (var index = 0; index < npcData.Count; index++)
				{
					NpcDataDto npcDataDto = npcData[index];
					sw.WriteLine(Print(Map(npcDataDto)));
					progress.Report((int)(index * 100 / npcData.Count));
				}
			}
			
			return new ServiceResult { HasErrors = false };
		}
		#endregion

		#region Private methods
		private static NpcCache Map(NpcDataDto data)
		{
			return new NpcCache
			{
				Name = data.Name,
				Id = data.Id
			};
		}

		// 1        Gremlin
		static string Print(NpcCache model)
		{
			string formattedId = model.Id.ToString().PadRight(5);
			return $"{formattedId}\t{model.Name}";
		}
		#endregion
	}
}

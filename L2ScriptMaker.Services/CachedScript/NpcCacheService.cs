using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Models.CachedScript;
using L2ScriptMaker.Models.Npc;
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

			_npcDataService.WithProgress(progress);
			List<NpcData> npcDatas = _npcDataService.Get(inNpcdataFile).ToList();

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (var index = 0; index < npcDatas.Count; index++)
				{
					NpcData npcData = npcDatas[index];
					sw.WriteLine(Print(Map(npcData)));
					progress.Report((int)(index * 100 / npcDatas.Count));
				}
			}
			
			return new ServiceResult { HasErrors = false };
		}
		#endregion

		#region Private methods
		private static NpcCache Map(NpcData data)
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

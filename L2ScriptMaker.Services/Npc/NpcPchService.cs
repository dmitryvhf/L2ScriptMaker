using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Parsers;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcPchService : INpcPchService
	{
		private readonly INpcDataService _npcDataService = new NpcDataService();
		private readonly ParserService<NpcPch> _parser = new ParserService<NpcPch>();

		#region IProgressService implementation
		private IProgress<int> _progress;
		public void WithProgress(IProgress<int> progress) => _progress = progress;
		#endregion

		#region INpcPchService implementation
		public IEnumerable<NpcPch> Get(string dataFile)
		{
			IEnumerable<string> rawData;

			if (_progress == null)
			{
				rawData = FileUtils.Read(dataFile);
			}
			else
			{
				rawData = FileUtils.Read(dataFile, _progress);
			}
			return _parser.Do(rawData);
		}

		public List<ListItem> GetListItems(string fileName)
		{
			return Get(fileName)
				.Select(a => new ListItem { Text = a.Name, Value = a.Id.ToString() })
				.ToList();
		}
		#endregion

		#region IGenerateService implementation
		public ServiceResult Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress)
		{
			string inNpcdataFile = Path.Combine(NpcDataDir, NpcDataFile);
			string outPchFile = Path.Combine(NpcDataDir, NpcContants.NpcPchFileName);
			string outPch2File = Path.Combine(NpcDataDir, NpcContants.NpcPch2FileName);

			List<NpcData> npcData = _npcDataService.Get(inNpcdataFile).ToList();

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (var index = 0; index < npcData.Count; index++)
				{
					NpcData npcDataDto = npcData[index];
					sw.WriteLine(Print(Map(npcDataDto)));
					progress.Report((int)(index * 100 / npcData.Count));
				}
			}

			File.Create(outPch2File).Close();

			return new ServiceResult { HasErrors = false };
		}
		#endregion

		#region Private methods
		private static string Print(NpcPch model)
		{
			// [gremlin]       =       1020001
			return $"[{model.Name}] = {model.Id}";
		}

		private NpcPch Map(NpcData data)
		{
			return new NpcPch
			{
				Name = data.Name,
				Id = NpcContants.NpcPchPrefix + data.Id
			};
		}
		#endregion
	}
}

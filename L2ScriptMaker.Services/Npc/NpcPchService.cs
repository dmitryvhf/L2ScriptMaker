using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Parsers;

namespace L2ScriptMaker.Services.Npc
{
	/// <inheritdoc />
	public class NpcPchService : INpcPchService
	{
		private readonly INpcDataService _npcDataService = new NpcDataService();
		private readonly IParserService<NpcPch> _parser = ParserFactory.Get<NpcPch>();

		#region IProgressService implementation
		private IProgress<int> _progress;
		public void With(IProgress<int> progress) => _progress = progress;
		public void Unbind() => _progress = null;

		#endregion

		#region INpcPchService implementation

		/// <inheritdoc />
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

		/// <inheritdoc />
		public List<ListItem> GetListItems(string fileName)
		{
			return Get(fileName)
				.Select(a => new ListItem { Text = a.Name, Value = a.Id.ToString() })
				.ToList();
		}
		#endregion

		#region IGenerateService implementation
		public ServiceResult Generate(string dataDir, string dataFile)
		{
			string inNpcdataFile = Path.Combine(dataDir, dataFile);
			string outPchFile = Path.Combine(dataDir, NpcContants.NpcPchFileName);
			string outPch2File = Path.Combine(dataDir, NpcContants.NpcPch2FileName);

			List<NpcData> npcData = _npcDataService.Get(inNpcdataFile).ToList();

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (int index = 0; index < npcData.Count; index++)
				{
					NpcData npcDataDto = npcData[index];
					sw.WriteLine(Print(Map(npcDataDto)));
					_progress.Report(index * 100 / npcData.Count);
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

		private static NpcPch Map(NpcData data)
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

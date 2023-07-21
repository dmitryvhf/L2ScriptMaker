using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.DomainObjects;
using L2ScriptMaker.DomainObjects.Constants;
using L2ScriptMaker.DomainObjects.Contracts.Models;
using L2ScriptMaker.DomainObjects.Models.Scripts;
using L2ScriptMaker.Parsers.Services;

namespace L2ScriptMaker.Services.Scripts.Npc
{
	/// <inheritdoc />
	public class NpcPchService : INpcPchService
	{
		private readonly INpcDataService _npcDataService = new NpcDataService();
		private readonly ParserCore<NpcPch> _parser = new ParserCore<NpcPch>(Chronicles.C0);

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


			NpcPch[] result = Parse(rawData).ToArray();

			return result;
		}

		private IEnumerable<NpcPch> Parse(IEnumerable<string> lines)
		{
			IEnumerable<string> sss1 = ParseService.Collect(lines, NpcConstants.StartPrefix, NpcConstants.EndPrefix);
			foreach (string ss in sss1)
			{
				yield return _parser.Parse(ss);
			}
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

		public CommandResult Generate(string dataDir, string dataFile)
		{
			string inNpcdataFile = Path.Combine(dataDir, dataFile);
			string outPchFile = Path.Combine(dataDir, NpcConstants.NpcPchFileName);
			string outPch2File = Path.Combine(dataDir, NpcConstants.NpcPch2FileName);

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

			return CommandResult.Success();
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
				Id = NpcConstants.NpcPchPrefix + data.Id
			};
		}
		#endregion
	}
}

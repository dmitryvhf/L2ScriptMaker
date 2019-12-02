using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Parsers.Models;
using L2ScriptMaker.Parsers.Parsers.Inline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcPchService : INpcPchService
	{
		private const int NpcPchPrefix = 1_000_000;
		private static readonly IInlineParser InlineParser = new InlineParser<NpcDataDto>();

		public NpcPchService()
		{
			InlineParser.Initialize();
		}

		public NpcPch Parse(string data)
		{
			return InlineParser.Parse<NpcPch>(data);
		}

		public IEnumerable<NpcPch> Parse(IEnumerable<string> data)
		{
			IEnumerable<NpcPch> result = data.Select(Parse);
			return result;
		}

		#region WinForms service
		public void Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress)
		{
			string inNpcdataFile = Path.Combine(NpcDataDir, NpcDataFile);
			string outPchFile = Path.Combine(NpcDataDir, NpcContants.NpcPchFileName);
			string outPch2File = Path.Combine(NpcDataDir, NpcContants.NpcPch2FileName);

			// IEnumerable<string> rawNpcData = FileUtils.Read(inNpcdataFile, progress);

			using (StreamReader sr = new StreamReader(inNpcdataFile))
			{
				long dataLenght = sr.BaseStream.Length;

				using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
				{
					while (!sr.EndOfStream)
					{
						string current = sr.ReadLine();
						progress.Report((int)(sr.BaseStream.Position * 100 / dataLenght));

						NpcPch parsed = InlineParser.Parse<NpcPch>(current);
						sw.WriteLine(Print(parsed));
					}
				}
			}

			File.Create(outPch2File);

		}
		#endregion

		// [gremlin]       =       1020001
		static string Print(NpcPch model)
		{
			return $"[{model.Name}] = {NpcPchPrefix + model.Id}";
		}
	}
}

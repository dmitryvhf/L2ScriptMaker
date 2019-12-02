using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Models.CachedScript;
using L2ScriptMaker.Parsers.Models;
using L2ScriptMaker.Parsers.Parsers.Inline;
using L2ScriptMaker.Services.Npc;

namespace L2ScriptMaker.Services.CachedScript
{
	public class NpcCacheService : INpcCacheService
	{
		private static readonly IInlineParser InlineParser = new InlineParser<NpcDataDto>();

		public NpcCacheService()
		{
			InlineParser.Initialize();
		}

		public NpcCache Parse(string data)
		{
			return InlineParser.Parse<NpcCache>(data);
		}

		public IEnumerable<NpcCache> Parse(IEnumerable<string> data)
		{
			IEnumerable<NpcCache> result = data.Select(Parse);
			return result;
		}

		#region WinForms service
		public void Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress)
		{
			string inNpcdataFile = Path.Combine(NpcDataDir, NpcDataFile);
			string outPchFile = Path.Combine(NpcDataDir, NpcContants.NpcCacheFileName);

			using (StreamReader sr = new StreamReader(inNpcdataFile))
			{
				long dataLenght = sr.BaseStream.Length;

				using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
				{
					while (!sr.EndOfStream)
					{
						string current = sr.ReadLine();
						progress.Report((int)(sr.BaseStream.Position * 100 / dataLenght));

						NpcCache parsed = InlineParser.Parse<NpcCache>(current);
						sw.WriteLine(Print(parsed));
					}
				}
			}
		}
		#endregion

		// 1        Gremlin
		static string Print(NpcCache model)
		{
			string formattedId = model.Id.ToString().PadRight(5);
			return $"{formattedId}\t{model.Name}";
		}
	}
}

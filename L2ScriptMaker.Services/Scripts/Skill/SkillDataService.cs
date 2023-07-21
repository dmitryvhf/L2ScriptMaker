using System;
using System.Collections.Generic;
using System.Linq;

using L2ScriptMaker.Core.Files;
using L2ScriptMaker.DomainObjects.Constants;
using L2ScriptMaker.DomainObjects.Contracts.Models;
using L2ScriptMaker.DomainObjects.Models.Scripts;
using L2ScriptMaker.Parsers.Services;

namespace L2ScriptMaker.Services.Scripts.Skill
{
	public class SkillDataService : ISkillDataService
	{
		private readonly ParserCore<SkillData> _parser = new ParserCore<SkillData>(Chronicles.C0);

		#region IProgressService implementation

		private IProgress<int>? _progress;
		public void With(IProgress<int>? progress) => _progress = progress;
		public void Unbind() => _progress = null;

		#endregion

		#region IDataService implementation

		public IEnumerable<SkillData> Get(string dataFile)
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

			return Parse(rawData).ToArray();
		}

		private IEnumerable<SkillData> Parse(IEnumerable<string> lines)
		{
			IEnumerable<string> skillDataRows =
				ParseService.Collect(lines, SkillConstants.StartPrefix, SkillConstants.EndPrefix);
			foreach (string skillDataRow in skillDataRows)
			{
				yield return _parser.Parse(skillDataRow);
			}
		}

		#endregion
	}
}
using L2ScriptMaker.Core.Files;

using System;
using System.Collections.Generic;
using System.Linq;

namespace L2ScriptMaker.Services.Scripts.Manual
{
	public class ManualPchService
	{
		private readonly Dictionary<string, int> _abnormals = new Dictionary<string, int>();
		private readonly Dictionary<string, int> _targets = new Dictionary<string, int>();
		private readonly Dictionary<string, int> _attributes = new Dictionary<string, int>();

		public ManualPchService(string initFile)
		{
			FillManualData(initFile);
		}

		#region Public methods
		public int GetAbnormalId(string abnormal)
		{
			if (abnormal == null || abnormal == "none")
			{
				return -1;
			}

			if (!abnormal.StartsWith("ab_"))
			{
				abnormal = "ab_" + abnormal;
			}

			if (_abnormals.ContainsKey(abnormal))
			{
				return _abnormals[abnormal];
			}

			return -1; // "ab_none";
		}

		public int GetAttributeId(string attribute)
		{
			if (attribute == null)
			{
				return 0;
			}

			if (_attributes.ContainsKey(attribute))
			{
				return _attributes[attribute];
			}

			return 0; // "attr_none";
		}

		public int GetTargetId(string target)
		{
			if (target == null)
			{
				return 0;
			}

			target = "stgt_" + target;

			if (_targets.ContainsKey(target))
			{
				return _targets[target];
			}

			return 0; // "self";
		}
		#endregion

		#region Private methods
		private void FillManualData(string FileName)
		{
			string[] manualPchData = FileUtils.Read(FileName).Where(FilterSkillAttributes).ToArray();

			ParseManualPch(manualPchData, "[ab_", _abnormals);
			ParseManualPch(manualPchData, "[STGT_", _targets);
			ParseManualPch(manualPchData, "[attr_", _attributes);
		}

		private static bool FilterSkillAttributes(string a)
		{
			return a.StartsWith("[ab_") || a.StartsWith("[attr_") || a.StartsWith("[STGT_");
		}

		private static void ParseManualPch(string[] manualPchData, string prefix, Dictionary<string, int> dictionary)
		{
			// string regexPattern = $"\\[{prefix}[a-zA-Z_]\\]\\s?=\\s?\\d";

			string pref = prefix.ToLower();
			foreach (string raw in manualPchData)
			{
				string line = raw.ToLower().Trim();
				if (!line.StartsWith(pref))
				{
					continue;
				}

				// [ab_pa_up]      =       0
				string[] data = line.Split('=');
				string key = data[0].Trim();
				int value = Convert.ToInt32(data[1].Trim());

				key = key.Substring(1, key.Length - 2);

				// if (trimPrefix) key = key.Substring(prefix.Length - 1);

				dictionary.Add(key, value);
			}
		}
		#endregion
	}
}

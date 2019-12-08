using L2ScriptMaker.Parsers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Models.Skill;
using L2ScriptMaker.Core.Files;

namespace L2ScriptMaker.Services.Skill
{
	public class SkillPchService : ISkillPchService
	{
		private readonly SkillDataService _skillDataService = new SkillDataService();
		private readonly SkillPchOptions _options;

		private Dictionary<string, int> abnormals = new Dictionary<string, int>();
		private Dictionary<string, int> targets = new Dictionary<string, int>();
		private Dictionary<string, int> attributes = new Dictionary<string, int>();

		public SkillPchService(SkillPchOptions options)
		{
			_options = options;
		}

		private void ParseManualPch(string prefix, Dictionary<string, int> dictionary, bool trimPrefix = false)
		{
			string pref = prefix.ToLower();
			foreach (string raw in _options.ManualPchAttributes)
			{
				string line = raw.ToLower().Trim();
				if (String.IsNullOrWhiteSpace(line) || line.StartsWith("//") || !line.StartsWith(pref)) continue;

				// [ab_pa_up]      =       0
				string[] data = line.Split('=');
				string key = data[0].Trim();
				int value = Convert.ToInt32(data[1].Trim());

				key = key.Substring(1, key.Length - 2);

				if (trimPrefix) key = key.Substring(prefix.Length - 1);

				dictionary.Add(key, value);
			}
		}


		#region WinForms service
		public void Generate(string SkillDataDir, string SkillDataFile, IProgress<int> progress)
		{
			ParseManualPch("[ab_", abnormals);
			ParseManualPch("[STGT_", targets, true);
			ParseManualPch("[attr_", attributes);

			string inNpcdataFile = Path.Combine(SkillDataDir, SkillDataFile);
			string outPchFile = Path.Combine(SkillDataDir, SkillContants.SkillPchFileName);
			string outPch2File = Path.Combine(SkillDataDir, SkillContants.SkillPch2FileName);
			// outPch3File

			IEnumerable<string> rawNpcData = FileUtils.Read(inNpcdataFile);
			List<SkillDataDto> skillData = _skillDataService.Parse(rawNpcData).ToList();

			StreamWriter sw2 = new StreamWriter(outPch2File, false, Encoding.Unicode);

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (var index = 0; index < skillData.Count; index++)
				{
					SkillDataDto npcDataDto = skillData[index];
					SkillPch pch = Map(npcDataDto);
					SkillPch2 pch2 = MapPch2(npcDataDto);

					sw.WriteLine(Print(pch));
					sw2.WriteLine(Print(pch2));

					progress.Report((int)(index * 100 / skillData.Count));
				}
			}

			// File.Create(outPch2File).Close();
			sw2.Close();
			sw2.Dispose();
		}
		#endregion

		#region Private methods
		private static SkillPch Map(SkillDataDto data)
		{
			return new SkillPch
			{
				Name = data.Name,
				Id = data.SkillId * SkillContants.SkillUniqueIdMultiplier + data.Level
			};
		}

		// [s_power_strike11] = 769
		private static string Print(SkillPch model)
		{
			return $"[{model.Name}] = {model.Id}";
		}
		#endregion

		#region Private methods Pch2
		private SkillPch2 MapPch2(SkillDataDto data)
		{
			int hitTime = CalculateHitTime(data.HitTime, data.CoolTime);
			int cooldownTime = CalculateReuseCooldown(data.ReuseDelay, data.HitTime, data.HitCancelTime, data.CoolTime);

			int targetTypeId = CalculateTargetTypeId(data.TargetType);
			int attributeId = CalculateAttributeId(data.Attribute);
			int abnormalTypeId = CalculateAbnormalTypeId(data.AbnormalType);

			return new SkillPch2
			{
				Id = data.SkillId * SkillContants.SkillUniqueIdMultiplier + data.Level,
				CastRange = data.CastRange,
				HpConsume = data.HpConsume,
				MpConsume2 = data.MpConsume2,
				TargetTypeId = targetTypeId,
				EffectPoint = data.EffectPoint,
				AttributeId = attributeId,
				AbnormalTypeId = abnormalTypeId,
				AbnormalLevel = data.AbnormalLevel,
				HitTime = hitTime,
				ReuseCooldown = cooldownTime,
				IsMagic = data.IsMagic
			};
		}

		private int CalculateTargetTypeId(string targetType)
		{
			if (targetType == null) return 0;

			if (targets.ContainsKey(targetType)) return targets[targetType];

			return 0; // "self";
		}

		private int CalculateAttributeId(string attribute)
		{
			if (attribute == null) return 0;

			if (attributes.ContainsKey(attribute)) return attributes[attribute];

			return 0; // "attr_none";
		}

		private int CalculateAbnormalTypeId(string abnormalType)
		{
			if (abnormalType == null || abnormalType == "none") return -1;

			if (abnormalType == "none" || abnormals.ContainsKey(abnormalType)) 
				return abnormals[abnormalType];

			return -1; // "attr_none";
		}

		private static int CalculateHitTime(double HitTime, double CoolTime)
		{
			if (HitTime == 0) return 0;

			double result = Math.Round((HitTime + CoolTime), MidpointRounding.AwayFromZero);

			return Convert.ToInt32(result);
		}

		private static int CalculateReuseCooldown(double ReuseDelay, double HitTime, double hitCancelTime, double CoolTime)
		{
			double result = Math.Round((ReuseDelay - (HitTime - hitCancelTime) - CoolTime), MidpointRounding.AwayFromZero);

			// double result = Math.Round((ReuseDelay - HitTime - CoolTime), MidpointRounding.AwayFromZero);

			return Convert.ToInt32(result);
		}

		// 769 40 0 10 3 -52 34 -1 0 2 11 0 -12345
		private static string Print(SkillPch2 model)
		{
			string[] skillPch2Params = new string[]
			{
				model.Id.ToString(),
				model.CastRange.ToString(),
				model.HpConsume.ToString(),
				model.MpConsume2.ToString(),
				model.TargetTypeId.ToString(),
				model.EffectPoint.ToString(),
				model.AttributeId.ToString(),
				model.AbnormalTypeId.ToString(),
				model.AbnormalLevel.ToString(),
				model.HitTime.ToString(),
				model.ReuseCooldown.ToString(),
				model.IsMagic.ToString(),
				"-12345"
			};

			return String.Join(" ", skillPch2Params);
		}
		#endregion
	}
}

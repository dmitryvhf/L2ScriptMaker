using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Models.Skill;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Models.Dto;
using L2ScriptMaker.Services.Manual;

namespace L2ScriptMaker.Services.Skill
{
	public class SkillPchService : ISkillPchService
	{
		private readonly SkillDataService _skillDataService = new SkillDataService();
		private readonly SkillPchOptions _options;
		private readonly ManualPchService _manualPchService;

		public SkillPchService(SkillPchOptions options)
		{
			_options = options;

			if(String.IsNullOrWhiteSpace(_options.ManualPchFile)) throw new ArgumentException("manual_pch");
			_manualPchService = new ManualPchService(_options.ManualPchFile);
		}

		#region WinForms service
		public ServiceResult Generate(string SkillDataDir, string SkillDataFile, IProgress<int> progress)
		{
			string inNpcdataFile = Path.Combine(SkillDataDir, SkillDataFile);
			string outPchFile = Path.Combine(SkillDataDir, SkillContants.SkillPchFileName);
			string outPch2File = Path.Combine(SkillDataDir, SkillContants.SkillPch2FileName);
			string outPch3File = Path.Combine(SkillDataDir, SkillContants.SkillPch3FileName);

			IEnumerable<string> rawNpcData = FileUtils.Read(inNpcdataFile);
			IEnumerable<string> collectedRecord = _skillDataService.Collect(rawNpcData);
			List<SkillDataDto> skillData = _skillDataService.Parse(collectedRecord).ToList();

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

			sw2.Close();
			sw2.Dispose();
			File.Create(outPch3File).Close();

			return new ServiceResult { HasErrors = false };
		}
		#endregion

		#region Private methods
		private SkillPch Map(SkillDataDto data)
		{
			return new SkillPch
			{
				Name = data.Name,
				Id = data.SkillId * SkillContants.SkillIdMultiplierV1 + data.Level
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

			int targetTypeId = _manualPchService.GetTargetId(data.TargetType);
			int attributeId = _manualPchService.GetAttributeId(data.Attribute);
			int abnormalTypeId = _manualPchService.GetAbnormalId(data.AbnormalType);

			return new SkillPch2
			{
				Id = data.SkillId * SkillContants.SkillIdMultiplierV1 + data.Level,
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

		private static int CalculateHitTime(double HitTime, double CoolTime)
		{
			if (HitTime == 0) return 0;

			double result = Math.Round((HitTime + CoolTime), MidpointRounding.AwayFromZero);

			return Convert.ToInt32(result);
		}

		private static int CalculateReuseCooldown(double ReuseDelay, double HitTime, double hitCancelTime, double CoolTime)
		{
			// double result = Math.Round((ReuseDelay - (HitTime - hitCancelTime) - CoolTime), MidpointRounding.AwayFromZero);
			// double result = Math.Round((ReuseDelay - HitTime - CoolTime), MidpointRounding.AwayFromZero);
			// double result = (ReuseDelay - (HitTime - hitCancelTime));
			double result = Math.Round((ReuseDelay - HitTime - CoolTime), MidpointRounding.AwayFromZero);

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

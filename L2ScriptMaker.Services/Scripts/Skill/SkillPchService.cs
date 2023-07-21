using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using L2ScriptMaker.DomainObjects.Constants;
using L2ScriptMaker.DomainObjects.Models.Scripts;
using L2ScriptMaker.Services.Scripts.Manual;

namespace L2ScriptMaker.Services.Scripts.Skill
{
	public class SkillPchService : ISkillPchService
	{
		private readonly SkillDataService _skillDataService = new SkillDataService();
		private readonly ManualPchService _manualPchService;
		private IProgress<int>? _progress;

		public SkillPchService(SkillPchOptions options)
		{
			if (string.IsNullOrWhiteSpace(options.ManualPchFile))
			{
				throw new ArgumentException("manual_pch");
			}

			_manualPchService = new ManualPchService(options.ManualPchFile);
		}

		#region IProgressService implementation

		public void With(IProgress<int> progress)
		{
			_progress = progress;
		}

		public void Unbind() => _progress = null;

		#endregion

		#region IGenerateService implementation
		public CommandResult Generate(string dataDir, string dataFile)
		{
			string inSkillDataFile = Path.Combine(dataDir, dataFile);
			string outPchFile = Path.Combine(dataDir, SkillConstants.SkillPchFileName);
			string outPch2File = Path.Combine(dataDir, SkillConstants.SkillPch2FileName);
			string outPch3File = Path.Combine(dataDir, SkillConstants.SkillPch3FileName);

			_skillDataService.With(_progress);
			List<SkillData> skillDatas = _skillDataService.Get(inSkillDataFile).ToList();

			StreamWriter sw2 = new StreamWriter(outPch2File, false, Encoding.Unicode);

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (int index = 0; index < skillDatas.Count; index++)
				{
					SkillData skillData = skillDatas[index];
					SkillPch pch = Map(skillData);
					SkillPch2 pch2 = MapPch2(skillData);

					sw.WriteLine(Print(pch));
					sw2.WriteLine(Print(pch2));

					_progress?.Report(index * 100 / skillDatas.Count);
				}
			}

			sw2.Close();
			sw2.Dispose();
			File.Create(outPch3File).Close();

			return CommandResult.Success();
		}
		#endregion

		#region Private methods
		private static SkillPch Map(SkillData data)
		{
			return new SkillPch
			{
				Name = data.Name,
				Id = data.SkillId * SkillConstants.SkillIdMultiplierV1 + data.Level
			};
		}

		// [s_power_strike11] = 769
		private static string Print(SkillPch model)
		{
			return $"[{model.Name}] = {model.Id}";
		}
		#endregion

		#region Private methods Pch2
		private SkillPch2 MapPch2(SkillData data)
		{
			int mpConsume = CalculateMpConsume(data.MpConsume1, data.MpConsume2);
			int hitTime = CalculateHitTime(data.HitTime, data.CoolTime);
			int cooldownTime = CalculateReuseCooldown(data.ReuseDelay, data.HitTime, data.HitCancelTime, data.CoolTime);

			int targetTypeId = _manualPchService.GetTargetId(data.TargetType);
			int attributeId = _manualPchService.GetAttributeId(data.Attribute);
			int abnormalTypeId = _manualPchService.GetAbnormalId(data.AbnormalType);

			return new SkillPch2
			{
				Id = data.SkillId * SkillConstants.SkillIdMultiplierV1 + data.Level,
				CastRange = data.CastRange,
				HpConsume = data.HpConsume,
				MpConsume = mpConsume,
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

		/// <summary>
		///		Calculate mana consume
		/// </summary>
		/// <param name="mpConsume1">Activate using mana consume</param>
		/// <param name="mpConsume2">Next casting mana consume</param>
		/// <returns>Full mana consume</returns>
		private static int CalculateMpConsume(int mpConsume1, int mpConsume2)
		{
			return Convert.ToInt32(mpConsume1 + mpConsume2);
		}

		/// <summary>
		///		Calculate skill hit time
		/// </summary>
		/// <param name="hitTime">Skill cast time</param>
		/// <param name="coolTime">No cancel casting time</param>
		/// <returns>Full hit casting time</returns>
		private static int CalculateHitTime(double hitTime, double coolTime)
		{
			if (hitTime == 0)
			{
				return 0;
			}

			double result = Math.Round(hitTime + coolTime, MidpointRounding.AwayFromZero);

			return Convert.ToInt32(result);
		}

		/// <summary>
		///		Calculate skill cooldown time
		/// </summary>
		/// <param name="reuseDelay">Skill reuse delay</param>
		/// <param name="hitTime">Skill cast time</param>
		/// <param name="hitCancelTime">Time for available cancelling</param>
		/// <param name="coolTime">Cooldown time</param>
		/// <returns></returns>
		private static int CalculateReuseCooldown(double reuseDelay, double hitTime, double hitCancelTime, double coolTime)
		{
			// double result = Math.Round((ReuseDelay - (HitTime - hitCancelTime) - CoolTime), MidpointRounding.AwayFromZero);
			// double result = Math.Round((ReuseDelay - HitTime - CoolTime), MidpointRounding.AwayFromZero);
			// double result = (ReuseDelay - (HitTime - hitCancelTime));
			double result = Math.Round(reuseDelay - hitTime - coolTime, MidpointRounding.AwayFromZero);

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
				model.MpConsume.ToString(),
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

			return string.Join(" ", skillPch2Params);
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Models.Skill
{
	public class SkillData
	{
		// P
		public string Name { get; set; }
		public int SkillId { get; set; }
		public int Level { get; set; }
		public string Type { get; set; }
		public int MagicLevel { get; set; }
		public string Effect { get; set; }

		// T
		public int MpConsume1 { get; set; }
		public int HpConsume { get; set; }
		public double ReuseDelay { get; set; }
		public string TargetType { get; set; }
		public string NextAction { get; set; }
		public string RideState { get; set; }

		// A1
		public string Condition { get; set; }
		public int IsMagic { get; set; }
		public int MpConsume2 { get; set; }
		public int CastRange { get; set; }
		public int EffectiveRange { get; set; }
		public double HitTime { get; set; }
		public double CoolTime { get; set; }
		public double HitCancelTime { get; set; }
		public string Attribute { get; set; }
		public int EffectPoint { get; set; }
		public string AffectScope { get; set; }
		public string AffectLimit { get; set; }

		// A2
		public int ActivateRate { get; set; }
		public int LevelBonusRate { get; set; }
		public string BasicProperty { get; set; }
		public int AbnormalTime { get; set; }
		public int AbnormalLevel { get; set; }
		public string AbnormalType { get; set; }
		public int Debuff { get; set; }
	}
}

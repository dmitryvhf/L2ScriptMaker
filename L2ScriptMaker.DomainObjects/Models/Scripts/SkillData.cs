using System;

using L2ScriptMaker.DomainObjects.Contracts;
using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.DomainObjects.Contracts.Models;

namespace L2ScriptMaker.DomainObjects.Models.Scripts
{
	[ScriptRecord("skill_begin", "skill_end")]
	public class SkillData : IScript
	{
		// P
		[KeyValue("skill_name")]
		[Wrap(Brackets.Square)]
		public string Name { get; set; } = String.Empty;

		[KeyValue("skill_id")]
		public int SkillId { get; set; }

		[KeyValue("level")]
		public int Level { get; set; }

		[KeyValue("operate_type")]
		public string Type { get; set; } = String.Empty;

		[KeyValue("magic_level")]
		public int MagicLevel { get; set; }

		[KeyValue("effect")]
		public string Effect { get; set; } = String.Empty;

		// T
		[KeyValue("mp_consume1")]
		public int MpConsume1 { get; set; }

		[KeyValue("hp_consume1")]
		public int HpConsume { get; set; }

		[KeyValue("reuse_delay")]
		public double ReuseDelay { get; set; }

		[KeyValue("target_type")]
		public string TargetType { get; set; } = String.Empty;

		[KeyValue("next_action")]
		public string NextAction { get; set; } = String.Empty;

		[KeyValue("ride_state")]
		public string RideState { get; set; } = String.Empty;

		// A1
		[KeyValue("operate_cond")]
		public string Condition { get; set; } = String.Empty;

		[KeyValue("is_magic")]
		public int IsMagic { get; set; }

		[KeyValue("mp_consume2")]
		public int MpConsume2 { get; set; }

		[KeyValue("cast_range")]
		public int CastRange { get; set; }

		[KeyValue("effective_range")]
		public int EffectiveRange { get; set; }

		[KeyValue("skill_hit_time")]
		public double HitTime { get; set; }

		[KeyValue("skill_cool_time")]
		public double CoolTime { get; set; }

		[KeyValue("skill_hit_cancel_time")]
		public double HitCancelTime { get; set; }

		[KeyValue("attribute")]
		public string Attribute { get; set; } = String.Empty;

		[KeyValue("effect_point")]
		public int EffectPoint { get; set; }

		[KeyValue("affect_scope")]
		public string AffectScope { get; set; } = String.Empty;

		[KeyValue("affect_limit")]
		public string AffectLimit { get; set; } = String.Empty;

		// A2
		[KeyValue("activate_rate")]
		public int ActivateRate { get; set; }

		[KeyValue("lv_bonus_rate")]
		public int LevelBonusRate { get; set; }

		[KeyValue("basic_property")]
		public string BasicProperty { get; set; } = String.Empty;

		[KeyValue("abnormal_time")]
		public int AbnormalTime { get; set; }

		[KeyValue("abnormal_lv")]
		public int AbnormalLevel { get; set; }

		[KeyValue("abnormal_type")]
		public string AbnormalType { get; set; } = String.Empty;

		[KeyValue("debuff")]
		public int Debuff { get; set; }
	}
}

using L2ScriptMaker.Core.Attributes;

namespace L2ScriptMaker.Models.Dto
{
	[Record(HasBrackets = true, StartBracket = "skill_begin", EndBracket = "skill_end")]
	public class SkillDataDto
	{
		// P
		[RecordParam("skill_name", Brackets = Brackets.Square)]
		public string Name { get; set; }

		[RecordParam("skill_id")]
		public int SkillId { get; set; }

		[RecordParam("level")]
		public int Level { get; set; }

		[RecordParam("operate_type")]
		public string Type { get; set; }

		[RecordParam("magic_level")]
		public int MagicLevel { get; set; }

		[RecordParam("effect")]
		public string Effect { get; set; }

		// T
		[RecordParam("mp_consume1")]
		public int MpConsume1 { get; set; }

		[RecordParam("hp_consume1")]
		public int HpConsume { get; set; }

		[RecordParam("reuse_delay")]
		public double ReuseDelay { get; set; }

		[RecordParam("target_type")]
		public string TargetType { get; set; }

		[RecordParam("next_action")]
		public string NextAction { get; set; }
		
		[RecordParam("ride_state")]
		public string RideState { get; set; }

		// A1
		[RecordParam("operate_cond")]
		public string Condition { get; set; }

		[RecordParam("is_magic")]
		public int IsMagic { get; set; }

		[RecordParam("mp_consume2")]
		public int MpConsume2 { get; set; }

		[RecordParam("cast_range")]
		public int CastRange { get; set; }

		[RecordParam("effective_range")]
		public int EffectiveRange { get; set; }

		[RecordParam("skill_hit_time")]
		public double HitTime { get; set; }

		[RecordParam("skill_cool_time")]
		public double CoolTime { get; set; }

		[RecordParam("skill_hit_cancel_time")]
		public double HitCancelTime { get; set; }

		[RecordParam("attribute")]
		public string Attribute { get; set; }

		[RecordParam("effect_point")]
		public int EffectPoint { get; set; }

		[RecordParam("affect_scope")]
		public string AffectScope { get; set; }

		[RecordParam("affect_limit")]
		public string AffectLimit { get; set; }

		// A2
		[RecordParam("activate_rate")]
		public int ActivateRate { get; set; }

		[RecordParam("lv_bonus_rate")]
		public int LevelBonusRate { get; set; }

		[RecordParam("basic_property")]
		public string BasicProperty { get; set; }

		[RecordParam("abnormal_time")]
		public int AbnormalTime { get; set; }

		[RecordParam("abnormal_lv")]
		public int AbnormalLevel { get; set; }

		[RecordParam("abnormal_type")]
		public string AbnormalType { get; set; }

		[RecordParam("debuff")]
		public int Debuff { get; set; }
	}
}

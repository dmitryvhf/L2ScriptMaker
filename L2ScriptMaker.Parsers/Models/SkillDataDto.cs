using L2ScriptMaker.Parsers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Parsers.Models
{
	[Script]
	public class SkillDataDto
	{
		// P
		[ScriptParam("skill_name", TrimLR = true)]
		public string Name { get; set; }

		[ScriptParam("skill_id")]
		public int SkillId { get; set; }

		[ScriptParam("level")]
		public int Level { get; set; }

		[ScriptParam("operate_type")]
		public string Type { get; set; }

		[ScriptParam("magic_level")]
		public int MagicLevel { get; set; }

		[ScriptParam("effect")]
		public string Effect { get; set; }

		// T
		[ScriptParam("mp_consume1")]
		public int MpConsume1 { get; set; }

		[ScriptParam("hp_consume1")]
		public int HpConsume { get; set; }

		[ScriptParam("reuse_delay")]
		public double ReuseDelay { get; set; }

		[ScriptParam("target_type")]
		public string TargetType { get; set; }

		[ScriptParam("next_action")]
		public string NextAction { get; set; }
		
		[ScriptParam("ride_state")]
		public string RideState { get; set; }

		// A1
		[ScriptParam("operate_cond")]
		public string Condition { get; set; }

		[ScriptParam("is_magic")]
		public int IsMagic { get; set; }

		[ScriptParam("mp_consume2")]
		public int MpConsume2 { get; set; }

		[ScriptParam("cast_range")]
		public int CastRange { get; set; }

		[ScriptParam("effective_range")]
		public int EffectiveRange { get; set; }

		[ScriptParam("skill_hit_time")]
		public double HitTime { get; set; }

		[ScriptParam("skill_cool_time")]
		public double CoolTime { get; set; }

		[ScriptParam("skill_hit_cancel_time")]
		public double HitCancelTime { get; set; }

		[ScriptParam("attribute")]
		public string Attribute { get; set; }

		[ScriptParam("effect_point")]
		public int EffectPoint { get; set; }

		[ScriptParam("affect_scope")]
		public string AffectScope { get; set; }

		[ScriptParam("affect_limit")]
		public string AffectLimit { get; set; }

		// A2
		[ScriptParam("activate_rate")]
		public int ActivateRate { get; set; }

		[ScriptParam("lv_bonus_rate")]
		public int LevelBonusRate { get; set; }

		[ScriptParam("basic_property")]
		public string BasicProperty { get; set; }

		[ScriptParam("abnormal_time")]
		public int AbnormalTime { get; set; }

		[ScriptParam("abnormal_lv")]
		public int AbnormalLevel { get; set; }

		[ScriptParam("abnormal_type")]
		public string AbnormalType { get; set; }

		[ScriptParam("debuff")]
		public int Debuff { get; set; }
	}
}

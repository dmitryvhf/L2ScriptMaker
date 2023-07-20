using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Models.Skill
{
	public class SkillPch2
	{
		public int Id { get; set; }
		public int CastRange { get; set; }
		public int HpConsume { get; set; }
		public int MpConsume { get; set; }
		public int TargetTypeId { get; set; }
		public int EffectPoint { get; set; }
		public int AttributeId { get; set; }
		public int AbnormalTypeId { get; set; }
		public int AbnormalLevel { get; set; }
		public int HitTime { get; set; }
		public int ReuseCooldown { get; set; }
		public int IsMagic { get; set; }
	}
}

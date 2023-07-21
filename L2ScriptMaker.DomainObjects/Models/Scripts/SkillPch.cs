using System;

using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.DomainObjects.Contracts.Models;

namespace L2ScriptMaker.DomainObjects.Models.Scripts
{
	[ScriptRecord]
	public class SkillPch
	{
		[Position(Number = 0)]
		[Wrap(Brackets.Square)]
		public string Name { get; set; }

		[Position(Number = 2)]
		public int Id { get; set; }

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
		}
	}
}

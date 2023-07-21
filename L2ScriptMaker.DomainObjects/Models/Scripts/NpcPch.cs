using System;

using L2ScriptMaker.DomainObjects.Contracts;
using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.DomainObjects.Contracts.Models;

namespace L2ScriptMaker.DomainObjects.Models.Scripts
{
	[ScriptRecord]
	public class NpcPch : IScript
	{
		[Position(Number = 0)]
		[Wrap(Brackets.Square)]
		public string Name { get; set; } = String.Empty;

		[Position(Number = 2)]
		public Int32 Id { get; set; }

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
		}
	}
}

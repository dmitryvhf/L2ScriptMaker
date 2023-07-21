using L2ScriptMaker.DomainObjects.Contracts;
using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.DomainObjects.Contracts.Models;

namespace L2ScriptMaker.DomainObjects.Models.Scripts
{
	[ScriptRecord("npcdata_begin", "npcdata_end")]
	public class NpcData : IScript
	{
		[Position(Number = 1)]
		public string Type { get; set; } = string.Empty;

		[Position(Number = 2)]
		public int Id { get; set; }

		[Position(Number = 3)]
		[Wrap(Brackets.Square)]
		public string Name { get; set; } = string.Empty;

		[KeyValue("level")]
		public string Level { get; set; } = string.Empty;

		public override string ToString()
		{
			return $"{nameof(Type)}: {Type}, {nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Level)}: {Level}";
		}
	}
}

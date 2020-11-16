using L2ScriptMaker.Core.Attributes;
using L2ScriptMaker.Parsers.Attributes;

namespace L2ScriptMaker.Parsers.Dto
{
	[Record(HasBrackets = true, StartBracket = "npcdata_begin", EndBracket = "npcdata_end")]
	internal class NpcDataDto
	{
		[RecordParam(2)]
		public string Type { get; set; }

		[RecordParam(3)]
		public int Id { get; set; }

		[RecordParam(4, Brackets = Brackets.Square)]
		public string Name { get; set; }

		[RecordParam("level")]
		public string Level { get; set; }

		public override string ToString()
		{
			return $"{nameof(Type)}: {Type}, {nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Level)}: {Level}";
		}
	}
}

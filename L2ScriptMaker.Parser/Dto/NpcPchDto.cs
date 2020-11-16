using L2ScriptMaker.Core.Attributes;
using L2ScriptMaker.Parsers.Attributes;

namespace L2ScriptMaker.Parsers.Dto
{
	[Record(HasBrackets = false)]
	internal class NpcPchDto
	{
		[RecordParam(1, Brackets = Brackets.Square)]
		public string Name { get; set; }

		[RecordParam(2)]
		public string Id { get; set; }

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
		}
	}
}

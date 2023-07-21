using System;

using L2ScriptMaker.DomainObjects.Contracts;
using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.DomainObjects.Contracts.Models;
using L2ScriptMaker.DomainObjects.Models.Collections;

namespace L2ScriptMaker.DomainObjects.Models.Scripts
{
	[ScriptRecord("item_begin", "item_end")]
	public class ItemData : IScript
	{
		[Position(Number = 1)]
		public string Type { get; set; } = string.Empty;

		[Position(Number = 2)]
		public int Id { get; set; }

		[Position(Number = 3)]
		[Wrap(Brackets.Square)]
		public string Name { get; set; } = string.Empty;

		[KeyValue("item_type")]
		public ItemTypes ItemType { get; set; }

		[KeyValue("slot_bit_type")]
		[Wrap(Brackets.Decorative)]
		public SlotType SlotType { get; set; }

		[KeyValue("armor_type")]
		public ArmorTypes ArmorType { get; set; }
	}
}

using System.ComponentModel;

namespace L2ScriptMaker.DomainObjects.Contracts.Models
{
	/// <summary>
	///		Lineage II Chronicles timeline codenames
	/// </summary>
	/// <see href="https://en.wikipedia.org/wiki/Lineage_II"/>
	public enum Chronicles
	{
		// The Chaotic Chronicles
		[Description("Prelude")]
		C0,
		[Description("Chronicle 1: Harbingers of War")]
		C1,
		[Description("Chronicle 2: Age of Splendor")]
		C2,
		[Description("Chronicle 3: Rise of Darkness")]
		C3,
		[Description("Chronicle 4: Scions of Destiny")]
		C4,
		[Description("Chronicle 5: Oath of Blood")]
		C5,

		// The Chaotic Throne
		[Description("Interlude")]
		CT0,
		[Description("The Kamael")]
		CT1,
		[Description("Hellbound / Kamael Plus")]
		CT1_5,
		[Description("Gracia Part 1")]
		CT2_1,
		[Description("Gracia Part 2")]
		CT2_2,
		[Description("Gracia Final")]
		CT2_3,
		[Description("Gracia Epilogue / Gracia Plus")]
		CT2_4,
		[Description("Freya")]
		CT2_5,
		[Description("High Five")]
		CT2_5_1,
		[Description("High Five Part 2")]
		CT2_5_2,
		[Description("High Five Part 3")]
		CT2_5_3,
		[Description("High Five / High Five Part 4")]
		CT2_6,
		[Description("High Five Part 5")]
		CT2_6_1,

		// Goddess of Destruction (Free2Play)
		[Description("Awakening")]
		GD1,
		[Description("Harmony")]
		GD1_5,
		[Description("Tauti")]
		GD2,
		[Description("Glory Days")]
		GD2_5,
		[Description("Echo")]
		GD2_5_1,
		[Description("Power of the West Wind")]
		GD2_5_2,
		[Description("Lindvior / Ruler of the West Wind")]
		GD3,
		[Description("Episodeon")]
		GD3_1,
		[Description("Valiance / Raiders")]
		GD3_5,

		// Epic Tale Of Aden (The Conquest of Echelon)
		[Description("Ertheia / Dimensional Strangers")]
		EP1,
		[Description("Infinite Odyssey: Prelude to the Journey")]
		EP1_1,
		[Description("Infinite Odyssey")]
		EP1_2,
		[Description("Infinite Odyssey / Infinite Odyssey: Shadows of Light Part 1")]
		EP2,
		[Description("Infinite Odyssey: Shadows of Light Part 2")]
		EP2_1,
		[Description("Underground / Infinite Odyssey: Hymn of the Soul")]
		EP2_5,
		[Description("Infinite Odyssey: Will of the Ancients")]
		EP2_5_1,
		[Description("Helios")]
		EP3,
		[Description("Grand Crusade")]
		EP3_1,
		[Description("Grand Crusade / Grand Crusade: Force Bringer")]
		EP4,
		[Description("Salvation: First Chapter / The Page: Salvation")]
		EP5,
		[Description("Salvation: The Gathering")]
		EP5_1
	}
}

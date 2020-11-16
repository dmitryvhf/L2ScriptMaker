using System;

namespace L2ScriptMaker.Core.Attributes
{
	public enum Brackets
	{
		None,
		Square,
		Round
	}


	[AttributeUsage(AttributeTargets.Property)]
	public class RecordParamAttribute : Attribute
	{
		public bool ByName { get; }

		public int? Index { get; }
		public string Name { get; }
		public Brackets Brackets { get; set; }

		public RecordParamAttribute(string param)
		{
			Name = param;
			ByName = true;
		}

		public RecordParamAttribute(int index)
		{
			Index = index;
			ByName = false;
		}
	}

}

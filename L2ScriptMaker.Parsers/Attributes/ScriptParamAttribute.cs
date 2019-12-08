using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Parsers.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	internal class ScriptParamAttribute : Attribute
	{
		public bool ByName { get; }

		public int? FieldNum { get; }

		public string FieldName { get; }

		public bool TrimLR { get; set; }

		public ScriptParamAttribute(string param)
		{
			FieldName = param;
			ByName = true;
		}

		public ScriptParamAttribute(int fieldNum)
		{
			FieldNum = fieldNum;
			ByName = false;
		}
	}
}

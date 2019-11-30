using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Parsers.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	class InlineScriptParamAttribute : Attribute
	{
		public bool ByName { get; }

		public int? FieldNum { get; }

		public string FieldName { get; }

		public bool TrimLR { get; set; }

		public InlineScriptParamAttribute(string param)
		{
			FieldName = param;
			ByName = true;
		}

		public InlineScriptParamAttribute(int fieldNum)
		{
			FieldNum = fieldNum;
			ByName = false;
		}
	}
}

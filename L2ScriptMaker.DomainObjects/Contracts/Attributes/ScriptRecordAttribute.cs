using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using L2ScriptMaker.DomainObjects.Contracts;

namespace L2ScriptMaker.DomainObjects.Contracts.Attributes
{
	/// <summary>
	///		Server script record
	/// </summary>
	/// <remarks>Defined:
	/// <br />- wrap tags;
	/// <br />- list of values.
	/// </remarks>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class ScriptRecordAttribute : Attribute, IParseSetting
	{
		/// <summary>
		///		Begin tag
		/// </summary>
		public string Begin { get; } = String.Empty;

		/// <summary>
		///		End tag
		/// </summary>
		public string End { get; } = String.Empty;

		public bool HasBrackets { get; }

		public ScriptRecordAttribute()
		{
			HasBrackets = false;
		}

		public ScriptRecordAttribute(string begin, string end)
		{
			HasBrackets = true;

			Begin = begin;
			End = end;
		}
	}
}

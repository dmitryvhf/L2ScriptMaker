using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using L2ScriptMaker.DomainObjects.Contracts;

namespace L2ScriptMaker.DomainObjects.Contracts.Attributes
{
	/// <summary>
	///		Value with absolute position into record
	/// </summary>
	/// <remarks>Position defined after splitting record by part</remarks>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public class PositionAttribute : Attribute, IParseSetting
	{
		/// <summary>
		/// Value column position
		/// </summary>
		/// <remarks>Begin from 0 (zero)</remarks>
		public Int32 Number { get; set; }
	}
}

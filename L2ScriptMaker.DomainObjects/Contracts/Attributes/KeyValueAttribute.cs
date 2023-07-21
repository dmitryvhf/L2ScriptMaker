using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using L2ScriptMaker.DomainObjects.Contracts;

namespace L2ScriptMaker.DomainObjects.Contracts.Attributes
{
	/// <summary>
	///		Naming value
	/// </summary>
	/// <remarks>
	/// Common value with naming key.
	/// Default key separating character and value - equal sign [=]
	/// </remarks>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public class KeyValueAttribute : Attribute, IParseSetting
	{
		/// <summary>
		///		Key for script record value
		/// </summary>
		public string Key { get; set; }

		public KeyValueAttribute(string key)
		{
			Key = key;
		}
	}
}

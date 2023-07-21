using System;
using System.Linq;

using L2ScriptMaker.DomainObjects.Contracts.Models;

namespace L2ScriptMaker.DomainObjects.Contracts.Attributes
{
	/// <summary>
	///		Define compatible chronicles server script version
	/// </summary>
	/// <remarks>
	/// Minimum version and above.
	/// Maximum version is not defined yet.
	/// </remarks>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field,
		AllowMultiple = false, Inherited = false)]
	public class ChroniclesCompatibleAttribute : Attribute, IParseSetting
	{
		/// <summary>
		///     Compatible chronicles
		/// </summary>
		public Chronicles[] Version { get; set; }

		/// <summary>
		///     Required full compatibile
		/// </summary>
		public bool Required { get; set; }

		public ChroniclesCompatibleAttribute(Chronicles[] version, bool required = false)
		{
			Version = version;
			Required = required;
		}

		/// <summary>
		///     Check chronicles requirements
		/// </summary>
		/// <param name="versionAttr">Attribute with require chronicles</param>
		/// <param name="serverVersion">Minimal script chronicle version</param>
		/// <returns>True - compatible or attribute undefined; False - Incompatible</returns>
		public static bool CheckCompatible(ChroniclesCompatibleAttribute? versionAttr, Chronicles serverVersion)
		{
			if (versionAttr == null)
			{
				return true;
			}

			if (versionAttr.Version.Any() && !versionAttr.Version.Contains(serverVersion))
			{
				if (versionAttr.Required)
				{
					return false;
				}
			}

			return true;
		}
	}
}

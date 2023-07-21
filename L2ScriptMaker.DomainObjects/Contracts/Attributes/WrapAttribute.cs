using System;

using L2ScriptMaker.DomainObjects.Contracts.Models;

namespace L2ScriptMaker.DomainObjects.Contracts.Attributes
{
	/// <summary>
	///		Value with leading and trailing characters
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = false)]
	public class WrapAttribute : Attribute, IParseSetting
	{
		/// <summary>
		/// Leading character
		/// </summary>
		public char Lead { get; }

		/// <summary>
		/// Trailing character
		/// </summary>
		public char Trail { get; }

		public WrapAttribute(char lead, char trail)
		{
			Lead = lead;
			Trail = trail;
		}

		public WrapAttribute(Brackets brackets)
		{
			switch (brackets)
			{
				case Brackets.Square:
					Lead = '[';
					Trail = ']';
					break;
				case Brackets.Round:
					Lead = '(';
					Trail = ')';
					break;
				case Brackets.Decorative:
					Lead = '{';
					Trail = '}';
					break;
				case Brackets.None:
				default:
					break;
			}
		}

		public void Deconstruct(out char lead, out char trail)
		{
			lead = Lead;
			trail = Trail;
		}
	}
}

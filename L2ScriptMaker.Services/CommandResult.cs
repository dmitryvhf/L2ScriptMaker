using System.Collections.Generic;
using System.Linq;

namespace L2ScriptMaker.Services
{
	/// <summary>
	///		Result of executed command
	/// </summary>
	public class CommandResult
	{
		/// <summary>
		///		Command executed with errors
		/// </summary>
		public bool HasErrors => Errors.Any();

		/// <summary>
		///		Errors list
		/// </summary>
		public List<string> Errors { get; } = new List<string>();

		public static CommandResult Success()
		{
			return new CommandResult();
		}
	}
}

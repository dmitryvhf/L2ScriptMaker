using System;
using System.Collections.Generic;
using System.Linq;

namespace L2ScriptMaker.Parsers.Models
{
	public interface IParserResponse
	{
		/// <summary>
		///		Handler result state
		/// </summary>
		public bool IsSuccess { get; }

		/// <summary>
		///		List of errors
		/// </summary>
		public List<string> Errors { get; }
	}

	public class ParserResponse : IParserResponse
	{
		/// <inheritdoc />
		public bool IsSuccess => Errors.Any() == false;

		/// <inheritdoc />
		public List<string> Errors { get; } = new List<string>();

		public ParserResponse()
		{
		}

		public ParserResponse(List<string> errors)
		{
			Errors = errors;
		}
	}
}

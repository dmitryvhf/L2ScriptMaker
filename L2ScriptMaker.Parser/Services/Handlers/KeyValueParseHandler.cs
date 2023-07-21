using System;
using System.Linq;

using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Parsers.Services.Handlers
{
	/// <summary>
	///		Handler for getting value by named key
	/// </summary>
	internal class KeyValueParseHandler : AbstractParseHandler
	{
		public override void Handle(ParserRequest request, ParserResponse response, ParserOptions options)
		{
			KeyValueAttribute? keyValueAttr = options.PropCache[request.Property]
				.OfType<KeyValueAttribute>()
				.FirstOrDefault();

			if (keyValueAttr == null)
			{
				base.Handle(request, response, options);
				return;
			}

			string valueKey = keyValueAttr.Key;
			string availableValue = request.SplittedString.GetValue(valueKey);

			if (!string.IsNullOrWhiteSpace(availableValue))
			{
				request.SetValue(availableValue);
			}

			base.Handle(request, response, options);
		}
	}
}

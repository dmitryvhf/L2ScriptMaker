using System;
using System.Linq;

using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.DomainObjects.Contracts.Models;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Parsers.Services.Handlers
{
	/// <summary>
	///		Handler for getting value by position
	/// </summary>
	internal class ChroniclesCompatibleParseHandler : AbstractParseHandler
	{
		private readonly Chronicles _serverVersion;

		public ChroniclesCompatibleParseHandler(Chronicles serverVersion)
		{
			_serverVersion = serverVersion;
		}

		public override void Handle(ParserRequest request, ParserResponse response, ParserOptions options)
		{
			ChroniclesCompatibleAttribute? chroniclesCompatibleAttribute = options.PropCache[request.Property]
				.OfType<ChroniclesCompatibleAttribute>()
				.FirstOrDefault();

			if (!ChroniclesCompatibleAttribute.CheckCompatible(chroniclesCompatibleAttribute, _serverVersion))
			{
				response.Errors.Add($"Script version {_serverVersion} is not compatible with" +
									$" {string.Join(',', chroniclesCompatibleAttribute.Version)}" +
									$" on property: [{request.Property.Name}]");

				return;
			}

			base.Handle(request, response, options);
		}
	}
}

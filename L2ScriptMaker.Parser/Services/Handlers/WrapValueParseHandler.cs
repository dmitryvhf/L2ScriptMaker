using System.Linq;

using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Parsers.Services.Handlers
{
	/// <summary>
	///		Handler for getting value by named key
	/// </summary>
	internal class WrapValueParseHandler : AbstractParseHandler
	{
		public override void Handle(ParserRequest request, ParserResponse response, ParserOptions options)
		{
			WrapAttribute? wrapAttribute = options.PropCache[request.Property]
				.OfType<WrapAttribute>()
				.FirstOrDefault();

			if (wrapAttribute == null)
			{
				base.Handle(request, response, options);
				return;
			}

			string? wrapValue = request.Value as string;
			if (wrapValue == null)
			{
				return;
			}

			(char lead, char trail) = (WrapAttribute)wrapAttribute;
			if (wrapValue.StartsWith(lead))
			{
				wrapValue = wrapValue.Remove(0, 1);
			}
			if (wrapValue.EndsWith(trail))
			{
				wrapValue = wrapValue.Remove(wrapValue.Length - 1, 1);
			}

			request.SetValue(wrapValue);

			base.Handle(request, response, options);
		}
	}
}

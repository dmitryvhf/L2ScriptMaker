using System.Linq;

using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Parsers.Services.Handlers
{
	/// <summary>
	///		Handler for getting value by position
	/// </summary>
	internal class PositionParseHandler : AbstractParseHandler
	{
		public override void Handle(ParserRequest request, ParserResponse response, ParserOptions options)
		{
			PositionAttribute? propVersionAttr = options.PropCache[request.Property]
				.OfType<PositionAttribute>()
				.FirstOrDefault();

			if (propVersionAttr != null)
			{
				var positionNumber = propVersionAttr.Number;
				// string positionValue = request.SplittedString[positionNumber];
				string positionValue = request.SplittedString.GetValue(positionNumber);

				request.SetValue(positionValue);
			}

			base.Handle(request, response, options);
		}
	}
}

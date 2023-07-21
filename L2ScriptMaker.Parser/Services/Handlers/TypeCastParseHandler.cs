using System;

using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Parsers.Services.Handlers
{
	/// <summary>
	///		Finishing handler for cast value to target type
	/// </summary>
	internal class TypeCastParseHandler : AbstractParseHandler
	{
		public override void Handle(ParserRequest request, ParserResponse response, ParserOptions options)
		{
			if (request.Value == null)
			{
				response.Errors.Add($"Requested value '{request.Value}' is empty.");
				return;
			}

			if (request.Property.PropertyType == typeof(string))
			{
				request.SetValue(request.Value);

				base.Handle(request, response, options);
				return;
			}

			if (request.Property.PropertyType.IsEnum)
			{
				if (Enum.TryParse(request.Property.PropertyType, request.Value.ToString(), out object? enumValue))
				{
					request.SetValue(enumValue);

					base.Handle(request, response, options);
					return;
				}

				response.Errors.Add($"Value '{request.Value}' is not enum for property {request.Property.PropertyType.Name}.");
				return;
			}

			try
			{
				object typedValue = Convert.ChangeType(request.Value, request.Property.PropertyType);
				request.SetValue(typedValue);
			}
			catch
			{
				response.Errors.Add($"Requested value '{request.Value}' cannot converted to target type {request.Property.PropertyType.Name}.");
				return;
			}

			base.Handle(request, response, options);
		}
	}
}

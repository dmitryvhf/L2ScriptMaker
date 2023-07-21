using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using L2ScriptMaker.DomainObjects.Contracts;
using L2ScriptMaker.DomainObjects.Contracts.Attributes;
using L2ScriptMaker.DomainObjects.Contracts.Models;
using L2ScriptMaker.Parsers.Models;
using L2ScriptMaker.Parsers.Services.Handlers;

namespace L2ScriptMaker.Parsers.Services
{
	/// <summary>
	///		Service for parsing script data to object model
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ParserCore<T> where T : IScript, new()
	{
		#region Private properties

		/// <summary>
		///     Коллекция свойств модели с атрибутами
		/// </summary>
		private readonly Dictionary<PropertyInfo, Attribute[]> _propCache = new();

		private readonly ParserOptions _parseOptions = null!;
		private readonly IHandler _parseChaining = null!;

		#endregion

		#region Public properties

		/// <summary>
		///     Флаг наличия ошибок при обработке данных
		/// </summary>
		public bool HasErrors => Errors.Any();

		/// <summary>
		///     Коллекция ошибок обработки данных
		/// </summary>
		public List<string> Errors { get; private set; } = new List<string>();

		#endregion

		#region Constructor

		/// <summary>
		///		Service for parsing script data to object model
		/// </summary>
		/// <param name="serverVersion">Required script version</param>
		public ParserCore(Chronicles serverVersion)
		{
			Type scriptType = typeof(T);

			// --------- chronicles version check ----
			//ChroniclesCompatibleAttribute? scriptVersionAttr = scriptType.GetCustomAttribute<ChroniclesCompatibleAttribute>();
			//if (!ChroniclesCompatibleAttribute.CheckCompatible(scriptVersionAttr, serverVersion))
			//{
			//	Errors.Add($"Script version {serverVersion} is not compatible with" +
			//						$" {string.Join(',', scriptVersionAttr.Version)}");
			//	return;
			//}
			// --------- chronicles version check ----

			CacheTargetObjectInfo(scriptType);

			_parseOptions = new ParserOptions(_propCache);

			_parseChaining = new ChroniclesCompatibleParseHandler(serverVersion);
			_parseChaining
				.Next(new PositionParseHandler())
				.Next(new KeyValueParseHandler())
				.Next(new WrapValueParseHandler())
				.Next(new TypeCastParseHandler());
		}

		#endregion

		#region Public methods

		/// <summary>
		///		Parse string row to script object model
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		public T Parse(string row)
		{
			T model = new();
			ParserResponse result = new ParserResponse();

			if (_propCache.Count == 0)
			{
				Errors.Add("Parser is not ready.");
				return model;
			}

			// TODO handler? data collector for one and multilines data
			// string[] splittedString = row.Split('\t');

			ParsedData splittedString = ParseService.ToKeyValueCollection(row);
			if (splittedString.IsEmpty)
			{
				Errors.Add("Prepare data empty.");
				return model;
			}

			foreach (KeyValuePair<PropertyInfo, Attribute[]> prop in _propCache)
			{
				ParserRequest request = new ParserRequest(prop.Key, splittedString);

				_parseChaining.Handle(request, result, _parseOptions);

				if (result.IsSuccess)
				{
					prop.Key.SetValue(model, request.Value);
				}
				else
				{
					Errors.AddRange(result.Errors);
					result.Errors.Clear();
				}
			}

			return model;
		}

		/// <summary>
		///     Clear error state
		/// </summary>
		public void ClearState()
		{
			Errors = new List<string>();
		}

		#endregion

		#region Private methods

		/// <summary>
		///     Scan target object model and cache properties information
		/// </summary>
		/// <param name="scriptType">Type of target model</param>
		private void CacheTargetObjectInfo(Type scriptType)
		{
			// check script properties
			foreach (PropertyInfo propertyInfo in scriptType.GetProperties())
			{
				//ChroniclesCompatibleAttribute? propVersionAttr = propertyInfo.GetCustomAttribute<ChroniclesCompatibleAttribute>();
				//if (!ChroniclesCompatibleAttribute.CheckCompatible(propVersionAttr, _serverVersion))
				//{
				//    continue;
				//}

				Attribute[] propAttributes = propertyInfo.GetCustomAttributes()
					.Where(a => a is IParseSetting)
					.ToArray();

				_propCache.Add(propertyInfo, propAttributes);
			}
		}

		#endregion
	}
}

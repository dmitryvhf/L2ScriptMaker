using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using L2ScriptMaker.Core.Attributes;
using L2ScriptMaker.Core.Parser;

namespace L2ScriptMaker.Core.Mapper
{
	public class ModelMapper<T>
	{
		private readonly Dictionary<string, RecordParamAttribute> _params;

		/// <summary>
		/// Transfer parsed data to target type, uses target attribute rules.
		/// </summary>
		/// <exception cref="ArgumentException">Target type is not marked with RecordAttribute</exception>
		/// <exception cref="ArgumentException">Index not defined for property with non-name link</exception>
		public ModelMapper()
		{
			_params = new Dictionary<string, RecordParamAttribute>();

			Initialize();
		}

		private void Initialize()
		{
			Type t = typeof(T);
			if (!t.IsDefined(typeof(RecordAttribute)))
				throw new ArgumentException("Target type is not marked with RecordAttribute");

			PropertyInfo[] targetProperties = t.GetProperties()
				.Where(a => a.IsDefined(typeof(RecordParamAttribute)))
				.ToArray();

			foreach (PropertyInfo propertyInfo in targetProperties)
			{
				RecordParamAttribute attributedProperty =
					propertyInfo.GetCustomAttribute<RecordParamAttribute>();

				if (attributedProperty.ByName == false && !attributedProperty.Index.HasValue)
				{
					throw new ArgumentException($"Index not defined for property {propertyInfo.Name}");
				}

				_params.Add(propertyInfo.Name, attributedProperty);
			}
		}

		public T Map(ParsedData data)
		{
			T instance = Activator.CreateInstance<T>();
			if (_params.Count == 0) return instance;

			foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
			{
				if (!_params.ContainsKey(propertyInfo.Name)) continue;

				RecordParamAttribute attr = _params[propertyInfo.Name];

				Type t2 = propertyInfo.PropertyType;
				object value = _params[propertyInfo.Name].ByName ? data.GetValue<string>(attr.Name) : data.GetValue<string>(attr.Index.Value);

				// Additional filters
				if (attr.Brackets != Brackets.None)
				{
					value = StringUtils.CutBrackets(value.ToString());
				}

				// Target type transformation
				if (value != null && t2 != typeof(string))
				{
					value = Convert.ChangeType(value, t2);
				}

				propertyInfo.SetValue(instance, value);
			}

			return instance;
		}
	}
}
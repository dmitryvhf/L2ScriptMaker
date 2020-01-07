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

		public ModelMapper()
		{
			_params = new Dictionary<string, RecordParamAttribute>();

			Initialize();
		}

		private void Initialize()
		{
			Type t = typeof(T);
			bool isInlineScript = t.IsDefined(typeof(RecordAttribute));
			if (!isInlineScript) throw new ArgumentException("Type is not script");

			PropertyInfo[] myMembers = t.GetProperties()
				.Where(a => a.IsDefined(typeof(RecordParamAttribute)))
				.ToArray();

			foreach (PropertyInfo propertyInfo in myMembers)
			{
				RecordParamAttribute attributedProperty =
					propertyInfo.GetCustomAttribute<RecordParamAttribute>();

				_params.Add(propertyInfo.Name, attributedProperty);
			}
		}

		public T Map(ParsedData data)
		{
			T instance = Activator.CreateInstance<T>();

			if (_params.Count == 0) return instance;

			Type t = typeof(T);
			PropertyInfo[] myMembers = t.GetProperties().ToArray();

			foreach (PropertyInfo propertyInfo in myMembers)
			{
				if (!_params.ContainsKey(propertyInfo.Name)) continue;

				RecordParamAttribute attr = _params[propertyInfo.Name];

				Type t2 = propertyInfo.PropertyType;
				object value;
				if (_params[propertyInfo.Name].ByName)
				{
					value = data.GetValue<string>(attr.Name);
				}
				else
				{
					if (!attr.Index.HasValue)
						throw new ArgumentException($"Index not defined for property {propertyInfo.Name}");

					value = data.GetValue<string>(attr.Index.Value);
				}

				// Additional filters
				if (attr.Brackets != Brackets.None)
				{
					value = value.ToString().Substring(1, value.ToString().Length - 2);
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

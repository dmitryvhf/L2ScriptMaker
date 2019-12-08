using L2ScriptMaker.Parsers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace L2ScriptMaker.Parsers.Parsers.Inline
{
	public class InlineParser<T> : IInlineParser<T>
	{
		private readonly Dictionary<string, ScriptParamAttribute> _scriptParams;
		private readonly IScriptReader<InlineData> _reader;

		public InlineParser()
		{
			_scriptParams = new Dictionary<string, ScriptParamAttribute>();
			_reader = new InlineDataReader();
		}

		public void Initialize()
		{
			Type t = typeof(T);
			bool isInlineScript = t.IsDefined(typeof(ScriptAttribute));
			if (!isInlineScript) throw new ArgumentException("Type is not inline script");

			if (_scriptParams.Count > 0) _scriptParams.Clear();

			PropertyInfo[] myMembers = t.GetProperties()
				.Where(a => a.IsDefined(typeof(ScriptParamAttribute)))
				.ToArray();

			foreach (PropertyInfo propertyInfo in myMembers)
			{
				ScriptParamAttribute attributedProperty =
					propertyInfo.GetCustomAttribute<ScriptParamAttribute>();

				_scriptParams.Add(propertyInfo.Name, attributedProperty);
			}
		}

		public T Parse(string raw)
		{
			T instance = Activator.CreateInstance<T>();

			if (_scriptParams.Count == 0) return instance;

			InlineData data = _reader.Read(raw);
			Type t = typeof(T);
			PropertyInfo[] myMembers = t.GetProperties().ToArray();

			foreach (PropertyInfo propertyInfo in myMembers)
			{
				if (!_scriptParams.ContainsKey(propertyInfo.Name)) continue;

				ScriptParamAttribute attr = _scriptParams[propertyInfo.Name];

				Type t2 = propertyInfo.PropertyType;
				object value;
				if (_scriptParams[propertyInfo.Name].ByName)
				{
					value = data.GetValue<string>(attr.FieldName);
				}
				else
				{
					value = data.GetParam<string>(attr.FieldNum.GetValueOrDefault());
				}

				// Additional filters
				if (attr.TrimLR)
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace L2ScriptMaker.Core
{
	public static class SerializeUtils
	{
		//Десериализация (чтение состояния модели)
		public static T Deserialize<T>(string path)
		{
			var result = default(T);
			using (var stream = new StreamReader(path))
			{
				var serializer = new XmlSerializer(typeof(T));
				result = (T)serializer.Deserialize(stream);
			}
			return result;
		}

		//Сериализация (сохранение состояния модели)
		public static void Serialize<T>(T obj, string path)
		{
			using (var stream = new StreamWriter(path))
			{
				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(stream, obj);
			}
		}
	}
}

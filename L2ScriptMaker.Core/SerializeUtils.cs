using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace L2ScriptMaker.Core
{
	public static class SerializeUtils
	{
		public static void Serialize<T>(T obj, string path)
		{
			using (var stream = new StreamWriter(path))
			{
				var ns = new XmlSerializerNamespaces();
				ns.Add("", "");

				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(stream, obj, ns);
			}
		}

		public static T Deserialize<T>(string path)
		{
			using (var stream = new StreamReader(path))
			{
				var serializer = new XmlSerializer(typeof(T));
				return (T)serializer.Deserialize(stream);
			}
		}
	}
}

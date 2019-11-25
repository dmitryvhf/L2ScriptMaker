using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace L2ScriptMaker.Core.Files
{
	public static class FileUtils
	{
		private static readonly Func<string, bool> FilterEmptyOrCommentLines =
			(s) => !String.IsNullOrWhiteSpace(s) && !s.StartsWith("//");

		/// <exception cref="NullReferenceException">Путь к файлу null или пустое значение</exception>
		/// <exception cref="FileNotFoundException">Файл не существует</exception>
		public static IEnumerable<string> ReadFile(string path) // todo ? , Func<string, bool> filter
		{
			return File.ReadLines(path).Where(FilterEmptyOrCommentLines);
		}

		public static void SaveFile(IEnumerable<string> data, string targetPath, Encoding encoding)
		{
			File.WriteAllLines(targetPath, data, encoding);
		}

		public static FileInfo GetFileInfo(string file)
		{
			FileInfo res = new FileInfo(file);
			return res;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2ScriptMaker.Extensions.VbCompatibleHelper
{
	public enum CompareMethod
	{
		Binary = 0,
		Text = 1
	}

	public class Strings
	{
		public static Int32 InStr(String searchString, String searchFor) => searchString.IndexOf(searchFor, StringComparison.OrdinalIgnoreCase) + 1;
		public static Int32 InStr(Int32 StartPos, String searchString, String searchFor) => searchString.IndexOf(searchFor, StartPos, StringComparison.OrdinalIgnoreCase) + 1;

		public static Int32 InStr(String searchString, String searchFor, CompareMethod option)
		{
			if (option == CompareMethod.Text) return searchString.IndexOf(searchFor, StringComparison.OrdinalIgnoreCase) + 1;

			return searchString.IndexOf(searchFor, StringComparison.Ordinal) + 1;
		}

		public static Int32 InStr(Int32 StartPos, String searchString, String searchFor, CompareMethod option)
		{
			if (option == CompareMethod.Text) return searchString.IndexOf(searchFor, StartPos, StringComparison.OrdinalIgnoreCase) + 1;

			return searchString.IndexOf(searchFor, StartPos, StringComparison.Ordinal) + 1;
		}

		public static string Mid(String searchString, int startIndex) => searchString.Substring(startIndex - 1);
		public static string Mid(String searchString, int startIndex, int length) => searchString.Substring(startIndex - 1, length);
		public static string Join(String[] searchString, string splitter) => String.Join(splitter, searchString);

		public static string Trim(String value) => value.Trim();

		//public static Int32 InStr(Int32 StartPos, String SearchString, String SearchFor, bool IgnoreCaseFlag = true)
		//{
		//	Int32 result = -1;

		//	if (IgnoreCaseFlag)
		//		result = SearchString.IndexOf(SearchFor, StartPos, StringComparison.OrdinalIgnoreCase);
		//	else
		//		result = SearchString.IndexOf(SearchFor, StartPos);

		//	return result;
		//}
		public static int AscW(char c)
		{
			// char c => string c
			// return int only for first
			return c;
		}

		public static int Asc(char c)
		{
			return c;
		}

		public static string Replace(string readStr, string inLink, string chgHtmlButStl)
		{
			return readStr.Replace(inLink, chgHtmlButStl);
		}

		public static int Len(string s)
		{
			return s.Length;
		}

		public static string Format(double value, string format)
		{
			return String.Format(format, value);
		}

		public static int WordCount(string Str, string Razd = " ")
		{
			int WordCountRet = default(int);
			// Возвращает количество слов в строке

			int i;

			Str = Str.Trim();
			var loopTo = Str.Length - 1;
			for (i = 1; i <= loopTo; i++)
			{
				if ((Str.Substring(i, 1) ?? "") == (Razd ?? ""))
					WordCountRet = WordCountRet + 1;
				else if (i == Str.Length - 1)
					WordCountRet = WordCountRet + 1;
			}

			return WordCountRet;
		}

		public static string WordWrap(string Str, string Symb, string Pos = "Left")
		{
			string WordWrapRet = default(string);
			// Обрезает строку вплоть до символа (либо несколькх символов) symb включительно
			// Pos может быть Left или Right. Он задает с какой стороны от символа вернуть строку

			int i;
			var loopTo = Str.Length - 1;
			for (i = 0; i <= loopTo; i++)
			{
				if ((Str.Substring(i, Symb.Length) ?? "") == (Symb ?? ""))
				{
					if ((Pos ?? "") == "Left")
						WordWrapRet = Str.Substring(0, i + Symb.Length - 1).Trim();
					else
						WordWrapRet = Str.Substring(i + Symb.Length, Str.Length - i - Symb.Length).Trim();
					return WordWrapRet;
				}
			}

			WordWrapRet = Str;
			return WordWrapRet;
		}

		public static string[] Words(string Str, string Razd)
		{
			string[] WordsRet = default(string[]);
			int wCount;
			int i;
			int j = 0;
			int WordStart = 0;
			string[] tWords;

			wCount = WordCount(Str, Razd);

			tWords = new string[wCount + 1];
			var loopTo = Str.Length - 1;
			for (i = 1; i <= loopTo; i++)
			{
				if ((Str.Substring(i, 1) ?? "") == (Razd ?? "") | Str.Length - 1 == i)
				{
					j = j + 1;
					if (i == Str.Length - 1)
					{
						if (WordStart == i)
						{
						}
						else
							tWords[j] = Str.Substring(WordStart, i - WordStart + 1);
					}
					else if (i == WordStart)
					{
					}
					else
						tWords[j] = Str.Substring(WordStart, i - WordStart);
					WordStart = i + 1;
				}
			}

			WordsRet = tWords;
			return WordsRet;
		}
	}
}

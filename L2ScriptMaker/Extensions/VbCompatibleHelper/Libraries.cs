namespace L2ScriptMaker.Extensions.VbCompatibleHelper
{
	class Libraries
	{
		public static bool GlobalLog(string ModuleName, string LogMessage, short HeaderFlag)
		{
			// HeaderFlag = 0 - start text, 1 - normal message, 2 - end text
			return true;
		}

		private static string GetCommentaryFromStr(string SourceStr)
		{
			string GetCommentaryFromStrRet = null;
			string sTempCommentary = "";

			if (SourceStr.IndexOf("/*") > 0)
				GetCommentaryFromStrRet = SourceStr.Substring(SourceStr.IndexOf("/*"), SourceStr.IndexOf("*/") - SourceStr.IndexOf("/*") + 2);

			return GetCommentaryFromStrRet;
		}
		public static string SetNeedParamToStr(string SourceStr, string Param, string Value)
		{
			string sTemp;
			string sTempCommentaryBefore = "";
			string sTempCommentaryAfter = "";

			// 14:09 13.04.2010 - if Value ="" then write parameter without value and =
			// 14:15 13.04.2010 - save TAB in commentary

			if (SourceStr.IndexOf("/*") > 0)
				sTempCommentaryBefore = GetCommentaryFromStr(SourceStr);

			// PreWorking string
			SourceStr = SourceStr.Replace("\t", " ");
			SourceStr = SourceStr.Replace(" = ", "=");
			while (SourceStr.IndexOf("  ") > 0)
			{
				SourceStr = SourceStr.Replace("  ", " ");
			}

			sTemp = GetNeedParamFromStr(SourceStr, Param);
			if (!string.IsNullOrEmpty(sTemp))
			{
				if (!string.IsNullOrEmpty(Value))
					SourceStr = SourceStr.Replace(" " + Param + "=" + sTemp, " " + Param + "=" + Value);
				else
					SourceStr = SourceStr.Replace(" " + Param + "=" + sTemp, " " + Param);
			}
			SourceStr = SourceStr.Replace(" ", "\t");

			// Commentary recovery
			if (SourceStr.IndexOf("/*") > 0)
			{
				sTempCommentaryAfter = GetCommentaryFromStr(SourceStr);
				SourceStr = SourceStr.Replace(sTempCommentaryAfter, sTempCommentaryBefore);
			}

			return SourceStr;
		}

		public static string GetNeedParamFromStr(string SourceStr, string MaskStr)
		{
			string GetNeedParamFromStrRet = default(string);

			// Update 13.03.2007 18:00

			int FirstPos, SecondPos;
			GetNeedParamFromStrRet = "";

			// PreWorking string
			SourceStr = SourceStr.Replace("\t", " ");
			SourceStr = SourceStr.Replace(" = ", "=");
			while (SourceStr.IndexOf("  ") > 0)
			{
				SourceStr = SourceStr.Replace("  ", " ");
			}

			FirstPos = Strings.InStr(1, SourceStr, " " + MaskStr + "="); // + 1
			if (FirstPos == default(int))
			{
				if (SourceStr.StartsWith(MaskStr))
				{
					GetNeedParamFromStrRet = SourceStr.Remove(0, MaskStr.Length + 1).Trim();
					return GetNeedParamFromStrRet;
				}

				GetNeedParamFromStrRet = "";
				return GetNeedParamFromStrRet;
			} 

			FirstPos += MaskStr.Length + 1; // +1 - next symbol after Mask word + space
			SecondPos = FirstPos + 1;
			SecondPos = Strings.InStr(SecondPos, SourceStr, " ");
			if (SecondPos == 0)
				SecondPos = SourceStr.Length;

			GetNeedParamFromStrRet = SourceStr.Substring(FirstPos, SecondPos - FirstPos).Trim();
			if (GetNeedParamFromStrRet.StartsWith("[") == true & GetNeedParamFromStrRet.EndsWith("]") == false)
			{
				SecondPos = Strings.InStr(FirstPos, SourceStr, "]");
				// If SecondPos = 0 Then SecondPos = SourceStr.Length
				GetNeedParamFromStrRet = SourceStr.Substring(FirstPos, SecondPos - FirstPos).Trim();
			}
			// SourceStr = SourceStr.Replace(" ", "\t");
			return GetNeedParamFromStrRet;
		}

		//public static string StrPrepare(string SourceStr)
		//{
		//	string Msg;
		//	Msg = SourceStr.Replace("\t", " ");
		//	// SourceStr = SourceStr.Replace(" = ", "=");
		//	while (Msg.IndexOf("  ") > 0)
		//	{
		//		Msg = Msg.Replace("  ", " ");
		//	}
		//	return Msg;
		//}

		//private static Int32 StrInstr(Int32 StartPos, String SearchString, String SearchFor, bool IgnoreCaseFlag = true)
		//{
		//	Int32 result = -1;

		//	if (IgnoreCaseFlag)
		//		result = SearchString.IndexOf(SearchFor, StartPos, StringComparison.OrdinalIgnoreCase);
		//	else
		//		result = SearchString.IndexOf(SearchFor, StartPos);

		//	return result;
		//}
	}
}

Public Class Libraries

    Shared Function GlobalLog(ByVal ModuleName As String, ByVal LogMessage As String, ByVal HeaderFlag As Short) As Boolean

        'HeaderFlag = 0 - start text, 1 - normal message, 2 - end text


        Return True

    End Function

    Private Shared Function GetCommentaryFromStr(ByVal SourceStr As String) As String

        GetCommentaryFromStr = Nothing
        Dim sTempCommentary As String = ""

        If InStr(SourceStr, "/*") > 0 Then
            GetCommentaryFromStr = SourceStr.Substring(SourceStr.IndexOf("/*"), SourceStr.IndexOf("*/") - SourceStr.IndexOf("/*") + 2)
        End If

        Return GetCommentaryFromStr

    End Function

    Shared Function SetNeedParamToStr(ByVal SourceStr As String, ByVal Param As String, ByVal Value As String) As String

        Dim sTemp As String
        Dim sTempCommentaryBefore As String = "", sTempCommentaryAfter As String = ""

        ' 14:09 13.04.2010 - if Value ="" then write parameter without value and =
        ' 14:15 13.04.2010 - save TAB in commentary

        If InStr(SourceStr, "/*") > 0 Then sTempCommentaryBefore = GetCommentaryFromStr(SourceStr)

        ' PreWorking string
        SourceStr = SourceStr.Replace(Chr(9), " ")
        SourceStr = SourceStr.Replace(" = ", "=")
        While InStr(SourceStr, "  ") > 0
            SourceStr = SourceStr.Replace("  ", " ")
        End While

        sTemp = GetNeedParamFromStr(SourceStr, Param)
        If sTemp <> "" Then
            If Value <> "" Then
                SourceStr = SourceStr.Replace(" " & Param & "=" & sTemp, " " & Param & "=" & Value)
            Else
                SourceStr = SourceStr.Replace(" " & Param & "=" & sTemp, " " & Param)
            End If
        End If
        SourceStr = SourceStr.Replace(" ", Chr(9))

        ' Commentary recovery
        If InStr(SourceStr, "/*") > 0 Then
            sTempCommentaryAfter = GetCommentaryFromStr(SourceStr)
            SourceStr = SourceStr.Replace(sTempCommentaryAfter, sTempCommentaryBefore)
        End If

        Return SourceStr
    End Function

    Shared Function GetNeedParamFromStr(ByVal SourceStr As String, ByVal MaskStr As String) As String

        'Update 13.03.2007 18:00

        Dim FirstPos, SecondPos As Integer
        GetNeedParamFromStr = ""

        ' PreWorking string
        SourceStr = SourceStr.Replace(Chr(9), " ")
        SourceStr = SourceStr.Replace(" = ", "=")
        While InStr(SourceStr, "  ") > 0
            SourceStr = SourceStr.Replace("  ", " ")
        End While

        FirstPos = InStr(1, SourceStr, " " & MaskStr & "=") ' + 1
        If FirstPos = Nothing Then 'Or FirstPos = 0

            If SourceStr.StartsWith(MaskStr) Then
                GetNeedParamFromStr = SourceStr.Remove(0, MaskStr.Length + 1).Trim()
                Exit Function
            End If

            GetNeedParamFromStr = ""
            Exit Function
        End If

        FirstPos += MaskStr.Length + 1 ' +1 - next symbol after Mask word + space
        SecondPos = FirstPos + 1
        SecondPos = InStr(SecondPos, SourceStr, " ")
        If SecondPos = 0 Then SecondPos = SourceStr.Length

        GetNeedParamFromStr = Trim(Mid(SourceStr, FirstPos + 1, SecondPos - FirstPos))
        If GetNeedParamFromStr.StartsWith("[") = True And GetNeedParamFromStr.EndsWith("]") = False Then
            SecondPos = InStr(FirstPos, SourceStr, "]")
            'If SecondPos = 0 Then SecondPos = SourceStr.Length
            GetNeedParamFromStr = Trim(Mid(SourceStr, FirstPos + 1, SecondPos - FirstPos))
            'And InStr(GetNeedParamFromStr, " ") <> 0
        End If
        SourceStr = SourceStr.Replace(" ", Chr(9))

    End Function

End Class

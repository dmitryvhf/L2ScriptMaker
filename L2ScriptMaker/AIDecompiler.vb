Public Class AIDecompiler

    Dim aLabelsDB(0) As String

    Dim inAIFile As System.IO.StreamReader
    Dim iGF_FileIndex As Integer
    Dim iGF_FilePosition As Long
    Dim aGF_FileName(0) As String
    Dim iGF_ErrorFlag As Boolean = False

    Dim OriginalCode(0) As String
    Dim OriginalCodeFlag As Integer
    Dim DecompiledCode(0) As String
    Dim DecompiledCodeFlag As Integer

    Dim Stack(100000) As Object     ' full stack
    Dim StackFlag As Integer = -1   ' current marker in stack. It and current stack size
    Dim StackCache(100) As Object   ' cache for getting values from stack

    Dim AiCode As String
    Dim LineStat As Long = 0

    Dim sSTable(0) As String
    Dim sSTableParam(0) As String
    Dim sVarTable(0) As String

    ' Use for handler/fetch_i/push_event/func_call config list
    Dim sLastClassType As String
    Dim sLastHandler As String
    Dim sLastEvent As String

    'ai_functions.txt
    ' 167837696|GetSpawnDefine,1,0
    Dim FuncTable(0) As String
    Dim FuncTableParam(0) As AiFuncCall

    Private Structure AiFuncCall
        Dim FuncId As String
        Dim FuncName As String
        Dim FuncInVar As Integer
        'Dim FuncOutVar As Integer
    End Structure

    'ai_events.txt
    '40|default|talker
    Dim AiEventsTable(0) As String
    Dim AiEventsTableParam(0) As AiEvents

    Private Structure AiEvents
        Dim eventId As Integer
        Dim eventHandler As String
        Dim eventName As String
    End Structure

    'ai_fetch_i.txt
    '16|default|y
    '16|h0|creature

    Dim AiFetchTable(0) As String
    Dim AiFetchTableParam(0) As AiFetch

    Private Structure AiFetch
        Dim fetchId As Integer
        Dim fetchEvent As String
        Dim fetchName As String
    End Structure

    'ai_handlers.txt
    '0|1|NO_DESIRE
    Dim AiHandlerTable(0) As String
    Dim AiHandlerTableParam(0) As AiHandler

    Private Structure AiHandler
        Dim handlerId As Integer
        Dim handlerClassType As String
        Dim handlerName As String
    End Structure


#Region "PreLoading"

    Private Function GetAiVar(ByVal iId As String, ByVal sType As String) As String

        Dim iTemp As Integer
        Dim sResult As String = Nothing

        Select Case sType
            Case "handler"

                iTemp = Array.IndexOf(AiHandlerTable, iId)
                If iTemp = -1 Then GoTo ErrExit
                If AiHandlerTableParam(iTemp).handlerClassType <> sLastClassType Then
                    iTemp = Array.IndexOf(AiHandlerTable, iId, iTemp + 1)
                    If iTemp = -1 Then GoTo ErrExit
                End If
                sResult = AiHandlerTableParam(iTemp).handlerName

            Case "function"

                '167837696|GetSpawnDefine,1,0
                iTemp = Array.IndexOf(FuncTable, iId)
                If iTemp = -1 Then GoTo ErrExit
                sResult = FuncTableParam(iTemp).FuncName

            Case "event"

                ''40|default|talker

                '672|default|lparty
                '672|ON_NPC_DELETED|deleted_def
                ' MAX 2 variance

                'If iId = "656" And sLastHandler = "ON_NPC_DELETED" Then
                '    Dim asd As Boolean = False
                'End If

                iTemp = Array.IndexOf(AiEventsTable, iId)
                If iTemp = -1 Then GoTo ErrExit
                sResult = AiEventsTableParam(iTemp).eventName   ' example "default" value

                If AiEventsTableParam(iTemp).eventHandler <> "default" And AiEventsTableParam(iTemp).eventHandler <> sLastHandler Then
                    MessageBox.Show("Wrong record into push_event config. 'default' type not defined or placed on not in first position. Decompiling code maybe wrong!" & vbNewLine _
                                    & "Found fetch '// " & sResult & "' for id:[" & iId & "] in handler: [" & sLastHandler & "]", "Wrong config", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return sResult
                    Exit Select
                End If

                While iTemp <> -1
                    If AiEventsTableParam(iTemp).eventHandler = sLastHandler Then sResult = AiEventsTableParam(iTemp).eventName : Exit Select
                    iTemp = Array.IndexOf(AiEventsTable, iId, iTemp + 1)
                End While

                'If AiEventsTableParam(iTemp).eventHandler = sLastHandler Or AiEventsTableParam(iTemp).eventHandler = "default" Then
                '    iTemp = Array.IndexOf(AiEventsTable, iId, iTemp + 1)
                '    If iTemp = -1 Then GoTo ErrExit
                'End If
                'sResult = AiEventsTableParam(iTemp).eventName

            Case "fetch"

                'ai_fetch_i.txt

                'ai_fetch_i.txt
                '16|default|y
                '16|h0|creature

                iTemp = Array.IndexOf(AiFetchTable, iId)
                If iTemp = -1 Then GoTo ErrExit 'Exit Select 
                sResult = AiFetchTableParam(iTemp).fetchName     ' example "default" value
                If AiFetchTableParam(iTemp).fetchEvent <> "default" And AiFetchTableParam(iTemp).fetchEvent <> sLastEvent Then
                    MessageBox.Show("Wrong record into fetch_i config. 'default' type not defined or placed on not in first position. Decompiling code maybe wrong!" & vbNewLine _
                                    & "Found fetch '// " & sResult & "' for id:[" & iId & "] in handler: [" & sLastHandler & "] with last push_event: [" & sLastEvent & "].", "Wrong config", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return sResult
                    Exit Select
                End If

                While iTemp <> -1
                    If AiFetchTableParam(iTemp).fetchEvent = sLastEvent Then sResult = AiFetchTableParam(iTemp).fetchName : Exit Select
                    iTemp = Array.IndexOf(AiFetchTable, iId, iTemp + 1)
                End While

                'If AiFetchTableParam(iTemp).fetchHandler <> sLastHandler Then
                '    iTemp = Array.IndexOf(AiFetchTable, iId, iTemp + 1)
                '    If iTemp <> -1 Then sResult = AiFetchTableParam(iTemp).fetchName
                'End If
                ''sResult = AiFetchTableParam(iTemp).fetchHandler

        End Select
        Return sResult

ErrExit:
        If sType = "handler" Then
            MessageBox.Show("Not found '" & sType & "' for id:[" & iId & "] for class type: [" & sLastClassType & "]", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Not found '" & sType & "' for id:[" & iId & "] in handler: [" & sLastHandler & "]", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return Nothing

    End Function

    Private Function FuncCallLoader() As Boolean

        Dim sTemp As String
        Dim aTemp(10) As String
        Dim iTemp As Integer = 0, iForTemp As Integer = 0
        Dim sFolder As String, sConfigFile As String
        Dim aConfigs() As String = {"ai_functions.txt", "ai_handlers.txt", "ai_events.txt", "ai_fetch_i.txt"}
        Dim inFile As System.IO.StreamReader

        sFolder = System.IO.Path.GetDirectoryName(FuncFileTextBox.Text)

        Array.Clear(FuncTable, 0, FuncTable.Length)
        Array.Clear(FuncTableParam, 0, FuncTableParam.Length)
        Array.Clear(AiHandlerTable, 0, AiHandlerTable.Length)
        Array.Clear(AiHandlerTableParam, 0, AiHandlerTableParam.Length)
        Array.Clear(AiEventsTable, 0, AiEventsTable.Length)
        Array.Clear(AiEventsTableParam, 0, AiEventsTableParam.Length)
        Array.Clear(AiFetchTable, 0, AiFetchTable.Length)
        Array.Clear(AiFetchTableParam, 0, AiFetchTableParam.Length)

        For iForTemp = 0 To aConfigs.Length - 1

            sConfigFile = sFolder & "\" & aConfigs(iForTemp)
            If System.IO.File.Exists(sConfigFile) = False Then
                MessageBox.Show("Config file '" & sFolder & aConfigs(iForTemp) & "'not exist. Enter valid path and try again.", "File not exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            inFile = New System.IO.StreamReader(sConfigFile, System.Text.Encoding.Default, True, 1)

            While inFile.EndOfStream <> True
                sTemp = inFile.ReadLine.Trim
                If sTemp <> "" And sTemp.StartsWith("//") = False Then

                    sTemp = sTemp.Trim.Replace("|", ",")
                    aTemp = sTemp.Split(CChar(","))


                    Select Case aConfigs(iForTemp)
                        Case "ai_functions.txt"
                            '167837696|GetSpawnDefine,1,0
                            If AiVarsCheckBox.Checked = False Then
                                FuncTable(iTemp) = aTemp(1)
                            Else
                                FuncTable(iTemp) = aTemp(0)
                            End If
                            FuncTableParam(iTemp).FuncId = aTemp(0)
                            FuncTableParam(iTemp).FuncName = aTemp(1)
                            FuncTableParam(iTemp).FuncInVar = CInt(aTemp(2))
                            'FuncTableParam(iTemp).FuncOutVar = CInt(aTemp(3))

                            iTemp += 1
                            Array.Resize(FuncTable, iTemp + 1)
                            Array.Resize(FuncTableParam, iTemp + 1)

                        Case "ai_handlers.txt"
                            '0|1|NO_DESIRE
                            'Dim AiHandlerTable(0) As String
                            'Dim AiHandlerTableParam(0) As AiHandler

                            AiHandlerTable(iTemp) = aTemp(0)
                            AiHandlerTableParam(iTemp).handlerId = CInt(aTemp(0))
                            AiHandlerTableParam(iTemp).handlerClassType = aTemp(1)
                            AiHandlerTableParam(iTemp).handlerName = aTemp(2)

                            iTemp += 1
                            Array.Resize(AiHandlerTable, iTemp + 1)
                            Array.Resize(AiHandlerTableParam, iTemp + 1)

                        Case "ai_events.txt"
                            '40|default|talker
                            'Dim AiEventsTable(0) As String
                            'Dim AiEventsTableParam(0) As AiEvents
                            AiEventsTable(iTemp) = aTemp(0)
                            AiEventsTableParam(iTemp).eventId = CInt(aTemp(0))
                            AiEventsTableParam(iTemp).eventHandler = aTemp(1)
                            AiEventsTableParam(iTemp).eventName = aTemp(2)

                            iTemp += 1
                            Array.Resize(AiEventsTable, iTemp + 1)
                            Array.Resize(AiEventsTableParam, iTemp + 1)

                        Case "ai_fetch_i.txt"
                            '8|default|x
                            'Dim AiFetchTable(0) As String
                            'Dim AiFetchTableParam(0) As AiFetch
                            AiFetchTable(iTemp) = aTemp(0)
                            AiFetchTableParam(iTemp).fetchId = CInt(aTemp(0))
                            AiFetchTableParam(iTemp).fetchEvent = aTemp(1)
                            AiFetchTableParam(iTemp).fetchName = aTemp(2)

                            iTemp += 1
                            Array.Resize(AiFetchTable, iTemp + 1)
                            Array.Resize(AiFetchTableParam, iTemp + 1)

                    End Select

                End If
            End While
            iTemp = 0
            inFile.Close()

        Next

        'FuncCallLoader = True
        Return True

    End Function

#End Region

#Region "Support functions"


    Private Function ElseLabel() As String

        Dim iTemp As Integer = OriginalCodeFlag
        While iTemp > 1

            If OriginalCode(iTemp).StartsWith("jump ") = True Then
                ElseLabel = OriginalCode(iTemp).Replace("jump ", "")
                Return ElseLabel
            End If

            iTemp = iTemp - 1
        End While
        Return ""

    End Function


    Private Function IsLastElse(ByVal sTempLabel As String) As Boolean


        sTempLabel = sTempLabel.Replace("jump ", "")

        Dim sTemp As String
        'sTemp = OriginalCode(Array.IndexOf(OriginalCode, OriginalCode(OriginalCodeFlag).Replace("jump ", "")) - 1)
        sTemp = OriginalCode(Array.IndexOf(OriginalCode, sTempLabel) - 1)

        If sTemp.StartsWith("jump ") = False And sTemp.StartsWith("L") = False Then 'And sTemp.StartsWith("//") = False
            Return True
        End If

        If OriginalCode(OriginalCodeFlag + 2) = OriginalCode(OriginalCodeFlag).Replace("jump ", "") Then
            Return True
        End If

        Return False

    End Function

    Private Function JumpLType(ByVal Label As String) As String

        JumpLType = ""

        If OriginalCode(FindJump("jump " & Label) - 1).StartsWith("L") = True Then
            JumpLType = "L"
        Else
            JumpLType = "."
        End If
        If OriginalCode(FindJump("jump " & Label) + 1).StartsWith("L") = True Then
            JumpLType = JumpLType & "L"
        Else
            JumpLType = JumpLType & "."
        End If

        Return JumpLType

    End Function



    Private Function FindJump(ByVal Label As String) As Integer

        'FindJump = -1
        FindJump = Array.IndexOf(OriginalCode, Label)
        If Array.LastIndexOf(OriginalCode, Label) <> FindJump And Label.StartsWith("branch_false") = True Then
            MessageBox.Show("duplicate definition for " & Label)
        End If

    End Function


    Private Function ToStack(ByVal Value As Object) As Boolean

        StackFlag += 1
        Stack(StackFlag) = Value

        ToStack = True
    End Function

    Private Function FromStack(ByVal Value As Integer) As Boolean

        Dim iTemp As Integer

        If Value > 0 Then
            ErrorStat("Wrong value for getting values from stack", "Stack reading...")
            iGF_ErrorFlag = True
            Return False
        End If

        If StackFlag = -1 Then
            ErrorStat("Stack empty", "Stack reading...")
            iGF_ErrorFlag = True
            Return False
        End If

        Value = -Value

        If Value > StackFlag + 1 Then
            ErrorStat("Trying of reading data more them exist", "Stack reading...")
            iGF_ErrorFlag = True
            Return False
        End If


        Array.Clear(StackCache, 0, StackCache.Length)

        For iTemp = 0 To Value - 1
            StackCache(iTemp) = Stack(StackFlag - Value + 1 + iTemp)
        Next

        DeleteStack(Value)

        FromStack = True
    End Function

    Private Function DeleteStack(ByVal Value As Integer) As Boolean

        Dim iTemp As Integer

        For iTemp = 0 To Value - 1
            Stack(StackFlag - iTemp) = ""
        Next
        StackFlag -= Value

        DeleteStack = True
    End Function

    Private Function Loader() As String

        Loader = OriginalCode(OriginalCodeFlag)
        'AISrcCodeTextBox.AppendText(Loader & vbNewLine)
        Label2.Text = "line is: " & LineStat
        Label3.Text = "current code: " & Loader
        Me.Update()
        LineStat += 1
        Loader = StringPrecompile(Loader, False)
        ProgressBar.Value = CInt(OriginalCodeFlag) 'CInt(OriginalCodeFlag / (OriginalCode.Length - 1) * 100)
        ProgressBar.Update()

    End Function

    Private Function Saver(ByVal Msg As String, ByVal DebugMsg As String, ByVal DebugMsgConfirm As Boolean) As Boolean

        'DebugMsgConfirm = False
        DebugMsgConfirm = FullDebugCodeCheckBox.Checked

        AiCode = Msg
        If DebugMsgConfirm = True Then
            AiCode = AiCode & "<---" & DebugMsg
        End If

        If DecompiledCode.Length <= DecompiledCodeFlag Then
            Array.Resize(DecompiledCode, DecompiledCodeFlag + 1)
        End If
        DecompiledCode(DecompiledCodeFlag) = AiCode
        DecompiledCodeFlag += 1

        AiCode = ""
        Return True

    End Function

    Private Function Tabs(ByVal TabValue As Integer) As String
        Dim iTemp As Integer
        Tabs = ""

        For iTemp = 0 To TabValue - 1
            Tabs = Tabs & vbTab
        Next
    End Function

    Private Function StringPrecompile(ByVal Msg As String, ByVal RemoveComma As Boolean) As String

        If RemoveComma = True Then
            Msg = Msg.Replace("//", "")
        End If

        Msg = Msg.Replace(Chr(9), Chr(32)).Replace("  ", " ").Trim
        While InStr(Msg, "  ") <> 0
            Msg = Msg.Replace("  ", " ")
        End While
        Return Msg

    End Function

    Private Function ErrorStat(ByVal Msg As String, ByVal EventBlock As String) As Boolean

        If ShowBugLineCheckBox.Checked = True Then
            Dim iTemp As Integer
            AIDebugCodeTextBox.Text = ""
            TabControl.SelectedIndex = 2

            Dim UpRange As Integer = 5, DownRange As Integer = 5

            If OriginalCodeFlag <= 5 Then
                UpRange = OriginalCodeFlag
            End If
            If OriginalCodeFlag >= OriginalCode.Length - 5 Then
                DownRange = OriginalCode.Length - OriginalCodeFlag - 1
            End If

            For iTemp = -UpRange To DownRange
                AIDebugCodeTextBox.AppendText((OriginalCodeFlag + iTemp).ToString & ": ")
                If iTemp = 0 Then AIDebugCodeTextBox.AppendText("-> ")
                AIDebugCodeTextBox.AppendText(OriginalCode(OriginalCodeFlag + iTemp) & vbNewLine)
            Next
        End If

        'If MessageBox.Show("Decompilation error for :" & EventBlock & vbNewLine & Msg & vbNewLine & "Error in : '" & LineStat & "' line" & vbNewLine & vbNewLine & "Stop decompilation or continue?", "Decompilation critical error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
        MessageBox.Show("Decompilation error for :" & EventBlock & vbNewLine & Msg & vbNewLine & "Error in : '" & LineStat & "' line", "Decompilation critical error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ShowCode()
        iGF_ErrorFlag = True
        If DataFromDebugCheckBox.Checked <> True Then SaveCode()
        MessageBox.Show("Decompilation abort on error line by user." & vbNewLine & "File saved to 'ai_out_abort.txt'", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information)
        OriginalCodeFlag = OriginalCode.Length - 1
        ProgressBar.Value = 0
        GlobalProgressBar.Value = 0

        If DataFromDebugCheckBox.Checked = False And LoadFilesCheckBox.Checked = False Then
            inAIFile.Close()
        End If

        Return False
        'End If

        Return True

    End Function
#End Region

#Region "C4Decompilator"

    Private Sub C4Decompilator()

        On Error GoTo errorDef

        Dim sTemp As String ', sTemp2 As String
        Dim iTemp As Integer
        Dim aTemp(100) As String
        Dim IsProperty As Boolean = True

        While LoadCode() = True

            If LoadFilesCheckBox.Checked = True Then
                GlobalProgressBar.Value = iGF_FileIndex + 1
            ElseIf DataFromDebugCheckBox.Checked = True Then
                GlobalProgressBar.Value = (OriginalCode.Length - 1)
            Else
                If iGF_FilePosition > 0 Then GlobalProgressBar.Value = CInt(inAIFile.BaseStream.Position)
            End If


            'AIDebugCodeTextBox.Text = ""

            ProgressBar.Maximum = OriginalCode.Length - 1
            ProgressBar.Value = 0

            Dim LabelStack As String = Nothing

            For OriginalCodeFlag = 0 To OriginalCode.Length - 1

                sTemp = Loader()
                sTemp = StringPrecompile(sTemp, False)

                If sTemp.StartsWith("L") = True Then
                    If OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = True Then
                        'LabelStack = LabelStack 
                    Else
                        LabelStack = sTemp
                    End If
                End If

                If sTemp.StartsWith("L201147") = True Then
                    AiCode = ""
                End If

                'class 1 default_npc : (null)
                If sTemp.StartsWith("class ") = True Then
                    ' ---------- class ----------
                    'Saver(outFile, "", "class", False)
                    Saver(sTemp, "class", False)
                    Saver("{", "class", False)

                    aTemp = sTemp.Split(Chr(32))
                    sLastClassType = aTemp(1)   ' keep class type - 1 or 2
                    SavedFileLabel.Text = "Load data from: " & System.IO.Path.GetFileName(aGF_FileName(iGF_FileIndex)) & " .... Decompilation class: " & aTemp(2)

                    IsProperty = True

                ElseIf sTemp.Trim = "" Then
                    'Saver(outFile, "", "null-line", False)

                ElseIf sTemp.StartsWith("L") = True Then
                    ' ----------- L02093 -----------

                    sTemp = StringPrecompile(sTemp, False)
                    aTemp = sTemp.Split(Chr(32))

                    ' bebug breakpoint
                    If sTemp = "L21278" Then
                        AiCode = "L33899"
                    End If

                    ' ---- IF block start
                    '	branch_false L4128
                    'L4127
                    If OriginalCode(OriginalCodeFlag - 1).StartsWith("branch_false") = True Then
                        If FromStack(-1) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        If InStr(DecompiledCode(DecompiledCodeFlag - 2), "else ") <> 0 Then

                            If ElseLabel() <> "" Then
                                iTemp = Array.IndexOf(aLabelsDB, ElseLabel())
                                If iTemp <> -1 Then
                                    aLabelsDB(iTemp) = ""
                                End If
                            End If

                            ' --------- test labels db ----
                            aTemp = OriginalCode(OriginalCodeFlag - 1).Split(Chr(32))

                            iTemp = Array.IndexOf(aLabelsDB, aTemp(0))
                            If iTemp <> -1 Then
                                aLabelsDB(iTemp) = ""
                                If Array.IndexOf(aLabelsDB, aTemp(0)) <> -1 Then
                                    MessageBox.Show("WoW")
                                End If
                            End If

                            Array.Resize(aLabelsDB, aLabelsDB.Length + 1)
                            aLabelsDB(aLabelsDB.Length - 1) = aTemp(1)
                            ' ------------------------------

                            ' Start ElseIf block
                            DecompiledCodeFlag -= 2
                            Saver("elseif ( " & StackCache(0).ToString & " )", sTemp & "_ElseIf_block", True)
                            Saver("{", sTemp & "_ElseIf_block", True)


                        ElseIf InStr(DecompiledCode(DecompiledCodeFlag - 1), "case :") <> 0 Then
                            DecompiledCodeFlag -= 1
                            Saver("case " & StackCache(0).ToString & ": {", sTemp & "_Case_block", True)

                            ' -- Empty Case fix ---
                            '	branch_false L20874
                            'L20873
                            '	jump L20875
                            'L20874
                            If OriginalCode(OriginalCodeFlag + 1).StartsWith("jump") Then
                                If OriginalCode(OriginalCodeFlag - 1).Replace("branch_false ", "") = OriginalCode(OriginalCodeFlag + 2) Then
                                    ' Empty block found
                                    Saver("}", sTemp & "_EmptyCase_block", True)
                                    OriginalCodeFlag = OriginalCodeFlag + 2
                                End If
                            End If

                        Else
                            Saver("if ( " & StackCache(0).ToString & " )", sTemp & "_IF_block_start", True)
                            Saver("{", sTemp & "IF_block_start", True)

                            ' --------- test labels db ----
                            aTemp = OriginalCode(OriginalCodeFlag - 1).Split(Chr(32))
                            Array.Resize(aLabelsDB, aLabelsDB.Length + 1)
                            aLabelsDB(aLabelsDB.Length - 1) = aTemp(1)
                            ' ------------------------------

                        End If
                        GoTo EndOfL
                    End If

                    If Array.IndexOf(aLabelsDB, sTemp) <> -1 Then

                        If FindJump("branch_false " & sTemp) <> -1 Then
                            Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else1)", True)
                            GoTo EndOfL
                        End If

                        If FindJump("jump " & sTemp) <> -1 Then
                            Saver("}", sTemp & "_EndOfBlock_jumpcheck1_2(While,Select,Else1)", True)
                            GoTo EndOfL
                        End If
                        GoTo EndOfL

                        'If OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = False Then
                        'Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else2)", True)
                        'GoTo EndOfL
                        'End If

                        If OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = False And OriginalCode(OriginalCodeFlag + 1).StartsWith("L") = False Then
                            ' 100% filter - Prev and Next is not Label
                            If OriginalCode(OriginalCodeFlag + 1).StartsWith("handler_end") = False And OriginalCode(OriginalCodeFlag + 2).StartsWith("handler_end") = False Then
                                ' 100% filter - Label in end of handler
                                Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", True)
                                GoTo EndOfL
                            End If

                            ' ---- Label first in block
                        ElseIf OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = False And OriginalCode(OriginalCodeFlag + 1).StartsWith("L") = True Then
                            ' Prev Null and Next is Branch
                            Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", True)
                            GoTo EndOfL
                            If FindJump("branch_false " & OriginalCode(OriginalCodeFlag + 1)) <> -1 Then
                                Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", True)
                            End If

                            ' ---- Label into block (not first)
                        ElseIf OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = True Then

                            GoTo EndOfL
                            If OriginalCode(OriginalCodeFlag + 1).StartsWith("L") = True Then
                                If FindJump("branch_false " & OriginalCode(OriginalCodeFlag + 1)) <> -1 Then
                                    If FindJump("branch_false " & LabelStack) = -1 Then
                                        Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", True)
                                        GoTo EndOfL
                                    End If

                                End If
                            End If


                            ' ----- Confuse filters! -----
                            ' Label is last in label block
                            If OriginalCode(OriginalCodeFlag + 1).StartsWith("L") = False Then
                                If FindJump("branch_false " & LabelStack) = -1 Then
                                    Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", True)
                                    GoTo EndOfL
                                End If
                            End If

                        End If

                        ' --- old code ---
                        'If OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = False Then
                        'Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else)", True)
                        'GoTo EndOfL
                        'End If

                    End If

                    ' Start WHILE
                    If FindJump("jump " & sTemp) > OriginalCodeFlag Then

                        'L118404
                        '...
                        '	shift_sp -1
                        '	jump L118404
                        'L118405
                        If OriginalCode(FindJump("jump " & sTemp) - 1) = "shift_sp -1" Then
                            If OriginalCode(FindJump("jump " & sTemp) + 1).StartsWith("L") Then
                                Saver("WhileFor ( ", sTemp & "WhileFor_block_start", True)
                                GoTo EndOfL
                            End If
                        End If
                    End If

                    If OriginalCode(OriginalCodeFlag - 2).StartsWith("shift_sp -1") = True And OriginalCode(OriginalCodeFlag - 1).StartsWith("jump ") = True Then
                        Saver("}", sTemp & "while_block_end", True)
                        GoTo EndOfL
                    End If
                    ' END WHILE

                ElseIf InStr(sTemp, "branch_true") <> 0 Then

                    GoTo EndOfL
                    ' ---------------- branch_true ------------------
                    AiCode = ""
                    sTemp = StringPrecompile(sTemp, False)
                    aTemp = sTemp.Split(Chr(32))

                    If DecompiledCode(DecompiledCodeFlag - 1).StartsWith("WhileFor ( ") = True Then
                        If OriginalCode(OriginalCodeFlag + 1).StartsWith("jump ") = False Then
                            If FromStack(-1) = False Then
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If
                            DecompiledCode(DecompiledCodeFlag - 1) = "while ( " & StackCache(0).ToString & " )"
                            Saver("{", sTemp & "_While_Start_Block", False)
                        Else
                            ' This is FOR
                        End If
                    End If


                ElseIf InStr(sTemp, "branch_false") <> 0 Then
                    ' ---------------- branch_false ------------------

                    sTemp = StringPrecompile(sTemp, False)
                    aTemp = sTemp.Split(Chr(32))

                    If sTemp = "branch_false L118405" Then
                        AiCode = ""
                    End If

                    If DecompiledCode(DecompiledCodeFlag - 1).StartsWith("WhileFor ( ") = True Then
                        If OriginalCode(OriginalCodeFlag + 1).StartsWith("jump ") = False Then
                            If FromStack(-1) = False Then
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If
                            DecompiledCode(DecompiledCodeFlag - 1) = "while ( " & StackCache(0).ToString & " )"
                            Saver("{", sTemp & "_While_Start_Block", False)
                        End If
                    End If

                    GoTo EndOfL

                ElseIf InStr(sTemp, "jump") <> 0 Then
                    ' ----------- jump L207102 -----------
                    sTemp = StringPrecompile(sTemp, False)
                    aTemp = sTemp.Split(Chr(32))

                    If sTemp = "jump L21278" Then
                        Dim aaa As Integer = 0
                    End If

                    If FindJump(aTemp(1)) < OriginalCodeFlag Then
                        ' End While and etc
                        If DecompiledCode(DecompiledCodeFlag - 2).StartsWith("for ( ") = True Then
                            ' And FOR block

                            ' FIX
                            'If FromStack(-1) = False Then
                            'iGF_ErrorFlag = True
                            'GoTo EndOfL
                            'End If
                            ' FIX 

                            AiCode = DecompiledCode(DecompiledCodeFlag - 2) & " ; " & DecompiledCode(DecompiledCodeFlag - 1).Replace(";", "") & " )"
                            DecompiledCodeFlag -= 2
                            'AiCode = AiCode & " ; " & StackCache(0).ToString & " )"
                            Saver(AiCode, sTemp & "_FOR_define_finished", True)
                            Saver("{", sTemp & "_FOR_define_finished", True)
                            OriginalCodeFlag += 1
                        End If

                    Else

                        If OriginalCode(OriginalCodeFlag + 1).StartsWith("jump ") Then
                            ' SelectCase - Case block

                            Saver("break;", sTemp & "_oneCaseBlockEnd_jumpjump", True)
                            Saver("}", sTemp & "_oneCaseBlockEnd_jumpjump", True)

                            OriginalCodeFlag += 1
                            ' REMOVED TO Lxxx block
                            ' ------------
                        ElseIf OriginalCode(OriginalCodeFlag - 1).StartsWith("branch_false") And OriginalCode(OriginalCodeFlag + 1).StartsWith("L") Then
                            ' And FOR block
                            If FromStack(-1) = False Then
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If
                            ' --------- test labels db ----
                            aTemp = OriginalCode(OriginalCodeFlag - 1).Split(Chr(32))
                            Array.Resize(aLabelsDB, aLabelsDB.Length + 1)
                            aLabelsDB(aLabelsDB.Length - 1) = aTemp(1)
                            ' --------- test labels db ----

                            If DecompiledCode(DecompiledCodeFlag - 1).StartsWith("WhileFor ( ") = True Then
                                StackCache(1) = StackCache(0)
                                StackCache(0) = DecompiledCode(DecompiledCodeFlag - 2)
                                DecompiledCodeFlag -= 2
                            Else
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If

                            'DecompiledCode(DecompiledCodeFlag - 1) = "for ( " & StackCache(0).ToString & " , " & StackCache(1).ToString
                            'Saver("for ( " & StackCache(0).ToString & " ; " & StackCache(1).ToString, sTemp & "_ForStartBlock", True)
                            Saver("for ( " & StackCache(0).ToString & " " & StackCache(1).ToString, sTemp & "_ForStartBlock", True)
                            OriginalCodeFlag += 1

                        ElseIf OriginalCode(OriginalCodeFlag + 1).StartsWith("L") = True Then ' And OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = False Then

                            ' -------- ELSE FIX v2 ----------

                            ' -- Empty Case fix ---
                            '	branch_false L22408
                            'L22407
                            '....
                            '	jump L22409 <----
                            'L22408
                            'L22409
                            '	jump L22410
                            'L22406

                            If OriginalCode(OriginalCodeFlag + 2).StartsWith("L") = True Then
                                If OriginalCode(OriginalCodeFlag).Replace("jump ", "") = OriginalCode(OriginalCodeFlag + 2) Then
                                    ' Empty block found
                                    'Saver("}2", sTemp & "_EmptyElse_block", True)
                                    'OriginalCodeFlag = OriginalCodeFlag + 1
                                    'GoTo EndOfL
                                End If
                            End If

                            ' -------- ELSE FIX v1 ----------
                            'If IsLastElse(OriginalCode(OriginalCodeFlag)) = True Then
                            ' --------- test labels db ----
                            aTemp = OriginalCode(OriginalCodeFlag + 1).Split(Chr(32))
                            iTemp = Array.IndexOf(aLabelsDB, aTemp(0))
                            If iTemp <> -1 Then
                                aLabelsDB(iTemp) = ""
                                If Array.IndexOf(aLabelsDB, aTemp(0)) <> -1 Then
                                    MessageBox.Show("WoW")
                                End If
                            End If

                            aTemp = sTemp.Split(Chr(32))
                            Array.Resize(aLabelsDB, aLabelsDB.Length + 1)
                            aLabelsDB(aLabelsDB.Length - 1) = aTemp(1)
                            ' ------------------------------

                            'End If

                            ' Else
                            Saver("}", sTemp & "_ElseBlock", True)
                            Saver("else ", sTemp & "_ElseBlock", True)
                            Saver("{", sTemp & "_ElseBlock", True)
                            OriginalCodeFlag += 1

                        ElseIf OriginalCode(OriginalCodeFlag + 1).StartsWith("L") = True And OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = True Then

                            ' -- Empty Case fix ---
                            '	branch_false L22408
                            'L22407
                            '....
                            '	jump L22409
                            'L22408
                            'L22409 (jump for empty block)
                            '	jump L22410 <----
                            'L22406 (branch_false)
                            If FindJump("jump " & OriginalCode(OriginalCodeFlag - 1)) <> -1 And FindJump("branch_false " & OriginalCode(OriginalCodeFlag + 1)) <> -1 Then
                                If Array.IndexOf(aLabelsDB, OriginalCode(OriginalCodeFlag + 1)) <> -1 Then
                                    'Array.IndexOf(aLabelsDB, OriginalCode(OriginalCodeFlag - 1)) = -1 And
                                    ' -------- ELSE FIX v1 ----------
                                    If IsLastElse(OriginalCode(OriginalCodeFlag)) = True Then
                                        ' --------- test labels db ----
                                        aTemp = OriginalCode(OriginalCodeFlag + 1).Split(Chr(32))
                                        iTemp = Array.IndexOf(aLabelsDB, aTemp(0))
                                        If iTemp <> -1 Then
                                            aLabelsDB(iTemp) = ""
                                            If Array.IndexOf(aLabelsDB, aTemp(0)) <> -1 Then
                                                MessageBox.Show("WoW")
                                            End If
                                        End If

                                        aTemp = sTemp.Split(Chr(32))
                                        Array.Resize(aLabelsDB, aLabelsDB.Length + 1)
                                        aLabelsDB(aLabelsDB.Length - 1) = aTemp(1)
                                        ' ------------------------------

                                    End If
                                    ' Else
                                    Saver("}", sTemp & "_ElseBlock", True)
                                    Saver("else ", sTemp & "_ElseBlock", True)
                                    Saver("{", sTemp & "_ElseBlock", True)
                                    OriginalCodeFlag += 1
                                End If

                            ElseIf FindJump("branch_false " & OriginalCode(OriginalCodeFlag - 1)) <> -1 And FindJump("branch_false " & OriginalCode(OriginalCodeFlag + 1)) <> -1 Then


                                ' ssq_main_event_acolyte 
                                'L22574
                                '	jump L22578
                                'L22571
                                ' need else and this is last jump

                            End If


                        End If


                    End If


                ElseIf InStr(sTemp, "push_event") <> 0 Then
                    ' ---------- push_event ----------
                    ' push_event      //  myself
                    ' push_const 111
                    ' APPROVE 100%

                    If InStr(OriginalCode(OriginalCodeFlag + 1), "push_const") = 0 Then
                        ErrorStat("[Crit] Required 'push_event' must be 'push_const'", "push_const")
                        iGF_ErrorFlag = True
                        GoTo EndOfL
                    End If

                    If AiVarsCheckBox.Checked = False Then

                        If InStr(sTemp, "//") = 0 Then
                            ErrorStat("[Crit] Not defined name for this push_event.", "push_event")
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If

                        sTemp = StringPrecompile(sTemp, True)
                        aTemp = sTemp.Split(Chr(32))
                        ToStack(aTemp(1))
                        sLastEvent = aTemp(1)

                        If DataFromDebugCheckBox.Checked = False And Array.IndexOf(sVarTable, aTemp(1)) = -1 And aTemp(1) <> "gg" Then
                            ErrorStat("[Aver] Event '" & aTemp(1) & "' is not defined in variable list for this handler", "push_event")
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If

                        OriginalCodeFlag += 1
                        sTemp = Loader()
                        'If InStr(sTemp, "push_const") = 0 Then
                        '    ErrorStat("[Aver] Required push_const next after push_event", "push_const")
                        '    iGF_ErrorFlag = True
                        '    GoTo EndOfL
                        'End If

                    Else

                        sTemp = StringPrecompile(sTemp, True)
                        'aTemp = sTemp.Split(Chr(32))
                        OriginalCodeFlag += 1
                        sTemp = Loader()
                        'If InStr(sTemp, "push_const") = 0 Then
                        '    ErrorStat("[Aver] Required push_const next after push_event", "push_const")
                        '    iGF_ErrorFlag = True
                        '    GoTo EndOfL
                        'End If
                        sTemp = StringPrecompile(sTemp, True)
                        aTemp = sTemp.Split(Chr(32))
                        sTemp = GetAiVar(aTemp(1), "event")
                        If sTemp = Nothing Then iGF_ErrorFlag = True : GoTo EndOfL
                        ToStack(sTemp)
                        sLastEvent = sTemp

                    End If


                ElseIf InStr(sTemp, "fetch_232323232") <> 0 Then
                    ' ---------- fetch_i ----------
                    ' APPROVE 100%


                    If InStr(OriginalCode(OriginalCodeFlag + 1), "push_const") > 0 And OriginalCode(OriginalCodeFlag + 2) = "add" Then


                        sTemp = StringPrecompile(sTemp, True)
                        aTemp = sTemp.Split(Chr(32))
                        sTemp = aTemp(1)  ' var name for NoAIVarConfig mode

                        If AiVarsCheckBox.Checked = False Then
                            Stack(StackFlag) = Stack(StackFlag).ToString & "." & aTemp(1)
                        Else
                            OriginalCodeFlag += 1
                            sTemp = Loader()
                            sTemp = StringPrecompile(sTemp, True)
                            aTemp = sTemp.Split(Chr(32))
                            sTemp = GetAiVar(aTemp(1), "fetch")
                            If sTemp = Nothing Then iGF_ErrorFlag = True : GoTo EndOfL
                            Stack(StackFlag) = Stack(StackFlag).ToString & "." & sTemp
                        End If

                    Else
                        'MessageBox.Show("FETCH NO ADD!! ALARMA. NEED REPORT TO DEVELOPER!")

                    End If


                ElseIf InStr(sTemp, "fetch_") <> 0 Then

                    If FreyaAITempFixCheckBox.Checked = True Then

                        ' FREYA FIX
                        'push_event	//  myself
                        'push_const 784			//ShowPage
                        'add
                        'fetch_i			//ShowPage
                        'push_event	//  talker
                        'push_const 40			//talker
                        'add
                        'fetch_i
                        'S11656.	"guide_gcol002.htm"
                        'push_string S11656
                        'func_call 235012172	//  func[ShowPage]
                        'shift_sp -2
                        'shift_sp -1

                        If InStr(sTemp, "//") <> 0 Then

                            If (InStr(OriginalCode(OriginalCodeFlag + 1), "push_const") > 0 And InStr(OriginalCode(OriginalCodeFlag + 1), "push_const 0") = 0) Or InStr(OriginalCode(OriginalCodeFlag + 1), "push_event") > 0 Then
                                sTemp = StringPrecompile(sTemp, True)
                                aTemp = sTemp.Split(Chr(32))
                                sTemp = aTemp(0)
                            End If

                        End If
                    End If

                    If InStr(sTemp, "//") <> 0 And AiVarsCheckBox.Checked = False Then

                        sTemp = StringPrecompile(sTemp, True)
                        aTemp = sTemp.Split(Chr(32))


                        If OriginalCode(OriginalCodeFlag + 2) = "add" Then
                            'push_event	//  myself
                            'push_const 704
                            'add
                            'fetch_i	//  sm
                            'push_const 544
                            'add
                            'fetch_i	//  alive
                            'push_const 104
                            'add
                            'fetch_i4

                            '---> target.alive
                            '---> myself.sm.alive

                            If aTemp.Length = 1 Then
                                ErrorStat("Required name for fetch_i. Example, fetch_i //  alive", "fetch_i")
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If
                            Stack(StackFlag) = Stack(StackFlag).ToString & "." & aTemp(1)
                        Else
                            ToStack(aTemp(1))
                            'MessageBox.Show("FETCH NO ADD!! ALARMA. NEED REPORT TO DEVELOPER!")
                        End If


                        If FreyaAITempFixCheckBox.Checked = True Then
                            If InStr(OriginalCode(OriginalCodeFlag + 1), "push_const") > 0 Or InStr(OriginalCode(OriginalCodeFlag + 1), "push_parameter 0") > 0 Then
                                OriginalCodeFlag += 1
                                sTemp = Loader()
                            End If
                        Else
                            OriginalCodeFlag += 1
                            sTemp = Loader()
                            If InStr(sTemp, "push_const") = 0 And InStr(sTemp, "push_parameter") = 0 Then
                                ' DEBUG
                                ErrorStat("Required 'push_const' next after 'fetch_i'", "fetch_i")
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If

                        End If


                ElseIf AiVarsCheckBox.Checked = True And InStr(OriginalCode(OriginalCodeFlag + 1), "push_const") > 0 Then

                    'sLastEvent
                    'ai_fetch_i.txt
                    '16|default|y
                    '16|h0|creature

                    'push_event	//  myself
                    'push_const 704
                    'add
                    'fetch_i	//  sm
                    'push_const 544
                    'add
                    'fetch_i	//  alive
                    'push_const 104
                    'add
                    'fetch_i4

                    sTemp = StringPrecompile(sTemp, True)
                    aTemp = sTemp.Split(Chr(32))
                    If aTemp(0) <> "fetch_i" Then GoTo EndOfL
                    OriginalCodeFlag += 1
                    sTemp = Loader()
                    sTemp = StringPrecompile(sTemp, True)
                    aTemp = sTemp.Split(Chr(32))
                    If OriginalCode(OriginalCodeFlag + 1).Trim = "add" Then
                        sTemp = GetAiVar(aTemp(1), "fetch")
                        If sTemp = Nothing Then iGF_ErrorFlag = True : GoTo EndOfL
                        Stack(StackFlag) = Stack(StackFlag).ToString & "." & sTemp

                        ' fix for myself(event).sm(fetch).hp(fetch)
                        sLastEvent = sTemp
                    Else

                        'iGF_ErrorFlag = True : GoTo EndOfL 'iGF_ErrorFlag = True : GoTo EndOfL
                        'recovery last line
                        OriginalCodeFlag = OriginalCodeFlag - 1

                    End If

                ElseIf 1 <> 1 Then

                    sTemp = GetAiVar(aTemp(1), "fetch")
                    If sTemp <> Nothing Then

                        If OriginalCode(OriginalCodeFlag + 2) = "add" Then
                            'push_event	//  target
                            'push_const96
                            'add
                            'fetch_i	//  alive
                            'push_const 104

                            '---> target.alive
                            Stack(StackFlag) = Stack(StackFlag).ToString & "." & sTemp
                        Else
                            ToStack(sTemp)
                            'MessageBox.Show("FETCH NO ADD!! ALARMA. NEED REPORT TO DEVELOPER!")
                        End If

                    Else
                        'iGF_ErrorFlag = True : GoTo EndOfL 'iGF_ErrorFlag = True : GoTo EndOfL
                        'recovery last line
                        OriginalCodeFlag = OriginalCodeFlag - 1
                    End If

                Else
                    ' Not happening

                    'push_event	//  myself
                    'push_const 704
                    'add
                    'fetch_i
                    'push_event	//  talker

                End If

                    ElseIf InStr(sTemp, "push_const") <> 0 Then
                        ' ---------- push_const ----------
                        ' APPROVE 100%
                        'push_const 40

                        sTemp = StringPrecompile(sTemp, False)
                        aTemp = sTemp.Split(Chr(32))
                        ToStack(aTemp(1))

                    ElseIf InStr(sTemp, "fetch_d") <> 0 Then
                        ' ---------- fetch_d ----------
                        'ToStack(0)
                    ElseIf InStr(sTemp, "fetch_f") <> 0 Then
                        ' ---------- fetch_f ----------
                        'ToStack(0.0)
                    ElseIf InStr(sTemp, "fetch_i4") <> 0 Then
                        ' ---------- fetch_i4 ----------
                        'ToStack(0)
                        ' ---------- fetch_i4 ----------
                    ElseIf InStr(sTemp, "fetch_i") <> 0 Then 'shift_sp
                        ' ---------- fetch_i ----------
                        'ToStack(0)

                    ElseIf InStr(sTemp, "assign4") <> 0 Then
                        ' ---------- assign4 ----------
                        ' APPROVE 100%

                        AiCode = ""
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & " = " & StackCache(1).ToString
                        ToStack(AiCode)
                        AiCode = ""
                        GoTo EndOfL

                    ElseIf InStr(sTemp, "assign") <> 0 Then
                        ' ---------- assign ----------
                        AiCode = ""
                        'Dim iTemp2 As Integer = StackFlag

                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & " = " & StackCache(1).ToString
                        ToStack(AiCode)
                        AiCode = ""

                    ElseIf InStr(sTemp, "shift_sp") <> 0 Then
                        ' ---------- shift_sp ----------

                        ' shift_sp -1; func_call; assign; fetch_
                        'If InStr(sTemp, "shift_sp -1") <> 0 Then ' And InStr(sLastLine, "assign") = 0 then
                        If sTemp = "shift_sp -1" Then ' And InStr(sLastLine, "assign") = 0 then

                            If OriginalCode(OriginalCodeFlag - 1) = "L118406" Then
                                Dim sdshdj As Integer = 1
                            End If
                            ' Select End Blocker
                            If OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = True Then ' End SelectCase Block
                                If FindJump("jump " & OriginalCode(OriginalCodeFlag - 1)) <> -1 And (FindJump("jump " & OriginalCode(OriginalCodeFlag - 1)) < OriginalCodeFlag) Then
                                    Saver("}", OriginalCode(OriginalCodeFlag - 1) & "_before_shift_sp -1_EndSelectCase_Block", True)

                                    ' Clear stack for shift_sp -1 for case Begin value
                                    If FromStack(-1) = False Then
                                        iGF_ErrorFlag = True
                                        GoTo EndOfL
                                    End If

                                    GoTo EndOfL
                                End If
                            End If

                            'If OriginalCode(OriginalCodeFlag - 1).StartsWith("fetch_") = False Then
                            ' fetch_ - for FOR
                            If FromStack(-1) = False Then
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If
                            AiCode = StackCache(0).ToString & ";"
                            Saver(AiCode, OriginalCode(OriginalCodeFlag - 1) & "after _shift_sp -1", True)
                            ' !!!!!!!!!!! testing clearing stack !!!!!!!!!!!
                            'If StackFlag > 0 Then StackFlag = -1
                            'End If

                        End If

                    ElseIf InStr(sTemp, "push_reg_sp") <> 0 Then
                        ' ---------- push_reg_sp ----------

                        If OriginalCode(OriginalCodeFlag - 1) = "L118431" Then
                            Dim ajhdja As Integer = 1
                        End If


                        If OriginalCode(OriginalCodeFlag + 4).StartsWith("branch_false") = True Then 'InStr(sLastLine, "fetch_") <> 0 Or 

                            '	func_call 184615097	//  func[Agit_GetDecoLevel]
                            '	shift_sp -1
                            '	push_reg_sp
                            If DecompiledCode(DecompiledCodeFlag - 2) <> "break;" And DecompiledCode(DecompiledCodeFlag - 2).StartsWith("case ") = False Then
                                'If StackFlag > -1 Then
                                If FromStack(-1) = False Then
                                    iGF_ErrorFlag = True
                                    GoTo EndOfL
                                End If
                                Saver("switch ( " & StackCache(0).ToString & " )", "_SelectCaseStartBlock_(push_reg_sp check)", True)
                                Saver("{", "SelectCaseStartBlock_(push_reg_sp check)", True)
                                Saver("case :", "SelectCaseStartBlock_(push_reg_sp check)", True)

                                ' Save last stack for next using
                                ' USE ONLY in Exception situation, when Previous Jumps use {} emptry block
                                ToStack(StackCache(0).ToString)
                                'ToStack(StackCache(0).ToString)

                                GoTo EndOfL
                            End If
                        End If

                        If OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = True And OriginalCode(OriginalCodeFlag - 2).StartsWith("jump ") = True Then ' Or InStr(sLastLine, "fetch_") <> 0 Then
                            Saver("case :", "SelectCase_start_block_(push_reg_sp check)", True)
                            GoTo EndOfL
                        End If


                        'push_event'//  i2
                        'push_const 268
                        'add
                        'push_reg_sp
                        'fetch_i
                        'push_reg_sp
                        'fetch_i
                        'fetch_i4
                        'push_const 1
                        'add
                        'assign4
                        'fetch_i4
                        'shift_sp -1
                        'jump L4140
                        ' ---------
                        ' i2=i2+1 = i2++

                        If OriginalCodeFlag + 9 < OriginalCode.Length Then

                            If OriginalCode(OriginalCodeFlag + 1).StartsWith("fetch_") = True And _
                                OriginalCode(OriginalCodeFlag + 2).StartsWith("push_reg_sp") = True And _
                                OriginalCode(OriginalCodeFlag + 3).StartsWith("fetch_i") = True And _
                                OriginalCode(OriginalCodeFlag + 5).StartsWith("push_const 1") = True And _
                                OriginalCode(OriginalCodeFlag + 6).StartsWith("add") = True And _
                                OriginalCode(OriginalCodeFlag + 7).StartsWith("assign") = True And _
                                OriginalCode(OriginalCodeFlag + 9).StartsWith("shift_sp -1") = True Then
                                If FromStack(-1) = False Then
                                    iGF_ErrorFlag = True
                                    GoTo EndOfL
                                End If
                                ToStack(StackCache(0).ToString & "++")
                                'ToStack(StackCache(0).ToString)
                                OriginalCodeFlag += 8
                                GoTo EndOfL
                            End If
                        End If

                        If OriginalCode(OriginalCodeFlag + 1).StartsWith("fetch_") = True And OriginalCode(OriginalCodeFlag + 2).StartsWith("fetch_") = True Then
                            If FromStack(-1) = False Then
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If
                            ToStack(StackCache(0).ToString)
                            ToStack(StackCache(0).ToString)
                            OriginalCodeFlag += 1
                            GoTo EndOfL
                        End If


                    ElseIf InStr(sTemp, "func_call ") <> 0 Then
                        'ElseIf InStr(sTemp, "func[") <> 0 Then

                        ' ---------- func_call ----------
                        'func_call 184680516     //  func[ShowPage]
                        ' APPROVE 100%

                        Dim sFuncName As String, ParamAmount As Integer
                        sTemp = StringPrecompile(sTemp, True)
                        aTemp = sTemp.Split(Chr(32))

                        ' AIVARConfig Method
                        If AiVarsCheckBox.Checked = False Then
                            sFuncName = aTemp(2).Replace("func[", "").Replace("]", "")

                            iTemp = Array.IndexOf(FuncTable, sFuncName)
                            If iTemp = -1 Then
                                ErrorStat("Function func[" & sFuncName & "] have not in base", "func[")
                                iGF_ErrorFlag = True : GoTo EndOfL
                            End If

                        Else
                            ' Config method
                            sFuncName = GetAiVar(aTemp(1), "function")
                            If sFuncName = Nothing Then iGF_ErrorFlag = True : GoTo EndOfL
                            iTemp = Array.IndexOf(FuncTable, aTemp(1))
                        End If

                        'If FuncTableParam(iTemp).FuncName = "GetSpawnDefine" Then
                        '    Dim test As Integer = 1
                        'End If

#If DEBUG Then
                        If sFuncName = "GetTimeOfDay" Then
                            Dim asdsa As Boolean = False
                        End If
#End If

                        ''shift_sp -2
                        ''167837696|GetSpawnDefine,1,0

                        'ParamAmount = FuncTableParam(iTemp).FuncInVar
                        If FuncTableParam(iTemp).FuncInVar = 0 Then
                            ParamAmount = 0
                        Else
                            ParamAmount = CInt(Val(OriginalCode(OriginalCodeFlag + 1).Replace("shift_sp ", "")))
                            OriginalCodeFlag += 1
                            sTemp = Loader()
                        End If

                        If FromStack(ParamAmount) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = sFuncName & "("
                        For iTemp = 0 To -ParamAmount - 1
                            If iTemp > 0 Then
                                AiCode = AiCode & ", "
                            End If
                            'If InStr(StackCache(iTemp).ToString, " ") <> 0 Then StackCache(iTemp) = "(" & StackCache(iTemp).ToString & ")"
                            AiCode = AiCode & StackCache(iTemp).ToString
                        Next
                        AiCode = AiCode & ")"

                        If FromStack(-1) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & "::" & AiCode
                        ToStack(AiCode)

                    ElseIf sTemp.StartsWith("S") = True And InStr(sTemp, ".") <> 0 Then
                        ' ---------- Sxxxxxxx ----------
                        'S0.     "noquest.htm"

                        'sTemp = StringPrecompile(sTemp, False)
                        'aTemp = sTemp.Split(Chr(32))
                        aTemp(0) = Mid(sTemp, 1, InStr(sTemp, "."))
                        iTemp = Array.IndexOf(sSTable, aTemp(0))
                        If iTemp = -1 Then
                            aTemp(1) = sTemp.Remove(0, InStr(sTemp, """") - 1)

                            sSTable(sSTable.Length - 1) = aTemp(0)
                            sSTableParam(sSTableParam.Length - 1) = aTemp(1)
                            Array.Resize(sSTable, sSTable.Length + 1)
                            Array.Resize(sSTableParam, sSTableParam.Length + 1)
                        End If

                        ' -------- Сравнения ---------
                        ' greater_equal greater not_equal less_equal equal less
                    ElseIf sTemp = "greater_equal" Then
                        'If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        'AiCode = "(" & StackCache(0).ToString & " >= " & StackCache(1).ToString & ")"
                        AiCode = StackCache(0).ToString & " >= " & StackCache(1).ToString
                        'AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                        AiCode = ""
                        'End If
                    ElseIf sTemp = "greater" Then
                        'If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        'AiCode = "(" & StackCache(0).ToString & " > " & StackCache(1).ToString & ")"
                        AiCode = StackCache(0).ToString & " > " & StackCache(1).ToString
                        'AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                        AiCode = ""
                        'End If
                    ElseIf sTemp = "not_equal" Then
                        'If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        'AiCode = "(" & StackCache(0).ToString & " != " & StackCache(1).ToString & ")"
                        AiCode = StackCache(0).ToString & " != " & StackCache(1).ToString
                        'AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                        AiCode = ""
                        'End If
                    ElseIf sTemp = "less_equal" Then
                        'If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        'AiCode = "(" & StackCache(0).ToString & " <= " & StackCache(1).ToString & ")"
                        AiCode = StackCache(0).ToString & " <= " & StackCache(1).ToString
                        'AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                        AiCode = ""
                        'End If
                    ElseIf sTemp = "equal" Then
                        'If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
                        If DecompiledCode(DecompiledCodeFlag - 1).StartsWith("case :") = False And DecompiledCode(DecompiledCodeFlag - 2).StartsWith("break;") = False Then
                            If FromStack(-2) = False Then
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If
                            'AiCode = "(" & StackCache(0).ToString & " == " & StackCache(1).ToString & ")"
                            AiCode = StackCache(0).ToString & " == " & StackCache(1).ToString
                            'AiCode = "(" & AiCode & ")"
                            ToStack(AiCode)
                            AiCode = ""
                        End If
                        'End If
                    ElseIf sTemp = "less" Then
                        'If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        'AiCode = "(" & StackCache(0).ToString & " < " & StackCache(1).ToString & ")"
                        AiCode = StackCache(0).ToString & " < " & StackCache(1).ToString
                        'AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                        AiCode = ""
                        'End If
                        ' ------- LOGICAL LINKS ------
                    ElseIf sTemp = "call_super" Then
                        ' ----------- call_super -----------
                        Saver("super;", "call_super", False)

                    ElseIf sTemp = "exit_handler" Then
                        ' ----------- exit_handler -----------
                        Saver("return;", "exit_handler", False)

                    ElseIf sTemp = "and" Then
                        ' ----------- and -----------
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        'Dim Symb() As Char = CType(" =", Char())
                        'If StackCache(0).ToString.IndexOfAny(Symb) <> -1 Then StackCache(0) = "( " & StackCache(0).ToString & " )"
                        'If StackCache(1).ToString.IndexOfAny(Symb) <> -1 Then StackCache(1) = "( " & StackCache(1).ToString & " )"
                        If StackCache(0).ToString.StartsWith("(") = False Then StackCache(0) = "(" & StackCache(0).ToString & ")"
                        If StackCache(1).ToString.StartsWith("(") = False Then StackCache(1) = "(" & StackCache(1).ToString & ")"
                        AiCode = StackCache(0).ToString & " && " & StackCache(1).ToString
                        'AiCode = "(" & AiCode & ")"
                        '	push_const 18
                        '	equal
                        '	and
                        '	push_reg_sp
                        '	fetch_i
                        '	branch_true L22455
                        If OriginalCode(OriginalCodeFlag + 1) = "push_reg_sp" And OriginalCode(OriginalCodeFlag + 2) = "fetch_i" And _
                                OriginalCode(OriginalCodeFlag + 3).StartsWith("branch_true ") = True And _
                                OriginalCode(OriginalCodeFlag + 4).StartsWith("L") = False Then
                            ' nothing
                        Else

                            AiCode = "(" & AiCode & ")"
                        End If

                        ToStack(AiCode)

                    ElseIf sTemp = "or" Then
                        ' ----------- or -----------
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        'Dim Symb() As Char = CType(" =", Char())
                        'If StackCache(0).ToString.IndexOfAny(Symb) <> -1 Then StackCache(0) = "( " & StackCache(0).ToString & " )"
                        'If StackCache(1).ToString.IndexOfAny(Symb) <> -1 Then StackCache(1) = "( " & StackCache(1).ToString & " )"
                        If StackCache(0).ToString.StartsWith("(") = False Then StackCache(0) = "(" & StackCache(0).ToString & ")"
                        If StackCache(1).ToString.StartsWith("(") = False Then StackCache(1) = "(" & StackCache(1).ToString & ")"
                        AiCode = StackCache(0).ToString & " || " & StackCache(1).ToString

                        '	push_const 18
                        '	equal
                        '	or
                        '	push_reg_sp
                        '	fetch_i
                        '	branch_true L22455
                        If OriginalCode(OriginalCodeFlag + 1) = "push_reg_sp" And OriginalCode(OriginalCodeFlag + 2) = "fetch_i" And _
                                OriginalCode(OriginalCodeFlag + 3).StartsWith("branch_true ") = True And _
                                OriginalCode(OriginalCodeFlag + 4).StartsWith("L") = False Then
                            ' nothing
                        Else
                            AiCode = "(" & AiCode & ")"
                        End If

                        'AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)

                        ' ------- ARIFMETIC COMMAND -------------
                    ElseIf sTemp = "add" Then ' And InStr(sLastLine, "push_const") = 0 Then

                        ' I
                        'push_event	//  reply
                        'push_const 164
                        'add
                        'fetch_i4

                        ' II
                        'push_event	//  myself
                        'push_const 704
                        'add
                        'fetch_i	//  sm
                        'push_const 544
                        'add
                        'fetch_i

                        ' III
                        'push_event	//  myself
                        'push_const 704
                        'add
                        'fetch_i	//  i_ai1
                        'push_const 312
                        'add
                        'push_reg_sp
                        'fetch_i

                        'IV
                        ' (180 + 8) < 
                        'push_const 180
                        'push_const 8
                        'add
                        'less
                        'and
                        'push_reg_sp
                        'fetch_i
                        'branch_false L13394



                        'push_event      //  myself
                        'push_const 704
                        'add
                        'fetch_i
                        'push_event      //  myself
                        'push_const 704
                        'add
                        'fetch_i //  sm
                        'push_const 544
                        'add
                        'fetch_i
                        'push_const 3700
                        'push_const 0
                        'push_const 3

                        '  -> myself.sm.hp  myself.sm.max_hp
                        'push_event      //  myself
                        'push_const 704
                        'add
                        'fetch_i //  sm
                        'push_const 544
                        'add
                        'fetch_i //  hp
                        'push_const 392
                        'add
                        'fetch_d

                        'push_event      //  myself
                        'push_const 704
                        'add
                        'fetch_i //  sm
                        'push_const 544
                        'add
                        'fetch_i //  max_hp
                        'push_const 1216
                        'add
                        'fetch_d
                        'push_const 1.000000
                        'mul

                        '100% work code/original code for "// detected" version
                        'If InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0 Or InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Then

                        'If InStr(AISrcCodeTextBox.Lines(AISrcCodeTextBox.Lines.Length - 4), "push_event") = 0 And _
                        'InStr(AISrcCodeTextBox.Lines(AISrcCodeTextBox.Lines.Length - 4), "fetch_i") = 0 Then
                        'If InStr(AISrcCodeTextBox.Lines(AISrcCodeTextBox.Lines.Length - 4), "//") = 0 Then
                        'If InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0 Or InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Then
                        'AiVarsCheckBox.checked
                        '(AiVarsCheckBox.Checked = False And InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0) Or _
                        '(AiVarsCheckBox.Checked = True And InStr(OriginalCode(OriginalCodeFlag - 2), "push_event ") > 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const ") > 0) Then

                        'If InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Or _
                        '    ((InStr(OriginalCode(OriginalCodeFlag - 2), "push_event") > 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") > 0) = False And _
                        '    (InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") > 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") > 0) = False) Then

                        'If InStr(OriginalCode(OriginalCodeFlag - 2), "func_call") <> 0 Or (InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") <> 0 And _
                        '    (InStr(OriginalCode(OriginalCodeFlag - 2), "push_event") = 0 And InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") = 0)) Then

                        'If (AiVarsCheckBox.Checked = False And (InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0 Or InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0)) Or _
                        '   (AiVarsCheckBox.Checked = True And (InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Or (InStr(OriginalCode(OriginalCodeFlag - 3), "func_call ") <> 0 And InStr(OriginalCode(OriginalCodeFlag - 2), "shift_sp") <> 0) Or (InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") = 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const ") = 0) Or (InStr(OriginalCode(OriginalCodeFlag - 2), "push_event ") = 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const ") = 0))) Then

                        'If InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Or InStr(OriginalCode(OriginalCodeFlag - 1), "func_call ") <> 0 Or _
                        '    (AiVarsCheckBox.Checked = False And InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0) Or _
                        '    (AiVarsCheckBox.Checked = True And _
                        '        ((InStr(OriginalCode(OriginalCodeFlag - 2), "push_event") = 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") = 0) Or _
                        '         (InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") = 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") = 0))) Then

                        ' Or InStr(OriginalCode(OriginalCodeFlag - 1), "func_call ") <> 0
                        If InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Or _
                            (AiVarsCheckBox.Checked = False And InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0) Or _
                            (AiVarsCheckBox.Checked = True And (InStr(OriginalCode(OriginalCodeFlag - 2), "push_event") = 0 And InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") = 0)) Then


                            If FromStack(-2) = False Then
                                iGF_ErrorFlag = True
                                GoTo EndOfL
                            End If
                            AiCode = StackCache(0).ToString & " + " & StackCache(1).ToString
                            AiCode = "(" & AiCode & ")"
                            ToStack(AiCode)
                        End If

                    ElseIf sTemp = "sub" Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & " - " & StackCache(1).ToString
                        AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                    ElseIf sTemp = "div" Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        Dim Symb() As Char = CType(" =", Char())
                        'If StackCache(0).ToString.IndexOfAny(Symb) <> -1 Then StackCache(0) = "( " & StackCache(0).ToString & " )"
                        'If StackCache(1).ToString.IndexOfAny(Symb) <> -1 Then StackCache(1) = "( " & StackCache(1).ToString & " )"
                        AiCode = StackCache(0).ToString & " / " & StackCache(1).ToString
                        AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                    ElseIf sTemp = "mul" Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        'If StackCache(0).ToString.StartsWith("(") = False Then StackCache(0) = "(" & StackCache(0).ToString & ")"
                        'If StackCache(1).ToString.StartsWith("(") = False Then StackCache(1) = "(" & StackCache(1).ToString & ")"
                        'Dim Symb() As Char = CType(" =", Char())
                        'If StackCache(0).ToString.IndexOfAny(Symb) <> -1 Then StackCache(0) = "( " & StackCache(0).ToString & " )"
                        'If StackCache(1).ToString.IndexOfAny(Symb) <> -1 Then StackCache(1) = "( " & StackCache(1).ToString & " )"
                        AiCode = StackCache(0).ToString & " * " & StackCache(1).ToString
                        AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                    ElseIf sTemp = "negate" Then
                        If FromStack(-1) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = "-" & StackCache(0).ToString
                        ToStack(AiCode)
                    ElseIf sTemp = "bit_or" Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & " | " & StackCache(1).ToString
                        AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                    ElseIf sTemp = "bit_and" Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & " & " & StackCache(1).ToString
                        AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                    ElseIf sTemp = "xor" Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & " ^ " & StackCache(1).ToString
                        AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)
                    ElseIf sTemp = "not" Then
                        If FromStack(-1) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = "~(" & StackCache(0).ToString & ")"
                        ToStack(AiCode)
                    ElseIf sTemp = "mod" Then
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & " % " & StackCache(1).ToString
                        AiCode = "(" & AiCode & ")"
                        ToStack(AiCode)


                        ' ==========================
                    ElseIf sTemp.StartsWith("push_string") = True Then
                        ' ---------- push_string ----------
                        'S964.   ".htm"
                        'push_string S964

                        sTemp = StringPrecompile(sTemp, False)
                        aTemp = sTemp.Split(Chr(32))
                        iTemp = Array.IndexOf(sSTable, aTemp(1) & ".")

                        If iTemp = -1 Then
                            ErrorStat("Required definition 'Sxxx.' for " & aTemp(1) & " for push_string", "push_string")
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        Else
                            ToStack(sSTableParam(iTemp))
                        End If

                    ElseIf sTemp.StartsWith("add_string") = True Then
                        ' ---------- add_string ----------
                        'add_string 1025

                        sTemp = StringPrecompile(sTemp, True)
                        aTemp = sTemp.Split(Chr(32))
                        If FromStack(-2) = False Then
                            iGF_ErrorFlag = True
                            GoTo EndOfL
                        End If
                        AiCode = StackCache(0).ToString & " + " & StackCache(1).ToString
                        ToStack(AiCode)

                    ElseIf sTemp.StartsWith("push_parameter") = True Then
                        ' ---------- push_parameter ----------
                        'push_parameter fnNoFeudInfo
                        sTemp = StringPrecompile(sTemp, False)
                        aTemp = sTemp.Split(Chr(32))
                        ToStack(aTemp(1))

                    ElseIf sTemp.StartsWith("push_property") = True Then
                        ' ---------- push_parameter ----------
                        'push_parameter fnNoFeudInfo
                        sTemp = StringPrecompile(sTemp, False)
                        aTemp = sTemp.Split(Chr(32))
                        ToStack(aTemp(1))

                        ' FIRST BLOCK
                    ElseIf sTemp.StartsWith("class_end") = True Then
                        ' ---------- class ----------
                        Saver("}", "_class_end", False) '& "Debug: class_end"
                        Saver("class_end", "_class_end", False) '& "Debug: class_end"
                        Saver("", "_class_end", False) '& "Debug: class_end"

                        Array.Clear(aLabelsDB, 0, aLabelsDB.Length)
                        Array.Resize(aLabelsDB, 0)

                        'If SplitClassCheckBox.Checked = True Then SaveCode("")

                        'SaveClass(outFile)

                    ElseIf sTemp.StartsWith("parameter_define_begin") = True Then
                        ' ---------- parameter_define_begin ----------

                        'sauron fix - Saver("parameter_define_begin", "parameter_define_begin", False)
                        Saver("parameter:", "parameter_define_begin", False)
                        OriginalCodeFlag += 1
                        sTemp = Loader()
                        While sTemp <> "parameter_define_end"
                            'string fnHi "chi.htm"
                            If sTemp.Trim <> "" Then
                                sTemp = StringPrecompile(sTemp, True).Replace("{", "").Replace("}", "")
                                aTemp = sTemp.Split(Chr(32))
                                '	int	MoveAroundSocial2 = 0;
                                If aTemp(0) = "waypointstype" Or aTemp(0) = "waypointdelaystype" Then
                                    'waypointstype WayPoints
                                    'waypointdelaystype WayPointDelays
                                    sTemp = aTemp(0) & " = " & aTemp(1) & ";"
                                    Saver(sTemp, "parameter_define_begin", False)
                                Else
                                    'Saver(aTemp(0) & " " & aTemp(1) & " = " & aTemp(2) & ";", "parameter_define_end", False)
                                    'sTemp = StringPrecompile(sTemp, True).Replace("{", "").Replace("}", "")
                                    sTemp = aTemp(0) & vbTab & aTemp(1) & " = " & aTemp(2) & ";"
                                    Saver(sTemp, "parameter_define_begin", False)
                                End If
                            End If
                            OriginalCodeFlag += 1
                            sTemp = Loader()
                        End While
                        'sauron fix - Saver("parameter_define_end", "parameter_define_end", False)

                    ElseIf sTemp.StartsWith("property_define_begin") = True Then
                        ' ---------- property_define_begin ----------

                        'sauron fix - Saver("property_define_begin", "property_define_begin", False)
                        Saver("property:", "property_define_begin", False)
                        OriginalCodeFlag += 1
                        sTemp = Loader()
                        Dim PropertyType As Short, sLine As String = ""
                        'aTemp(0) = ""
                        While sTemp <> "property_define_end"
                            '	telposlist_begin RaidBossList20_29
                            If sTemp.Trim <> "" Then
                                sTemp = StringPrecompile(sTemp, True) '.Replace("{", "").Replace("}", "")
                                If sTemp.StartsWith("buyselllist_begin") = True Then
                                    PropertyType = 1
                                    sLine = "BuySellList " & sTemp.Replace("buyselllist_begin ", "") & " = {"
                                End If
                                If sTemp.StartsWith("telposlist_begin") = True Then
                                    PropertyType = 2
                                    sLine = "TelPosList " & sTemp.Replace("telposlist_begin ", "") & " = {"
                                End If
                                If sTemp.StartsWith("buyselllist_end") = True Then
                                    sLine = sLine & "};"
                                    Saver(sLine, "buyselllist_end", False)
                                    sLine = ""
                                End If
                                If sTemp.StartsWith("telposlist_end") = True Then
                                    sLine = sLine & "};"
                                    Saver(sLine, "telposlist_end", False)
                                    sLine = ""
                                End If
                                If sTemp.StartsWith("buyselllist_") = False And sTemp.StartsWith("telposlist_") = False Then
                                    If PropertyType = 1 Then
                                        aTemp = sTemp.Replace("{", "").Replace("}", "").Replace(" ", "").Split(CChar(";"))
                                        If InStr(sLine, ";") <> 0 Then sLine = sLine & ";"
                                        sLine = sLine & "{" & aTemp(0) & ";" & aTemp(1) & "}"
                                    End If
                                    If PropertyType = 2 Then
                                        If InStr(sLine, ";") <> 0 Then sLine = sLine & ";"
                                        sLine = sLine & sTemp
                                    End If
                                End If
                                'sTemp = "(" & sTemp & ")"
                                'aTemp = sTemp.Split(Chr(9))
                                'Saver(sTemp, "property_define_end", False)
                            End If
                            OriginalCodeFlag += 1
                            sTemp = Loader()
                        End While
                        'sauron fix - Saver("property_define_end", "property_define_end", False)
                        'sauron fix - Saver("", "property_define_end", False)

                    ElseIf sTemp.StartsWith("handler ") = True Then
                        ' ---------- handler ----------
                        'handler 4 13    //  TALK_SELECTED

                        If IsProperty = True Then
                            IsProperty = False
                            Saver("", "handler_start", False)
                            Saver("handler:", "handler_start", False)
                        End If
                        sTemp = StringPrecompile(sTemp, True)
                        aTemp = sTemp.Split(Chr(32))
                        Saver("", "EventHandler", False)
                        'sauron fix -- AiCode = aTemp(0) & " " & aTemp(3)

                        ' AIVARConfig Method
                        If AiVarsCheckBox.Checked = False Then
                            sLastHandler = aTemp(3)
                        Else
                            ' Config method
                            sLastHandler = GetAiVar(aTemp(1), "handler")
                        End If
                        If sLastHandler = Nothing Then iGF_ErrorFlag = True : GoTo EndOfL
                        AiCode = "EventHandler " & sLastHandler

                        'variable_begin
                        AiCode = AiCode & "("
                        iTemp = 0

                        OriginalCodeFlag += 1
                        sTemp = Loader()
                        If sTemp.StartsWith("variable_begin") = True Then

                            Array.Clear(sVarTable, 0, sVarTable.Length)
                            Array.Resize(sVarTable, 0)

                            ' ---------- variable_begin ----------
                            OriginalCodeFlag += 1
                            sTemp = Loader()

                            While sTemp <> "variable_end"
                                '"_from_choice"
                                If sTemp.Trim <> "" Then
                                    'sTemp = StringPrecompile(sTemp)
                                    sTemp = sTemp.Replace("""", "")

                                    If sTemp.StartsWith("_") = False And sTemp <> "myself" Then
                                        If iTemp > 0 Then
                                            AiCode = AiCode & ", "
                                        End If
                                        AiCode = AiCode & sTemp
                                        Array.Resize(sVarTable, sVarTable.Length + 1)
                                        sVarTable(sVarTable.Length - 1) = sTemp
                                        iTemp += 1
                                    Else
                                        Array.Resize(sVarTable, sVarTable.Length + 1)
                                        sVarTable(sVarTable.Length - 1) = sTemp
                                    End If
                                End If
                                OriginalCodeFlag += 1
                                sTemp = Loader()
                            End While
                        Else
                            ' DEBUG
                            'ErrorStat("Required variable_begin block after Handler definition", "handler")
                            'iGF_ErrorFlag = True
                            'GoTo EndOfL
                        End If
                        AiCode = AiCode & ")"
                        Saver(AiCode, "variable_end", True)
                        Saver("{", "EventHandler", True)

                        Array.Clear(Stack, 0, Stack.Length)
                        Array.Clear(StackCache, 0, StackCache.Length)
                        StackFlag = -1

                    ElseIf sTemp.StartsWith("handler_end") = True Then

                        ' DEBUG: Excess (избыточный) code output
                        If StackFlag > 0 Then
                            For iTemp = 0 To StackFlag - 1
                                FromStack(-1)
                                Saver("// DEBUG: Excess (" & iTemp & "): " & StackCache(0).ToString, "LeftStack", True)
                            Next
                        End If
                        ' DEBUG: Excess END

                        ' ---------- handler_end ----------
                        'Saver("}", "handler_end_last_autotag", True)
                        Saver("}", "handler_end_last_autotag", True)
                        ' - sauron fix Saver("handler_end", "handler_end_last_autotag", True)
                        Saver("", "handler_end_last_autotag", True)
                        'SaveClass(outFile)

                        Array.Clear(sSTable, 0, sSTable.Length)
                        Array.Clear(sSTableParam, 0, sSTableParam.Length)
                        Array.Resize(sSTable, 1)
                        Array.Resize(sSTableParam, 1)

                        ' -------- END of checking ----------- 
                    Else
                        'outFile.WriteLine(">> " & sTemp)
                        'Saver(outFile, "!" & sTemp)
                    End If

EndOfL:
                    If iGF_ErrorFlag = True Then Exit Sub

                    Me.Update()
            Next

            If DataFromDebugCheckBox.Checked = True Then Exit While
            SaveCode()
            Me.Refresh()
            Me.Update()
        End While
        GlobalProgressBar.Value = 0
        Exit Sub

errorDef:
        iGF_ErrorFlag = True
        ErrorStat("Unkwnown error", "Unkwnown error")

    End Sub

    Private Function LoadCode() As Boolean

        Dim sTemp As String
        'Dim inFile As System.IO.StreamReader = Nothing

        ' Clearing array for new code before decompiling
        Array.Clear(OriginalCode, 0, OriginalCode.Length)
        Array.Resize(OriginalCode, 0)
        OriginalCodeFlag = 0
        Array.Clear(DecompiledCode, 0, DecompiledCode.Length)
        Array.Resize(DecompiledCode, 0)
        DecompiledCodeFlag = 0

        ' Load Data from Debug window
        If DataFromDebugCheckBox.Checked = True Then

            Dim iTemp As Integer
            For iTemp = 0 To SrcAITextBox.Lines.Length - 1
                sTemp = SrcAITextBox.Lines(iTemp).ToString
                sTemp = StringPrecompile(sTemp, False)
                If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then
                    Array.Resize(OriginalCode, OriginalCodeFlag + 1)
                    OriginalCode(OriginalCodeFlag) = sTemp
                    OriginalCodeFlag += 1
                End If
            Next

            aGF_FileName(0) = "%SELF_DEVELOPING%"
            iGF_FileIndex = 0
            GlobalProgressBar.Maximum = OriginalCode.Length
            Return True
        End If

        If iGF_FilePosition = 0 Then
            iGF_FileIndex += 1
            If iGF_FileIndex = aGF_FileName.Length Then Return False
            inAIFile = New System.IO.StreamReader(aGF_FileName(iGF_FileIndex), System.Text.Encoding.Default, True, 1)
            SavedFileLabel.Text = "Load data from: " & System.IO.Path.GetFileName(aGF_FileName(iGF_FileIndex))
        End If

        If LoadFilesCheckBox.Checked = True Then
            GlobalProgressBar.Maximum = aGF_FileName.Length
            LineStat = 0
        Else
            GlobalProgressBar.Maximum = CInt(inAIFile.BaseStream.Length)
        End If

        While inAIFile.EndOfStream <> True
            sTemp = inAIFile.ReadLine
            sTemp = StringPrecompile(sTemp, False)
            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then
                Array.Resize(OriginalCode, OriginalCodeFlag + 1)
                OriginalCode(OriginalCodeFlag) = sTemp
                OriginalCodeFlag += 1
            End If
            If sTemp = "class_end" Then
                Exit While
            End If
        End While


        iGF_FilePosition = inAIFile.BaseStream.Position
        If inAIFile.BaseStream.Position = inAIFile.BaseStream.Length Then
            iGF_FilePosition = 0
            inAIFile.Close()
            If OriginalCode.Length = 0 Then Return False
            'If LoadFilesCheckBox.Checked = False Then Return False
            ' If reading from one file (ai.obj) and eof
        End If

        OriginalCodeFlag = 0
        AIDstCodeTextBox.Text = ""
        Return True

    End Function

    Private Function SaveCode() As Boolean

        'ByVal outAiFile As String

        Dim iTemp As Integer
        Dim iTab As Integer = 0

        ' Write Header
        Dim outFile As System.IO.StreamWriter = Nothing
        Dim aTemp() As String


        If SplitClassCheckBox.Checked = False And iGF_ErrorFlag = False Then
            'outFile = New System.IO.StreamWriter(outAiTextBox.Text, AppendFileCheckBox.Checked, System.Text.Encoding.Default, 1)
            ' Write code to file
            'outFile.Write(AIDstCodeTextBox.Text)
            SavedFileLabel.Text = outAiTextBox.Text
        End If

        Dim OpenFlag As Boolean = True


        'Dim sForTemp As String
        Dim aForTemp() As String

        For iTemp = 0 To DecompiledCode.Length - 1
            If DecompiledCode(iTemp).StartsWith("class ") Then
                aTemp = DecompiledCode(iTemp).Split(Chr(32))
                'If SplitClassCheckBox.Checked = True Or iGF_ErrorFlag = True Then
                SavedFileLabel.Text = aTemp(2) & ".txt"
                If iGF_ErrorFlag = True Then
                    outFile = New System.IO.StreamWriter("~ai_out_abort.txt", False, System.Text.Encoding.Unicode, 1)
                ElseIf SplitClassCheckBox.Checked = True Then
                    outFile = New System.IO.StreamWriter(DecompiledPathTextBox.Text & aTemp(2) & ".txt", False, System.Text.Encoding.Unicode, 1)
                ElseIf SplitClassCheckBox.Checked = False And iGF_ErrorFlag = False Then
                    outFile = New System.IO.StreamWriter(outAiTextBox.Text, AppendFileCheckBox.Checked, System.Text.Encoding.Unicode, 1)
                End If
                ' Write code to file
                If outFile.BaseStream.Length = 0 Then 'AppendFileCheckBox.Checked = True And 
                    outFile.WriteLine("//---------------------------------------------------------")
                    outFile.WriteLine("// L2ScriptMaker: Lineage II Cronicles 4 AI.obj Decompiler")
                    outFile.WriteLine("//---------------------------------------------------------")
                    outFile.WriteLine("// Decompiling: " & Now)
                    outFile.WriteLine("// Decompiler build is: " & My.Application.Info.Version.ToString)
                    outFile.WriteLine("//---------------------------------------------------------")
                    outFile.WriteLine()
                End If
                'outFile.Write(AIDstCodeTextBox.Text)
                OpenFlag = True
                'End If
                iTab = 0

                If CheckBoxLa2GuardFormat.Checked = True Then
                    If DecompiledCode(iTemp).StartsWith("class 1") = True Then
                        outFile.WriteLine("set_compiler_opt base_event_type(@NTYPE_NPC_EVENT)")
                        DecompiledCode(iTemp) = DecompiledCode(iTemp).Replace("class 1", "class")
                    Else
                        outFile.WriteLine("set_compiler_opt base_event_type(@NTYPE_MAKER_EVENT)")
                        DecompiledCode(iTemp) = DecompiledCode(iTemp).Replace("class 2", "class")
                    End If
                End If

            End If

            If DecompiledCode(iTemp).StartsWith("handler:") Then iTab = 0
            If DecompiledCode(iTemp).StartsWith("EventHandler ") Then iTab = 1
            If DecompiledCode(iTemp).StartsWith("parameter:") Then iTab = 0
            'If DecompiledCode(iTemp).StartsWith("parameter_define_end") Then iTab = 0 : DecompiledCode(iTemp) = ""
            If DecompiledCode(iTemp).StartsWith("property:") Then iTab = 0
            'If DecompiledCode(iTemp).StartsWith("property_define_end") Then iTab = 0 : DecompiledCode(iTemp) = ""
            If DecompiledCode(iTemp).StartsWith("telposlist_end") Then iTab = 1
            If DecompiledCode(iTemp).StartsWith("buyselllist_end") Then iTab = 1
            'If DecompiledCode(iTemp).StartsWith("handler_end") Then iTab = 1 : DecompiledCode(iTemp) = ""
            If DecompiledCode(iTemp).StartsWith("class_end") = True Then : DecompiledCode(iTemp) = ""
                iTab = 0
            End If
            If DecompiledCode(iTemp).StartsWith("}") = True Then iTab -= 1

            If CheckBoxLa2GuardFormat.Checked = True Then
                If InStr(DecompiledCode(iTemp), ("switch")) > 0 Then
                    DecompiledCode(iTemp) = DecompiledCode(iTemp).Replace("switch", "select")
                End If
                If InStr(DecompiledCode(iTemp), ("elseif")) > 0 Then
                    DecompiledCode(iTemp) = DecompiledCode(iTemp).Replace("elseif", "else if")
                End If
                If InStr(DecompiledCode(iTemp), ("gg::")) > 0 Then
                    DecompiledCode(iTemp) = DecompiledCode(iTemp).Replace("gg::", "")
                End If
                If InStr(DecompiledCode(iTemp), ("::")) > 0 Then
                    DecompiledCode(iTemp) = DecompiledCode(iTemp).Replace("::", ".")
                End If

                If InStr(DecompiledCode(iTemp), ("for (")) > 0 Then
                    'for ( i2 = 1; i2 <= 25 ; ++i2  )
                    aForTemp = DecompiledCode(iTemp).Split(CChar(";"))
                    'aForTemp(2)=" i2++  )"
                    aForTemp(2) = aForTemp(2).Replace("++ )", " )")
                    aForTemp(2) = aForTemp(2).Replace(" i", " ++i")
                    'aForTemp(2)=" ++i2  )"
                    DecompiledCode(iTemp) = Join(aForTemp, ";")
                End If

            End If

            If OpenFlag = True Then outFile.WriteLine(Tabs(iTab) & DecompiledCode(iTemp))

            If DecompiledCode(iTemp).StartsWith("class_end") = True And SplitClassCheckBox.Checked = True Then
                outFile.Close()
                OpenFlag = False
            End If

            If DecompiledCode(iTemp).StartsWith("property:") Then iTab = 1
            If DecompiledCode(iTemp).StartsWith("parameter:") Then iTab = 1
            If DecompiledCode(iTemp).StartsWith("telposlist_begin") Then iTab = 2
            If DecompiledCode(iTemp).StartsWith("buyselllist_begin") Then iTab = 2
            If DecompiledCode(iTemp).StartsWith("case ") Then iTab += 1
            'If DecompiledCode(iTemp).StartsWith("break;") Then iTab -= 1
            If DecompiledCode(iTemp).StartsWith("{") = True Then iTab += 1
            'If DecompiledCode(iTemp).StartsWith("handler:") Then iTab = 1
        Next

        outFile.Close()
        '-------

        If iGF_ErrorFlag = True Then
            outFile = New System.IO.StreamWriter("~ai_out_abort_class.txt", False, System.Text.Encoding.Unicode, 1)
            For iTemp = 0 To OriginalCode.Length - 1
                outFile.WriteLine(OriginalCode(iTemp))
            Next
        End If
        outFile.Close()

        Return True

    End Function

#End Region


    Private Function ShowCode() As Boolean

        If ShowCodeCheckBox.Checked = False And DataFromDebugCheckBox.Checked = False Then Return False

        Dim iTemp As Integer
        Dim iTab As Integer = 0

        Dim iMaxLines As Integer

        If DecompiledCode.Length - 1 > 100 Then
            iMaxLines = 100
        Else
            iMaxLines = DecompiledCode.Length - 1
        End If

        AIDstCodeTextBox.Text = ""
        AIDstCodeTextBox.SuspendLayout()

        AIDstCodeTextBox.AppendText("//---------------------------------------------------------" & vbNewLine)
        AIDstCodeTextBox.AppendText("// L2ScriptMaker: Lineage II Cronicles 4 AI.obj Decompiler" & vbNewLine)
        AIDstCodeTextBox.AppendText("//---------------------------------------------------------" & vbNewLine)
        AIDstCodeTextBox.AppendText("// Decompiling: " & Now & vbNewLine)
        AIDstCodeTextBox.AppendText("// Decompiler build is: " & My.Application.Info.Version.ToString & vbNewLine)
        AIDstCodeTextBox.AppendText("//---------------------------------------------------------" & vbNewLine)
        AIDstCodeTextBox.AppendText(vbNewLine)

        For iTemp = 0 To DecompiledCode.Length - 1
            If DecompiledCode(iTemp).StartsWith("class ") Then iTab = 0
            If DecompiledCode(iTemp).StartsWith("handler:") Then iTab = 0
            If DecompiledCode(iTemp).StartsWith("EventHandler ") Then iTab = 1
            If DecompiledCode(iTemp).StartsWith("parameter:") Then iTab = 0
            'If DecompiledCode(iTemp).StartsWith("parameter_define_end") Then iTab = 0
            If DecompiledCode(iTemp).StartsWith("property:") Then iTab = 0
            'If DecompiledCode(iTemp).StartsWith("property_define_end") Then iTab = 0
            'If DecompiledCode(iTemp).StartsWith("telposlist_end") Then iTab = 1
            'If DecompiledCode(iTemp).StartsWith("buyselllist_end") Then iTab = 1
            'If DecompiledCode(iTemp).StartsWith("handler_end") Then iTab = 1
            If DecompiledCode(iTemp).StartsWith("class_end") = True Then
                iTab = 0
            End If
            If DecompiledCode(iTemp).StartsWith("}") = True Then iTab -= 1

            AIDstCodeTextBox.AppendText(Tabs(iTab) & DecompiledCode(iTemp) & vbNewLine)

            'If DecompiledCode(iTemp).StartsWith("property_define_begin") Then iTab = 1
            'If DecompiledCode(iTemp).StartsWith("parameter_define_begin") Then iTab = 1
            'If DecompiledCode(iTemp).StartsWith("telposlist_begin") Then iTab = 2
            'If DecompiledCode(iTemp).StartsWith("buyselllist_begin") Then iTab = 2
            If DecompiledCode(iTemp).StartsWith("case ") Then iTab += 1
            If DecompiledCode(iTemp).StartsWith("break;") Then iTab -= 1
            If DecompiledCode(iTemp).StartsWith("{") = True Then iTab += 1

        Next

        AIDstCodeTextBox.ResumeLayout()
        Return True

    End Function

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        ' --- PreWorking Checking Stage ---
        'If FuncTable.Length <= 1 Then
        '    'If FuncCallLoader() = False Then
        '    '    Exit Sub
        '    'End If
        'End If

        If FuncCallLoader() = False Then
            MessageBox.Show("Loading ai config's complete failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If outAiTextBox.Text = "" Then
            MessageBox.Show("Must be define target file name for saving results. Define and try again.", "No target file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If SplitClassCheckBox.Checked = True And (DecompiledPathTextBox.Text = "" Or System.IO.Directory.Exists(DecompiledPathTextBox.Text) = False) Then
            MessageBox.Show("Must be define target path name for saving results. Define and try again.", "No target path", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        iGF_FileIndex = -1
        iGF_FilePosition = 0

        If sSTable.Length > 1 Then
            Array.Clear(sSTable, 0, sSTable.Length)
            Array.Clear(sSTableParam, 0, sSTableParam.Length)
            Array.Resize(sSTable, 1)
            Array.Resize(sSTableParam, 1)
        End If

        Array.Clear(aGF_FileName, 0, aGF_FileName.Length)
        Array.Resize(aGF_FileName, 1)

        If DataFromDebugCheckBox.Checked = False Then
            If LoadFilesCheckBox.Checked = False Then
                If inAiTextBox.Text = "" Or System.IO.File.Exists(inAiTextBox.Text) = False Then
                    MessageBox.Show("Must be define valid source file name for decompilation. Define and try again.", "No source file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                aGF_FileName(0) = inAiTextBox.Text
            Else
                If System.IO.Directory.Exists(SourcePathTextBox.Text) = False Then
                    MessageBox.Show("Source folder no exist. Change target path for searching and try again", "Folder not exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                aGF_FileName = System.IO.Directory.GetFiles(SourcePathTextBox.Text, SrcFileExtTextBox.Text, IO.SearchOption.AllDirectories)
                If aGF_FileName.Length = 0 Then
                    MessageBox.Show("Source folder no have data files. Put files or change extention for searching and try again", "No sources", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        Else
            If SrcAITextBox.Lines.Length = 0 Then
                MessageBox.Show("No data for decompilation in Debug Window.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If SplitClassCheckBox.Checked = False And AppendFileCheckBox.Checked = False Then
            If System.IO.File.Exists(outAiTextBox.Text) = True Then
                If MessageBox.Show("You sure to overwrite target file?", "Overwrite file?", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.No Then Exit Sub
                System.IO.File.Delete(outAiTextBox.Text)
            End If
            AppendFileCheckBox.Checked = True
        End If
        C4Decompilator()

        If SplitClassCheckBox.Checked = False Or DataFromDebugCheckBox.Checked = True Then ShowCode()

        ProgressBar.Value = 0
        MessageBox.Show("Decompilation complete" & vbNewLine & "I'm finding work in NCSoft. =)", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        If ShowFileCheckBox.Checked = True And SplitClassCheckBox.Checked = False And DataFromDebugCheckBox.Checked = False And iGF_ErrorFlag = False Then Shell("notepad " & outAiTextBox.Text, AppWinStyle.NormalFocus, False)
        iGF_ErrorFlag = False

        'AIDstCodeTextBox.TabIndex = 0

        If ShowCodeCheckBox.Checked = True Then TabControl.SelectedIndex = 2

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

    Private Sub inAiTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles inAiTextBox.MouseDoubleClick
        OpenFileDialog.InitialDirectory = Application.ExecutablePath
        OpenFileDialog.FileName = inAiTextBox.Text
        OpenFileDialog.Filter = "Lineage II AI.obj script (ai.obj)|*.obj|Lineage II AI.obj scripts (*.txt)|*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then inAiTextBox.Text = OpenFileDialog.FileName
        outAiTextBox.Text = inAiTextBox.Text & "_decompiled.txt"
    End Sub

    Private Sub outAiTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles outAiTextBox.MouseDoubleClick
        SaveFileDialog.FileName = outAiTextBox.Text
        SaveFileDialog.Filter = "Lineage II AI.obj Decompiled code (ai_out.txt)|*.txt|All files|*.*"
        SaveFileDialog.OverwritePrompt = False
        If SaveFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then outAiTextBox.Text = SaveFileDialog.FileName
    End Sub

    Private Sub LoadFilesCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadFilesCheckBox.CheckedChanged
        If LoadFilesCheckBox.Checked = False Then
            SourcePathTextBox.Enabled = False
        Else
            SourcePathTextBox.Enabled = True
        End If
    End Sub

    Private Sub SourcePathTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SourcePathTextBox.MouseDoubleClick
        If System.IO.Directory.Exists(SourcePathTextBox.Text) = False Then
            FolderBrowserDialog.SelectedPath = Application.StartupPath
        Else
            FolderBrowserDialog.SelectedPath = SourcePathTextBox.Text
        End If
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        SourcePathTextBox.Text = FolderBrowserDialog.SelectedPath
    End Sub

    Private Sub SourcePathTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SourcePathTextBox.Validated
        If SourcePathTextBox.Text.EndsWith("\") = False Then SourcePathTextBox.Text &= "\"
    End Sub

    Private Sub SplitClassCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitClassCheckBox.CheckedChanged
        If SplitClassCheckBox.Checked = False Then
            DecompiledPathTextBox.Enabled = False
        Else
            DecompiledPathTextBox.Enabled = True
            If System.IO.Directory.Exists(DecompiledPathTextBox.Text) = False Then
                System.IO.Directory.CreateDirectory(DecompiledPathTextBox.Text)
            End If

        End If
    End Sub

    Private Sub DecompiledPathTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DecompiledPathTextBox.MouseDoubleClick
        If System.IO.Directory.Exists(DecompiledPathTextBox.Text) = False Then
            FolderBrowserDialog.SelectedPath = Application.StartupPath
        Else
            FolderBrowserDialog.SelectedPath = DecompiledPathTextBox.Text
        End If
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        DecompiledPathTextBox.Text = FolderBrowserDialog.SelectedPath
    End Sub

    Private Sub DecompiledPathTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DecompiledPathTextBox.Validated
        If DecompiledPathTextBox.Text.EndsWith("\") = False Then DecompiledPathTextBox.Text &= "\"
    End Sub

    Private Sub SaveCodeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveCodeButton.Click

        If AIDstCodeTextBox.Lines.Length = 0 Then
            MessageBox.Show("No more to writing.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim iTemp As Integer
        Dim outFile As New System.IO.StreamWriter(outAiTextBox.Text, False, System.Text.Encoding.Unicode, 1)

        For iTemp = 0 To AIDstCodeTextBox.Lines.Length - 2
            outFile.WriteLine(AIDstCodeTextBox.Lines(iTemp).ToString)
        Next
        outFile.Close()

        MessageBox.Show("Decompiled code saved to '" & outAiTextBox.Text & "'", "Saved", MessageBoxButtons.OK)

    End Sub

    Private Sub AboutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        MessageBox.Show("L2ScriptMaker: Lineage II Cronicles 4 AI.obj Decompiler" & vbNewLine & My.Application.Info.Version.ToString, "About", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Private Sub AIDecompiler_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    '    MessageBox.Show("Loading ")
    '    If FuncCallLoader() = False Then
    '        MessageBox.Show("Loading ai config's complete failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End If


    'End Sub

    'Private Sub ReloadConfigsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadConfigsButton.Click

    '    If FuncCallLoader() = False Then
    '        Exit Sub
    '    End If
    '    MessageBox.Show("All ai config's loading complete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    'End Sub

End Class

Public Class AiFixer

    Dim FuncArr1(1000) As String ' id
    Dim FuncArr2(1000) As String ' handler
    Dim FuncArr3(1000) As String ' name

    Private Sub ButtonFetch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        If ComboBoxFixType.Text = "" Then
            MessageBox.Show("Select target to fix", "Select target", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim AiFile As String
        Dim AiFuncFile As String

        OpenFileDialog.Filter = "Lineage II AI file|*.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        AiFile = OpenFileDialog.FileName

        OpenFileDialog.Filter = "Lineage II AI " + ComboBoxFixType.Text + " fix file|*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        AiFuncFile = OpenFileDialog.FileName

        Dim TempStr As String

        ' Loading all func in table
        Dim TempArr(2) As String
        Dim ArrMarker As Integer = -1

        Dim inAiFix As New System.IO.StreamReader(AiFuncFile, System.Text.Encoding.Default, True, 1)

        If inAiFix.ReadLine <> "[" + ComboBoxFixType.Text + "]" Then
            MessageBox.Show("Wrong file type. Waiting list for '" + ComboBoxFixType.Text + "'. Select valid file", "Wrong fix file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            inAiFix.Close()
            Exit Sub
        End If

        ToolStripProgressBar.Maximum = CInt(inAiFix.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        While inAiFix.EndOfStream <> True
            TempStr = inAiFix.ReadLine.Trim

            If TempStr <> "" And TempStr.StartsWith("//") = False Then
                If ComboBoxFixType.Text = "func_call" Then TempStr = TempStr.Replace(",", "|")
                TempArr = TempStr.Split(Chr(124)) '124 - |

                ArrMarker += 1
                FuncArr1(ArrMarker) = TempArr(0)    ' id
                FuncArr2(ArrMarker) = TempArr(1)    ' marker ([QUEST_ACCEPTED,default], [0,1,2], [QUEST_ACCEPTED,default])
                FuncArr3(ArrMarker) = TempArr(2)    ' name (fetch_i (creature), func (ShowPage), event (704))

                ToolStripProgressBar.Value = CInt(inAiFix.BaseStream.Length / inAiFix.BaseStream.Position * 100)
            End If
            Me.Update()

        End While
        inAiFix.Close()
        ToolStripProgressBar.Value = 0

        ' Work with ai.obj
        System.IO.File.Copy(AiFile, System.IO.Path.GetDirectoryName(AiFile) + "\" + System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", True)
        Dim inAi As New System.IO.StreamReader(System.IO.Path.GetDirectoryName(AiFile) + "\" + System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", System.Text.Encoding.Default, True, 1)
        Dim outAi As New System.IO.StreamWriter(AiFile, False, System.Text.Encoding.Unicode, 1)
        Dim outAiLog As New System.IO.StreamWriter(System.IO.Path.GetDirectoryName(AiFile) + "\" + System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".log", LogOverwriteCheckBox.Checked, System.Text.Encoding.Unicode, 1)

        outAiLog.WriteLine("L2ScriptMaker AI.obj check and fix." _
            + vbNewLine + Now.ToString + vbNewLine + "Work with " + ComboBoxFixType.Text + vbNewLine)

        Dim sTemp As String
        Dim iTemp As Integer

        ' check controls
        Dim ClassNameMarker As String = ""
        Dim HandlerNameMarker As String = ""
        Dim LastPushConstMarker As String = ""

        Dim LineNum As Long = 1

        ToolStripProgressBar.Maximum = CInt(inAi.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        While inAi.EndOfStream <> True

            TempStr = inAi.ReadLine
            'TempStr = TempStr.Trim
            LineNum += 1

            ToolStripProgressBar.Value = CInt(inAi.BaseStream.Position)
            StatusStrip.Update()
            Me.Update()

            If TempStr.StartsWith("class ") = True Then
                ClassNameMarker = TempStr
            End If

            If TempStr.StartsWith("handler ") = True Then
                HandlerNameMarker = TempStr.Remove(0, InStr(TempStr, "//") + 2).Trim
            End If

            If InStr(6, TempStr, "//") <> 0 And InStr(TempStr, ComboBoxFixType.Text) = 0 Then
                'If InStr(6, TempStr, "push_event") <> 0 And (ComboBoxFixType.Text = "func_call" Or ComboBoxFixType.Text = "fetch_i") Then
                ' push_event      //  myself
                ' push_const 704
                ' add
                ' fetch_i //  c_ai1
                ' push_const 384
                ' add
                ' fetch_i //  name
                ' push_const 104

                ' Write previous line
                'outAi.WriteLine(TempStr)
                'TempStr = inAi.ReadLine
                'LastPushConstMarker = TempStr.Replace(Chr(9), Chr(32)).Replace("push_const", "").Trim

                LastPushConstMarker = Mid(TempStr, (InStr(TempStr, "//") + 2), TempStr.Length - (InStr(TempStr, "//") + 1)).Trim

            End If

            If InStr(TempStr, ComboBoxFixType.Text) <> 0 And TempStr.Trim.StartsWith("//") = False _
                And InStr(5, TempStr, "//") <> 0 Then

                Select Case ComboBoxFixType.Text

                    ' ------------ FETCH_I -------------------
                    Case "fetch_i"

                        ' fetch_i // param2
                        ' push_const 2272

                        ' Write previous line
                        outAi.WriteLine(TempStr)

                        ' Define name for fetch_i
                        sTemp = Mid(TempStr, (InStr(TempStr, "//") + 2), TempStr.Length - (InStr(TempStr, "//") + 1)).Trim

                        iTemp = Array.IndexOf(FuncArr3, sTemp)
                        If iTemp = -1 Then
                            'MessageBox.Show(ComboBoxFixType.Text + " not found in table!" + vbNewLine + TempStr, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine(">>>>>> Not found :" + vbNewLine + TempStr + vbNewLine)
                            Exit Select
                        End If

                        TempStr = inAi.ReadLine
                        LineNum += 1

                        If InStr(TempStr, "push_const") = 0 Then
                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine(ComboBoxFixType.Text + " definition failed. Waiting push_const next after " + ComboBoxFixType.Text + vbNewLine + TempStr)
                            outAi.WriteLine(TempStr)
                            inAi.Close()
                            outAi.Close()
                            outAiLog.Close()
                            MessageBox.Show("Line: " & LineNum & vbTab & ComboBoxFixType.Text + " definition failed. Waiting push_const next after " + ComboBoxFixType.Text + vbNewLine + TempStr, "Definition failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Select
                        End If

                        iTemp = FindIndex(sTemp, LastPushConstMarker)
                        If iTemp = -1 Then
                            iTemp = FindIndex(sTemp, HandlerNameMarker)

                            If iTemp = -1 Then

                                iTemp = FindIndex(sTemp, "default")
                                If iTemp = -1 Then
                                    outAi.WriteLine(TempStr)
                                    outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                                    outAiLog.WriteLine("Warning! Required 'default' for '" + sTemp + "'. Ignored.")
                                    outAiLog.WriteLine("Debug info:" + vbNewLine + "Fixed class: " + ClassNameMarker _
                                                + vbNewLine + "Fixed handler: " + HandlerNameMarker _
                                                 + vbNewLine + "Last push_const: " + LastPushConstMarker)
                                    Exit Select
                                End If

                            End If

                        End If


                        If TempStr.Trim <> "push_const " + FuncArr1(iTemp) Then
                            outAiLog.WriteLine("Fix to: '" + FuncArr3(iTemp) + "'" _
                            + vbNewLine + "Fixed class: " + ClassNameMarker _
                            + vbNewLine + "Fixed handler: " + HandlerNameMarker _
                            + vbNewLine + "Last push_const: " + LastPushConstMarker)
                            outAiLog.WriteLine("Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine("Fix as:" + TempStr + " --> " + "push_const " + FuncArr1(iTemp) + vbNewLine)

                            TempStr = Chr(9) + "push_const " + FuncArr1(iTemp)
                        End If

                        LastPushConstMarker = sTemp

                        ' ------------ PUSH_EVENT -------------------
                    Case "push_event"

                        ' push_event // myself
                        ' push_const 704

                        ' Write previous line
                        outAi.WriteLine(TempStr)

                        ' Define name for push_event
                        sTemp = Mid(TempStr, (InStr(TempStr, "//") + 2), TempStr.Length - (InStr(TempStr, "//") + 1)).Trim

                        iTemp = Array.IndexOf(FuncArr3, sTemp)
                        If iTemp = -1 Then
                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine(">>>>>> Not found :" + vbNewLine + TempStr + vbNewLine)
                            Exit Select
                        End If

                        TempStr = inAi.ReadLine
                        LineNum += 1

                        If InStr(TempStr, "push_const") = 0 Then
                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine(ComboBoxFixType.Text + " definition failed. Waiting push_const next after " + ComboBoxFixType.Text + vbNewLine + TempStr)
                            outAi.WriteLine(TempStr)
                            inAi.Close()
                            outAi.Close()
                            outAiLog.Close()
                            MessageBox.Show("Line: " & LineNum & vbTab & ComboBoxFixType.Text + " definition failed. Waiting push_const next after " + ComboBoxFixType.Text + vbNewLine + TempStr, "Definition failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Select
                        End If

                        iTemp = FindIndex(sTemp, LastPushConstMarker)
                        If iTemp = -1 Then
                            iTemp = FindIndex(sTemp, HandlerNameMarker)

                            If iTemp = -1 Then

                                iTemp = FindIndex(sTemp, "default")
                                If iTemp = -1 Then
                                    outAi.WriteLine(TempStr)
                                    outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                                    outAiLog.WriteLine("Warning! Required 'default' for '" + sTemp + "'. Ignored.")
                                    outAiLog.WriteLine("Debug info:" + vbNewLine + "Fixed class: " + ClassNameMarker _
                                                + vbNewLine + "Fixed handler: " + HandlerNameMarker _
                                                 + vbNewLine + "Last push_const: " + LastPushConstMarker)
                                    Exit Select
                                End If
                            End If
                        End If

                        If TempStr.Trim <> "push_const " + FuncArr1(iTemp) Then
                            outAiLog.WriteLine("Fix to: '" + FuncArr3(iTemp) + "'" _
                            + vbNewLine + "Fixed class: " + ClassNameMarker _
                            + vbNewLine + "Fixed handler: " + HandlerNameMarker _
                            + vbNewLine + "Last push_const: " + LastPushConstMarker)
                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine("Fix as:" + TempStr + " --> " + "push_const " + FuncArr1(iTemp) + vbNewLine)

                            TempStr = Chr(9) + "push_const " + FuncArr1(iTemp)
                        End If

                        LastPushConstMarker = FuncArr1(iTemp)

                        ' ------------ FUNC_CALL -------------------
                    Case "func_call"

                        sTemp = Mid(TempStr, InStr(TempStr, "func["), (InStr(TempStr, "]") - InStr(TempStr, "func[")) + 1)
                        iTemp = Array.IndexOf(FuncArr3, sTemp)

                        If iTemp = -1 Then
                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine("Func not found in table!" + vbNewLine + TempStr, "Func_call not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            inAi.Close()
                            outAi.Close()
                            outAiLog.Close()
                            MessageBox.Show("Line: " & LineNum & vbTab & "Func not found in table!" + vbNewLine + TempStr, "Func_call not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        iTemp = FindIndex(sTemp, LastPushConstMarker)
                        If iTemp = -1 Then
                            iTemp = FindIndex(sTemp, HandlerNameMarker)

                            If iTemp = -1 Then

                                iTemp = FindIndex(sTemp, "default")
                                If iTemp = -1 Then
                                    outAi.WriteLine(TempStr)
                                    outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                                    outAiLog.WriteLine("Warning! Required 'default' for '" + sTemp + "'. Ignored.")
                                    outAiLog.WriteLine("Debug info:" + vbNewLine + "Fixed class: " + ClassNameMarker _
                                                + vbNewLine + "Fixed handler: " + HandlerNameMarker _
                                                 + vbNewLine + "Last push_const: " + LastPushConstMarker)
                                    Exit Select
                                End If

                            End If

                        End If

                        If Mid(TempStr, InStr(TempStr, "func_call ") + 10, (InStr(TempStr, "// ") - InStr(TempStr, "func_call ") - 10)).Trim <> FuncArr1(iTemp) Then

                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine("Fix to: '" + FuncArr3(iTemp) + "'" _
                                + vbNewLine + "Fixed class: " + ClassNameMarker _
                                + vbNewLine + "Fixed handler: " + HandlerNameMarker _
                                + vbNewLine + "Fix " + Mid(TempStr, InStr(TempStr, "func_call ") + 10, (InStr(TempStr, "// ") - InStr(TempStr, "func_call ") - 10)).Trim + " to " + FuncArr1(iTemp) + vbNewLine)

                            TempStr = TempStr.Replace(Mid(TempStr, InStr(TempStr, "func_call ") + 10, (InStr(TempStr, "// ") - InStr(TempStr, "func_call ") - 10)).Trim, FuncArr1(iTemp))

                        End If

                        ' ------------ HANDLER -------------------
                    Case "handler"

                        ' handler 3 138   //  TALKED
                        ' HandlerNameMarker

                        ' Define name for push_event
                        'sTemp = Mid(TempStr, (InStr(TempStr, "//") + 2), TempStr.Length - (InStr(TempStr, "//") + 1)).Trim
                        sTemp = HandlerNameMarker

                        iTemp = Array.IndexOf(FuncArr3, sTemp)
                        If iTemp = -1 Then
                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine(">>>>>> Not found :" + vbNewLine + TempStr + vbNewLine)
                            Exit Select
                        End If

                        If TempStr.StartsWith("handler " + FuncArr1(iTemp) + " ") = False Then
                            Dim tempStr2() As String
                            tempStr2 = TempStr.Replace(Chr(9), Chr(32)).Split(Chr(32))

                            TempStr = "handler " + FuncArr1(iTemp) + " " + tempStr2(2) + Chr(9) + "//" + Chr(9) + FuncArr3(iTemp)
                            outAiLog.WriteLine(vbNewLine & "Line: " & LineNum & vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                            outAiLog.WriteLine("Fix to: '" + FuncArr3(iTemp) + "'" _
                                + vbNewLine + "Fixed class: " + ClassNameMarker _
                                + vbNewLine + "Fixed handler: " + HandlerNameMarker _
                                + vbNewLine + "Fix " + tempStr2(1) + " to " + FuncArr1(iTemp) + vbNewLine)
                        End If

                    Case Else
                        outAi.WriteLine(TempStr)

                End Select

            End If

            outAi.WriteLine(TempStr)

        End While

        outAiLog.WriteLine(vbNewLine + "Work complete" + vbNewLine + Now.ToString + vbNewLine)
        ToolStripProgressBar.Value = 0
        inAi.Close()
        outAi.Close()
        outAiLog.Close()

        MessageBox.Show("Fixing done. Check Log file for full information.", "Complete", MessageBoxButtons.OK)

    End Sub

    Private Function FindIndex(ByVal fName As String, ByVal fHandler As String) As Integer

        Dim FinalMarker As Integer = -1
        Dim TempMarker As Integer = 0

        'Dim FuncArr1(500) As String ' id
        'Dim FuncArr2(500) As String ' name
        'Dim FuncArr3(500) As String ' handler


        For TempMarker = 0 To FuncArr3.Length - 1

            TempMarker = Array.IndexOf(FuncArr3, fName, TempMarker)
            If TempMarker = -1 Then Exit For

            If FuncArr2(TempMarker) = fHandler Then
                FinalMarker = TempMarker
                Exit For
            Else
                'If FuncArr2(TempMarker) = "default" Then
                'FinalMarker = TempMarker
                'End If
            End If

        Next

        Return FinalMarker
    End Function

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

    Private Sub IncreaseQuestListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncreaseQuestListButton.Click
        If CInt(IncQuestTextBox.Text) <= 0 Then Exit Sub

        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        System.IO.File.Copy(OpenFileDialog.FileName, OpenFileDialog.FileName & ".bak", True)
        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(OpenFileDialog.FileName, False, System.Text.Encoding.Unicode, 1)

        Dim outAiLog As New System.IO.StreamWriter(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + "\" + System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog.FileName) + ".log", True, System.Text.Encoding.Unicode, 1)

        outAiLog.WriteLine("L2ScriptMaker AI.obj Increase Quest List Module" & vbNewLine)

        Dim sTemp As String
        Dim aTemp() As String

        Dim sClass As String = ""
        Dim sHandler As String = ""

        Dim iTemp As Integer
        Dim iInc As Integer = CInt(IncQuestTextBox.Text)

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        While inFile.EndOfStream <> True

            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            sTemp = inFile.ReadLine

            If sTemp.StartsWith("class ") = True Then
                sClass = sTemp
            End If
            If sTemp.StartsWith("handler ") = True Then
                sHandler = sTemp
            End If

            'func_call 184615006     //  func[GetMemoCount]
            'shift_sp -1
            'push_const 16

            If InStr(sTemp, "func_call 184615006") <> 0 Then
                outFile.WriteLine(sTemp)
                sTemp = inFile.ReadLine

                If InStr(sTemp, "shift_sp -1") <> 0 Then
                    outFile.WriteLine(sTemp)

                    sTemp = inFile.ReadLine
                    If InStr(sTemp, "push_const ") <> 0 Then

                        sTemp = sTemp.Replace(Chr(9), "").Trim
                        aTemp = sTemp.Split(Chr(32))

                        If aTemp(0) = "push_const" Then

                            iTemp = CInt(aTemp(1))
                            iTemp = iTemp + iInc

                            If CheckBoxIgnoreAlredy.Checked = False Then
                                sTemp = vbTab & "push_const " & iTemp

                                outAiLog.WriteLine(vbNewLine & sClass & vbNewLine & sHandler)
                                outAiLog.WriteLine("Fixed: " & CInt(aTemp(1)) & " -> " & iTemp)
                            ElseIf (CheckBoxIgnoreAlredy.Checked = True And iTemp < 30) Then
                                sTemp = vbTab & "push_const " & iTemp

                                outAiLog.WriteLine(vbNewLine & sClass & vbNewLine & sHandler)
                                outAiLog.WriteLine("Fixed: " & CInt(aTemp(1)) & " -> " & iTemp)
                            Else
                                sTemp = vbTab & sTemp
                            End If

                        Else

                            MessageBox.Show("Error in AI.obj. Report about this exception to L2ScriptMaker owner for debuging")
                        End If

                    End If

                End If


            End If

            outFile.WriteLine(sTemp)

        End While

        outAiLog.WriteLine(vbNewLine + "Work complete" + vbNewLine + Now.ToString + vbNewLine)
        outAiLog.Close()

        outFile.Close()
        inFile.Close()

        MessageBox.Show("Complete.")


    End Sub

End Class

Public Class AIHandlersChecker


    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim CheckFile As String

        OpenFileDialog.Filter = "Lineage II Intelligence file|ai.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        CheckFile = OpenFileDialog.FileName

        Dim inFile As New System.IO.StreamReader(CheckFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(CheckFile & "_scriptCheck.log", True, System.Text.Encoding.Unicode, 1)

        outFile.WriteLine("L2ScriptMaker: AI Handlers Checker")
        outFile.WriteLine(Now & " Start")
        outFile.WriteLine("File: " & CheckFile)
        outFile.WriteLine()

        Dim sTemp As String = ""
        Dim sTemp2() As String
        Dim FlagClassName As String = ""
        Dim FlagHandlerName As String = ""
        Dim FlagHandlerLenght1 As Integer = 0
        Dim FlagHandlerLenght2 As Integer = 0
        Dim LineNum As Long = 0, LineNumHandler As Long

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        Me.Refresh()
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            LineNum += 1
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            Me.Update()

            If sTemp.StartsWith("class ") Then FlagClassName = sTemp
            If sTemp.StartsWith("handler ") Then
                LineNumHandler = LineNum
                FlagHandlerName = sTemp
                sTemp2 = sTemp.Split
                FlagHandlerLenght1 = CInt(sTemp2(2))

                ' Start Handler Reading
                FlagHandlerLenght2 = 0
                sTemp = inFile.ReadLine
                LineNum += 1
                While sTemp.StartsWith("handler_end") <> True
                    sTemp = sTemp.Replace(Chr(9), Chr(32)).Trim

                    If sTemp.StartsWith("variable_") = True Then GoTo nextItem
                    If sTemp.StartsWith(Chr(34)) = True Then GoTo nextItem
                    If sTemp.StartsWith("//") = True Then GoTo nextItem
                    If sTemp.StartsWith("L") = True Then
                        ' HR and Kvoxi counting metod without label Lxxx
                        If NoLabelsCheckBox.Checked = True Then GoTo nextItem
                    End If
                    If sTemp = Nothing Then GoTo nextItem

                    FlagHandlerLenght2 += 1
nextItem:
                    sTemp = inFile.ReadLine
                    LineNum += 1
                End While

                If FlagHandlerLenght1 <> FlagHandlerLenght2 Then
                    outFile.WriteLine("")
                    outFile.WriteLine("Class  : " & FlagClassName)
                    outFile.WriteLine("Handler: " & FlagHandlerName)
                    outFile.WriteLine("Line: [" & LineNumHandler.ToString & "]")
                    outFile.WriteLine("Class value:" & FlagHandlerLenght1.ToString & Chr(9) & "Real value: " & FlagHandlerLenght2.ToString)
                End If
            End If

        End While
        outFile.WriteLine(Now & vbNewLine)
        ToolStripProgressBar.Value = 0
        MessageBox.Show("Done.")
        outFile.WriteLine()

        inFile.Close()
        outFile.Close()
    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

    Private Sub HandlerVariableCheckButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HandlerVariableCheckButton.Click

        Dim AiFile As String

        OpenFileDialog.Filter = "Lineage II AI file|*.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        AiFile = OpenFileDialog.FileName

        Dim inAi As New System.IO.StreamReader(AiFile, System.Text.Encoding.Default, True, 1)
        Dim outAiLog As New System.IO.StreamWriter(AiFile & "_scriptCheck.log", True, System.Text.Encoding.Unicode, 1)
        outAiLog.WriteLine("L2ScriptMaker: AI.obj Handler Variable Checker. Start time: " & Now.ToString & vbNewLine)
        outAiLog.Flush()

        Dim aVar(0) As String
        Dim sTemp As String
        Dim iTemp As Integer

        ' check controls
        Dim ClassNameMarker As String = ""
        Dim HandlerNameMarker As String = ""
        Dim LastPushConstMarker As String = ""

        ToolStripProgressBar.Maximum = CInt(inAi.BaseStream.Length)

        While inAi.EndOfStream <> True

            sTemp = inAi.ReadLine.Trim
            'TempStr = TempStr.Trim

            ToolStripProgressBar.Value = CInt(inAi.BaseStream.Position)
            StatusStrip.Update()
            Me.Update()


            If sTemp.StartsWith("class ") = True Then
                ClassNameMarker = sTemp
            End If

            If sTemp.StartsWith("handler ") = True Then
                HandlerNameMarker = sTemp.Remove(0, InStr(sTemp, "//") + 2).Trim
            End If

            If sTemp.StartsWith("variable_begin") = True Then
                Array.Clear(aVar, 0, aVar.Length)
                Array.Resize(aVar, 0)

                sTemp = inAi.ReadLine.Trim
                While sTemp <> "variable_end"
                    '"_from_choice"
                    If sTemp.Trim <> "" Then
                        sTemp = sTemp.Replace("""", "")
                        Array.Resize(aVar, aVar.Length + 1)
                        aVar(aVar.Length - 1) = sTemp
                    End If
                    sTemp = inAi.ReadLine.Trim
                End While

            End If

            If sTemp.StartsWith("push_event") = True And InStr(sTemp, "//") > 1 Then

                'sTemp = sTemp.Replace(Chr(9), "").Replace(Chr(32), "")
                sTemp = sTemp.Remove(0, InStr(sTemp, "//") + 2).Trim
                If sTemp <> "gg" Then
                    iTemp = Array.IndexOf(aVar, sTemp)
                    If iTemp = -1 Then
                        outAiLog.WriteLine(vbTab & "Class: " & ClassNameMarker & vbTab & "Handler: " & HandlerNameMarker)
                        outAiLog.WriteLine(">>>>>> Not found variable:" & sTemp & vbNewLine)
                    End If
                End If

            End If

        End While

        ToolStripProgressBar.Value = 0

        outAiLog.WriteLine("L2ScriptMaker: AI.obj Handler Variable Checker. End time: " & Now.ToString & vbNewLine)
        outAiLog.WriteLine()
        outAiLog.Close()
        inAi.Close()

        MessageBox.Show("Complete.")

    End Sub

End Class
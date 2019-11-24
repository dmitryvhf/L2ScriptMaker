Public Class AiRateChanger

    Dim QuestPchName(2000) As String

    Private Sub ButtonQuest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuest.Click

        Dim AiFile As String
        Dim TempStr As String

        If CheckBoxAdena.Checked = False And CheckBoxExp.Checked = False And CheckBoxSP.Checked = False Then
            MessageBox.Show("No more jobs. Select need params and try again.", "No job", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        OpenFileDialog.Filter = "Lineage II AI file|ai.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        AiFile = OpenFileDialog.FileName

        ' Work with ai.obj
        Dim inAi As New System.IO.StreamReader(AiFile, System.Text.Encoding.Unicode, True, 1)
        Dim outAi As New System.IO.StreamWriter(AiFile + ".fixed.ai", False, System.Text.Encoding.Unicode, 1)
        Dim outAiLog As New System.IO.StreamWriter(AiFile + ".fixed.log", False, System.Text.Encoding.Unicode, 1)

        outAiLog.WriteLine("AI Rate Changer: Start at" & vbTab & Now & vbNewLine)

        ProgressBar.Maximum = CInt(inAi.BaseStream.Length)
        ProgressBar.Value = 0

        Dim tempClass As String = ""
        Dim tempHandler As String = ""

        'push_const 7586
        'push_const 2
        'func_call 184746111     //  func[GiveItem1]

        ' 0 - Exp, 1 - SP
        'push_const 0
        'push_const 3600
        'func_call 184746219 //  func[IncrementParam]

        Dim ReadBuffer(3) As String, HaveNegate As Short = 0
        Dim ReadCount As Integer = -1
        Dim iTemp As Integer = 0
        Dim sTemp As String = ""
        Dim Divider As Double = 0

        While inAi.EndOfStream <> True

            TempStr = inAi.ReadLine

            If Mid(TempStr, 1, 6) = "class " Then tempClass = TempStr
            If Mid(TempStr, 1, 8) = "handler " Then tempHandler = TempStr

            If InStr(TempStr, "push_const ") <> 0 Then
                ReadCount = 0
                ReadBuffer(ReadCount) = TempStr

                ' Check first param
                Divider = 0
                sTemp = ReadBuffer(0).Replace(Chr(9), Chr(32)).Trim

                If sTemp <> "push_const " + TextBoxItem.Text Then ' ADENA

                    If sTemp <> "push_const 0" Then ' EXP
                        If sTemp <> "push_const 1" Then GoTo Unload 'SP
                        If CheckBoxSP.Checked = False Then GoTo Unload
                        Divider = CDbl(TextBoxSP.Text)
                    Else
                        If CheckBoxExp.Checked = False Then GoTo Unload
                        Divider = CDbl(TextBoxExp.Text)
                    End If

                Else
                    If CheckBoxAdena.Checked = False Then GoTo Unload
                    Divider = CDbl(TextBoxAdena.Text)
                End If

                TempStr = inAi.ReadLine
                ReadCount = 1
                ReadBuffer(ReadCount) = TempStr
                If InStr(TempStr, "push_const ") <> 0 Then

                    TempStr = inAi.ReadLine
                    ReadCount = 2
                    ReadBuffer(ReadCount) = TempStr
                    If InStr(TempStr, "negate") <> 0 Then
                        TempStr = inAi.ReadLine
                        ReadCount = 3
                        ReadBuffer(ReadCount) = TempStr
                        HaveNegate = 1
                    End If


                    For iTemp = 0 To CheckedListBox.CheckedItems.Count - 1
                        If InStr(tempHandler, CheckedListBox.CheckedItems.Item(iTemp).ToString) <> 0 Then GoTo Unload
                    Next

                    ' Check thrird param
                    Select Case sTemp
                        Case "push_const " + TextBoxItem.Text
                            If InStr(TempStr, "func[GiveItem1]") = 0 Then GoTo Unload
                        Case "push_const 0"
                            If InStr(TempStr, "func[IncrementParam]") = 0 Then GoTo Unload
                        Case "push_const 1"
                            If InStr(TempStr, "func[IncrementParam]") = 0 Then GoTo Unload
                        Case Else
                    End Select

                    ' Achtung. Start fixing!
                    iTemp = CInt(ReadBuffer(1).Replace(Chr(9), Chr(32)).Trim.Replace("push_const ", ""))
                    ReadBuffer(1) = ReadBuffer(1).Replace("push_const " + iTemp.ToString, "push_const " + CInt(iTemp * Divider).ToString)
                    outAiLog.WriteLine(vbNewLine + tempClass + vbNewLine + tempHandler)
                    outAiLog.Write("Rebuild: ")
                    Select Case sTemp
                        Case "push_const " + TextBoxItem.Text
                            outAiLog.Write("adena")
                        Case "push_const 0"
                            outAiLog.Write("exp")
                        Case "push_const 1"
                            outAiLog.Write("SP")
                        Case Else
                    End Select
                    outAiLog.WriteLine(vbTab & "with divider: " & Divider & vbTab & "From: " & iTemp.ToString & vbTab & "To: " & CInt(iTemp * Divider).ToString)
                End If

Unload:
                ' Unload all data to dist
                For iTemp = 0 To ReadCount
                    outAi.WriteLine(ReadBuffer(iTemp))
                Next
                Array.Clear(ReadBuffer, 0, 4)
                HaveNegate = 0
            End If

            If ReadCount <> -1 Then
                ReadCount = -1
            Else
                outAi.WriteLine(TempStr)
            End If

            ProgressBar.Value = CInt(inAi.BaseStream.Position)
            Me.Update()

        End While

        ProgressBar.Value = 0
        outAiLog.WriteLine(vbNewLine & "AI Rate Changer: End at " & Now.ToString & vbNewLine)
        inAi.Close()
        outAi.Close()
        outAiLog.Close()


        MessageBox.Show("Fixing done. Check Log file for full information.", "Complete", MessageBoxButtons.OK)
        Shell("notepad.exe " + AiFile + ".fixed.log", AppWinStyle.NormalFocus)

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Close()
    End Sub

    Private Sub AiRateChanger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBoxAdena.Enabled = False
        TextBoxExp.Enabled = False
        TextBoxSP.Enabled = False
        CheckBoxAdena.Checked = False
        CheckBoxExp.Checked = False
        CheckBoxSP.Checked = False

        Dim sTemp As String, iTemp As Integer

        OpenFileDialog.FileName = "questname-e.txt"
        If System.IO.File.Exists("questname-e.txt") = False Then
            OpenFileDialog.Title = "Select Questname-e.txt file..."
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If

        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine
            sTemp = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "")
            If QuestListBox.Items.IndexOf(sTemp) = -1 Then
                QuestListBox.Items.Add(sTemp)
                QuestPchName(iTemp) = Libraries.GetNeedParamFromStr(sTemp, "id")
            End If
        End While
        inFile.Close()

    End Sub

    Private Sub CheckBoxAdena_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxAdena.CheckedChanged
        If CheckBoxAdena.Checked = False Then
            TextBoxAdena.Enabled = False
        Else
            TextBoxAdena.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxExp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxExp.CheckedChanged
        If CheckBoxExp.Checked = False Then
            TextBoxExp.Enabled = False
        Else
            TextBoxExp.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxSP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxSP.CheckedChanged
        If CheckBoxSP.Checked = False Then
            TextBoxSP.Enabled = False
        Else
            TextBoxSP.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxItem.CheckedChanged
        If CheckBoxItem.Checked = False Then
            TextBoxItem.Enabled = False
        Else
            TextBoxItem.Enabled = True
        End If
    End Sub

    Private Sub TextBoxItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxItem.Leave
        TextBoxItem.Text = TextBoxItem.Text.Trim
        If CInt(TextBoxItem.Text).ToString <> TextBoxItem.Text Then
            TextBoxItem.Text = "57"
            Exit Sub
        End If
        If CInt(TextBoxItem.Text) < 2 Or CInt(TextBoxItem.Text) > 40000 Then
            TextBoxItem.Text = "57"
            Exit Sub
        End If
    End Sub

    Private Sub TextBoxAdena_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAdena.Leave
        TextBoxAdena.Text = TextBoxAdena.Text.Trim
        Try
            If CDbl(TextBoxAdena.Text).ToString <> TextBoxAdena.Text Then
                'TextBoxAdena.Text = "1"
                'Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Wrong value: 1) is not Digital Value 2) check digital symbol in Regional Setting", "Wrong value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxAdena.Text = "1"
            Exit Sub
        End Try
        If CDbl(TextBoxAdena.Text) < 0 Or CDbl(TextBoxAdena.Text) > 101 Then
            TextBoxAdena.Text = "1"
        End If
    End Sub

    Private Sub TextBoxExp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxExp.Leave
        TextBoxExp.Text = TextBoxExp.Text.Trim
        Try
            If CDbl(TextBoxExp.Text).ToString <> TextBoxExp.Text Then
                'TextBoxExp.Text = "1"
                'Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Wrong value: 1) is not Digital Value 2) check digital symbol in Regional Setting", "Wrong value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxExp.Text = "1"
            Exit Sub
        End Try

        If CDbl(TextBoxExp.Text) < 0 Or CDbl(TextBoxExp.Text) > 101 Then
            TextBoxExp.Text = "1"
        End If
    End Sub

    Private Sub TextBoxSP_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxSP.Leave
        TextBoxSP.Text = TextBoxSP.Text.Trim
        Try
            If CDbl(TextBoxSP.Text).ToString <> TextBoxSP.Text Then
                'TextBoxSP.Text = "1"
                'Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Wrong value: 1) is not Digital Value 2) check digital symbol in Regional Setting", "Wrong value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxSP.Text = "1"
            Exit Sub
        End Try
        If CDbl(TextBoxSP.Text) < 0 Or CDbl(TextBoxSP.Text) > 101 Then
            TextBoxSP.Text = "1"
        End If
    End Sub

    Private Sub QuestListCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuestListCheckBox.CheckedChanged
        If QuestListCheckBox.Checked = False Then
            QuestListBox.Enabled = False
        Else
            QuestListBox.Enabled = True
        End If

    End Sub

    Private Sub QuestSelectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuestSelectButton.Click

        Dim iTemp As Integer
        For iTemp = 0 To QuestListBox.Items.Count - 1
            QuestListBox.SetItemChecked(iTemp, True)
        Next
    End Sub

    Private Sub QuestDeSelectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuestDeSelectButton.Click
        Dim iTemp As Integer
        For iTemp = 0 To QuestListBox.Items.Count - 1
            QuestListBox.SetItemChecked(iTemp, False)
        Next
    End Sub

    Private Sub SelectAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllButton.Click

        Dim iTemp As Integer
        For iTemp = 0 To CheckedListBox.Items.Count - 1
            CheckedListBox.SetItemChecked(iTemp, True)
        Next
    End Sub

    Private Sub DeselectAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeselectAllButton.Click
        Dim iTemp As Integer
        For iTemp = 0 To CheckedListBox.Items.Count - 1
            CheckedListBox.SetItemChecked(iTemp, False)
        Next

    End Sub
End Class

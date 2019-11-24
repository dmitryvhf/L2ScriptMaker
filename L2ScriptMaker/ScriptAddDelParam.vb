Public Class ScriptAddDelParam

    Private Sub ButtonDelParamGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelParamGo.Click

        If ComboBoxParamList.Text.Trim.Length = 0 Then
            MessageBox.Show("Clean parameter undefined! Enter name and Go again.", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sNewValue As String = Nothing
        Select Case ComboBoxDelMode.Text
            Case "Delete value"
                If TextBoxAddParamValue.Text = "" Then
                    MessageBox.Show("Default Value undefined! Select mode and Go again.", "No mode", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                sNewValue = TextBoxAddParamValue.Text
            Case "Delete param"
                'ComboBoxParamList
            Case Else
                MessageBox.Show("Mode for cleaning undefined! Select mode and Go again.", "No mode", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        Dim sFileName As String
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sFileName = OpenFileDialog.FileName

        Dim inFile As System.IO.StreamReader
        Dim outFile As System.IO.StreamWriter
        Dim sTempFS As String, sTemp As String, sTempLook As String = ComboBoxParamList.Text.Trim
        
        If System.IO.File.Exists(sFileName & ".bak") = True Then
            If MessageBox.Show("Backup file already exist. Overwrite this file?", "Overwrite backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then Exit Sub
        End If

        System.IO.File.Copy(sFileName, sFileName & ".bak", True)
        inFile = New System.IO.StreamReader(sFileName & ".bak", System.Text.Encoding.Default, True, 1)
        outFile = New System.IO.StreamWriter(sFileName, False, System.Text.Encoding.Default, 1)
        While inFile.EndOfStream <> True

            sTempFS = inFile.ReadLine()
            sTemp = Libraries.GetNeedParamFromStr(sTempFS, sTempLook)
            If sTemp <> "" Then

                If ComboBoxDelMode.Text = "Delete value" Then
                    sTempFS = Libraries.SetNeedParamToStr(sTempFS, sTempLook, sNewValue)
                Else
                    sTempFS = Libraries.SetNeedParamToStr(sTempFS, sTempLook, "")
                    sTempFS = sTempFS.Replace(sTempLook, "")
                End If
                sTempFS = sTempFS.Replace(Chr(9) & Chr(9), Chr(9))

            End If

            outFile.WriteLine(sTempFS)

        End While
        outFile.Close()
        inFile.Close()

        MessageBox.Show("Writing complete. Param has been cleaned", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Private Sub ButtonStructLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStructLoad.Click

        Dim sFileName As String
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sFileName = OpenFileDialog.FileName

        Dim aParamList(0) As String
        Dim inFile As System.IO.StreamReader
        Dim sTemp As String

        inFile = New System.IO.StreamReader(sFileName, System.Text.Encoding.Default, True, 1)

        sTemp = inFile.ReadLine()
        aParamList = sTemp.Split(Chr(9))
        Dim iTemp As Integer, iTemp2 As Integer

        For iTemp = 0 To aParamList.Length - 1
            iTemp2 = InStr(aParamList(iTemp), "=")
            If iTemp2 = 0 Then
                ComboBoxParamList.Items.Add(aParamList(iTemp))
            Else
                ComboBoxParamList.Items.Add(aParamList(iTemp).Remove(iTemp2 - 1))
            End If
        Next

        inFile.Close()

        If iTemp > 1 Then
            ComboBoxParamList.Text = CStr(ComboBoxParamList.Items.Item(0))
        Else
            MessageBox.Show("Empty file? No params?", "No param", MessageBoxButtons.OK, MessageBoxIcon.Question)
        End If

    End Sub

    Private Sub ButtonAddParamGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddParamGo.Click

        If ComboBoxParamList.Text.Trim.Length = 0 Then
            MessageBox.Show("New parameter undefined! Enter name and Go again.", "No new param", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If TextBoxAddParam.Text.ToString.Trim.Length = 0 Or TextBoxAddParamValue.Text.ToString.Trim.Length = 0 Then
            MessageBox.Show("Empty new parameter! Enter name and Go again.", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If ComboBoxEditMode.SelectedIndex = 0 And ComboBoxParamList.SelectedIndex = 0 Then
            MessageBox.Show("Impossible add before first element", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sFileName As String
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sFileName = OpenFileDialog.FileName

        Dim inFile As System.IO.StreamReader
        Dim outFile As System.IO.StreamWriter
        Dim sTempFS As String, sTemp As String, sTempLook As String
        Dim sTempNewParam As String = TextBoxAddParam.Text, sTempNewParamValue As String = TextBoxAddParamValue.Text, sTempNewParamFull As String = sTempNewParam & "=" & sTempNewParamValue

        ' parameter for looking after/before
        sTempLook = ComboBoxParamList.Text

        If System.IO.File.Exists(sFileName & ".bak") = True Then
            If MessageBox.Show("Backup file already exist. Overwrite this file?", "Overwrite backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then Exit Sub
        End If

        System.IO.File.Copy(sFileName, sFileName & ".bak", True)
        inFile = New System.IO.StreamReader(sFileName & ".bak", System.Text.Encoding.Default, True, 1)
        outFile = New System.IO.StreamWriter(sFileName, False, System.Text.Encoding.Default, 1)
        While inFile.EndOfStream <> True

            sTempFS = inFile.ReadLine()
            sTemp = Libraries.GetNeedParamFromStr(sTempFS, sTempLook)
            If sTemp = "" Then
                MessageBox.Show("Empty file? No params?", "No param", MessageBoxButtons.OK, MessageBoxIcon.Question)
                outFile.Close()
                inFile.Close()
                Exit Sub
            Else

                sTemp = Libraries.GetNeedParamFromStr(sTempFS, sTempNewParam)
                If sTemp = "" Then
                    Select Case ComboBoxEditMode.SelectedIndex
                        ' 0 - before
                        ' 1 - after
                        Case 0
                            sTempFS = sTempFS.Replace(sTempLook, sTempNewParamFull & Chr(9) & sTempLook)
                        Case 1
                            sTempFS = sTempFS.Replace(sTempLook & "=" & Libraries.GetNeedParamFromStr(sTempFS, sTempLook), sTempLook & "=" & Libraries.GetNeedParamFromStr(sTempFS, sTempLook) & Chr(9) & sTempNewParamFull)
                    End Select

                Else

                    ' This parameter already exist. Need to be ignore?
                    ' New function (future) - rewrite exist param by default value
                    If CheckBoxAddParamOverwrite.Checked = True Then sTempFS = Libraries.SetNeedParamToStr(sTempFS, sTempNewParam, sTempNewParamValue)

                End If
            End If

            outFile.WriteLine(sTempFS)

        End While
        outFile.Close()
        inFile.Close()

        MessageBox.Show("Writing complete. New param has been added", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

End Class
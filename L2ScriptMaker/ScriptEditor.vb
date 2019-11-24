Public Class ScriptEditor

    Dim MaskCol(100) As String
    Dim isLoading As Boolean = False

    Private Sub ButtonConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConfig.Click

        OpenFileDialog.Filter = "Visual Script Editor config file|*.ini|All files(*.*)|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim IniFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.GetEncoding(1250), True, 1)
        If IniFile.ReadLine <> "L2ScriptMaker Visual Script Editor config file v1" Then
            MessageBox.Show("This file is not L2ScriptMaker Visual Script Editor config file v1" + vbNewLine + "Buy it or download free :)", "Wrong config file", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            IniFile.Close()
            Exit Sub
        End If

        Dim iColIndex As Integer = -1
        For iColIndex = DataGridView.ColumnCount - 1 To 0 Step -1
            DataGridView.Columns.Remove(DataGridView.Columns(iColIndex).Name)
        Next
        iColIndex = -1

        Dim ColName As String = "Default"
        Dim ColWidth As Integer = 30
        Dim ColToolTip As String = ""
        Dim ColReadOnly As Boolean = False
        Dim ColList As Boolean = False
        Dim ColDefValue As String = ""
        Dim ColBlockSym As String = ""

        Dim aTemp(2) As String
        Dim TempStr As String

        Dim comboBoxColumn As DataGridViewComboBoxColumn = Nothing
        Dim textColumn As DataGridViewTextBoxColumn = Nothing

        isLoading = True

        While IniFile.EndOfStream <> True

            TempStr = IniFile.ReadLine

            ' Start working with new column
            If TempStr.StartsWith("[") = True Then
                comboBoxColumn = New DataGridViewComboBoxColumn
                textColumn = New DataGridViewTextBoxColumn

                ColName = TempStr.Replace("[", "").Replace("]", "")
                iColIndex += 1

            End If

            ' Found List block
            If TempStr = "<" Then
                TempStr = IniFile.ReadLine

                While Mid(TempStr, 1, 1) <> ">"
                    If ColList = True Then
                        comboBoxColumn.Items.Add(TempStr)
                    End If
                    TempStr = IniFile.ReadLine
                End While


                ' FINISHING and creating new column
                If ColList = True Then
                    comboBoxColumn.Name = ColName
                    comboBoxColumn.Width = ColWidth
                    comboBoxColumn.ToolTipText = ColToolTip
                    comboBoxColumn.ReadOnly = ColReadOnly
                    comboBoxColumn.Tag = ColDefValue
                    DataGridView.Columns.Add(comboBoxColumn)
                Else
                    textColumn.Name = ColName
                    textColumn.Width = ColWidth
                    textColumn.ToolTipText = ColToolTip
                    textColumn.ReadOnly = ColReadOnly
                    textColumn.Tag = ColDefValue
                    DataGridView.Columns.Add(textColumn)
                End If
                If ColDefValue <> Nothing Then DataGridView.Item(iColIndex, 0).Value = ColDefValue

                ' Clean all params for new cycle
                ColName = "Default"
                ColWidth = 30
                ColList = False
                ColReadOnly = False
                ColToolTip = ""
                ColDefValue = ""
                MaskCol(DataGridView.ColumnCount - 1) = ColBlockSym
                ColBlockSym = ""

            End If

            If InStr(TempStr, "=") <> 0 Then

                aTemp = TempStr.Split(CChar("="))
                aTemp(0) = aTemp(0).Trim
                aTemp(1) = aTemp(1).Trim

                Select Case aTemp(0)
                    Case "width"
                        ColWidth = CInt(aTemp(1))
                    Case "list"
                        If aTemp(1) = "on" Then
                            ColList = True
                        End If
                    Case "block"
                        If aTemp(1) = "on" Then
                            ColReadOnly = True
                        End If
                    Case "tooltip"
                        If aTemp(1) = "" Then aTemp(1) = ColName
                        ColToolTip = aTemp(1)
                    Case "defvalue"
                        ColDefValue = aTemp(1)
                    Case "symbols"
                        ColBlockSym = aTemp(1)
                        ColToolTip = ColToolTip & vbNewLine & "Block symbols: " & aTemp(1)
                    Case Else
                        MessageBox.Show("Unknown params in config file." + vbNewLine + aTemp(1), "Unknown param", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
            End If

        End While

        isLoading = False

        'comboBoxColumn.Items.AddRange(New String() {"sss", "llsd"})

    End Sub

    Private Sub ButtonGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerate.Click

        Dim TableCount As Integer, RowCounter As Integer, iTemp As Integer
        TextBox1.Text = ""

        If DataGridView.RowCount > 11 Then
            MessageBox.Show("Use 'Save file' button for generate big project. Only 10 lines will be generation.", "Big project", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RowCounter = 9
        Else
            RowCounter = DataGridView.RowCount - 2
        End If

        For iTemp = 0 To RowCounter
            For TableCount = 0 To DataGridView.ColumnCount - 1
                If TableCount > 0 Then TextBox1.AppendText(Chr(9))
                TextBox1.AppendText(DataGridView.Columns(TableCount).Name)

                If DataGridView.Item(TableCount, iTemp).Value IsNot Nothing Or MaskCol(TableCount) <> "" Then
                    If DataGridView.Columns(TableCount).Name <> Nothing Then
                        TextBox1.AppendText("=")
                    End If
                    If MaskCol(TableCount) <> "" Then
                        TextBox1.AppendText(Mid(MaskCol(TableCount), 1, 1))
                    End If
                    If DataGridView.Item(TableCount, iTemp).Value IsNot Nothing Then
                        TextBox1.AppendText(DataGridView.Item(TableCount, iTemp).Value.ToString)
                    End If
                    If MaskCol(TableCount) <> "" Then
                        TextBox1.AppendText(Mid(MaskCol(TableCount), 2, 1))
                    End If
                End If
            Next
            TextBox1.AppendText(vbNewLine)
        Next

        TabControl1.SelectedIndex = 1

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        Dim TableCount As Integer

        For TableCount = DataGridView.ColumnCount - 1 To 0 Step -1
            DataGridView.Columns.Remove(DataGridView.Columns(TableCount).Name)
        Next

    End Sub

    Private Sub ButtonLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoadFile.Click

        If DataGridView.ColumnCount = 0 Then
            MessageBox.Show("Empty structure.", "Empty structure", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sTemp As String
        Dim aTemp() As String = {}
        Dim iTemp As Integer

        OpenFileDialog.Filter = "Lineage II script-config|*.txt|All files(*.*)|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)

        DataGridView.Rows.Clear()
        DataGridView.SuspendLayout()

        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine

            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then

                aTemp = sTemp.Split(Chr(9))

                'If aTemp.Length <> DataGridView.ColumnCount Then
                If aTemp(0) = DataGridView.Columns.Item(0).Tag.ToString Then

                    DataGridView.Rows.Add()

                    For iTemp = 0 To aTemp.Length - 1
                        aTemp(iTemp) = aTemp(iTemp).Trim

                        If InStr(aTemp(iTemp), "=") <> 0 Then
                            aTemp(iTemp) = Libraries.GetNeedParamFromStr(sTemp, DataGridView.Columns.Item(iTemp).Name)
                        Else
                            'nothing do because
                            'aTemp(iTemp) = aTemp(iTemp)
                        End If
                        If MaskCol(iTemp) <> "" Then
                            aTemp(iTemp) = Mid(aTemp(iTemp).Trim, 2, aTemp(iTemp).Length - 2)
                        End If
                        DataGridView.Item(iTemp, DataGridView.RowCount - 2).Value = aTemp(iTemp)
                    Next

                Else

                    'MessageBox.Show("Incoming file incompatible with configuration file. Use correct config for this file type.")
                    'DataGridView.Rows.Clear()
                    'ProgressBar.Value = 0
                    'inFile.Close()
                    'Exit Sub
                End If

            End If
            ProgressBar.Value = CInt(inFile.BaseStream.Position)

        End While

        ProgressBar.Value = 0
        DataGridView.ResumeLayout()
        inFile.Close()
        MessageBox.Show("File loaded.", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ButtonSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveFile.Click

        If DataGridView.RowCount <= 1 Then
            MessageBox.Show("Empty project.", "Empty project", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim iTemp As Integer, iTemp2 As Integer
        Dim sTemp As String

        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim outFile As New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Unicode, 1)

        ProgressBar.Value = 0
        ProgressBar.Maximum = DataGridView.RowCount - 2
        sTemp = ""

        For iTemp = 0 To DataGridView.RowCount - 2
            For iTemp2 = 0 To DataGridView.ColumnCount - 1
                If iTemp2 > 0 Then sTemp = sTemp & Chr(9)
                sTemp = sTemp & DataGridView.Columns(iTemp2).Name

                If DataGridView.Item(iTemp2, iTemp).Value IsNot Nothing Or MaskCol(iTemp2) <> "" Then
                    If DataGridView.Columns(iTemp2).Name <> Nothing Then
                        sTemp = sTemp & "="
                    End If
                    If MaskCol(iTemp2) <> "" Then
                        sTemp = sTemp & Mid(MaskCol(iTemp2), 1, 1)
                    End If
                    If DataGridView.Item(iTemp2, iTemp).Value IsNot Nothing Then
                        sTemp = sTemp & CStr(DataGridView.Item(iTemp2, iTemp).Value)
                    End If
                    If MaskCol(iTemp2) <> "" Then
                        sTemp = sTemp & Mid(MaskCol(iTemp2), 2, 1)
                    End If
                End If
            Next
            outFile.WriteLine(sTemp)
            ProgressBar.Value = iTemp
            sTemp = ""
        Next

        outFile.Close()
        ProgressBar.Value = 0

        MessageBox.Show("New file saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub DataGridView_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView.RowsAdded
        'MessageBox.Show("qq")

        If isLoading = False Then       ' Don't if file loading
            Dim iTemp As Integer
            For iTemp = 0 To DataGridView.Columns.Count - 1
                DataGridView.Item(iTemp, e.RowIndex).Value = DataGridView.Columns(iTemp).Tag
            Next
        End If

    End Sub
End Class
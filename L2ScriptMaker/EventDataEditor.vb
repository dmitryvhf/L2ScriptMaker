Public Class EventDataEditor

    Dim ItemsIsNumbers As Boolean = False

    Dim ItemPch(30000) As String

    Private Sub AIbuyselllistEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim FileName As String = "item_pch.txt"

        If System.IO.File.Exists("item_pch.txt") = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Title = "Select item_pch.txt file for reading name of items from server file..."
            OpenFileDialog.Filter = "item_pch.txt|item_pch.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Me.Close() 'Exit Sub
            End If
            FileName = OpenFileDialog.FileName
        End If

        If MessageBox.Show("Loading items as names?", "Items as name", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then ItemsIsNumbers = True
        If ItemPchLoad(FileName) = False Then Exit Sub

    End Sub

    Private Function ItemPchLoad(ByVal FileName As String) As Boolean

        Dim inFile As System.IO.StreamReader
        Try
            inFile = New System.IO.StreamReader(FileName, System.Text.Encoding.Default, True, 1)
        Catch ex As Exception
            Return False
        End Try
        Dim sTempStr As String = ""
        Dim aTemp(1) As String

        While inFile.EndOfStream <> True

            '[small_sword]	=	1
            Try
                sTempStr = inFile.ReadLine
                sTempStr = sTempStr.Replace(" ", "").Replace(Chr(9), "").Replace("[", "").Replace("]", "")
                aTemp = sTempStr.Split(CChar("="))
                ItemPch(CInt(aTemp(1))) = aTemp(0)
                If ItemsIsNumbers = False Then
                    Column1Name.Items.Add(aTemp(0))
                Else
                    Column1Name.Items.Add(aTemp(1))
                End If
            Catch ex As Exception
                MessageBox.Show("Import data invalid in line" & vbNewLine & sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
                inFile.Close()
                Return False
            End Try

        End While

        inFile.Close()
        Return True

    End Function

    Private Sub GenerateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateButton.Click
        Dim iTemp As Integer

        TabControl1.SelectTab(0)

        FinalBox.Text = "[event]" & vbNewLine
        FinalBox.Text += "eventname=" & EventNameBox.Text & vbNewLine
        FinalBox.Text += "eventnpcname=" & EventNpcNameBox.Text & vbNewLine
        FinalBox.Text += "flagsettingtime=" & FlagSettingTimeBox.Text & vbNewLine
        FinalBox.Text += "event_doing=" & EventDoingBox.SelectedIndex.ToString & vbNewLine

        'dropitem_count
        FinalBox.Text += "dropitem_count= " & (DataGridView1.RowCount - 1).ToString & vbNewLine
        For iTemp = 0 To DataGridView1.RowCount - 2
            If ItemsIsNumbers = False Then
                FinalBox.Text += vbTab & "dropitem" & iTemp.ToString & "= " & DataGridView1.Item(0, iTemp).Value.ToString & " " & DataGridView1.Item(1, iTemp).Value.ToString & vbNewLine
            Else
                FinalBox.Text += vbTab & "dropitem" & iTemp.ToString & "= " & ItemPch(CInt(DataGridView1.Item(0, iTemp).Value)) & " " & DataGridView1.Item(1, iTemp).Value.ToString & vbNewLine
            End If
        Next
        FinalBox.Text += vbNewLine

        'dropitem_count
        FinalBox.Text += "droptime_count= " & (DataGridView2.RowCount - 1).ToString & vbNewLine
        For iTemp = 0 To DataGridView2.RowCount - 2
            FinalBox.Text += vbTab & "droptime" & iTemp.ToString & "= " & DataGridView2.Item(0, iTemp).Value.ToString & " ~ " & DataGridView2.Item(1, iTemp).Value.ToString & vbNewLine
        Next
        FinalBox.Text += vbNewLine

        'dropitem_count
        FinalBox.Text += "npctime_count= " & (DataGridView3.RowCount - 1).ToString & vbNewLine
        For iTemp = 0 To DataGridView3.RowCount - 2
            FinalBox.Text += vbTab & "npctime" & iTemp.ToString & "= " & DataGridView3.Item(0, iTemp).Value.ToString & " ~ " & DataGridView3.Item(1, iTemp).Value.ToString & vbNewLine
        Next
        FinalBox.Text += vbNewLine

        'FinalBox.Text += "timevariable_count= 0" & vbNewLine
        'timevariable_count
        FinalBox.Text += "timevariable_count= " & (DataGridView4.RowCount - 1).ToString & vbNewLine
        For iTemp = 0 To DataGridView4.RowCount - 2
            FinalBox.Text += vbTab & "timevariable" & iTemp.ToString & "= " & DataGridView4.Item(0, iTemp).Value.ToString & " ~ " & DataGridView4.Item(1, iTemp).Value.ToString & ";" & DataGridView4.Item(2, iTemp).Value.ToString & vbNewLine
        Next
        FinalBox.Text += vbNewLine

        FinalBox.Text += "[npcsetting]" & vbNewLine
        FinalBox.Text += "npcsetting_count= 1" & vbNewLine
        FinalBox.Text += "npc_eventname0= " & EventNameBox.Text & vbNewLine
        FinalBox.Text += vbNewLine

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
        'Me.Close()
    End Sub

    Private Sub AboutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        EventDataEditorAbout.Show()
    End Sub

    Private Sub DataGridView2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            If e.RowIndex = DataGridView2.RowCount - 1 Then
                DataGridView2.Rows.Add()
            End If
            DataGridView2.Item(e.ColumnIndex, e.RowIndex).Value = DateTimePicker2.Text
        End If
    End Sub

    Private Sub DataGridView3_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            If e.RowIndex = DataGridView3.RowCount - 1 Then
                DataGridView3.Rows.Add()
            End If
            DataGridView3.Item(e.ColumnIndex, e.RowIndex).Value = DateTimePicker2.Text
        End If
    End Sub


    Private Sub DataGridView4_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellValueChanged

        If e.RowIndex >= 0 Then

            If e.ColumnIndex = 0 Then
                If DataGridView4.Item(1, e.RowIndex).Value IsNot Nothing Then
                    If CInt(DataGridView4.Item(0, e.RowIndex).Value) > CInt(DataGridView4.Item(1, e.RowIndex).Value) Then
                        DataGridView4.Item(0, e.RowIndex).Value = DataGridView4.Item(1, e.RowIndex).Value
                    End If
                Else
                    DataGridView4.Item(1, e.RowIndex).Value = DataGridView4.Item(0, e.RowIndex).Value
                End If
            End If

            If e.ColumnIndex = 1 Then
                If DataGridView4.Item(0, e.RowIndex).Value IsNot Nothing Then
                    If CInt(DataGridView4.Item(1, e.RowIndex).Value) < CInt(DataGridView4.Item(0, e.RowIndex).Value) Then
                        DataGridView4.Item(1, e.RowIndex).Value = DataGridView4.Item(0, e.RowIndex).Value
                    End If
                Else
                    DataGridView4.Item(0, e.RowIndex).Value = DataGridView4.Item(1, e.RowIndex).Value
                End If
            End If

            If DataGridView4.Item(2, e.RowIndex).Value Is Nothing Then
                DataGridView4.Item(2, e.RowIndex).Value = "1"
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If (DataGridView1.Item(1, e.RowIndex).Value Is Nothing) Then
                    DataGridView1.Item(1, e.RowIndex).Value = "1"
                End If
            End If
        End If

    End Sub
End Class
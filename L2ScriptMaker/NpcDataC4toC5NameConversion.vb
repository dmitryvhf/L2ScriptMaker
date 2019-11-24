Public Class NpcC4toC5IdsConversion

    '13846	14829
    Dim aOldId(0) As Integer, aNewId(0) As Integer
    Dim sIDFile As String

    Private Function IDReloader() As Boolean

        OpenFileDialog.FileName = sIDFile
        OpenFileDialog.Filter = "File with ids (2 column)|*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Return False
        sIDFile = OpenFileDialog.FileName

        Dim sTemp As String
        Dim aTemp(2) As String

        Array.Clear(aOldId, 0, aOldId.Length)
        Array.Clear(aNewId, 0, aNewId.Length)
        Array.Resize(aOldId, 0)
        Array.Resize(aNewId, 0)

        Dim inFile As New System.IO.StreamReader(sIDFile, System.Text.Encoding.Default, True, 1)
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            sTemp = sTemp.Trim
            If sTemp <> "" And sTemp.StartsWith("//") = False Then
                While InStr(sTemp, "  ") <> 0
                    sTemp = sTemp.Replace("  ", " ")
                End While
                sTemp = sTemp.Replace(Chr(32), Chr(9))
                While InStr(sTemp, Chr(9) & Chr(9)) <> 0
                    sTemp = sTemp.Replace(Chr(9) & Chr(9), Chr(9))
                End While
                aTemp = sTemp.Split(Chr(9))

                Array.Resize(aOldId, aOldId.Length + 1)
                aOldId(aOldId.Length - 1) = CInt(aTemp(0))
                Array.Resize(aNewId, aNewId.Length + 1)
                aNewId(aNewId.Length - 1) = CInt(aTemp(1))
            End If

        End While

        inFile.Close()
        Return True

    End Function

    Private Sub NpcC4toC5IdsConversion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If IDReloader() = False Then Me.Close()

    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sNpcdataFile As String = ""
        OpenFileDialog.FileName = sNpcdataFile
        OpenFileDialog.Filter = "Lineage II C4 server npc config (npcdata.txt)|npcdata*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sNpcdataFile = OpenFileDialog.FileName

        Dim sTemp As String
        Dim aTemp() As String

        If System.IO.File.Exists(sNpcdataFile & ".bak") = True Then
            If MessageBox.Show("Overwrite last backup file " & sNpcdataFile & ".bak ?", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If


        System.IO.File.Copy(sNpcdataFile, sNpcdataFile & ".bak", True)
        Dim inFile As New System.IO.StreamReader(sNpcdataFile & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sNpcdataFile, False, System.Text.Encoding.Unicode, 1)
        Dim iTemp As Integer

        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar1.Value = CInt(inFile.BaseStream.Position)
            sTemp = sTemp.Trim
            If sTemp <> "" And sTemp.StartsWith("//") = False Then
                aTemp = sTemp.Split(Chr(9))

                'npc_begin(0)      pet(1)     12077(2)   [pet_wolf_a](3)    level=15(4)
                If InverseDirectionCheckBox.Checked = False Then
                    iTemp = Array.IndexOf(aOldId, CInt(aTemp(2)))
                    If iTemp <> -1 Then
                        aTemp(2) = CStr(aNewId(iTemp))
                        sTemp = Join(aTemp, Chr(9))
                    Else
                        If DisableCheckBox.Checked = True Then sTemp = "//" & sTemp
                    End If
                Else
                    iTemp = Array.IndexOf(aNewId, CInt(aTemp(2)))
                    If iTemp <> -1 Then
                        aTemp(2) = CStr(aOldId(iTemp))
                        sTemp = Join(aTemp, Chr(9))
                    Else
                        If DisableCheckBox.Checked = True Then sTemp = "//" & sTemp
                    End If

                End If
            End If
            outFile.WriteLine(sTemp)

        End While
        inFile.Close()
        outFile.Close()
        ToolStripProgressBar1.Value = 0
        MessageBox.Show("Fixed npcdata file created successfuly", "Complete")

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

    Private Sub C4TextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles C4TextBox.TextChanged

        '13846	14829
        Dim iTemp As Integer
        Try
            iTemp = Array.IndexOf(aOldId, CInt(C4TextBox.Text))
        Catch ex As Exception
            Exit Sub
        End Try
        If iTemp <> -1 Then
            C6TextBox.Text = CStr(aNewId(iTemp))
        Else
            C6TextBox.Text = "Not found"
        End If

    End Sub

    Private Sub C6TextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles C6TextBox.TextChanged
        Dim iTemp As Integer
        Try
            iTemp = Array.IndexOf(aNewId, CInt(C6TextBox.Text))
        Catch ex As Exception
            Exit Sub
        End Try
        If iTemp <> -1 Then
            C4TextBox.Text = CStr(aOldId(iTemp))
        Else
            C4TextBox.Text = "Not found"
        End If
    End Sub

    Private Sub ReloadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadButton.Click
        If IDReloader() = True Then
            MessageBox.Show("New ID table reloaded", "Complete")
        Else
            MessageBox.Show("New ID table NOT reloaded", "Failure")
        End If
    End Sub
End Class
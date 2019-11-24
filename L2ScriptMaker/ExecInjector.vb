Public Class ExecInjector

    Private Sub InjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InjectButton.Click

        Dim ExecFile, FixFile As String
        Dim ReadStr As String

        ' Select source and target files
        OpenFileDialog1.Title = "Select Exec file to fix:"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "L2Server.exe|L2Server.exe|All files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            ExecFile = OpenFileDialog1.FileName
            ExecName.Text = ExecFile
        End If

        OpenFileDialog1.Title = "Select Fix file:"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Text file format|*.txt|All files|*.*"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            FixFile = OpenFileDialog1.FileName
            FixName.Text = FixFile
        End If

        ' Make backup for exec
        System.IO.File.Copy(ExecFile, ExecFile + ".bak", True)

        ' Start fix
        Dim InFixFile As New System.IO.StreamReader(FixFile, System.Text.Encoding.Default, True, 1)
        Dim OExecFile As System.IO.Stream = New System.IO.FileStream(ExecFile, _
                IO.FileMode.Open, IO.FileAccess.ReadWrite)
        Dim OutExecFile As System.IO.StreamWriter = New System.IO.StreamWriter(OExecFile)

        If System.IO.File.Exists(FixFile & ".bak") = True And RecoveryBox.Checked = True Then
            If MessageBox.Show("Backup file already exist. Owerwrite last good recovery backup?", "Owerwrite backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If


        Dim OExecFileBak As System.IO.Stream = Nothing
        Dim OutExecFileBak As System.IO.StreamWriter = Nothing

        If RecoveryBox.Checked = True Then
            'System.IO.Path.GetDirectoryName()
            OExecFileBak = New System.IO.FileStream(System.IO.Path.GetDirectoryName(FixFile) & "\backup~" & System.IO.Path.GetFileName(FixFile), _
            IO.FileMode.Create, IO.FileAccess.Write)
            OutExecFileBak = New System.IO.StreamWriter(OExecFileBak)
        End If

        Dim WriteOffset, WriteLenght, tempOff As Integer

        ReadStr = Trim(InFixFile.ReadLine)
        Do While (ReadStr <> Nothing)

            WriteOffset = CInt(Val("&H" + Mid(ReadStr, 1, InStr(ReadStr, ":"))))
            If IsOffset.Checked = True Then
                WriteOffset -= &H400000

                If WriteOffset < 0 Then
                    MessageBox.Show("This fix no required inject offset", "No required offset", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    OExecFile.Close()
                    InFixFile.Close()
                    If RecoveryBox.Checked = True Then
                        OutExecFileBak.Close()
                    End If
                    Exit Sub
                End If
            End If

            ReadStr = Mid(ReadStr, InStr(ReadStr, ":") + 1, ReadStr.Length).TrimStart

            Dim TempArr() As String
            TempArr = ReadStr.Split(Chr(32))

            Dim FixStr(TempArr.Length - 1) As Byte

            If RecoveryBox.Checked = True Then

                Dim BackupArr(TempArr.Length - 1) As Byte

                OExecFile.Position = WriteOffset
                OExecFile.Read(BackupArr, 0, TempArr.Length)

                OutExecFileBak.Write(Hex(WriteOffset) & ":")

                Dim tChr As Byte
                For Each tChr In BackupArr
                    OutExecFileBak.Write(" " & Hex(tChr).PadLeft(2, Convert.ToChar("0")))
                Next
                OutExecFileBak.WriteLine("")
                OutExecFileBak.Flush()
            End If

            For tempOff = 0 To TempArr.Length - 1
                Try
                    FixStr(tempOff) = CByte(Val("&H" + (TempArr(tempOff))))
                Catch ex As Exception
                    MessageBox.Show("Fix file have incorrect format. Make recovery fix from backup (.bak) file.", "Incorrect fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    OExecFile.Close()
                    InFixFile.Close()
                    If RecoveryBox.Checked = True Then
                        OutExecFileBak.Close()
                    End If
                    Exit Sub
                End Try
            Next
            WriteLenght = tempOff

            OExecFile.Position = WriteOffset
            OExecFile.Write(FixStr, 0, WriteLenght)
            OutExecFile.Flush()

            ReadStr = Trim(InFixFile.ReadLine)
        Loop

        OExecFile.Close()
        InFixFile.Close()
        If RecoveryBox.Checked = True Then
            OutExecFileBak.Close()
        End If

        MessageBox.Show("Injection success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub HelpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpButton2.Click
        MessageBox.Show("Fix file format is:" + Chr(10) + Chr(10) + "[hex offset]: [binary code or text code]" + Chr(10) + "Example:" + Chr(10) + "26A63: E9 35 EC 0F 00 90 90 90 90")
    End Sub
End Class
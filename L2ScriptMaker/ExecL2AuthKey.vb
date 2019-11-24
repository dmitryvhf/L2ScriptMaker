Public Class ExecL2AuthKey

    Private Sub LoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadButton.Click

        OpenFileDialog.Filter = "Lineage II Server Authentification Service|*L2Auth*.exe|Lineage II Client Library (Engine.dll)|Engine.dll"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        'Dim InFixFile As System.IO.Stream = New System.IO.FileStream(OpenFileDialog.FileName, IO.FileMode.Create, Security.AccessControl.FileSystemRights.FullControl, IO.FileShare.None, 1, IO.FileOptions.None)

        Dim InFixFile As New System.IO.FileStream(OpenFileDialog.FileName, IO.FileMode.Open, IO.FileAccess.Read)

        Dim HexOffset As Long = 0
        Dim HexL2AuthOffset As Long = CLng(Val("&H06C6B0")), HexEngineOffset As Long = CLng(Val("&H62531C"))
        If InStr(OpenFileDialog.FileName.ToLower, "engine") <> 0 Then
            HexOffset = HexEngineOffset
        Else
            HexOffset = HexL2AuthOffset
        End If
        If HexOffset = 0 Then MessageBox.Show("AHTUNG!")

        Dim iTemp As Integer ' sTemp As String
        Dim aLoadKey(19) As Byte

        InFixFile.Position = HexOffset
        InFixFile.Read(aLoadKey, 0, 20)

        KeyLoadBox.Text = "" : LoadKeyHexBox.Text = ""
        For iTemp = 0 To 19
            KeyLoadBox.Text = KeyLoadBox.Text & Chr(aLoadKey(iTemp))
            LoadKeyHexBox.Text = LoadKeyHexBox.Text & Hex(aLoadKey(iTemp)) & " "
        Next
        InFixFile.Close()

    End Sub

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Dispose()
    End Sub

    Private Sub KeyLoadBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles KeyLoadBox.TextChanged
        LoadKeyLabel.Text = KeyLoadBox.Text.Length.ToString
    End Sub

    Private Sub CopyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyButton.Click
        NewKeyBox.Text = KeyLoadBox.Text
    End Sub

    Private Sub NewKeyBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewKeyBox.TextChanged
        LoadKeyHexBox.Text = ""
        Dim iTemp As Integer : Dim aLoadKey(19) As Byte
        For iTemp = 0 To NewKeyBox.Text.Length - 1
            LoadKeyHexBox.Text = LoadKeyHexBox.Text & Hex(Asc(NewKeyBox.Text(iTemp))) & " "
        Next

        LoadKeyLabel.Text = NewKeyBox.Text.Length.ToString

    End Sub

    Private Sub WriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WriteButton.Click

        If NewKeyBox.Text = "" Then
            MessageBox.Show("New key must be defined", "No new key", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If NewKeyBox.Text.Length <> 20 Then
            MessageBox.Show("New Key must have 20 symbols", "Wrong key length", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim outAuth As String, outEngine As String

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II Server Authentification Service|*L2Auth*.exe"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            outAuth = ""
        Else
            outAuth = OpenFileDialog.FileName
        End If

        OpenFileDialog.Filter = "Lineage II Client Library (Engine.dll)|Engine*.dll"
        OpenFileDialog.FileName = ""
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            outEngine = ""
        Else
            outEngine = OpenFileDialog.FileName
        End If


        Dim HexL2AuthOffset As Long = CLng(Val("&H06C6B0")), HexEngineOffset As Long = CLng(Val("&H62531C"))
        Dim outFixFile As System.IO.FileStream

        Dim iTemp As Integer : Dim aLoadKey(19) As Byte
        For iTemp = 0 To 19
            aLoadKey(iTemp) = CByte(AscW(NewKeyBox.Text(iTemp)))
        Next

        ' Write L2Auth
        If outAuth <> "" Then
            System.IO.File.Copy(outAuth, outAuth & ".bak", True)
            outFixFile = New System.IO.FileStream(outAuth, IO.FileMode.Open, IO.FileAccess.Write)
            outFixFile.Position = HexL2AuthOffset
            outFixFile.Write(aLoadKey, 0, 20)
            outFixFile.Close()
        End If

        ' Write L2Auth
        If outEngine <> "" Then
            System.IO.File.Copy(outEngine, outEngine & ".bak", True)
            outFixFile = New System.IO.FileStream(outEngine, IO.FileMode.Open, IO.FileAccess.Write)
            outFixFile.Position = HexEngineOffset
            outFixFile.Write(aLoadKey, 0, 20)
            outFixFile.Close()
        End If

        MessageBox.Show("New blowfish key has been injected.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class
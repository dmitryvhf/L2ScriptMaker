Public Class NpcDataCollisionFix

    Private Structure Collision
        Dim Radius As String
        Dim Height As String
    End Structure

    Dim NpcId(0) As Integer
    Dim NpcParam(0) As Collision

    'collision_radius={13;13}	collision_height={11.5;11.5}	

    Private Sub ImportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportButton.Click

        Dim sImportData As String
        Dim sNpcData As String

        OpenFileDialog.Title = "Select collision table file"
        OpenFileDialog.Filter = "Collision table file|*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sImportData = OpenFileDialog.FileName

        OpenFileDialog.FileName = "npcdata.txt"
        OpenFileDialog.Filter = "Lineage II Server Npc config|npcdata*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sNpcData = OpenFileDialog.FileName

        Dim inFile As System.IO.StreamReader
        Dim aTemp() As String
        Dim sTemp As String
        Dim iTemp As Integer

        ' Loading Collision data
        inFile = New System.IO.StreamReader(sImportData, System.Text.Encoding.Default, True, 1)

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then
                aTemp = sTemp.Split(Chr(9))

                iTemp = NpcId.Length
                Array.Resize(NpcId, iTemp + 1)
                Array.Resize(NpcParam, iTemp + 1)

                '12077	collision_radius={13;13}	collision_height={11.5;11.5}
                NpcId(iTemp - 1) = CInt(aTemp(0))
                If UseFirstCheckBox.Checked = False Then
                    NpcParam(iTemp - 1).Radius = aTemp(1).Replace("collision_radius=", "")
                    NpcParam(iTemp - 1).Height = aTemp(2).Replace("collision_height=", "")
                Else
                    'Required fix only first param
                    NpcParam(iTemp - 1).Radius = aTemp(1).Substring(InStr(aTemp(1), "{"), InStr(aTemp(1), ";") - InStr(aTemp(1), "{") - 1)
                    NpcParam(iTemp - 1).Height = aTemp(2).Substring(InStr(aTemp(2), "{"), InStr(aTemp(2), ";") - InStr(aTemp(2), "{") - 1)
                End If
            End If

        End While
        inFile.Close()
        ToolStripProgressBar.Value = 0

        'UseFirstCheckBox

        ' Fixing current file
        System.IO.File.Copy(sNpcData, sNpcData & ".bak", True)
        inFile = New System.IO.StreamReader(sNpcData & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sNpcData, False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        Dim sTemp2 As String

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then
                aTemp = sTemp.Split(Chr(9))
                'npc_begin      warrior 20761   [pytan] level=69
                iTemp = Array.IndexOf(NpcId, CInt(aTemp(2)))
                If iTemp <> -1 Then

                    If UseFirstCheckBox.Checked = False Then
                        sTemp = Libraries.SetNeedParamToStr(sTemp, "collision_radius", NpcParam(iTemp).Radius)
                        sTemp = Libraries.SetNeedParamToStr(sTemp, "collision_height", NpcParam(iTemp).Height)
                    Else

                        'Required fix only first param
                        '12077	collision_radius={13;13}	collision_height={11.5;11.5}

                        sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "collision_radius")
                        sTemp2 = sTemp2.Substring(InStr(sTemp2, ";"), InStr(sTemp2, "}") - InStr(sTemp2, ";") - 1)
                        If CInt(sTemp2) < CInt(NpcParam(iTemp).Radius) Then
                            sTemp2 = NpcParam(iTemp).Radius
                        End If
                        sTemp2 = "{" & NpcParam(iTemp).Radius & ";" & sTemp2 & "}"
                        sTemp = Libraries.SetNeedParamToStr(sTemp, "collision_radius", sTemp2)

                        sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "collision_height")
                        sTemp2 = sTemp2.Substring(InStr(sTemp2, ";"), InStr(sTemp2, "}") - InStr(sTemp2, ";") - 1)
                        If CInt(sTemp2) < CInt(NpcParam(iTemp).Height) Then
                            sTemp2 = NpcParam(iTemp).Height
                        End If
                        sTemp2 = "{" & NpcParam(iTemp).Height & ";" & sTemp2 & "}"
                        sTemp = Libraries.SetNeedParamToStr(sTemp, "collision_height", sTemp2)

                    End If
                End If
            End If
            outFile.WriteLine(sTemp)

        End While
        inFile.Close()
        outFile.Close()
        ToolStripProgressBar.Value = 0

        MessageBox.Show("Import complete.")

    End Sub

    Private Sub ExportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportButton.Click

        SaveFileDialog.Title = "Enter file name export collision table list"
        SaveFileDialog.Filter = "collision table text file|*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        OpenFileDialog.FileName = "npcdata.txt"
        OpenFileDialog.Filter = "Lineage II Server Npc config|npcdata*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        'sNpcData = OpenFileDialog.FileName

        Dim aTemp() As String
        Dim sTemp As String

        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then
                aTemp = sTemp.Split(Chr(9))
                'npc_begin      warrior 20761   [pytan] level=69
                outFile.Write(aTemp(2) & vbTab)
                outFile.Write("collision_radius=" & Libraries.GetNeedParamFromStr(sTemp, "collision_radius") & vbTab)
                outFile.WriteLine("collision_height=" & Libraries.GetNeedParamFromStr(sTemp, "collision_height") & vbTab)
            End If
            
        End While
        outFile.Close()
        inFile.Close()
        ToolStripProgressBar.Value = 0
        MessageBox.Show("Export complete.")

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

End Class
Public Class ScriptFromDat

    Public Structure ScriptStruct
        Dim Name As String
        Dim Import As String
        Dim DefValue As String
        Dim Symbols As String
        Dim Autoname As String
        Dim Unique As String
    End Structure


    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sCfgFile As String

        Dim sDatFile As String
        Dim sSaveFile As String

        'SaveFileDialog

        OpenFileDialog.InitialDirectory = Application.StartupPath
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "L2ScriptMaker Script Generator config file v2|*.ini"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sCfgFile = OpenFileDialog.FileName

        'OpenFileDialog.InitialDirectory = Application.StartupPath
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II Client Dat text file (..-e.txt)|*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sDatFile = OpenFileDialog.FileName

        'SaveFileDialog.InitialDirectory = Application.StartupPath
        SaveFileDialog.FileName = ""
        SaveFileDialog.Filter = "Lineage II Server Script file|*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sSaveFile = SaveFileDialog.FileName

        Dim sTemp As String
        Dim aParams(0) As ScriptStruct
        Dim aUnique(0) As String

        Dim inFile As New System.IO.StreamReader(sCfgFile, System.Text.Encoding.Default, True, 1)
        If inFile.ReadLine <> "L2ScriptMaker Visual Script Editor config file v2" Then
            MessageBox.Show("Config file incompatible with this module." & vbNewLine & "Required 'L2ScriptMaker Script Generator config file v2'", "Incorrect config", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                ' Name
                If sTemp.StartsWith("[") = True Then
                    aParams(aParams.Length - 1).Name = sTemp.Substring(1, sTemp.Length - 2)
                    Array.Resize(aParams, aParams.Length + 1)
                End If

                If sTemp.StartsWith("import") = True Then
                    aParams(aParams.Length - 2).Import = sTemp.Replace("import", "").Replace("=", "")
                End If

                If sTemp.StartsWith("defvalue") = True Then
                    aParams(aParams.Length - 2).DefValue = sTemp.Replace("defvalue", "").Replace("=", "")
                End If

                If sTemp.StartsWith("symbols") = True Then
                    aParams(aParams.Length - 2).Symbols = sTemp.Replace("symbols", "").Replace("=", "")
                End If

                If sTemp.StartsWith("autogenname") = True Then
                    aParams(aParams.Length - 2).Autoname = sTemp.Replace("autogenname", "").Replace("=", "")
                End If

                If sTemp.StartsWith("unique") = True Then
                    aParams(aParams.Length - 2).Unique = sTemp.Replace("unique", "").Replace("=", "")
                End If

                If sTemp.StartsWith("<") = True Then
                    While inFile.ReadLine.Trim.StartsWith(">") = False
                        ' finding
                    End While
                End If
            End If


        End While
        inFile.Close()


        inFile = New System.IO.StreamReader(sDatFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sSaveFile, False, System.Text.Encoding.Unicode, 1)

        'Dim aTemp() As String
        ' Reading Npcdata-e config...

        'Dim Name As String
        'Dim Import As String
        'Dim DefValue As String
        'Dim Symbols As String

        Dim iTemp As Integer
        Dim sTemp2 As String

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

            For iTemp = 0 To aParams.Length - 1

                If aParams(iTemp).Name <> "" Then
                    outFile.Write(aParams(iTemp).Name & "=")
                End If

                If aParams(iTemp).Import = "" Then
                    If aParams(iTemp).Symbols <> "" Then outFile.Write(aParams(iTemp).Symbols(0))
                    outFile.Write(aParams(iTemp).DefValue)
                    If aParams(iTemp).Symbols <> "" Then outFile.Write(aParams(iTemp).Symbols(1))
                Else
                    sTemp2 = Libraries.GetNeedParamFromStr(sTemp, aParams(iTemp).Import).ToLower
                    If aParams(iTemp).Symbols <> "" Then sTemp2 = sTemp2.Replace(aParams(iTemp).Symbols(0), "").Replace(aParams(iTemp).Symbols(1), "")
                    sTemp2 = sTemp2.Replace(" ", "_").Replace("&", "").Replace(":", "").Replace("(", "").Replace(")", "").Replace("_-_", "_")
                    sTemp2 = sTemp2.Replace("_of_", "_").Replace("_the_", "_").Replace("!", "").Replace(".", "").Replace(",", "")
                    ' Fix for Empty Npc names
                    If sTemp2 = "" Then
                        sTemp2 = "npcid_" & Libraries.GetNeedParamFromStr(sTemp, aParams(iTemp).Autoname).ToLower
                    End If

                    ' Fix for Unique Name
                    If aParams(iTemp).Unique = "on" Then
                        If Array.IndexOf(aUnique, sTemp2) <> -1 Then
                            sTemp2 = sTemp2 & "_" & Libraries.GetNeedParamFromStr(sTemp, aParams(iTemp).Autoname).ToLower
                        End If
                        aUnique(aUnique.Length - 1) = sTemp2
                        Array.Resize(aUnique, aUnique.Length + 1)
                    End If

                    ' Finishing of writing param
                    If aParams(iTemp).Symbols <> "" Then outFile.Write(aParams(iTemp).Symbols(0))
                    outFile.Write(sTemp2)
                    If aParams(iTemp).Symbols <> "" Then outFile.Write(aParams(iTemp).Symbols(1))
                End If

                If iTemp < aParams.Length - 1 Then outFile.Write(vbTab)
            Next
            outFile.Write(vbNewLine)


        End While
        inFile.Close()
        outFile.Close()
        ToolStripProgressBar.Value = 0

        MessageBox.Show("Generation complete", "Complete", MessageBoxButtons.OK)


    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub
End Class
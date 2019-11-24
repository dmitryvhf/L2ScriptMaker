Public Class GeoGetTestPoint

    Private Sub ScanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanButton.Click

        Dim aLogFiles() As String
        Dim sLogPath As String, sBugPath As String

        ToolStripStatusLabel1.Text = "Select folder with server Error log"
        FolderBrowserDialog.SelectedPath = Application.StartupPath
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sLogPath = FolderBrowserDialog.SelectedPath

        ToolStripStatusLabel1.Text = "Select folder for geo_bug files"
        FolderBrowserDialog.SelectedPath = Application.StartupPath
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sBugPath = FolderBrowserDialog.SelectedPath

        aLogFiles = System.IO.Directory.GetFiles(sLogPath, "*.log", IO.SearchOption.AllDirectories)
        If aLogFiles.Length = 0 Then
            MessageBox.Show("No log in selected folder", "No logs", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim inFile As System.IO.StreamReader
        Dim outFile As New System.IO.StreamWriter("L2ScriptMaker_GetTestPoint.log", True, System.Text.Encoding.Unicode, 1)
        outFile.WriteLine("L2ScriptMaker: GetTestPoint Finder and Geodata Bug file gererator.")
        outFile.WriteLine(Now.ToString & " Start processing... ")

        ProgressBar.Maximum = CInt(aLogFiles.Length - 1)
        ProgressBar.Value = 0

        Dim sTemp As String, sBugPoint As String
        Dim aBugPoint(0) As String

        Dim iTemp As Integer
        For iTemp = 0 To aLogFiles.Length - 1

            inFile = New System.IO.StreamReader(aLogFiles(iTemp), System.Text.Encoding.Default, True, 1)

            ProgressBar.Value = iTemp
            ToolStripStatusLabel1.Text = "Scan file: " & System.IO.Path.GetFileName(aLogFiles(iTemp))
            Me.Update()

            While inFile.EndOfStream <> True

                '02/23/2007 14:07:50.140, [.\User.cpp][1157] Invalid(37384,-33800,-3640) GetTestPoint
                sTemp = inFile.ReadLine
                If sTemp.EndsWith(") GetTestPoint") = True Then

                    'debug log
                    outFile.WriteLine(sTemp)

                    ' Substring point
                    sBugPoint = sTemp.Substring(InStr(sTemp, "Invalid(") + 7, InStr(sTemp, ")") - InStr(sTemp, "Invalid(") - 8)
                    If Array.IndexOf(aBugPoint, sBugPoint) = -1 Then
                        aBugPoint(aBugPoint.Length - 1) = sBugPoint
                        Array.Resize(aBugPoint, aBugPoint.Length + 1)
                    End If

                End If

            End While
            inFile.Close()

        Next
        ProgressBar.Value = 0
        ToolStripStatusLabel1.Text = "Scanning complete."
        outFile.Flush()

        Dim outBugFile As System.IO.StreamWriter
        Dim BugX As String, BugY As String
        Dim aTemp() As String

        Array.Sort(aBugPoint, 0, aBugPoint.Length)

        ProgressBar.Maximum = (aBugPoint.Length - 1)
        ProgressBar.Value = 0

        ToolStripStatusLabel1.Text = "Saving xx_xx_bug.txt files..."
        Me.Update()
        For iTemp = 1 To aBugPoint.Length - 1

            aTemp = aBugPoint(iTemp).Split(CChar(","))
            BugX = CStr(Fix(20 + (CInt(aTemp(0)) - CInt(aTemp(0)) \ 32768) / 32768))
            BugY = CStr(Fix(18 + (CInt(aTemp(1)) - CInt(aTemp(1)) \ 32768) / 32768))
            '21_16_bug.txt
            '36304;-37552;-3736

            If System.IO.File.Exists(sBugPath & "\" & BugX & "_" & BugY & "_bug.txt") = True Then
                inFile = New System.IO.StreamReader(sBugPath & "\" & BugX & "_" & BugY & "_bug.txt", System.Text.Encoding.ASCII, True, 1)
                sTemp = inFile.ReadToEnd
                inFile.Close()
                If InStr(sTemp, aBugPoint(iTemp).Replace(",", ";") & vbNewLine) = 0 Then
                    ' Point not found. Write this
                    outBugFile = New System.IO.StreamWriter(sBugPath & "\" & BugX & "_" & BugY & "_bug.txt", True, System.Text.Encoding.ASCII, 1)
                    outBugFile.WriteLine(aBugPoint(iTemp).Replace(",", ";"))
                    outBugFile.Close()
                End If
            Else
                outBugFile = New System.IO.StreamWriter(sBugPath & "\" & BugX & "_" & BugY & "_bug.txt", True, System.Text.Encoding.ASCII, 1)
                outBugFile.WriteLine(aBugPoint(iTemp).Replace(",", ";"))
                outBugFile.Close()
            End If

            ProgressBar.Value = iTemp

        Next

        outFile.WriteLine(Now.ToString & " End of processing... ")
        outFile.Close()
        ProgressBar.Value = 0
        ToolStripStatusLabel1.Text = "Complete."

        MessageBox.Show("Scanning and generating complete. Calculated of " & iTemp - 1 & " points.")

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub
End Class
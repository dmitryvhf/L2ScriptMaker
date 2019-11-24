Public Class HtmlMissedFinder

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim ConfigDir As String, HtmlDir As String = "", NewHtmlDir As String = ""
        Dim HtmlFiles(0) As String
        Dim HtmlMissed(0) As String
        Dim iTemp As Integer
        Dim sTemp As String, sTemp2 As String
        Dim MissCount As Integer = -1

        Dim MakeMissed As System.IO.StreamWriter

        ConfigDir = Application.StartupPath
        FolderBrowserDialog.SelectedPath = ConfigDir

        If CheckedListBox.CheckedItems.Count > 0 Then
            FolderBrowserDialog.SelectedPath = System.Environment.CurrentDirectory
            CurActionLabel.Text = "Select folder with files from checked box..." : CurActionLabel.Update()
            FolderBrowserDialog.Description = "Select folder with files from checked box..."
            If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            ConfigDir = FolderBrowserDialog.SelectedPath
            CurActionLabel.Text = "Loading files to checking..." : CurActionLabel.Update()
            For iTemp = 0 To CheckedListBox.CheckedItems.Count - 1
                If System.IO.File.Exists(ConfigDir & "\" & CStr(CheckedListBox.CheckedItems.Item(iTemp))) = False Then
                    MessageBox.Show("Not found file '" & CStr(CheckedListBox.CheckedItems.Item(iTemp)) & "' to checking", "No file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next
        End If

        CurActionLabel.Text = "Select server 'html' folder..." : CurActionLabel.Update()
        FolderBrowserDialog.Description = "Select server 'html' folder"
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        HtmlDir = FolderBrowserDialog.SelectedPath
        HtmlFiles = System.IO.Directory.GetFiles(HtmlDir, "*.htm", IO.SearchOption.AllDirectories)

        If CreateHtmBox.Checked = True Then
            CurActionLabel.Text = "Select folder where tool will be create missed html file..." : CurActionLabel.Update()
            FolderBrowserDialog.Description = "Select folder where tool will be create missed html file"
            If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            NewHtmlDir = FolderBrowserDialog.SelectedPath
        End If

        If HtmlFiles.Length < 1 Then
            MessageBox.Show("This directory not have Htm files", "No htm files", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        sTemp2 = System.IO.Path.GetDirectoryName(HtmlFiles(0))
        For iTemp = 0 To HtmlFiles.Length - 1
            HtmlFiles(iTemp) = HtmlFiles(iTemp).Replace(sTemp2 & "\", "")
        Next

        Array.Resize(HtmlMissed, HtmlFiles.Length)
        Dim outFile As New System.IO.StreamWriter(ConfigDir + "\l2scriptmaker_html_missed.log", True, System.Text.Encoding.Unicode, 1)

        outFile.WriteLine("L2ScriptMaker: Missed HTML Checker")
        outFile.WriteLine(Now & " Start")

        Me.Update()
        Dim inFile As System.IO.StreamReader

        For iTemp = 0 To CheckedListBox.CheckedItems.Count - 1

            inFile = New System.IO.StreamReader(ConfigDir & "\" & CStr(CheckedListBox.CheckedItems.Item(iTemp)), System.Text.Encoding.Default, True, 1)
            ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
            ProgressBar.Value = 0
            outFile.WriteLine(vbNewLine & "File: " + CStr(CheckedListBox.CheckedItems.Item(iTemp)))
            CurActionLabel.Text = "Checking " & CStr(CheckedListBox.CheckedItems.Item(iTemp)) & " ..."
            Me.Update() 'CurActionLabel.Update()

            Select Case CStr(CheckedListBox.CheckedItems.Item(iTemp))
                Case "ai.obj"           'ai.obj

                    ' AI.obj Checker
                    While inFile.EndOfStream <> True
                        sTemp = inFile.ReadLine
                        ProgressBar.Value = CInt(inFile.BaseStream.Position)

                        If InStr(sTemp, ".htm") <> 0 Then
                            sTemp2 = sTemp.Trim.Remove(0, InStr(sTemp, """") - 1).Replace("""", "")

                            ' Common function for write error
                            If Array.IndexOf(HtmlFiles, sTemp2) = -1 Then
                                If Array.IndexOf(HtmlMissed, sTemp2) = -1 Then
                                    MissCount += 1
                                    HtmlMissed(MissCount) = sTemp2
                                    outFile.WriteLine("Not found html:" & vbTab & sTemp2)
                                    If WriteFullCheckBox.Checked = True Then
                                        outFile.WriteLine("in line:" & vbNewLine & sTemp & vbNewLine)
                                    End If
                                    If CreateHtmBox.Checked = True Then
                                        MakeMissed = New System.IO.StreamWriter(NewHtmlDir & "\" & sTemp2, False, System.Text.Encoding.Unicode, 1)
                                        MakeMissed.WriteLine("<html><head>")
                                        MakeMissed.WriteLine("<body>")
                                        MakeMissed.WriteLine("If you see this message: say to Server Administrator about this message and how you open this dialog.")
                                        MakeMissed.WriteLine("</body></html>")
                                        MakeMissed.Close()
                                    End If
                                Else
                                    If IgnoreMissDupCheckBox.Checked = False Then
                                        outFile.WriteLine("Not found html:" & vbTab & "'" & sTemp2 & "'")
                                        If WriteFullCheckBox.Checked = True Then
                                            outFile.WriteLine("in line:" & vbNewLine & sTemp & vbNewLine)
                                        End If
                                    End If
                                End If
                            End If
                            ' Common function for write error

                        End If

                    End While


                Case "npcdata.txt"      'npcdata.txt

                    ' NPCDATA Checker
                    'npc_ai={[lector];{[fnHi]=[lector001.htm]};{[fnSell]=[lector002.htm]};{[fnBuy]=[lector003.htm]};{[fnUnableItemSell]=[lector005.htm]};{[fnYouAreChaotic]=[lector006.htm]};{[fnNowSiege]=[lector007.htm]};{[MoveAroundSocial]=0};{[MoveAroundSocial1]=110};{[MoveAroundSocial2]=150}}	

                    Dim iTemp2 As Integer
                    Dim aNpcParam(0) As String

                    While inFile.EndOfStream <> True

                        sTemp = inFile.ReadLine
                        ProgressBar.Value = CInt(inFile.BaseStream.Position)
                        Me.Update()
                        sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "npc_ai").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "")

                        Array.Clear(aNpcParam, 0, aNpcParam.Length)
                        aNpcParam = sTemp2.Split(CChar(";"))

                        For iTemp2 = 0 To aNpcParam.Length - 1
                            If InStr(aNpcParam(iTemp2), ".htm") <> 0 Then
                                aNpcParam(iTemp2) = aNpcParam(iTemp2).Remove(0, InStr(aNpcParam(iTemp2), "=")).Replace("""", "")

                                sTemp2 = aNpcParam(iTemp2)
                                ' Common function for write error
                                If Array.IndexOf(HtmlFiles, sTemp2) = -1 Then
                                    If Array.IndexOf(HtmlMissed, sTemp2) = -1 Then
                                        MissCount += 1
                                        HtmlMissed(MissCount) = sTemp2
                                        outFile.WriteLine("Not found html:" & vbTab & sTemp2)
                                        If WriteFullCheckBox.Checked = True Then
                                            outFile.WriteLine("in line:" & vbNewLine & sTemp & vbNewLine)
                                        End If
                                        If CreateHtmBox.Checked = True Then
                                            MakeMissed = New System.IO.StreamWriter(NewHtmlDir & "\" & sTemp2, False, System.Text.Encoding.Unicode, 1)
                                            MakeMissed.WriteLine("<html><head>")
                                            MakeMissed.WriteLine("<body>")
                                            MakeMissed.WriteLine("If you see this message: say to Server Administrator about this message and how you open this dialog.")
                                            MakeMissed.WriteLine("</body></html>")
                                            MakeMissed.Close()
                                        End If
                                    Else
                                        If IgnoreMissDupCheckBox.Checked = False Then
                                            outFile.WriteLine("Not found html:" & vbTab & "'" & sTemp2 & "'")
                                            If WriteFullCheckBox.Checked = True Then
                                                outFile.WriteLine("in line:" & vbNewLine & sTemp & vbNewLine)
                                            End If
                                        End If
                                    End If
                                End If
                                ' Common function for write error

                            End If
                        Next



                    End While

                Case "itemdata.txt"     'itemdata.txt

                    ' ITEMDATA Checker
                    '....enchanted=0	html=[item_default.htm]	equip_pet={0}...
                    While inFile.EndOfStream <> True
                        sTemp = inFile.ReadLine
                        ProgressBar.Value = CInt(inFile.BaseStream.Position)
                        Me.Update()
                        sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "html").Replace("[", "").Replace("]", "")

                        If sTemp2 <> "" Then

                            ' Common function for write error
                            If Array.IndexOf(HtmlFiles, sTemp2) = -1 Then
                                If Array.IndexOf(HtmlMissed, sTemp2) = -1 Then
                                    MissCount += 1
                                    HtmlMissed(MissCount) = sTemp2
                                    outFile.WriteLine("Not found html:" & vbTab & sTemp2)
                                    If WriteFullCheckBox.Checked = True Then
                                        outFile.WriteLine("in line:" & vbNewLine & sTemp & vbNewLine)
                                    End If
                                    If CreateHtmBox.Checked = True Then
                                        MakeMissed = New System.IO.StreamWriter(NewHtmlDir & "\" & sTemp2, False, System.Text.Encoding.Unicode, 1)
                                        MakeMissed.WriteLine("<html><head>")
                                        MakeMissed.WriteLine("<body>")
                                        MakeMissed.WriteLine("If you see this message: say to Server Administrator about this message and how you open this dialog.")
                                        MakeMissed.WriteLine("</body></html>")
                                        MakeMissed.Close()
                                    End If
                                Else
                                    If IgnoreMissDupCheckBox.Checked = False Then
                                        outFile.WriteLine("Not found html:" & vbTab & "'" & sTemp2 & "'")
                                        If WriteFullCheckBox.Checked = True Then
                                            outFile.WriteLine("in line:" & vbNewLine & sTemp & vbNewLine)
                                        End If
                                    End If
                                End If
                            End If
                            ' Common function for write error

                        End If

                    End While

            End Select

            inFile.Close()
            Me.Refresh()

        Next

        ' HTML folder checker
        '<font color="LEVEL">harbor</font>.<br><a action="link abel002.htm">Ask abo
        If HtmlDirCheckBox.Checked = True Then

            Dim Pos1 As Integer, Pos2 As Integer
            outFile.WriteLine(vbNewLine & "File: HTML folder ...")
            CurActionLabel.Text = "Checking HTML folder ..."
            Me.Update()

            ProgressBar.Maximum = HtmlFiles.Length - 1
            ProgressBar.Value = 0

            For iTemp = 0 To HtmlFiles.Length - 1

                inFile = New System.IO.StreamReader(HtmlDir & "\" & HtmlFiles(iTemp), System.Text.Encoding.Default, True, 1)
                ProgressBar.Value = iTemp

                While inFile.EndOfStream <> True
                    'sTemp = inFile.ReadLine

                    sTemp = inFile.ReadToEnd

                    'Pos1 = InStr(1, sTemp, "<a action=")
                    Pos1 = InStr(1, sTemp, """link ")
                    While Pos1 > 0
                        Pos2 = InStr(Pos1 + 1, sTemp, """")
                        If Pos2 = 0 Then
                            outFile.WriteLine("HTML parser found error in file: " & HtmlFiles(iTemp) & vbNewLine)
                            Exit While
                        End If
                        sTemp2 = Mid(sTemp, Pos1 + 6, Pos2 - Pos1 - 6) '.Trim

                        If InStr(sTemp2, "#") <> 0 Then
                            sTemp2 = sTemp2.Remove(InStr(sTemp2, "#") - 1, sTemp2.Length - InStr(sTemp2, "#") + 1)
                        End If

                        If InStr(sTemp2, "tutorial_close_") <> 0 Then
                            sTemp2 = ""
                        End If

                        ' Common function for write error
                        If Array.IndexOf(HtmlFiles, sTemp2) = -1 And sTemp2 <> "" Then
                            If Array.IndexOf(HtmlMissed, sTemp2) = -1 Then
                                MissCount += 1
                                HtmlMissed(MissCount) = sTemp2
                                outFile.WriteLine("Not found html:" & vbTab & "'" & sTemp2 & "'" & vbTab & "in html file: " & HtmlFiles(iTemp))
                                'outFile.WriteLine("Not found html:" & vbTab & sTemp2)
                                'outFile.WriteLine("in html file:" & vbTab & HtmlFiles(iTemp) & vbNewLine)
                                If CreateHtmBox.Checked = True Then
                                    Try
                                        MakeMissed = New System.IO.StreamWriter(NewHtmlDir & "\" & sTemp2, False, System.Text.Encoding.Unicode, 1)
                                        MakeMissed.WriteLine("<html><head>")
                                        MakeMissed.WriteLine("<body>")
                                        MakeMissed.WriteLine("If you see this message: say to Server Administrator about this message and how you open this dialog.")
                                        MakeMissed.WriteLine("</body></html>")
                                        MakeMissed.Close()
                                    Catch ex As Exception
                                        outFile.WriteLine("HTML parser found bad html file name: " & HtmlFiles(iTemp))
                                        Exit While
                                    End Try
                                End If
                            Else
                                If IgnoreMissDupCheckBox.Checked = False Then
                                    outFile.WriteLine("Not found html:" & vbTab & "'" & sTemp2 & "'" & vbTab & "in html file: " & HtmlFiles(iTemp))
                                    'outFile.WriteLine("in html file:" & vbTab & HtmlFiles(iTemp) & vbNewLine)
                                End If
                            End If
                        End If
                        ' Common function for write error

                        Pos1 = InStr(Pos2, sTemp, """link ")
                    End While
                    Pos1 = 0 : Pos2 = 0


                End While
                inFile.Close()

            Next
        End If

        outFile.WriteLine(vbNewLine & "Missed:" & vbTab & MissCount + 1)
        outFile.WriteLine(vbNewLine & Now & " End of checking." & vbNewLine)
        outFile.Close()
        ProgressBar.Value = 0
        CurActionLabel.Text = "Complete."
        MessageBox.Show("Checking complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub
End Class
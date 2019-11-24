Public Class ScriptExchanger

    Dim ItemPch(25000) As String
    Dim NpcPch(25000) As String
    Dim SkillPch(3000000) As String
    Dim PchStat As Boolean = False
    Dim TempStr As String = ""

    Dim ArrNameTemp(50) As String

    Private Function StringSplitter(ByVal TempStr As String) As Integer

        Dim iTemp As Integer, Pos1 As Integer, Pos2 As Integer, ArrAmount As Integer = 0
        Array.Resize(ArrNameTemp, 0)
        Array.Clear(ArrNameTemp, 0, ArrNameTemp.Length)

        For iTemp = 1 To TempStr.Length
            'find item and npc

            If InStr(iTemp, TempStr, "[") <> 0 Then
                ' work with item or npc
                Pos1 = InStr(iTemp, TempStr, "[")
                If Pos1 = 0 Then Exit For
                Dim SearchArr() As Char = {Chr(93)}
                Pos2 = TempStr.IndexOf(SearchArr, Pos1) + 1
                'Pos2 = InStr(Pos1, TempStr, "]")
                If Pos2 < Pos1 Then
                    MessageBox.Show("No dual []. Check config", "Dual [] error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                End If
            Else : Exit For
            End If

            ' ~ - check for ai=[~....]
            If Pos2 > Pos1 + 1 And InStr(Mid(TempStr, Pos1 + 1, Pos2 - Pos1 - 1), "~") = 0 Then
                If Array.IndexOf(ArrNameTemp, Mid(TempStr, Pos1, Pos2 - Pos1 + 1)) = -1 Then
                    ArrAmount += 1
                    Array.Resize(ArrNameTemp, ArrAmount + 1)
                    ArrNameTemp(ArrAmount) = Mid(TempStr, Pos1, Pos2 - Pos1 + 1)
                    If ArrNameTemp(ArrAmount) = Nothing Then ArrAmount -= 1
                End If
            End If
            iTemp = Pos2


        Next

        'Pos1 = 0 : Pos2 = 0
        ' search skills
        For iTemp = 1 To TempStr.Length
            'find item and npc

            If InStr(iTemp, TempStr, "@") <> 0 Then
                ' work with item or npc
                Pos1 = InStr(iTemp, TempStr, "@")
                If Pos1 = 0 Then Exit For
                Dim SearchArr() As Char = {Chr(91), Chr(59), Chr(125)} ' ];}
                Pos2 = TempStr.IndexOfAny(SearchArr, Pos1) + 1
            Else : Exit For
            End If

            If Pos2 > Pos1 + 1 Then 'And InStr(TempStr, "clan=") > Pos1 Then
                If Array.IndexOf(ArrNameTemp, Mid(TempStr, Pos1 + 1, Pos2 - Pos1 - 1)) = -1 Then
                    ArrAmount += 1
                    Array.Resize(ArrNameTemp, ArrAmount + 1)
                    ArrNameTemp(ArrAmount) = Mid(TempStr, Pos1 + 1, Pos2 - Pos1 - 1)
                End If
            End If
            iTemp = Pos2
        Next

        Return ArrAmount
    End Function

    Private Function PchLoader() As Short
        ' Loading all items

        FilePos.Value = 0
        StatusBox.Text = ""

        Dim WorkDir As String = ""
        FolderBrowserDialog.SelectedPath = System.IO.Directory.GetCurrentDirectory
        FolderBrowserDialog.Description = "Select folder have item/npc/skill -_pch files"
        If FolderBrowserDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            WorkDir = FolderBrowserDialog.SelectedPath
        Else
            Return -1
        End If

        If System.IO.File.Exists(WorkDir & "\item_pch.txt") = False Or _
            System.IO.File.Exists(WorkDir & "\npc_pch.txt") = False Or _
            System.IO.File.Exists(WorkDir & "\skill_pch.txt") = False Then
            MessageBox.Show("Need Pch files not exist. Check files in folder", "No PCH in folder", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If

        Array.Clear(ItemPch, 0, ItemPch.Length)
        Array.Clear(NpcPch, 0, NpcPch.Length)
        Array.Clear(SkillPch, 0, SkillPch.Length)

        Dim outLog As New System.IO.StreamWriter(WorkDir & "\ScriptExchanger.log", True, System.Text.Encoding.Unicode, 1)
        outLog.WriteLine(vbNewLine & Now & vbTab & "ScriptExchanger PCH data duplicate checker..." & vbNewLine)
        Dim ErrMsg As String

        Dim FilePch As New System.IO.StreamReader(WorkDir & "\item_pch.txt")
        Dim TempStr2(2) As String
        FilePos.Maximum = CInt(FilePch.BaseStream.Length)
        While FilePch.EndOfStream <> True

            TempStr = FilePch.ReadLine
            If InStr(TempStr, "//") = 0 And Trim(TempStr) <> Nothing And InStr(TempStr, "set_begin") = 0 Then
                TempStr = Replace(TempStr, " ", "")
                TempStr = Replace(TempStr, Chr(9), "")
                TempStr2 = TempStr.Split(Chr(61)) ' =

                If ItemPch.Length < CInt(TempStr2(1)) Then
                    Array.Resize(ItemPch, CInt(TempStr2(1)) + 1)
                End If
                If DuplicateCheckBox.Checked = True Then
                    If Array.IndexOf(ItemPch, (TempStr2(0))) >= 0 Then
                        ErrMsg = "Duplicate ItemData name: " & TempStr2(0) & " ID: " & TempStr2(1)
                        outLog.WriteLine(ErrMsg)
                        If DoIgnore.Checked = False Then
                            MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            FilePch.Close()
                            outLog.Close()
                            Exit Function
                        End If
                    End If
                    If ItemPch(CInt(TempStr2(1))) <> "" Then
                        ErrMsg = "Duplicate ItemData ID: " & TempStr2(1)
                        outLog.WriteLine(ErrMsg)
                        If DoIgnore.Checked = False Then
                            MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            FilePch.Close()
                            outLog.Close()
                            Exit Function
                        End If
                    End If
                End If
                ItemPch(CInt(TempStr2(1))) = TempStr2(0)

            End If
            FilePos.Value = CInt(FilePch.BaseStream.Position)
            Me.Update()
        End While
        StatusBox.Text += "Item Id's imported." & vbNewLine
        Me.Update()
        FilePch.Close()
        Array.Clear(TempStr2, 0, TempStr2.Length)

        ' Loading all items
        FilePos.Value = 0
        FilePch = New System.IO.StreamReader(WorkDir & "\npc_pch.txt")
        FilePos.Maximum = CInt(FilePch.BaseStream.Length)
        While FilePch.EndOfStream <> True
            TempStr = Trim(FilePch.ReadLine)
            TempStr = Replace(TempStr, " ", "")
            TempStr = Replace(TempStr, Chr(9), "")
            TempStr2 = TempStr.Split(Chr(61)) ' =

            If NpcPch.Length < (CInt(TempStr2(1)) - 1000000) Then
                Array.Resize(NpcPch, (CInt(TempStr2(1)) - 1000000) + 1)
            End If
            If DuplicateCheckBox.Checked = True Then
                If Array.IndexOf(NpcPch, (CInt(TempStr2(1)) - 1000000)) >= 0 Then
                    ErrMsg = "Duplicate NpcData name: " & TempStr2(0) & " ID: " & (CInt(TempStr2(1)) - 1000000)
                    outLog.WriteLine(ErrMsg)
                    If DoIgnore.Checked = False Then
                        MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        FilePch.Close()
                        outLog.Close()
                        Exit Function
                    End If
                End If
                If NpcPch(CInt(TempStr2(1)) - 1000000) <> "" Then
                    ErrMsg = "Duplicate NpcData ID: "(CInt(TempStr2(1)) - 1000000)
                    outLog.WriteLine(ErrMsg)
                    If DoIgnore.Checked = False Then
                        MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        FilePch.Close()
                        outLog.Close()
                        Exit Function
                    End If
                End If
            End If
            NpcPch(CInt(TempStr2(1)) - 1000000) = TempStr2(0)

            FilePos.Value = CInt(FilePch.BaseStream.Position)
            Me.Update()
        End While
        StatusBox.Text += "Npc Id's imported." & vbNewLine
        Me.Update()
        FilePch.Close()
        Array.Clear(TempStr2, 0, TempStr2.Length)

        ' Loading all skills
        FilePos.Value = 0
        FilePch = New System.IO.StreamReader(WorkDir & "\skill_pch.txt")
        FilePos.Maximum = CInt(FilePch.BaseStream.Length)
        Dim SkillArrMarker As Integer = 0
        While FilePch.EndOfStream <> True
            TempStr = FilePch.ReadLine
            TempStr = Replace(TempStr, " ", "")
            TempStr = Replace(TempStr, Chr(9), "")
            TempStr2 = TempStr.Split(Chr(61)) ' =
            SkillArrMarker += 1

            If SkillPch.Length < CInt(TempStr2(1)) Then
                Array.Resize(SkillPch, CInt(TempStr2(1)) + 1)
            End If
            If DuplicateCheckBox.Checked = True Then
                If Array.IndexOf(SkillPch, (TempStr2(0))) >= 0 Then
                    ErrMsg = "Duplicate SkillData name: " & TempStr2(0) & " ID: " & TempStr2(1)
                    outLog.WriteLine(ErrMsg)
                    If DoIgnore.Checked = False Then
                        MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        FilePch.Close()
                        outLog.Close()
                        Exit Function
                    End If
                End If
                If SkillPch(CInt(TempStr2(1))) <> "" Then
                    ErrMsg = "Duplicate SkillData ID: " & TempStr2(1)
                    outLog.WriteLine(ErrMsg)
                    If DoIgnore.Checked = False Then
                        MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        FilePch.Close()
                        outLog.Close()
                        Exit Function
                    End If
                End If
            End If
            SkillPch(CInt(TempStr2(1))) = TempStr2(0)

            FilePos.Value = CInt(FilePch.BaseStream.Position)
            Me.Update()
        End While
        StatusBox.Text += "Skill Id's imported." & vbNewLine
        Me.Update()
        Array.Clear(TempStr2, 0, TempStr2.Length)
        FilePch.Close()
        outLog.WriteLine(vbNewLine & Now & vbTab & "ScriptExchanger PCH data duplicate checker finished." & vbNewLine)
        outLog.Close()

        'MessageBox.Show("All source id's loaded.")
        FilePos.Value = 0

        PchStat = True : PchLoader = 0
    End Function

    Private Sub ButtonImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImport.Click

        If PchStat = False Then
            MessageBox.Show("It is necessary to load identifiers (ID) all over again", "ID's not loaded", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If

        Dim SourceFile As String = ""
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II script file|*.txt|All files|*.*"
        OpenFileDialog.Title = "Select folder have item/npc/skill -data file for encoding"
        If OpenFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            SourceFile = OpenFileDialog.FileName
        Else
            Exit Sub
        End If

        Dim FilePch As New System.IO.StreamReader(SourceFile)
        FilePos.Maximum = CInt(FilePch.BaseStream.Length)
        Dim WorkFile As New System.IO.StreamWriter(SourceFile & ".id.txt", False, System.Text.Encoding.Unicode, 1)

        TimeStart.Text = Now.ToString
        TimeEnd.Text = ""

        While FilePch.EndOfStream <> True
            TempStr = FilePch.ReadLine
            If Mid(TempStr, 1, 2) <> "//" And Trim(TempStr) <> Nothing Then

                TempStr = TempStr.Replace("npc_ai={[", "npc_ai={[~")
                StringSplitter(TempStr)
                FilePos.Value = CInt(FilePch.BaseStream.Position)
                StatusBox.Text = TempStr
                Me.Update()


                Dim iTemp As Integer
                For iTemp = 1 To ArrNameTemp.Length - 1

                    Me.Update()

                    ' what is it - item, npc, skill
                    If DoItem.Checked = True Then
                        If Array.LastIndexOf(ItemPch, ArrNameTemp(iTemp)) <> -1 Then
                            ' this item
                            TempStr = TempStr.Replace(ArrNameTemp(iTemp), "[%i" & Array.LastIndexOf(ItemPch, ArrNameTemp(iTemp)).ToString & "%]")
                        End If
                    End If

                    If DoNpc.Checked = True Then
                        If Array.LastIndexOf(NpcPch, ArrNameTemp(iTemp)) <> -1 Then
                            ' this npc
                            TempStr = TempStr.Replace(ArrNameTemp(iTemp), "[%n" & Array.LastIndexOf(NpcPch, ArrNameTemp(iTemp)).ToString & "%]")
                        End If
                    End If

                    If DoSkill.Checked = True Then
                        If IsSkillAquire.SelectedIndex = 0 Then ' Is anothers scripts
                            If Array.IndexOf(SkillPch, ArrNameTemp(iTemp)) <> -1 Then
                                ' this item
                                TempStr = TempStr.Replace(ArrNameTemp(iTemp), "[%s" & Array.IndexOf(SkillPch, ArrNameTemp(iTemp)).ToString & "%]")
                                TempStr = TempStr.Replace("@" & ArrNameTemp(iTemp), "%s" & Array.LastIndexOf(SkillPch, "[" & ArrNameTemp(iTemp) & "]").ToString & "%")
                            End If
                        ElseIf IsSkillAquire.SelectedIndex = 1 Then ' Is Skilldata
                            If Array.LastIndexOf(SkillPch, "[" + ArrNameTemp(iTemp) + "]") <> -1 Then
                                ' this item
                                TempStr = TempStr.Replace("@" & ArrNameTemp(iTemp), "%s" & Array.LastIndexOf(SkillPch, "[" & ArrNameTemp(iTemp) & "]").ToString & "%")
                            End If
                        End If
                    End If

                Next
                TempStr = TempStr.Replace("npc_ai={[~", "npc_ai={[")
            End If
            WorkFile.WriteLine(TempStr)
            WorkFile.Flush()

        End While

        WorkFile.Close()
        FilePch.Close()
        TimeEnd.Text = Now.ToString

        MessageBox.Show("Import done. Your friend perfect!", "Import finish", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ButtonExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExport.Click

        If PchStat = False Then
            MessageBox.Show("It is necessary to load identifiers (ID) all over again", "ID's not loaded", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If

        Dim IgnoreStat As Boolean = False

        Dim SourceFile As String = ""
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II ID script file|*.id.txt|All files|*.*"
        OpenFileDialog.Title = "Select folder have item/npc/skill -data file for decoding"
        If OpenFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            SourceFile = OpenFileDialog.FileName
        Else
            Exit Sub
        End If

        Dim FilePch As New System.IO.StreamReader(SourceFile)
        FilePos.Maximum = CInt(FilePch.BaseStream.Length)
        SourceFile = System.IO.Path.GetFileName(SourceFile)
        Dim WorkFile As New System.IO.StreamWriter(Mid(SourceFile, 1, SourceFile.Length - 3) & "new.txt", False, System.Text.Encoding.Unicode, 1)

        TimeStart.Text = Now.ToString
        TimeEnd.Text = ""

        Dim TempStr As String
        Dim iTemp As Integer, Pos1 As Integer, Pos2 As Integer
        Dim NewVar As String

        While FilePch.EndOfStream <> True

            TempStr = FilePch.ReadLine
            StatusBox.Text = TempStr
            iTemp = 1
            Me.Update()

            While InStr(iTemp, TempStr, "[%") <> 0

                ' work with item or npc
                Pos1 = InStr(iTemp, TempStr, "[%") + 1
                'If Pos1 = 0 Then Exit For
                Pos2 = InStr(Pos1 + 1, TempStr, "%]")
                NewVar = Mid(TempStr, Pos1 + 1, Pos2 - Pos1 - 1)

                FilePos.Value = CInt(FilePch.BaseStream.Position)
                Me.Update()

                If Pos2 > Pos1 + 1 Then
                    ' what is it - item, npc, skill
                    If DoItem.Checked = True Then
                        If InStr(NewVar, "i") <> 0 Then
                            ' this item
                            NewVar = Mid(NewVar, 2, NewVar.Length - 1)
                            Try
                                If ItemPch(CInt(NewVar)) <> "" Then
                                    TempStr = TempStr.Replace("[%i" & NewVar & "%]", ItemPch(CInt(NewVar)))
                                Else
                                    Error 1
                                End If
                            Catch ex As Exception
                                'If ex.Message = "Index was outside the bounds of the array." Then
                                IgnoreStat = True
                                If DoIgnore.Checked <> True Then
                                    MessageBox.Show("Your itemdata no have new items.", "unknown id's", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    GoTo ExportEnd
                                Else
                                    iTemp = InStr(1, TempStr, "%i" & NewVar.ToString & "%") + NewVar.ToString.Length + 3
                                End If
                                'End If
                            End Try
                        End If
                    End If
                    If DoNpc.Checked = True Then
                        If InStr(NewVar, "n") <> 0 Then
                            ' this item
                            NewVar = Mid(NewVar, 2, NewVar.Length - 1)
                            Try
                                If NpcPch(CInt(NewVar)) <> "" Then
                                    TempStr = TempStr.Replace("[%n" & NewVar & "%]", NpcPch(CInt(NewVar)))
                                Else
                                    Error 1
                                End If
                            Catch ex As Exception
                                'If ex.Message = "Index was outside the bounds of the array." Then
                                IgnoreStat = True
                                If DoIgnore.Checked <> True Then
                                    MessageBox.Show("Your npcdata no have new items.", "unknown id's", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    GoTo ExportEnd
                                Else
                                    iTemp = InStr(1, TempStr, "%" & NewVar.ToString & "%") + NewVar.ToString.Length
                                End If
                                'End If
                            End Try
                        End If
                    End If
                    If DoSkill.Checked = True Then
                        If InStr(NewVar, "s") <> 0 Then
                            ' this item
                            NewVar = Mid(NewVar, 2, NewVar.Length - 1)
                            Try
                                If SkillPch(CInt(NewVar)) <> "" Then
                                    Dim NewScill As String = ""
                                    NewScill = Replace(SkillPch(CInt(NewVar)), "[", "")
                                    NewScill = Replace(NewScill, "]", "")
                                    TempStr = TempStr.Replace("%s" & NewVar & "%", NewScill)
                                Else
                                    Error 1
                                End If
                            Catch ex As Exception
                                'If ex.Message = "Index was outside the bounds of the array." Then
                                IgnoreStat = True
                                If DoIgnore.Checked <> True Then
                                    MessageBox.Show("Your skilldata no have new items.", "unknown id's", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    GoTo ExportEnd
                                Else
                                    iTemp = InStr(1, TempStr, "%" & NewVar.ToString & "%") + NewVar.ToString.Length
                                End If
                                'End If
                            End Try
                        End If
                    End If

                End If
                iTemp = Pos2 + 1
            End While
            WorkFile.WriteLine(TempStr)
        End While

ExportEnd:

        If IgnoreStat = False Then
            MessageBox.Show("Export done. Your friend perfect!", "Export finish", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Export done. Finish file have error's, because you use ignore feature. ", "Export finish", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        FilePch.Close()
        WorkFile.Close()
        TimeEnd.Text = Now.ToString


    End Sub

    Private Sub ButtonLoadItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoadItem.Click
        PchLoader()
    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Close()
    End Sub

    Private Sub ScriptExchanger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FilePos.Value = 0
    End Sub

End Class
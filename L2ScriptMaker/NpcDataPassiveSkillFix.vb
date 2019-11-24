Public Class NpcDataPassiveSkillFix

    'npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
    'npcgrp.txt:	property_list={4298;4278;4333}
    '[s_power_strike11]	=	769

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim NpcGrpFile As String        ' Name/path of npcgrp.txt file
        Dim aNpcSkill(30000) As String   ' Skilllist on each mob from npcgrp.txt file
        Dim SkillPchFile As String        ' Name/path of skillpch.txt file
        Dim aSkillPch(10000) As String   ' Skilllist on each mob from npcgrp.txt file
        Dim NpcDataFile As String        ' Name/path of npcgrp.txt file

        Dim TempStr As String, TempStr2 As String
        Dim TempData() As String
        Dim iTemp As Integer


        OpenFileDialog.Filter = "Lineage client text file (npcgrp.txt)|npcgrp.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        NpcGrpFile = OpenFileDialog.FileName

        OpenFileDialog.Filter = "Lineage server script file (skill_pch.txt)|skill_pch.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        SkillPchFile = OpenFileDialog.FileName

        OpenFileDialog.Filter = "Lineage server script file (npcdata.txt)|npcdata.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        NpcDataFile = OpenFileDialog.FileName

        ' ---- Loading NpcSkills ---- 
        Dim iNpcGrpFile As New System.IO.StreamReader(NpcGrpFile, System.Text.Encoding.Default, True)
        ProgressBar.Maximum = CInt(iNpcGrpFile.BaseStream.Length)
        ProgressBar.Value = 0
        While iNpcGrpFile.EndOfStream <> True

            TempStr = iNpcGrpFile.ReadLine
            If TempStr <> Nothing And TempStr.StartsWith("//") = False Then
                TempStr2 = Libraries.GetNeedParamFromStr(TempStr, "property_list")
                If TempStr2 <> "{0}" Then
                    aNpcSkill(CInt(Libraries.GetNeedParamFromStr(TempStr, "npc_id"))) = Libraries.GetNeedParamFromStr(TempStr, "property_list").Replace("{", "").Replace("}", "")
                End If
            End If
            ProgressBar.Value = CInt(iNpcGrpFile.BaseStream.Position * 100 / iNpcGrpFile.BaseStream.Length)
            Me.Update()

        End While
        iNpcGrpFile.Close()
        ProgressBar.Value = 0
        ' End of Loading NpcSkills

        ' ---- Loading Skills ---- 
        '[s_power_strike11]	=	769
        Dim iSkillPchFile As New System.IO.StreamReader(SkillPchFile, System.Text.Encoding.Default, True)
        ProgressBar.Maximum = CInt(iSkillPchFile.BaseStream.Length)
        ProgressBar.Value = 0
        While iSkillPchFile.EndOfStream <> True

            TempStr = Replace(iSkillPchFile.ReadLine, Chr(9), " ")
            If TempStr <> Nothing And TempStr.StartsWith("//") = False Then

                ' tabs and spaces correction
                TempStr = Replace(TempStr, " ", "")
                TempData = TempStr.Split(CChar("="))

                iTemp = CInt(Fix(CInt(TempData(1)) / 256))
                If iTemp > aSkillPch.Length Then
                    Array.Resize(aSkillPch, iTemp)
                End If

                'Fix with LvlSklBox
                If LvlSklBox.Checked = True And aSkillPch(iTemp) <> Nothing Then
                    aSkillPch(iTemp) = ClearDigit(aSkillPch(iTemp))
                Else
                    aSkillPch(iTemp) = TempData(0).Replace("[", "").Replace("]", "")
                End If

            End If
            ProgressBar.Value = CInt(iSkillPchFile.BaseStream.Position * 100 / iSkillPchFile.BaseStream.Length)
            Me.Update()

        End While
        iSkillPchFile.Close()
        ProgressBar.Value = 0
        ' End of Loading Skills

        ' ---- Main module ----

        Dim iNpcDataFile As New System.IO.StreamReader(NpcDataFile, System.Text.Encoding.Default, True)
        Dim oNpcDataFile As New System.IO.StreamWriter(NpcDataFile & ".fixed.txt", False, System.Text.Encoding.Unicode, 1)
        Dim outFile As New System.IO.StreamWriter(NpcDataFile + "_scriptCheck.log", True, System.Text.Encoding.Unicode, 1)

        ProgressBar.Maximum = CInt(iNpcDataFile.BaseStream.Length)
        ProgressBar.Value = 0

        'npc_begin	warrior	1	[gremlin]	level=1
        'npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
        'npcgrp.txt:	property_list={4298;4278;4333}  aNpcSkill
        'aSkillPch

        Dim NpcId As Integer
        Dim OldSkillList As String, NewSkillList As String
        Dim aOldSkill() As String = {}
        Dim aNewSkill() As String = {}

        outFile.WriteLine(vbNewLine & "L2ScriptMaker. Npcdata skill_list fixer.")
        outFile.WriteLine(Now & " Start" & vbNewLine)

        While iNpcDataFile.EndOfStream <> True

            TempStr = Replace(iNpcDataFile.ReadLine, Chr(9), " ")
            If TempStr <> Nothing And TempStr.StartsWith("//") = False Then

                ' tabs and spaces correction
                While InStr(TempStr, "  ") <> 0
                    TempStr = Replace(TempStr, "  ", " ")
                End While
                TempData = TempStr.Split(Chr(32))

                'Preparing
                Array.Clear(aNewSkill, 0, aNewSkill.Length)
                Array.Clear(aOldSkill, 0, aOldSkill.Length)
                OldSkillList = "" : NewSkillList = ""

                NpcId = CInt(TempData(2))

                OldSkillList = Libraries.GetNeedParamFromStr(TempStr, "skill_list")

                If aNpcSkill(NpcId) <> Nothing Then

                    aNewSkill = aNpcSkill(NpcId).Split(CChar(";"))

                    NewSkillList = "{"
                    For iTemp = 0 To aNewSkill.Length - 1
                        'npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
                        If iTemp > 0 And iTemp <= (aNewSkill.Length - 1) Then
                            NewSkillList += ";"
                        End If

                        ' ----- Fix with LvlSklBox ----
                        Dim sTemp1 As String = ""
                        If LvlSklBox.Checked = True Then
                            aOldSkill = OldSkillList.Replace("{", "").Replace("}", "").Replace("@", "").Split(CChar(";"))

                            Dim iTemp1 As Integer, iTemp2 As Integer
                            iTemp1 = CInt(aNewSkill(iTemp))
                            sTemp1 = ClearDigit(aSkillPch(iTemp1))
                            For iTemp2 = 0 To aOldSkill.Length - 1
                                If InStr(aOldSkill(iTemp2), sTemp1) <> 0 Then
                                    sTemp1 = aOldSkill(iTemp2)
                                    Exit For
                                End If
                            Next
                        Else
                            sTemp1 = aSkillPch(CInt(aNewSkill(iTemp)))
                        End If
                        '---- end of fix ---------

                        NewSkillList += "@" & sTemp1

                    Next
                    NewSkillList += "}"

                Else
                    NewSkillList = "{}"
                End If

                ' ---- @s_full_magic_defence fix ----
                If SFullMagicDefBox.Checked = True Then
                    For iTemp = 0 To SkillIgnorListBox.Lines.Length - 1
                        If OldSkillList.Contains(SkillIgnorListBox.Lines(iTemp)) = True And NewSkillList.Contains(SkillIgnorListBox.Lines(iTemp)) = False Then

                            ' fix for s_npc_high_level_1 and s_npc_high_level_10
                            If (iTemp = SkillIgnorListBox.Lines.Length - 1) And OldSkillList.Contains("@s_npc_high_level_10") = True Then
                                Exit For
                            End If

                            If NewSkillList <> "{}" Then NewSkillList = NewSkillList.Replace("}", ";}")
                            NewSkillList = NewSkillList.Replace("}", SkillIgnorListBox.Lines(iTemp) & "}")
                        End If
                    Next
                End If
                ' end of @s_full_magic_defence fix

                If OldSkillList <> NewSkillList Then
                    TempStr = TempStr.Replace(OldSkillList, NewSkillList).Replace(Chr(32), Chr(9))
                    outFile.WriteLine("Fixing npc: " & TempData(0) & vbTab & TempData(1) & vbTab & TempData(2) & vbTab & TempData(3))
                    outFile.WriteLine(OldSkillList & vbNewLine & "-->" & vbNewLine & NewSkillList & vbNewLine)
                End If

            End If
            TempStr = TempStr.Replace(Chr(32), Chr(9))
            oNpcDataFile.WriteLine(TempStr)

            ProgressBar.Value = CInt(iNpcDataFile.BaseStream.Position)
            ProgressBar.Update()

        End While

        outFile.WriteLine(Now & " End")
        outFile.Close()
        oNpcDataFile.Close()
        ProgressBar.Value = 0

        MessageBox.Show("Done.")


    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Function ClearDigit(ByRef Name As String) As String

        'ClearDigit = Name.Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("0", "")
        'Dim cTemp() As Char = {CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("7"), CChar("8"), CChar("9"), CChar("0")}
        Dim iTemp As Integer
        For itemp = Name.Length - 1 To 0 Step -1
            If Char.IsDigit(Name(itemp)) = True Then
                Name = Name.Remove(iTemp, 1)
            Else
                Exit For
            End If
        Next
        ClearDigit = Name

    End Function
End Class
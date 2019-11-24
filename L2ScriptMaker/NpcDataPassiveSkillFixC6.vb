Public Class NpcDataPassiveSkillFixC6

    'npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
    'npcgrp.txt:	property_list={4298;4278;4333}
    '[s_power_strike11]	=	769

    Private Structure SkillData
        '    Dim skill_id As Integer
        '    Dim skill_level As Integer
        Dim skill_name As String
        Dim skill_op As String
    End Structure

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim NpcGrpFile As String = "npcgrp.txt"    ' Name/path of npcgrp.txt file
        Dim aNpcPassiveSkill(40000) As String   ' Skilllist on each mob from npcgrp.txt file
        Dim aNpcActiveSkill(40000) As String   ' Skilllist on each mob from npcgrp.txt file
        'Dim SkillPchFile As String = "skill_pch.txt"     ' Name/path of skillpch.txt file
        Dim SkillDataFile As String = "skilldata.txt"     ' Name/path of skillpch.txt file

        'Dim aSkillPchId(30000) As String   ' Skilllist on each mob from skill_pch.txt file
        'Dim aSkillPchName(30000) As String   ' Skilllist on each mob from skill_pch.txt file

        Dim aSkillData(30000, 850) As SkillData   ' Skilllist on each mob from skill_pch.txt file

        Dim inNpcDataFile As String = "npcdata.txt"      ' Name/path of npcgrp.txt file
        Dim outNpcDataFile As String = "npcdata_new.txt"      ' Name/path of npcgrp.txt file

        Dim aRequiredSkillsCursor As Integer = -1
        Dim aRequiredSkills(100) As String    ' founded skills

        Dim TempStr As String, TempStr2 As String
        Dim TempData() As String
        Dim iTemp As Integer
        Dim iTemp1 As Integer, iTemp2 As Integer

        If System.IO.File.Exists(NpcGrpFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage client text file (npcgrp.txt)|npcgrp.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            NpcGrpFile = OpenFileDialog.FileName
        End If

        'If System.IO.File.Exists(SkillPchFile) = False Then
        '    OpenFileDialog.FileName = ""
        '    OpenFileDialog.Filter = "Lineage server script file (skill_pch.txt)|skill_pch.txt|All files|*.*"
        '    If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        '    SkillPchFile = OpenFileDialog.FileName
        'End If

        If System.IO.File.Exists(SkillDataFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage server script file (skilldata.txt)|skilldata*.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            SkillDataFile = OpenFileDialog.FileName
        End If

        If System.IO.File.Exists(inNpcDataFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage server npc script file (npcdata.txt)|npcdata*.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            inNpcDataFile = OpenFileDialog.FileName
        End If

        SaveFileDialog.FileName = outNpcDataFile
        SaveFileDialog.Filter = "Lineage II server New npc script (npcdata.txt)|npcdata*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        outNpcDataFile = SaveFileDialog.FileName


        ' ---- Loading Skills ---- 
        ToolStripStatusLabel.Text = "Loading skilldata file..."
        Dim iSkillPchFile As New System.IO.StreamReader(SkillDataFile, System.Text.Encoding.Default, True)
        ToolStripProgressBar.Maximum = CInt(iSkillPchFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        'skill_begin	skill_name=[s_triple_slash1]	/* [Triple Slash] */	skill_id=1	level=1	

        While iSkillPchFile.EndOfStream <> True

            TempStr = Replace(iSkillPchFile.ReadLine, Chr(9), " ")
            If (TempStr IsNot Nothing) = True Then

                If TempStr.StartsWith("//") = False Then
                    iTemp1 = CInt(Libraries.GetNeedParamFromStr(TempStr, "skill_id"))
                    iTemp2 = CInt(Libraries.GetNeedParamFromStr(TempStr, "level"))

                    aSkillData(iTemp1, iTemp2).skill_name = Libraries.GetNeedParamFromStr(TempStr, "skill_name").Replace("[", "").Replace("]", "")
                    aSkillData(iTemp1, iTemp2).skill_op = Libraries.GetNeedParamFromStr(TempStr, "operate_type")
                End If

            End If
            ToolStripProgressBar.Value = CInt(iSkillPchFile.BaseStream.Position)
            StatusStrip.Update()

        End While
        iSkillPchFile.Close()
        ToolStripProgressBar.Value = 0
        ' End of Loading Skills

        ' ---- Loading NpcSkills ---- 
        Dim iNpcDataFile As System.IO.StreamReader
        Dim oNpcDataFile As System.IO.StreamWriter

        Dim outFile As New System.IO.StreamWriter(inNpcDataFile + "_scriptCheck.log", True, System.Text.Encoding.Unicode, 1)
        outFile.WriteLine(vbNewLine & "L2ScriptMaker. NpcdataC6 skill_list fixer.")
        outFile.WriteLine(Now & " Start" & vbNewLine)

        'ResultsTextBox.Text

        ' L2Disasm Format
        'cnt_dtab1=2	dtab1[0]=4416	dtab1[1]=13	dtab1[2]=	dtab1[3]=	
        Dim sTemp As String, sTemp2 As String

        Dim aTemp(3) As String

        ToolStripStatusLabel.Text = "Loading npcgrp file..."
        Dim iNpcGrpFile As New System.IO.StreamReader(NpcGrpFile, System.Text.Encoding.Default, True)
        ToolStripProgressBar.Maximum = CInt(iNpcGrpFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        While iNpcGrpFile.EndOfStream <> True

            TempStr = iNpcGrpFile.ReadLine
            If TempStr <> Nothing And TempStr.StartsWith("//") = False Then
                TempStr2 = Libraries.GetNeedParamFromStr(TempStr, "cnt_dtab1")
                If TempStr2 <> "0" And TempStr2 <> "1" Then
                    sTemp = "{" : sTemp2 = "npc_ai={"
                    For iTemp = 0 To CInt(TempStr2) - 1 Step 2

                        iTemp1 = CInt(Libraries.GetNeedParamFromStr(TempStr, "dtab1[" & iTemp & "]"))
                        iTemp2 = CInt(Libraries.GetNeedParamFromStr(TempStr, "dtab1[" & (iTemp + 1) & "]"))
                        If aSkillData(iTemp1, iTemp2).skill_name = "" Then
                            'MessageBox.Show("Skill pch_id:" & iTemp2 & " not found in skilldata. Update file and try again", "Skill not defined", MessageBoxButtons.OK)
                            'ResultsTextBox.AppendText("Npc_id: " & Libraries.GetNeedParamFromStr(TempStr, "tag") & " Skill pch_id:" & iTemp2 & " not found in skilldata. Update file and try again" & vbNewLine)
                            outFile.WriteLine("Npc_id: " & Libraries.GetNeedParamFromStr(TempStr, "tag") & vbTab & "Skill id:" & iTemp1 & vbTab & "Skill_level:" & iTemp2)
                        Else

                            If Array.IndexOf(aRequiredSkills, aSkillData(iTemp1, iTemp2).skill_name) = -1 Then
                                aRequiredSkillsCursor += 1
                                If aRequiredSkillsCursor = aRequiredSkills.Length Then
                                    Array.Resize(aRequiredSkills, aRequiredSkillsCursor + 1)
                                End If
                                aRequiredSkills(aRequiredSkillsCursor) = aSkillData(iTemp1, iTemp2).skill_name 'aSkillPch(iTemp2)
                            End If

                            If aSkillData(iTemp1, iTemp2).skill_op = "P" Then
                                sTemp = sTemp & "@" & aSkillData(iTemp1, iTemp2).skill_name
                                If iTemp < (CInt(TempStr2) - 2) Then
                                    sTemp = sTemp & ";"
                                End If
                            Else
                                sTemp2 = sTemp2 & "{[DDMagic]=@" & aSkillData(iTemp1, iTemp2).skill_name & "}"
                                If iTemp < (CInt(TempStr2) - 2) Then
                                    sTemp2 = sTemp2 & ";"
                                End If
                            End If

                        End If
                    Next
                    sTemp = sTemp & "}" : sTemp2 = sTemp2 & "}"
                    aNpcPassiveSkill(CInt(Libraries.GetNeedParamFromStr(TempStr, "tag"))) = sTemp
                    If sTemp2 <> "npc_ai={}" Then
                        aNpcActiveSkill(CInt(Libraries.GetNeedParamFromStr(TempStr, "tag"))) = sTemp2
                    End If
                    'aNpcSkill(CInt(Libraries.GetNeedParamFromStr(TempStr, "npc_id"))) = Libraries.GetNeedParamFromStr(TempStr, "property_list").Replace("{", "").Replace("}", "")
                End If
            End If
            ToolStripProgressBar.Value = CInt(iNpcGrpFile.BaseStream.Position)
            StatusStrip.Update()

        End While
        iNpcGrpFile.Close()
        ToolStripProgressBar.Value = 0
        ' End of Loading NpcSkills
        outFile.WriteLine()
        outFile.WriteLine("Start fixing passive skills...")
        outFile.WriteLine()
        outFile.Flush()

        outFile.WriteLine("Required Skills for Mobs:")
        For iTemp2 = 0 To aRequiredSkillsCursor
            outFile.WriteLine(iTemp2 & ": " & aRequiredSkills(iTemp2)) ' & ": " & aSkillPch(aRequiredSkills(iTemp2)))
        Next
        outFile.WriteLine()

        If CheckBoxSaveActive.Checked = True Then
            oNpcDataFile = New System.IO.StreamWriter(outNpcDataFile & "_skills.txt", False, System.Text.Encoding.Unicode, 1)
            For iTemp = 0 To aNpcActiveSkill.Length - 1
                oNpcDataFile.WriteLine(aNpcActiveSkill(iTemp))
            Next
            oNpcDataFile.Close()
        End If
        If CheckBoxStopActive.Checked = True Then
            outFile.Close()
            ToolStripProgressBar.Value = 0
            ToolStripStatusLabel.Text = "Complete."
            MessageBox.Show("Done.")
            Exit Sub
        End If


        ' ---- Main module ----

        ToolStripStatusLabel.Text = "Writing npdata file..."
        Me.Update()
        iNpcDataFile = New System.IO.StreamReader(inNpcDataFile, System.Text.Encoding.Default, True)
        If System.IO.File.Exists(outNpcDataFile) Then System.IO.File.Copy(outNpcDataFile, outNpcDataFile & ".bak", True)
        oNpcDataFile = New System.IO.StreamWriter(outNpcDataFile, False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(iNpcDataFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        'npc_begin	warrior	1	[gremlin]	level=1
        'npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
        'npcgrp.txt:	property_list={4298;4278;4333}  aNpcSkill
        'skillpch.txt   aSkillPch(1130509) = s_race13

        Dim NpcId As Integer
        Dim OldSkillList As String, NewSkillList As String

        While iNpcDataFile.EndOfStream <> True

            TempStr = Replace(iNpcDataFile.ReadLine, Chr(9), " ").Trim
            If TempStr <> "" And TempStr <> Nothing And TempStr.StartsWith("//") = False Then

                ' tabs and spaces correction
                While InStr(TempStr, "  ") <> 0
                    TempStr = Replace(TempStr, "  ", " ")
                End While
                TempData = TempStr.Split(Chr(32))
                NpcId = CInt(TempData(2))

                'Preparing
                OldSkillList = "" : NewSkillList = ""

                OldSkillList = Libraries.GetNeedParamFromStr(TempStr, "skill_list")
                NewSkillList = aNpcPassiveSkill(NpcId)
                If NewSkillList Is Nothing Then NewSkillList = "{}"

                ' Magical Defence fix
                If MagicDefCheckBox.Checked = True Then

                    NewSkillList = NewSkillList.Replace("}", "")
                    'If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"

                    Select Case TempData(1)
                        Case "pet"
                            If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"
                            NewSkillList = NewSkillList & "@" & CustomNameTextBox.Lines(0) & "}" '"@s_summon_magic_defence}"

                        Case "summon"
                            If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"
                            NewSkillList = NewSkillList & "@" & CustomNameTextBox.Lines(0) & "}" '"@s_summon_magic_defence}"

                        Case "monrace"
                            If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"
                            NewSkillList = NewSkillList & "@s_full_magic_defence;@s_npc_abnormal_immunity}" '"@s_npc_abnormal_immunity}"

                        Case "warrior"

                            If Libraries.GetNeedParamFromStr(TempStr, "race") = "castle_guard" Or Libraries.GetNeedParamFromStr(TempStr, "race") = "mercenary" Then
                                If MagicDefCheckBox.Checked = True And AutosetToBossCheckBox.Checked = True Then
                                    If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"
                                    NewSkillList = NewSkillList & "@" & CustomNameTextBox.Lines(1) '& "}" ' "@s_full_magic_defence}"
                                Else
                                    'NewSkillList = NewSkillList & "}"
                                End If
                            Else
                                'NewSkillList = NewSkillList & "}"
                            End If
                            NewSkillList = NewSkillList & "}"

                        Case "boss"
                            If MagicDefCheckBox.Checked = True And AutosetToBossCheckBox.Checked = True Then
                                If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"
                                NewSkillList = NewSkillList & "@" & CustomNameTextBox.Lines(1) ' & "}" ' "@s_full_magic_defence}"
                            Else
                                'NewSkillList = NewSkillList & "}"
                            End If
                            NewSkillList = NewSkillList & "}"

                        Case "zzoldagu"
                            'NewSkillList = NewSkillList & "}"
                            If MagicDefCheckBox.Checked = True And AutosetToBossCheckBox.Checked = True Then
                                If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"
                                NewSkillList = NewSkillList & "@" & CustomNameTextBox.Lines(1) ' & "}" ' "@s_full_magic_defence}"
                            Else
                                'NewSkillList = NewSkillList & "}"
                            End If
                            NewSkillList = NewSkillList & "}"

                        Case Else
                            If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"
                            NewSkillList = NewSkillList & "@" & CustomNameTextBox.Lines(1) & "}" ' "@s_full_magic_defence}"
                    End Select

                End If

                If OldSkillList <> NewSkillList Then
                    'TempStr = TempStr.Replace(OldSkillList, NewSkillList).Replace(Chr(32), Chr(9))
                    TempStr = Libraries.SetNeedParamToStr(TempStr, "skill_list", NewSkillList)
                    outFile.WriteLine("Fixing npc: " & TempData(0) & vbTab & TempData(1) & vbTab & TempData(2) & vbTab & TempData(3))
                    outFile.WriteLine(OldSkillList & vbNewLine & "-->" & vbNewLine & NewSkillList & vbNewLine)
                End If

            End If
            TempStr = TempStr.Replace(Chr(32), Chr(9))
            oNpcDataFile.WriteLine(TempStr)

            ToolStripProgressBar.Value = CInt(iNpcDataFile.BaseStream.Position)
            StatusStrip.Update()

        End While

        outFile.WriteLine()
        outFile.WriteLine(Now & " End")
        outFile.WriteLine()
        outFile.Close()
        oNpcDataFile.Close()
        ToolStripProgressBar.Value = 0

        ToolStripStatusLabel.Text = "Complete."
        MessageBox.Show("Done.")


    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub MagicDefCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MagicDefCheckBox.CheckedChanged

        If MagicDefCheckBox.Checked = False Then
            AutosetToBossCheckBox.Checked = False
            AutosetToBossCheckBox.Enabled = False
        Else
            AutosetToBossCheckBox.Enabled = True
        End If

    End Sub

End Class
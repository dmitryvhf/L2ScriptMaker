Public Class ScriptLeecherOld

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonOpen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpen1.Click
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        File1.Text = OpenFileDialog.FileName
    End Sub

    Private Sub ButtonOpen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpen2.Click
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        File2.Text = OpenFileDialog.FileName
    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim TempStr As String
        ' Debug data. remove this for release!
        'File1.Text = "npcdata_c1.txt"
        'File2.Text = "npcdata_c4.txt"
        ' Debug data. remove this for release!

        If File1.Text = "" Or File2.Text = "" Then
            MessageBox.Show("I'm ready to suck, but i cant see source and target.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If NpcParam.CheckedItems.Count = 0 Then
            MessageBox.Show("Gimme list! I wish to suck!", "No list", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim inNpc1 As New System.IO.StreamReader(File1.Text, System.Text.Encoding.Default, True, 1)
        TempStr = System.IO.Path.GetFileName(File1.Text) + "_" + System.IO.Path.GetFileName(File2.Text) + ".txt"
        'Dim NewFile As System.IO.Stream = New System.IO.FileStream(TempStr, _
        '       IO.FileMode.Create, IO.FileAccess.Write)
        Dim NewFile2 As New System.IO.StreamWriter(TempStr, False, System.Text.Encoding.Unicode, 1)

        'Dim outLog As New System.IO.StreamWriter(TempStr & ".log", False, System.Text.Encoding.Unicode, 1)
        'outLog.WriteLine("L2ScriptMaker: ScriptLeacher..." & vbNewLine & Now.ToString & " Start" & vbNewLine)

        Dim TempStr1 As String
        Dim TempStr2 As String
        Dim Comment1 As String
        Dim Comment2 As String
        Dim Npc1() As String
        Dim Npc2() As String

        Dim IsData As Integer = 0 ' 1 - npcdata, 2 - itemdata
        ProgressBar.Maximum = CInt(inNpc1.BaseStream.Length)

        While inNpc1.EndOfStream <> True

            ProgressBar.Value = CInt(inNpc1.BaseStream.Position)
            Comment1 = "" : Comment2 = ""
            Me.Update()
            TempStr1 = inNpc1.ReadLine

            If TempStr1 <> "" And TempStr1.StartsWith("//") = False Then

                TempStr1 = TextCorrector(TempStr1)

            If InStr(TempStr1, "/*") <> 0 Then
                ' Comment
                Comment1 = Mid(TempStr1, InStr(TempStr1, "/*"), InStr(TempStr1, "*/") - InStr(TempStr1, "/*") + 2)
                TempStr1 = TempStr1.Replace(Chr(9) + Comment1, "")
                Comment1 = Comment1.Replace(Chr(9), " ")
            End If

            Npc1 = TempStr1.Split(Chr(9))
            Select Case Npc1(0)
                Case "npc_begin"
                    IsData = 2
                Case "item_begin"
                    IsData = 2
                Case "set_begin"
                    IsData = 1
                Case "skill_begin"
                    IsData = 3
            End Select

            TempStr2 = ""
            If IsData <> 3 Then
                TempStr2 = FindInFile(Npc1(IsData), IsData)  ' 2 - NpcId
                TempStr2 = TextCorrector(TempStr2)
            Else
                ' It's skilldata
                If SrcSkilldataEButton.Checked = True Or SrcSkillgrpButton.Checked = True Then
                    TempStr2 = FindInFile("skill_id=" + Libraries.GetNeedParamFromStr(TempStr1, "skill_id") + Chr(9) + "skill_level=" + Libraries.GetNeedParamFromStr(TempStr1, "level"), IsData)  ' 2 - NpcId
                Else
                    ' Except skilldata-e.txt and skillgrp.txt
                    TempStr2 = FindInFile("skill_id=" + Libraries.GetNeedParamFromStr(TempStr1, "skill_id") + Chr(9) + "level=" + Libraries.GetNeedParamFromStr(TempStr1, "level"), IsData)  ' 2 - NpcId
                End If
                If InStr(TempStr2, "/*") <> 0 Then
                    ' Comment
                    Comment2 = Mid(TempStr2, InStr(TempStr2, "/*"), InStr(TempStr2, "*/") - InStr(TempStr2, "/*") + 2)
                    TempStr2 = TempStr2.Replace(Chr(9) + Comment2, "")
                    Comment2 = Comment2.Replace(Chr(9), " ")
                Else
                    If SrcSkilldataEButton.Checked = True And TempStr2 <> "" Then
                        Dim iTemp As Integer = InStr(TempStr2, "name=[") + 5
                        'Mid(TempStr2, InStr(TempStr2, "desc=[")+6, InStr( InStr(TempStr2, "desc=[") , TempStr2,  InStr(TempStr2, "desc=[")-2)
                        'Comment2 = Libraries.GetNeedParamFromStr(TempStr2, "desc")
                        Comment2 = "/* " & Mid(TempStr2, iTemp, InStr(iTemp, TempStr2, "]") - iTemp + 1).Replace(Chr(9), Chr(32)) & " */"
                    End If
                End If

                TempStr2 = TextCorrector(TempStr2)
            End If

            If TempStr2 <> "" Then

                ' Npc exist. Working...
                Npc2 = TempStr2.Split(Chr(9))

                Dim TempInt As Integer, TempStr3 As String
                For TempInt = 0 To NpcParam.CheckedItems.Count - 1
                    TempStr3 = Libraries.GetNeedParamFromStr(TempStr2, NpcParam.CheckedItems(TempInt).ToString)

                    ' Correction for new param's
                    Select Case NpcParam.CheckedItems(TempInt).ToString
                        Case "collision_radius"
                            'TempStr3 = Mid(TempStr3, 2, TempStr3.Length - InStr(TempStr3, ";") - 1)
                            TempStr3 = TempStr3.Replace("collision_radius=", "")
                        Case "collision_height"
                            'TempStr3 = Mid(TempStr3, 2, TempStr3.Length - InStr(TempStr3, ";") - 1)
                            TempStr3 = TempStr3.Replace("collision_height=", "")
                        Case "align"
                            ' Correction for old param 'align'
                            Dim iAlign As Integer
                            iAlign = CInt(Replace(Npc2(4), "level=", ""))
                            iAlign = -iAlign * iAlign
                            If iAlign < -4900 Then
                                iAlign = -1
                            End If
                            TempStr3 = iAlign.ToString
                        Case "is_magic"
                            If Libraries.GetNeedParamFromStr(TempStr1, "is_magic") = "2" Then
                                ' nothing change if is_magic=2 in original file
                                TempStr3 = ""
                            End If
                        Case "mp_consume"

                            If IsData = 3 Then ' skilldata

                                ' It's import from skillgrp.dat to skilldata.txt
                                'Dim test As String = ""
                                Dim Mp1 As Integer, Mp2 As Integer

                                Mp2 = CInt(TempStr3)

                                Select Case Libraries.GetNeedParamFromStr(TempStr1, "is_magic")
                                    Case "0"
                                        If Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1") <> "" Then
                                            TempStr1 = TempStr1.Replace("mp_consume1" & "=" & Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1"), "")
                                        End If
                                        'is_magic=0	mp_consume2=10	
                                        Mp1 = 0 ' not exist
                                        Mp2 = Mp2 - Mp1
                                        If Libraries.GetNeedParamFromStr(TempStr1, "operate_type") = "T" Then
                                            Mp1 = Mp2
                                            Mp2 = 0
                                        End If
                                    Case "1"
                                        If Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1") = "" Then
                                            TempStr1 = TempStr1.Replace("is_magic=1", "is_magic=1" & vbTab & "mp_consume1=0")
                                        End If
                                        If Libraries.GetNeedParamFromStr(TempStr1, "mp_consume2") = "" Then
                                            TempStr1 = TempStr1.Replace("is_magic=1", "is_magic=1" & vbTab & "mp_consume1=0")
                                        End If
                                        'is_magic=1	mp_consume1=11	mp_consume2=44
                                        Mp1 = CInt(Mp2 * 0.2) ' MP1 = 20% of Summary
                                        Mp2 = Mp2 - Mp1
                                    Case "2"
                                        If Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1") = "" Then
                                            TempStr1 = TempStr1.Replace("is_magic=2", "is_magic=2" & vbTab & "mp_consume1=0")
                                        End If
                                        'is_magic = 2	mp_consume1 = 50	mp_consume2 = 0	
                                        Mp1 = Mp2  ' MP1 = 20% of Summary
                                        Mp2 = 0
                                    Case Nothing
                                        ' T skill or wrong skill type
                                        Mp1 = Mp2
                                        Mp2 = 0
                                End Select

                                TempStr1 = Libraries.SetNeedParamToStr(TempStr1, "mp_consume1", CStr(Mp1))
                                TempStr1 = Libraries.SetNeedParamToStr(TempStr1, "mp_consume2", CStr(Mp2))
                                'TempStr1 = TempStr1.Replace("mp_consume1" & "=" & Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1"), "mp_consume1" & "=" & CInt(Mp1))
                                'TempStr1 = TempStr1.Replace("mp_consume2" & "=" & Libraries.GetNeedParamFromStr(TempStr1, "mp_consume2"), "mp_consume2" & "=" & CInt(Mp2))

                                ' Disable common worker
                                TempStr3 = ""
                            End If

                        Case "hit_time"
                            ' It's import from skillgrp.dat to skilldata.dat

                            If IsData = 3 Then ' skilldata

                                TempStr1 = TempStr1.Replace("skill_hit_time" & "=" & Libraries.GetNeedParamFromStr(TempStr1, "skill_hit_time"), "skill_hit_time" & "=" & Double.Parse(TempStr3).ToString)
                                TempStr3 = ""
                            End If


                        End Select

                    If TempStr3 <> "" Then
                        If Libraries.GetNeedParamFromStr(TempStr2, NpcParam.CheckedItems(TempInt).ToString) <> "" Then
                            TempStr1 = TempStr1.Replace(NpcParam.CheckedItems(TempInt).ToString + "=" + Libraries.GetNeedParamFromStr(TempStr1, NpcParam.CheckedItems(TempInt).ToString), NpcParam.CheckedItems(TempInt).ToString + "=" + TempStr3)
                        Else
                            'param not exist in target config
                            'NpcParam.FindString("")
                        End If
                    End If
                Next


            Else
                ' New npc. What do next? Add new?

                'Npc2 = TempStr1.Split(Chr(9))
                'Array.Clear(Npc2, 0, Npc2.Length)

                'Dim itemsCount As Integer = 0
                'Npc2(0) = "npc_begin"     ' npc_begin
                'Npc2(1) = Npc1(1)     ' npctype (warrior and etc)
                'Npc2(2) = Npc1(2)     ' npcid
                'Npc2(3) = Npc1(3)     ' npcname
                'itemsCount = 3

                ' Npc exist. Working...
                'Dim TempInt As Integer, TempStr3 As String
                'For TempInt = 0 To NpcParam.CheckedItems.Count - 1
                'TempStr3 = Libraries.GetNeedParamFromStr(TempStr1, NpcParam.CheckedItems(TempInt).ToString)
                'If TempStr3 <> "" Then
                'itemsCount += 1
                'Npc2(itemsCount) = NpcParam.CheckedItems(TempInt).ToString + "=" + Libraries.GetNeedParamFromStr(TempStr1, NpcParam.CheckedItems(TempInt).ToString + "=")
                'End If
                'Next

                'Npc2(itemsCount + 1) = "npc_end"
                'NewFile2.WriteLine("npc_end")     ' npc_end
                'TempStr1 = Join(Npc2, Chr(9))

            End If
            If Comment2 <> "" Then
                TempStr1 = TempStr1.Replace(Chr(9) + "skill_id", Chr(9) + Comment2 + Chr(9) + "skill_id")
            Else
                TempStr1 = TempStr1.Replace(Chr(9) + "skill_id", Chr(9) + Comment1 + Chr(9) + "skill_id")
            End If

            End If


            NewFile2.WriteLine(TempStr1)

        End While

        ProgressBar.Value = 0

        'outLog.WriteLine(Now & vbNewLine)
        'outLog.Close()

        inNpc1.Close()
        NewFile2.Close()

        MessageBox.Show("Sucking complete. Thanks NCSoft for good sex.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Function TextCorrector(ByVal SourceText As String) As String

        ' tabs and spaces correction
        SourceText = Replace(SourceText, " = ", "=")
        While InStr(SourceText, "  ") <> 0
            SourceText = Replace(SourceText, "  ", " ")
        End While
        SourceText = Replace(SourceText, " ", Chr(9))

        Return SourceText

    End Function

    Function FindInFile(ByVal WhatNeed As String, ByVal IsData As Integer) As String


        Dim File As New System.IO.StreamReader(File2.Text, System.Text.Encoding.Default, True, 1)

        FindInFile = ""

        Dim TempStr As String = ""
        'Dim Npc2() As String

        While File.EndOfStream <> True

            TempStr = File.ReadLine
            TempStr = TextCorrector(TempStr)
            If TempStr <> "" Then

                'If IsData <> 3 Then
                'Npc2 = TempStr.Split(Chr(9))
                'If WhatNeed = Npc2(IsData) Then
                'File.Close()
                'Return TempStr
                'End If
                'Else
                ' It's skilldata
                If InStr(TempStr, Chr(9) + WhatNeed, CompareMethod.Text) <> 0 Then
                    File.Close()
                    Return TempStr
                End If
            End If

        End While
        File.Close()

    End Function

    Private Sub ButtonChkAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonChkAll.Click

        Dim TempInt As Integer
        For TempInt = 0 To NpcParam.Items.Count - 1
            NpcParam.SetItemChecked(TempInt, True)
        Next

    End Sub

    Private Sub ButtonDeChkAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeChkAll.Click

        Dim TempInt As Integer
        For TempInt = 0 To NpcParam.CheckedItems.Count - 1
            NpcParam.SetItemChecked(TempInt, False)
        Next

    End Sub

    Private Sub ButtonImportList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImportList.Click

        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        NpcParam.Items.Clear()

        Dim LstFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        Dim TempStr As String

        While LstFile.EndOfStream <> True
            TempStr = LstFile.ReadLine.Trim
            NpcParam.Items.Add(TempStr, True)
        End While

        LstFile.Close()
        MessageBox.Show("Import new list complete.", "Import complete", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

End Class

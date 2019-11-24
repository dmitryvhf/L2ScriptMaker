Public Class NpcDropItemChecker

    Private Structure GroupItems
        Dim name As String
        Dim minValue As Integer
        Dim maxValue As Integer
        Dim chance As Double
    End Structure

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click


        Dim sNpcdataFile As String
        OpenFileDialog.Filter = "Lineage II npcdata config (npcdata.txt)|npcdata*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sNpcdataFile = OpenFileDialog.FileName

        If System.IO.File.Exists(sNpcdataFile & ".bak") Then
            If MessageBox.Show("Overwrite previous backup file?", "Overwrite", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
        End If

        System.IO.File.Copy(sNpcdataFile, sNpcdataFile & ".bak", True)
        Dim inFile As New System.IO.StreamReader(sNpcdataFile & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sNpcdataFile, False, System.Text.Encoding.Unicode, 1)

        Dim outLogFile As New System.IO.StreamWriter(sNpcdataFile + "_scriptCheck.log", True, System.Text.Encoding.Unicode, 1)
        outLogFile.WriteLine("L2ScriptMaker: Npcdata.txt DropItemChecker.")
        outLogFile.WriteLine(Now & " Start" & vbNewLine)

        Dim iTemp As Integer, iTemp2 As Integer
        Dim sTemp As String, sTempGroup As String

        Dim iSumChance As Double = 0
        Dim iSumChanceInc As Double = 1

        Dim aGroup(0) As String
        Dim aGroupChance(0) As String

        Dim aItemInGroup() As String    ' Items list in one group
        Dim aGroupItem(3) As String     ' One item in one group
        Dim aTemp2(3) As String         ' One item splited to name,min,max,chance

        Dim iItemChanceInc As Double = CDbl(ItemChanceRateTextBox.Text)

        Dim sTempNewGroup As String, sTempForNew As String

        Dim iLineCursor As Long = 0
        Dim isSpoil As Boolean = True
        Dim stopOnError As Boolean = StopOnErrorCheckBox.Checked

        'aGroup - all group in mob drop
        'aGroupItem - all items in one group

        If ClearBadParamCheckBox.Checked = True Then
            outLogFile.WriteLine("Cleaning bad drop Activated!" & vbNewLine)
        End If

        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            iLineCursor += 1
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then


                If CheckBoxIgnoreSpoil.Checked = True Then GoTo ContinueWorkingDrop

                ' ---- SPOIL checker ---
                sTempGroup = Libraries.GetNeedParamFromStr(sTemp, "corpse_make_list")
                If sTempGroup <> "{}" Then
                    isSpoil = True

                    sTempNewGroup = sTemp

                    ' Step 1. remove start/end symbols {...}
                    sTempGroup = sTempGroup.Substring(2, sTempGroup.Length - 2)

                    ' Step 2. Split groups to array
                    ' {{{[adena];14000000;18000000;100}};100};{{{[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}
                    sTempGroup = sTempGroup.Replace("};{", "}|{").Replace("}", "").Replace("{", "")
                    'sTempGroup = sTempGroup.Replace("{{{[", "{[")
                    ' {{{[adena];14000000;18000000;100}};100}|{{{[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}

                    aGroup = sTempGroup.Split(CChar("|"))
                    Array.Resize(aGroupChance, aGroup.Length)
                    '{{ {[adena];14000000;18000000;100}};100};
                    '{{ {[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}

                    sTempNewGroup = ""
                    For iTemp = 0 To aGroup.Length - 1

                        'aGroupChance(iTemp) = aGroup(iTemp).Substring(InStr(aGroup(iTemp), "}};") + 2, aGroup(iTemp).Length - InStr(aGroup(iTemp), "}};") - 3)
                        aGroupChance(iTemp) = aGroup(iTemp).Remove(0, aGroup(iTemp).LastIndexOf(";") + 1)
                        Try
                            iTemp2 = CInt(CDbl(aGroupChance(iTemp)))
                        Catch ex As Exception
                            GoTo CriticalErrorExit
                        End Try

                        sTempGroup = aGroup(iTemp).Replace("};{", "}|{").Replace("{{{", "{")
                        '{[dark_legion_s_edge];1;2;25}|{[meteor_shower];1;2;25}};100}

                        'sTempGroup = sTempGroup.Replace(";", "|")
                        '{[dark_legion_s_edge];1;2;25}|{[meteor_shower];1;2;25}
                        aItemInGroup = sTempGroup.Split(CChar("|"))
                        'If aItemInGroup.Length = 1 Then GoTo CriticalErrorExit
                        '[dark_legion_s_edge];1;2;25
                        '[meteor_shower];1;2;25

                        iSumChance = 0
                        iSumChanceInc = 1
                        'Array.Resize(aGroupItem, aItemInGroup.Length)
                        For iTemp2 = 0 To aItemInGroup.Length - 1
                            aTemp2 = aItemInGroup(iTemp2).Split(CChar(";"))
                            If aTemp2.Length <> 4 Then
                                GoTo CriticalErrorExit
                            End If
                            aGroupItem(0) = aTemp2(0)
                            aGroupItem(1) = aTemp2(1)
                            aGroupItem(2) = aTemp2(2)
                            If AdenaSkipCheckBox.Checked = True And iItemChanceInc > 0 And aGroupItem(0) = "[adena]" Then
                                aGroupItem(3) = aTemp2(3)
                                'iSumChance = iSumChance + CDbl(Format(CDbl(aTemp2(3)), "0.####"))
                            Else
                                aGroupItem(3) = CStr(CDbl(aTemp2(3)) * iItemChanceInc)
                                'iSumChance = iSumChance + (CDbl(Format(CDbl(aTemp2(3)), "0.####")) * iItemChanceInc)
                            End If

                            iSumChance = iSumChance + CDbl(aGroupItem(3))
                            aItemInGroup(iTemp2) = Join(aGroupItem, ";")
                        Next

                        iSumChance = CDbl(Format(iSumChance, "0.####"))

                        If iSumChance > 100 Then
                            'MessageBox.Show("Attention in npc:" & vbNewLine & sTemp.Substring(0, 30) & vbNewLine & "in group:" & vbNewLine & aGroup(iTemp))
                            'iSumChanceInc = CDbl(Format((100 / iSumChance), "0.####"))
                            iSumChanceInc = 100 / iSumChance
                        End If

                        ' Rebuilding group
                        iSumChance = 0  ' Additional control
                        'sTempForNew = "{{"
                        sTempForNew = ""
                        For iTemp2 = 0 To aItemInGroup.Length - 1
                            aTemp2 = aItemInGroup(iTemp2).Split(CChar(";"))
                            aGroupItem(0) = aTemp2(0)
                            aGroupItem(1) = aTemp2(1)
                            aGroupItem(2) = aTemp2(2)
                            aGroupItem(3) = Format((CDbl(aTemp2(3)) * iSumChanceInc), "0.####")
                            'aGroupItem(3) = CStr(CDbl(aTemp2(3)) * iSumChanceInc)

                            iSumChance = iSumChance + CDbl(aTemp2(3)) * iSumChanceInc

                            sTempForNew = sTempForNew & "{" & Join(aGroupItem, ";") & "}"
                            If iTemp2 < (aItemInGroup.Length - 1) Then sTempForNew = sTempForNew & ";"
                        Next
                        iSumChance = CDbl(Format(iSumChance, "0.####"))
                        If iSumChance > 100 Then
                            MessageBox.Show("Attention in npc:" & vbNewLine & sTemp.Substring(0, 30) & vbNewLine & "in group:" & vbNewLine & aGroup(iTemp))
                        End If

                        'sTempForNew = sTempForNew & "};" & aGroupChance(iTemp) & "}"
                        sTempForNew = sTempForNew ' & aGroupChance(iTemp) & "}"
                        aGroup(iTemp) = sTempForNew
                    Next
                    sTempNewGroup = "{" & Join(aGroup, ";") & "}"
                    sTemp = sTemp.Replace(Libraries.GetNeedParamFromStr(sTemp, "corpse_make_list"), sTempNewGroup)
                End If
                ' ---- SPOIL checker END ---

ContinueWorkingDrop:

                ' ---- DROP checker ---
                sTempGroup = Libraries.GetNeedParamFromStr(sTemp, "additional_make_multi_list")
                If sTempGroup <> "{}" Then
                    isSpoil = False

                    sTempNewGroup = sTemp

                    ' Step 1. remove start/end symbols {...}
                    sTempGroup = sTempGroup.Substring(2, sTempGroup.Length - 2)

                    ' Step 2. Split groups to array
                    ' {{{[adena];14000000;18000000;100}};100};{{{[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}
                    sTempGroup = sTempGroup.Replace("};{{", "}|{{")
                    'sTempGroup = sTempGroup.Replace("{{{[", "{[")
                    ' {{{[adena];14000000;18000000;100}};100}|{{{[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}

                    aGroup = sTempGroup.Split(CChar("|"))
                    Array.Resize(aGroupChance, aGroup.Length)
                    '{{ {[adena];14000000;18000000;100}};100};
                    '{{ {[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}

                    sTempNewGroup = ""
                    For iTemp = 0 To aGroup.Length - 1

                        'aGroupChance(iTemp) = aGroup(iTemp).Substring(InStr(aGroup(iTemp), "}};") + 2, aGroup(iTemp).Length - InStr(aGroup(iTemp), "}};") - 3)
                        aGroupChance(iTemp) = aGroup(iTemp).Remove(0, InStr(aGroup(iTemp), "}};") + 2).Replace("}", "")
                        Try
                            iTemp2 = CInt(CDbl(aGroupChance(iTemp)))
                        Catch ex As Exception
                            GoTo CriticalErrorExit
                        End Try

                        sTempGroup = aGroup(iTemp).Replace("};{", "}|{").Replace("{{{", "{")
                        '{[dark_legion_s_edge];1;2;25}|{[meteor_shower];1;2;25}};100}


                        sTempGroup = sTempGroup.Substring(0, InStr(sTempGroup, "}};") + 1).Replace("{", "").Replace("}", "")
                        '{[dark_legion_s_edge];1;2;25}|{[meteor_shower];1;2;25}
                        aItemInGroup = sTempGroup.Split(CChar("|"))
                        'If aItemInGroup.Length = 1 Then GoTo CriticalErrorExit
                        '[dark_legion_s_edge];1;2;25
                        '[meteor_shower];1;2;25

                        iSumChance = 0
                        iSumChanceInc = 1
                        'Array.Resize(aGroupItem, aItemInGroup.Length)
                        For iTemp2 = 0 To aItemInGroup.Length - 1
                            aTemp2 = aItemInGroup(iTemp2).Split(CChar(";"))
                            If aTemp2.Length <> 4 Then
                                GoTo CriticalErrorExit
                            End If
                            aGroupItem(0) = aTemp2(0)
                            aGroupItem(1) = aTemp2(1)
                            aGroupItem(2) = aTemp2(2)
                            If AdenaSkipCheckBox.Checked = True And iItemChanceInc > 0 And aGroupItem(0) = "[adena]" Then
                                aGroupItem(3) = aTemp2(3)
                                'iSumChance = iSumChance + CDbl(Format(CDbl(aTemp2(3)), "0.####"))
                            Else
                                aGroupItem(3) = CStr(CDbl(aTemp2(3)) * iItemChanceInc)
                                'iSumChance = iSumChance + (CDbl(Format(CDbl(aTemp2(3)), "0.####")) * iItemChanceInc)
                            End If

                            iSumChance = iSumChance + CDbl(aGroupItem(3))
                            aItemInGroup(iTemp2) = Join(aGroupItem, ";")
                        Next

                        iSumChance = CDbl(Format(iSumChance, "0.####"))

                        If iSumChance > 100 Then
                            'MessageBox.Show("Attention in npc:" & vbNewLine & sTemp.Substring(0, 30) & vbNewLine & "in group:" & vbNewLine & aGroup(iTemp))
                            'iSumChanceInc = CDbl(Format((100 / iSumChance), "0.####"))
                            iSumChanceInc = 100 / iSumChance
                        End If

                        ' Rebuilding group
                        iSumChance = 0  ' Additional control
                        sTempForNew = "{{"
                        For iTemp2 = 0 To aItemInGroup.Length - 1
                            aTemp2 = aItemInGroup(iTemp2).Split(CChar(";"))
                            aGroupItem(0) = aTemp2(0)
                            aGroupItem(1) = aTemp2(1)
                            aGroupItem(2) = aTemp2(2)
                            aGroupItem(3) = Format((CDbl(aTemp2(3)) * iSumChanceInc), "0.####")
                            'aGroupItem(3) = CStr(CDbl(aTemp2(3)) * iSumChanceInc)

                            iSumChance = iSumChance + CDbl(aTemp2(3)) * iSumChanceInc

                            sTempForNew = sTempForNew & "{" & Join(aGroupItem, ";") & "}"
                            If iTemp2 < (aItemInGroup.Length - 1) Then sTempForNew = sTempForNew & ";"
                        Next
                        iSumChance = CDbl(Format(iSumChance, "0.####"))
                        If iSumChance > 100 Then
                            MessageBox.Show("Attention in npc:" & vbNewLine & sTemp.Substring(0, 30) & vbNewLine & "in group:" & vbNewLine & aGroup(iTemp))
                        End If

                        sTempForNew = sTempForNew & "};" & aGroupChance(iTemp) & "}"
                        aGroup(iTemp) = sTempForNew
                    Next
                    sTempNewGroup = "{" & Join(aGroup, ";") & "}"
                    sTemp = sTemp.Replace(Libraries.GetNeedParamFromStr(sTemp, "additional_make_multi_list"), sTempNewGroup)
                End If
                ' ---- DROP checker END ---
            End If

ContinueWorking:
            outFile.WriteLine(sTemp)

        End While
        ToolStripProgressBar.Value = 0

        outLogFile.WriteLine()
        outLogFile.WriteLine(Now & " End")
        outLogFile.WriteLine()

        outLogFile.Close()
        outFile.Close()
        inFile.Close()

        ToolStripProgressBar.Value = 0
        MessageBox.Show("Complete")
        Exit Sub

CriticalErrorExit:

        If isSpoil = True Then
            sTempGroup = "(Spoil:) " & Libraries.GetNeedParamFromStr(sTemp, "corpse_make_list")
        Else
            sTempGroup = "(Drop: ) " & Libraries.GetNeedParamFromStr(sTemp, "additional_make_multi_list")
        End If

        outLogFile.WriteLine("Parsing error in line: " & iLineCursor & vbTab & sTempGroup)

        If stopOnError = True Then
            outLogFile.WriteLine()
            outLogFile.WriteLine(Now & " End")
            outLogFile.WriteLine()

            outLogFile.Close()
            outFile.Close()
            inFile.Close()
            ToolStripProgressBar.Value = 0
            MessageBox.Show("Parsing error in line: " & iLineCursor & vbTab & sTempGroup)
            Exit Sub
        Else
            If isSpoil = True Then
                If ClearBadParamCheckBox.Checked = True Then sTemp = Libraries.SetNeedParamToStr(sTemp, "corpse_make_list", "{}")
                GoTo ContinueWorkingDrop
            Else
                If ClearBadParamCheckBox.Checked = True Then sTemp = Libraries.SetNeedParamToStr(sTemp, "additional_make_multi_list", "{}")
                GoTo ContinueWorking
            End If
        End If

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub


    Private Sub ItemChanceRateTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ItemChanceRateTextBox.Validating

        Try
            ItemChanceRateTextBox.Text = ItemChanceRateTextBox.Text.Trim
            ItemChanceRateTextBox.Text = CStr(CDbl(ItemChanceRateTextBox.Text))
        Catch ex As Exception
            ItemChanceRateTextBox.Text = "1"
        End Try

        If ItemChanceRateTextBox.Text = "0" Or CDbl(ItemChanceRateTextBox.Text) < 0 Then ItemChanceRateTextBox.Text = "1"

    End Sub

    Private Sub ClearBadParamCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBadParamCheckBox.CheckedChanged

        If ClearBadParamCheckBox.Checked = True Then
            If StopOnErrorCheckBox.Checked = True Then
                StopOnErrorCheckBox.Checked = False
            End If
        End If

    End Sub

    Private Sub StopOnErrorCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopOnErrorCheckBox.CheckedChanged
        If StopOnErrorCheckBox.Checked = True Then
            If ClearBadParamCheckBox.Checked = True Then
                ClearBadParamCheckBox.Checked = False
            End If
        End If
    End Sub
End Class
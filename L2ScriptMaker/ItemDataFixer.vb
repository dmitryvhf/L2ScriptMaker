Public Class ItemDataFixer

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click


        If CheckedListBox.CheckedItems.Count = 0 Then
            MessageBox.Show("Select what you want to check and fix and try again", "No select", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sTemp As String, aTemp() As String = {}
        Dim sTemp2 As String
        Dim iTemp As Integer = 0
        Dim ItemNames(0) As String

        CheckFilesBox.Text = CheckFilesBox.Text.Trim

        Dim CheckConfig(CheckFilesBox.Lines.Length) As String
        Dim inCheckFiles(CheckFilesBox.Lines.Length) As System.IO.StreamReader

        For iTemp = 0 To CheckFilesBox.Lines.Length - 1
            inCheckFiles(iTemp) = New System.IO.StreamReader(CheckFilesBox.Lines(iTemp), System.Text.Encoding.Default, True, 1)
            CheckConfig(iTemp) = inCheckFiles(iTemp).ReadToEnd
            inCheckFiles(iTemp).Close()
            System.IO.File.Copy(CheckFilesBox.Lines(iTemp), CheckFilesBox.Lines(iTemp) & ".bak", True)
        Next

        Dim outCheckFiles(CheckFilesBox.Lines.Length) As System.IO.StreamWriter
        For iTemp = 0 To CheckFilesBox.Lines.Length - 1
            outCheckFiles(iTemp) = New System.IO.StreamWriter(CheckFilesBox.Lines(iTemp), False, System.Text.Encoding.Unicode, 1)
        Next


        Dim aCapsuleSkill(0) As String 'action_capsule
        If CheckedListBox.CheckedItems.IndexOf("action_capsule items") <> -1 Then

            OpenFileDialog.FileName = "skilldata.txt"
            If System.IO.File.Exists("skilldata.txt") = False Then
                'OpenFileDialog.FileName = "skilldata.txt"
                OpenFileDialog.Filter = "Lineage II server skill config (skilldata.txt)|skilldata*.txt|All files|*.*"
                If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
                'sSkillDataFile = OpenFileDialog.FileName
            End If

            ' ---- Loading 'Skilldata.txt' ---- 
            Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
            ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
            'ProgressBar.Text = "Loading skilldata.txt..."

            While inFile.EndOfStream <> True

                sTemp = inFile.ReadLine
                If sTemp <> "" And sTemp.StartsWith("//") = False Then

                    'skill_begin	skill_name = [s_quiver_of_arrows_a]	/* [?? ?? ???? - A????] */	skill_id = 323	level = 1	operate_type = A1	magic_level = 66	effect = {{i_restoration_random;{{{{[mithril_arrow];700}};30};{{{[mithril_arrow];1400}};50};{{{[mithril_arrow];2800}};20}}}}	is_magic = 1	mp_consume1 = 366	mp_consume2 = 0	item_consume = {[crystal_a];1}	cast_range = -1	effective_range = -1	skill_hit_time = 3	skill_cool_time = 0	skill_hit_cancel_time = 0.5	reuse_delay = 1800	attribute = attr_none	effect_point = 0	target_type = self	affect_scope = single	affect_limit = {0;0}	next_action = none	ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	skill_end
                    'skill_begin	skill_name = [s_summon_cp_potion]	/* [?? CP ??] */	skill_id = 1324	level = 1	operate_type = A1	magic_level = -1	effect = {{i_restoration;[adv_cp_potion];20}}	is_magic = 1	mp_consume1 = 412	mp_consume2 = 0	item_consume = {[soul_ore];50}	cast_range = -1	effective_range = -1	skill_hit_time = 20	skill_cool_time = 0	skill_hit_cancel_time = 0.5	reuse_delay = 1800	attribute = attr_none	effect_point = 0	target_type = self	affect_scope = single	affect_limit = {0;0}	next_action = none	ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	skill_end

                    If InStr(Libraries.GetNeedParamFromStr(sTemp, "effect"), "{i_restoration") > 0 Then
                        'iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "skill_id"))
                        'If iTemp >= aCapsuleSkill.Length Then
                        iTemp = aCapsuleSkill.Length
                        Array.Resize(aCapsuleSkill, iTemp + 1)
                        'End If
                        aCapsuleSkill(iTemp - 1) = Libraries.GetNeedParamFromStr(sTemp, "skill_name") '.Replace("[", "").Replace("]", "")
                    End If

                End If
                ProgressBar.Value = CInt(inFile.BaseStream.Position)
                ProgressBar.Update()
            End While
            ProgressBar.Value = 0
            inFile.Close()
            Me.Refresh()
        End If
        Me.Update()

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim inItemFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        Dim outItemFile As New System.IO.StreamWriter(OpenFileDialog.FileName + "_fixed.txt", False, System.Text.Encoding.Unicode, 1)
        Dim outLogFile As New System.IO.StreamWriter(OpenFileDialog.FileName + "_fixed.log", True, System.Text.Encoding.Unicode, 1)
        outLogFile.WriteLine("L2ScriptMaker ItemData Fixer" & vbNewLine & Now.ToString & " Start" & vbNewLine)
        ProgressBar.Maximum = CInt(inItemFile.BaseStream.Length)
        ProgressBar.Value = 0


        While inItemFile.EndOfStream <> True

            sTemp = inItemFile.ReadLine
            sTemp = sTemp.Replace(" = ", "=").Replace("  ", " ").Replace(" ", Chr(9))

            If sTemp.StartsWith("item_begin") = True Then
                Array.Clear(aTemp, 0, aTemp.Length)
                aTemp = sTemp.Split(Chr(9))

                'If InStr(sTemp, "questitem") <> 0 Then
                'If Libraries.GetNeedParamFromStr(sTemp, "item_type") ="" Then
                'If aTemp(1) = "questitem" And aTemp(4) <> "item_type=questitem" Then

                'item_begin(0)	questitem(1)	687(2)	[darings_letter](3)	item_type=questitem(4)

                ' Duplicate check actived
                If CheckedListBox.CheckedItems.IndexOf("duplicate names") <> -1 Then
                    If ItemNames.Length < (CInt(aTemp(2)) + 1) Then
                        Array.Resize(ItemNames, CInt(aTemp(2)) + 1)
                    End If
                    If Array.IndexOf(ItemNames, aTemp(3)) <> -1 Then
                        outLogFile.WriteLine("ItemId " & aTemp(2) & " " & aTemp(3) & vbTab & " is duplicate item for item " & Array.IndexOf(ItemNames, aTemp(3)) & ". Automaticaly renamed to " & aTemp(3).Replace("]", "_" & aTemp(2) & "]"))
                        For iTemp = 0 To CheckFilesBox.Lines.Length - 1
                            CheckConfig(iTemp) = CheckConfig(iTemp).Replace(aTemp(3), aTemp(3).Replace("]", "_" & aTemp(2) & "]"))
                        Next
                        aTemp(3) = aTemp(3).Replace("]", "_" & aTemp(2) & "]")
                        sTemp = Join(aTemp, Chr(9))
                    End If
                    ItemNames(CInt(aTemp(2))) = aTemp(3)

                End If


                ' Items type check actived
                If CheckedListBox.CheckedItems.IndexOf("item_type=") <> -1 Then
                    If aTemp(1) <> aTemp(4).Replace("item_type=", "") Then
                        outLogFile.WriteLine("ItemId " & aTemp(2) & " " & aTemp(3) & vbTab & " define as '" & aTemp(1) & "', but '" & aTemp(4) & "'. Header fixed.")
                        aTemp(1) = aTemp(4).Replace("item_type=", "")
                        sTemp = Join(aTemp, Chr(9))
                    End If
                    ' Special checking for item_type=questitem
                    'If aTemp(1) <> "questitem" And aTemp(4) = "item_type=questitem" Then
                    'outLogFile.WriteLine("ItemId " & aTemp(2) & " " & aTemp(3) & " is " & aTemp(4) & " but header define as " & aTemp(1))
                    'aTemp(1) = "questitem"
                    'sTemp = Join(aTemp, Chr(9))
                    'End If
                End If

                ' QuestItems name check actived
                If CheckedListBox.CheckedItems.IndexOf("add q_ for questitems") <> -1 Then
                    If aTemp(4) = "item_type=questitem" Then
                        If aTemp(3).StartsWith("[q_") = False And aTemp(3).StartsWith("[q0") = False Then
                            ' Itemname is questitem but name not q_...
                            outLogFile.WriteLine("ItemId " & aTemp(2) & " " & aTemp(3) & vbTab & " is " & aTemp(1) & ", but named as not quest item. Header fixed.")
                            For iTemp = 0 To CheckFilesBox.Lines.Length - 1
                                CheckConfig(iTemp) = CheckConfig(iTemp).Replace(aTemp(3), aTemp(3).Replace("[", "[q_"))
                            Next
                            aTemp(3) = aTemp(3).Replace("[", "[q_")
                            sTemp = Join(aTemp, Chr(9))
                        End If
                    End If
                End If

                ' QuestItems name check2 actived
                If CheckedListBox.CheckedItems.IndexOf("remove q_ from non-questitems") <> -1 Then
                    If aTemp(4) <> "item_type=questitem" Then
                        If aTemp(3).StartsWith("[q_") = True Then
                            ' Itemname is normal item, but named as questitem [q_...]
                            outLogFile.WriteLine("ItemId " & aTemp(2) & " " & aTemp(3) & vbTab & " is " & aTemp(1) & ", but named as quest item. Header removed.")
                            For iTemp = 0 To CheckFilesBox.Lines.Length - 1
                                CheckConfig(iTemp) = CheckConfig(iTemp).Replace(aTemp(3), aTemp(3).Replace("[q_", "["))
                            Next
                            aTemp(3) = aTemp(3).Replace("[q_", "[")
                            sTemp = Join(aTemp, Chr(9))
                        End If
                    End If
                End If

                ' action_capsule items
                If CheckedListBox.CheckedItems.IndexOf("action_capsule items") <> -1 Then
                    'item_begin	etcitem	5134	[comp_soulshot_none]	default_action=action_capsule	item_skill=[s_restoration1]
                    'item_begin(0)	questitem(1)	687(2)	[darings_letter](3)	item_type=questitem(4)
                    sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "item_skill")
                    If sTemp2 <> "[]" Then
                        If Array.IndexOf(aCapsuleSkill, sTemp2) <> -1 Then
                            If Libraries.GetNeedParamFromStr(sTemp, "default_action") <> "action_capsule" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "default_action", "action_capsule")
                                outLogFile.WriteLine("ItemId " & aTemp(2) & " " & aTemp(3) & vbTab & " now default_action=action_capsule")
                            End If
                        End If
                    End If
                End If

                ' dual_fhit_rate
                If CheckedListBox.CheckedItems.IndexOf("dual_fhit_rate") <> -1 Then
                    'item_begin	etcitem	5134	[comp_soulshot_none]	default_action=action_capsule	item_skill=[s_restoration1]
                    'item_begin(0)	questitem(1)	687(2)	[darings_letter](3)	item_type=questitem(4)
                    'weapon_type=dualfist
                    sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "weapon_type")
                    If sTemp2 = "dualfist" Or sTemp2 = "dual" Then
                        If Libraries.GetNeedParamFromStr(sTemp, "dual_fhit_rate") = "0" Then
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "dual_fhit_rate", "50")
                            outLogFile.WriteLine("ItemId " & aTemp(2) & " " & aTemp(3) & vbTab & " now dual_fhit_rate=50")
                        End If
                    End If
                End If

                'polearm multitarget
                If CheckedListBox.CheckedItems.IndexOf("polearm multitarget") <> -1 Then
                    'item_begin	etcitem	5134	[comp_soulshot_none]	default_action=action_capsule	item_skill=[s_restoration1]
                    'item_begin(0)	questitem(1)	687(2)	[darings_letter](3)	item_type=questitem(4)
                    'weapon_type=dualfist
                    sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "weapon_type")
                    If sTemp2 = "pole" Then
                        'item_skill=[s_polearm_multi_attack]
                        If Libraries.GetNeedParamFromStr(sTemp, "item_skill") = "[none]" Then
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "item_skill", "[s_polearm_multi_attack]")
                            outLogFile.WriteLine("ItemId " & aTemp(2) & " " & aTemp(3) & vbTab & " now item_skill=[s_polearm_multi_attack]")
                        End If
                    End If
                End If

            End If

            outItemFile.WriteLine(sTemp)
            ProgressBar.Value = CInt(inItemFile.BaseStream.Position)
        End While
        ProgressBar.Value = 0
        outLogFile.WriteLine(vbNewLine & Now.ToString & " End" & vbNewLine)

        inItemFile.Close()
        outItemFile.Close()
        outLogFile.Close()

        For iTemp = 0 To CheckFilesBox.Lines.Length - 1
            outCheckFiles(iTemp).Write(CheckConfig(iTemp))
            outCheckFiles(iTemp).Close()
        Next

        MessageBox.Show("Complete")

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub
End Class
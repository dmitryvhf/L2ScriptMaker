Public Class QuestPchMaker

    Private Sub QuestPchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuestPchButton.Click

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim QuestDataDir As String = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName)
        If System.IO.File.Exists("ai.obj") = False Or System.IO.File.Exists("questname-e.txt") = False Then
            MessageBox.Show("Required all files (itemdata.txt and ai.obj and questname-e.txt) for generation", "Required files not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Initialization

        'quest_begin	id=257	level=1	name=[The Guard is Busy]
        'quest_begin	id=1	level=1	name=[Letters of Love]
        Dim QuestPchName(2000) As String
        '[guard_is_busy1]	257
        '[letters_of_love1](1)

        Dim QuestPch2Name(2000) As String
        '257 4 1084 752 1085 1086  QuestPch2Name(257)
        '1 4 687 688 1079 1080     QuestPch2Name(1)

        Dim UnDestrItems(30000) As String

        'Dim inQuestEFile As New System.IO.StreamReader("questname-e.txt", System.Text.Encoding.Default, True, 1)
        'Dim inItemFile As New System.IO.StreamReader("itemdata.txt", System.Text.Encoding.Default, True, 1)
        'Dim inAiFile As New System.IO.StreamReader("ai.obj", System.Text.Encoding.Default, True, 1)

        'Dim outQuestPchFile As New System.IO.StreamWriter(QuestDataDir + "\quest_pch.txt", False, System.Text.Encoding.Unicode, 1)
        'Dim outQuestPch2File As New System.IO.StreamWriter(QuestDataDir + "\quest_pch2.txt", False, System.Text.Encoding.Unicode, 1)
        Dim outLogFile As New System.IO.StreamWriter(QuestDataDir + "\quest_pch.log", True, System.Text.Encoding.Unicode, 1)
        outLogFile.WriteLine("L2ScriptMaker QuestPch/Pch2 Builder" & vbNewLine & Now.ToString & " Start" & vbNewLine)

        Dim sTemp As String
        Dim aTemp() As String = {}
        Dim iTemp As Integer

        Dim inQuestEFile As New System.IO.StreamReader("questname-e.txt", System.Text.Encoding.Default, True, 1)
        ProgressBar.Maximum = CInt(inQuestEFile.BaseStream.Length)
        ProgressBar.Value = 0
        StatusLabel.Text = "Loading quest names and generate quest_pch.txt ..."
        StatusLabel.Refresh()

        ' Loading Quests Name to QuestPchName and Generate quest_pch
        'quest_begin	id=257	level=1	name=[The Guard is Busy]
        'quest_begin	id=1	level=1	name=[Letters of Love]
        'Dim QuestPchName(2000) As String
        '[guard_is_busy1]	257
        '[letters_of_love1] 1

        While inQuestEFile.EndOfStream <> True

            sTemp = inQuestEFile.ReadLine
            'aTemp = sTemp.Split(Chr(9))
            'iTemp = CInt(aTemp(1).Remove(0, 3))
            iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "quest_id"))
            If QuestPchName(iTemp) = "" Then
                'QuestPchName(iTemp) = aTemp(3).Remove(0, 5)
                QuestPchName(iTemp) = Libraries.GetNeedParamFromStr(sTemp, "main_name")
                QuestPchName(iTemp) = QuestPchName(iTemp).Replace("  ", " ").Replace(" ", "_").ToLower.Trim
                QuestPchName(iTemp) = QuestPchName(iTemp).Replace("'", "").Replace("!", "").Replace(".", "").Replace(",", "").Replace("?", "")
                'outQuestPchFile.WriteLine(QuestPchName(iTemp) & vbTab & iTemp.ToString)
            End If

            ProgressBar.Value = CInt(inQuestEFile.BaseStream.Position)
        End While
        inQuestEFile.Close()
        ProgressBar.Value = 0

        'item_begin	weapon	1	[small_sword]	item_type=weapon	slot_bit_type={rhand}	armor_type=none	etcitem_type=none	recipe_id=0	blessed=0	weight=1600	default_action=action_equip	consume_type=consume_type_normal	initial_count=1	maximum_count=1	soulshot_count=1	spiritshot_count=1	reduced_soulshot={}	reduced_spiritshot={}	reduced_mp_consume={}	immediate_effect=1	price=0	default_price=768	item_skill=[none]	critical_attack_skill=[none]	attack_skill=[none]	magic_skill=[none]	item_skill_enchanted_four=[none]	material_type=steel	crystal_type=none	crystal_count=0	is_trade=1	is_drop=1	
        'is_destruct=1	physical_damage=8	random_damage=10	weapon_type=sword	can_penetrate=0	critical=8	hit_modify=0	avoid_modify=0	dual_fhit_rate=0	shield_defense=0	shield_defense_rate=0	attack_range=40	damage_range={0;0;40;120}	attack_speed=379	reuse_delay=0	mp_consume=0	magical_damage=6	durability=95	damaged=0	physical_defense=0	magical_defense=0	mp_bonus=0	category={}	enchanted=0	html=[item_default.htm]	equip_pet={0}	magic_weapon=0	enchant_enable=0	can_equip_sex=-1	can_equip_race={}	can_equip_change_class=-1	can_equip_class={}	can_equip_agit=-1	can_equip_castle=-1	can_equip_castle_num={}	can_equip_clan_leader=-1	can_equip_clan_level=-1	can_equip_hero=-1	can_equip_nobless=-1	can_equip_chaotic=-1	item_end
        'Dim UnDestrItems(30000) As String

        Array.Clear(aTemp, 0, aTemp.Length)
        Dim inItemFile As New System.IO.StreamReader("itemdata.txt", System.Text.Encoding.Default, True, 1)
        ProgressBar.Maximum = CInt(inItemFile.BaseStream.Length)
        ProgressBar.Value = 0
        StatusLabel.Text = "Loading itemdata and find all quest items ..."
        StatusLabel.Refresh()
        While inItemFile.EndOfStream <> True

            sTemp = inItemFile.ReadLine
            If Libraries.GetNeedParamFromStr(sTemp, "item_type") = "questitem" Then
                'If Libraries.GetNeedParamFromStr(sTemp, "is_destruct") = "0" Then
                sTemp = sTemp.Replace(" = ", "=").Replace("  ", " ").Replace(" ", Chr(9))
                aTemp = sTemp.Split(Chr(9))
                iTemp = CInt(aTemp(2))
                ' array protect
                If iTemp > UnDestrItems.Length Then
                    MessageBox.Show("Itemdata use item with id >30000", "Big ItemID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inItemFile.Close()
                    Exit Sub
                End If
                UnDestrItems(iTemp) = aTemp(3)
            End If

            ProgressBar.Value = CInt(inItemFile.BaseStream.Position)
        End While
        ProgressBar.Value = 0
        inItemFile.Close()

        'quest_begin	id=257	level=1	name=[The Guard is Busy]
        'quest_begin	id=1	level=1	name=[Letters of Love]
        'Dim QuestPchName(2000) As String
        '[guard_is_busy1]	257
        '[letters_of_love1] 1

        'push_const 337
        'func_call 184680547	//  func[GetMemoState]
        'push_const 337
        'func_call 184680543	//  func[HaveMemo]
        'push_const 337
        'func_call 184615017	//  func[SetCurrentQuestID]
        'push_const 3856
        'func_call 184680579	//  func[OwnItemCount]

        'Dim QuestPch2Name(2000) As String
        '257 4 1084 752 1085 1086  QuestPch2Name(257)
        '1 4 687 688 1079 1080     QuestPch2Name(1)

        Array.Clear(aTemp, 0, aTemp.Length)
        Dim sLastPushConst As String = "", sLastPushConst2 As String = ""
        Dim sLastQuestID As String = ""
        Dim sLastPushConstForOwnItem As String = ""
        Dim sLastClass As String = ""

        Dim inAiFile As New System.IO.StreamReader("ai.obj", System.Text.Encoding.Default, True, 1)
        ProgressBar.Maximum = CInt(inAiFile.BaseStream.Length)
        ProgressBar.Value = 0
        StatusLabel.Text = "Loading Ai.obj and find all quests ..."
        StatusLabel.Refresh()

        While inAiFile.EndOfStream <> True

            sTemp = inAiFile.ReadLine

            If sTemp.StartsWith("class ") = True Then
                sLastClass = sTemp
            End If
            If InStr(sTemp, "push_parameter ") <> 0 Then
                sLastPushConst2 = sLastPushConst
            End If
            If InStr(sTemp, "push_const ") <> 0 Then
                sLastPushConst2 = sLastPushConst
                sLastPushConst = sTemp.Replace("push_const", "").Replace(Chr(9), "").Replace(" ", "")
            End If

            If InStr(sTemp, "func_call") <> 0 Then
                If InStr(sTemp, "[SetCurrentQuestID]") <> 0 Then

                    ' Bug fix ">0" againts 'Song of Hunter' quest
                    If CInt(sLastPushConst) > 0 Then
                        sLastQuestID = sLastPushConst
                    Else
                        MessageBox.Show("Wrong Number into :" & sLastClass)
                    End If
                    
                    'ElseIf InStr(sTemp, "GetMemoState") <> 0 Then
                    'sLastQuestID = sLastPushConst
                    'ElseIf InStr(sTemp, "HaveMemo") <> 0 Then
                    'sLastQuestID = sLastPushConst
                End If

                If InStr(sTemp, "[DeleteItem1]") <> 0 Or InStr(sTemp, "[OwnItemCount]") <> 0 Then 'OwnItemCount GiveItem1 DeleteItem1
                    'Or InStr(sTemp, "[GiveItem1]") <> 0
                    'Or InStr(sTemp, "[OwnItemCount]") <> 0
                    If sLastQuestID <> "" Then
                        sLastPushConstForOwnItem = sLastPushConst

                        If InStr(sTemp, "[DeleteItem1]") <> 0 Then
                            sLastPushConstForOwnItem = sLastPushConst2
                        End If

                        ' PROCEDURE
                        If CInt(sLastPushConstForOwnItem) <= UnDestrItems.Length Then

                            If UnDestrItems(CInt(sLastPushConstForOwnItem)) <> "" Then
                                If sLastQuestID <> "" Then

                                    If QuestPchName(CInt(sLastQuestID)) = "" Then

                                        ' Undefined quest in questname-e
                                        outLogFile.WriteLine(vbNewLine & "Last class: " & sLastClass & vbNewLine & "Undefined QuestId: " & sLastQuestID & " for Item " & sLastPushConstForOwnItem & " " & UnDestrItems(CInt(sLastPushConstForOwnItem)))
                                        ' quest not exist in Questdata-e and not created in new list. Maybe later...
                                        If MakeUndefinedBox.Checked = True Then
                                            QuestPchName(CInt(sLastQuestID)) = "[autoquestgen_" & CInt(sLastQuestID).ToString & "]"
                                            QuestPch2Name(CInt(sLastQuestID)) = sLastPushConstForOwnItem
                                        End If
                                    Else

                                        If QuestPch2Name(CInt(sLastQuestID)) = "" Then
                                            ' Quest exist in quest_pch list, but no items
                                            QuestPch2Name(CInt(sLastQuestID)) = sLastPushConstForOwnItem
                                        Else
                                            ' Quest exist in quest_pch list, quest_pch2 record exist. check item in list
                                            Array.Clear(aTemp, 0, aTemp.Length)
                                            aTemp = QuestPch2Name(CInt(sLastQuestID)).Split(CChar(" "))
                                            If Array.IndexOf(aTemp, sLastPushConstForOwnItem) = -1 Then
                                                QuestPch2Name(CInt(sLastQuestID)) = QuestPch2Name(CInt(sLastQuestID)) & " " & sLastPushConstForOwnItem
                                            End If

                                        End If
                                    End If
                                End If
                            End If

                        Else
                            'check - bad item id
                            outLogFile.WriteLine(vbNewLine & "Last class: " & sLastClass & vbNewLine & "Bad value for item: " & sLastPushConstForOwnItem)
                        End If


                    End If

                End If
            End If

            If InStr(sTemp, "handler_end") <> 0 Then
                sLastPushConst = ""
                sLastQuestID = ""
                sLastPushConstForOwnItem = ""
            End If

            ProgressBar.Value = CInt(inAiFile.BaseStream.Position)

        End While
        ProgressBar.Value = 0
        inAiFile.Close()

        StatusLabel.Text = "Writing quest_pch.txt file ..."
        Dim outQuestPchFile As New System.IO.StreamWriter(QuestDataDir + "\quest_pch.txt", False, System.Text.Encoding.Unicode, 1)
        For iTemp = 0 To QuestPchName.Length - 1
            If QuestPchName(iTemp) <> "" Then
                outQuestPchFile.WriteLine(QuestPchName(iTemp) & vbTab & iTemp.ToString)
            End If
        Next
        outQuestPchFile.Close()

        StatusLabel.Text = "Writing quest_pch2.txt file ..."
        Dim outQuestPch2File As New System.IO.StreamWriter(QuestDataDir + "\quest_pch2.txt", False, System.Text.Encoding.Unicode, 1)
        For iTemp = 0 To QuestPch2Name.Length - 1
            If QuestPch2Name(iTemp) <> "" Then
                outQuestPch2File.WriteLine(iTemp.ToString & " " & QuestPch2Name(iTemp).Split(CChar(" ")).Length.ToString & " " & QuestPch2Name(iTemp))
            End If
        Next
        outQuestPch2File.Close()

        outLogFile.WriteLine(vbNewLine & Now.ToString & " End" & vbNewLine)
        outLogFile.Close()

        StatusLabel.Text = "Work complete ..."


    End Sub

    Private Sub QuestCacheScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuestCacheScript.Click

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II config (quest_pch.txt)|quest_pch.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim QuestDataDir As String = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName)
        If System.IO.File.Exists("quest_pch2.txt") = False Then
            MessageBox.Show("Required all files (quest_pch.txt and quest_pch2.txt) for generation", "quest_pch2.txt not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Initialization
        ProgressBar.Value = 0
        Dim inPchFile As New System.IO.StreamReader("quest_pch.txt", System.Text.Encoding.Default, True, 1)
        Dim inPch2File As New System.IO.StreamReader("quest_pch2.txt", System.Text.Encoding.Default, True, 1)
        Dim outData As New System.IO.StreamWriter("questcomp.txt", False, System.Text.Encoding.Unicode, 1)
        'Dim outData As New System.IO.StreamWriter(oFile, System.Text.Encoding.Unicode, 1)

        Dim ReadStr As String
        Dim ReadSplitStr() As String

        'quest_pch.txt      -   1 4 687 688 1079 1080 
        'quest_pch2.txt     -   [gourd_event]	997
        'questcomp.txt    -   [0001]	letters_of_love1	{687;688;1079;1080}

        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inPchFile.BaseStream.Length)
        Dim QuestDB(1000) As String
        While inPchFile.EndOfStream <> True

            ReadStr = inPchFile.ReadLine.Replace(Chr(9), Chr(32))
            If ReadStr <> Nothing Then
                If Mid(ReadStr, 1, 2) <> "//" Then
                    ReadSplitStr = ReadStr.Trim.Split
                    QuestDB(CInt(ReadSplitStr(1))) = ReadSplitStr(0).Replace("[", "").Replace("]", "")
                End If
            End If
            ProgressBar.Value = CInt(inPchFile.BaseStream.Position * 100 / inPchFile.BaseStream.Length)
        End While

        'quest_pch.txt      -   1 4 687 688 1079 1080 
        'quest_pch2.txt     -   [gourd_event]	997
        'questcomp-e.txt    -   [0001]	letters_of_love1	{687;688;1079;1080}

        ProgressBar.Maximum = CInt(inPch2File.BaseStream.Length)
        ProgressBar.Value = 0
        Do While inPch2File.BaseStream.Position <> inPch2File.BaseStream.Length

            ReadStr = inPch2File.ReadLine.Replace(Chr(9), Chr(32))

            If ReadStr <> Nothing Then
                If Mid(Trim(ReadStr), 1, 2) <> "//" Then

                    ReadSplitStr = ReadStr.Trim.Split(Chr(32))

                    outData.Write("[" + CInt(ReadSplitStr(0)).ToString.PadLeft(4, CChar("0")) + "]" + Chr(9))
                    outData.Write(QuestDB(CInt(ReadSplitStr(0))) + Chr(9))

                    outData.Write("{")
                    Dim Marker As Integer
                    For Marker = 2 To ReadSplitStr.Length - 1
                        If Marker > 2 Then outData.Write(";")
                        outData.Write(ReadSplitStr(Marker))
                    Next

                    outData.WriteLine("}")


                End If
            End If

            ProgressBar.Value = CInt(inPch2File.BaseStream.Position * 100 / inPch2File.BaseStream.Length)
        Loop

        MessageBox.Show("questcomp-e Complete")
        ProgressBar.Value = 0
        inPchFile.Close()
        inPch2File.Close()
        outData.Close()

    End Sub

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        'Me.Dispose()
        Me.Close()
    End Sub

End Class
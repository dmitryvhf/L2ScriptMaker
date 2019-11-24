Public Class L2J_NpcData_Drop

    Private Structure DropList
        Dim itemId As Integer
        Dim min As Integer
        Dim max As Integer
        Dim category As Integer
        Dim chance As Double
    End Structure

    Private Function FixDropBlock(ByVal sTemp As String) As String

        If sTemp.IndexOf(")") = 0 Then Return Nothing
        sTemp = sTemp.Substring(1, sTemp.IndexOf(")") - 1)

        Return sTemp
    End Function

    Private Sub ButtonDropChanceUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDropChanceUpdate.Click

        Dim iTemp As Integer
        Dim sTemp As String
        Dim aTemp() As String

        ' Constants
        ' ----------
        Dim sealStones() As String = {"6360", "6361", "6362"} ' Blue/Green/Red Seal Stone
        Dim iRateAdena As UInteger = 1
        Dim iRateSealstones As UInteger = 1
        Dim iRateDrop As UInteger = 1
        Dim iRateDropRb As UInteger = 1
        Dim iRateSpoil As UInteger = 1
        Dim iRateHerb As UInteger = 1
        Const iRateLimit As UInteger = 1000000    ' 100 * 10000
        Dim aNpcIgnore(1000) As String   ' Raidboss list

        Try
            iRateAdena = CUInt(TextBoxRateAdena.Text)
            iRateSealstones = CUInt(TextBoxRateSealstones.Text)
            iRateDrop = CUInt(TextBoxRateDrop.Text)
            iRateDropRb = CUInt(TextBoxRateDropRB.Text)
            iRateSpoil = CUInt(TextBoxRateSpoil.Text)
            iRateHerb = CUInt(TextBoxRateHerb.Text)
        Catch ex As Exception
            MessageBox.Show("Enter only integer numbers to rate value." & vbNewLine & ex.Message)
            Exit Sub
        End Try

        Dim inFile As System.IO.StreamReader
        Dim outFile As System.IO.StreamWriter

        ' LOADING ignorenpclist.txt 
        If CheckBoxSpecNpcList.Checked = True Then
            If System.IO.File.Exists("raidlist.csv") = False Then
                MessageBox.Show("raidlist.csv not found", "raidlist.csv", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            inFile = New System.IO.StreamReader("raidlist.csv", System.Text.Encoding.Default, True, 1)
            ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
            ToolStripStatusLabel.Text = "Loading raidlist.csv ..."

            While inFile.EndOfStream <> True
                sTemp = inFile.ReadLine.Trim
                ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

                If sTemp.Length = 0 Then Continue While
                If CInt(sTemp) = 0 Then Continue While
                aNpcIgnore(Array.IndexOf(aNpcIgnore, Nothing)) = sTemp
            End While

            'inFile = New System.IO.StreamReader("NpcName-e.txt", System.Text.Encoding.Default, True, 1)
            'ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
            'ToolStripStatusLabel.Text = "Loading NpcName-e.txt ..."
            ''        Dim iSpecialBoss() As Integer = {18465, 22326, 22341, 25539, 29021, 12532, 12533, 12534, 12539, 12540, 12541, 12542, 12543, 29045, 29046}

            'outFile = New System.IO.StreamWriter("npcignorelist.sql", False, System.Text.Encoding.ASCII, 1)
            ''outFile.WriteLine ("UPDATE `npc` SET type = '")
            'While inFile.EndOfStream <> True

            '    sTemp = inFile.ReadLine.Trim
            '    ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            '    sTemp = sTemp.Trim
            '    If sTemp.StartsWith("npcname_begin") = True Then
            '        'npcname_begin	id=25001	name=[Greyclaw Kutus]	description=[Raid Boss]	            rgb[0]=[3F]	rgb[1]=[8B]	rgb[2]=[FE]	reserved1=-1	npcname_end
            '        'npcname_begin	id=25563	name=[Beautiful Atrielle]	description=[Forsaken Prisoner]	rgb[0]=[3F]	rgb[1]=[8B]	rgb[2]=[FE]	reserved1=-1	npcname_end
            '        'npcname_begin	id=20001	name=[Gremlin]	        description=[]	                    rgb[0]=[9C]	rgb[1]=[E8]	rgb[2]=[A9]	reserved1=-1	npcname_end
            '        'npcname_begin	id=29028	name=[Valakas]	description=[Fire Dragon]	                rgb[0]=[9C]	rgb[1]=[E8]	rgb[2]=[A9]	reserved1=-1	npcname_end
            '        If Libraries.GetNeedParamFromStr(sTemp, "rgb[0]") = "[3F]" And Libraries.GetNeedParamFromStr(sTemp, "rgb[1]") = "[8B]" _
            '            And Libraries.GetNeedParamFromStr(sTemp, "rgb[2]") = "[FE]" Then
            '            aNpcIgnore(Array.IndexOf(aNpcIgnore, Nothing)) = Libraries.GetNeedParamFromStr(sTemp, "id")
            '            outFile.WriteLine(Libraries.GetNeedParamFromStr(sTemp, "id"))
            '        End If
            '    End If

            'End While
            'outFile.Flush()

            inFile.Close()
            ToolStripProgressBar.Value = 0
        End If

        ' LOADING itemdata-e.txt
        If System.IO.File.Exists("ItemName-e.txt") = False Then
            MessageBox.Show("ItemName-e.txt not found", "Need ItemName-e.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aItemdata(30000) As String
        inFile = New System.IO.StreamReader("ItemName-e.txt", System.Text.Encoding.Default, True, 1)
        inFile = New System.IO.StreamReader("~ItemName-e_new.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading ItemName-e.txt ..."

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            ' If sTemp.StartsWith("itemname_begin") = False Then Continue While
            If sTemp.StartsWith("~ItemName_begin") = False Then Continue While

            'itemname_begin	id=17	name=[Wooden Arrow]	
            iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "id"))
            sTemp = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "")
            Try
                aItemdata(iTemp) = sTemp
            Catch ex As Exception
                MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" & vbNewLine & sTemp)
                inFile.Close()
                Exit Sub
            End Try

        End While
        inFile.Close()
        ToolStripProgressBar.Value = 0

        ' --------------
        ' MAIN ENGINE 

        If System.IO.File.Exists("droplist.sql") = False Then
            MessageBox.Show("droplist.sql not found", "droplist.sql", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        System.IO.File.Copy("droplist.sql", "droplist.sql.bak", True)
        inFile = New System.IO.StreamReader("droplist.sql.bak", System.Text.Encoding.Default, True, 1)
        outFile = New System.IO.StreamWriter("droplist.sql", False, System.Text.Encoding.ASCII, 1)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading droplist.sql ..."

        Dim sPrevNpcId As String = "", sCurNpcId As String = ""
        Dim sPrevCategory As String = "", sCurCategory As String = ""
        Dim sEndSymb As Char = CChar(","), sItemName As String

        Dim iChanceSumm As UInteger
        Dim iGroupNum As UInteger

        While inFile.EndOfStream <> True

            '(18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
            '(18001,57,765,1528,0,700000),-- Adena
            '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
            ' mobid , itemid, min, max, category/group , change*10000

            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

            If sTemp.StartsWith("(") = True Then

                If sTemp.IndexOf(";") > 0 Then sEndSymb = CChar(";") Else sEndSymb = CChar(",")

                sTemp = FixDropBlock(sTemp)
                aTemp = sTemp.Split(CChar(","))

                sCurNpcId = aTemp(0)
                sCurCategory = aTemp(4)

                If sPrevNpcId = "" Then
                    sPrevNpcId = sCurNpcId
                End If
                If sPrevCategory = "" Then
                    sPrevCategory = sCurCategory
                End If

                ' CHANCE CHECKER ENGINE

                If sPrevNpcId <> sCurNpcId Then
                    iGroupNum = 0
                End If

                If sPrevNpcId <> sCurNpcId Or sCurCategory <> sPrevCategory Then
                    If iChanceSumm > iRateLimit And sPrevCategory <> "-1" Then
                        outFile.WriteLine("-- Attention!!! Previous group have wrong group chance: [" & iChanceSumm.ToString & "]")
                    End If
                    iChanceSumm = 0
                End If
                iChanceSumm = iChanceSumm + CUInt(aTemp(5))

                If aItemdata(CInt(aTemp(1))) <> Nothing Then
                    sItemName = aItemdata(CInt(aTemp(1))).Replace("'", "")
                Else
                    sItemName = "undefined item"
                End If

                '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
                ' mobid , itemid, min, max, category/group , change*10000

                ' -------------------
                ' RATE CHANCE ENGINE
                ' -------------------
                If aTemp(1) = "57" Then
                    'ADENA RATE

                    aTemp(2) = (CUInt(aTemp(2)) * iRateAdena).ToString
                    aTemp(3) = (CUInt(aTemp(3)) * iRateAdena).ToString

                ElseIf Array.IndexOf(sealStones, aTemp(1)) <> -1 Then
                    ' SEALSTONES RATE
                    aTemp(2) = (CUInt(aTemp(2)) * iRateSealstones).ToString
                    aTemp(3) = (CUInt(aTemp(3)) * iRateSealstones).ToString
                Else

                    If sCurCategory = "-1" Then
                        ' SPOIL RATE
                        If CUInt(aTemp(5)) * iRateSpoil > iRateLimit Then
                            'aTemp(1) = aTemp(1)
                            aTemp(2) = (CUInt(aTemp(2)) * iRateSpoil).ToString
                            aTemp(3) = (CUInt(aTemp(3)) * iRateSpoil).ToString
                        Else
                            'aTemp(5) = CDbl(Format((CDbl(aTemp(5)) * iRateSpoil), "0.######")).ToString
                            aTemp(5) = (CUInt(aTemp(5)) * iRateSpoil).ToString
                        End If

                    Else

                        If aItemdata(CInt(aTemp(1))).IndexOf("Herb") <> -1 Then
                            ' HERB ENGINE
                            If CDbl(aTemp(5)) * iRateHerb <= iRateLimit Then
                                'aTemp(5) = CDbl(Format((CDbl(aTemp(5)) * iRateHerb), "0.######")).ToString
                                aTemp(5) = (CInt(aTemp(5)) * iRateHerb).ToString
                            Else
                                aTemp(5) = iRateLimit.ToString
                            End If

                        Else

                            ' DROP ENGINE
                            If CheckBoxSpecNpcList.Checked = False Then
                                ' SIMPLE DROP RATE ENGINE
                                If CUInt(aTemp(5)) * iRateDrop > iRateLimit Then
                                    'aTemp(1) = aTemp(1)
                                    aTemp(2) = (CUInt(aTemp(2)) * iRateDrop).ToString
                                    aTemp(3) = (CUInt(aTemp(3)) * iRateDrop).ToString
                                Else
                                    'aTemp(5) = CDbl(Format((CDbl(aTemp(5)) * iRateDrop), "0.######")).ToString
                                    aTemp(5) = (CUInt(aTemp(5)) * iRateDrop).ToString
                                End If

                            Else

                                ' SPECIAL NPC LIST USE
                                iTemp = Array.IndexOf(aNpcIgnore, aTemp(0))

                                ' RadioButtonIgnoreDropNpc
                                ' RadioButtonRateChanceOnly

                                'If (RadioButtonIgnoreDropNpc.Checked = True Or RadioButtonRateChanceOnly.Checked = True) And iTemp = -1 Then
                                If iTemp = -1 Then

                                    ' ALL OTHERS
                                    If CUInt(aTemp(5)) * iRateDrop > iRateLimit Then
                                        aTemp(2) = (CUInt(aTemp(2)) * iRateDrop).ToString
                                        aTemp(3) = (CUInt(aTemp(3)) * iRateDrop).ToString
                                        'int fixation
                                        aTemp(5) = CUInt(aTemp(5)).ToString
                                    Else
                                        aTemp(5) = (CUInt(aTemp(5)) * iRateDrop).ToString
                                    End If

                                ElseIf RadioButtonRateChanceOnly.Checked = True And iTemp <> -1 Then

                                    ' NPC FROM LIST WILL BE Rate ONLY chances
                                    If (CUInt(aTemp(5)) * iRateDropRb) + iChanceSumm > iRateLimit Then
                                        aTemp(5) = iRateLimit.ToString
                                        iGroupNum = CUInt(iGroupNum + 1)
                                        aTemp(4) = CStr(iGroupNum)
                                    Else
                                        aTemp(5) = (CUInt(aTemp(5)) * iRateDropRb).ToString
                                        If iGroupNum <> CUInt(aTemp(4)) Then
                                            iGroupNum = CUInt(iGroupNum + 1)
                                            aTemp(4) = CStr(iGroupNum)
                                        Else
                                            iGroupNum = CUInt(aTemp(4))
                                        End If
                                    End If
                                Else
                                    'MessageBox.Show("!!! alarm! [" & aTemp(0) & "|" & aTemp(1) & "|" & aTemp(2) & "|" & aTemp(3) & "]")
                                End If


                            End If
                        End If
                    End If

                End If

                sTemp = Join(aTemp, ",")
                sTemp = "(" & sTemp & ")" & sEndSymb & "-- " & sItemName
                sPrevNpcId = sCurNpcId
                sPrevCategory = sCurCategory


            End If

            outFile.WriteLine(sTemp)

        End While
        outFile.Flush() : outFile.Close()
        inFile.Close()
        ToolStripProgressBar.Value = 0

        MessageBox.Show("Done.")
        ToolStripStatusLabel.Text = "Done."

    End Sub

    Private Sub ButtonStartPTSL2J_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStartPTSL2J.Click


        MessageBox.Show("No work yet.")
        Exit Sub

        'Dim sSpawnListFile As String
        'Dim sTemp As String
        'Dim aTemp() As String

        'Dim inFile As System.IO.StreamReader
        'Dim outFile As System.IO.StreamWriter


        '' LOADING npc_pch.txt
        'If System.IO.File.Exists("npc_pch.txt") = False Then
        '    MessageBox.Show("npc_pch.txt not found", "Need npc_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'Dim aNpcPch(40000) As String
        'inFile = New System.IO.StreamReader("npc_pch.txt", System.Text.Encoding.Default, True, 1)
        'ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        'ToolStripStatusLabel.Text = "Loading npc_pch.txt ..."

        'While inFile.EndOfStream <> True

        '    sTemp = inFile.ReadLine.Trim
        '    ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
        '    If sTemp <> "" And sTemp.StartsWith("//") = False Then

        '        '[pet_wolf_a] = 1012077
        '        sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
        '        aTemp = sTemp.Split(CChar("="))
        '        Try
        '            aNpcPch(CInt(aTemp(1)) - 1000000) = aTemp(0)
        '        Catch ex As Exception
        '            MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" & vbNewLine & sTemp)
        '            inFile.Close()
        '            Exit Sub
        '        End Try

        '    End If

        'End While
        'inFile.Close()
        'ToolStripProgressBar.Value = 0

        '' LOADING item_pch.txt
        'If System.IO.File.Exists("item_pch.txt") = False Then
        '    MessageBox.Show("item_pch.txt not found", "Need item_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'Dim aItemPch(25000) As String
        'inFile = New System.IO.StreamReader("item_pch.txt", System.Text.Encoding.Default, True, 1)
        'ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        'ToolStripStatusLabel.Text = "Loading item_pch.txt ..."

        'While inFile.EndOfStream <> True

        '    sTemp = inFile.ReadLine.Trim
        '    ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
        '    If sTemp <> "" And sTemp.StartsWith("//") = False Then

        '        '[small_sword] = 1
        '        sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
        '        aTemp = sTemp.Split(CChar("="))
        '        Try
        '            aItemPch(CInt(aTemp(1))) = aTemp(0)
        '        Catch ex As Exception
        '            MessageBox.Show("Error in loading item_pch.txt. Last reading line:" & vbNewLine & sTemp)
        '            inFile.Close()
        '            Exit Sub
        '        End Try

        '    End If

        'End While
        'inFile.Close()
        'ToolStripProgressBar.Value = 0


        '' PREPARATION droplist.sql
        'OpenFileDialog.Filter = "PTS NpcData (npcdata.txt)|npcdata.txt|All files|*.*"
        'If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        'ToolStripStatusLabel.Text = "Preparation droplist.sql..."
        'Me.Update()
        'sSpawnListFile = OpenFileDialog.FileName
        'inFile = New System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, True, 1)
        'outFile = New System.IO.StreamWriter("droplist.sql", True, System.Text.Encoding.Unicode, 1)
        '' Dim sTemp2 As String

        'ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        'ToolStripStatusLabel.Text = "Saving new droplist.sql ..."

        'While inFile.EndOfStream <> True
        '    sTemp = inFile.ReadLine.Trim
        '    ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
        '    ' Me.Update()
        '    If sTemp.StartsWith("npc_begin") = False Then Continue While

        '    'corpse_make_list={{[charcoal];1;1;5.6617};{[magic_ring];1;1;45.2932};{[rp_broad_sword];1;1;4.5293}}	
        '    'additional_make_list={}   ' используется для томбстоунов и т.п. клан дропа для кланскилов 100,101
        '    'additional_make_multi_list={{{{[adena];30;42;100}};70};{{{[apprentice's_earing];1;1;30.627};{[necklace_of_magic];1;1;22.8201};{[magic_ring];1;1;46.5529}};33.529};{{{[stem];1;1;29.1262};{[varnish];1;1;14.5631};{[suede];1;1;9.7087};{[silver_nugget];1;1;5.8252};{[thread];1;1;29.1262};{[rp_bow];1;1;11.6506}};6.6988}}	ex_item_drop_list={{{{[herb_of_hp_a];1;1;55};{[greater_herb_of_hp_a];1;1;38};{[full_herb_of_hp_a];1;1;7}};42};{{{[herb_of_mp_a];1;1;50};{[greater_herb_of_mp_a];1;1;43};{[full_herb_of_mp_a];1;1;7}};11};{{{[herb_of_pa];1;1;20};{[herb_of_pa_speed];1;1;20};{[herb_of_crt_rate];1;1;20};{[vampiric_rage_herb];1;1;20};{[death_whisper_herb];1;1;20}};25};{{{[herb_of_ma];1;1;50};{[herb_of_ma_speed];1;1;50}};10};{{{[figher_herb];1;1;33};{[magician_herb];1;1;33};{[recovery_herb];1;1;34}};1};{{{[herb_of_move_speed];1;1;94};{[big_head_herb];1;1;3};{[vitality_herb1];1;1;3}};11}}	


        '    '(18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
        '    '(18001,57,765,1528,0,700000),-- Adena
        '    '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
        '    ' mobid , itemid, min, max, category/group , change*10000

        '    sTemp = sTemp.Substring(InStr(sTemp, "("), InStr(sTemp, ")") - InStr(sTemp, "(") - 1)
        '    outFile.WriteLine(sTemp)

        'End While
        'outFile.Flush()
        'outFile.Close()
        'inFile.Close()
        'ToolStripProgressBar.Value = 0
        'System.IO.File.Move(sSpawnListFile, sSpawnListFile & ".orig")




    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStartL2JPTS.Click

        Dim sSpawnListFile As String
        Dim sTemp As String
        Dim aTemp() As String

        Dim inSpawnFile As System.IO.StreamReader
        Dim outFile As System.IO.StreamWriter


        ' LOADING npc_pch.txt
        If System.IO.File.Exists("npc_pch.txt") = False Then
            MessageBox.Show("npc_pch.txt not found", "Need npc_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aNpcPch(40000) As String
        inSpawnFile = New System.IO.StreamReader("npc_pch.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npc_pch.txt ..."

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                '[pet_wolf_a] = 1012077
                sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
                aTemp = sTemp.Split(CChar("="))
                Try
                    aNpcPch(CInt(aTemp(1)) - 1000000) = aTemp(0)
                Catch ex As Exception
                    MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" & vbNewLine & sTemp)
                    inSpawnFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0

        ' LOADING item_pch.txt
        If System.IO.File.Exists("item_pch.txt") = False Then
            MessageBox.Show("item_pch.txt not found", "Need item_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aItemPch(25000) As String
        inSpawnFile = New System.IO.StreamReader("item_pch.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading item_pch.txt ..."

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                '[small_sword] = 1
                sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
                aTemp = sTemp.Split(CChar("="))
                Try
                    aItemPch(CInt(aTemp(1))) = aTemp(0)
                Catch ex As Exception
                    MessageBox.Show("Error in loading item_pch.txt. Last reading line:" & vbNewLine & sTemp)
                    inSpawnFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0

        ' PREPARATION droplist.sql
        OpenFileDialog.Filter = "L2J NpcData Drop (droplist.sql)|droplist.sql|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        ToolStripStatusLabel.Text = "Preparation droplist.sql..."
        Me.Update()
        sSpawnListFile = OpenFileDialog.FileName
        inSpawnFile = New System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, True, 1)
        Dim sTemp2 As String

        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading item_pch.txt ..."

        System.IO.Directory.CreateDirectory("~droptmp")
        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            Me.Update()

            If sTemp <> "" And sTemp.StartsWith("(") = True Then 'sTemp.StartsWith("--")=False

                sTemp2 = sTemp.Substring(InStr(sTemp, "("), InStr(sTemp, ")") - InStr(sTemp, "(") - 1)
                sTemp2 = sTemp2.Replace("'", "")
                aTemp = sTemp2.Split(CChar(","))

                '(18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
                outFile = New System.IO.StreamWriter("~droptmp\" & aTemp(0) & ".txt", True, System.Text.Encoding.Unicode, 1)
                outFile.WriteLine(sTemp)
                outFile.Close()

            End If
        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0
        System.IO.File.Move(sSpawnListFile, sSpawnListFile & ".orig")

        ' COLLECT NEW droplist.sql
        Dim iNpcCount As Integer = 0
        outFile = New System.IO.StreamWriter(sSpawnListFile, False, System.Text.Encoding.Unicode, 1)
        aTemp = System.IO.Directory.GetFiles("~droptmp")
        ToolStripProgressBar.Maximum = CInt(aTemp.Length - 1)
        ToolStripStatusLabel.Text = "Loading item_pch.txt ..."

        For iNpcCount = 0 To aTemp.Length - 1
            ToolStripProgressBar.Value = iNpcCount
            inSpawnFile = New System.IO.StreamReader(aTemp(iNpcCount), System.Text.Encoding.Default, True, 1)
            outFile.Write(inSpawnFile.ReadToEnd)
            inSpawnFile.Close()
        Next
        outFile.Close()

        System.IO.Directory.Delete("~droptmp", True)

        Array.Clear(aTemp, 0, aTemp.Length)
        Array.Resize(aTemp, 0)

        outFile = New System.IO.StreamWriter("npcdata_drop_l2j.txt", False, System.Text.Encoding.Unicode, 1)
        inSpawnFile = New System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading droplist.sql..."

        Dim sCurNpcName As String = "", sPrevNpcName As String = Nothing
        Dim sTempNpcName As String, sTempItemName As String
        'Dim sTempDropSpoil As String, sTempDropItems As String
        Dim bItemCategory As Boolean = False

        Dim aItemList(0) As DropList
        Dim aItemCategory(255) As String
        Dim aItemMiss(0) As Integer
        Dim aNpcMiss(0) As Integer

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("(") = True Then 'sTemp.StartsWith("--")=False

                ' ---------- Prepare for importing
                '  `mobId` INT NOT NULL DEFAULT '0',
                '  `itemId` INT NOT NULL DEFAULT '0',
                '  `min` INT NOT NULL DEFAULT '0',
                '  `max` INT NOT NULL DEFAULT '0',
                '  `category` INT NOT NULL DEFAULT '0',
                '  `chance` INT NOT NULL DEFAULT '0',

                '(18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
                '(18001,57,765,1528,0,700000),-- Adena
                '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
                '(18001,4070,1,1,1,3192),-- Stockings of Zubei Fabric
                '(18001,4071,1,1,1,1615),-- Avadon Robe Fabric
                '(18001,1419,1,1,2,200000),-- Blood Mark
                '(18001,1864,1,1,2,166667),-- Stem

                sTemp = sTemp.Substring(InStr(sTemp, "("), InStr(sTemp, ")") - InStr(sTemp, "(") - 1)
                sTemp = sTemp.Replace("'", "")
                aTemp = sTemp.Split(CChar(","))

                ' 0     1    2 3 4 5
                '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric

                sCurNpcName = aTemp(0)
                If CInt(aTemp(1)) > 25000 Then
                    MessageBox.Show("Wrong item_id [" & aTemp(0) & "] in line" & vbNewLine & sTemp)
                    inSpawnFile.Close()
                    outFile.Close()
                    ToolStripProgressBar.Value = 0
                    Exit Sub
                End If

                If sPrevNpcName = Nothing Then sPrevNpcName = sCurNpcName
                If sCurNpcName <> sPrevNpcName Then

                    ' Checking exising npc in NpcPch
                    If aNpcPch(CInt(sPrevNpcName)) = Nothing Then
                        If Array.IndexOf(aNpcMiss, sPrevNpcName) = -1 Then
                            aNpcMiss(aNpcMiss.Length - 1) = CInt(sPrevNpcName)
                            Array.Resize(aNpcMiss, aNpcMiss.Length + 1)
                        End If

                        sTempNpcName = "[_need_" & sPrevNpcName & "_]"
                    Else
                        sTempNpcName = aNpcPch(CInt(sPrevNpcName))
                    End If

                    ' Start writing npc
                    'npc_begin	warrior	20761	[pytan]
                    outFile.Write("npc_begin" & Chr(9) & "warrior" & Chr(9) & sPrevNpcName & Chr(9) & sTempNpcName & Chr(9))

                    For iTemp = 0 To iNpcCount - 1

                        'sTempItemName
                        ' Checking exising Items in ItemPch
                        If aItemPch(aItemList(iTemp).itemId) = Nothing Then
                            If Array.IndexOf(aItemMiss, aItemList(iTemp).itemId) = -1 Then
                                aItemMiss(aItemMiss.Length - 1) = aItemList(iTemp).itemId
                                Array.Resize(aItemMiss, aItemMiss.Length + 1)
                            End If
                            sTempItemName = "[_need_" & CInt(aItemList(iTemp).itemId) & "_]"
                        Else
                            sTempItemName = aItemPch(aItemList(iTemp).itemId)
                        End If

                        'corpse_make_list={
                        '{[rp_soulshot_a];1;1;0.9041};{[oriharukon_ore];1;1;45.2069};{[stone_of_purity];1;1;45.2069}  }	

                        If aItemList(iTemp).category = -1 Then
                            If aItemCategory(255) <> Nothing Then _
                                aItemCategory(255) = aItemCategory(255) & ";"
                            aItemCategory(255) = aItemCategory(255) & "{" & sTempItemName & ";" & aItemList(iTemp).min & ";" & aItemList(iTemp).max & ";" & aItemList(iTemp).chance & "}"
                        Else
                            If aItemCategory(aItemList(iTemp).category) <> Nothing Then _
                                aItemCategory(aItemList(iTemp).category) = aItemCategory(aItemList(iTemp).category) & ";"
                            aItemCategory(aItemList(iTemp).category) = aItemCategory(aItemList(iTemp).category) & "{" & sTempItemName & ";" & aItemList(iTemp).min & ";" & aItemList(iTemp).max & ";" & aItemList(iTemp).chance & "}"

                        End If

                        'additional_make_multi_list={
                        '{{{[adena];3286;6671;100}};70};
                        '{{{[sealed_dark_crystal_breastplate];1;1;30.61224};{[sealed_dark_crystal_gaiters];1;1;48.97959};{[sealed_tallum_plate_armor];1;1;20.40816}};0.0049};
                        '{{{[sealed_dark_crystal_gaiters_pattern];1;1;0.97862};{[sealed_tallum_plate_armor_pattern];1;1;0.45199};{[sealed_dark_crystal_breastplate_pattern];1;1;0.64022};{[iron_thread];1;1;6.91546};{[rp_sealed_majestic_leather_mail_i];1;1;0.05709};{[rp_hose_of_doom_i];1;1;0.28606};{[red_dimension_stone];1;1;0.11448};{[compound_braid];1;1;4.13007};{[silver_nugget];1;1;24.7801};{[thread];1;3;59.47248};{[thons];1;1;1.42972};{[life_stone_level_671];1;1;0.68661};{[mid_grade_life_stone_level_671];1;1;0.05709}};33.629}}	

                    Next

                    outFile.Write("corpse_make_list={" & aItemCategory(255) & "}")
                    outFile.Write(Chr(9) & "additional_make_multi_list={")
                    For iNpcCount = 0 To 254
                        If aItemCategory(iNpcCount) <> Nothing Then
                            If bItemCategory = True Then outFile.Write(";")
                            outFile.Write("{{" & aItemCategory(iNpcCount) & "};100}")
                            bItemCategory = True
                        End If
                    Next
                    bItemCategory = False
                    outFile.Write("}" & Chr(9))
                    outFile.WriteLine("npc_end")

                    iNpcCount = 0
                    Array.Clear(aItemList, 0, aItemList.Length)
                    Array.Resize(aItemList, 1)

                    Array.Clear(aItemCategory, 0, aItemCategory.Length)

                    'sCurNpcName = sPrevNpcName
                    'sTempDropSpoil = ""
                    'sTempDropItems = ""
                    sPrevNpcName = sCurNpcName

                End If

                ' ADD new Drop Items to Array
                Array.Resize(aItemList, iNpcCount + 1)

                ' 0     1    2 3 4 5
                '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric

                aItemList(iNpcCount).itemId = CInt(aTemp(1))
                aItemList(iNpcCount).min = CInt(aTemp(2))
                aItemList(iNpcCount).max = CInt(aTemp(3))
                aItemList(iNpcCount).category = CInt(aTemp(4))
                aItemList(iNpcCount).chance = CInt(aTemp(5)) / 10000

                iNpcCount = iNpcCount + 1

            End If

        End While
        ToolStripProgressBar.Value = 0
        inSpawnFile.Close()
        outFile.Close()

        If aNpcMiss.Length > 0 Then
            outFile = New System.IO.StreamWriter("npcdata_drop_l2j.log", False, System.Text.Encoding.Unicode, 1)
            outFile.WriteLine("Missed Npc. Required for NpcData drop:")
            For iNpcCount = 0 To aNpcMiss.Length - 2
                outFile.WriteLine("npc_id=" & aNpcMiss(iNpcCount))
            Next
            outFile.Close()
        End If
        If aItemMiss.Length > 0 Then
            outFile = New System.IO.StreamWriter("npcdata_drop_l2j.log", True, System.Text.Encoding.Unicode, 1)
            outFile.WriteLine("Missed Items. Required for NpcData drop:")
            For iNpcCount = 0 To aItemMiss.Length - 2
                outFile.WriteLine("item_id=" & aItemMiss(iNpcCount))
            Next
            outFile.Close()
        End If


        MessageBox.Show("Completed. With [" & aItemMiss.Length - 1 & "] missed item's [" & aNpcMiss.Length - 1 & "] missed npc's.")

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub


    Private Sub OldButtonStart()

        Dim sSpawnListFile As String
        Dim sTemp As String
        Dim aTemp() As String

        Dim inSpawnFile As System.IO.StreamReader


        ' LOADING npc_pch.txt
        If System.IO.File.Exists("npc_pch.txt") = False Then
            MessageBox.Show("npc_pch.txt not found", "Need npc_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aNpcPch(40000) As String
        inSpawnFile = New System.IO.StreamReader("npc_pch.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npc_pch.txt ..."

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                '[pet_wolf_a] = 1012077
                sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
                aTemp = sTemp.Split(CChar("="))
                Try
                    aNpcPch(CInt(aTemp(1)) - 1000000) = aTemp(0)
                Catch ex As Exception
                    MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" & vbNewLine & sTemp)
                    inSpawnFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0

        ' LOADING item_pch.txt
        If System.IO.File.Exists("item_pch.txt") = False Then
            MessageBox.Show("item_pch.txt not found", "Need item_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aItemPch(25000) As String
        inSpawnFile = New System.IO.StreamReader("item_pch.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading item_pch.txt ..."

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                '[small_sword] = 1
                sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
                aTemp = sTemp.Split(CChar("="))
                Try
                    aItemPch(CInt(aTemp(1))) = aTemp(0)
                Catch ex As Exception
                    MessageBox.Show("Error in loading item_pch.txt. Last reading line:" & vbNewLine & sTemp)
                    inSpawnFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0

        OpenFileDialog.Filter = "L2J NpcData Drop (droplist.sql)|droplist.sql|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sSpawnListFile = OpenFileDialog.FileName
        inSpawnFile = New System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter("npcdata_drop_l2j.txt", False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading droplist.sql..."

        Dim iNpcCount As Integer = 0
        Dim sCurNpcName As String = "", sPrevNpcName As String = Nothing
        Dim sTempNpcName As String, sTempItemName As String
        'Dim sTempDropSpoil As String, sTempDropItems As String
        Dim bItemCategory As Boolean = False

        Dim aItemList(0) As DropList
        Dim aItemCategory(255) As String
        Dim aItemMiss(0) As Integer
        Dim aNpcMiss(0) As Integer

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("(") = True Then 'sTemp.StartsWith("--")=False

                ' ---------- Prepare for importing
                '  `mobId` INT NOT NULL DEFAULT '0',
                '  `itemId` INT NOT NULL DEFAULT '0',
                '  `min` INT NOT NULL DEFAULT '0',
                '  `max` INT NOT NULL DEFAULT '0',
                '  `category` INT NOT NULL DEFAULT '0',
                '  `chance` INT NOT NULL DEFAULT '0',

                '(18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
                '(18001,57,765,1528,0,700000),-- Adena
                '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
                '(18001,4070,1,1,1,3192),-- Stockings of Zubei Fabric
                '(18001,4071,1,1,1,1615),-- Avadon Robe Fabric
                '(18001,1419,1,1,2,200000),-- Blood Mark
                '(18001,1864,1,1,2,166667),-- Stem

                sTemp = sTemp.Substring(InStr(sTemp, "("), InStr(sTemp, ")") - InStr(sTemp, "(") - 1)
                sTemp = sTemp.Replace("'", "")
                aTemp = sTemp.Split(CChar(","))

                ' 0     1    2 3 4 5
                '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric

                sCurNpcName = aTemp(0)
                If CInt(aTemp(1)) > 25000 Then
                    MessageBox.Show("Wrong item_id [" & aTemp(0) & "] in line" & vbNewLine & sTemp)
                    inSpawnFile.Close()
                    outFile.Close()
                    ToolStripProgressBar.Value = 0
                    Exit Sub
                End If

                If sPrevNpcName = Nothing Then sPrevNpcName = sCurNpcName
                If sCurNpcName <> sPrevNpcName Then

                    ' Checking exising npc in NpcPch
                    If aNpcPch(CInt(sPrevNpcName)) = Nothing Then
                        If Array.IndexOf(aNpcMiss, sPrevNpcName) = -1 Then
                            aNpcMiss(aNpcMiss.Length - 1) = CInt(sPrevNpcName)
                            Array.Resize(aNpcMiss, aNpcMiss.Length + 1)
                        End If

                        sTempNpcName = "[_need_" & sPrevNpcName & "_]"
                    Else
                        sTempNpcName = aNpcPch(CInt(sPrevNpcName))
                    End If

                    ' Start writing npc
                    'npc_begin	warrior	20761	[pytan]
                    outFile.Write("npc_begin" & Chr(9) & "warrior" & Chr(9) & sPrevNpcName & Chr(9) & sTempNpcName & Chr(9))

                    For iTemp = 0 To iNpcCount - 1

                        'sTempItemName
                        ' Checking exising Items in ItemPch
                        If aItemPch(aItemList(iTemp).itemId) = Nothing Then
                            If Array.IndexOf(aItemMiss, aItemList(iTemp).itemId) = -1 Then
                                aItemMiss(aItemMiss.Length - 1) = aItemList(iNpcCount).itemId
                                Array.Resize(aItemMiss, aItemMiss.Length + 1)
                            End If
                            sTempItemName = "[_need_" & CInt(aItemList(iTemp).itemId) & "_]"
                        Else
                            sTempItemName = aItemPch(aItemList(iTemp).itemId)
                        End If

                        'corpse_make_list={
                        '{[rp_soulshot_a];1;1;0.9041};{[oriharukon_ore];1;1;45.2069};{[stone_of_purity];1;1;45.2069}  }	

                        If aItemList(iTemp).category = -1 Then
                            If aItemCategory(255) <> Nothing Then _
                                aItemCategory(255) = aItemCategory(255) & ";"
                            aItemCategory(255) = aItemCategory(255) & "{" & sTempItemName & ";" & aItemList(iTemp).min & ";" & aItemList(iTemp).max & ";" & aItemList(iTemp).chance & "}"
                        Else
                            If aItemCategory(aItemList(iTemp).category) <> Nothing Then _
                                aItemCategory(aItemList(iTemp).category) = aItemCategory(aItemList(iTemp).category) & ";"
                            aItemCategory(aItemList(iTemp).category) = aItemCategory(aItemList(iTemp).category) & "{" & sTempItemName & ";" & aItemList(iTemp).min & ";" & aItemList(iTemp).max & ";" & aItemList(iTemp).chance & "}"

                        End If

                        'additional_make_multi_list={
                        '{{{[adena];3286;6671;100}};70};
                        '{{{[sealed_dark_crystal_breastplate];1;1;30.61224};{[sealed_dark_crystal_gaiters];1;1;48.97959};{[sealed_tallum_plate_armor];1;1;20.40816}};0.0049};
                        '{{{[sealed_dark_crystal_gaiters_pattern];1;1;0.97862};{[sealed_tallum_plate_armor_pattern];1;1;0.45199};{[sealed_dark_crystal_breastplate_pattern];1;1;0.64022};{[iron_thread];1;1;6.91546};{[rp_sealed_majestic_leather_mail_i];1;1;0.05709};{[rp_hose_of_doom_i];1;1;0.28606};{[red_dimension_stone];1;1;0.11448};{[compound_braid];1;1;4.13007};{[silver_nugget];1;1;24.7801};{[thread];1;3;59.47248};{[thons];1;1;1.42972};{[life_stone_level_671];1;1;0.68661};{[mid_grade_life_stone_level_671];1;1;0.05709}};33.629}}	

                    Next

                    outFile.Write("corpse_make_list={" & aItemCategory(255) & "}")
                    outFile.Write(Chr(9) & "additional_make_multi_list={")
                    For iNpcCount = 0 To 254
                        If aItemCategory(iNpcCount) <> Nothing Then
                            If bItemCategory = True Then outFile.Write(";")
                            outFile.Write("{{" & aItemCategory(iNpcCount) & "};100}")
                            bItemCategory = True
                        End If
                    Next
                    bItemCategory = False
                    outFile.Write("}" & Chr(9))
                    outFile.WriteLine("npc_end")

                    iNpcCount = 0
                    Array.Clear(aItemList, 0, aItemList.Length)
                    Array.Resize(aItemList, 1)

                    Array.Clear(aItemCategory, 0, aItemCategory.Length)

                    'sCurNpcName = sPrevNpcName
                    'sTempDropSpoil = ""
                    'sTempDropItems = ""
                    sPrevNpcName = sCurNpcName

                End If

                ' ADD new Drop Items to Array
                Array.Resize(aItemList, iNpcCount + 1)

                ' 0     1    2 3 4 5
                '(18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric

                aItemList(iNpcCount).itemId = CInt(aTemp(1))
                aItemList(iNpcCount).min = CInt(aTemp(2))
                aItemList(iNpcCount).max = CInt(aTemp(3))
                aItemList(iNpcCount).category = CInt(aTemp(4))
                aItemList(iNpcCount).chance = CInt(CDbl(aTemp(5)) / 10000)

                iNpcCount = iNpcCount + 1

            End If

        End While
        ToolStripProgressBar.Value = 0
        inSpawnFile.Close()
        outFile.Close()

        If aNpcMiss.Length > 0 Then
            outFile = New System.IO.StreamWriter("npcdata_drop_l2j.log", False, System.Text.Encoding.Unicode, 1)
            outFile.WriteLine("Missed Npc. Required for NpcData drop:")
            For iNpcCount = 0 To aNpcMiss.Length - 2
                outFile.WriteLine("npc_id=" & aNpcMiss(iNpcCount))
            Next
            outFile.Close()
        End If
        If aItemMiss.Length > 0 Then
            outFile = New System.IO.StreamWriter("npcdata_drop_l2j.log", True, System.Text.Encoding.Unicode, 1)
            outFile.WriteLine("Missed Items. Required for NpcData drop:")
            For iNpcCount = 0 To aItemMiss.Length - 2
                outFile.WriteLine("item_id=" & aItemMiss(iNpcCount))
            Next
            outFile.Close()
        End If


        MessageBox.Show("Completed. With [" & aItemMiss.Length - 1 & "] missed item's [" & aNpcMiss.Length - 1 & "] missed npc's.")

    End Sub

    Private Sub RadioButtonRateChanceOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonRateChanceOnly.CheckedChanged
        TextBoxRateDropRB.Enabled = True
    End Sub

    Private Sub RadioButtonIgnoreDropNpc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonIgnoreDropNpc.CheckedChanged
        TextBoxRateDropRB.Enabled = False
    End Sub
End Class
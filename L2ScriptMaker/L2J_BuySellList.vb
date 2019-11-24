Public Class L2J_BuySellList

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

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
                    aNpcPch(CInt(aTemp(1)) - 1000000) = aTemp(0).Replace("[", "").Replace("]", "")
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
                    aItemPch(CInt(aTemp(1))) = aTemp(0).Replace("[", "").Replace("]", "")
                Catch ex As Exception
                    MessageBox.Show("Error in loading item_pch.txt. Last reading line:" & vbNewLine & sTemp)
                    inSpawnFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0

        ' LOADING merchant_shopids.sql
        If System.IO.File.Exists("merchant_shopids.sql") = False Then
            MessageBox.Show("merchant_shopids.sql not found", "Need merchant_shopids.sql", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aShopId(1000) As String
        Dim aShopNpc(1000) As String
        inSpawnFile = New System.IO.StreamReader("merchant_shopids.sql", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading merchant_shopids.sql ..."
        Dim iTempCount As Integer = 0

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp.StartsWith("(") = True Then

                '(3000100,'30001'),
                '(9029,'gm'),
                sTemp = sTemp.Substring(InStr(sTemp, "("), InStr(sTemp, ")") - InStr(sTemp, "(") - 1)
                sTemp = sTemp.Replace("'", "")
                aTemp = sTemp.Split(CChar(","))

                Array.Resize(aShopId, iTempCount + 1)
                Array.Resize(aShopNpc, iTempCount + 1)
                aShopId(iTempCount) = aTemp(0)
                aShopNpc(iTempCount) = aTemp(1).Replace("'", "").Trim
                iTempCount = iTempCount + 1

            End If

        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0


        ' -----------------

        OpenFileDialog.Filter = "L2J AI.obj BuySell List config (merchant_buylists.sql)|merchant_buylists.sql|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sSpawnListFile = OpenFileDialog.FileName
        inSpawnFile = New System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter("ai_buysell_list_l2j.txt", False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading merchant_buylists.sql..."

        Dim iNpcCount As Integer = 0
        Dim sCurNpcName As String = "", sPrevNpcName As String = ""
        Dim sCurShopId As String = "", sPrevShopId As String = ""
        Dim sItemPch As String = ""
        Dim sTempItemName As String, sTempNpcName As String

        Dim aItemMiss(0) As Integer
        Dim aNpcMiss(0) As Integer

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("(") = True Then 'sTemp.StartsWith("--")=False

                sTemp = sTemp.Substring(InStr(sTemp, "("), InStr(sTemp, ")") - InStr(sTemp, "(") - 1)
                sTemp = sTemp.Replace("'", "")
                aTemp = sTemp.Split(CChar(","))

                ' 0           1        2       3
                '`item_id`,`price`,`shop_id`,`order`
                '(1835,      -1,    13128001,  0),

                'class 1 asamah : citizen
                'property_define_begin
                '        buyselllist_begin SellList0
                '                {8764; 35; 0.000000; 0 }
                '               {8763; 35; 0.000000; 0 }
                '        buyselllist_end
                '        buyselllist_begin SellList1
                '                {8764; 35; 0.000000; 0 }
                '               {8763; 35; 0.000000; 0 }
                '        buyselllist_end
                'property_define_end
                'handler 4 1362  //  TALK_SELECTED

                'class asamah : citizen
                '{
                'property:
                '  BuySellList SellList0 = {
                '	      {"trap_stone"; 35; 0.000000; 0};
                '	      {"elrokian_trap"; 35; 0.000000; 0}
                '	};
                'handler:
                '	EventHandler TALK_SELECTED(talker)

                If Array.IndexOf(aShopId, aTemp(2)) = -1 Then
                    sTempNpcName = ""
                Else
                    sTempNpcName = aShopNpc(Array.IndexOf(aShopId, aTemp(2)))
                    If sTempNpcName = "gm" Then sTempNpcName = ""
                End If
                sItemPch = aTemp(0)
                sCurShopId = aTemp(2)

                If sTempNpcName <> "" Then
                    ' Checking exising npc in NpcPch
                    If aNpcPch(CInt(sTempNpcName)) = Nothing Then
                        If Array.IndexOf(aNpcMiss, sTempNpcName) = -1 Then
                            aNpcMiss(aNpcMiss.Length - 1) = CInt(sTempNpcName)
                            Array.Resize(aNpcMiss, aNpcMiss.Length + 1)
                        End If

                        sCurNpcName = "[_need_" & sTempNpcName & "_]"
                    Else
                        sCurNpcName = aNpcPch(CInt(sTempNpcName))
                    End If
                    If sPrevNpcName <> sCurNpcName Then
                        If sPrevNpcName <> "" Then outFile.WriteLine(vbNewLine & vbTab & "};")
                        outFile.WriteLine("class " & sCurNpcName & vbTab & "// " & sTempNpcName)
                        sPrevNpcName = sCurNpcName
                        sPrevShopId = ""
                    End If
                    If sCurShopId <> sPrevShopId Then
                        '	BuySellList SellList1 = {
                        If sPrevShopId <> "" Then outFile.WriteLine(vbNewLine & vbTab & "};")
                        outFile.WriteLine(vbTab & "BuySellList SellList" & sCurShopId & " = {")
                        sPrevShopId = sCurShopId
                    Else
                        outFile.WriteLine(";")
                    End If

                    If aItemPch(CInt(sItemPch)) = Nothing Then
                        If Array.IndexOf(aItemMiss, CInt(sItemPch)) = -1 Then
                            aItemMiss(aItemMiss.Length - 1) = CInt(sItemPch)
                            Array.Resize(aItemMiss, aItemMiss.Length + 1)
                        End If
                        sTempItemName = "[_need_" & CInt(CInt(sItemPch)) & "_]"
                    Else
                        sTempItemName = aItemPch(CInt(sItemPch))
                    End If
                    If CInt(sItemPch) > 25000 Then
                        MessageBox.Show("Wrong item_id [" & sItemPch & "] in line" & vbNewLine & sTemp)
                        inSpawnFile.Close()
                        outFile.Close()
                        ToolStripProgressBar.Value = 0
                        Exit Sub
                    End If

                    outFile.Write(vbTab & vbTab & "{""" & sTempItemName & """; 15; 0.000000; 0 }")

                End If

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
End Class
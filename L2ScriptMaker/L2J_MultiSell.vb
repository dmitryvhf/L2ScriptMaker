Public Class L2J_MultiSell

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim sTemp As String
        Dim aTemp() As String
        'Dim sSpawnListFile As String

        Dim inSpawnFile As System.IO.StreamReader

        Dim aXMLFiles() As String
        FolderBrowserDialog.SelectedPath = Application.StartupPath
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        aXMLFiles = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.xml", IO.SearchOption.TopDirectoryOnly)
        If aXMLFiles.Length = 0 Then
            MessageBox.Show("No XML files into this folder", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

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


        Dim outFile As New System.IO.StreamWriter("multisell_l2j.txt", False, System.Text.Encoding.Unicode, 1)
        Dim outLogFile As New System.IO.StreamWriter("multisell_l2j.log", False, System.Text.Encoding.Unicode, 1)
        outLogFile.WriteLine("MultiSell clean config generator log. Start working: " & Now())

        'Dim iNpcCount As Integer = 0
        'Dim sCurNpcName As String = "", sPrevNpcName As String = Nothing
        'Dim sTempNpcName As String, sTempItemName As String
        'Dim sTempDropSpoil As String, sTempDropItems As String
        'Dim bItemCategory As Boolean = False

        Dim iXMLCount, iXMLCountLine As Integer
        Dim sTempProduct As String = ""
        Dim sTempIngredient As String = ""
        Dim sTempGetName As String
        Dim sDuty As String = ""

        ToolStripProgressBar.Maximum = aXMLFiles.Length - 1

        For iXMLCount = 0 To aXMLFiles.Length - 1

            inSpawnFile = New System.IO.StreamReader(aXMLFiles(iXMLCount), System.Text.Encoding.Default, True, 1)
            ToolStripStatusLabel.Text = "Loading " & System.IO.Path.GetFileName(aXMLFiles(iXMLCount)) & "..."

            outFile.WriteLine("MultiSell_begin" & Chr(9) & "[" & System.IO.Path.GetFileNameWithoutExtension(aXMLFiles(iXMLCount)) & "]" & Chr(9) & System.IO.Path.GetFileNameWithoutExtension(aXMLFiles(iXMLCount)))
            iXMLCountLine = 0
            While inSpawnFile.EndOfStream <> True


                sTemp = inSpawnFile.ReadLine.Trim
                ToolStripProgressBar.Value = iXMLCount
                If sTemp <> "" And sTemp.StartsWith("//") = False Then


                    '<?xml version="1.0" encoding="UTF-8"?>
                    '       <ingredient id="57" count="3390000" isTaxIngredient="true" />
                    '       {{{[sword_of_damascus_focus];1}};{{[sword_of_damascus];1};{[red_soul_crystal_10];1};{[gemstone_b];339}};{3390000}};

                    'applyTaxes
                    'maintainEnchantment=false

                    'MultiSell_begin	[blackmerchant_weapon]	1
                    'is_dutyfree = 1
                    'is_show_all = 0
                    'keep_enchanted = 1
                    'selllist={
                    '{{{[heavy_war_axe];1}};{{[crystal_b];579};{[crystal_c];1737}}};
                    '{{{[spell_breaker];1}};{{[crystal_b];579};{[crystal_c];1737}}}
                    '}
                    'MultiSell_end


                    '<list applyTaxes="true" maintainEnchantment="true">
                    '<list>
                    '	<item id="1">
                    '		<ingredient id="2505" count="1" />
                    '		<ingredient id="2130" count="24" />
                    '		<production id="3439" count="1" />
                    '	</item>
                    '</list>
                    If sTemp.StartsWith("<list") = True Then

                        outFile.WriteLine("//is_dutyfree = 1")

                        If InStr(sTemp, "maintainEnchantment=""true""") > 0 Then
                            outFile.WriteLine("is_show_all = 0")
                            outFile.WriteLine("keep_enchanted = 1")
                        ElseIf InStr(sTemp, "maintainEnchantment=""false""") > 0 Then
                            outFile.WriteLine("keep_enchanted = 0")
                        End If

                        outFile.WriteLine("selllist={")

                    End If

                    If sTemp.StartsWith("<item id=") Then

                        ' Close previous line
                        If iXMLCountLine > 0 Then
                            outFile.WriteLine(";")
                        End If

                    End If


                    If sTemp.StartsWith("<ingredient id=") Then

                        'sTempIngredient = sTempIngredient & "{" & GetValByName(sTemp, "id") & ";" & GetValByName(sTemp, "count") & "}"

                        If GetValByName(sTemp, "id") = "-300" Then
                            sTempGetName = "[pvp_point]"
                        ElseIf GetValByName(sTemp, "id") = "-200" Then
                            sTempGetName = "[pledge_point]"
                            'ElseIf GetValByName(sTemp, "id") = "-100" Then
                            'sTempGetName = "[pcbang_point]"
                        Else
                            If aItemPch(CInt(GetValByName(sTemp, "id"))) = Nothing Then
                                outLogFile.WriteLine("MISSED ID:[" & GetValByName(sTemp, "id") & "]")
                                sTempGetName = "_no_id_" & GetValByName(sTemp, "id")
                            Else
                                sTempGetName = aItemPch(CInt(GetValByName(sTemp, "id")))
                            End If
                        End If

                        '<ingredient id="2135" count="1" mantainIngredient="true" />

                        '<ingredient id="57" count="291000" isTaxIngredient="true" />
                        If InStr(sTemp, "isTaxIngredient=""true""") > 0 Then
                            'sTempIngredient = sTempIngredient & "};{" & GetValByName(sTemp, "count") & "}"
                            sDuty = "{" & GetValByName(sTemp, "count") & "}"
                        Else
                            If sTempIngredient <> "" Then sTempIngredient = sTempIngredient & ";"
                            sTempIngredient = sTempIngredient & "{" & sTempGetName & ";" & GetValByName(sTemp, "count") & "}"
                            'bPrevDuty = False
                        End If

                    End If

                    If sTemp.StartsWith("<production id=") Then

                        If sTempProduct <> "" Then sTempProduct = sTempProduct & ";"

                        If GetValByName(sTemp, "id") = "-300" Then
                            sTempGetName = "[pvp_point]"
                        ElseIf GetValByName(sTemp, "id") = "-200" Then
                            sTempGetName = "[pledge_point]"
                            'ElseIf GetValByName(sTemp, "id") = "-100" Then
                            'sTempGetName = "[pcbang_point]"
                        Else
                            If aItemPch(CInt(GetValByName(sTemp, "id"))) = Nothing Then
                                outLogFile.WriteLine("MISSED ID:[" & GetValByName(sTemp, "id") & "]")
                                sTempGetName = "_no_id_" & GetValByName(sTemp, "id")
                            Else
                                sTempGetName = aItemPch(CInt(GetValByName(sTemp, "id")))
                            End If
                        End If

                        'sTempProduct = "{" & GetValByName(sTemp, "id") & ";" & GetValByName(sTemp, "count") & "}"
                        sTempProduct = "{" & sTempGetName & ";" & GetValByName(sTemp, "count") & "}"
                    End If

                    If sTemp.StartsWith("</item>") Then

                        '{ { {[heavy_war_axe];1}  };{  {[crystal_b];579}; {[crystal_c];1737} }  };
                        outFile.Write("{{" & sTempProduct & "};{" & sTempIngredient & "}")
                        If sDuty = "" Then
                            outFile.Write("}")
                        Else
                            outFile.Write(";" & sDuty & "}")
                        End If

                        ' SAVING LINE
                        'outFile.WriteLine("")
                        iXMLCountLine = iXMLCountLine + 1
                        sTempProduct = "" : sTempIngredient = ""
                        sDuty = ""
                    End If

                    If sTemp.StartsWith("</list>") Then
                        outFile.WriteLine(vbNewLine & "}")
                    End If

                End If

            End While
            outFile.WriteLine("MultiSell_end" & vbNewLine)
            inSpawnFile.Close()


        Next
        ToolStripProgressBar.Value = 0
        outFile.Close()
        outLogFile.Close()

        MessageBox.Show("Completed.")


    End Sub

    Private Function GetValByName(ByVal Str As String, ByVal ParamName As String) As String

        '<ingredient id="2505" count="1" />
        Dim iTemp, iTemp2 As Integer
        iTemp = InStr(Str, ParamName & "=""") + (ParamName & "=""").Length - 1
        iTemp2 = InStr(iTemp + 1, Str, """") - 1

        GetValByName = Str.Substring(iTemp, iTemp2 - iTemp)

    End Function

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub


End Class
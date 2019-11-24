Public Class RecipeGenerator

    Dim ItemPch(0) As String

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sItemPch As String = "item_pch.txt"
        OpenFileDialog.InitialDirectory = Application.StartupPath
        If System.IO.File.Exists(sItemPch) = False Then
            OpenFileDialog.FileName = "item_pch.txt"
            OpenFileDialog.Filter = "Lineage II Server Item_pch file(item_pch.txt)|item_pch.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sItemPch = OpenFileDialog.FileName
        End If
        If ItemPchLoad(sItemPch) = False Then Exit Sub

        Dim sRecipeE As String
        OpenFileDialog.FileName = "recipe-c.txt"
        OpenFileDialog.Filter = "Lineage II Client Recipe file(recipe-c.txt)|recipe-c.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sRecipeE = OpenFileDialog.FileName

        If System.IO.File.Exists("recipe.txt") = True Then
            If MessageBox.Show("Backup and overwrite exist 'recipe.txt' file?", "Overwrite", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
            System.IO.File.Copy("recipe.txt", "recipe.txt.bak", True)
        End If

        Dim inFile As New System.IO.StreamReader(sRecipeE, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter("recipe.txt", False, System.Text.Encoding.Unicode, 1)

        Dim sTemp As String, sGen As String = ""
        'Dim aTemp() As String
        Dim iTemp As Integer

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            'recipe_begin	name=[mk_brigandine]	id_mk=79	id_recipe=2186	level=3	id_item=352	count=1	mp_cost=120	success_rate=100	materials_cnt=5	materials_m[0]_id=1941	materials_m[0]_cnt=7	materials_m[1]_id=1883	materials_m[1]_cnt=3	materials_m[2]_id=1880	materials_m[2]_cnt=54	materials_m[3]_id=1458	materials_m[3]_cnt=90	materials_m[4]_id=2130	materials_m[4]_cnt=24	materials_m[5]_id=	materials_m[5]_cnt=	materials_m[6]_id=	materials_m[6]_cnt=	materials_m[7]_id=	materials_m[7]_cnt=	materials_m[8]_id=	materials_m[8]_cnt=	materials_m[9]_id=	materials_m[9]_cnt=	recipe_end
            'recipe_begin	[mk_brigandine]	79	level=3	material={{[brigandine_temper];7};{[steel_mold];3};{[steel];54};{[crystal_d];90};{[gemstone_d];24}}	catalyst={}	product={{[brigandine];1}}	npc_fee={{[rp_brigandine];1};{[adena];59800}}	mp_consume=120	success_rate=100	item_id=2186	iscommonrecipe=0	recipe_end
            'aTemp = sTemp.Split(Chr(9))

            'recipe_begin
            outFile.Write("recipe_begin" & vbTab)

            '[mk_brigandine]
            outFile.Write(Libraries.GetNeedParamFromStr(sTemp, "name") & vbTab)

            '79
            outFile.Write(Libraries.GetNeedParamFromStr(sTemp, "id_mk") & vbTab)

            'level=3
            outFile.Write("level=" & Libraries.GetNeedParamFromStr(sTemp, "level") & vbTab)

            'material={{[brigandine_temper];7};{[steel_mold];3};{[steel];54};{[crystal_d];90};{[gemstone_d];24}}

            'materials_cnt=5	materials_m[0]_id=1941	materials_m[0]_cnt=7
            For iTemp = 0 To CInt(Libraries.GetNeedParamFromStr(sTemp, "materials_cnt")) - 1

                If CInt(Libraries.GetNeedParamFromStr(sTemp, "materials_m[" & iTemp.ToString & "]_id")) > ItemPch.Length Then
                    If IgnoreUnknownCheckBox.Checked = False Then
                        MessageBox.Show("Recipe " & Libraries.GetNeedParamFromStr(sTemp, "name") & " have item with unknown id " & Libraries.GetNeedParamFromStr(sTemp, "materials_m[" & iTemp.ToString & "]_id") & vbNewLine & "Check itemdata.txt for this item or regenerate item_pch.txt." & vbNewLine & "Generation aborted.", "Unknown ItemID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit While
                        'inFile.Close()
                        'outFile.Close()
                        'Exit Sub
                    Else
                        sGen = ""
                        Exit For
                    End If
                Else
                    sGen = sGen & "{" & ItemPch(CInt(Libraries.GetNeedParamFromStr(sTemp, "materials_m[" & iTemp.ToString & "]_id"))) & ";" & Libraries.GetNeedParamFromStr(sTemp, "materials_m[" & iTemp.ToString & "]_cnt") & "}"
                End If

                'if ItemPch(CInt(Libraries.GetNeedParamFromStr(sTemp, "materials_m[" & iTemp.ToString & "]_id")) = "" then
                If iTemp < CInt(Libraries.GetNeedParamFromStr(sTemp, "materials_cnt")) - 1 Then sGen = sGen & ";"
            Next
            outFile.Write("material={" & sGen & "}" & vbTab) : sGen = ""

            'catalyst={}
            outFile.Write("catalyst={}" & vbTab)

            'product={{[brigandine];1}}
            If CInt(Libraries.GetNeedParamFromStr(sTemp, "id_item")) > ItemPch.Length Then
                If IgnoreUnknownCheckBox.Checked = False Then
                    MessageBox.Show("Recipe " & Libraries.GetNeedParamFromStr(sTemp, "name") & " have record with unknown itemid " & Libraries.GetNeedParamFromStr(sTemp, "id_item") & vbNewLine & "Check itemdata.txt for this item or regenerate item_pch.txt.", "Unknown ItemID" & vbNewLine & "Generation aborted.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit While
                    'inFile.Close()
                    'outFile.Close()
                    'Exit Sub
                Else
                    sGen = ""
                End If
            Else

                'sGen = "{" & ItemPch(CInt(Libraries.GetNeedParamFromStr(sTemp, "id_item"))) & ";" & Libraries.GetNeedParamFromStr(sTemp, "count") & "}"
                sGen = "{" & ItemPch(CInt(Libraries.GetNeedParamFromStr(sTemp, "id_item"))) & ";" & Libraries.GetNeedParamFromStr(sTemp, "count")

                'product={{[soulshot_c];952;100}}	
                'product={{[dynasty_staff];1;96};{[fnd_dyn_staff];1;4}}	
                If CheckBoxDevnextSupport.Checked = True Then
                    sGen = sGen & ";100"
                End If
                sGen = sGen & "}"

            End If

            outFile.Write("product={" & sGen & "}" & vbTab) : sGen = ""

            'npc_fee={{[rp_brigandine];1};{[adena];59800}}
            outFile.Write("npc_fee={}" & vbTab)

            'mp_consume=120
            outFile.Write("mp_consume=" & Libraries.GetNeedParamFromStr(sTemp, "mp_cost") & vbTab)

            'success_rate=100
            outFile.Write("success_rate=" & Libraries.GetNeedParamFromStr(sTemp, "success_rate") & vbTab)

            'item_id=2186
            outFile.Write("item_id=" & Libraries.GetNeedParamFromStr(sTemp, "id_recipe") & vbTab)

            'iscommonrecipe=0
            outFile.Write("iscommonrecipe=0" & vbTab)

            'recipe_end
            outFile.WriteLine("recipe_end")

            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position) : Me.Update()

        End While

        ToolStripProgressBar.Value = 0

        inFile.Close()
        outFile.Close()

        MessageBox.Show("Generation complete", "Complete", MessageBoxButtons.OK)


    End Sub

    Private Function ItemPchLoad(ByVal FileName As String) As Boolean

        Dim inFile As System.IO.StreamReader
        Try
            inFile = New System.IO.StreamReader(FileName, System.Text.Encoding.Default, True, 1)
        Catch ex As Exception
            Return False
        End Try
        Dim sTempStr As String = ""
        Dim aTemp(1) As String
        Dim iTemp As Integer = -1

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        While inFile.EndOfStream <> True

            '[small_sword]	=	1
            Try
                sTempStr = inFile.ReadLine
                sTempStr = sTempStr.Replace(" ", "").Replace(Chr(9), "") '.Replace("[", "").Replace("]", "")
                aTemp = sTempStr.Split(CChar("="))

                iTemp = CInt(aTemp(1))
                If ItemPch.Length <= iTemp Then
                    Array.Resize(ItemPch, iTemp + 1)
                End If
                ItemPch(iTemp) = aTemp(0)
            Catch ex As Exception
                MessageBox.Show("Import data invalid in line" & vbNewLine & sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
                inFile.Close()
                Return False
            End Try

            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position) : Me.Update()
            'Me.Update()

        End While

        ToolStripProgressBar.Value = 0
        inFile.Close()
        Return True

    End Function

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

End Class
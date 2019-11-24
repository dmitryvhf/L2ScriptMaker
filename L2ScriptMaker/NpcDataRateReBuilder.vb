Public Class NpcdataRateReBuilder

    'ItemGroup1(ItemId/name , MinItem, MaxItem, chance)

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sWorkFile As String

        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        sWorkFile = OpenFileDialog.FileName

        System.IO.File.Copy(sWorkFile, sWorkFile & ".bak", True)
        Dim fInFile As New System.IO.StreamReader(sWorkFile & ".bak", System.Text.Encoding.Default, True, 1)
        Dim fOutFile As New System.IO.StreamWriter(sWorkFile, False, System.Text.Encoding.Unicode)

        Dim sTemp As String, aNpcType(15) As String ' 15 - params in npcdata npc definition

        ProgressBar.Maximum = CInt(fInFile.BaseStream.Length)
        ProgressBar.Value = 0
        While fInFile.EndOfStream <> True

            sTemp = fInFile.ReadLine

            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then

                'npc_begin(0)	warrior(1)	1(2)	[gremlin](3)	level=1	acquire_exp_rate=29.39
                sTemp = sTemp.Replace("  ", " ").Replace(Chr(32), Chr(9))
                aNpcType = sTemp.Split(Chr(9))

                ' If UseIgnoreListBox.Checked = True And IgnoreNpcCheckedListBox.CheckedItems.IndexOf(aNpcType(1)) <> -1 Then GoTo LeaveWithoutChanges

                If RadioButton2.Checked = True And IgnoreNpcCheckedListBox.CheckedItems.IndexOf(aNpcType(1)) <> -1 Then GoTo LeaveWithoutChanges
                If RadioButton3.Checked = True And IgnoreNpcCheckedListBox.CheckedItems.IndexOf(aNpcType(1)) = -1 Then GoTo LeaveWithoutChanges

                If IgnoreNpcNameCheckBox.Checked = True And InStr(IgnoreNpcNamesTextBox.Text, aNpcType(3)) <> 0 Then GoTo LeaveWithoutChanges

                ' npc found in ignore list. Nothing happening. Write as is.
                sTemp = ParamChange(sTemp, "acquire_exp_rate", CDbl(MultExpBox.Text))
                sTemp = ParamChange(sTemp, "acquire_sp", CDbl(MultSPBox.Text))
                sTemp = DropChange(sTemp, "additional_make_multi_list", CDbl(MultDropBox.Text))
                sTemp = SpoilChange(sTemp, "corpse_make_list", CDbl(MultSpoilBox.Text))
LeaveWithoutChanges:
            End If

            fOutFile.WriteLine(sTemp)
            ProgressBar.Value = CInt(fInFile.BaseStream.Position)

        End While


        fInFile.Close()
        fOutFile.Close()

        MessageBox.Show("Work complete.", "Complete", MessageBoxButtons.OK)
        ProgressBar.Value = 0


    End Sub


    Private Function ParamChange(ByVal StrLine As String, ByVal ParamName As String, ByVal RateValue As Double) As String

        Dim sParam As String
        'Dim dblChcIn As Double, 
        Dim dblChcOut As Double

        On Error GoTo ErrorMessage

        sParam = Libraries.GetNeedParamFromStr(StrLine, ParamName)
        'dblChcIn = CDbl(sParam )
        dblChcOut = CDbl(Format((CDbl(sParam) * RateValue), "0.####"))
        If ParamName = "acquire_exp_rate" Then
            If dblChcOut < 0 Then dblChcOut = 0
        End If
        If ParamName = "acquire_sp" Then
            If dblChcOut < 0 Then dblChcOut = 0
            dblChcOut = Convert.ToInt64(dblChcOut)
        End If
        ParamChange = Libraries.SetNeedParamToStr(StrLine, ParamName, CStr(dblChcOut))
        'ParamChange = StrLine.Replace(ParamName & "=" & dblChcIn, ParamName & "=" & dblChcOut)

        Return ParamChange
ErrorMessage:

        MessageBox.Show("Program cause error [" & Err.Description & "] in rate process with param:[" & ParamName & "] and keep old value without changes. Last data:" & vbNewLine & "[" & StrLine & "]")
        Return StrLine

    End Function


    Private Function SumChanges(ByVal ItemChances() As Double) As Double

        Dim iTemp As Integer, Summ As Double
        For iTemp = 0 To ItemChances.Length - 1
            Summ = Summ + ItemChances(itemp)
        Next

        Return Summ

    End Function

    Private Function DropChange(ByVal StrLine As String, ByVal ParamName As String, ByVal RateValue As Double) As String

        ' PROCEDURE

        Dim sParam As String, sTempParam As String
        Dim iTemp As Integer, iForTemp As Integer
        Dim dblChcIn As Double ', dblChcOut As Double
        Dim ItemGroupList(100) As String
        Dim ItemGroupListChance(100) As Double
        Dim AggrMetodDrop(100) As Integer ', AggrMetodSpoil As Integer
        Dim RateLimit As Integer = CInt(RateLimitTextBox.Text)

        If RateLimitTextBox.Enabled = True Then
            RateLimit = CInt(RateLimitTextBox.Text)
        Else
            RateLimit = 100
        End If

        sParam = Libraries.GetNeedParamFromStr(StrLine, ParamName)

        If sParam <> "{}" Then
            Array.Clear(ItemGroupList, 0, ItemGroupList.Length)
            Array.Clear(ItemGroupListChance, 0, ItemGroupListChance.Length)
            sTempParam = sParam.Replace("{{{{", "{") ' additional_make_multi_list
            sTempParam = sTempParam.Remove(sTempParam.Length - 1, 1) ' additional_make_multi_list

            ItemGroupList = sTempParam.Replace(";{{", "|").Split(Chr(124)) ' 124 - | ' additional_make_multi_list

            ' Generating table with chances
            For iForTemp = 0 To ItemGroupList.Length - 1
                iTemp = InStr(ItemGroupList(iForTemp), "}};")   ' additional_make_multi_list
                dblChcIn = CDbl(Mid(ItemGroupList(iForTemp), iTemp + 3, ItemGroupList(iForTemp).Length - iTemp - 3))
                'ItemGroupList(iForTemp) = ItemGroupList(iForTemp).Replace("}};" & dblChcIn.ToString & "}", "}")
                ItemGroupList(iForTemp) = ItemGroupList(iForTemp).Remove(iTemp, ItemGroupList(iForTemp).Length - iTemp)
                ItemGroupListChance(iForTemp) = dblChcIn
            Next


            ' -----  MAke CHANCE for groups
            ' NORMAL Metod Chance and 100% max Metod Chance 
            If NormalRadioButton.Checked = True Or Max100RadioButton.Checked = True Then
                For iForTemp = 0 To ItemGroupList.Length - 1
                    If InStr(ItemGroupList(iForTemp), "[adena]") = 0 And InStr(ItemGroupList(iForTemp), "sealstone]") = 0 Then
                        ItemGroupListChance(iForTemp) = ItemGroupListChance(iForTemp) * RateValue
                    Else
                        'nothing more if Adena or SealStones
                        'ItemGroupListChance(iForTemp) = ItemGroupListChance(iForTemp)
                    End If
                    ' 100% correction
                    If Max100RadioButton.Checked = True Then
                        If ItemGroupListChance(iForTemp) > RateLimit Then ItemGroupListChance(iForTemp) = RateLimit
                    End If
                Next
            End If

            ' AGRESSIVE Metod Chance 
            If AgressiveRadioButton.Checked = True Then
                For iForTemp = 0 To ItemGroupList.Length - 1
                    ' 100% correction
                    If InStr(ItemGroupList(iForTemp), "[adena]") = 0 And InStr(ItemGroupList(iForTemp), "sealstone]") = 0 Then
                        ItemGroupListChance(iForTemp) = ItemGroupListChance(iForTemp) * RateValue
                        If ItemGroupListChance(iForTemp) > RateLimit Then
                            AggrMetodDrop(iForTemp) = CInt(Fix(ItemGroupListChance(iForTemp) / RateLimit))
                            ItemGroupListChance(iForTemp) = RateLimit
                        End If
                    Else
                        'nothing more if Adena or SealStones
                        'ItemGroupListChance(iForTemp) = ItemGroupListChance(iForTemp)
                    End If
                Next
            End If

            ' BALANCED Metod Chance 
            If BalancedRadioButton.Checked = True Then
                For iForTemp = 0 To ItemGroupList.Length - 1
                    ' 100% correction
                    If InStr(ItemGroupList(iForTemp), "[adena]") = 0 And InStr(ItemGroupList(iForTemp), "sealstone]") = 0 Then
                        If ItemGroupListChance(iForTemp) * RateValue > RateLimit Then
                            AggrMetodDrop(iForTemp) = CInt(RateValue)
                        Else
                            ItemGroupListChance(iForTemp) = ItemGroupListChance(iForTemp) * RateValue
                            AggrMetodDrop(iForTemp) = 1
                        End If
                    Else
                        'nothing more if Adena or SealStones
                        'ItemGroupListChance(iForTemp) = ItemGroupListChance(iForTemp)
                    End If
                Next
            End If

            ' "No Low No More" Metod Chance 
            If NolownomoreRadioButton.Checked = True Then
                For iForTemp = 0 To ItemGroupList.Length - 1
                    ' 100% correction
                    If InStr(ItemGroupList(iForTemp), "[adena]") = 0 And InStr(ItemGroupList(iForTemp), "sealstone]") = 0 Then
                        If ItemGroupListChance(iForTemp) * RateValue > RateLimit Then
                            AggrMetodDrop(iForTemp) = CInt(Fix(ItemGroupListChance(iForTemp) * RateValue) / RateLimit)
                            ' ItemGroupListChance(iForTemp) = RateLimit
                        Else
                            ItemGroupListChance(iForTemp) = ItemGroupListChance(iForTemp) * RateValue
                            AggrMetodDrop(iForTemp) = 1
                        End If
                    Else
                        'nothing more if Adena or SealStones
                        'ItemGroupListChance(iForTemp) = ItemGroupListChance(iForTemp)
                    End If
                Next
            End If

            sTempParam = "{"
            For iForTemp = 0 To ItemGroupList.Length - 1

                If iForTemp > 0 And iForTemp <= ItemGroupList.Length - 1 Then
                    sTempParam = sTempParam & ";"
                End If

                ' ITEM VALUE FIX
                Dim isDrop As Integer = 0
                If InStr(ItemGroupList(iForTemp), "[adena]") <> 0 Then isDrop = 1 ' adena
                If InStr(ItemGroupList(iForTemp), "sealstone]") <> 0 Then isDrop = 2 ' sealstone
                Select Case isDrop
                    Case 0
                        If BalancedRadioButton.Checked = False And NolownomoreRadioButton.Checked = False Then
                            ItemGroupList(iForTemp) = FixValueInTable(ItemGroupList(iForTemp), CDbl(AmnDropBox.Text) + AggrMetodDrop(iForTemp))
                        Else
                            ItemGroupList(iForTemp) = FixValueInTable(ItemGroupList(iForTemp), CInt(AmnDropBox.Text) * AggrMetodDrop(iForTemp))
                        End If
                    Case 1
                        ItemGroupList(iForTemp) = FixValueInTable(ItemGroupList(iForTemp), CDbl(AmnAdenaBox.Text))
                    Case 2
                        ItemGroupList(iForTemp) = FixValueInTable(ItemGroupList(iForTemp), CDbl(AmnSStoneBox.Text))
                End Select
                '  ITEM VALUE FIX END

                'ItemGroupList(iForTemp) = "{{" & ItemGroupList(iForTemp).Replace("}};" & dblChcIn.ToString & "}", "}};" & ItemGroupList(iForTemp).ToString & "}")
                'ItemGroupList(iForTemp) = "{{" & ItemGroupList(iForTemp) '& "}"
                ItemGroupList(iForTemp) = "{{" & ItemGroupList(iForTemp) & "};" & ItemGroupListChance(iForTemp).ToString & "}"
                sTempParam = sTempParam & ItemGroupList(iForTemp)
            Next
            sTempParam = sTempParam & "}"
            DropChange = StrLine.Replace(sParam, sTempParam)
        Else
            DropChange = StrLine
        End If

    End Function

    Private Function FixValueInTable(ByVal ItemGroup As String, ByVal RateValue As Double) As String

        '"{[piece_bone_breastplate];1;1;2.2988};{[piece_bone_breastplate_fragment];1;1;36.9195}
        ';{[bronze_breastplate];1;1;1.4858};{[piece_bone_gaiters];1;1;3.6734};{[piece_bone_gaiters_fragment];1;1;53.2415};
        '{[bronze_gaiters];1;1;2.381}};2.3887}"

        If RateValue = 1 Then
            Return ItemGroup
        End If

        Dim ItemGroupList(0) As String
        Dim ItemList(0) As String
        Dim sTemp As String, iTemp As Integer, iTemp2 As Integer
        ' for Special list
        Dim iTemp3 As Integer, isSpecialItem As Boolean

        'iTemp = InStr(ItemGroup, "}};")
        'dblChanceTemp = CDbl(Mid(ItemGroup, iTemp + 3, ItemGroup.Length - iTemp - 3))
        'sTemp = ItemGroup.Remove(iTemp - 1, (ItemGroup.Length - iTemp + 1)).Remove(0, 1)
        'If RateValue = 1 Then
        'Return "{" & sTemp & "}"
        'End If

        sTemp = ItemGroup.Substring(1, ItemGroup.Length - 2)
        Array.Clear(ItemGroupList, 0, ItemGroupList.Length)
        ItemGroupList = sTemp.Replace("};{", "|").Split(CChar("|"))

        ItemGroup = ""
        For iTemp = 0 To ItemGroupList.Length - 1

            If iTemp > 0 And iTemp <= ItemGroupList.Length - 1 Then
                ItemGroup = ItemGroup & ";"
            End If

            Array.Clear(ItemList, 0, ItemList.Length)
            ItemList = ItemGroupList(iTemp).Split(CChar(";"))

            For iTemp2 = 2 To ItemList.Length - 1 Step 4

                If AmnChgItemListBox.Checked = True Then
                    SpecialItemsListTextBox.Text = SpecialItemsListTextBox.Text.Trim
                    isSpecialItem = False
                    For iTemp3 = 0 To SpecialItemsListTextBox.Lines.Length - 1
                        If ItemList(0) = SpecialItemsListTextBox.Lines(iTemp3) Then
                            isSpecialItem = True
                            Exit For
                        End If
                    Next
                    If isSpecialItem = True Then
                        ItemList(iTemp2) = CStr(CDbl(ItemList(iTemp2)) * RateValue)
                        If AmnChgBothBox.Checked = True Then
                            ItemList(iTemp2 - 1) = CStr(CDbl(ItemList(iTemp2 - 1)) * RateValue)
                        End If
                    End If

                Else

                    ' Fix any items
                    ItemList(iTemp2) = CStr(CDbl(ItemList(iTemp2)) * RateValue)
                    If AmnChgBothBox.Checked = True Then
                        ItemList(iTemp2 - 1) = CStr(CDbl(ItemList(iTemp2 - 1)) * RateValue)
                    End If

                End If
            Next
            ' Fix for Int amount
            ' Fix for Int amount
            If CInt(ItemList(1)) < 1 Then ItemList(1) = "1"
            If CInt(ItemList(2)) < 1 Then ItemList(2) = "1"
            ItemList(1) = CStr(CInt(ItemList(1))) : ItemList(2) = CStr(CInt(ItemList(2)))
            ItemGroupList(iTemp) = Join(ItemList, ";")
            ItemGroup = ItemGroup & "{" & ItemGroupList(iTemp) & "}"

        Next
        Return ItemGroup

    End Function

    Private Function SpoilChange(ByVal StrLine As String, ByVal ParamName As String, ByVal RateValue As Double) As String

        Dim sParam As String, sTempParam As String
        Dim iTemp As Integer
        Dim ItemGroupList() As String
        Dim ItemGroupItemList() As String
        'Dim ItemGroupListChance(3) As Double
        Dim RateLimit As Integer = CInt(RateLimitTextBox.Text)

        If RateLimitTextBox.Enabled = True Then
            RateLimit = CInt(RateLimitTextBox.Text)
        Else
            RateLimit = 100
        End If

        ' PROCEDURE
        'corpse_make_list={  {[charcoal];1;1;5.6617};{[magic_ring];1;1;34.3131};{[rp_broad_sword];1;1;4.5293} }
        sParam = Libraries.GetNeedParamFromStr(StrLine, "corpse_make_list")

        If sParam <> "{}" Then

            'Array.Clear(ItemGroupList, 0, ItemGroupList.Length)

            sTempParam = sParam.Replace("{{", "").Replace("}}", "")  ' corpse_make_list
            ItemGroupList = sTempParam.Replace("};{", "|").Split(Chr(124)) ' 124 - | ' corpse_make_list
            Dim ItemGroupListChance(ItemGroupList.Length) As Double


            ' Generating table with chances
            For iTemp = 0 To ItemGroupList.Length - 1
                ItemGroupItemList = ItemGroupList(iTemp).Split(CChar(";"))
                ItemGroupListChance(iTemp) = CDbl(ItemGroupItemList(3))
            Next

            ' -----  MAke CHANCE for groups
            ' NORMAL Metod Chance and 100% max metod chance
            If NormalRadioButton.Checked = True Or Max100RadioButton.Checked = True Then
                For iTemp = 0 To ItemGroupList.Length - 1
                    ItemGroupListChance(iTemp) = ItemGroupListChance(iTemp) * RateValue
                    ' 100% correction for Normal mode (drop all rates more them 100%)
                    If Max100RadioButton.Checked = True Then
                        If ItemGroupListChance(iTemp) > RateLimit Then ItemGroupListChance(iTemp) = RateLimit
                    End If
                Next
            End If

            ' AGRESSIVE Metod Chance 
            Dim AggrMetodDrop(ItemGroupList.Length) As Integer ', AggrMetodSpoil As Integer
            If AgressiveRadioButton.Checked = True Then
                For iTemp = 0 To ItemGroupList.Length - 1
                    ' 100% correction
                    ItemGroupListChance(iTemp) = ItemGroupListChance(iTemp) * RateValue
                    If ItemGroupListChance(iTemp) > RateLimit Then
                        AggrMetodDrop(iTemp) = CInt(Fix(ItemGroupListChance(iTemp) / RateLimit))
                        ItemGroupListChance(iTemp) = RateLimit
                    End If
                Next
            End If

            ' BALANCED Metod Chance 
            If BalancedRadioButton.Checked = True Then
                For iTemp = 0 To ItemGroupList.Length - 1
                    If ItemGroupListChance(iTemp) * RateValue > RateLimit Then
                        AggrMetodDrop(iTemp) = CInt(RateValue)
                    Else
                        ItemGroupListChance(iTemp) = ItemGroupListChance(iTemp) * RateValue
                        AggrMetodDrop(iTemp) = 1
                    End If
                Next
            End If

            ' "Gold Middle" METOD 
            If GoldMiddleRadioButton.Checked = True Then
                For iTemp = 0 To ItemGroupList.Length - 1
                    ItemGroupListChance(iTemp) = (ItemGroupListChance(iTemp) * RateValue)
                Next

                Dim ChanceSumm As Double, ChanceKoeff As Double
                ChanceSumm = SumChanges(ItemGroupListChance)
                ChanceKoeff = ChanceSumm / RateLimit

                '259 - x%
                '100 - 100%
                For iTemp = 0 To ItemGroupList.Length - 1
                    ItemGroupListChance(iTemp) = CDbl((ItemGroupListChance(iTemp) / ChanceKoeff).ToString(".0000"))
                Next
            End If

            ' END NEW CODE

            sTempParam = "{"
            For iTemp = 0 To ItemGroupList.Length - 1
                If iTemp > 0 And iTemp <= ItemGroupList.Length - 1 Then
                    sTempParam = sTempParam & ";"
                End If

                ' NEW CODE

                ' AMOUNT SPOIL RATE
                If BalancedRadioButton.Checked = False Then
                    ItemGroupList(iTemp) = FixValueInTableSpoil(ItemGroupList(iTemp), CDbl(AmnSpoilBox.Text) + AggrMetodDrop(iTemp))
                Else
                    ItemGroupList(iTemp) = FixValueInTableSpoil(ItemGroupList(iTemp), CDbl(AmnSpoilBox.Text) * AggrMetodDrop(iTemp))
                End If
                ItemGroupItemList = ItemGroupList(iTemp).Split(CChar(";"))
                ItemGroupItemList(3) = CStr(ItemGroupListChance(iTemp))

                'ItemGroupList(iForTemp) = "{" & ItemGroupItemList(0) & ";" & ItemGroupItemList(1) & ";" & ItemGroupItemList(2) & ";" & dblChcOut.ToString & "}"
                ItemGroupList(iTemp) = "{" & Join(ItemGroupItemList, ";") & "}"
                sTempParam = sTempParam & ItemGroupList(iTemp)
            Next
            sTempParam = sTempParam & "}"
            SpoilChange = StrLine.Replace(sParam, sTempParam)
        Else
            SpoilChange = StrLine
        End If

    End Function

    Private Function FixValueInTableSpoil(ByVal ItemGroup As String, ByVal RateValue As Double) As String

        '"{[piece_bone_breastplate];1;1;2.2988};{[piece_bone_breastplate_fragment];1;1;36.9195}
        ';{[bronze_breastplate];1;1;1.4858};{[piece_bone_gaiters];1;1;3.6734};{[piece_bone_gaiters_fragment];1;1;53.2415};
        '{[bronze_gaiters];1;1;2.381}};2.3887}"

        If RateValue = 1 Then
            Return ItemGroup
        End If

        Dim ItemList(0) As String
        ' for Special list
        Dim iTemp3 As Integer, isSpecialItem As Boolean

        Array.Clear(ItemList, 0, ItemList.Length)
        ItemList = ItemGroup.Split(CChar(";"))

        ItemGroup = ""

        If AmnChgItemListBox.Checked = True Then
            'SpecialItemsListTextBox
            isSpecialItem = False
            For iTemp3 = 0 To SpecialItemsListTextBox.Lines.Length - 1
                If ItemList(0) = SpecialItemsListTextBox.Lines(iTemp3) Then
                    isSpecialItem = True
                    Exit For
                End If
            Next
            If isSpecialItem = True Then
                ItemList(2) = CStr(CDbl(ItemList(2)) * RateValue)
                If AmnChgBothBox.Checked = True Then
                    ItemList(1) = CStr(CDbl(ItemList(1)) * RateValue)
                End If
            End If

        Else

            ' Fix any items
            ItemList(2) = CStr(CDbl(ItemList(2)) * RateValue)
            If AmnChgBothBox.Checked = True Then
                ItemList(1) = CStr(CDbl(ItemList(1)) * RateValue)
            End If

        End If
        ' Fix for Int amount
        If CInt(ItemList(1)) < 1 Then ItemList(1) = "1"
        If CInt(ItemList(2)) < 1 Then ItemList(2) = "1"
        ItemList(1) = CStr(CInt(ItemList(1))) : ItemList(2) = CStr(CInt(ItemList(2)))
        ItemGroup = Join(ItemList, ";")

        Return ItemGroup

    End Function

    Private Sub AmnDropBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles AmnDropBox.Validated
        'AmnDropBox.Text = CInt(AmnDropBox.Text).ToString
        If Val(AmnDropBox.Text) <= 0 Then
            AmnDropBox.Text = "1"
        End If
    End Sub

    Private Sub AmnSpoilBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles AmnSpoilBox.Validated
        'AmnSpoilBox.Text = CInt(AmnSpoilBox.Text).ToString
        If Val(AmnSpoilBox.Text) <= 0 Then
            AmnSpoilBox.Text = "1"
        End If
    End Sub

    Private Sub AmnAdenaBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles AmnAdenaBox.Validated
        'AmnAdenaBox.Text = CInt(AmnAdenaBox.Text).ToString
        If Val(AmnAdenaBox.Text) <= 0 Then
            AmnAdenaBox.Text = "1"
        End If
    End Sub

    Private Sub AmnSStoneBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles AmnSStoneBox.Validated
        'AmnSStoneBox.Text = CInt(AmnSStoneBox.Text).ToString
        If Val(AmnSStoneBox.Text) <= 0 Then
            AmnSStoneBox.Text = "1"
        End If
    End Sub



    Private Sub IgnoreNpcSelectAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IgnoreNpcSelectAllButton.Click
        Dim iTemp As Integer

        For iTemp = 0 To IgnoreNpcCheckedListBox.Items.Count - 1
            IgnoreNpcCheckedListBox.SetItemChecked(iTemp, True)
        Next
    End Sub

    Private Sub IgnoreNpcDeselectAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IgnoreNpcDeselectAllButton.Click
        Dim iTemp As Integer
        For iTemp = 0 To IgnoreNpcCheckedListBox.Items.Count - 1
            IgnoreNpcCheckedListBox.SetItemChecked(iTemp, False)
        Next
    End Sub

    Private Sub IgnoreNpcSelectionInvertButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IgnoreNpcSelectionInvertButton.Click
        Dim iTemp As Integer

        For iTemp = 0 To IgnoreNpcCheckedListBox.Items.Count - 1
            If IgnoreNpcCheckedListBox.GetItemChecked(iTemp) = False Then
                IgnoreNpcCheckedListBox.SetItemChecked(iTemp, True)
            Else
                IgnoreNpcCheckedListBox.SetItemChecked(iTemp, False)
            End If
        Next
    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

    Private Sub UseIgnoreListBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        If RadioButton1.Checked = False Then
            IgnoreNpcCheckedListBox.Enabled = True
        Else
            IgnoreNpcCheckedListBox.Enabled = False
        End If
    End Sub

    Private Sub RateLimitCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RateLimitCheckBox.CheckedChanged
        If RateLimitTextBox.Enabled = False Then
            RateLimitTextBox.Enabled = True
        Else
            RateLimitTextBox.Enabled = False
        End If
    End Sub

    Private Sub RateLimitTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles RateLimitTextBox.Validated
        RateLimitTextBox.Text = CInt(RateLimitTextBox.Text).ToString
        If CInt(RateLimitTextBox.Text) <= 0 Then
            RateLimitTextBox.Text = "100"
        End If
    End Sub

    Private Sub IgnoreNpcNameCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IgnoreNpcNameCheckBox.CheckedChanged
        If IgnoreNpcNameCheckBox.Checked = False Then
            IgnoreNpcNamesTextBox.Enabled = False
        Else
            IgnoreNpcNamesTextBox.Enabled = True
        End If
    End Sub

    Private Sub NpcdataRateReBuilder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MessageBox.Show("Decimal delimiter in 'Regional Settings' must be set to '.'", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

End Class
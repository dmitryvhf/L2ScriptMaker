Public Class NpcPosAreaMaker

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        NpcX.Text = "0"
        NpcY.Text = "0"
        NpcZ.Text = "0"
        ZoneRadius.Text = "100"
        TotalNpc.Text = "1"
        HeightZ.Text = "300"
        RespawnTime.Text = "1"
        RespawnClass.Text = "min"
        LookDirect.Text = "North"
        ImportPosText.Text = ""

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim Pos As Integer, NpcCount As Integer
        Dim TempX As Integer, TempY As Integer
        Dim MinTempX As Integer, MinTempY As Integer, MaxTempX As Integer, MaxTempY As Integer, MinTempZ As Integer, MaxTempZ As Integer
        Dim LookDir As String = ""

        'Dim dc As DataGridCell
        'dc.RowNumber = 1
        'dc.ColumnNumber = 1
        'DataGrid.Item(1, 1).Value = ""
        'DataGrid.Rows.Count

        Dim TempInstr1 As Integer, TempInstr2 As Integer
        NpcCount = 0

        If AutoClearBox.Checked = True Or OneZone.Checked = True Then TextBoxFinal.Text = ""

        ImportPosText.Text = Replace(ImportPosText.Text, " = ", "=")
        If CycleImport.Checked = True Then
            ImportPosText.Text = Replace(ImportPosText.Text, Chr(9), " ")
            ' tabs and spaces correction
            While InStr(ImportPosText.Text, "  ") <> 0
                ImportPosText.Text = Replace(ImportPosText.Text, "  ", " ")
            End While
        End If

        TempInstr2 = 1

cycleDo:
        If CycleImport.Checked = True And InStr(TempInstr2, ImportPosText.Text, "npc_begin") <> 0 Then

            If InStr(1, ImportPosText.Text, "npc_begin") = 0 Then Exit Sub

            TempInstr1 = InStr(TempInstr2, ImportPosText.Text, "[")
            TempInstr2 = InStr(TempInstr1, ImportPosText.Text, "]")

            NpcName.Text = Mid(ImportPosText.Text, TempInstr1 + 1, TempInstr2 - TempInstr1 - 1)

            TotalNpc.Text = GetNeedParamFromStr(ImportPosText.Text, "total")

            RespawnTime.Text = GetNeedParamFromStr(Mid(ImportPosText.Text, TempInstr1), "respawn")
            If InStr(RespawnTime.Text, "sec") <> 0 Then RespawnClass.Text = "sec" : RespawnTime.Text = Replace(RespawnTime.Text, "sec", "")
            If InStr(RespawnTime.Text, "min") <> 0 Then RespawnClass.Text = "min" : RespawnTime.Text = Replace(RespawnTime.Text, "min", "")
            If InStr(RespawnTime.Text, "hour") <> 0 Then RespawnClass.Text = "hour" : RespawnTime.Text = Replace(RespawnTime.Text, "hour", "")

            TempInstr1 = InStr(TempInstr2, ImportPosText.Text, "pos={") + 5
            TempInstr2 = InStr(TempInstr1, ImportPosText.Text, ";")
            NpcX.Text = Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1)

            TempInstr1 = TempInstr2 + 1
            TempInstr2 = InStr(TempInstr1, ImportPosText.Text, ";")
            NpcY.Text = Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1)

            TempInstr1 = TempInstr2 + 1
            TempInstr2 = InStr(TempInstr1, ImportPosText.Text, ";")
            NpcZ.Text = Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1)

            TempInstr1 = TempInstr2 + 1
            TempInstr2 = InStr(TempInstr1, ImportPosText.Text, "}")
            LookDirect.Text = Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1)

            If NpcCount = 0 Then
                MinTempX = CInt(NpcX.Text)
                MinTempY = CInt(NpcY.Text)
                MinTempZ = CInt(NpcZ.Text)
                MaxTempX = CInt(NpcX.Text)
                MaxTempY = CInt(NpcY.Text)
                MaxTempZ = CInt(NpcZ.Text)
            End If

        End If

        Select Case LookDirect.Text
            Case "North"
                LookDir = "49152"
            Case "East"
                LookDir = "0"
            Case "South"
                LookDir = "16384"
            Case "West"
                LookDir = "32768"
            Case Else
                LookDir = LookDirect.Text
        End Select


        ' If AutoClearBox.Checked = True And CycleImport.Checked = False Then TextBoxFinal.Text = ""

        'territory_begin	[20_22_NPC_031130_01]	{{19900;146109;-3224;-3024};{20100;146109;-3224;-3024};{20100;146309;-3224;-3024};{19900;146309;-3224;-3024}}	territory_end
        If CycleImport.Checked = True Then
            If OneZone.Checked = True Then
                'TextBoxFinal.Text += "territory_begin" & Chr(9) & "[" & ZoneName.Text & "]" & Chr(9) & "{"
            Else
                TextBoxFinal.Text += "territory_begin" & Chr(9) & "[" & NpcName.Text & "_auto_gen_zone" & "]" & Chr(9) & "{"
            End If
        Else
            TextBoxFinal.Text += "territory_begin" & Chr(9) & "[" & ZoneName.Text & "]" & Chr(9) & "{"
        End If

        For Pos = 1 To 4
            If OneZone.Checked = False Then If Pos > 1 Then TextBoxFinal.Text += ";"
            Select Case Pos
                Case 1
                    TempX = CInt(NpcX.Text) - CInt(ZoneRadius.Text)
                    TempY = CInt(NpcY.Text) - CInt(ZoneRadius.Text)
                    If MinTempX > TempX Then MinTempX = TempX
                    If MinTempY > TempY Then MinTempY = TempY
                Case 2
                    TempX = CInt(NpcX.Text) + CInt(ZoneRadius.Text)
                    TempY = CInt(NpcY.Text) - CInt(ZoneRadius.Text)
                    If MaxTempX < TempX Then MaxTempX = TempX
                    If MinTempY > TempY Then MinTempY = TempY
                Case 3
                    TempX = CInt(NpcX.Text) + CInt(ZoneRadius.Text)
                    TempY = CInt(NpcY.Text) + CInt(ZoneRadius.Text)
                    If MaxTempX < TempX Then MaxTempX = TempX
                    If MaxTempY < TempY Then MaxTempY = TempY
                Case 4
                    TempX = CInt(NpcX.Text) - CInt(ZoneRadius.Text)
                    TempY = CInt(NpcY.Text) + CInt(ZoneRadius.Text)
                    If MinTempX > TempX Then MinTempX = TempX
                    If MaxTempY < TempY Then MaxTempY = TempY
            End Select
            If OneZone.Checked = False Then
                TextBoxFinal.Text += "{" & TempX.ToString & ";" & TempY.ToString & ";" & (CInt(NpcZ.Text) - 20).ToString & ";" & (CInt(NpcZ.Text) + CInt(HeightZ.Text)).ToString & "}"
            End If
        Next

        If OneZone.Checked = False Then
            TextBoxFinal.Text += "}" & Chr(9) & "territory_end" & Chr(13) & Chr(10)
        End If

        'npcmaker_begin	[20_22_NPC_031130_01]	initial_spawn = all	maximum_npc = 1

        If CycleImport.Checked = True Then
            If OneZone.Checked = True Then
                NpcCount += 1
            Else
                TextBoxFinal.Text += "npcmaker_begin" & Chr(9) & "[" & NpcName.Text & "_auto_gen_zone]" & Chr(9) & "initial_spawn=all" & Chr(9) & "maximum_npc=1" & Chr(13) & Chr(10)
            End If
        Else
            TextBoxFinal.Text += "npcmaker_begin" & Chr(9) & "[" & ZoneName.Text & "]" & Chr(9) & "initial_spawn=all" & Chr(9) & "maximum_npc=1" & Chr(13) & Chr(10)
        End If

        Dim PrivText As String = ""
        If PrivChkBox.Checked = True Then

            ' make Privates pos
            Dim TempVal As Integer
            PrivText += "Privates=["

            If CInt(Priv1Quantity.Text) > 0 Then
                For TempVal = 1 To CInt(Priv1Quantity.Text)
                    PrivText += Priv1Name.Text + ":" + Priv1Ai.Text + ":" + "1:" + PrivRespawn.Text + PrivRespawnTime.Text
                    If TempVal <> CInt(Priv1Quantity.Text) Then PrivText += ";"
                Next
            End If
            If CInt(Priv2Quantity.Text) > 0 Then
                PrivText += ";"
                For TempVal = 1 To CInt(Priv2Quantity.Text)
                    PrivText += Priv2Name.Text + ":" + Priv2Ai.Text + ":" + "1:" + PrivRespawn.Text + PrivRespawnTime.Text
                    If TempVal <> CInt(Priv2Quantity.Text) Then PrivText += ";"
                Next
            End If

            PrivText += "]" & Chr(9)
        End If

        'npc_begin	[seth]	pos = {19996;146216;-3111;57344}	total=1	respawn = 1min	npc_end
        TextBoxFinal.Text += "npc_begin" & Chr(9) & "[" & NpcName.Text.ToLower & "]" & Chr(9) & "pos={" & NpcX.Text & ";" & NpcY.Text & ";" & NpcZ.Text & ";" & LookDir & "}" & Chr(9) & "total=" & TotalNpc.Text & Chr(9) & "respawn=" & RespawnTime.Text & RespawnClass.Text & Chr(9) & PrivText & "npc_end" & Chr(13) & Chr(10)

        If MinTempZ > CInt(NpcZ.Text) Then MinTempZ = CInt(NpcZ.Text)
        If MaxTempZ < CInt(NpcZ.Text) Then MaxTempZ = CInt(NpcZ.Text)

        'npcmaker_end
        'If OneZone.Checked = False Then TextBoxFinal.Text += "npcmaker_end"

        If CycleImport.Checked = True Then
            If InStr(TempInstr2, ImportPosText.Text, "npc_begin") <> 0 Then
                If OneZone.Checked = False Then TextBoxFinal.Text += "npcmaker_end" & Chr(13) & Chr(10)
                GoTo cycleDo
            Else
                TextBoxFinal.Text += "npcmaker_end"
                If OneZone.Checked = True Then
                    'TextBoxFinal.Text += "npcmaker_end"
                    Dim ZoneDefine As String
                    ZoneDefine = "{" & MinTempX.ToString & ";" & MinTempY.ToString & ";" & (MinTempZ - 20).ToString & ";" & (MaxTempZ + CInt(HeightZ.Text)).ToString & "}"
                    ZoneDefine += ";{" & MaxTempX.ToString & ";" & MinTempY.ToString & ";" & (MinTempZ - 20).ToString & ";" & (MaxTempZ + CInt(HeightZ.Text)).ToString & "}"
                    ZoneDefine += ";{" & MaxTempX.ToString & ";" & MaxTempY.ToString & ";" & (MinTempZ - 20).ToString & ";" & (MaxTempZ + CInt(HeightZ.Text)).ToString & "}"
                    ZoneDefine += ";{" & MinTempX.ToString & ";" & MaxTempY.ToString & ";" & (MinTempZ - 20).ToString & ";" & (MaxTempZ + CInt(HeightZ.Text)).ToString & "}"

                    TextBoxFinal.Text = "npcmaker_begin" & Chr(9) & "[" & ZoneName.Text & "]" & Chr(9) & "initial_spawn=all" & Chr(9) & "maximum_npc=" & NpcCount & Chr(13) & Chr(10) & TextBoxFinal.Text
                    TextBoxFinal.Text = "territory_begin" & Chr(9) & "[" & ZoneName.Text & "]" & Chr(9) & "{" & ZoneDefine & "}" & Chr(9) & "territory_end" & Chr(13) & Chr(10) & TextBoxFinal.Text
                End If
                Exit Sub
            End If
        Else
            'If OneZone.Checked = True Then
            TextBoxFinal.Text += "npcmaker_end"
            Exit Sub
        End If

        Exit Sub

    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        TextBoxFinal.Text = ""
    End Sub

    Function GetNeedParamFromStr(ByVal SourceStr As String, ByVal MaskStr As String) As String

        'Update 15.01.2007 00:05

        Dim FirstPos, SecondPos As Integer
        GetNeedParamFromStr = ""

        ' PreWorking string
        SourceStr = SourceStr.Replace(Chr(9), " ")
        SourceStr = SourceStr.Replace(" = ", "=")
        While InStr(SourceStr, "  ") > 0
            SourceStr = SourceStr.Replace("  ", " ")
        End While

        FirstPos = InStr(1, SourceStr, MaskStr + "=")
        If FirstPos = Nothing Then
            GetNeedParamFromStr = ""
            Exit Function
        End If
        FirstPos += MaskStr.Length
        SecondPos = FirstPos + 1
        SecondPos = InStr(SecondPos, SourceStr, " ")
        If SecondPos = 0 Then SecondPos = SourceStr.Length

        GetNeedParamFromStr = Trim(Mid(SourceStr, FirstPos + 1, SecondPos - FirstPos))

    End Function

    Private Sub ImportPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportPos.Click
        Dim TempInstr1 As Integer, TempInstr2 As Integer

        If InStr(1, ImportPosText.Text, "npc_begin") = 0 Then Exit Sub

        ImportPosText.Text = Replace(ImportPosText.Text, Chr(9), " ")
        ' tabs and spaces correction
        While InStr(ImportPosText.Text, "  ") <> 0
            ImportPosText.Text = Replace(ImportPosText.Text, "  ", " ")
        End While

        TempInstr1 = InStr(ImportPosText.Text, "[")
        TempInstr2 = InStr(TempInstr1, ImportPosText.Text, "]")

        NpcName.Text = Mid(ImportPosText.Text, TempInstr1 + 1, TempInstr2 - TempInstr1 - 1)

        TotalNpc.Text = GetNeedParamFromStr(ImportPosText.Text, "total")

        RespawnTime.Text = GetNeedParamFromStr(ImportPosText.Text, "respawn")
        If InStr(RespawnTime.Text, "sec") <> 0 Then RespawnClass.Text = "sec" : RespawnTime.Text = Replace(RespawnTime.Text, "sec", "")
        If InStr(RespawnTime.Text, "min") <> 0 Then RespawnClass.Text = "min" : RespawnTime.Text = Replace(RespawnTime.Text, "min", "")
        If InStr(RespawnTime.Text, "hour") <> 0 Then RespawnClass.Text = "hour" : RespawnTime.Text = Replace(RespawnTime.Text, "hour", "")

        TempInstr1 = InStr(TempInstr2, ImportPosText.Text, "{") + 1
        TempInstr2 = InStr(TempInstr1, ImportPosText.Text, ";")
        NpcX.Text = Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1)

        TempInstr1 = TempInstr2 + 1
        TempInstr2 = InStr(TempInstr1, ImportPosText.Text, ";")
        NpcY.Text = Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1)

        TempInstr1 = TempInstr2 + 1
        TempInstr2 = InStr(TempInstr1, ImportPosText.Text, ";")
        NpcZ.Text = Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1)

        TempInstr1 = TempInstr2 + 1
        TempInstr2 = InStr(TempInstr1, ImportPosText.Text, "}")
        LookDirect.Text = Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1)

    End Sub

    Private Sub OneZone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OneZone.CheckedChanged
        If OneZone.Checked = True Then
            CycleImport.Checked = True
            CycleImport.Enabled = False
            AutoClearBox.Checked = True
        Else
            CycleImport.Enabled = True
        End If
    End Sub

    ' ------------------------ MultiSpawn Module -------------------

    Private Sub CalculateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateButton.Click

        If DataGrid.RowCount < 2 Then
            Exit Sub
        End If

        'Dim dc As DataGridCell
        'dc.RowNumber = 1
        'dc.ColumnNumber = 1

        Dim iTemp As Integer : Dim Summ As Integer = 0

        ' Calculate full change summ
        Dim aChange(DataGrid.RowCount - 2) As Integer
again:
        For iTemp = 0 To DataGrid.RowCount - 2
            If CInt(DataGrid.Item(4, iTemp).Value) < 0 Then
                MessageBox.Show("Negative chance! Edit and calculate again.", "Wrong chance", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Summ += CInt(DataGrid.Item(4, iTemp).Value)
        Next

        Select Case Summ
            Case Is < 0
                MessageBox.Show("Somewhere wrong chance", "Wrong chance", MessageBoxButtons.OK)
                Exit Sub
            Case Is < 100
                DataGrid.Item(4, 0).Value = CInt(DataGrid.Item(4, 0).Value) + (100 - Summ)
            Case Is > 100
                Dim Divider As Double = CDbl(100 / Summ)
                For iTemp = 0 To DataGrid.RowCount - 2
                    DataGrid.Item(4, iTemp).Value = CInt(CInt(DataGrid.Item(4, iTemp).Value) * Divider)
                Next
                Summ = 0
                GoTo again
            Case 100
                Exit Sub
        End Select

    End Sub

    Private Sub GenerateMultiSpawnButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateMultiSpawnButton.Click
        MultiSpawnTextBox.Text = ""
        Dim aChange(DataGrid.RowCount - 2) As Integer
        Dim iTemp As Integer : Dim Summ As Integer = 0

        MultiSpawnTextBox.Text += "{"
        For iTemp = 0 To DataGrid.RowCount - 2

            If iTemp > 0 Then
                MultiSpawnTextBox.Text += ";"
            End If
            MultiSpawnTextBox.Text += "{"
            Try
                MultiSpawnTextBox.Text += DataGrid.Item(0, iTemp).Value.ToString & ";"
                MultiSpawnTextBox.Text += DataGrid.Item(1, iTemp).Value.ToString & ";"
                MultiSpawnTextBox.Text += DataGrid.Item(2, iTemp).Value.ToString & ";"
                MultiSpawnTextBox.Text += DataGrid.Item(3, iTemp).Value.ToString & ";"
                MultiSpawnTextBox.Text += DataGrid.Item(4, iTemp).Value.ToString & "%"
            Catch ex As Exception
                MessageBox.Show("Enter values to all cells and try again", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MultiSpawnTextBox.Text = ""
                Exit Sub
            End Try
            MultiSpawnTextBox.Text += "}"

        Next
        MultiSpawnTextBox.Text += "}"

    End Sub
End Class
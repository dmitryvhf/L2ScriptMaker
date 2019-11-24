Public Class ClientAggroPatchMaker

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim AiFile As String
        Dim NpcFile As String
        Dim NpcFileE As String
        Dim newNpcEFile As String

        Dim aClassName(0) As String
        Dim aClassStyle(0) As String

        Dim aNpcId(0) As String
        Dim aNpcAi(0) As String
        Dim aNpcLvl(0) As String

        OpenFileDialog.FileName = "ai.obj"
        OpenFileDialog.Filter = "Lineage II server npc intelligence file (ai.obj)|ai*.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        AiFile = OpenFileDialog.FileName

        OpenFileDialog.FileName = "npcdata.txt"
        OpenFileDialog.Filter = "Lineage II server npc file (npcdata.txt)|npcdata*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        NpcFile = OpenFileDialog.FileName

        OpenFileDialog.FileName = "npcname-e.txt"
        OpenFileDialog.Filter = "Lineage II client npc file (npcname-e.txt)|npcname-e.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        NpcFileE = OpenFileDialog.FileName

        SaveFileDialog.FileName = "npcname-e_new.txt"
        SaveFileDialog.Filter = "Lineage II server npc file (npcname-e.txt)|npcname-e*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        newNpcEFile = SaveFileDialog.FileName

        Dim inFile As System.IO.StreamReader

        Dim aTemp() As String
        Dim sTemp As String

        inFile = New System.IO.StreamReader(AiFile, System.Text.Encoding.Default, True, 1)
        ToolStripStatusLabel.Text = "Loading Ai.obj..."
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        StatusStrip.Update()
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp.StartsWith("class ") = True Then
                aTemp = sTemp.Split(Chr(32))
                'class(0) 1(1) default_npc(2) :(3) (null)(4)
                Array.Resize(aClassName, aClassName.Length + 1)
                aClassName(aClassName.Length - 1) = aTemp(2)
                Array.Resize(aClassStyle, aClassStyle.Length + 1)
                aClassStyle(aClassStyle.Length - 1) = aTemp(4)
            End If

        End While
        inFile.Close()
        ToolStripProgressBar.Value = 0

        Dim sTemp2 As String

        inFile = New System.IO.StreamReader(NpcFile, System.Text.Encoding.Default, True, 1)
        ToolStripStatusLabel.Text = "Loading npcdata.txt..."
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        StatusStrip.Update()
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then

                'npc_begin      pet     12077   [pet_wolf_a]    level=15
                'npc_ai={[black_leopard];{[MoveAroundSocial]=90};

                aTemp = sTemp.Replace(Chr(32), Chr(9)).Split(Chr(9))

                If aTemp(1) = "warrior" Then
                    Array.Resize(aNpcId, aNpcId.Length + 1)
                    aNpcId(aNpcId.Length - 1) = aTemp(2)    'ID
                    Array.Resize(aNpcLvl, aNpcLvl.Length + 1)
                    aNpcLvl(aNpcLvl.Length - 1) = Libraries.GetNeedParamFromStr(sTemp, "level")    'Level

                    sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "npc_ai")
                    If sTemp2 <> "{}" Then
                        sTemp2 = sTemp2.Substring(2, InStr(sTemp2, "]") - 3)
                        Array.Resize(aNpcAi, aNpcAi.Length + 1)
                        aNpcAi(aNpcAi.Length - 1) = sTemp2   'Ai
                    End If
                End If

            End If

        End While
        inFile.Close()


        'npcname_begin  id=20001        name=[Gremlin]  description=[]

        inFile = New System.IO.StreamReader(NpcFileE, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(newNpcEFile, False, System.Text.Encoding.Unicode, 1)
        ToolStripStatusLabel.Text = "Analysing npcname-e.txt..."
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        StatusStrip.Update()

        Dim iTempId As Integer, iTemp As Integer

        Dim Tag1 As String = Tag1TextBox.Text
        Dim Tag2 As String = Tag2TextBox.Text

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

            iTempId = CInt(Libraries.GetNeedParamFromStr(sTemp, Tag1))
            iTemp = Array.IndexOf(aNpcId, iTempId.ToString)
            If iTemp <> -1 Then
                If Libraries.GetNeedParamFromStr(sTemp, Tag2TextBox.Text) = "[]" Then

                    sTemp2 = MaskPassTextBox.Text.Replace("$lvl", aNpcLvl(iTemp))
                    iTemp = Array.IndexOf(aClassName, aNpcAi(iTemp))

                    If iTemp <> -1 Then
                        If InStr(aClassStyle(iTemp), "_ag_") <> 0 Or InStr(aClassStyle(iTemp), "aggressive") <> 0 Then
                            sTemp2 = sTemp2 & MaskAggrTextBox.Text
                        End If

                        sTemp = sTemp.Replace(" = ", "=")
                        sTemp = sTemp.Replace(Tag2 & "=" & Libraries.GetNeedParamFromStr(sTemp, Tag2), Tag2 & "=[" & sTemp2 & "]")
                    End If
                End If
            End If
            outFile.WriteLine(sTemp)

        End While
        inFile.Close()
        ToolStripProgressBar.Value = 0

        outFile.Close()

        ToolStripStatusLabel.Text = "Complete"
        ToolStripProgressBar.Value = 0
        MessageBox.Show("Complete.")


    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

    Private Sub MaskPassTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskPassTextBox.TextChanged
        ExampleTextBox.Text = (MaskPassTextBox.Text & MaskAggrTextBox.Text).Replace("$lvl", "75")
    End Sub

    Private Sub MaskAggrTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskAggrTextBox.TextChanged
        ExampleTextBox.Text = (MaskPassTextBox.Text & MaskAggrTextBox.Text).Replace("$lvl", "75")
    End Sub
End Class
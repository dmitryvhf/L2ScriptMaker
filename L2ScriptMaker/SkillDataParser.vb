Public Class SkillDataParser

    Private Sub ScanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanButton.Click

        Dim sSkillFile As String

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II C4 Skill Script (skilldata.txt)|skilldata.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sSkillFile = OpenFileDialog.FileName

        If ScanParamComboBox.Text.Trim = "" Then
            MessageBox.Show("Enter param name for researching and try again.", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim inFile As New System.IO.StreamReader(sSkillFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sSkillFile & ".log", True, System.Text.Encoding.Unicode, 1)

        Dim sTemp As String, sTemp2 As String

        Dim aTemp() As String   ' Use for temporary splitting skill effect to parts
        Dim aTemp2() As String   ' Use for temporary splitting effect to effects
        Dim aEffect(0) As String
        Dim aEffectSkill(0) As String
        Dim aEffectExample(0) As String

        'skill_name=[s_stun_attack_boss_b_1a_8]
        'effect={}
        '{{p_block_act}}
        '{{i_m_attack;57}}
        '{{i_spoil};{p_attack_speed;{all};-23;per}}

        Dim iTemp As Integer

        outFile.WriteLine("//------------------------------------------------------")
        outFile.WriteLine("// L2ScriptMaker: Lineage II Skilldata Effect Researcher")
        outFile.WriteLine("//------------------------------------------------------")
        outFile.WriteLine("// Researching for [" & ScanParamComboBox.Text & "] start at " & Now)
        outFile.WriteLine()

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            sTemp2 = Libraries.GetNeedParamFromStr(sTemp, ScanParamComboBox.Text)
            If sTemp2 <> "" And sTemp2.StartsWith("//") = False And sTemp2 <> "{}" Then
                sTemp2 = sTemp2.Substring(1, sTemp2.Length - 2).Replace("};{", "}|{")
                aTemp = sTemp2.Split(CChar("|"))

                For iTemp = 0 To aTemp.Length - 1
                    aTemp2 = aTemp(iTemp).Substring(1, aTemp(iTemp).Length - 2).Split(CChar(";"))
                    If Array.IndexOf(aEffect, aTemp2(0)) = -1 Then

                        aEffect(aEffect.Length - 1) = aTemp2(0)
                        aEffectSkill(aEffectSkill.Length - 1) = aTemp(iTemp)
                        aEffectExample(aEffectExample.Length - 1) = Libraries.GetNeedParamFromStr(sTemp, "skill_name")

                        outFile.WriteLine("------------------")
                        outFile.WriteLine("Skill effect     : " & aTemp2(0))
                        outFile.WriteLine("Example for skill: " & Libraries.GetNeedParamFromStr(sTemp, "skill_name") & vbTab _
                        & Libraries.GetNeedParamFromStr(sTemp, "operate_type") & vbTab & aTemp(iTemp))
                        outFile.WriteLine("Description      :")
                        outFile.Flush()

                        Array.Resize(aEffect, aEffect.Length + 1)
                        Array.Resize(aEffectSkill, aEffectSkill.Length + 1)
                        Array.Resize(aEffectExample, aEffectExample.Length + 1)
                    End If
                    If aTemp2(0) = "i_restoration_random" Then Exit For
                    If aTemp2(0) = "op_not_territory" Then Exit For
                Next

            End If
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

        End While

        ToolStripProgressBar.Value = 0

        outFile.WriteLine()
        outFile.WriteLine("Researching stop at " & Now & vbTab & "Founded at " & aEffect.Length & " effects of skill.")
        outFile.Close()
        inFile.Close()

        MessageBox.Show("Complete.")


    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub
End Class
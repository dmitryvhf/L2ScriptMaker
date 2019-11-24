Public Class AugmentationGenerator

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sTemp As String
        Dim iTemp As Integer

        Dim inFile As System.IO.StreamReader
        Dim outFile As System.IO.StreamWriter

        Dim sAughEFile As String = "optiondata_client-e.txt"
        Dim sAughDataFile As String = "augmentation.txt"


        If System.IO.File.Exists(sAughEFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II client text file (optiondata_client-e.txt)|optiondata_client*.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sAughEFile = OpenFileDialog.FileName
        End If

        SaveFileDialog.FileName = sAughDataFile
        SaveFileDialog.Filter = "Lineage II server Augmentation script (La2Guard Ext) (augmentation.txt)|augmentation*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sAughDataFile = SaveFileDialog.FileName


        inFile = New System.IO.StreamReader(sAughEFile, System.Text.Encoding.Default, True, 1)
        outFile = New System.IO.StreamWriter(sAughDataFile, False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading optiondata_client-e.txt..."

        Dim sTempVal As String = "", sNewData As String = ""

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

            If sTemp.Trim <> "" And sTemp.Trim <> Nothing And sTemp.StartsWith("//") = False Then

                sNewData = "augmentation_begin" & vbTab
                sNewData = sNewData & Libraries.GetNeedParamFromStr(sTemp, "id") & vbTab

                'optiondata_client-e_begin	id=1	level?=1	var_of_level?=1	effect1_desc=[P. Def. +15.4]	effect2_desc=[]	effect3_desc?=[]	optiondata_client-e_end
                'optiondata_client-e_begin	id=5810	level?=3	var_of_level?=1	effect1_desc=[HP Recovery +0.2]	effect2_desc=[MP Recovery +0.1]	effect3_desc?=[]	optiondata_client-e_end
                'optiondata_client-e_begin	id=15024	level?=3	var_of_level?=2	effect1_desc=[Chance: Has a chance to increase your PVP power wh\\nen you take damage in PvP.]	effect2_desc=[]	effect3_desc?=[]	optiondata_client-e_end

                'augmentation_begin	1	p_def=15.4	augmentation_end
                'augmentation_begin	5810	hp_recovery=0.2	mp_recovery=0.1	augmentation_end
                'augmentation_begin	15024	skill_id=3217	skill_level=3	augmentation_end

                'effect1_desc=[P. Def. +15.4]

                For iTemp = 1 To 2

                    If iTemp = 1 Then sTempVal = Libraries.GetNeedParamFromStr(sTemp, "effect1_desc")
                    If iTemp = 2 Then sTempVal = Libraries.GetNeedParamFromStr(sTemp, "effect2_desc")
                    If iTemp = 3 Then sTempVal = Libraries.GetNeedParamFromStr(sTemp, "effect3_desc?")

                    If sTempVal.StartsWith("[Active:") = True Or sTempVal.StartsWith("[Chance:") = True Or sTempVal.StartsWith("[Passive:") = True Then
                        '[Active:  [Passive:
                        sTempVal = "skill_id=1" & vbTab & "skill_level=1" & vbTab
                    Else

                        ' La2Guard standart
                        sTempVal = sTempVal.Replace("[P. Atk. ", "p_atk")
                        sTempVal = sTempVal.Replace("[P. Def.", "p_def")
                        sTempVal = sTempVal.Replace("[M. Atk.", "m_atk")
                        sTempVal = sTempVal.Replace("[M. Def.", "m_def")
                        sTempVal = sTempVal.Replace("[Accuracy", "accuracy")
                        sTempVal = sTempVal.Replace("[Dodge", "dodge")
                        sTempVal = sTempVal.Replace("[Critical", "critical")

                        sTempVal = sTempVal.Replace("[HP Recovery", "hp_recovery")
                        sTempVal = sTempVal.Replace("[MP Recovery", "mp_recovery")
                        sTempVal = sTempVal.Replace("[CP Recovery", "cp_recovery")
                        sTempVal = sTempVal.Replace("[Maximum HP", "max_hp")
                        sTempVal = sTempVal.Replace("[Maximum MP", "max_mp")
                        sTempVal = sTempVal.Replace("[Maximum CP", "max_cp")

                        sTempVal = sTempVal.Replace("[STR", "str")
                        sTempVal = sTempVal.Replace("[CON", "con")
                        sTempVal = sTempVal.Replace("[DEX", "dex")
                        sTempVal = sTempVal.Replace("[INT", "int")
                        sTempVal = sTempVal.Replace("[MEN", "men")
                        sTempVal = sTempVal.Replace("[WIT", "wit")

                        ' dVampire standart

                        'level?=4
                        'sTempVal = sTempVal.Replace("[P. Atk. ", "pAtk_inc")
                        'sTempVal = sTempVal.Replace("[P. Def.", "pDef_inc")
                        'sTempVal = sTempVal.Replace("[M. Atk.", "matk_inc")
                        'sTempVal = sTempVal.Replace("[M. Def.", "mdef_inc")
                        'sTempVal = sTempVal.Replace("[Accuracy", "accuracy_inc")
                        'sTempVal = sTempVal.Replace("[Dodge", "evasion_inc")
                        'sTempVal = sTempVal.Replace("[Critical", "critical_atk_inc")

                        'sTempVal = sTempVal.Replace("[HP Recovery", "hp_regen")
                        'sTempVal = sTempVal.Replace("[MP Recovery", "mp_regen")
                        'sTempVal = sTempVal.Replace("[CP Recovery", "cp_regen")
                        'sTempVal = sTempVal.Replace("[Maximum HP", "max_hp")
                        'sTempVal = sTempVal.Replace("[Maximum MP", "max_mp")
                        'sTempVal = sTempVal.Replace("[Maximum CP", "max_cp")

                        'sTempVal = sTempVal.Replace("[STR", "str_inc")
                        'sTempVal = sTempVal.Replace("[CON", "con_inc")
                        'sTempVal = sTempVal.Replace("[DEX", "dex_inc")
                        'sTempVal = sTempVal.Replace("[INT", "int_inc")
                        'sTempVal = sTempVal.Replace("[MEN", "men_inc")
                        'sTempVal = sTempVal.Replace("[WIT", "wit_inc")

                        sTempVal = sTempVal.Replace(" ", "").Replace("+", "=").Replace("[", "").Replace("]", "")

                    End If

                    If sTempVal <> "" Then sNewData = sNewData & sTempVal & vbTab

                Next

                sNewData = sNewData & "augmentation_end"

            End If

            outFile.WriteLine(sNewData)
            sNewData = ""

        End While

        inFile.Close()
        outFile.Close()
        ToolStripProgressBar.Value = 0

        MessageBox.Show("Done")


    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub
End Class
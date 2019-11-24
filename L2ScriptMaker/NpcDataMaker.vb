Public Class NpcDataMaker

    Private Sub NpcDataMaker_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DataGridView1.Rows.Add(1, 1, 1, 1, 1, 1, 1)
    End Sub

    Private Sub ButtonGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerate.Click

        Dim iTemp As Integer = 0
        Dim sTemp As String = ""

        Dim iTempVal As Double

        FinalTextBox.Text = CommonStatTextBox.Text & vbNewLine
        For iTemp = 0 To DataGridView1.ColumnCount - 1

            iTempVal = CDbl(DataGridView1.Item(iTemp, 0).Value)

            Select Case NpcTypeComboBox.Text
                Case "warrior"
                    Select Case DataGridView1.Columns(iTemp).Name
                        Case "org_hp"
                            iTempVal = CInt(iTempVal / 1.58)
                        Case "org_mp"
                            iTempVal = CInt(iTempVal / 1.1)
                        Case "base_physical_attack"
                            iTempVal = CDbl((iTempVal / 1.91).ToString(".##"))
                        Case "base_attack_speed"
                            iTempVal = CDbl((iTempVal / 1.095).ToString(".##"))
                        Case "base_magic_attack"
                            iTempVal = CDbl((iTempVal / 1.66).ToString(".##"))
                        Case "base_defend"
                            iTempVal = CDbl((iTempVal / 1.58).ToString(".##"))
                        Case "base_magic_defend"
                            iTempVal = CDbl((iTempVal / 1.76).ToString(".##"))
                    End Select
                Case "boss"
                    Select Case DataGridView1.Columns(iTemp).Name
                        Case "org_hp"
                            iTempVal = CInt(iTempVal / 2.38)
                        Case "org_mp"
                            iTempVal = CInt(iTempVal / 2.21)
                        Case "base_physical_attack"
                            iTempVal = CDbl((iTempVal / 3.935).ToString(".##"))
                        Case "base_attack_speed"
                            iTempVal = CDbl((iTempVal / 1.62).ToString(".##"))
                        Case "base_magic_attack"
                            iTempVal = CDbl((iTempVal / 15.37).ToString(".##"))
                        Case "base_defend"
                            iTempVal = CDbl((iTempVal / 1.62).ToString(".##"))
                        Case "base_magic_defend"
                            iTempVal = CDbl((iTempVal / 3.6).ToString(".##"))
                    End Select
            End Select

            sTemp = DataGridView1.Columns(iTemp).Name & "=" & iTempVal & vbTab

            FinalTextBox.AppendText(sTemp)

        Next

        TabControl1.SelectedIndex = 1


    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        FinalTextBox.Text = ""
    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

    Private Sub NpcTypeComboBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NpcTypeComboBox.TextChanged

        Select Case NpcTypeComboBox.SelectedIndex
            Case 0
                CommonStatTextBox.Text = "str=40	int=21	dex=30	wit=20	con=43	men=10"
            Case 1
                CommonStatTextBox.Text = "str=60	int=76	dex=73	wit=70	con=57	men=80"
        End Select

    End Sub

End Class
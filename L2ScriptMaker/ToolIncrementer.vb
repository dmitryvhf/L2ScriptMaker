Public Class ToolIncrementer

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        ResultTextBox.Text = ""

        Dim StartLevel As Double, EndLevel As Double
        Dim Increment As Double
        Dim Variable As Double

        Try
            StartLevel = CDbl(StartLevelTextBox.Text)
            EndLevel = CDbl(EndLevelTextBox.Text)
            If Use1RadioButton.Checked = True Then
                Increment = CDbl(IncValueTextBox.Text)
            Else
                Increment = CDbl(MultValueTextBox.Text)
            End If
            Variable = CDbl(StartValueTextBox.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

        Dim ParamName As String = ParamNameTextBox.Text
        Dim LeftSym As String = LeftTextBox.Text
        Dim RightSym As String = RightTextBox.Text

        Dim iTemp As Double

        For iTemp = StartLevel To EndLevel
            ResultTextBox.AppendText(ParamName)
            If ParamAddNameCheckBox.Checked = True Then ResultTextBox.AppendText(CStr(iTemp))
            ResultTextBox.AppendText(" = " & LeftSym)
            ResultTextBox.AppendText(Variable.ToString & RightSym & vbNewLine)
            If Use1RadioButton.Checked = True Then
                Variable = Variable + Increment
            Else
                If Variable < 0 Then
                    Increment = -Increment
                Else
                    If Increment < 0 Then
                        Increment = Increment
                    End If
                End If
                Variable = Variable + (Variable * Increment)
            End If
        Next

        TabControl1.SelectedIndex = 1

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub


    Private Sub Use2RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Use2RadioButton.CheckedChanged
        If Use2RadioButton.Checked = False Then
            IncValueTextBox.ReadOnly = False
            MultValueTextBox.ReadOnly = True
        Else
            IncValueTextBox.ReadOnly = True
            MultValueTextBox.ReadOnly = False
        End If
    End Sub
End Class
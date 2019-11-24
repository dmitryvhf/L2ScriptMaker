Public Class Eula

    Private Sub Accept2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Accept2Button.Click
        Me.Close()
        'form.WelcomeForm
    End Sub

    Private Sub DeclineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeclineButton.Click
        End
        'Application.Exit()
    End Sub

    Private Sub Eula_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Select(0, 0)
    End Sub
End Class
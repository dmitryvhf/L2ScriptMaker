Public Class GeoLocConverter

    '$geo_x=20+($game_x-$game_x%32768)/32768; 
    '$geo_y=18+($game_y-$game_y%32768)/32768;

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub XTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XTextBox.TextChanged
        Try
            GeonameXTextBox.Text = CStr(Fix(20 + (CInt(XTextBox.Text) - CInt(XTextBox.Text) \ 32768) / 32768))
        Catch ex As Exception
            If XTextBox.Text = "" Then
                XTextBox.Text = "0"
            Else
                GeonameXTextBox.Text = "!"
            End If
        End Try
    End Sub

    Private Sub YTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YTextBox.TextChanged
        Try
            GeonameYTextBox.Text = CStr(Fix(18 + (CInt(YTextBox.Text) - CInt(YTextBox.Text) \ 32768) / 32768))
        Catch ex As Exception
            If YTextBox.Text = "" Then
                YTextBox.Text = "0"
            Else
                GeonameYTextBox.Text = "!"
            End If
        End Try
    End Sub

    Private Sub GeonameXTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GeonameXTextBox.TextChanged, GeonameYTextBox.TextChanged
        GeonameTextBox.Text = GeonameXTextBox.Text & "/" & GeonameYTextBox.Text
    End Sub

    Private Sub ImportLocButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportLocButton.Click
        Dim Locs(2) As String

        If ImportLocTextBox.Text = "" Then
            GoTo WrongType
        End If

        ImportLocTextBox.Text = ImportLocTextBox.Text.Replace(";", ",")
        Try
            Locs = ImportLocTextBox.Text.Split(CChar(","))
            If Locs.Length < 2 Then GoTo WrongType
            XTextBox.Text = Locs(0)
            YTextBox.Text = Locs(1)
        Catch ex As Exception
            GoTo WrongType
        End Try

        Exit Sub

WrongType:
        MessageBox.Show("Enter data is not valid. Enter data in format ""XXXX,YYYY,ZZZZ""", "Invalid data", MessageBoxButtons.OK)
        Exit Sub

    End Sub
End Class
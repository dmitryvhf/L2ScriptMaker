Public Class GeoIndexGen

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim GeoFiles() As String = {}
        Dim GeoFilesControl() As String = {}
        Dim iTemp As Integer

        FolderBrowserDialog.SelectedPath = System.Environment.CurrentDirectory
        FolderBrowserDialog.Description = "Select folder with geodata *.dat files"
        If FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            'GeoFolder = FolderBrowserDialog.SelectedPath
        End If

        GeoFiles = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.dat", IO.SearchOption.AllDirectories)
        If GeoFiles.Length < 1 Then
            MessageBox.Show("No Geofiles into this folder. Select correct folder", "No geodata", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim outGeoFile As New System.IO.StreamWriter(FolderBrowserDialog.SelectedPath & "\geo_index.txt", False, System.Text.Encoding.ASCII, 1)
        Dim GeoId As Integer
        outGeoFile.WriteLine(GeoFiles.Length)
        Array.Resize(GeoFilesControl, GeoFiles.Length)
        For iTemp = 0 To GeoFiles.Length - 1

            GeoId = Array.IndexOf(GeoFilesControl, System.IO.Path.GetFileName(GeoFiles(iTemp)))
            GeoFilesControl(iTemp) = System.IO.Path.GetFileName(GeoFiles(iTemp))
            If GeoId <> -1 And GeoId <> iTemp Then
                outGeoFile.Close()
                MessageBox.Show("Geodata " & GeoFilesControl(iTemp) & " already exist in geo_index. Remove duplicate geo and try again", "Duplicate geodata", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.IO.File.Delete(FolderBrowserDialog.SelectedPath & "\geo_index.txt")
                Exit Sub
            End If
            outGeoFile.WriteLine(GeoFiles(iTemp).Replace(FolderBrowserDialog.SelectedPath & "\", ""))
        Next

        outGeoFile.Close()
        MessageBox.Show("Generation complete.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub
End Class
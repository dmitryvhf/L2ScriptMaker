Public Class CheckUpdate

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sUrlBase As String = "http://dragon.ur.ru/l2sm/"
        'Dim sUrlBase As String = "http://server/l2sm/"
        Dim l2tempver As String = System.IO.Path.GetTempFileName
        Dim sVersion As String
        Dim sUrlFile As String

        If GetFileFromHttp(sUrlBase & "l2scriptmaker.txt", l2tempver) = False Then
            MessageBox.Show("Can't download version file from site.", "Can't read version", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        Dim VerRead As New System.IO.StreamReader(l2tempver, System.Text.Encoding.Default, True, 1)
        sVersion = VerRead.ReadLine
        sUrlFile = VerRead.ReadLine
        CheckStatLabel.Text = "Version detected: " & sVersion
        CheckStatLinkLabel.Text = VerRead.ReadLine

        VerRead.Close()
        System.IO.File.Delete(l2tempver)

        If Application.ProductVersion = sVersion Then
            If MessageBox.Show("You have lastest release" & vbNewLine & "Want to download again?", "No new", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        Else
            If MessageBox.Show("Found new build! " & sVersion & vbNewLine & "Want to download new?", "Found update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

        End If

        If GetFileFromHttp(sUrlBase & sUrlFile, sUrlFile) = False Then
            MessageBox.Show("Can't download file from site.", "Can't download", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        MessageBox.Show("Download new update success. Last build is " & sVersion & vbNewLine & "Note: close tool, extract new build from file " & sUrlFile & " in your tool folder", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

    Private Function GetFileFromHttp(ByVal FileUrl As String, ByVal FileDisk As String) As Boolean
        Dim fs As New System.Net.WebClient

        fs.Encoding = System.Text.Encoding.GetEncoding(1250)

        Dim CachePol As New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore)
        fs.CachePolicy = CachePol

        Try
            fs.DownloadFile(FileUrl, FileDisk)
        Catch ex As Exception
            If ex.Message = "The remote server returned an error: (404) Not Found." Then
                'MessageBox.Show("Error on Lineage II Update system. Report to support.")
                Return False
            End If
            'UpdStatus.Text = ex.Message
            MessageBox.Show(ex.Message)
            Return False
        End Try


        Return True
    End Function

    Private Sub SendMailButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMailButton.Click
        Try
            Dim Feedback As New System.Net.Mail.MailMessage(MailFromTextBox.Text, "hellfire@reborn.ru", SubjectTextBox.Text, TextBox.Text)
            Dim Mailclient As New System.Net.Mail.SmtpClient(MailSrvTextBox.Text)
            Mailclient.UseDefaultCredentials = True
            Mailclient.Send(Feedback)
            MessageBox.Show("Send complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As FormatException
            MessageBox.Show(ex.Message)
        Catch ex As System.Net.Mail.SmtpException
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub CheckStatLinkLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckStatLinkLabel.Click
        'Process.Start("iexplore.exe " & CheckStatLinkLabel.Text)
        Process.Start("iexplore.exe", CheckStatLinkLabel.Text)
    End Sub
End Class
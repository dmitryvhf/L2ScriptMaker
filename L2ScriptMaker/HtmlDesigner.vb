Public Class HtmlDesigner

    Private Sub ButtonLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoad.Click

        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)

        Dim sTemp As String
        sTemp = inFile.ReadToEnd
        inFile.Close()

        sTemp = sTemp.Replace(vbNewLine, "")
        sTemp = sTemp.Replace("<br>", vbNewLine & vbNewLine)
        sTemp = sTemp.Replace("<html>", "")
        sTemp = sTemp.Replace("</html>", "")
        sTemp = sTemp.Replace("<head>", "")
        sTemp = sTemp.Replace("<body>", "")
        sTemp = sTemp.Replace("</body>", "")

        TextBoxEdit.Text = sTemp

    End Sub

    Private Sub ButtonResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResult.Click
        'TextBoxEdit.Text = ""
        If TextBoxEdit.Text = "" Then Exit Sub

        Dim sTemp As String, sTempHtml As String

        sTemp = TextBoxEdit.Text

        ' Preparing. Maybe someone paste ready code to this window
        sTemp = sTemp.Replace("<br>", vbNewLine & vbNewLine)
        sTemp = sTemp.Replace("<html>", "")
        sTemp = sTemp.Replace("</html>", "")
        sTemp = sTemp.Replace("<head>", "")
        sTemp = sTemp.Replace("<body>", "")
        sTemp = sTemp.Replace("</body>", "")


        sTemp = sTemp.Replace(vbNewLine & vbNewLine, vbNewLine & vbNewLine & "<br>")
        sTemp = "<html><head><body>" & vbNewLine & sTemp & vbNewLine & "</body></html>"
        TextBoxResult.Text = sTemp

        sTemp = sTemp.Replace("<body>", "<body text=""#FFFFFF"" bgcolor=""#000000"">" & vbNewLine & "<font face=""Tahoma, Arial, Verdana, Helvetica, Sans-Serif"" size=""2"">")
        sTemp = sTemp.Replace("<a action=", "<a href=")
        sTemp = sTemp.Replace("<a href=", "<a target=""_blank"" href=")
        sTemp = sTemp.Replace(vbNewLine, "")
        sTemp = sTemp.Replace("<br>", vbNewLine & vbNewLine & "<br><br>")
        sTemp = sTemp.Replace("<font color=""LEVEL"">", "<font color=""FFFF33"">")
        sTempHtml = sTemp

        Dim outTempFile As New System.IO.StreamWriter("~temp.htm", False, System.Text.Encoding.Unicode, 1)
        outTempFile.Write(sTemp)
        outTempFile.Close()

        Dim sUrl As New Uri(System.Environment.CurrentDirectory & "\~temp.htm")
        WebBrowserPreview.Url = sUrl
        WebBrowserPreview.Show()

    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        If TextBoxResult.Text = "" Then Exit Sub

        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim outTempFile As New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Unicode, 1)
        outTempFile.Write(TextBoxResult.Text)
        outTempFile.Close()

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click

        If System.IO.File.Exists("~temp.htm") = True Then System.IO.File.Delete("~temp.htm")
        Me.Dispose()

    End Sub

    Private Sub ComboBoxShortCuts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxShortCuts.SelectedIndexChanged
        TextBoxEdit.AppendText(vbNewLine & ComboBoxShortCuts.Text)
    End Sub
End Class
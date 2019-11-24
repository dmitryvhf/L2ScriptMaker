Public Class HtmlButtonDesigner

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        ' check input params
        If WidthValue.Text = "" Then MessageBox.Show("No Width param", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        If HeightValue.Text = "" Then MessageBox.Show("No Height param", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        If BackValue.Text = "" Then MessageBox.Show("No Back param", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        If ForeValue.Text = "" Then MessageBox.Show("No Fore param", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

        ' - Select work directory -
        ProgressBar.Value = 0
        ScanFile.Text = ""
        Dim WorkDirName As String

        ' Select folder to work
        FolderBrowserDialog.Description = "Select where source html file's"
        If FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        WorkDirName = FolderBrowserDialog.SelectedPath

        If System.IO.Directory.Exists(WorkDirName + "\fixed_html") = False Then
            System.IO.Directory.CreateDirectory(WorkDirName + "\fixed_html")
        Else
            MessageBox.Show("Fixed folder already exist. Delete it or rename", "Exist output folder", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Read files list
        Dim FileList() As String
        FileList = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath + "\", "*.htm", IO.SearchOption.TopDirectoryOnly)
        If FileList.Length = 0 Then
            MessageBox.Show("Source directory empty!", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim ReadStr As String

        Dim TempFileNum As Integer
        Dim InLink As String

        For TempFileNum = 0 To FileList.Length - 1

            ScanFile.Text = System.IO.Path.GetFileName(FileList(TempFileNum))
            Me.Refresh()


TryAgain:
            Dim InFixFile As New System.IO.StreamReader(FileList(TempFileNum), System.Text.Encoding.Default, True, 1)
            ReadStr = InFixFile.ReadToEnd
            Dim FixStatus As Boolean = False

            While InStr(ReadStr, "<a action=") <> 0

                Dim Temp1 As Integer, Temp2 As Integer
                Temp1 = InStr(ReadStr, "<a action=")
                Temp2 = InStr(Temp1, ReadStr, "</a>") + 4
                If Temp2 < Temp1 Then
                    InFixFile.Close()
                    Shell("notepad.exe " + FileList(TempFileNum), AppWinStyle.NormalFocus)
                    MessageBox.Show("Fix file and press OK to try again")
                    GoTo TryAgain
                End If

                InLink = Mid(ReadStr, Temp1, Temp2 - Temp1)
                If StartTag.Text <> "" And EndTag.Text <> "" Then
                    ReadStr = Replace(ReadStr, InLink, StartTag.Text + ChgHtmlButStl(InLink) + EndTag.Text)
                Else
                    ReadStr = Replace(ReadStr, InLink, ChgHtmlButStl(InLink))
                End If
                FixStatus = True
            End While
            InFixFile.Close()

            If FixStatus = True Then
                Dim oExecFile As System.IO.Stream = New System.IO.FileStream(WorkDirName + "\fixed_html\" + System.IO.Path.GetFileName(FileList(TempFileNum)), _
                    IO.FileMode.Create, IO.FileAccess.Write)
                Dim outExecFile As System.IO.StreamWriter = New System.IO.StreamWriter(oExecFile, System.Text.Encoding.Unicode)
                outExecFile.Write(ReadStr)
                outExecFile.Flush()
                outExecFile.Close()
            End If

            ProgressBar.Value = CInt((TempFileNum + 1) * 100 / FileList.Length)

        Next

        ProgressBar.Value = 0
        ScanFile.Text = ""
        MessageBox.Show("Html directory now +" & FileList.Length & " enchant.")

    End Sub

    Function ChgHtmlButStl(ByVal InLink As String) As String

        Dim InStrArr(1) As String
        Dim Temp1 As Integer, Temp2 As Integer

        ' 1. link 
        Temp1 = InStr(InLink, "<a action=") + 11
        Temp2 = InStr(Temp1, InLink, Chr(34))
        InStrArr(0) = Mid(InLink, Temp1, Temp2 - Temp1)

        ' 2. link text
        Temp1 = Temp2 + 2
        Temp2 = InStr(Temp1, InLink, "</a>")
        InStrArr(1) = Mid(InLink, Temp1, Temp2 - Temp1)

        '  <button action="link hello.html" value="Hello Chat" width=200 height=50 back="background.jpg" fore="foreground.jpg">
        ChgHtmlButStl = "<button action=" + Chr(34) + InStrArr(0) + Chr(34) + " value=" + Chr(34) + InStrArr(1) + Chr(34) + " width=" + WidthValue.Text + " height=" + HeightValue.Text + " back=" + Chr(34) + BackValue.Text + Chr(34) + " fore=" + Chr(34) + ForeValue.Text + Chr(34) + ">"

    End Function

    Private Sub AboutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        MessageBox.Show("Tool for convert html to new C3 design. Idea by Virgi" _
        + vbNewLine + "Tool change standart button to button with user define style (size, background and etc). Example. This message in html file" _
        + vbNewLine _
        + vbNewLine + "<center><a action=" + Chr(34) + "bypass -h recipe?id=159" + Chr(34) + ">[Create]</a><br><br></center></body></html>" _
        + vbNewLine _
        + vbNewLine + "will be this after updating:" + vbNewLine _
        + vbNewLine + "<center><td><button action=" + Chr(34) + "bypass -h recipe?id=159" + Chr(34) + " value=" + Chr(34) + "[Create]" + Chr(34) + " width=111 height=222 back=" + Chr(34) + "L2UI_CH3.Btn1_normalOn" + Chr(34) + " fore=" + Chr(34) + "L2UI_CH3.Btn1_normal" + Chr(34) + "></td><br><br></center></body></html>" _
        + vbNewLine _
        + vbNewLine + "with using: width=111 height=222 back=L2UI_CH3.Btn1_normalOn fore=L2UI_CH3.Btn1_normal in tool dialog starttag=<td> endtag=</td>")

    End Sub
End Class

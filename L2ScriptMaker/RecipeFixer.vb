Public Class RecipeFixer

    ' recipe_begin	[mk_wooden_arrow]	1	level=1	material={{[stem];4};{[iron_ore];2}}	catalyst={}	product={{[wooden_arrow];500}}	npc_fee={{[rp_wooden_arrow];1};{[adena];200}}	mp_consume=30	success_rate=100	item_id=1666	recipe_end
    ' <a action="bypass -h recipe?id=464">[Create]</a>

    Private Sub StartFixButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartFixButton.Click

        ' - Select work directory -
        ProgressBar.Value = 0
        ScanFile.Text = ""

        Dim WorkDirName As String, RecipeFile As String
        ' temp string for file reading
        Dim ReadStr As String
        Dim RecipeId(1000, 1) As String
        Dim RecipeTempId() As String
        Dim TempFileNum As Integer = 0, RanGenId As Integer
        'Dim TempDupeId As Integer

        ' Define target file to fix
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II recipe config (recipe.txt)|recipe.txt"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            RecipeFile = OpenFileDialog.FileName
        End If
        Dim InRecFile As New System.IO.StreamReader(RecipeFile, System.Text.Encoding.Default, True, 1)
        Dim oExecFile As System.IO.Stream = New System.IO.FileStream(RecipeFile + ".fix", _
            IO.FileMode.Create, IO.FileAccess.Write)
        Dim outExecFile As System.IO.StreamWriter = New System.IO.StreamWriter(oExecFile, System.Text.Encoding.Unicode)

        While InRecFile.BaseStream.Position <> InRecFile.BaseStream.Length

            ReadStr = Replace(InRecFile.ReadLine, Chr(9), " ")
            While InStr(ReadStr, "  ") <> 0
                ReadStr = Replace(ReadStr, "  ", " ")
            End While

            If ReadStr <> "" Then
                RecipeTempId = ReadStr.Split(Chr(32))
                RecipeId(TempFileNum, 0) = RecipeTempId(2)
                TempFileNum += 1

                RanGenId = CInt(Rnd() * 10000000)
                RecipeTempId(2) = RanGenId.ToString
                RecipeId(TempFileNum, 1) = RanGenId.ToString

                outExecFile.WriteLine(Join(RecipeTempId, " ").ToString)

            End If

        End While

        InRecFile.Close()
        outExecFile.Close()

        ' Select folder to work
        FolderBrowserDialog.Description = "Select where source html file's"
        If FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        WorkDirName = FolderBrowserDialog.SelectedPath
        If System.IO.Directory.Exists(WorkDirName + "\fixed_recipe") = False Then
            System.IO.Directory.CreateDirectory(WorkDirName + "\fixed_recipe")
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

        Dim InLink As String

        For TempFileNum = 0 To FileList.Length - 1

            ScanFile.Text = System.IO.Path.GetFileName(FileList(TempFileNum))
            Me.Refresh()

            Dim InFixFile As New System.IO.StreamReader(FileList(TempFileNum), System.Text.Encoding.Default, True, 1)
            ReadStr = InFixFile.ReadToEnd
            Dim FixStatus As Boolean = False

            While InStr(ReadStr, "<a action=") <> 0
                InLink = Mid(ReadStr, InStr(ReadStr, "<a action="), InStr(ReadStr, "</a>") + 4 - InStr(ReadStr, "<a action="))
                ReadStr = Replace(ReadStr, InLink, ChgHtmlButStl(InLink))
                FixStatus = True
            End While
            InFixFile.Close()

            If FixStatus = True Then
                Dim oHtmlFile As System.IO.Stream = New System.IO.FileStream(WorkDirName + "\fixed_recipe\" + System.IO.Path.GetFileName(FileList(TempFileNum)), IO.FileMode.Create, IO.FileAccess.Write)
                Dim outHtmlFile As System.IO.StreamWriter = New System.IO.StreamWriter(oHtmlFile, System.Text.Encoding.Unicode)

                outHtmlFile.Write(ReadStr)
                outHtmlFile.Flush()
                outHtmlFile.Close()
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
        'ChgHtmlButStl = "<button action=" + Chr(34) + InStrArr(0) + Chr(34) + " value=" + Chr(34) + InStrArr(1) + Chr(34) + " width=" + WidthValue.Text + " height=" + HeightValue.Text + " back=" + Chr(34) + BackValue.Text + Chr(34) + " fore=" + Chr(34) + ForeValue.Text + Chr(34) + ">"
        ChgHtmlButStl = "111111111111111111111"

    End Function

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub
End Class
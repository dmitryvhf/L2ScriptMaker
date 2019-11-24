Public Class ItemInjector
    'Dim TabSymbol As String = Chr(9)

    Private Sub Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quit.Click
        Me.Close()
    End Sub

    Private Sub AiInjector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SourceFile.Text = ""
        TargetFile.Text = ""
    End Sub


    Private Sub SplitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitButton.Click

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            SourceFile.Text = OpenFileDialog.FileName
        End If

        ' Select folder to work
        If FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim str() As String
        str = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.*", IO.SearchOption.AllDirectories)
        If str.Length <> 0 And OverwriteBox.Checked = False Then
            If MessageBox.Show("Source directory no empty! Continue?", "No empty directory", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        TargetFile.Text = FolderBrowserDialog.SelectedPath

        ' Initialization
        ProgressBar.Value = 0
        Dim inFile As New System.IO.StreamReader(SourceFile.Text, System.Text.Encoding.Default, True, 1)

        Dim ReadStr As String
        Dim ReadSplitStr() As String
        Dim FileName, FileDirName As String

        Do While inFile.BaseStream.Position <> inFile.BaseStream.Length

            ReadStr = Replace(inFile.ReadLine, Chr(9), Chr(32))

            ' tabs and spaces correction
            While InStr(ReadStr, "  ") <> 0
                ReadStr = Replace(ReadStr, "  ", Chr(32))
            End While

            ' fix for comments and empty string in itemdata
            If ReadStr.Length = Nothing Then GoTo nextitem
            If Mid(ReadStr, 1, 2) = "//" Then GoTo nextitem

            ReadSplitStr = ReadStr.Split(Chr(32))

            StatusBox.Text = "Please wait... Split item: " & ReadSplitStr(3)
            Me.Refresh()

            Select Case ReadSplitStr(0)
                Case "item_begin"
                    ' error symbols correction
                    ReadSplitStr(3) = Replace(ReadSplitStr(3), ":", "_")
                    ReadSplitStr(3) = Replace(ReadSplitStr(3), "*", "_")
                    ReadSplitStr(3) = Mid(ReadSplitStr(3), 2, Len(ReadSplitStr(3)) - 2)

                    ReadSplitStr(2) = ReadSplitStr(2).PadLeft(5, CChar("0"))

                    FileDirName = FolderBrowserDialog.SelectedPath + "\item_begin\" + ReadSplitStr(2) + "-" + ReadSplitStr(3)
                    FileName = ReadSplitStr(2) + "-" + ReadSplitStr(3) + ".txt"

                Case "set_begin"

                    ReadSplitStr(1) = ReadSplitStr(1).PadLeft(5, CChar("0"))
                    FileDirName = FolderBrowserDialog.SelectedPath + "\set_begin\" + ReadSplitStr(1)
                    FileName = ReadSplitStr(1) + ".txt"

                Case Else
                    MessageBox.Show("Unknown/bad file format for :" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & ReadStr, "Unknown/bad file format", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Do
            End Select

            'FileDirName = FileDirName + "\" + ReadSplitStr(2) + "-" + ReadSplitStr(3) + "\" + ReadSplitStr(2) + "-" + ReadSplitStr(3) + ".txt"
            System.IO.Directory.CreateDirectory(FileDirName)

            Dim oAiFile As System.IO.Stream = New System.IO.FileStream(FileDirName + "\" + FileName, _
                IO.FileMode.Create, IO.FileAccess.Write)
            Dim outAiData As System.IO.StreamWriter = New System.IO.StreamWriter(oAiFile, _
                    System.Text.Encoding.Unicode, 1)

            ' == ART Correction ==
            SymbolCorrection(ReadStr)
            ReadStr = Replace(ReadStr, " = ", "=")
            ReadStr = Replace(ReadStr, Chr(32), Chr(9))

            outAiData.WriteLine(ReadStr)
            outAiData.Close()
nextitem:

            ProgressBar.Value = CInt(inFile.BaseStream.Position * 100 / inFile.BaseStream.Length)
        Loop

        StatusBox.Text = "Splitting done."
        ProgressBar.Value = 0
        inFile.Close()

    End Sub

    Private Sub MergeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MergeButton.Click

        Dim WorkDirName As String

        ' Select folder to work
        FolderBrowserDialog.Description = "Select where source file's with item/npc"
        If FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        SourceFile.Text = FolderBrowserDialog.SelectedPath
        WorkDirName = FolderBrowserDialog.SelectedPath

        ' check file exist
        If System.IO.File.Exists(FolderBrowserDialog.SelectedPath + "\itemdata.txt") = True Then
            If MessageBox.Show("File exist in directory. Continue and overwrite?", "File exist", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                System.IO.File.Copy(FolderBrowserDialog.SelectedPath + "\itemdata.txt", FolderBrowserDialog.SelectedPath + "\itemdata.txt.bak", True)
            End If
        End If
        TargetFile.Text = FolderBrowserDialog.SelectedPath + "\itemdata.txt"

        Dim oFile As System.IO.Stream = New System.IO.FileStream(FolderBrowserDialog.SelectedPath + "\itemdata.txt", _
            IO.FileMode.Create, IO.FileAccess.Write)
        Dim outData As System.IO.StreamWriter = New System.IO.StreamWriter(oFile, _
                System.Text.Encoding.Unicode, 1)

        Dim TempFileNum As Integer
        Dim FileList() As String

        FileList = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath + "\item_begin", "*.*", IO.SearchOption.AllDirectories)
        If FileList.Length = 0 Then
            MessageBox.Show("Source directory empty!", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        For TempFileNum = (FileList.Length - 1) To 0 Step -1

            StatusBox.Text = "Merging file: " & System.IO.Path.GetFileName(FileList(TempFileNum))
            Me.Refresh()

            Dim inFile As New System.IO.StreamReader(FileList(TempFileNum), System.Text.Encoding.Default, True, 1)

            ' == ART Correction ==
            Dim ReadStr As String
            ReadStr = inFile.ReadLine
            SymbolCorrection(ReadStr)
            ReadStr = Replace(ReadStr, " = ", "=")
            ReadStr = Replace(ReadStr, Chr(32), Chr(9))

            outData.WriteLine(ReadStr)
            inFile.Close()

            ProgressBar.Value = CInt(TempFileNum * 100 / FileList.Length)
        Next


        ' ====== Set begin =========
        FileList = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath + "\set_begin", "*.*", IO.SearchOption.AllDirectories)
        If FileList.Length = 0 Then
            MessageBox.Show("Source directory empty!", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        For TempFileNum = (FileList.Length - 1) To 0 Step -1

            StatusBox.Text = "Merging file: " & FileList(TempFileNum)
            Me.Refresh()

            Dim inFile As New System.IO.StreamReader(FileList(TempFileNum), System.Text.Encoding.Default, True, 1)
            outData.WriteLine(inFile.ReadLine)
            inFile.Close()

            ProgressBar.Value = CInt(TempFileNum * 100 / FileList.Length)
        Next


        outData.Close()
        ProgressBar.Value = 0
        StatusBox.Text = "Merging done."

    End Sub

    Private Sub Inject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inject.Click

        ' Define fix file
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II item fix file (*.txt)|*.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            SourceFile.Text = OpenFileDialog.FileName
        End If

        ' Define target file to fix
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II itemdata config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            TargetFile.Text = OpenFileDialog.FileName
        End If

        Dim InjectStatus As Byte = 0
        Dim WorkDataDir As String = System.IO.Path.GetDirectoryName(SourceFile.Text)
        Dim SrcFile As String = SourceFile.Text
        Dim TarFile As String = TargetFile.Text

        ' fix from
        Dim inSrcFile As New System.IO.StreamReader(SrcFile, System.Text.Encoding.Default, True, 1)
        ' fix to 
        System.IO.File.Copy(TarFile, TarFile + ".bak", True)
        Dim inTarFile As New System.IO.StreamReader(TarFile + ".bak", System.Text.Encoding.Default, True, 1)

        Dim oTarFile As System.IO.Stream = New System.IO.FileStream(TarFile, _
                IO.FileMode.Create, IO.FileAccess.Write)
        Dim outTarData As System.IO.StreamWriter = New System.IO.StreamWriter(oTarFile, _
                System.Text.Encoding.Unicode)

        StatusBox.Text = "Finding string to fix..."
        Me.Refresh()

        Dim TempFixStr As String
        Dim SrcID() As String
        Dim TempStr As String
        Dim TarID() As String

        TempFixStr = Replace(inSrcFile.ReadLine, Chr(9), " ")
        If Mid(TempFixStr, 1, 9) = "set_begin" Then
            MessageBox.Show("Injection for Set item no supported. Use Merge", "Set no support", MessageBoxButtons.OK, MessageBoxIcon.Error)
            inSrcFile.Close()
            inTarFile.Close()
            outTarData.Close()
            Exit Sub
        End If
        ' tabs and spaces correction
        While InStr(TempFixStr, "  ") <> 0
            TempFixStr = Replace(TempFixStr, "  ", " ")
        End While
        SrcID = TempFixStr.Split(Chr(32))

        Do While (inTarFile.BaseStream.Position <> inTarFile.BaseStream.Length)

            TempStr = Replace(inTarFile.ReadLine, Chr(9), " ")
            ' tabs and spaces correction
            While InStr(TempStr, "  ") <> 0
                TempStr = Replace(TempStr, "  ", " ")
            End While
            TarID = TempStr.Split(Chr(32))

            If SrcID(2) = TarID(2) Then

                If TempFixStr = TempStr Then
                    ' nothing
                    outTarData.WriteLine(Replace(TempStr, " ", Chr(9)))
                Else
                    If MessageBox.Show("Different item define. ID is: " & TarID(2) _
                    & Chr(13) & Chr(10) & "Original string :" & Chr(13) & Chr(10) & TempStr _
                    & Chr(13) & Chr(10) & "New string :" & Chr(13) & Chr(10) & TempFixStr _
                    & Chr(13) & Chr(10) & "Write new fix?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                        outTarData.WriteLine(Replace(TempStr, " ", Chr(9)))
                        InjectStatus = 3
                    Else
                        outTarData.WriteLine(Replace(TempFixStr, " ", Chr(9)))
                        InjectStatus = 1
                        outTarData.WriteLine(inTarFile.ReadToEnd())
                    End If

                End If

            Else
                outTarData.WriteLine(Replace(TempStr, " ", Chr(9)))
            End If

            ProgressBar.Value = CInt(inTarFile.BaseStream.Position * 100 / inTarFile.BaseStream.Length)
        Loop

        If InjectStatus = 0 Then
            outTarData.WriteLine(Replace(TempFixStr, " ", Chr(9)))
            InjectStatus = 2
        End If

        inSrcFile.Close()
        inTarFile.Close()
        outTarData.Close()

        StatusBox.Text = "Injection done..."
        ProgressBar.Value = 0

        Select Case InjectStatus
            Case 0
                MessageBox.Show("Big error. Send me your file to test", "Nothing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case 1
                MessageBox.Show("Injection done. Fix integrity to file. Old code has been replaced", "Old code replaced", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case 2
                MessageBox.Show("Injection done. Fix integrity to file. New code has been added", "New code added", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case 3
                MessageBox.Show("Injection done. Nothing changed", "Nothing changed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Select

    End Sub

    Function SymbolCorrection(ByVal SourceStr As String) As String
        ' tabs and spaces correction
        While InStr(SourceStr, "  ") <> 0
            SourceStr = Replace(SourceStr, "  ", " ")
        End While
        Return SourceStr
    End Function

End Class
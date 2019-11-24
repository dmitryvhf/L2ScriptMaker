Public Class SkillInjector

    'Dim TabSymbol As String = " "
    'Dim TabSymbol As String = Chr(9)

    Private Sub Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quit.Click
        Me.Close()
    End Sub

    Private Sub AiInjector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SourceFile.Text = ""
        TargetFile.Text = ""
    End Sub

    Private Sub Inject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inject.Click

        'MessageBox.Show("Please, use Merge function for it", "Use Merge", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Exit Sub

        Dim inFile As System.IO.StreamReader
        Dim inInjectFile As System.IO.StreamReader = Nothing
        Dim outFile As System.IO.StreamWriter
        Dim outLogFile As System.IO.StreamWriter

        Dim sTemp As String
        Dim iTemp As Integer

        Dim iInjectValue As Integer = -1
        Dim aInject1(0) As Integer  ' skill id
        Dim aInject2(0) As Boolean ' skill file name

        Dim sSkillData As String
        Dim sSkillInjectData As String
        'Dim sTempFolder As String

        'FolderBrowserDialog.SelectedPath = System.Environment.CurrentDirectory

        OpenFileDialog.InitialDirectory = System.Environment.CurrentDirectory

        StatusBox.Text = "Definition for working objects..."
        OpenFileDialog.Filter = "Lineage II Skill Config (skilldata.txt)|skilldata*.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sSkillData = OpenFileDialog.FileName

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II inject skills file (.txt)|*.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sSkillInjectData = OpenFileDialog.FileName

        If System.IO.Directory.Exists("~l2smtemp") Then System.IO.Directory.Delete("~l2smtemp", True)
        System.IO.Directory.CreateDirectory("~l2smtemp")

        outLogFile = New System.IO.StreamWriter("l2scriptmaker_skillinjector.log", True, System.Text.Encoding.Unicode, 1)
        outLogFile.WriteLine("L2ScriptMaker: SkillData Injector module")
        outLogFile.WriteLine(Now & " Start" & vbNewLine)

        outLogFile.WriteLine("Fixed file :" & vbTab & sSkillData)
        outLogFile.WriteLine("Inject file:" & vbTab & sSkillInjectData)

        ' START: UPLOAD Inject skills to file's
        inFile = New System.IO.StreamReader(sSkillInjectData, System.Text.Encoding.Default, True, 1)
        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        StatusBox.Text = "Loading and preparing inject file..."
        Me.Update()

        outLogFile.WriteLine()

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            ProgressBar.Value = CInt(inFile.BaseStream.Position)

            If sTemp <> "" And sTemp.StartsWith("//") = False Then
                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "skill_id"))
                If CInt(Libraries.GetNeedParamFromStr(sTemp, "level")) = 1 And System.IO.File.Exists("~l2smtemp\" & Libraries.GetNeedParamFromStr(sTemp, "skill_id") & ".txt") = True Then
                    outLogFile.WriteLine("[ATTENTION] Skill ID: " & iTemp & vbTab & "name=" & Libraries.GetNeedParamFromStr(sTemp, "skill_name") & vbTab)
                    MessageBox.Show("Inject skill already exist. Skill: " & Libraries.GetNeedParamFromStr(sTemp, "skill_id") & ":" & Libraries.GetNeedParamFromStr(sTemp, "skill_name") & vbNewLine & "Continue loading?", "Inject exist", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ProgressBar.Value = 0
                    StatusBox.Text = "Aborted..."
                    If System.IO.Directory.Exists("~l2smtemp") Then System.IO.Directory.Delete("~l2smtemp", True)
                    inFile.Close()
                    outLogFile.WriteLine(vbNewLine & "Aborted" & vbNewLine & Now & " End" & vbNewLine)
                    outLogFile.Close()
                    Exit Sub

                End If

                outFile = New System.IO.StreamWriter("~l2smtemp\" & Libraries.GetNeedParamFromStr(sTemp, "skill_id") & ".txt", True, System.Text.Encoding.Unicode, 1)
                outFile.WriteLine(sTemp)
                outFile.Close()

                If Array.IndexOf(aInject1, iTemp) = -1 Then
                    iInjectValue = iInjectValue + 1
                    If aInject1.Length <= iInjectValue Then
                        Array.Resize(aInject1, iInjectValue + 1)
                        Array.Resize(aInject2, iInjectValue + 1)
                    End If
                    aInject1(iInjectValue) = iTemp
                    aInject2(iInjectValue) = False
                End If

            End If

        End While
        inFile.Close()
        ProgressBar.Value = 0
        ' END: UPLOAD Inject skills to file

        ' START2: INJECT skills to SkillData
        System.IO.File.Copy(sSkillData, sSkillData & ".bak", True)
        'inFile = New System.IO.StreamReader(sSkillData, System.Text.Encoding.Default, True, 1)
        inFile = New System.IO.StreamReader(sSkillData & ".bak", System.Text.Encoding.Default, True, 1)
        outFile = New System.IO.StreamWriter(sSkillData, False, System.Text.Encoding.Unicode, 1)

        outLogFile.WriteLine()

        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        StatusBox.Text = "Inject skills to skilldata file..."
        Me.Update()

        Dim iLastFixSkill As Integer

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            ProgressBar.Value = CInt(inFile.BaseStream.Position)

            If sTemp <> "" And sTemp.StartsWith("//") = False Then
                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "skill_id"))
                If Array.IndexOf(aInject1, iTemp) <> -1 Then

                    If iLastFixSkill <> iTemp Then

                        outLogFile.WriteLine("[UPDATED  ] Skill ID: " & iTemp & vbTab & "name=" & Libraries.GetNeedParamFromStr(sTemp, "skill_name"))

                        inInjectFile = New System.IO.StreamReader("~l2smtemp\" & iTemp & ".txt", System.Text.Encoding.Default, True, 1)
                        sTemp = inInjectFile.ReadToEnd.Trim
                        outFile.WriteLine(sTemp)
                        sTemp = ""
                        inInjectFile.Close()

                        ' DUMMY Cycle
                        iLastFixSkill = iTemp
                        aInject2(Array.IndexOf(aInject1, iTemp)) = True
                    Else
                        sTemp = ""
                    End If
                End If
            End If
            If sTemp <> "" Then outFile.WriteLine(sTemp)

        End While
        ProgressBar.Value = 0
        inFile.Close()
        ' END2: INJECT skills to SkillData

        ' START3: Uploading left injections
        StatusBox.Text = "Inject New skills to skilldata file..."
        Me.Update()
        If CheckBoxWriteNew.Checked = True Then

            iTemp = Array.IndexOf(aInject2, False)
            While iTemp <> -1
                inInjectFile = New System.IO.StreamReader("~l2smtemp\" & aInject1(iTemp) & ".txt", System.Text.Encoding.Default, True, 1)
                sTemp = inInjectFile.ReadToEnd.Trim
                outFile.WriteLine(sTemp)

                outLogFile.WriteLine("[ADDED    ] Skill ID: " & aInject1(iTemp) & vbTab & "name=" & Libraries.GetNeedParamFromStr(sTemp, "skill_name"))

                sTemp = ""
                inInjectFile.Close()
                aInject2(iTemp) = True

                iTemp = Array.IndexOf(aInject2, False)

            End While

        End If
        ' END3: Uploading left injections

        outFile.Close()
        outLogFile.WriteLine(vbNewLine & Now & " End" & vbNewLine)
        outLogFile.Close()

        If System.IO.Directory.Exists("~l2smtemp") Then System.IO.Directory.Delete("~l2smtemp", True)

        StatusBox.Text = "Done."
        MessageBox.Show("Done.")



    End Sub

    Private Sub SplitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitButton.Click

        ' Define file
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II config (skilldata.txt)|skilldata.txt|All files (*.*)|*.*"
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
        Dim Digit() As Char = {CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("6"), CChar("7"), CChar("8"), CChar("9"), CChar("0")}
        'Dim DigitPos As Integer
        Dim FileName, FileDirName As String
        Dim SkillName, SkillLvl, SkillID As String

        Do While inFile.BaseStream.Position <> inFile.BaseStream.Length

            ReadStr = SymbolCorrection(Replace(inFile.ReadLine, Chr(9), " "))
            ' SkillData or not
            If Mid(ReadStr, 1, 11) <> "skill_begin" Then
                MessageBox.Show("File format is not npcdata. Invalid record is: " & Chr(13) _
                & Chr(13) & ReadStr, "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            SkillName = GetNeedParamFromStr(ReadStr, "skill_name")
            SkillName = Mid(SkillName, 2, Len(SkillName) - 2)
            SkillID = GetNeedParamFromStr(ReadStr, "skill_id")
            SkillLvl = GetNeedParamFromStr(ReadStr, "level")

            SkillID = SkillID.PadLeft(4, CChar("0"))

            If SkillName.IndexOfAny(Digit, Len(SkillName) - 3) > 0 Then
                SkillName = Mid(SkillName, 1, SkillName.IndexOfAny(Digit, Len(SkillName) - 3))
            End If
            FileName = SkillID + "-" + SkillName + ".txt"

            FileDirName = FolderBrowserDialog.SelectedPath + "\skill_begin\" + SkillID + "-" + SkillName


            StatusBox.Text = "Please wait... Split skill: " & SkillName
            Me.Refresh()

            ' == ART Correction ==
            ReadStr = SymbolCorrection(ReadStr)
            ReadStr = Replace(ReadStr, " = ", "=")
            ReadStr = Replace(ReadStr, Chr(32), Chr(9))

            Dim TempRemPos As Integer = InStr(ReadStr, "/*")
            Dim Temp1 As String
            Do While TempRemPos <> 0
                Temp1 = Mid(ReadStr, TempRemPos, InStr(TempRemPos, ReadStr, "*/") - TempRemPos + 2)
                ReadStr = Replace(ReadStr, Temp1, Replace(Temp1, Chr(9), Chr(32)))
                TempRemPos = InStr(TempRemPos + 1, ReadStr, "/*")
            Loop


            ' If last Skill or not?
            If System.IO.Directory.Exists(FileDirName) = False Then
                System.IO.Directory.CreateDirectory(FileDirName)
                Dim oAiFile As System.IO.Stream = New System.IO.FileStream(FileDirName + "\" + FileName, _
                    IO.FileMode.Create)
                Dim outAiData As System.IO.StreamWriter = New System.IO.StreamWriter(oAiFile, _
                        System.Text.Encoding.Unicode, 1)
                outAiData.WriteLine(ReadStr)
                outAiData.Close()
            Else
                Dim oAiFile As System.IO.Stream = New System.IO.FileStream(FileDirName + "\" + FileName, _
                    IO.FileMode.Append, IO.FileAccess.Write)
                Dim outAiData As System.IO.StreamWriter = New System.IO.StreamWriter(oAiFile, _
                        System.Text.Encoding.Unicode, 1)
                outAiData.WriteLine(ReadStr)
                outAiData.Close()
            End If

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
        If System.IO.File.Exists(FolderBrowserDialog.SelectedPath + "\skilldata.txt") = True Then
            If MessageBox.Show("File skilldata.txt exist in directory. Continue and overwrite?", "File exist", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                System.IO.File.Copy(FolderBrowserDialog.SelectedPath + "\skilldata.txt", FolderBrowserDialog.SelectedPath + "\skilldata.txt.bak", True)
            End If
        End If
        TargetFile.Text = FolderBrowserDialog.SelectedPath + "\skilldata.txt"

        Dim oFile As System.IO.Stream = New System.IO.FileStream(FolderBrowserDialog.SelectedPath + "\skilldata.txt", _
            IO.FileMode.Create, IO.FileAccess.Write)
        Dim outData As System.IO.StreamWriter = New System.IO.StreamWriter(oFile, _
                System.Text.Encoding.Unicode, 1)

        Dim TempFileNum As Integer
        Dim FileList() As String

        ' Dim TempFileList() As String

        FileList = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath + "\skill_begin", "*.*", IO.SearchOption.AllDirectories)
        If FileList.Length = 0 Then
            MessageBox.Show("Source directory empty!", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim TempStr As String
        For TempFileNum = (FileList.Length - 1) To 0 Step -1

            StatusBox.Text = "Merging file: " & System.IO.Path.GetFileName(FileList(TempFileNum))
            Me.Refresh()

            Dim inFile As New System.IO.StreamReader(FileList(TempFileNum), System.Text.Encoding.Default, True, 1)
            Do While inFile.BaseStream.Position <> inFile.BaseStream.Length
                TempStr = inFile.ReadLine

                ' == ART Correction ==
                TempStr = SymbolCorrection(TempStr)
                TempStr = Replace(TempStr, " = ", "=")
                TempStr = Replace(TempStr, Chr(32), Chr(9))

                Dim TempRemPos As Integer = InStr(TempStr, "/*")
                Dim Temp1 As String
                Do While TempRemPos <> 0
                    Temp1 = Mid(TempStr, TempRemPos, InStr(TempRemPos, TempStr, "*/") - TempRemPos + 2)
                    TempStr = Replace(TempStr, Temp1, Replace(Temp1, Chr(9), Chr(32)))
                    TempRemPos = InStr(TempRemPos + 1, TempStr, "/*")
                Loop

                If TempStr <> "" Then
                    outData.WriteLine(TempStr)
                End If
            Loop
            inFile.Close()

            ProgressBar.Value = CInt(TempFileNum * 100 / FileList.Length)
        Next

        outData.Close()
        ProgressBar.Value = 0
        StatusBox.Text = "Merging done."

    End Sub

    Function GetNeedParamFromStr(ByVal SourceStr As String, ByVal MaskStr As String) As String

        'Update 15.01.2007 00:05

        Dim FirstPos, SecondPos As Integer
        GetNeedParamFromStr = ""

        ' PreWorking string
        SourceStr = SourceStr.Replace(Chr(9), " ")
        SourceStr = SourceStr.Replace(" = ", "=")
        While InStr(SourceStr, "  ") > 0
            SourceStr = SourceStr.Replace("  ", " ")
        End While

        FirstPos = InStr(1, SourceStr, MaskStr + "=")
        If FirstPos = Nothing Then
            GetNeedParamFromStr = ""
            Exit Function
        End If
        FirstPos += MaskStr.Length
        SecondPos = FirstPos + 1
        SecondPos = InStr(SecondPos, SourceStr, " ")
        If SecondPos = 0 Then SecondPos = SourceStr.Length

        GetNeedParamFromStr = Trim(Mid(SourceStr, FirstPos + 1, SecondPos - FirstPos))

    End Function

    Function SymbolCorrection(ByVal SourceStr As String) As String
        ' tabs and spaces correction
        While InStr(SourceStr, "  ") <> 0
            SourceStr = Replace(SourceStr, "  ", " ")
        End While
        Return SourceStr
    End Function

End Class
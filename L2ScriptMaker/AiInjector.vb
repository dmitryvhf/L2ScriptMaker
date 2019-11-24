Public Class AiInjector


    Private Sub Inject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inject.Click

        ' Define Ai.obj file
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II AI config (ai.obj)|*.obj|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            AiFile.Text = OpenFileDialog.FileName
        End If

        'Dim AIFixDataDir As String = FolderBrowserDialog.SelectedPath
        Dim AIFixDataDir As String
        'Dim AIFixFiles() As String = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.txt")
        Dim AIFixFiles(0) As String

        ' Define fix file
        If FixOneClassBox.Checked = False Then
            FolderBrowserDialog.SelectedPath = System.IO.Path.GetDirectoryName(AiFile.Text)
            FolderBrowserDialog.Description = "Select folder with AI.obj fixes (requiered .txt files)"
            If FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                FixFile.Text = FolderBrowserDialog.SelectedPath
            End If
            AIFixFiles = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.txt", IO.SearchOption.AllDirectories)
            AIFixDataDir = FolderBrowserDialog.SelectedPath

        Else
            OpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(AiFile.Text)
            OpenFileDialog.Tag = "Select folder with AI.obj fixes (requiered .txt files)"
            OpenFileDialog.Filter = "Ai.obj fixed class file (*.txt)|*.txt|All files|*.*"
            If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                FixFile.Text = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName)
            End If
            AIFixFiles(0) = OpenFileDialog.FileName
            AIFixDataDir = FixFile.Text

        End If
        Dim AIDataDir As String = System.IO.Path.GetDirectoryName(AiFile.Text)
        Dim AIObjFile As String = AiFile.Text
        Dim AIFixClasses(AIFixFiles.Length - 1) As String

        Dim InjectStatus As Byte = 0
        Dim TempStr, NpcName(4) As String
        Dim iTemp As Integer

        Dim inFixFile As System.IO.StreamReader
        ' Checking fix files on valid
        For iTemp = 0 To AIFixFiles.Length - 1

            inFixFile = New System.IO.StreamReader(AIFixFiles(iTemp), System.Text.Encoding.Default, True, 1)

            TempStr = inFixFile.ReadLine
            If TempStr.StartsWith("class ") = False Then
                MessageBox.Show("File '" + System.IO.Path.GetFileName(AIFixFiles(iTemp)) + "' is not AI class", "File is not fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
                inFixFile.Close()
                Exit Sub
            End If
            NpcName = TempStr.Split(Chr(32))
            AIFixClasses(iTemp) = NpcName(2)

            inFixFile.Close()
        Next

        System.IO.File.Copy(AiFile.Text, AIDataDir & "\" & System.IO.Path.GetFileNameWithoutExtension(AiFile.Text) + ".bak", True)
        Dim inAiFile As New System.IO.StreamReader(AIDataDir & "\" & System.IO.Path.GetFileNameWithoutExtension(AiFile.Text) + ".bak", System.Text.Encoding.Default, True, 1)
        Dim oAiFile As New System.IO.FileStream(AiFile.Text, IO.FileMode.Create, IO.FileAccess.Write)
        Dim outAiData As New System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode)
        Dim oAiLogData As New System.IO.StreamWriter(AIDataDir & "\" & System.IO.Path.GetFileNameWithoutExtension(AiFile.Text) + ".log", True, System.Text.Encoding.Unicode, 1)

        oAiLogData.WriteLine("--------------------------------------------" + vbNewLine + _
                                "L2ScriptMaker AI.obj Injector check and fix.")
        oAiLogData.WriteLine("Start at :" + Now.ToString + vbNewLine)

        Dim TempInAiStr As String
        ProgressBar.Maximum = CInt(inAiFile.BaseStream.Length)
        ProgressBar.Value = 0


        Do While inAiFile.EndOfStream <> True '(inAiFile.BaseStream.Position > inAiFile.BaseStream.Length)

            TempStr = inAiFile.ReadLine

            ' Enter to class
            If TempStr.StartsWith("class ") = True Then

                ' Checking for available fix
                NpcName = TempStr.Split(Chr(32))
                iTemp = Array.IndexOf(AIFixClasses, NpcName(2))
                If iTemp <> -1 Then

                    StatusBox.Text = "Injection..."

                    inFixFile = New System.IO.StreamReader(AIFixFiles(iTemp), System.Text.Encoding.Default, True, 1)
                    TempInAiStr = inFixFile.ReadLine
                    InjectStatus = 1

                    If TempStr <> TempInAiStr Then
                        ' If name correct but class different
                        If MessageBox.Show("Found different description for class in old file:" _
                            & Chr(13) & Chr(10) & TempStr & Chr(13) & Chr(10) & "new ai:" _
                            & Chr(13) & Chr(10) & TempInAiStr, "Different description" _
                            & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "Write new ai?", _
                            MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then

                            InjectStatus = 0
                        End If
                    End If

                    ' Main Injection
                    If InjectStatus = 1 Then
                        StatusBox.Text = "Fixing in " + System.IO.Path.GetFileNameWithoutExtension(AIFixClasses(iTemp) + "...")
                        outAiData.WriteLine(TempInAiStr)
                        outAiData.Write(inFixFile.ReadToEnd)
                        oAiLogData.WriteLine("Fixing class: " + NpcName(2))
                    Else

                    End If

                    ' find end of fixed class
                    Do
                        TempStr = inAiFile.ReadLine
                        If InjectStatus = 0 Then
                            outAiData.WriteLine(TempStr)
                        End If
                    Loop While TempStr.StartsWith("class_end") = False

                    AIFixClasses(iTemp) = ""

                Else
                    outAiData.WriteLine(TempStr)
                End If

                InjectStatus = 0
                StatusBox.Text = "Check for new updates..."

            Else
                outAiData.WriteLine(TempStr)
            End If

            ProgressBar.Value = CInt(inAiFile.BaseStream.Position)
            Me.Update()
        Loop
        outAiData.WriteLine()

        ' Append new AI if exist
        StatusBox.Text = "Checking for available new classes to append."
        For iTemp = 0 To AIFixClasses.Length - 1
            If AIFixClasses(iTemp) <> "" Then
                ' Last class crack fix
                inFixFile = New System.IO.StreamReader(AIFixFiles(iTemp), System.Text.Encoding.Default, True, 1)
                outAiData.WriteLine(inFixFile.ReadToEnd)
                outAiData.WriteLine()
                inFixFile.Close()
                oAiLogData.WriteLine("Add new class :" + System.IO.Path.GetFileNameWithoutExtension(AIFixClasses(iTemp)))
            End If
        Next

        oAiLogData.WriteLine(vbNewLine + "End at :" + Now.ToString + vbNewLine)
        ProgressBar.Value = 0
        StatusBox.Text = "Done."
        MessageBox.Show("Work complete. Read log file for full information.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        inAiFile.Close()
        outAiData.Close()
        oAiLogData.Close()

    End Sub

    Private Sub SplitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitButton.Click

        Dim sPath As String
        FolderBrowserDialog.SelectedPath = Application.StartupPath
        FolderBrowserDialog.Tag = "Select empty folder for data uploading"
        StatusBox.Text = "Select emptry folder for data uploading"
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sPath = FolderBrowserDialog.SelectedPath

        Dim aTemp() As String
        aTemp = System.IO.Directory.GetFiles(sPath)
        If aTemp.Length > 0 Then
            MessageBox.Show("Folder not empty. Select different folder or clean directory and try again", "Folder not empty", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II Server Intelligence file (ai.obj)|ai.obj|All files|*.*"
        StatusBox.Text = "Select AI.obj file"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        StatusBox.Text = "Start uploading classes to folder tree"
        If SplitClassTextBox.Text <> "" And CheckBoxUseList.Enabled = False Then
            StatusBox.Text = "Searching class '" & SplitClassTextBox.Text & "' for uploading to file..."
        ElseIf CheckedListBox.CheckedItems.Count > 0 And CheckBoxUseList.Enabled = True Then
            StatusBox.Text = "Searching classes for uploading to file..."
            SplitClassTextBox.Text = ""
        Else
            MessageBox.Show("Nothing to uploading...")
            Exit Sub
        End If

        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        Dim outFile As System.IO.StreamWriter
        Dim sTemp As String
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine

            If sTemp.StartsWith("class ") = True Then
                ' Founded class definition
                'class(0) 1(1) default_npc(2) :() (null)(3)
                aTemp = sTemp.Replace(": ", "").Split(Chr(32))

                If (SplitClassTextBox.Text = "" And CheckBoxUseList.Enabled = False) Or _
                (SplitClassTextBox.Text <> "" And CheckBoxUseList.Enabled = False And aTemp(2) = SplitClassTextBox.Text) Or _
                (CheckedListBox.CheckedItems.Count > 0 And CheckBoxUseList.Enabled = True And CheckedListBox.CheckedItems.IndexOf(aTemp(2)) <> -1) Then
                    If System.IO.Directory.Exists(sPath & "\" & aTemp(3)) = False Then System.IO.Directory.CreateDirectory(sPath & "\" & aTemp(3))
                    StatusBox.Text = "Uploading class: " & aTemp(2)
                    outFile = New System.IO.StreamWriter(sPath & "\" & aTemp(3) & "\" & aTemp(2) & ".txt", False, System.Text.Encoding.Unicode, 1)
                    While sTemp.StartsWith("class_end") = False
                        outFile.WriteLine(sTemp)
                        sTemp = inFile.ReadLine
                        ProgressBar.Value = CInt(inFile.BaseStream.Position)
                    End While
                    outFile.WriteLine(sTemp)
                    outFile.Close()

                    If SplitClassTextBox.Text <> "" And aTemp(2) = SplitClassTextBox.Text Then Exit While
                End If

            End If
            ProgressBar.Value = CInt(inFile.BaseStream.Position)
            Me.Update()

        End While

        inFile.Close()
        ProgressBar.Value = 0
        MessageBox.Show("Uploading successfuly completed", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub MergeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MergeButton.Click

        Dim sPath As String
        FolderBrowserDialog.SelectedPath = Application.StartupPath
        FolderBrowserDialog.Tag = "Select folder with data (AI class in text file)"
        StatusBox.Text = "Select folder with data (AI class in text file)"
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sPath = FolderBrowserDialog.SelectedPath

        Dim newAiObj As String
        SaveFileDialog.FileName = ""
        SaveFileDialog.Filter = "Lineage II Intelligence File (ai.obj)|ai.obj|All files|*.*"
        SaveFileDialog.OverwritePrompt = True
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        newAiObj = SaveFileDialog.FileName

        Dim outLog As System.IO.StreamWriter = Nothing
        If MergeCheckBox2.Checked = True Then outLog = New System.IO.StreamWriter("L2ScriptMaker_AISplitter.log", True, System.Text.Encoding.Unicode, 1)

        ' --- Logger ---
        If MergeCheckBox2.Checked = True Then outLog.WriteLine("L2ScriptMaker AI.obj Generator")
        If MergeCheckBox2.Checked = True Then outLog.WriteLine(Now.ToString & " Start process...")
        If MergeCheckBox2.Checked = True Then outLog.WriteLine("")

        Dim aClassFiles() As String
        aClassFiles = System.IO.Directory.GetFiles(sPath, "*.txt", IO.SearchOption.AllDirectories)
        If aClassFiles.Length = 0 Then
            MessageBox.Show("Folder empty. Select different folder.", "Folder empty", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ' --- Logger ---
        If MergeCheckBox2.Checked = True Then outLog.WriteLine("Loaded " & aClassFiles.Length & " classes" & vbNewLine)
        Dim aClassName(aClassFiles.Length) As String
        Dim aParentClass(aClassFiles.Length) As String
        Dim aClassDependence(aClassFiles.Length) As String
        Dim aClassOrder(aClassFiles.Length) As Integer
        Dim aTemp() As String
        Dim sTemp As String

        ' ---- STEP 1: loading data about class and creating array's for working ---

        ProgressBar.Maximum = CInt(aClassFiles.Length)
        ProgressBar.Value = 0

        Dim inFile As System.IO.StreamReader

        Dim iTemp As Integer
        For iTemp = 0 To aClassFiles.Length - 1

            ProgressBar.Value = iTemp
            StatusBox.Text = "Loading: " & System.IO.Path.GetFileName(aClassFiles(iTemp))
            Me.Update()

            inFile = New System.IO.StreamReader(aClassFiles(iTemp), System.Text.Encoding.Default, True, 1)
            Try
                ' File can be empty, permission denied and etc
                sTemp = inFile.ReadLine.Trim
            Catch ex As Exception
                If MergeCheckBox2.Checked = True Then
                    outLog.WriteLine("File '" & System.IO.Path.GetFileName(aClassFiles(iTemp)) & "' crash with exception " & ex.Message)
                Else
                    MessageBox.Show("File '" & System.IO.Path.GetFileName(aClassFiles(iTemp)) & "' crash with exception " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                inFile.Close()
                GoTo CritExit
                'Exit For
            End Try
            If sTemp = "" Then
                ' --- Logger ---
                If MergeCheckBox2.Checked = True Then
                    outLog.WriteLine("File '" & System.IO.Path.GetFileName(aClassFiles(iTemp)) & "' empty or have null header")
                    outLog.WriteLine("Exit")
                Else
                    MessageBox.Show("File '" & System.IO.Path.GetFileName(aClassFiles(iTemp)) & "' empty or have null header", "Bad input file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                inFile.Close()
                GoTo CritExit
                'Exit For
            End If

            aTemp = sTemp.Replace(": ", "").Split(Chr(32))
            'class(0) 1(1) default_npc(2) :() (null)(3)
            aClassName(iTemp) = aTemp(2)
            aParentClass(iTemp) = aTemp(3)
            'aClassDependence(iTemp) = ""
            aClassOrder(iTemp) = -1

        Next
        ProgressBar.Value = 0

        ' ---- STEP 2: find all dependence ---
        Dim Cursor As Integer = 0
        Dim ParentValid As Boolean = True

        ProgressBar.Maximum = CInt(aClassFiles.Length - 1)

        Dim iTemp2 As Integer = 0
        For iTemp = 0 To aClassFiles.Length - 1


            StatusBox.Text = "Searching all dependence for: " & aClassName(iTemp)
            Me.Update()

            'find class tree
            Cursor = iTemp ' Array.IndexOf(aClassName, aParentClass(iTemp))
            aClassDependence(iTemp) = aClassName(iTemp)
            While Cursor <> -1
                sTemp = aParentClass(Cursor)
                aClassDependence(iTemp) = aClassDependence(iTemp) & "|" & sTemp
                Cursor = Array.IndexOf(aClassName, sTemp)
                If sTemp <> "(null)" And Cursor = -1 Then
                    ' Class have not Parent Class
                    If MergeCheckBox2.Checked = True Then
                        outLog.WriteLine("Class '" & aClassName(iTemp) & "' not have parent class '" & sTemp & "'.")
                    Else
                        MessageBox.Show("Class '" & aClassName(iTemp) & "' not have parent class '" & sTemp & "'.", "No parent class", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    ParentValid = False
                End If
            End While

            If ParentValid = True Then
                aTemp = aClassDependence(iTemp).Split(CChar("|"))
                aClassOrder(iTemp) = aTemp.Length
            Else
                aClassOrder(iTemp) = 1
                ParentValid = True
            End If

            ProgressBar.Value = iTemp

        Next
        ProgressBar.Value = 0

        ' ---- STEP 3: saving AI.obj ---

        Dim outAI As New System.IO.StreamWriter(newAiObj, False, System.Text.Encoding.Unicode, 1)

        ' Write AI.obj default header
        outAI.WriteLine("SizeofPointer 8")
        outAI.WriteLine("SharedFactoryVersion 429")
        outAI.WriteLine("NPCHVersion 413")
        outAI.WriteLine("NASCVersion 235")
        outAI.WriteLine("NPCEventHVersion 125")
        outAI.WriteLine("Debug 0" & vbNewLine)

        Dim iClassCount As Integer = 0
        iTemp = 2   ' Start finding for (null) - ID 2
        ProgressBar.Maximum = CInt(aClassOrder.Length)
        While iTemp <> -1

            StatusBox.Text = "Writing " & (iTemp - 1) & " dependence tree level..."
            Me.Update()

            Cursor = iTemp
            Cursor = Array.IndexOf(aClassOrder, iTemp)
            If Cursor = -1 Then Exit While
            While Cursor <> -1

                ProgressBar.Value = Cursor

                ' Write class to AI.obj
                inFile = New System.IO.StreamReader(aClassFiles(Cursor), System.Text.Encoding.Default, True, 1)
                outAI.WriteLine(inFile.ReadToEnd)
                inFile.Close()
                iClassCount += 1

                ' Find next class with equal dependence level
                Cursor = Array.IndexOf(aClassOrder, iTemp, Cursor + 1)
            End While

            iTemp += 1

        End While

        ' Writing classes without dependence
        If MergeCheckBox1.Checked = True Then

            StatusBox.Text = "Writing classes without dependence..."
            Me.Update()

            iTemp = 1
            Cursor = 1
            Cursor = Array.IndexOf(aClassOrder, iTemp)

            If Cursor <> -1 Then

                outAI.WriteLine("//----------------------------------------------------------")
                outAI.WriteLine("// ATTENTION!! Here classes without parent class dependence!")
                outAI.WriteLine("//----------------------------------------------------------")
                outAI.WriteLine()

                While Cursor <> -1

                    ProgressBar.Value = Cursor

                    ' Write class to AI.obj
                    inFile = New System.IO.StreamReader(aClassFiles(Cursor), System.Text.Encoding.Default, True, 1)
                    outAI.WriteLine(inFile.ReadToEnd)
                    inFile.Close()
                    iClassCount += 1

                    ' Find next class with equal dependence level
                    Cursor = Array.IndexOf(aClassOrder, iTemp, Cursor + 1)
                End While

            End If
        End If

        outAI.Close()
        If MergeCheckBox2.Checked = True Then outLog.WriteLine(vbNewLine & "Saved " & iClassCount & " classes" & vbNewLine)

CritExit:
        ProgressBar.Value = 0
        StatusBox.Text = "Complete"
        ' --- Logger ---
        If MergeCheckBox2.Checked = True Then outLog.WriteLine(vbNewLine & Now.ToString & " Work complete" & vbNewLine)
        If MergeCheckBox2.Checked = True Then outLog.Close()

        MessageBox.Show("New Ai.obj file gathered complete. Statistics:" _
        & vbNewLine & "Loaded: " & aClassFiles.Length & " classes" _
        & vbNewLine & "Saved:  " & iClassCount & " classes" & vbNewLine)

    End Sub


    Private Sub Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quit.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonLoadClassList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoadClassList.Click

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II AI config (ai.obj)|*.obj|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim sAIFile As String
        sAIFile = OpenFileDialog.FileName


        Dim inFile As System.IO.StreamReader = New System.IO.StreamReader(sAIFile, System.Text.Encoding.Default, True, 1)

        Dim iTemp As Integer = 0
        Dim sTemp As String = ""
        Dim aTemp() As String = Nothing

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ProgressBar.Value = 0

        CheckedListBox.SuspendLayout()

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ProgressBar.Value = CInt(inFile.BaseStream.Position)
            Me.Update()

            If sTemp.StartsWith("class ") = True Then
                'class 1 party_private : party_private_param
                aTemp = sTemp.Split(Chr(32))
                CheckedListBox.Items.Add(aTemp(2))
            End If

        End While
        ProgressBar.Value = 0
        CheckedListBox.ResumeLayout()

        If CheckedListBox.Items.Count > 0 Then CheckBoxUseList.Enabled = True

    End Sub


    Private Sub CheckedListBox_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles CheckedListBox.ItemCheck

        If (e.NewValue = CheckState.Checked) Then
            If CheckedListBox.CheckedItems.Count = 0 Then
                CheckBoxUseList.Checked = True
                SplitClassTextBox.Enabled = False
            End If
        End If

        If (e.NewValue = CheckState.Unchecked) Then
            If CheckedListBox.CheckedItems.Count = 1 Then
                CheckBoxUseList.Checked = False
                SplitClassTextBox.Enabled = True
            End If
        End If


    End Sub

    Private Sub ButtonFindSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindSelect.Click

        If TextBoxFindSelect.Text = "" Then
            MessageBox.Show("Nothing to searching.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim iTemp As Integer = CheckedListBox.FindString(TextBoxFindSelect.Text)
        If iTemp <> -1 Then
            CheckedListBox.SetItemCheckState(iTemp, CheckState.Checked)
            CheckedListBox.SetSelected(iTemp, True)
        Else
            MessageBox.Show("Nothing founded.", "Nothing", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ButtonFindExact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindExact.Click

        If TextBoxFindSelect.Text = "" Then
            MessageBox.Show("Nothing to searching.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim iTemp As Integer = CheckedListBox.FindString(TextBoxFindSelect.Text, CheckedListBox.SelectedIndex)
        If iTemp <> -1 Then
            'CheckedListBox.SetItemCheckState(iTemp, CheckState.Checked)
            CheckedListBox.SetSelected(iTemp, True)
        Else
            MessageBox.Show("Nothing founded.", "Nothing", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class
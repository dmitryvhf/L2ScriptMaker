Public Class DatDecoder

    Private Structure L2Asm
        Dim Name As String
        Dim ReadData As String
        Dim ReadDataNum As String
        Dim StartTag As String
        Dim EndTag As String
        Dim Unicode As Boolean
    End Structure

    Private Sub DatDecoder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        l2asmDDFPathTextBox.Text = System.IO.Directory.GetCurrentDirectory & "\DatProject\DDF"
        'DatProject\DDF
        If System.IO.Directory.Exists(l2asmDDFPathTextBox.Text) = False Then
            MessageBox.Show("Not exist DDF folder. Define correct folder and try again.", "Wrong DDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
            l2asmDDFPathTextBox.Text = System.IO.Directory.GetCurrentDirectory
            'Exit Sub
        Else
            Dim DDFList() As String
            DDFList = System.IO.Directory.GetFiles(l2asmDDFPathTextBox.Text, "*.ddf", IO.SearchOption.AllDirectories)
            'DDFList = System.IO.Directory.GetFiles(l2asmDDFPathTextBox.Text.Replace(System.IO.Directory.GetCurrentDirectory & "\", ""), "*.ddf", IO.SearchOption.AllDirectories)
            If DDFList.Length < 1 Then
                MessageBox.Show("Not exist DDF files in this folder. Define correct folder and try again.", "Wrong DDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim iTemp As Integer
            For iTemp = 0 To DDFList.Length - 1
                DDFList(iTemp) = DDFList(iTemp).Replace(l2asmDDFPathTextBox.Text, "")
            Next

            DDFListComboBox.Items.Clear()
            DDFListComboBox.Items.AddRange(DDFList)
        End If

    End Sub

    Private Sub l2asmDDFPathTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles l2asmDDFPathTextBox.MouseDoubleClick

        'FolderBrowserDialog.SelectedPath = l2asmDDFPathTextBox.Text
        FolderBrowserDialog.Tag = "L2Asm DDF file folder (root path)(*.ddf)"
        If FolderBrowserDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            l2asmDDFPathTextBox.Text = FolderBrowserDialog.SelectedPath '.Replace(System.IO.Directory.GetCurrentDirectory & "\", "")

            Dim DDFList() As String
            DDFList = System.IO.Directory.GetFiles(l2asmDDFPathTextBox.Text, "*.ddf", IO.SearchOption.AllDirectories)
            If DDFList.Length = 0 Then
                MessageBox.Show("Not exist DDF files in this folder. Define correct folder and try again.", "Wrong DDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim iTemp As Integer
            For iTemp = 0 To DDFList.Length - 1
                DDFList(iTemp) = DDFList(iTemp).Replace(l2asmDDFPathTextBox.Text, "")
            Next
            DDFListComboBox.Items.Clear()
            DDFListComboBox.Items.AddRange(DDFList)

        End If
    End Sub


    ' ---------------------- L2Asm -> Dat ----------------------

    Private Sub l2encInFileTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles l2encInFileTextBox.MouseDoubleClick

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II client file (*.dat)|*.dat|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        l2encInFileTextBox.Text = OpenFileDialog.FileName

        ' Auto define for default values
        l2encOutFileTextBox.Text = System.IO.Path.GetFileName(l2encInFileTextBox.Text)
        l2encOutFileTextBox.Text = l2encInFileTextBox.Text.Replace(l2encOutFileTextBox.Text, "~" & l2encOutFileTextBox.Text)
        l2asmOutFileTextBox.Text = l2encOutFileTextBox.Text.Replace(".dat", ".txt")


    End Sub

    Private Sub l2encOutFileTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles l2encOutFileTextBox.MouseDoubleClick
        SaveFileDialog.FileName = l2encOutFileTextBox.Text
        SaveFileDialog.Filter = "Lineage II decoded client file (*.dat)|*.dat|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        l2encOutFileTextBox.Text = SaveFileDialog.FileName

    End Sub

    Private Sub l2asmOutFileTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles l2asmOutFileTextBox.MouseDoubleClick
        SaveFileDialog.FileName = l2asmOutFileTextBox.Text
        SaveFileDialog.Filter = "Lineage II client file parsed as plain text (*.txt)|*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        l2asmOutFileTextBox.Text = SaveFileDialog.FileName
    End Sub

    Private Sub DecWithL2EncdecButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecWithL2EncdecButton.Click

        If DDFListComboBox.Text = "" Or l2encInFileTextBox.Text = "" Or l2encOutFileTextBox.Text = "" Then
            MessageBox.Show("Not defined all parameters for decrypting", "Must define all params", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sTemp As String
        sTemp = """" & l2ancdecPathTextBox.Text & """" & " " & l2encParamsComboBox.Text & " "
        sTemp = sTemp & """" & l2encInFileTextBox.Text & """" & " "
        sTemp = sTemp & """" & l2encOutFileTextBox.Text & """"

        'MessageBox.Show(sTemp)
        Shell(sTemp, AppWinStyle.NormalFocus, True)

        If System.IO.File.Exists(l2encOutFileTextBox.Text) = False Then
            MessageBox.Show("File not created. Change decrypt option and try again.", "File not created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("File saved success.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub DecWithL2AsmButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecWithL2AsmButton.Click

        If l2encOutFileTextBox.Text = "" Or DDFListComboBox.Text = "" Or l2asmOutFileTextBox.Text = "" Then
            MessageBox.Show("Not defined all parameters for parsing", "Must define all params", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sTemp As String
        sTemp = """" & l2disasmPathTextBox.Text & """" & " -d " & """" & l2asmDDFPathTextBox.Text & DDFListComboBox.Text & """" & " "
        sTemp = sTemp & """" & l2encOutFileTextBox.Text & """" & " "
        sTemp = sTemp & """" & l2asmOutFileTextBox.Text & """"

        Shell(sTemp, AppWinStyle.NormalFocus, True)

        If System.IO.File.Exists(l2asmOutFileTextBox.Text) = False Then
            MessageBox.Show("File not created. Perhaps you are select wrong DDF type for this file.", "File not created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("File saved success.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    ' ---------------------- L2Asm -> Dat -> Decrypt ----------------------

    Private Sub TxtToL2asmUseStructureButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtToL2asmUseStructureButton.Click

        Dim inTxtFile As String
        Dim outL2asmFile As String
        Dim inStructFile As String

        Dim sTemp As String
        Dim aTemp(0) As String
        Dim iTemp As Integer
        Dim inStructure(0) As L2Asm

        ' --- Reading structure file ---
        OpenFileDialog.Title = "Select text file with structure definition..."
        OpenFileDialog.Filter = "Text files (*.cfg)|*.cfg|All files (*.*)|*.*"
        OpenFileDialog.FileName = ""
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        inStructFile = OpenFileDialog.FileName
        Dim inFile As New System.IO.StreamReader(inStructFile, System.Text.Encoding.Default, True, 1)
        If inFile.ReadLine <> "[L2ScriptMaker: Plain file L2Asm Converter v2]" Then
            MessageBox.Show("This file is not structure file. Select another file and try again.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            inFile.Close()
            Exit Sub
        End If
        outL2asmFile = inFile.ReadLine

        iTemp = -1
        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine.Trim
            If sTemp <> "" Then
                iTemp += 1
                Array.Resize(inStructure, iTemp + 1)
                Try
                    aTemp = sTemp.Split(CChar(","))

                    inStructure(iTemp).Name = aTemp(0)          'name of column
                    inStructure(iTemp).ReadData = aTemp(1)      'read data from name param
                    inStructure(iTemp).StartTag = aTemp(2)      'read data from name param
                    inStructure(iTemp).EndTag = aTemp(3)        'read data from name param
                    inStructure(iTemp).Unicode = CBool(aTemp(4))        'read data from name param

                Catch ex As Exception
                    MessageBox.Show("Bad structure in line " & vbNewLine & sTemp & vbNewLine & " Select another file and try again.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inFile.Close()
                    Exit Sub
                End Try
            End If
        End While
        '                Array.IndexOf(inStructure, "asa")
        inFile.Close()

        ' --- Reading structure file ---
        OpenFileDialog.Title = "Select file generated by L2Asm for reparsing..."
        OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        OpenFileDialog.FileName = ""
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        inTxtFile = OpenFileDialog.FileName
        outL2asmFile = System.IO.Path.GetDirectoryName(inTxtFile) & "\" & outL2asmFile

        If inTxtFile = outL2asmFile Then
            MessageBox.Show("Source file cant be same as target file. Change source file name and try again.", "Bad source file name file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If System.IO.File.Exists(outL2asmFile) = True Then
            If MessageBox.Show("Overwrite existing file?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                MessageBox.Show("Output file '" & outL2asmFile & "' already exist.", "Output file exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        inFile = New System.IO.StreamReader(inTxtFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(outL2asmFile, False, System.Text.Encoding.GetEncoding(1250), 1)

        sTemp = ""
        For iTemp = 0 To inStructure.Length - 1
            sTemp = sTemp & inStructure(iTemp).Name
            If iTemp < inStructure.Length - 1 Then sTemp = sTemp & vbTab
        Next
        ' Write header for structure
        outFile.WriteLine(sTemp)

        sTemp = "" : Dim sTempParam As String = ""
        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        Dim sTemp2 As String
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            aTemp = sTemp.Split(Chr(9))
            sTemp2 = ""
            For iTemp = 0 To inStructure.Length - 1
                sTempParam = Libraries.GetNeedParamFromStr(sTemp, inStructure(iTemp).ReadData)
                If inStructure(iTemp).StartTag <> "" Then
                    sTempParam = sTempParam.Replace(inStructure(iTemp).StartTag, "")
                End If
                If inStructure(iTemp).StartTag <> "" Then
                    sTempParam = sTempParam.Replace(inStructure(iTemp).EndTag, "")
                End If
                If inStructure(iTemp).Unicode = True Then
                    If sTempParam.Length > 0 Then sTempParam = sTempParam & "\0"
                    sTempParam = "a," & sTempParam
                End If
                sTemp2 = sTemp2 & sTempParam
                If iTemp < inStructure.Length - 1 Then sTemp2 = sTemp2 & vbTab
            Next
            outFile.WriteLine(sTemp2)
            ProgressBar.Value = CInt(inFile.BaseStream.Position)

        End While
        inFile.Close()
        outFile.Close()
        ProgressBar.Value = 0

        MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub


    Private Sub L2asmToTxtUseStructureButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L2asmToTxtUseStructureButton.Click

        Dim inL2AsmFile As String
        Dim outGoodFile As String
        Dim inStructFile As String

        Dim sTemp As String
        Dim aTemp(0) As String
        Dim iTemp As Integer
        Dim inStructure(0) As L2Asm

        ' --- Reading structure file ---
        OpenFileDialog.Title = "Select text file with structure definition..."
        OpenFileDialog.Filter = "Text files (*.cfg)|*.cfg|All files (*.*)|*.*"
        OpenFileDialog.FileName = ""
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        inStructFile = OpenFileDialog.FileName
        Dim inFile As New System.IO.StreamReader(inStructFile, System.Text.Encoding.Default, True, 1)
        If inFile.ReadLine <> "[L2ScriptMaker: L2DisAsm to Plain file Converter v2]" Then
            MessageBox.Show("This file is not structure file. Select another file and try again.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            inFile.Close()
            Exit Sub
        End If
        outGoodFile = inFile.ReadLine

        iTemp = -1
        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine
            iTemp += 1
            Array.Resize(inStructure, iTemp + 1)
            Try
                aTemp = sTemp.Split(CChar(","))
                inStructure(iTemp).Name = aTemp(0)
                inStructure(iTemp).ReadData = aTemp(1)
                inStructure(iTemp).ReadDataNum = aTemp(2)
                inStructure(iTemp).StartTag = aTemp(3)
                inStructure(iTemp).EndTag = aTemp(4)
                inStructure(iTemp).Unicode = CBool(aTemp(5))
            Catch ex As Exception
                MessageBox.Show("Bad structure in line " & vbNewLine & sTemp & vbNewLine & " Select another file and try again.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                inFile.Close()
                Exit Sub
            End Try
        End While
        inFile.Close()

        ' --- Reading structure file ---
        OpenFileDialog.Title = "Select file generated by L2Asm for reparsing..."
        OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        OpenFileDialog.FileName = ""
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        inL2AsmFile = OpenFileDialog.FileName
        outGoodFile = System.IO.Path.GetDirectoryName(inL2AsmFile) & "\" & outGoodFile

        If inL2AsmFile = outGoodFile Then
            MessageBox.Show("Source file cant be same as target file. Change source file name and try again.", "Bad source file name file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If System.IO.File.Exists(outGoodFile) = True Then
            If MessageBox.Show("Overwrite existing file?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                MessageBox.Show("Output file '" & outGoodFile & "' already exist.", "Output file exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        inFile = New System.IO.StreamReader(inL2AsmFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(outGoodFile, False, System.Text.Encoding.Unicode, 1)

        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        inFile.ReadLine()   'Read structure. Ignore it.
        Dim sTemp2 As String, sTemp3 As String
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            aTemp = sTemp.Split(Chr(9))
            sTemp = "" : sTemp2 = "" : sTemp3 = ""
            For iTemp = 0 To inStructure.Length - 1
                'inStructure(iTemp).Name

                If inStructure(iTemp).Unicode = True Then
                    sTemp3 = aTemp(CInt(inStructure(iTemp).ReadDataNum))
                    If sTemp3.StartsWith("a,") = True Then sTemp3 = sTemp3.Remove(0, 2)
                    If sTemp3.EndsWith("\0") = True Then sTemp3 = sTemp3.Remove(sTemp3.Length - 2, 2)
                    aTemp(CInt(inStructure(iTemp).ReadDataNum)) = sTemp3
                End If

                Select Case inStructure(iTemp).ReadData
                    Case "0"
                        '0 - nothing (ignore)
                    Case "1"
                        '1 - only 'name'
                        sTemp2 = inStructure(iTemp).Name
                    Case "2"
                        '2 - only data (read data from l2asm generic file (0 - no, 1 - yes))
                        sTemp2 = inStructure(iTemp).StartTag & aTemp(CInt(inStructure(iTemp).ReadDataNum)) & inStructure(iTemp).EndTag
                    Case "3"
                        '3 - name and data (name=[1221])
                        sTemp2 = inStructure(iTemp).Name & "=" & inStructure(iTemp).StartTag & aTemp(CInt(inStructure(iTemp).ReadDataNum)) & inStructure(iTemp).EndTag
                End Select
                If iTemp < inStructure.Length - 1 Then
                    sTemp = sTemp & sTemp2 & vbTab
                Else
                    sTemp = sTemp & sTemp2
                End If
                sTemp2 = ""

            Next
            outFile.WriteLine(sTemp)
            ProgressBar.Value = CInt(inFile.BaseStream.Position)

        End While
        inFile.Close()
        outFile.Close()
        ProgressBar.Value = 0

        MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub L2Adm2NormalButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L2Adm2NormalButton.Click

        Dim WorkFile As String
        Dim sTemp As String
        Dim iTemp As Integer, iTempLength As Integer
        Dim aStruct() As String
        Dim sHeader As String, sHeaderEnder As String

        OpenFileDialog.Title = "Select text file after L2Asm decoding..."
        OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        WorkFile = OpenFileDialog.FileName

        Dim inFile As New System.IO.StreamReader(WorkFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(System.IO.Path.GetDirectoryName(WorkFile) & "\" & System.IO.Path.GetFileNameWithoutExtension(WorkFile) & "_new.txt", False, System.Text.Encoding.Unicode, 1)

        sTemp = System.IO.Path.GetFileNameWithoutExtension(WorkFile)
        sTemp = sTemp.Replace("dec-", "").Replace("-e", "")
        sHeader = sTemp & "_begin"
        sHeaderEnder = sTemp & "_end"

        ' Read structure
        sTemp = inFile.ReadLine
        aStruct = sTemp.Split(Chr(9))
        iTempLength = aStruct.Length
        Dim aTemp(iTempLength) As String

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ProgressBar.Value = 0
        Me.Update()
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ProgressBar.Value = CInt(inFile.BaseStream.Position) : Me.Update()
            aTemp = sTemp.Split(Chr(9))
            outFile.Write(sHeader)
            For iTemp = 0 To iTempLength - 1
                If aTemp(iTemp).ToUpper <> aTemp(iTemp).ToLower Then aTemp(iTemp) = "[" & aTemp(iTemp) & "]"
                outFile.Write(vbTab & aStruct(iTemp) & "=" & aTemp(iTemp))
            Next
            outFile.WriteLine(vbTab & sHeaderEnder)

        End While

        outFile.Close()
        inFile.Close()

        ProgressBar.Value = 0
        MessageBox.Show("Done")


    End Sub

    ' ---------------------- Dat -> L2Asm -> Encrypt ----------------------
    Private Sub inl2asmToDatTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles inl2asmToDatTextBox.MouseDoubleClick

        OpenFileDialog.FileName = inl2asmToDatTextBox.Text
        OpenFileDialog.Filter = "Lineage II plain text client file (*.txt)|*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            inl2asmToDatTextBox.Text = OpenFileDialog.FileName

            ' Auto define for default values
            outl2asmToDatTextBox.Text = inl2asmToDatTextBox.Text.Replace(".txt", ".dat")

            inl2encdecToDatTextBox.Text = System.IO.Path.GetFileName(outl2asmToDatTextBox.Text).Replace("~", "")
            inl2encdecToDatTextBox.Text = outl2asmToDatTextBox.Text.Replace("\~" & inl2encdecToDatTextBox.Text, "\" & inl2encdecToDatTextBox.Text)
        End If

    End Sub

    Private Sub outl2asmToDatTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles outl2asmToDatTextBox.MouseDoubleClick
        SaveFileDialog.FileName = outl2asmToDatTextBox.Text
        SaveFileDialog.Filter = "Lineage II decoded client file (*.dat)|*.dat|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        outl2asmToDatTextBox.Text = SaveFileDialog.FileName

    End Sub

    Private Sub inl2encdecToDatTextBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles inl2encdecToDatTextBox.MouseDoubleClick
        SaveFileDialog.FileName = inl2encdecToDatTextBox.Text
        SaveFileDialog.Filter = "Lineage II decoded client file (*.dat)|*.dat|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        inl2encdecToDatTextBox.Text = SaveFileDialog.FileName
    End Sub

    Private Sub EncWithL2AsmButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncWithL2AsmButton.Click

        If inl2asmToDatTextBox.Text = "" Or DDFListComboBox.Text = "" Or outl2asmToDatTextBox.Text = "" Then
            MessageBox.Show("Not defined all parameters for packing", "Must define all params", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sTemp As String
        sTemp = """" & l2asmPathTextBox.Text & """ " & TextBoxL2AsmAddComm.Text & " -d " & """" & l2asmDDFPathTextBox.Text & DDFListComboBox.Text & """" & " "
        sTemp = sTemp & """" & inl2asmToDatTextBox.Text & """" & " "
        sTemp = sTemp & """" & outl2asmToDatTextBox.Text & """"

        Shell(sTemp, AppWinStyle.NormalFocus, True)

        If System.IO.File.Exists(outl2asmToDatTextBox.Text) = False Then
            MessageBox.Show("File not created. Perhaps you are select wrong DDF type for this file.", "File not created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("File saved success.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub EncWithL2EncdecButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncWithL2EncdecButton.Click

        If outl2asmToDatTextBox.Text = "" Or inl2encdecToDatTextBox.Text = "" Then
            MessageBox.Show("Not defined all parameters for encrypting", "Must define all params", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sTemp As String
        sTemp = """" & l2ancdecPathTextBox.Text & """" & " " & l2endecEncModeComboBox.Text & " " & l2endecEncMetodComboBox.Text & " "
        sTemp = sTemp & """" & outl2asmToDatTextBox.Text & """" & " "
        sTemp = sTemp & """" & inl2encdecToDatTextBox.Text & """"

        'MessageBox.Show(sTemp)
        Shell(sTemp, AppWinStyle.NormalFocus, True)

        If System.IO.File.Exists(inl2encdecToDatTextBox.Text) = False Then
            MessageBox.Show("File not created. Change decrypt option and try again.", "File not created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("File saved success.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    ' ---------------------- End ----------------------

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

    Private Sub LoadDDFButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadDDFButton.Click

        OpenFileDialog.Filter = "L2Disasm text file (~*.txt)|*.txt|All files(*.*)|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim sTemp As String, iTemp As Integer
        Dim aTemp(50) As String

        sTemp = System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog.FileName)
        If sTemp.StartsWith("~") = True Then sTemp = sTemp.Remove(0, 1)
        PlainFileNameTextBox.Text = sTemp & ".txt"
        HeadTextBox.Text = sTemp & "_begin"
        EndTextBox.Text = sTemp & "_end"

        DDFDataGridView.Rows.Clear()

        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        sTemp = inFile.ReadLine.Trim

        ' First line -- Structure
        aTemp = sTemp.Split(Chr(9))
        For iTemp = 0 To aTemp.Length - 1
            DDFDataGridView.Rows.Add(aTemp(iTemp))
        Next

        sTemp = inFile.ReadLine.Trim
        inFile.Close()
        ' Second line -- Unicode autodetect
        aTemp = sTemp.Split(Chr(9))
        For iTemp = 0 To aTemp.Length - 1
            If aTemp(iTemp).StartsWith("a,") = True Then 'And aTemp(iTemp).EndsWith("\0") = True
                DDFDataGridView.Item(3, iTemp).Value = True
            End If
        Next

        MessageBox.Show("File structure loaded. Make required changes in structure and make Generate new config", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub MakeConfigsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeConfigsButton.Click

        Dim sFolderToSave As String, sFileName As String
        Dim outFile As System.IO.StreamWriter
        Dim iTemp As Integer

        FolderBrowserDialog.SelectedPath = Application.StartupPath
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sFolderToSave = FolderBrowserDialog.SelectedPath
        sFileName = System.IO.Path.GetFileNameWithoutExtension(PlainFileNameTextBox.Text)

        'l2sm_l2asmtodat_castlename-e.cfg
        'l2sm_dattol2asm_castlename-e.cfg

        ' Save L2DisAsm -> Plain cfg
        outFile = New System.IO.StreamWriter(sFolderToSave & "\l2sm_l2disasmtotxt_" & sFileName & ".cfg", False, System.Text.Encoding.Default, 1)
        outFile.WriteLine("[L2ScriptMaker: L2DisAsm to Plain file Converter v2]")
        outFile.WriteLine(sFileName & ".txt")
        outFile.WriteLine(HeadTextBox.Text & ",1,,,,False")
        For iTemp = 0 To DDFDataGridView.Rows.Count - 2
            outFile.Write(CStr(DDFDataGridView.Item(0, iTemp).Value) & ",3,")    ' param name
            outFile.Write(iTemp & ",")    ' counter
            outFile.Write(CStr(DDFDataGridView.Item(1, iTemp).Value) & ",")      ' start symbol
            outFile.Write(CStr(DDFDataGridView.Item(2, iTemp).Value) & ",")      ' end symbol
            outFile.WriteLine(DDFDataGridView.Item(3, iTemp).FormattedValue.ToString)      ' unicode? symbol
        Next
        outFile.WriteLine(EndTextBox.Text & ",1,,,,False")
        outFile.Close()

        outFile = New System.IO.StreamWriter(sFolderToSave & "\l2sm_txttol2asm_" & sFileName & ".cfg", False, System.Text.Encoding.Default, 1)
        outFile.WriteLine("[L2ScriptMaker: Plain file L2Asm Converter v2]")
        outFile.WriteLine("~" & sFileName & ".txt")
        For iTemp = 0 To DDFDataGridView.Rows.Count - 2
            outFile.Write(CStr(DDFDataGridView.Item(0, iTemp).Value) & ",")    ' param name
            outFile.Write(CStr(DDFDataGridView.Item(0, iTemp).Value) & ",")    ' param name
            outFile.Write(CStr(DDFDataGridView.Item(1, iTemp).Value) & ",")     ' start symbol
            outFile.Write(CStr(DDFDataGridView.Item(2, iTemp).Value) & ",") ' end symbol
            outFile.WriteLine(DDFDataGridView.Item(3, iTemp).FormattedValue.ToString)        ' unicode? symbol
        Next
        outFile.Close()

        MessageBox.Show("File structure saved. Now you can use module L2DisAsm->Txt", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


End Class

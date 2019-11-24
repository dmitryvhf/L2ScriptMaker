Public Class AIDecompilerPack

    'push_event	//  myself
    'push_const 704

    '704|default|myself
    '704|CREATED|myself

    Dim sEventID(0) As String
    Dim sEventName(0) As String
    Dim sEventHandlerName(0) As String

    'fetch_i	//  p_state
    'push_const 280

    '16|default|value
    '16|ATTACKED|creature

    '16|default|y
    '16|status|value
    '16|h0|creature

    Dim sFetchID(0) As String
    Dim sFetchName(0) As String
    Dim sFetchEventName(0) As String


    Private Function SearchAllEvents(ByVal fID As String, ByVal fName As String, ByVal fHandler As String) As Boolean

        SearchAllEvents = False

        Dim iTemp1 As Integer = 0, iTemp2 As Integer = 0

        iTemp1 = Array.IndexOf(sEventID, fID)
        If iTemp1 = -1 Then Return False
        If sEventName(iTemp1) = fName And (sEventHandlerName(iTemp1) = "default" Or sEventHandlerName(iTemp1) = fHandler) Then Return True

        iTemp1 = Array.IndexOf(sEventID, fID, iTemp1 + 1)
        While iTemp1 <> -1

            If sEventName(iTemp1) = fName And sEventHandlerName(iTemp1) = fHandler Then Return True
            iTemp1 = Array.IndexOf(sEventID, fID, iTemp1 + 1)

        End While

    End Function

    Private Sub CollectEventButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectEventButton.Click

        '656|default|last_attacker
        '656|ON_START|myself

        Dim sTemp As String, sTemp2 As String, sFile As String = ""
        Dim aTemp() As String
        Dim iTemp As Integer = 0
        Dim iErrFlag As Boolean = False

        Dim sTempEventID As String = ""
        Dim sTempEventName As String = ""
        'Dim sTempEventName As String = ""
        Dim sTempHandlerName As String = ""

        Dim iFuncCounter As Integer = 0

        If OpenFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then sFile = OpenFileDialog.FileName
        Dim inFile As System.IO.StreamReader = New System.IO.StreamReader(sFile, System.Text.Encoding.Default, True, 1)

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine()
            ProgressBar.Value = CInt(inFile.BaseStream.Position)
            sTemp = StrPrepare(sTemp)
            iTemp = iTemp + 1

            If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("handler ") = True Then
                'handler(0) 13(1) 289(2)	//(3)  CREATED(4)
                aTemp = sTemp.Split(Chr(32))
                sTempHandlerName = aTemp(4)
            End If

RepeateRead:

            'fetch_i	//  p_state
            'push_const 280

            If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("push_event ") = True Then
                aTemp = sTemp.Split(Chr(32))

                'fetch_i(0)	//(1)  p_state(2)
                'push_const(0) 280(1)

                '16|default|value
                '16|ATTACKED|creature

                If aTemp.Length < 1 Then
                    MessageBox.Show("Not found '//' in " & iTemp & " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    iErrFlag = True
                    Exit While
                End If

                sTempEventName = aTemp(2)

                ' Read next line, waiting push_const 
                sTemp2 = inFile.ReadLine()
                sTemp2 = StrPrepare(sTemp2)
                ProgressBar.Value = CInt(inFile.BaseStream.Position)
                iTemp = iTemp + 1

                If sTemp2 <> "" And sTemp2.StartsWith("//") = False Then
                    If sTemp2.StartsWith("push_const ") = False Then
                        MessageBox.Show("Not found 'push_const' after 'fetch_i' in " & iTemp & " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        iErrFlag = True
                        Exit While
                    End If
                End If

                aTemp = sTemp2.Split(Chr(32))
                sTempEventID = aTemp(1)

                If SearchAllEvents(sTempEventID, sTempEventName, sTempHandlerName) = False Then

                    Array.Resize(sEventID, iFuncCounter + 1)
                    Array.Resize(sEventName, iFuncCounter + 1)
                    Array.Resize(sEventHandlerName, iFuncCounter + 1)
                    If Array.IndexOf(sEventID, sTempEventID) = -1 Then
                        sEventHandlerName(iFuncCounter) = "default"
                    Else
                        sEventHandlerName(iFuncCounter) = sTempHandlerName
                    End If

                    sEventName(iFuncCounter) = sTempEventName
                    sEventID(iFuncCounter) = sTempEventID
                    iFuncCounter = iFuncCounter + 1

                    ' Make dublicate previous push_event for default value
                    If sEventHandlerName(iFuncCounter - 1) = "default" And FetchDefaultCopyCheckBox.Checked = True Then
                        Array.Resize(sEventID, iFuncCounter + 1)
                        Array.Resize(sEventName, iFuncCounter + 1)
                        Array.Resize(sEventHandlerName, iFuncCounter + 1)

                        sEventName(iFuncCounter) = sTempEventName
                        sEventID(iFuncCounter) = sTempEventID
                        sEventHandlerName(iFuncCounter) = sTempHandlerName
                        iFuncCounter = iFuncCounter + 1

                    End If

                End If

            End If

        End While

        ProgressBar.Value = 0
        inFile.Close()

        If iErrFlag = False Then

            MessageBox.Show("Fetch ID's collecting complete. Success." & vbNewLine & " Found " & iFuncCounter & " events.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            SaveFileDialog.FileName = "ai_events.txt"
            If SaveFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then sFile = SaveFileDialog.FileName Else Exit Sub
            Dim outFile As System.IO.StreamWriter = New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Default, 1)

            outFile.WriteLine("// --------------------------")
            outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)")
            outFile.WriteLine("// AI Decompiler 'push_event' list")
            outFile.WriteLine("// updated: " & Now)
            outFile.WriteLine("// --------------------------")
            outFile.WriteLine("// format:")
            outFile.WriteLine("// push_event id|specific HANDLER name|event name")

            '656|default|last_attacker
            '656|ON_START|myself

            For iTemp = 0 To (iFuncCounter - 1)
                sTemp = sEventID(iTemp) & "|" & sEventHandlerName(iTemp) & "|" & sEventName(iTemp)
                outFile.WriteLine(sTemp)
            Next
            outFile.Close()

        End If

    End Sub


    Private Function SearchAllFetch(ByVal fID As String, ByVal fName As String, ByVal fEvent As String) As Boolean

        SearchAllFetch = False

        Dim iTemp1 As Integer = 0, iTemp2 As Integer = 0

        iTemp1 = Array.IndexOf(sFetchID, fID)
        If iTemp1 = -1 Then Return False
        If sFetchName(iTemp1) = fName And (sFetchEventName(iTemp1) = "default" Or sFetchEventName(iTemp1) = fEvent) Then Return True

        iTemp1 = Array.IndexOf(sFetchID, fID, iTemp1 + 1)
        While iTemp1 <> -1

            If sFetchName(iTemp1) = fName And sFetchEventName(iTemp1) = fEvent Then Return True
            iTemp1 = Array.IndexOf(sFetchID, fID, iTemp1 + 1)

        End While

    End Function


    Private Sub CollectFetchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectFetchButton.Click

        Dim sTemp As String, sTemp2 As String, sFile As String = ""
        Dim aTemp() As String
        Dim iTemp As Integer = 0
        Dim iErrFlag As Boolean = False

        Dim sTempFetchID As String = ""
        Dim sTempFetchName As String = ""
        Dim sTempEventName As String = ""
        'Dim sHandlerName As String = ""

        Dim iFuncCounter As Integer = 0

        If OpenFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then sFile = OpenFileDialog.FileName
        Dim inFile As System.IO.StreamReader = New System.IO.StreamReader(sFile, System.Text.Encoding.Default, True, 1)

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine()
            ProgressBar.Value = CInt(inFile.BaseStream.Position)
            sTemp = StrPrepare(sTemp)
            iTemp = iTemp + 1

            'If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("handler ") = True Then
            '    'class 1 default_npc : (null)
            '    aTemp = sTemp.Split(Chr(32))
            '    sHandlerName = aTemp(4)
            'End If

            If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("push_event ") = True And InStr(sTemp, "//") > 0 Then
                'push_event	//  myself
                'push_const 704

                aTemp = sTemp.Split(Chr(32))
                sTempEventName = aTemp(2)
            End If

RepeateRead:

            'fetch_i	//  p_state
            'push_const 280

            If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("fetch_i ") = True Then
                aTemp = sTemp.Split(Chr(32))

                'fetch_i(0)	//(1)  p_state(2)
                'push_const(0) 280(1)

                '16|default|value
                '16|ATTACKED|creature

                If aTemp.Length < 1 Then
                    MessageBox.Show("Not found '//' in " & iTemp & " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    iErrFlag = True
                    Exit While
                End If

                sTempFetchName = aTemp(2)

                ' Read next line, waiting push_const 
                sTemp2 = inFile.ReadLine()
                sTemp2 = StrPrepare(sTemp2)
                ProgressBar.Value = CInt(inFile.BaseStream.Position)
                iTemp = iTemp + 1

                If sTemp2 <> "" And sTemp2.StartsWith("//") = False Then
                    If sTemp2.StartsWith("push_const ") = False Then
                        MessageBox.Show("Not found 'push_const' after 'fetch_i' in " & iTemp & " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        iErrFlag = True
                        Exit While
                    End If
                End If

                aTemp = sTemp2.Split(Chr(32))
                sTempFetchID = aTemp(1)

                If SearchAllFetch(sTempFetchID, sTempFetchName, sTempEventName) = False Then

                    Array.Resize(sFetchID, iFuncCounter + 1)
                    Array.Resize(sFetchName, iFuncCounter + 1)
                    Array.Resize(sFetchEventName, iFuncCounter + 1)
                    If Array.IndexOf(sFetchID, sTempFetchID) = -1 Then
                        sFetchEventName(iFuncCounter) = "default"
                    Else
                        sFetchEventName(iFuncCounter) = sTempEventName
                    End If

                    sFetchName(iFuncCounter) = sTempFetchName
                    sFetchID(iFuncCounter) = sTempFetchID
                    iFuncCounter = iFuncCounter + 1

                    ' Make dublicate previous push_event for default value
                    If sFetchEventName(iFuncCounter - 1) = "default" And FetchDefaultCopyCheckBox.Checked = True Then
                        Array.Resize(sFetchID, iFuncCounter + 1)
                        Array.Resize(sFetchName, iFuncCounter + 1)
                        Array.Resize(sFetchEventName, iFuncCounter + 1)

                        sFetchName(iFuncCounter) = sTempFetchName
                        sFetchID(iFuncCounter) = sTempFetchID
                        sFetchEventName(iFuncCounter) = sTempEventName
                        iFuncCounter = iFuncCounter + 1

                    End If

                End If

            End If

        End While

        ProgressBar.Value = 0
        inFile.Close()

        If iErrFlag = False Then

            MessageBox.Show("Fetch ID's collecting complete. Success." & vbNewLine & " Found " & iFuncCounter & " events.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            SaveFileDialog.FileName = "ai_fetch_i.txt"
            If SaveFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then sFile = SaveFileDialog.FileName Else Exit Sub
            Dim outFile As System.IO.StreamWriter = New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Default, 1)

            outFile.WriteLine("// --------------------------")
            outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)")
            outFile.WriteLine("// AI Decompiler 'fetch_i' list")
            outFile.WriteLine("// updated: " & Now)
            outFile.WriteLine("// --------------------------")
            outFile.WriteLine("// format:")
            outFile.WriteLine("// fetch_i id|previous 'push_event // ' name|fetch name")

            '656|default|last_attacker
            '656|ON_START|myself

            For iTemp = 0 To (iFuncCounter - 1)
                sTemp = sFetchID(iTemp) & "|" & sFetchEventName(iTemp) & "|" & sFetchName(iTemp)
                outFile.WriteLine(sTemp)
            Next
            outFile.Close()

        End If

    End Sub



    Private Sub CollectHandlerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectHandlerButton.Click

        'handler 0 9	//  NO_DESIRE

        Dim sTemp As String  ', sFile As String = ""
        Dim aTemp() As String
        Dim iTemp As Integer = 0
        Dim iErrFlag As Boolean = False

        Dim sClassType As String = ""

        Dim sHandlerID(0) As String
        Dim sHandlerName(0) As String
        Dim sHandlerClassType(0) As String
        Dim iFuncCounter As Integer = 0

        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim inFile As System.IO.StreamReader = New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine()
            ProgressBar.Value = CInt(inFile.BaseStream.Position)
            sTemp = StrPrepare(sTemp)
            iTemp = iTemp + 1

            If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("class ") = True Then
                'class 1 default_npc : (null)
                aTemp = sTemp.Split(Chr(32))
                sClassType = aTemp(1)
            End If

RepeateRead:
            If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("handler ") = True Then
                aTemp = sTemp.Split(Chr(32))

                'handler(0) 0(1) 9(2)	//(3)  NO_DESIRE(4)
                If aTemp.Length < 3 Then
                    MessageBox.Show("Not found '//' in " & iTemp & " line." & vbNewLine & "Stream:" & sTemp, "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    iErrFlag = True
                    Exit While
                End If

                If Array.IndexOf(sHandlerName, aTemp(4)) = -1 Then

                    Array.Resize(sHandlerID, iFuncCounter + 1)
                    Array.Resize(sHandlerName, iFuncCounter + 1)
                    Array.Resize(sHandlerClassType, iFuncCounter + 1)

                    sHandlerID(iFuncCounter) = aTemp(1)
                    sHandlerName(iFuncCounter) = aTemp(4)
                    sHandlerClassType(iFuncCounter) = sClassType
                    iFuncCounter = iFuncCounter + 1

                End If

            End If

        End While

        ProgressBar.Value = 0
        inFile.Close()

        If iErrFlag = False Then

            MessageBox.Show("Handler's collecting complete. Success." & vbNewLine & " Found " & iFuncCounter & " handlers.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            SaveFileDialog.FileName = "ai_handlers.txt"
            If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            Dim outFile As System.IO.StreamWriter = New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Default, 1)

            outFile.WriteLine("// --------------------------")
            outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)")
            outFile.WriteLine("// AI Decompiler 'HANDLER' list")
            outFile.WriteLine("// updated: " & Now)
            outFile.WriteLine("// --------------------------")
            outFile.WriteLine("// format:")
            outFile.WriteLine("// handler id|specific class type (1,2)|handler name")

            '0|1|NO_DESIRE
            For iTemp = 0 To (iFuncCounter - 1)
                sTemp = sHandlerID(iTemp) & "|" & sHandlerClassType(iTemp) & "|" & sHandlerName(iTemp)
                outFile.WriteLine(sTemp)
            Next
            outFile.Close()

        End If

    End Sub

    Private Sub CollectFuncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectFuncButton.Click
        ' 	func_call 184680516	//  func[ShowPage]

        Dim sTemp As String, sFile As String = ""
        Dim aTemp() As String
        Dim iTemp As Integer = 0
        Dim iErrFlag As Boolean = False

        Dim sFuncID(0) As String
        Dim sFuncName(0) As String
        Dim sFuncOut(0) As String
        Dim iFuncCounter As Integer = 0

        If OpenFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then sFile = OpenFileDialog.FileName
        Dim inFile As System.IO.StreamReader = New System.IO.StreamReader(sFile, System.Text.Encoding.Default, True, 1)

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine()
            ProgressBar.Value = CInt(inFile.BaseStream.Position)
            sTemp = StrPrepare(sTemp)
            iTemp = iTemp + 1

RepeateRead:
            If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("func_call") = True Then
                aTemp = sTemp.Split(Chr(32))

                'func_call(0) 184680516(1)	//(2)  func[ShowPage](3)
                If aTemp.Length < 2 Then
                    MessageBox.Show("Not found '//' in " & iTemp & " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    iErrFlag = True
                    Exit While
                End If

                If Array.IndexOf(sFuncID, aTemp(1)) = -1 Then

                    aTemp(3) = aTemp(3).Replace("func[", "").Replace("]", "")

                    Array.Resize(sFuncID, iFuncCounter + 1)
                    Array.Resize(sFuncName, iFuncCounter + 1)
                    Array.Resize(sFuncOut, iFuncCounter + 1)

                    sFuncID(iFuncCounter) = aTemp(1)
                    sFuncName(iFuncCounter) = aTemp(3)
                    iFuncCounter = iFuncCounter + 1

                    sTemp = inFile.ReadLine()
                    ProgressBar.Value = CInt(inFile.BaseStream.Position)
                    iTemp = iTemp + 1
                    sTemp = StrPrepare(sTemp)

                    If sTemp <> "" And sTemp.StartsWith("//") = False Then
                        If sTemp.StartsWith("shift_sp") = True Then
                            'func_call 184745993	//  func[AddAttackDesire]
                            'shift_sp(0) -3(1)  - сброс входящих параметров
                            'shift_sp(0) -1(1)  - закрытие функции
                            ' если нет параметров, то сразу идёт -1
                            ' возможно за параметрами идёт другая функция, а закрытие идёт позже

                            aTemp = sTemp.Split(Chr(32))
                            sFuncOut(iFuncCounter - 1) = aTemp(1).Replace("-", "")
                        Else
                            sFuncOut(iFuncCounter - 1) = "0"
                            GoTo RepeateRead
                        End If
                    End If

                End If

            End If

        End While

        ProgressBar.Value = 0
        inFile.Close()

        If iErrFlag = False Then

            SaveFileDialog.FileName = "ai_functions.txt"
            If SaveFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then sFile = SaveFileDialog.FileName Else Exit Sub
            Dim outFile As System.IO.StreamWriter = New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Default, 1)

            outFile.WriteLine("// --------------------------")
            outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)")
            outFile.WriteLine("// AI Decompiler 'func_call' list")
            outFile.WriteLine("// updated: " & Now)
            outFile.WriteLine("// --------------------------")
            outFile.WriteLine("// format:")
            outFile.WriteLine("// func_id|name|incoming_params_value|output_params_value(nouse)")
            For iTemp = 0 To (iFuncCounter - 1)
                sTemp = sFuncID(iTemp) & "|" & sFuncName(iTemp) & "," & sFuncOut(iTemp) & ",0"
                outFile.WriteLine(sTemp)
            Next
            outFile.Close()

            MessageBox.Show("Function ID's collecting complete. Success." & vbNewLine & " Found " & iFuncCounter & " functions.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Function StrPrepare(ByVal Msg As String) As String

        Msg = Msg.Replace(Chr(9), Chr(32)).Replace("  ", " ").Trim
        While InStr(Msg, "  ") <> 0
            Msg = Msg.Replace("  ", " ")
        End While
        Return Msg

    End Function

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub


 

End Class
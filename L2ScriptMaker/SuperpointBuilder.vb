Public Class SuperpointBuilder

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sBinFile As String

        OpenFileDialog.Filter = "Superpoint.bin|Superpoint.bin|All Files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sBinFile = OpenFileDialog.FileName

        Dim inFile As New System.IO.StreamReader(sBinFile, System.Text.Encoding.GetEncoding(1250), False, 1)
        Dim outFile As New System.IO.StreamWriter(sBinFile + ".log", False, System.Text.Encoding.Unicode, 1)

        Dim sTempStr As String = ""
        Dim iTemp As Integer = 0, iTempSP As Integer, SuperPointsValue As Integer, PointsInSuperpoint As Integer

        SuperPointsValue = endian(4, inFile)
        outFile.WriteLine("Amount of Superpoints is: " & SuperPointsValue)

        For iTempSP = 1 To SuperPointsValue

            sTempStr = textread(4, inFile)

            outFile.WriteLine(vbNewLine & "[" & sTempStr & "]")
            outFile.WriteLine(endian(4, inFile))
            PointsInSuperpoint = endian(4, inFile)

            ' Normal mode
            outFile.WriteLine("Points in this superpoint: " & PointsInSuperpoint)

            For iTemp = 0 To PointsInSuperpoint - 1
                outFile.WriteLine("=================================")

                ' Normal mode
                outFile.Write("index:" & Chr(9) & endian(4, inFile) & ":" & Chr(9))
                outFile.Write(endian(4, inFile))
                outFile.Write(";" & endian(4, inFile))
                outFile.WriteLine(";" & endian(4, inFile))
                outFile.WriteLine("delay:" & Chr(9) & endian(4, inFile))

                ' Debug mode
                'outFile.WriteLine("index:" & " " & endian(4, inFile))
                'outFile.WriteLine("x:" & " " & endian(4, inFile))
                'outFile.WriteLine("y:" & " " & endian(4, inFile))
                'outFile.WriteLine("z:" & " " & endian(4, inFile))
                'outFile.WriteLine("delay:" & " " & endian(4, inFile))

            Next

            Dim iTemp2 As Integer, ConnMark As Integer
            ' Normal mode
            outFile.WriteLine(vbNewLine & "Connections:")

            For iTemp = 1 To CInt((PointsInSuperpoint ^ 2 - PointsInSuperpoint))
                ConnMark = CInt(endian(4, inFile))
                outFile.WriteLine("conn type:" & ConnMark)
                If ConnMark <> 0 Then
                    For iTemp2 = 1 To ConnMark
                        ' Normal mode
                        outFile.Write(" index: " & endian(4, inFile) & ":" & Chr(9))
                        outFile.Write(endian(4, inFile) & ";")
                        outFile.Write(endian(4, inFile) & ";")
                        outFile.Write(endian(4, inFile))
                        outFile.WriteLine("")

                        ' Debug mode
                        'endian(4, inFile)
                        'endian(4, inFile)
                        'endian(4, inFile)
                        'endian(4, inFile)
                    Next
                End If
            Next
        Next

        inFile.Close()
        outFile.Close()

        MessageBox.Show("Superpoint.bin research finished. Report wrote to " & sBinFile + ".log file.", "Complete", MessageBoxButtons.OK)

    End Sub


    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub


    Private Function endian(ByVal Bytes As Short, ByRef inFile As System.IO.StreamReader) As Integer
        Dim iByteRead As Integer
        Dim cReadBuff(Bytes - 1) As Byte
        Dim HexDigit As String = ""

        inFile.BaseStream.Read(cReadBuff, 0, Bytes)

        For iByteRead = (Bytes - 1) To 0 Step -1
            HexDigit = HexDigit & Hex(cReadBuff(iByteRead)).PadLeft(2, Convert.ToChar("0")).ToString
        Next

        If HexDigit = "FFFFFFFF" Then 'FFFEBE04
            endian = -1
        ElseIf HexDigit.StartsWith("FF") Then
            endian = CInt(Val("&h" & HexDigit))
        Else
            endian = CInt(CLng("&h" & HexDigit))
        End If

        'If cReadBuff(Bytes - 1) >= 8 And Bytes > 1 Then
        'endian = -((Not endian) + 1)
        'End If

        Return endian

    End Function

    Private Function unendian(ByVal Bytes As Integer, ByVal Value As Integer, ByRef outFile As System.IO.Stream) As Boolean

        Dim iTemp As Integer
        Dim aMsgByte(Bytes - 1) As Byte

        If Value = -1 Then
            aMsgByte(0) = 255
            aMsgByte(1) = 255
            aMsgByte(2) = 255
            aMsgByte(3) = 255
            outFile.Write(aMsgByte, 0, 4)
            Return True
        End If

        'If Value = 51462 Then Dim asds As Integer = 1281

        Dim sTemp As String = Hex(Value)
        sTemp = sTemp.PadLeft(Bytes * 2, Convert.ToChar("0"))

        For iTemp = 0 To Bytes - 1
            'Dim aaa As String = "&H" & Mid(sTemp, (Bytes * 2 - iTemp * 2) - 1, 2)
            'Dim aaass As Integer = CInt("&H" & Mid(sTemp, (Bytes * 2 - iTemp * 2) - 1, 2))
            'Dim aaass2 As Char = Convert.ToChar(CInt("&H" & Mid(sTemp, (Bytes * 2 - iTemp * 2) - 1, 2)))

            aMsgByte(iTemp) = CByte(Val("&H" & Mid(sTemp, (Bytes * 2 - iTemp * 2) - 1, 2)))

        Next
        outFile.Write(aMsgByte, 0, Bytes)
        Return True

    End Function


    Private Function textread(ByVal Bytes As Short, ByRef iFile As System.IO.StreamReader) As String

        Dim TempStr As String = ""
        Dim iByteRead As Integer, iTemp As Integer
        Dim cReadBuff(1) As Char

        Dim bReadBuff2(1) As Byte

        iByteRead = endian(Bytes, iFile)
        If iByteRead = 0 Then Return ""


        For iTemp = 0 To iByteRead - 1
            iFile.BaseStream.Read(bReadBuff2, 0, 2)
            TempStr = TempStr & Chr(bReadBuff2(0))
        Next

        Return TempStr
    End Function

    Private Function textwrite(ByVal Message As String, ByRef outFile As System.IO.Stream) As Boolean

        Dim iTemp As Integer
        Dim aMsgByte(0) As Byte

        unendian(4, Message.Length, outFile)
        If Message <> "" Then
            For iTemp = 0 To Message.Length - 1
                Array.Resize(aMsgByte, Message.Length * 2)
                aMsgByte(iTemp * 2) = CByte(Asc(Message(iTemp)))
                aMsgByte(iTemp * 2 + 1) = 0
            Next
        End If
        ' Zero end of string
        'aMsgByte(iTemp * 2) = Chr(0)
        outFile.Write(aMsgByte, 0, Message.Length * 2)

        Return True

    End Function

    Private Sub GenerateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateButton.Click

        Dim sBinFile As String

        OpenFileDialog.Filter = "Superpoint.bin.log|Superpoint.bin.log|All Files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sBinFile = OpenFileDialog.FileName

        'If System.IO.File.Exists(sBinFile + ".bin") = True Then
        'If MessageBox.Show("Output file exist. Overwrite?", "Exist file", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
        'System.IO.File.Delete(sBinFile + ".bin")
        'End If

        Dim inFile As New System.IO.StreamReader(sBinFile, System.Text.Encoding.Default, True, 1)
        'Dim outFile As New System.IO.StreamWriter(sBinFile + ".bin", False, System.Text.Encoding.GetEncoding(1250), 1)

        'FOR Release 
        sBinFile = sBinFile.Replace(".bin.log", ".bin")
        Dim outFile As System.IO.Stream = New System.IO.FileStream(sBinFile, _
        IO.FileMode.Create, IO.FileAccess.ReadWrite)
        'Dim outFile As System.IO.StreamWriter = New System.IO.StreamWriter(outFil)

        Dim sTemp As String = ""
        Dim iTemp As Integer, aTemp(2) As String ', iTempSP As Integer, SuperPointsValue As Integer, PointsInSuperpoint As Integer

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Replace(" ", "").Replace(Chr(9), "")

            If InStr(sTemp, "Superpoints") <> 0 Then
                'Superpoints: 16
                iTemp = CInt(sTemp.Remove(0, InStr(sTemp, ":")).Trim)
                unendian(4, iTemp, outFile)        ' full amount in superpoint.bin
            End If

            If InStr(sTemp, "[") <> 0 Then
                '[scribe_leandro]
                textwrite(sTemp.Replace("[", "").Replace("]", "").Trim, outFile)     ' name of superpoint
                unendian(4, 0, outFile)         ' unknown param
            End If

            If InStr(sTemp, "Points") <> 0 Then
                'Points in this superpoint:	11
                iTemp = CInt(sTemp.Remove(0, InStr(sTemp, ":")).Trim)
                unendian(4, iTemp, outFile)        ' full amount in superpoint.bin
            End If

            If InStr(sTemp, "index:") <> 0 Then
                'index:	0:	-82428;245204;-3712
                aTemp = sTemp.Split(CChar(":"))
                unendian(4, CInt(aTemp(1)), outFile)    ' index number
                aTemp = aTemp(2).Split(CChar(";"))
                unendian(4, CInt(aTemp(0)), outFile)    ' x
                unendian(4, CInt(aTemp(1)), outFile)    ' y
                unendian(4, CInt(aTemp(2)), outFile)    ' z
            End If

            If InStr(sTemp, "delay:") <> 0 Then
                'Points in this superpoint:	11
                iTemp = CInt(sTemp.Remove(0, InStr(sTemp, ":")).Trim)
                unendian(4, iTemp, outFile)        ' delay
            End If

            If InStr(sTemp, "conntype:") <> 0 Then
                'conn type:2
                iTemp = CInt(sTemp.Remove(0, InStr(sTemp, ":")).Trim)
                unendian(4, iTemp, outFile)        ' conn type
            End If


        End While

        inFile.Close()
        outFile.Close()

        MessageBox.Show("New Superpoint.bin has been created in '" & sBinFile + "' file.", "Complete", MessageBoxButtons.OK)


    End Sub

    Private Sub MakeNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeNewButton.Click

        Dim iTemp As Integer
        'dim sTemp as String

        '[scribe_leandro]
        '0
        'Points in this superpoint: 11
        '=================================
        'index:	0:	-82428;245204;-3712
        'delay:	0

        If (DataGridView.RowCount - 2) < 1 Then
            MessageBox.Show("SuperPath cant be generate from 1 point. Need enter more them 1 point and try again", "Need more points", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If StartNumberTextBox.Text = "" Then
            MessageBox.Show("Invalid start point number. Try correct number and try again.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim Counter As Integer = CInt(StartNumberTextBox.Text)

        If NpcNameTextBox.Text = "" Then
            MessageBox.Show("Invalid npc name. Try correct name and try again.", "Invalid npc name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If NpcNameTextBox.Text.StartsWith("[") = False Then
            NpcNameTextBox.Text = "[" & NpcNameTextBox.Text & "]"
        End If

        MakeNewTextBox.Text = ""
        MakeNewTextBox.AppendText(NpcNameTextBox.Text & vbNewLine)
        MakeNewTextBox.AppendText("0" & vbNewLine)
        MakeNewTextBox.AppendText("Points in this superpoint: " & (DataGridView.RowCount - 1).ToString & vbNewLine)

        Dim PointList(DataGridView.RowCount - 2) As String
        For iTemp = 0 To DataGridView.RowCount - 2

            MakeNewTextBox.AppendText("=================================" & vbNewLine)
            If DataGridView.Item(0, iTemp).Value Is Nothing Then
                MessageBox.Show("Bad value! in 1;" & iTemp & " cell")
                Exit Sub
            End If
            If DataGridView.Item(1, iTemp).Value Is Nothing Then
                MessageBox.Show("Bad value! in 2;" & iTemp & " cell")
                Exit Sub
            End If
            If DataGridView.Item(2, iTemp).Value Is Nothing Then
                MessageBox.Show("Bad value! in 3;" & iTemp & " cell")
                Exit Sub
            End If
            If DataGridView.Item(3, iTemp).Value Is Nothing Then
                DataGridView.Item(3, iTemp).Value = "0"
            End If

            PointList(iTemp) = DataGridView.Item(0, iTemp).Value.ToString & ";" & DataGridView.Item(1, iTemp).Value.ToString & ";" & DataGridView.Item(2, iTemp).Value.ToString

            'MakeNewTextBox.AppendText("index:" & vbTab & (Counter + iTemp) & vbTab & _
            'DataGridView.Item(0, iTemp).Value.ToString & ";" & DataGridView.Item(1, iTemp).Value.ToString & ";" & _
            'DataGridView.Item(2, iTemp).Value.ToString & vbNewLine)
            MakeNewTextBox.AppendText("index:" & vbTab & (Counter + iTemp) & ":" & vbTab & PointList(iTemp) & vbNewLine)
            MakeNewTextBox.AppendText("delay:" & vbTab & DataGridView.Item(3, iTemp).Value.ToString & vbNewLine)
        Next

        'Connections:
        MakeNewTextBox.AppendText(vbNewLine & "Connections:" & vbNewLine)
        'conn type:2 --------------------------------> Connection: 11 - 12 (Note: 11 - 11 Never)
        ' index: 11: -81926;243894;-3712
        ' index: 12: -82134;243600;-3728
        'conn type:0 --------------------------------> Connection: 11 - 13
        Dim iTemp2 As Integer
        For iTemp = 0 To DataGridView.RowCount - 2
            For iTemp2 = 0 To DataGridView.RowCount - 2
                If iTemp <> iTemp2 Then

                    If (iTemp2 = iTemp - 1) Or (iTemp2 = iTemp + 1) Then
                        MakeNewTextBox.AppendText("conn type:2" & vbNewLine)
                        If (iTemp2 = iTemp - 1) Then
                            MakeNewTextBox.AppendText(" index:" & vbTab & (Counter + iTemp) & ":" & vbTab & PointList(iTemp) & vbNewLine)
                            MakeNewTextBox.AppendText(" index:" & vbTab & (Counter + iTemp - 1) & ":" & vbTab & PointList(iTemp - 1) & vbNewLine)
                        Else
                            MakeNewTextBox.AppendText(" index:" & vbTab & (Counter + iTemp) & ":" & vbTab & PointList(iTemp) & vbNewLine)
                            MakeNewTextBox.AppendText(" index:" & vbTab & (Counter + iTemp + 1) & ":" & vbTab & PointList(iTemp + 1) & vbNewLine)
                        End If

                    Else
                        If GenAllCheckBox.Checked = False Then
                            MakeNewTextBox.AppendText("conn type:0" & vbNewLine)
                        Else

                            If iTemp2 < (DataGridView.RowCount - 1) Then
                                MakeNewTextBox.AppendText("conn type:2" & vbNewLine)
                                MakeNewTextBox.AppendText(" index:" & vbTab & (Counter + iTemp) & ":" & vbTab & PointList(iTemp) & vbNewLine)
                                MakeNewTextBox.AppendText(" index:" & vbTab & (Counter + iTemp2) & ":" & vbTab & PointList(iTemp2) & vbNewLine)
                            End If

                        End If
                    End If

                End If
            Next
        Next

        TabControl1.SelectedIndex = 4 ' "Result"

    End Sub

    Private Sub LoadPointsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPointsButton.Click

        DataGridView.Rows.Clear()

        Dim iTemp As Integer
        Dim sTemp As String
        Dim aTemp(2) As String

        Dim Counter As Integer = -1

        'index:	0:	-82428;245204;-3712
        'delay:	0

        'NpcNameTextBox.Text
        'StartNumberTextBox.Text

        For iTemp = 0 To ImportPointsTextBox.Lines.Length - 1

            sTemp = ImportPointsTextBox.Lines.GetValue(iTemp).ToString

            If sTemp.StartsWith("[") Then
                NpcNameTextBox.Text = sTemp
            End If

            If sTemp.StartsWith("index:") Then


                sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
                Counter += 1
                DataGridView.Rows.Add()

                'Loading points
                aTemp = sTemp.Split(CChar(":"))

                If Counter = 0 Then StartNumberTextBox.Text = aTemp(1)

                aTemp = aTemp(2).Split(CChar(";"))
                DataGridView.Item(0, Counter).Value = aTemp(0)
                DataGridView.Item(1, Counter).Value = aTemp(1)
                DataGridView.Item(2, Counter).Value = aTemp(2)

                'Loading delay
                sTemp = ImportPointsTextBox.Lines.GetValue(iTemp + 1).ToString.Replace(" ", "").Replace(Chr(9), "")
                aTemp = sTemp.Split(CChar(":"))

                DataGridView.Item(3, Counter).Value = aTemp(1)

                iTemp += 1

            End If


        Next

        TabControl1.SelectedIndex = 2 ' "SettingTabPage"

    End Sub
End Class
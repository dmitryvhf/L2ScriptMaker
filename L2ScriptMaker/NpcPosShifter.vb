Public Class NpcPosShifter

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim PosFile As String

        Dim XS As Integer, YS As Integer, ZS As Integer

        XS = CInt(Val(XShift.Text.ToString))
        YS = CInt(Val(YShift.Text.ToString))
        ZS = CInt(Val(ZShift.Text.ToString))
        If MessageBox.Show("You sure start conversion use this shifting for:" & vbNewLine & "X: " & XS & " | Y: " & YS & " |Z: " & ZS, "Confirm start", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub

        OpenFileDialog.Title = "Select Lineage II npcpos file"
        OpenFileDialog.Filter = "Lineage II npcpos file|npcpos.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        PosFile = OpenFileDialog.FileName

        Dim inFile As New System.IO.StreamReader(PosFile)
        Dim outFile As New System.IO.StreamWriter(PosFile & ".new.txt", False, System.Text.Encoding.Unicode)

        Dim TempRead As String

        Dim locArr(5) As String
        Dim Pos1 As Integer, Pos2 As Integer

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)

        While inFile.EndOfStream <> True

            TempRead = inFile.ReadLine
            ProgressBar.Value = CInt(inFile.BaseStream.Position)

            While InStr(TempRead, "  ") <> 0
                TempRead = TempRead.Replace("  ", " ")
            End While
            TempRead = TempRead.Replace(" = ", "=")
            TempRead = TempRead.Replace(" ", Chr(9))

            Dim LastMarker As Integer


            If TempRead.Length > 1 Then

                If InStr(TempRead, "pos=") <> 0 Then
                    LastMarker = InStr(InStr(TempRead, "pos=") + 5, TempRead, Chr(9))
                Else
                    LastMarker = TempRead.Length
                End If

                'find end of pos

                Pos1 = 1

                While InStr(Pos1, TempRead, "{", CompareMethod.Text) <> 0

                    Pos1 = InStr(Pos1 + 1, TempRead, "{", CompareMethod.Text)
                    If TempRead(Pos1) = "{" Then
                        Pos1 += 1
                    End If
                    Pos2 = InStr(Pos1, TempRead, "}", CompareMethod.Text)

                    If Pos1 > LastMarker Then Exit While

                    locArr = Mid(TempRead, Pos1 + 1, Pos2 - Pos1 - 1).Split(Chr(59))  ' 59 - ;

                    Dim NewValue As String
                    NewValue = (CInt(locArr(0)) + XS).ToString & ";" & (CInt(locArr(1)) + YS).ToString & ";" & (CInt(locArr(2)) + ZS).ToString & ";" & locArr(3)
                    If locArr.Length > 4 Then
                        NewValue = NewValue & ";" & locArr(4)
                    End If

                    TempRead = TempRead.Replace(Mid(TempRead, Pos1 + 1, Pos2 - Pos1 - 1), NewValue)

                    Pos1 += 1
                    Array.Clear(locArr, 0, locArr.Length)
                End While

            End If

            outFile.WriteLine(TempRead)
            'If Pos1 > LastMarker Then Exit While

        End While

        inFile.Close()
        outFile.Close()

        MessageBox.Show("Done.")


    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Close()
    End Sub

End Class
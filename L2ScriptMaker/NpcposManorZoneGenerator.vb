Public Class NpcposManorZoneGenerator

    Private Structure GeoMinMax
        Dim XMin As Integer
        Dim XMax As Integer
        Dim YMin As Integer
        Dim YMax As Integer
        Dim ZMin As Integer ' lower then max -3900
        Dim ZMax As Integer ' more then min +2000
        Dim Castle As String
        Dim CastleId As Integer
    End Structure

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim iTemp As Integer, iTemp1 As Integer, iTemp2 As Integer, iDomain As Short
        Dim LocationFix As Integer = CInt(SafeRangeTextBox.Text)   ' Fix for range to inside for bug fixing with zone links

        Dim Geos(26, 26) As GeoMinMax

        If DataGridView.Rows.Count = 1 Then
            MessageBox.Show("You need define location and castle for each location before processing.", "Wrong definition", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        OpenFileDialog.FileName = "npcpos.txt"
        If MetodCheckBox.Checked = True Then
            OpenFileDialog.Filter = "Lineage II Server npc spawn config (npcpos.txt)|npcpos*.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If

        SaveFileDialog.FileName = System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog.FileName) & "_manor_zone.txt"
        SaveFileDialog.Filter = "Lineage II Server npc spawn config (npcpos.txt)|npcpos*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub


        ' Loading Castle Names control location (set castle id to each location)
        For iTemp = 0 To DataGridView.Rows.Count - 2
            Geos(CInt(DataGridView.Item(0, iTemp).Value), CInt(DataGridView.Item(1, iTemp).Value)).Castle = CStr(DataGridView.Item(2, iTemp).Value)
            Geos(CInt(DataGridView.Item(0, iTemp).Value), CInt(DataGridView.Item(1, iTemp).Value)).CastleId = CastleName.Items.IndexOf(CStr(DataGridView.Item(2, iTemp).Value)) + 1
            If MetodCheckBox.Checked = False Then
                ' SIMPLE METOD
                Geos(CInt(DataGridView.Item(0, iTemp).Value), CInt(DataGridView.Item(1, iTemp).Value)).XMin = (CInt(DataGridView.Item(0, iTemp).Value) - 20) * 32768 + LocationFix
                Geos(CInt(DataGridView.Item(0, iTemp).Value), CInt(DataGridView.Item(1, iTemp).Value)).XMax = (CInt(DataGridView.Item(0, iTemp).Value) - 19) * 32768 - LocationFix
                Geos(CInt(DataGridView.Item(0, iTemp).Value), CInt(DataGridView.Item(1, iTemp).Value)).YMin = (CInt(DataGridView.Item(1, iTemp).Value) - 18) * 32768 + LocationFix
                Geos(CInt(DataGridView.Item(0, iTemp).Value), CInt(DataGridView.Item(1, iTemp).Value)).YMax = (CInt(DataGridView.Item(1, iTemp).Value) - 17) * 32768 - LocationFix
                Geos(CInt(DataGridView.Item(0, iTemp).Value), CInt(DataGridView.Item(1, iTemp).Value)).ZMin = 2500
                Geos(CInt(DataGridView.Item(0, iTemp).Value), CInt(DataGridView.Item(1, iTemp).Value)).ZMax = -2500
            End If
        Next

        If MetodCheckBox.Checked = False Then

            ' SIMPLE METOD
            ' Already generated in Loading block

        Else
            ' USE NPCPOS METOD

            ' Definition min, max to center location
            For iTemp1 = 16 To 26
                For iTemp2 = 10 To 26
                    Geos(iTemp1, iTemp2).XMin = (iTemp1 - 20) * 32768 + 16384
                    Geos(iTemp1, iTemp2).XMax = (iTemp1 - 19) * 32768 - 16384
                    Geos(iTemp1, iTemp2).YMin = (iTemp2 - 18) * 32768 + 16384
                    Geos(iTemp1, iTemp2).YMax = (iTemp2 - 17) * 32768 - 16384
                    'Geos(iTemp1, iTemp2).ZMin = 0
                    'Geos(iTemp1, iTemp2).ZMax = 0
                Next
            Next

            Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
            Dim sTemp As String
            Dim aTemp1() As String, aTemp2() As String
            Dim LocX As Integer, LocY As Integer

            Dim iTempZ As Integer

            ToolStripProgressBar.Value = 0
            ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
            While inFile.EndOfStream <> True

                sTemp = inFile.ReadLine
                ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

                If sTemp.StartsWith("territory_begin") = True Then

                    sTemp = sTemp.Remove(0, InStr(sTemp, "{") - 1)
                    sTemp = sTemp.Replace("territory_end", "").Trim
                    sTemp = sTemp.Replace("};{", "|").Replace("{", "").Replace("}", "")
                    aTemp1 = sTemp.Split(CChar("|"))

                    For iTemp2 = 0 To aTemp1.Length - 1

                        aTemp2 = aTemp1(iTemp2).Split(CChar(";"))

                        ' Define location name
                        LocX = CInt(Fix(20 + (CInt(aTemp2(0)) - CInt(aTemp2(0)) \ 32768) / 32768))
                        LocY = CInt(Fix(18 + (CInt(aTemp2(1)) - CInt(aTemp2(1)) \ 32768) / 32768))

                        ' Check each value
                        If Geos(LocX, LocY).XMin > CInt(aTemp2(0)) Then Geos(LocX, LocY).XMin = CInt(aTemp2(0))
                        If Geos(LocX, LocY).XMax < CInt(aTemp2(0)) Then Geos(LocX, LocY).XMax = CInt(aTemp2(0))
                        If Geos(LocX, LocY).YMin > CInt(aTemp2(1)) Then Geos(LocX, LocY).YMin = CInt(aTemp2(1))
                        If Geos(LocX, LocY).YMax < CInt(aTemp2(1)) Then Geos(LocX, LocY).YMax = CInt(aTemp2(1))

                        If Geos(LocX, LocY).ZMin = 0 And Geos(LocX, LocY).ZMax = 0 Then
                            Geos(LocX, LocY).ZMin = CInt(aTemp2(2))
                            Geos(LocX, LocY).ZMax = CInt(aTemp2(3))
                        End If

                        ' Fix for MinZ > MaxZ
                        If CInt(aTemp2(2)) > CInt(aTemp2(3)) Then
                            iTempZ = CInt(aTemp2(2))
                            aTemp2(2) = aTemp2(3)
                            aTemp2(3) = CStr(iTempZ)
                        End If
                        If CInt(aTemp2(2)) < Geos(LocX, LocY).ZMin Then Geos(LocX, LocY).ZMin = CInt(aTemp2(2))
                        If CInt(aTemp2(3)) > Geos(LocX, LocY).ZMax Then Geos(LocX, LocY).ZMax = CInt(aTemp2(3))
                        ''Else
                        ' No castle control in this location or not definitions for this location for anyone castle
                        ''End If

                    Next

                End If

            End While
            inFile.Close()
            ToolStripProgressBar.Value = 0

        End If


        ' ---- Generation Manor Zone file ----
        Dim outFile As New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Unicode, 1)

        Dim doUnknown As Short = 1

        If DoUnknownCheckBox.Checked = True And MetodCheckBox.Checked = True Then
            doUnknown = 0
        End If

        ' No use shifts for Autogen file (no use npcpos).
        If MetodCheckBox.Checked = False Then LocationFix = 0

        outFile.WriteLine("// Castle Manor domain generated by L2SciptMaker at " & Now.ToString)
        For iDomain = doUnknown To 9

            If iDomain > 0 Then outFile.WriteLine("// " & CastleName.Items.Item(iDomain - 1).ToString & " manor domain")

            For iTemp = 16 To 26        ' X
                For iTemp2 = 10 To 26   ' Y

                    If Geos(iTemp, iTemp2).CastleId = iDomain Then

                        If Geos(iTemp, iTemp2).XMin <> Geos(iTemp, iTemp2).XMax Then
                            'domain_begin	[schtgart_2311_001]	domain_id=9	{{98560;-228352;-4672;816};{130816;-228480;-4672;816};{130944;-196736;-4672;816};{98816;-196736;-4672;816}}	domain_end
                            outFile.Write("domain_begin" & vbTab)

                            If iDomain = 0 Then
                                outFile.Write("[location" & "_" & iTemp & iTemp2 & "_001]" & vbTab)
                            Else
                                outFile.Write("[" & Geos(iTemp, iTemp2).Castle.ToLower & "_" & iTemp & iTemp2 & "_001]" & vbTab)
                            End If
                            outFile.Write("domain_id=" & iDomain & vbTab)
                            outFile.Write("{")
                            outFile.Write("{" & Geos(iTemp, iTemp2).XMin - LocationFix & ";" & Geos(iTemp, iTemp2).YMin - LocationFix & ";" & Geos(iTemp, iTemp2).ZMin & ";" & Geos(iTemp, iTemp2).ZMax & "};")
                            outFile.Write("{" & Geos(iTemp, iTemp2).XMax + LocationFix & ";" & Geos(iTemp, iTemp2).YMin - LocationFix & ";" & Geos(iTemp, iTemp2).ZMin & ";" & Geos(iTemp, iTemp2).ZMax & "};")
                            outFile.Write("{" & Geos(iTemp, iTemp2).XMax + LocationFix & ";" & Geos(iTemp, iTemp2).YMax + LocationFix & ";" & Geos(iTemp, iTemp2).ZMin & ";" & Geos(iTemp, iTemp2).ZMax & "};")
                            outFile.Write("{" & Geos(iTemp, iTemp2).XMin - LocationFix & ";" & Geos(iTemp, iTemp2).YMax + LocationFix & ";" & Geos(iTemp, iTemp2).ZMin & ";" & Geos(iTemp, iTemp2).ZMax & "}")
                            outFile.Write("}" & vbTab)
                            outFile.Write("domain_end")

                            If (Geos(iTemp, iTemp2).ZMax - Geos(iTemp, iTemp2).ZMin) * Math.Sign(Geos(iTemp, iTemp2).ZMax - Geos(iTemp, iTemp2).ZMin) > 6000 Then
                                outFile.Write(vbTab & "// Foung big Z range (more then 6000). Required Z splitting.")
                            End If
                            outFile.WriteLine()
                        End If

                    End If
                Next

            Next
        Next
        outFile.Close()
        ' ---- END OF Generation Manor Zone file ----

        MessageBox.Show("done")

        'GeonameXTextBox.Text = CStr(Fix(20 + (CInt(XTextBox.Text) - CInt(XTextBox.Text) \ 32768) / 32768))
        'GeonameYTextBox.Text = CStr(Fix(18 + (CInt(YTextBox.Text) - CInt(YTextBox.Text) \ 32768) / 32768))
        '$geo_x=20+($game_x-$game_x%32768)/32768; 
        '$geo_y=18+($game_y-$game_y%32768)/32768;

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

    Private Sub LoadCastleControlButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCastleControlButton.Click

        OpenFileDialog.Filter = "Manor Castle Control Locations config|*.ini|All files|*.*"
        'OpenFileDialog.FileName = "manor_castle_control_locations.ini"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim sTemp As String
        Dim iTemp As Integer
        Dim aTemp(3) As String

        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        If inFile.ReadLine <> "[L2ScriptMaker: Manor Castle Control Locations config]" Then
            MessageBox.Show("This is not configuration file", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            inFile.Close()
            Exit Sub
        End If

        DataGridView.Rows.Clear()

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                aTemp = sTemp.Split(CChar(","))
                Try
                    iTemp = CInt(aTemp(0))
                    If iTemp = 0 Then Error 1
                    iTemp = CInt(aTemp(1))
                    If iTemp = 0 Then Error 2
                Catch ex As Exception
                    MessageBox.Show("Wrong definition for location id. " & ex.Message, "Wrong geo definition", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inFile.Close()
                    Exit Sub
                End Try
                If CastleName.Items.IndexOf(aTemp(2)) = -1 Then
                    MessageBox.Show("Invalid Castle Town name. Check available names in checkbox, fix config and try again", "Invalid Castle Town name", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inFile.Close()
                    Exit Sub
                End If
                DataGridView.Rows.Add(aTemp(0), aTemp(1), aTemp(2))

            End If

        End While
        inFile.Close()

    End Sub

    Private Sub SafeRangeTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SafeRangeTextBox.Validated
        Try
            SafeRangeTextBox.Text = CStr(CInt(SafeRangeTextBox.Text))
        Catch ex As Exception
            SafeRangeTextBox.Text = "2000"
        End Try
    End Sub
End Class
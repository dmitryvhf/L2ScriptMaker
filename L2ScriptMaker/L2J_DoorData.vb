Public Class L2J_DoorData

    Private Structure doordata

        ' door_begin	[olympiad_door_154]	type=normal_type	editor_id=15120021	open_method=by_npc	close_time=600	height=150	hp=3258432	hp_showable=0	physical_defence=100000	pos={-145946;-181419;-3341}	range={{-145957;-181547;-3341};{-145932;-181547;-3341};{-145932;-181292;-3341};{-145956;-181292;-3341}}	default_status=close	door_end
        Dim id As String            ' editor_id
        Dim name As String          ' [olympiad_door_154]
        Dim open_method As String   ' open_method
        Dim height As UInteger      ' height=150
        Dim hp As String          ' hp=3258432
        Dim physical_defence As String    ' physical_defence=100000
        Dim magical_defence As String     ' magical_defence=518
        Dim pos As String           ' pos={-145946;-181419;-3341}
        Dim posx As Integer
        Dim posy As Integer
        Dim posz As Integer
        Dim range As String         ' range={{-145957;-181547;-3341};{-145932;-181547;-3341};{-145932;-181292;-3341};{-145956;-181292;-3341}}
        Dim range_minx As Integer
        Dim range_miny As Integer
        Dim range_minz As Integer
        Dim range_maxx As Integer
        Dim range_maxy As Integer
        Dim range_maxz As Integer

    End Structure

    Private Sub ButtonPTS2L2J_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPTS2L2J.Click

        Dim sTemp As String
        Dim iTemp As UInteger

        Dim inFile As System.IO.StreamReader
        Dim outFile As System.IO.StreamWriter
        Dim outFile2 As System.IO.StreamWriter

        Dim aTemp() As String, aTemp2() As String
        Dim aDoor(1) As doordata

       ' LOADING itemdata-e.txt
        If System.IO.File.Exists("doordata.txt") = False Then
            MessageBox.Show("doordata.txt not found", "Need doordata.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        inFile = New System.IO.StreamReader("doordata.txt", System.Text.Encoding.Default, True, 1)
        outFile = New System.IO.StreamWriter("_doordata.sql", False, System.Text.Encoding.Default, 1)
        outFile2 = New System.IO.StreamWriter("_doordata_pos_update.sql", False, System.Text.Encoding.Default, 1)

        outFile.WriteLine("------------------------------------------------------")
        outFile.WriteLine("-- Script for INSERT doors for door storaged in DB")
        outFile.WriteLine("-- USE DB: fort_staticobjects")
        outFile.WriteLine("------------------------------------------------------")
        outFile.WriteLine("INSERT INTO `fort_staticobjects` VALUES")
        
        outFile2.WriteLine("------------------------------------------------------")
        outFile2.WriteLine("-- Script for UPDATE positions for door storaged in DB")
        outFile2.WriteLine("-- USE DB: castle_door, fort_staticobjects")
        outFile2.WriteLine("------------------------------------------------------")

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading doordata.txt ..."

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp.StartsWith("door_begin") = False Then Continue While

            aTemp = sTemp.Split(Chr(9))

            '' door_begin	[olympiad_door_154]	type=normal_type	editor_id=15120021	open_method=by_npc	close_time=600	height=150	hp=3258432	hp_showable=0	physical_defence=100000	pos={-145946;-181419;-3341}	range={{-145957;-181547;-3341};{-145932;-181547;-3341};{-145932;-181292;-3341};{-145956;-181292;-3341}}	default_status=close	door_end
            'Dim id As String            ' editor_id
            'Dim name As String          ' [olympiad_door_154]
            'Dim open_method As String   ' open_method
            'Dim height As UInteger      ' height=150
            'Dim hp As UInteger          ' hp=3258432
            'Dim physical_defence As UInteger    ' physical_defence=100000
            'Dim magical_defence As UInteger     ' magical_defence=518	
            'Dim pos As String           ' pos={-145946;-181419;-3341}	
            'Dim range As String         ' range={{-145957;-181547;-3341};{-145932;-181547;-3341};{-145932;-181292;-3341};{-145956;-181292;-3341}}

            If Libraries.GetNeedParamFromStr(sTemp, "type") <> "normal_type" Then Continue While ' normal_type parent_type wall_type

            aDoor(0).id = Libraries.GetNeedParamFromStr(sTemp, "editor_id") '.Replace("[", "").Replace("]", "")
            aDoor(0).name = aTemp(1).Replace("[", "").Replace("]", "")
            aDoor(0).open_method = Libraries.GetNeedParamFromStr(sTemp, "open_method")
            Select Case aDoor(0).open_method
                Case "by_npc"
                    aDoor(0).open_method = "false"
                Case "by_click"
                    aDoor(0).open_method = "true"
                    'Case "by_item"
                    '    Continue While
                Case Else
                    ' by_item, by_skill, by_time, by_time_skill
                    aDoor(0).open_method = "false"
            End Select
            aDoor(0).height = CUInt(Val(Libraries.GetNeedParamFromStr(sTemp, "height")))
            aDoor(0).hp = Libraries.GetNeedParamFromStr(sTemp, "hp")
            aDoor(0).physical_defence = Libraries.GetNeedParamFromStr(sTemp, "physical_defence")
            If aDoor(0).physical_defence = "" Then aDoor(0).physical_defence = "0"
            aDoor(0).magical_defence = Libraries.GetNeedParamFromStr(sTemp, "magical_defence")
            If aDoor(0).magical_defence = "" Then aDoor(0).magical_defence = "0"
            aDoor(0).pos = Libraries.GetNeedParamFromStr(sTemp, "pos")

            aTemp = aDoor(0).pos.Replace("{", "").Replace("}", "").Split(CChar(";"))
            aDoor(0).posx = CInt(aTemp(0))
            aDoor(0).posy = CInt(aTemp(1))
            aDoor(0).posz = CInt(aTemp(2))

            aDoor(0).range = Libraries.GetNeedParamFromStr(sTemp, "range")
            If aDoor(0).range = "" Then Continue While
            aDoor(0).range = aDoor(0).range.Replace("};{", "|").Replace("{", "").Replace("}", "")
            aTemp = aDoor(0).range.Split(CChar("|"))

            For iTemp = 0 To CUInt(aTemp.Length - 1)
                aTemp2 = aTemp(CInt(iTemp)).Split(CChar(";"))
                If iTemp = 0 Then
                    aDoor(0).range_minx = CInt(aTemp2(0))
                    aDoor(0).range_miny = CInt(aTemp2(0))
                    aDoor(0).range_minz = CInt(aTemp2(1))
                    aDoor(0).range_maxx = CInt(aTemp2(0))
                    aDoor(0).range_maxy = CInt(aTemp2(1))
                    aDoor(0).range_maxz = CInt(aTemp2(2)) + CInt(aDoor(0).height)
                End If

                If CInt(aTemp2(0)) < aDoor(0).range_minx Then aDoor(0).range_minx = CInt(aTemp2(0))
                If CInt(aTemp2(1)) < aDoor(0).range_miny Then aDoor(0).range_miny = CInt(aTemp2(1))
                If CInt(aTemp2(2)) < aDoor(0).range_minz Then aDoor(0).range_minz = CInt(aTemp2(2))
                If CInt(aTemp2(0)) > aDoor(0).range_maxx Then aDoor(0).range_maxx = CInt(aTemp2(0))
                If CInt(aTemp2(1)) > aDoor(0).range_maxy Then aDoor(0).range_maxy = CInt(aTemp2(1))
                If CInt(aTemp2(2)) > aDoor(0).range_maxz Then aDoor(0).range_maxz = CInt(aTemp2(2))

            Next

            ' ----------------
            ' fort_staticobjects.sql 
            ' ----------------
            '(113,18200001,'Fort Gate',-54247,89585,-2870,0,0,0,0,0,0,203652,644,518,'false','false',0),

            '(113,      18200001,'Fort Gate',           -54247,89585,-2870,0,0,0,0,0,0,203652,644,518,'false','false',0),
            '(fort_id,  18200001,'fortress_1820_001',   -54247,89585,-2870,0,0,0,0,0,0,169710,644,518,'false','false',0),


            '  `fortId` tinyint(3) unsigned NOT NULL DEFAULT '0',   - 1
            '  `id` int(8) unsigned NOT NULL DEFAULT '0',           - 2
            '  `name` varchar(30) NOT NULL,                         - 3
            '  `x` mediumint(6) NOT NULL DEFAULT '0',               - 4
            '  `y` mediumint(6) NOT NULL DEFAULT '0',               - 5
            '  `z` mediumint(6) NOT NULL DEFAULT '0',               - 6
            '  `range_xmin` mediumint(6) NOT NULL DEFAULT '0',      - 7
            '  `range_ymin` mediumint(6) NOT NULL DEFAULT '0',      - 8
            '  `range_zmin` mediumint(6) NOT NULL DEFAULT '0',      - 9
            '  `range_xmax` mediumint(6) NOT NULL DEFAULT '0',      - 10
            '  `range_ymax` mediumint(6) NOT NULL DEFAULT '0',      - 11
            '  `range_zmax` mediumint(6) NOT NULL DEFAULT '0',      - 12
            '  `hp` mediumint(6) unsigned NOT NULL DEFAULT '0',     - 13
            '  `pDef` mediumint(6) unsigned NOT NULL DEFAULT '0',   - 14
            '  `mDef` mediumint(6) unsigned NOT NULL DEFAULT '0',   - 15
            '  `openType` enum('true','false') NOT NULL DEFAULT 'false',        - 16
            '  `commanderDoor` enum('true','false') NOT NULL DEFAULT 'false',   - 17
            '  `objectType` tinyint(1) unsigned NOT NULL DEFAULT '0',           -18

            outFile.WriteLine("(fort_id,{0},'{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},'false',0),", _
                              aDoor(0).id, aDoor(0).name, _
                              aDoor(0).posx, aDoor(0).posy, aDoor(0).posz, _
                              aDoor(0).range_minx, aDoor(0).range_miny, aDoor(0).range_minz, _
                              aDoor(0).range_maxx, aDoor(0).range_maxy, aDoor(0).range_maxz, _
                              aDoor(0).hp, aDoor(0).physical_defence, aDoor(0).magical_defence, _
                              aDoor(0).open_method)

            outFile2.WriteLine("UPDATE `fort_staticobjects` SET x='{0}', y='{1}', z='{2}', range_xmin='{3}', range_ymin='{4}', range_zmin='{5}', range_xmax='{6}', range_ymax='{7}', range_zmax='{8}', hp='{9}', pDef='{10}', mDef='{11}', openType='{12}' WHERE id='{13}';", _
                  aDoor(0).posx, aDoor(0).posy, aDoor(0).posz, _
                  aDoor(0).range_minx, aDoor(0).range_miny, aDoor(0).range_minz, _
                  aDoor(0).range_maxx, aDoor(0).range_maxy, aDoor(0).range_maxz, _
                  aDoor(0).hp, aDoor(0).physical_defence, aDoor(0).magical_defence, _
                  aDoor(0).open_method, aDoor(0).id)


        End While
        outFile.Flush() : outFile.Close()
        outFile2.Flush() : outFile2.Close()
        inFile.Close()
        ToolStripProgressBar.Value = 0

        MessageBox.Show("Done")

    End Sub



    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub
End Class
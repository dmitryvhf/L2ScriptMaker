Public Class DoorMakerForm


    'door_begin	[gludio_castle_inner_002]	type=normal_type	editor_id=19210006	open_method=by_npc	height=255	hp=126600	physical_defence=644	magical_defence=518	pos={-17981;110520;-2289}	range={{-18112;110514;-2547};{-17981;110514;-2547};{-17981;110526;-2547};{-18112;110526;-2547}}	door_end

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBoxX.Text = "0"
        TextBoxY.Text = "0"
        TextBoxZ.Text = "0"
        TextBoxXS.Text = "0"
        TextBoxYS.Text = "0"
        TextBoxZS.Text = "0"
        Heights.Text = "0"
        HP.Text = "0"
        PDef.Text = "0"
        MDef.Text = "0"
    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click
        Dim Pos As Integer
        Dim TempX, TempY, TempZ As Double

        If AutoClearBox.Checked = True Then TextBoxFinal.Text = ""

        If BestZBox.Checked = True Then
            TempZ = Val(TextBoxZ.Text)
        Else
            TempZ = Val(TextBoxZ.Text) + (Val(TextBoxZS.Text) * 3 / 4)
        End If


        'door_begin	[gludio_castle_outter_001]	type=normal_type	static_object_id=19210001	open_method=by_npc	
        TextBoxFinal.AppendText("door_begin" & vbTab & "[" & DoorName.Text & "]" & vbTab & "type=" & DoorType.Text & vbTab & "editor_id=" & StatObjID.Text & vbTab & "open_method=" & OpenMetod.Text)
        'height=300	hp=316500	physical_defence=644	magical_defence=518	door_end	
        TextBoxFinal.AppendText(vbTab & "height=" & Heights.Text & vbTab & "hp=" & HP.Text & vbTab & "physical_defence=" & PDef.Text & vbTab & "magical_defence=" & MDef.Text)

        'pos={-18450;113067;-2466}	range={{-18450;113061;-2789};{-18320;113061;-2789};{-18320;113073;-2789};{-18450;113073;-2789}}
        TextBoxFinal.AppendText(vbTab & "pos={" & TextBoxX.Text & ";" & TextBoxY.Text & ";" & (Fix(TempZ)).ToString & "}  range={")

        For Pos = 1 To 4

            If Pos > 1 Then TextBoxFinal.AppendText(";")
            Select Case Pos
                Case 1
                    TempX = Val(TextBoxX.Text) - Val(TextBoxXS.Text)
                    TempY = Val(TextBoxY.Text) - Val(TextBoxYS.Text)
                Case 2
                    TempX = Val(TextBoxX.Text) + Val(TextBoxXS.Text)
                    TempY = Val(TextBoxY.Text) - Val(TextBoxYS.Text)
                Case 3
                    TempX = Val(TextBoxX.Text) + Val(TextBoxXS.Text)
                    TempY = Val(TextBoxY.Text) + Val(TextBoxYS.Text)
                Case 4
                    TempX = Val(TextBoxX.Text) - Val(TextBoxXS.Text)
                    TempY = Val(TextBoxY.Text) + Val(TextBoxYS.Text)
            End Select
            TextBoxFinal.AppendText("{" & TempX.ToString & ";" & TempY.ToString & ";" & TextBoxZ.Text & "}")

        Next
        TextBoxFinal.AppendText("}" & vbTab & "door_end" & vbNewLine)


    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        TextBoxFinal.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        HowToForm.ShowDialog()
    End Sub

    Private Sub KnowType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles KnowType.TextChanged
        Select Case KnowType.Text
            Case "Aden Walls"
                Heights.Text = "640"
                HP.Text = "678840"
                PDef.Text = "837"
                MDef.Text = "674"
            Case "Aden Outer Doors"
                Heights.Text = "512"
                HP.Text = "339420"
                PDef.Text = "837"
                MDef.Text = "674"
            Case "Aden Inner Doors"
                Heights.Text = "256"
                HP.Text = "158250"
                PDef.Text = "837"
                MDef.Text = "674"
            Case "Aden Castle Gates"
                Heights.Text = "256"
                HP.Text = "158250"
                PDef.Text = "837"
                MDef.Text = "674"
            Case "Castle Walls"
                Heights.Text = "500"
                HP.Text = "633000"
                PDef.Text = "644"
                MDef.Text = "518"
            Case "Castle Outer Doors"
                Heights.Text = "300"
                HP.Text = "316500"
                PDef.Text = "644"
                MDef.Text = "518"
            Case "Castle Inner Doors"
                Heights.Text = "256"
                HP.Text = "158250"
                PDef.Text = "644"
                MDef.Text = "518"
            Case "Castle Gate (Station)"
                Heights.Text = "256"
                HP.Text = "158250"
                PDef.Text = "644"
                MDef.Text = "518"
            Case "Lattice"
                Heights.Text = "128"
                HP.Text = "79125"
                PDef.Text = "644"
                MDef.Text = "518"
            Case "Kruma Door"
                Heights.Text = "150"
                HP.Text = "150000"
                PDef.Text = "476"
                MDef.Text = "383"
            Case "Bandit Stronghold Door"
                Heights.Text = "256"
                HP.Text = "158250"
                PDef.Text = "644"
                MDef.Text = "518"
            Case "City and Partisan Doors"
                Heights.Text = "128"
                HP.Text = "79128"
                PDef.Text = "644"
                MDef.Text = "518"
        End Select

    End Sub

End Class

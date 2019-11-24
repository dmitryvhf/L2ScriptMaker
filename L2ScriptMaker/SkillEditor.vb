Public Class SkillEditor

    Public Structure Skill
        Public skill_name As String
        Public skill_id As Integer
        Public comment As String
        Public level As Short
        Public operate_type As String
        Public magic_level As Short
        Public effect As String
        Public is_magic As Boolean

        Public mp_consume1 As Integer
        Public mp_consume2 As Integer
        Public hp_consume As Integer

        Public itemconsume As String

        Public skill_hit_time As Integer
        Public skill_cool_time As Integer
        Public skill_hit_cancel_time As Integer
        Public reuse_delay As Integer

        Public operate_cond As String
        Public unavailable_cond As String

        Public cast_range As Integer
        Public effective_range As Integer
        Public attribute As String
        Public effect_point As Integer
        Public target_type As String

        Public abnormal_lv As Integer
        Public abnormal_time As Integer
        Public activate_rate As Integer
        Public lv_bonus_rate As Integer
        Public basic_property As String
        Public abnormal_type As Integer
        Public abnormal_visual_effect As String

        Public affect_scope As Integer
        Public affect_object As Integer
        Public affect_range As Integer

        Public fan_range As Integer

        Public next_action As String
    End Structure


    Dim TabSym As Char = Chr(9)

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click
        If AutoClear.Checked = True Then SkillOutBox.Text = ""

        SkillOutBox.Text += "skill_begin" + TabSym
        If skillname.Text <> "" Then
            SkillOutBox.Text += "skill_name=[" + skillname.Text + "]" + TabSym
        Else
            showUndefinedParam("skill_name")
            Exit Sub
        End If
        If comment.Text <> "" Then
            SkillOutBox.Text += "/* " + comment.Text + " */" + TabSym
        End If
        If skillid.Text <> "" Then
            SkillOutBox.Text += "skill_id=" + skillid.Text + TabSym
        Else
            showUndefinedParam("skill_id")
            Exit Sub
        End If

        If skilllevel.Text <> "" Then
            SkillOutBox.Text += "level=" + skilllevel.Text + TabSym
        Else
            showUndefinedParam("level")
            Exit Sub
        End If
        If operatetype.Text <> "" Then
            SkillOutBox.Text += "operate_type=" + operatetype.Text + TabSym
        End If
        If magiclevel.Text <> "" Then
            SkillOutBox.Text += "magic_level=" + magiclevel.Text + TabSym
        Else
            showUndefinedParam("magic_level")
            Exit Sub
        End If
        If effect.Text <> "" Then
            SkillOutBox.Text += "effect={" + effect.Text + "}" + TabSym
        End If
        If ismagic.Text <> "" Then
            SkillOutBox.Text += "is_magic=" + ismagic.Text + TabSym
        End If

        If mp1.Text <> "" Then
            SkillOutBox.Text += "mp_consume1=" + mp1.Text + TabSym
        End If
        If mp2.Text <> "" Then
            SkillOutBox.Text += "mp_consume2=" + mp2.Text + TabSym
        End If
        If hp.Text <> "" Then
            SkillOutBox.Text += "hp_consume=" + hp.Text + TabSym
        End If
        If itemconsume.Text <> "" Then
            SkillOutBox.Text += "itemconsume={" + itemconsume.Text + "}" + TabSym
        End If

        If skillhittime.Text <> "" Then
            SkillOutBox.Text += "skill_hit_time=" + skillhittime.Text + TabSym
        End If
        If skillcooltime.Text <> "" Then
            SkillOutBox.Text += "skill_cool_time=" + skillcooltime.Text + TabSym
        End If
        If skillhitcanceltime.Text <> "" Then
            SkillOutBox.Text += "skill_hit_cancel_time=" + skillhitcanceltime.Text + TabSym
        End If
        If reusedelay.Text <> "" Then
            SkillOutBox.Text += "reuse_delay=" + reusedelay.Text + TabSym
        End If

        If operatecond.Text <> "" Then
            SkillOutBox.Text += "operate_cond={" + operatecond.Text + "}" + TabSym
        End If
        If unavcond.Text <> "" Then
            SkillOutBox.Text += "unavailable_cond={" + unavcond.Text + "}" + TabSym
        End If

        If castrange.Text <> "" Then
            SkillOutBox.Text += "cast_range=" + castrange.Text + TabSym
        End If
        If effectrange.Text <> "" Then
            SkillOutBox.Text += "effective_range=" + effectrange.Text + TabSym
        End If
        If attribute.Text <> "" Then
            SkillOutBox.Text += "attribute=" + attribute.Text + TabSym
        End If
        If effectpoint.Text <> "" Then
            SkillOutBox.Text += "effect_point=" + effectpoint.Text + TabSym
        End If
        If targettype.Text <> "" Then
            SkillOutBox.Text += "target_type=" + targettype.Text + TabSym
        End If

        If abnormallv.Text <> "" Then
            SkillOutBox.Text += "abnormal_lv=" + abnormallv.Text + TabSym
        End If
        If abnormaltime.Text <> "" Then
            SkillOutBox.Text += "abnormal_time=" + abnormaltime.Text + TabSym
        End If
        If activaterate.Text <> "" Then
            SkillOutBox.Text += "activate_rate=" + activaterate.Text + TabSym
        End If
        If lvbonusrate.Text <> "" Then
            SkillOutBox.Text += "lv_bonus_rate=" + lvbonusrate.Text + TabSym
        End If
        If basicprop.Text <> "" Then
            SkillOutBox.Text += "basic_property=" + basicprop.Text + TabSym
        End If
        If abnormaltype.Text <> "" Then
            SkillOutBox.Text += "abnormal_type=" + abnormaltype.Text + TabSym
        End If
        If abnormalviseffect.Text <> "" Then
            SkillOutBox.Text += "abnormal_visual_effect=" + abnormalviseffect.Text + TabSym
        End If

        If affectscope.Text <> "" Then
            SkillOutBox.Text += "affect_scope=" + affectscope.Text + TabSym
        End If
        If affectobject.Text <> "" Then
            SkillOutBox.Text += "affect_object=" + affectobject.Text + TabSym
        End If
        If affectrange.Text <> "" Then
            SkillOutBox.Text += "affect_range=" + affectrange.Text + TabSym
        End If

        If fanrange.Text <> "" Then
            SkillOutBox.Text += "fan_range=" + fanrange.Text + TabSym
        End If

        If nextaction.Text <> "" Then
            SkillOutBox.Text += "next_action=" + nextaction.Text + TabSym
        End If

        SkillOutBox.Text += "skill_end" + vbNewLine

    End Sub

    Private Sub ClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearButton.Click
        skillname.Text = ""
        comment.Text = ""
        skillid.Text = ""
        skilllevel.Text = ""
        operatetype.Text = ""
        magiclevel.Text = ""
        effect.Text = ""
        ismagic.Text = ""
        mp1.Text = ""
        mp2.Text = ""
        hp.Text = ""
        itemconsume.Text = ""
        skillhittime.Text = ""
        skillcooltime.Text = ""
        skillhitcanceltime.Text = ""
        reusedelay.Text = ""
        operatecond.Text = ""
        unavcond.Text = ""
        castrange.Text = ""
        effectrange.Text = ""
        attribute.Text = ""
        effectpoint.Text = ""
        targettype.Text = ""
        abnormallv.Text = ""
        abnormaltime.Text = ""
        activaterate.Text = ""
        lvbonusrate.Text = ""
        basicprop.Text = ""
        abnormaltype.Text = ""
        abnormalviseffect.Text = ""
        affectscope.Text = ""
        affectobject.Text = ""
        affectrange.Text = ""
        fanrange.Text = ""
        nextaction.Text = ""

        SkillOutBox.Text = ""
    End Sub

    Private Sub ImportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportButton.Click

        skillname.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_name")
        skillname.Text = Mid(skillname.Text, 2, Len(skillname.Text) - 2)
        If InStr(SkillOutBox.Text, "/*") <> 0 Then
            comment.Text = Trim(Mid(SkillOutBox.Text, InStr(SkillOutBox.Text, "/*") + 2, InStr(SkillOutBox.Text, "*/") - InStr(SkillOutBox.Text, "/*") - 2))
        End If
        skillid.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_id")
        skilllevel.Text = GetNeedParamFromStr(SkillOutBox.Text, "level")
        operatetype.Text = GetNeedParamFromStr(SkillOutBox.Text, "operate_type")
        magiclevel.Text = GetNeedParamFromStr(SkillOutBox.Text, "magic_level")
        effect.Text = GetNeedParamFromStr(SkillOutBox.Text, "effect")
        If effect.Text <> "" Then effect.Text = Mid(effect.Text, 2, Len(effect.Text) - 2)
        ismagic.Text = GetNeedParamFromStr(SkillOutBox.Text, "is_magic")
        mp1.Text = GetNeedParamFromStr(SkillOutBox.Text, "mp_consume1")
        mp2.Text = GetNeedParamFromStr(SkillOutBox.Text, "mp_consume2")
        hp.Text = GetNeedParamFromStr(SkillOutBox.Text, "hp_consume")
        itemconsume.Text = GetNeedParamFromStr(SkillOutBox.Text, "itemconsume")
        If itemconsume.Text <> "" Then itemconsume.Text = Mid(itemconsume.Text, 2, Len(itemconsume.Text) - 2)
        skillhittime.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_hit_time")
        skillcooltime.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_cool_time")
        skillhitcanceltime.Text = GetNeedParamFromStr(SkillOutBox.Text, "skill_hit_cancel_time")
        reusedelay.Text = GetNeedParamFromStr(SkillOutBox.Text, "reuse_delay")
        operatecond.Text = GetNeedParamFromStr(SkillOutBox.Text, "operate_cond")
        If operatecond.Text <> "" Then operatecond.Text = Mid(operatecond.Text, 2, Len(operatecond.Text) - 2)
        unavcond.Text = GetNeedParamFromStr(SkillOutBox.Text, "unavailable_cond")
        If unavcond.Text <> "" Then unavcond.Text = Mid(unavcond.Text, 2, Len(unavcond.Text) - 2)
        castrange.Text = GetNeedParamFromStr(SkillOutBox.Text, "cast_range")
        effectrange.Text = GetNeedParamFromStr(SkillOutBox.Text, "effective_range")
        attribute.Text = GetNeedParamFromStr(SkillOutBox.Text, "attribute")
        effectpoint.Text = GetNeedParamFromStr(SkillOutBox.Text, "effect_point")
        targettype.Text = GetNeedParamFromStr(SkillOutBox.Text, "target_type")
        abnormallv.Text = GetNeedParamFromStr(SkillOutBox.Text, "abnormal_lv")
        abnormaltime.Text = GetNeedParamFromStr(SkillOutBox.Text, "abnormal_time")
        activaterate.Text = GetNeedParamFromStr(SkillOutBox.Text, "activate_rate")
        lvbonusrate.Text = GetNeedParamFromStr(SkillOutBox.Text, "lv_bonus_rate")
        basicprop.Text = GetNeedParamFromStr(SkillOutBox.Text, "basic_property")
        abnormaltype.Text = GetNeedParamFromStr(SkillOutBox.Text, "abnormal_type")
        abnormalviseffect.Text = GetNeedParamFromStr(SkillOutBox.Text, "abnormal_visual_effect")
        affectscope.Text = GetNeedParamFromStr(SkillOutBox.Text, "affect_scope")
        affectobject.Text = GetNeedParamFromStr(SkillOutBox.Text, "affect_object")
        affectrange.Text = GetNeedParamFromStr(SkillOutBox.Text, "affect_range")
        fanrange.Text = GetNeedParamFromStr(SkillOutBox.Text, "fan_range")
        nextaction.Text = GetNeedParamFromStr(SkillOutBox.Text, "next_action")

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

    Sub showUndefinedParam(ByVal ParamName As String)
        MessageBox.Show("Must defined '" + ParamName + "' parameter for complete.", "Not defined", MessageBoxButtons.OK, MessageBoxIcon.Error)
        SkillOutBox.Text = ""
    End Sub

    Private Sub mp1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mp1.TextChanged
        mp_summ.Text = CStr(Val(mp1.Text) + Val(mp2.Text))
    End Sub
    Private Sub mp2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mp2.TextChanged
        mp_summ.Text = CStr(Val(mp1.Text) + Val(mp2.Text))
    End Sub
End Class
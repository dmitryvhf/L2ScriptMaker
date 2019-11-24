Public Class AiParamsNpcdataChecker

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim sTemp As String

        Dim CheckFolder As String
        FolderBrowserDialog.SelectedPath = System.Environment.CurrentDirectory
        FolderBrowserDialog.Description = "Select folder with Ai.obj and Npcdata.txt"
        'FolderBrowserDialog.Filter = "Lineage II Intelligence file|ai.obj|All files|*.*"
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        CheckFolder = FolderBrowserDialog.SelectedPath

        If System.IO.File.Exists(CheckFolder & "\ai.obj") = False Or System.IO.File.Exists(CheckFolder & "\npcdata.txt") = False Then
            MessageBox.Show("Not found Ai.obj or npcdata in this folder. Put and try again", "Files not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim inAiFile As New System.IO.StreamReader(CheckFolder & "\ai.obj", System.Text.Encoding.Default, True, 1)
        Dim outLogFile As New System.IO.StreamWriter(CheckFolder + "\ai.obj_scriptCheck.log", True, System.Text.Encoding.Unicode, 1)

        outLogFile.WriteLine("L2ScriptMaker. Ai params in Npcdata Checker.")
        outLogFile.WriteLine(Now & " Start" & vbNewLine)

        'class 1 default_npc : (null)
        'parameter_define_begin
        '        int MoveAroundSocial2 0
        '        float MoveAround_DecayRatio 0.000000
        '        string fnFeudInfo "defaultfeudinfo.htm"
        'parameter_define_end

        ' -------- Loading and checking AI.obj ---------
        Dim aClass(10000) As String, aParentClass(10000) As String, aParams(10000) As String
        Dim ClassMark As Integer = -1
        Dim sName As String, aName(4) As String

        ToolStripProgressBar.Maximum = CInt(inAiFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        CurActionLabel.Text = "Loading Ai.obj" : CurActionLabel.Update()
        While inAiFile.EndOfStream <> True

            sTemp = inAiFile.ReadLine

            ' --- Compiling class name
            If sTemp.StartsWith("class ") = True Then
                ' ERR check exist or not : in class line
                If InStr(sTemp, ":") = 0 Then
                    WriteErrToLog(outLogFile, sTemp & vbNewLine & "Not found "":"" in class definition")
                End If

                sName = FixSymbols(sTemp.Replace(":", "")).Trim
                'class(0) 1(1) default_npc(2) : (null)(3)
                aName = sName.Split(Chr(32))

                CurActionLabel.Text = "Loading " & aName(2) & " class" : CurActionLabel.Update()
                ClassMark += 1
                aClass(ClassMark) = aName(2)
                aParentClass(ClassMark) = aName(3)

                ' ERR check exist or not : in class line
                If aName(3) <> "(null)" Then
                    If Array.IndexOf(aClass, aName(3)) = -1 Then
                        WriteErrToLog(outLogFile, aName(2) & " have not parent class " & aName(3))
                    End If
                End If
            End If
            ' ___ Compiling class name

            'class 1 default_npc : (null)
            'parameter_define_begin
            '        int MoveAroundSocial2 0
            '        float MoveAround_DecayRatio 0.000000
            '        string fnFeudInfo "defaultfeudinfo.htm"
            'parameter_define_end

            ' --- Compiling parameter_define
            If sTemp.StartsWith("parameter_define_begin") = True Then


                CurActionLabel.Text = "Loading parameters from " & aName(2) & " class" : CurActionLabel.Update()
                sTemp = inAiFile.ReadLine
                While sTemp.StartsWith("parameter_define_end") = False

                    sTemp = FixSymbols(sTemp).Trim
                    'string(0) fnFeudInfo(1) "defaultfeudinfo.htm"(2)
                    Try
                        aName = sTemp.Split(Chr(32))
                        If aParams(ClassMark) <> Nothing Then aParams(ClassMark) += ","
                        aParams(ClassMark) += aName(1)
                    Catch ex As Exception
                        'nothing Example, queen_ant
                    End Try

                    sTemp = inAiFile.ReadLine
                End While
            End If
            ' ____ Compiling parameter_define

            ToolStripProgressBar.Value = CInt(inAiFile.BaseStream.Position)
            Me.Update()
        End While
        ToolStripProgressBar.Value = 0
        CurActionLabel.Text = "Loading AI.obj complete" : CurActionLabel.Update()
        inAiFile.Close()
        outLogFile.WriteLine(vbNewLine & Now & " End of Ai.obj loading and checking of " & ClassMark & " class's.")
        outLogFile.Flush()
        Me.Refresh()

        ' _______ Loading and checking AI.obj ____________

        Dim sNpcAi As String            ' ai class name for this npc
        Dim sNpcAiParam As String = ""  ' full npc_ai line
        Dim aNpcAiParam(20) As String   ' all npc_ai params 
        Dim iTemp1 As Integer, bFoundStatus As Boolean
        Dim sNpcAiParam2 As String      ' temp string for work finding parameter in classes
        Dim aNpcParam(50) As String     'list AI parameters

        Dim inNpcDataFile As New System.IO.StreamReader(CheckFolder & "\npcdata.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inNpcDataFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        CurActionLabel.Text = "Loading NpcData.txt" : CurActionLabel.Update()
        While inNpcDataFile.EndOfStream <> True

            sTemp = inNpcDataFile.ReadLine

            If sTemp.StartsWith("npc_begin") = True Then

                sName = Mid(sTemp, 1, InStr(sTemp, "level=") - 1)
                sName = FixSymbols(sName).Trim
                aName = sName.Split(Chr(32))

                CurActionLabel.Text = "Compiling " & aName(3) & " npc" : CurActionLabel.Update()
                sNpcAiParam = Libraries.GetNeedParamFromStr(sTemp, "npc_ai")

                'npc_begin(0)	warrior(1)	56(2)	[dre_vanul_disposer](3)	level=22(4)	acquire_exp_rate=1.586508	acquire_sp=36	unsowing=0	clan={@demonic_clan}	ignore_clan_list={}	clan_help_range=300	slot_chest=[]	slot_rhand=[]	slot_lhand=[]	shield_defense_rate=0	shield_defense=0	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}	
                ' 1) Simple AI
                If sNpcAiParam = "{}" Then
                    'empty ai class definition
                    WriteErrToLog(outLogFile, sName & " have empty ai.")

                Else
                    '2) Enchant AI
                    'npc_ai={[dre_vanul_disposer];{[MoveAroundSocial]=0};{[MoveAroundSocial1]=0};{[MoveAroundSocial2]=0};{[DDMagic1]=@s_mega_storm_strike2};{[DDMagic2]=@s_blood_sucking2};{[DeBuff]=@s_npc_chill_flame2}}	
                    'npc_ai={[varikan_brigand_ldr];{[MoveAroundSocial]=42};{[MoveAroundSocial1]=42};{[MoveAroundSocial2]=42};{[Privates]=[varikan_brigand:varikan_brigand:1:0;varikan_brigand:varikan_brigand:1:0;varikan_brigand:varikan_brigand:1:0;varikan_brigand:varikan_brigand:1:0]};{[ShoutMsg1]=[1000154]};{[ShoutMsg2]=[1000155]};{[ShoutMsg3]=[1000156]};{[ShoutMsg4]=[1000157]}}

                    sNpcAi = Mid(sNpcAiParam, 3, InStr(sNpcAiParam, "]") - 3)
                    ' ERR check exist or not : in class line
                    If Array.IndexOf(aClass, sNpcAi) = -1 Then
                        WriteErrToLog(outLogFile, sName & " have not ai class in Ai.obj")
                    Else

                        'Dim aClass(10000) As String, aParentClass(10000) As String, aParams(10000) As String
                        'Dim sNpcAi As String            ' ai class name for this npc
                        'Dim sNpcAiParam As String = ""  ' full npc_ai line
                        'Dim aNpcAiParam(20) As String   ' all npc_ai params 
                        'Dim iTemp1 As Integer, iTemp2 As Integer, bFoundStatus As Boolean
                        'Dim sNpcAiParam2 As String      ' temp string for work finding parameter in classes
                        'Dim aNpcParam(50) As String     'list AI parameters

                        ' --------- BIG MAIN HARD COMPILING -----------
                        If InStr(sNpcAiParam, ";") <> 0 Then
                            sNpcAiParam = sNpcAiParam.Replace("[" & sNpcAi & "];", "") ' remove npc ai class
                            sNpcAiParam = sNpcAiParam.Replace("{{", "").Replace("}}", "") ' remove npc ai class
                            sNpcAiParam = sNpcAiParam.Replace("};{", "|")               ' make split char one symbol
                            Array.Clear(aNpcAiParam, 0, aNpcAiParam.Length)
                            aNpcAiParam = sNpcAiParam.Split(CChar("|"))                 '[MoveAroundSocial]=42

                            For iTemp1 = 0 To aNpcAiParam.Length - 1
                                sNpcAiParam2 = Mid(aNpcAiParam(iTemp1), 2, InStr(aNpcAiParam(iTemp1), "]") - 2)
                                ClassMark = Array.IndexOf(aClass, sNpcAi)

                                While bFoundStatus = False

                                    If ClassMark = -1 Then Exit While
                                    Array.Clear(aNpcParam, 0, aNpcParam.Length)
                                    If aParams(ClassMark) <> Nothing Then
                                        Array.Clear(aNpcParam, 0, aNpcParam.Length)
                                        aNpcParam = aParams(ClassMark).Split(CChar(","))
                                        If Array.IndexOf(aNpcParam, sNpcAiParam2) <> -1 Then
                                            bFoundStatus = True
                                            Exit While
                                        End If
                                    End If
                                    ClassMark = Array.IndexOf(aClass, aParentClass(ClassMark))

                                End While

                                If bFoundStatus = False Then
                                    WriteErrToLog(outLogFile, sName & vbTab & vbTab & "npc_ai=[" & sNpcAi & "] not found parameter " & sNpcAiParam2)
                                Else
                                    bFoundStatus = False
                                End If
                            Next
                        End If
                        ' ______________  BIG MAIN HARD COMPILING ____________

                    End If

                End If

            End If
            ToolStripProgressBar.Value = CInt(inNpcDataFile.BaseStream.Position)
            Me.Update()

        End While
        outLogFile.WriteLine(vbNewLine & Now & " End of NpcData.txt loading and checking")
        outLogFile.WriteLine(vbNewLine & Now & " End" & vbNewLine)
        ToolStripProgressBar.Value = 0
        CurActionLabel.Text = "Work complete."

        inNpcDataFile.Close()
        outLogFile.Close()

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Close()
    End Sub

    Private Function WriteErrToLog(ByVal LogName As System.IO.StreamWriter, ByVal ErrMsg As String) As Boolean

        'LogName.WriteLine(vbNewLine & "ERR: " & ErrMsg)
        LogName.WriteLine("ERR: " & ErrMsg)

    End Function

    Private Function FixSymbols(ByVal Msg As String) As String

        Msg = Msg.Replace(Chr(9), " ")
        While InStr(Msg, "  ") <> 0
            Msg = Msg.Replace("  ", " ")
        End While

        Return Msg

    End Function

End Class
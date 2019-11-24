Option Explicit On
Option Strict On
Option Infer On

Imports Microsoft.Win32

Public Class LogParser


    Private Sub LoadPaths()

        Paths.LogIDs = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "LogIDs", ""))
        Paths.ItemName = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "ItemName", ""))
        Paths.Logs = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Logs", ""))
        Paths.Skills = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Skills", ""))
        Paths.Quests = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Quests", ""))
        Paths.NPC = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "NPC", ""))

        LoadNamesOnLaunch = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Load", "0"))

        MaxRows = CInt(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "MaxRows", "5000"))

    End Sub

    Public Sub LoadSecFiles()

        If Paths.ItemName <> "" Then
            Items = New cItems(Paths.ItemName)
        End If

        If Paths.LogIDs <> "" Then
            LogIDs = New cLogIDs(Paths.LogIDs)
        End If

        If Paths.Skills <> "" Then
            locSkills = New cSkills(Paths.Skills)
        End If

        If Paths.Quests <> "" Then
            Quests = New cQuests(Paths.Quests)
        End If

        If Paths.NPC <> "" Then
            NPC = New cNPC(Paths.NPC)
        End If

        'If Paths.Logs <> "" Then

        'End If

    End Sub

    Private Sub LoadLogIDS()
        If Paths.LogIDs <> "" Then
            LogIDs = New cLogIDs(Paths.LogIDs)
            LogIDs.FillCombo(cActions)
        End If

    End Sub

    Sub Main2()



    End Sub



#Region "Settings"

    Private Sub textLogIDs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textLogIDs.DoubleClick

        Open.Filter = "Текстовый файл (*.txt)|*.txt"
        Open.InitialDirectory = textLogIDs.Text
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            textLogIDs.Text = Open.FileName
        End If

    End Sub

    Private Sub textItemName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textItemName.DoubleClick

        Open.Filter = "Текстовый файл (*.txt)|*.txt"
        Open.InitialDirectory = textItemName.Text
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            textItemName.Text = Open.FileName
        End If

    End Sub

    Private Sub textLogs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textLogs.DoubleClick

        If System.IO.Directory.Exists(textLogs.Text) = False Then
            textLogs.Text = System.Environment.CurrentDirectory
        End If
        Folder.SelectedPath = textLogs.Text
        If Folder.ShowDialog = Windows.Forms.DialogResult.OK Then
            textLogs.Text = Folder.SelectedPath
        End If

    End Sub


    Private Sub textSkillName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textSkillName.DoubleClick

        Open.Filter = "Текстовый файл (*.txt)|*.txt"
        Open.InitialDirectory = textSkillName.Text
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            textSkillName.Text = Open.FileName
        End If


    End Sub

    Public Sub textQuestName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textQuestName.DoubleClick

        Open.Filter = "Текстовый файл (*.txt)|*.txt"
        Open.InitialDirectory = textQuestName.Text
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            textQuestName.Text = Open.FileName
        End If

    End Sub

    Public Sub textNPC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textNPC.DoubleClick

        Open.Filter = "Текстовый файл (*.txt)|*.txt"
        Open.InitialDirectory = textNPC.Text
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            textNPC.Text = Open.FileName
        End If

    End Sub

    Public Sub bSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSave.Click

        Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "LogIDs", textLogIDs.Text)
        Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "ItemName", textItemName.Text)
        Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Logs", textLogs.Text)
        Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Skills", textSkillName.Text)
        Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Quests", textQuestName.Text)
        Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "NPC", textNPC.Text)

        Paths.LogIDs = textLogIDs.Text
        Paths.ItemName = textItemName.Text
        Paths.Logs = textLogs.Text
        Paths.Skills = textSkillName.Text
        Paths.Quests = textQuestName.Text
        Paths.NPC = textNPC.Text

        LoadSecFiles()

        MessageBox.Show("Config's reloaded successfuly", "Reloaded", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Container_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadPaths()

        FillParametersString()

        Logs = New cLogs()

        LoadLogIDS()

        If LoadNamesOnLaunch = "1" Then
            LoadSecFiles()
        End If

        textLogIDs.Text = Paths.LogIDs
        textItemName.Text = Paths.ItemName
        textLogs.Text = Paths.Logs
        textSkillName.Text = Paths.Skills
        textQuestName.Text = Paths.Quests
        textNPC.Text = Paths.NPC
        textMaxRows.Text = CStr(CInt(MaxRows))

        If LoadNamesOnLaunch = "1" Then
            checkLoadOnLaunch.Checked = True
        End If

        If textLogIDs.Text = "" Then
            textLogIDs.Text = System.Environment.CurrentDirectory
            Paths.LogIDs = System.Environment.CurrentDirectory
        End If

        If textItemName.Text = "" Then
            textItemName.Text = System.Environment.CurrentDirectory
            Paths.ItemName = System.Environment.CurrentDirectory
        End If

        If textLogs.Text = "" Then
            textLogs.Text = System.Environment.CurrentDirectory
            Paths.Logs = System.Environment.CurrentDirectory
        End If

        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        Dim i As Integer
        For i = 1 To ParametersString.GetUpperBound(0)
            colParam.Items.Add(ParametersString(i))
        Next

        colOperation.Items.Add("=")
        colOperation.Items.Add(">")
        colOperation.Items.Add("<")
        colOperation.Items.Add("<>")

    End Sub

#End Region

    Private Sub FillGrid()

        Logs.FillGrid(Me)

    End Sub

    Private Sub bFillGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bFillGrid.Click

        FillGrid()

    End Sub

    Private Sub InMemory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InMemory.Click

        If MsgBox("Загрузить логи в память?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Logs.LoadInMemory(textLogs.Text, Me)
        MessageBox.Show("Loaded successfuly", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)
        tab1.SelectedIndex = 0

    End Sub

    Private Sub textLogToSave_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textLogToSave.DoubleClick

        Save.Filter = "Файл логов (*.log)|*.log"
        If Save.ShowDialog = Windows.Forms.DialogResult.OK Then
            textLogToSave.Text = Save.FileName
        End If

    End Sub

    Private Sub bSaveToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSaveToFile.Click

        If textLogToSave.Text = "" Then
            MessageBox.Show("Enter correct file name for save data and try again.", "No name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Logs.SaveToFile(Me, textLogToSave.Text)
        MessageBox.Show("Saved successfuly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub checkLoadOnLaunch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkLoadOnLaunch.CheckedChanged

        If checkLoadOnLaunch.Checked Then
            Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Load", "1")
        Else
            Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Load", "0")
        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        MaxRows = CInt(textMaxRows.Text)
        Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "MaxRows", textMaxRows.Text)

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

End Class

Public Class cLogs

    Public Structure Log
        Friend act_time As String
        Friend log_id As String
        Friend actor As String
        Friend actor_account As String
        Friend target As String
        Friend target_account As String
        Friend location_x As String
        Friend location_y As String
        Friend location_z As String
        Friend etc_str1 As String
        Friend etc_str2 As String
        Friend etc_str3 As String
        Friend etc_num1 As String
        Friend etc_num2 As String
        Friend etc_num3 As String
        Friend etc_num4 As String
        Friend etc_num5 As String
        Friend etc_num6 As String
        Friend etc_num7 As String
        Friend etc_num8 As String
        Friend etc_num9 As String
        Friend etc_num10 As String
        Friend STR_actor As String
        Friend STR_actor_account As String
        Friend STR_target As String
        Friend STR_target_account As String
        Friend item_id As String
        Friend STR_item As String
        Friend STR_action As String
        Friend Str As String
    End Structure

    Private pPath As String

    Public L() As Log

    Private lC As LogParser

    Public Actions() As String
    Public Actors() As String
    Public Targets() As String
    'Public DBitems() As String

    Private LogsLoaded As Boolean = False

    Private C() As CompareRow

    Private Structure CompareRow
        Friend Parameter As String
        Friend Operation As String
        Friend Value As String
    End Structure

    Private Sub UpdateMass(ByRef Mass() As String, ByVal Val As String)

        Dim Update As Boolean
        Dim i As Integer

        If Val = Nothing Then
            Exit Sub
        End If

        Update = True
        If Mass.GetUpperBound(0) > 0 Then
            For i = 1 To Mass.GetUpperBound(0)
                If Mass(i) = Val Then
                    Update = False
                    Exit For
                End If
            Next
        End If
        If Update = True Then
            ReDim Preserve Mass(Mass.GetUpperBound(0) + 1)
            Mass(Mass.GetUpperBound(0)) = Val
        End If

    End Sub

    Private Sub UpdateMasses(ByVal S As Log)

        UpdateMass(Actions, S.STR_action)
        UpdateMass(Actors, S.STR_actor)
        UpdateMass(Targets, S.STR_target)
        'UpdateMass(DBitems, S.item_id)

    End Sub

    Private Sub MakeNum(ByRef Num As String, ByVal Str As String)

        On Error Resume Next

        If Str = Nothing Then
            Num = ""
        Else
            'Num = WordWrap(Str, ".", "Left")
            Num = Str.Replace(".", ",")
        End If

    End Sub

    Private Function LogFromString(ByVal Str As String) As Log

        Dim S() As String
        'S = Words(Str, ",")
        S = Str.Split(CChar(","))
        Dim L As Log

        L.Str = Str
        L.act_time = S(0)
        L.STR_action = LogIDs.Name((S(1)))
        L.log_id = S(1)
        L.actor = S(2)
        L.actor_account = S(3)
        L.target = S(4)
        L.target_account = S(5)
        L.location_x = S(6)
        L.location_y = S(7)
        L.location_z = S(8)
        L.etc_str1 = S(9)
        L.etc_str2 = S(10)
        L.etc_str3 = S(11)

        L.etc_num1 = S(12)
        L.etc_num2 = S(13)
        L.etc_num3 = S(14)
        L.etc_num4 = S(15)
        L.etc_num5 = S(16)
        L.etc_num6 = S(17)
        L.etc_num7 = S(18)
        L.etc_num8 = S(19)
        L.etc_num9 = S(20)
        L.etc_num10 = S(21)

        L.STR_actor = S(22)
        L.STR_actor_account = S(23)
        L.STR_target = S(24)
        L.STR_target_account = S(25)
        L.item_id = S(26)
        'If Items Is Nothing Then
        'Else
        '    L.STR_item = Items.Name((L.etc_num8))
        'End If


        If S.GetUpperBound(0) <> 26 Then
            'L.item_id = S(27)
        End If

        LogFromString = L

    End Function

    Private Sub FromFiles(ByRef Cont As LogParser, Optional ByVal SavePath As String = "")

        Dim Files() As String
        Files = System.IO.Directory.GetFiles(Cont.textLogs.Text, "*.log")
        Dim i As Integer
        Dim F As System.IO.StreamReader
        Dim F2 As System.IO.StreamWriter
        Dim Str As String
        Dim L As Log
        Dim Add As Boolean

        Dim RowsCount As Integer = 0

        Cont.Grid.Rows.Clear()

        If SavePath <> "" Then
            F2 = New System.IO.StreamWriter(SavePath, False)
        End If

        For i = 0 To Files.GetUpperBound(0)

            F = System.IO.File.OpenText(Files(i))
            Do While Not F.EndOfStream
                Str = F.ReadLine


                L = LogFromString(Str)

                Add = True
                If (Cont.cActions.Text <> ">>Без фильтра") Then
                    If Cont.cActions.Text <> L.STR_action Then
                        Add = False
                    End If
                End If
                If (Cont.cActors.Text <> "") Then
                    If Cont.cActors.Text <> L.STR_actor Then
                        Add = False
                    End If
                End If
                If (Cont.cTarget.Text <> "") Then
                    If Cont.cTarget.Text <> L.STR_target Then
                        Add = False
                    End If
                End If
                'If (Cont.cDBitem.Text <> "") Then
                'If Cont.cDBitem.Text <> L.item_id Then
                'Add = False
                'End If
                'End If

                If Add = True Then
                    If Cont.checkEnableExtraFilter.Checked = True Then
                        Add = CBool(CheckLogByGrid(L))
                    End If
                    If Add = True Then
                        If SavePath <> "" Then
                            F2.WriteLine(L.Str)
                        Else
                            RowsCount = RowsCount + 1
                            If RowsCount = MaxRows Then
                                MsgBox("Превышено максимальное количество строк")
                                Exit For
                            End If
                            GridFromLog(Cont, L)
                        End If
                    End If
                End If


            Loop

            F.Close()

        Next

        If SavePath <> "" Then
            F2.Close()
        End If

    End Sub

    Private Function LoadLogs() As AppDomain

        Dim Files() As String
        Dim i As Integer, j As Integer = 0
        Dim CurLog As Integer = 0
        Dim F As System.IO.StreamReader
        Dim S() As String

        ReDim Actions(0)
        ReDim Actors(0)
        ReDim Targets(0)
        'ReDim DBitems(0)

        Files = System.IO.Directory.GetFiles(pPath, "*.log")
        For i = 0 To Files.GetUpperBound(0)

            F = System.IO.File.OpenText(Files(i))
            Do While Not F.EndOfStream
                j = j + 1

                Dim Str As String = F.ReadLine
                If j / 1000 = Int(j / 1000) Then
                    lC.Status.Text = "Загрузка логов (1-" & i & "-" & j & ")"
                End If
            Loop

            F.Close()

        Next

        ReDim L(j)
        j = 0
        For i = 0 To Files.GetUpperBound(0)

            F = System.IO.File.OpenText(Files(i))
            Do While Not F.EndOfStream
                j = j + 1

                Dim Str As String = F.ReadLine

                L(j) = LogFromString(Str)

                UpdateMasses(L(j))

                If j / 1000 = Int(j / 1000) Then
                    lC.Status.Text = "Загрузка логов (2-" & i & "-" & j & ")"
                End If
            Loop

            F.Close()

        Next

        lC.Status.Text = "Готово"

    End Function

    Private Sub UpdateCombo(ByRef Combo As System.Windows.Forms.ComboBox, ByVal Mass() As String)

        Dim i As Integer

        If Mass.GetUpperBound(0) > 2000 Then
            Exit Sub
        End If

        Combo.Items.Clear()
        Combo.Items.Add(">>Без фильтра")
        If Mass.GetUpperBound(0) > 0 Then
            For i = 1 To Mass.GetUpperBound(0)
                Combo.Items.Add(Mass(i))
            Next
        End If
        Combo.Sorted = True
        'Combo.SelectedIndex = 0

        For i = 0 To Combo.Items.Count - 1
            If Combo.Items(i).ToString = ">>Без фильтра" Then
                Combo.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub

    Public Sub LoadInMemory(ByVal Path As String, ByRef Cont As LogParser)

        pPath = Path
        lC = Cont

        LoadLogs()

        'UpdateCombo(lC.cActions, Actions)
        UpdateCombo(lC.cActors, Actors)
        'UpdateCombo(lC.cDBitem, DBitems)
        UpdateCombo(lC.cTarget, Targets)

        LogsLoaded = True

    End Sub

    Private Function CheckLogByGrid(ByVal L As Log) As Boolean

        Dim Add As Boolean = True
        Dim EnFilter As Boolean
        Dim j As Integer

        If C.GetUpperBound(0) > 0 Then
            For j = 1 To C.GetUpperBound(0)
                EnFilter = True
                If C(j).Parameter = Nothing Then
                    EnFilter = False
                End If
                If C(j).Operation = Nothing Then
                    EnFilter = False
                End If
                If EnFilter = True Then
                    Try
                        Dim valToCompare As Double = CDbl(ValueFromLog(L, C(j).Parameter))
                        Dim valToCompare2 As Double = CDbl(C(j).Value)

                        Select Case C(j).Operation
                            Case ">"
                                If IsNumeric(valToCompare) And IsNumeric(valToCompare2) Then
                                    If CDbl(valToCompare) <= CDbl(valToCompare2) Then
                                        Add = False
                                    End If
                                Else
                                    Add = False
                                End If
                            Case "<"
                                If IsNumeric(valToCompare) And IsNumeric(valToCompare2) Then
                                    If valToCompare >= valToCompare2 Then
                                        Add = False
                                    End If
                                Else
                                    Add = False
                                End If
                            Case "="
                                If valToCompare = valToCompare2 Then
                                Else
                                    Add = False
                                End If
                            Case "<>"
                                If valToCompare = valToCompare2 Then
                                    Add = False
                                End If
                        End Select
                    Catch ex As Exception
                        Add = False
                    End Try
                End If
                If Add = False Then
                    Exit For
                End If
            Next
        End If

        CheckLogByGrid = Add

    End Function

    Private Sub FillCompareTable(ByRef Cont As LogParser)

        Dim i As Integer

        If Cont.gridFilter.Rows.Count > 1 Then
            ReDim C(Cont.gridFilter.Rows.Count - 1)
            For i = 0 To C.GetUpperBound(0) - 1
                C(i + 1).Parameter = Cont.gridFilter.Rows(i).Cells(0).Value.ToString
                C(i + 1).Operation = Cont.gridFilter.Rows(i).Cells(1).Value.ToString
                C(i + 1).Value = Cont.gridFilter.Rows(i).Cells(2).Value.ToString
            Next
        Else
            ReDim C(0)
        End If



    End Sub

    Private Sub FillTunableCells(ByRef Cont As LogParser, ByVal L As Log)



    End Sub

    Private Sub GridFromLog(ByRef Cont As LogParser, ByVal L As Log)

        Dim sdvig As Integer = 6
        Dim i As Integer '
        Dim s() As String

        Cont.Grid.Rows.Add()
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(0).Value = L.act_time
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(1).Value = L.STR_action

        If LogIDs.IsTunable(CInt(L.log_id)) Then
            For i = 1 To 5
                Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(1 + i).Value = LogIDs.TunableValue(CInt(L.log_id), i, L)
            Next
        End If

        s = L.Str.Split(CChar(","))
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 1).Value = L.actor
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 2).Value = L.actor_account
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 3).Value = L.target
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 4).Value = L.target_account
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 5).Value = L.location_x
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 6).Value = L.location_y
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 7).Value = L.location_z
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 8).Value = L.etc_str1
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 9).Value = L.etc_str2
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 10).Value = L.etc_str3
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 11).Value = L.etc_num1
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 12).Value = L.etc_num2
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 13).Value = L.etc_num3
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 14).Value = L.etc_num4
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 15).Value = L.etc_num5
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 16).Value = L.etc_num6
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 17).Value = L.etc_num7
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 18).Value = L.etc_num8
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 19).Value = L.etc_num9
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 20).Value = L.etc_num10
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 21).Value = L.STR_actor
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 22).Value = L.STR_actor_account
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 23).Value = L.STR_target
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 24).Value = L.STR_target_account
        Cont.Grid.Rows(Cont.Grid.Rows.Count - 1).Cells(sdvig + 25).Value = L.item_id

    End Sub

    Private Sub FromMemory(ByRef Cont As LogParser, Optional ByVal SavePath As String = "")

        Dim i As Integer
        Dim Add As Boolean
        Dim F As System.IO.StreamWriter

        Dim RowsCount As Integer = 0

        Cont.Status.Text = "Заполняется таблица"
        Cont.Update()

        Cont.Grid.Rows.Clear()

        If Logs.L.GetUpperBound(0) > 0 Then

            If SavePath <> "" Then
                F = New System.IO.StreamWriter(SavePath, False)
            End If

            For i = 1 To Logs.L.GetUpperBound(0)
                Add = True
                If Cont.cActions.SelectedItem.ToString <> ">>Без фильтра" Then
                    If Cont.cActions.SelectedItem.ToString <> Logs.L(i).STR_action Then
                        Add = False
                    End If
                End If
                If Cont.cActors.SelectedItem.ToString <> ">>Без фильтра" Then
                    If Cont.cActors.SelectedItem.ToString <> Logs.L(i).STR_actor Then
                        Add = False
                    End If
                End If
                If Cont.cTarget.SelectedItem.ToString <> ">>Без фильтра" Then
                    If Cont.cTarget.SelectedItem.ToString <> Logs.L(i).STR_target Then
                        Add = False
                    End If
                End If
                'If Cont.cDBitem.SelectedItem.ToString <> ">>Без фильтра" Then
                'If Cont.cDBitem.SelectedItem.ToString <> Logs.L(i).item_id Then
                'Add = False
                'End If
                'End If

                If Add = True Then
                    If Cont.checkEnableExtraFilter.Checked = True Then
                        Add = CheckLogByGrid(L(i))
                    End If
                End If

                If Add = True Then
                    If SavePath = "" Then
                        RowsCount = RowsCount + 1
                        If RowsCount = MaxRows Then
                            MsgBox("Превышено максимальное количество строк")
                            Exit For
                        End If
                        GridFromLog(Cont, L(i))
                    Else
                        F.WriteLine(L(i).Str)
                    End If

                End If
            Next
        End If

        If SavePath <> "" Then
            F.Close()
        End If


        Cont.Status.Text = "Готово"
        Cont.Update()

    End Sub

    Public Sub FillGrid(ByRef Cont As LogParser)

        FillCompareTable(Cont)

        If LogsLoaded = True Then
            FromMemory(Cont)
        Else
            FromFiles(Cont)
        End If


    End Sub


    Public Function SaveToFile(ByRef Cont As LogParser, ByVal PathToSave As String) As Boolean

        If PathToSave = "" Then Exit Function

        FillCompareTable(Cont)

        If LogsLoaded = True Then
            FromMemory(Cont, PathToSave)
        Else
            FromFiles(Cont, PathToSave)
        End If

    End Function

End Class

Public Class cItems

    Private IDs() As Integer
    Private Names() As String

    Private idxIDs() As Integer

    Public Sub LoadItems(ByVal Path As String)

        Dim F As System.IO.StreamReader
        Dim Str As String
        Dim Str2() As String

        Dim MaxID As Integer
        Dim i As Integer
        Dim CountID As Integer

        ReDim IDs(0)
        ReDim Names(0)

        'Exit Sub

        On Error Resume Next
        F = System.IO.File.OpenText(Path)
        If Err.Number <> 0 Then
        Else
            Do While Not F.EndOfStream
                Str = F.ReadLine
                CountID = CountID + 1
            Loop
            F.Close()
            ReDim IDs(CountID)
            ReDim Names(CountID)
            CountID = 0
            F = System.IO.File.OpenText(Path)
            Do While Not F.EndOfStream
                Str = F.ReadLine
                CountID = CountID + 1
                'Str2 = Words(Str, Chr(9))
                Str2 = Str.Split(Chr(9))
                IDs(CountID) = CInt(WordWrap(Str2(1), "=", "Right"))
                Names(CountID) = WordWrap(Str2(2), "=", "Right") ' .Replace("[", "").Replace("]", "")
                MaxID = CInt(IIf(IDs(CountID) > MaxID, IDs(CountID), MaxID))
            Loop

            ReDim idxIDs(MaxID)

            For i = 1 To IDs.GetUpperBound(0)
                idxIDs(IDs(i)) = i
            Next

            F.Close()

        End If

    End Sub

    Public Sub New(ByVal Path As String)

        LoadItems(Path)

    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Count = Names.GetUpperBound(0)
        End Get
    End Property

    Public ReadOnly Property Name(ByVal ID As String) As String
        Get
            On Error Resume Next
            Name = Names(idxIDs(CInt(ID)))
            If Err.Number <> 0 Then
                Name = CStr(ID)
            End If
        End Get
    End Property

    Public ReadOnly Property ID(ByVal Name As String) As Integer
        Get
            Dim i As Integer
            For i = 1 To Names.GetUpperBound(0)
                If Names(i) = Name Then
                    ID = IDs(i)
                    Exit For
                End If
            Next
            ID = 0
        End Get
    End Property

End Class

Public Class cLogIDs

    Private IDs() As Integer
    Private Names() As String


    Private kolonki(,) As String
    Private kolids(,) As String

    Private idxIDs() As Integer

    Public Sub LoadIDs(ByVal Path As String)

        Dim F As System.IO.StreamReader
        Dim Str As String
        Dim Str2() As String

        Dim MaxID As Integer
        Dim i As Integer

        ReDim IDs(0)
        ReDim Names(0)
        ReDim kolonki(5, 0)
        ReDim kolids(5, 0)

        On Error Resume Next
        F = System.IO.File.OpenText(Path)
        If Err.Number <> 0 Then
        Else
            Do While Not F.EndOfStream
                Str = F.ReadLine
                'Str2 = Words(Str, " ")
                Str2 = Str.Split(CChar(" "))
                ReDim Preserve IDs(IDs.GetUpperBound(0) + 1)
                ReDim Preserve Names(Names.GetUpperBound(0) + 1)
                ReDim Preserve kolonki(5, kolonki.GetUpperBound(1) + 1)
                ReDim Preserve kolids(5, kolids.GetUpperBound(1) + 1)
                IDs(IDs.GetUpperBound(0)) = CInt(Str2(0))
                Names(Names.GetUpperBound(0)) = Str2(1)
                MaxID = CInt(IIf(IDs(IDs.GetUpperBound(0)) > MaxID, IDs(IDs.GetUpperBound(0)), MaxID))
                If Str2.GetUpperBound(0) > 1 Then
                    For i = 2 To Str2.GetUpperBound(0)
                        If Str2(i).Contains("=") Then
                            kolonki(i - 1, kolonki.GetUpperBound(1)) = WordWrap(Str2(i), "=", "Left")
                            kolids(i - 1, kolids.GetUpperBound(1)) = WordWrap(Str2(i), "=", "Right")
                        Else
                            kolonki(i - 1, kolonki.GetUpperBound(1)) = Str2(i)
                        End If
                    Next
                End If
            Loop

            ReDim idxIDs(MaxID)

            For i = 1 To IDs.GetUpperBound(0)
                idxIDs(IDs(i)) = i
            Next
        End If

    End Sub

    Public Sub New(ByVal Path As String)

        LoadIDs(Path)

    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Count = Names.GetUpperBound(0)
        End Get
    End Property

    Public ReadOnly Property Name(ByVal ID As String) As String
        Get
            On Error Resume Next
            Name = Names(idxIDs(CInt(ID)))
            If Err.Number <> 0 Then
                Name = CStr(ID)
            End If
        End Get
    End Property

    Public ReadOnly Property ID(ByVal Name As String) As Integer
        Get
            Dim i As Integer
            For i = 1 To Names.GetUpperBound(0)
                If Names(i) = Name Then
                    ID = IDs(i)
                    Exit For
                End If
            Next
            ID = 0
        End Get
    End Property
    Public ReadOnly Property ID(ByVal Combo As System.Windows.Forms.ComboBox) As Integer
        Get
            ID = IDs(Combo.SelectedIndex + 1)
        End Get
    End Property

    Public Sub FillCombo(ByRef Combo As System.Windows.Forms.ComboBox)

        Dim i As Integer

        Combo.Items.Clear()

        Combo.Items.Add(">>Без фильтра")

        For i = 1 To Count
            Combo.Items.Add(Names(i))
        Next

        Combo.Sorted = True

        For i = 0 To Combo.Items.Count - 1
            If Combo.Items(i).ToString = ">>Без фильтра" Then
                Combo.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub

    Public ReadOnly Property IsTunable(ByVal ID As Integer) As Boolean
        Get
            Dim i = idxIDs(ID)
            Dim j = kolonki(1, idxIDs(ID))
            If kolonki(1, idxIDs(ID)) <> "" Then
                IsTunable = True
            Else
                IsTunable = False
            End If
        End Get
    End Property

    Public ReadOnly Property TunableValue(ByVal ID As Integer, ByVal num As Integer, ByVal L As cLogs.Log) As String
        Get
            If IsTunable(ID) = False Then
                TunableValue = ""
                Exit Property
            End If
            If kolids(num, idxIDs(ID)) = "" Then
                If kolonki(num, idxIDs(ID)) <> "" Then
                    TunableValue = CStr(ValueFromLog(L, kolonki(num, idxIDs(ID))))
                Else
                    TunableValue = ""
                End If
            Else
                Select Case kolids(num, idxIDs(ID))
                    Case "item"
                        If Items Is Nothing Then
                            TunableValue = CStr(ID)
                        Else
                            TunableValue = Items.Name((ValueFromLog(L, kolonki(num, idxIDs(ID)))))
                        End If
                    Case "skill"
                        If locSkills Is Nothing Then
                            TunableValue = CStr(ID)
                        Else
                            TunableValue = locSkills.Name((ValueFromLog(L, kolonki(num, idxIDs(ID)))))
                        End If
                    Case "quest"
                        If Quests Is Nothing Then
                            TunableValue = CStr(ID)
                        Else
                            TunableValue = Quests.Name((ValueFromLog(L, kolonki(num, idxIDs(ID)))))
                        End If
                    Case "npc"
                        If NPC Is Nothing Then
                            TunableValue = CStr(ID)
                        Else
                            'TunableValue = NPC.Name((ValueFromLog(L, kolonki(num, idxIDs(ID))).ToString.Substring(2)))
                            TunableValue = NPC.Name(ValueFromLog(L, kolonki(num, idxIDs(ID))))
                        End If
                End Select

            End If
        End Get
    End Property

End Class

Public Class cNPC

    Private IDs() As Integer
    Private Names() As String

    Private idxIDs() As Integer

    Public Sub LoadNPC(ByVal Path As String)

        Dim F As System.IO.StreamReader
        Dim Str As String
        Dim Str2() As String

        Dim MaxID As Integer
        Dim i As Integer
        Dim CountID As Integer

        ReDim IDs(0)
        ReDim Names(0)

        On Error Resume Next
        F = System.IO.File.OpenText(Path)
        If Err.Number <> 0 Then
        Else

            Do While Not F.EndOfStream
                Str = F.ReadLine
                CountID = CountID + 1
            Loop
            ReDim IDs(CountID)
            ReDim Names(CountID)
            CountID = 0
            F.Close()
            F = System.IO.File.OpenText(Path)
            Do While Not F.EndOfStream
                Str = F.ReadLine
                'Str2 = Words(Str, Chr(9))
                Str2 = Str.Split(Chr(9))
                CountID = CountID + 1
                IDs(CountID) = CInt(WordWrap(Str2(1), "=", "Right")) + 1000000
                Names(CountID) = WordWrap(Str2(2), "=", "Right") '.Replace("[", "").Replace("]", "")
                MaxID = CInt(IIf(IDs(CountID) > MaxID, IDs(CountID), MaxID))
            Loop

            ReDim idxIDs(MaxID)

            For i = 1 To IDs.GetUpperBound(0)
                idxIDs(IDs(i)) = i
            Next

            F.Close()

        End If

    End Sub

    Public Sub New(ByVal Path As String)

        LoadNPC(Path)

    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Count = Names.GetUpperBound(0)
        End Get
    End Property

    Public ReadOnly Property Name(ByVal ID As String) As String
        Get
            On Error Resume Next
            Name = Names(idxIDs(CInt(ID)))
            If Err.Number <> 0 Then
                Name = CStr(ID)
            End If
        End Get
    End Property

    Public ReadOnly Property ID(ByVal Name As String) As Integer
        Get
            Dim i As Integer
            For i = 1 To Names.GetUpperBound(0)
                If Names(i) = Name Then
                    ID = IDs(i)
                    Exit For
                End If
            Next
            ID = 0
        End Get
    End Property

End Class

Public Class cQuests

    Private IDs() As Integer
    Private Names() As String

    Private idxIDs() As Integer

    Public Sub LoadQuests(ByVal Path As String)

        Dim F As System.IO.StreamReader
        Dim Str As String
        Dim Str2() As String

        Dim MaxID As Integer
        Dim i As Integer
        Dim CountID As Integer

        ReDim IDs(0)
        ReDim Names(0)

        On Error Resume Next
        F = System.IO.File.OpenText(Path)
        If Err.Number <> 0 Then
        Else

            Do While Not F.EndOfStream
                Str = F.ReadLine
                CountID = CountID + 1
            Loop
            ReDim IDs(CountID)
            ReDim Names(CountID)
            CountID = 0
            F.Close()
            F = System.IO.File.OpenText(Path)
            Do While Not F.EndOfStream
                Str = F.ReadLine
                'Str2 = Words(Str, Chr(9))
                Str2 = Str.Split(Chr(9))
                CountID = CountID + 1
                IDs(CountID) = CInt(WordWrap(Str2(2), "=", "Right"))
                Names(CountID) = WordWrap(Str2(4), "=", "Right") '.Replace("[", "").Replace("]", "")
                MaxID = CInt(IIf(IDs(CountID) > MaxID, IDs(CountID), MaxID))
            Loop

            ReDim idxIDs(MaxID)

            For i = 1 To IDs.GetUpperBound(0)
                idxIDs(IDs(i)) = i
            Next

            F.Close()

        End If

    End Sub

    Public Sub New(ByVal Path As String)

        LoadQuests(Path)

    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Count = Names.GetUpperBound(0)
        End Get
    End Property

    Public ReadOnly Property Name(ByVal ID As String) As String
        Get
            On Error Resume Next
            Name = Names(idxIDs(CInt(ID)))
            If Err.Number <> 0 Then
                Name = CStr(ID)
            End If
        End Get
    End Property

    Public ReadOnly Property ID(ByVal Name As String) As Integer
        Get
            Dim i As Integer
            For i = 1 To Names.GetUpperBound(0)
                If Names(i) = Name Then
                    ID = IDs(i)
                    Exit For
                End If
            Next
            ID = 0
        End Get
    End Property

End Class

Public Class cSkills
    Private IDs() As Integer
    Private Names() As String



    Private idxIDs() As Integer



    Public Sub LoadSkills(ByVal Path As String)

        Dim F As System.IO.StreamReader
        Dim Str As String
        Dim Str2() As String

        Dim MaxID As Integer
        Dim i As Integer
        Dim CountID As Integer = 0

        ReDim IDs(0)
        ReDim Names(0)

        On Error Resume Next
        F = System.IO.File.OpenText(Path)
        If Err.Number <> 0 Then
        Else
            Do While Not F.EndOfStream
                Str = F.ReadLine
                Str2 = Str.Split(Chr(9))
                If WordWrap(Str2(2), "=", "Right") = "1" Then
                    CountID = CountID + 1
                End If
            Loop
            F.Close()
            ReDim IDs(CountID)
            ReDim Names(CountID)
            CountID = 0
            F = System.IO.File.OpenText(Path)
            Do While Not F.EndOfStream
                Str = F.ReadLine
                'Str2 = Words(Str, Chr(9))
                Str2 = Str.Split(Chr(9))
                If WordWrap(Str2(2), "=", "Right") = "1" Then
                    CountID = CountID + 1
                    IDs(CountID) = CInt(WordWrap(Str2(1), "=", "Right"))
                    Names(CountID) = WordWrap(Str2(3), "=", "Right") '.Replace("[", "").Replace("]", "")
                    MaxID = CInt(IIf(IDs(CountID) > MaxID, IDs(CountID), MaxID))
                End If
            Loop

            ReDim idxIDs(MaxID)

            For i = 1 To IDs.GetUpperBound(0)
                idxIDs(IDs(i)) = i
            Next

            F.Close()

        End If

    End Sub

    Public Sub New(ByVal Path As String)

        LoadSkills(Path)

    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Count = Names.GetUpperBound(0)
        End Get
    End Property

    Public ReadOnly Property Name(ByVal ID As String) As String
        Get
            On Error Resume Next
            Name = Names(idxIDs(CInt(ID)))
            If Err.Number <> 0 Then
                Name = CStr(ID)
            End If
        End Get
    End Property

    Public ReadOnly Property ID(ByVal Name As String) As Integer
        Get
            Dim i As Integer
            For i = 1 To Names.GetUpperBound(0)
                If Names(i) = Name Then
                    ID = IDs(i)
                    Exit For
                End If
            Next
            ID = 0
        End Get
    End Property

End Class

Module Main

    Public ParametersString(30) As String

    Public MaxRows As Integer

    Public Structure sPaths
        Friend LogIDs As String
        Friend ItemName As String
        Friend Logs As String
        Friend Skills As String
        Friend Quests As String
        Friend NPC As String
    End Structure



    Public Paths As sPaths

    Public Items As cItems
    Public LogIDs As cLogIDs

    Public Logs As cLogs

    Public locSkills As cSkills

    Public Quests As cQuests

    Public NPC As cNPC

    Public LoadNamesOnLaunch As String = "0"
    Public Function ValueFromLog(ByVal L As cLogs.Log, ByVal pName As String) As String



        Select Case pName
            Case "act_time"
                ValueFromLog = L.act_time
            Case "log_id"
                ValueFromLog = L.log_id
            Case "actor"
                ValueFromLog = L.actor
            Case "actor_account"
                ValueFromLog = L.actor_account
            Case "target"
                ValueFromLog = L.target
            Case "target_account"
                ValueFromLog = L.target_account
            Case "location_x"
                ValueFromLog = L.location_x
            Case "location_y"
                ValueFromLog = L.location_y
            Case "location_z"
                ValueFromLog = L.location_z
            Case "etc_str1"
                ValueFromLog = L.etc_str1
            Case "etc_str2"
                ValueFromLog = L.etc_str2
            Case "etc_str3"
                ValueFromLog = L.etc_str3
            Case "etc_num1"
                ValueFromLog = L.etc_num1
            Case "etc_num2"
                ValueFromLog = L.etc_num2
            Case "etc_num3"
                ValueFromLog = L.etc_num3
            Case "etc_num4"
                ValueFromLog = L.etc_num4
            Case "etc_num5"
                ValueFromLog = L.etc_num5
            Case "etc_num6"
                ValueFromLog = L.etc_num6
            Case "etc_num7"
                ValueFromLog = L.etc_num7
            Case "etc_num8"
                ValueFromLog = L.etc_num8
            Case "etc_num9"
                ValueFromLog = L.etc_num9
            Case "etc_num10"
                ValueFromLog = L.etc_num10
            Case "STR_actor"
                ValueFromLog = L.STR_actor
            Case "STR_actor_account"
                ValueFromLog = L.STR_actor_account
            Case "STR_target"
                ValueFromLog = L.STR_target
            Case "STR_target_account"
                ValueFromLog = L.STR_target_account
            Case "item_id"
                ValueFromLog = L.item_id
            Case "STR_item"
                ValueFromLog = L.STR_item
            Case "STR_action"
                ValueFromLog = L.STR_action
            Case "Str"
                ValueFromLog = L.Str
        End Select

    End Function

    Public Sub FillParametersString()

        ParametersString(1) = "act_time"
        ParametersString(2) = "log_id"
        ParametersString(3) = "actor"
        ParametersString(4) = "actor_account"
        ParametersString(5) = "target"
        ParametersString(6) = "target_account"
        ParametersString(7) = "location_x"
        ParametersString(8) = "location_y"
        ParametersString(9) = "location_z"
        ParametersString(10) = "etc_str1"
        ParametersString(11) = "etc_str2"
        ParametersString(12) = "etc_str3"
        ParametersString(13) = "etc_num1"
        ParametersString(14) = "etc_num2"
        ParametersString(15) = "etc_num3"
        ParametersString(16) = "etc_num4"
        ParametersString(17) = "etc_num5"
        ParametersString(18) = "etc_num6"
        ParametersString(19) = "etc_num7"
        ParametersString(20) = "etc_num8"
        ParametersString(21) = "etc_num9"
        ParametersString(22) = "etc_num10"
        ParametersString(23) = "STR_actor"
        ParametersString(24) = "STR_actor_account"
        ParametersString(25) = "STR_target"
        ParametersString(26) = "STR_target_account"
        ParametersString(27) = "item_id"
        ParametersString(28) = "STR_item"
        ParametersString(29) = "STR_action"
        ParametersString(30) = "Str"

    End Sub

End Module

Module Strings
    Public Function WordCount(ByVal Str As String, Optional ByVal Razd As String = " ") As Integer
        'Возвращает количество слов в строке

        Dim i As Integer

        Str = Str.Trim()

        For i = 1 To Str.Length - 1
            If Str.Substring(i, 1) = Razd Then
                WordCount = WordCount + 1
            Else
                If i = Str.Length - 1 Then
                    WordCount = WordCount + 1
                End If
            End If
        Next

    End Function

    Public Function WordWrap(ByVal Str As String, ByVal Symb As String, Optional ByVal Pos As String = "Left") As String
        'Обрезает строку вплоть до символа (либо несколькх символов) symb включительно
        'Pos может быть Left или Right. Он задает с какой стороны от символа вернуть строку

        Dim i As Integer
        For i = 0 To Str.Length - 1
            If Str.Substring(i, Symb.Length) = Symb Then
                If Pos = "Left" Then
                    WordWrap = Trim(Str.Substring(0, i + Symb.Length - 1))
                Else
                    WordWrap = Trim(Str.Substring(i + Symb.Length, Str.Length - i - Symb.Length))
                End If
                Exit Function
            End If
        Next

        WordWrap = Str

    End Function

    Public Function Words(ByVal Str As String, ByVal Razd As String) As String()

        Dim wCount As Integer
        Dim i As Integer, j As Integer = 0
        Dim WordStart As Integer = 0
        Dim tWords() As String

        wCount = WordCount(Str, Razd)

        ReDim tWords(wCount)

        For i = 1 To Str.Length - 1
            If (Str.Substring(i, 1) = Razd) Or (Str.Length - 1 = i) Then
                j = j + 1
                If i = Str.Length - 1 Then
                    If WordStart = i Then
                    Else
                        tWords(j) = Str.Substring(WordStart, i - WordStart + 1)
                    End If

                Else
                    If i = WordStart Then
                    Else
                        tWords(j) = Str.Substring(WordStart, i - WordStart)
                    End If
                End If
                WordStart = i + 1
            End If
        Next

        Words = tWords

    End Function
End Module
Public Class ScriptLeecher

#Region "Работа со строками"

    Private Function WordCount(ByVal Str As String, Optional ByVal Razd As String = " ") As Integer
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

    Private Function WordWrap(ByVal Str As String, ByVal Symb As String, Optional ByVal Pos As String = "Left") As String
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

    Private Function Words(ByVal Str As String, ByVal Razd As String) As String()

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

#End Region

    Public S As Skills

    Public S2 As Skills

    Private Sub textSource_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textSource.DoubleClick

        Open.InitialDirectory = System.IO.Directory.GetCurrentDirectory
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then

            textSource.Text = Open.FileName

            Dim F As System.IO.StreamReader
            Dim Str As String
            Dim W() As String
            Dim i As Integer

            F = System.IO.File.OpenText(textSource.Text)

            ID.Items.Clear()
            Level.Items.Clear()
            ID.Text = ""
            Level.Text = ""

            Str = F.ReadLine
            W = Words(Str, Chr(9))
            For i = 1 To W.GetUpperBound(0)
                If W(i).Contains("=") Then
                    ID.Items.Add(WordWrap(W(i), "="))
                    Level.Items.Add(WordWrap(W(i), "="))
                Else
                    ID.Items.Add("Field " & i & " (" & W(i) & ")")
                    Level.Items.Add("Field " & i & " (" & W(i) & ")")
                End If
            Next

        End If

    End Sub

    Private Sub bOpenSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bOpenSource.Click

        If System.IO.File.Exists(textSource.Text) = True Then
            S = New Skills()
            S.LoadFile(textSource.Text, ID.SelectedIndex + 1, Level.SelectedIndex + 1, Me, Status1, ToolStripProgressBar)
        End If

    End Sub

    Private Sub bSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSave.Click
        S.Save(textSave.Text, Me, Status1, ToolStripProgressBar)
    End Sub

    Private Sub textSave_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles textSave.DoubleClick
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            textSave.Text = Open.FileName
        End If
    End Sub


    Private Sub bLoadObraz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLoadObraz.Click

        If System.IO.File.Exists(textSource.Text) = True Then
            S2 = New Skills()
            S2.LoadFile(textSource.Text, ID.SelectedIndex + 1, Level.SelectedIndex + 1, Me, Status1, ToolStripProgressBar)
        End If

    End Sub

    Private Sub rIname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rIname.CheckedChanged

        cGrid.Rows.Clear()

        If rIname.Checked = True Then
            S.FillConvertCombo(Skills.FillComboModes.ByName, sParameter)
        Else
            S.FillConvertCombo(Skills.FillComboModes.ByNumber, sParameter)
        End If

    End Sub

    Private Sub rInumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rInumber.CheckedChanged

        cGrid.Rows.Clear()

        If rIname.Checked = True Then
            S.FillConvertCombo(Skills.FillComboModes.ByName, sParameter)
        Else
            S.FillConvertCombo(Skills.FillComboModes.ByNumber, sParameter)
        End If

    End Sub

    Private Sub rOname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rOname.CheckedChanged

        cGrid.Rows.Clear()

        If rOname.Checked = True Then
            S2.FillConvertCombo(Skills.FillComboModes.ByName, oParameter)
        Else
            S2.FillConvertCombo(Skills.FillComboModes.ByNumber, oParameter)
        End If

    End Sub

    Private Sub rOnumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rOnumber.CheckedChanged

        cGrid.Rows.Clear()

        If rOname.Checked = True Then
            S2.FillConvertCombo(Skills.FillComboModes.ByName, oParameter)
        Else
            S2.FillConvertCombo(Skills.FillComboModes.ByNumber, oParameter)
        End If

    End Sub

    Private Sub bCompute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCompute.Click

        Dim i As Integer, j As Integer
        Dim oMode As Skills.FillComboModes, sMode As Skills.FillComboModes

        For i = 0 To cGrid.Rows.Count - 2 'бляцтво
            For j = 0 To sParameter.Items.Count - 1
                If cGrid.Rows(i).Cells(0).Value.ToString = sParameter.Items(j).ToString Then
                    cGrid.Rows(i).Cells(2).Value = j + 1
                    Exit For
                End If
            Next
            For j = 0 To oParameter.Items.Count - 1
                If cGrid.Rows(i).Cells(1).Value.ToString = oParameter.Items(j).ToString Then
                    cGrid.Rows(i).Cells(3).Value = j + 1
                    Exit For
                End If
            Next
        Next

        If rIname.Checked = True Then
            sMode = Skills.FillComboModes.ByName
        Else
            sMode = Skills.FillComboModes.ByNumber
        End If

        If rOname.Checked = True Then
            oMode = Skills.FillComboModes.ByName
        Else
            oMode = Skills.FillComboModes.ByNumber
        End If

        S.ConvertParameters(cGrid, S2, sMode, oMode, Me, Status1)

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Form.ActiveForm.Dispose()
    End Sub
End Class

Module Main2

    Public Structure Forms
        Friend Cont As ScriptLeecher
    End Structure

    Public F As Forms

    Sub Main()

        F.Cont = New ScriptLeecher

        F.Cont.ShowDialog()

    End Sub

End Module

Public Class Skill

#Region "Работа со строками"

    Private Function WordCount(ByVal Str As String, Optional ByVal Razd As String = " ") As Integer
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

    Private Function WordWrap(ByVal Str As String, ByVal Symb As String, Optional ByVal Pos As String = "Left") As String
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

    Private Function Words(ByVal Str As String, ByVal Razd As String) As String()

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

#End Region

    Private sString As String

    Private IDfield As Integer
    Private Levelfield As Integer

    Private Structure Mass
        Friend FieldsCount As Integer
        Friend FieldsNames() As String
        Friend FieldsValues() As String
    End Structure

    Private M As Mass

    Public Sub New(ByVal Str As String, ByVal skillID As Integer, ByVal skillLevel As Integer)
        IDfield = skillID
        Levelfield = skillLevel
        FileString = Str
    End Sub

    Private Sub AnalyseString(ByVal Str As String, ByVal ID As Integer, ByVal Level As Integer)

        Dim W() As String
        Dim i As Integer

        Str = Str.Replace(" ", "").Replace(Chr(9) & Chr(9), Chr(9))
        W = Words(Str, Chr(9))

        IDfield = ID
        Levelfield = Level

        M.FieldsCount = W.GetUpperBound(0)
        ReDim M.FieldsNames(M.FieldsCount)
        ReDim M.FieldsValues(M.FieldsCount)

        For i = 1 To M.FieldsCount
            If W(i).Contains("=") = True Then
                M.FieldsNames(i) = WordWrap(W(i), "=", "Left")
                M.FieldsValues(i) = WordWrap(W(i), "=", "Right")
            Else
                M.FieldsNames(i) = "Field " & i
                M.FieldsValues(i) = W(i)
            End If
        Next

    End Sub

    Public Property FileString() As String
        Get
            FileString = sString
        End Get
        Set(ByVal value As String)
            sString = value
            AnalyseString(sString, IDfield, Levelfield)
        End Set
    End Property

    Public ReadOnly Property FieldsCount() As Integer
        Get
            FieldsCount = M.FieldsCount
        End Get
    End Property

    Public Property FieldValue(ByVal Num As Integer) As String
        Get
            If Num > M.FieldsCount Then
                FieldValue = ""
            Else
                FieldValue = M.FieldsValues(Num)
            End If
        End Get
        Set(ByVal value As String)
            If Num < M.FieldsCount Then
                M.FieldsValues(Num) = value
            End If
        End Set
    End Property

    Public Property FieldValue(ByVal Name As String) As String
        Get
            Dim i As Integer
            FieldValue = ""
            For i = 1 To M.FieldsCount
                If M.FieldsNames(i) = Name Then
                    FieldValue = M.FieldsValues(i)
                    Exit For
                End If
            Next
        End Get
        Set(ByVal value As String)
            Dim i As Integer
            For i = 1 To M.FieldsCount
                If M.FieldsNames(i) = Name Then
                    M.FieldsValues(i) = value
                    Exit For
                End If
            Next
        End Set
    End Property


    Public Property FieldName(ByVal Num As Integer) As String
        Get
            If Num > M.FieldsCount Then
                FieldName = ""
            Else
                FieldName = M.FieldsNames(Num)
            End If
        End Get
        Set(ByVal value As String)
            If Num < M.FieldsCount Then
                M.FieldsNames(Num) = value
            End If
        End Set
    End Property

    Public Function GetString() As String

        Dim i As Integer
        Dim Str As String = ""

        For i = 1 To M.FieldsCount
            If FieldName(i).Length >= 5 Then
                If FieldName(i).Substring(0, 5) = "Field" Then
                    Str = Str & FieldValue(i)
                Else
                    Str = Str & FieldName(i) & "=" & FieldValue(i)
                End If
            Else
                Str = Str & FieldName(i) & "=" & FieldValue(i)
            End If
            If i < M.FieldsCount Then
                Str = Str & Chr(9)
            End If
        Next

        GetString = Str

    End Function

    Public ReadOnly Property ID() As Integer
        Get
            If IDfield > 0 Then
                ID = CInt(M.FieldsValues(IDfield))
            Else
                ID = 0
            End If
        End Get
    End Property

    Public ReadOnly Property Level() As Integer
        Get
            If Levelfield > 0 Then
                Level = CInt(M.FieldsValues(Levelfield))
            Else
                Level = 0
            End If
        End Get
    End Property

End Class

Public Class Skills

    Private pSkills() As Skill

    Private Structure skillID
        Public ID As Integer
        Public Level As Integer
    End Structure

    Public Enum FillComboModes
        ByNumber = 1
        ByName = 2
    End Enum

    Private sID As skillID

    Private skillIDsLevels() As Integer

    Private Idx(0, 0) As Integer

    Public Sub LoadFile(ByVal Path As String, ByVal ID As Integer, ByVal Level As Integer, ByRef Form As System.Windows.Forms.Form, ByRef Status As System.Windows.Forms.ToolStripStatusLabel, ByRef ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar)

        Dim F As System.IO.StreamReader
        Dim Str As String = Nothing
        Dim sCount As Integer, i As Integer, j As Integer
        Dim D1 As Integer, D2 As Integer
        Dim CurP As Integer, Points As String

        F = System.IO.File.OpenText(Path)

        sID.ID = ID
        sID.Level = Level

        ToolStripProgressBar.Maximum = CInt(F.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        Do While Not F.EndOfStream

            Try
                Str = F.ReadLine
            Catch ex As Exception
                MessageBox.Show("File reading error. Line :" & sCount & vbNewLine & Str, "File error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ToolStripProgressBar.Value = 0
                F.Close()
                Exit Sub
            End Try
            ToolStripProgressBar.Value = CInt(F.BaseStream.Position)

            Try
                If Str.StartsWith("//") = False And Str.Trim <> "" Then
                    sCount = sCount + 1
                    ReDim Preserve pSkills(sCount)
                    pSkills(sCount) = New Skill(Str, ID, Level)
                    If D1 < CInt(pSkills(sCount).FieldValue(ID)) Then
                        D1 = CInt(pSkills(sCount).FieldValue(ID))
                    End If
                    If D2 < CInt(pSkills(sCount).FieldValue(Level)) Then
                        D2 = CInt(pSkills(sCount).FieldValue(Level))
                    End If
                    If sCount / 300 = Int(sCount / 300) Then
                        CurP = CurP + 1
                        If CurP = 5 Then
                            CurP = 0
                        End If
                        Points = ""
                        For i = 0 To CurP
                            Points = Points & "."
                        Next
                        Status.Text = "Loading file" & Points
                        Form.Update()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error data conversion. Line Structure must be same like first line. Commentaries existing? Line :" & sCount & vbNewLine & Str, "Structure error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ToolStripProgressBar.Value = 0
                F.Close()
                Exit Sub
            End Try
            
        Loop

        ToolStripProgressBar.Value = 0
        F.Close()

        ReDim Idx(D1, D2)
        ReDim skillIDsLevels(D1)

        For i = 1 To pSkills.GetUpperBound(0)
            Idx(CInt(pSkills(i).FieldValue(ID)), CInt(pSkills(i).FieldValue(Level))) = i
            If skillIDsLevels(CInt(pSkills(i).FieldValue(ID))) < CDbl(pSkills(i).FieldValue(Level)) Then
                skillIDsLevels(CInt(pSkills(i).FieldValue(ID))) = CInt(pSkills(i).FieldValue(Level))
            End If
            If i / 300 = Int(i / 300) Then
                If CurP = 5 Then
                    CurP = 0
                End If
                Points = ""
                For j = 0 To CurP
                    Points = Points & "."
                Next
                Status.Text = "Loading file" & Points
                Form.Update()
            End If
        Next

        Status.Text = "Ready"
        Form.Update()

    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Count = pSkills.GetUpperBound(0)
        End Get
    End Property

    Public Property SkillByID(ByVal ID As Integer, ByVal Level As Integer) As Skill
        Get
            SkillByID = Nothing
            If ID <= Idx.GetUpperBound(0) Then
                If Level <= Idx.GetUpperBound(1) Then
                    If Idx(ID, Level) > 0 Then
                        SkillByID = pSkills(Idx(ID, Level))
                    End If
                End If
            End If
        End Get
        Set(ByVal value As Skill)
            pSkills(Idx(ID, Level)) = value
        End Set
    End Property

    Public Sub FillIDList(ByRef List As Windows.Forms.ComboBox)

        Dim i As Integer, j As Integer

        List.Items.Clear()

        For i = 1 To Idx.GetUpperBound(0)
            For j = 1 To Idx.GetUpperBound(1)
                If Idx(i, j) > 0 Then
                    List.Items.Add(i)
                    Exit For
                End If
            Next
        Next

    End Sub

    Public Sub FillLevelList(ByRef List As Windows.Forms.ComboBox, ByVal ID As Integer)

        Dim i As Integer

        List.Items.Clear()

        For i = 1 To skillIDsLevels(ID)
            List.Items.Add(i)
        Next

    End Sub

    Private Sub AddSkillToGrid(ByRef Grid As Windows.Forms.DataGridView, ByVal cSkill As Skill)

        Dim i As Integer

        Grid.Rows.Add()

        For i = 1 To cSkill.FieldsCount
            Grid.Rows(Grid.Rows.Count - 2).Cells(i - 1).Value = cSkill.FieldValue(i)
        Next

    End Sub

    Private Sub FillGridNames(ByRef Grid As Windows.Forms.DataGridView, ByVal cSkill As Skill)

        Dim i As Integer

        For i = 1 To cSkill.FieldsCount
            Grid.Columns.Add(cSkill.FieldName(i), cSkill.FieldName(i))
        Next

    End Sub

    Public Sub FillGridID(ByRef Grid As Windows.Forms.DataGridView, ByVal ID As Integer, Optional ByVal Level As Integer = 0)

        Dim i As Integer

        Grid.Rows.Clear()
        Grid.Columns.Clear()

        If Level = 0 Then
            For i = 1 To Idx.GetUpperBound(1)
                If Idx(ID, i) > 0 Then
                    FillGridNames(Grid, pSkills(Idx(ID, i)))
                    Exit For
                End If
            Next
        Else
            FillGridNames(Grid, pSkills(Idx(ID, Level)))
        End If

        If Level = 0 Then
            For i = 1 To Idx.GetUpperBound(1)
                If Idx(ID, i) > 0 Then
                    AddSkillToGrid(Grid, pSkills(Idx(ID, i)))
                End If
            Next
        Else
            AddSkillToGrid(Grid, pSkills(Idx(ID, Level)))
        End If

    End Sub

    Public Sub UpdateSkill(ByVal Grid As System.Windows.Forms.DataGridView, ByVal Row As Integer)

        Dim i As Integer
        Dim pS As Skill

        pS = pSkills(Idx(CInt(Grid.Rows(Row).Cells(sID.ID - 1).Value), CInt(Grid.Rows(Row).Cells(sID.Level - 1).Value)))

        For i = 1 To pS.FieldsCount
            pS.FieldValue(i) = CStr(Grid.Rows(Row).Cells(i - 1).Value)
        Next

    End Sub

    Public Sub Save(ByVal Path As String, ByRef Form As System.Windows.Forms.Form, ByRef Status As System.Windows.Forms.ToolStripStatusLabel, ByRef ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar)

        Dim F2 As System.IO.StreamWriter
        Dim i As Integer, j As Integer
        Dim CurP As Integer, Points As String

        F2 = New System.IO.StreamWriter(Path, False, System.Text.Encoding.Unicode, 1)

        Status.Text = "Saving file"
        Form.Update()

        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = Count

        For i = 1 To Count
            F2.WriteLine(pSkills(i).GetString)
            ToolStripProgressBar.Value = i
            If i / 300 = Int(i / 300) Then
                If CurP = 5 Then
                    CurP = 0
                End If
                Points = ""
                For j = 0 To CurP
                    Points = Points & "."
                Next
                Status.Text = "Saving file" & Points
                Form.Update()
            End If
        Next

        F2.Close()
        ToolStripProgressBar.Value = 0

        Status.Text = "Ready"
        Form.Update()


    End Sub

    Public Sub Search(ByVal SearchString As String, ByRef Grid As Windows.Forms.DataGridView)

        Dim i As Integer, j As Integer
        Dim Res(0) As Integer

        Grid.Rows.Clear()
        Grid.Columns.Clear()

        For i = 1 To Count
            For j = 1 To pSkills(i).FieldsCount
                If pSkills(i).FieldValue(j).Contains(SearchString) Then
                    ReDim Preserve Res(Res.GetUpperBound(0) + 1)
                    Res(Res.GetUpperBound(0)) = i
                    Exit For
                End If
            Next
        Next

        If Res.GetUpperBound(0) > 0 Then
            FillGridMass(Res, Grid)
        End If

    End Sub

    Private Sub FillGridMass(ByVal Mass() As Integer, ByRef Grid As System.Windows.Forms.DataGridView)

        Dim i As Integer
        Dim MaxCount As Integer = 0

        For i = 1 To Mass.GetUpperBound(0)
            If pSkills(Mass(i)).FieldsCount > MaxCount Then
                MaxCount = pSkills(Mass(i)).FieldsCount
            End If
        Next

        For i = 1 To MaxCount
            Grid.Columns.Add("Field" & i, "Field " & i)
        Next

        For i = 1 To Mass.GetUpperBound(0)
            AddSkillToGrid(Grid, pSkills(Mass(i)))
        Next

    End Sub

    Public Sub FillConvertCombo(ByVal Mode As FillComboModes, ByVal Combo As Windows.Forms.DataGridViewComboBoxColumn)

        Dim i As Integer, j As Integer, k As Integer
        Dim Str(0) As String
        Dim Flag As Boolean
        Dim MinFieldCount As Integer = 1000000

        Combo.Items.Clear()

        If Mode = FillComboModes.ByName Then
            For i = 1 To pSkills.GetUpperBound(0)
                For j = 1 To pSkills(i).FieldsCount
                    If pSkills(i).FieldName(j).Length >= 5 Then
                        If pSkills(i).FieldName(j).Substring(0, 5) <> "Field" Then
                            If Str.GetUpperBound(0) > 0 Then
                                For k = 1 To Str.GetUpperBound(0)
                                    Flag = False
                                    If pSkills(i).FieldName(j) = Str(k) Then
                                        Flag = True
                                        Exit For
                                    End If
                                Next
                                If Flag = False Then
                                    ReDim Preserve Str(Str.GetUpperBound(0) + 1)
                                    Str(Str.GetUpperBound(0)) = pSkills(i).FieldName(j)
                                End If
                            Else
                                ReDim Preserve Str(Str.GetUpperBound(0) + 1)
                                Str(Str.GetUpperBound(0)) = pSkills(i).FieldName(j)
                            End If
                        End If
                    End If
                Next
            Next
            For i = 1 To Str.GetUpperBound(0)
                Combo.Items.Add(Str(i))
            Next
        End If

        If Mode = FillComboModes.ByNumber Then
            For i = 1 To pSkills.GetUpperBound(0)
                If pSkills(i).FieldsCount < MinFieldCount Then
                    MinFieldCount = pSkills(i).FieldsCount
                End If
            Next
            For i = 1 To MinFieldCount
                Combo.Items.Add("Field" & i & " (" & pSkills(1).FieldValue(i) & ")")
            Next
        End If


    End Sub

    Public Sub ConvertParameters(ByRef Grid As Windows.Forms.DataGridView, ByRef S As Skills, ByVal SourceMode As FillComboModes, ByVal ObrazMode As FillComboModes, ByRef Form As System.Windows.Forms.Form, ByRef Status As System.Windows.Forms.ToolStripStatusLabel)

        Dim i As Integer, j As Integer, k As Integer
        Dim SourceField As Integer, ObrazField As Integer
        Dim tempSkill As Skill
        Dim CurP As Integer, Points As String

        Status.Text = "Parameter analyzing"
        Form.Update()

        For i = 1 To pSkills.GetUpperBound(0)
            If S.SkillByID(pSkills(i).ID, pSkills(i).Level) Is Nothing Then
            Else
                If pSkills(i).FileString = "" Or Trim(pSkills(i).FileString).Substring(0, 2) = "//" Then

                Else
                    For j = 0 To Grid.Rows.Count - 2
                        If SourceMode = FillComboModes.ByName Then
                            SourceField = 0
                            For k = 1 To pSkills(i).FieldsCount
                                If CStr(pSkills(i).FieldName(k)) = CStr(Grid.Rows(j).Cells(0).Value) Then
                                    SourceField = k
                                    Exit For
                                End If
                            Next
                        ElseIf SourceMode = FillComboModes.ByNumber Then
                            If (pSkills(i).FieldsCount) < CDbl(Grid.Rows(j).Cells(2).Value) Then
                                SourceField = 0
                            Else
                                SourceField = CInt(Grid.Rows(j).Cells(2).Value)
                            End If
                        End If
                        If SourceField > 0 Then
                            tempSkill = S.SkillByID(pSkills(i).ID, pSkills(i).Level)
                            If ObrazMode = FillComboModes.ByName Then
                                ObrazField = 0
                                For k = 1 To tempSkill.FieldsCount
                                    If tempSkill.FieldName(k) = CStr(Grid.Rows(j).Cells(1).Value) Then
                                        ObrazField = k
                                        Exit For
                                    End If
                                Next
                            ElseIf ObrazMode = FillComboModes.ByNumber Then
                                If tempSkill.FieldsCount < CInt(Grid.Rows(j).Cells(3).Value) Then
                                    ObrazField = 0
                                Else
                                    ObrazField = CInt(Grid.Rows(j).Cells(3).Value)
                                End If
                            End If
                            If ObrazField > 0 Then
                                pSkills(i).FieldValue(SourceField) = tempSkill.FieldValue(ObrazField)
                            End If
                        End If
                    Next
                End If
            End If
            If i / 300 = Int(i / 300) Then
                If CurP = 5 Then
                    CurP = 0
                End If
                Points = ""
                For j = 0 To CurP
                    Points = Points & "."
                Next
                Status.Text = "Parameter analyzing" & Points
                Form.Update()
            End If
        Next

        Status.Text = "Ready"
        Form.Update()

    End Sub

End Class
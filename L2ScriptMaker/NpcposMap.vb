Option Explicit On
Option Strict On
Option Infer On

Imports Microsoft.Win32

Module l2_map_main

#Region "map_constants"

    Public Const map_multiplier As Double = 133.5
    Public Const map_move_x As Integer = 987
    Public Const map_move_y As Integer = 1964

#End Region


    Public info As l2_map_info

End Module

Public Class NpcposMap

#Region "Загрузка формы"

    Private Sub l2_map_container_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        info = New l2_map_info

        Dim imgPath As String
        Try
            imgPath = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\NpcposMap", "imagePath", ""))
        Catch ex As Exception
            imgPath = ""
        End Try

        If imgPath = "" Then
            If System.IO.File.Exists("img.jpg") Then
                imgPath = "img.jpg"
            End If
        End If

        If (imgPath = "") Or System.IO.File.Exists(imgPath) = False Then
            Open.Filter = "Файл с картой l2 (*.jpg)|*.jpg"
            If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
                imgPath = Open.FileName
                Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\NpcposMap", "imagePath", imgPath)
            End If
        End If

        If System.IO.File.Exists(imgPath) Then
            picMap.Image = System.Drawing.Image.FromFile(imgPath)
        End If

        Dim configPath As String
        Try
            configPath = CStr(Registry.GetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\NpcposMap", "configPath", ""))
        Catch ex As Exception
            configPath = ""
        End Try

        If configPath = "" Then
            If System.IO.File.Exists("map_config.txt") Then
                configPath = "map_config.txt"
            End If
        End If
        If (configPath = "") Or System.IO.File.Exists(configPath) = False Then
            Open.Filter = "Файл конфига карты l2 (*.txt)|*.txt"
            If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
                configPath = Open.FileName
                Registry.SetValue("HKEY_CURRENT_USER\Software\L2ScriptMaker\NpcposMap", "configPath", configPath)
            End If
        End If

        If System.IO.File.Exists(configPath) Then
            info.config_path = configPath
        End If


    End Sub

#End Region

#Region "Перемещение карты (мышкой)"

    Private flagMouseDown As Boolean = False
    Private X As Integer, Y As Integer

    Public Declare Function GetCursorPos Lib "user32" (ByRef lpPoint As System.Drawing.Point) As Boolean


    Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim A As System.Drawing.Point
            GetCursorPos(A)
            X = A.X
            Y = A.Y
            Timer.Enabled = True
        End If
    End Sub

    Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            draw_objects()
            Timer.Enabled = False
        End If
    End Sub

    Private Sub picMap_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picMap.MouseLeave
        Timer.Enabled = False
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick

        Dim A As System.Drawing.Point, B As System.Drawing.Point

        GetCursorPos(A)

        B.X = picMap.Location.X + (A.X - X)
        B.Y = picMap.Location.Y + (A.Y - Y)

        CheckForBorderOfMap(B)

        X = A.X
        Y = A.Y

        picMap.Location = B

    End Sub

#End Region

#Region "Перемещение карты (к объекту)"

    Private Sub move_map(ByVal obj As l2_map_file_string)

        Dim point As System.Drawing.Point

        'On Error Resume Next

        If obj.drawing_objects.GetUpperBound(0) > 0 Then
            point = obj.drawing_objects(1).points(1)

            Dim newPoint As System.Drawing.Point

            newPoint.X = (-point.X + CInt(Me.Width / 2))
            newPoint.Y = (-point.Y + CInt(Me.Height / 2))

            CheckForBorderOfMap(newPoint)

            picMap.Location = newPoint

            draw_objects()
        End If


    End Sub

    Private Sub CheckForBorderOfMap(ByRef Loc As System.Drawing.Point)

        If Loc.X > 0 Then
            Loc.X = 0
        End If
        If Loc.Y > 0 Then
            Loc.Y = 0
        End If

        If -Loc.X > picMap.Width - Me.Size.Width Then
            Loc.X = -(picMap.Width - Me.Size.Width)
        End If

        If -Loc.Y > picMap.Height - Me.Size.Height Then
            Loc.Y = -(picMap.Height - Me.Size.Height)
        End If

    End Sub

#End Region

#Region "Прорисовка объектов"

    Private Structure str_draw_object
        Friend points() As System.Drawing.Point
        Friend type As l2_map_drawing_parameters.drawing_types
        Friend color As System.Drawing.Color
        Friend draw_width As Integer
    End Structure

    Private Structure str_draw_objects
        Friend idx As Integer 'индекс в объекте info (для добавления-удаления)
        Friend draw_object() As str_draw_object
    End Structure


    Private obj_to_draw(0) As str_draw_objects

    Private Sub add_draw_obj_to_local(ByRef obj As str_draw_objects, ByVal file_string As l2_map_file_string)

        Dim i As Integer, j As Integer
        Dim sdvig As Integer

        If file_string.drawing_objects.GetUpperBound(0) > 0 Then

            sdvig = obj.draw_object.GetUpperBound(0)
            ReDim Preserve obj.draw_object(sdvig + file_string.drawing_objects.GetUpperBound(0))

            For i = 1 To file_string.drawing_objects.GetUpperBound(0)

                obj.draw_object(sdvig + i).color = file_string.drawing_objects(i).drawing_parameters.color
                obj.draw_object(sdvig + i).draw_width = file_string.drawing_objects(i).drawing_parameters.draw_width
                obj.draw_object(sdvig + i).type = file_string.drawing_objects(i).drawing_parameters.drawing_type
                ReDim obj.draw_object(sdvig + i).points(file_string.drawing_objects(i).points.GetUpperBound(0))
                For j = 1 To obj.draw_object(sdvig + i).points.GetUpperBound(0)
                    obj.draw_object(sdvig + i).points(j) = file_string.drawing_objects(i).points(j)
                Next

            Next

        End If


    End Sub

    Private Function create_local_draw_obj(ByVal idx As Integer, Optional ByVal with_collection As Boolean = False) As str_draw_objects

        Dim i As Integer

        Dim temp_obj As str_draw_objects
        ReDim temp_obj.draw_object(0)

        temp_obj.idx = idx

        add_draw_obj_to_local(temp_obj, info.file_strings(idx))

        If with_collection = True Then

            If info.file_strings(idx).obj_idx_count > 0 Then

                For i = 1 To info.file_strings(idx).obj_idx_count

                    add_draw_obj_to_local(temp_obj, info.file_strings(info.file_strings(idx).obj_idx(i)))

                Next

            End If

        End If

        create_local_draw_obj = temp_obj

    End Function


    Private Sub add_draw_obj(ByVal idx As Integer)

        Dim i As Integer
        Dim need_to_add As Boolean = True


        If obj_to_draw.GetUpperBound(0) > 0 Then
            For i = 1 To obj_to_draw.GetUpperBound(0)
                If obj_to_draw(i).idx = idx Then
                    need_to_add = False
                End If
            Next
        Else
            need_to_add = True
        End If

        If need_to_add = True Then

            ReDim Preserve obj_to_draw(obj_to_draw.GetUpperBound(0) + 1)

            obj_to_draw(obj_to_draw.GetUpperBound(0)) = create_local_draw_obj(idx)

        End If

    End Sub

    Private Sub remove_draw_obj(ByVal idx As Integer)

        Dim i As Integer
        Dim num As Integer = 0
        Dim temp_mass() As str_draw_objects
        Dim founded As Boolean

        If obj_to_draw.GetUpperBound(0) = 0 Then
            Exit Sub
        End If

        founded = False
        For i = 1 To obj_to_draw.GetUpperBound(0)
            If obj_to_draw(i).idx = idx Then
                founded = True
                Exit For
            End If
        Next

        If founded = False Then
            Exit Sub
        End If

        If obj_to_draw.GetUpperBound(0) = 1 Then
            ReDim obj_to_draw(0)
            Exit Sub
        End If

        If obj_to_draw.GetUpperBound(0) > 0 Then
            ReDim temp_mass(obj_to_draw.GetUpperBound(0) - 1)
            For i = 1 To obj_to_draw.GetUpperBound(0)
                If num > 0 Then
                    temp_mass(i - 1) = obj_to_draw(i)
                Else
                    If obj_to_draw(i).idx = idx Then
                        num = 1
                    Else
                        temp_mass(i) = obj_to_draw(i)
                    End If
                End If
            Next
        End If

        If num > 0 Then
            obj_to_draw = temp_mass
        End If

    End Sub

    Private Function check_obj_visibility(ByVal obj As str_draw_object) As Boolean
        'Если хоть одна точка видна, рисуем весь объект

        Dim i As Integer
        Dim t_v As Boolean
        Dim x As Integer, y As Integer
        Dim xx1 As Integer, yy1 As Integer

        check_obj_visibility = False

        If obj.points.GetUpperBound(0) = 0 Then
            Exit Function
        End If

        For i = 1 To obj.points.GetUpperBound(0)
            t_v = True
            x = obj.points(i).X
            y = obj.points(i).Y

            If x < -picMap.Location.X Then
                t_v = False
            End If
            If y < -picMap.Location.Y Then
                t_v = False
            End If

            xx1 = -picMap.Location.X + Me.Width
            yy1 = -picMap.Location.Y + Me.Height

            If x > xx1 Then
                t_v = False
            End If
            If y > yy1 Then
                t_v = False
            End If

            If t_v = True Then
                check_obj_visibility = True
                Exit Function
            End If

        Next

    End Function

    Private Sub draw_object(ByVal obj As str_draw_objects, ByRef Gr As System.Drawing.Graphics, ByRef loc_pen As System.Drawing.Pen)

        Dim i As Integer, j As Integer
        Dim num1 As Integer, num2 As Integer

        For i = 1 To obj.draw_object.GetUpperBound(0)

            If check_obj_visibility(obj.draw_object(i)) = True Then

                drawed_obj = drawed_obj + 1

                loc_pen.Color = obj.draw_object(i).color
                loc_pen.Width = obj.draw_object(i).draw_width

                If obj.draw_object(i).type = l2_map_drawing_parameters.drawing_types.zone Then

                    For j = 1 To obj.draw_object(i).points.GetUpperBound(0)
                        num1 = j
                        If j = obj.draw_object(i).points.GetUpperBound(0) Then
                            num2 = 1
                        Else
                            num2 = j + 1
                        End If
                        Gr.DrawLine(loc_pen, obj.draw_object(i).points(num1).X, obj.draw_object(i).points(num1).Y, obj.draw_object(i).points(num2).X, obj.draw_object(i).points(num2).Y)
                    Next

                Else

                    For j = 1 To obj.draw_object(i).points.GetUpperBound(0)
                        Gr.DrawRectangle(loc_pen, obj.draw_object(i).points(j).X, obj.draw_object(i).points(j).Y, obj.draw_object(i).draw_width, obj.draw_object(i).draw_width)
                    Next

                End If
            End If
        Next

    End Sub

    Private drawed_obj As Integer

    Private Sub draw_objects()

        Dim i As Integer
        Dim Gr As System.Drawing.Graphics
        Dim loc_pen As New System.Drawing.Pen(Drawing.Color.Red)

        drawed_obj = 0

        picMap.Refresh()

        Gr = picMap.CreateGraphics()

        If obj_to_draw.GetUpperBound(0) > 0 Then
            For i = 1 To obj_to_draw.GetUpperBound(0)
                draw_object(obj_to_draw(i), Gr, loc_pen)
            Next
        End If
        If tree.SelectedNode Is Nothing Then
        Else
            If tree.SelectedNode.Tag Is Nothing Then
            Else
                draw_object(create_local_draw_obj(CInt(tree.SelectedNode.Tag), True), Gr, loc_pen)
            End If
        End If

        'Me.Text = drawed_obj.ToString

    End Sub

#End Region

#Region "Загрузка и сохранение текстового файла с мобами"

    Private Sub bOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bOpenFile.Click

        Open.Filter = "Текстовый файл (*.txt)|*.txt"
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then

            info.file_path = Open.FileName

            Dim i As Integer
            Dim collection_started As Boolean = False
            Dim temp_node As System.Windows.Forms.TreeNode
            Dim show_comments As Boolean = False
            Dim add_node As Boolean

            tree.Nodes.Clear()
            For i = 1 To info.file_strings.GetUpperBound(0)

                If info.file_strings(i).string_type = l2_map_file_string.string_types.collection_start Then
                    If info.file_strings(i).is_indexed = False Then
                        temp_node = tree.Nodes.Add(info.file_strings(i).name_to_display)
                        temp_node.Tag = i
                        temp_node.Nodes.Add("tempnode")
                    End If
                    collection_started = True
                End If

                If collection_started = True Then
                    If info.file_strings(i).string_type = l2_map_file_string.string_types.collection_end Then
                        collection_started = False
                    End If
                Else
                    add_node = False
                    If show_comments = True Then
                        add_node = True
                    Else
                        If info.file_strings(i).string_type = l2_map_file_string.string_types.comment Then
                        Else
                            add_node = True
                        End If
                    End If
                    If add_node = True Then
                        If info.file_strings(i).is_indexed = False Then
                            temp_node = tree.Nodes.Add(info.file_strings(i).name_to_display)
                            temp_node.Tag = i
                            temp_node.Nodes.Add("tempnode")
                        End If
                    End If
                End If
            Next
            i = 1
        End If

    End Sub

    Private Sub bSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSave.Click

        MsgBox("сохранение пока не работает нихуя")

    End Sub

#End Region

#Region "Дерево объектов"

    Private Sub tree_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tree.NodeMouseClick
        On Error Resume Next

        If e.Node.Tag.ToString <> "" Then
            If e.Node.Checked = True Then
                add_draw_obj(CInt(e.Node.Tag))
            Else
                remove_draw_obj(CInt(e.Node.Tag))
            End If
        End If

    End Sub

#End Region

#Region "Поиск"

    Private Sub search()

        Dim i As Integer, j As Integer
        Dim start_index As Integer
        Dim founded_index As Integer = 0

        If text_search.Text.Length < 3 Then
            MsgBox("lenght of search text must be >2")
            Exit Sub
        End If

        If tree.SelectedNode Is Nothing Then
            start_index = 1
        Else
            If tree.SelectedNode.Tag Is Nothing Then
            Else
                start_index = CInt(tree.SelectedNode.Tag)
            End If

        End If

        For i = start_index To info.file_strings.GetUpperBound(0)

            If info.file_strings(i).object_name.Length >= text_search.Text.Length Then
                If info.file_strings(i).object_name.Contains(text_search.Text) Then
                    founded_index = i
                    Exit For
                End If
            End If
        Next
        If founded_index = 0 Then
            If start_index > 1 Then
                For i = 1 To start_index - 1
                    If info.file_strings(i).object_name.Length >= text_search.Text.Length Then
                        If info.file_strings(i).object_name.ToUpper.Contains(text_search.Text.ToUpper) Then
                            founded_index = i
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        If founded_index > 0 Then
            Dim in_nodes As Integer = 0
            For i = 0 To tree.Nodes.Count - 1
                If tree.Nodes(i).Tag Is Nothing Then
                Else
                    If CInt(tree.Nodes(i).Tag) = founded_index Then
                        tree.SelectedNode = tree.Nodes(i)
                        tree.Select()
                        tree.Nodes(i).Expand()
                    End If
                    If CInt(tree.Nodes(i).Tag) > founded_index Then
                        tree.SelectedNode = tree.Nodes(i - 1)
                        tree.Select()
                        tree.Nodes(i - 1).Expand()
                        Exit For
                    End If
                End If
            Next

        End If


    End Sub

    Private Sub button_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_search.Click

        search()

    End Sub

    Private Sub text_search_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles text_search.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            search()
        End If
    End Sub


#End Region

#Region "Дерево объектов - пометка автоматом"

    Private Sub button_select_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_select_all.Click

        Dim i As Integer

        For i = 0 To tree.Nodes.Count - 1
            If tree.Nodes(i).Parent Is Nothing Then
                tree.Nodes(i).Checked = True
                If tree.Nodes(i).Tag Is Nothing Then
                Else
                    add_draw_obj(CInt(tree.Nodes(i).Tag))
                End If
            End If
        Next

    End Sub

    Private Sub button_deselect_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_deselect_all.Click

        Dim i As Integer

        For i = 0 To tree.Nodes.Count - 1
            If tree.Nodes(i).Checked = True Then
                tree.Nodes(i).Checked = False
                If tree.Nodes(i).Tag Is Nothing Then
                Else
                    remove_draw_obj(CInt(tree.Nodes(i).Tag))
                End If
            End If
        Next

    End Sub


#End Region

#Region "Дерево объектов - разворачивание"

    Private Sub tree_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tree.BeforeExpand

        Dim i As Integer, j As Integer
        Dim node_properties As System.Windows.Forms.TreeNode
        Dim node_collection_obj As System.Windows.Forms.TreeNode

        If e.Node.Nodes(0).Text = "tempnode" Then
            e.Node.Nodes.Clear()
            node_properties = e.Node.Nodes.Add("properties")
            With info.file_strings(CInt(e.Node.Tag))
                For i = 1 To .properties.GetUpperBound(0)
                    node_properties.Nodes.Add(.properties(i).simple_name)
                Next
                If .string_type = l2_map_file_string.string_types.collection_start Then
                    For i = CInt(e.Node.Tag) + 1 To info.file_strings.GetUpperBound(0)
                        If info.file_strings(i).string_type = l2_map_file_string.string_types.collection_end Then
                            Exit For
                        End If

                        If info.file_strings(i).string_type = l2_map_file_string.string_types.comment Then
                        Else
                            node_collection_obj = e.Node.Nodes.Add(info.file_strings(i).name_to_display)
                            node_collection_obj.Tag = i
                            node_collection_obj.Nodes.Add("tempnode")
                        End If

                    Next
                End If
                If .obj_idx_count > 0 Then
                    For j = 1 To .obj_idx_count
                        node_collection_obj = e.Node.Nodes.Add(info.file_strings(.obj_idx(j)).name_to_display)
                        node_collection_obj.Tag = .obj_idx(j)
                        node_collection_obj.Nodes.Add("tempnode")
                    Next
                End If
            End With
        End If

    End Sub


#End Region

#Region "Дерево объектов - вывод параметров на экран"

    Private Sub show_panel(ByVal panel_name As String)

        Select Case panel_name
            Case "simple"
                group_simple.Visible = True
                group_coordinates.Visible = False
                group_list.Visible = False
                group_list_table.Visible = False
                group_obj_list.Visible = False
            Case "coordinates"
                group_simple.Visible = False
                group_coordinates.Visible = True
                group_list.Visible = False
                group_list_table.Visible = False
                group_obj_list.Visible = False
            Case "list"
                group_simple.Visible = False
                group_coordinates.Visible = False
                group_list.Visible = True
                group_list_table.Visible = False
                group_obj_list.Visible = False
            Case "list_table"
                group_simple.Visible = False
                group_coordinates.Visible = False
                group_list.Visible = False
                group_list_table.Visible = True
                group_obj_list.Visible = False
            Case "obj_list"
                group_simple.Visible = False
                group_coordinates.Visible = False
                group_list.Visible = False
                group_list_table.Visible = False
                group_obj_list.Visible = True
        End Select

    End Sub

    Private property_index_local As Integer
    Private string_index_local As Integer

    Private need_to_move As Boolean = True

    Private Sub tree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tree.AfterSelect

        Dim i As Integer

        property_index_local = 0
        string_index_local = 0

        If e.Node.Tag Is Nothing Then
            If e.Node.Text = "properties" Then
            Else
                If e.Node.Parent.Text = "properties" Then

                    string_index_local = CInt(e.Node.Parent.Parent.Tag)

                    For i = 0 To e.Node.Parent.Nodes.Count - 1
                        If e.Node.Parent.Nodes(i).Index = e.Node.Index Then
                            property_index_local = i + 1
                            Exit For
                        End If
                    Next

                    Select Case info.file_strings(string_index_local).properties(property_index_local).property_type
                        Case l2_map_file_string_property.file_string_properties_types.empty
                            show_panel("simple")
                            text_simple_value.Text = info.file_strings(string_index_local).properties(property_index_local).simple_name
                        Case l2_map_file_string_property.file_string_properties_types.empty_clear
                            show_panel("simple")
                            text_simple_value.Text = info.file_strings(string_index_local).properties(property_index_local).simple_name
                        Case l2_map_file_string_property.file_string_properties_types.simple
                            show_panel("simple")
                            text_simple_value.Text = info.file_strings(string_index_local).properties(property_index_local).simple_name
                        Case l2_map_file_string_property.file_string_properties_types.simple_with_name
                            show_panel("simple")
                            text_simple_value.Text = info.file_strings(string_index_local).properties(property_index_local).simple_name
                        Case l2_map_file_string_property.file_string_properties_types.coordinate
                            show_panel("coordinates")
                            fill_coordinates_list(info.file_strings(string_index_local).properties(property_index_local))
                        Case l2_map_file_string_property.file_string_properties_types.list
                            show_panel("list")
                            fill_list_list(info.file_strings(string_index_local).properties(property_index_local))
                        Case l2_map_file_string_property.file_string_properties_types.list_table
                            show_panel("list_table")
                            fill_list_table(info.file_strings(string_index_local).properties(property_index_local))
                        Case l2_map_file_string_property.file_string_properties_types.obj_list
                            show_panel("obj_list")
                            fill_list_obj(info.file_strings(string_index_local).properties(property_index_local))
                    End Select

                End If
            End If
        Else
            If need_to_move = True Then
                move_map(info.file_strings(CInt(e.Node.Tag)))
            End If

        End If

    End Sub


#End Region

#Region "Редактирование координат"

    Private Sub fill_coordinates_list(ByVal cur_property As l2_map_file_string_property)

        Dim i As Integer

        list_coordinates.Items.Clear()

        text_coordinate_1.Text = ""
        text_coordinate_2.Text = ""
        text_coordinate_3.Text = ""
        text_coordinate_4.Text = ""


        label_coordinate_1.Text = cur_property.config_parameter.coordinates_names(1)
        label_coordinate_2.Text = cur_property.config_parameter.coordinates_names(2)
        label_coordinate_3.Text = cur_property.config_parameter.coordinates_names(3)
        label_coordinate_4.Text = cur_property.config_parameter.coordinates_names(4)
        If cur_property.config_parameter.coordinates_names(5) = "" Then
            text_coordinate_5.Visible = False
            label_coordinate_5.Visible = False
        Else
            text_coordinate_5.Visible = True
            label_coordinate_5.Visible = True
            text_coordinate_5.Text = ""
            label_coordinate_5.Text = cur_property.config_parameter.coordinates_names(5)
        End If

        If cur_property.anywhere = True Then
        Else
            For i = 1 To cur_property.points.GetUpperBound(0)
                list_coordinates.Items.Add(cur_property.point_string(i))
            Next
            list_coordinates.SelectedIndex = 0
        End If

    End Sub

    Private Sub text_coordinate_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles text_coordinate_1.TextChanged

        On Error Resume Next

        If property_index_local > 0 Then
            info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).x = CInt(text_coordinate_1.Text)
        End If

    End Sub

    Private Sub text_coordinate_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles text_coordinate_2.TextChanged

        On Error Resume Next

        If property_index_local > 0 Then
            info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).y = CInt(text_coordinate_2.Text)
        End If

    End Sub

    Private Sub text_coordinate_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles text_coordinate_3.TextChanged

        On Error Resume Next

        If property_index_local > 0 Then
            info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).z = CInt(text_coordinate_3.Text)
        End If

    End Sub

    Private Sub text_coordinate_4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles text_coordinate_4.TextChanged

        On Error Resume Next

        If property_index_local > 0 Then
            info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).z2 = CInt(text_coordinate_4.Text)
        End If

    End Sub

    Private Sub text_coordinate_5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles text_coordinate_5.TextChanged

        On Error Resume Next

        If property_index_local > 0 Then
            info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).percent = text_coordinate_5.Text
        End If

    End Sub

    Private Sub list_coordinates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list_coordinates.SelectedIndexChanged

        If property_index_local > 0 Then

            text_coordinate_1.Text = info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).x.ToString
            text_coordinate_2.Text = info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).y.ToString
            text_coordinate_3.Text = info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).z.ToString
            text_coordinate_4.Text = info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).z2.ToString
            text_coordinate_5.Text = info.file_strings(string_index_local).properties(property_index_local).points(list_coordinates.SelectedIndex + 1).percent

        End If

    End Sub

#End Region

#Region "Редактирование списка"

    Private Sub fill_list_list(ByVal cur_property As l2_map_file_string_property)

        Dim i As Integer

        list_list.Items.Clear()

        For i = 1 To cur_property.list.GetUpperBound(0)
            list_list.Items.Add(cur_property.list(i))
        Next

    End Sub

    Private Sub list_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list_list.SelectedIndexChanged

        If property_index_local > 0 Then
            text_list.Text = info.file_strings(string_index_local).properties(property_index_local).list(list_list.SelectedIndex + 1)
        End If

    End Sub

    Private Sub text_list_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles text_list.TextChanged

        If property_index_local > 0 Then
            info.file_strings(string_index_local).properties(property_index_local).list(list_list.SelectedIndex + 1) = text_list.Text
        End If

    End Sub

#End Region

#Region "Редактирование таблицы"

    Private Sub fill_list_table(ByVal cur_property As l2_map_file_string_property)

        Dim i As Integer, j As Integer

        grid.Columns.Clear()

        For i = 1 To cur_property.list_table_names.GetUpperBound(0)
            grid.Columns.Add("column" & i.ToString, cur_property.list_table_names(i))
        Next

        For i = 1 To cur_property.table.GetUpperBound(1)
            grid.Rows.Add()
            For j = 1 To cur_property.table.GetUpperBound(0)
                grid.Rows(i - 1).Cells(j - 1).Value = cur_property.table(j, i)
            Next
        Next

    End Sub

    Private Sub grid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellEndEdit

        If property_index_local > 0 Then
            info.file_strings(string_index_local).properties(property_index_local).table(e.ColumnIndex + 1, e.RowIndex + 1) = grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        End If

    End Sub

#End Region

#Region "Просмотр списка объектов"

    Private Sub fill_list_obj(ByVal cur_property As l2_map_file_string_property)

        Dim i As Integer

        label_obj_name.Text = "obj_list: " & cur_property.config_parameter.object_name
        list_obj.Items.Clear()

        For i = 1 To cur_property.obj_list.GetUpperBound(0)
            list_obj.Items.Add(cur_property.obj_list(i))
        Next


    End Sub

#End Region

#Region "По клику мышкой находим кликнутый объект в дереве"

    Private Function check_point_in(ByVal obj As l2_map_file_string, ByVal x As Integer, ByVal y As Integer) As Boolean

        Dim x_center As Double, y_center As Double
        Dim num1 As Integer, num2 As Integer

        Dim multik As Double, sdvig As Double
        Dim y2_center As Double, y2_point As Double

        Dim loc_points() As System.Drawing.Point
        Dim c_points As Integer

        Dim obj_in As Boolean = False

        'Dim radius As Double
        Dim less_x As Integer, less_y As Integer
        Dim check_in_radius As Integer

        Dim log As String

        If obj.drawing_objects.GetUpperBound(0) > 0 Then

            For j = 1 To obj.drawing_objects.GetUpperBound(0)

                If obj.drawing_objects(j).drawing_parameters.drawing_type = l2_map_drawing_parameters.drawing_types.zone Then

                    loc_points = obj.drawing_objects(j).points
                    c_points = loc_points.GetUpperBound(0)

                    If c_points > 2 Then

                        'щитаем центр
                        x_center = 0
                        y_center = 0
                        For k = 1 To c_points
                            x_center = x_center + loc_points(k).X
                            y_center = y_center + loc_points(k).Y
                        Next
                        y_center = y_center / c_points
                        x_center = x_center / c_points

                        less_x = 0
                        less_y = 0
                        check_in_radius = 0
                        For i = 1 To c_points
                            If loc_points(i).X > x Then
                                less_x = less_x + 1
                            Else
                                less_x = less_x - 1
                            End If
                            If loc_points(i).Y > y Then
                                less_y = less_y + 1
                            Else
                                less_y = less_y - 1
                            End If
                        Next

                        If less_x = c_points Or -less_x = c_points Then
                        Else
                            check_in_radius = check_in_radius + 1
                        End If

                        If less_y = c_points Or -less_y = c_points Then
                        Else
                            check_in_radius = check_in_radius + 1
                        End If

                        If check_in_radius = 2 Then

                            log = obj.name_to_display & vbNewLine

                            log = log & "x = " & x & vbNewLine
                            log = log & "y = " & y & vbNewLine

                            log = log & "x_center = " & x_center & vbNewLine
                            log = log & "y_center = " & y_center & vbNewLine

                            'пошли по прямым
                            'если хоть одна не совпала - облом
                            obj_in = True
                            For k = 1 To c_points

                                num1 = k
                                num2 = CInt(IIf(k = c_points, 1, k + 1))

                                log = log & vbNewLine
                                log = log & "num1 = " & num1 & ", num2 = " & num2 & vbNewLine

                                log = log & "loc_points(num1).X = " & loc_points(num1).X & vbNewLine
                                log = log & "loc_points(num1).Y = " & loc_points(num1).Y & vbNewLine
                                log = log & "loc_points(num2).X = " & loc_points(num2).X & vbNewLine
                                log = log & "loc_points(num2).Y = " & loc_points(num2).Y & vbNewLine

                                If loc_points(num1).Y = loc_points(num2).Y Then

                                    If y_center >= loc_points(num1).Y Then
                                        If y >= loc_points(num1).Y Then
                                        Else
                                            obj_in = False
                                            Exit For
                                        End If
                                    Else
                                        If y < loc_points(num1).Y Then
                                        Else
                                            obj_in = False
                                            Exit For
                                        End If
                                    End If

                                Else

                                    If loc_points(num1).X = loc_points(num2).X Then

                                        If x >= loc_points(num1).X Then
                                            If x_center >= loc_points(num1).X Then
                                            Else
                                                obj_in = False
                                                Exit For
                                            End If
                                        Else
                                            If x_center < loc_points(num1).X Then
                                            Else
                                                obj_in = False
                                                Exit For
                                            End If
                                        End If

                                    Else

                                        multik = (loc_points(num1).Y - loc_points(num2).Y) / (loc_points(num1).X - loc_points(num2).X)
                                        sdvig = loc_points(num1).Y - (loc_points(num1).X * multik)

                                        y2_center = x_center * multik + sdvig
                                        y2_point = x * multik + sdvig

                                        log = log & "multik = " & multik & vbNewLine
                                        log = log & "sdvig = " & sdvig & vbNewLine

                                        log = log & "y2_center = " & y2_center & vbNewLine
                                        log = log & "y2_point = " & y2_point & vbNewLine

                                        If y_center >= y2_center Then
                                            If y >= y2_point Then

                                            Else
                                                obj_in = False
                                                Exit For
                                            End If
                                        Else
                                            If y < y2_point Then

                                            Else
                                                obj_in = False
                                                Exit For
                                            End If
                                        End If

                                    End If

                                End If

                                If obj_in = False Then
                                    Exit For
                                End If

                            Next

                            If obj_in = True Then
                                Exit For
                            End If

                        End If

                    End If

                End If

            Next

        End If

        If obj_in = True Then
            text_log.Text = log
        End If

        check_point_in = obj_in

    End Function

    Private Sub picMap_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseClick

        If e.Button = Windows.Forms.MouseButtons.Left Then
        Else
            Exit Sub
        End If

        Dim x As Integer, y As Integer
        Dim i As Integer

        Dim start_index As Integer

        Dim idx_to_select As Integer

        If info.file_strings.GetUpperBound(0) = 0 Then
            Exit Sub
        End If

        If tree.SelectedNode Is Nothing Then
            start_index = 1
        Else
            If tree.SelectedNode.Tag Is Nothing Then
                start_index = 1
            Else
                start_index = CInt(tree.SelectedNode.Tag) + 1
            End If
        End If

        'x = CInt((e.X - map_move_x) * 133.5)
        'y = CInt((e.Y - map_move_y) * 133.5)

        x = e.X
        y = e.Y

        For i = start_index To info.file_strings.GetUpperBound(0)

            If info.file_strings(i).string_type = l2_map_file_string.string_types.comment Or _
               info.file_strings(i).string_type = l2_map_file_string.string_types.collection_end Then
            Else

                If check_point_in(info.file_strings(i), x, y) = True Then
                    idx_to_select = i
                    Exit For
                End If

            End If

        Next

        If idx_to_select = 0 Then

            For i = 1 To start_index - 1

                If info.file_strings(i).string_type = l2_map_file_string.string_types.comment Or _
                   info.file_strings(i).string_type = l2_map_file_string.string_types.collection_end Then
                Else

                    If check_point_in(info.file_strings(i), x, y) = True Then
                        idx_to_select = i
                        Exit For
                    End If

                End If

            Next

        End If

        If idx_to_select > 0 Then

            For i = 0 To tree.Nodes.Count - 1

                If CInt(tree.Nodes(i).Tag) = idx_to_select Then
                    need_to_move = False
                    tree.SelectedNode = tree.Nodes(i)
                    tree.SelectedNode.Expand()
                    tree.Select()
                    need_to_move = True
                    Exit For
                End If

            Next

        End If

        'Me.Text = x.ToString & ", " & y.ToString

    End Sub


#End Region



End Class

Public Class l2_map_config

    Private name_local As String
    Private name_end_local As String

    Public ReadOnly Property name() As String
        Get
            name = name_local
        End Get
    End Property
    Public ReadOnly Property name_end() As String
        Get
            name_end = name_end_local
        End Get
    End Property

    Private config_parameters_local() As l2_map_config_parameter

    Public ReadOnly Property config_parameters_count() As Integer
        Get
            config_parameters_count = config_parameters_local.GetUpperBound(0)
        End Get
    End Property

    Public ReadOnly Property config_parameters() As l2_map_config_parameter()
        Get
            config_parameters = config_parameters_local
        End Get
    End Property

    Private name_to_display_local As String

    Public ReadOnly Property name_to_display() As String
        Get
            name_to_display = name_to_display_local
        End Get
    End Property

    Private drawing_parameters_local As l2_map_drawing_parameters
    Public ReadOnly Property drawing_parameters() As l2_map_drawing_parameters
        Get
            drawing_parameters = drawing_parameters_local
        End Get
    End Property

    Public Sub New(ByVal s() As String)

        Dim i As Integer
        Dim count_parameters As Integer

        name_local = s(0).Substring(s(0).LastIndexOf("=") + 1)

        If name_local.Contains(";") Then
            name_end_local = name_local.Substring(name_local.LastIndexOf(";") + 1)
            name_local = name_local.Substring(0, name_local.LastIndexOf(";"))
        End If

        For i = 1 To s.GetUpperBound(0)
            s(i) = s(i).Replace(Chr(9), "")
            If s(i).StartsWith("display=") Or s(i).StartsWith("draw=") Then
            Else
                count_parameters = count_parameters + 1
            End If
        Next

        ReDim config_parameters_local(count_parameters)

        count_parameters = 0
        For i = 1 To s.GetUpperBound(0)
            If s(i).StartsWith("display=") Then
                name_to_display_local = s(i).Substring(s(i).LastIndexOf("=") + 1)
            ElseIf s(i).StartsWith("draw=") Then
                drawing_parameters_local = New l2_map_drawing_parameters(s(i))
            Else
                count_parameters = count_parameters + 1
                config_parameters_local(count_parameters) = New l2_map_config_parameter(s(i))
            End If
        Next

    End Sub


End Class

Public Class l2_map_config_parameter

#Region "position"

    Private position_local As String

    Public ReadOnly Property position() As String
        Get
            position = position_local
        End Get
    End Property

    Private position_name_local As String

    Public ReadOnly Property position_name() As String
        Get
            position_name = position_name_local
        End Get
    End Property

#End Region

#Region "format"

    Public Enum config_formats
        empty = 10
        empty_clear = 11
        coordinates = 20
        coordinate_pos = 30
        obj_list = 40
        coordinate = 50
        list = 60
        list_table = 70
    End Enum

    Private format_local As config_formats

    Public ReadOnly Property format() As config_formats
        Get
            format = format_local
        End Get
    End Property

    Private Function format_from_string(ByVal f As String) As config_formats

        f = f.Replace("format=", "")

        If f.StartsWith("empty") Then
            If f.Length = 5 Then
                format_from_string = config_formats.empty
            Else
                format_from_string = config_formats.empty_clear
            End If
            Exit Function
        End If

        If f.StartsWith("list_table") Then
            format_from_string = config_formats.list_table
            Exit Function
        Else
            If f.StartsWith("list") Then
                format_from_string = config_formats.list
                Exit Function
            End If
        End If

        If f.StartsWith("obj_list") Then
            format_from_string = config_formats.obj_list
            Exit Function
        End If

        Select Case f
            Case "coordinates"
                format_from_string = config_formats.coordinates
            Case "coordinate_pos"
                format_from_string = config_formats.coordinate_pos
            Case "coordinate"
                format_from_string = config_formats.coordinate
        End Select

    End Function


#End Region

#Region "Empty"

    Private property_name_local As String

    Public ReadOnly Property property_name() As String
        Get
            property_name = property_name_local
        End Get
    End Property

#End Region

#Region "coordinates_names"

    Private coordinates_names_local(5) As String

    Public ReadOnly Property coordinates_names() As String()
        Get
            coordinates_names = coordinates_names_local
        End Get
    End Property

    Private Sub create_coordinates_names(ByVal s As String)

        Dim i As Integer
        Dim s2() As String

        s = s.Replace("names=", "")

        s2 = s.Split(CChar(","))

        For i = 0 To s2.GetUpperBound(0)
            coordinates_names_local(i + 1) = s2(i)
        Next

    End Sub

#End Region

#Region "list_table"

    Private list_names_local() As String

    Private separator_local As String

    Public ReadOnly Property separator() As String
        Get
            separator = separator_local
        End Get
    End Property

    Public ReadOnly Property list_names() As String()
        Get
            list_names = list_names_local
        End Get
    End Property

    Private Sub create_list_names(ByVal s As String)

        Dim i As Integer
        Dim s2() As String

        s = s.Replace("format=list_table", "")

        separator_local = CChar(s.Substring(0, 1))

        s = s.Substring(2, s.Length - 3)

        s2 = s.Split(CChar(","))

        ReDim list_names_local(s2.GetUpperBound(0) + 1)

        For i = 0 To s2.GetUpperBound(0)
            list_names_local(i + 1) = s2(i)
        Next

    End Sub

#End Region

#Region "obj_list"

    Private object_name_local As String
    Public ReadOnly Property object_name() As String
        Get
            object_name = object_name_local
        End Get
    End Property

    Private object_id_local As String

    Public ReadOnly Property object_id() As String
        Get
            object_id = object_id_local
        End Get
    End Property

    Private Sub create_object_parameters(ByVal s As String)

        Dim s2() As String

        s = s.Replace("format=obj_list(", "")
        s = s.Substring(0, s.Length - 1)

        s2 = s.Split(CChar(","))

        object_name_local = s2(0)
        object_id_local = s2(1)

    End Sub

#End Region

    Public Sub New(ByVal str As String)

        Dim s() As String

        Dim start As Integer

        str = str.Replace(Chr(9), "")

        s = str.Split(CChar(";"))

        position_local = s(0).Substring(s(0).LastIndexOf("=") + 1)

        If position_local = "any" Then
            start = 1
            position_name_local = s(1)
        Else
            start = 0
        End If

        property_name_local = s(start + 1)

        format_local = format_from_string(s(start + 2))

        Select Case format_local
            Case config_formats.empty Or config_formats.empty_clear

            Case config_formats.coordinates
                create_coordinates_names(s(start + 3))
            Case config_formats.coordinate
                create_coordinates_names(s(start + 3))
            Case config_formats.coordinate_pos
                create_coordinates_names(s(start + 3))
            Case config_formats.list_table
                create_list_names(s(start + 2))
            Case config_formats.obj_list
                create_object_parameters(s(start + 2))
        End Select

    End Sub

End Class

Public Class l2_map_drawing_object

    Private drawing_parameters_local As l2_map_drawing_parameters
    Public ReadOnly Property drawing_parameters() As l2_map_drawing_parameters
        Get
            drawing_parameters = drawing_parameters_local
        End Get
    End Property


    Private points_local(0) As System.Drawing.Point
    Public ReadOnly Property points() As System.Drawing.Point()
        Get
            points = points_local
        End Get
    End Property

    Public Sub add_point(ByVal x As Integer, ByVal y As Integer)

        ReDim Preserve points_local(points_local.GetUpperBound(0) + 1)
        points(points_local.GetUpperBound(0)) = New System.Drawing.Point(CInt(x / map_multiplier + map_move_x), CInt(y / map_multiplier + map_move_y))


    End Sub

    Public Sub New(ByVal new_drawing_parameters As l2_map_drawing_parameters)

        drawing_parameters_local = new_drawing_parameters

    End Sub


End Class

Public Class l2_map_drawing_parameters



    Public Enum drawing_types
        points = 10
        zone = 20
    End Enum

    Private color_local As System.Drawing.Color
    Public ReadOnly Property color() As System.Drawing.Color
        Get
            color = color_local
        End Get
    End Property

    Private drawing_type_local As drawing_types
    Public ReadOnly Property drawing_type() As drawing_types
        Get
            drawing_type = drawing_type_local
        End Get
    End Property

    Private draw_width_local As Integer

    Public ReadOnly Property draw_width() As Integer
        Get
            draw_width = draw_width_local
        End Get
    End Property

    Private Function color_by_string(ByVal str As String) As System.Drawing.Color

        Dim a As New System.Drawing.ColorConverter

        Try
            color_by_string = CType(a.ConvertFromString(str), Drawing.Color)
        Catch ex As Exception
            color_by_string = Drawing.Color.Black
        End Try

    End Function

    Public Sub New(ByVal str As String)

        Dim s() As String

        str = str.Replace("draw=", "")

        s = str.Split(CChar(";"))

        If s(0) = "zone" Then
            drawing_type_local = drawing_types.zone
        Else
            drawing_type_local = drawing_types.points
        End If

        color_local = color_by_string(s(1))

        draw_width_local = CInt(s(2))

    End Sub



End Class

Public Class l2_map_file_string

#Region "string type"

    Public Enum string_types
        obj = 10
        comment = 20
        collection_start = 30
        collection_end = 40
    End Enum

    Private string_type_local As string_types

    Public ReadOnly Property string_type() As string_types
        Get
            string_type = string_type_local
        End Get
    End Property

#End Region


    Private str_local As String
    Public ReadOnly Property str() As String
        Get
            str = str_local
        End Get
    End Property

#Region "object properties"

    Private properties_local() As l2_map_file_string_property
    Public ReadOnly Property properties() As l2_map_file_string_property()
        Get
            properties = properties_local
        End Get
    End Property

#End Region

    Private object_name_local As String

    Public ReadOnly Property object_name() As String
        Get
            object_name = object_name_local
        End Get
    End Property

    Private name_to_display_local As String

    Public ReadOnly Property name_to_display() As String
        Get
            name_to_display = name_to_display_local
        End Get
    End Property


    Private drawing_objects_local(0) As l2_map_drawing_object
    Public Property drawing_objects() As l2_map_drawing_object()
        Get
            drawing_objects = drawing_objects_local
        End Get
        Set(ByVal value As l2_map_drawing_object())
            drawing_objects_local = value
        End Set
    End Property

    Private config_used_local As l2_map_config
    Public ReadOnly Property config_used() As l2_map_config
        Get
            config_used = config_used_local
        End Get
    End Property

#Region "Ссылки на этот объект"

    Public obj_idx(50) As Integer
    Public obj_idx_count As Integer
    Public is_indexed As Boolean = False


#End Region


    Public Sub New(ByVal file_string As String, ByVal configs() As l2_map_config)

        Dim i As Integer
        Dim s() As String

        Dim config_num As Integer = 0

        Dim end_property_num As Integer

        str_local = file_string
        str_local = file_string.Replace("    ", Chr(9))

        s = str_local.Split(Chr(9))

        string_type_local = 0

        For i = 1 To configs.GetUpperBound(0)
            If configs(i).name = s(0) Then
                If configs(i).name_end <> "" Then
                    string_type_local = string_types.collection_start
                Else
                    string_type_local = string_types.obj
                End If
                config_num = i
                Exit For
            End If
            If configs(i).name_end <> "" Then
                If s(0).StartsWith(configs(i).name_end) Then
                    string_type_local = string_types.collection_end
                    config_num = i
                End If
            End If
        Next

        If string_type_local = 0 Then
            string_type_local = string_types.comment
        End If

        If string_type_local = string_types.collection_end Then
            object_name_local = configs(config_num).name_end
        ElseIf string_type_local = string_types.comment Then
            object_name_local = str_local
        Else

            With configs(config_num)

                config_used_local = configs(config_num)

                end_property_num = 0
                For i = 1 To s.GetUpperBound(0)
                    If s(i).Length > 0 Then
                        end_property_num = end_property_num + 1
                    End If
                Next

                If .name_end = "" Then
                    end_property_num = end_property_num - 1
                Else
                    end_property_num = end_property_num
                End If

                ReDim properties_local(end_property_num)

                For i = 1 To end_property_num

                    properties_local(i) = New l2_map_file_string_property(s(i), i + 1, configs(config_num))

                Next

                For i = 1 To properties_local.GetUpperBound(0)

                    If .name_to_display = properties_local(i).config_name Then
                        object_name_local = properties_local(i).simple_name
                        name_to_display_local = .name & " - " & properties_local(i).simple_name
                        Exit For
                    End If

                Next

            End With


        End If


    End Sub

End Class

Public Class l2_map_file_string_property

#Region "string type"

    Public Enum file_string_properties_types
        simple = 10
        simple_with_name = 20
        empty = 30
        empty_clear = 40
        obj_list = 50
        list = 60
        list_table = 70
        coordinate = 80
    End Enum

    Private property_type_local As file_string_properties_types

    Public ReadOnly Property property_type() As file_string_properties_types
        Get
            property_type = property_type_local
        End Get
    End Property

#End Region

#Region "simple"

    Private simple_name_local As String
    Private simple_value_local As String

    Public Property simple_name() As String
        Get
            simple_name = simple_name_local
        End Get
        Set(ByVal value As String)
            simple_name_local = value
        End Set
    End Property

    Public Property simple_value() As String
        Get
            simple_value = simple_value_local
        End Get
        Set(ByVal value As String)
            simple_value_local = value
        End Set
    End Property

#End Region

#Region "obj_list"

    Private obj_list_local() As String
    Public Property obj_list() As String()
        Get
            obj_list = obj_list_local
        End Get
        Set(ByVal value As String())
            obj_list_local = value
        End Set
    End Property

    Private Sub create_obj_list(ByVal str As String)

        Dim s() As String
        s = str.Split(CChar(";"))
        ReDim obj_list_local(s.GetUpperBound(0) + 1)
        ReDim obj_list_indexes(s.GetUpperBound(0) + 1)
        For i = 0 To s.GetUpperBound(0)
            obj_list_local(i + 1) = s(i).Substring(1, s(i).Length - 2)
        Next

    End Sub

    Public obj_list_indexes() As Integer

    Private obj_list_str_type_local As String
    Public ReadOnly Property obj_list_str_type() As String
        Get
            obj_list_str_type = obj_list_str_type_local
        End Get
    End Property

#End Region

#Region "List"

    Private list_local() As String
    Public Property list() As String()
        Get
            list = list_local
        End Get
        Set(ByVal value As String())
            list_local = value
        End Set
    End Property

    Private Sub create_list(ByVal str As String)

        Dim i As Integer
        Dim s() As String

        str = str.Substring(str.IndexOf("=") + 2)
        str = str.Substring(0, str.Length - 1)

        s = str.Split(CChar(";"))
        ReDim list_local(s.GetUpperBound(0) + 1)
        For i = 0 To s.GetUpperBound(0)
            list_local(i + 1) = s(i)
        Next

    End Sub

#End Region

#Region "list_table"

    Private list_table_names_local() As String
    Private table_local(,) As String

    Public ReadOnly Property list_table_names() As String()
        Get
            list_table_names = list_table_names_local
        End Get
    End Property

    Public Property table() As String(,)
        Get
            table = table_local
        End Get
        Set(ByVal value As String(,))
            table_local = value
        End Set
    End Property

    Public Sub create_table(ByVal str As String, ByVal config As l2_map_config_parameter)

        Dim s() As String, s2() As String
        Dim i As Integer, j As Integer

        list_table_names_local = config.list_names

        str = str.Substring(str.IndexOf("=") + 1)
        str = str.Substring(1, str.Length - 2)

        s = str.Split(CChar(";"))

        ReDim table_local(list_table_names_local.GetUpperBound(0), s.GetUpperBound(0) + 1)
        For i = 0 To s.GetUpperBound(0)
            s2 = s(i).Split(CChar(config.separator))
            For j = 0 To s2.GetUpperBound(0)
                table_local(j + 1, i + 1) = s2(j)
            Next
        Next

    End Sub

#End Region

#Region "property_name"

    Private config_name_local As String

    Public ReadOnly Property config_name() As String
        Get
            config_name = config_name_local
        End Get
    End Property

#End Region

#Region "coordinate"

    Private pos_local As String
    Private points_count_local As Integer

    Private points_local() As point

    Public Structure point
        Friend x As Integer
        Friend y As Integer
        Friend z As Integer
        Friend z2 As Integer
        Friend percent As String
    End Structure

    Private anywhere_local As Boolean

    Public ReadOnly Property anywhere() As Boolean
        Get
            anywhere = anywhere_local
        End Get
    End Property


    Private Sub create_coordinate(ByVal str As String)

        Dim s1() As String, s2() As String
        Dim i As Integer, j As Integer

        If str.StartsWith("pos=") Then
            pos_local = "pos="
            str = str.Substring(4)
        Else
            pos_local = ""
        End If

        If str.StartsWith("{{") Then
            str = str.Substring(1, str.Length - 2)
            If str.Substring(str.Length - 2) = "}}" Then
                str = str.Substring(0, str.Length - 1)
            End If
            s2 = str.Split(CChar("};"))
            ReDim s1(s2.GetUpperBound(0) - 1)
            For i = 0 To s2.GetUpperBound(0) - 1
                s1(i) = s2(i)
                If s1(i).StartsWith(";") Then
                    s1(i) = s1(i).Substring(1)
                End If
            Next
        Else
            ReDim s1(0)
            s1(0) = str.Replace("}", "")
        End If

        points_count_local = s1.GetUpperBound(0) + 1

        ReDim points_local(points_count_local)

        For i = 0 To points_count_local - 1
            s2 = s1(i).Replace("{", "").Split(CChar(";"))

            If s2(0) = "anywhere" Then
                anywhere_local = True
            Else
                anywhere_local = False
                points_local(i + 1).x = CInt(s2(0))
                points_local(i + 1).y = CInt(s2(1))
                points_local(i + 1).z = CInt(s2(2))
                points_local(i + 1).z2 = CInt(s2(3))
                If s2.GetUpperBound(0) > 3 Then
                    points_local(i).percent = s2(4)
                End If
            End If
        Next

    End Sub

    Public ReadOnly Property points_count() As Integer
        Get
            points_count = points_count_local
        End Get
    End Property

    Public Property points() As point()
        Get
            points = points_local
        End Get
        Set(ByVal value As point())
            points_local = value
        End Set
    End Property

    Public ReadOnly Property point_string(ByVal index As Integer) As String
        Get
            point_string = points_local(index).x & ", " & points_local(index).y & ", " & points_local(index).z & ", " & points(index).z2
            If points_local(index).percent <> "" Then
                point_string = point_string & points_local(index).percent
            End If
        End Get
    End Property

#End Region

#Region "used_config"

    Private config_parameter_local As l2_map_config_parameter

    Public ReadOnly Property config_parameter() As l2_map_config_parameter
        Get
            config_parameter = config_parameter_local
        End Get
    End Property

#End Region

    Public Sub New(ByVal str As String, ByVal property_num As Integer, ByVal config As l2_map_config)

        Dim rule_num As Integer
        Dim i As Integer

        rule_num = 0
        With config
            For i = 1 To .config_parameters_count
                If .config_parameters(i).position = "any" Then
                    If str.Contains("=") Then
                        If str.Substring(0, str.LastIndexOf("=")) = .config_parameters(i).position_name Then
                            rule_num = i
                            Exit For
                        End If
                    End If
                Else
                    If CInt(.config_parameters(i).position) = property_num Then
                        rule_num = i
                        Exit For
                    End If
                End If
            Next

        End With

        If rule_num > 0 Then

            config_parameter_local = config.config_parameters(rule_num)

            With config.config_parameters(rule_num)

                config_name_local = .property_name

                Select Case .format
                    Case l2_map_config_parameter.config_formats.empty
                        property_type_local = file_string_properties_types.empty
                        simple_name_local = str
                    Case l2_map_config_parameter.config_formats.empty_clear
                        property_type_local = file_string_properties_types.empty_clear
                        simple_name_local = str.Substring(1, str.Length - 2)
                    Case l2_map_config_parameter.config_formats.obj_list
                        property_type_local = file_string_properties_types.obj_list
                        obj_list_str_type_local = .object_name
                        create_obj_list(str)
                        For i = 1 To obj_list_local.GetUpperBound(0)
                            simple_name_local = simple_name_local & obj_list_local(i)
                            If i < obj_list_local.GetUpperBound(0) Then
                                simple_name_local = simple_name_local & ";"
                            End If
                        Next
                        simple_name_local = simple_name_local
                    Case l2_map_config_parameter.config_formats.list
                        property_type_local = file_string_properties_types.list
                        simple_name_local = str.Substring(0, str.LastIndexOf("="))
                        create_list(str)
                    Case l2_map_config_parameter.config_formats.list_table
                        property_type_local = file_string_properties_types.list_table
                        create_table(str, config.config_parameters(rule_num))
                        simple_name_local = str.Substring(0, str.IndexOf("="))
                    Case l2_map_config_parameter.config_formats.coordinate
                        property_type_local = file_string_properties_types.coordinate
                        create_coordinate(str)
                        If anywhere_local = True Then
                            simple_name_local = "coordinates = anywhere"
                        Else
                            simple_name_local = "coordinates (" & points_count_local & ")"
                        End If

                End Select

            End With

        End If

        If rule_num = 0 Then

            'If str.Contains("=") Then
            '    property_type_local = file_string_properties_types.simple_with_name
            '    simple_value_local = str.Substring(str.LastIndexOf("=") + 1)
            '    simple_name_local = str.Substring(0, str.LastIndexOf("="))
            'Else
            property_type_local = file_string_properties_types.simple
            simple_name_local = str
            'End If

        End If

    End Sub

End Class

Public Class l2_map_info

#Region "Конфигурация"

    Private config_path_local As String

    Private config_local() As String

    Public Property config_path() As String
        Get
            config_path = config_path_local
        End Get
        Set(ByVal value As String)
            config_path_local = value
            load_config(value)
        End Set
    End Property

    Private configs() As l2_map_config

    Private Sub load_config(ByVal path As String)

        Dim F As System.IO.StreamReader
        Dim Str As String

        Dim str_count As Integer = 0
        Dim config_start As Integer = 0

        Dim config() As String

        Dim i As Integer

        ReDim config_local(0)

        ReDim configs(0)

        F = System.IO.File.OpenText(path)
        Do While Not F.EndOfStream
            Str = F.ReadLine
            str_count = str_count + 1
            ReDim Preserve config_local(str_count)
            config_local(str_count) = Str

            If Str.StartsWith("type") Then
                config_start = str_count
            End If

            If Str.StartsWith("end_type") Then
                If config_start > 0 Then
                    ReDim config(0)
                    For i = config_start To str_count - 1
                        config(config.GetUpperBound(0)) = config_local(i)
                        If i < str_count - 1 Then
                            ReDim Preserve config(config.GetUpperBound(0) + 1)
                        End If
                    Next

                    ReDim Preserve configs(configs.GetUpperBound(0) + 1)
                    configs(configs.GetUpperBound(0)) = New l2_map_config(config)

                    config_start = 0
                End If
            End If

        Loop

    End Sub

#End Region

#Region "Загрузка файла"

    Private file_path_local As String

    Private file_strings_local() As l2_map_file_string

    Public Property file_path() As String
        Get
            file_path = file_path_local
        End Get
        Set(ByVal value As String)

            load_file(value)

            file_path_local = value

        End Set
    End Property

    Private Sub add_drawing_parameters(ByVal str_num As Integer, Optional ByVal obj As l2_map_file_string = Nothing)

        Dim k As Integer

        If obj Is Nothing Then
            obj = file_strings_local(str_num)
        End If

        For k = 1 To obj.properties.GetUpperBound(0)
            If obj.properties(k).property_type = l2_map_file_string_property.file_string_properties_types.coordinate Then
                If obj.properties(k).anywhere = True Then
                Else
                    With obj.properties(k)
                        ReDim Preserve file_strings_local(str_num).drawing_objects(file_strings_local(str_num).drawing_objects.GetUpperBound(0) + 1)
                        file_strings_local(str_num).drawing_objects(file_strings_local(str_num).drawing_objects.GetUpperBound(0)) = New l2_map_drawing_object(obj.config_used.drawing_parameters)
                        For m = 1 To .points.GetUpperBound(0)
                            file_strings_local(str_num).drawing_objects(file_strings_local(str_num).drawing_objects.GetUpperBound(0)).add_point(.points(m).x, .points(m).y)
                        Next
                    End With
                End If
            End If
        Next

    End Sub

    Private Sub load_file(ByVal path As String)

        Dim F As System.IO.StreamReader
        Dim Str As String
        Dim file_str_count As Integer
        Dim founded As Boolean
        Dim flag_space As Integer

        Dim i As Integer, j As Integer, k As Integer, m As Integer

        'Падщот строк файла
        F = System.IO.File.OpenText(path)
        Do While Not F.EndOfStream
            Str = F.ReadLine
            file_str_count = file_str_count + 1
        Loop
        F.Close()

        ReDim file_strings_local(file_str_count)
        file_str_count = 0

        'Загрузка файла
        F = System.IO.File.OpenText(path)
        Do While Not F.EndOfStream
            Str = F.ReadLine

            'Убираем пробелы, идущие подряд по несколько штук
            flag_space = Str.Length
            'Str = Str.Replace(Chr(9), " ")
            Do While 1 = 1
                Str = Str.Replace("  ", " ")
                If Str.Length = flag_space Then
                    Exit Do
                Else
                    flag_space = Str.Length
                End If
            Loop
            Str = Str.Replace(" ", Chr(9))

            file_str_count = file_str_count + 1
            file_strings_local(file_str_count) = New l2_map_file_string(Str, configs)

        Loop
        F.Close()

        'Индексация ссылок на другие объекты (obj_list)
        For i = 1 To file_str_count

            If file_strings_local(i).string_type = l2_map_file_string.string_types.obj Or file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Then
                For j = 1 To file_strings_local(i).properties.GetUpperBound(0)
                    If file_strings_local(i).properties(j).property_type = l2_map_file_string_property.file_string_properties_types.obj_list Then
                        For m = 1 To file_strings_local(i).properties(j).obj_list_indexes.GetUpperBound(0)
                            founded = False
                            For k = i - 1 To 1 Step -1
                                Dim obj1 As l2_map_file_string = file_strings_local(i)
                                Dim obj2 As l2_map_file_string = file_strings_local(k)
                                If obj2.string_type = l2_map_file_string.string_types.obj Then
                                    If obj1.properties(j).obj_list_str_type = obj2.config_used.name Then
                                        If file_strings_local(k).object_name = file_strings_local(i).properties(j).obj_list(m) Then
                                            file_strings_local(i).properties(j).obj_list_indexes(m) = k
                                            founded = True
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next
                            If founded = False Then
                                For k = i To file_str_count
                                    Dim obj1 As l2_map_file_string = file_strings_local(i)
                                    Dim obj2 As l2_map_file_string = file_strings_local(k)
                                    If obj2.string_type = l2_map_file_string.string_types.obj Then
                                        If obj1.properties(j).obj_list_str_type = obj2.config_used.name Then
                                            If file_strings_local(k).object_name = file_strings_local(i).properties(j).obj_list(m) Then
                                                file_strings_local(i).properties(j).obj_list_indexes(m) = k
                                                founded = True
                                                Exit For
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                            founded = True
                        Next
                    End If
                Next
            End If

        Next

        'Создание объектов прорисовки
        For i = 1 To file_str_count

            'индексировано => нахуй
            'If file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Or file_strings_local(i).string_type = l2_map_file_string.string_types.obj Then
            '    For j = 1 To file_strings_local(i).properties.GetUpperBound(0)
            '        If file_strings_local(i).properties(j).property_type = l2_map_file_string_property.file_string_properties_types.obj_list Then
            '            For k = 1 To file_strings_local(i).properties(j).obj_list_indexes.GetUpperBound(0)
            '                add_drawing_parameters(i, file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(k)))
            '            Next
            '        End If
            '    Next
            'End If

            If file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Then

                add_drawing_parameters(i)

                For j = i + 1 To file_str_count

                    If file_strings_local(j).string_type = l2_map_file_string.string_types.collection_end Then
                        Exit For
                    End If

                    On Error Resume Next

                    add_drawing_parameters(i, file_strings_local(j))

                    'If Err.Number > 0 Then
                    '    MsgBox(j)
                    '    Err.Clear()
                    'End If

                Next

            End If

            If file_strings_local(i).string_type = l2_map_file_string.string_types.obj Then
                add_drawing_parameters(i)
            End If

        Next

        Dim u_bound As Integer, u_bound_2 As Integer

        'Индексация ссылок на объект
        'For i = 1 To file_strings_local.GetUpperBound(0)
        '    If file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Or file_strings_local(i).string_type = l2_map_file_string.string_types.obj Then

        '        For j = 1 To file_strings_local(i).properties.GetUpperBound(0)

        '            If file_strings_local(i).properties(j).property_type = l2_map_file_string_property.file_string_properties_types.obj_list Then

        '                u_bound = file_strings_local(i).properties(j).obj_list_indexes.GetUpperBound(0)

        '                If u_bound = 1 Then
        '                    u_bound_2 = file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx.GetUpperBound(0)
        '                    ReDim Preserve file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx(u_bound_2 + 1)
        '                    file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx(u_bound_2) = i
        '                End If

        '            End If

        '        Next

        '    End If
        'Next

        'Dim num_idx(file_strings_local.GetUpperBound(0)) As Integer


        'For i = 1 To file_strings_local.GetUpperBound(0)
        '    If file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Or file_strings_local(i).string_type = l2_map_file_string.string_types.obj Then

        '        For j = 1 To file_strings_local(i).properties.GetUpperBound(0)

        '            If file_strings_local(i).properties(j).property_type = l2_map_file_string_property.file_string_properties_types.obj_list Then

        '                u_bound = file_strings_local(i).properties(j).obj_list_indexes.GetUpperBound(0)

        '                If u_bound = 1 Then
        '                    num_idx(file_strings_local(i).properties(j).obj_list_indexes(1)) = num_idx(file_strings_local(i).properties(j).obj_list_indexes(1)) + 1
        '                End If

        '            End If

        '        Next

        '    End If
        'Next

        'For i = 1 To file_strings_local.GetUpperBound(0)
        '    If num_idx(i) > 0 Then
        '        ReDim file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx(num_idx(i))
        '    End If
        '    num_idx(i) = 0
        'Next

        For i = 1 To file_strings_local.GetUpperBound(0)
            If file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Or file_strings_local(i).string_type = l2_map_file_string.string_types.obj Then

                For j = 1 To file_strings_local(i).properties.GetUpperBound(0)

                    If file_strings_local(i).properties(j).property_type = l2_map_file_string_property.file_string_properties_types.obj_list Then

                        u_bound = file_strings_local(i).properties(j).obj_list_indexes.GetUpperBound(0)

                        If u_bound = 1 Then
                            file_strings_local(i).is_indexed = True
                            file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx_count = file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx_count + 1
                            file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx(file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx_count) = i
                        End If

                    End If

                Next

            End If
        Next

    End Sub


#End Region

#Region "file_strings"

    Public ReadOnly Property file_strings() As l2_map_file_string()
        Get
            file_strings = file_strings_local
        End Get
    End Property

#End Region

End Class
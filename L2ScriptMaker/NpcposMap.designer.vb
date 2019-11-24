<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcposMap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.picMap = New System.Windows.Forms.PictureBox
        Me.Open = New System.Windows.Forms.OpenFileDialog
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.text_log = New System.Windows.Forms.RichTextBox
        Me.button_deselect_all = New System.Windows.Forms.Button
        Me.button_select_all = New System.Windows.Forms.Button
        Me.group_obj_list = New System.Windows.Forms.GroupBox
        Me.list_obj = New System.Windows.Forms.ListBox
        Me.label_obj_name = New System.Windows.Forms.Label
        Me.group_list_table = New System.Windows.Forms.GroupBox
        Me.grid = New System.Windows.Forms.DataGridView
        Me.group_list = New System.Windows.Forms.GroupBox
        Me.text_list = New System.Windows.Forms.RichTextBox
        Me.list_list = New System.Windows.Forms.ListBox
        Me.group_coordinates = New System.Windows.Forms.GroupBox
        Me.text_coordinate_5 = New System.Windows.Forms.TextBox
        Me.text_coordinate_4 = New System.Windows.Forms.TextBox
        Me.text_coordinate_3 = New System.Windows.Forms.TextBox
        Me.text_coordinate_2 = New System.Windows.Forms.TextBox
        Me.text_coordinate_1 = New System.Windows.Forms.TextBox
        Me.label_coordinate_5 = New System.Windows.Forms.Label
        Me.label_coordinate_4 = New System.Windows.Forms.Label
        Me.label_coordinate_3 = New System.Windows.Forms.Label
        Me.label_coordinate_2 = New System.Windows.Forms.Label
        Me.label_coordinate_1 = New System.Windows.Forms.Label
        Me.list_coordinates = New System.Windows.Forms.ListBox
        Me.button_search = New System.Windows.Forms.Button
        Me.group_simple = New System.Windows.Forms.GroupBox
        Me.text_simple_value = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.text_search = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tree = New System.Windows.Forms.TreeView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bSave = New System.Windows.Forms.Button
        Me.bOpenFile = New System.Windows.Forms.Button
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.group_obj_list.SuspendLayout()
        Me.group_list_table.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_list.SuspendLayout()
        Me.group_coordinates.SuspendLayout()
        Me.group_simple.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'picMap
        '
        Me.picMap.Location = New System.Drawing.Point(0, 0)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(3072, 4096)
        Me.picMap.TabIndex = 6
        Me.picMap.TabStop = False
        '
        'Timer
        '
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.text_log)
        Me.Panel1.Controls.Add(Me.button_deselect_all)
        Me.Panel1.Controls.Add(Me.button_select_all)
        Me.Panel1.Controls.Add(Me.group_obj_list)
        Me.Panel1.Controls.Add(Me.group_list_table)
        Me.Panel1.Controls.Add(Me.group_list)
        Me.Panel1.Controls.Add(Me.group_coordinates)
        Me.Panel1.Controls.Add(Me.button_search)
        Me.Panel1.Controls.Add(Me.group_simple)
        Me.Panel1.Controls.Add(Me.text_search)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.tree)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(377, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 587)
        Me.Panel1.TabIndex = 8
        '
        'text_log
        '
        Me.text_log.Location = New System.Drawing.Point(3, 588)
        Me.text_log.Name = "text_log"
        Me.text_log.Size = New System.Drawing.Size(332, 218)
        Me.text_log.TabIndex = 41
        Me.text_log.Text = ""
        '
        'button_deselect_all
        '
        Me.button_deselect_all.Location = New System.Drawing.Point(100, 334)
        Me.button_deselect_all.Name = "button_deselect_all"
        Me.button_deselect_all.Size = New System.Drawing.Size(88, 22)
        Me.button_deselect_all.TabIndex = 40
        Me.button_deselect_all.Text = "убрать все"
        Me.button_deselect_all.UseVisualStyleBackColor = True
        '
        'button_select_all
        '
        Me.button_select_all.Location = New System.Drawing.Point(6, 334)
        Me.button_select_all.Name = "button_select_all"
        Me.button_select_all.Size = New System.Drawing.Size(88, 22)
        Me.button_select_all.TabIndex = 39
        Me.button_select_all.Text = "выбрать все"
        Me.button_select_all.UseVisualStyleBackColor = True
        '
        'group_obj_list
        '
        Me.group_obj_list.Controls.Add(Me.list_obj)
        Me.group_obj_list.Controls.Add(Me.label_obj_name)
        Me.group_obj_list.Location = New System.Drawing.Point(3, 366)
        Me.group_obj_list.Name = "group_obj_list"
        Me.group_obj_list.Size = New System.Drawing.Size(332, 216)
        Me.group_obj_list.TabIndex = 10
        Me.group_obj_list.TabStop = False
        Me.group_obj_list.Text = "properties"
        '
        'list_obj
        '
        Me.list_obj.FormattingEnabled = True
        Me.list_obj.Location = New System.Drawing.Point(8, 41)
        Me.list_obj.Name = "list_obj"
        Me.list_obj.Size = New System.Drawing.Size(317, 160)
        Me.list_obj.TabIndex = 1
        '
        'label_obj_name
        '
        Me.label_obj_name.AutoSize = True
        Me.label_obj_name.Location = New System.Drawing.Point(10, 19)
        Me.label_obj_name.Name = "label_obj_name"
        Me.label_obj_name.Size = New System.Drawing.Size(53, 13)
        Me.label_obj_name.TabIndex = 0
        Me.label_obj_name.Text = "obj_name"
        '
        'group_list_table
        '
        Me.group_list_table.Controls.Add(Me.grid)
        Me.group_list_table.Location = New System.Drawing.Point(5, 366)
        Me.group_list_table.Name = "group_list_table"
        Me.group_list_table.Size = New System.Drawing.Size(330, 216)
        Me.group_list_table.TabIndex = 10
        Me.group_list_table.TabStop = False
        Me.group_list_table.Text = "properties"
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Location = New System.Drawing.Point(7, 21)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(314, 187)
        Me.grid.TabIndex = 0
        '
        'group_list
        '
        Me.group_list.Controls.Add(Me.text_list)
        Me.group_list.Controls.Add(Me.list_list)
        Me.group_list.Location = New System.Drawing.Point(5, 366)
        Me.group_list.Name = "group_list"
        Me.group_list.Size = New System.Drawing.Size(330, 216)
        Me.group_list.TabIndex = 10
        Me.group_list.TabStop = False
        Me.group_list.Text = "properties"
        '
        'text_list
        '
        Me.text_list.Location = New System.Drawing.Point(9, 133)
        Me.text_list.Name = "text_list"
        Me.text_list.Size = New System.Drawing.Size(314, 76)
        Me.text_list.TabIndex = 1
        Me.text_list.Text = ""
        '
        'list_list
        '
        Me.list_list.FormattingEnabled = True
        Me.list_list.Location = New System.Drawing.Point(9, 19)
        Me.list_list.Name = "list_list"
        Me.list_list.Size = New System.Drawing.Size(314, 108)
        Me.list_list.TabIndex = 0
        '
        'group_coordinates
        '
        Me.group_coordinates.Controls.Add(Me.text_coordinate_5)
        Me.group_coordinates.Controls.Add(Me.text_coordinate_4)
        Me.group_coordinates.Controls.Add(Me.text_coordinate_3)
        Me.group_coordinates.Controls.Add(Me.text_coordinate_2)
        Me.group_coordinates.Controls.Add(Me.text_coordinate_1)
        Me.group_coordinates.Controls.Add(Me.label_coordinate_5)
        Me.group_coordinates.Controls.Add(Me.label_coordinate_4)
        Me.group_coordinates.Controls.Add(Me.label_coordinate_3)
        Me.group_coordinates.Controls.Add(Me.label_coordinate_2)
        Me.group_coordinates.Controls.Add(Me.label_coordinate_1)
        Me.group_coordinates.Controls.Add(Me.list_coordinates)
        Me.group_coordinates.Location = New System.Drawing.Point(5, 366)
        Me.group_coordinates.Name = "group_coordinates"
        Me.group_coordinates.Size = New System.Drawing.Size(330, 216)
        Me.group_coordinates.TabIndex = 2
        Me.group_coordinates.TabStop = False
        Me.group_coordinates.Text = "properties"
        '
        'text_coordinate_5
        '
        Me.text_coordinate_5.Location = New System.Drawing.Point(162, 135)
        Me.text_coordinate_5.Name = "text_coordinate_5"
        Me.text_coordinate_5.Size = New System.Drawing.Size(82, 20)
        Me.text_coordinate_5.TabIndex = 10
        '
        'text_coordinate_4
        '
        Me.text_coordinate_4.Location = New System.Drawing.Point(162, 109)
        Me.text_coordinate_4.Name = "text_coordinate_4"
        Me.text_coordinate_4.Size = New System.Drawing.Size(82, 20)
        Me.text_coordinate_4.TabIndex = 9
        '
        'text_coordinate_3
        '
        Me.text_coordinate_3.Location = New System.Drawing.Point(30, 161)
        Me.text_coordinate_3.Name = "text_coordinate_3"
        Me.text_coordinate_3.Size = New System.Drawing.Size(82, 20)
        Me.text_coordinate_3.TabIndex = 8
        '
        'text_coordinate_2
        '
        Me.text_coordinate_2.Location = New System.Drawing.Point(30, 135)
        Me.text_coordinate_2.Name = "text_coordinate_2"
        Me.text_coordinate_2.Size = New System.Drawing.Size(82, 20)
        Me.text_coordinate_2.TabIndex = 7
        '
        'text_coordinate_1
        '
        Me.text_coordinate_1.Location = New System.Drawing.Point(30, 109)
        Me.text_coordinate_1.Name = "text_coordinate_1"
        Me.text_coordinate_1.Size = New System.Drawing.Size(82, 20)
        Me.text_coordinate_1.TabIndex = 6
        '
        'label_coordinate_5
        '
        Me.label_coordinate_5.AutoSize = True
        Me.label_coordinate_5.Location = New System.Drawing.Point(138, 138)
        Me.label_coordinate_5.Name = "label_coordinate_5"
        Me.label_coordinate_5.Size = New System.Drawing.Size(15, 13)
        Me.label_coordinate_5.TabIndex = 5
        Me.label_coordinate_5.Text = "%"
        '
        'label_coordinate_4
        '
        Me.label_coordinate_4.AutoSize = True
        Me.label_coordinate_4.Location = New System.Drawing.Point(138, 112)
        Me.label_coordinate_4.Name = "label_coordinate_4"
        Me.label_coordinate_4.Size = New System.Drawing.Size(18, 13)
        Me.label_coordinate_4.TabIndex = 4
        Me.label_coordinate_4.Text = "z2"
        '
        'label_coordinate_3
        '
        Me.label_coordinate_3.AutoSize = True
        Me.label_coordinate_3.Location = New System.Drawing.Point(8, 164)
        Me.label_coordinate_3.Name = "label_coordinate_3"
        Me.label_coordinate_3.Size = New System.Drawing.Size(12, 13)
        Me.label_coordinate_3.TabIndex = 3
        Me.label_coordinate_3.Text = "z"
        '
        'label_coordinate_2
        '
        Me.label_coordinate_2.AutoSize = True
        Me.label_coordinate_2.Location = New System.Drawing.Point(8, 138)
        Me.label_coordinate_2.Name = "label_coordinate_2"
        Me.label_coordinate_2.Size = New System.Drawing.Size(12, 13)
        Me.label_coordinate_2.TabIndex = 2
        Me.label_coordinate_2.Text = "y"
        '
        'label_coordinate_1
        '
        Me.label_coordinate_1.AutoSize = True
        Me.label_coordinate_1.Location = New System.Drawing.Point(8, 112)
        Me.label_coordinate_1.Name = "label_coordinate_1"
        Me.label_coordinate_1.Size = New System.Drawing.Size(12, 13)
        Me.label_coordinate_1.TabIndex = 1
        Me.label_coordinate_1.Text = "x"
        '
        'list_coordinates
        '
        Me.list_coordinates.FormattingEnabled = True
        Me.list_coordinates.Location = New System.Drawing.Point(6, 21)
        Me.list_coordinates.Name = "list_coordinates"
        Me.list_coordinates.Size = New System.Drawing.Size(238, 82)
        Me.list_coordinates.TabIndex = 0
        '
        'button_search
        '
        Me.button_search.Location = New System.Drawing.Point(300, 71)
        Me.button_search.Name = "button_search"
        Me.button_search.Size = New System.Drawing.Size(37, 20)
        Me.button_search.TabIndex = 37
        Me.button_search.Text = "go"
        Me.button_search.UseVisualStyleBackColor = True
        '
        'group_simple
        '
        Me.group_simple.Controls.Add(Me.text_simple_value)
        Me.group_simple.Controls.Add(Me.Label2)
        Me.group_simple.Location = New System.Drawing.Point(7, 366)
        Me.group_simple.Name = "group_simple"
        Me.group_simple.Size = New System.Drawing.Size(328, 216)
        Me.group_simple.TabIndex = 38
        Me.group_simple.TabStop = False
        Me.group_simple.Text = "property"
        '
        'text_simple_value
        '
        Me.text_simple_value.Location = New System.Drawing.Point(75, 13)
        Me.text_simple_value.Name = "text_simple_value"
        Me.text_simple_value.Size = New System.Drawing.Size(245, 20)
        Me.text_simple_value.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Значение:"
        '
        'text_search
        '
        Me.text_search.Location = New System.Drawing.Point(49, 71)
        Me.text_search.Name = "text_search"
        Me.text_search.Size = New System.Drawing.Size(245, 20)
        Me.text_search.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Поиск"
        '
        'tree
        '
        Me.tree.CheckBoxes = True
        Me.tree.Location = New System.Drawing.Point(3, 97)
        Me.tree.Name = "tree"
        Me.tree.Size = New System.Drawing.Size(333, 231)
        Me.tree.TabIndex = 34
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bSave)
        Me.GroupBox2.Controls.Add(Me.bOpenFile)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(334, 62)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ncppos_c4_retail.txt"
        '
        'bSave
        '
        Me.bSave.Location = New System.Drawing.Point(225, 21)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(101, 27)
        Me.bSave.TabIndex = 28
        Me.bSave.Text = "Сохранить"
        Me.bSave.UseVisualStyleBackColor = True
        Me.bSave.Visible = False
        '
        'bOpenFile
        '
        Me.bOpenFile.Location = New System.Drawing.Point(13, 21)
        Me.bOpenFile.Name = "bOpenFile"
        Me.bOpenFile.Size = New System.Drawing.Size(101, 27)
        Me.bOpenFile.TabIndex = 0
        Me.bOpenFile.Text = "Открыть"
        Me.bOpenFile.UseVisualStyleBackColor = True
        '
        'l2_map_container
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 854)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picMap)
        Me.IsMdiContainer = True
        Me.Name = "l2_map_container"
        Me.Text = "npc_pos_viewer made by E.Koksharov"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.group_obj_list.ResumeLayout(False)
        Me.group_obj_list.PerformLayout()
        Me.group_list_table.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_list.ResumeLayout(False)
        Me.group_coordinates.ResumeLayout(False)
        Me.group_coordinates.PerformLayout()
        Me.group_simple.ResumeLayout(False)
        Me.group_simple.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents Open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bSave As System.Windows.Forms.Button
    Friend WithEvents bOpenFile As System.Windows.Forms.Button
    Friend WithEvents tree As System.Windows.Forms.TreeView
    Friend WithEvents button_search As System.Windows.Forms.Button
    Friend WithEvents text_search As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents group_simple As System.Windows.Forms.GroupBox
    Friend WithEvents text_simple_value As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents group_coordinates As System.Windows.Forms.GroupBox
    Friend WithEvents list_coordinates As System.Windows.Forms.ListBox
    Friend WithEvents label_coordinate_5 As System.Windows.Forms.Label
    Friend WithEvents label_coordinate_4 As System.Windows.Forms.Label
    Friend WithEvents label_coordinate_3 As System.Windows.Forms.Label
    Friend WithEvents label_coordinate_2 As System.Windows.Forms.Label
    Friend WithEvents label_coordinate_1 As System.Windows.Forms.Label
    Friend WithEvents text_coordinate_5 As System.Windows.Forms.TextBox
    Friend WithEvents text_coordinate_4 As System.Windows.Forms.TextBox
    Friend WithEvents text_coordinate_3 As System.Windows.Forms.TextBox
    Friend WithEvents text_coordinate_2 As System.Windows.Forms.TextBox
    Friend WithEvents text_coordinate_1 As System.Windows.Forms.TextBox
    Friend WithEvents group_list As System.Windows.Forms.GroupBox
    Friend WithEvents text_list As System.Windows.Forms.RichTextBox
    Friend WithEvents list_list As System.Windows.Forms.ListBox
    Friend WithEvents group_list_table As System.Windows.Forms.GroupBox
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents group_obj_list As System.Windows.Forms.GroupBox
    Friend WithEvents label_obj_name As System.Windows.Forms.Label
    Friend WithEvents list_obj As System.Windows.Forms.ListBox
    Friend WithEvents button_deselect_all As System.Windows.Forms.Button
    Friend WithEvents button_select_all As System.Windows.Forms.Button
    Friend WithEvents text_log As System.Windows.Forms.RichTextBox
End Class

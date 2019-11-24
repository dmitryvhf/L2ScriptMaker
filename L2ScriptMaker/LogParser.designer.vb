<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogParser
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogParser))
        Me.tab1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.checkEnableExtraFilter = New System.Windows.Forms.CheckBox
        Me.cTarget = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cDBitem = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.bFillGrid = New System.Windows.Forms.Button
        Me.cActors = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cActions = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Grid = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.str5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.textMaxRows = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.textLogToSave = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.bSaveToFile = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.textLogs = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.InMemory = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.textNPC = New System.Windows.Forms.TextBox
        Me.checkLoadOnLaunch = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.bSave = New System.Windows.Forms.Button
        Me.textQuestName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.textSkillName = New System.Windows.Forms.TextBox
        Me.textLogIDs = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.textItemName = New System.Windows.Forms.TextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.gridFilter = New System.Windows.Forms.DataGridView
        Me.colParam = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colOperation = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.kolValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Save = New System.Windows.Forms.SaveFileDialog
        Me.Folder = New System.Windows.Forms.FolderBrowserDialog
        Me.Open = New System.Windows.Forms.OpenFileDialog
        Me.tab1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.gridFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tab1
        '
        Me.tab1.Controls.Add(Me.TabPage1)
        Me.tab1.Controls.Add(Me.TabPage2)
        Me.tab1.Controls.Add(Me.TabPage3)
        Me.tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab1.Location = New System.Drawing.Point(0, 0)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(733, 519)
        Me.tab1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(725, 493)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Search/Поиск"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonQuit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.checkEnableExtraFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cTarget)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cDBitem)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.bFillGrid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cActors)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cActions)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid)
        Me.SplitContainer1.Size = New System.Drawing.Size(719, 465)
        Me.SplitContainer1.SplitterDistance = 98
        Me.SplitContainer1.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(542, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(137, 26)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Developed by E.Koksharov" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Russia, Ekaterinburg"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(539, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 18)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "LogD log Parser"
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(639, 63)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 10
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'checkEnableExtraFilter
        '
        Me.checkEnableExtraFilter.AutoSize = True
        Me.checkEnableExtraFilter.Checked = True
        Me.checkEnableExtraFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkEnableExtraFilter.Location = New System.Drawing.Point(86, 64)
        Me.checkEnableExtraFilter.Name = "checkEnableExtraFilter"
        Me.checkEnableExtraFilter.Size = New System.Drawing.Size(240, 17)
        Me.checkEnableExtraFilter.TabIndex = 9
        Me.checkEnableExtraFilter.Text = "Additional filters/Дополнительные фильтры"
        Me.checkEnableExtraFilter.UseVisualStyleBackColor = True
        '
        'cTarget
        '
        Me.cTarget.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cTarget.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cTarget.FormattingEnabled = True
        Me.cTarget.Location = New System.Drawing.Point(341, 34)
        Me.cTarget.Name = "cTarget"
        Me.cTarget.Size = New System.Drawing.Size(181, 21)
        Me.cTarget.TabIndex = 8
        Me.cTarget.Text = ">>Без фильтра"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(281, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "STR_target"
        '
        'cDBitem
        '
        Me.cDBitem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cDBitem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cDBitem.FormattingEnabled = True
        Me.cDBitem.Location = New System.Drawing.Point(341, 7)
        Me.cDBitem.Name = "cDBitem"
        Me.cDBitem.Size = New System.Drawing.Size(181, 21)
        Me.cDBitem.TabIndex = 6
        Me.cDBitem.Text = ">>Без фильтра"
        Me.cDBitem.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(290, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "item_id"
        Me.Label6.Visible = False
        '
        'bFillGrid
        '
        Me.bFillGrid.Location = New System.Drawing.Point(412, 64)
        Me.bFillGrid.Name = "bFillGrid"
        Me.bFillGrid.Size = New System.Drawing.Size(110, 20)
        Me.bFillGrid.TabIndex = 4
        Me.bFillGrid.Text = "Заполнить/Fill"
        Me.bFillGrid.UseVisualStyleBackColor = True
        '
        'cActors
        '
        Me.cActors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cActors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cActors.FormattingEnabled = True
        Me.cActors.Location = New System.Drawing.Point(86, 34)
        Me.cActors.Name = "cActors"
        Me.cActors.Size = New System.Drawing.Size(181, 21)
        Me.cActors.TabIndex = 3
        Me.cActors.Text = ">>Без фильтра"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "STR_Actor"
        '
        'cActions
        '
        Me.cActions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cActions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cActions.FormattingEnabled = True
        Me.cActions.Location = New System.Drawing.Point(86, 7)
        Me.cActions.Name = "cActions"
        Me.cActions.Size = New System.Drawing.Size(181, 21)
        Me.cActions.TabIndex = 1
        Me.cActions.Text = ">>Без фильтра"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "STR_action"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToOrderColumns = True
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.str5, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27})
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.Location = New System.Drawing.Point(0, 0)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.Size = New System.Drawing.Size(719, 363)
        Me.Grid.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "act_time"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 72
        '
        'Column2
        '
        Me.Column2.HeaderText = "action"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column28
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Column28.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column28.HeaderText = "str1"
        Me.Column28.Name = "Column28"
        Me.Column28.ReadOnly = True
        '
        'Column29
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Column29.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column29.HeaderText = "str2"
        Me.Column29.Name = "Column29"
        Me.Column29.ReadOnly = True
        '
        'Column30
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Column30.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column30.HeaderText = "str3"
        Me.Column30.Name = "Column30"
        Me.Column30.ReadOnly = True
        '
        'Column31
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Column31.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column31.HeaderText = "str4"
        Me.Column31.Name = "Column31"
        Me.Column31.ReadOnly = True
        '
        'str5
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.str5.DefaultCellStyle = DataGridViewCellStyle5
        Me.str5.HeaderText = "str5"
        Me.str5.Name = "str5"
        Me.str5.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "actor"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "actor_account"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "target"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "target_account"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "location_x"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "location_y"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "location_z"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "etc_str1"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "etc_str2"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "etc_str3"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "etc_num1"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "etc_num2"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "etc_num3"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "etc_num4"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.HeaderText = "etc_num5"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.HeaderText = "etc_num6"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.HeaderText = "etc_num7"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.HeaderText = "etc_num8"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'Column21
        '
        Me.Column21.HeaderText = "etc_num9"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        '
        'Column22
        '
        Me.Column22.HeaderText = "etc_num10"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        '
        'Column23
        '
        Me.Column23.HeaderText = "STR_actor"
        Me.Column23.Name = "Column23"
        Me.Column23.ReadOnly = True
        '
        'Column24
        '
        Me.Column24.HeaderText = "STR_actor_account"
        Me.Column24.Name = "Column24"
        Me.Column24.ReadOnly = True
        '
        'Column25
        '
        Me.Column25.HeaderText = "STR_target"
        Me.Column25.Name = "Column25"
        Me.Column25.ReadOnly = True
        '
        'Column26
        '
        Me.Column26.HeaderText = "STR_target_account"
        Me.Column26.Name = "Column26"
        Me.Column26.ReadOnly = True
        '
        'Column27
        '
        Me.Column27.HeaderText = "item_id"
        Me.Column27.Name = "Column27"
        Me.Column27.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 468)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(719, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(38, 17)
        Me.Status.Text = "Готов"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(725, 493)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings/Настройки"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.textMaxRows)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 370)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(471, 82)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Additional / Дополнительно"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(327, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 21)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Save / Запомнить"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'textMaxRows
        '
        Me.textMaxRows.Location = New System.Drawing.Point(248, 19)
        Me.textMaxRows.Name = "textMaxRows"
        Me.textMaxRows.Size = New System.Drawing.Size(53, 20)
        Me.textMaxRows.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(230, 26)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Maximum rows into table / " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Максимальное количество строк в таблице"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.textLogToSave)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.bSaveToFile)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 287)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(470, 77)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "To file/ В файл"
        '
        'textLogToSave
        '
        Me.textLogToSave.Location = New System.Drawing.Point(64, 19)
        Me.textLogToSave.Name = "textLogToSave"
        Me.textLogToSave.Size = New System.Drawing.Size(393, 20)
        Me.textLogToSave.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "file"
        '
        'bSaveToFile
        '
        Me.bSaveToFile.Location = New System.Drawing.Point(326, 45)
        Me.bSaveToFile.Name = "bSaveToFile"
        Me.bSaveToFile.Size = New System.Drawing.Size(128, 21)
        Me.bSaveToFile.TabIndex = 7
        Me.bSaveToFile.Text = "Save / Сохранить"
        Me.bSaveToFile.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.textLogs)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.InMemory)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 208)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(470, 73)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Logs/Логи"
        '
        'textLogs
        '
        Me.textLogs.Location = New System.Drawing.Point(64, 19)
        Me.textLogs.Name = "textLogs"
        Me.textLogs.Size = New System.Drawing.Size(393, 20)
        Me.textLogs.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "logs"
        '
        'InMemory
        '
        Me.InMemory.Location = New System.Drawing.Point(326, 45)
        Me.InMemory.Name = "InMemory"
        Me.InMemory.Size = New System.Drawing.Size(128, 21)
        Me.InMemory.TabIndex = 7
        Me.InMemory.Text = "To memory/В память"
        Me.InMemory.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.textNPC)
        Me.GroupBox1.Controls.Add(Me.checkLoadOnLaunch)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.bSave)
        Me.GroupBox1.Controls.Add(Me.textQuestName)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.textSkillName)
        Me.GroupBox1.Controls.Add(Me.textLogIDs)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.textItemName)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(471, 192)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Object Names/Названия"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(2, 126)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "NPCname"
        '
        'textNPC
        '
        Me.textNPC.Location = New System.Drawing.Point(67, 123)
        Me.textNPC.Name = "textNPC"
        Me.textNPC.Size = New System.Drawing.Size(393, 20)
        Me.textNPC.TabIndex = 12
        '
        'checkLoadOnLaunch
        '
        Me.checkLoadOnLaunch.AutoSize = True
        Me.checkLoadOnLaunch.Location = New System.Drawing.Point(67, 149)
        Me.checkLoadOnLaunch.Name = "checkLoadOnLaunch"
        Me.checkLoadOnLaunch.Size = New System.Drawing.Size(212, 17)
        Me.checkLoadOnLaunch.TabIndex = 11
        Me.checkLoadOnLaunch.Text = "Load on start/Загружать при запуске"
        Me.checkLoadOnLaunch.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(2, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "questname"
        '
        'bSave
        '
        Me.bSave.Location = New System.Drawing.Point(327, 149)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(133, 35)
        Me.bSave.TabIndex = 6
        Me.bSave.Text = "Save and Load /" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Запомнить и загрузить"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'textQuestName
        '
        Me.textQuestName.Location = New System.Drawing.Point(67, 97)
        Me.textQuestName.Name = "textQuestName"
        Me.textQuestName.Size = New System.Drawing.Size(393, 20)
        Me.textQuestName.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "skillname"
        '
        'textSkillName
        '
        Me.textSkillName.Location = New System.Drawing.Point(67, 71)
        Me.textSkillName.Name = "textSkillName"
        Me.textSkillName.Size = New System.Drawing.Size(393, 20)
        Me.textSkillName.TabIndex = 7
        '
        'textLogIDs
        '
        Me.textLogIDs.Location = New System.Drawing.Point(67, 19)
        Me.textLogIDs.Name = "textLogIDs"
        Me.textLogIDs.Size = New System.Drawing.Size(393, 20)
        Me.textLogIDs.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "log-ids"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "itemname"
        '
        'textItemName
        '
        Me.textItemName.Location = New System.Drawing.Point(67, 45)
        Me.textItemName.Name = "textItemName"
        Me.textItemName.Size = New System.Drawing.Size(393, 20)
        Me.textItemName.TabIndex = 4
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.gridFilter)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(725, 493)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Additional filters/Доп. фильтры"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'gridFilter
        '
        Me.gridFilter.AllowUserToOrderColumns = True
        Me.gridFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridFilter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colParam, Me.colOperation, Me.kolValue})
        Me.gridFilter.Location = New System.Drawing.Point(8, 6)
        Me.gridFilter.Name = "gridFilter"
        Me.gridFilter.Size = New System.Drawing.Size(539, 305)
        Me.gridFilter.TabIndex = 0
        '
        'colParam
        '
        Me.colParam.HeaderText = "Parameter/Параметр"
        Me.colParam.Name = "colParam"
        Me.colParam.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colParam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colParam.Width = 160
        '
        'colOperation
        '
        Me.colOperation.HeaderText = "Operation/Операция"
        Me.colOperation.Name = "colOperation"
        Me.colOperation.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOperation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colOperation.Width = 130
        '
        'kolValue
        '
        Me.kolValue.HeaderText = "Value/Значение"
        Me.kolValue.Name = "kolValue"
        Me.kolValue.Width = 200
        '
        'LogParser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 519)
        Me.Controls.Add(Me.tab1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LogParser"
        Me.Text = "Lineage II ScriptMaker: LogD Logs Parser"
        Me.tab1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.gridFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents tab1 As System.Windows.Forms.TabControl
    Public WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents checkEnableExtraFilter As System.Windows.Forms.CheckBox
    Public WithEvents cTarget As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents cDBitem As System.Windows.Forms.ComboBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents bFillGrid As System.Windows.Forms.Button
    Public WithEvents cActors As System.Windows.Forms.ComboBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents cActions As System.Windows.Forms.ComboBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Grid As System.Windows.Forms.DataGridView
    Public WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Public WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents textMaxRows As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents textLogToSave As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bSaveToFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents textLogs As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents InMemory As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents textNPC As System.Windows.Forms.TextBox
    Friend WithEvents checkLoadOnLaunch As System.Windows.Forms.CheckBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents textQuestName As System.Windows.Forms.TextBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents textSkillName As System.Windows.Forms.TextBox
    Public WithEvents textLogIDs As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents bSave As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents textItemName As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents gridFilter As System.Windows.Forms.DataGridView
    Friend WithEvents Save As System.Windows.Forms.SaveFileDialog
    Public WithEvents Folder As System.Windows.Forms.FolderBrowserDialog
    Public WithEvents Open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents colParam As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colOperation As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents kolValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents str5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

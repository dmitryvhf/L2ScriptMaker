<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class NpcPosAreaMaker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcPosAreaMaker))
        Me.AutoClearBox = New System.Windows.Forms.CheckBox
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.HeightZ = New System.Windows.Forms.TextBox
        Me.TotalNpc = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ZoneRadius = New System.Windows.Forms.TextBox
        Me.TextBoxFinal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.NpcZ = New System.Windows.Forms.TextBox
        Me.NpcY = New System.Windows.Forms.TextBox
        Me.NpcX = New System.Windows.Forms.TextBox
        Me.QuitButton = New System.Windows.Forms.Button
        Me.StartButton = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.NpcName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ZoneName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.RespawnTime = New System.Windows.Forms.TextBox
        Me.RespawnClass = New System.Windows.Forms.ComboBox
        Me.LookDirect = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Priv1Ai = New System.Windows.Forms.TextBox
        Me.Priv1Name = New System.Windows.Forms.TextBox
        Me.PrivRespawn = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Priv2Quantity = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Priv2Ai = New System.Windows.Forms.TextBox
        Me.Priv2Name = New System.Windows.Forms.TextBox
        Me.PrivRespawnTime = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Priv1Quantity = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.PrivChkBox = New System.Windows.Forms.CheckBox
        Me.ImportPos = New System.Windows.Forms.Button
        Me.ImportPosText = New System.Windows.Forms.TextBox
        Me.CycleImport = New System.Windows.Forms.CheckBox
        Me.OneZone = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Territory = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.NpcMaker = New System.Windows.Forms.TabPage
        Me.Label24 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.NpcBegin = New System.Windows.Forms.TabPage
        Me.DataGrid = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBoxUseDB = New System.Windows.Forms.CheckBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Privates = New System.Windows.Forms.TabPage
        Me.ImportData = New System.Windows.Forms.TabPage
        Me.ColumnX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnZ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnLook = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnChance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label28 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.MultiSpawn = New System.Windows.Forms.TabPage
        Me.MultiSpawnTextBox = New System.Windows.Forms.TextBox
        Me.GenerateMultiSpawnButton = New System.Windows.Forms.Button
        Me.CalculateButton = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Territory.SuspendLayout()
        Me.NpcMaker.SuspendLayout()
        Me.NpcBegin.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Privates.SuspendLayout()
        Me.ImportData.SuspendLayout()
        Me.MultiSpawn.SuspendLayout()
        Me.SuspendLayout()
        '
        'AutoClearBox
        '
        Me.AutoClearBox.AutoSize = True
        Me.AutoClearBox.Location = New System.Drawing.Point(14, 362)
        Me.AutoClearBox.Name = "AutoClearBox"
        Me.AutoClearBox.Size = New System.Drawing.Size(75, 17)
        Me.AutoClearBox.TabIndex = 13
        Me.AutoClearBox.Text = "Auto Clear"
        Me.ToolTip1.SetToolTip(Me.AutoClearBox, "Check it for automatic clearing a window" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "of a conclusion of the information.")
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(10, 385)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClear.TabIndex = 16
        Me.ButtonClear.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.ButtonClear, "Press it for clearing output" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "window for new position info.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(88, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "maximum_npc"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Zone(radius)"
        '
        'HeightZ
        '
        Me.HeightZ.Location = New System.Drawing.Point(17, 161)
        Me.HeightZ.Name = "HeightZ"
        Me.HeightZ.Size = New System.Drawing.Size(42, 20)
        Me.HeightZ.TabIndex = 9
        '
        'TotalNpc
        '
        Me.TotalNpc.Location = New System.Drawing.Point(91, 96)
        Me.TotalNpc.Name = "TotalNpc"
        Me.TotalNpc.Size = New System.Drawing.Size(36, 20)
        Me.TotalNpc.TabIndex = 6
        '
        'ZoneRadius
        '
        Me.ZoneRadius.Location = New System.Drawing.Point(17, 200)
        Me.ZoneRadius.Name = "ZoneRadius"
        Me.ZoneRadius.Size = New System.Drawing.Size(42, 20)
        Me.ZoneRadius.TabIndex = 5
        '
        'TextBoxFinal
        '
        Me.TextBoxFinal.AcceptsTab = True
        Me.TextBoxFinal.Location = New System.Drawing.Point(93, 304)
        Me.TextBoxFinal.Multiline = True
        Me.TextBoxFinal.Name = "TextBoxFinal"
        Me.TextBoxFinal.ReadOnly = True
        Me.TextBoxFinal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxFinal.Size = New System.Drawing.Size(473, 129)
        Me.TextBoxFinal.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Height"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(126, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Z"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Y"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "X"
        '
        'NpcZ
        '
        Me.NpcZ.Location = New System.Drawing.Point(129, 81)
        Me.NpcZ.Name = "NpcZ"
        Me.NpcZ.Size = New System.Drawing.Size(50, 20)
        Me.NpcZ.TabIndex = 4
        '
        'NpcY
        '
        Me.NpcY.Location = New System.Drawing.Point(75, 81)
        Me.NpcY.Name = "NpcY"
        Me.NpcY.Size = New System.Drawing.Size(50, 20)
        Me.NpcY.TabIndex = 3
        '
        'NpcX
        '
        Me.NpcX.Location = New System.Drawing.Point(19, 81)
        Me.NpcX.Name = "NpcX"
        Me.NpcX.Size = New System.Drawing.Size(50, 20)
        Me.NpcX.TabIndex = 2
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(10, 414)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 17
        Me.QuitButton.Text = "Quit"
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(10, 333)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 14
        Me.StartButton.Text = "Start"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "NPC Name"
        '
        'NpcName
        '
        Me.NpcName.Location = New System.Drawing.Point(16, 42)
        Me.NpcName.Name = "NpcName"
        Me.NpcName.Size = New System.Drawing.Size(229, 20)
        Me.NpcName.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Zone Name"
        '
        'ZoneName
        '
        Me.ZoneName.Location = New System.Drawing.Point(83, 27)
        Me.ZoneName.Name = "ZoneName"
        Me.ZoneName.Size = New System.Drawing.Size(346, 20)
        Me.ZoneName.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(308, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "respawn"
        '
        'RespawnTime
        '
        Me.RespawnTime.Location = New System.Drawing.Point(311, 159)
        Me.RespawnTime.Name = "RespawnTime"
        Me.RespawnTime.Size = New System.Drawing.Size(36, 20)
        Me.RespawnTime.TabIndex = 7
        '
        'RespawnClass
        '
        Me.RespawnClass.FormattingEnabled = True
        Me.RespawnClass.Items.AddRange(New Object() {"sec", "min", "hour"})
        Me.RespawnClass.Location = New System.Drawing.Point(353, 158)
        Me.RespawnClass.Name = "RespawnClass"
        Me.RespawnClass.Size = New System.Drawing.Size(47, 21)
        Me.RespawnClass.TabIndex = 8
        '
        'LookDirect
        '
        Me.LookDirect.FormattingEnabled = True
        Me.LookDirect.Items.AddRange(New Object() {"North", "East", "South", "West"})
        Me.LookDirect.Location = New System.Drawing.Point(185, 80)
        Me.LookDirect.Name = "LookDirect"
        Me.LookDirect.Size = New System.Drawing.Size(63, 21)
        Me.LookDirect.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(182, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Look direction"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.Dragon
        Me.PictureBox1.Location = New System.Drawing.Point(10, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(88, 196)
        Me.PictureBox1.TabIndex = 59
        Me.PictureBox1.TabStop = False
        '
        'Priv1Ai
        '
        Me.Priv1Ai.Location = New System.Drawing.Point(71, 69)
        Me.Priv1Ai.Name = "Priv1Ai"
        Me.Priv1Ai.Size = New System.Drawing.Size(184, 20)
        Me.Priv1Ai.TabIndex = 1
        '
        'Priv1Name
        '
        Me.Priv1Name.Location = New System.Drawing.Point(71, 46)
        Me.Priv1Name.Name = "Priv1Name"
        Me.Priv1Name.Size = New System.Drawing.Size(184, 20)
        Me.Priv1Name.TabIndex = 0
        '
        'PrivRespawn
        '
        Me.PrivRespawn.Location = New System.Drawing.Point(72, 226)
        Me.PrivRespawn.Name = "PrivRespawn"
        Me.PrivRespawn.Size = New System.Drawing.Size(70, 20)
        Me.PrivRespawn.TabIndex = 6
        Me.PrivRespawn.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 158)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 94
        Me.Label17.Text = "Ai name:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 135)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 13)
        Me.Label18.TabIndex = 93
        Me.Label18.Text = "Npc Name:"
        '
        'Priv2Quantity
        '
        Me.Priv2Quantity.FormattingEnabled = True
        Me.Priv2Quantity.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6"})
        Me.Priv2Quantity.Location = New System.Drawing.Point(71, 180)
        Me.Priv2Quantity.Name = "Priv2Quantity"
        Me.Priv2Quantity.Size = New System.Drawing.Size(64, 21)
        Me.Priv2Quantity.TabIndex = 5
        Me.Priv2Quantity.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 183)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 13)
        Me.Label19.TabIndex = 91
        Me.Label19.Text = "How many:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.Location = New System.Drawing.Point(70, 118)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 13)
        Me.Label20.TabIndex = 90
        Me.Label20.Text = "Minion 2"
        '
        'Priv2Ai
        '
        Me.Priv2Ai.Location = New System.Drawing.Point(71, 158)
        Me.Priv2Ai.Name = "Priv2Ai"
        Me.Priv2Ai.Size = New System.Drawing.Size(184, 20)
        Me.Priv2Ai.TabIndex = 4
        '
        'Priv2Name
        '
        Me.Priv2Name.Location = New System.Drawing.Point(71, 135)
        Me.Priv2Name.Name = "Priv2Name"
        Me.Priv2Name.Size = New System.Drawing.Size(184, 20)
        Me.Priv2Name.TabIndex = 3
        '
        'PrivRespawnTime
        '
        Me.PrivRespawnTime.FormattingEnabled = True
        Me.PrivRespawnTime.Items.AddRange(New Object() {"sec", "min", "hour"})
        Me.PrivRespawnTime.Location = New System.Drawing.Point(147, 225)
        Me.PrivRespawnTime.Name = "PrivRespawnTime"
        Me.PrivRespawnTime.Size = New System.Drawing.Size(64, 21)
        Me.PrivRespawnTime.TabIndex = 7
        Me.PrivRespawnTime.Text = "sec"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.Location = New System.Drawing.Point(71, 209)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 13)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "Minion respawn:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 83
        Me.Label14.Text = "Ai name:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 82
        Me.Label13.Text = "Npc Name:"
        '
        'Priv1Quantity
        '
        Me.Priv1Quantity.FormattingEnabled = True
        Me.Priv1Quantity.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6"})
        Me.Priv1Quantity.Location = New System.Drawing.Point(71, 91)
        Me.Priv1Quantity.Name = "Priv1Quantity"
        Me.Priv1Quantity.Size = New System.Drawing.Size(64, 21)
        Me.Priv1Quantity.TabIndex = 2
        Me.Priv1Quantity.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 94)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "How many:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(70, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Minion 1"
        '
        'PrivChkBox
        '
        Me.PrivChkBox.AutoSize = True
        Me.PrivChkBox.Location = New System.Drawing.Point(9, 6)
        Me.PrivChkBox.Name = "PrivChkBox"
        Me.PrivChkBox.Size = New System.Drawing.Size(93, 17)
        Me.PrivChkBox.TabIndex = 11
        Me.PrivChkBox.Text = "Boss Privates:"
        '
        'ImportPos
        '
        Me.ImportPos.Location = New System.Drawing.Point(136, 12)
        Me.ImportPos.Name = "ImportPos"
        Me.ImportPos.Size = New System.Drawing.Size(75, 23)
        Me.ImportPos.TabIndex = 69
        Me.ImportPos.Text = "Import pos"
        '
        'ImportPosText
        '
        Me.ImportPosText.AcceptsReturn = True
        Me.ImportPosText.AcceptsTab = True
        Me.ImportPosText.HideSelection = False
        Me.ImportPosText.Location = New System.Drawing.Point(18, 54)
        Me.ImportPosText.Multiline = True
        Me.ImportPosText.Name = "ImportPosText"
        Me.ImportPosText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ImportPosText.Size = New System.Drawing.Size(419, 192)
        Me.ImportPosText.TabIndex = 70
        '
        'CycleImport
        '
        Me.CycleImport.AutoSize = True
        Me.CycleImport.Location = New System.Drawing.Point(18, 12)
        Me.CycleImport.Name = "CycleImport"
        Me.CycleImport.Size = New System.Drawing.Size(101, 17)
        Me.CycleImport.TabIndex = 71
        Me.CycleImport.Text = "Multidata Import"
        '
        'OneZone
        '
        Me.OneZone.AutoSize = True
        Me.OneZone.Location = New System.Drawing.Point(18, 31)
        Me.OneZone.Name = "OneZone"
        Me.OneZone.Size = New System.Drawing.Size(100, 17)
        Me.OneZone.TabIndex = 72
        Me.OneZone.Text = "Make one zone"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Territory)
        Me.TabControl1.Controls.Add(Me.NpcMaker)
        Me.TabControl1.Controls.Add(Me.NpcBegin)
        Me.TabControl1.Controls.Add(Me.Privates)
        Me.TabControl1.Controls.Add(Me.ImportData)
        Me.TabControl1.Controls.Add(Me.MultiSpawn)
        Me.TabControl1.Location = New System.Drawing.Point(104, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(462, 288)
        Me.TabControl1.TabIndex = 95
        '
        'Territory
        '
        Me.Territory.Controls.Add(Me.Label28)
        Me.Territory.Controls.Add(Me.HeightZ)
        Me.Territory.Controls.Add(Me.Label15)
        Me.Territory.Controls.Add(Me.Label6)
        Me.Territory.Controls.Add(Me.Label8)
        Me.Territory.Controls.Add(Me.ZoneName)
        Me.Territory.Controls.Add(Me.ZoneRadius)
        Me.Territory.Controls.Add(Me.Label4)
        Me.Territory.Location = New System.Drawing.Point(4, 22)
        Me.Territory.Name = "Territory"
        Me.Territory.Size = New System.Drawing.Size(454, 262)
        Me.Territory.TabIndex = 3
        Me.Territory.Text = "Territory"
        Me.Territory.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 4)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 13)
        Me.Label15.TabIndex = 64
        Me.Label15.Text = "Territory_begin"
        '
        'NpcMaker
        '
        Me.NpcMaker.Controls.Add(Me.Label24)
        Me.NpcMaker.Controls.Add(Me.TextBox1)
        Me.NpcMaker.Controls.Add(Me.Label21)
        Me.NpcMaker.Controls.Add(Me.Label22)
        Me.NpcMaker.Controls.Add(Me.ComboBox1)
        Me.NpcMaker.Controls.Add(Me.Label5)
        Me.NpcMaker.Controls.Add(Me.TotalNpc)
        Me.NpcMaker.Location = New System.Drawing.Point(4, 22)
        Me.NpcMaker.Name = "NpcMaker"
        Me.NpcMaker.Padding = New System.Windows.Forms.Padding(3)
        Me.NpcMaker.Size = New System.Drawing.Size(454, 262)
        Me.NpcMaker.TabIndex = 1
        Me.NpcMaker.Text = "NpcMaker"
        Me.NpcMaker.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(15, 80)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 13)
        Me.Label24.TabIndex = 99
        Me.Label24.Text = "initial_spawn"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(18, 96)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(36, 20)
        Me.TextBox1.TabIndex = 98
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(15, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 97
        Me.Label21.Text = "spawn_time"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 4)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 13)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "npcmaker_begin"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"agit_defend_warfare_start([partisan_agit001])", "agit_attack_warfare_start([partisan_agit001])", "siege_warfare_start(1)", "pc_siege_warfare_start(1)"})
        Me.ComboBox1.Location = New System.Drawing.Point(18, 47)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(238, 21)
        Me.ComboBox1.TabIndex = 96
        '
        'NpcBegin
        '
        Me.NpcBegin.Controls.Add(Me.ComboBox2)
        Me.NpcBegin.Controls.Add(Me.Label29)
        Me.NpcBegin.Controls.Add(Me.TextBox5)
        Me.NpcBegin.Controls.Add(Me.GroupBox1)
        Me.NpcBegin.Controls.Add(Me.Label23)
        Me.NpcBegin.Controls.Add(Me.Label26)
        Me.NpcBegin.Controls.Add(Me.TextBox3)
        Me.NpcBegin.Controls.Add(Me.RespawnClass)
        Me.NpcBegin.Controls.Add(Me.Label10)
        Me.NpcBegin.Controls.Add(Me.Label1)
        Me.NpcBegin.Controls.Add(Me.Label9)
        Me.NpcBegin.Controls.Add(Me.Label3)
        Me.NpcBegin.Controls.Add(Me.Label2)
        Me.NpcBegin.Controls.Add(Me.NpcZ)
        Me.NpcBegin.Controls.Add(Me.RespawnTime)
        Me.NpcBegin.Controls.Add(Me.NpcY)
        Me.NpcBegin.Controls.Add(Me.Label7)
        Me.NpcBegin.Controls.Add(Me.NpcX)
        Me.NpcBegin.Controls.Add(Me.LookDirect)
        Me.NpcBegin.Controls.Add(Me.NpcName)
        Me.NpcBegin.Location = New System.Drawing.Point(4, 22)
        Me.NpcBegin.Name = "NpcBegin"
        Me.NpcBegin.Size = New System.Drawing.Size(454, 262)
        Me.NpcBegin.TabIndex = 2
        Me.NpcBegin.Text = "NpcName"
        Me.NpcBegin.UseVisualStyleBackColor = True
        '
        'DataGrid
        '
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnX, Me.ColumnY, Me.ColumnZ, Me.ColumnLook, Me.ColumnChance})
        Me.DataGrid.Location = New System.Drawing.Point(15, 18)
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.Size = New System.Drawing.Size(349, 99)
        Me.DataGrid.TabIndex = 65
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxUseDB)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 108)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DB Options"
        '
        'CheckBoxUseDB
        '
        Me.CheckBoxUseDB.AutoSize = True
        Me.CheckBoxUseDB.Location = New System.Drawing.Point(154, 10)
        Me.CheckBoxUseDB.Name = "CheckBoxUseDB"
        Me.CheckBoxUseDB.Size = New System.Drawing.Size(60, 17)
        Me.CheckBoxUseDB.TabIndex = 98
        Me.CheckBoxUseDB.Text = "UseDB"
        Me.CheckBoxUseDB.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 58)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 13)
        Me.Label27.TabIndex = 97
        Me.Label27.Text = "dbsaving"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(45, 13)
        Me.Label25.TabIndex = 97
        Me.Label25.Text = "dbname"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(9, 74)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(229, 20)
        Me.TextBox4.TabIndex = 1
        Me.TextBox4.Text = "{death_time;parameters;pos}"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(9, 32)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(229, 20)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "[gludio_siege_001]"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 4)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(92, 13)
        Me.Label23.TabIndex = 64
        Me.Label23.Text = "Territory_begin"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(262, 64)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(27, 13)
        Me.Label26.TabIndex = 53
        Me.Label26.Text = "total"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(263, 81)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(36, 20)
        Me.TextBox3.TabIndex = 6
        '
        'Privates
        '
        Me.Privates.Controls.Add(Me.Label17)
        Me.Privates.Controls.Add(Me.Priv2Name)
        Me.Privates.Controls.Add(Me.Label18)
        Me.Privates.Controls.Add(Me.Priv1Name)
        Me.Privates.Controls.Add(Me.Priv2Quantity)
        Me.Privates.Controls.Add(Me.PrivChkBox)
        Me.Privates.Controls.Add(Me.Priv1Ai)
        Me.Privates.Controls.Add(Me.Label19)
        Me.Privates.Controls.Add(Me.PrivRespawn)
        Me.Privates.Controls.Add(Me.Label20)
        Me.Privates.Controls.Add(Me.Label11)
        Me.Privates.Controls.Add(Me.Priv2Ai)
        Me.Privates.Controls.Add(Me.Label12)
        Me.Privates.Controls.Add(Me.Priv1Quantity)
        Me.Privates.Controls.Add(Me.PrivRespawnTime)
        Me.Privates.Controls.Add(Me.Label13)
        Me.Privates.Controls.Add(Me.Label16)
        Me.Privates.Controls.Add(Me.Label14)
        Me.Privates.Location = New System.Drawing.Point(4, 22)
        Me.Privates.Name = "Privates"
        Me.Privates.Padding = New System.Windows.Forms.Padding(3)
        Me.Privates.Size = New System.Drawing.Size(454, 262)
        Me.Privates.TabIndex = 0
        Me.Privates.Text = "Privates"
        Me.Privates.UseVisualStyleBackColor = True
        '
        'ImportData
        '
        Me.ImportData.Controls.Add(Me.OneZone)
        Me.ImportData.Controls.Add(Me.ImportPos)
        Me.ImportData.Controls.Add(Me.CycleImport)
        Me.ImportData.Controls.Add(Me.ImportPosText)
        Me.ImportData.Location = New System.Drawing.Point(4, 22)
        Me.ImportData.Name = "ImportData"
        Me.ImportData.Size = New System.Drawing.Size(454, 262)
        Me.ImportData.TabIndex = 4
        Me.ImportData.Text = "MultiPos Import"
        Me.ImportData.UseVisualStyleBackColor = True
        '
        'ColumnX
        '
        Me.ColumnX.HeaderText = "X"
        Me.ColumnX.Name = "ColumnX"
        Me.ColumnX.Width = 60
        '
        'ColumnY
        '
        Me.ColumnY.HeaderText = "Y"
        Me.ColumnY.Name = "ColumnY"
        Me.ColumnY.Width = 60
        '
        'ColumnZ
        '
        Me.ColumnZ.HeaderText = "Z"
        Me.ColumnZ.Name = "ColumnZ"
        Me.ColumnZ.Width = 60
        '
        'ColumnLook
        '
        Me.ColumnLook.HeaderText = "Look"
        Me.ColumnLook.Name = "ColumnLook"
        Me.ColumnLook.Width = 60
        '
        'ColumnChance
        '
        Me.ColumnChance.HeaderText = "Chance"
        Me.ColumnChance.Name = "ColumnChance"
        Me.ColumnChance.Width = 60
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label28.Location = New System.Drawing.Point(16, 129)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(87, 13)
        Me.Label28.TabIndex = 65
        Me.Label28.Text = "Other options:"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"sec", "min", "hour"})
        Me.ComboBox2.Location = New System.Drawing.Point(353, 197)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(47, 21)
        Me.ComboBox2.TabIndex = 71
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(308, 182)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(74, 13)
        Me.Label29.TabIndex = 72
        Me.Label29.Text = "respawn_rand"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(311, 198)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(36, 20)
        Me.TextBox5.TabIndex = 70
        '
        'MultiSpawn
        '
        Me.MultiSpawn.Controls.Add(Me.CalculateButton)
        Me.MultiSpawn.Controls.Add(Me.GenerateMultiSpawnButton)
        Me.MultiSpawn.Controls.Add(Me.MultiSpawnTextBox)
        Me.MultiSpawn.Controls.Add(Me.DataGrid)
        Me.MultiSpawn.Location = New System.Drawing.Point(4, 22)
        Me.MultiSpawn.Name = "MultiSpawn"
        Me.MultiSpawn.Size = New System.Drawing.Size(454, 262)
        Me.MultiSpawn.TabIndex = 5
        Me.MultiSpawn.Text = "MultiSpawn"
        Me.MultiSpawn.UseVisualStyleBackColor = True
        '
        'MultiSpawnTextBox
        '
        Me.MultiSpawnTextBox.Location = New System.Drawing.Point(15, 123)
        Me.MultiSpawnTextBox.Multiline = True
        Me.MultiSpawnTextBox.Name = "MultiSpawnTextBox"
        Me.MultiSpawnTextBox.Size = New System.Drawing.Size(418, 125)
        Me.MultiSpawnTextBox.TabIndex = 66
        '
        'GenerateMultiSpawnButton
        '
        Me.GenerateMultiSpawnButton.Location = New System.Drawing.Point(370, 47)
        Me.GenerateMultiSpawnButton.Name = "GenerateMultiSpawnButton"
        Me.GenerateMultiSpawnButton.Size = New System.Drawing.Size(75, 23)
        Me.GenerateMultiSpawnButton.TabIndex = 67
        Me.GenerateMultiSpawnButton.Text = "Generate"
        Me.GenerateMultiSpawnButton.UseVisualStyleBackColor = True
        '
        'CalculateButton
        '
        Me.CalculateButton.Location = New System.Drawing.Point(370, 18)
        Me.CalculateButton.Name = "CalculateButton"
        Me.CalculateButton.Size = New System.Drawing.Size(75, 23)
        Me.CalculateButton.TabIndex = 68
        Me.CalculateButton.Text = "Calculate"
        Me.CalculateButton.UseVisualStyleBackColor = True
        '
        'NpcPosAreaMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 445)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.AutoClearBox)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.TextBoxFinal)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcPosAreaMaker"
        Me.Text = "Npc Area/Pos Maker"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Territory.ResumeLayout(False)
        Me.Territory.PerformLayout()
        Me.NpcMaker.ResumeLayout(False)
        Me.NpcMaker.PerformLayout()
        Me.NpcBegin.ResumeLayout(False)
        Me.NpcBegin.PerformLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Privates.ResumeLayout(False)
        Me.Privates.PerformLayout()
        Me.ImportData.ResumeLayout(False)
        Me.ImportData.PerformLayout()
        Me.MultiSpawn.ResumeLayout(False)
        Me.MultiSpawn.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents AutoClearBox As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents HeightZ As System.Windows.Forms.TextBox
    Friend WithEvents TotalNpc As System.Windows.Forms.TextBox
    Friend WithEvents ZoneRadius As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NpcZ As System.Windows.Forms.TextBox
    Friend WithEvents NpcY As System.Windows.Forms.TextBox
    Friend WithEvents NpcX As System.Windows.Forms.TextBox
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NpcName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ZoneName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RespawnTime As System.Windows.Forms.TextBox
    Friend WithEvents RespawnClass As System.Windows.Forms.ComboBox
    Friend WithEvents LookDirect As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Priv1Ai As System.Windows.Forms.TextBox
    Friend WithEvents Priv1Name As System.Windows.Forms.TextBox
    Friend WithEvents PrivRespawn As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Priv2Quantity As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Priv2Ai As System.Windows.Forms.TextBox
    Friend WithEvents Priv2Name As System.Windows.Forms.TextBox
    Friend WithEvents PrivRespawnTime As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Priv1Quantity As System.Windows.Forms.ComboBox
    Friend WithEvents PrivChkBox As System.Windows.Forms.CheckBox
    Friend WithEvents ImportPos As System.Windows.Forms.Button
    Friend WithEvents ImportPosText As System.Windows.Forms.TextBox
    Friend WithEvents CycleImport As System.Windows.Forms.CheckBox
    Friend WithEvents OneZone As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Privates As System.Windows.Forms.TabPage
    Friend WithEvents NpcMaker As System.Windows.Forms.TabPage
    Friend WithEvents NpcBegin As System.Windows.Forms.TabPage
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Territory As System.Windows.Forms.TabPage
    Friend WithEvents ImportData As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxUseDB As System.Windows.Forms.CheckBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ColumnX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnZ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnLook As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnChance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents MultiSpawn As System.Windows.Forms.TabPage
    Friend WithEvents CalculateButton As System.Windows.Forms.Button
    Friend WithEvents GenerateMultiSpawnButton As System.Windows.Forms.Button
    Friend WithEvents MultiSpawnTextBox As System.Windows.Forms.TextBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class DoorMakerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DoorMakerForm))
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.TextBoxX = New System.Windows.Forms.TextBox
        Me.TextBoxY = New System.Windows.Forms.TextBox
        Me.TextBoxZ = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxFinal = New System.Windows.Forms.TextBox
        Me.TextBoxZS = New System.Windows.Forms.TextBox
        Me.TextBoxYS = New System.Windows.Forms.TextBox
        Me.TextBoxXS = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.AutoClearBox = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BestZBox = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.DoorName = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.DoorType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.StatObjID = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.OpenMetod = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Heights = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.HP = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.PDef = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.MDef = New System.Windows.Forms.TextBox
        Me.HeightData = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.KnowType = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(249, 254)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 15
        Me.StartButton.Text = "Start"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(522, 254)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 18
        Me.QuitButton.Text = "Quit"
        '
        'TextBoxX
        '
        Me.TextBoxX.Location = New System.Drawing.Point(103, 100)
        Me.TextBoxX.Name = "TextBoxX"
        Me.TextBoxX.Size = New System.Drawing.Size(78, 20)
        Me.TextBoxX.TabIndex = 4
        '
        'TextBoxY
        '
        Me.TextBoxY.Location = New System.Drawing.Point(226, 100)
        Me.TextBoxY.Name = "TextBoxY"
        Me.TextBoxY.Size = New System.Drawing.Size(78, 20)
        Me.TextBoxY.TabIndex = 5
        '
        'TextBoxZ
        '
        Me.TextBoxZ.Location = New System.Drawing.Point(352, 101)
        Me.TextBoxZ.Name = "TextBoxZ"
        Me.TextBoxZ.Size = New System.Drawing.Size(78, 20)
        Me.TextBoxZ.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(187, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(310, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(433, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Z"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(433, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Z-Shift"
        '
        'TextBoxFinal
        '
        Me.TextBoxFinal.Location = New System.Drawing.Point(104, 170)
        Me.TextBoxFinal.Multiline = True
        Me.TextBoxFinal.Name = "TextBoxFinal"
        Me.TextBoxFinal.ReadOnly = True
        Me.TextBoxFinal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxFinal.Size = New System.Drawing.Size(493, 80)
        Me.TextBoxFinal.TabIndex = 17
        '
        'TextBoxZS
        '
        Me.TextBoxZS.Location = New System.Drawing.Point(352, 125)
        Me.TextBoxZS.Name = "TextBoxZS"
        Me.TextBoxZS.Size = New System.Drawing.Size(78, 20)
        Me.TextBoxZS.TabIndex = 9
        '
        'TextBoxYS
        '
        Me.TextBoxYS.Location = New System.Drawing.Point(226, 125)
        Me.TextBoxYS.Name = "TextBoxYS"
        Me.TextBoxYS.Size = New System.Drawing.Size(78, 20)
        Me.TextBoxYS.TabIndex = 8
        '
        'TextBoxXS
        '
        Me.TextBoxXS.Location = New System.Drawing.Point(103, 125)
        Me.TextBoxXS.Name = "TextBoxXS"
        Me.TextBoxXS.Size = New System.Drawing.Size(78, 20)
        Me.TextBoxXS.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(309, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Y-shift"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(187, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "X-shift"
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(249, 283)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClear.TabIndex = 34
        Me.ButtonClear.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.ButtonClear, "Press it for clearing output" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "window for new position info.")
        '
        'AutoClearBox
        '
        Me.AutoClearBox.AutoSize = True
        Me.AutoClearBox.Location = New System.Drawing.Point(329, 258)
        Me.AutoClearBox.Name = "AutoClearBox"
        Me.AutoClearBox.Size = New System.Drawing.Size(75, 17)
        Me.AutoClearBox.TabIndex = 16
        Me.AutoClearBox.Text = "Auto Clear"
        Me.ToolTip1.SetToolTip(Me.AutoClearBox, "Check it for automatic clearing a window" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "of a conclusion of the information.")
        '
        'BestZBox
        '
        Me.BestZBox.AutoSize = True
        Me.BestZBox.Location = New System.Drawing.Point(352, 147)
        Me.BestZBox.Name = "BestZBox"
        Me.BestZBox.Size = New System.Drawing.Size(95, 17)
        Me.BestZBox.TabIndex = 37
        Me.BestZBox.Text = "No best-Z shift"
        Me.ToolTip1.SetToolTip(Me.BestZBox, "No do best Z location." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """Pos"" will have the same level," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as ""Range"".")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(168, 254)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "HowToDo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.Dragon
        Me.PictureBox1.Location = New System.Drawing.Point(8, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(88, 196)
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'DoorName
        '
        Me.DoorName.Location = New System.Drawing.Point(103, 25)
        Me.DoorName.Name = "DoorName"
        Me.DoorName.Size = New System.Drawing.Size(178, 20)
        Me.DoorName.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(102, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "DoorName"
        '
        'DoorType
        '
        Me.DoorType.FormattingEnabled = True
        Me.DoorType.Items.AddRange(New Object() {"normal_type", "wall_type", "parent_type", "child_type"})
        Me.DoorType.Location = New System.Drawing.Point(297, 24)
        Me.DoorType.Name = "DoorType"
        Me.DoorType.Size = New System.Drawing.Size(121, 21)
        Me.DoorType.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(296, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "DoorType"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(103, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "StaticObjectID"
        '
        'StatObjID
        '
        Me.StatObjID.Location = New System.Drawing.Point(103, 67)
        Me.StatObjID.Name = "StatObjID"
        Me.StatObjID.Size = New System.Drawing.Size(100, 20)
        Me.StatObjID.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(296, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "OpenMetod"
        '
        'OpenMetod
        '
        Me.OpenMetod.FormattingEnabled = True
        Me.OpenMetod.Items.AddRange(New Object() {"by_npc", "by_skill", "by_click", "by_time"})
        Me.OpenMetod.Location = New System.Drawing.Point(297, 69)
        Me.OpenMetod.Name = "OpenMetod"
        Me.OpenMetod.Size = New System.Drawing.Size(121, 21)
        Me.OpenMetod.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(557, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Height"
        '
        'Heights
        '
        Me.Heights.Location = New System.Drawing.Point(473, 53)
        Me.Heights.Name = "Heights"
        Me.Heights.Size = New System.Drawing.Size(78, 20)
        Me.Heights.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(557, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "HP"
        '
        'HP
        '
        Me.HP.Location = New System.Drawing.Point(473, 82)
        Me.HP.Name = "HP"
        Me.HP.Size = New System.Drawing.Size(78, 20)
        Me.HP.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(557, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 26)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Physical" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "defence"
        '
        'PDef
        '
        Me.PDef.Location = New System.Drawing.Point(473, 109)
        Me.PDef.Name = "PDef"
        Me.PDef.Size = New System.Drawing.Size(78, 20)
        Me.PDef.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(557, 136)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 26)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "Magical" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "defence"
        '
        'MDef
        '
        Me.MDef.Location = New System.Drawing.Point(473, 136)
        Me.MDef.Name = "MDef"
        Me.MDef.Size = New System.Drawing.Size(78, 20)
        Me.MDef.TabIndex = 14
        '
        'HeightData
        '
        Me.HeightData.Location = New System.Drawing.Point(467, 19)
        Me.HeightData.Name = "HeightData"
        Me.HeightData.Size = New System.Drawing.Size(78, 20)
        Me.HeightData.TabIndex = 47
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(467, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(78, 20)
        Me.TextBox1.TabIndex = 47
        '
        'KnowType
        '
        Me.KnowType.FormattingEnabled = True
        Me.KnowType.Items.AddRange(New Object() {"Aden Walls", "Aden Outer Doors", "Aden Inner Doors", "Aden Castle Gates", "Castle Walls", "Castle Outer Doors", "Castle Inner Doors", "Castle Gate (Station)", "Lattice", "Kruma Door", "Bandit Stronghold Door", "City and Partisan Doors"})
        Me.KnowType.Location = New System.Drawing.Point(473, 24)
        Me.KnowType.Name = "KnowType"
        Me.KnowType.Size = New System.Drawing.Size(121, 21)
        Me.KnowType.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(472, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "KnowType"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 283)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 13)
        Me.Label16.TabIndex = 58
        Me.Label16.Text = "(support C4 scripts)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 267)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 16)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "DoorData Maker"
        '
        'DoorMakerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 318)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.KnowType)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.MDef)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PDef)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.HP)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Heights)
        Me.Controls.Add(Me.OpenMetod)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.StatObjID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DoorType)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DoorName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BestZBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.AutoClearBox)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxZS)
        Me.Controls.Add(Me.TextBoxYS)
        Me.Controls.Add(Me.TextBoxXS)
        Me.Controls.Add(Me.TextBoxFinal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxZ)
        Me.Controls.Add(Me.TextBoxY)
        Me.Controls.Add(Me.TextBoxX)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DoorMakerForm"
        Me.Text = "LineageII RangeMaker"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents TextBoxX As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxY As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxZ As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFinal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxZS As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxYS As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxXS As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents AutoClearBox As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BestZBox As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DoorName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DoorType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents StatObjID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents OpenMetod As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Heights As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents HP As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PDef As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents MDef As System.Windows.Forms.TextBox
    Friend WithEvents HeightData As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents KnowType As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class

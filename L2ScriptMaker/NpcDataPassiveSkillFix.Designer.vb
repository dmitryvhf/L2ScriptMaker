<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcDataPassiveSkillFix
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcDataPassiveSkillFix))
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.QuitButton = New System.Windows.Forms.Button
        Me.StartButton = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.LvlSklBox = New System.Windows.Forms.CheckBox
        Me.SFullMagicDefBox = New System.Windows.Forms.CheckBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SkillIgnorListBox = New System.Windows.Forms.TextBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "(support C4 scripts)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 32)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "NpcData Passive Skill " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "('skill_list') fix"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(267, 9)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 50
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(186, 9)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 49
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(15, 221)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(331, 23)
        Me.ProgressBar.TabIndex = 54
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(15, 57)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(331, 162)
        Me.TabControl1.TabIndex = 57
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LvlSklBox)
        Me.TabPage1.Controls.Add(Me.SFullMagicDefBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(323, 136)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Inherits options"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LvlSklBox
        '
        Me.LvlSklBox.AutoSize = True
        Me.LvlSklBox.Checked = True
        Me.LvlSklBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LvlSklBox.Location = New System.Drawing.Point(6, 6)
        Me.LvlSklBox.Name = "LvlSklBox"
        Me.LvlSklBox.Size = New System.Drawing.Size(125, 17)
        Me.LvlSklBox.TabIndex = 55
        Me.LvlSklBox.Text = "Do Inherits skill_level"
        Me.LvlSklBox.UseVisualStyleBackColor = True
        '
        'SFullMagicDefBox
        '
        Me.SFullMagicDefBox.AutoSize = True
        Me.SFullMagicDefBox.Checked = True
        Me.SFullMagicDefBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SFullMagicDefBox.Location = New System.Drawing.Point(6, 29)
        Me.SFullMagicDefBox.Name = "SFullMagicDefBox"
        Me.SFullMagicDefBox.Size = New System.Drawing.Size(140, 17)
        Me.SFullMagicDefBox.TabIndex = 56
        Me.SFullMagicDefBox.Text = "Do Inherits skills from list"
        Me.SFullMagicDefBox.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SkillIgnorListBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(323, 136)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Inherits skills"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SkillIgnorListBox
        '
        Me.SkillIgnorListBox.Location = New System.Drawing.Point(6, 6)
        Me.SkillIgnorListBox.Multiline = True
        Me.SkillIgnorListBox.Name = "SkillIgnorListBox"
        Me.SkillIgnorListBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.SkillIgnorListBox.Size = New System.Drawing.Size(311, 124)
        Me.SkillIgnorListBox.TabIndex = 0
        Me.SkillIgnorListBox.Text = resources.GetString("SkillIgnorListBox.Text")
        '
        'NpcDataPassiveSkillFix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 251)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcDataPassiveSkillFix"
        Me.Text = "NpcData Passive Skill fixer "
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents LvlSklBox As System.Windows.Forms.CheckBox
    Friend WithEvents SFullMagicDefBox As System.Windows.Forms.CheckBox
    Friend WithEvents SkillIgnorListBox As System.Windows.Forms.TextBox
End Class

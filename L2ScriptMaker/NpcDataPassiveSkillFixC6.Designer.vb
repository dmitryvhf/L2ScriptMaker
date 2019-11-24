<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcDataPassiveSkillFixC6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcDataPassiveSkillFixC6))
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.QuitButton = New System.Windows.Forms.Button
        Me.StartButton = New System.Windows.Forms.Button
        Me.MagicDefCheckBox = New System.Windows.Forms.CheckBox
        Me.CustomNameTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.AutosetToBossCheckBox = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.CheckBoxSaveActive = New System.Windows.Forms.CheckBox
        Me.CheckBoxStopActive = New System.Windows.Forms.CheckBox
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "(support all scripts and L2Disasm format)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 32)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "NpcData Passive Skill " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "('skill_list') fix"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(285, 6)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 59
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(204, 6)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 58
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'MagicDefCheckBox
        '
        Me.MagicDefCheckBox.AutoSize = True
        Me.MagicDefCheckBox.Checked = True
        Me.MagicDefCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MagicDefCheckBox.Location = New System.Drawing.Point(15, 67)
        Me.MagicDefCheckBox.Name = "MagicDefCheckBox"
        Me.MagicDefCheckBox.Size = New System.Drawing.Size(345, 43)
        Me.MagicDefCheckBox.TabIndex = 57
        Me.MagicDefCheckBox.Text = "Autoset skills:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- @s_summon_magic_defence on 'pet' and 'summon'" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- @s_full_magic" & _
            "_defence on all types except 'warrior' and 'zzoldagu'"
        Me.MagicDefCheckBox.UseVisualStyleBackColor = True
        '
        'CustomNameTextBox
        '
        Me.CustomNameTextBox.Location = New System.Drawing.Point(15, 165)
        Me.CustomNameTextBox.Multiline = True
        Me.CustomNameTextBox.Name = "CustomNameTextBox"
        Me.CustomNameTextBox.Size = New System.Drawing.Size(234, 37)
        Me.CustomNameTextBox.TabIndex = 63
        Me.CustomNameTextBox.Text = "s_summon_magic_defence" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "s_full_magic_defence"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 13)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Custom names for autoset skills:"
        '
        'AutosetToBossCheckBox
        '
        Me.AutosetToBossCheckBox.AutoSize = True
        Me.AutosetToBossCheckBox.Checked = True
        Me.AutosetToBossCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutosetToBossCheckBox.Location = New System.Drawing.Point(15, 116)
        Me.AutosetToBossCheckBox.Name = "AutosetToBossCheckBox"
        Me.AutosetToBossCheckBox.Size = New System.Drawing.Size(257, 30)
        Me.AutosetToBossCheckBox.TabIndex = 65
        Me.AutosetToBossCheckBox.Text = "Use autoset to 'boss' type" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(default, apply '@s_full_magic_defence' to 'boss')"
        Me.AutosetToBossCheckBox.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(255, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "skill_id=4121 level=1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(255, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 13)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "skill_id=4045 level=1"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 216)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(421, 22)
        Me.StatusStrip.TabIndex = 68
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(250, 16)
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(62, 17)
        Me.ToolStripStatusLabel.Text = "Welcome..."
        '
        'CheckBoxSaveActive
        '
        Me.CheckBoxSaveActive.AutoSize = True
        Me.CheckBoxSaveActive.Location = New System.Drawing.Point(278, 129)
        Me.CheckBoxSaveActive.Name = "CheckBoxSaveActive"
        Me.CheckBoxSaveActive.Size = New System.Drawing.Size(108, 17)
        Me.CheckBoxSaveActive.TabIndex = 69
        Me.CheckBoxSaveActive.Text = "Save active skills"
        Me.CheckBoxSaveActive.UseVisualStyleBackColor = True
        Me.CheckBoxSaveActive.Visible = False
        '
        'CheckBoxStopActive
        '
        Me.CheckBoxStopActive.AutoSize = True
        Me.CheckBoxStopActive.Location = New System.Drawing.Point(278, 144)
        Me.CheckBoxStopActive.Name = "CheckBoxStopActive"
        Me.CheckBoxStopActive.Size = New System.Drawing.Size(131, 17)
        Me.CheckBoxStopActive.TabIndex = 70
        Me.CheckBoxStopActive.Text = "Stop after save Active"
        Me.CheckBoxStopActive.UseVisualStyleBackColor = True
        Me.CheckBoxStopActive.Visible = False
        '
        'NpcDataPassiveSkillFixC6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 238)
        Me.Controls.Add(Me.CheckBoxStopActive)
        Me.Controls.Add(Me.CheckBoxSaveActive)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AutosetToBossCheckBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CustomNameTextBox)
        Me.Controls.Add(Me.MagicDefCheckBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcDataPassiveSkillFixC6"
        Me.Text = "NpcData Passive Skill fixer "
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents MagicDefCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CustomNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AutosetToBossCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CheckBoxSaveActive As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxStopActive As System.Windows.Forms.CheckBox
End Class

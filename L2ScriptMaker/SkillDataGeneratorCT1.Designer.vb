<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SkillDataGeneratorCT1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SkillDataGeneratorCT1))
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ExistPchCheckBox = New System.Windows.Forms.CheckBox
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.DontDescCheckBox = New System.Windows.Forms.CheckBox
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.Label4 = New System.Windows.Forms.Label
        Me.AllPassiveCheckBox = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Shema2RadioButton = New System.Windows.Forms.RadioButton
        Me.Shema1RadioButton = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.QuitButton = New System.Windows.Forms.Button
        Me.StartButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.StatusStrip.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(300, 16)
        Me.ToolStripProgressBar.Step = 1
        Me.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ExistPchCheckBox
        '
        Me.ExistPchCheckBox.AutoSize = True
        Me.ExistPchCheckBox.Location = New System.Drawing.Point(129, 174)
        Me.ExistPchCheckBox.Name = "ExistPchCheckBox"
        Me.ExistPchCheckBox.Size = New System.Drawing.Size(188, 17)
        Me.ExistPchCheckBox.TabIndex = 87
        Me.ExistPchCheckBox.Text = "use exist skill names from skill_pch"
        Me.ExistPchCheckBox.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 209)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(469, 22)
        Me.StatusStrip.TabIndex = 84
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'DontDescCheckBox
        '
        Me.DontDescCheckBox.AutoSize = True
        Me.DontDescCheckBox.Location = New System.Drawing.Point(129, 151)
        Me.DontDescCheckBox.Name = "DontDescCheckBox"
        Me.DontDescCheckBox.Size = New System.Drawing.Size(172, 17)
        Me.DontDescCheckBox.TabIndex = 85
        Me.DontDescCheckBox.Text = "dont transfer description /* [] */"
        Me.DontDescCheckBox.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(126, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Options:"
        '
        'AllPassiveCheckBox
        '
        Me.AllPassiveCheckBox.AutoSize = True
        Me.AllPassiveCheckBox.Location = New System.Drawing.Point(129, 128)
        Me.AllPassiveCheckBox.Name = "AllPassiveCheckBox"
        Me.AllPassiveCheckBox.Size = New System.Drawing.Size(149, 17)
        Me.AllPassiveCheckBox.TabIndex = 83
        Me.AllPassiveCheckBox.Text = "create all skill as (P)assive"
        Me.AllPassiveCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(126, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 13)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Skillname generation shemas:"
        '
        'Shema2RadioButton
        '
        Me.Shema2RadioButton.AutoSize = True
        Me.Shema2RadioButton.Location = New System.Drawing.Point(129, 89)
        Me.Shema2RadioButton.Name = "Shema2RadioButton"
        Me.Shema2RadioButton.Size = New System.Drawing.Size(207, 17)
        Me.Shema2RadioButton.TabIndex = 80
        Me.Shema2RadioButton.Text = "'s_%skill_id%_%skill_level%'  (s_458_1)"
        Me.Shema2RadioButton.UseVisualStyleBackColor = True
        '
        'Shema1RadioButton
        '
        Me.Shema1RadioButton.AutoSize = True
        Me.Shema1RadioButton.Checked = True
        Me.Shema1RadioButton.Location = New System.Drawing.Point(129, 66)
        Me.Shema1RadioButton.Name = "Shema1RadioButton"
        Me.Shema1RadioButton.Size = New System.Drawing.Size(327, 17)
        Me.Shema1RadioButton.TabIndex = 81
        Me.Shema1RadioButton.TabStop = True
        Me.Shema1RadioButton.Text = "generate name like 's_%skill_id%%skill_level%' (s_power_strike1)"
        Me.Shema1RadioButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(260, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "(support all scripts and L2Disasm format)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(137, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(320, 32)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "clean Cronicles Throne 1 Skilldata.txt and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "skillenchantdata.txt Generator from c" & _
            "lient .dat side"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(381, 142)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 76
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(381, 109)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 75
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 158)
        Me.PictureBox1.TabIndex = 77
        Me.PictureBox1.TabStop = False
        '
        'SkillDataGeneratorCT1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 231)
        Me.Controls.Add(Me.ExistPchCheckBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.DontDescCheckBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AllPassiveCheckBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Shema2RadioButton)
        Me.Controls.Add(Me.Shema1RadioButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SkillDataGeneratorCT1"
        Me.Text = "Lineage II Cronicles Throne 1 SkillData and SkillEnchantData Generator"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ExistPchCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DontDescCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AllPassiveCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Shema2RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Shema1RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
End Class

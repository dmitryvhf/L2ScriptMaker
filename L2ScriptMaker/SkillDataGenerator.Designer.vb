<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SkillDataGenerator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SkillDataGenerator))
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Shema2RadioButton = New System.Windows.Forms.RadioButton
        Me.Shema1RadioButton = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.AllPassiveCheckBox = New System.Windows.Forms.CheckBox
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.DontDescCheckBox = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ExistPchCheckBox = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(381, 114)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(381, 147)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 1
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 158)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(260, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "(support all scripts and L2Disasm format)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(145, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(270, 32)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "clean Skilldata.txt and skillenchantdata.txt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Generator from client .dat side"
        '
        'Shema2RadioButton
        '
        Me.Shema2RadioButton.AutoSize = True
        Me.Shema2RadioButton.Location = New System.Drawing.Point(129, 94)
        Me.Shema2RadioButton.Name = "Shema2RadioButton"
        Me.Shema2RadioButton.Size = New System.Drawing.Size(207, 17)
        Me.Shema2RadioButton.TabIndex = 67
        Me.Shema2RadioButton.Text = "'s_%skill_id%_%skill_level%'  (s_458_1)"
        Me.Shema2RadioButton.UseVisualStyleBackColor = True
        '
        'Shema1RadioButton
        '
        Me.Shema1RadioButton.AutoSize = True
        Me.Shema1RadioButton.Checked = True
        Me.Shema1RadioButton.Location = New System.Drawing.Point(129, 71)
        Me.Shema1RadioButton.Name = "Shema1RadioButton"
        Me.Shema1RadioButton.Size = New System.Drawing.Size(327, 17)
        Me.Shema1RadioButton.TabIndex = 68
        Me.Shema1RadioButton.TabStop = True
        Me.Shema1RadioButton.Text = "generate name like 's_%skill_id%%skill_level%' (s_power_strike1)"
        Me.Shema1RadioButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(126, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Skillname generation shemas:"
        '
        'AllPassiveCheckBox
        '
        Me.AllPassiveCheckBox.AutoSize = True
        Me.AllPassiveCheckBox.Location = New System.Drawing.Point(129, 133)
        Me.AllPassiveCheckBox.Name = "AllPassiveCheckBox"
        Me.AllPassiveCheckBox.Size = New System.Drawing.Size(149, 17)
        Me.AllPassiveCheckBox.TabIndex = 70
        Me.AllPassiveCheckBox.Text = "create all skill as (P)assive"
        Me.AllPassiveCheckBox.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 208)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(469, 22)
        Me.StatusStrip.TabIndex = 71
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(300, 16)
        Me.ToolStripProgressBar.Step = 1
        Me.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'DontDescCheckBox
        '
        Me.DontDescCheckBox.AutoSize = True
        Me.DontDescCheckBox.Location = New System.Drawing.Point(129, 156)
        Me.DontDescCheckBox.Name = "DontDescCheckBox"
        Me.DontDescCheckBox.Size = New System.Drawing.Size(172, 17)
        Me.DontDescCheckBox.TabIndex = 72
        Me.DontDescCheckBox.Text = "dont transfer description /* [] */"
        Me.DontDescCheckBox.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(126, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Options:"
        '
        'ExistPchCheckBox
        '
        Me.ExistPchCheckBox.AutoSize = True
        Me.ExistPchCheckBox.Location = New System.Drawing.Point(129, 179)
        Me.ExistPchCheckBox.Name = "ExistPchCheckBox"
        Me.ExistPchCheckBox.Size = New System.Drawing.Size(188, 17)
        Me.ExistPchCheckBox.TabIndex = 74
        Me.ExistPchCheckBox.Text = "use exist skill names from skill_pch"
        Me.ExistPchCheckBox.UseVisualStyleBackColor = True
        '
        'SkillDataGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 230)
        Me.Controls.Add(Me.ExistPchCheckBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DontDescCheckBox)
        Me.Controls.Add(Me.AllPassiveCheckBox)
        Me.Controls.Add(Me.StatusStrip)
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
        Me.Name = "SkillDataGenerator"
        Me.Text = "Lineage II Cronicles 4 SkillData and SkillEnchantData Generator"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Shema2RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Shema1RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AllPassiveCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DontDescCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ExistPchCheckBox As System.Windows.Forms.CheckBox
End Class

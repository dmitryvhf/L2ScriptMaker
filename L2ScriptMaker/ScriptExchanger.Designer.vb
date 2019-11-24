<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptExchanger
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptExchanger))
        Me.Label4 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.TimeEnd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TimeStart = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.ButtonImport = New System.Windows.Forms.Button
        Me.ButtonExport = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusBox = New System.Windows.Forms.TextBox
        Me.FilePos = New System.Windows.Forms.ProgressBar
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.ButtonLoadItem = New System.Windows.Forms.Button
        Me.DoItem = New System.Windows.Forms.CheckBox
        Me.DoNpc = New System.Windows.Forms.CheckBox
        Me.DoSkill = New System.Windows.Forms.CheckBox
        Me.DoIgnore = New System.Windows.Forms.CheckBox
        Me.DuplicateCheckBox = New System.Windows.Forms.CheckBox
        Me.IsSkillAquire = New System.Windows.Forms.ComboBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(360, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "End time:"
        '
        'TimeEnd
        '
        Me.TimeEnd.Location = New System.Drawing.Point(420, 174)
        Me.TimeEnd.Name = "TimeEnd"
        Me.TimeEnd.ReadOnly = True
        Me.TimeEnd.Size = New System.Drawing.Size(140, 20)
        Me.TimeEnd.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(360, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Start time:"
        '
        'TimeStart
        '
        Me.TimeStart.Location = New System.Drawing.Point(420, 148)
        Me.TimeStart.Name = "TimeStart"
        Me.TimeStart.ReadOnly = True
        Me.TimeStart.Size = New System.Drawing.Size(140, 20)
        Me.TimeStart.TabIndex = 25
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.Dragon
        Me.PictureBox1.Location = New System.Drawing.Point(6, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 201)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Current text in progress:"
        '
        'ButtonImport
        '
        Me.ButtonImport.Location = New System.Drawing.Point(101, 175)
        Me.ButtonImport.Name = "ButtonImport"
        Me.ButtonImport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonImport.TabIndex = 22
        Me.ButtonImport.Text = "Import"
        Me.ButtonImport.UseVisualStyleBackColor = True
        '
        'ButtonExport
        '
        Me.ButtonExport.Location = New System.Drawing.Point(101, 204)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExport.TabIndex = 21
        Me.ButtonExport.Text = "Export"
        Me.ButtonExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(101, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Progress:"
        '
        'StatusBox
        '
        Me.StatusBox.Location = New System.Drawing.Point(101, 26)
        Me.StatusBox.Multiline = True
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(459, 84)
        Me.StatusBox.TabIndex = 19
        '
        'FilePos
        '
        Me.FilePos.Location = New System.Drawing.Point(158, 116)
        Me.FilePos.Name = "FilePos"
        Me.FilePos.Size = New System.Drawing.Size(402, 23)
        Me.FilePos.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.FilePos.TabIndex = 18
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(485, 204)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 17
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ButtonLoadItem
        '
        Me.ButtonLoadItem.Location = New System.Drawing.Point(101, 146)
        Me.ButtonLoadItem.Name = "ButtonLoadItem"
        Me.ButtonLoadItem.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLoadItem.TabIndex = 16
        Me.ButtonLoadItem.Text = "Load Pch"
        Me.ButtonLoadItem.UseVisualStyleBackColor = True
        '
        'DoItem
        '
        Me.DoItem.AutoSize = True
        Me.DoItem.Checked = True
        Me.DoItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DoItem.Location = New System.Drawing.Point(182, 179)
        Me.DoItem.Name = "DoItem"
        Me.DoItem.Size = New System.Drawing.Size(53, 17)
        Me.DoItem.TabIndex = 29
        Me.DoItem.Text = "Item's"
        Me.DoItem.UseVisualStyleBackColor = True
        '
        'DoNpc
        '
        Me.DoNpc.AutoSize = True
        Me.DoNpc.Checked = True
        Me.DoNpc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DoNpc.Location = New System.Drawing.Point(182, 195)
        Me.DoNpc.Name = "DoNpc"
        Me.DoNpc.Size = New System.Drawing.Size(53, 17)
        Me.DoNpc.TabIndex = 30
        Me.DoNpc.Text = "Npc's"
        Me.DoNpc.UseVisualStyleBackColor = True
        '
        'DoSkill
        '
        Me.DoSkill.AutoSize = True
        Me.DoSkill.Checked = True
        Me.DoSkill.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DoSkill.Location = New System.Drawing.Point(182, 211)
        Me.DoSkill.Name = "DoSkill"
        Me.DoSkill.Size = New System.Drawing.Size(52, 17)
        Me.DoSkill.TabIndex = 31
        Me.DoSkill.Text = "Skill's"
        Me.DoSkill.UseVisualStyleBackColor = True
        '
        'DoIgnore
        '
        Me.DoIgnore.AutoSize = True
        Me.DoIgnore.Location = New System.Drawing.Point(258, 179)
        Me.DoIgnore.Name = "DoIgnore"
        Me.DoIgnore.Size = New System.Drawing.Size(80, 17)
        Me.DoIgnore.TabIndex = 32
        Me.DoIgnore.Text = "Ignore error"
        Me.DoIgnore.UseVisualStyleBackColor = True
        '
        'DuplicateCheckBox
        '
        Me.DuplicateCheckBox.AutoSize = True
        Me.DuplicateCheckBox.Location = New System.Drawing.Point(182, 150)
        Me.DuplicateCheckBox.Name = "DuplicateCheckBox"
        Me.DuplicateCheckBox.Size = New System.Drawing.Size(104, 17)
        Me.DuplicateCheckBox.TabIndex = 33
        Me.DuplicateCheckBox.Text = "Duplicate check"
        Me.DuplicateCheckBox.UseVisualStyleBackColor = True
        '
        'IsSkillAquire
        '
        Me.IsSkillAquire.FormattingEnabled = True
        Me.IsSkillAquire.Items.AddRange(New Object() {"Is Another script", "Is SkillData"})
        Me.IsSkillAquire.Location = New System.Drawing.Point(258, 206)
        Me.IsSkillAquire.Name = "IsSkillAquire"
        Me.IsSkillAquire.Size = New System.Drawing.Size(121, 21)
        Me.IsSkillAquire.TabIndex = 35
        Me.IsSkillAquire.Text = "Is Another script"
        '
        'ScriptExchanger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 241)
        Me.Controls.Add(Me.IsSkillAquire)
        Me.Controls.Add(Me.DuplicateCheckBox)
        Me.Controls.Add(Me.DoIgnore)
        Me.Controls.Add(Me.DoSkill)
        Me.Controls.Add(Me.DoNpc)
        Me.Controls.Add(Me.DoItem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TimeEnd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TimeStart)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonImport)
        Me.Controls.Add(Me.ButtonExport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.FilePos)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonLoadItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScriptExchanger"
        Me.Text = "ScriptExchanger"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TimeEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TimeStart As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ButtonImport As System.Windows.Forms.Button
    Friend WithEvents ButtonExport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Friend WithEvents FilePos As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ButtonLoadItem As System.Windows.Forms.Button
    Friend WithEvents DoItem As System.Windows.Forms.CheckBox
    Friend WithEvents DoNpc As System.Windows.Forms.CheckBox
    Friend WithEvents DoSkill As System.Windows.Forms.CheckBox
    Friend WithEvents DoIgnore As System.Windows.Forms.CheckBox
    Friend WithEvents DuplicateCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IsSkillAquire As System.Windows.Forms.ComboBox
End Class

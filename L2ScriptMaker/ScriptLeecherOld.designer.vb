<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptLeecherOld
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptLeecherOld))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ButtonOpen1 = New System.Windows.Forms.Button
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.File1 = New System.Windows.Forms.TextBox
        Me.File2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonOpen2 = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.ButtonChkAll = New System.Windows.Forms.Button
        Me.ButtonDeChkAll = New System.Windows.Forms.Button
        Me.ButtonImportList = New System.Windows.Forms.Button
        Me.NpcParam = New System.Windows.Forms.CheckedListBox
        Me.SrcSkillgrpButton = New System.Windows.Forms.RadioButton
        Me.SrcSkilldataEButton = New System.Windows.Forms.RadioButton
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.Dragon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 195)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ButtonOpen1
        '
        Me.ButtonOpen1.Location = New System.Drawing.Point(422, 24)
        Me.ButtonOpen1.Name = "ButtonOpen1"
        Me.ButtonOpen1.Size = New System.Drawing.Size(45, 23)
        Me.ButtonOpen1.TabIndex = 3
        Me.ButtonOpen1.Text = "Select"
        Me.ButtonOpen1.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(12, 213)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 4
        Me.ButtonStart.Text = "Leaching..."
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(393, 213)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 5
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'File1
        '
        Me.File1.Location = New System.Drawing.Point(114, 27)
        Me.File1.Name = "File1"
        Me.File1.Size = New System.Drawing.Size(303, 20)
        Me.File1.TabIndex = 6
        '
        'File2
        '
        Me.File2.Location = New System.Drawing.Point(114, 66)
        Me.File2.Name = "File2"
        Me.File2.Size = New System.Drawing.Size(303, 20)
        Me.File2.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(111, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Original file"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(111, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Where suck"
        '
        'ButtonOpen2
        '
        Me.ButtonOpen2.Location = New System.Drawing.Point(422, 63)
        Me.ButtonOpen2.Name = "ButtonOpen2"
        Me.ButtonOpen2.Size = New System.Drawing.Size(45, 23)
        Me.ButtonOpen2.TabIndex = 10
        Me.ButtonOpen2.Text = "Select"
        Me.ButtonOpen2.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 242)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(455, 23)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 11
        '
        'ButtonChkAll
        '
        Me.ButtonChkAll.Location = New System.Drawing.Point(393, 149)
        Me.ButtonChkAll.Name = "ButtonChkAll"
        Me.ButtonChkAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonChkAll.TabIndex = 12
        Me.ButtonChkAll.Text = "Checked All"
        Me.ButtonChkAll.UseVisualStyleBackColor = True
        '
        'ButtonDeChkAll
        '
        Me.ButtonDeChkAll.Location = New System.Drawing.Point(393, 177)
        Me.ButtonDeChkAll.Name = "ButtonDeChkAll"
        Me.ButtonDeChkAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDeChkAll.TabIndex = 13
        Me.ButtonDeChkAll.Text = "Deselect All"
        Me.ButtonDeChkAll.UseVisualStyleBackColor = True
        '
        'ButtonImportList
        '
        Me.ButtonImportList.Location = New System.Drawing.Point(392, 97)
        Me.ButtonImportList.Name = "ButtonImportList"
        Me.ButtonImportList.Size = New System.Drawing.Size(75, 23)
        Me.ButtonImportList.TabIndex = 14
        Me.ButtonImportList.Text = "Import List"
        Me.ButtonImportList.UseVisualStyleBackColor = True
        '
        'NpcParam
        '
        Me.NpcParam.FormattingEnabled = True
        Me.NpcParam.Location = New System.Drawing.Point(114, 97)
        Me.NpcParam.Name = "NpcParam"
        Me.NpcParam.Size = New System.Drawing.Size(273, 139)
        Me.NpcParam.TabIndex = 2
        '
        'SrcSkillgrpButton
        '
        Me.SrcSkillgrpButton.AutoSize = True
        Me.SrcSkillgrpButton.Location = New System.Drawing.Point(105, 271)
        Me.SrcSkillgrpButton.Name = "SrcSkillgrpButton"
        Me.SrcSkillgrpButton.Size = New System.Drawing.Size(108, 17)
        Me.SrcSkillgrpButton.TabIndex = 17
        Me.SrcSkillgrpButton.TabStop = True
        Me.SrcSkillgrpButton.Text = "Source is SkillGrp"
        Me.ToolTip.SetToolTip(Me.SrcSkillgrpButton, "Use this for correct transferring" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "mana use params (mp_consume).")
        Me.SrcSkillgrpButton.UseVisualStyleBackColor = True
        '
        'SrcSkilldataEButton
        '
        Me.SrcSkilldataEButton.AutoSize = True
        Me.SrcSkilldataEButton.Location = New System.Drawing.Point(219, 271)
        Me.SrcSkilldataEButton.Name = "SrcSkilldataEButton"
        Me.SrcSkilldataEButton.Size = New System.Drawing.Size(123, 17)
        Me.SrcSkilldataEButton.TabIndex = 18
        Me.SrcSkilldataEButton.TabStop = True
        Me.SrcSkilldataEButton.Text = "Source is SkillData-e"
        Me.ToolTip.SetToolTip(Me.SrcSkilldataEButton, "Use it only for correct transferring" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "full skill names from skilldata-e.")
        Me.SrcSkilldataEButton.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(12, 271)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(87, 17)
        Me.RadioButton1.TabIndex = 19
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Normal mode"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'ScriptLeecher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 298)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.SrcSkilldataEButton)
        Me.Controls.Add(Me.SrcSkillgrpButton)
        Me.Controls.Add(Me.ButtonImportList)
        Me.Controls.Add(Me.ButtonDeChkAll)
        Me.Controls.Add(Me.ButtonChkAll)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonOpen2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.File2)
        Me.Controls.Add(Me.File1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.ButtonOpen1)
        Me.Controls.Add(Me.NpcParam)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScriptLeecher"
        Me.Text = "Lineage II Script C4 Data Leecher"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonOpen1 As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents File1 As System.Windows.Forms.TextBox
    Friend WithEvents File2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonOpen2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonChkAll As System.Windows.Forms.Button
    Friend WithEvents ButtonDeChkAll As System.Windows.Forms.Button
    Friend WithEvents ButtonImportList As System.Windows.Forms.Button
    Friend WithEvents NpcParam As System.Windows.Forms.CheckedListBox
    Friend WithEvents SrcSkillgrpButton As System.Windows.Forms.RadioButton
    Friend WithEvents SrcSkilldataEButton As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton

End Class

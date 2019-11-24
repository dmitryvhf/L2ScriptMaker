<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcDropItemChecker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcDropItemChecker))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ItemChanceRateTextBox = New System.Windows.Forms.TextBox()
        Me.AdenaSkipCheckBox = New System.Windows.Forms.CheckBox()
        Me.StopOnErrorCheckBox = New System.Windows.Forms.CheckBox()
        Me.ClearBadParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckBoxIgnoreSpoil = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(109, 160)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(130, 178)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(86, 23)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "<=100% check"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(243, 178)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(86, 23)
        Me.QuitButton.TabIndex = 2
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 209)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(351, 22)
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(300, 16)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(240, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "(support all scripts)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(127, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(179, 16)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Npcdata Drop Checker Tool"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(127, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Item Chance Rate:"
        '
        'ItemChanceRateTextBox
        '
        Me.ItemChanceRateTextBox.Location = New System.Drawing.Point(130, 57)
        Me.ItemChanceRateTextBox.Name = "ItemChanceRateTextBox"
        Me.ItemChanceRateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ItemChanceRateTextBox.TabIndex = 54
        Me.ItemChanceRateTextBox.Text = "1"
        '
        'AdenaSkipCheckBox
        '
        Me.AdenaSkipCheckBox.AutoSize = True
        Me.AdenaSkipCheckBox.Checked = True
        Me.AdenaSkipCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AdenaSkipCheckBox.Location = New System.Drawing.Point(130, 83)
        Me.AdenaSkipCheckBox.Name = "AdenaSkipCheckBox"
        Me.AdenaSkipCheckBox.Size = New System.Drawing.Size(131, 17)
        Me.AdenaSkipCheckBox.TabIndex = 55
        Me.AdenaSkipCheckBox.Text = "Ignore [adena] for rate"
        Me.AdenaSkipCheckBox.UseVisualStyleBackColor = True
        '
        'StopOnErrorCheckBox
        '
        Me.StopOnErrorCheckBox.AutoSize = True
        Me.StopOnErrorCheckBox.Location = New System.Drawing.Point(130, 142)
        Me.StopOnErrorCheckBox.Name = "StopOnErrorCheckBox"
        Me.StopOnErrorCheckBox.Size = New System.Drawing.Size(183, 30)
        Me.StopOnErrorCheckBox.TabIndex = 56
        Me.StopOnErrorCheckBox.Text = "stop on Parsing Error" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(or write error to file and continue)"
        Me.StopOnErrorCheckBox.UseVisualStyleBackColor = True
        '
        'ClearBadParamCheckBox
        '
        Me.ClearBadParamCheckBox.AutoSize = True
        Me.ClearBadParamCheckBox.Location = New System.Drawing.Point(130, 106)
        Me.ClearBadParamCheckBox.Name = "ClearBadParamCheckBox"
        Me.ClearBadParamCheckBox.Size = New System.Drawing.Size(160, 30)
        Me.ClearBadParamCheckBox.TabIndex = 57
        Me.ClearBadParamCheckBox.Text = "Clear bad param (spoil, drop)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Write to file and Continue"
        Me.ClearBadParamCheckBox.UseVisualStyleBackColor = True
        '
        'CheckBoxIgnoreSpoil
        '
        Me.CheckBoxIgnoreSpoil.AutoSize = True
        Me.CheckBoxIgnoreSpoil.Location = New System.Drawing.Point(267, 83)
        Me.CheckBoxIgnoreSpoil.Name = "CheckBoxIgnoreSpoil"
        Me.CheckBoxIgnoreSpoil.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxIgnoreSpoil.TabIndex = 58
        Me.CheckBoxIgnoreSpoil.Text = "Ignore Spoil"
        Me.CheckBoxIgnoreSpoil.UseVisualStyleBackColor = True
        '
        'NpcDropItemChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 231)
        Me.Controls.Add(Me.CheckBoxIgnoreSpoil)
        Me.Controls.Add(Me.ClearBadParamCheckBox)
        Me.Controls.Add(Me.StopOnErrorCheckBox)
        Me.Controls.Add(Me.AdenaSkipCheckBox)
        Me.Controls.Add(Me.ItemChanceRateTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcDropItemChecker"
        Me.Text = "NpcDropItemChecker"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ItemChanceRateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdenaSkipCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StopOnErrorCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ClearBadParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxIgnoreSpoil As System.Windows.Forms.CheckBox
End Class

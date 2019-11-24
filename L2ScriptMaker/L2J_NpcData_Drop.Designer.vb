<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class L2J_NpcData_Drop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(L2J_NpcData_Drop))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonQuit = New System.Windows.Forms.Button()
        Me.ButtonStartL2JPTS = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonStartPTSL2J = New System.Windows.Forms.Button()
        Me.ButtonDropChanceUpdate = New System.Windows.Forms.Button()
        Me.TextBoxRateAdena = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxRateSealstones = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxRateSpoil = New System.Windows.Forms.TextBox()
        Me.TextBoxRateHerb = New System.Windows.Forms.TextBox()
        Me.TextBoxRateDrop = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonRateChanceOnly = New System.Windows.Forms.RadioButton()
        Me.CheckBoxSpecNpcList = New System.Windows.Forms.CheckBox()
        Me.RadioButtonIgnoreDropNpc = New System.Windows.Forms.RadioButton()
        Me.TextBoxRateDropRB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.StatusStrip.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(159, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 32)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "NpcDrop Generator" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "L2J and PTS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(32, 193)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 64
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ButtonStartL2JPTS
        '
        Me.ButtonStartL2JPTS.Location = New System.Drawing.Point(147, 36)
        Me.ButtonStartL2JPTS.Name = "ButtonStartL2JPTS"
        Me.ButtonStartL2JPTS.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStartL2JPTS.TabIndex = 63
        Me.ButtonStartL2JPTS.Text = "L2J->PTS"
        Me.ButtonStartL2JPTS.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 226)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(333, 22)
        Me.StatusStrip.TabIndex = 66
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(200, 16)
        Me.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(107, 157)
        Me.PictureBox1.TabIndex = 65
        Me.PictureBox1.TabStop = False
        '
        'ButtonStartPTSL2J
        '
        Me.ButtonStartPTSL2J.Location = New System.Drawing.Point(228, 36)
        Me.ButtonStartPTSL2J.Name = "ButtonStartPTSL2J"
        Me.ButtonStartPTSL2J.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStartPTSL2J.TabIndex = 68
        Me.ButtonStartPTSL2J.Text = "PTS->L2J"
        Me.ButtonStartPTSL2J.UseVisualStyleBackColor = True
        '
        'ButtonDropChanceUpdate
        '
        Me.ButtonDropChanceUpdate.Location = New System.Drawing.Point(32, 164)
        Me.ButtonDropChanceUpdate.Name = "ButtonDropChanceUpdate"
        Me.ButtonDropChanceUpdate.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDropChanceUpdate.TabIndex = 69
        Me.ButtonDropChanceUpdate.Text = "DropRate"
        Me.ButtonDropChanceUpdate.UseVisualStyleBackColor = True
        '
        'TextBoxRateAdena
        '
        Me.TextBoxRateAdena.Location = New System.Drawing.Point(47, 16)
        Me.TextBoxRateAdena.Name = "TextBoxRateAdena"
        Me.TextBoxRateAdena.Size = New System.Drawing.Size(43, 20)
        Me.TextBoxRateAdena.TabIndex = 70
        Me.TextBoxRateAdena.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Adena"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 26)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Seal" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stones"
        '
        'TextBoxRateSealstones
        '
        Me.TextBoxRateSealstones.Location = New System.Drawing.Point(142, 16)
        Me.TextBoxRateSealstones.Name = "TextBoxRateSealstones"
        Me.TextBoxRateSealstones.Size = New System.Drawing.Size(43, 20)
        Me.TextBoxRateSealstones.TabIndex = 72
        Me.TextBoxRateSealstones.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Drop"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Herb"
        '
        'TextBoxRateSpoil
        '
        Me.TextBoxRateSpoil.Location = New System.Drawing.Point(47, 68)
        Me.TextBoxRateSpoil.Name = "TextBoxRateSpoil"
        Me.TextBoxRateSpoil.Size = New System.Drawing.Size(43, 20)
        Me.TextBoxRateSpoil.TabIndex = 74
        Me.TextBoxRateSpoil.Text = "1"
        '
        'TextBoxRateHerb
        '
        Me.TextBoxRateHerb.Location = New System.Drawing.Point(142, 68)
        Me.TextBoxRateHerb.Name = "TextBoxRateHerb"
        Me.TextBoxRateHerb.Size = New System.Drawing.Size(43, 20)
        Me.TextBoxRateHerb.TabIndex = 76
        Me.TextBoxRateHerb.Text = "1"
        '
        'TextBoxRateDrop
        '
        Me.TextBoxRateDrop.Location = New System.Drawing.Point(47, 42)
        Me.TextBoxRateDrop.Name = "TextBoxRateDrop"
        Me.TextBoxRateDrop.Size = New System.Drawing.Size(43, 20)
        Me.TextBoxRateDrop.TabIndex = 78
        Me.TextBoxRateDrop.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Spoil"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxRateDropRB)
        Me.GroupBox1.Controls.Add(Me.RadioButtonRateChanceOnly)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.CheckBoxSpecNpcList)
        Me.GroupBox1.Controls.Add(Me.RadioButtonIgnoreDropNpc)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBoxRateDrop)
        Me.GroupBox1.Controls.Add(Me.TextBoxRateHerb)
        Me.GroupBox1.Controls.Add(Me.TextBoxRateAdena)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBoxRateSpoil)
        Me.GroupBox1.Controls.Add(Me.TextBoxRateSealstones)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(125, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 151)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rate Options"
        '
        'RadioButtonRateChanceOnly
        '
        Me.RadioButtonRateChanceOnly.AutoSize = True
        Me.RadioButtonRateChanceOnly.Location = New System.Drawing.Point(9, 129)
        Me.RadioButtonRateChanceOnly.Name = "RadioButtonRateChanceOnly"
        Me.RadioButtonRateChanceOnly.Size = New System.Drawing.Size(184, 17)
        Me.RadioButtonRateChanceOnly.TabIndex = 83
        Me.RadioButtonRateChanceOnly.Text = "Rate Chance only for npc from list"
        Me.RadioButtonRateChanceOnly.UseVisualStyleBackColor = True
        '
        'CheckBoxSpecNpcList
        '
        Me.CheckBoxSpecNpcList.AutoSize = True
        Me.CheckBoxSpecNpcList.Checked = True
        Me.CheckBoxSpecNpcList.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSpecNpcList.Location = New System.Drawing.Point(9, 94)
        Me.CheckBoxSpecNpcList.Name = "CheckBoxSpecNpcList"
        Me.CheckBoxSpecNpcList.Size = New System.Drawing.Size(123, 17)
        Me.CheckBoxSpecNpcList.TabIndex = 81
        Me.CheckBoxSpecNpcList.Text = "Use special Npc List"
        Me.CheckBoxSpecNpcList.UseVisualStyleBackColor = True
        '
        'RadioButtonIgnoreDropNpc
        '
        Me.RadioButtonIgnoreDropNpc.AutoSize = True
        Me.RadioButtonIgnoreDropNpc.Checked = True
        Me.RadioButtonIgnoreDropNpc.Location = New System.Drawing.Point(9, 111)
        Me.RadioButtonIgnoreDropNpc.Name = "RadioButtonIgnoreDropNpc"
        Me.RadioButtonIgnoreDropNpc.Size = New System.Drawing.Size(186, 17)
        Me.RadioButtonIgnoreDropNpc.TabIndex = 82
        Me.RadioButtonIgnoreDropNpc.TabStop = True
        Me.RadioButtonIgnoreDropNpc.Text = "Ignore drop modify for npc from list"
        Me.RadioButtonIgnoreDropNpc.UseVisualStyleBackColor = True
        '
        'TextBoxRateDropRB
        '
        Me.TextBoxRateDropRB.Enabled = False
        Me.TextBoxRateDropRB.Location = New System.Drawing.Point(142, 42)
        Me.TextBoxRateDropRB.Name = "TextBoxRateDropRB"
        Me.TextBoxRateDropRB.Size = New System.Drawing.Size(43, 20)
        Me.TextBoxRateDropRB.TabIndex = 85
        Me.TextBoxRateDropRB.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(96, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Drop RB"
        '
        'L2J_NpcData_Drop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 248)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonDropChanceUpdate)
        Me.Controls.Add(Me.ButtonStartPTSL2J)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStartL2JPTS)
        Me.Controls.Add(Me.StatusStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "L2J_NpcData_Drop"
        Me.Text = "L2J_NpcData_Drop"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ButtonStartL2JPTS As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonStartPTSL2J As System.Windows.Forms.Button
    Friend WithEvents ButtonDropChanceUpdate As System.Windows.Forms.Button
    Friend WithEvents TextBoxRateAdena As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRateSealstones As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRateSpoil As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxRateHerb As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxRateDrop As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonRateChanceOnly As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxSpecNpcList As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButtonIgnoreDropNpc As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxRateDropRB As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class

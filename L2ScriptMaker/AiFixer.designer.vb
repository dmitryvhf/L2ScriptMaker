<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AiFixer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AiFixer))
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.ComboBoxFixType = New System.Windows.Forms.ComboBox
        Me.LogOverwriteCheckBox = New System.Windows.Forms.CheckBox
        Me.IncQuestTextBox = New System.Windows.Forms.TextBox
        Me.IncreaseQuestListButton = New System.Windows.Forms.Button
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.CheckBoxIgnoreAlredy = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(134, 151)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 1
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(116, 155)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(134, 39)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 5
        Me.ButtonStart.Text = "Fix"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ComboBoxFixType
        '
        Me.ComboBoxFixType.FormattingEnabled = True
        Me.ComboBoxFixType.Items.AddRange(New Object() {"func_call", "push_event", "fetch_i", "handler"})
        Me.ComboBoxFixType.Location = New System.Drawing.Point(134, 12)
        Me.ComboBoxFixType.Name = "ComboBoxFixType"
        Me.ComboBoxFixType.Size = New System.Drawing.Size(144, 21)
        Me.ComboBoxFixType.TabIndex = 6
        '
        'LogOverwriteCheckBox
        '
        Me.LogOverwriteCheckBox.AutoSize = True
        Me.LogOverwriteCheckBox.Location = New System.Drawing.Point(215, 39)
        Me.LogOverwriteCheckBox.Name = "LogOverwriteCheckBox"
        Me.LogOverwriteCheckBox.Size = New System.Drawing.Size(63, 30)
        Me.LogOverwriteCheckBox.TabIndex = 7
        Me.LogOverwriteCheckBox.Text = "Append" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Log"
        Me.LogOverwriteCheckBox.UseVisualStyleBackColor = True
        '
        'IncQuestTextBox
        '
        Me.IncQuestTextBox.Location = New System.Drawing.Point(134, 79)
        Me.IncQuestTextBox.Name = "IncQuestTextBox"
        Me.IncQuestTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IncQuestTextBox.TabIndex = 8
        Me.IncQuestTextBox.Text = "9"
        '
        'IncreaseQuestListButton
        '
        Me.IncreaseQuestListButton.Location = New System.Drawing.Point(134, 105)
        Me.IncreaseQuestListButton.Name = "IncreaseQuestListButton"
        Me.IncreaseQuestListButton.Size = New System.Drawing.Size(111, 23)
        Me.IncreaseQuestListButton.TabIndex = 9
        Me.IncreaseQuestListButton.Text = "Increase Quest List"
        Me.IncreaseQuestListButton.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 177)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(287, 22)
        Me.StatusStrip.TabIndex = 10
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(250, 16)
        '
        'CheckBoxIgnoreAlredy
        '
        Me.CheckBoxIgnoreAlredy.AutoSize = True
        Me.CheckBoxIgnoreAlredy.Checked = True
        Me.CheckBoxIgnoreAlredy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxIgnoreAlredy.Location = New System.Drawing.Point(134, 134)
        Me.CheckBoxIgnoreAlredy.Name = "CheckBoxIgnoreAlredy"
        Me.CheckBoxIgnoreAlredy.Size = New System.Drawing.Size(123, 17)
        Me.CheckBoxIgnoreAlredy.TabIndex = 11
        Me.CheckBoxIgnoreAlredy.Text = "Ignore If already >30"
        Me.CheckBoxIgnoreAlredy.UseVisualStyleBackColor = True
        '
        'AiFixer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 199)
        Me.Controls.Add(Me.CheckBoxIgnoreAlredy)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.IncreaseQuestListButton)
        Me.Controls.Add(Me.IncQuestTextBox)
        Me.Controls.Add(Me.LogOverwriteCheckBox)
        Me.Controls.Add(Me.ComboBoxFixType)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AiFixer"
        Me.Text = "Ai.obj Fixer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ComboBoxFixType As System.Windows.Forms.ComboBox
    Friend WithEvents LogOverwriteCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IncQuestTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IncreaseQuestListButton As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents CheckBoxIgnoreAlredy As System.Windows.Forms.CheckBox

End Class

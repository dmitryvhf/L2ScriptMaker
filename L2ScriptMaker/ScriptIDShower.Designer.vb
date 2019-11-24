<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptIDShower
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptIDShower))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.QuitButton = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ShortResultsCheckBox = New System.Windows.Forms.CheckBox
        Me.FindAsIsCheckBox = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ClearBeforeCheckBox = New System.Windows.Forms.CheckBox
        Me.FileComboBox = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PchTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ResultsTextBox = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 158)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(27, 212)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 2
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(126, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(426, 223)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ShortResultsCheckBox)
        Me.TabPage1.Controls.Add(Me.FindAsIsCheckBox)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.ClearBeforeCheckBox)
        Me.TabPage1.Controls.Add(Me.FileComboBox)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.PchTextBox)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.NameTextBox)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.IDTextBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(418, 197)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Search and Results"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ShortResultsCheckBox
        '
        Me.ShortResultsCheckBox.AutoSize = True
        Me.ShortResultsCheckBox.Checked = True
        Me.ShortResultsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShortResultsCheckBox.Location = New System.Drawing.Point(237, 53)
        Me.ShortResultsCheckBox.Name = "ShortResultsCheckBox"
        Me.ShortResultsCheckBox.Size = New System.Drawing.Size(108, 17)
        Me.ShortResultsCheckBox.TabIndex = 9
        Me.ShortResultsCheckBox.Text = "Short result mode"
        Me.ShortResultsCheckBox.UseVisualStyleBackColor = True
        '
        'FindAsIsCheckBox
        '
        Me.FindAsIsCheckBox.AutoSize = True
        Me.FindAsIsCheckBox.Location = New System.Drawing.Point(237, 29)
        Me.FindAsIsCheckBox.Name = "FindAsIsCheckBox"
        Me.FindAsIsCheckBox.Size = New System.Drawing.Size(155, 17)
        Me.FindAsIsCheckBox.TabIndex = 8
        Me.FindAsIsCheckBox.Text = "Find As-Is (lower-high case)"
        Me.FindAsIsCheckBox.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Working file:"
        '
        'ClearBeforeCheckBox
        '
        Me.ClearBeforeCheckBox.AutoSize = True
        Me.ClearBeforeCheckBox.Checked = True
        Me.ClearBeforeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ClearBeforeCheckBox.Location = New System.Drawing.Point(237, 6)
        Me.ClearBeforeCheckBox.Name = "ClearBeforeCheckBox"
        Me.ClearBeforeCheckBox.Size = New System.Drawing.Size(172, 17)
        Me.ClearBeforeCheckBox.TabIndex = 6
        Me.ClearBeforeCheckBox.Text = "Clear before output new results"
        Me.ClearBeforeCheckBox.UseVisualStyleBackColor = True
        '
        'FileComboBox
        '
        Me.FileComboBox.FormattingEnabled = True
        Me.FileComboBox.Items.AddRange(New Object() {"itemname-e.txt", "npcname-e.txt", "skillname-e.txt", "huntingzone-e.txt", "staticobject-e.txt", "sysstring-e.txt"})
        Me.FileComboBox.Location = New System.Drawing.Point(6, 20)
        Me.FileComboBox.Name = "FileComboBox"
        Me.FileComboBox.Size = New System.Drawing.Size(100, 21)
        Me.FileComboBox.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Pch ID:"
        '
        'PchTextBox
        '
        Me.PchTextBox.Enabled = False
        Me.PchTextBox.Location = New System.Drawing.Point(6, 138)
        Me.PchTextBox.Name = "PchTextBox"
        Me.PchTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PchTextBox.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Name:"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(6, 99)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.NameTextBox.Size = New System.Drawing.Size(403, 20)
        Me.NameTextBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID:"
        '
        'IDTextBox
        '
        Me.IDTextBox.Location = New System.Drawing.Point(6, 60)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IDTextBox.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ResultsTextBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(418, 197)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Results"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ResultsTextBox
        '
        Me.ResultsTextBox.Location = New System.Drawing.Point(6, 6)
        Me.ResultsTextBox.Multiline = True
        Me.ResultsTextBox.Name = "ResultsTextBox"
        Me.ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ResultsTextBox.Size = New System.Drawing.Size(406, 185)
        Me.ResultsTextBox.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 240)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(556, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(400, 16)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(600, 16)
        '
        'ScriptIDShower
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 262)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScriptIDShower"
        Me.Text = "Lineage II ID-Name shower"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents FileComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PchTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ResultsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ClearBeforeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FindAsIsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ShortResultsCheckBox As System.Windows.Forms.CheckBox
End Class

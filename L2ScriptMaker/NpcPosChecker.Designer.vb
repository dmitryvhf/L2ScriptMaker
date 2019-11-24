<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcPosChecker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcPosChecker))
        Me.QuitButton = New System.Windows.Forms.Button
        Me.StartButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.MakerNameButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.AiPrivatesButton = New System.Windows.Forms.Button
        Me.DBNameButton = New System.Windows.Forms.Button
        Me.QuotButton = New System.Windows.Forms.Button
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.OutsiderButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.OutsiderOffsetTextBox = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(23, 198)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 4
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(125, 41)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(126, 35)
        Me.StartButton.TabIndex = 2
        Me.StartButton.Text = "NpcPos Privates Checker"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(138, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "(support C4 scripts)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(138, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 16)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Npcpos Checker"
        '
        'MakerNameButton
        '
        Me.MakerNameButton.Location = New System.Drawing.Point(125, 111)
        Me.MakerNameButton.Name = "MakerNameButton"
        Me.MakerNameButton.Size = New System.Drawing.Size(126, 23)
        Me.MakerNameButton.TabIndex = 49
        Me.MakerNameButton.Text = "MakerName Checker"
        Me.MakerNameButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(6, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 160)
        Me.PictureBox1.TabIndex = 50
        Me.PictureBox1.TabStop = False
        '
        'AiPrivatesButton
        '
        Me.AiPrivatesButton.Location = New System.Drawing.Point(125, 82)
        Me.AiPrivatesButton.Name = "AiPrivatesButton"
        Me.AiPrivatesButton.Size = New System.Drawing.Size(126, 23)
        Me.AiPrivatesButton.TabIndex = 51
        Me.AiPrivatesButton.Text = "AI.obj Privates Checker"
        Me.AiPrivatesButton.UseVisualStyleBackColor = True
        '
        'DBNameButton
        '
        Me.DBNameButton.Location = New System.Drawing.Point(125, 140)
        Me.DBNameButton.Name = "DBNameButton"
        Me.DBNameButton.Size = New System.Drawing.Size(126, 23)
        Me.DBNameButton.TabIndex = 52
        Me.DBNameButton.Text = "DBName Checker"
        Me.DBNameButton.UseVisualStyleBackColor = True
        '
        'QuotButton
        '
        Me.QuotButton.Location = New System.Drawing.Point(125, 169)
        Me.QuotButton.Name = "QuotButton"
        Me.QuotButton.Size = New System.Drawing.Size(126, 23)
        Me.QuotButton.TabIndex = 53
        Me.QuotButton.Text = "Quot Checker"
        Me.QuotButton.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 251)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(259, 22)
        Me.StatusStrip.TabIndex = 54
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(240, 16)
        '
        'OutsiderButton
        '
        Me.OutsiderButton.Location = New System.Drawing.Point(125, 198)
        Me.OutsiderButton.Name = "OutsiderButton"
        Me.OutsiderButton.Size = New System.Drawing.Size(126, 23)
        Me.OutsiderButton.TabIndex = 55
        Me.OutsiderButton.Text = "Outsider Checker"
        Me.OutsiderButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(126, 227)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Outsider grow:"
        '
        'OutsiderOffsetTextBox
        '
        Me.OutsiderOffsetTextBox.Location = New System.Drawing.Point(207, 224)
        Me.OutsiderOffsetTextBox.Name = "OutsiderOffsetTextBox"
        Me.OutsiderOffsetTextBox.Size = New System.Drawing.Size(40, 20)
        Me.OutsiderOffsetTextBox.TabIndex = 57
        Me.OutsiderOffsetTextBox.Text = "300"
        '
        'NpcPosChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 273)
        Me.Controls.Add(Me.OutsiderOffsetTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OutsiderButton)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.QuotButton)
        Me.Controls.Add(Me.DBNameButton)
        Me.Controls.Add(Me.AiPrivatesButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MakerNameButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcPosChecker"
        Me.Text = "NpcPos Checker"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MakerNameButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents AiPrivatesButton As System.Windows.Forms.Button
    Friend WithEvents DBNameButton As System.Windows.Forms.Button
    Friend WithEvents QuotButton As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OutsiderButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OutsiderOffsetTextBox As System.Windows.Forms.TextBox
End Class

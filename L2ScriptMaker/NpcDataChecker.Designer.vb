<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcDataChecker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcDataChecker))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.NoWarriorCheckBox = New System.Windows.Forms.CheckBox()
        Me.NoWarriorUndCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckBoxZzoldagu74 = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 159)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(404, 60)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "Scanning..."
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(404, 89)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 2
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 178)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(494, 22)
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(300, 16)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(366, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "(support all Chronicles)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(300, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 16)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "NpcData Analyser and Fixer"
        '
        'CheckedListBox
        '
        Me.CheckedListBox.FormattingEnabled = True
        Me.CheckedListBox.Items.AddRange(New Object() {"acquire_exp_rate, acquire_sp", "unsowing", "slot_rhand, base_attack_type", "agro_range", "no_sleep_mode", "undying, can_be_attacked", "npc active skill", "castle bowguard range", "npc race", "stats (str,int,dex,wit,con,men)"})
        Me.CheckedListBox.Location = New System.Drawing.Point(128, 12)
        Me.CheckedListBox.Name = "CheckedListBox"
        Me.CheckedListBox.Size = New System.Drawing.Size(169, 154)
        Me.CheckedListBox.TabIndex = 56
        '
        'NoWarriorCheckBox
        '
        Me.NoWarriorCheckBox.AutoSize = True
        Me.NoWarriorCheckBox.Location = New System.Drawing.Point(303, 60)
        Me.NoWarriorCheckBox.Name = "NoWarriorCheckBox"
        Me.NoWarriorCheckBox.Size = New System.Drawing.Size(96, 17)
        Me.NoWarriorCheckBox.TabIndex = 58
        Me.NoWarriorCheckBox.Text = "except 'warrior'"
        Me.NoWarriorCheckBox.UseVisualStyleBackColor = True
        '
        'NoWarriorUndCheckBox
        '
        Me.NoWarriorUndCheckBox.AutoSize = True
        Me.NoWarriorUndCheckBox.Location = New System.Drawing.Point(303, 120)
        Me.NoWarriorUndCheckBox.Name = "NoWarriorUndCheckBox"
        Me.NoWarriorUndCheckBox.Size = New System.Drawing.Size(96, 17)
        Me.NoWarriorUndCheckBox.TabIndex = 59
        Me.NoWarriorUndCheckBox.Text = "except 'warrior'"
        Me.NoWarriorUndCheckBox.UseVisualStyleBackColor = True
        '
        'CheckBoxZzoldagu74
        '
        Me.CheckBoxZzoldagu74.AutoSize = True
        Me.CheckBoxZzoldagu74.Location = New System.Drawing.Point(304, 148)
        Me.CheckBoxZzoldagu74.Name = "CheckBoxZzoldagu74"
        Me.CheckBoxZzoldagu74.Size = New System.Drawing.Size(133, 17)
        Me.CheckBoxZzoldagu74.TabIndex = 60
        Me.CheckBoxZzoldagu74.Text = "Zzoldagu74+ like Boss"
        Me.CheckBoxZzoldagu74.UseVisualStyleBackColor = True
        '
        'NpcDataChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 200)
        Me.Controls.Add(Me.CheckBoxZzoldagu74)
        Me.Controls.Add(Me.NoWarriorUndCheckBox)
        Me.Controls.Add(Me.NoWarriorCheckBox)
        Me.Controls.Add(Me.CheckedListBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcDataChecker"
        Me.Text = "NpcDataChecker"
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
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents NoWarriorCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NoWarriorUndCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CheckBoxZzoldagu74 As System.Windows.Forms.CheckBox
End Class

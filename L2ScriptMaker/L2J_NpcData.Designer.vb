<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class L2J_NpcData
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
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonQuit = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ButtonExpSP = New System.Windows.Forms.Button()
        Me.CheckBoxFixStats = New System.Windows.Forms.CheckBox()
        Me.CheckBoxZzoldagu74 = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(206, 16)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "NpcData Generator from L2J file"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(200, 16)
        Me.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(107, 157)
        Me.PictureBox1.TabIndex = 70
        Me.PictureBox1.TabStop = False
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(128, 132)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 69
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(128, 32)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 68
        Me.ButtonStart.Text = "Generate..."
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 182)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(358, 22)
        Me.StatusStrip.TabIndex = 71
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ButtonExpSP
        '
        Me.ButtonExpSP.Location = New System.Drawing.Point(128, 103)
        Me.ButtonExpSP.Name = "ButtonExpSP"
        Me.ButtonExpSP.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExpSP.TabIndex = 73
        Me.ButtonExpSP.Text = "Exp/SP Fix"
        Me.ButtonExpSP.UseVisualStyleBackColor = True
        '
        'CheckBoxFixStats
        '
        Me.CheckBoxFixStats.AutoSize = True
        Me.CheckBoxFixStats.Location = New System.Drawing.Point(212, 36)
        Me.CheckBoxFixStats.Name = "CheckBoxFixStats"
        Me.CheckBoxFixStats.Size = New System.Drawing.Size(121, 17)
        Me.CheckBoxFixStats.TabIndex = 74
        Me.CheckBoxFixStats.Text = "Fix STATs (str,dex..)"
        Me.CheckBoxFixStats.UseVisualStyleBackColor = True
        '
        'CheckBoxZzoldagu74
        '
        Me.CheckBoxZzoldagu74.AutoSize = True
        Me.CheckBoxZzoldagu74.Location = New System.Drawing.Point(212, 59)
        Me.CheckBoxZzoldagu74.Name = "CheckBoxZzoldagu74"
        Me.CheckBoxZzoldagu74.Size = New System.Drawing.Size(136, 17)
        Me.CheckBoxZzoldagu74.TabIndex = 75
        Me.CheckBoxZzoldagu74.Text = "Zzoldagu 74+ like Boss"
        Me.CheckBoxZzoldagu74.UseVisualStyleBackColor = True
        '
        'L2J_NpcData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 204)
        Me.Controls.Add(Me.CheckBoxZzoldagu74)
        Me.Controls.Add(Me.CheckBoxFixStats)
        Me.Controls.Add(Me.ButtonExpSP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.StatusStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "L2J_NpcData"
        Me.Text = "L2J_NpcData"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ButtonExpSP As System.Windows.Forms.Button
    Friend WithEvents CheckBoxFixStats As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxZzoldagu74 As System.Windows.Forms.CheckBox
End Class

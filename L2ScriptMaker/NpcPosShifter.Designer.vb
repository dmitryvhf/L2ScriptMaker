<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcPosShifter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcPosShifter))
        Me.Label3 = New System.Windows.Forms.Label
        Me.ZShift = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.YShift = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.XShift = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(139, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Z-shifting"
        '
        'ZShift
        '
        Me.ZShift.Location = New System.Drawing.Point(139, 109)
        Me.ZShift.Name = "ZShift"
        Me.ZShift.Size = New System.Drawing.Size(100, 20)
        Me.ZShift.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(139, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Y-shifting"
        '
        'YShift
        '
        Me.YShift.Location = New System.Drawing.Point(139, 70)
        Me.YShift.Name = "YShift"
        Me.YShift.Size = New System.Drawing.Size(100, 20)
        Me.YShift.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(139, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "X-shifting"
        '
        'XShift
        '
        Me.XShift.Location = New System.Drawing.Point(139, 31)
        Me.XShift.Name = "XShift"
        Me.XShift.Size = New System.Drawing.Size(100, 20)
        Me.XShift.TabIndex = 14
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.Dragon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(90, 200)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 218)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(227, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 11
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(164, 147)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 10
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(164, 189)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 12
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'NpcPosShifter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(251, 256)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ZShift)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.YShift)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.XShift)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.ButtonQuit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcPosShifter"
        Me.Text = "NpcPosShifter"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ZShift As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents YShift As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents XShift As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class

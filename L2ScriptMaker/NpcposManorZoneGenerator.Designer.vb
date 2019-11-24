<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcposManorZoneGenerator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcposManorZoneGenerator))
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView = New System.Windows.Forms.DataGridView
        Me.LoadCastleControlButton = New System.Windows.Forms.Button
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.MetodCheckBox = New System.Windows.Forms.CheckBox
        Me.DoUnknownCheckBox = New System.Windows.Forms.CheckBox
        Me.SafeRangeTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LocX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LocY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CastleName = New System.Windows.Forms.DataGridViewComboBoxColumn
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(29, 228)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(29, 257)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 1
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(109, 160)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(139, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "(support C4 scripts and above)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(127, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 32)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Manor zones Generator" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for Npcpos.txt"
        '
        'DataGridView
        '
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LocX, Me.LocY, Me.CastleName})
        Me.DataGridView.Location = New System.Drawing.Point(130, 65)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.Size = New System.Drawing.Size(307, 157)
        Me.DataGridView.TabIndex = 55
        '
        'LoadCastleControlButton
        '
        Me.LoadCastleControlButton.Location = New System.Drawing.Point(29, 185)
        Me.LoadCastleControlButton.Name = "LoadCastleControlButton"
        Me.LoadCastleControlButton.Size = New System.Drawing.Size(75, 37)
        Me.LoadCastleControlButton.TabIndex = 56
        Me.LoadCastleControlButton.Text = "Load Castle Control"
        Me.LoadCastleControlButton.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 300)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(445, 22)
        Me.StatusStrip.TabIndex = 57
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(400, 16)
        '
        'MetodCheckBox
        '
        Me.MetodCheckBox.AutoSize = True
        Me.MetodCheckBox.Location = New System.Drawing.Point(142, 228)
        Me.MetodCheckBox.Name = "MetodCheckBox"
        Me.MetodCheckBox.Size = New System.Drawing.Size(221, 17)
        Me.MetodCheckBox.TabIndex = 58
        Me.MetodCheckBox.Text = "Use real spawn locations from Npcpos.txt"
        Me.MetodCheckBox.UseVisualStyleBackColor = True
        '
        'DoUnknownCheckBox
        '
        Me.DoUnknownCheckBox.AutoSize = True
        Me.DoUnknownCheckBox.Location = New System.Drawing.Point(142, 251)
        Me.DoUnknownCheckBox.Name = "DoUnknownCheckBox"
        Me.DoUnknownCheckBox.Size = New System.Drawing.Size(295, 17)
        Me.DoUnknownCheckBox.TabIndex = 59
        Me.DoUnknownCheckBox.Text = "Generate location without castle control like domain_id=0"
        Me.DoUnknownCheckBox.UseVisualStyleBackColor = True
        '
        'SafeRangeTextBox
        '
        Me.SafeRangeTextBox.Location = New System.Drawing.Point(263, 274)
        Me.SafeRangeTextBox.Name = "SafeRangeTextBox"
        Me.SafeRangeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SafeRangeTextBox.TabIndex = 60
        Me.SafeRangeTextBox.Text = "2000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(139, 277)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = """Safe"" range for territory:"
        '
        'LocX
        '
        Me.LocX.HeaderText = "LocX"
        Me.LocX.Name = "LocX"
        Me.LocX.Width = 50
        '
        'LocY
        '
        Me.LocY.HeaderText = "LocY"
        Me.LocY.Name = "LocY"
        Me.LocY.Width = 50
        '
        'CastleName
        '
        Me.CastleName.HeaderText = "Castle Control"
        Me.CastleName.Items.AddRange(New Object() {"Gludio", "Dion", "Giran", "Oren", "Aden", "Heine", "Goddard", "Rune", "Schuttgart", "Kamael"})
        Me.CastleName.Name = "CastleName"
        Me.CastleName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'NpcposManorZoneGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 322)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SafeRangeTextBox)
        Me.Controls.Add(Me.DoUnknownCheckBox)
        Me.Controls.Add(Me.MetodCheckBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.LoadCastleControlButton)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcposManorZoneGenerator"
        Me.Text = "Npcpos Manor zones Generator"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents LoadCastleControlButton As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MetodCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DoUnknownCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SafeRangeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LocX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CastleName As System.Windows.Forms.DataGridViewComboBoxColumn
End Class

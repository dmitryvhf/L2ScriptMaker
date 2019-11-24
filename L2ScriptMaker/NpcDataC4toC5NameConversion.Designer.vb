<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcC4toC5IdsConversion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcC4toC5IdsConversion))
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.C4TextBox = New System.Windows.Forms.TextBox
        Me.C6TextBox = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.InverseDirectionCheckBox = New System.Windows.Forms.CheckBox
        Me.ReloadButton = New System.Windows.Forms.Button
        Me.DisableCheckBox = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(278, 112)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Fix NpcData"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(278, 141)
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
        Me.PictureBox1.Size = New System.Drawing.Size(107, 159)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'C4TextBox
        '
        Me.C4TextBox.Location = New System.Drawing.Point(168, 57)
        Me.C4TextBox.Name = "C4TextBox"
        Me.C4TextBox.Size = New System.Drawing.Size(100, 20)
        Me.C4TextBox.TabIndex = 4
        '
        'C6TextBox
        '
        Me.C6TextBox.Location = New System.Drawing.Point(168, 83)
        Me.C6TextBox.Name = "C6TextBox"
        Me.C6TextBox.Size = New System.Drawing.Size(100, 20)
        Me.C6TextBox.TabIndex = 5
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 178)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(369, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(340, 16)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(125, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "(support C4 scripts)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(125, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(242, 16)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Npcdata C4 to C5 IDs Conversion Tool"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "C4 ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "C6 ID:"
        '
        'InverseDirectionCheckBox
        '
        Me.InverseDirectionCheckBox.AutoSize = True
        Me.InverseDirectionCheckBox.Location = New System.Drawing.Point(146, 118)
        Me.InverseDirectionCheckBox.Name = "InverseDirectionCheckBox"
        Me.InverseDirectionCheckBox.Size = New System.Drawing.Size(104, 17)
        Me.InverseDirectionCheckBox.TabIndex = 53
        Me.InverseDirectionCheckBox.Text = "Inverse direction"
        Me.InverseDirectionCheckBox.UseVisualStyleBackColor = True
        '
        'ReloadButton
        '
        Me.ReloadButton.Location = New System.Drawing.Point(278, 55)
        Me.ReloadButton.Name = "ReloadButton"
        Me.ReloadButton.Size = New System.Drawing.Size(75, 23)
        Me.ReloadButton.TabIndex = 54
        Me.ReloadButton.Text = "Reload IDs"
        Me.ReloadButton.UseVisualStyleBackColor = True
        '
        'DisableCheckBox
        '
        Me.DisableCheckBox.AutoSize = True
        Me.DisableCheckBox.Checked = True
        Me.DisableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DisableCheckBox.Location = New System.Drawing.Point(146, 141)
        Me.DisableCheckBox.Name = "DisableCheckBox"
        Me.DisableCheckBox.Size = New System.Drawing.Size(122, 17)
        Me.DisableCheckBox.TabIndex = 55
        Me.DisableCheckBox.Text = "Disable Unknown Id"
        Me.DisableCheckBox.UseVisualStyleBackColor = True
        '
        'NpcC4toC5IdsConversion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 200)
        Me.Controls.Add(Me.DisableCheckBox)
        Me.Controls.Add(Me.ReloadButton)
        Me.Controls.Add(Me.InverseDirectionCheckBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.C6TextBox)
        Me.Controls.Add(Me.C4TextBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcC4toC5IdsConversion"
        Me.Text = "Npcdata C4 to C5 Ids Conversion Tool"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents C4TextBox As System.Windows.Forms.TextBox
    Friend WithEvents C6TextBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents InverseDirectionCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ReloadButton As System.Windows.Forms.Button
    Friend WithEvents DisableCheckBox As System.Windows.Forms.CheckBox
End Class

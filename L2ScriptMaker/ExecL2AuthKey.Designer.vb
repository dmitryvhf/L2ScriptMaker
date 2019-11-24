<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExecL2AuthKey
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExecL2AuthKey))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonExit = New System.Windows.Forms.Button
        Me.LoadButton = New System.Windows.Forms.Button
        Me.KeyLoadBox = New System.Windows.Forms.TextBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.LoadKeyLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.NewKeyBox = New System.Windows.Forms.TextBox
        Me.CopyButton = New System.Windows.Forms.Button
        Me.LoadKeyHexBox = New System.Windows.Forms.TextBox
        Me.WriteButton = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(127, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "(support C4 scripts)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(127, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(245, 16)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Authentifycation Blowfish Change Key"
        '
        'ButtonExit
        '
        Me.ButtonExit.Location = New System.Drawing.Point(534, 139)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExit.TabIndex = 56
        Me.ButtonExit.Text = "Exit"
        '
        'LoadButton
        '
        Me.LoadButton.Location = New System.Drawing.Point(130, 57)
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Size = New System.Drawing.Size(124, 23)
        Me.LoadButton.TabIndex = 59
        Me.LoadButton.Text = "Load BlowFish Key"
        Me.LoadButton.UseVisualStyleBackColor = True
        '
        'KeyLoadBox
        '
        Me.KeyLoadBox.Location = New System.Drawing.Point(130, 86)
        Me.KeyLoadBox.Name = "KeyLoadBox"
        Me.KeyLoadBox.ReadOnly = True
        Me.KeyLoadBox.Size = New System.Drawing.Size(131, 20)
        Me.KeyLoadBox.TabIndex = 60
        '
        'LoadKeyLabel
        '
        Me.LoadKeyLabel.AutoSize = True
        Me.LoadKeyLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LoadKeyLabel.Location = New System.Drawing.Point(339, 62)
        Me.LoadKeyLabel.Name = "LoadKeyLabel"
        Me.LoadKeyLabel.Size = New System.Drawing.Size(13, 14)
        Me.LoadKeyLabel.TabIndex = 62
        Me.LoadKeyLabel.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(265, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 14)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Key length:"
        '
        'NewKeyBox
        '
        Me.NewKeyBox.Location = New System.Drawing.Point(130, 141)
        Me.NewKeyBox.Name = "NewKeyBox"
        Me.NewKeyBox.Size = New System.Drawing.Size(131, 20)
        Me.NewKeyBox.TabIndex = 63
        '
        'CopyButton
        '
        Me.CopyButton.Location = New System.Drawing.Point(130, 112)
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.Size = New System.Drawing.Size(75, 23)
        Me.CopyButton.TabIndex = 64
        Me.CopyButton.Text = "Copy key"
        Me.CopyButton.UseVisualStyleBackColor = True
        '
        'LoadKeyHexBox
        '
        Me.LoadKeyHexBox.Location = New System.Drawing.Point(267, 86)
        Me.LoadKeyHexBox.Name = "LoadKeyHexBox"
        Me.LoadKeyHexBox.ReadOnly = True
        Me.LoadKeyHexBox.Size = New System.Drawing.Size(342, 20)
        Me.LoadKeyHexBox.TabIndex = 65
        '
        'WriteButton
        '
        Me.WriteButton.Location = New System.Drawing.Point(391, 139)
        Me.WriteButton.Name = "WriteButton"
        Me.WriteButton.Size = New System.Drawing.Size(124, 23)
        Me.WriteButton.TabIndex = 66
        Me.WriteButton.Text = "Write BlowFish Key"
        Me.WriteButton.UseVisualStyleBackColor = True
        '
        'ExecL2AuthKey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 184)
        Me.Controls.Add(Me.WriteButton)
        Me.Controls.Add(Me.LoadKeyHexBox)
        Me.Controls.Add(Me.CopyButton)
        Me.Controls.Add(Me.NewKeyBox)
        Me.Controls.Add(Me.LoadKeyLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.KeyLoadBox)
        Me.Controls.Add(Me.LoadButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ExecL2AuthKey"
        Me.Text = "ExecL2AuthKey"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents LoadButton As System.Windows.Forms.Button
    Friend WithEvents KeyLoadBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LoadKeyLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NewKeyBox As System.Windows.Forms.TextBox
    Friend WithEvents CopyButton As System.Windows.Forms.Button
    Friend WithEvents LoadKeyHexBox As System.Windows.Forms.TextBox
    Friend WithEvents WriteButton As System.Windows.Forms.Button
End Class

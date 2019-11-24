<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AIMessageTeleportImporter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AIMessageTeleportImporter))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.ButtonExport = New System.Windows.Forms.Button
        Me.ButtonImport = New System.Windows.Forms.Button
        Me.ButtonAbout = New System.Windows.Forms.Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.AiFileBox = New System.Windows.Forms.TextBox
        Me.StatusText = New System.Windows.Forms.Label
        Me.AiImportBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 170)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(311, 159)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 6
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ButtonExport
        '
        Me.ButtonExport.Location = New System.Drawing.Point(129, 87)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExport.TabIndex = 5
        Me.ButtonExport.Text = "Export"
        Me.ButtonExport.UseVisualStyleBackColor = True
        '
        'ButtonImport
        '
        Me.ButtonImport.Location = New System.Drawing.Point(129, 116)
        Me.ButtonImport.Name = "ButtonImport"
        Me.ButtonImport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonImport.TabIndex = 4
        Me.ButtonImport.Text = "Import"
        Me.ButtonImport.UseVisualStyleBackColor = True
        '
        'ButtonAbout
        '
        Me.ButtonAbout.Location = New System.Drawing.Point(129, 160)
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAbout.TabIndex = 8
        Me.ButtonAbout.Text = "About"
        Me.ButtonAbout.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 208)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(374, 23)
        Me.ProgressBar.TabIndex = 9
        '
        'AiFileBox
        '
        Me.AiFileBox.Location = New System.Drawing.Point(129, 12)
        Me.AiFileBox.Name = "AiFileBox"
        Me.AiFileBox.ReadOnly = True
        Me.AiFileBox.Size = New System.Drawing.Size(257, 20)
        Me.AiFileBox.TabIndex = 10
        '
        'StatusText
        '
        Me.StatusText.AutoSize = True
        Me.StatusText.Location = New System.Drawing.Point(9, 192)
        Me.StatusText.Name = "StatusText"
        Me.StatusText.Size = New System.Drawing.Size(0, 13)
        Me.StatusText.TabIndex = 12
        '
        'AiImportBox
        '
        Me.AiImportBox.Location = New System.Drawing.Point(129, 38)
        Me.AiImportBox.Name = "AiImportBox"
        Me.AiImportBox.ReadOnly = True
        Me.AiImportBox.Size = New System.Drawing.Size(257, 20)
        Me.AiImportBox.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(289, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "(support C4 scripts)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(242, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 32)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Import/Export teleport" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "name in Ai.obj"
        '
        'AIMessageTeleportImporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 240)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AiImportBox)
        Me.Controls.Add(Me.StatusText)
        Me.Controls.Add(Me.AiFileBox)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonAbout)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonExport)
        Me.Controls.Add(Me.ButtonImport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AIMessageTeleportImporter"
        Me.Text = "Import/Export teleport name in Ai.obj"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ButtonExport As System.Windows.Forms.Button
    Friend WithEvents ButtonImport As System.Windows.Forms.Button
    Friend WithEvents ButtonAbout As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents AiFileBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusText As System.Windows.Forms.Label
    Friend WithEvents AiImportBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

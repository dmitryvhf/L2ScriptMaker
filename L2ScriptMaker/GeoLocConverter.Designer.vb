<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeoLocConverter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeoLocConverter))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.XTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.YTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GeonameXTextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.QuitButton = New System.Windows.Forms.Button
        Me.GeonameYTextBox = New System.Windows.Forms.TextBox
        Me.GeonameTextBox = New System.Windows.Forms.TextBox
        Me.ImportLocTextBox = New System.Windows.Forms.TextBox
        Me.ImportLocButton = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'XTextBox
        '
        Me.XTextBox.Location = New System.Drawing.Point(129, 107)
        Me.XTextBox.Name = "XTextBox"
        Me.XTextBox.Size = New System.Drawing.Size(100, 20)
        Me.XTextBox.TabIndex = 1
        Me.XTextBox.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(126, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(126, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Y"
        '
        'YTextBox
        '
        Me.YTextBox.Location = New System.Drawing.Point(129, 146)
        Me.YTextBox.Name = "YTextBox"
        Me.YTextBox.Size = New System.Drawing.Size(100, 20)
        Me.YTextBox.TabIndex = 3
        Me.YTextBox.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(126, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Geoname"
        '
        'GeonameXTextBox
        '
        Me.GeonameXTextBox.Location = New System.Drawing.Point(235, 107)
        Me.GeonameXTextBox.Name = "GeonameXTextBox"
        Me.GeonameXTextBox.ReadOnly = True
        Me.GeonameXTextBox.Size = New System.Drawing.Size(40, 20)
        Me.GeonameXTextBox.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(126, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "(support C4 scripts)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(126, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(194, 16)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Geoname finder from location"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(235, 183)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 51
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'GeonameYTextBox
        '
        Me.GeonameYTextBox.Location = New System.Drawing.Point(235, 146)
        Me.GeonameYTextBox.Name = "GeonameYTextBox"
        Me.GeonameYTextBox.ReadOnly = True
        Me.GeonameYTextBox.Size = New System.Drawing.Size(40, 20)
        Me.GeonameYTextBox.TabIndex = 52
        '
        'GeonameTextBox
        '
        Me.GeonameTextBox.Location = New System.Drawing.Point(129, 185)
        Me.GeonameTextBox.Name = "GeonameTextBox"
        Me.GeonameTextBox.ReadOnly = True
        Me.GeonameTextBox.Size = New System.Drawing.Size(69, 20)
        Me.GeonameTextBox.TabIndex = 53
        '
        'ImportLocTextBox
        '
        Me.ImportLocTextBox.Location = New System.Drawing.Point(129, 68)
        Me.ImportLocTextBox.Name = "ImportLocTextBox"
        Me.ImportLocTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ImportLocTextBox.TabIndex = 54
        Me.ImportLocTextBox.Text = "XXXX,YYY,ZZZZ"
        '
        'ImportLocButton
        '
        Me.ImportLocButton.Location = New System.Drawing.Point(235, 66)
        Me.ImportLocButton.Name = "ImportLocButton"
        Me.ImportLocButton.Size = New System.Drawing.Size(75, 23)
        Me.ImportLocButton.TabIndex = 55
        Me.ImportLocButton.Text = "Import"
        Me.ImportLocButton.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(126, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Import data"
        '
        'GeoLocConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 217)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ImportLocButton)
        Me.Controls.Add(Me.ImportLocTextBox)
        Me.Controls.Add(Me.GeonameTextBox)
        Me.Controls.Add(Me.GeonameYTextBox)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GeonameXTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.YTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.XTextBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GeoLocConverter"
        Me.Text = "Geodata: Geoname from Location"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents XTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents YTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GeonameXTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents GeonameYTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GeonameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ImportLocTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ImportLocButton As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class

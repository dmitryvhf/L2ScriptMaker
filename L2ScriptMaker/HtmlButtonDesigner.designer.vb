<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class HtmlButtonDesigner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HtmlButtonDesigner))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.AboutButton = New System.Windows.Forms.Button
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.WidthValue = New System.Windows.Forms.TextBox
        Me.HeightValue = New System.Windows.Forms.TextBox
        Me.BackValue = New System.Windows.Forms.TextBox
        Me.ForeValue = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.ScanFile = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.EndTag = New System.Windows.Forms.TextBox
        Me.StartTag = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(95, 196)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'AboutButton
        '
        Me.AboutButton.Location = New System.Drawing.Point(113, 185)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(75, 23)
        Me.AboutButton.TabIndex = 1
        Me.AboutButton.Text = "About"
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(194, 185)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 2
        Me.StartButton.Text = "Enchant!"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(302, 185)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 3
        Me.QuitButton.Text = "Quit"
        '
        'WidthValue
        '
        Me.WidthValue.Location = New System.Drawing.Point(153, 9)
        Me.WidthValue.Name = "WidthValue"
        Me.WidthValue.Size = New System.Drawing.Size(63, 20)
        Me.WidthValue.TabIndex = 4
        '
        'HeightValue
        '
        Me.HeightValue.Location = New System.Drawing.Point(153, 35)
        Me.HeightValue.Name = "HeightValue"
        Me.HeightValue.Size = New System.Drawing.Size(63, 20)
        Me.HeightValue.TabIndex = 5
        '
        'BackValue
        '
        Me.BackValue.Location = New System.Drawing.Point(153, 61)
        Me.BackValue.Name = "BackValue"
        Me.BackValue.Size = New System.Drawing.Size(211, 20)
        Me.BackValue.TabIndex = 6
        '
        'ForeValue
        '
        Me.ForeValue.Location = New System.Drawing.Point(153, 87)
        Me.ForeValue.Name = "ForeValue"
        Me.ForeValue.Size = New System.Drawing.Size(211, 20)
        Me.ForeValue.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(113, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Width"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Height"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(120, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "back"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(126, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "fore"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(275, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "width"
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.SelectedPath = "FolderBrowserDialog1"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(113, 156)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(264, 23)
        Me.ProgressBar.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(112, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Scanning html:"
        '
        'ScanFile
        '
        Me.ScanFile.Location = New System.Drawing.Point(192, 130)
        Me.ScanFile.Name = "ScanFile"
        Me.ScanFile.ReadOnly = True
        Me.ScanFile.Size = New System.Drawing.Size(185, 20)
        Me.ScanFile.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(254, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "EndTag"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(251, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "StartTag"
        '
        'EndTag
        '
        Me.EndTag.Location = New System.Drawing.Point(301, 35)
        Me.EndTag.Name = "EndTag"
        Me.EndTag.Size = New System.Drawing.Size(63, 20)
        Me.EndTag.TabIndex = 16
        '
        'StartTag
        '
        Me.StartTag.Location = New System.Drawing.Point(301, 9)
        Me.StartTag.Name = "StartTag"
        Me.StartTag.Size = New System.Drawing.Size(63, 20)
        Me.StartTag.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 220)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.EndTag)
        Me.Controls.Add(Me.StartTag)
        Me.Controls.Add(Me.ScanFile)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ForeValue)
        Me.Controls.Add(Me.BackValue)
        Me.Controls.Add(Me.HeightValue)
        Me.Controls.Add(Me.WidthValue)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Enchant Htmls"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents AboutButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents WidthValue As System.Windows.Forms.TextBox
    Friend WithEvents HeightValue As System.Windows.Forms.TextBox
    Friend WithEvents BackValue As System.Windows.Forms.TextBox
    Friend WithEvents ForeValue As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ScanFile As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents EndTag As System.Windows.Forms.TextBox
    Friend WithEvents StartTag As System.Windows.Forms.TextBox

End Class

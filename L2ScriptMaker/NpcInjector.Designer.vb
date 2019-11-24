<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class NpcInjector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcInjector))
        Me.OverwriteBox = New System.Windows.Forms.CheckBox
        Me.SplitButton = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.StatusBox = New System.Windows.Forms.TextBox
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.TargetFile = New System.Windows.Forms.TextBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SourceFile = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Quit = New System.Windows.Forms.Button
        Me.Inject = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.MergeButton = New System.Windows.Forms.Button
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OverwriteBox
        '
        Me.OverwriteBox.AutoSize = True
        Me.OverwriteBox.Location = New System.Drawing.Point(199, 97)
        Me.OverwriteBox.Name = "OverwriteBox"
        Me.OverwriteBox.Size = New System.Drawing.Size(67, 17)
        Me.OverwriteBox.TabIndex = 41
        Me.OverwriteBox.Text = "Overwrite"
        '
        'SplitButton
        '
        Me.SplitButton.Location = New System.Drawing.Point(118, 93)
        Me.SplitButton.Name = "SplitButton"
        Me.SplitButton.Size = New System.Drawing.Size(75, 23)
        Me.SplitButton.TabIndex = 38
        Me.SplitButton.Text = "Split"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(117, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Status:"
        '
        'StatusBox
        '
        Me.StatusBox.Location = New System.Drawing.Point(118, 161)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.ReadOnly = True
        Me.StatusBox.Size = New System.Drawing.Size(311, 20)
        Me.StatusBox.TabIndex = 36
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(118, 187)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(312, 23)
        Me.ProgressBar.TabIndex = 35
        '
        'TargetFile
        '
        Me.TargetFile.Location = New System.Drawing.Point(118, 67)
        Me.TargetFile.Name = "TargetFile"
        Me.TargetFile.ReadOnly = True
        Me.TargetFile.Size = New System.Drawing.Size(312, 20)
        Me.TargetFile.TabIndex = 34
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'SourceFile
        '
        Me.SourceFile.Location = New System.Drawing.Point(118, 28)
        Me.SourceFile.Name = "SourceFile"
        Me.SourceFile.ReadOnly = True
        Me.SourceFile.Size = New System.Drawing.Size(312, 20)
        Me.SourceFile.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(117, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Vien:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(117, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Injection:"
        '
        'Quit
        '
        Me.Quit.Location = New System.Drawing.Point(355, 120)
        Me.Quit.Name = "Quit"
        Me.Quit.Size = New System.Drawing.Size(75, 23)
        Me.Quit.TabIndex = 30
        Me.Quit.Text = "Quit"
        '
        'Inject
        '
        Me.Inject.Location = New System.Drawing.Point(354, 91)
        Me.Inject.Name = "Inject"
        Me.Inject.Size = New System.Drawing.Size(75, 23)
        Me.Inject.TabIndex = 29
        Me.Inject.Text = "Inject fix"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = L2ScriptMaker.My.Resources.Resources.Dragon
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(89, 198)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'MergeButton
        '
        Me.MergeButton.Location = New System.Drawing.Point(118, 119)
        Me.MergeButton.Name = "MergeButton"
        Me.MergeButton.Size = New System.Drawing.Size(75, 23)
        Me.MergeButton.TabIndex = 39
        Me.MergeButton.Text = "Merge"
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.SelectedPath = "FolderBrowserDialog1"
        '
        'NpcInjector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 224)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.TargetFile)
        Me.Controls.Add(Me.SourceFile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Quit)
        Me.Controls.Add(Me.Inject)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MergeButton)
        Me.Controls.Add(Me.OverwriteBox)
        Me.Controls.Add(Me.SplitButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcInjector"
        Me.Text = "NpcInjector"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OverwriteBox As System.Windows.Forms.CheckBox
    Friend WithEvents SplitButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents TargetFile As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SourceFile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Quit As System.Windows.Forms.Button
    Friend WithEvents Inject As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MergeButton As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
End Class

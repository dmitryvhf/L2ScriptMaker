<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptSyntacsisChecker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptSyntacsisChecker))
        Me.StartButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.QuitButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ReadLikeLineCheckBox = New System.Windows.Forms.CheckBox
        Me.ReadingFolderCheckBox = New System.Windows.Forms.CheckBox
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.UseMetod2CheckBox = New System.Windows.Forms.CheckBox
        Me.UseMetod1CheckBox = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Metod2TextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Metod1TextBox = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(129, 147)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 158)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(290, 147)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 2
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(126, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "(support all scripts)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(126, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(239, 16)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "simple script checker for known tag's"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 181)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(373, 22)
        Me.StatusStrip.TabIndex = 53
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(200, 16)
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'ReadLikeLineCheckBox
        '
        Me.ReadLikeLineCheckBox.AutoSize = True
        Me.ReadLikeLineCheckBox.Location = New System.Drawing.Point(6, 6)
        Me.ReadLikeLineCheckBox.Name = "ReadLikeLineCheckBox"
        Me.ReadLikeLineCheckBox.Size = New System.Drawing.Size(164, 30)
        Me.ReadLikeLineCheckBox.TabIndex = 54
        Me.ReadLikeLineCheckBox.Text = "Reading full file (use for Html)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(default, reading like one line)"
        Me.ReadLikeLineCheckBox.UseVisualStyleBackColor = True
        '
        'ReadingFolderCheckBox
        '
        Me.ReadingFolderCheckBox.AutoSize = True
        Me.ReadingFolderCheckBox.Location = New System.Drawing.Point(6, 42)
        Me.ReadingFolderCheckBox.Name = "ReadingFolderCheckBox"
        Me.ReadingFolderCheckBox.Size = New System.Drawing.Size(131, 17)
        Me.ReadingFolderCheckBox.TabIndex = 55
        Me.ReadingFolderCheckBox.Text = "Reading file in folder..."
        Me.ReadingFolderCheckBox.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(129, 44)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(236, 97)
        Me.TabControl1.TabIndex = 56
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ReadLikeLineCheckBox)
        Me.TabPage1.Controls.Add(Me.ReadingFolderCheckBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(228, 71)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Mode"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.UseMetod2CheckBox)
        Me.TabPage2.Controls.Add(Me.UseMetod1CheckBox)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Metod2TextBox)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Metod1TextBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(228, 71)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'UseMetod2CheckBox
        '
        Me.UseMetod2CheckBox.AutoSize = True
        Me.UseMetod2CheckBox.Location = New System.Drawing.Point(167, 34)
        Me.UseMetod2CheckBox.Name = "UseMetod2CheckBox"
        Me.UseMetod2CheckBox.Size = New System.Drawing.Size(45, 17)
        Me.UseMetod2CheckBox.TabIndex = 5
        Me.UseMetod2CheckBox.Text = "Use"
        Me.UseMetod2CheckBox.UseVisualStyleBackColor = True
        '
        'UseMetod1CheckBox
        '
        Me.UseMetod1CheckBox.AutoSize = True
        Me.UseMetod1CheckBox.Checked = True
        Me.UseMetod1CheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseMetod1CheckBox.Location = New System.Drawing.Point(167, 8)
        Me.UseMetod1CheckBox.Name = "UseMetod1CheckBox"
        Me.UseMetod1CheckBox.Size = New System.Drawing.Size(45, 17)
        Me.UseMetod1CheckBox.TabIndex = 4
        Me.UseMetod1CheckBox.Text = "Use"
        Me.UseMetod1CheckBox.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Metod 2:"
        '
        'Metod2TextBox
        '
        Me.Metod2TextBox.Location = New System.Drawing.Point(61, 32)
        Me.Metod2TextBox.Name = "Metod2TextBox"
        Me.Metod2TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Metod2TextBox.TabIndex = 2
        Me.Metod2TextBox.Text = """"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Metod 1:"
        '
        'Metod1TextBox
        '
        Me.Metod1TextBox.Location = New System.Drawing.Point(61, 6)
        Me.Metod1TextBox.Name = "Metod1TextBox"
        Me.Metod1TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Metod1TextBox.TabIndex = 0
        Me.Metod1TextBox.Text = "[],{},<>"
        '
        'ScriptSyntacsisChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 203)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScriptSyntacsisChecker"
        Me.Text = "Script Syntax Checker"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ReadLikeLineCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ReadingFolderCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Metod2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Metod1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents UseMetod2CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents UseMetod1CheckBox As System.Windows.Forms.CheckBox
End Class

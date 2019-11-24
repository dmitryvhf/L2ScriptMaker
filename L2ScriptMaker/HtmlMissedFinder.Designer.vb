<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HtmlMissedFinder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HtmlMissedFinder))
        Me.CurActionLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.HtmlDirCheckBox = New System.Windows.Forms.CheckBox
        Me.WriteFullCheckBox = New System.Windows.Forms.CheckBox
        Me.IgnoreMissDupCheckBox = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.CreateHtmBox = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CurActionLabel
        '
        Me.CurActionLabel.AutoSize = True
        Me.CurActionLabel.Location = New System.Drawing.Point(12, 186)
        Me.CurActionLabel.Name = "CurActionLabel"
        Me.CurActionLabel.Size = New System.Drawing.Size(0, 13)
        Me.CurActionLabel.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Current action:"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 202)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(270, 23)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 56
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(207, 147)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 60
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(126, 147)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 59
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(154, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "(support C4 scripts)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(154, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Missed Html Finder"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 158)
        Me.PictureBox1.TabIndex = 55
        Me.PictureBox1.TabStop = False
        '
        'CheckedListBox
        '
        Me.CheckedListBox.FormattingEnabled = True
        Me.CheckedListBox.Items.AddRange(New Object() {"ai.obj", "npcdata.txt", "itemdata.txt"})
        Me.CheckedListBox.Location = New System.Drawing.Point(6, 9)
        Me.CheckedListBox.Name = "CheckedListBox"
        Me.CheckedListBox.Size = New System.Drawing.Size(89, 49)
        Me.CheckedListBox.TabIndex = 63
        '
        'HtmlDirCheckBox
        '
        Me.HtmlDirCheckBox.AutoSize = True
        Me.HtmlDirCheckBox.Location = New System.Drawing.Point(9, 61)
        Me.HtmlDirCheckBox.Name = "HtmlDirCheckBox"
        Me.HtmlDirCheckBox.Size = New System.Drawing.Size(79, 17)
        Me.HtmlDirCheckBox.TabIndex = 64
        Me.HtmlDirCheckBox.Text = "Html Folder"
        Me.HtmlDirCheckBox.UseVisualStyleBackColor = True
        '
        'WriteFullCheckBox
        '
        Me.WriteFullCheckBox.AutoSize = True
        Me.WriteFullCheckBox.Location = New System.Drawing.Point(6, 6)
        Me.WriteFullCheckBox.Name = "WriteFullCheckBox"
        Me.WriteFullCheckBox.Size = New System.Drawing.Size(120, 17)
        Me.WriteFullCheckBox.TabIndex = 65
        Me.WriteFullCheckBox.Text = "Write full debug info"
        Me.WriteFullCheckBox.UseVisualStyleBackColor = True
        '
        'IgnoreMissDupCheckBox
        '
        Me.IgnoreMissDupCheckBox.AutoSize = True
        Me.IgnoreMissDupCheckBox.Checked = True
        Me.IgnoreMissDupCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IgnoreMissDupCheckBox.Location = New System.Drawing.Point(6, 25)
        Me.IgnoreMissDupCheckBox.Name = "IgnoreMissDupCheckBox"
        Me.IgnoreMissDupCheckBox.Size = New System.Drawing.Size(102, 30)
        Me.IgnoreMissDupCheckBox.TabIndex = 66
        Me.IgnoreMissDupCheckBox.Text = "Ignore duplicate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "missed html"
        Me.IgnoreMissDupCheckBox.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(126, 34)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(156, 107)
        Me.TabControl1.TabIndex = 67
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckedListBox)
        Me.TabPage1.Controls.Add(Me.HtmlDirCheckBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(148, 81)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Check items"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CreateHtmBox)
        Me.TabPage2.Controls.Add(Me.WriteFullCheckBox)
        Me.TabPage2.Controls.Add(Me.IgnoreMissDupCheckBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(148, 81)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CreateHtmBox
        '
        Me.CreateHtmBox.AutoSize = True
        Me.CreateHtmBox.Location = New System.Drawing.Point(6, 61)
        Me.CreateHtmBox.Name = "CreateHtmBox"
        Me.CreateHtmBox.Size = New System.Drawing.Size(114, 17)
        Me.CreateHtmBox.TabIndex = 67
        Me.CreateHtmBox.Text = "Create missed html"
        Me.CreateHtmBox.UseVisualStyleBackColor = True
        '
        'HtmlMissedFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 235)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CurActionLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HtmlMissedFinder"
        Me.Text = "Html Missed Finder"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CurActionLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HtmlDirCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents WriteFullCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IgnoreMissDupCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CreateHtmBox As System.Windows.Forms.CheckBox
End Class
